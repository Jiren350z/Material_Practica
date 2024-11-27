#include "PinkyController.h"
#include <iostream>
#include <cstdlib> 


float manhattanDistance(std::pair<int,int> a,std::pair<int,int> b){
    return abs((a.first-b.first)) +abs((a.second-b.second));
}
std::pair<int, int> FiveDistanceBlock(const GameState& game){
	const auto pacmanDir=game.getPacmanDir();
	auto trapCoord=game.getMaze().getNodePos(game.getPacmanPos());
	switch (pacmanDir)
	{
	case 0:
		if(trapCoord.second-(3*5)>=-2){
			trapCoord.second-=(3*5);
		}
		break;
	case 1:
		if(trapCoord.first+(3*5)<=110){
			trapCoord.first+=(3*5);
		}
		break;
	case 2:
		if(trapCoord.second+(3*5)<=122){
			trapCoord.second+=(3*5);
		}
		break;
	case 3:
		if(trapCoord.first-(3*5)>=-2){
			trapCoord.first-=(3*5);
		}
		break;		
	default:
		break;
	}
	return trapCoord;
}

PinkyController::PinkyController(std::shared_ptr<Character> character):
	Controller(character),
	fsm(std::make_shared<PinkyStateMachine>(character)){
}

PinkyController::~PinkyController() {

}

Move PinkyController::getMove(const GameState& game){
	return fsm->update(game);		
}
///////                                                                  //////////
/////************************************* States *************************////////
///////                                                                  //////////
///////////////////////////////ChaseState///////////////////////////////////////
PinkyChaseState::PinkyChaseState(std::shared_ptr<Character> _character):FSMState(_character){

}

void PinkyChaseState::onEnter(const GameState& ){//revert when entering state
	//std::dynamic_pointer_cast<Ghost>(character)->revert();
}

Move PinkyChaseState::onUpdate(const GameState& game){
	//cantidad de movimientos
	std::vector<Move> moves;
	//coordenadas del pacman
	auto pacmanCoord=game.getMaze().getNodePos(game.getPacmanPos());
	//coordenadas de los 5 bloques que estan adelante de la direccion de pacman
	auto trapCoord=FiveDistanceBlock(game);
	//indice del fantasma
	const auto myPos=character->getPos();

	if(character->getDirection()==PASS){		//Primer movimiento
		moves=game.getMaze().getPossibleMoves(myPos);
	}else{										//cuando ya se esta moviendo
		moves=game.getMaze().getGhostLegalMoves(myPos,character->getDirection());
	}
	
	// calcular la distancia entre el fantasma y pacman
	float min=euclid2(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[0])),
			pacmanCoord);
	int minI=0;

	// calcular la distancia entre el fantasma y los 5 bloques que estan adelante de la direccion de pacman
	float _min=euclid2(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[0])),
			trapCoord);
	int _minI=0;
	
	//for para escoger el mejor movimiento del fantasma hacia pacman
	for(unsigned int i=1;i<moves.size();i++){
		auto dist=euclid2(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[i])),
			pacmanCoord);
		if(dist<min){
			min=dist;
			minI=i;
		}
	}

	//for para escoger el mejor movimiento del fantasma hacia los 5 bloques que estan adelante de la direccion de pacman
	for(unsigned int i=1;i<moves.size();i++){
		auto dist=euclid2(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[i])),
			trapCoord);
		if(dist<_min){
			_min=dist;
			_minI=i;
		}
	}
	
	//dependiendo de la distancia, se escojera entre la pocicion de pacman o sus 5 bloques de distancia 
	if(abs(_min-min)>=500&&_min-min==0){
		return moves[_minI];
	}else
		return moves[minI];
}
PinkyChaseState::~PinkyChaseState(){

}

///////////////////////////////FrightState///////////////////////////////////////
PinkyFrightState::PinkyFrightState(std::shared_ptr<Character> _character):FSMState(_character){

}

void PinkyFrightState::onEnter(const GameState& ){//revert when entering state
	//std::dynamic_pointer_cast<Ghost>(character)->revert();
}

