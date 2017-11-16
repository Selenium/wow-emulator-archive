# Microsoft Developer Studio Project File - Name="TownHall" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Application" 0x0101

CFG=TownHall - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "TownHall.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "TownHall.mak" CFG="TownHall - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "TownHall - Win32 Release" (based on "Win32 (x86) Application")
!MESSAGE "TownHall - Win32 Debug" (based on "Win32 (x86) Application")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
CPP=cl.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "TownHall - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_MBCS" /YX /FD /c
# ADD CPP /nologo /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_MBCS" /YX /FD /c
# ADD BASE MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x409 /d "NDEBUG"
# ADD RSC /l 0x409 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /machine:I386
# ADD LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /machine:I386

!ELSEIF  "$(CFG)" == "TownHall - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "TownHall___Win32_Debug"
# PROP BASE Intermediate_Dir "TownHall___Win32_Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 1
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "TownHall___Win32_Debug"
# PROP Intermediate_Dir "TownHall___Win32_Debug"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_MBCS" /YX /FD /GZ /c
# ADD CPP /nologo /MTd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_MBCS" /YX /FD /GZ /c
# ADD BASE MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x409 /d "_DEBUG"
# ADD RSC /l 0x409 /d "_DEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /debug /machine:I386 /pdbtype:sept
# ADD LINK32 zlib.lib /nologo /subsystem:windows /debug /machine:I386 /nodefaultlib:"LIBCD" /out:"TownHall.exe" /pdbtype:sept

!ENDIF 

# Begin Target

# Name "TownHall - Win32 Release"
# Name "TownHall - Win32 Debug"
# Begin Group "Source Files"

# PROP Default_Filter "cpp;c;cxx;rc;def;r;odl;idl;hpj;bat"
# Begin Source File

SOURCE=.\Account.cpp
# End Source File
# Begin Source File

SOURCE=.\Client.cpp
# End Source File
# Begin Source File

SOURCE=.\Compress.cpp
# End Source File
# Begin Source File

SOURCE=.\Container.cpp
# End Source File
# Begin Source File

SOURCE=.\Creature.cpp
# End Source File
# Begin Source File

SOURCE=.\CreatureTemplate.cpp
# End Source File
# Begin Source File

SOURCE=.\DataManager.cpp
# End Source File
# Begin Source File

SOURCE=.\DBCHandler.cpp
# End Source File
# Begin Source File

SOURCE=.\Debug.cpp
# End Source File
# Begin Source File

SOURCE=.\EventManager.cpp
# End Source File
# Begin Source File

SOURCE=.\GMCommands.cpp
# End Source File
# Begin Source File

SOURCE=.\Item.cpp
# End Source File
# Begin Source File

SOURCE=.\ItemTemplate.cpp
# End Source File
# Begin Source File

SOURCE=.\LootTable.cpp
# End Source File
# Begin Source File

SOURCE=.\MsgHandlers.cpp
# End Source File
# Begin Source File

SOURCE=.\PathGroup.cpp
# End Source File
# Begin Source File

SOURCE=.\Player.cpp
# End Source File
# Begin Source File

SOURCE=.\RealmServer.cpp
# End Source File
# Begin Source File

SOURCE=.\RegionManager.cpp
# End Source File
# Begin Source File

SOURCE=.\SendPDlg.cpp
# End Source File
# Begin Source File

SOURCE=.\Settings.cpp
# End Source File
# Begin Source File

SOURCE=.\SpawnPoint.cpp
# End Source File
# Begin Source File

SOURCE=.\TCPSocket.cpp
# End Source File
# Begin Source File

SOURCE=.\TownHall.cpp
# End Source File
# Begin Source File

SOURCE=.\TownHallDlg.cpp
# End Source File
# Begin Source File

SOURCE=.\UDPSocket.cpp
# End Source File
# Begin Source File

SOURCE=.\WoWObject.cpp
# End Source File
# Begin Source File

