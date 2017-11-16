#ifndef UDPSOCKET_H
#define UDPSOCKET_H

#include "TCPSocket.h"

#ifndef SD_BOTH
#define SD_BOTH 0x02
#endif

class UDPSocket
{
public:
	UDPSocket(void);
	~UDPSocket(void);

	SOCKET s;
	bool Create(int LocalPort);
	bool isData();
	int SendTo(void *buf,  int len, Addr &to);
	int RecvFrom(void * buf, int len, Addr &from);
	void ShutDown();

	Addr LocalAddr;
	bool bValid;
};

#endif // UDPSOCKET_H
