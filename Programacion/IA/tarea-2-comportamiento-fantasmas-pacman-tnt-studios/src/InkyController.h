#pragma once

#include "Controller.h"
#include "BehaviorTree.h"
#include <chrono>

#include <random>

class InfoInky{
	static InfoInky *info;
	InfoInky(){}

public:
	static InfoInky* getInfoInky(){
		if(info==nullptr)info = new InfoInky();
		return info;
	}
	const GameState* in_gamestate;
	Move out_move;
	std::shared_ptr<Character> in_Inky;

};




class InkyController: public Controller {
private:
	std::shared_ptr<Composite> root;

public:
	InkyController(std::shared_ptr<Character> character);
	virtual ~InkyController();
	virtual Move getMove(const GameState& game)override;
};

class ChaseAction : public Behavior{
	public:
		virtual Status update() override;

};

class FrighteredAction : public Behavior{
	private:
    std::pair<int,int> target;
	public:
		virtual Status update() override;
		FrighteredAction();
};

class HomeAction : public Behavior{
	private:
		std::pair<int,int> target;
	public:
		virtual Status update() override;
		HomeAction();
};

class BeginingCondition : public Behavior{
	private:
		bool PtjisLower;
	public:
		virtual Status update() override;
		BeginingCondition();
};

class IamBlueCondition : public Behavior{
	private:
		bool IamBLue;
	public:
		virtual Status update() override;
		IamBlueCondition();
};



class ForceMovementAction : public Behavior{
	private:
		std::pair<int,int> target;

	public:
		virtual Status update() override;
		ForceMovementAction();
};

class TimeOutCondition : public Behavior{
	private: 
		//std::chrono::time_point<std::chrono::high_resolution_clock> lastTime;
		//int *_FPS;
		int lastTime;
	public:
		virtual Status update() override;
		TimeOutCondition();
};

