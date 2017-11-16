using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class FiregutOgre : BaseCreature
	{
		public FiregutOgre() : base()
		{
			Name = "Firegut Ogre";
			Id = 7033;
			Model = 11549;
			Level = RandomLevel(50,51);
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
			BoundingRadius = 1.9f;
			CombatReach = 3.3f;
			Size = 2.2f;
			Speed = 2.3f;
			WalkSpeed = 2.3f;
			RunSpeed = 5.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7477, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1434, 50 );
			Loots = new BaseTreasure[]{  new BaseTreasure( FiregutDrops.FiregutOgre , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class FiregutOgreMage : BaseCreature
	{
		public FiregutOgreMage() : base()
		{
			Name = "Firegut Ogre Mage";
			Id = 7034;
			Model = 11550;
			Level = RandomLevel(50,52);
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
			BoundingRadius = 1.9f;
			CombatReach = 3.3f;
			Size = 2.2f;
			Speed = 2.3f;
			WalkSpeed = 2.3f;
			RunSpeed = 5.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			BCAddon.Hp( this, 2158, 50 );
			Loots = new BaseTreasure[]{  new BaseTreasure( FiregutDrops.FiregutOgreMage , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class FiregutBrute : BaseCreature
	{
		public FiregutBrute() : base()
		{
			Name = "Firegut Brute";
			Id = 7035;
			Model = 10707;
			Level = RandomLevel(52,53);
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
			BoundingRadius = 2f;
			CombatReach = 3.5f;
			Size = 2.35f;
			Speed = 2.3f;
			WalkSpeed = 2.3f;
			RunSpeed = 5.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 2847, 52 );
			Loots = new BaseTreasure[]{  new BaseTreasure( FiregutDrops.FiregutBrute , 100f )
			, new BaseTreasure( Drops.MoneyC , 100f ) };
		}
	}
}
