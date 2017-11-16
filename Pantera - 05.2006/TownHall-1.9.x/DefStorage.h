#ifndef DEFSTORAGE_H
#define DEFSTORAGE_H

#include "Storage.h"
#include <map>
#include <string>
#include <algorithm>
#include "Queue.h"
#include "DataManager.h"

extern class CDataManager DataManager;

using namespace std;
#ifndef _MakeLower
#define _MakeLower(yourstring) transform (yourstring.begin(),yourstring.end(), yourstring.begin(), tolower);
#endif

#define CStorage CDefStorage
#ifdef WIN32
#define STORAGE_APPEND	"ab"
#define STORAGE_READ	"rb"
#define STORAGE_WRITE	"r+b"
#define STORAGE_CREATE	"w+b"
#else
#define STORAGE_APPEND	"a"
#define STORAGE_READ	"r"
#define STORAGE_WRITE	"r+"
#define STORAGE_CREATE	"w+"
#endif

// "flat file" storage system
// every object of x type will give the same size of data to store
// we can have one file per type.
// keep rotating backups of the main file.

// this gives us the ability to keep a list (per type) of locations in the file
// where each object of that type is.  then to read, we read x size at that location.
// to write, we write x size at that location.  to delete, we zero out x size and add
// to a list of freed locations.  to add, we first check the list of freed locations,
// and use one of those, otherwise append.

// each file needs a header.  this header needs to identify the object type in the file,
// and the size of each object stored.
// HEADER:
//     type     |    size     |
//  01 00 00 00 | 10 00 00 00 |

// each object in the file needs to have a header. this header needs to identify the
// particular object's 32-bit ID, and a CRC to identify database corruption
// OBJECT HEADER:
//     guid     |    crc32    |
//  05 10 01 00 | DA BC 65 17 |

// the structure of each file will go like this:
// HEADER | OBJECT HEADER | OBJECT DATA | OBJECT HEADER | OBJECT DATA |  . . .

// TODO: Threaded file storage and deletion

struct DefStorageFileHeader
{
	unsigned long Type;
	unsigned long ItemSize;
};

struct DefStorageItemHeader
{
	unsigned long ID;
	unsigned long CRC32;
};

class CDefStorageFile
{
public:
	CDefStorageFile()
	{
		TotalItems=0;
		ItemSize=0;
		file=0;
		HighestID=0;
		Safe=false;
	}

	~CDefStorageFile()
	{
		if (file)
			fclose(file);
	}

	void Clear()
	{
		if (file)
		{
			fclose(file);
			file=0;
		}
		Positions.clear();
		Deleted.Clear();
		ItemSize=0;
		TotalItems=0;
		HighestID=0;
		ItemType=0;
		Safe=false;
	}

	bool Initialize(unsigned long Type,const char *filename)
	{
		Clear();
		ItemType=Type;
		if (strlen(filename)>255)
			return false;
		strcpy(szfilename,filename);
		if (_FileExists(filename))
		{
			if ((file=fopen(filename,STORAGE_WRITE)))
			{
				// read header
				DefStorageFileHeader FileHeader;
				if (!fread(&FileHeader,sizeof(DefStorageFileHeader),1,file))
					return false;
				if (FileHeader.Type!=Type)
					return false;
				ItemSize=FileHeader.ItemSize;
				DefStorageItemHeader ItemHeader;
				void *buffer=malloc(ItemSize);
				unsigned long ThisPosition=sizeof(DefStorageFileHeader);
				while(fread(&ItemHeader,sizeof(DefStorageItemHeader),1,file)==1)
				{
					if (ItemHeader.ID)
					{
						Positions[ItemHeader.ID]=ThisPosition;
						if (ItemHeader.ID>HighestID)
							HighestID=ItemHeader.ID;
					}
					else
					{
						Deleted.Push(ThisPosition);
					}
					fseek(file,ItemSize,SEEK_CUR);
					ThisPosition+=sizeof(DefStorageItemHeader)+ItemSize;
				}
				free(buffer);
				Safe=true;
				return true;
			}
			return false; // unsafe
		}
		else
		{
			// TODO
			// create and initialize empty file

			// Note: In order to initialize the file, we need to know the size of each item.
			// we wont know this until storage.. so lets initialize on first storage.
			Safe=true;
			return true;
		}
	}

	inline unsigned long TotalLinear()
	{
		if (!Safe || !file)
			return 0;
		// yeah theres other ways to get file size, im lazy
		fseek(file,0,SEEK_END);
		unsigned long Size=ftell(file);
		if (Size<sizeof(DefStorageFileHeader))
			return 0;
		return (Size-sizeof(DefStorageFileHeader))/(sizeof(DefStorageItemHeader)+ItemSize);
	}

