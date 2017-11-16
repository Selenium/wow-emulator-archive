#if !defined(TIMER_H)
#define TIMER_H

#ifdef EVENTSYSTEM

class Timer
{
	public:
		Timer();
		~Timer();

		void(__cdecl *Function_x)(void *);
		void *Param_x;
		DoubleWord ExpireTime;
};

#endif

#endif