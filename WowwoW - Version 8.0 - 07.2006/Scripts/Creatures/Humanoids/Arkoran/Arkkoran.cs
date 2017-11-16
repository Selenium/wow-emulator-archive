using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class ArkkoranClacker : BaseCreature
	{
		public ArkkoranClacker() : base()
		{
			Id = 6135;
			Level = RandomLevel( 53 ,54 );
			Name = "Arkkoran Clacker";
			Model = 2599;
			AttackSpeed = 2000;
			CombatReach = 1.04f;
			BoundingRadius = 0.4002f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 60;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f ) 
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( SolidStone ), 0.02f )
					, new Loot( typeof( BigMouthClam ), 39.3f )
					, new Loot( typeof( ZestyClamMeat ), 0.42f )
					}, 100f ) };
		}
	}
	public class ArkkoranMuckdweller : BaseCreature
	{
		public ArkkoranMuckdweller() : base()
		{
			Id = 6136;
			Level = RandomLevel( 53 ,54 );
			Name = "Arkkoran Muckdweller";
			Model = 5025;
			AttackSpeed = 2000;
			CombatReach = 2.62f;
			BoundingRadius = 0.72975f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 60;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f ) 
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( SolidStone ), 0.01f )
					, new Loot( typeof( BigMouthClam ), 39.8f )
					, new Loot( typeof( ZestyClamMeat ), 0.33f )
					}, 100f ) };
		}
	}
	public class ArkkoranPincer : BaseCreature
	{
		public ArkkoranPincer() : base()
		{
			Id = 6137;
			Level = RandomLevel( 53 ,55 );
			Name = "Arkkoran Pincer";
			Model = 1817;
			AttackSpeed = 2000;
			CombatReach = 1.62f;
			BoundingRadius = 0.4524f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 60;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f ) 
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( BigMouthClam ), 39.1f )
					, new Loot( typeof( ZestyClamMeat ), 0.40f )
					}, 100f ) };
		}
	}
	public class ArkkoranOracle : BaseCreature
	{
		public ArkkoranOracle() : base()
		{
			Id = 6138;
			Level = RandomLevel( 54 ,55 );
			Name = "Arkkoran Oracle";
			Model = 11293;
			AttackSpeed = 2000;
			CombatReach = 2.62f;
			BoundingRadius = 0.72975f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 60;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyD , 100f ) 
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( PatternStormshroudArmor ), 1.04f )
					, new Loot( typeof( BigMouthClam ), 39.6f )
					, new Loot( typeof( ZestyClamMeat ), 0.47f )
					}, 100f ) };
		}
	}
	
	
}