	unsigned long RetrieveLinear(ObjectStorage &Data, unsigned long index)
	{
		if (!Safe || !file)
			return 0;
		Data.Allocate(ItemSize);
		if (Data.Size < ItemSize)
			return false;
		unsigned long Pos=sizeof(DefStorageFileHeader)+index*(sizeof(DefStorageItemHeader)+ItemSize);
		fseek(file,Pos,SEEK_SET);
		DefStorageItemHeader ItemHeader;
		if (!fread(&ItemHeader,sizeof(DefStorageItemHeader),1,file))
			return 0;
		if (!fread(Data.Data,ItemSize,1,file))
			return 0;
		if (GenerateCRC(Data)!=ItemHeader.CRC32)
			return 0; // invalid crc!
		return ItemHeader.ID;
	}

	unsigned long RetrieveLinear(unsigned long index)
	{
		if (!Safe || !file)
			return 0;

		unsigned long Pos=sizeof(DefStorageFileHeader)+index*(sizeof(DefStorageItemHeader)+ItemSize);
		fseek(file,Pos,SEEK_SET);
		DefStorageItemHeader ItemHeader;
		if (!fread(&ItemHeader,sizeof(DefStorageItemHeader),1,file))
			return 0;
		return ItemHeader.ID;
	}

	bool RetrieveObject(ObjectStorage &Data, unsigned long ID)
	{
		if (unsigned long Pos=Positions[ID])
		{
			fseek(file,Pos,SEEK_SET);
			DefStorageItemHeader ItemHeader;
			if (!fread(&ItemHeader,sizeof(DefStorageItemHeader),1,file))
				return false;
			Data.Allocate(ItemSize);
			if (!fread(Data.Data,ItemSize,1,file))
				return false;
			if (GenerateCRC(Data)!=ItemHeader.CRC32)
				return false; // invalid crc!
			return true;
		}
		else
			return false;
	}

	bool StoreObject(ObjectStorage &Data, unsigned long ID)
	{
		if (!file)
		{
			if (!Safe)
				return false;
			if ((file=fopen(szfilename,STORAGE_CREATE)))
			{
				// initialize file
				DefStorageFileHeader FileHeader;
				ItemSize=FileHeader.ItemSize=Data.Size;
				FileHeader.Type=ItemType;
				fwrite(&FileHeader,sizeof(DefStorageFileHeader),1,file);
			}
			else
				return false;
		}

		if (Data.Size>ItemSize)
			return false;// size too big...
		if (unsigned long Pos=Positions[ID])
		{
			fseek(file,Pos,SEEK_SET);
			DefStorageItemHeader ItemHeader;
			ItemHeader.CRC32=GenerateCRC(Data);
			ItemHeader.ID=ID;
			fwrite(&ItemHeader,sizeof(DefStorageItemHeader),1,file);
			fwrite(Data.Data,Data.Size,1,file);
		}
		else
		{
			// new position
			if (Deleted.Empty())
			{
				// end
				fseek(file,0,SEEK_END);
				Pos=ftell(file);
				Positions[ID]=Pos;
				DefStorageItemHeader ItemHeader;
				ItemHeader.CRC32=GenerateCRC(Data);
				ItemHeader.ID=ID;
				fwrite(&ItemHeader,sizeof(DefStorageItemHeader),1,file);
				fwrite(Data.Data,Data.Size,1,file);
			}
			else
			{
				unsigned long Pos=Deleted.Pop();
				Positions[ID]=Pos;
				fseek(file,Pos,SEEK_SET);
				DefStorageItemHeader ItemHeader;
				ItemHeader.CRC32=GenerateCRC(Data);
				ItemHeader.ID=ID;
				fwrite(&ItemHeader,sizeof(DefStorageItemHeader),1,file);
				fwrite(Data.Data,Data.Size,1,file);
			}
		}
		return true;
	}

	bool DeleteObject(unsigned long ID)
	{
		if (unsigned long Pos=Positions[ID])
		{
			fseek(file,Pos,SEEK_SET);
			DefStorageItemHeader ItemHeader;
			memset(&ItemHeader,0,sizeof(DefStorageItemHeader));
			fwrite(&ItemHeader,sizeof(DefStorageItemHeader),1,file);
			Deleted.Push(ID);
			return true;
		}
		else
			return false;
	}

