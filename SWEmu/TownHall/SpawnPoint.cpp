#include "SpawnPoint.h"
#include "Globals.h"
#include "Creature.h"
#include "CreatureTemplate.h"

CSpawnPoint::CSpawnPoint(void):CWoWObject(OBJ_SPAWNPOINT)
{
}

CSpawnPoint::~CSpawnPoint(void)
{
	Delete();
}

void CSpawnPoint::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(SpawnPointData));
}

void CSpawnPoint::Delete()
{
	// dont bother detaching the creature
	CWoWObject::Delete();
}

bool CSpawnPoint::StoringData(ObjectStorage &Storage)
{
	return false; // do not store yet
	if (!guid)
		return false;
	Storage.Allocate(sizeof(SpawnPointData));
	memcpy(Storage.Data,&Data,sizeof(SpawnPointData));
	return true;
}

bool CSpawnPoint::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(SpawnPointData));
	return true;
}

void CSpawnPoint::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_SPAWNPOINT_SPAWN:
		Spawn();
		break;
	case EVENT_SPAWNPOINT_DESPAWN:
		Despawn();
		break;
	}
}

void CSpawnPoint::Spawn()
{
	struct PotentialSpawn
	{
		CCreatureTemplate *pTemplate;
		unsigned long Rate;
		unsigned long MaxLifetime;
	} Candidates[10];
	memset(&Candidates,0,sizeof(Candidates));
	unsigned long i;
	unsigned long nTotal=0;
	unsigned long nCandidates=0;
	unsigned long TotalRate=0;
	time_t now=time(0);
	for (i = 0 ; i < 10 ; i++)
	{
		// determine which creatures we're counting
		if (Data.Creatures[i]) // no template guid means no candidate!
		{
			CCreatureTemplate *pTemplate=NULL;
			if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,Data.Creatures[i]))
			{
				nTotal++;
				// template indeed, make sure we're ALLOWED to spawn this right now
				if (difftime(now,pTemplate->Data.LastSpawn)>=pTemplate->Data.MinRespawnTime)
				{
					// ok. NOW lets add the candidate.
					Candidates[nCandidates].pTemplate=pTemplate;
					Candidates[nCandidates].Rate=Data.CreatureRates[i];
					Candidates[nCandidates].MaxLifetime=Data.CreatureLifetimes[i];
					TotalRate+=Data.CreatureRates[i];
					nCandidates++; // OHNOS I DIDNT USE PREFIX
				}
			}
		}
	}
	if (!nTotal)
	{
		Delete();
		return;
	}
	if (!nCandidates)
	{
		// no spawn candidates, try again next time
		EventManager.AddEvent(*this,Data.Periodicity,EVENT_SPAWNPOINT_SPAWN,0,0);
		return;
	}
	unsigned long R=Random(0,TotalRate);
	for (i = 0 ; i < nCandidates ; i++)
	{
		if (R<Candidates[i].Rate)
		{
			// set up spawn using this candidate!
			CCreature *pSpawn = new CCreature;
			CCreatureTemplate *pTemplate=Candidates[i].pTemplate;
			pSpawn->New(*pTemplate);
			pSpawn->Data.Continent=Data.OriginContinent;
			pSpawn->Data.Loc=Data.Origin;
			pSpawn->Data.Facing=Data.OriginFacing;
			Data.Creature=pSpawn->guid;
			Data.SpawnTime=now;
			// do we need to despawn?
			if (pTemplate->Data.MaxLifetime)
			{
				// yes, add despawn event
				EventManager.AddEvent(*this,pTemplate->Data.MaxLifetime*1000,EVENT_SPAWNPOINT_DESPAWN,0,0);
			}
			// add creature to data manager
			DataManager.NewObject(*pSpawn);
			// add creature to its region
			RegionManager.ObjectNew(*pSpawn,pSpawn->Data.Continent,pSpawn->Data.Loc.X,pSpawn->Data.Loc.Y);
			return;
		}
		R-=Candidates[i].Rate; // the rates are relative
	}
}

void CSpawnPoint::Despawn()
{
	CCreature *pSpawn=NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pSpawn,OBJ_CREATURE,Data.Creature))
	{
		delete pSpawn; // seeya!
	}
}
