#include "StdAfx.h"

// Copyright (C) 2004 WoW Daemon
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

#if COMPILER == MICROSOFT

createFileSingleton( MemoryManager ) ;


/// Catch memory leaks
MemoryManager::MemoryManager( )
{
  //_CrtSetDbgFlag( _CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
  //_CrtSetDbgFlag( _CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF | _CRTDBG_CHECK_CRT_DF);
  //_CrtSetDbgFlag( _CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF | _CRTDBG_CHECK_CRT_DF | _CRTDBG_CHECK_ALWAYS_DF);
  //_CrtSetDbgFlag( _CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF | _CRTDBG_CHECK_ALWAYS_DF);

  /// set the parameter to this to the allocation number to break at to find a memory leak
  //_CrtSetBreakAlloc (46);

	//----------------------------------------------------------
	// this vvv put somewhere in the code
	//
	// _CrtMemState s1, s2, s3; _CrtMemCheckpoint( &s1 );
	//
	// some suspicious code between here
	//
	// _CrtMemCheckpoint( &s2 ); if ( _CrtMemDifference( &s3, &s1, &s2) ) _CrtMemDumpStatistics( &s3 );
	//
	// breakpoint down vvv here... and BANG in debug log we see the truth :)
}


#endif

