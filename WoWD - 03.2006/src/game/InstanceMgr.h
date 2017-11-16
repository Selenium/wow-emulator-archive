
//instance manager

#ifndef WOWD_INSTANCEMGR_H
#define WOWD_INSTANCEMGR_H


#include "Database/DatabaseEnv.h"

class Object;
class WoWInstance
{
public:
	WoWInstance();
	~WoWInstance();
	typedef HM_NAMESPACE::hash_map<uint64, Object*> ObjectMap;

	void Update(uint8 pTime);
	void AddObject(Object *obj);
    void RemoveObject(Object *obj);
    void ChangeObjectLocation(Object *obj); // update inrange lists

	private:
	uint32 m_InstanceID;
	uint8 m_InstanceType;
	uint32 m_IntanceTimer;
	ObjectMap _objects;
};


class InstanceManager
{
public:
	typedef HM_NAMESPACE::hash_map<uint64, WoWInstance*> InstanceMap;

	uint8 GenerateInstanceID();
	void LoadInstance();
	void UnloadInstance();

private:
	InstanceMap     mInstanceList;

};

#endif