Move PinkyFrightState::onUpdate(const GameState& game){
	//cantidad de movimientos
	std::vector<Move> moves;
	//coordenadas del pacman
	auto pacmanCoord=game.getMaze().getNodePos(game.getPacmanPos());
	//indice del fantasma
	const auto myPos=character->getPos();

	if(character->getDirection()==PASS){		//Primer movimiento
		moves=game.getMaze().getPossibleMoves(myPos);
	}else{										//cuando ya se esta moviendo
		moves=game.getMaze().getGhostLegalMoves(myPos,character->getDirection());
	}

	// calcular la distancia entre el fantasma y pacman
	float min=euclid2(
		game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[0])),
			pacmanCoord);
	int minI=0;

	//for para escoger el movimiento mas lejano del fantasma hacia pacman
	for(unsigned int i=1;i<moves.size();i++){
		auto dist=euclid2(
			game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[i])),
			pacmanCoord);
		//if para hacer que el fantama no se aleje demasiado de pacman
		if(min>4000){
			if(dist<min){
				min=dist;
				minI=i;
			}
		}else{
			if(dist>min){
				min=dist;
				minI=i;
			}
		}
		
	}
	return moves[minI];
}
PinkyFrightState::~PinkyFrightState(){

}

PinkyScatterState::PinkyScatterState(std::shared_ptr<Character> _character):FSMState(_character){

}

void PinkyScatterState::onEnter(const GameState& ){//revert when entering state
	//std::dynamic_pointer_cast<Ghost>(character)->revert();
}

Move PinkyScatterState::onUpdate(const GameState& game){
	//cantidad de movimientos
	std::vector<Move> moves;
	//coordenadas de la meta
	const auto goal=std::pair<int,int>(4,4);
	//indice del fantasma
	const auto myPos=character->getPos();

	if(character->getDirection()==PASS){		//Primer movimiento
		moves=game.getMaze().getPossibleMoves(myPos);
	}else{										//cuando ya se esta moviendo
		moves=game.getMaze().getGhostLegalMoves(myPos,character->getDirection());
	}

	// calcular la distancia entre el fantasma y el objetivo
	float min=euclid2(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[0])),goal);
	int minI=0;

	//for para escoger el movimiento cercano al objetivo
	for(unsigned int i=1;i<moves.size();i++){
		auto dist=euclid2(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[i])),goal);
		if(dist<min){
			min=dist;
			minI=i;
		}
	}
	return moves[minI];
}
PinkyScatterState::~PinkyScatterState(){

}

///////////////////////////////InitialPointState///////////////////////////////////////
PinkyInitialPointState::PinkyInitialPointState(std::shared_ptr<Character> _character):FSMState(_character){

}

void PinkyInitialPointState::onEnter(const GameState& ){//revert when entering state
	//std::dynamic_pointer_cast<Ghost>(character)->revert();
}

Move PinkyInitialPointState::onUpdate(const GameState& game){
	//cantidad de movimientos
	std::vector<Move> moves;
	//coordenadas de la meta
	const auto goal=std::pair<int,int>(96,44);
	//indice del fantasma
	const auto myPos=character->getPos();

	if(character->getDirection()==PASS){		//Primer movimiento
		moves=game.getMaze().getPossibleMoves(myPos);
	}else{										//cuando ya se esta moviendo
		moves=game.getMaze().getGhostLegalMoves(myPos,character->getDirection());
	}

	// calcular la distancia entre el fantasma y el objetivo
	float min=manhattanDistance(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[0])),goal);
	int minI=0;

	//for para escoger el movimiento cercano al objetivo
	for(unsigned int i=1;i<moves.size();i++){
		float dist=manhattanDistance(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[i])),goal);
		if(dist<min){
			min=dist;
			minI=i;
		}
	}
	return moves[minI];
}
PinkyInitialPointState::~PinkyInitialPointState(){

}
///////                                                                  ///////////
//////***************************** Transition **************************////////
///////                                                                  ///////////


///////////////////////////////////FrightTransition///////////////////////////////
PinkyFrightTransition::PinkyFrightTransition(std::shared_ptr<FSMState> next,
								std::shared_ptr<Character> character,
								bool toFright,int *FFS):_next(next),_character(character),_toFright(toFright),_FFS(FFS){
	
}

