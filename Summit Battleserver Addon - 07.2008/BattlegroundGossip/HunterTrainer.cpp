#include "StdAfx.h"
#include "Setup.h"

#define SendQuickMenu(textid) objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), textid, Plr); \
    Menu->SendTo(Plr);

void SpawnPet(Player * pPlayer, uint32 petId)
{
	if(pPlayer->getClass() == HUNTER)
	{
		uint32 Entry = petId;
		CreatureProto * pTemplate = CreatureProtoStorage.LookupEntry(Entry);
		CreatureInfo * pCreatureInfo = CreatureNameStorage.LookupEntry(Entry);
		Creature * pCreature = new Creature(0xF1300000);
		CreatureSpawn * sp = new CreatureSpawn;
		sp->id = 1;
		sp->bytes = 0;
		sp->bytes2 = 0;
		sp->displayid = pCreatureInfo->Male_DisplayID;
		sp->emote_state = 0;
		sp->entry = pCreatureInfo->Id;
		sp->factionid = 35;
		sp->flags = 0;
		sp->form = 0;
		sp->movetype = 0;
		sp->o = pPlayer->GetOrientation();
		sp->x = pPlayer->GetPositionX();
		sp->y = pPlayer->GetPositionY();
		sp->channel_spell=sp->channel_target_creature=sp->channel_target_go=0;
		pCreature->Load(sp, (uint32)NULL, NULL);
		Pet *old_pet = pPlayer->GetSummon();
		if(old_pet != NULL)
			old_pet->Dismiss(true);

		Pet * pPet = objmgr.CreatePet();
		pPet->SetInstanceID(pPlayer->GetInstanceID());
		pPet->SetMapId(pPlayer->GetMapId());
		pPet->SetFloatValue(OBJECT_FIELD_SCALE_X, pTemplate->Scale / 2);
		pPet->CreateAsSummon(Entry, pCreatureInfo, pCreature, pPlayer, NULL, 0x2, 0);
		pPet->Rename("Pet");
		pPet->SendSpellsToOwner();
	}
}

class SCRIPT_DECL HunterTrainer : public GossipScript
{
public:
     void GossipHello(Object * pObject, Player* Plr, bool AutoSend)
	{
		GossipMenu *Menu;
		uint32 TextID = 2;
		objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), TextID, Plr);
		Menu->AddItem(0, "I would like a pet, Rexxar.", 1);
	
		if(AutoSend)
			Menu->SendTo(Plr);
	}

     void GossipSelectOption(Object * pObject, Player* Plr, uint32 Id, uint32 IntId, const char * Code)
	{
		GossipMenu *Menu;
		if(Plr->getClass() != HUNTER)
		{
			SendQuickMenu(200016);
			return;
		}

		static uint32 pets[] = { 16174, 24530, 21723, 24047, 18155, 17724, 23219 };
		// size: 7

		switch(IntId)
		{
			case 0:
				GossipHello(pObject, Plr, true);
				return;
				break;
			
			case 1:
				objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), 200018, Plr);
				Menu->AddItem(0, "I would like a Greater Shadowbat.", 10);
				Menu->AddItem(0, "I would like an Amani Elder Lynx.", 11);
				Menu->AddItem(0, "I would like a Blackwind Sabercat.", 12);
				Menu->AddItem(0, "I would like an Amani Crocolisk.", 13);
				Menu->AddItem(0, "I would like a Bloodfalcon.", 14);
				Menu->AddItem(0, "I would like an Underbat.", 15);
				Menu->AddItem(0, "I would like a Blackwind Warp Chaser.", 16);
				Menu->SendTo(Plr);
				return;
				break;
		}

		uint32 id = IntId - 10;
		if(id > 6) return;

		SpawnPet(Plr, pets[id]);
		SendQuickMenu(200017);
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

void SetupHunterTrainer(ScriptMgr * mgr)
{
	GossipScript * ht = (GossipScript*)new HunterTrainer;
	mgr->register_gossip_script(200016, ht);
}

