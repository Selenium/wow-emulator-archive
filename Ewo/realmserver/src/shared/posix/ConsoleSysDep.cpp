//////////////////////////////////////////////////////////////////////
//  Console.cpp
//
//  Posix-specific console functions
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2005 Team WSD
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

#include "Console.h"
#include "SystemFun.h"

#include <stdlib.h>
#include <unistd.h>
#include <sys/select.h>
#include <sys/ioctl.h>
#include <termios.h>

#if defined HAVE_LIBTERMCAP
#  include <termcap.h>
#else
#if defined HAVE_LIBNCURSES
#  include <ncurses/termcap.h>
#endif
#endif

static char ColorXlat [] =
{
	'0',
	'4',
	'2',
	'6',
	'1',
	'5',
	'3',
	'7',
};

static struct termios initial_tio;
static bool bsp_127 = true;

Console::Console ()
{
	const char *term = getenv ("TERM");
	if (!term)
		return;

	tcgetattr (0, &initial_tio);
	struct termios tio = initial_tio;
	tio.c_lflag &= ~(ICANON | ECHO);
	tcsetattr (0, TCSANOW, &tio);

#if defined HAVE_LIBTERMCAP || defined HAVE_LIBNCURSES
	// Get some minimal info about terminal capabilities
	char termbuf [2048];
	if (tgetent (termbuf, term) >= 0) {
		char tcbuff [100];
		char *buff = tcbuff;
		char *bsp = tgetstr ("bc", &buff);
		if (bsp && strcmp (bsp, "^H") == 0)
			bsp_127 = false;
                buff = tcbuff;
		if (tgetstr ("AF", &buff))
			UseColoredText = true;
        }
#else
        // Hardcode most used terminal types
	if (strstr (term, "xterm") ||
	    strstr (term, "rxvt") ||
	    strstr (term, "linux"))
		UseColoredText = true;
#endif
}

Console::~Console ()
{
	tcsetattr (0, TCSANOW, &initial_tio);
}

void Console::Clear ()
{
	if (!UseColoredText)
		return;

	write (STDOUT_FILENO, "\x1b[0m\x1b[H\x1b[2J", 11);
}

void Console::GetTextColor (uint8 *fg, uint8 *bg)
{
	if (fg)
		*fg = CurrentFG;
	if (bg)
		*bg = CurrentBG;
}

void Console::SetTextColor (int fg, int bg)
{
	if (!UseColoredText)
		return;

	char attr [16];
	strcpy (attr, "\x1b[");
	char *cur = attr + 3;
	if (fg >= 0 && fg <= 15 && CurrentFG != fg) {
		cur += sprintf (cur - 1, "%c;3%c;", fg > 7 ? '1' : '0', ColorXlat [fg & 7]) - 1;
		CurrentFG = fg;
	}
	if (bg >= 0 && bg <= 7 && CurrentBG != bg) {
		cur += sprintf (cur - 1, "4%c;", ColorXlat [bg]) - 1;
		CurrentBG = bg;
	}
	cur [-1] = 'm';
	write (STDOUT_FILENO, attr, cur - attr);
}

void Console::GetSize (int *Columns, int *Rows)
{
	int screen_cols, screen_rows;
	struct winsize ws;
        if (ioctl (1, TIOCGWINSZ, &ws) != -1 && ws.ws_col > 0 && ws.ws_row > 0) {
		screen_cols = ws.ws_col;
		screen_rows = ws.ws_row;
	} else {
		screen_cols = 80;
		screen_rows = 24;
	}

	char *columns = getenv("COLUMNS");
	char *lines = getenv("LINES");

	if (columns && *columns)
		screen_cols = atoi (columns);
	if (lines && *lines)
		screen_rows = atoi (lines);
	if ((screen_cols < 9) || (screen_rows < 2) ||
	    (screen_cols > 500) || (screen_rows > 300)) {
		screen_cols = 80;
		screen_rows = 24;
	}

	if (Columns)
		*Columns = screen_cols;
	if (Rows)
		*Rows = screen_rows;
}

int Console::RawOutput (const void *String, size_t Length)
{
	return write (STDOUT_FILENO, String, Length);
}

//--------------------------// Keyboard handling //--------------------------//

