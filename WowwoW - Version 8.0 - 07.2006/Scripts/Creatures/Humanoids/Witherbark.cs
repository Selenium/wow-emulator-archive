using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class Rinji : BaseNPC
	{
		public Rinji() : base()
		{
			Id = 7780;
			Level = RandomLevel( 46 );
			Name = "Rin'ji";
			Guild = "Witherbark Troll";
			NpcText00 = "Greetings $N, I am Rin'ji.";
			Model = 6485;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			Flags1 = 0x0480066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class WitherbarkBloodling : BaseCreature
	{
		public WitherbarkBloodling() : base()
		{
			Id = 7768;
			Level = RandomLevel( 25 );
			Name = "Witherbark Bloodling";
			Model = 513;
			AttackSpeed = 1000;
			CombatReach = 0.6f;
			BoundingRadius = 0.748f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x04006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( SolidStone ), 33.8f )
					}, 100f ) };
		}
	}
	public class WitherbarkScalper : BaseCreature
	{
		public WitherbarkScalper() : base()
		{
			Id = 2649;
			Level = RandomLevel( 41 );
			Name = "Witherbark Scalper";
			Model = 6479;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.2907f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Francisca(), new CrescentAxe());
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WildkinFeather ), 0.01f )
					, new Loot( typeof( TrollSweat ), 29.4f )
					, new Loot( typeof( SilkCloth ), 9.94f )
					, new Loot( typeof( MageweaveCloth ), 24.6f )
					, new Loot( typeof( FlaskOfMojo ), 9.76f )
					, new Loot( typeof( OOX09HLDistressBeacon ), 0.36f )
					, new Loot( typeof( TrollTribalNecklace ), 33.9f )
					, new Loot( typeof( WitherbarkSkull ), 9.01f )
					}, 100f ) };
		}
	}
	public class WitherbarkZealot : BaseCreature
	{
		public WitherbarkZealot() : base()
		{
			Id = 2650;
			Level = RandomLevel( 41 );
			Name = "Witherbark Zealot";
			Model = 6480;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new CrescentAxe() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( TrollSweat ), 29.5f )
					, new Loot( typeof( SilkCloth ), 9.71f )
					, new Loot( typeof( MageweaveCloth ), 24.4f )
					, new Loot( typeof( FlaskOfMojo ), 9.48f )
					, new Loot( typeof( OOX09HLDistressBeacon ), 0.34f )
					, new Loot( typeof( TrollTribalNecklace ), 33.7f )
					, new Loot( typeof( WitherbarkSkull ), 9.41f )
					}, 100f ) };
		}
	}
	public class WitherbarkHideskinner : BaseCreature
	{
		public WitherbarkHideskinner() : base()
		{
			Id = 2651;
			Level = RandomLevel( 43 );
			Name = "Witherbark Hideskinner";
			Model = 6484;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new ShinyDirk() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WildkinFeather ), 0.01f )
					, new Loot( typeof( TrollSweat ), 29.0f )
					, new Loot( typeof( SilkCloth ), 9.48f )
					, new Loot( typeof( MageweaveCloth ), 23.8f )
					, new Loot( typeof( LongElegantFeather ), 9.23f )
					, new Loot( typeof( SolidStone ), 0.01f )
					, new Loot( typeof( FlaskOfMojo ), 9.97f )
					, new Loot( typeof( OOX09HLDistressBeacon ), 0.32f )
					, new Loot( typeof( TrollTribalNecklace ), 33.3f )
					, new Loot( typeof( WitherbarkSkull ), 6.61f )
					}, 100f ) };
		}
	}
	public class WitherbarkVenomblood : BaseCreature
	{
		public WitherbarkVenomblood() : base()
		{
			Id = 2652;
			Level = RandomLevel( 43 );
			Name = "Witherbark Venomblood";
			Model = 6485;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new CrescentAxe() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WildkinFeather ), 0.01f )
					, new Loot( typeof( TrollSweat ), 29.5f )
					, new Loot( typeof( SilkCloth ), 9.72f )
					, new Loot( typeof( MageweaveCloth ), 24.1f )
					, new Loot( typeof( FlaskOfMojo ), 9.48f )
					, new Loot( typeof( OOX09HLDistressBeacon ), 0.40f )
					, new Loot( typeof( TrollTribalNecklace ), 33.6f )
					, new Loot( typeof( WitherbarkSkull ), 6.55f )
					}, 100f ) };
		}
	}
	public class WitherbarkSadist : BaseCreature
	{
		public WitherbarkSadist() : base()
		{
			Id = 2653;
			Level = RandomLevel( 44 );
			Name = "Witherbark Sadist";
			Model = 6490;
			AttackSpeed = 1500;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new BigBronzeKnife() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( TrollSweat ), 29.3f )
					, new Loot( typeof( SilkCloth ), 9.39f )
					, new Loot( typeof( MageweaveCloth ), 23.8f )
					, new Loot( typeof( ZestyClamMeat ), 0.01f )
					, new Loot( typeof( FlaskOfMojo ), 9.41f )
					, new Loot( typeof( OOX09HLDistressBeacon ), 0.36f )
					, new Loot( typeof( TrollTribalNecklace ), 33.7f )
					, new Loot( typeof( WitherbarkSkull ), 5.07f )
					}, 100f ) };
		}
	}
	public class WitherbarkCaller : BaseCreature
	{
		public WitherbarkCaller() : base()
		{
			Id = 2654;
			Level = RandomLevel( 45 );
			Name = "Witherbark Caller";
			Model = 6487;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new SpellforceRod() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( TrollSweat ), 30.6f )
					, new Loot( typeof( SilkCloth ), 8.91f )
					, new Loot( typeof( MageweaveCloth ), 24.8f )
					, new Loot( typeof( SackOfRye ), 0.03f )
					, new Loot( typeof( SolidStone ), 0.06f )
					, new Loot( typeof( FlaskOfMojo ), 10.0f )
					, new Loot( typeof( OOX09HLDistressBeacon ), 0.30f )
					, new Loot( typeof( TrollTribalNecklace ), 33.5f )
					, new Loot( typeof( WitherbarkSkull ), 4.18f )
					}, 100f ) };
		}
	}
	public class ZalasWitherbark : BaseCreature
	{
		public ZalasWitherbark() : base()
		{
			Id = 2605;
			Level = RandomLevel( 40 );
			Name = "Zalas Witherbark";
			Guild = "Warband Leader";
			Model = 4003;
			AttackSpeed = 1294;
			CombatReach = 1.05f;
			BoundingRadius = 0.51f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 2;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 3;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level)*(Elite+1), MoneyDrops.MaxAmount(Level)*(Elite+1), 100f ) }
				, 100f ), new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( SilkCloth ), 22.5f )
					, new Loot( typeof( MageweaveCloth ), 6.45f )
					, new Loot( typeof( WitherbarkTusk ), 6.45f )
					, new Loot( typeof( FlaskOfMojo ), 3.22f )
					}, 100f ) };
		}
	}
	public class WitherbarkTroll : BaseCreature
	{
		public WitherbarkTroll() : base()
		{
			Id = 2552;
			Level = RandomLevel( 30 );
			Name = "Witherbark Troll";
			Model = 3986;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WoolCloth ), 3.86f )
					, new Loot( typeof( SilkCloth ), 30.4f )
					, new Loot( typeof( MageweaveCloth ), 0.85f )
					, new Loot( typeof( WitherbarkTusk ), 12.3f )
					, new Loot( typeof( WitherbarkTotemStick ), 1.49f )
					}, 100f ) };
		}
	}
	public class WitherbarkShadowcaster : BaseCreature
	{
		public WitherbarkShadowcaster() : base()
		{
			Id = 2553;
			Level = RandomLevel( 32 );
			Name = "Witherbark Shadowcaster";
			Model = 3994;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Starfaller() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( RobesOfTheShadowcaster ), 0.50f )
					, new Loot( typeof( WoolCloth ), 3.72f )
					, new Loot( typeof( SilkCloth ), 28.7f )
					, new Loot( typeof( MageweaveCloth ), 1.02f )
					, new Loot( typeof( WitherbarkTusk ), 12.7f )
					, new Loot( typeof( WitherbarkTotemStick ), 1.79f )
					}, 100f ) };
		}
	}
	public class WitherbarkAxeThrower : BaseCreature
	{
		public WitherbarkAxeThrower() : base()
		{
			Id = 2554;
			Level = RandomLevel( 33 );
			Name = "Witherbark Axe Thrower";
			Model = 3991;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new CrescentAxe(), new CrescentAxe()) ;
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WoolCloth ), 3.97f )
					, new Loot( typeof( SilkCloth ), 29.2f )
					, new Loot( typeof( MageweaveCloth ), 0.94f )
					, new Loot( typeof( WitherbarkTusk ), 11.6f )
					, new Loot( typeof( WitherbarkTotemStick ), 2.08f )
					}, 100f ) };
		}
	}
	public class WitherbarkWitchDoctor : BaseCreature
	{
		public WitherbarkWitchDoctor() : base()
		{
			Id = 2555;
			Level = RandomLevel( 34 );
			Name = "Witherbark Witch Doctor";
			Model = 3996;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Starfaller() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WoolCloth ), 3.92f )
					, new Loot( typeof( SilkCloth ), 28.6f )
					, new Loot( typeof( MageweaveCloth ), 1.02f )
					, new Loot( typeof( WitherbarkTusk ), 9.42f )
					, new Loot( typeof( WitherbarkMedicinePouch ), 14.9f )
					, new Loot( typeof( WitherbarkTotemStick ), 1.56f )
					}, 100f ) };
		}
	}
	public class WitherbarkHeadhunter : BaseCreature
	{
		public WitherbarkHeadhunter() : base()
		{
			Id = 2556;
			Level = RandomLevel( 34 );
			Name = "Witherbark Headhunter";
			Model = 3997;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new HillborneAxe() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( FormulaEnchantGlovesSkinning ), 1.04f )
					, new Loot( typeof( WoolCloth ), 3.78f )
					, new Loot( typeof( SilkCloth ), 28.7f )
					, new Loot( typeof( MageweaveCloth ), 0.95f )
					, new Loot( typeof( WitherbarkTusk ), 8.30f )
					, new Loot( typeof( WitherbarkTotemStick ), 1.24f )
					}, 100f ) };
		}
	}
	public class WitherbarkShadowHunter : BaseCreature
	{
		public WitherbarkShadowHunter() : base()
		{
			Id = 2557;
			Level = RandomLevel( 35 );
			Name = "Witherbark Shadow Hunter";
			Model = 4000;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Starfaller() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level), MoneyDrops.MaxAmount(Level), 100f ) }, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( FormulaEnchantGlovesSkinning ), 1.00f )
					, new Loot( typeof( WoolCloth ), 4.11f )
					, new Loot( typeof( SilkCloth ), 28.2f )
					, new Loot( typeof( MageweaveCloth ), 0.87f )
					, new Loot( typeof( WitherbarkTusk ), 6.84f )
					, new Loot( typeof( ShadowHunterKnife ), 10.6f )
					, new Loot( typeof( WitherbarkTotemStick ), 0.62f )
					, new Loot( typeof( SolidStone ), 0.02f )
					}, 100f ) };
		}
	}
	public class WitherbarkBerserker : BaseCreature
	{
		public WitherbarkBerserker() : base()
		{
			Id = 2558;
			Level = RandomLevel( 36 );
			Name = "Witherbark Berserker";
			Model = 4002;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 40;
			ResistFire = 0;
			ResistFrost = 40;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction =Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Francisca(), new Francisca() );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] { new Loot( typeof( Money ), MoneyDrops.MinAmount(Level)*(Elite+1), MoneyDrops.MaxAmount(Level)*(Elite+1), 100f ) }
				, 100f ), new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( FormulaEnchantGlovesSkinning ), 0.83f )
					, new Loot( typeof( SilkCloth ), 25.8f )
					, new Loot( typeof( MageweaveCloth ), 4.23f )
					, new Loot( typeof( WitherbarkTusk ), 1.02f )
					, new Loot( typeof( WitherbarkTotemStick ), 0.79f )
					, new Loot( typeof( FlaskOfMojo ), 8.95f )
					}, 100f ) };
		}
	}
	
	
}