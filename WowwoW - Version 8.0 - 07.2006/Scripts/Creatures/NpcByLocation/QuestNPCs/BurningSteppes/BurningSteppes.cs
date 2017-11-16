using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class MaxwortUberglint : BaseNPC
	{
		public MaxwortUberglint() : base()
		{
			Id = 9536;
			Level = RandomLevel( 42 );
			Name = "Maxwort Uberglint";
			NpcText00 = "Greetings $N, I am Maxwort Uberglint.";
			Model = 8656;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class JalindaSprig : BaseNPC
	{
		public JalindaSprig() : base()
		{
			Id = 9561;
			Level = RandomLevel( 57 );
			Name = "Jalinda Sprig";
			NpcText01 = "It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			Model = 8693;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x0480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class RaggedJohn : BaseNPC
	{
		public RaggedJohn() : base()
		{
			Id = 9563;
			Level = RandomLevel( 57 );
			Name = "Ragged John";
			NpcText00 = "Greetings $N, I am Ragged John.";
			Model = 8696;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class MathredisFirestar : BaseNPC
	{
		public MathredisFirestar() : base()
		{
			Id = 9836;
			Level = RandomLevel( 60 );
			Name = "Mathredis Firestar";
			NpcText00 = "Greetings $N, I am Mathredis Firestar.";
			Model = 9149;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.214f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class Oralius : BaseNPC
	{
		public Oralius() : base()
		{
			Id = 9177;
			Level = RandomLevel( 55 );
			Name = "Oralius";
			NpcText00 = "Greetings $N, I am Oralius.";
			Model = 8872;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7482, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1705, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class Kibler : BaseNPC
	{
		public Kibler() : base()
		{
			Id = 10260;
			Level = RandomLevel( 56 );
			Name = "Kibler";
			NpcText00 = "Greetings $N, I am Kibler.";
			Model = 9561;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class HelendisRiverhorn : BaseNPC
	{
		public HelendisRiverhorn() : base()
		{
			Id = 9562;
			Level = RandomLevel( 55 );
			Name = "Helendis Riverhorn";
			NpcText00 = "Greetings $N, I am Helendis Riverhorn.";
			Model = 8694;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x0480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7480, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class TinkeeSteamboil : BaseNPC
	{
		public TinkeeSteamboil() : base()
		{
			Id = 10267;
			Level = RandomLevel( 53 );
			Name = "Tinkee Steamboil";
			NpcText00 = "Greetings $N, I am Tinkee Steamboil.";
			Model = 9791;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7445, (InventoryTypes)13, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	
	
}