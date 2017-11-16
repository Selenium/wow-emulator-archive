// ToBin.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>

const char* ending = ".bin";
const char* endingreadable = ".txt";

struct String
{
	int len;
	char* str;
};

char charToChar(char c)
{
	char ret=0;
	switch(c)
	{
	case 'F':
		ret += 15;
		break;
	case 'E':
		ret += 14;
		break;
	case 'D':
		ret += 13;
		break;
	case 'C':
		ret += 12;
		break;
	case 'B':
		ret += 11;
		break;
	case 'A':
		ret += 10;
		break;
	case '9':
		ret += 9;
		break;
	case '8':
		ret += 8;
		break;
	case '7':
		ret += 7;
		break;
	case '6':
		ret += 6;
		break;
	case '5':
		ret += 5;
		break;
	case '4':
		ret += 4;
		break;
	case '3':
		ret += 3;
		break;
	case '2':
		ret += 2;
		break;
	case '1':
		ret += 1;
		break;
	}
	return ret;
}

char strToChar(FILE* f)
{
	char* tmp = new char[2];
	fread(tmp,1,2,f);
	char ret = 0;
	ret += charToChar(tmp[0]) * 16;
	ret += charToChar(tmp[1]);
	delete [] tmp;
	return ret;
}
	
String getToWhite(FILE* f)
{
	String str;
	str.str = new char[65536];
	str.len = 0;
	memset(str.str,0x00,65536);
	if(feof(f))
		return str;
	char tmp;
	fread(&tmp,1,1,f);
	while(!feof(f) && tmp != ' ' /* space */&& tmp != '\n' /* newline */&& tmp != '	'/* tab */)
	{
		str.str[str.len] = tmp;
		str.len++;
		fread(&tmp,1,1,f);
	}
	if(!feof(f)) fseek(f,ftell(f)-1,SEEK_SET);
	return str;
}

void skipWhite(FILE* f)
{
	char tmp;
	fread(&tmp,1,1,f);
	while(!feof(f) && (tmp == ' ' /* space */|| tmp == '\n' /* full newline*/||tmp == 0x0A /* newline part 1*/ || tmp == 0x0D /* newline part 2*/|| tmp == '	'/* tab */))
	{
		fread(&tmp,1,1,f);
	}
	if(!feof(f)) fseek(f,ftell(f)-1,SEEK_SET);
}

void skipToNewline(FILE* f)
{
	char tmp;
	fread(&tmp,1,1,f);
	while(!feof(f) && (tmp != '\n' /* newline part 1*/))
	{
		fread(&tmp,1,1,f);
	}
	//if(!feof(f)) fseek(f,ftell(f)-1,SEEK_SET);
}

int main(int argc, char* argv[])
{
	int num=0;
	if(argc < 2) 
	{
		printf("Useage: ToBin logfile.log\n");
		//argv[1] = new char[strlen("player.txt")];
		//strcpy(argv[1],"player.txt");
		return 0;
	}
	FILE *f = fopen(argv[1],"rb");
	if(f == NULL)
	{
		printf("File %s does not exist.\n",argv[0]);
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
	while(!feof(f))
	{
		short len;
		unsigned char* data;
		unsigned char* ip1,*ip2;
		char send = 2;
		bool log = false;

		String tmp;
		tmp = getToWhite(f); // Packet Number
		delete [] tmp.str;
		skipWhite(f);

		tmp = getToWhite(f); // Sending IP
		if(strcmp(tmp.str,"127.0.0.1")) log = true;
		ip1 = new unsigned char[tmp.len];
		strcpy((char *)ip1,tmp.str);
		delete [] tmp.str;
		skipWhite(f);

		tmp = getToWhite(f); // Recieving IP
		if(strcmp(tmp.str,"127.0.0.1")) log = true;
		ip2 = new unsigned char[tmp.len];
		strcpy((char *)ip2,tmp.str);
		delete [] tmp.str;
		skipWhite(f);


		tmp = getToWhite(f); // Packet len - IMPORTANT!
		len = (short)atoi(tmp.str);
		delete [] tmp.str;
		skipWhite(f);

		if(len < 4) log = false;

		data = new unsigned char[len];

		tmp = getToWhite(f); // Send / Recieve - IMPORTANT
		switch(tmp.str[0])
		{
		case 'R':
			send = 1;
			break;
		case 'S':
			send = 0;
			break;
		}
		delete [] tmp.str;
		skipWhite(f);

		// Data collection:

		int pnt=0;
		for(int i=0;i<len/16;i++)
		{
			tmp = getToWhite(f); // Packet offset
			delete [] tmp.str;
			skipWhite(f);
			for(int j=0;j<16;j++)
			{
				data[pnt] = strToChar(f);
				skipWhite(f);
				pnt++;
			}
			skipToNewline(f);
		}

		if(pnt < len)
		{
			tmp = getToWhite(f); // Packet offset
			delete [] tmp.str;
			skipWhite(f);
			for(i=pnt;i<len;i++)
			{
				data[pnt] = strToChar(f);
				skipWhite(f);
				pnt++;
			}
			skipToNewline(f);
		}
		skipWhite(f);

		if(log)
		{
			fwrite(&send,1,1,fOut);
			if(send == 1)
			{
				char strl = (char)strlen((char *)ip1);
				fwrite(&strl,1,1,fOut);
				fwrite(ip1,1,strl,fOut);
			}
			else
			{
				char strl = (char)strlen((char *)ip2);
				fwrite(&strl,1,1,fOut);
				fwrite(ip2,1,strl,fOut);
			}
			fwrite(&len,1,2,fOut);
			fwrite(data,1,len,fOut);
		}
			
	}
	fclose(f);
	fclose(fOut);

	return 0;
}
	