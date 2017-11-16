# Copyright (C) 2004 Team Python
#
# This file is free software; as a special exception the author gives
# unlimited permission to copy and/or distribute it, with or without
# modifications, as long as this notice is preserved.
#
# This program is distributed in the hope that it will be useful, but
# WITHOUT ANY WARRANTY, to the extent permitted by law; without even the
# implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.


INCLUDES = -I$(srcdir) -I$(srcdir)/lua -I$(srcdir)/../srp

noinst_LIBRARIES = libshared.a

libshared_a_SOURCES = Common.h Errors.h Singleton.h Sockets.h \
		      Client.h Client.cpp \
		      Log.h Log.cpp \
		      MemoryLeaks.h MemoryLeaks.cpp \
		      Network.h Network.cpp \
		      NetworkInterface.h NetworkInterface.cpp \
		      Script.h Script.cpp \
		      Server.h Server.cpp \
		      Threads.h Threads.cpp \
		      UserAccount.h UserAccount.cpp \
		      Console.h Console.cpp posix/ConsoleSysDep.cpp \
		      CommandInterpreter.h CommandInterpreter.cpp \
		      Debug.h Debug.cpp \
		      StringFun.h StringFun.cpp \
		      SystemFun.h posix/TimeFun.cpp \
		      Base.cpp Base.h ObjVec.cpp ObjVec.h \
		      StrVec.cpp StrVec.h

#                      lua/lapi.c lua/lapi.h lua/lauxlib.h \
#                      lua/lcode.c lua/lcode.h lua/ldebug.c lua/ldebug.h \
#                      lua/ldo.c lua/ldo.h lua/ldump.c \
#                      lua/lfunc.c lua/lfunc.h lua/lgc.c lua/lgc.h \
#                      lua/llex.c lua/llex.h lua/llimits.h \
#                      lua/lmem.c lua/lmem.h lua/lobject.c lua/lobject.h \
#                      lua/lopcodes.c lua/lopcodes.h \
#                      lua/lparser.c lua/lparser.h lua/lstate.c lua/lstate.h \
#                      lua/lstring.c lua/lstring.h lua/ltable.c lua/ltable.h \
#                      lua/ltests.c lua/ltm.c lua/ltm.h lua/lua.h \
#                      lua/lualib.h lua/lundump.c lua/lundump.h \
#                      lua/lvm.c lua/lvm.h lua/lzio.c lua/lzio.h

.cpp.o:
	@echo "CXX " $@
	@if $(CXXCOMPILE) -MT $@ -MD -MP -MF "$(DEPDIR)/$*.Tpo" -c -o $@ $<; \
	then mv -f "$(DEPDIR)/$*.Tpo" "$(DEPDIR)/$*.Po"; else rm -f "$(DEPDIR)/$*.Tpo"; exit 1; fi
