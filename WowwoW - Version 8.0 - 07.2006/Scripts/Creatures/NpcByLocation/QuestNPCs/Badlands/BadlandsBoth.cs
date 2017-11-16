using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class LucienTosselwrench : BaseNPC
	{
		public LucienTosselwrench() : base()
		{
			Id = 2920;
			Level = RandomLevel( 31 );
			Name = "Lucien Tosselwrench";
			NpcText00 = "Greetings $N, I am Lucien Tosselwrench.";
			Model = 4895;
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
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 6535, (InventoryTypes)23, 4, 0, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KeeperBeldugur : BaseNPC
	{
		public KeeperBeldugur() : base()
		{
			Id = 2934;
			Level = RandomLevel( 42 );
			Name = "Keeper Bel'dugur";
			NpcText00 = "Greetings $N, I am Keeper Bel'dugur.";
			Model = 5751;
			AttackSpeed = 1500;
			CombatReach = 1.5f;
			BoundingRadius = 0.383f;
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
			Flags1 = 0x018480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Undercity;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class LotwilVeriatus : BaseNPC
	{
		public LotwilVeriatus() : base()
		{
			Id = 2921;
			Level = RandomLevel( 36 );
			Name = "Lotwil Veriatus";
			NpcText00 = "Greetings $N, I am Lotwil Veriatus.";
			Model = 4896;
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
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 5569, (InventoryTypes)21, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class Rigglefuzz : BaseNPC
	{
		public Rigglefuzz() : base()
		{
			Id = 2817;
			Level = RandomLevel( 37 );
			Name = "Rigglefuzz";
			NpcText00 = "Greetings $N, I am Rigglefuzz.";
			Model = 7033;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	
}