#include "stdafx.h"
#include "DBCHandler.h"
#include "Globals.h"

DBCFile::DBCFile()
{
	fp=0;
}

DBCFile::~DBCFile()
{
	if (fp)
		fclose(fp);
}

bool DBCFile::init(char *fname)
{
	char *file = (char *)malloc(sizeof(char) * ((strlen(fname) * strlen(Settings.dbc_path)) + 2));
	strcpy(file, Settings.dbc_path);
	strcat(file, "/");
	strcat(file, fname);
	
	if (!(fp = fopen(file, _FO_READB)))
	{
		if (_FileExists(file))
		{
			Debug.Error("DBCFile: File %s exists but could not be opened\n",file);
		}
		else
		{
			Debug.Error("DBCFile: File %s does not exist\n",file);
		}

		free(file);
		return false;
	}
	
	free(file);
	
	fread(&header, sizeof(header), 1, fp);
	
	unsigned long rowsize=header.cols * sizeof(int);
	int *row = (int *)malloc(rowsize);
	// populate KeyMap
	unsigned long ThisPosition=sizeof(header);
	while(fread(row, rowsize, 1, fp)==1)
	{
		KeyMap[row[0]]=ThisPosition;
		ThisPosition+=rowsize;
	}
	free(row);

	return true;
}

bool DBCFile::getValue(unsigned long key, unsigned long col, int &value)
{
	if (col>header.cols)
		return false;
	unsigned long position=KeyMap[key];
	if (!position) // this auto-catches a null fp
		return false;

	// <lax> note: we might as well say *4 because if sizeof(int) isnt 4 this is going to be failing anyway :)
	fseek(fp,position+col*sizeof(int),SEEK_SET);
	fread(&value,sizeof(int),1,fp);
	return true;
}

int DBCFile::getValue(unsigned long key, unsigned long col)
{
	if (col>header.cols)
		return -1;
	unsigned long position=KeyMap[key];
	if (!position) // this auto-catches a null fp
		return -1;


	// <lax> note: we might as well say *4 because if sizeof(int) isnt 4 this is going to be failing anyway :)
	fseek(fp,position+col*sizeof(int),SEEK_SET);
	int val;
	fread(&val,sizeof(int),1,fp);
	return val;
}

bool DBCFile::getValue(unsigned long key, unsigned long col, float &value)
{
	if (col>header.cols)
		return false;
	unsigned long position=KeyMap[key];
	if (!position) // this auto-catches a null fp
		return false;

	// <lax> note: we might as well say *4 because if sizeof(int) isnt 4 this is going to be failing anyway :)
	fseek(fp,position+col*sizeof(int),SEEK_SET);
	fread(&value,sizeof(int),1,fp);
	return true;
}

bool DBCFile::getString(unsigned long key, unsigned long col, char *buffer, unsigned long buffersize)
{
	if (col>header.cols || !buffersize)
		return false;
	unsigned long position=KeyMap[key];
	if (!position) // this auto-catches a null fp
		return false;

	// <lax> note: we might as well say *4 because if sizeof(int) isnt 4 this is going to be failing anyway :)
	fseek(fp,position+col*sizeof(int),SEEK_SET);
	unsigned long val=0;
	fread(&val,sizeof(unsigned long),1,fp);
	if (val==0)
	{
		buffer[0]=0;
		return true;
	}
	if (val>header.str_len)
		return false;

	if (val+buffersize>header.str_len)
	{	
		buffersize=header.str_len-val;
	}
	fseek(fp,StringPos+val,SEEK_SET);
	if (fread(buffer,buffersize,1,fp)!=1)
		return false;
	buffer[buffersize-1]=0;// null terminate it ourselves.
	return true;
}

bool DBCFile::fetchRow(unsigned long key, int *buffer)
{
	unsigned long position=KeyMap[key];
	if (!position) // this auto-catches a null fp
		return false;
	// if buffer is null let the fucking thing crash on fread so whoever sucks can fix it :)

	fseek(fp,position,SEEK_SET);
	return fread(buffer,header.cols * sizeof(int),1,fp)!=0;
}


bool CDBCManager::Initialize()
{
	bool ReturnFalse=false;
	ReturnFalse|=Spell.init("Spell.dbc");
	ReturnFalse|=EmotesText.init("EmotesText.dbc");
	ReturnFalse|=SpellDuration.init("SpellDuration.dbc");

	return (!ReturnFalse);
}

