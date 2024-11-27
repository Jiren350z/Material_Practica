#pragma once

#ifndef BLINKYCONTROLLER_H_
#define BLINKYCONTROLLER_H_


#include "Controller.h"
#include "FSM.h"


class BlinkyFiniteStateMachine;

class BlinkyController: public Controller {
	std::shared_ptr<BlinkyFiniteStateMachine> bfsm;
public:
	BlinkyController(std::shared_ptr<Character> character);
	virtual ~BlinkyController();
	virtual Move getMove(const GameState& game)override;
};

///////                                                                  ///////////
//////***************************** ESTADOS **************************////////
///////                                                                  ///////////

//perseguir acechando a pacman
class BlinkyChaseState:public FSMState{
public:
	BlinkyChaseState(std::shared_ptr<Character> _character);
	Move onUpdate(const GameState& gs) override;
	void onEnter(const GameState& gs) override;
	~BlinkyChaseState();

};

//ir a la esquina 
class BlinkyScatterState: public FSMState{
public:
	BlinkyScatterState(std::shared_ptr<Character> _character);
	Move onUpdate(const GameState& gs) override;
	void onEnter(const GameState& gs) override;
	~BlinkyScatterState();
};

//estado cuando el fantasma esta azul y es vulnerable ante pacman
class BlinkyFrighteredState: public FSMState{
public:
	BlinkyFrighteredState(std::shared_ptr<Character> _character);
	Move onUpdate(const GameState& gs) override;
	void onEnter(const GameState& gs) override;
	~BlinkyFrighteredState();
};

///////                                                                  ///////////
//////***************************** TRANSICIONES **************************////////
///////                                                                  ///////////

//transicion a estado de scatter
class BlinkyScatterTransition:public FSMTransition{
	std::shared_ptr<FSMState> _next;
	std::shared_ptr<Character> _character;
	int*_FFS; //variable para contar fotogramas
public:
	BlinkyScatterTransition(std::shared_ptr<FSMState> next,
	std::shared_ptr<Character> character, int* FFS);
	bool isValid(const GameState& gs)override;
	std::shared_ptr<FSMState> getNextState()override;
};
//transicion a estado de frightered
class BlinkyFrighteredTransition:public FSMTransition{
	std::shared_ptr<FSMState> _next;
	std::shared_ptr<Character> _character;
	bool _toFright;
	int *_FFS; //contador de fotogramas

public:
	BlinkyFrighteredTransition(std::shared_ptr<FSMState> next,
	std::shared_ptr<Character> character,
	bool toFright,int *FFS);
	bool isValid(const GameState& gs)override;
	std::shared_ptr<FSMState> getNextState()override;
};

//fsm para blinky
class BlinkyFiniteStateMachine: public FiniteStateMachine{
	int timer; //variable para controlar el tiempo para la transicion chase-scatter
public:
	BlinkyFiniteStateMachine(std::shared_ptr<Character> _character);
	Move update(const GameState& gs) override;
	~BlinkyFiniteStateMachine();
};

#endif /* BLINKYCONTROLLER_H_ */