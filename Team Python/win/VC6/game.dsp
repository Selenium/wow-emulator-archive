# Microsoft Developer Studio Project File - Name="game" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Static Library" 0x0104

CFG=game - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "game.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "game.mak" CFG="game - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "game - Win32 Release" (based on "Win32 (x86) Static Library")
!MESSAGE "game - Win32 Debug" (based on "Win32 (x86) Static Library")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
CPP=cl.exe
RSC=rc.exe

!IF  "$(CFG)" == "game - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "game___Win32_Release"
# PROP BASE Intermediate_Dir "game___Win32_Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "game___Win32_Release"
# PROP Intermediate_Dir "game___Win32_Release"
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_MBCS" /D "_LIB" /YX /FD /c
# ADD CPP /nologo /MT /W3 /GX /O2 /I "..\..\src\shared" /D "WIN32" /D "NDEBUG" /D "_MBCS" /D "_LIB" /YX /FD /c
# ADD BASE RSC /l 0x409 /d "NDEBUG"
# ADD RSC /l 0x409 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LIB32=link.exe -lib
# ADD BASE LIB32 /nologo
# ADD LIB32 /nologo

!ELSEIF  "$(CFG)" == "game - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "game___Win32_Debug"
# PROP BASE Intermediate_Dir "game___Win32_Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "game___Win32_Debug"
# PROP Intermediate_Dir "game___Win32_Debug"
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_MBCS" /D "_LIB" /YX /FD /GZ /c
# ADD CPP /nologo /MTd /W3 /Gm /GX /Zi /Od /I "..\..\src\shared" /D "WIN32" /D "_DEBUG" /D "_MBCS" /D "_LIB" /YX /FD /GZ /c
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

# Name "game - Win32 Release"
# Name "game - Win32 Debug"
# Begin Group "World/Handlers"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\game\AuraHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\AuraHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\CharacterHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\CharacterHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\ChatHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\ChatHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Combat.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Combat.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Group.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Group.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\GroupHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\GroupHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\ItemHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\ItemHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\MiscHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\MiscHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\MovementHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\MovementHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\MsgHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\NPCHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\NPCHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Path.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\PetHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\PetHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\QueryHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\QueryHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Quest.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\QuestHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\QuestHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\SkillHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\SkillHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\SpellHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\SpellHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Stats.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\TaxiHandler.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\TaxiHandler.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\World.h
# End Source File
# End Group
# Begin Group "Object"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\game\Character.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Character.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\GameObject.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\GameObject.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Item.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Item.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Object.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Object.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\ObjectMgr.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\ObjectMgr.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Unit.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Unit.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\UpdateMask.h
# End Source File
# End Group
# Begin Group "Server "

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\game\GameClient.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\GameClient.h
# End Source File
# Begin Source File

SOURCE=..\..\src\game\WorldServer.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\WorldServer.h
# End Source File
# End Group
# Begin Group "Chat Commands"

# PROP Default_Filter ""
# Begin Source File

SOURCE=..\..\src\game\Level0.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Level1.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Level2.cpp
# End Source File
# Begin Source File

SOURCE=..\..\src\game\Level3.cpp
# End Source File
# End Group
# Begin Source File

SOURCE=..\..\src\game\Opcodes.h
# End Source File
# End Target
# End Project
