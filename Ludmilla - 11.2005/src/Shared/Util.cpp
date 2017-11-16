//******************************************************************************
#include "StdAfx.h"
#include <sys/timeb.h>

using namespace std;
//------------------------------------------------------------------------------
vector<string> StrSplit(const string &src, const string &sep)
{
	vector<string> r;
	string s;
	for (string::const_iterator i = src.begin(); i != src.end(); i++) {
		if (sep.find(*i) != string::npos) {
			if (s.length()) r.push_back(s);
			s = "";
		} else {
			s += *i;
		}
	}
	if (s.length()) r.push_back(s);
	return r;
}
//------------------------------------------------------------------------------
void ProgressBarShow (uint32 progressPos, uint32 progressTotal, char *label)
{
	printf ("\r%s [", label);

	uint32 barPos = progressPos * 50 / progressTotal + 1;
	for (uint32 p = 0; p < barPos; p++) putchar ('#');
	for (uint32 p = barPos; p < 50; p++) putchar (' ');

	printf ("] %d%%\r", progressPos * 100 / progressTotal);
	fflush(stdout);
}
//------------------------------------------------------------------------------
void ProgressBarHide()
{
	putchar ('\r');

	for (int p = 0; p < 79; p++) putchar (' ');

	putchar ('\r');
	fflush(stdout);
}
//------------------------------------------------------------------------------
std::string EncodeBinaryStr (char *text, int size)
{
	static char *static_hex = "01234567890ABCDEF";

	std::string str;
	str.reserve (size * 2);

	for (int i = 0; i < size; i++)
	{
		str += static_hex[text[i] >> 4];
		str += static_hex[text[i] & 0x0F];
	}
	return str;
}
//------------------------------------------------------------------------------
char *DecodeBinaryStr (std::string text, int &size)
{
	size = text.size() / 2;
	char *out = new char[size + 1];
	char c, c1, c2;
	int outindex = 0;
	
	for (uint32 i = 0; i+1 < text.size(); i += 2)
	{
		c = text[i];
		if (c < '0' || (c > '9' && c < 'A') || c > 'F') {
			memset (out, 0, size);
			return out;
		}
		c1 = (c <= '9') ? (c - '0') : (c - 'A' + 10);
		
		c = text[i + 1];
		if (c < '0' || (c > '9' && c < 'A') || c > 'F') {
			memset (out, 0, size);
			return out;
		}
		c2 = (c <= '9') ? (c - '0') : (c - 'A' + 10);
		
		out[outindex++] = (c1 << 4) + c2;
	}

	return out;
}
//------------------------------------------------------------------------------
PreciseTime GetPreciseTime()
{
#ifdef WIN32
	static struct __timeb64 timebuffer;

	_ftime64( &timebuffer );

	return (uint64)timebuffer.time * PTSECONDS(1) + (uint64)timebuffer.millitm;
#else
	static struct timeval tv;
	static struct timezone tz;

	gettimeofday(&tv, &tz);

//#error "Check tv_usec divider here!!!"
	return (uint64)tv.tv_sec * PTSECONDS(1) + (uint64)tv.tv_usec / 1000000;
#endif
}
//------------------------------------------------------------------------------
uint64 hex2guid (const std::string& str)
{
	uint64 r = 0;
	for (size_t i = 0; i < str.size(); i++)
	{
		r = r * 16 + str[i] - 48 - ((str[i] >= 'A') ? 7 : 0) - ((str[i] >= 'a') ? 32 : 0);
	}
	return r;
}
//------------------------------------------------------------------------------
// Attempts to recognize Hex number in text in various notations:
// prefixed with zero (wadsux style), prefixed with 0x or 0X,
// and prefixed with $ (pascal style). Or returns normal atoi result.
uint32 hex_or_decimal (const char *s)
{
	if (!s[0]) return 0;
	if (s[0] == '0') {
		if (s[1] == 'x' || s[1] == 'X')
			return Utility::hex2unsigned (s+2);

		return Utility::hex2unsigned (s+1);
	}
	if (s[0] == '$') {
		return Utility::hex2unsigned (s+1);
	}
	return atoi (s);
}


//------------------------------------------------------------------------------
// Replace SQL important chars with encoded once
void replaceESCChars( char * inText, char * outText )
{  
	int iLen = strlen( inText );
	int iout = 0;

	for ( int iin = 0; inText[iin] != 0; iin++ )  
	{  
		if ( inText[ iin ] == '"' || inText[ iin ] == '\\' ||
			 inText[ iin ] == '\'' ) outText[ iout++ ] = '\\';

		outText[ iout++ ] = inText[ iin ];
	}  

	outText[ iout ] = 0;  
}  

//------------------------------------------------------------------------------
// Check if name is correct
// If proposed_len is not 0, then it is checked too
// Note: it is security check
bool CheckName(const char * const name, int proposed_len)
{
	if (proposed_len >= 30 || proposed_len < 0)
		return false;
	
	int i = 0;
	for (; name[i]!=0; i++)
	{
		if (proposed_len!=0 && proposed_len<=i)
			return false;

		if (!
			(
				(name[i]>='a' && name[i]<='z')
				||
				(name[i]>='A' && name[i]<='Z')
				||
				(name[i]>='0' && name[i]<='9')
				||
				(name[i]=='_' && name[i]=='-')
			)
			)
			return false;
	}
	
	if (proposed_len!=0 && i!=proposed_len)
		return false;

	return true;
}

//------------------------------------------------------------------------------
// Checks string, does not touch position
bool CheckNameInPacket(WorldPacket* recvPacket)
{
	size_t old_rpos = recvPacket->rpos();
	size_t packet_size = recvPacket->size();
	char tmp[51];
	for (uint32 i=0; i<50; i++)
	{
		if (i >= packet_size || i >= 30)
			return false;
		tmp[i] = recvPacket->read<char>();
		if (tmp[i] == 0)
			break;
	}
	recvPacket->rpos(old_rpos);
	return CheckName(tmp);
}

//******************************************************************************
