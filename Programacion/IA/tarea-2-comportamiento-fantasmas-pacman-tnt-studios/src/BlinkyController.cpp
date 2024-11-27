#include "BlinkyController.h"
#include <iostream>
#include <climits> 

//heuristica de manhattan para calculo de distancias
float BlinkyManhattan(std::pair<int,int> a,std::pair<int,int> b){
	return abs((a.first-b.first) + abs((a.second-b.second)));
}

//constructor del controlador de blinky
BlinkyController::BlinkyController(std::shared_ptr<Character> character):
	Controller(character),
	bfsm(std::make_shared<BlinkyFiniteStateMachine>(character)){
}

//destructor del controlador de blinky
BlinkyController::~BlinkyController() {

}

//obtener el movimiento de blinky basado en el estado actual del juego
Move
BlinkyController::getMove(const GameState& game){
	return bfsm->update(game);	
	
}

///////                                                                  ///////////
//////***************************** ESTADOS **************************////////
///////                                                                  ///////////

///////////////////////////////BlinkyChaseState///////////////////////////////////////
BlinkyChaseState::BlinkyChaseState(std::shared_ptr<Character> _character):FSMState(_character){

}

//constructor del estado chase de blinky
void BlinkyChaseState::onEnter(const GameState& ){
	//std::cout << "Entering Chase State." << std::endl;
}

//intercambia las direcciones
Move reverseDir(Move dir) 
{
    switch (dir) {
        case UP: return DOWN;
        case DOWN: return UP;
        case LEFT: return RIGHT;
        case RIGHT: return LEFT;
        default: return PASS; 
    }
}
//funcion que convierte el reverse dir en int para su uso
Move intToMove(int dir)
{
	switch (dir) {
        case 0: return UP;
        case 1: return RIGHT;
        case 2: return DOWN;
        case 3: return LEFT;
        default: return PASS; 
    }
}

//actualizar el estado chase de blinky basado en el estado del juego
Move BlinkyChaseState::onUpdate(const GameState& game) {
   
    std::vector<Move> moves;
    const auto pacmanPos = game.getPacmanPos();
    const auto pacmanCoord = game.getMaze().getNodePos(pacmanPos);
	const auto pacmanDir = game.getPacmanDir();
   

	std::pair<int, int> predictedPacmanCoord = pacmanCoord;
    int predictionSteps = 4; //numero de pasos que predecimos

	//posibles movimientos del pacman basados en 4 direcciones
    for (int i = 0; i < predictionSteps; ++i) 
	{
        switch (pacmanDir) 
		{
            case UP:
                predictedPacmanCoord.second -= 1;
                break;
            case DOWN:
                predictedPacmanCoord.second += 1;
                break;
            case LEFT:
                predictedPacmanCoord.first -= 1;
                break;
            case RIGHT:
                predictedPacmanCoord.first += 1;
                break;
            default:
                break;
        }
		
    }

    const auto myPos = character->getPos();
    const auto myCoord = game.getMaze().getNodePos(myPos);

    if (character->getDirection() == PASS) { //primer movimiento
        moves = game.getMaze().getPossibleMoves(myPos);
    } else { //cuando ya se esta moviendo
        moves = game.getMaze().getGhostLegalMoves(myPos, character->getDirection());
    }

    
    //calcular la distancia actual entre blinky y pacman
    float currentDistance = BlinkyManhattan(myCoord, pacmanCoord);

    //determinar si pacman esta cerca de una powerpill
    bool pacmanNearPowerPill = false;
    for (const auto& powerPillPos : game.getMaze().getPowerPillPositions()) {
        float distanceToPowerPill = BlinkyManhattan(pacmanCoord, powerPillPos);
        if (distanceToPowerPill < 20) { //pacman esta cerca de una powerpill si esta a menos de 4 cuadros
            pacmanNearPowerPill = true;
            break;
        }
    }

    std::pair<int, int> targetCoord; //coordenadas objetivo
	
    if (pacmanNearPowerPill) {
        //emboscar a pacman utilizando las coordenadas predichas
        targetCoord = predictedPacmanCoord;
    } else {
        //determinar el objetivo de blinky basado en la distancia
        targetCoord = (currentDistance < 2) ? pacmanCoord : predictedPacmanCoord;
    }
	

	//verificar la posicion relativa de los otros fantasmas con respecto a pacman
	bool isGhostBehind = false;
	bool isGhostLeft = false;
	bool isGhostRight = false;
	bool isGhostAbove = false;
	
	std::vector<std::pair<int,int>> ghosts;

	//sacar el total de fantasmas en el mapa
    for(int i = 0; i < 4; i++)
    {
        ghosts.push_back(game.getMaze().getNodePos(game.getGhostsPos(i)));
    }

	for (const auto& ghost : ghosts) {
		
		//verificar si el fantasma esta detras, a la izquierda, a la derecha o arriba de pacman
		if (ghost.first == pacmanCoord.first && ghost.second < pacmanCoord.second) {
			isGhostBehind = true;
		} else if (ghost.first < pacmanCoord.first && ghost.second == pacmanCoord.second) {
			isGhostLeft = true;
		} else if (ghost.first > pacmanCoord.first && ghost.second == pacmanCoord.second) {
			isGhostRight = true;
		} else if (ghost.first == pacmanCoord.first && ghost.second > pacmanCoord.second) {
			isGhostAbove = true;
		}
	}
	// verificar si blinky esta detras de otro fantasma que esta persiguiendo a pacman
    bool isGhostBehindPursuing = false;
    for (const auto& ghost : ghosts) {
        // verificar si el fantasma esta detras y persiguiendo a Pac-Man
        if (ghost.first == myCoord.first && ghost.second > myCoord.second &&
            character->getPos() == reverseDir(intToMove(game.getPacmanDir()))) {
            isGhostBehindPursuing = true;
            break;
        }
    }
	//aplicar condiciones de acorralamiento segun la posicion relativa de los fantasmas
	if (isGhostBehindPursuing) { //si blinky va detras de otro fantasma que esta persiguiendo a pacman,
        for (const auto& move : moves) { //busca una ruta alternativa para encerrarlo
            if (move != character->getDirection()) {
                targetCoord = game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos, move));
                break;
            }
		}
    } else if (isGhostBehind) {
		
		targetCoord = pacmanCoord;//blinky va directamente hacia pacman
	} else if (isGhostLeft) {
		
		targetCoord.first = pacmanCoord.first + 1;//blinky va por la derecha de pacman
	} else if (isGhostRight) {
		
		targetCoord.first = pacmanCoord.first - 1;//blinky va por la izquierda de pacman
	} else if (isGhostAbove) {
		
		targetCoord.second = pacmanCoord.second + 1;//blinky va por debajo de pacman
	} else {
		//no hay fantasmas en posiciones que indiquen acorralamiento directo
		//continuar con la logica original de seguir o predecir la posición de pacman
		targetCoord = (currentDistance < 2) ? pacmanCoord : predictedPacmanCoord;
	}
	
 	//elegir la mejor direccion para llegar al objetivo
    float min = BlinkyManhattan(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos, moves[0])), targetCoord);
    int minI = 0;
    for (unsigned int i = 1; i < moves.size(); i++) {
        auto dist = BlinkyManhattan(game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos, moves[i])), targetCoord);
        if (dist < min) {
            min = dist;
            minI = i;
        }
    }
    return moves[minI];
}

