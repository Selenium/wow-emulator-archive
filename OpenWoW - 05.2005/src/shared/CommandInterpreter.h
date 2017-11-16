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

#ifndef __COMMANDINTERPRETER_H__
#define __COMMANDINTERPRETER_H__

#include "Common.h"

#define MAX_COMMAND_ARGS 4

// String arguments are passed as-is, with interpreted escape commands like \n\r\a\t etc
#define ARG_STR		0
// Integer arguments 
#define ARG_INT		1
// Boolean arguments (on/off, yes/no, 1/0)
#define ARG_BOOL	2
// Missing optional strings are passed as NULLs, other types get NO_ARG
#define ARG_OPT		0x80

#define ARG_OSTR	(ARG_OPT | ARG_STR)
#define ARG_OINT	(ARG_OPT | ARG_INT)
#define ARG_OBOOL	(ARG_OPT | ARG_BOOL)

#define NO_ARG		((uintptr)-1)

/**
 * This structure describes a server console command.
 */
struct CommandDesc
{
	/// The command
	const char *Name;
	/// Number of command arguments
	int NumArgs;
	/// An array of command argument types (OPTional arguments may be missing)
	uint8 Type [MAX_COMMAND_ARGS];
	/**
	 * The command callback; if it returns non-zero, interpreter quits.
	 * Every parameter specified in the Type array is passed either
	 * as a char *pointer (ARG_STR) or a uintptr (ARG_INT and ARG_BOOL).
	 */
	typedef int (*ExecuteFunc) (void *, ...);
	ExecuteFunc Execute;
#define CMDFUNC(x) ((CommandDesc::ExecuteFunc)x)
	/// Command description
	const char *Description;
};

/**
 * Invoke an interactive command interpreter.
 * @arg ConfigFile
 *   This is the 'autoexec' script to execute at startup.
 * @arg UserData
 *   A black box pointer to be passed to every Execute() function as first arg.
 * @arg Commands
 *   Pointer to array of structs describing the commands.
 * @arg NumCommands
 *   The number of elements in the Commands array.
 * @arg Prompt
 *   The prompt to display for command input.
 * @arg BadCommandHint
 *   The hint to display after "Bad command".
 * @return
 *   Nothing
 */
extern void CommandInterpreter (const char *ConfigFile, void *UserData,
				CommandDesc *Commands, int NumCommands,
				const char *Prompt);

#endif // __COMMANDINTERPRETER_H__
