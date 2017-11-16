using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class SplinterFistWarrior : BaseCreature
	{
		public SplinterFistWarrior() : base()
		{
			Name = "Splinter Fist Warrior";
			Id = 212;
			Model = 610;
			Level = RandomLevel(29,30);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = Level;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 1.7f;
			Size = 1.3f;
			Speed = 2.16f;
			WalkSpeed = 2.16f;
			RunSpeed = 5.16f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			BCAddon.Hp( this, 930, 29 );
			Loots = new BaseTreasure[]{  new BaseTreasure( SplinterDrops.SplinterFistWarrior , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class SplinterFistOgre : BaseCreature
	{
		public SplinterFistOgre() : base()
		{
			Name = "Splinter Fist Ogre";
			Id = 889;
			Model = 415;
			Level = RandomLevel(25,26);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = Level;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 1.7f;
			Size = 1.3f;
			Speed = 2.43f;
			WalkSpeed = 2.43f;
			RunSpeed = 5.43f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 731, 25 );
			Loots = new BaseTreasure[]{  new BaseTreasure( SplinterDrops.SplinterFistOgre , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class SplinterFistFireWeaver : BaseCreature
	{
		public SplinterFistFireWeaver() : base()
		{
			Name = "Splinter Fist Fire Weaver";
			Id = 891;
			Model = 326;
			Level = RandomLevel(26,27);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = Level;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 2.12f;
			WalkSpeed = 2.12f;
			RunSpeed = 5.12f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			BCAddon.Hp( this, 716, 26 );
			Loots = new BaseTreasure[]{  new BaseTreasure( SplinterDrops.SplinterFistFireWeaver , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class SplinterFistTaskmaster : BaseCreature
	{
		public SplinterFistTaskmaster() : base()
		{
			Name = "Splinter Fist Taskmaster";
			Id = 892;
			Model = 11567;
			Level = RandomLevel(27,28);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = Level;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 1.7f;
			Size = 1.15f;
			Speed = 2.12f;
			WalkSpeed = 2.12f;
			RunSpeed = 5.12f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7441, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 820, 27 );
			Loots = new BaseTreasure[]{  new BaseTreasure( SplinterDrops.SplinterFistTaskmaster , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class SplinterFistFiremonger : BaseCreature
	{
		public SplinterFistFiremonger() : base()
		{
			Name = "Splinter Fist Firemonger";
			Id = 1251;
			Model = 3190;
			Level = RandomLevel(28,29);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = Level;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.15f;
			CombatReach = 1.7f;
			Size = 1.15f;
			Speed = 2.12f;
			WalkSpeed = 2.12f;
			RunSpeed = 5.12f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			BCAddon.Hp( this, 1580, 28 );
			Loots = new BaseTreasure[]{  new BaseTreasure( SplinterDrops.SplinterFistFiremonger , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class SplinterFistEnslaver : BaseCreature
	{
		public SplinterFistEnslaver() : base()
		{
			Name = "Splinter Fist Enslaver";
			Id = 1487;
			Model = 6170;
			Level = RandomLevel(30,31);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = Level;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.3f;
			CombatReach = 1.9f;
			Size = 1.3f;
			Speed = 2.14f;
			WalkSpeed = 2.14f;
			RunSpeed = 5.14f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0),new Item ( 16751, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			BCAddon.Hp( this, 1015, 30 );
			Loots = new BaseTreasure[]{  new BaseTreasure( SplinterDrops.SplinterFistEnslaver , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}