BlinkyChaseState::~BlinkyChaseState(){

} 

///////////////////////////////BlinkyScatterState///////////////////////////////////////
//constructor del estado scatter de blinky
BlinkyScatterState::BlinkyScatterState(std::shared_ptr<Character> _character):FSMState(_character){

}

//accion al entrar al estado scatter
void BlinkyScatterState::onEnter(const GameState& ){
	std::cout << "Entering Scatter State." << std::endl;
}

//actualizar el estado scatter de blinky basado en el estado del juego
Move BlinkyScatterState::onUpdate(const GameState& game){
	std::vector<Move> moves;

	std::pair<int,int> dest(108,0);

	const auto myPos=character->getPos();

	if(character->getDirection()==PASS){		//primer movimiento
		moves=game.getMaze().getPossibleMoves(myPos);
	}else{										//cuando ya se esta moviendo
		moves=game.getMaze().getGhostLegalMoves(myPos,character->getDirection());
	}

	float min=BlinkyManhattan(
		game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[0])),
			dest);
	int minI=0;
	for(unsigned int i=1;i<moves.size();i++){
		auto dist=BlinkyManhattan(
			game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[i])),
			dest);
		if(dist<min){
			min=dist;
			minI=i;
		}
	}
	return moves[minI];
}
BlinkyScatterState::~BlinkyScatterState(){

}

///////////////////////////////BlinkyFrighteredState///////////////////////////////////////

//constructor del estado frightered de blinky
BlinkyFrighteredState::BlinkyFrighteredState(std::shared_ptr<Character> _character):FSMState(_character){

}

//accion al entrar al estado frightered
void BlinkyFrighteredState::onEnter(const GameState& ){
	//std::cout << "Entering Frightered State." << std::endl;
}

