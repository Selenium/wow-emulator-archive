/*****************************************************************************
TEQIM, EQIMd and EQIMu
Copyright (C) 2003-2004 Lax

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License, version 2,
as published by the Free Software Foundation.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

Usage of these EQIM clients and derivatives subject you to the rules of
the EQIM network.  Access to the network is restricted to paying
subscribers of the online game EverQuest.  This software and the EQIM
protocol is provided in good faith to the EverQuest community, and not
intended for malicious purposes.  Usage of this software for malicious
purposes is prohibited and any distribution, usage, or mention of
malicious activity can and will be reported to the administrators of the
EQIM network.
******************************************************************************/

// TCPSocket.cpp: implementation of the TCPSocket class.
//
//////////////////////////////////////////////////////////////////////

// WARNING: you MUST link ws2_32.lib!
#include "stdafx.h"
#include "TCPSocket.h"

#ifdef WIN32
#ifdef _DEBUG
#define new DEBUG_NEW
#endif
#else
#endif	// ifdef WIN32
#include "Debug.h"


//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

TCPSocket::TCPSocket()
{
	valid=true;
	m_hSocket=INVALID_SOCKET;	// init socket to invalid
}

TCPSocket::~TCPSocket()
{
	Close();
}

bool TCPSocket::Create(int nPort)
{
	if (m_hSocket == INVALID_SOCKET)
	{
		// If the socket is invalid, we are allowed to make a new socket

		m_hSocket = socket(PF_INET, SOCK_STREAM, 0);
		if (m_hSocket == INVALID_SOCKET)
			return false; // If it's still invalid.. uhh.. umm...
	}

	// Make sure blocking mode is turned OFF!
	unsigned long yes=1;
	if (ioctlsocket(m_hSocket,FIONBIO,&yes)==SOCKET_ERROR)
	{
		closesocket(m_hSocket);
		m_hSocket=INVALID_SOCKET;
		return false;
	}


	setsockopt(m_hSocket,SOL_SOCKET,SO_REUSEADDR,(char*)&yes,sizeof(int));

	Addr sockAddr;
	memset(&sockAddr,0,sizeof(Addr));

	sockAddr.sa_family = 2;
	sockAddr.Port=htons((u_short)nPort);
	//	sockAddr.sin_family = AF_INET;
	//	sockAddr.sin_addr.s_addr = INADDR_ANY;
	//	sockAddr.sin_port = htons((u_short)nPort);

	if (bind(m_hSocket,(const sockaddr*)&sockAddr,sizeof(Addr))!=0)
		return false;


	return true;
}

bool TCPSocket::Connect(char *addr, UINT port)
{
	if (m_hSocket==INVALID_SOCKET)
		return false; // If it's an invalid socket, get out of here
	Addr sockAddr;
	memset(&sockAddr,0,sizeof(Addr));

	sockAddr.sa_family = 2;
	//	sockAddr.sin_addr.s_addr = inet_addr(addr);     // check if address is x.x.x.x format
	sockAddr.IP = inet_addr(addr);
	if (sockAddr.IP == INADDR_NONE)				// if not, we resolve hostname
	{
		LPHOSTENT lphost;
		lphost = gethostbyname(addr);
		if (lphost != NULL)
			sockAddr.IP = ((LPIN_ADDR)lphost->h_addr)->s_addr;
		else
		{
			return FALSE;
		}
	}

	sockAddr.Port = htons((u_short)port);
	int ret=0;
	int n=0;
	do
	{
		if (ret=connect(m_hSocket, (SOCKADDR*)&sockAddr, sizeof(sockAddr))==SOCKET_ERROR)
		{
			ret=WSAGetLastError();
			if (ret==WSAEISCONN)
				return true;
			if (ret!=WSAEWOULDBLOCK)
			{

				//				char buffer[128];
				//				strcpy(buffer,ErrorName(ret));
				return false;
			}
			if (n++>10)
			{
				return false;
			}
		}
		Sleep(200);
	} while(ret==WSAEWOULDBLOCK);

	return true;
}

bool TCPSocket::Close()
{
	if (m_hSocket!=INVALID_SOCKET)
	{
		Disconnect();
		closesocket(m_hSocket);
	}
	m_hSocket=INVALID_SOCKET;
	return true;
}

bool TCPSocket::Send(char csend)
{
	if (m_hSocket==INVALID_SOCKET)
		return false;
	int ret = send(m_hSocket,&csend,sizeof(char),MSG_NOSIGNAL);
	if (ret==SOCKET_ERROR)
	{
#ifndef WIN32
		if (errno==EPIPE)
		{
			closesocket(m_hSocket);
			m_hSocket=INVALID_SOCKET;
		}
#endif
		return 0;
	}
	return (ret!=0);
}

