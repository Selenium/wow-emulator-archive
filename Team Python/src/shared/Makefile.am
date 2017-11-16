# Copyright (C) 2004 Team Python
#
# This file is free software; as a special exception the author gives
# unlimited permission to copy and/or distribute it, with or without
# modifications, as long as this notice is preserved.
#
# This program is distributed in the hope that it will be useful, but
# WITHOUT ANY WARRANTY, to the extent permitted by law; without even the
# implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.


INCLUDES = -I$(srcdir) -I$(srcdir)/lua

## we don't want to need this here
INCLUDES += -I$(srcdir)/../game -I$(srcdir)/../realmlist

noinst_LIBRARIES = libshared.a

libshared_a_SOURCES = Client.cpp Client.h Common.h Database.cpp Database.h \
                      DatabaseInterface.cpp DatabaseInterface.h Errors.h \
                      Log.cpp Log.h MemoryLeaks.cpp MemoryLeaks.h \
                      Network.cpp Network.h \
                      NetworkInterface.cpp NetworkInterface.h \
                      Script.cpp Script.h Server.cpp Server.h \
                      Singleton.h Sockets.h \
                      Threads.cpp Threads.h Timer.h \
                      UserAccount.cpp UserAccount.h \
                      lua/lapi.c lua/lapi.h lua/lauxlib.h \
                      lua/lcode.c lua/lcode.h lua/ldebug.c lua/ldebug.h \
                      lua/ldo.c lua/ldo.h lua/ldump.c \
                      lua/lfunc.c lua/lfunc.h lua/lgc.c lua/lgc.h \
                      lua/llex.c lua/llex.h lua/llimits.h \
                      lua/lmem.c lua/lmem.h lua/lobject.c lua/lobject.h \
                      lua/lopcodes.c lua/lopcodes.h \
                      lua/lparser.c lua/lparser.h lua/lstate.c lua/lstate.h \
                      lua/lstring.c lua/lstring.h lua/ltable.c lua/ltable.h \
                      lua/ltests.c lua/ltm.c lua/ltm.h lua/lua.h \
                      lua/lualib.h lua/lundump.c lua/lundump.h \
                      lua/lvm.c lua/lvm.h lua/lzio.c lua/lzio.h




