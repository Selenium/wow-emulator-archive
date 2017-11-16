#pragma once
#include "Threading.h"

#include <time.h>
#include <pthread.h>

#define CLock CUnixLock
#define CSemaphore CUnixSemaphore
#define CThread CUnixThread
#define CSignal CUnixSignal

#ifndef PTHREAD_MUTEX_RECURSIVE_NP
#define PTHREAD_MUTEX_RECURSIVE_NP PTHREAD_MUTEX_RECURSIVE
#endif

#define DEC (void *(*)(void *))

#define Sleep(ms) usleep(1000*ms)

class CUnixSemaphore : public CPortableSemaphore
{
public:
	pthread_mutexattr_t attr;
	pthread_mutex_t s;
	CUnixSemaphore()
	{
		//InitializeCriticalSection(&s);
		pthread_mutexattr_init(&attr);
		pthread_mutexattr_settype(&attr,PTHREAD_MUTEX_RECURSIVE_NP);
		pthread_mutex_init(&s,&attr);
	}

	~CUnixSemaphore()
	{
		pthread_mutex_destroy(&s);
		pthread_mutexattr_destroy(&attr);
	};
};

class CUnixLock : public CPortableLock
{
public:
	CUnixLock()
	{
		s=NULL;
		Locked=false;
	};
	CUnixLock(CUnixSemaphore* sem,bool bLocked=true)
	{
		s=&sem->s;
		if (bLocked && s)
		{
			pthread_mutex_lock(s);
			Locked=true;
		} else
		{
			Locked=false;
		}
	};
	~CUnixLock()
	{
		Unlock();
	};

	void Lock()
	{
		if (s)
		{
			pthread_mutex_lock(s);
			Locked=true;
		}
	};

	void Unlock()
	{
		if (Locked)
		{
			pthread_mutex_unlock(s);
			Locked=false;
		}
	};
	bool IsLocked()
	{
		return Locked;
	};
	void SetSemaphore(CPortableSemaphore* sem)
	{
		s=&((CUnixSemaphore*)sem)->s;
	};
private:
	pthread_mutex_t *s;
	bool Locked;

};

class CUnixSignal : public CPortableSignal
{
public:
	CUnixSignal(void)
	{
		pthread_mutex_init(&waiting,NULL);
		pthread_mutex_init(&signaling,NULL);
		bSignaling=false;
	}
	~CUnixSignal(void)
	{
		pthread_mutex_destroy(&waiting);
		pthread_mutex_destroy(&signaling);
	}

	void Wait(int Timeout, CPortableLock* unlockme=NULL)
	{
		pthread_mutex_lock(&waiting);
		((CUnixLock*)unlockme)->Unlock();
		time_t start=time(0);
		while(!bSignaling)
		{
			if (time(0)-start>Timeout)
			{
				pthread_mutex_unlock(&waiting);
				return;
			}
			Sleep(1);
		}
	}

	void Release()
	{
		pthread_mutex_unlock(&waiting);
	}

	void Signal()
	{
		pthread_mutex_lock(&signaling);
		bSignaling=true;
		pthread_mutex_lock(&waiting);
		bSignaling=false;
		pthread_mutex_unlock(&signaling);
		pthread_mutex_unlock(&waiting);
	}
private:
	pthread_mutex_t waiting;
	pthread_mutex_t signaling;
	bool bSignaling;
};

class CUnixThread : public CPortableThread
{
public:
	CUnixSemaphore Threading;
        pthread_t thread;

	CUnixThread()
	{
		ThreadReady = false;
		bThreading = false;
		CloseThread=false;
	};
	~CUnixThread()
	{
		if (bThreading)
			EndThread();
	};

	void BeginThread(PTHREAD_START_ROUTINE function, void *pInfo)
	{
		if (bThreading || !function)
			return;
                Info=pInfo;
		ThreadReady=false;
		CloseThread=false;
//		printf("Function is 0x%08X\n",function);
//		(DEC function)(this);
		
//		printf("BeginThread(0x%08X,0x%08X)\n",function,Info);

		if (pthread_create(&thread,0,function,this))
			return;
		while(!ThreadReady)
		{
			Sleep(0);
		}
	};

	void EndThread()
	{
		CloseThread=true;
		CUnixLock L(&Threading,true);
	};
};

