// NiceLog.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#define ZLIB_WINAPI
#include "zlib.h"

const char* ending = ".log";
/*typedef char* (*GETNAMEPROC)(void);
typedef void (*INITPROC)(void);
typedef void (*DESTROYPROC)(void);
typedef bool (*DOOPCODEPROC)(long opcode);
typedef long (*DOPACKETPROC)(long *opcode, short *len, char* data, char* f);

int numDLLsInFolder()
{
	WIN32_FIND_DATA FileData; 
	HANDLE hSearch;  
	BOOL fFinished = FALSE;

	int num=0;

	//Getting number of DLLs
	hSearch = FindFirstFile(".\\Plugins\\*.dll", &FileData); 
	if (hSearch == INVALID_HANDLE_VALUE) 
	{ 	
		return 0;
	} 
	
	while (!fFinished) 
	{ 
		num++;
		
		if (!FindNextFile(hSearch, &FileData)) 
		{
			if (GetLastError() == ERROR_NO_MORE_FILES) 
			{ 
				return num;
			} 
			else 
			{ 
				printf("Couldn't count DLLs."); 
				return 0;
			} 
		}
	}
	return num;
}*/

int main(int argc, char* argv[])
{
	if(argc < 2) 
	{
		printf("Useage: ToBin logfile.log\n");
		//argv[1] = new char[strlen("player.txt.bin")];
		//strcpy(argv[1],"player.txt.bin");
		return 0;
	}
	FILE *f = fopen(argv[1],"rb");
	if(f == NULL)
	{
		printf("File %s does not exist.\n",argv[1]);
		return 0;
	}
	char* newname = new char[strlen(argv[1]) + 4];
	strcpy(newname,argv[1]);
	strcat(newname,ending);
	FILE *fOut = fopen(newname,"wb");
	if(fOut == NULL)
	{
		fclose(f);
		printf("Could not create file %s. Check permissions and/or disk space.\n",newname);
		return 0;
	}

	printf("Analyzing dump...");
	
	while(!feof(f))
	{
		unsigned char* data,*pktdata,*ip;
		char strl,send;
		short len;

		fread(&send,1,1,f);
		fread(&strl,1,1,f);
		ip = new unsigned char[strl+1];
		fread(ip,1,strl,f);
		ip[strl] = 0x00;
		fread(&len,1,2,f);
		data = new unsigned char[len];
		fread(data,1,len,f);

		long opcode;
		int pnt=0;
		if(send == 0)
		{
			len-=2;
			pnt+=2;
		}
		memcpy(&opcode,data+pnt,4);
		len-=4;
		pnt+=4;
		
		pktdata = new unsigned char[len];
		memcpy(pktdata,data+pnt,len);
		
		if (opcode == 0x1E7) {
			fprintf(fOut,"%s %s len: %u opcode: %X - Compressed. Uncompressed version:\r\n",send == 0 ? "                    SEND" : "RECV",ip,len,opcode);
			short tlen;
			memcpy((char *)&tlen,data+pnt,2);
			unsigned char *destination = new unsigned char[tlen+4];
			unsigned long destlen = tlen+4;
			
			int zrv = ::uncompress((unsigned char *)destination,&destlen,(unsigned char *)&pktdata[pnt],len);
			if (zrv == 0) {
				opcode = 0xA9;
				//length = (short)(destlen +4);
				delete [] data;
				data = destination;
				len = (short)destlen;
			}
		}
		
		fprintf(fOut,"%s %s len: %u opcode: %X\r\n",send == 0 ? "                    SEND" : "RECV",ip,len,opcode);
		
		for(int i=0;i<len/4;i++)
		{
			fprintf(fOut,"%s",send == 0 ? "                    " : "");
			for(int j=0;j<4;j++)
			{
				fprintf(fOut,"%02X ",data[i*4+j+pnt]);
			}
			fprintf(fOut,"\r\n");
		}
		if(i*4 < len) 
		{
			fprintf(fOut,"%s",send == 0 ? "                    " : "");
			for(i=i*4;i<len;i++) 
			{
				fprintf(fOut,"%02X ",data[i+pnt]);
			}
			fprintf(fOut,"\r\n");
		}
		fprintf(fOut,"\r\n");
		delete [] data;
		delete [] ip;
	}

	printf("Done!\n");
	return 0;
}
 
 