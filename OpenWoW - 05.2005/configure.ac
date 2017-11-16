# Copyright (C) 2004 Team Python
#
# This file is free software; as a special exception the author gives
# unlimited permission to copy and/or distribute it, with or without
# modifications, as long as this notice is preserved.
#
# This program is distributed in the hope that it will be useful, but
# WITHOUT ANY WARRANTY, to the extent permitted by law; without even the
# implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

## Process this file with autoconf to produce a configure script.

AC_INIT([WSDserver],
        [1.2.1],    
        [WSD],
        [wsdserver])

LPATH="$PATH:/usr/local/bin"

AC_PREREQ(2.5)

if test -d obj; then rm -rf obj; fi
 
AM_CONFIG_HEADER( config.h )
AM_INIT_AUTOMAKE
AM_MAINTAINER_MODE

CFLAGS=${CFLAGS:--O2 -g -Wall}
CXXFLAGS=${CXXFLAGS:--O2 -g -Wall}

# Checks for programs.
AC_PROG_CC
AC_PROG_CXX
AC_PROG_RANLIB

# Checks for libraries.
AC_CHECK_LIB( pthread, pthread_create, [], 
	[LDFLAGS="-pthread $LDFLAGS"
	 AC_TRY_LINK([char pthread_create();],
		pthread_create();,
		[], [AC_MSG_ERROR([Missing pthread])])
	])
AC_CHECK_LIB( z, compress, [],[AC_MSG_ERROR([Missing zlib])] )
AC_CHECK_LIB( compat, ftime )
#AC_CHECK_LIB( mysqlclient, mysql_init, [],[AC_CHECK_LIB(mysql, mysql_init,[],[AC_MSG_ERROR([Missing mysql])])])
AC_CHECK_LIB( ssl, BN_cmp, [], [AC_MSG_ERROR([Missing openssl])])
AC_CHECK_LIB( termcap, tgetent, [],
		[AC_CHECK_LIB( ncurses, tgetent, [],
			     [AC_MSG_ERROR([Either termcap or ncurses is required])]
		)]
	)

AC_ARG_WITH(mysql-libs,
[ --with-mysql-libs=DIR		Look for mysql libs in this dir ],
	MYSQL_LIBS="-L$withval -lmysqlclient"
)
AC_ARG_WITH(mysql-includes,
[ --with-mysql-includes=DIR	Look for mysql includes in this dir ],
	MYSQL_INCLUDES="-I$withval"
)

AC_PATH_PROGS(MYSQL_CONFIG, mysql_config, mysql_config, $LPATH)

if test -x "$MYSQL_CONFIG"
then
	# MySQL v4 uses --include while v3 uses --cflags
	MYSQL_INCLUDES="`$MYSQL_CONFIG --include`" || \
		MYSQL_INCLUDES="`$MYSQL_CONFIG --cflags`"
	MYSQL_LIBS="`$MYSQL_CONFIG --libs`"
fi

AC_SUBST(MYSQL_INCLUDES)
AC_SUBST(MYSQL_LIBS)

# Checks for header files.
AC_HEADER_STDC
AC_HEADER_STDBOOL
AC_HEADER_TIME
AC_CHECK_HEADERS(                                             \
   limits.h sys/ioctl.h unistd.h fcntl.h float.h              \
   malloc.h netdb.h netinet/in.h stddef.h sys/socket.h        \
   sys/time.h sys/timeb.h                                     \
 ,[],[AC_MSG_ERROR([Missing required header])])

# Checks for typedefs, structures, and compiler characteristics.
AC_C_CONST
AC_C_INLINE
AC_C_VOLATILE
AC_TYPE_SIZE_T
AC_TYPE_OFF_T
AC_TYPE_SIGNAL
AC_STRUCT_TM
AC_CHECK_TYPES([ ptrdiff_t ])

# Checks for library functions.
AC_FUNC_MEMCMP
AC_FUNC_STRCOLL
AC_FUNC_ALLOCA
AC_FUNC_MALLOC
AC_FUNC_REALLOC
AC_FUNC_SELECT_ARGTYPES
AC_FUNC_STRFTIME
AC_FUNC_STRNLEN
AC_FUNC_VPRINTF
AC_CHECK_FUNCS(                                               \
   ftime strcspn strtoul atexit bzero floor gethostbyname     \
   gettimeofday localtime_r memset rint select socket         \
   sqrt stpcpy strchr strpbrk strrchr strstr strtol strtoul   \
)

AC_CONFIG_FILES([
   ./Makefile
   doc/Makefile
   src/Makefile
   src/wsdrealmlist/Makefile
   src/wsdworldsrv/Makefile
   src/shared/Makefile
   src/realmlist/Makefile
   src/srp/Makefile
   src/game/Makefile
   src/tools/Makefile
])

AC_OUTPUT
