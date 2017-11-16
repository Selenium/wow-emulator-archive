using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class GordunniOgre : BaseCreature
	{
		public GordunniOgre() : base()
		{
			Name = "Gordunni Ogre";
			Id = 5229;
			Model = 597;
			Level = RandomLevel(40,41);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.4f;
			CombatReach = 2.4f;
			Size = 1.6f;
			Speed = 1.9f;
			WalkSpeed = 1.9f;
			RunSpeed = 4.9f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1783, 40 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class GordunniBrute : BaseCreature
	{
		public GordunniBrute() : base()
		{
			Name = "Gordunni Brute";
			Id = 5232;
			Model = 11554;
			Level = RandomLevel(42,43);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2800;			
			BoundingRadius = 1.6f;
			CombatReach = 2.8f;
			Size = 1.9f;
			Speed = 2.24f;
			WalkSpeed = 2.24f;
			RunSpeed = 5.24f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 3879, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			BCAddon.Hp( this, 1877, 42 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniBrute , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class GordunniMauler : BaseCreature
	{
		public GordunniMauler() : base()
		{
			Name = "Gordunni Mauler";
			Id = 5234;
			Model = 11557;
			Level = RandomLevel(43,44);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.8f;
			CombatReach = 3f;
			Size = 2.05f;
			Speed = 2.24f;
			WalkSpeed = 2.24f;
			RunSpeed = 5.24f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7436, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1658, 43 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniMauler , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class GordunniShaman : BaseCreature
	{
		public GordunniShaman() : base()
		{
			Name = "Gordunni Shaman";
			Id = 5236;
			Model = 11559;
			Level = RandomLevel(44,45);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.9f;
			CombatReach = 3.3f;
			Size = 2.2f;
			Speed = 2.25f;
			WalkSpeed = 2.25f;
			RunSpeed = 5.25f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 1552, 44 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniShaman , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class GordunniOgreMage : BaseCreature
	{
		public GordunniOgreMage() : base()
		{
			Name = "Gordunni Ogre Mage";
			Id = 5237;
			Model = 11558;
			Level = RandomLevel(41,42);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.6f;
			CombatReach = 2.4f;
			Size = 1.6f;
			Speed = 2.23f;
			WalkSpeed = 2.23f;
			RunSpeed = 5.23f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 2840, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 1099, 41 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniOgreMage , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class GordunniBattlemaster : BaseCreature
	{
		public GordunniBattlemaster() : base()
		{
			Name = "Gordunni Battlemaster";
			Id = 5238;
			Model = 11533;
			Level = RandomLevel(45,46);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 2f;
			CombatReach = 3.5f;
			Size = 2.35f;
			Speed = 2.26f;
			WalkSpeed = 2.26f;
			RunSpeed = 5.26f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0));
			BCAddon.Hp( this, 2313, 45 );
			NpcText00="Some adventurers think enchanting doesn't work. I find that when I challenge them to battle they change their tune!";
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniBattlemaster , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class GordunniMageLord : BaseCreature
	{
		public GordunniMageLord() : base()
		{
			Name = "Gordunni Mage-Lord";
			Id = 5239;
			Model = 11556;
			Level = RandomLevel(45,46);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.9f;
			CombatReach = 2.8f;
			Size = 1.9f;
			Speed = 2.26f;
			WalkSpeed = 2.26f;
			RunSpeed = 5.26f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 5098, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 1651, 45 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniMageLord , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class GordunniWarlock : BaseCreature
	{
		public GordunniWarlock() : base()
		{
			Name = "Gordunni Warlock";
			Id = 5240;
			Model = 11560;
			Level = RandomLevel(43,44);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.7f;
			CombatReach = 2.6f;
			Size = 1.75f;
			Speed = 2.24f;
			WalkSpeed = 2.24f;
			RunSpeed = 5.24f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 1386, 43 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniWarlock , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class GordunniWarlord : BaseCreature
	{
		public GordunniWarlord() : base()
		{
			Name = "Gordunni Warlord";
			Id = 5241;
			Model = 11561;
			Level = RandomLevel(41,42);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 2.3f;
			CombatReach = 3.5f;
			Size = 2.35f;
			Speed = 2.27f;
			WalkSpeed = 2.27f;
			RunSpeed = 5.27f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 3797, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0));
			BCAddon.Hp( this, 1099, 41 );
			Loots = new BaseTreasure[]{  new BaseTreasure( GordunniDrops.GordunniWarlord , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}


