#include "StdAfx.h"
#include "Setup.h"

#define SendQuickMenu(textid) objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), textid, Plr); \
    Menu->SendTo(Plr);

class SCRIPT_DECL Teleporter : public GossipScript
{
public:
    void GossipHello(Object * pObject, Player* Plr, bool AutoSend)
	{
		GossipMenu *Menu;
		uint32 TextID = 600;
		objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), TextID, Plr);

		if(Plr->GetTeam() == 0)
		{
			Menu->AddItem(0, "Elwynn Forest", 1);
			Menu->AddItem(0, "Dun Morogh", 2);
			Menu->AddItem(0, "Teldrassil", 3);
			Menu->AddItem(0, "Azuremyst Isle", 4);
		}

		if(Plr->GetTeam() == 1)
		{
			Menu->AddItem(0, "Durotar", 5);
			Menu->AddItem(0, "Tirisfal Glades", 6);
			Menu->AddItem(0, "Mulgore", 7);
			Menu->AddItem(0, "Eversong Woods", 8);
		}

		Menu->AddItem(0, "Gurubashi Arena", 9);
	
		if(AutoSend)
			Menu->SendTo(Plr);
	}

    void GossipSelectOption(Object * pObject, Player* Plr, uint32 Id, uint32 IntId, const char * Code)
	{
		// Cheater Checks
		if(IntId != 9 && Plr->GetTeam() == 0 && IntId >= 5)
			return;

		if(IntId != 9 && Plr->GetTeam() == 1 && IntId < 5)
			return;

		switch(IntId)
		{
		case 1: // Elwynn Forest
			{
				Plr->EventTeleport(0, -8949.950f, -132.49f, 83.53f);
				break;
			}
		case 2: // Dun Morogh
			{
				Plr->EventTeleport(0, -6113.704f, 397.93f, 395.543f);
				break;
			}
		case 3: // Teldrassil
			{
				Plr->EventTeleport(1, 10398.80f, 772.664f, 1322.707f);
				break;
			}
		case 4: // Azuremyst Isle
			{
				Plr->EventTeleport(530, -4030.82, -13788.79, 74.5f);
				break;
			}
		case 5: // Durotar
			{
				Plr->EventTeleport(1, -618.5f, -4251.66f, 38.71f);
				break;
			}
		case 6: // Tirisfal Glades
			{
				Plr->EventTeleport(0, 1822.94f, 1589.16f, 95.29f);
				break;
			}
		case 7: // Mulgore
			{
				Plr->EventTeleport(1, -2917.58f, -257.98f, 52.99f);
				break;
			}
		case 8: // Eversong Woods
			{
				Plr->EventTeleport(530, 10349.59f, -6357.29f, 33.40f);
				break;
			}
		case 9: // Gurubashi Arena
			{
				Plr->EventTeleport(0, -13226.706f, 231.263f, 33.25f);
				break;
			}
		}

		if(IntId != 9)
			Plr->RemoveFlag(PLAYER_FLAGS, PLAYER_FLAG_FREE_FOR_ALL_PVP);

		GossipEnd(pObject, Plr);
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

void SetupTeleporter(ScriptMgr * mgr)
{
	GossipScript * tl = (GossipScript*)new Teleporter;
	mgr->register_gossip_script(200008, tl);
}



