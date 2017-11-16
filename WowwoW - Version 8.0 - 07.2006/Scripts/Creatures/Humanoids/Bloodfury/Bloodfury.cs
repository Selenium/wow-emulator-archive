using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class BloodfuryRipper : BaseCreature
	{
		public BloodfuryRipper() : base()
		{
			Id = 12579;
			Level = RandomLevel( 26 );
			Name = "Bloodfury Ripper";
			Model = 2295;
			AttackSpeed = 2000;
			CombatReach = 1.95f;
			BoundingRadius = 0.6188f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( BloodfuryRippersRemains ), 53.0f )
					, new Loot( typeof( LightFeather ), 22.9f )
					, new Loot( typeof( WoolCloth ), 8.06f )
					, new Loot( typeof( SilkCloth ), 19.6f )
					, new Loot( typeof( LongTailFeather ), 3.72f )
					, new Loot( typeof( VibrantPlume ), 23.2f )
					, new Loot( typeof( ClamMeat ), 0.02f )
					, new Loot( typeof( SharpClaw ), 4.23f )
					, new Loot( typeof( DelicateFeather ), 0.67f )
					}, 100f ) };
		}
	}
	public class BloodfuryHarpy : BaseCreature
	{
		public BloodfuryHarpy() : base()
		{
			Id = 4022;
			Level = RandomLevel( 23 );
			Name = "Bloodfury Harpy";
			Model = 3022;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.5474f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LightFeather ), 27.9f )
					, new Loot( typeof( LinenCloth ), 5.01f )
					, new Loot( typeof( WoolCloth ), 23.6f )
					, new Loot( typeof( Coal ), 3.84f )
					, new Loot( typeof( SilkCloth ), 4.78f )
					, new Loot( typeof( BrokenWishbone ), 3.23f )
					, new Loot( typeof( LongTailFeather ), 11.0f )
					, new Loot( typeof( SharpClaw ), 3.83f )
					, new Loot( typeof( DelicateFeather ), 0.99f )
					}, 100f ) };
		}
	}
	public class BloodfuryRoguefeather : BaseCreature
	{
		public BloodfuryRoguefeather() : base()
		{
			Id = 4023;
			Level = RandomLevel( 26 );
			Name = "Bloodfury Roguefeather";
			Model = 6813;
			AttackSpeed = 2000;
			CombatReach = 1.95f;
			BoundingRadius = 0.6188f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LightFeather ), 27.8f )
					, new Loot( typeof( LinenCloth ), 4.78f )
					, new Loot( typeof( WoolCloth ), 23.5f )
					, new Loot( typeof( Coal ), 4.85f )
					, new Loot( typeof( SilkCloth ), 4.79f )
					, new Loot( typeof( BrokenWishbone ), 3.23f )
					, new Loot( typeof( LongTailFeather ), 10.9f )
					, new Loot( typeof( SharpClaw ), 3.73f )
					, new Loot( typeof( DelicateFeather ), 0.94f )
					}, 100f ) };
		}
	}
	public class BloodfurySlayer : BaseCreature
	{
		public BloodfurySlayer() : base()
		{
			Id = 4024;
			Level = RandomLevel( 26 );
			Name = "Bloodfury Slayer";
			Model = 10870;
			AttackSpeed = 2000;
			CombatReach = 2.25f;
			BoundingRadius = 0.714f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LightFeather ), 27.8f )
					, new Loot( typeof( LinenCloth ), 4.74f )
					, new Loot( typeof( WoolCloth ), 23.3f )
					, new Loot( typeof( Coal ), 4.64f )
					, new Loot( typeof( SilkCloth ), 4.62f )
					, new Loot( typeof( BrokenWishbone ), 3.20f )
					, new Loot( typeof( LongTailFeather ), 11.1f )
					, new Loot( typeof( SharpClaw ), 3.79f )
					, new Loot( typeof( DelicateFeather ), 0.99f )
					}, 100f ) };
		}
	}
	public class BloodfuryAmbusher : BaseCreature
	{
		public BloodfuryAmbusher() : base()
		{
			Id = 4025;
			Level = RandomLevel( 23 );
			Name = "Bloodfury Ambusher";
			Model = 10869;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.5474f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LightFeather ), 27.9f )
					, new Loot( typeof( LinenCloth ), 4.74f )
					, new Loot( typeof( WoolCloth ), 23.8f )
					, new Loot( typeof( Coal ), 3.84f )
					, new Loot( typeof( SilkCloth ), 4.76f )
					, new Loot( typeof( BrokenWishbone ), 3.24f )
					, new Loot( typeof( LongTailFeather ), 11.0f )
					, new Loot( typeof( SharpClaw ), 3.85f )
					, new Loot( typeof( DelicateFeather ), 1.01f )
					, new Loot( typeof( SolidStone ), 0.01f )
					}, 100f ) };
		}
	}
	public class BloodfuryWindcaller : BaseCreature
	{
		public BloodfuryWindcaller() : base()
		{
			Id = 4026;
			Level = RandomLevel( 24 );
			Name = "Bloodfury Windcaller";
			Model = 10282;
			AttackSpeed = 2000;
			CombatReach = 1.95f;
			BoundingRadius = 0.6188f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LightFeather ), 27.6f )
					, new Loot( typeof( LinenCloth ), 4.53f )
					, new Loot( typeof( WoolCloth ), 23.8f )
					, new Loot( typeof( Coal ), 3.95f )
					, new Loot( typeof( SilkCloth ), 4.74f )
					, new Loot( typeof( BrokenWishbone ), 3.17f )
					, new Loot( typeof( LongTailFeather ), 11.2f )
					, new Loot( typeof( SharpClaw ), 3.63f )
					, new Loot( typeof( DelicateFeather ), 1.05f )
					}, 100f ) };
		}
	}
	public class BloodfuryStormWitch : BaseCreature
	{
		public BloodfuryStormWitch() : base()
		{
			Id = 4027;
			Level = RandomLevel( 26 );
			Name = "Bloodfury Storm Witch";
			Model = 10871;
			AttackSpeed = 2000;
			CombatReach = 2.25f;
			BoundingRadius = 0.714f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( BloodfuryRippersRemains ), 0.33f )
					, new Loot( typeof( LightFeather ), 27.8f )
					, new Loot( typeof( LinenCloth ), 4.69f )
					, new Loot( typeof( WoolCloth ), 23.2f )
					, new Loot( typeof( Coal ), 4.54f )
					, new Loot( typeof( SilkCloth ), 4.75f )
					, new Loot( typeof( BrokenWishbone ), 3.25f )
					, new Loot( typeof( LongTailFeather ), 11.2f )
					, new Loot( typeof( SharpClaw ), 3.85f )
					, new Loot( typeof( DelicateFeather ), 0.96f )
					, new Loot( typeof( SolidStone ), 0.01f )
					}, 100f ) };
		}
	}
	
	
}