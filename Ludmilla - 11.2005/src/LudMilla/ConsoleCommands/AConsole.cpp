//******************************************************************************
#include "StdAfx.h"

#ifdef _WIN32

//******************************************************************************
							// Win32 Implementation
//******************************************************************************
#include <conio.h>
//==============================================================================
							// Public methods:
//------------------------------------------------------------------------------
// Get char from console or EOF
int CAConsole::GetChar()
{
	int ret = EOF;

	if (!RealConsole)
	{
		DWORD read = 0;
		BOOL gor = 0;
		DWORD err = ERROR_SUCCESS;

		if (keyread != 1)
		{
			gor = GetOverlappedResult(hStdIn, &ol, &read, false);
			if (gor == 0)
			{
				err = GetLastError();
				if (err != ERROR_IO_INCOMPLETE)
				{
					sLog.outError("GetOverlappedResult, code=%d", err);
					return EOF;
				}
			}
		}

		if ( keyread==1 || (gor!=0 && read==1) )
		{
			ret = key;
			keyread = 0;
			BOOL rf = ReadFile(hStdIn, &key, 1, &keyread, &ol);
			if (rf == 0)
			{
				err = GetLastError();
				if (err != ERROR_IO_PENDING)
					sLog.outError("ReadFile, code=%d", err);
			}
		}
	}
	else
	{
		if (_kbhit() != 0)
			ret = getch();
	}

	return ret;
}
//------------------------------------------------------------------------------
// Constructor
CAConsole::CAConsole()
{
	DWORD err = ERROR_SUCCESS;

	ol.hEvent = 0;
	ol.Internal = 0;
	ol.InternalHigh = 0;
	ol.Offset = 0;
	ol.OffsetHigh = 0;
	ol.Pointer = 0;

	hStdIn = GetStdHandle(STD_INPUT_HANDLE);
	if (hStdIn == INVALID_HANDLE_VALUE)
	{
		err = GetLastError();
		sLog.outError("GetStdHandle, code=%d", err);
		// return;
	}

	DWORD type = GetFileType(hStdIn);
	if (type == FILE_TYPE_UNKNOWN)
	{
		err = GetLastError();
		if (err != NO_ERROR)
			sLog.outError("GetFileType, code=%d", err);
	}


	RealConsole = type==FILE_TYPE_CHAR;

	if (!RealConsole)
	{
		BOOL rf = ReadFile(hStdIn, &key, 1, &keyread, &ol);
		if (rf == 0)
		{
			err = GetLastError();
			if (err != ERROR_IO_PENDING)
				sLog.outError("ReadFile, code=%d", err);
		}
	}
}
//------------------------------------------------------------------------------
// Simple destructor
CAConsole::~CAConsole()
{
	if (hStdIn!=INVALID_HANDLE_VALUE && !RealConsole)
		CancelIo(hStdIn);
}
//******************************************************************************

#else // ndef _win32

//******************************************************************************
							// Not Win32 Implementation
//******************************************************************************
// _kbhit is not ANSI func, but it is implemented by Borland and MS
// i've found (have not tested) this implementation of kbhit for Linux:
// http://sxs.thexdershome.com/programming/kbhit.html
// also see
// http://www.uclinux.org/pub/uClinux/archive/1602.html

// text from http://sxs.thexdershome.com/programming/kbhit.html
/*
"_sleep()" can be replaced by a number of Linux (UNIX) functions, depending on the time resolution. Below are some of these functions (reference the man pages).

sleep() - second resolution
usleep() - microsecond resolution
nanosleep() - nanosecond resolution


getch() is getchar() or use the readch() function I provide below.

kbhit() is not available on Linux (UNIX), it is a DOS function. Below is some code (functions) to replace the "kbhit" functionality (this code is from a book called "Beginning Linux Programming", from Wrox Press -- www.wrox.com -- you can download the Code Examples from the Book at this Site):
*/

#include <unistd.h> // read()
//==============================================================================
							// Public methods:
//------------------------------------------------------------------------------
// Get char from console or EOF
int CAConsole::GetChar()
{
	if (kbhit() == 0)
		return EOF;
	else
		return getchar();
}
//------------------------------------------------------------------------------
// Constructor
CAConsole::CAConsole()
{
	tcgetattr(0,&initial_settings);
	new_settings = initial_settings;
	new_settings.c_lflag &= ~ICANON;
	new_settings.c_lflag &= ~ECHO;
	new_settings.c_lflag &= ~ISIG;
	new_settings.c_cc[VMIN] = 1;
	new_settings.c_cc[VTIME] = 0;
	tcsetattr(0, TCSANOW, &new_settings);
	peek_character=-1;
}
//------------------------------------------------------------------------------
// Simple destructor
CAConsole::~CAConsole()
{
	tcsetattr(0, TCSANOW, &initial_settings);
}
//------------------------------------------------------------------------------
							// Protected methods:
//------------------------------------------------------------------------------
int CAConsole::kbhit()
{
	unsigned char ch;
	int nread;

	if (peek_character != -1) return 1;
	new_settings.c_cc[VMIN]=0;
	tcsetattr(0, TCSANOW, &new_settings);
	nread = read(0,&ch,1);
	new_settings.c_cc[VMIN]=1;
	tcsetattr(0, TCSANOW, &new_settings);

	if (nread == 1) 
	{
		peek_character = ch;
		return 1;
	}
	return 0;
}
//------------------------------------------------------------------------------
int CAConsole::getch()
{
	char ch;

	if (peek_character != -1)
	{
		ch = peek_character;
		peek_character = -1;
	}
	else read(0,&ch,1);

	return ch;
}
//******************************************************************************

#endif