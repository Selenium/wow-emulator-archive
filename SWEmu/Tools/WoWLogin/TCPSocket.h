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

// WinSocket.h: interface for the WinSocket class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WINSOCKET_H__2B84B082_914A_11D3_B72A_00AA00644CD7__INCLUDED_)
#define AFX_WINSOCKET_H__2B84B082_914A_11D3_B72A_00AA00644CD7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "stdafx.h"
/* SOCKADDR */
struct Addr
{
	unsigned short sa_family;
	/* sa_data */
	unsigned short Port;
	unsigned long IP; // inet_addr
	unsigned long unusedA;
	unsigned long unusedB;
};

class TCPSocket 
{
public:
	TCPSocket();
	virtual ~TCPSocket();
//protected:
	long GetClientIP();
	bool isConnection();
	long isData();
	bool Disconnect();
	bool isOpen();
	bool isConnected();
	bool Listen();
	bool Accept(TCPSocket&);
	bool Receive(char *crecv);
	int Receive(char *crecv, int length);
	int Send(const char *csend, int length);
	bool Send(char send);
	bool Close();
	bool Connect(char *addr, UINT port);
	bool Create(int LocalPort);
	SOCKET m_hSocket;

	static bool GetHostByName(const char *Name, char *dest);

//	char *ErrorName(int error);
	bool valid;
//private:
//	WSADATA wsa;
};

#endif // !defined(AFX_WINSOCKET_H__2B84B082_914A_11D3_B72A_00AA00644CD7__INCLUDED_)
