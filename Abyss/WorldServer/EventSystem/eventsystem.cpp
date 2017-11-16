// (c) AbyssX Group
#include "../WorldEnvironment.h"
#include <mmsystem.h>

#ifdef EVENTSYSTEM

template <class EventSystem> EventSystem *Singleton<EventSystem>::msSingleton = 0;

EventSystem::EventSystem()
{
	mDebug = false;
}

EventSystem::~EventSystem()
{
}

void EventSystem::CallFunction(void(__cdecl *Function)(void *), void *Param)
{
	(Function)(Param);
}

void EventSystem::AddTimer(DoubleWord ExpireTime, void(__cdecl *Function)(void *), void *Pointer, DoubleWord EventID, QuadWord EventGUID)
{
	DoubleWord gameTime = GetTime();

	Timer *timer = new Timer();

	timer->Function_x = Function;
	timer->Param_x = Pointer;
	timer->ExpireTime = (gameTime+ExpireTime);
	timer->EventID = EventID;
	timer->EventGUID = EventGUID;

	mTimer.push_back(timer);
}

void EventSystem::DeleteTimer(DoubleWord EventID, QuadWord EventGUID)
{
	list<Timer *>::iterator it;
	
	if (EventID != 10001)
	{
		for (it = mTimer.begin();it != mTimer.end();)
		{
			if ((*it)->EventID == EventID && (*it)->EventGUID == EventGUID)
			{
				delete *it;
				mTimer.erase(it++);
			}
			else
				it++;
		}
	}
	else
	{
		for (it = mTimer.begin();it != mTimer.end();)
		{
			if ((*it)->EventGUID == EventGUID)
			{
				delete *it;
				mTimer.erase(it++);
			}
			else
				it++;
		}
	}
}

void EventSystem::CheckReadyEvents()
{
	list<Timer *>::iterator it;
	
	DoubleWord gameTime = GetTime();
	
	for (it = mTimer.begin();it != mTimer.end();)
	{
		if (mDebug)
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
#ifdef WIN32
	return timeGetTime();
#else
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
#endif
}

#endif