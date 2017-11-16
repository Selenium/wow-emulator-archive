using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class ShadowPriestSarvis : BaseNPC
	{
		public ShadowPriestSarvis() : base()
		{
			Name = "Shadow Priest Sarvis";
			Id = 1569;
			Model = 1584;
			Level = RandomLevel(5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08000066;
			BaseMana = 0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 1f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this );
			NpcType = 6;
			NpcText00="No other race on Azeroth has suffered as much as our people, $c. To laugh in the face of death has become second nature for all of us.";
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 21341, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			BCAddon.Hp( this, 150, 5 );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD , 100f )};
		}
	}
}

