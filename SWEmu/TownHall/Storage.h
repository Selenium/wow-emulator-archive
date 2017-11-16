#include "WoWObject.h"

class CStorageSolution
{
public:
	virtual bool Initialize()=0;
	virtual bool StoreObject(CWoWObject &Object)=0;
	virtual bool RetrieveObject(CWoWObject &Object, guid_t ID)=0;
	virtual bool DeleteObject(CWoWObject &Object)=0;
	virtual bool EnumObjects(unsigned long Type, fStorageEnum)=0;
	virtual bool EnumObjectIDs(unsigned long Type, fObjectIDEnum)=0;
	virtual void SetObjectSize(unsigned long Type, unsigned long Size)=0;
};
