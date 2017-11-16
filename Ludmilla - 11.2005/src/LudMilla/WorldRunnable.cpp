#include "StdAfx.h"
//
// WorldRunnable.cpp
//

#include <CXX/Exception.hxx>

void * InitThreadScripting();
void ShutdownThreadScripting (void *state);

void InitScripting();
void ShutdownScripting();


void WorldRunnable::run()
{
	try
	{
		//void * threadstate = InitThreadScripting();
		uint32 realCurrTime = 0, realPrevTime = 0;
		InitScripting();

		while (!Master::m_stopEvent)
		{
			// uint32 exceeded
			if (realPrevTime > realCurrTime)
				realPrevTime = 0;

			realCurrTime = getMSTime();
			sWorld.Update( realCurrTime - realPrevTime );
			realPrevTime = realCurrTime;

			ZThread::Thread::sleep(50);
		}

		//ShutdownThreadScripting (threadstate);
		ShutdownScripting();
	}
	catch (Py::Exception) // e)
	{
		Log::getSingleton( ).outError("FATAL ERROR in scripts or scripting system!");
		raise(SIGINT);
	}
}

//--- END ---