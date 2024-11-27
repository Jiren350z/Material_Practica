#pragma once

#include "Controller.h"
#include "BehaviorTree.h"
#include <chrono>
#include <random>

class SueInfo{
    static SueInfo *sueInfo;
    SueInfo(){}

	public:
		static SueInfo* getSueInfo(){
			if(sueInfo==nullptr)sueInfo = new SueInfo();
			return sueInfo;
		}
		const GameState* in_gamestate;
		Move out_move;
		std::shared_ptr<Character> in_character;
};

class SueController: public Controller {
private:
	std::shared_ptr<Composite> root;

public:
	SueController(std::shared_ptr<Character> character);
	virtual ~SueController();
	virtual Move getMove(const GameState& game)override;
};

class SueChase : public Behavior
{
	public:
		virtual Status update() override;
};

class SueGetsAway : public Behavior
{
	private:
		std::mt19937 e;
		std::uniform_int_distribution<int> uniform_dist;

	public:
		virtual Status update() override;
		SueGetsAway();
};

class SueGoToPill : public Behavior
{
	private:
		std::pair<int,int> target;

	public:
		virtual Status update() override;
		SueGoToPill();
};

class SuePowerPill : public Behavior
{
	private:

	public:
		virtual Status update() override;

};

class SueKeepDistance : public Behavior
{
	private:

	public:
	virtual Status update() override;
};

class SueGetsCloser : public Behavior
{
	private:

	public:
	virtual Status update() override;
};

class SueIfPill : public Behavior
{
	private:	
		int pills;
	public:
	 	virtual Status update() override;
		SueIfPill();
};