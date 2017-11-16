// (c) AbyssX Group
#include "../LoginEnvironment.h"

#ifdef EVENTSYSTEM

template <class EventSystem> EventSystem *Singleton<EventSystem>::msSingleton = 0;

EventSystem::EventSystem()
{
	EventDebug = false;
}

EventSystem::~EventSystem()
{
}

void EventSystem::CallFunction(void(__cdecl *Function)(void *), void *Param)
{
	(Function)(Param);
}

void EventSystem::AddTimer(DoubleWord T, void(__cdecl *F)(void *), void *P)
{
	DoubleWord gameTime = GetTime();

	Timer *timer = new Timer();

	timer->Function_x = F;
	timer->Param_x = P;
	timer->ExpireTime = (gameTime+T);

	mTimer.push_back(timer);
}

void EventSystem::CheckReadyEvents()
{
	list<Timer *>::iterator it;
	
	DoubleWord gameTime = GetTime();
	
	for (it = mTimer.begin();it != mTimer.end();)
	{
		if (EventDebug)
			printf("[World-Server] - [ gameTime: %d | ExpireTime: %d ]\n",gameTime,(*it)->ExpireTime);

		if ((*it)->ExpireTime <= gameTime)
		{
			CallFunction((*it)->Function_x,(*it)->Param_x);
			delete *it;
			mTimer.erase(it++);
		}
		else
			it++;
	}
}

DoubleWord EventSystem::GetTime()
{
	DoubleWord gameTime = 0;

	_timeb now;
	_ftime(&now);

	time_t tmp;
	time(&tmp);
	tm* t = localtime(&tmp);

	gameTime = 	t->tm_hour;		gameTime = (gameTime * 60);
	gameTime += t->tm_min;		gameTime = (gameTime * 60);
	gameTime += t->tm_sec;		gameTime = (gameTime * 1000);
	gameTime += now.millitm;

	return gameTime;
}

#endif