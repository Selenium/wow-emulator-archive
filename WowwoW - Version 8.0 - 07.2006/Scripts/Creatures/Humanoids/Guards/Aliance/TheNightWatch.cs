using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class WatcherBrownell : BaseCreature
	{
		public WatcherBrownell() : base()
		{
			Id = 11040;
			Level = RandomLevel( 30 );
			Name = "Watcher Brownell";
			Guild = "The Night Watch";
			Model = 10455;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 852;
			NpcFlags = (int)NpcActions.Vendor;
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Sells = new Item[] { new Server.Items.SmallShield17184()
				, new Server.Items.LargeRoundShield()
				, new Server.Items.SmallShield()
				, new Server.Items.TarnishedChainVest()
				, new Server.Items.TarnishedChainBelt()
				, new Server.Items.TarnishedChainLeggings()
				, new Server.Items.TarnishedChainBoots()
				, new Server.Items.TarnishedChainBracers()
				, new Server.Items.TarnishedChainGloves()
			 };
			Equip( new Item ( 23508, (InventoryTypes)13, 2, 8, 1, 1, 0, 0, 0) );
			 Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherWollpert : BaseCreature
	{
		public WatcherWollpert() : base()
		{
			Id = 8310;
			Level = RandomLevel( 37 );
			Name = "Watcher Wollpert";
			Guild = "The Night Watch";
			Model = 7537;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherFraizer : BaseCreature
	{
		public WatcherFraizer() : base()
		{
			Id = 2470;
			Level = RandomLevel( 37 );
			Name = "Watcher Fraizer";
			Guild = "The Night Watch";
			Model = 9232;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherFraizer, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherCallahan : BaseNPC
	{
		public WatcherCallahan() : base()
		{
			Id = 2142;
			Level = RandomLevel( 32 );
			Name = "Watcher Callahan";
			Guild = "The Night Watch";
			NpcText00 = "Greetings $N, I am Watcher Callahan.";
			Model = 2377;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherCutford : BaseCreature
	{
		public WatcherCutford() : base()
		{
			Id = 1436;
			Level = RandomLevel( 37 );
			Name = "Watcher Cutford";
			Guild = "The Night Watch";
			Model = 2383;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherCutford, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherSarys : BaseCreature
	{
		public WatcherSarys() : base()
		{
			Id = 1203;
			Level = RandomLevel( 35 );
			Name = "Watcher Sarys";
			Guild = "The Night Watch";
			Model = 2399;
			AttackSpeed = 1623;
			CombatReach = 0.6f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1754;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherCorwin : BaseCreature
	{
		public WatcherCorwin() : base()
		{
			Id = 1204;
			Level = RandomLevel( 38 );
			Name = "Watcher Corwin";
			Guild = "The Night Watch";
			Model = 2382;
			AttackSpeed = 1581;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1904;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherMerant : BaseCreature
	{
		public WatcherMerant() : base()
		{
			Id = 1098;
			Level = RandomLevel( 50 );
			Name = "Watcher Merant";
			Guild = "The Night Watch";
			Model = 2394;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class WatcherGelwin : BaseCreature
	{
		public WatcherGelwin() : base()
		{
			Id = 1099;
			Level = RandomLevel( 20 );
			Name = "Watcher Gelwin";
			Guild = "The Night Watch";
			Model = 2386;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherSelkin : BaseCreature
	{
		public WatcherSelkin() : base()
		{
			Id = 1100;
			Level = RandomLevel( 20 );
			Name = "Watcher Selkin";
			Guild = "The Night Watch";
			Model = 2400;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherThayer : BaseCreature
	{
		public WatcherThayer() : base()
		{
			Id = 1101;
			Level = RandomLevel( 20 );
			Name = "Watcher Thayer";
			Guild = "The Night Watch";
			Model = 2401;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherRoyce : BaseCreature
	{
		public WatcherRoyce() : base()
		{
			Id = 999;
			Level = RandomLevel( 37 );
			Name = "Watcher Royce";
			Guild = "The Night Watch";
			Model = 2398;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherRoyce, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this ); 
               }
	}

 	public class WatcherBlomberg : BaseCreature
	{
		public WatcherBlomberg() : base()
		{
			Id = 1000;
			Level = RandomLevel( 20 );
			Name = "Watcher Blomberg";
			Guild = "The Night Watch";
			Model = 2381;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherHutchins : BaseCreature
	{
		public WatcherHutchins() : base()
		{
			Id = 1001;
			Level = RandomLevel( 20 );
			Name = "Watcher Hutchins";
			Guild = "The Night Watch";
			Model = 2388;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherHutchins, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherKeller : BaseCreature
	{
		public WatcherKeller() : base()
		{
			Id = 885;
			Level = RandomLevel( 39 );
			Name = "Watcher Keller";
			Guild = "The Night Watch";
			Model = 2392;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherKeller, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherHartin : BaseCreature
	{
		public WatcherHartin() : base()
		{
			Id = 886;
			Level = RandomLevel( 38 );
			Name = "Watcher Hartin";
			Guild = "The Night Watch";
			Model = 2387;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherHartin, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherJordan : BaseCreature
	{
		public WatcherJordan() : base()
		{
			Id = 887;
			Level = RandomLevel( 39 );
			Name = "Watcher Jordan";
			Guild = "The Night Watch";
			Model = 2390;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherJordan, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherDodds : BaseNPC
	{
		public WatcherDodds() : base()
		{
			Id = 888;
			Level = RandomLevel( 29 );
			Name = "Watcher Dodds";
			Guild = "The Night Watch";
			NpcText00 = "Greetings $N, I am Watcher Dodds.";
			Model = 2384;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherBackus : BaseNPC
	{
		public WatcherBackus() : base()
		{
			Id = 840;
			Level = RandomLevel( 42 );
			Name = "Watcher Backus";
			Guild = "The Night Watch";
			NpcText00 = "Greetings $N, I am Watcher Backus.";
			Model = 2380;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherJan : BaseCreature
	{
		public WatcherJan() : base()
		{
			Id = 826;
			Level = RandomLevel( 39 );
			Name = "Watcher Jan";
			Guild = "The Night Watch";
			Model = 2389;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherJan, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherMocarski : BaseCreature
	{
		public WatcherMocarski() : base()
		{
			Id = 827;
			Level = RandomLevel( 38 );
			Name = "Watcher Mocarski";
			Guild = "The Night Watch";
			Model = 2395;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherMocarski, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherPetras : BaseCreature
	{
		public WatcherPetras() : base()
		{
			Id = 828;
			Level = RandomLevel( 38 );
			Name = "Watcher Petras";
			Guild = "The Night Watch";
			Model = 2397;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherPetras, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherLadimore : BaseNPC
	{
		public WatcherLadimore() : base()
		{
			Id = 576;
			Level = RandomLevel( 28 );
			Name = "Watcher Ladimore";
			Guild = "The Night Watch";
			NpcText00 = "Greetings $N, I am Watcher Ladimore.";
			Model = 2375;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherWollpert, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherKeefer : BaseCreature
	{
		public WatcherKeefer() : base()
		{
			Id = 495;
			Level = RandomLevel( 40 );
			Name = "Watcher Keefer";
			Guild = "The Night Watch";
			Model = 2391;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherKeefer, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherPaige : BaseCreature
	{
		public WatcherPaige() : base()
		{
			Id = 499;
			Level = RandomLevel( 29 );
			Name = "Watcher Paige";
			Guild = "The Night Watch";
			Model = 2396;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 0;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherPaige, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class WatcherBukouris : BaseCreature
	{
		public WatcherBukouris() : base()
		{
			Id = 494;
			Level = RandomLevel( 37 );
			Name = "Watcher Bukouris";
			Guild = "The Night Watch";
			NpcText00 = "Greetings $N, I am Watcher Bukouris.";
			Model = 2379;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			// NpcFlags = 16389;
			Flags1 = 0x0480002;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.WatcherBukouris, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	public class CommanderAltheaEbonlocke : BaseNPC
	{
		public CommanderAltheaEbonlocke() : base()
		{
			Id = 264;
			Level = RandomLevel( 45 );
			Name = "Commander Althea Ebonlocke";
			Guild = "Leader of The Night Watch";
			NpcText00 = "Greetings $N, I am Commander Althea Ebonlocke.";
			Model = 4322;
			AttackSpeed = 1000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;

			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid ;
			Faction = Factions.Stormwind;
			Equip( new Item ( 7420, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{  new BaseTreasure( NightWatchDrops.CommanderAltheaEbonlocke, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
                {
                        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );                }
 	}
	
	
	
	
}