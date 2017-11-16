using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class CrierGoodman : BaseCreature
	{
		public CrierGoodman() : base()
		{
			Name = "Crier Goodman";
			Id = 2198;
			Model = 1525;
			Level = RandomLevel(3);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 1*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480000;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new TravellerSalesmanAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Equip( new Item( 5010, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )};
		}
	}
}

namespace Server.Creatures
{
	public class AedisBrom : BaseCreature
	{
		public AedisBrom() : base()
		{
			Name = "Aedis Brom";
			Id = 1478;
			Model = 1519;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480004;
			BaseHitPoints = 499;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new TravellerSalesmanAI( this );
			NpcType = 7;
			//NpcText00="Not all Forsaken are driven by Sylvanas' will, $N. Some of us are driven by true power--power we earn for ourselves.";
			NpcFlags = 0;
			Equip( new Item( 24595, InventoryTypes.TwoHanded, 2, 14, 1, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindDrops.AedisBrom, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}