bool Console::KeyPressed ()
{
	// We'd better use poll() but select() is enough, and who knows
	// what obscure platforms will somebody try to compile this on ...
	fd_set fds;
	FD_ZERO (&fds);
	FD_SET (STDIN_FILENO, &fds);

	struct timeval tv;
	tv.tv_sec = 0;
	tv.tv_usec = 0;

	return (select (1, &fds, NULL, NULL, &tv) > 0);
}

struct KeyXlatTable
{
	unsigned short code;
	char key;
};

// linux console F-keys -- ESC [ [ <code>
static KeyXlatTable kxLinuxFx [] = {
        { Console::KEY_F1,    'A' },
	{ Console::KEY_F2,    'B' },
	{ Console::KEY_F3,    'C' },
	{ Console::KEY_F4,    'D' },
        { Console::KEY_F5,    'E' },
};

// Standard arrow keys -- ESC [ <code>
static KeyXlatTable kxStdKeys [] = {
        { Console::KEY_UP,    'A' },
        { Console::KEY_DOWN,  'B' },
	{ Console::KEY_RIGHT, 'C' },
	{ Console::KEY_LEFT,  'D' },
	{ Console::KEY_HOME,  'H' },
	{ Console::KEY_END,   'F' },
};

// Numeric pad -- ESC O <code>
static KeyXlatTable kxPadKeys [] = {
	{ Console::KEY_HOME,  'w' },
        { Console::KEY_INS,   'p' },
	{ Console::KEY_DEL,   'n' },
        { Console::KEY_END,   'q' },
	{ Console::KEY_PGUP,  'y' },
        { Console::KEY_PGDN,  's' },
        { Console::KEY_UP,    'x' },
        { Console::KEY_DOWN,  'r' },
	{ Console::KEY_LEFT,  't' },
        { Console::KEY_RIGHT, 'v' },
        { Console::MASK_CTRL | Console::KEY_UP,    'a' },
        { Console::MASK_CTRL | Console::KEY_DOWN,  'b' },
        { Console::MASK_CTRL | Console::KEY_RIGHT, 'c' },
	{ Console::MASK_CTRL | Console::KEY_LEFT,  'd' },
	// xterm
	{ Console::KEY_F1,    'P' },
	{ Console::KEY_F2,    'Q' },
	{ Console::KEY_F3,    'R' },
	{ Console::KEY_F4,    'S' },
};

// Extended keys (the most logical and easy to use scheme) -- ESC [ <code> {~|^|$|@}
static KeyXlatTable kxExtKeys [] = {
	{ Console::KEY_HOME,  1 },
	{ Console::KEY_INS,   2 },
	{ Console::KEY_DEL,   3 },
        { Console::KEY_END,   4 },
	{ Console::KEY_PGUP,  5 },
        { Console::KEY_PGDN,  6 },
        { Console::KEY_F5,    15 },
	{ Console::KEY_F6,    17 },
	{ Console::KEY_F7,    18 },
	{ Console::KEY_F8,    19 },
	{ Console::KEY_F9,    20 },
        { Console::KEY_F10,   21 },
	{ Console::KEY_F11,   23 },
	{ Console::KEY_F12,   24 },
	{ Console::MASK_SHIFT | Console::KEY_F3,  25 },
	{ Console::MASK_SHIFT | Console::KEY_F4,  26 },
	{ Console::MASK_SHIFT | Console::KEY_F5,  28 },
	{ Console::MASK_SHIFT | Console::KEY_F6,  29 },
	{ Console::MASK_SHIFT | Console::KEY_F7,  31 },
	{ Console::MASK_SHIFT | Console::KEY_F8,  32 },
	{ Console::MASK_SHIFT | Console::KEY_F9,  33 },
	{ Console::MASK_SHIFT | Console::KEY_F10, 34 },
};

static int FindXlat (unsigned char c, KeyXlatTable *kxt, size_t kxt_len)
{
	for (size_t i = 0; i < kxt_len; i++)
		if (kxt [i].key == c)
			return kxt [i].code;
	return -1;
}

// Read one more character, if it comes in 0.1 secs
static int ReadKeyNoWait ()
{
	unsigned char c;
	int countdown = 3;
	while (countdown--) {
                if (Console::KeyPressed ()) {
			if (read (STDIN_FILENO, &c, sizeof (c)) > 0)
				return c;
		}
		SleepMs (33);
	}
	return -1;
}

