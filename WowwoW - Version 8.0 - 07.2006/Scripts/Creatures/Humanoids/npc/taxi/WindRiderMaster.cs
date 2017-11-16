using System;
using Server.Items;

namespace Server.Creatures
{
	public class Thysta : TaxiVendor
	{
		public Thysta() : base()
		{
			Name = "Thysta";
			Guild="Wind Rider Master";
			Id = 1387;
			Model = 1868;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new NightWatchShortsword(), new PhalanxShield() );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Urda : TaxiVendor
	{
		public Urda() : base()
		{
			Name = "Urda";
			Guild="Wind Rider Master";
			Id = 2851;
			Model = 3972;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Gringer : TaxiVendor
	{
		public Gringer() : base()
		{
			Name = "Gringer";
			Guild="Wind Rider Master";
			Id = 2858;
			Model = 3972;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Gorrik : TaxiVendor
	{
		public Gorrik() : base()
		{
			Name = "Gorrik";
			Guild="Wind Rider Master";
			Id = 2861;
			Model = 3972;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Tal : TaxiVendor
	{
		public Tal() : base()
		{
			Name = "Tal";
			Guild="Wind Rider Master";
			Id = 2995;
			Model = 2098;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.35f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Doras : TaxiVendor
	{
		public Doras() : base()
		{
			Name = "Doras";
			Guild="Wind Rider Master";
			Id = 3310;
			Model = 1311;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}




namespace Server.Creatures
{
	public class Devrak : TaxiVendor
	{
		public Devrak() : base()
		{
			Name = "Devrak";
			Guild="Wind Rider Master";
			Id = 3615;
			Model = 1652;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Tharm : TaxiVendor
	{
		public Tharm() : base()
		{
			Name = "Tharm";
			Guild="Wind Rider Master";
			Id = 4312;
			Model = 2411;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.35f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Nyse : TaxiVendor
	{
		public Nyse() : base()
		{
			Name = "Nyse";
			Guild="Wind Rider Master";
			Id = 4317;
			Model = 2412;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.25f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Breyk : TaxiVendor
	{
		public Breyk() : base()
		{
			Name = "Breyk";
			Guild="Wind Rider Master";
			Id = 6026;
			Model = 2412;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Thalon : TaxiVendor
	{
		public Thalon() : base()
		{
			Name = "Thalon";
			Guild="Wind Rider Master";
			Id = 6726;
			Model = 2412;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.35f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class BulkrekRagefist : TaxiVendor
	{
		public BulkrekRagefist() : base()
		{
			Name = "Bulkrek Ragefist";
			Guild="Wind Rider Master";
			Id = 7824;
			Model = 6883;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}




namespace Server.Creatures
{
	public class Shyn : TaxiVendor
	{
		public Shyn() : base()
		{
			Name = "Shyn";
			Guild="Wind Rider Master";
			Id = 8020;
			Model = 7248;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.25f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Kroum : TaxiVendor
	{
		public Kroum() : base()
		{
			Name = "Kroum";
			Guild="Wind Rider Master";
			Id = 8610;
			Model = 7904;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}




namespace Server.Creatures
{
	public class Yugrek : TaxiVendor
	{
		public Yugrek() : base()
		{
			Name = "Yugrek";
			Guild="Wind Rider Master";
			Id = 11139;
			Model = 10658;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Shardi : TaxiVendor
	{
		public Shardi() : base()
		{
			Name = "Shardi";
			Guild="Wind Rider Master";
			Id = 11899;
			Model = 11850;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}





namespace Server.Creatures
{
	public class Brakkar : TaxiVendor
	{
		public Brakkar() : base()
		{
			Name = "Brakkar";
			Guild="Wind Rider Master";
			Id = 11900;
			Model = 11849;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}



namespace Server.Creatures
{
	public class Andruk : TaxiVendor
	{
		public Andruk() : base()
		{
			Name = "Andruk";
			Guild="Wind Rider Master";
			Id = 11901;
			Model = 11851;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			//Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}




namespace Server.Creatures
{
	public class Vhulgra : TaxiVendor
	{
		public Vhulgra() : base()
		{
			Name = "Vhulgra";
			Guild="Wind Rider Master";
			Id = 12616;
			Model = 12974;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}




namespace Server.Creatures
{
	public class Faustron : TaxiVendor
	{
		public Faustron() : base()
		{
			Name = "Faustron";
			Guild="Wind Rider Master";
			Id = 12740;
			Model = 12629;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) );
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}




namespace Server.Creatures
{
	public class Vahgruk : TaxiVendor
	{
		public Vahgruk() : base()
		{
			Name = "Vahgruk";
			Guild="Wind Rider Master";
			Id = 13177;
			Model = 1652;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}




namespace Server.Creatures
{
	public class Sulhasa : TaxiVendor
	{
		public Sulhasa() : base()
		{
			Name = "Sulhasa";
			Guild="Wind Rider Master";
			Id = 14242;
			Model = 14306;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			//NpcText00 = "To maintain our link to the mainland, we have hippogryphs constantly flying between Rut'theran Village and Darkshore.";
			//NpcText01 = "These great beasts know paths that ye can't find on foot, they'll get ye there fast and maybe show ye something new at the same time.";
			Size = 1.0f;
			Elite = 1;
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f)};
			MountId = 295;
		}
	}
}


