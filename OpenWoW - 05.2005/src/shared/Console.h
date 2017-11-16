//////////////////////////////////////////////////////////////////////
//  Console.h
//
//  System-specific console functions
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

#ifndef __CONSOLE_H__
#define __CONSOLE_H__

#include "Common.h"
#include "Singleton.h"

// Handy shortcut
#define CONSOLE (Console::getSingleton ())

/**
 * A class for interacting with the console.
 * Why a class?... hard to say, mostly to keep hardcore C++ guys happy.
 * For now uses STDIN/STDOUT handles; no initialization parameters are
 * allowed due to the Singleton architecture.
 */
class Console : public Singleton <Console>
{
public:
	/**
	 * Key codes as returned by ReadKey ().
	 * ReadKey uses the following code ranges for different control keys:
	 *
	 * 1-31     special keys like backspace, enter etc
	 * 32..255  ASCII extended codes
	 * 256..511 Functional keys, arrows, ins/del etc.
	 *
	 * Also if a key has been pressed together with a modifier like Ctrl
	 * or Alt, it is added 512 and/or 1024 respectively.
	 *
	 * For example, Alt-A would return 1024+65 = 1089, Ctrl-A would return
	 * 512 + 65 = 577, Ctrl-Alt-A would return 512 + 1024 + 65 = 1601 and so on.
	 */
	enum KeyCodes {
		// Use this mask to extract just the base key code
		MASK_KEY = 511,
		// This mask denotes that a key was pressed together with CTRL
		MASK_CTRL = 512,
		// This mask denotes that a key was pressed together with ALT
		MASK_ALT = 1024,
		// Key was pressed together with SHIFT (ONLY for functional keys)
		MASK_SHIFT = 2048,
		// Special keys
		KEY_BACKSP = 8,
		KEY_ENTER = 13,
		KEY_ESC = 27,
		KEY_TAB = 9,
		// Extended function keys
		KEY_F1 = 256,
		KEY_F2,
		KEY_F3,
		KEY_F4,
		KEY_F5,
		KEY_F6,
		KEY_F7,
		KEY_F8,
		KEY_F9,
		KEY_F10,
		KEY_F11,
		KEY_F12,
		KEY_UP,
		KEY_DOWN,
		KEY_LEFT,
		KEY_RIGHT,
		KEY_HOME,
		KEY_END,
		KEY_INS,
		KEY_DEL,
		KEY_PGUP,
		KEY_PGDN
	};

	/**
	 * Console text color constants (used as values 0 to 0xf in
	 * TextOutput ()). Foreground colors are allowed in the 0..15 range,
	 * background in 0..7 range.
	 */
	enum ConsoleTextColor {
		BLACK = 0,
		DBLUE,
		DGREEN,
		DCYAN,
		DRED,
		DMAGENTA,
		BROWN,
		GRAY,
		LGRAY,
		LBLUE,
		LGREEN,
		LCYAN,
		LRED,
		LMAGENTA,
		YELLOW,
		WHITE
	};

	// Set this to false to disable colored text output
	static bool UseColoredText;

	//-------------------------------------------------------------------//

	// Initialize the object
	Console ();

	// Destroy the object
	~Console ();

	/**
	 * Get terminal size.
	 */
	static void GetSize (int *Columns, int *Rows);

	/**
	 * Clear the whole screen. This resets textcolor to whatever
	 * the defaults are.
	 */
	static void Clear ();

	/**
	 * Change console text color to given Foreground/Background colors.
	 * If either fg and/or bg is -1, that one does not change.
	 */
	static void SetTextColor (int fg, int bg);

	/**
	 * Get current text color.
	 */
	static void GetTextColor (uint8 *fg, uint8 *bg);

	/**
	 * The most basic console output routine. Usually not used,
	 * provided just for implementing more advanced functions like
	 * operator <<
	 * @return
	 *   Number of characters successfuly output.
	 */
	int RawOutput (const void *String, size_t Length);

	/**
	 * Emit a string to console.
	 *
	 * "\a1fBlah \axaYeah \a3xIndeed" would produce "Blah" as white
	 * letters on blue background, then "Yeah" as bright green letters
	 * on same background (any chars except 0-9 a-f A-F stay for
	 * "don't change"), and, finally, "Indeed" would be printed
	 * as bright green letters on cyan background.
	 *
	 * If the two characters after \a are 'pu', the current color is
	 * pushed into a 32-element-deep stack, and there is the 'po' command
	 * for popping the text color from that stack. Make sure those always
	 * comes in pairs.
	 */
	int operator << (const char *string);

	/**
	 * Just like printf, but supports additional control codes
	 * (see operator <<).
	 *
	 * Returns the number of actual characters displayed.
	 */
	static int TextOutput (const char *format, ...);

	/**
	 * Check if a key was pressed.
	 */
	static bool KeyPressed ();

	/**
	 * Read (and wait for, if not available) a keycode from standard input.
	 * See the comments before the definition of the KeyCodes enum.
	 *
	 * Also it has support for some control keys, defined by the KEY_XXX
	 * constants. Not that we write a game engine, but it supports at least
	 * the basic text editing keys.
	 *
	 * The function returns -1 on error or if a unknown key is pressed.
	 */
	static int GetKey ();

	/**
	 * Read a line from terminal, implementing minimal line editing
	 * capabilities. Returns number of characters entered.
	 */
	static int ReadLine (const char *Prompt, char *Buffer, size_t BufferSize);

        /**
         * Push a string into the readline's history buffer.
         */
        static void ReadLineHistoryPush (const char *String);

private:
	// Readline history
	static char *ReadlineHistory [32];
	static int ReadlineHistoryLen;

	// Current foreground & background colors
	static uint8 CurrentFG;
	static uint8 CurrentBG;

	// The stack for \aPU and \aPO ops
	static uint8 ColorStack [64];
	static int ColorStackDepth;

	static void PushColor ();
	static void PopColor ();
};

#endif // __CONSOLE_H__
