# Copyright (C) 2004 WoW Daemon
#
# This file is free software; as a special exception the author gives
# unlimited permission to copy and/or distribute it, with or without
# modifications, as long as this notice is preserved.
#
# This program is distributed in the hope that it will be useful, but
# WITHOUT ANY WARRANTY, to the extent permitted by law; without even the
# implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.


INCLUDES += -I$(srcdir) -I$(srcdir)/../../dep/include

## we don't want to need this here
INCLUDES += -I$(srcdir)/../game -I$(srcdir)/../realmlist

noinst_LIBRARIES = libshared.a libauth.a libconfig.a libdatabase.a libnetwork.a

libshared_a_SOURCES = \
    Log.cpp \
    MemoryLeaks.cpp \
    ByteBuffer.h \
    Common.h \
    Errors.h \
    Log.h \
    MemoryLeaks.h \
    Singleton.h \
    Timer.h \
    Util.h \
    Util.cpp \
    WorldPacket.h


libauth_a_SOURCES = \
    Auth/BigNumber.cpp \
    Auth/BigNumber.h \
    Auth/Sha1.cpp \
    Auth/Sha1.h \
    Auth/WowCrypt.cpp \
    Auth/WowCrypt.h


libconfig_a_SOURCES = \
    Config/Config.cpp \
    Config/Config.h \
    Config/ConfigEnv.h \
    Config/dotconfpp/dotconfpp.cpp \
    Config/dotconfpp/dotconfpp.h \
    Config/dotconfpp/mempool.cpp \
    Config/dotconfpp/mempool.h \
    Config/dotconfpp

libdatabase_a_SOURCES = \
    Database/DBC.cpp \
    Database/Database.cpp \
    Database/DatabaseSqlite.cpp \
    Database/QueryResultMysql.cpp \
    Database/DBC.h \
    Database/Database.h \
    Database/DatabaseSqlite.h \
    Database/QueryResultMysql.h \
    Database/DBCStores.cpp \
    Database/DatabaseEnv.h \
    Database/Field.cpp \
    Database/QueryResultSqlite.cpp \
    Database/DBCStores.h \
    Database/DatabaseMysql.cpp \
    Database/Field.h \
    Database/QueryResultSqlite.h \
    Database/DataStore.h \
    Database/DatabaseMysql.h \
    Database/QueryResult.h 

libnetwork_a_SOURCES = \
    Network/Base64.cpp \
    Network/Base64.h \
    Network/CircularBuffer.cpp \
    Network/CircularBuffer.h \
    Network/ListenSocket.h \
    Network/Parse.cpp \
    Network/Parse.h \
    Network/Socket.cpp \
    Network/Socket.h \
    Network/SocketHandler.cpp \
    Network/SocketHandler.h \
    Network/socket_include.h \
    Network/StdLog.h \
    Network/TcpSocket.cpp \
    Network/TcpSocket.h \
    Network/UdpSocket.cpp \
    Network/UdpSocket.h \
    Network/Utility.h
