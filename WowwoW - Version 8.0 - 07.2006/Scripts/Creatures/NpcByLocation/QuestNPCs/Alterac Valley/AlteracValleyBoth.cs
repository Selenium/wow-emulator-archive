using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class MasterEngineerZinfizzlex : BaseNPC
	{
		public MasterEngineerZinfizzlex() : base()
		{
			Id = 13377;
			Level = RandomLevel( 60 );
			Name = "Master Engineer Zinfizzlex";
			Model = 13439;
			AttackSpeed = 1061;
			CombatReach = 1.39f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 24.6f )
					}, 100f ) };
		}
	}
	public class CommanderLouisPhilips : BaseNPC
	{
		public CommanderLouisPhilips() : base()
		{
			Id = 13154;
			Level = RandomLevel( 61 );
			Name = "Commander Louis Philips";
			Model = 13465;
			AttackSpeed = 1050;
			CombatReach = 1.39f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 23.7f )
					, new Loot( typeof( ArmorScraps ), 89.4f )
					, new Loot( typeof( StormCrystal ), 48f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 36f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 14.5f )
					, new Loot( typeof( ColdtoothSupplies ), 0.28f )
					, new Loot( typeof( DarkspearTrollMojo ), 0.28f )
					, new Loot( typeof( IchorOfUndeath ), 3.71f )
					}, 100f ) };
		}
	}
	public class CommanderKarlPhilips : BaseNPC
	{
		public CommanderKarlPhilips() : base()
		{
			Id = 13320;
			Level = RandomLevel( 61 );
			Name = "Commander Karl Philips";
			Model = 13450;
			AttackSpeed = 1050;
			CombatReach = 1.39f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 26.2f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 40.7f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 38.8f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 17.3f )
					, new Loot( typeof( Steamsaw ), 0.27f )
					, new Loot( typeof( ArmorScraps ), 90.2f )
					, new Loot( typeof( StormCrystal ), 0.27f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 0.27f )
					, new Loot( typeof( HumanBoneChip ), 0.27f )
					, new Loot( typeof( ForsakenHeart ), 0.27f )
					}, 100f ) };
		}
	}
	
}