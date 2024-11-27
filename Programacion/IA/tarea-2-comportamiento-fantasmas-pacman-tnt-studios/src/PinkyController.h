#pragma once

#include "Controller.h"
#include "FSM.h"
#include <random>
#include <chrono>

class PinkyStateMachine;

class PinkyController: public Controller {
	
	std::shared_ptr<PinkyStateMachine> fsm;

public:
	PinkyController(std::shared_ptr<Character> character);
	virtual ~PinkyController();
	virtual Move getMove(const GameState& game)override;
};

////////////////////// Pinky States ////////////////////////////////////
class PinkyInitialPointState:public FSMState{

public:
	PinkyInitialPointState(std::shared_ptr<Character> _character);
	Move onUpdate(const GameState& gs) override;
	void onEnter(const GameState& gs) override;
	~PinkyInitialPointState();

};
class PinkyChaseState:public FSMState{

public:
	PinkyChaseState(std::shared_ptr<Character> _character);
	//////////////**************BFS****************///////////////////
	static std::vector<std::pair<int,int>> BFS(const GameState& gs);
	Move onUpdate(const GameState& gs) override;
	void onEnter(const GameState& gs) override;
	~PinkyChaseState();

};

class PinkyFrightState:public FSMState{

public:
	PinkyFrightState(std::shared_ptr<Character> _character);
	Move onUpdate(const GameState& gs) override;
	void onEnter(const GameState& gs) override;
	~PinkyFrightState();

};

class PinkyScatterState:public FSMState{

public:
	PinkyScatterState(std::shared_ptr<Character> _character);
	Move onUpdate(const GameState& gs) override;
	void onEnter(const GameState& gs) override;
	~PinkyScatterState();

};
////////////////////// Pinky transtition ////////////////////////////////////


class  PinkyInitialPointTransition:public FSMTransition{
	std::shared_ptr<FSMState> _next;
	std::shared_ptr<Character> _character;
	bool _arrivePlace=false;
public:
	PinkyInitialPointTransition(std::shared_ptr<FSMState> next,std::shared_ptr<Character> character);
	bool isValid(const GameState& gs)override;
	std::shared_ptr<FSMState> getNextState()override;
};


class  PinkyScatterTransition:public FSMTransition{
	std::shared_ptr<FSMState> _next;
	std::shared_ptr<Character> _character;
	int *_FFS;
public:
	 PinkyScatterTransition(std::shared_ptr<FSMState> next,std::shared_ptr<Character> character, int *FFS);
	bool isValid(const GameState& gs)override;
	std::shared_ptr<FSMState> getNextState()override;
};

class  PinkyFrightTransition:public FSMTransition{
	std::shared_ptr<FSMState> _next;
	std::shared_ptr<Character> _character;
	bool _toFright;
	int *_FFS;
public:
	PinkyFrightTransition(std::shared_ptr<FSMState> next,std::shared_ptr<Character> character,bool toFright,int *FFS);
	bool isValid(const GameState& gs)override;
	std::shared_ptr<FSMState> getNextState()override;
};


//////////////***********stateMachine**********////////////
class PinkyStateMachine: public FiniteStateMachine{
	
	int timer;
public:
	PinkyStateMachine(std::shared_ptr<Character> _character);
	Move update(const GameState& gs) override;
	~PinkyStateMachine();

};



