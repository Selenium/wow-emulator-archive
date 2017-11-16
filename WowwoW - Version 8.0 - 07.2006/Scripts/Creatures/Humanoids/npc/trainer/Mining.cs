//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class KurdramStonehammer : BaseCreature 
	{ 
		public  KurdramStonehammer() : base() 
		{ 
			Model = 5019;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Kurdram Stonehammer" ;
			Flags1 = 0x08480046 ;
			Id = 6297 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Kurdram Stonehammer." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class GelmanStonehand : BaseCreature 
	{ 
		public  GelmanStonehand() : base() 
		{ 
			Model = 3308;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Gelman Stonehand" ;
			Flags1 = 0x08480046 ;
			Id = 5513 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1705 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 46, 59 );
			NpcText00 = "Greetings $N, I am Gelman Stonehand." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 20726, InventoryTypes.RangeRight, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class YarrHammerstone : BaseCreature 
	{ 
		public  YarrHammerstone() : base() 
		{ 
			Model = 3396;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Yarr Hammerstone" ;
			Flags1 = 0x08480046 ;
			Id = 5392 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 10 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Yarr Hammerstone." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class BromKillian : BaseCreature 
	{ 
		public  BromKillian() : base() 
		{ 
			Model = 2617;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Brom Killian" ;
			Flags1 = 0x018480046 ;
			Id = 4598 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Brom Killian." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class GeoframBouldertoe : BaseCreature 
	{ 
		public  GeoframBouldertoe() : base() 
		{ 
			Model = 3092;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Geofram Bouldertoe" ;
			Flags1 = 0x08480046 ;
			Id = 4254 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Geofram Bouldertoe." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ),new Item( 1706, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class Makaru : BaseCreature 
	{ 
		public  Makaru() : base() 
		{ 
			Model = 1379;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Makaru" ;
			Flags1 = 0x08480046 ;
			Id = 3357 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Makaru." ;
			BaseMana = 0 ;
			Trains = new int[] {10249
								   ,2582
								   ,2581
								   ,2659
								   ,10097
								   ,16154
								   ,10098
								   ,3568
								   ,3569
								   ,3307
								   ,3308
								   ,3304
								   ,2658
								   ,10249
								   ,2582
								   ,2581
								   ,2659
								   ,10097
								   ,16154
								   ,10098
								   ,3568
								   ,3569
								   ,3307
								   ,3308
								   ,3304
								   ,2658} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class Krunn : BaseCreature 
	{ 
		public  Krunn() : base() 
		{ 
			Model = 3748;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Krunn" ;
			Flags1 = 0x08480046 ;
			Id = 3175 ; 
			Guild = "Miner";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 16 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 664 ;
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 1.5f ;
			SetDamage ( 17, 22 );
			NpcText00 = "Greetings $N, I am Krunn." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2659
								   ,16154
								   ,10098
								   ,10097
								   ,10249
								   ,3569
								   ,3568
								   ,3307
								   ,3308
								   ,3304
								   ,2582} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class MattJohnson : BaseCreature 
	{ 
		public  MattJohnson() : base() 
		{ 
			Model = 4333;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Matt Johnson" ;
			Flags1 = 0x08480046 ;
			Id = 3137 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 20 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 824 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Greetings $N, I am Matt Johnson." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class DankDrizzlecut : BaseCreature 
	{ 
		public  DankDrizzlecut() : base() 
		{ 
			Model = 3424;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Dank Drizzlecut" ;
			Flags1 = 0x08480046 ;
			Id = 1701 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 10 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Dank Drizzlecut." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class BrockStoneseeker : BaseCreature 
	{ 
		public  BrockStoneseeker() : base() 
		{ 
			Model = 1822;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Brock Stoneseeker" ;
			Flags1 = 0x08480046 ;
			Id = 1681 ; 
			Guild = "Mining Trainer";
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 15 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 624 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings $N, I am Brock Stoneseeker." ;
			BaseMana = 0 ;
			Trains = new int[] {2581
								   ,2658
								   ,2582
								   ,2659
								   ,3568
								   ,10097
								   ,16154
								   ,10098
								   ,10249
								   ,3569
								   ,3307
								   ,3308
								   ,3304} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	
}