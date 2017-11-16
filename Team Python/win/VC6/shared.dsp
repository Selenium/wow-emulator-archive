# Microsoft Developer Studio Project File - Name="shared" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Static Library" 0x0104

CFG=shared - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "shared.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "shared.mak" CFG="shared - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "shared - Win32 Release" (based on "Win32 (x86) Static Library")
!MESSAGE "shared - Win32 Debug" (based on "Win32 (x86) Static Library")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
CPP=cl.exe
RSC=rc.exe

!IF  "$(CFG)" == "shared - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "shared___Win32_Release"
# PROP BASE Intermediate_Dir "shared___Win32_Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "shared___Win32_Release"
# PROP Intermediate_Dir "shared___Win32_Release"
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_MBCS" /D "_LIB" /YX /FD /c
# ADD CPP /nologo /MT /W3 /GX /O2 /I "..\..\dep\inc\mysql" /I "..\..\src\shared" /I "..\..\src\game" /I "..\..\src\realmlist" /D "WIN32" /D "NDEBUG" /D "_MBCS" /D "_LIB" /YX /FD /c
# ADD BASE RSC /l 0x409 /d "NDEBUG"
# ADD RSC /l 0x409 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LIB32=link.exe -lib
# ADD BASE LIB32 /nologo
# ADD LIB32 /nologo

!ELSEIF  "$(CFG)" == "shared - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "shared___Win32_Debug"
# PROP BASE Intermediate_Dir "shared___Win32_Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "shared___Win32_Debug"
# PROP Intermediate_Dir "shared___Win32_Debug"
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_MBCS" /D "_LIB" /YX /FD /GZ  /c
# ADD CPP /nologo /MTd /W3 /Gm /GX /Zi /Od /I "..\..\dep\inc\mysql" /I "..\..\src\shared" /I "..\..\src\game" /I "..\..\src\realmlist" /D "WIN32" /D "_DEBUG" /D "_MBCS" /D "_LIB" /YX /FD /GZ  /c
# ADD BASE RSC /l 0x409 /d "_DEBUG"
# ADD RSC /l 0x409 /d "_DEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LIB32=link.exe -lib
# ADD BASE LIB32 /nologo
# ADD LIB32 /nologo

!ENDIF 

# Begin Target

# Name "shared - Win32 Release"
# Name "shared - Win32 Debug"
# Begin Group "Database"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\shared\Database.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Database.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\DatabaseInterface.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\DatabaseInterface.h
# End Source File
# End Group
# Begin Group "Script"

# PROP Default_Filter ""
# Begin Group "lua"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\shared\lua\lapi.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lapi.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lauxlib.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lcode.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lcode.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ldebug.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ldebug.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ldo.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ldo.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ldump.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lfunc.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lfunc.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lgc.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lgc.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\llex.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\llex.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\llimits.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lmem.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lmem.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lobject.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lobject.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lopcodes.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lopcodes.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lparser.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lparser.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lstate.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lstate.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lstring.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lstring.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ltable.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ltable.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ltests.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ltm.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\ltm.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lua.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lualib.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lundump.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lundump.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lvm.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lvm.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lzio.c
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\lua\lzio.h
# End Source File
# End Group
# Begin Source File

SOURCE=..\..\src\shared\Script.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Script.h
# End Source File
# End Group
# Begin Group "Threads"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\shared\Threads.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Threads.h
# End Source File
# End Group
# Begin Group "Network"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\shared\Network.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Network.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\NetworkInterface.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\NetworkInterface.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Sockets.h
# End Source File
# End Group
# Begin Group "Server"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\shared\Client.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Client.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Server.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Server.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\UserAccount.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\UserAccount.h
# End Source File
# End Group
# Begin Group "Log"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\shared\Log.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Log.h
# End Source File
# End Group
# Begin Group "Util"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\shared\Errors.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\MemoryLeaks.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\MemoryLeaks.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Singleton.h
# End Source File
# Begin Source File

SOURCE=..\..\src\shared\Timer.h
# End Source File
# End Group
# Begin Source File

SOURCE=..\..\src\shared\Common.h
# End Source File
# End Target
# End Project
