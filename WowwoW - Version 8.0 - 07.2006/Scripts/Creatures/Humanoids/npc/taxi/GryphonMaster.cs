using System;
using Server.Items;

namespace Server.Creatures
{
	public class DungarLongdrink : TaxiVendor
	{
		public DungarLongdrink() : base()
		{
			Name = "Dungar Longdrink";
			Guild="Gryphon Master";
			Id = 352;
			Model = 5128;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new NightWatchShortsword(), new PhalanxShield() );
			NpcText00 = "Where is it ye would like to go $g lad : lass;? For just a few coin my Gryphons can get ye there faster than even the swiftest horse.";
			NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class ArienaStormfeather : TaxiVendor
	{
		public ArienaStormfeather() : base()
		{
			Name = "Ariena Stormfeather";
			Guild="Gryphon Master";
			Id = 931;
			Model = 3364;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new NightWatchShortsword(), new PhalanxShield() );
			//NpcText00 = "Where is it ye would like to go $g lad : lass;? For just a few coin my Gryphons can get ye there faster than even the swiftest horse.";
			//NpcText10 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}




namespace Server.Creatures
{
	public class ShelleiBrondir : TaxiVendor
	{
		public ShelleiBrondir() : base()
		{
			Name = "Shellei Brondir";
			Guild="Gryphon Master";
			Id = 1571;
			Model = 5130;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new NightWatchShortsword(), new PhalanxShield() );
			NpcText00 = "Hello, $N! If you don't see it in my shop, chances are good I can get it!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class ThorgrumBorrelson : TaxiVendor
	{
		public ThorgrumBorrelson() : base()
		{
			Name = "Thorgrum Borrelson";
			Guild="Gryphon Master";
			Id = 1572;
			Model = 5037;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new NightWatchShortsword(), new PhalanxShield() );
			NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class GrythThurden : TaxiVendor
	{
		public GrythThurden() : base()
		{
			Name = "Gryth Thurden";
			Guild="Gryphon Master";
			Id = 1573;
			Model = 3007;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new MasterworkStormhammer());
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}




namespace Server.Creatures
{
	public class BorgusStoutarm : TaxiVendor
	{
		public BorgusStoutarm() : base()
		{
			Name = "Borgus Stoutarm";
			Guild="Gryphon Master";
			Id = 2299;
			Model = 1626;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new MasterworkStormhammer());
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}




namespace Server.Creatures
{
	public class FeliciaMaline : TaxiVendor
	{
		public FeliciaMaline() : base()
		{
			Name = "Felicia Maline";
			Guild="Gryphon Master";
			Id = 2409;
			Model = 5129;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new MasterworkStormhammer());
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class DarlaHarris : TaxiVendor
	{
		public DarlaHarris() : base()
		{
			Name = "Darla Harris";
			Guild="Gryphon Master";
			Id = 2432;
			Model = 4349;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7460, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class CedrikProse : TaxiVendor
	{
		public CedrikProse() : base()
		{
			Name = "Cedrik Prose";
			Guild="Gryphon Master";
			Id = 2835;
			Model = 4044;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 21376, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class Gyll : TaxiVendor
	{
		public Gyll() : base()
		{
			Name = "Gyll";
			Guild="Gryphon Master";
			Id = 2859;
			Model = 12945;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2839, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class Baldruc : TaxiVendor
	{
		public Baldruc() : base()
		{
			Name = "Baldruc";
			Guild="Gryphon Master";
			Id = 4321;
			Model = 2417;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 6233, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}




namespace Server.Creatures
{
	public class BeraStonehammer : TaxiVendor
	{
		public BeraStonehammer() : base()
		{
			Name = "Bera Stonehammer";
			Guild="Gryphon Master";
			Id = 7823;
			Model = 6880;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 23948, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class GuthrumThunderfist : TaxiVendor
	{
		public GuthrumThunderfist() : base()
		{
			Name = "Guthrum Thunderfist";
			Guild="Gryphon Master";
			Id = 8018;
			Model = 7250;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.WildHammerClan;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}




namespace Server.Creatures
{
	public class AlexandraConstantine : TaxiVendor
	{
		public AlexandraConstantine() : base()
		{
			Name = "Alexandra Constantine";
			Guild="Gryphon Master";
			Id = 8609;
			Model = 7905;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 23948, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}



namespace Server.Creatures
{
	public class BibilfazFeatherwhistle : TaxiVendor
	{
		public BibilfazFeatherwhistle() : base()
		{
			Name = "Bibilfaz Featherwhistle";
			Guild="Gryphon Master";
			Id = 12596;
			Model = 12911;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 23948, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) );
			//NpcText00 = "Mark my words!  You won't find faster gryphons anywhere in the Eastern Kingdoms than the ones right here in Thelsamar!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}


namespace Server.Creatures
{
	public class Thor : TaxiVendor
	{
		public Thor() : base()
		{
			Name = "Thor";
			Guild="Gryphon Master";
			Id = 523;
			Model = 3263;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400046; NpcType = (int)NpcTypes.Humanoid; 
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 23948, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) );
			NpcText00 = "Where are you going?  Well if you're looking to get there quickly, then look no further!";			
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 1147;
		}
	}
}

