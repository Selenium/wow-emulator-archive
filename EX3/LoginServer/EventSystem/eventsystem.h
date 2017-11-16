#if !defined(EVENTSYSTEM_H)
#define EVENTSYSTEM_H

#ifdef EVENTSYSTEM

class EventSystem : public Singleton<EventSystem>
{
	public:
		EventSystem();
		~EventSystem();

		void CallFunction( void(__cdecl *)(void *), void * );
		void AddTimer( DoubleWord, void(__cdecl *)(void *), void *);
		void CheckReadyEvents();
		DoubleWord GetTime();

		list<Timer *> mTimer;
		bool EventDebug;
};

#endif

#endif