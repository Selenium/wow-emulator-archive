//////////////////////////////////////////////////////////////////////
//  Console.cpp
//
//  Non-system-specific console functions
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

#include "Common.h"
#include "Debug.h"

void DebugDump (FILE *Out, const void *Data, unsigned Size, bool RelOfs)
{
	
	const uint8 *data = (const uint8 *)Data;
	unsigned int ofs = 0;
	while (ofs < Size)
	{
//		fprintf (Out, "%08x | ", RelOfs ? ofs : (unsigned int) (data + ofs));

		unsigned int i;
		for (i = 0; i < 16; i++)
			if (ofs + i < Size)
				fprintf (Out, "%02x ", data [ofs + i]);
			else
				fprintf (Out, "   ");

/*		fprintf (Out, "| ");
		for (i = 0; i < 16; i++)
			if (ofs + i < Size)
			{
				char c = data [ofs + i];
				fprintf (Out, "%c", c > 31 ? c : '.');
			}
			else
				fprintf (Out, " ");
*/
		ofs += 16;
		fprintf (Out, "\n");
	}
	fflush (Out);
	
}

void printBytes(char* bytes, int l, char *name)
{

	if (bytes == NULL)
		return;
	printf ("%s: ", name);
	for (int i = 0; i < l; i++)
		printf ("%02X", (unsigned char)bytes [i]);
	printf ("\n");

}
