#include "StdAfx.h"
#include "Setup.h"

#define SendQuickMenu(textid) objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), textid, Plr); \
    Menu->SendTo(Plr);

#define EPILORN_BASE_TEXT 1200
#define EPILORN_WELCOME_TEXT EPILORN_BASE_TEXT + 1
#define EPILORN_PROGRESS_TEXT EPILORN_WELCOME_TEXT + 1
#define EPILORN_PERSONALPROGRESS_TEXT EPILORN_PROGRESS_TEXT + 1
#define EPILORN_READY_TEXT EPILORN_PERSONALPROGRESS_TEXT + 1

#define STAGE_SERVERWIDE 1
#define STAGE_PERSONAL 2
#define STAGE_READY 3

#define QUESTPROGRESS_EPILORN 2

#define WORLDSTATE_SERVERWIDE 9999
#define WORLDSTATE_PERSONAL 9998

class SCRIPT_DECL Epilorn : public GossipScript
{
public:
	Epilorn() : GossipScript()
	{
		m_serverStageBadges = 0;

		QueryResult * result = CharacterDatabase.Query("SELECT * from playerquestprogress");
		if(result)
		{
			do 
			{
				uint32 guid = result->Fetch()[0].GetUInt32();
				uint32 val = result->Fetch()[1].GetUInt32();

				PlayerProgress.insert( make_pair(guid, val) );
			} while(result->NextRow());

			delete result;
		}

		QueryResult * result2 = CharacterDatabase.Query("SELECT progress from questprogress WHERE id = 3");
		if(result2)
		{
			do 
			{
				m_serverStageBadges = result2->Fetch()[0].GetUInt32();
			} while(result2->NextRow());

			delete result2;
		}
	}

    void GossipHello(Object * pObject, Player* Plr, bool AutoSend)
	{
		GossipMenu *Menu;

		if(GetStage(Plr) == STAGE_SERVERWIDE)
		{
			uint32 TextID = EPILORN_BASE_TEXT;
			objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), TextID, Plr);
			Menu->AddItem(0, "I would like to donate Badges of Justice.", 1);
			Menu->AddItem(0, "How many more Badges do you require?", 2);
		}
		if(GetStage(Plr) == STAGE_PERSONAL)
		{
			uint32 TextID = EPILORN_WELCOME_TEXT;
			objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), TextID, Plr);
			Menu->AddItem(0, "I would like to donate Badges of Justice", 1);
			Menu->AddItem(0, "How many more Badges do you require?", 3);
		}
		if(GetStage(Plr) == STAGE_READY)
		{
			uint32 TextID = EPILORN_READY_TEXT;
			objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), TextID, Plr);
			Menu->AddItem(1, "I would like to browse your goods.", 4);
		}
	
		if(AutoSend)
			Menu->SendTo(Plr);
	}

    void GossipSelectOption(Object * pObject, Player* Plr, uint32 Id, uint32 IntId, const char * Code)
	{
		// WPE Checks :(
		if(IntId == 4 && GetStage(Plr) != STAGE_READY)
			return;

		GossipMenu *Menu;

		if(IntId == 1)
		{
			objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), 1304, Plr);
			Menu->AddItem(0, "Yes, I would.", 5);
			Menu->SendTo(Plr);
			return;
		}

		if(IntId == 5)
		{
			if(Plr->GetItemInterface()->GetItemCount(29434, false) < 20)
			{
				objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), 1306, Plr);
				Menu->SendTo(Plr);
				return;
			}
			Plr->GetItemInterface()->RemoveItemAmt(29434, 20);
			objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), 1305, Plr);
			Menu->SendTo(Plr);

			if(GetStage(Plr) == STAGE_SERVERWIDE)
			{
				m_serverStageBadges += 20;
				CharacterDatabase.Execute("UPDATE questprogress SET progress = progress + 20 WHERE id = 3");
			}

			if(GetPlayerProgress(Plr) == 0)
				PlayerProgress.insert( make_pair( Plr->GetLowGUID(), 20 ) );
			else
				PlayerProgress[Plr->GetLowGUID()] += 20;

			// But there is now ;)
			CharacterDatabase.Execute("REPLACE INTO playerquestprogress VALUES ('%u', %u)", Plr->GetLowGUID(), PlayerProgress[Plr->GetLowGUID()]);
			
			return;
		}

		if(IntId == 2)
		{
			Plr->SendWorldStateUpdate(WORLDSTATE_SERVERWIDE, GetPercentServerStage());
			objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), EPILORN_PROGRESS_TEXT, Plr);
			Menu->SendTo(Plr);
			return;
		}

		if(IntId == 3)
		{
			if(GetStage(Plr) == STAGE_SERVERWIDE)
			{
				Plr->SendWorldStateUpdate(WORLDSTATE_SERVERWIDE, GetPercentServerStage());
				objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), EPILORN_PROGRESS_TEXT, Plr);
				Menu->SendTo(Plr);
			}
			else
			{
				Plr->SendWorldStateUpdate(WORLDSTATE_PERSONAL, GetPlayerProgress(Plr));
				objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), EPILORN_PERSONALPROGRESS_TEXT, Plr);
				Menu->SendTo(Plr);
			}
			return;
		}

		if(IntId == 4)
		{
			Plr->GetSession()->SendInventoryList((Creature*)pObject);
			return;
		}
	}

	void GossipEnd(Object * pObject, Player* Plr)
	{
		GossipScript::GossipEnd(pObject, Plr);
	}

    void Destroy()
    {
		delete this;
    }

protected:
	uint32 m_serverStageBadges;
	std::map<uint32,uint32> PlayerProgress;
	uint32 GetPlayerProgress(Player * pPlayer)
	{
		if(PlayerProgress.find(pPlayer->GetLowGUID()) == PlayerProgress.end())
			return 0;
		
		return 500 - PlayerProgress[pPlayer->GetLowGUID()];
	}

	uint32 GetPercentServerStage()
	{
		return (uint32)float2int32(((float)m_serverStageBadges / 1500.0f) * 100.0f);
	}

	uint32 GetStage(Player * pTarget)
	{
		if(m_serverStageBadges < 1500)
			return STAGE_SERVERWIDE;

		if(GetPlayerProgress(pTarget) < 100)
			return STAGE_PERSONAL;

		return STAGE_READY;
	}
};

void SetupEpilorn(ScriptMgr * mgr)
{
	GossipScript * el = (GossipScript*)new Epilorn;
	mgr->register_gossip_script(1200, el);
}