int TCPSocket::Send(const char *csend, int length)
{
	if (m_hSocket==INVALID_SOCKET)
		return 0;
	int ret = send(m_hSocket,(char*)csend,length,MSG_NOSIGNAL);
	if (ret==SOCKET_ERROR)
	{
#ifndef WIN32
		if (errno==EPIPE)
		{
			closesocket(m_hSocket);
			m_hSocket=INVALID_SOCKET;
		}
#endif
		return 0;
	}
	return ret;
}

int TCPSocket::Receive(char *crecv, int length)
{
	if (m_hSocket==INVALID_SOCKET)
		return 0;
	int ret = recv(m_hSocket,crecv,length,0);
	if (ret==SOCKET_ERROR)
		return 0;
	return ret;
}

bool TCPSocket::Receive(char *crecv)
{
	if (m_hSocket==INVALID_SOCKET)
		return false;
	return (recv(m_hSocket,crecv,1,0)==1);
}


bool TCPSocket::Accept(TCPSocket& returnSocket)
{
	SOCKET Socket = accept(m_hSocket,NULL,NULL);
	if (Socket==INVALID_SOCKET)
		return false;
	returnSocket.m_hSocket=Socket;
	// Make sure blocking mode is turned OFF!
	unsigned long falsifyblocking=1;
	ioctlsocket(Socket,FIONBIO,&falsifyblocking);

	return true;
}

bool TCPSocket::Listen()
{
	return (listen(m_hSocket,5)==0);
}

bool TCPSocket::isConnected()
{
	if (m_hSocket==INVALID_SOCKET)
		return false;
	char szBuffer[1]="";
	int err = recv(m_hSocket,szBuffer,1,MSG_PEEK);
	if (err==1)
		return true;
	if (err==0)
		return false;
	err=WSAGetLastError();
	if (err==WSAECONNRESET
		|| err==WSAENOTCONN
		|| err==WSAENETRESET
		|| err==WSAENOTSOCK
		|| err==WSAESHUTDOWN
		|| err==WSAEINVAL
		|| err==WSAECONNABORTED
		)
		return false;
	return true;
}

bool TCPSocket::isOpen()
{
	return (m_hSocket!=INVALID_SOCKET);
}

bool TCPSocket::Disconnect()
{
	if (m_hSocket==INVALID_SOCKET)
		return false;
	return (shutdown(m_hSocket,SD_BOTH)==0);
}

long TCPSocket::isData()
{
	unsigned long result;
	if (ioctlsocket(m_hSocket,FIONREAD,&result)!=0)
		return 0;
	return result;
}

bool TCPSocket::isConnection()
{
	SOCKADDR saddr;
	int namelen=sizeof(saddr); // was int
	return (getpeername(m_hSocket,&saddr,(socklen_t*)&namelen)==0);
}

long TCPSocket::GetClientIP()
{
	SOCKADDR saddr;
	int namelen=sizeof(saddr); // was int
	getpeername(m_hSocket,&saddr,(socklen_t*)&namelen);
	sockaddr_in *ptr = (sockaddr_in *)&saddr;
#ifdef WIN32
	return(ptr->sin_addr.S_un.S_addr);
#else
	return(ptr->sin_addr.s_addr);
#endif
}

bool TCPSocket::GetHostByName(const char *Name, char *dest)
{
	LPHOSTENT lphost;
	lphost = gethostbyname(Name);
	if (lphost != NULL)
	{
		char *data=inet_ntoa(*(in_addr*)&((LPIN_ADDR)lphost->h_addr)->s_addr);
		strcpy(dest,data);
		//free(data); // wtf...valgrind reports a memleak here, but debug mode crashes...
		return true;
	}
	return false;
}

/*
char *TCPSocket::ErrorName(int error)
{
switch (error)
{
case WSAEINTR:
return "WSAEINTR (10004): Interrupted function call";
case WSAEACCES:
return "WSAEACCES (10013): Permission denied";
case WSAEFAULT:
return "WSAEFAULT (10014): Bad address";
case WSAEINVAL:
return "WSAEINVAL (10022): Invalid argument";
case WSAEMFILE:
return "WSAEMFILE (10024): Too many open files";
case WSAEWOULDBLOCK:
return "WSAEWOULDBLOCK (10035): Resource temporarily unavailable";
}
return "Unknown";
}
*/
