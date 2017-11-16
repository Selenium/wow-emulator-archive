using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class AzoreAldamort : BaseNPC
	{
		public AzoreAldamort() : base()
		{
			Id = 11863;
			Level = RandomLevel( 60 );
			Name = "Azore Aldamort";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Azore Aldamort.";
			Model = 11794;
			AttackSpeed = 1273;
			CombatReach = 0.8f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x0480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f ) 
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class ArgentDefender : BaseCreature
	{
		public ArgentDefender() : base()
		{
			Id = 11194;
			Level = RandomLevel( 55 );
			Name = "Argent Defender";
			Guild = "The Argent Dawn";
			Model = 11407;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7526, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 23568, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f ) 
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class ArgentGuard : BaseCreature
	{
		public ArgentGuard() : base()
		{
			Id = 11099;
			Level = RandomLevel( 55 );
			Name = "Argent Guard";
			Guild = "The Argent Dawn";
			Model = 10557;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7526, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 23568, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class ArgentRider : BaseCreature
	{
		public ArgentRider() : base()
		{
			Id = 11102;
			Level = RandomLevel( 55 );
			Name = "Argent Rider";
			Guild = "The Argent Dawn";
			Model = 10562;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 22492, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class CarlinRedpath : BaseNPC
	{
		public CarlinRedpath() : base()
		{
			Id = 11063;
			Level = RandomLevel( 58 );
			Name = "Carlin Redpath";
			Guild = "The Argent Dawn";
			NpcText00 = "We have all been witness to terrible tragedies, but we must not let them drag us to despair.$B$BInstead, hold those memories close so that one day, we might find a reckoning.";
			Model = 10476;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 7483, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1706, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class DukeNicholasZverenhoff : BaseNPC
	{
		public DukeNicholasZverenhoff() : base()
		{
			Id = 11039;
			Level = RandomLevel( 60 );
			Name = "Duke Nicholas Zverenhoff";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Duke Nicholas Zverenhoff.";
			Model = 10468;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 2466, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class BetinaBigglezink : BaseNPC
	{
		public BetinaBigglezink() : base()
		{
			Id = 11035;
			Level = RandomLevel( 57 );
			Name = "Betina Bigglezink";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Betina Bigglezink.";
			Model = 10465;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class LeonidBarthalomewTheRevered : BaseNPC
	{
		public LeonidBarthalomewTheRevered() : base()
		{
			Id = 11036;
			Level = RandomLevel( 60 );
			Name = "Leonid Barthalomew the Revered";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Leonid Barthalomew the Revered.";
			Model = 10474;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.383f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 3797, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class LordMaxwellTyrosus : BaseNPC
	{
		public LordMaxwellTyrosus() : base()
		{
			Id = 11034;
			Level = RandomLevel( 62 );
			Name = "Lord Maxwell Tyrosus";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Lord Maxwell Tyrosus.";
			Model = 10469;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 23692, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class GregorGreystone : BaseNPC
	{
		public GregorGreystone() : base()
		{
			Id = 10431;
			Level = RandomLevel( 55 );
			Name = "Gregor Greystone";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Gregor Greystone.";
			Model = 9792;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 2466, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class DawnwatcherShaedlass : BaseNPC
	{
		public DawnwatcherShaedlass() : base()
		{
			Id = 4786;
			Level = RandomLevel( 22 );
			Name = "Dawnwatcher Shaedlass";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Dawnwatcher Shaedlass.";
			Model = 5225;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class ArgentGuardThaelrid : BaseNPC
	{
		public ArgentGuardThaelrid() : base()
		{
			Id = 4787;
			Level = RandomLevel( 20 );
			Name = "Argent Guard Thaelrid";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Argent Guard Thaelrid.";
			Model = 4946;
			AttackSpeed = 1833;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 7480, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LinenCloth ), 20f )
					}, 100f ) };
		}
	}
	public class DawnwatcherSelgorm : BaseNPC
	{
		public DawnwatcherSelgorm() : base()
		{
			Id = 4783;
			Level = RandomLevel( 25 );
			Name = "Dawnwatcher Selgorm";
			Guild = "The Argent Dawn";
			Model = 5226;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class ArgentGuardManados : BaseNPC
	{
		public ArgentGuardManados() : base()
		{
			Id = 4784;
			Level = RandomLevel( 23 );
			Name = "Argent Guard Manados";
			Guild = "The Argent Dawn";
			NpcText00 = "Greetings $N, I am Argent Guard Manados.";
			Model = 5084;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class FatherGavin : BaseCreature
	{
		public FatherGavin() : base()
		{
			Id = 1253;
			Level = RandomLevel( 15 );
			Name = "Father Gavin";
			Guild = "The Argent Dawn";
			Model = 1616;
			AttackSpeed = 1500;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 30;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x08080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ArgentDawn;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 24499, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	
}