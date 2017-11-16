#include "stdafx.h"
#include "Debug.h"
#include "ConsoleInterface.h"
#include "TownHall.h"
#include "TownHallDlg.h"
#include "Globals.h"
#include "ConsoleDlg.h"

#define TIMESTAMP 1
#define TIME_FORMAT "%Y/%m/%d %H:%M:%S: "
#define ALLOW_LOGBUFFER

CDebug::CDebug(void)
{
	Initialized=false;
}
CDebug::CDebug(const char *debugfile)
{
	strcpy(Outfile,debugfile);
	Initialized=true;
}

CDebug::~CDebug(void)
{
}

void CDebug::Initialize(const char *debugfile)
{
	strcpy(Outfile,debugfile);
	Initialized=true;
}

void CDebug::Log(const char *out)
{
	if (!Initialized) return;

	CLock L(&S,true);
	FILE *file=fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
#if TIMESTAMP
	struct tm *now;
	time_t cur=time(0);
	char tmpbuf[80];
	now = localtime(&cur);
	strftime( tmpbuf, 70, TIME_FORMAT, now );
	fprintf(file,"%s%s\n", tmpbuf,out);
#else
	fputs(out,file);
#endif
#ifdef WIN32
	//dlg->LogText(out);
#else
	puts(out);
#endif
	fclose(file);
}

void CDebug::Logf(const char *format,...)
{
	if (!Initialized) return;
	CHAR szOutput[20480] = {0};
	va_list vaList;
	va_start( vaList, format );
	vsprintf(szOutput,format, vaList);
	CLock L(&S,true);
	FILE *file = fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
#if TIMESTAMP
	struct tm *now;
	time_t cur=time(0);
	char tmpbuf[80];
	now = localtime(&cur);
	strftime( tmpbuf, 70, TIME_FORMAT, now );
	fprintf(file,"%s%s\n", tmpbuf,szOutput);
#else
	fputs(szOutput,file);
#endif
#ifdef WIN32
	//dlg->LogText(szOutput);
#else
	puts(szOutput);
#endif
	fclose(file);
}

void CDebug::Error(const char *format,...)
{
	if (!Initialized) return;
	CHAR szOutput[20480] = {0};
	va_list vaList;
	va_start( vaList, format );
	vsprintf(szOutput,format, vaList);
	CLock L(&S,true);
	FILE *file = fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
#if TIMESTAMP
	struct tm *now;
	time_t cur=time(0);
	char tmpbuf[80];
	now = localtime(&cur);
	strftime( tmpbuf, 70, TIME_FORMAT, now );
	fprintf(file,"%s%s\n", tmpbuf,szOutput);
#else
	fputs(szOutput,file);
#endif
	fclose(file);
}

void CDebug::Warning(const char *format,...)
{
	if (!Initialized) return;
	CHAR szOutput[20480] = {0};
	va_list vaList;
	va_start( vaList, format );
	vsprintf(szOutput,format, vaList);
	CLock L(&S,true);
	FILE *file = fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
#if TIMESTAMP
	struct tm *now;
	time_t cur=time(0);
	char tmpbuf[80];
	now = localtime(&cur);
	strftime( tmpbuf, 70, TIME_FORMAT, now );
	fprintf(file,"%s%s\n", tmpbuf,szOutput);
#else
	fputs(szOutput,file);
#endif
	fclose(file);
}

const char Writechars[257]=
"................"   // 0-15
"................"   // 16-31
" !\"#$%&'()*+,-./"   // 32-47
"0123456789:;<=>?"   // 48-63
"@ABCDEFGHIJKLMNO"   // 64-79
"PQRSTUVWXYZ[\\]^_"   // 80-95
"`abcdefghijklmno"   // 96-111
"pqrstuvwxyz{|}~¦"   // 112-127
"ÇüéâäàåçêëèïîìÄÅ"   // 128-143
"ÉæÆôöòûùÿÖÜ¢£¥Pƒ"   // 144-159
"áíóúñÑªº¿¬¬½¼¡«»"   // 160-175
"¦¦¦¦¦¦¦++¦¦+++++"   // 176-191
"+--+-+¦¦++--¦-+-"   // 192-207
"---++++++++¦_¦¦¯"   // 208-223
"aßGpSsµtFTOd8fen"   // 224-239
"=±==()÷˜°··vn²¦ ";  // 240-255

void CDebug::LogBuffer(const char *out, long len, const char *Descriptor)
{
#ifdef ALLOW_LOGBUFFER
	if (!Initialized) return;
	CLock L(&S,true);
	FILE *file=fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
	char block[17];
	block[16]=0;
	char Part[512];
	char Out[512];

	unsigned short Pos=0;
	fputs("\n________________________________________________________________________\n",file);
#if TIMESTAMP
	struct tm *now;
	time_t cur=time(0);
	char tmpbuf[80];
	now = localtime(&cur);
	strftime( tmpbuf, 70, TIME_FORMAT, now );
	fprintf(file,"%s Len %u: %s\n", tmpbuf,len,Descriptor);
#else
	fputs(Descriptor,file);
#endif
	if (len<=0)
	{
		fputs("0000: (null)\n",file);
	}
	while(Pos<len)
	{
		Out[0]=0;
		sprintf(Part,"%04X:  ",Pos);
		strcat(Out,Part);
		for (int i = 0 ; i < 16 ; i++)
		{
			int pI=Pos+i;
			if (pI<len)
			{
				unsigned char ch=out[pI];
				block[i]=Writechars[ch];
				sprintf(Part,"%02X",ch);
				strcat(Out,Part);
			}
			else
			{
				block[i]=' ';
				strcat(Out,"  ");
			}

			if ((i&3)==3 && i>1 && i<15) // %4 --> &3
			{
				strcat(Out,"-");
			}
			else
				strcat(Out," ");
		}
		strcat(Out," ");
		strcat(Out,&block[0]);
		strcat(Out,"\n");
		fputs(Out,file);
		Pos+=16;
	}
	fputs("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n",file);
	fclose(file);
	//	file.Close();
#endif // ALLOW_LOGBUFFER
}

// Global debug object
CDebug Debug("CDebug.txt");
