//******************************************************************************
// Holds all LogonSockets which need some action
// Calls theirs methods at Update time
//==============================================================================
#ifndef __LOGONSOCKETMGR_H
#define __LOGONSOCKETMGR_H
//==============================================================================
#include "LogonSocket.h"
#include "../Shared/Singleton.h"
//==============================================================================
class LogonSocketMgr : public Singleton<LogonSocketMgr>
	// Holds all LogonSockets which need some action
	// Calls theirs methods at Update call
{
public:
	// Add LogonSocket to list for procession
	void AddToProcessList(LogonSocket *s) { process.push_back(s); }
	// Del LogonSocket from list for procession
	void DelFromProcessList(LogonSocket *s) { process.remove(s); }

	// Add LogonSocket to list for sending data
	void AddToSendList(LogonSocket *s) { send.push_back(s); }
	// Del LogonSocket from list for sending data
	void DelFromSendList(LogonSocket *s) { send.remove(s); }

	// Calls ProcessInput() and SendOutput() for all sockets in lists
	void Update(time_t diff);

private:

	// Calls ProcessInput() for all sockets in lists
	void Process(time_t diff);
	// Calls SendOutput() for all sockets in lists
	void Send(time_t diff);

	std::list<LogonSocket*> process; // ProcessInput() need to be called for elements of this list
	std::list<LogonSocket*> send; // SendOutput() need to be called for elements of this list
};
//==============================================================================
#define sLogonSocketMgr LogonSocketMgr::getSingleton()
//==============================================================================
#endif // __LOGONSOCKETMGR_H
//******************************************************************************