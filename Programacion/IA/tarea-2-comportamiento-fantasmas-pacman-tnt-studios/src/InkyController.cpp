#include "InkyController.h"
#include "PinkyController.h"
#include <iostream>
#include <unordered_map>
#include <vector>
#include <cmath>

InfoInky* InfoInky::info=nullptr;

float manhattanDistanceInky(std::pair<int,int> a,std::pair<int,int> b){
	return abs((a.first-b.first)) +abs((a.second-b.second));
}


InkyController::InkyController(std::shared_ptr<Character> character):
	Controller(character),root(std::make_shared<Selector>()){

	// creacion de HomeAction, es la primera en comenzar
	auto beginning = std::make_shared<Filter>();
	beginning->addCondition(std::make_shared<BeginingCondition>());
	beginning->addAction(std::make_shared<HomeAction>());
	// movimiento forzado a la derecha o arriba
	auto forceMovement = std::make_shared<Filter>();
	forceMovement -> addCondition(std::make_shared<TimeOutCondition>());
	forceMovement-> addCondition(std::make_shared<ForceMovementAction>());
	// creacion de frightered para escapar
	auto frigtered = std::make_shared<Filter>();
	frigtered->addCondition(std::make_shared<IamBlueCondition>());
	frigtered->addAction(std::make_shared<FrighteredAction>());
	//se annaden a la raiz
	root->addChild(frigtered);
	root -> addChild(forceMovement);
	root->addChild(beginning);
	root->addChild(std::make_shared<ChaseAction>());

}

InkyController::~InkyController() {
}

Move InkyController::getMove(const GameState& game){
	InfoInky::getInfoInky()->in_Inky = character;
	InfoInky::getInfoInky()->in_gamestate=&game;
	root->tick();

	return InfoInky::getInfoInky()->out_move;
	//return PASS;		
}
ForceMovementAction :: ForceMovementAction() : Behavior(){
	target = std::make_pair(-1,-1);
}

FrighteredAction::FrighteredAction() : Behavior(){
	target = std::make_pair(-1,-1); 
}

HomeAction::HomeAction():Behavior(){
	target = std::make_pair(-1,-1); 
}

//condicion y update para frightered
IamBlueCondition::IamBlueCondition() : Behavior(){
}
Status IamBlueCondition::update(){
	IamBLue = std::dynamic_pointer_cast<Ghost>(InfoInky::getInfoInky()->in_Inky)->isEdible();

	if(IamBLue){
		return BH_SUCCESS;
	}else{
		return BH_FAILURE;
	}
}
// condicion y update para Home
BeginingCondition::BeginingCondition() : Behavior(){
	PtjisLower=false;
}

