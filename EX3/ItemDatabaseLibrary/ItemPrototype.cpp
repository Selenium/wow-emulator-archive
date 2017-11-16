// (c) AbyssX Group

#include "ItemDatabaseEnvironment.h"

ItemPrototype::ItemPrototype()
{
	outputBuffer = NULL;
	buffersize = 0;
	built =true;
	infoSet = false;
}


ItemPrototype::ItemPrototype(const ItemPrototypeData *data)
{
	ItemPrototype();
	SetPrototypeData(data);
}

void ItemPrototype::SetPrototypeData(const ItemPrototypeData *data)
{
	built= false;
	memcpy(&(this->data),data,sizeof(this->data));
	for (int i=0;i<4;i++)
	{
		this->data.name[i] = new char[strlen(data->name[i])+1];
		strcpy(this->data.name[i],data->name[i]);
	}
	this->data.description = new char[strlen(data->description)+1];
	strcpy(this->data.description,data->description);
	infoSet = true;
}

ItemPrototypeData *ItemPrototype::GetModifiablePrototypeData()
{
	built=false;
	return &data;
}

const ItemPrototypeData *ItemPrototype::GetPrototypeData()
{
	return &((const ItemPrototypeData)data);
}

const char *ItemPrototype::GetPrototypePacket()
{
	Build();
	return (const char*)outputBuffer;
}

const short ItemPrototype::GetPacketSize()
{
	Build();
	return buffersize;
}

void ItemPrototype::Build()
{
	if(!built)
	{
	if(outputBuffer != NULL)
		{
			delete [buffersize] outputBuffer;
			buffersize = 0;
			outputBuffer = NULL;
		}
		char*tempBuffer = new char[65536];
		char*bufpnt = tempBuffer;

		memcpy(bufpnt,&(data.id),12);
		buffersize+=12;
		bufpnt+=12;

		for(int i=0;i<4;i++)
		{
			strcpy(bufpnt,data.name[i]);
			short strLen = (short)strlen(data.name[i])+1;
			buffersize+=strLen;
			bufpnt+=strLen;
		}

		memcpy(bufpnt,&data.displayID,364);
		buffersize+=364;
		bufpnt+=364;

		strcpy(bufpnt,data.description);
		short strLen =(short)strlen(data.description)+1;
		buffersize+=strLen;
		bufpnt+=strLen;

		memcpy(bufpnt,&data.pageMaterial,28);
		buffersize+=28;
		bufpnt+=28;

		outputBuffer = new char[buffersize];
		memcpy(tempBuffer,outputBuffer,buffersize);
		delete [65536] tempBuffer;
		built= true;			
	}
}

const bool ItemPrototype::IsInfoSet()
{
	return infoSet;
}

const bool ItemPrototype::IsBuilt()
{
	return built;
}

ItemPrototype::~ItemPrototype()
{
	if(outputBuffer != NULL)
		delete [buffersize] outputBuffer;
	buffersize = 0;
}