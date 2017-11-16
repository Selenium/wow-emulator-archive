using System;
using Server.Items;

namespace Server.Creatures
{
	public class KarosRazok : TaxiVendor
	{
		public KarosRazok() : base()
		{
			Name = "Karos Razok";
			Guild="Bat Handler";
			Id = 2226;
			Model = 3832;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Undead; 
			NpcFlags = (int)NpcActions.Taxi;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level*2.5f);
			Block = 5*Level;
			BaseHitPoints = 1780;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 4.2f;
			WalkSpeed = 4.2f;
			RunSpeed = 7.2f;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new NightWatchShortsword(), new PhalanxShield() );
			NpcText00 = "Greetings.  Our bats are well trained and fed.  You'll not find faster.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1566;
		}
	}
}


namespace Server.Creatures
{
	public class Zarise : TaxiVendor
	{
		public Zarise() : base()
		{
			Name = "Zarise";
			Guild="Bat Handler";
			Id = 2389;
			Model = 2037;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Undead; 
			NpcFlags = (int)NpcActions.Taxi;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level*2.5f);
			Block = 5*Level;
			BaseHitPoints = 1780;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 4.2f;
			WalkSpeed = 4.2f;
			RunSpeed = 7.2f;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "Where is it ye would like to go $g lad : lass;? For just a few coin my Gryphons can get ye there faster than even the swiftest horse.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1566;
		}
	}
}



namespace Server.Creatures
{
	public class MichaelGarrett : TaxiVendor
	{
		public MichaelGarrett() : base()
		{
			Name = "Michael Garrett";
			Guild="Bat Handler";
			Id = 4551;
			Model = 2638;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Undead; 
			NpcFlags = (int)NpcActions.Taxi;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level*2.5f);
			Block = 5*Level;
			BaseHitPoints = 1780;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 4.2f;
			WalkSpeed = 4.2f;
			RunSpeed = 7.2f;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			NpcText00 = "How may I be of service?";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1566;
		}
	}
}



namespace Server.Creatures
{
	public class Georgia : TaxiVendor
	{
		public Georgia() : base()
		{
			Name = "Georgia";
			Guild="Bat Handler";
			Id = 12636;
			Model = 12569;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Undead; 
			NpcFlags = (int)NpcActions.Taxi;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level*2.5f);
			Block = 5*Level;
			BaseHitPoints = 1780;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 4.2f;
			WalkSpeed = 4.2f;
			RunSpeed = 7.2f;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "How may I be of service?";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1566;
		}
	}
}
