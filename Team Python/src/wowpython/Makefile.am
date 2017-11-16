# Copyright (C) 2004 Team Python
#
# This file is free software; as a special exception the author gives
# unlimited permission to copy and/or distribute it, with or without
# modifications, as long as this notice is preserved.
#
# This program is distributed in the hope that it will be useful, but
# WITHOUT ANY WARRANTY, to the extent permitted by law; without even the
# implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.


INCLUDES = -I$(srcdir) -I$(srcdir)/../shared
INCLUDES += -I$(srcdir)/../realmlist -I$(srcdir)/../redirect
INCLUDES += -I$(srcdir)/../game


bin_PROGRAMS = wowpython

wowpython_SOURCES = Main.cpp

#wowpython_LDADD = $(srcdir)/../shared/libshared.a \
#                  $(srcdir)/../realmlist/librealmlist.a \
#                  $(srcdir)/../redirect/libredirect.a \
#                  $(srcdir)/../game/libgame.a
wowpython_LDADD = -lshared -lrealmlist -lredirect -lgame


wowpython_LDFLAGS = -L$(srcdir)/../shared \
                    -L$(srcdir)/../realmlist \
                    -L$(srcdir)/../redirect \
                    -L$(srcdir)/../game \
                    -L../shared -L../realmlist \
                    -L../redirect -L../game
