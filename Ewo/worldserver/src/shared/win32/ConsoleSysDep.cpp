//////////////////////////////////////////////////////////////////////
//  Console.cpp
//
//  Windows-specific console functions
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2005 Team WSD
// Copyright (C) 2006 Team Evolution
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <conio.h>

#include "Console.h"

static uint8 BgColorXlat [] =
{
	0,
	BACKGROUND_BLUE,
	BACKGROUND_GREEN,
	BACKGROUND_BLUE | BACKGROUND_GREEN,
	BACKGROUND_RED,
	BACKGROUND_RED | BACKGROUND_BLUE,
	BACKGROUND_RED | BACKGROUND_GREEN,
	BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE
};

static uint8 FgColorXlat [] =
{
	0,
	FOREGROUND_BLUE,
	FOREGROUND_GREEN,
	FOREGROUND_BLUE | FOREGROUND_GREEN,
	FOREGROUND_RED,
	FOREGROUND_RED | FOREGROUND_BLUE,
	FOREGROUND_RED | FOREGROUND_GREEN,
	FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE,
	FOREGROUND_INTENSITY,
	FOREGROUND_INTENSITY | FOREGROUND_BLUE,
	FOREGROUND_INTENSITY | FOREGROUND_GREEN,
	FOREGROUND_INTENSITY | FOREGROUND_BLUE | FOREGROUND_GREEN,
	FOREGROUND_INTENSITY | FOREGROUND_RED,
	FOREGROUND_INTENSITY | FOREGROUND_RED | FOREGROUND_BLUE,
	FOREGROUND_INTENSITY | FOREGROUND_RED | FOREGROUND_GREEN,
	FOREGROUND_INTENSITY | FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE
};

Console::Console ()
{
	SetConsoleMode (GetStdHandle (STD_INPUT_HANDLE), ENABLE_PROCESSED_OUTPUT);
	UseColoredText = true;
}

Console::~Console ()
{
}

static uint8 MakeAttr (uint8 fg, uint8 bg)
{
	return BgColorXlat [bg] | FgColorXlat [fg];
}

void Console::Clear ()
{
	if (!UseColoredText)
		return;

	CurrentFG = 7;
	CurrentBG = 0;

	HANDLE hConsole = GetStdHandle (STD_OUTPUT_HANDLE);

	CONSOLE_SCREEN_BUFFER_INFO csbi;
	GetConsoleScreenBufferInfo (hConsole, &csbi);

	DWORD dwConSize = csbi.dwSize.X * csbi.dwSize.Y;

	DWORD cCharsWritten;
	COORD coordScreen = { 0, 0 };
	FillConsoleOutputCharacter (hConsole, ' ',
		dwConSize, coordScreen, &cCharsWritten);
	FillConsoleOutputAttribute (hConsole, MakeAttr (CurrentFG, CurrentBG),
		dwConSize, coordScreen, &cCharsWritten);
	SetConsoleCursorPosition (hConsole, coordScreen);
}

void Console::SetTextColor (int fg, int bg)
{
	if (!UseColoredText)
		return;

	if (fg >= 0 && fg <= 15)
		CurrentFG = fg;
	if (bg >= 0 && bg <= 7)
		CurrentBG = bg;
	SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),
		MakeAttr (CurrentFG, CurrentBG));
}

void Console::GetTextColor (uint8 *fg, uint8 *bg)
{
	if (fg)
		*fg = CurrentFG;
	if (bg)
		*bg = CurrentBG;
}

void Console::GetSize (int *Columns, int *Rows)
{
	HANDLE hConsole = GetStdHandle (STD_OUTPUT_HANDLE);
	CONSOLE_SCREEN_BUFFER_INFO csbi;
        if (!GetConsoleScreenBufferInfo (hConsole, &csbi)) {
                csbi.dwSize.X = 80;
                csbi.dwSize.Y = 25;
        }

	if (Columns)
		*Columns = csbi.dwSize.X;
	if (Rows)
                *Rows = csbi.dwSize.Y;
}

int Console::RawOutput (const void *String, size_t Length)
{
	DWORD cw;
	WriteConsole (GetStdHandle (STD_OUTPUT_HANDLE),
		      String, Length, &cw, NULL);
	return cw;
}

