#ifndef _UTIL_H
#define _UTIL_H

//#include "Common.h"

#include "OurDefs.h"
#include <vector>
#include <string>

// Displays nice text progress bar
void ProgressBarShow (uint32 progressPos, uint32 progressTotal, char *label);
void ProgressBarHide();

///////////////////////////////////////////////////////////////////////////////
// String Functions ///////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
std::vector<std::string> StrSplit(const std::string &src, const std::string &sep);

// Encodes block of binary data into text string good for storing in SQL
std::string EncodeBinaryStr (char *text, int size);

// Decodes block of binary data and allocates new memory for it.
// Caller should free the memory
char *DecodeBinaryStr (std::string text, int &size);

// 0.001 second precise time
typedef uint64 PreciseTime;

#define PTPRECISION 1000
#define PTSECONDS(s) ((s) * PTPRECISION)

PreciseTime GetPreciseTime();

uint64 hex2guid (const std::string& str);
uint32 hex_or_decimal (const char *s);

void replaceESCChars( char * inText, char * outText );

// Check if name is correct
// If proposed_len is not 0, then it is checked too
// Note: it is security check
bool CheckName(const char * const name, int proposed_len=0);
// Checks string, does not touch position
class WorldPacket;
bool CheckNameInPacket(WorldPacket* recvPacket);

#endif