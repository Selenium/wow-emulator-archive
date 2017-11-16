using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class GrelinWhitebeard : BaseCreature
	{
		public GrelinWhitebeard() : base()
		{
			Name = "Grelin Whitebeard";
			Id = 786;
			Model = 1354;
			Level = RandomLevel(5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Armor = 150;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08080066;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcText00= "Greetings, $g sir : ma'am. I'm Grelin Whitebeard. I'm here to examine the threat posed by the growing numbers of trolls in Coldridge Valley. What have I found? It's a bit troubling...";
			NpcFlags = (int)NpcActions.Dialog; 
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 60, 5 );
			/*****************************/
		}
	}
}