//--------------------------// Keyboard handling //--------------------------//

static struct
{
	unsigned short vkey;
	unsigned short code;
} key_xlat [] =
{
  { VK_BACK,	Console::KEY_BACKSP },
  { VK_TAB,	Console::KEY_TAB },
  { VK_RETURN,	Console::KEY_ENTER },
  { VK_ESCAPE,	Console::KEY_ESC },
  { VK_PRIOR,	Console::KEY_PGUP },
  { VK_NEXT,	Console::KEY_PGDN },
  { VK_END,	Console::KEY_END },
  { VK_HOME,	Console::KEY_HOME },
  { VK_LEFT,	Console::KEY_LEFT },
  { VK_UP,	Console::KEY_UP },
  { VK_RIGHT,	Console::KEY_RIGHT },
  { VK_DOWN,	Console::KEY_DOWN },
  { VK_INSERT,	Console::KEY_INS },
  { VK_DELETE,	Console::KEY_DEL },
  { VK_F1,	Console::KEY_F1 },
  { VK_F2,	Console::KEY_F2 },
  { VK_F3,	Console::KEY_F3 },
  { VK_F4,	Console::KEY_F4 },
  { VK_F5,	Console::KEY_F5 },
  { VK_F6,	Console::KEY_F6 },
  { VK_F7,	Console::KEY_F7 },
  { VK_F8,	Console::KEY_F8 },
  { VK_F9,	Console::KEY_F9 },
  { VK_F10,	Console::KEY_F10 },
  { VK_F11,	Console::KEY_F11 },
  { VK_F12,	Console::KEY_F12 },
};

static int GetFuncKey (KEY_EVENT_RECORD *ke)
{
	for (unsigned i = 0; i < ARRAY_LEN (key_xlat); i++)
		if (ke->wVirtualKeyCode == key_xlat [i].vkey)
			return key_xlat [i].code;
	return -1;
}

bool Console::KeyPressed ()
{
	int keycode = -1;
        INPUT_RECORD ir;
        DWORD nr;

	while (PeekConsoleInput (GetStdHandle (STD_INPUT_HANDLE), &ir, 1, &nr) && nr) {
		bool skip_ev = ((ir.EventType != KEY_EVENT) ||
				!ir.Event.KeyEvent.bKeyDown);
		keycode = (unsigned char)ir.Event.KeyEvent.uChar.AsciiChar;
		if (!keycode)
			keycode = GetFuncKey (&ir.Event.KeyEvent);
		if (keycode <= 0)
			skip_ev = true;

		if (!skip_ev)
			return true;

		if (!ReadConsoleInput (GetStdHandle (STD_INPUT_HANDLE), &ir, 1, &nr) || !nr)
			return false;
	}

	return false;
}


int Console::GetKey ()
{
	int keycode = -1;
        INPUT_RECORD ir;
        DWORD nr;

	while (ReadConsoleInput (GetStdHandle (STD_INPUT_HANDLE), &ir, 1, &nr)) {
		if (nr && (ir.EventType == KEY_EVENT) && (ir.Event.KeyEvent.bKeyDown)) {
			int ascii_char = (unsigned char)ir.Event.KeyEvent.uChar.AsciiChar;
			int func_key = GetFuncKey (&ir.Event.KeyEvent);
			keycode = ascii_char;
			if (!keycode || ascii_char == 127)
				keycode = func_key;
			if (keycode <= 0)
				continue;
			if (ir.Event.KeyEvent.dwControlKeyState & (LEFT_CTRL_PRESSED | RIGHT_CTRL_PRESSED)) {
				keycode |= MASK_CTRL;
				if (func_key <= 0 && (ascii_char < 32))
					keycode += 64;
			}
			if (ir.Event.KeyEvent.dwControlKeyState & (LEFT_ALT_PRESSED | RIGHT_ALT_PRESSED))
				keycode |= MASK_ALT;

			if ((func_key > 0) &&
			    (ir.Event.KeyEvent.dwControlKeyState & SHIFT_PRESSED))
				keycode |= MASK_SHIFT;

			return keycode;
		}
	}
	return -1;
}
