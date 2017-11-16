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

#include "CommandInterpreter.h"
#include "Console.h"

struct BuiltinCmdInfo
{
	CommandDesc *Commands;
	int NumCommands;
};

static int cmdHelp (BuiltinCmdInfo *CmdInfo, char *Cmd);

static CommandDesc BuiltinCommands [] =
{
	{ "help", 1, { ARG_OSTR }, CMDFUNC (cmdHelp),
	  "Help on all commands, or help on a specific command" },
};

static int cmdHelp (BuiltinCmdInfo *CmdInfo, char *Cmd)
{
	if (Cmd)
	{
		CommandDesc *cmd;
		bool ok = false;
		for (int cmdset = 0; cmdset < 2; cmdset++)
		{
		        CommandDesc *last_cmd;
			if (cmdset == 0)
			{
				cmd = BuiltinCommands;
				last_cmd = BuiltinCommands + ARRAY_LEN (BuiltinCommands);
			}
			else
			{
				cmd = CmdInfo->Commands;
				last_cmd = CmdInfo->Commands + CmdInfo->NumCommands;
			}
			for (; cmd < last_cmd; cmd++)
				if (strcasecmp (Cmd, cmd->Name) == 0)
				{
					ok = true;
					break;
				}
			if (ok)
				break;
		}
		if (!ok)
		{
			CONSOLE.TextOutput ("\axcERROR: \axeUnknown command `%s'\n", Cmd);
			return 0;
                }

		CONSOLE.TextOutput ("\axa%s ", Cmd);
		int num_brackets = 0;
		for (int i = 0; i < cmd->NumArgs; i++)
		{
			char *arg_type, *bracket = "";
			switch (cmd->Type [i] & ~ARG_OPT)
			{
				case ARG_STR:
					arg_type = "str";
					break;
				case ARG_INT:
					arg_type = "num";
					break;
				case ARG_BOOL:
					arg_type = "bool";
					break;
				default:
					arg_type = "???";
					break;
			}

			if (cmd->Type [i] & ARG_OPT)
			{
				bracket = "{ ";
				num_brackets++;
			}
			CONSOLE.TextOutput ("\ax4%s\ax7<\axf%s\ax7> ", bracket, arg_type);
		}
		while (num_brackets--)
			CONSOLE.TextOutput ("\ax4} ");
		CONSOLE.TextOutput ("\n\t\ax2%s\n", cmd->Description);
		return 0;
	}

	size_t max_cmd_len = 0;
	for (int pass = 0; pass < 2; pass++)
	{
		for (int cmdset = 0; cmdset < 2; cmdset++)
		{
		        CommandDesc *cmd, *last_cmd;
			if (cmdset == 0)
			{
				cmd = BuiltinCommands;
				last_cmd = BuiltinCommands + ARRAY_LEN (BuiltinCommands);
			}
			else
			{
				cmd = CmdInfo->Commands;
				last_cmd = CmdInfo->Commands + CmdInfo->NumCommands;
			}
			for (; cmd < last_cmd; cmd++)
			{
				size_t sl = strlen (cmd->Name);
				if (cmd->NumArgs)
				{
					if (cmd->Type [0] & ARG_OPT)
						sl += 2;
					sl += 4;
				}
				if (pass == 0)
				{
					if (sl > max_cmd_len)
						max_cmd_len = sl;
				}
				else
				{
					char fill [32];
					memset (fill, ' ', max_cmd_len - sl);
					fill [max_cmd_len - sl] = 0;
					if (cmd->NumArgs)
					{
						bool braces = !!(cmd->Type [0] & ARG_OPT);
						CONSOLE.TextOutput ("\axa%s \ax4%s\axf...\ax4%s\ax2%s%s\n",
								    cmd->Name, braces ? "{" : "",
								    braces ? "}" : "", fill, cmd->Description);
					}
					else
						CONSOLE.TextOutput ("\axa%s\ax2%s%s\n",
								    cmd->Name, fill, cmd->Description);
				}
			}
		}
		max_cmd_len++;
		if (max_cmd_len > 31)
			max_cmd_len = 31;
	}
	
	return 0;
}

