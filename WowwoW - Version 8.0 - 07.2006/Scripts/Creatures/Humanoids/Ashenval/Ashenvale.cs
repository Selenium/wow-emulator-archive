using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class AshenvaleOutrunner : BaseCreature
	{
		public AshenvaleOutrunner() : base()
		{
			Id = 12856;
			Level = RandomLevel( 24 );
			Name = "Ashenvale Outrunner";
			Model = 12914;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)84;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 23692, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6231, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( ShredderOperatingManualPage1 ), 0.80f )
					, new Loot( typeof( ShredderOperatingManualPage2 ), 0.82f )
					, new Loot( typeof( ShredderOperatingManualPage3 ), 0.84f )
					, new Loot( typeof( ShredderOperatingManualPage4 ), 0.95f )
					, new Loot( typeof( ShredderOperatingManualPage5 ), 0.80f )
					, new Loot( typeof( ShredderOperatingManualPage6 ), 0.93f )
					, new Loot( typeof( ShredderOperatingManualPage7 ), 0.93f )
					, new Loot( typeof( ShredderOperatingManualPage8 ), 0.96f )
					, new Loot( typeof( ShredderOperatingManualPage9 ), 0.90f )
					, new Loot( typeof( ShredderOperatingManualPage10 ), 0.95f )
					, new Loot( typeof( ShredderOperatingManualPage11 ), 1.01f )
					, new Loot( typeof( ShredderOperatingManualPage12 ), 0.94f )
					, new Loot( typeof( BrokenLock ), 0.02f )
					, new Loot( typeof( PaddedLining ), 0.01f )
					, new Loot( typeof( LinenCloth ), 5.04f )
					, new Loot( typeof( WoolCloth ), 24.2f )
					, new Loot( typeof( SilkCloth ), 4.92f )
					}, 100f ) };
		}
	}
	
}