Status BeginingCondition::update(){
	auto game = InfoInky::getInfoInky()->in_gamestate;
	int ptj= game->getScore();
	if(ptj<300)
	{
		return BH_SUCCESS;
	}else{
		return BH_FAILURE;
	}

}
// update y condicion para Forcemovement
TimeOutCondition::TimeOutCondition() : Behavior(){
	lastTime =0;
}
Status TimeOutCondition::update(){	
	lastTime++;
	float timeStamp= lastTime/30;

	if((int)timeStamp%15 <1){		
		return BH_SUCCESS;
	}else{
		return BH_FAILURE;
	}
	
}
//asigna la la esquina inferior derecha
//y se dirige a esa esquina al comenzar la partida
Status HomeAction::update(){
	//std::cerr << " Home \n" ;
	if(target.first == -1){
		target = InfoInky::getInfoInky()->in_gamestate->getMaze().getPowerPillPositions()[0];//esquina inferior derecha
	}

	auto character = InfoInky::getInfoInky()->in_Inky;
	auto gs = InfoInky::getInfoInky()->in_gamestate;

	Move minMove=PASS;
	std::vector<Move> moves;
	if(character->getDirection()==PASS) {
		moves=gs->getMaze().getPossibleMoves(character->getPos());
	} else {
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(), character->getDirection());
	}

	float min=100000000;
	for(auto move:moves) {
		if(move==PASS) {
			break;
		}
		float dist = manhattanDistanceInky(target,gs->getMaze().getNodePos(gs->getMaze().getNeighbour(character->getPos(),move)));
		if(dist<min) {
			min=dist;
			minMove=move;
		}
	}
	InfoInky::getInfoInky()->out_move = minMove;
	return BH_SUCCESS;
}
//si pacman comio una power pill este se dirige por el camino mas largo
//hacia el por lo que se aleja
Status FrighteredAction::update(){
	//std::cerr << " Frightered \n" ;
	auto character = InfoInky::getInfoInky()->in_Inky;
	auto gs = InfoInky::getInfoInky()->in_gamestate;
	auto target= gs->getMaze().getNodePos(gs->getPacmanPos());
	float max=0;
	Move maxMove=PASS;
	std::vector<Move> moves;
	int i=0;
	if(character->getDirection()==PASS) {
		moves=gs->getMaze().getPossibleMoves(character->getPos());
	} else {
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(), character->getDirection());
	}

	for(auto move:moves) {
		if(move==PASS) {
			break;
		}
		float dist = manhattanDistanceInky(target,gs->getMaze().getNodePos(gs->getMaze().getNeighbour(character->getPos(),move)));
		if(dist>max) {
			max=dist;
			maxMove=move;
			
		}
		i++;
		if(i==2)
		{
			break;
		}
	}
	
	InfoInky::getInfoInky()->out_move = maxMove;
	return BH_SUCCESS;
}
//Perseguir a Pacman
Status ChaseAction::update(){
	//std::cerr << " Chase \n" ;
	auto character = InfoInky::getInfoInky()->in_Inky;
	auto gs = InfoInky::getInfoInky()->in_gamestate;
	
	auto target= gs->getMaze().getNodePos(gs->getPacmanPos());
	

	float min=1000000000;
	
	Move minMove=PASS;
	std::vector<Move> moves;

	if(character->getDirection()==PASS) {
		moves=gs->getMaze().getPossibleMoves(character->getPos());
		
	} else {
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(), character->getDirection());
	}

	for(auto move:moves) {
		if(move==PASS) {
			break;
		}
		float dist = manhattanDistanceInky(target,gs->getMaze().getNodePos(gs->getMaze().getNeighbour(character->getPos(),move)));
		if(dist<min) {
			min=dist;
			minMove=move;
		}
		
	}
	InfoInky::getInfoInky()->out_move = minMove;
	return BH_SUCCESS;
}
//valida los mov legales para realizar un movimiento a la derecha o arriba
//sirve para aleatorizar sus movimientos
//en complemento con sue que se mueve a la izquierda o abajo
Status ForceMovementAction::update(){
	auto character = InfoInky::getInfoInky()->in_Inky;
	auto gs = InfoInky::getInfoInky()->in_gamestate;
	auto target= gs->getMaze().getNodePos(gs->getPacmanPos());
	auto myPos= gs->getMaze().getNodePos(character->getPos());
//	auto PacmanPos=gs->getMaze().getNodePos(gs->getPacmanPos());
	float min=1000000000;
	Move minMove=PASS;
	std::vector<Move> moves;
	if(character->getDirection()==PASS) {
		//moves=gs->getMaze().getPossibleMoves(character->getPos());
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(), character->getDirection());
	} else {
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(), character->getDirection());
		//moves=gs->getMaze().getPossibleMoves(character->getPos());
	}

	for(auto move:moves) {
		
		if(move==PASS) {
			break;
		}else if(target.first<myPos.first && target.second>myPos.second){ //primer caso 
			if(move==RIGHT)
			{
				InfoInky::getInfoInky()->out_move = RIGHT;
				//std::cerr << " primer caso  \n" ;
			}
			
		}else if(target.first==myPos.first&& target.second>myPos.second){//segundo caso
			if(move==RIGHT)
			{
				InfoInky::getInfoInky()->out_move = RIGHT;
				//std::cerr << " segundo caso  \n" ;
			}
			
		}else if(target.first>myPos.first&& target.second>myPos.second){//tercer caso
			if(move==RIGHT)
			{
				InfoInky::getInfoInky()->out_move = RIGHT;
				//std::cerr << " tercer caso  \n" ;
			}
			
		}else if(target.first<myPos.first&& target.second==myPos.second){// cuarto caso
			if(move==DOWN)
			{
				InfoInky::getInfoInky()->out_move = DOWN;
				//std::cerr << " cuarto caso \n" ;
			}
			
		}else if(target.first>myPos.first&& target.second==myPos.second){// quinto caso
			if(move==DOWN)
			{
				InfoInky::getInfoInky()->out_move = DOWN;
				//std::cerr << " quinto caso  \n" ;
			}
			
		}else if(target.first<myPos.first&& target.second<myPos.second){ // sexto caso
			if(move==RIGHT)
			{
				InfoInky::getInfoInky()->out_move = RIGHT;
				//std::cerr << " sexto caso  \n" ;
			}
			
		}else if(target.first==myPos.first&& target.second<myPos.second){//septimo caso
			if(move==RIGHT)
			{
				InfoInky::getInfoInky()->out_move = RIGHT;
				//std::cerr << " septimo caso  \n" ;
			}
			
		}else if(target.first>myPos.first&& target.second<myPos.second){//octavo caso
			if(move==RIGHT)
			{
				InfoInky::getInfoInky()->out_move = RIGHT;
				//std::cerr << " octavo caso  \n" ;
			}
			
		}else
		{
			float dist = euclid2(target,gs->getMaze().getNodePos(gs->getMaze().getNeighbour(character->getPos(),move)));
		if(dist<min) {
			min=dist;
			minMove=move;
		}
			InfoInky::getInfoInky()->out_move = minMove;
		}
	}
	return BH_SUCCESS;
	
	
}
