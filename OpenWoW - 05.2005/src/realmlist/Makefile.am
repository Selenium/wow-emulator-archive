# Copyright (C) 2004 Team Python
#
# This file is free software; as a special exception the author gives
# unlimited permission to copy and/or distribute it, with or without
# modifications, as long as this notice is preserved.
#
# This program is distributed in the hope that it will be useful, but
# WITHOUT ANY WARRANTY, to the extent permitted by law; without even the
# implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.


INCLUDES = -I$(srcdir) -I$(srcdir)/../shared -I$(srcdir)/../srp

## we don't want to need this here
INCLUDES += -I$(srcdir)/../game

noinst_LIBRARIES = librealmlist.a

librealmlist_a_SOURCES = RealmClient.cpp RealmClient.h \
                         RealmListSrv.cpp RealmListSrv.h \
			 RealmList.cpp RealmList.h \
			 Accounts.cpp Accounts.h \
			 UserHashes.cpp UserHashes.h \
			 WorldCommSrv.cpp WorldCommSrv.h

.cpp.o:
	@echo "CXX " $@
	@if $(CXXCOMPILE) -MT $@ -MD -MP -MF "$(DEPDIR)/$*.Tpo" -c -o $@ $<; \
	then mv -f "$(DEPDIR)/$*.Tpo" "$(DEPDIR)/$*.Po"; else rm -f "$(DEPDIR)/$*.Tpo"; exit 1; fi