//actualizar el estado frightered de blinky basado en el estado del juego
Move BlinkyFrighteredState ::onUpdate(const GameState& game){
	std::vector<Move> moves;
	const auto pacmanCoord=game.getMaze().getNodePos(game.getPacmanPos());
	const auto myPos=character->getPos();

	if(character->getDirection()==PASS){		//primer movimiento
		moves=game.getMaze().getPossibleMoves(myPos);
	}else{										//cuando ya se esta moviendo
		moves=game.getMaze().getGhostLegalMoves(myPos,character->getDirection());
	}

	float max=BlinkyManhattan(
		game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[0])),
			pacmanCoord);
	int maxI=0;
	for(unsigned int i=1;i<moves.size();i++){
		auto dist=BlinkyManhattan(
			game.getMaze().getNodePos(game.getMaze().getNeighbour(myPos,moves[i])),
			pacmanCoord);
		if(dist>max){
			max=dist;
			maxI=i;
		}
	}
	return moves[maxI];
}
BlinkyFrighteredState::~BlinkyFrighteredState(){

}

///////                                                                  ///////////
//////***************************** TRANSICIONES **************************////////
///////                                                                  ///////////


///////////////////////////////////ScatterTransition///////////////////////////////

//constructor de la transicion a estado scatter de blinky
BlinkyScatterTransition::BlinkyScatterTransition(std::shared_ptr<FSMState> next,
								std::shared_ptr<Character> character,
								int *FFS
								):_next(next),
								_character(character),
								_FFS(FFS){
	
}

//validar si la transicion a estado scatter es valida
bool BlinkyScatterTransition::isValid(const GameState& gs) {
    (void)gs; //funcion para solucionar el warning de la variable gs sin usar
	float time = (float)*_FFS / 30;
    //std::cout << "Time in isValid: " << time << std::endl;

    if (time >= 20 && time < 27) {
        //std::cout << "Scatter Transition is valid." << std::endl;
        return true;
    }

    //reiniciar el timer cuando se sale del rango de scatter
    if (time >= 27) {
        *_FFS = 1;
    }

    return false;
}

//obtener el siguiente estado despues de la transicion a estado scatter
std::shared_ptr<FSMState>BlinkyScatterTransition::getNextState(){
	//std::cout << "Transitioning to Scatter State." << std::endl;
	return _next;
}

///////////////////////////////////FrighteredTransition///////////////////////////////

//constructor de la transicion a estado frightered de blinky
BlinkyFrighteredTransition::BlinkyFrighteredTransition(std::shared_ptr<FSMState> next,
						std::shared_ptr<Character> character,
						bool toFright,
						int *FFS):
						_next(next),
						_character(character),
						_toFright(toFright),		
						_FFS(FFS){

}

//validar si la transicion a estado frightered es valida
bool BlinkyFrighteredTransition::isValid(const GameState& gs){
	if(_toFright==gs.isGhostEdible(0)){
		*_FFS=1;
		//std::cout << "Frightered Transition is valid." << std::endl;
		return true;
	}else{
		return false;
	}
}

//obtener el siguiente estado despues de la transicion a estado frightered
std::shared_ptr<FSMState> BlinkyFrighteredTransition::getNextState(){
	//std::cout << "Transitioning to Frightered State." << std::endl;
	return _next;
}


/////////////////////////////////////BlinkyFiniteStateMachine/////////////////////////////

//constructor de la fsm de blinky
BlinkyFiniteStateMachine::BlinkyFiniteStateMachine(std::shared_ptr<Character> _character):FiniteStateMachine(_character){
	
	//estados
	auto chase =std::make_shared<BlinkyChaseState>(character);
	auto fright =std::make_shared<BlinkyFrighteredState>(character);
	auto scatter =std::make_shared<BlinkyScatterState>(character);
	
	timer=1; //variable para reiniciar el timer FFS
	
	//transiciones
	chase->addTransition(std::make_shared<BlinkyFrighteredTransition>(fright,character,true,&timer));
	scatter->addTransition(std::make_shared<BlinkyFrighteredTransition>(fright,character,true,&timer));
	fright->addTransition(std::make_shared<BlinkyFrighteredTransition>(chase,character,false,&timer));
	chase->addTransition(std::make_shared<BlinkyScatterTransition>(scatter,character,&timer));
	scatter->addTransition(std::make_shared<BlinkyScatterTransition>(chase,character,&timer));
	
	initialState = chase;
	activeState = chase;
	
	//estados almacenados
	states.push_back(scatter);
	states.push_back(chase);
	states.push_back(fright);
	
}

// actualizar la fsm de blinky
Move BlinkyFiniteStateMachine::update(const GameState& gs) {
    timer++;
	auto t = activeState->getActiveTransition(gs);
    if (t != nullptr) {
        activeState->onExit(gs);
        t->onTransition(gs);
        activeState = t->getNextState();
        activeState->onEnter(gs);
    }
    return activeState->onUpdate(gs);
}

//destructor de la fsm del blinky
BlinkyFiniteStateMachine::~BlinkyFiniteStateMachine() {
}




