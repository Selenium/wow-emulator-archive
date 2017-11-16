#include "UDPSocket.h"

UDPSocket::UDPSocket(void)
{
	bValid=false;
	s=INVALID_SOCKET;
}

UDPSocket::~UDPSocket(void)
{
	if (bValid)
	{
		shutdown(s,SD_BOTH);
		closesocket(s);
		s=INVALID_SOCKET;
		bValid=false;
	}
}

bool UDPSocket::Create(int LocalPort)
{
	s=socket(2,SOCK_DGRAM,0); // initialize socket
	if (s==INVALID_SOCKET)
	{
		bValid=false;
		return false;
	}
	int NonBlocking=1;
	if (ioctlsocket(s,FIONBIO,(u_long*)&NonBlocking)==SOCKET_ERROR) // set socket to non blocking
	{
		shutdown(s,SD_BOTH);
		closesocket(s);
		s=INVALID_SOCKET;
		bValid=false;
		return false;
	}
	memset(&LocalAddr,0,sizeof(Addr));
	LocalAddr.sa_family=2;
	LocalAddr.Port=htons(LocalPort);
	if (bind(s,(const sockaddr*)&LocalAddr,sizeof(Addr))==SOCKET_ERROR)
	{
		shutdown(s,SD_BOTH);
		closesocket(s);
		s=INVALID_SOCKET;
		bValid=false;
		return false;
	}
	// k, socket set up now
	bValid=true;
	return true;
}

bool UDPSocket::isData()
{
	unsigned long result=0;
	if (ioctlsocket(s,FIONREAD,&result)==SOCKET_ERROR)
	{
		bValid=false;
	}
	return (result>0);
}


int UDPSocket::SendTo(void *buf,  int len, Addr &to)
{
	if (s==INVALID_SOCKET)
		return 0;
	int ret= sendto(s,(const char*)buf,len,0,(sockaddr*)&to,sizeof(Addr));
	return ret;
}

int UDPSocket::RecvFrom(void * buf, int len, Addr &from)
{
	if (s==INVALID_SOCKET)
		return 0;
	int fromlen=sizeof(sockaddr);
	int ret = recvfrom(s,(char*)buf,len,0,(sockaddr*)&from,(socklen_t*)&fromlen);
	return ret;
}

void UDPSocket::ShutDown()
{
	if (bValid)
	{
		shutdown(s,SD_BOTH);
		closesocket(s);
		s=INVALID_SOCKET;
		bValid=false;
	}
}