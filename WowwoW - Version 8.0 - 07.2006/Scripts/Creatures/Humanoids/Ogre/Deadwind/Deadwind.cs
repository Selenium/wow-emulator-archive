using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class DeadwindOgreMage : BaseCreature
	{
		public DeadwindOgreMage() : base()
		{
			Name = "Deadwind Ogre Mage";
			Id = 7379;
			Model = 11537;
			Level = RandomLevel(55,56);
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
			Speed = 2.34f;
			WalkSpeed = 2.34f;
			RunSpeed = 5.34f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			BCAddon.Hp( this, 3584, 55 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DeadwindDrops.DeadwindOgreMage , 100f )
			, new BaseTreasure( Drops.MoneyD , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DeadwindBrute : BaseCreature
	{
		public DeadwindBrute() : base()
		{
			Name = "Deadwind Brute";
			Id = 7369;
			Model = 11533;
			Level = RandomLevel(55,56);
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
			BoundingRadius = 2.0f;
			CombatReach = 3.5f;
			Size = 2.35f;
			Speed = 2.34f;
			WalkSpeed = 2.34f;
			RunSpeed = 5.34f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			BCAddon.Hp( this, 3584, 55 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DeadwindDrops.DeadwindBrute , 100f )
			, new BaseTreasure( Drops.MoneyD , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DeadwindMauler : BaseCreature
	{
		public DeadwindMauler() : base()
		{
			Name = "Deadwind Mauler";
			Id = 7371;
			Model = 11536;
			Level = RandomLevel(57);
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
			CombatReach = 3.75f;
			Size = 2.5f;
			Speed = 2.34f;
			WalkSpeed = 2.34f;
			RunSpeed = 5.34f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			BCAddon.Hp( this, 3984, 57 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DeadwindDrops.DeadwindMauler , 100f )
			, new BaseTreasure( Drops.MoneyD , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DeadwindWarlock : BaseCreature
	{
		public DeadwindWarlock() : base()
		{
			Name = "Deadwind Warlock";
			Id = 7372;
			Model = 11538;
			Level = RandomLevel(57);
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
			BoundingRadius = 2.5f;
			CombatReach = 3.75f;
			Size = 2.5f;
			Speed = 2.34f;
			WalkSpeed = 2.34f;
			RunSpeed = 5.34f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			BCAddon.Hp( this, 3984, 57 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DeadwindDrops.DeadwindWarlock , 100f )
			, new BaseTreasure( Drops.MoneyD , 100f ) };
		}
	}
}


