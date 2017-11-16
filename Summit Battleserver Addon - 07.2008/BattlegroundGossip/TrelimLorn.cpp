#include "StdAfx.h"
#include "Setup.h"

#define SendQuickMenu(textid) objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), textid, Plr); \
    Menu->SendTo(Plr);

class SCRIPT_DECL TrelimLorn : public GossipScript
{
public:
    void GossipHello(Object * pObject, Player* Plr, bool AutoSend)
	{
		GossipMenu *Menu;
		uint32 TextID = 40;
		objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), TextID, Plr);
		Menu->AddItem(0, "What is the purpose of this realm?", 1);
		Menu->AddItem(0, "How do I earn more Badges of Honor?", 2);
		Menu->AddItem(0, "How can I fight the enemy?", 3);
		Menu->AddItem(0, "Where can I get weapons?", 5);
		Menu->AddItem(0, "I'd like to fix a stuck character.", 4);
		Menu->AddItem(0, "Getting Started.", 6);
	
		if(AutoSend)
			Menu->SendTo(Plr);
	}

    void GossipSelectOption(Object * pObject, Player* Plr, uint32 Id, uint32 IntId, const char * Code)
	{
		GossipMenu *Menu;
		switch(IntId)
		{
			case 1:
				SendQuickMenu(41);
				break;
			case 2:
				SendQuickMenu(42);
				break;
			case 3:
				SendQuickMenu(43);
				break;
			case 5:
				SendQuickMenu(49);
				break;
			case 6:
				SendQuickMenu(50);
				break;
		}
		
		if(IntId < 4 || IntId == 6) return;
		
		if(IntId == 4)
		{
			objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), 47, Plr);
			Menu->AddItem(0, "His name was...", 5, 1);
			Menu->SendTo(Plr);
			return;
		}
		
		PlayerInfo * cInfo = Plr->m_playerInfo;
		PlayerInfo * tInfo = objmgr.GetPlayerInfoByName( Code );
		if(!tInfo || !cInfo)
		{
			SendQuickMenu(44);
			return;
		}
		
		if(cInfo->acct != tInfo->acct)
		{
			SendQuickMenu(45);
			return;
		}
		
		if(cInfo == tInfo)
		{
			SendQuickMenu(48);
			return;
		}
		
		// Ok, let's do it!
		CharacterDatabase.Execute("UPDATE characters SET mapId = %u, zoneId = %u, positionX = %f, positionY = %f, positionZ = %f WHERE guid = %u", Plr->GetMapId(), Plr->GetZoneId(), Plr->GetPositionX(), Plr->GetPositionY(), Plr->GetPositionZ(), tInfo->guid);
		static_cast<Creature*>(pObject)->CastSpell((Creature*)pObject, 39390, true);
		SendQuickMenu(46);
	}

	void GossipEnd(Object * pObject, Player* Plr)
	{
		GossipScript::GossipEnd(pObject, Plr);
	}

    void Destroy()
    {
		delete this;
    }
};

void SetupHelper(ScriptMgr * mgr)
{
	GossipScript * tl = (GossipScript*)new TrelimLorn;
	mgr->register_gossip_script(301, tl);
}



