//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class VictorWard : BaseCreature 
	{ 
		public  VictorWard() : base() 
		{ 
			Model = 10580;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Victor Ward" ;
			Flags1 = 0x018480046 ;
			Id = 11048 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 24 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 984 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Victor Ward." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 22403, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 10968, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class RhiannonDavis : BaseCreature 
	{ 
		public  RhiannonDavis() : base() 
		{ 
			Model = 10581;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Rhiannon Davis" ;
			Flags1 = 0x018480046 ;
			Id = 11049 ; 
			Guild = "Expert Tailor";
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
			Level = RandomLevel( 32 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings $N, I am Rhiannon Davis." ;
			BaseMana = 0 ;
			Trains = new int[] {3913
								   ,3886
								   ,3884
								   ,8761
								   ,6691
								   ,8759
								   ,3885
								   ,3892
								   ,8763
								   ,8490
								   ,3888
								   ,3814
								   ,3893
								   ,8491
								   ,3887
								   ,8765
								   ,8773
								   ,8767
								   ,8775
								   ,3889
								   ,8807
								   ,8771
								   ,3894
								   ,8801} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23573, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 10968, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class Trianna : BaseCreature 
	{ 
		public  Trianna() : base() 
		{ 
			Model = 10582;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Trianna" ;
			Flags1 = 0x08480046 ;
			Id = 11050 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Trianna." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Vhan : BaseCreature 
	{ 
		public  Vhan() : base() 
		{ 
			Model = 10586;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Vhan" ;
			Flags1 = 0x08480046 ;
			Id = 11051 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 26 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1064 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 28, 36 );
			NpcText00 = "Greetings $N, I am Vhan." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7446, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class TimothyWorthington : BaseCreature 
	{ 
		public  TimothyWorthington() : base() 
		{ 
			Model = 10587;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Timothy Worthington" ;
			Flags1 = 0x08480046 ;
			Id = 11052 ; 
			Guild = "Master Tailor";
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
			Level = RandomLevel( 51 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2065 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 55, 72 );
			NpcText00 = "Greetings $N, I am Timothy Worthington." ;
			BaseMana = 0 ;
			Trains = new int[] {3875
								   ,12103
								   ,12105
								   ,12106
								   ,12101
								   ,12100
								   ,12102
								   ,12104
								   ,12110
								   ,12111
								   ,12113
								   ,12114
								   ,12115
								   ,12116
								   ,12117
								   ,12121
								   ,12123
								   ,12124
								   ,12126
								   ,12133
								   ,12128
								   ,12132
								   ,2408
								   ,7632
								   ,7631
								   ,6687
								   ,7635
								   ,7637
								   ,3896
								   ,3799
								   ,7640
								   ,3895
								   ,2411
								   ,6689
								   ,7644
								   ,3897
								   ,12142
								   ,7894
								   ,7895
								   ,3898
								   ,3905
								   ,3899
								   ,8779
								   ,8781
								   ,8783
								   ,3906
								   ,8785
								   ,3900
								   ,8787
								   ,6694
								   ,6701
								   ,3901
								   ,8790
								   ,3903
								   ,6696
								   ,8796
								   ,8794
								   ,8798
								   ,12137
								   ,8803
								   ,3902
								   ,3904
								   ,12138
								   ,12136
								   ,12141
								   ,12140
								   ,12145
								   ,12143
								   ,12146
								   ,12148
								   ,12147
								   ,12149
								   ,12150
								   ,18473
								   ,18472
								   ,18477
								   ,18478
								   ,18475
								   ,18474
								   ,18481
								   ,18480
								   ,18479
								   ,18487
								   ,18488
								   ,18482
								   ,18489
								   ,18494
								   ,18495
								   ,18496
								   ,18493
								   ,18490
								   ,18491
								   ,18492
								   ,18508
								   ,18507
								   ,18497
								   ,18511
								   ,18510
								   ,18509
								   ,18514
								   ,18515
								   ,18512
								   ,18513
								   ,18516
								   ,18528
								   ,18527
								   ,18526
								   ,18529
								   ,18537
								   ,18536
								   ,18532
								   ,18519
								   ,18518
								   ,18517
								   ,18521
								   ,18525
								   ,18524
								   ,18522} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class JalaneAyrole : BaseCreature 
	{ 
		public  JalaneAyrole() : base() 
		{ 
			Model = 8809;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Jalane Ayrole" ;
			Flags1 = 0x08480046 ;
			Id = 9584 ; 
			Guild = "Master Shadoweave Tailor";
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
			Level = RandomLevel( 45 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1825 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Greetings $N, I am Jalane Ayrole." ;
			BaseMana = 0 ;
			Trains = new int[] {12103
								   ,12114
								   ,12121
								   ,12126
								   ,12105} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class Sellandus : BaseCreature 
	{ 
		public  Sellandus() : base() 
		{ 
			Model = 3444;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Sellandus" ;
			Flags1 = 0x08480046 ;
			Id = 5567 ; 
			Guild = "Expert Tailor";
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
			Level = RandomLevel( 31 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1264 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 33, 43 );
			NpcText00 = "Greetings $N, I am Sellandus." ;
			BaseMana = 0 ;
			Trains = new int[] {3913
								   ,3886
								   ,3884
								   ,8761
								   ,6691
								   ,8759
								   ,3885
								   ,3892
								   ,8763
								   ,8490
								   ,3888
								   ,3814
								   ,3893
								   ,8491
								   ,3887
								   ,8765
								   ,8773
								   ,8767
								   ,8775
								   ,3889
								   ,8807
								   ,8771
								   ,3894
								   ,8801} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class JormundStonebrow : BaseCreature 
	{ 
		public  JormundStonebrow() : base() 
		{ 
			Model = 3091;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Jormund Stonebrow" ;
			Flags1 = 0x08480046 ;
			Id = 5153 ; 
			Guild = "Expert Tailor";
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
			NpcText00 = "Greetings $N, I am Jormund Stonebrow." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,3991} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7456, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class JosephineLister : BaseCreature 
	{ 
		public  JosephineLister() : base() 
		{ 
			Model = 2664;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Josephine Lister" ;
			Flags1 = 0x08400046 ;
			Id = 4578 ; 
			Guild = "Master Shadoweave Tailor";
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
			Level = RandomLevel( 45 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1825 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Greetings $N, I am Josephine Lister." ;
			BaseMana = 0 ;
			Trains = new int[] {3875
								   ,12103
								   ,12105
								   ,12106
								   ,12101
								   ,12100
								   ,12102
								   ,12104
								   ,12110
								   ,12111
								   ,12113
								   ,12114
								   ,12115
								   ,12116
								   ,12117
								   ,12121
								   ,12123
								   ,12124
								   ,12126
								   ,12133
								   ,12128
								   ,12132} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class JosefGregorian : BaseCreature 
	{ 
		public  JosefGregorian() : base() 
		{ 
			Model = 2634;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Josef Gregorian" ;
			Flags1 = 0x018480046 ;
			Id = 4576 ; 
			Guild = "Artisan Tailor";
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
			Level = RandomLevel( 45 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Josef Gregorian." ;
			BaseMana = 0 ;
			Trains = new int[] {12181
								   ,12109
								   ,8805
								   ,12122
								   ,12112
								   ,12127
								   ,12130
								   ,12131
								   ,12125
								   ,18470
								   ,12129
								   ,12135
								   ,18471
								   ,18563} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22367, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class GrondalMoonbreeze : BaseCreature 
	{ 
		public  GrondalMoonbreeze() : base() 
		{ 
			Model = 4400;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Grondal Moonbreeze" ;
			Flags1 = 0x08480046 ;
			Id = 4193 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 29 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 784 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 20, 26 );
			NpcText00 = "Greetings $N, I am Grondal Moonbreeze." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Melynn : BaseCreature 
	{ 
		public  Melynn() : base() 
		{ 
			Model = 2213;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Me'lynn" ;
			Flags1 = 0x08480046 ;
			Id = 4159 ; 
			Guild = "Expert Tailor";
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
			NpcText00 = "Greetings $N, I am Me'lynn." ;
			BaseMana = 0 ;
			Trains = new int[] {3913
								   ,3886
								   ,3884
								   ,8761
								   ,6691
								   ,8759
								   ,3885
								   ,3892
								   ,8763
								   ,8490
								   ,3888
								   ,3814
								   ,3893
								   ,8491
								   ,3887
								   ,8765
								   ,8773
								   ,8767
								   ,8775
								   ,3889
								   ,8807
								   ,8771
								   ,3894
								   ,8801} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 24596, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class Mahani : BaseCreature 
	{ 
		public  Mahani() : base() 
		{ 
			Model = 3896;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Mahani" ;
			Flags1 = 0x08400046 ;
			Id = 3704 ; 
			Guild = "Expert Tailor";
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
			Level = RandomLevel( 31 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1264 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 3.75f ;
			SetDamage ( 33, 43 );
			NpcText00 = "Greetings $N, I am Mahani." ;
			BaseMana = 0 ;
			Trains = new int[] {3913
								   ,3886
								   ,3884
								   ,8761
								   ,6691
								   ,8759
								   ,3885
								   ,3892
								   ,8763
								   ,8490
								   ,3888
								   ,3814
								   ,3893
								   ,8491
								   ,3887
								   ,8765
								   ,8773
								   ,8767
								   ,8775
								   ,3889
								   ,8807
								   ,8771
								   ,3894
								   ,8801} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class BowenBrisboise : BaseCreature 
	{ 
		public  BowenBrisboise() : base() 
		{ 
			Model = 1606;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Bowen Brisboise" ;
			Flags1 = 0x08400046 ;
			Id = 3523 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 24 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 744 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 19, 25 );
			NpcText00 = "Greetings $N, I am Bowen Brisboise." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7461, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class Kilhala : BaseCreature 
	{ 
		public  Kilhala() : base() 
		{ 
			Model = 4094;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Kil'hala" ;
			Flags1 = 0x08480046 ;
			Id = 3484 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Kil'hala." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23573, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Magar : BaseCreature 
	{ 
		public  Magar() : base() 
		{ 
			Model = 1385;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Magar" ;
			Flags1 = 0x08480046 ;
			Id = 3363 ; 
			Guild = "Expert Tailor";
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
			BaseHitPoints = 1504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 40, 52 );
			NpcText00 = "Greetings $N, I am Magar." ;
			BaseMana = 0 ;
			Trains = new int[] {3913
								   ,3886
								   ,3884
								   ,8761
								   ,6691
								   ,8759
								   ,3885
								   ,3892
								   ,8763
								   ,8490
								   ,3888
								   ,3814
								   ,3893
								   ,8491
								   ,3887
								   ,8765
								   ,8773
								   ,8767
								   ,8775
								   ,3889
								   ,8807
								   ,8771
								   ,3894
								   ,8801} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Tepa : BaseCreature 
	{ 
		public  Tepa() : base() 
		{ 
			Model = 2126;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Tepa" ;
			Flags1 = 0x08480046 ;
			Id = 3004 ; 
			Guild = "Expert Tailor";
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
			CombatReach = 3.75f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Tepa." ;
			BaseMana = 0 ;
			Trains = new int[] {3913
								   ,3886
								   ,3884
								   ,8761
								   ,6691
								   ,8759
								   ,3885
								   ,3892
								   ,8763
								   ,8490
								   ,3888
								   ,3814
								   ,3893
								   ,8491
								   ,3887
								   ,8765
								   ,8773
								   ,8767
								   ,8775
								   ,3889
								   ,8807
								   ,8771
								   ,3894
								   ,8801} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Snang : BaseCreature 
	{ 
		public  Snang() : base() 
		{ 
			Model = 4384;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Snang" ;
			Flags1 = 0x08480046 ;
			Id = 2855 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 24 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 984 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Snang." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7446, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
		}
	}
	public class GrarnikGoodstitch : BaseCreature 
	{ 
		public  GrarnikGoodstitch() : base() 
		{ 
			Model = 7176;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Grarnik Goodstitch" ;
			Flags1 = 0x08080046 ;
			Id = 2627 ; 
			Guild = "Expert Tailor";
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
			Level = RandomLevel( 34 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1545 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 41, 53 );
			NpcText00 = "Greetings $N, I am Grarnik Goodstitch." ;
			BaseMana = 0 ;
			Trains = new int[] {3913
								   ,3886
								   ,3884
								   ,8761
								   ,6691
								   ,8759
								   ,3885
								   ,3892
								   ,8763
								   ,8490
								   ,3888
								   ,3814
								   ,3893
								   ,8491
								   ,3887
								   ,8765
								   ,8773
								   ,8767
								   ,8775
								   ,3889
								   ,8807
								   ,8771
								   ,3894
								   ,8801} ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class DarylStack : BaseCreature 
	{ 
		public  DarylStack() : base() 
		{ 
			Model = 3655;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Daryl Stack" ;
			Flags1 = 0x08400046 ;
			Id = 2399 ; 
			Guild = "Master Tailor";
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
			Level = RandomLevel( 56 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 2266 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 61, 79 );
			NpcText00 = "Greetings $N, I am Daryl Stack." ;
			BaseMana = 0 ;
			Trains = new int[] {3911
								   ,8468
								   ,3917
								   ,12118
								   ,2415
								   ,2996
								   ,12119
								   ,8777
								   ,7627
								   ,3916
								   ,7626
								   ,3876
								   ,2416
								   ,8466
								   ,2414
								   ,3783
								   ,3912
								   ,3877
								   ,2419
								   ,2967
								   ,2966
								   ,2418
								   ,3878
								   ,2417
								   ,12120
								   ,2423
								   ,3785
								   ,3880
								   ,2421
								   ,3879
								   ,2424
								   ,6522
								   ,2422
								   ,8468
								   ,3882
								   ,3890
								   ,3874
								   ,3881
								   ,3891} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class UthrarThrex : BaseCreature 
	{ 
		public  UthrarThrex() : base() 
		{ 
			Model = 10629;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Uthrar Threx" ;
			Flags1 = 0x08480046 ;
			Id = 1703 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 24 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 984 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Uthrar Threx." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 22367, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ),new Item( 6593, InventoryTypes.HeldInHand, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class GeorgioBolero : BaseCreature 
	{ 
		public  GeorgioBolero() : base() 
		{ 
			Model = 1502;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Georgio Bolero" ;
			Flags1 = 0x08480046 ;
			Id = 1346 ; 
			Guild = "Artisan Tailor";
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
			Level = RandomLevel( 46 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Georgio Bolero." ;
			BaseMana = 0 ;
			Trains = new int[] {3879
								   ,12102
								   ,12104
								   ,12110
								   ,12112
								   ,12113
								   ,12111
								   ,3881
								   ,2424
								   ,2422
								   ,2421
								   ,8761
								   ,8759
								   ,8777
								   ,8468
								   ,8466
								   ,7627
								   ,7626
								   ,6691
								   ,3783
								   ,3875
								   ,3893
								   ,3888
								   ,3884
								   ,3874
								   ,3886
								   ,3890
								   ,3882
								   ,8807
								   ,8805
								   ,8801
								   ,8775
								   ,8773
								   ,8771
								   ,8767
								   ,8765
								   ,8763
								   ,3880
								   ,2423
								   ,2966
								   ,2418
								   ,2417
								   ,3878
								   ,2419
								   ,2996
								   ,3916
								   ,3913
								   ,3912
								   ,3889
								   ,12119
								   ,8491
								   ,8490
								   ,3911
								   ,3877
								   ,2416
								   ,2415
								   ,2414
								   ,2967
								   ,3876
								   ,3785
								   ,3814
								   ,6522
								   ,12106
								   ,12101
								   ,12120
								   ,12100} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class LawrenceSchneider : BaseCreature 
	{ 
		public  LawrenceSchneider() : base() 
		{ 
			Model = 1432;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Lawrence Schneider" ;
			Flags1 = 0x08480046 ;
			Id = 1300 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Lawrence Schneider." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Eldrin : BaseCreature 
	{ 
		public  Eldrin() : base() 
		{ 
			Model = 1290;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Eldrin" ;
			Flags1 = 0x08480046 ;
			Id = 1103 ; 
			Guild = "Journeyman Tailor";
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
			Level = RandomLevel( 22 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Eldrin." ;
			BaseMana = 0 ;
			Trains = new int[] {3916
								   ,2416
								   ,2419
								   ,2417
								   ,3911
								   ,8777
								   ,8466
								   ,7627
								   ,7626
								   ,3783
								   ,12120
								   ,12119
								   ,2423
								   ,2966
								   ,2418
								   ,3878
								   ,3877
								   ,2415
								   ,3876
								   ,2967
								   ,2414
								   ,2996
								   ,3912} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	
}