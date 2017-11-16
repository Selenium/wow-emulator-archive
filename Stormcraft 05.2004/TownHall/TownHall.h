// TownHall.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifdef WIN32
#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols


// CTownHallApp:
// See TownHall.cpp for the implementation of this class
//

class CTownHallApp : public CWinApp
{
public:
	CTownHallApp();

// Overrides
	public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CTownHallApp theApp;
#endif
