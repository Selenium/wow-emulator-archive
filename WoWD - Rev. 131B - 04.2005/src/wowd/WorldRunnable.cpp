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
    uint32 realCurrTime = 0, realPrevTime = 0;

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
}
