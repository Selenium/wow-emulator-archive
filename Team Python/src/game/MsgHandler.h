#ifndef WOWPYTHONSERVER_HANDLER_H
#define WOWPYTHONSERVER_HANDLER_H

#include "Common.h"

class GameClient;
struct wowWData;
class MsgHandler
{
public:
	MsgHandler() {};
	virtual ~MsgHandler() {};

	virtual void HandleMsg( wowWData & recv_data, GameClient *pClient ) = 0;
};

#endif
