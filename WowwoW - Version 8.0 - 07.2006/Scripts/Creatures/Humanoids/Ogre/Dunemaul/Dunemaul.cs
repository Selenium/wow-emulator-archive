using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class DunemaulOgre : BaseCreature
	{
		public DunemaulOgre() : base()
		{
			Name = "Dunemaul Ogre";
			Id = 5471;
			Model = 11545;
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
			BoundingRadius = 1.8f;
			CombatReach = 3.0f;
			Size = 2.05f;
			Speed = 2.26f;
			WalkSpeed = 2.26f;
			RunSpeed = 5.26f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7490, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			BCAddon.Hp( this, 2355, 45 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DunemaulDrops.DunemaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DunemaulEnforcer : BaseCreature
	{
		public DunemaulEnforcer() : base()
		{
			Name = "Dunemaul Enforcer";
			Id = 5472;
			Model = 11545;
			Level = RandomLevel(46,47);
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
			Speed = 2.27f;
			WalkSpeed = 2.27f;
			RunSpeed = 5.27f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			BCAddon.Hp( this, 2223, 46 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DunemaulDrops.DunemaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DunemaulOgreMage : BaseCreature
	{
		public DunemaulOgreMage() : base()
		{
			Name = "Dunemaul Ogre Mage";
			Id = 5473;
			Model = 12003;
			Level = RandomLevel(46,47);
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
			BoundingRadius = 2.6f;
			CombatReach = 3.9f;
			Size = 2.65f;
			Speed = 2.27f;
			WalkSpeed = 2.27f;
			RunSpeed = 5.27f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcText00="The Hippogriff is a noble beast, proud and swift.  They are on honor to train, and can quickly take their rider a great distance.";
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 2223, 46 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DunemaulDrops.DunemaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DunemaulBrute : BaseCreature
	{
		public DunemaulBrute() : base()
		{
			Name = "Dunemaul Brute";
			Id = 5474;
			Model = 11545;
			Level = RandomLevel(47,48);
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
			AttackSpeed = 2600;			
			BoundingRadius = 1.8f;
			CombatReach = 3.0f;
			Size = 2.05f;
			Speed = 2.26f;
			WalkSpeed = 2.26f;
			RunSpeed = 5.26f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7432, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 2144, 47 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DunemaulDrops.DunemaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DunemaulWarlock : BaseCreature
	{
		public DunemaulWarlock() : base()
		{
			Name = "Dunemaul Warlock";
			Id = 5475;
			Model = 11542;
			Level = RandomLevel(47,48);
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
			CombatReach = 3.0f;
			Size = 2.2f;
			Speed = 2.27f;
			WalkSpeed = 2.27f;
			RunSpeed = 5.27f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 1950, 47 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DunemaulDrops.DunemaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}