void CommandInterpreter (const char *ConfigFile, void *UserData,
			 CommandDesc *Commands, int NumCommands,
			 const char *Prompt)
{
	static const char *spaces = " \t";
	FILE *cf = NULL;
	if (ConfigFile)
	{
		cf = fopen (ConfigFile, "r");
		if (!cf)
			CONSOLE.TextOutput (
				"\axcFAILED\axe to open config file `%s', processing anyway ...\ax2\n",
				ConfigFile);
	}

	BuiltinCmdInfo CmdInfo;
	CmdInfo.Commands = Commands;
	CmdInfo.NumCommands = NumCommands;

	for (;;)
	{
next_cmd:;
		char line [512];
		if (cf)
		{
			if (fgets (line, sizeof (line), cf))
			{
				char *eol = strchr (line, 0);
				while ((eol > line) && strchr ("\r\n \t", eol [-1]))
					eol--;
				*eol = 0;
			}
			else
			{
				fclose (cf);
				cf = NULL;
			}
		}
		if (!cf)
			CONSOLE.ReadLine (Prompt, line, sizeof (line));

		// Skip initial whitespaces and comment lines
		char *cur = line;
		cur += strspn (cur, spaces);
		if (!*cur || *cur == '#')
			goto next_cmd;

		if (cf)
			CONSOLE.ReadLineHistoryPush (cur);

		// First of all, extract the command (the first word)
		char *eow = cur + strcspn (cur, spaces);
		bool cmd_ok = false;
                CommandDesc *cmd;

		int cmdset;
		for (cmdset = 0; cmdset < 2; cmdset++)
		{
			CommandDesc *last_cmd;
			if (cmdset == 0)
			{
				cmd = BuiltinCommands;
				last_cmd = BuiltinCommands + ARRAY_LEN (BuiltinCommands);
			}
			else
			{
				cmd = Commands;
				last_cmd = Commands + NumCommands;
			}
			for (; cmd < last_cmd; cmd++)
			{
				int cmdl = strlen (cmd->Name);
				if ((cmdl == eow - cur) &&
				    (memcmp (cur, cmd->Name, cmdl) == 0))
				{
					cmd_ok = true;
					break;
				}
			}
			if (cmd_ok)
				break;
		}

		if (!cmd_ok)
		{
			// Barf
			*eow = 0;
			CONSOLE.TextOutput (
				"\axcERROR: \axeUnknown command `%s' "
				"\axf(Type 'help' for a list of commands)\ax2\n",
				cur);
			goto next_cmd;
		}

		void *args [MAX_COMMAND_ARGS];

		// Okey, now we have to parse all the arguments
		int arg;
		bool found_eol = (*eow == 0);
		for (arg = 0; arg < cmd->NumArgs; arg++)
		{
			// Skip all whitespaces after end of the previous word
                        if (!found_eol)
				eow++;
			cur = eow + strspn (eow, spaces);
			if (!*cur)
				break;

			bool quote = (*cur == '"');

			eow = cur;
			if (quote)
				eow++;

			char *arg_str = cur;
			for (; *eow; eow++)
			{
                                // Inside quotes we handle most backslash sequences
				if (quote)
				{
					if (*eow == '\\')
					{
						eow++;
						switch (*eow)
						{
						case 0:
							*cur++ = *eow--;
							break;
						case 'a':
							*cur++ = '\a';
							break;
						case 't':
							*cur++ = '\t';
							break;
						case 'r':
							*cur++ = '\r';
							break;
						case 'n':
							*cur++ = '\n';
							break;
						default:
							*cur++ = *eow;
							break;
						}
					}
					else if (*eow == '"')
						break;
					else
						*cur++ = *eow;
				}
				else if (strchr (spaces, *eow))
					break;
				else
					*cur++ = *eow;
			}

			found_eol = (*eow == 0);
			*cur = 0;
			*eow = 0;
			switch (cmd->Type [arg] & ~ARG_OPT)
			{
			case ARG_STR:
				args [arg] = arg_str;
				break;
			case ARG_INT:
				{
					char *endptr;
					args [arg] = (void *)strtol (arg_str, &endptr, 0);
					if (endptr && *endptr)
					{
						CONSOLE.TextOutput (
							"\axcERROR: \axeExpected number, got `%s'\ax2\n",
							arg_str);
						goto next_cmd;
					}
					break;
				}
			case ARG_BOOL:
				{
					uintptr val;
					if (!strcasecmp (arg_str, "yes") || !strcasecmp (arg_str, "on"))
						val = 1;
					else if (!strcasecmp (arg_str, "no") || !strcasecmp (arg_str, "off"))
						val = 0;
					else
					{
						char *endptr;
						val = strtol (arg_str, &endptr, 0);
						if (endptr && *endptr)
						{
							CONSOLE.TextOutput (
								"\axcERROR: \axeExpected boolean, got `%s'\ax2\n",
								arg_str);
							goto next_cmd;
						}
					}
					args [arg] = (void *)val;
					break;
				}
			default:
				abort ();
			}
		}

		if ((arg < cmd->NumArgs) && !(cmd->Type [arg] & ARG_OPT))
		{
			CONSOLE.TextOutput ("\axcERROR: \axeNot enough command arguments\ax2\n");
			goto next_cmd;
		}

		for (; arg < cmd->NumArgs; arg++)
			if ((cmd->Type [arg] & ~ARG_OPT) == ARG_STR)
				args [arg] = NULL;
			else
				args [arg] = (void *)NO_ARG;

		if (!found_eol && eow [1])
			CONSOLE.TextOutput (
				"\axeWARNING: \ax2Ignoring excessive arguments: \axe`%s'\ax2.\n",
				eow + 1);

		void *arg0;
		if (cmdset == 0)
			arg0 = &CmdInfo;
		else
			arg0 = UserData;

		int rc;
		switch (cmd->NumArgs)
		{
		case 0:
			rc = cmd->Execute (arg0);
			break;
		case 1:
			rc = cmd->Execute (arg0, args [0]);
			break;
		case 2:
			rc = cmd->Execute (arg0, args [0], args [1]);
			break;
		case 3:
			rc = cmd->Execute (arg0, args [0], args [1], args [2]);
			break;
		case 4:
			rc = cmd->Execute (arg0, args [0], args [1], args [2], args [3]);
			break;
		default:
			rc = 0;
			break;
		}

		if (rc)
			break;
	}
}
