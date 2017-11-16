//******************************************************************************
#include "StdAfx.h"
#include "LogonSocketMgr.h"
//==============================================================================
createFileSingleton( LogonSocketMgr );
//==============================================================================
// Calls ProcessInput() and SendOutput() for all sockets in lists
void LogonSocketMgr::Update(time_t diff)
{
	Process(diff);
	Send(diff);
}
//------------------------------------------------------------------------------
// Calls ProcessInput() for all sockets in lists
void LogonSocketMgr::Process(time_t diff)
{
	std::list<LogonSocket*>::iterator i, j;
	for(i = process.begin(); i != process.end();)
	{
		j = i;
		j++;
		if ((*i)->ProcessInput(10))
			process.erase(i);
		i = j;
	}
}
//------------------------------------------------------------------------------
// Calls SendOutput() for all sockets in lists
void LogonSocketMgr::Send(time_t diff)
{
	std::list<LogonSocket*>::iterator i, j;
	for(i = send.begin(); i != send.end();)
	{
		j = i;
		j++;
		if ((*i)->SendOutput(diff, 10))
			send.erase(i);
		i = j;
	}
}
//******************************************************************************