static int DecodeShifts (unsigned char c)
{
	switch (c) {
	case 3:
		return Console::MASK_ALT;
	case 5:
		return Console::MASK_CTRL;
	case 7:
		return Console::MASK_ALT | Console::MASK_CTRL;
	}
	return 0;
}

static int ExtendedKey (unsigned char c2)
{
	unsigned char c3, c4;

	if (c2 == 27 || c2 == '[' || c2 == 'O') {
		int key = ReadKeyNoWait ();
		if (key == -1) {
			if (c2 == 27)
                                return Console::MASK_ALT | Console::KEY_ESC;
			return -1;
		}
		c3 = key;
	}

	switch (c2) {
	case 27:
		return Console::MASK_ALT | ExtendedKey (c3);
	case '[':
		if (c3 == '[') {
			if (read (STDIN_FILENO, &c4, sizeof (c4)) <= 0)
				return -1;
			return FindXlat (c4, kxLinuxFx, ARRAY_LEN (kxLinuxFx));
		}

		if (c3 >= '0' && c3 <= '9') {
			// Very good, this key code scheme is the best
			unsigned char val = c3 - '0';
			unsigned char val2 = 0;
			unsigned short mask = 0;
			for (;;) {
				if (read (STDIN_FILENO, &c3, sizeof (c3)) <= 0)
					return -1;
				if (c3 == '~')
					break;
				if (c3 == '^') {
					mask = Console::MASK_CTRL;
					break;
				}
				if (c3 == '$') {
					mask = Console::MASK_SHIFT;
					break;
				}
				if (c3 == '@') {
					mask = Console::MASK_CTRL | Console::MASK_SHIFT;
					break;
				}
				if (c3 == ';') {
					if (val2)
						return -1;
					val2 = val;
					val = 0;
					continue;
				}

				if (c3 < '0' || c3 > '9')
					if (val2 == 0)
						return -1;
					else
						break;
				val = (val * 10) + (c3 - '0');
			}
			if (val2 == 0)
				return mask | FindXlat (val, kxExtKeys, ARRAY_LEN (kxExtKeys));
			else if (val2 == 1) {
				int key = FindXlat (c3, kxStdKeys, ARRAY_LEN (kxStdKeys));
				if (key > 0)
					return DecodeShifts (val) | key;
			}
			else if (mask == 0) {
				int key = FindXlat (val2, kxExtKeys, ARRAY_LEN (kxExtKeys));
				if (key > 0)
					return DecodeShifts (val) | key;
			}
			return -1;
		}

		return FindXlat (c3, kxStdKeys, ARRAY_LEN (kxStdKeys));

	case 'O': {
		unsigned short mask = 0;
		if ((c3 >= '0') && (c3 <= '9')) {
			if (read (STDIN_FILENO, &c4, sizeof (c4)) <= 0)
				return -1;
			mask = DecodeShifts (c3 - '0');
			c3 = c4;
		}
		return mask | FindXlat (c3, kxPadKeys, ARRAY_LEN (kxPadKeys));
	}

	default:
		// If the second char is not an extended key prefix,
		// return an Alt+# combination
		return 256 + c2;
	}
}

int Console::GetKey ()
{
	unsigned char c;

	if (read (STDIN_FILENO, &c, sizeof (c)) < 0)
		return -1;

	// Convert XTerm's backspace into our code
	if (c == 127)
		return bsp_127 ? KEY_BACKSP : (MASK_CTRL | KEY_BACKSP);
	if (c == 8)
		return bsp_127 ? (MASK_CTRL | KEY_BACKSP) : KEY_BACKSP;
        // Treat \n as enter, as well as \r
	if (c == 10 || c == KEY_ENTER)
		return KEY_ENTER;
        // Do not modify basic control keys
	if (c == KEY_TAB)
		return c;

	// Modify the appearance of Ctrl+Alphabetic keys
	if (c < 27)
		return MASK_CTRL | (c + 64);

	if (c != 0x1b)
		return c;

	// Handle Alt+# codes as well
	int key = ReadKeyNoWait ();
	if (key != -1)
		return ExtendedKey (key);

	return 0x1b;
}
