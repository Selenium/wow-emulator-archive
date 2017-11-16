#include "StdAfx.h"
#include "Setup.h"

#define SendQuickMenu(textid) objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), textid, Plr); \
    Menu->SendTo(Plr);

class SCRIPT_DECL Blacksmith : public GossipScript
{
public:
    void GossipHello(Object * pObject, Player* Plr, bool AutoSend)
	{
		GossipMenu *Menu;
		uint32 TextID = 5411;
		objmgr.CreateGossipMenuForPlayer(&Menu, pObject->GetGUID(), TextID, Plr);
		Menu->AddItem(0, "Please repair my equipment, Krinkle.", 1);
		
	
		if(AutoSend)
			Menu->SendTo(Plr);
	}

    void GossipSelectOption(Object * pObject, Player* Plr, uint32 Id, uint32 IntId, const char * Code)
	{
		GossipMenu *Menu;
		if(Plr->GetItemInterface()->GetItemCount(29434, false) < 4)
		{
			SendQuickMenu(5412);
			return;
		}

		// Remove the items now and repair their gear
		Plr->GetItemInterface()->RemoveItemAmt(29434, 4);
		SendQuickMenu(5413);

		uint32 j, i;
	
		Item * pItem = NULL;
		Container * pContainer = NULL;
		for( i = 0; i < MAX_INVENTORY_SLOT; i++ )
		{
			pItem = Plr->GetItemInterface()->GetInventoryItem( i );
			if( pItem != NULL )
			{
				if( pItem->IsContainer() )
				{
					pContainer = static_cast<Container*>( pItem );
					for( j = 0; j < pContainer->GetProto()->ContainerSlots; ++j )
					{
						pItem = pContainer->GetItem( j );
						if( pItem != NULL )
						{
							pItem->SetDurabilityToMax();
							pItem->m_isDirty = true;
						}
					}
				}
				else
				{
					if( pItem->GetProto()->MaxDurability > 0 && i < INVENTORY_SLOT_BAG_END && pItem->GetDurability() <= 0 )
					{
						pItem->SetDurabilityToMax();
						pItem->m_isDirty = true;
						Plr->ApplyItemMods( pItem, i, true );
					}
					else
					{
						pItem->SetDurabilityToMax();
						pItem->m_isDirty = true;
					}					
				}
			}
		}
		Plr->SaveToDB(false);
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

void SetupBlacksmith(ScriptMgr * mgr)
{
	GossipScript * tl = (GossipScript*)new Blacksmith;
	mgr->register_gossip_script(5411, tl);
}



