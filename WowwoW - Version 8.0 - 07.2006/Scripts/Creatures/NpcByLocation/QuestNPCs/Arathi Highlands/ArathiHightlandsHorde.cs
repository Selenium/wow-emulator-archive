using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class KorinFel : BaseNPC
	{
		public KorinFel() : base()
		{
			Id = 2772;
			Level = RandomLevel( 35 );
			Name = "Korin Fel";
			NpcText00 = "Greetings $N, I am Korin Fel.";
			Model = 4046;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class Gormul : BaseNPC
	{
		public Gormul() : base()
		{
			Id = 2792;
			Level = RandomLevel( 40 );
			Name = "Gor'mul";
			NpcText00 = "Greetings $N, I am Gor'mul.";
			Model = 4048;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 22319, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class Torgan : BaseNPC
	{
		public Torgan() : base()
		{
			Id = 2706;
			Level = RandomLevel( 40 );
			Name = "Tor'gan";
			NpcText00 = "Greetings $N, I am Tor'gan.";
			Model = 4047;
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
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 23465, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	
}