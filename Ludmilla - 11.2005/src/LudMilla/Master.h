#ifndef _MASTER_H
#define _MASTER_H

#include "../Shared/Common.h"
#include "../Shared/Singleton.h"
#include "../Shared/Config/ConfigEnv.h"
#include "../Shared/Database/DatabaseEnv.h"

#define DEFAULT_LOOP_TIME		0 /* 0 millisecs - instant */
#define DEFAULT_LOG_LEVEL		0
#define DEFAULT_PLAYER_LIMIT	100
#define DEFAULT_WORLDSERVER_PORT 3725
#define DEFAULT_LOGONSERVER_PORT 3724
#define DEFAULT_HOST "127.0.0.1"

class Master : public Singleton<Master>
{
   public:
        Master();
        ~Master();
        bool Run();

        static volatile bool m_stopEvent;
   private:
        bool _StartDB();
        void _StopDB();

        void _HookSignals();
        void _UnhookSignals();

        static void _OnSignal(int s);
};

#endif