bool PinkyFrightTransition::isValid(const GameState& gs){

	//si el fantasma es edible, pasara a fright, sino pasara a chase
	if(_toFright==gs.isGhostEdible(2)){
		//reinicio el tiempo para que vuelva a chase y no a scatter
		*_FFS=1;
		return true;
	}else{
		return false;
	}
	
}
std::shared_ptr<FSMState>PinkyFrightTransition::getNextState(){
	return _next;
}

///////////////////////////////////ScatterTransition///////////////////////////////

PinkyScatterTransition::PinkyScatterTransition(std::shared_ptr<FSMState> next,
								std::shared_ptr<Character> character,
								int *FFs
								):_next(next),_character(character),_FFS(FFs){
	
}

bool PinkyScatterTransition::isValid(const GameState& gs){
	//no necesito el gs
	(void)gs;

	float Tiempo=(float)*_FFS/30;
	
	//si aun no pasan 20 segundos estara en chase, sino va a la trancicion de scatter 
	if((Tiempo<20)){
		
		return false;
	}
	
	if(Tiempo>27){
		//reinicio el tiempo para que vuelva a chase
		*_FFS=1;
	}
	return true;
}
std::shared_ptr<FSMState>PinkyScatterTransition::getNextState(){
	return _next;
}

///////////////////////////////////InitialPointTransition///////////////////////////////

PinkyInitialPointTransition::PinkyInitialPointTransition(std::shared_ptr<FSMState> next,
								std::shared_ptr<Character> character								
								):_next(next),_character(character){
	
}

bool PinkyInitialPointTransition::isValid(const GameState& gs){
	
	auto goal=std::pair<int,int>(96,44);
	
	//si llega al punto solicitado pasara a chase
	if(gs.getMaze().getNodePos(std::dynamic_pointer_cast<Ghost>(_character)->getPos())==goal){
		_arrivePlace=true;
	}
	if(_arrivePlace){
		return false;
	}else{
		return true;
	}

}
std::shared_ptr<FSMState>PinkyInitialPointTransition::getNextState(){
	return _next;
}

///////                                                                  ///////////
///////************************ PinkyStateMachine ***********************///////////
///////                                                                  ///////////
PinkyStateMachine::PinkyStateMachine(std::shared_ptr<Character> _character):FiniteStateMachine(_character){
	
	//estados
	auto chase =std::make_shared<PinkyChaseState>(character);
	auto fright =std::make_shared<PinkyFrightState>(character);
	auto scatter =std::make_shared<PinkyScatterState>(character);
	auto initialPoint =std::make_shared<PinkyInitialPointState>(character);
	timer=1;

	//transiciones
	chase->addTransition(std::make_shared<PinkyFrightTransition>(fright,_character,true,&timer));
	scatter->addTransition(std::make_shared<PinkyFrightTransition>(fright,_character,true,&timer));
	fright->addTransition(std::make_shared<PinkyFrightTransition>(chase,_character,false,&timer));
	chase->addTransition(std::make_shared<PinkyScatterTransition>(scatter,_character,&timer));
	scatter->addTransition(std::make_shared<PinkyScatterTransition>(chase,_character,&timer));
	chase->addTransition(std::make_shared<PinkyInitialPointTransition>(initialPoint,_character));
	initialPoint->addTransition(std::make_shared<PinkyInitialPointTransition>(chase,_character));

	initialState=chase;
	activeState=chase;

	
	states.push_back(scatter);
	states.push_back(initialPoint);
	states.push_back(chase);
	states.push_back(fright);
	
}



Move PinkyStateMachine::update(const GameState& gs){
	//incrementa el contador de tiempo
	timer++;

	auto t=activeState->getActiveTransition(gs);
	if(t!=nullptr){
		activeState->onExit(gs);
		t->onTransition(gs);
		activeState=t->getNextState();
		activeState->onEnter(gs);
	}
	return activeState->onUpdate(gs);
}
//

PinkyStateMachine::~PinkyStateMachine(){

}