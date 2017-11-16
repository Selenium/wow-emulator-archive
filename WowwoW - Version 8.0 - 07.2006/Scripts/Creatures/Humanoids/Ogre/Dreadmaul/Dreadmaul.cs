using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class DreadmaulOgre : BaseCreature
	{
		public DreadmaulOgre() : base()
		{
			Name = "Dreadmaul Ogre";
			Id = 5974;
			Model = 14402;
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
			CombatReach = 3.3f;
			Size = 2.2f;
			Speed = 2.26f;
			WalkSpeed = 2.26f;
			RunSpeed = 5.26f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 2424, 45 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DreadmaulDrops.DreadmaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}





namespace Server.Creatures
{
	public class DreadmaulOgreMage : BaseCreature
	{
		public DreadmaulOgreMage() : base()
		{
			Name = "Dreadmaul Ogre Mage";
			Id = 5975;
			Model = 11542;
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
			BoundingRadius = 2.2f;
			CombatReach = 3.3f;
			Size = 2.2f;
			Speed = 2.27f;
			WalkSpeed = 2.27f;
			RunSpeed = 5.27f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			//Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 2117, 46 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DreadmaulDrops.DreadmaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DreadmaulBrute : BaseCreature
	{
		public DreadmaulBrute() : base()
		{
			Name = "Dreadmaul Brute";
			Id = 5976;
			Model = 11584;
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
			AttackSpeed = 2600;			
			BoundingRadius = 2.0f;
			CombatReach = 3.5f;
			Size = 2.35f;
			Speed = 2.27f;
			WalkSpeed = 2.27f;
			RunSpeed = 5.27f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			//Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 2117, 46 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DreadmaulDrops.DreadmaulOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DreadmaulMauler : BaseCreature
	{
		public DreadmaulMauler() : base()
		{
			Name = "Dreadmaul Mauler";
			Id = 5977;
			Model = 14401;
			Level = RandomLevel(53,54);
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
			BoundingRadius = 2.0f;
			CombatReach = 3.5f;
			Size = 2.5f;
			Speed = 2.3f;
			WalkSpeed = 2.3f;
			RunSpeed = 5.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			//Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1755, 53 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DreadmaulDrops.DreadmaulWarlock , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DreadmaulWarlock : BaseCreature
	{
		public DreadmaulWarlock() : base()
		{
			Name = "Dreadmaul Warlock";
			Id = 5978;
			Model = 11543;
			Level = RandomLevel(54,55);
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
			BoundingRadius = 2.0f;
			CombatReach = 3.5f;
			Size = 2.5f;
			Speed = 2.32f;
			WalkSpeed = 2.32f;
			RunSpeed = 5.32f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			//Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1494, 54 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DreadmaulDrops.DreadmaulWarlock , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}
