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
	if(fp) return true;
	char *file = (char *)malloc(sizeof(char) * ((strlen(fname) * strlen(Settings.dbc_path)) + 2));
	strcpy(file, Settings.dbc_path);
	strcat(file, "/");
	strcat(file, fname);
	if (!(fp = fopen(file, _FO_READB)))
	{
		if (_FileExists(file))
		{
			Debug.Error("DBCFile::init() - File %s exists but could not be opened",file);
		}
		else
		{
			Debug.Error("DBCFile::init() - File %s does not exist",file);
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

bool DBCFile::prepPosition(unsigned long key, unsigned long col)
{
	if (((int)col)>header.cols)
		return false;
	unsigned long position=KeyMap[key];
	if (!position) // this auto-catches a null fp
		return false;

	// <lax> note: we might as well say *4 because if sizeof(int) isnt 4 this is going to be failing anyway :)
	fseek(fp,position+col*sizeof(int),SEEK_SET);
	return true;
}

bool DBCFile::getValue(unsigned long key, unsigned long col, int &value)
{
	if(!prepPosition(key,col)) return false;
	fread(&value,sizeof(int),1,fp);
	return true;
}

int DBCFile::getValue(unsigned long key, unsigned long col)
{
	if(!prepPosition(key,col)) return -1;
	int val;
	fread(&val,sizeof(int),1,fp);
	return val;
}

bool DBCFile::getValue(unsigned long key, unsigned long col, float &value)
{
	if(!prepPosition(key,col)) return false;
	fread(&value,sizeof(int),1,fp);
	return true;
}

bool DBCFile::getString(unsigned long key, unsigned long col, char *buffer, unsigned long buffersize)
{
	if(!prepPosition(key,col)) return false;
	unsigned long val=0;
	fread(&val,sizeof(unsigned long),1,fp);
	if (val==0)
	{
		buffer[0]=0;
		return true;
	}
	if (((int)val)>header.str_len)
		return false;

	if (((int)(val+buffersize))>header.str_len)
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

bool DBCFile::fetchRow(unsigned long key, void* buffer)
{
	unsigned long position=KeyMap[key];
	if (!position) // this auto-catches a null fp
		return false;
	// if buffer is null let the fucking thing crash on fread so whoever sucks can fix it :)
	fseek(fp,position,SEEK_SET);
	return fread(buffer,header.cols * sizeof(int),1,fp)!=0;
}

void DBCFile::prepNoKeyPosition(unsigned long row, unsigned long col)
{
	unsigned long rowsize=header.cols * sizeof(int);

	unsigned long position = sizeof(header);
	if (row)
		position += rowsize * row;

	fseek(fp, position+(col*sizeof(int)), SEEK_SET);
}

int DBCFile::getIntValueNoKey(unsigned long row, unsigned long col)
{
	prepNoKeyPosition(row,col);

	int val;
	fread(&val, sizeof(int), 1, fp);
	return val;
}

float DBCFile::getFloatValueNoKey(unsigned long row, unsigned long col)
{
	prepNoKeyPosition(row,col);

	float val;
	fread(&val, sizeof(float), 1, fp);
	return val;
}

bool CDBCManager::Initialize()
{
	bool ReturnFalse=false;
	ReturnFalse|=Spell.init("Spell.dbc");
	ReturnFalse|=Emotes.init("EmotesText.dbc");
	ReturnFalse|=Faction.init("Faction.dbc");
	ReturnFalse|=FactionTemplate.init("FactionTemplate.dbc");
	ReturnFalse|=SpellDuration.init("SpellDuration.dbc");
	ReturnFalse|=SpellItemEnchantment.init("SpellItemEnchantment.dbc");
	ReturnFalse|=SpellEffectNames.init("SpellEffectNames.dbc");
	ReturnFalse|=SpellAuraNames.init("SpellAuraNames.dbc");
	ReturnFalse|=SpellRadius.init("SpellRadius.dbc");
	ReturnFalse|=SkillLineAbility.init("SkillLineAbility.dbc");
	ReturnFalse|=SpellCast.init("SpellCastTimes.dbc");
	ReturnFalse|=TaxiPathNodes.init("TaxiPathNode.dbc");
	ReturnFalse|=TaxiPath.init("TaxiPath.dbc");
	ReturnFalse|=TaxiNodes.init("TaxiNodes.dbc");
	ReturnFalse|=WorldMapOverlay.init("WorldMapOverlay.dbc");
	ReturnFalse|=WorldMapArea.init("WorldMapArea.dbc");
	ReturnFalse|=AreaTable.init("AreaTable.dbc");
	ReturnFalse|=Talent.init("Talent.dbc");
	return (!ReturnFalse);
}
