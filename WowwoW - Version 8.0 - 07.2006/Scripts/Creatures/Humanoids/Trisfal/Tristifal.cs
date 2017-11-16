using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class TirisfalFarmer : BaseCreature
	{
		public TirisfalFarmer() : base()
		{
			Id = 1934;
			Level = RandomLevel( 7 );
			Name = "Tirisfal Farmer";
			Model = 3532;
			AttackSpeed = 3200;
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
			ResistNature = 100;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7464, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LinenCloth ), 28.4f )
					, new Loot( typeof( TirisfalPumpkin ), 1.43f )
					, new Loot( typeof( FarmersShovel ), 0.85f )
					}, 100f ) };
		}
	}
	public class TirisfalFarmhand : BaseCreature
	{
		public TirisfalFarmhand() : base()
		{
			Id = 1935;
			Level = RandomLevel( 6 );
			Name = "Tirisfal Farmhand";
			Model = 3534;
			AttackSpeed = 3200;
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
			ResistNature = 100;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7464, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( LinenCloth ), 28.6f )
					, new Loot( typeof( TirisfalPumpkin ), 1.26f )
					, new Loot( typeof( FarmersBroom ), 3.80f )
					}, 100f ) };
		}
	}
	
}