#include "SueController.h"
#include <iostream>

SueInfo* SueInfo::sueInfo=nullptr;

float manhattanDistance2(std::pair<int,int> a,std::pair<int,int> b){
	return abs((a.first-b.first)) +abs((a.second-b.second));
}

SueController::SueController(std::shared_ptr<Character> character):
	Controller(character), root(std::make_shared<Selector>()){
	
	//Va a la pildora si hay pildoras
	auto goToPill = std::make_shared<Filter>();
	goToPill->addCondition(std::make_shared<SueIfPill>());
	goToPill->addAction(std::make_shared<SueGoToPill>());
	root->addChild(goToPill);

	//Si es comible, ve si está a menos de 500 de distancia de Pacman, si es así, se aleja
	auto frightenedFarther = std::make_shared<Sequence>();
	frightenedFarther->addChild(std::make_shared<SuePowerPill>());
	frightenedFarther->addChild(std::make_shared<SueKeepDistance>());
	frightenedFarther->addChild(std::make_shared<SueGetsAway>());
	root->addChild(frightenedFarther);

	//Si es comible, ve si está a más de 500 de distancia de Pacman, si es así, se acerca
	auto frightenedCloser = std::make_shared<Sequence>();
	frightenedCloser->addChild(std::make_shared<SuePowerPill>());
	frightenedCloser->addChild(std::make_shared<SueGetsCloser>());
	frightenedCloser->addChild(std::make_shared<SueChase>());
	root->addChild(frightenedCloser);

	//Persigue a Pacman
	root->addChild(std::make_shared<SueChase>());
}

SueController::~SueController() {

}

Move SueController::getMove(const GameState& gs){
	SueInfo::getSueInfo()->in_character = character;	
	SueInfo::getSueInfo()->in_gamestate = &gs;
	root -> tick();

	return SueInfo::getSueInfo()->out_move;
}

Status SueKeepDistance::update() //Se aleja
{
	auto character = SueInfo::getSueInfo()->in_character; 
	auto gs = SueInfo::getSueInfo()->in_gamestate; 
	auto target= gs->getMaze().getNodePos(gs->getPacmanPos()); 
	auto myPos = gs->getMaze().getNodePos(character->getPos()); 

	float distGtP = euclid2(myPos, target); //Distancia entre Sue y Pacman

	if(distGtP < 500) //Va a gets SueGetsAway si está a menos de 500 de Pacman
	{
		return BH_SUCCESS;
	}
	else{
		return BH_FAILURE;
	}
}

Status SueGetsCloser::update() //Se Scerca
{
	auto character = SueInfo::getSueInfo()->in_character;
	auto gs = SueInfo::getSueInfo()->in_gamestate;
	auto target= gs->getMaze().getNodePos(gs->getPacmanPos());
	auto myPos = gs->getMaze().getNodePos(character->getPos());

	float distGtP = euclid2(myPos, target); //Distancia entre Sue y Pacman

	if(distGtP > 500) //Va a gets SueChase si está a más de 500 de Pacman
	{
		return BH_SUCCESS;
	}
	else{
		return BH_FAILURE;
	}
}

SueIfPill::SueIfPill() : Behavior()
{
	pills = 0;
}

Status SueIfPill::update() //Revisa si quedan PowerPills en el mapa
{
	auto gs = SueInfo::getSueInfo()->in_gamestate;

	for([[maybe_unused]] auto&_ :gs->getMaze().getPowerPillPositions()) //Cuenta las PowerPills que quedan
	{
		pills++;
	}

	if(pills > 0) //Si quedan PowerPills, va a la más cercana a Pacman
	{
		pills = 0;
		return BH_SUCCESS;
	}
	else{
		return BH_FAILURE;
	}
}

Status SueChase::update() //Se acerca
{
	auto character = SueInfo::getSueInfo()->in_character;
	auto gs = SueInfo::getSueInfo()->in_gamestate;
	auto target = gs->getMaze().getNodePos(gs->getPacmanPos());
	float min = 1000000000;

	Move minMove = PASS;

	std::vector<Move> moves;

	if(character->getDirection() == PASS)
	{
		moves = gs->getMaze().getPossibleMoves(character->getPos());
	}
	else{
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(), character->getDirection());
	}

	for(auto move:moves)
	{
		if(move == PASS)
		{
			continue;
		}
		float dist = euclid2(target, gs->getMaze().getNodePos(gs->getMaze().getNeighbour(character->getPos(),move)));
		if(dist<min)
		{
			min = dist;
			minMove = move;
		}
	}
	SueInfo::getSueInfo()->out_move = minMove;
	return BH_SUCCESS;
}

Status SuePowerPill::update()
{
	auto character = SueInfo::getSueInfo()->in_character;
	auto ghost = dynamic_cast<Ghost*>(character.get());

	if(ghost != nullptr && ghost->isEdible())
	{
		return BH_SUCCESS;
	}
	else{
		return BH_FAILURE;
	}
}

SueGetsAway::SueGetsAway() : Behavior(), e(rand()), uniform_dist(0,3)
{

}

Status SueGetsAway::update() //Se aleja (frightened)
{
	auto character = SueInfo::getSueInfo()->in_character;
	auto gs = SueInfo::getSueInfo()->in_gamestate;
	auto target= gs->getMaze().getNodePos(gs->getPacmanPos());
	float max = 0;

	Move maxMove=PASS;
	std::vector<Move> moves;

	if(character->getDirection() == PASS)
	{
		moves = gs->getMaze().getPossibleMoves(character->getPos());
	}
	else{
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(), character->getDirection());
	}

	for(auto move:moves) 
	{
		if(move==PASS) {
			continue;
		}
		float dist = euclid2(target, gs->getMaze().getNodePos(gs->getMaze().getNeighbour(character->getPos(),move)));

		if(dist>max) {			
			max=dist;
			maxMove=move;
		}
	}

	SueInfo::getSueInfo()->out_move = maxMove;
	return BH_SUCCESS;
}

SueGoToPill::SueGoToPill() : Behavior()
{
	target = std::make_pair(-1,-1);
}

Status SueGoToPill::update() //Va a la PowerPill más cercana a Pacman
{
	auto character = SueInfo::getSueInfo()->in_character;
	auto gs = SueInfo::getSueInfo()->in_gamestate;
	auto target = gs->getMaze().getNodePos(gs->getPacmanPos());

	Move minMove = PASS;
	std::vector<Move> moves;

	if(character->getDirection() == PASS)
	{
		moves = gs->getMaze().getPossibleMoves(character->getPos());
	}
	else{
		moves = gs->getMaze().getGhostLegalMoves(character->getPos(),character->getDirection());
	}

	float min = 100000000;
	float minPill = 100000000;
	float distPill; //Distancia de pacman a PowerPill
	std::pair<int, int> targetPill; //Coordenada de PowerPill
	
	for(auto pillPos:gs->getMaze().getPowerPillPositions()) //Consigue la coordenada de la PowerPill más cercana a Pacman
	{
		distPill = euclid2(target, pillPos);
		if(distPill < minPill)
		{
			minPill = distPill;
			targetPill = pillPos;		
		} 
	}
	for(auto move:moves)
	{	
		if(move == PASS)
		{
			break;
		}

		else{
			//Distancia a la PowerPill con cada dirección
			float dist = euclid2(targetPill, gs->getMaze().getNodePos(gs->getMaze().getNeighbour(character->getPos(),move)));
			
			if(dist<min) //Consigue el camino más cercano a la PowerPill
			{
				min = dist;
				minMove = move;
			}
			SueInfo::getSueInfo()->out_move = minMove;
		}

	}
	return BH_SUCCESS;
}