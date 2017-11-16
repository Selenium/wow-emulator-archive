/**
 **	File ......... Utility.h
 **	Published ....  2004-02-13
 **	Author ....... grymse@alhem.net
**/
/*
Copyright (C) 2004  Anders Hedstrom

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/
#ifndef _UTILITY_H
#define _UTILITY_H

#ifdef _WIN32
typedef unsigned __int64 uint64_t;
#else
#ifndef SOLARIS
#include <stdint.h>
#endif
#endif
#include "Base64.h"


namespace Utility
{
	inline std::string base64(const std::string& str_in)
	{
		std::string str;
		Base64 m_b;
		m_b.encode(str_in, str, false); // , false == do not add cr/lf
		return str;
	}
	inline std::string base64d(const std::string& str_in)
	{
		std::string str;
		Base64 m_b;
		m_b.decode(str_in, str);
		return str;
	}
	inline std::string l2string(long l)
	{
		std::string str;
		char tmp[100];
		sprintf(tmp,"%ld",l);
		str = tmp;
		return str;
	}
	inline std::string bigint2string(uint64_t l)
	{
		std::string str;
		uint64_t tmp = l;
		while (tmp)
		{
			uint64_t a = tmp % 10;
			str = (char)(a + 48) + str;
			tmp /= 10;
		}
		if (!str.size())
		{
			str = "0";
		}
		return str;
	}
	inline uint64_t atoi64(const std::string& str) 
	{
		uint64_t l = 0;
		for (size_t i = 0; i < str.size(); i++)
		{
			l = l * 10 + str[i] - 48;
		}
		return l;
	}
	inline unsigned int hex2unsigned(const std::string& str)
	{
		unsigned int r = 0;
		for (size_t i = 0; i < str.size(); i++)
		{
			r = r * 16 + str[i] - 48 - ((str[i] >= 'A') ? 7 : 0) - ((str[i] >= 'a') ? 32 : 0);
		}
		return r;
	}
}

//using Utility::l2string;
//using Utility::base64;
//using Utility::base64d;


#endif // _UTILITY_H
