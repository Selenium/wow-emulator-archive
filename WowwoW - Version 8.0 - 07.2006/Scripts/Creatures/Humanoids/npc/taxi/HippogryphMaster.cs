using System;
using Server.Items;

namespace Server.Creatures
{
	public class Vesprystus : TaxiVendor
	{
		public Vesprystus() : base()
		{
			Name = "Vesprystus";
			Guild="Hippogryph Master";
			Id = 3838;
			Model = 1931;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new NightWatchShortsword(), new PhalanxShield() );
			NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}



namespace Server.Creatures
{
	public class ShaethisDarkoak : TaxiVendor
	{
		public ShaethisDarkoak() : base()
		{
			Name = "Shaethis Darkoak";
			Guild="Hippogryph Master";
			Id = 1233;
			Model = 14310;
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
			Faction = Factions.Alliance;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}




namespace Server.Creatures
{
	public class CaylaisMoonfeather : TaxiVendor
	{
		public CaylaisMoonfeather() : base()
		{
			Name = "Caylais Moonfeather";
			Guild="Hippogryph Master";
			Id = 3841;
			Model = 1932;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}



namespace Server.Creatures
{
	public class Daelyshia : TaxiVendor
	{
		public Daelyshia() : base()
		{
			Name = "Daelyshia";
			Guild="Hippogryph Master";
			Id = 4267;
			Model = 2313;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}




namespace Server.Creatures
{
	public class Thyssiana : TaxiVendor
	{
		public Thyssiana() : base()
		{
			Name = "Thyssiana";
			Guild="Hippogryph Master";
			Id = 4319;
			Model = 2415;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) );
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}





namespace Server.Creatures
{
	public class Teloren : TaxiVendor
	{
		public Teloren() : base()
		{
			Name = "Teloren";
			Guild="Hippogryph Master";
			Id = 4407;
			Model = 2427;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 6231, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) );
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}




namespace Server.Creatures
{
	public class BaritanasSkyriver : TaxiVendor
	{
		public BaritanasSkyriver() : base()
		{
			Name = "Baritanas Skyriver";
			Guild="Hippogryph Master";
			Id = 6706;
			Model = 2427;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}




namespace Server.Creatures
{
	public class FyldrenMoonfeather : TaxiVendor
	{
		public FyldrenMoonfeather() : base()
		{
			Name = "Fyldren Moonfeather";
			Guild="Hippogryph Master";
			Id = 8019;
			Model = 7249;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) );
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}




namespace Server.Creatures
{
	public class Sindrayl : TaxiVendor
	{
		public Sindrayl() : base()
		{
			Name = "Sindrayl";
			Guild="Hippogryph Master";
			Id = 10897;
			Model = 10196;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 24483, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}




namespace Server.Creatures
{
	public class Maethrya : TaxiVendor
	{
		public Maethrya() : base()
		{
			Name = "Maethrya";
			Guild="Hippogryph Master";
			Id = 11138;
			Model = 10657;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 19555, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}



namespace Server.Creatures
{
	public class Jarrodenus : TaxiVendor
	{
		public Jarrodenus() : base()
		{
			Name = "Jarrodenus";
			Guild="Hippogryph Master";
			Id = 12577;
			Model = 12926;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7460, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}



namespace Server.Creatures
{
	public class Mishellena : TaxiVendor
	{
		public Mishellena() : base()
		{
			Name = "Mishellena";
			Guild="Hippogryph Master";
			Id = 12578;
			Model = 12927;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 7460, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
			//NpcText00 = "The Hippogryph is a noble beast, proud and swift.  They are an honor to train, and can quickly take their rider a great distance.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 479;
		}
	}
}


