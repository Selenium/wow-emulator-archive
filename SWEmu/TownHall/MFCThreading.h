#ifndef MFCTHREADING_H
#define MFCTHREADING_H

#include "Threading.h"

#include <afxmt.h>
#include <time.h>

#define CLock CMFCLock
#define CSemaphore CMFCSemaphore
#define CThread CMFCThread
#define CSignal CMFCSignal

class CMFCSemaphore : public CPortableSemaphore
{
public:
	CCriticalSection s;
};

class CMFCLock : public CPortableLock
{
public:
	CMFCLock()
	{
		s=NULL;
		L=NULL;
		Locked=false;
	};
	CMFCLock(CMFCSemaphore* sem,bool bLocked=true)
	{
		s=&sem->s;
		Locked=false;
		L=new CSingleLock(s,bLocked);
	};
	~CMFCLock()
	{
		Unlock();
	};

	void Lock()
	{
		if (s && L)
		{
			L->Lock();
			Locked=true;
		}
	};

	void Unlock()
	{
		if (L)
		{
			if (Locked)
				L->Unlock();
			delete L;
			Locked=false;
		}
	};
	bool IsLocked()
	{
		return Locked;
	};
	void SetSemaphore(CPortableSemaphore* sem)
	{
		s=&((CMFCSemaphore*)sem)->s;
		L=new CSingleLock(s);
	};
private:
	CSingleLock *L;
	CCriticalSection *s;
	bool Locked;
};

class CMFCSignal : public CPortableSignal
{
public:
	CMFCSignal(void)
	{
		Waiting=new CSingleLock(&csWaiting);
		bWaiting=false;
		bSignaling=false;
	}
	~CMFCSignal(void)
	{
		delete Waiting;
	}

	void Wait(unsigned long Timeout, CPortableLock* unlockme=NULL)
	{
		Waiting->Lock();
		if (unlockme)
			((CMFCLock*)unlockme)->Unlock();
		time_t start=time(0);
		int scount=0;
		{
			while(csSignaling.m_sect.OwningThread==0)
			{
				if ((unsigned long)(time(0)-start)>Timeout)
				{
					Waiting->Unlock();
					return;
				}
				if (scount++>5)
				{
					scount=0;
					Sleep(1);
				}
			}
		}
	}


	void Wait(CPortableLock* unlockme=NULL)
	{
		Waiting->Lock();
		bWaiting=true;
		if (unlockme)
			((CMFCLock*)unlockme)->Unlock();
		time_t start=time(0);
		int scount=0;
		{
			while(bSignaling==false)
			{
				if (scount++>5)
				{
					scount=0;
					Sleep(1);
				}
			}
		}
	}



	void Release()
	{
		bWaiting=false;
		Waiting->Unlock();
	}

	void Signal(bool* WhileTrue=0)
	{
		CSingleLock L(&csSignaling);
		L.Lock();
		bSignaling=true;
		int scount=0;
		while(bWaiting==false && (!WhileTrue || *WhileTrue))
		{
			if (scount++>5)
			{
				scount=0;
				Sleep(1);
			}
		}
		CSingleLock W(&csWaiting);
		W.Lock();
		bSignaling=false;
		L.Unlock();
		W.Unlock();
	}
private:
	CCriticalSection csWaiting;
	CCriticalSection csSignaling;
	CSingleLock *Waiting;
	bool bWaiting;
	bool bSignaling;
};

class CMFCThread : public CPortableThread
{
public:
	CMFCSemaphore Threading;
	CMFCThread()
	{
		ThreadReady = false;
		bThreading = false;
		CloseThread=false;
	};
	~CMFCThread()
	{
		EndThread();
	};

	void BeginThread(volatile void *function)
	{
		if (bThreading)
			return;
		AfxBeginThread((AFX_THREADPROC)function,this);
		while(!ThreadReady)
		{
			Sleep(20);
		}
	};

	void EndThread()
	{
		CloseThread=true;
		CMFCLock L(&Threading,true);
	};
};

#endif // MFCTHREADING_H
