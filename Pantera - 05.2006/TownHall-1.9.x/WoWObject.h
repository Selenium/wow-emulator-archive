#ifndef WOWOBJECT_H
#define WOWOBJECT_H
#include <stdlib.h>

#ifdef WIN32
#pragma warning(push)
#pragma warning(disable:100)
#endif

class ObjectStorage
{
public:
	ObjectStorage()
	{
		Size=0;
		Data=0;
	}
	~ObjectStorage()
	{
		if (Data)
			free(Data);
	}

	inline void Allocate(unsigned long NewSize)
	{
		Data=malloc(Size=NewSize);
	}

	inline void Free()
	{
		if (Data)
		{
			free(Data);
			Data=0;
			Size=0;
		}
	}

	unsigned long Size;
	void *Data;
};

class CWoWObject
{
public:
	CWoWObject(unsigned long xType);
	~CWoWObject(void);

	// base CWoWObject will not be loaded or stored, derive and replace.
	// hint: if you use a data structure inside your class rather than lots of
	// members, and have no pointers, the struct can be memcpy'd to the data buffer
	virtual bool StoringData(ObjectStorage &Storage) {return false;};
	virtual bool LoadingData(ObjectStorage &Storage) {return false;};
	virtual unsigned long DataStorageSize() {return 0;};

	virtual void New();
	virtual void Clear();
	virtual void Delete();

	virtual void ObjectNears(CWoWObject &Object) {};
	virtual void ObjectUpdates(CWoWObject &Object) {};
	virtual void ObjectFades(CWoWObject &Object) {};

	unsigned long guid;
	unsigned long type;

	virtual void ClearEvents();
	virtual void ClearEvents(unsigned long EventType);

	virtual void AddEvent(struct WoWEvent &Event);
	virtual void RemoveEvent(WoWEvent *const RemovedEvent, bool FromProcessReadyEvents=false);
	virtual void ProcessEvent(struct WoWEvent &Event) {};

	unsigned long SpellUnknown;
	CWoWObject *pCaster;
	virtual void RemoveSpell(unsigned long SpellID)
	{
		RemoveSpellEffect(SpellID,1);
		RemoveSpellEffect(SpellID,2);
		RemoveSpellEffect(SpellID,3);
	}

	virtual void ApplySpell(CWoWObject &Caster, unsigned long SpellID, unsigned long Unknown)
	{
		if (EventsEligible)
		{
			pCaster=&Caster;
			SpellUnknown=Unknown;
			ApplySpellEffect(SpellID,1);
			ApplySpellEffect(SpellID,2);
			ApplySpellEffect(SpellID,3);
		}
		// TODO: add spell removal event for duration spells?
	}
	virtual void ApplySpellEffect(unsigned long SpellID, unsigned long Effect) {};
	virtual void RemoveSpellEffect(unsigned long SpellID, unsigned long Effect) {};
	struct WoWEventNode *pEvents;
	bool EventsEligible;
	bool dead;
	bool armor_buff;
	bool bIsInCombat;
	CWoWObject *pTarget;
};

#ifdef WIN32
#pragma warning(pop)
#endif

#endif // WOWOBJECT_H
