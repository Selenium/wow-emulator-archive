//////////////////////////////////////////////////////////////////////
//  Console.cpp
//
//  Non-system-specific console functions
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

#include <stdio.h>
#include <stdarg.h>

createFileSingleton (Console);

bool Console::UseColoredText = false;
char *Console::ReadlineHistory [32];
int Console::ReadlineHistoryLen = 0;
uint8 Console::ColorStack [64];
int Console::ColorStackDepth = 0;
uint8 Console::CurrentFG = 7;
uint8 Console::CurrentBG = 0;

static inline int hex_digit (int x)
{
	if ((x < '0') || (x > 'f') ||
	    ((x < 'a') && (x > 'F')) ||
	    ((x < 'A') && (x > '9')))
		return -1;

	if (x <= '9')
		return x - '0';
	else
		return 10 + (x & 0xdf) - 'A';
}

void Console::PushColor ()
{
	uint8 fg, bg;
	GetTextColor (&fg, &bg);
	if (ColorStackDepth < (int)ARRAY_LEN (ColorStack)) {
		ColorStack [ColorStackDepth++] = fg;
		ColorStack [ColorStackDepth++] = bg;
	} else
		fprintf (stderr, "\nWARNING: Text color stack overflow. This indicates a bug in your program\n");
}

void Console::PopColor ()
{
	uint8 fg, bg;
	if (ColorStackDepth > 0) {
		bg = ColorStack [--ColorStackDepth];
		fg = ColorStack [--ColorStackDepth];
		SetTextColor (fg, bg);
	} else
		fprintf (stderr, "\nWARNING: Text color stack underflow. This indicates a bug in your program\n");
}

/**
 * Just like printf, but supports additional control codes.
 * "\a1fBlah \axaYeah \a3xIndeed" would produce "Blah" as white letters on blue
 * background, then "Yeah" as bright green letters on same background (any chars
 * except 0-9 a-f A-F stay for "don't change"), and, finally, "Indeed" would be
 * printed as bright green letters on cyan background.
 *
 * If the two characters after \a are 'pu', the current color is pushed into a
 * 32-element-deep stack, and there is the 'po' command for popping the text
 * color from that stack. Make sure those always comes in pairs.
 *
 * Returns the number of actual characters displayed.
 */
int Console::TextOutput (const char *format, ...)
{
	char line [4096];
	va_list args;
	va_start (args, format);
	vsnprintf (line, sizeof (line), format, args);
	va_end (args);

        // This is scary ... any better method?
        return (*(Console*)NULL) << line;
}

int Console::operator << (const char *string)
{
	int rc = 0;

        const char *span_start = string;
	const char *cur = span_start;
	while (*cur) {
		if (*cur == '\a') {
			// Spit out whatever we have in pocket
			rc += RawOutput (span_start, cur - span_start);

			if ((cur [1] & 0xdf) == 'P') {
				if ((cur [2] & 0xdf) == 'U')
					PushColor ();
				else if ((cur [2] & 0xdf) == 'O')
					PopColor ();
			} else {
				int bg = hex_digit ((unsigned char)cur [1]);
				int fg = hex_digit ((unsigned char)cur [2]);
				SetTextColor (fg, bg);
			}

			cur += 3;
			span_start = cur;
		} else
			cur++;
	}
	rc += RawOutput (span_start, cur - span_start);
	return rc;
}

/**
 * Read a line from terminal, implementing minimal line editing capabilities.
 * Returns number of characters entered.
 */
