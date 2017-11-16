//
// WorldRunnable.cpp
//

#include "Common.h"
#include "Log.h"
#include "World.h"
#include "WorldRunnable.h"
#include "Master.h"
#include "Timer.h"

void WorldRunnable::run()
{
    uint32 realCurrTime = getMSTime();
    uint32 realPrevTime = 0;

    while (!Master::m_stopEvent)
    {
        realPrevTime = realCurrTime;
        realCurrTime = getMSTime();

        // uint32 exceeded
        if (realPrevTime > realCurrTime)
            realPrevTime = 0;

        sWorld.Update( realCurrTime - realPrevTime );

        ZThread::Thread::sleep(50);
    }
}