	bool Convert(unsigned long NewItemSize)
	{
		if (!file)
		{
			return false;
		}
		if (NewItemSize<ItemSize)
			return false;
		if (NewItemSize==ItemSize)
			return true;

		FILE *newfile=fopen("conversion.thd",STORAGE_CREATE);
		if (!newfile)
			return false;
		// initialize file
		DefStorageFileHeader FileHeader;
		FileHeader.ItemSize=NewItemSize;
		FileHeader.Type=ItemType;
		fwrite(&FileHeader,sizeof(DefStorageFileHeader),1,newfile);
		// write all valid objects
		DefStorageItemHeader ItemHeader;
		ObjectStorage Data;
		Data.Allocate(NewItemSize);
		while(1)
		{
			if (!fread(&ItemHeader,sizeof(DefStorageItemHeader),1,file))
				break;
			if (!fread(Data.Data,ItemSize,1,file))
				break;
			if (GenerateCRC(Data,ItemSize)==ItemHeader.CRC32)
			{
				ItemHeader.CRC32=GenerateCRC(Data);
				fwrite(&ItemHeader,sizeof(DefStorageItemHeader),1,newfile);
				fwrite(Data.Data,NewItemSize,1,newfile);
			}
		}
		ItemSize=NewItemSize;
		fclose(newfile);
		fclose(file);
		file=0;
		remove(szfilename);
		rename("conversion.thd",szfilename);
		Initialize(ItemType,szfilename);
		return true;
	}

	unsigned long GenerateCRC(ObjectStorage &Data) { return 0; }
	unsigned long GenerateCRC(ObjectStorage &Data, unsigned long Size) { return 0; }

	unsigned long TotalItems;
	unsigned long HighestID;
private:
	map<unsigned long,unsigned long> Positions;
	Queue<unsigned long> Deleted;
	unsigned long ItemSize;
	unsigned long ItemType;
	char szfilename[256];
	FILE *file;
	bool Safe;
};

class CDefStorage : CStorageSolution
{
public:
	CDefStorage()
	{
		HighestID=0;
	}

	~CDefStorage()
	{
	}

	bool Initialize()
	{
		char filename[256]={0};
		for ( int i = 1 ; i < OBJ_TYPES ; i++)
		{
			sprintf(filename,"data/obj%02d.thd",i);
			if (!Files[i].Initialize(i,filename))
			{
				return false; // not safe to continue :(
			}
			else
			{
				if (Files[i].HighestID>HighestID)
					HighestID=Files[i].HighestID;
				//set the next id if the guid is correct
				if(Files[i].HighestID & (i << 24)) DataManager.SetNextID(Files[i].HighestID,i);
			}
		}
		/* Screw the Highest ID stuff b/c of type-specific GUIDs now
		if (HighestID<0x100000)
		HighestID=0x100000;
		DataManager.SetNextID(HighestID);
		*/
		return true;
	}

	void SetObjectSize(unsigned long Type, unsigned long Size)
	{
		if (Type==0 || Type>OBJ_TYPES)
			return;
		Files[Type].Convert(Size);
	}

	bool StoreObject(CWoWObject &Object)
	{
		ObjectStorage Data;
		// get the data to be stored
		if (Object.type==0 || Object.type>=OBJ_TYPES) return false;
		if (!Object.StoringData(Data)) return false;
		// then store it
		return Files[Object.type].StoreObject(Data,Object.guid);
	}

	bool RetrieveObject(CWoWObject &Object, unsigned long ID)
	{
		ObjectStorage Data;
		// read data and set up the object storage
		if (Object.type==0 || Object.type>=OBJ_TYPES) return false;
		if (!Files[Object.type].RetrieveObject(Data,ID))
			return false;
		Object.guid=ID;
		// then update the object
		return Object.LoadingData(Data);
	}

	bool DeleteObject(CWoWObject &Object)
	{
		if (Object.type==0 || Object.type>=OBJ_TYPES) return false;
		return Files[Object.type].DeleteObject(Object.guid);
	}

	bool EnumObjects(unsigned long Type, fStorageEnum EnumStorage)
	{
		if (Type==0 || Type>=OBJ_TYPES) return false;
		unsigned long Total=Files[Type].TotalLinear();
		for (unsigned long i = 0 ; i < Total ; i++)
		{
			ObjectStorage Data;
			if (unsigned long ID=Files[Type].RetrieveLinear(Data,i))
			{
				if (!EnumStorage(Data,ID))
					return false;
			}
		}
		return true;
	}

	bool EnumObjectIDs(unsigned long Type, fObjectIDEnum EnumObjectIDs)
	{
		if (Type==0 || Type>=OBJ_TYPES) return false;
		unsigned long Total=Files[Type].TotalLinear();
		for (unsigned long i = 0 ; i < Total ; i++)
		{
			if (unsigned long ID=Files[Type].RetrieveLinear(i))
			{
				if (!EnumObjectIDs(ID))
					return false;
			}
		}
		return true;
	}

	unsigned long HighestID;
	//private:
	CDefStorageFile Files[OBJ_TYPES];
};

#endif // DEFSTORAGE_H