int Console::ReadLine (const char *Prompt, char *Buffer, size_t BufferSize)
{
	if (!Buffer || !BufferSize)
		return 0;

	// Leave space for the ending zero
	BufferSize--;

	// Index of the first visible character
	int left_vis = 0;
	// Overall length of the string
	int length = 0;
	// Current cursor position
	int cursor = 0;
	// Current history position
	int hist_pos = ReadlineHistoryLen;

	Buffer [length] = 0;

#define SCROLL_STEP 8
	for (;;)
	{
		// Display the prompt and compute the screen left margin
		int prompt_w = TextOutput ("\r%s", Prompt) - 1;

		// Now display the edited string
		int term_width;
		GetSize (&term_width, NULL);

redisplay:
		// Find out how many characters we can display
		int str_width = term_width - prompt_w - 1;
		int lv = left_vis;

		// Leave space for the left "< " mark
		if (left_vis) {
			str_width -= 2;
			lv += 2;
		}
		// Leave space for the right " >" mark
		int right_mark = 0;
		if (lv + str_width < length) {
			str_width -= 2;
			right_mark = 1;
		}

		if (lv + str_width > length)
			str_width = length - lv;

		if (cursor < lv) {
			left_vis -= SCROLL_STEP;
			if (left_vis < 0)
				left_vis = 0;
			goto redisplay;
		}
		if (cursor > lv + str_width) {
			left_vis += SCROLL_STEP;
			if (left_vis > length)
				left_vis = length;
			goto redisplay;
		}

		char old_c = Buffer [lv + str_width];
		Buffer [lv + str_width] = 0;
		TextOutput ("%s%s%s", lv ? "\aPU\aXF< \aPO" : "",
			    Buffer + lv, right_mark ? "\aPU\aXF >\aPO" : "");
		Buffer [lv + str_width] = old_c;

		// Fill with spaces until EOL
		str_width = term_width - 1 - (prompt_w + (lv ? 2 : 0) + length - lv);
		if (str_width > 0) {
			char *spaces = new char [str_width + 1];
			memset (spaces, ' ', str_width);
			spaces [str_width] = 0;
			TextOutput ("%s", spaces);
			delete [] spaces;
		}
		// Now backspace until we stop at the cursor position
		str_width = term_width - 1 - (prompt_w + (lv ? 2 : 0) +
					      cursor - lv);
		if (str_width > 0) {
			char *backsp = new char [str_width + 1];
			memset (backsp, 8, str_width);
			backsp [str_width] = 0;
			TextOutput ("%s", backsp);
			delete [] backsp;
		}

		int key = GetKey ();
		switch (key) {
		case KEY_BACKSP:
			if (cursor > 0) {
				if (cursor <= length)
					memmove (Buffer + cursor - 1,
						 Buffer + cursor,
						 length - cursor + 1);
				cursor--; length--;
			}
			break;

		case MASK_CTRL | KEY_BACKSP: {
                        int old_cursor = cursor;
			while ((cursor > 0) && isspace (Buffer [cursor - 1]))
				cursor--;
			while ((cursor > 0) && !isspace (Buffer [cursor - 1]))
				cursor--;
			if (old_cursor <= length)
				memmove (Buffer + cursor,
					 Buffer + old_cursor,
					 length - old_cursor + 1);
			length -= old_cursor - cursor;
			break;
		}

		case KEY_DEL:
			if (cursor < length) {
				memmove (Buffer + cursor,
					 Buffer + cursor + 1,
					 length - cursor);
				length--;
			}
			break;

		case KEY_ENTER:
			printf ("\n");
			goto done;

		case KEY_LEFT:
			if (cursor > 0)
				cursor--;
			break;

		case KEY_RIGHT:
			if (cursor < length)
				cursor++;
			break;

		case KEY_HOME:
			cursor = 0;
			break;

		case KEY_END:
			cursor = length;
			break;

		case MASK_CTRL | KEY_LEFT:
			while ((cursor > 0) && isspace (Buffer [cursor - 1]))
				cursor--;
			while ((cursor > 0) && !isspace (Buffer [cursor - 1]))
				cursor--;
			break;

		case MASK_CTRL | KEY_RIGHT:
			while ((cursor < length) && !isspace (Buffer [cursor]))
				cursor++;
			while ((cursor < length) && isspace (Buffer [cursor]))
				cursor++;
			break;

		case KEY_UP:
			if (hist_pos > 0) {
				hist_pos--;
				goto load_hist;
			}
			break;

		case KEY_DOWN:
			if (hist_pos >= ReadlineHistoryLen)
				break;
			hist_pos++;
		load_hist:
			if (hist_pos >= ReadlineHistoryLen)
				Buffer [length = 0] = 0;
			else {
				length = strlen (ReadlineHistory [hist_pos]);
				if (length >= (int)BufferSize)
					length = BufferSize - 1;
				memcpy (Buffer, ReadlineHistory [hist_pos], length);
			}
			Buffer [length] = 0;
			cursor = length;
			left_vis = 0;
			break;

		case KEY_ESC:
			Buffer [left_vis = cursor = length = 0] = 0;
			break;

		default:
			if (key >= 32 && key < 256 && length < (int)BufferSize) {
				if (cursor <= length)
					memmove (Buffer + cursor + 1,
						 Buffer + cursor,
						 length - cursor + 1);
				Buffer [cursor] = key;
				cursor++; length++;
			}
			break;
		}
	}

done:
	if (Buffer [0])
		ReadLineHistoryPush (Buffer);

	return length;
}

void Console::ReadLineHistoryPush (const char *String)
{
	// Push the entered string into the history buffer
	if (ReadlineHistoryLen > (int)ARRAY_LEN (ReadlineHistory)) {
		delete [] ReadlineHistory [0];
		memmove (ReadlineHistory, ReadlineHistory + 1,
			 (ARRAY_LEN (ReadlineHistory) - 1) * sizeof (char *));
	} else
		ReadlineHistoryLen++;

        size_t sl = strlen (String);
	char *buff = new char [sl + 1];
	memcpy (buff, String, sl + 1);
	ReadlineHistory [ReadlineHistoryLen - 1] = buff;
}

// for testing
#ifdef CONSOLE_DEBUG

#include <locale.h>

int main ()
{
	Console &c = CONSOLE;
        setlocale (LC_ALL, "");
#if 0
	for (;;)
		if (!c.KeyPressed ()) {
			printf (".");
			fflush (stdout);
			SleepMs (100);
		} else {
			int key = c.GetKey ();
			if (key == 'q')
				break;
                        if (key != -1)
				printf ("\nctrl: %d  alt: %d  shift: %d  key: %d\n",
					(key & Console::MASK_CTRL) != 0, (key & Console::MASK_ALT) != 0,
					(key & Console::MASK_SHIFT) != 0, key & Console::MASK_KEY);
			else
				printf ("\nUnkown key pressed\n");
                }
#else
	char line [300];
	while (c.ReadLine ("\ax1C\ax3r\ax9o\axba\axfk\ax4>\ax7", line, sizeof (line)) != 0)
		printf ("Got [%s]\n", line);
#endif
}
#endif