SOURCE=.\Zone.cpp
# End Source File
# End Group
# Begin Group "Header Files"

# PROP Default_Filter "h;hpp;hxx;hm;inl"
# Begin Source File

SOURCE=.\Account.h
# End Source File
# Begin Source File

SOURCE=.\Client.h
# End Source File
# Begin Source File

SOURCE=.\Compress.h
# End Source File
# Begin Source File

SOURCE=.\Container.h
# End Source File
# Begin Source File

SOURCE=.\Creature.h
# End Source File
# Begin Source File

SOURCE=.\CreatureTemplate.h
# End Source File
# Begin Source File

SOURCE=.\DataManager.h
# End Source File
# Begin Source File

SOURCE=.\DBCHandler.h
# End Source File
# Begin Source File

SOURCE=.\Debug.h
# End Source File
# Begin Source File

SOURCE=.\Defines.h
# End Source File
# Begin Source File

SOURCE=.\DefStorage.h
# End Source File
# Begin Source File

SOURCE=.\Emotes.h
# End Source File
# Begin Source File

SOURCE=.\EventManager.h
# End Source File
# Begin Source File

SOURCE=.\Globals.h
# End Source File
# Begin Source File

SOURCE=.\Index.h
# End Source File
# Begin Source File

SOURCE=.\Item.h
# End Source File
# Begin Source File

SOURCE=.\ItemTemplate.h
# End Source File
# Begin Source File

SOURCE=.\LootTable.h
# End Source File
# Begin Source File

SOURCE=.\MFCThreading.h
# End Source File
# Begin Source File

SOURCE=.\MsgHandlers.h
# End Source File
# Begin Source File

SOURCE=.\OpCodes.h
# End Source File
# Begin Source File

SOURCE=.\PathGroup.h
# End Source File
# Begin Source File

SOURCE=.\Player.h
# End Source File
# Begin Source File

SOURCE=.\Queue.h
# End Source File
# Begin Source File

SOURCE=.\RealmServer.h
# End Source File
# Begin Source File

SOURCE=.\RegionManager.h
# End Source File
# Begin Source File

SOURCE=.\Resource.h
# End Source File
# Begin Source File

SOURCE=.\SendPDlg.h
# End Source File
# Begin Source File

SOURCE=.\Settings.h
# End Source File
# Begin Source File

SOURCE=.\SpawnPoint.h
# End Source File
# Begin Source File

SOURCE=.\stdafx.h
# End Source File
# Begin Source File

SOURCE=.\Storage.h
# End Source File
# Begin Source File

SOURCE=.\Structs.h
# End Source File
# Begin Source File

SOURCE=.\TCPSocket.h
# End Source File
# Begin Source File

SOURCE=.\Threading.h
# End Source File
# Begin Source File

SOURCE=.\TownHall.h
# End Source File
# Begin Source File

SOURCE=.\TownHallDlg.h
# End Source File
# Begin Source File

SOURCE=.\UDPSocket.h
# End Source File
# Begin Source File

SOURCE=.\UnixThreading.h
# End Source File
# Begin Source File

SOURCE=.\WinThreading.h
# End Source File
# Begin Source File

SOURCE=.\WoWObject.h
# End Source File
# Begin Source File

SOURCE=.\Zone.h
# End Source File
# End Group
# Begin Group "Resource Files"

# PROP Default_Filter "ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe"
# Begin Source File

SOURCE=.\res\TownHall.ico
# End Source File
# Begin Source File

SOURCE=.\TownHall.rc
# End Source File
# End Group
# Begin Group "Config Files"

# PROP Default_Filter ""
# Begin Source File

SOURCE=.\changes.txt
# End Source File
# Begin Source File

SOURCE=.\Conf\TownHall.conf
# End Source File
# End Group
# Begin Source File

SOURCE=.\res\TownHall.manifest
# End Source File
# End Target
# End Project
