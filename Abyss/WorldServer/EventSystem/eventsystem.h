#if !defined(EVENTSYSTEM_H)
#define EVENTSYSTEM_H

#ifdef EVENTSYSTEM

class EventSystem : public Singleton<EventSystem>
{
	public:
		EventSystem();
		~EventSystem();

		void CallFunction( void(__cdecl *)(void *), void * );
		void AddTimer( DoubleWord ExpireTime, void(__cdecl *Function)(void *), void *Pointer, DoubleWord EventID, QuadWord EventGUID );
		void DeleteTimer(DoubleWord EventID, QuadWord EventGUID);
		void CheckReadyEvents();
		DoubleWord GetTime();

		list<Timer *> mTimer;
		bool mDebug;
};

#endif

#endif