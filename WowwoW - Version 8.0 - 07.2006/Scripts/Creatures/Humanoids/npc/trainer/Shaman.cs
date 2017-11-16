//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Siantsu : BaseCreature 
	{ 
		public  Siantsu() : base() 
		{ 
			Model = 4231;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Sian'tsu" ;
			Flags1 = 0x08480046 ;
			Id = 3403 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Sian'tsu." ;
			BaseMana = 0 ;
			Trains = new int[] {8738
								   ,20778
								   ,20781
								   ,8164
								   ,8158
								   ,8144
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,6401
								   ,6400
								   ,1345
								   ,10625
								   ,10624
								   ,1444
								   ,1338
								   ,20613
								   ,10446
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,8159
								   ,8165
								   ,8135
								   ,20780} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 5527, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
		}
	}
	public class Grelkor : BaseCreature 
	{ 
		public  Grelkor() : base() 
		{ 
			Model = 1359;
			AttackSpeed= 1413;
			BoundingRadius = 1.00f ;
			Name = "Grelkor" ;
			Flags1 = 0x08400046 ;
			Id = 3343 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 50 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 11.00f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Grelkor." ;
			BaseMana = 0 ;
			Trains = new int[] {8738
								   ,20778
								   ,20781
								   ,8164
								   ,8158
								   ,8144
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,6401
								   ,6400
								   ,1345
								   ,10625
								   ,10624
								   ,1444
								   ,1338
								   ,20613
								   ,10446
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,8159
								   ,8165
								   ,8135
								   ,20780
								   ,20779} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class KardrisDreamseeker : BaseCreature 
	{ 
		public  KardrisDreamseeker() : base() 
		{ 
			Model = 1360;
			AttackSpeed= 1739;
			BoundingRadius = 0.236000f ;
			Name = "Kardris Dreamseeker" ;
			Flags1 = 0x08480046 ;
			Id = 3344 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 60 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings $N, I am Kardris Dreamseeker." ;
			BaseMana = 0 ;
			Trains = new int[] {1338
								   ,20613
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10446
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,8144
								   ,8159
								   ,8158
								   ,8165
								   ,8164
								   ,8135
								   ,20781
								   ,20780
								   ,20779
								   ,20778
								   ,8738
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,6401
								   ,6400
								   ,1345
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,1444
								   ,10625} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class Swart : BaseCreature 
	{ 
		public  Swart() : base() 
		{ 
			Model = 3746;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Swart" ;
			Flags1 = 0x08480046 ;
			Id = 3173 ; 
			Guild = "Shaman Trainer";
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
			NpcText00 = "Greetings $N, I am Swart." ;
			BaseMana = 0 ;
			Trains = new int[] {8738
								   ,20778
								   ,20781
								   ,8164
								   ,8158
								   ,8144
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,6401
								   ,6400
								   ,1345
								   ,10625
								   ,10624
								   ,1444
								   ,1338
								   ,20613
								   ,10446
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,8159
								   ,8165
								   ,8135
								   ,20780
								   ,20779} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 11289, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class Shikrik : BaseCreature 
	{ 
		public  Shikrik() : base() 
		{ 
			Model = 1878;
			AttackSpeed= 2000;
			BoundingRadius = 0.236000f ;
			Name = "Shikrik" ;
			Flags1 = 0x08080066 ;
			Id = 3157 ; 
			Guild = "Shaman Trainer";
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
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Shikrik." ;
			BaseMana = 0 ;
			Trains = new int[] {8020
								   ,2076
								   ,1326
								   ,8043} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7478, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class NarmSkychaser : BaseCreature 
	{ 
		public  NarmSkychaser() : base() 
		{ 
			Model = 3816;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Narm Skychaser" ;
			Flags1 = 0x08480046 ;
			Id = 3066 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 13 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Narm Skychaser." ;
			BaseMana = 0 ;
			Trains = new int[] {8738
								   ,20778
								   ,20781
								   ,8164
								   ,8158
								   ,8144
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,6401
								   ,6400
								   ,1345
								   ,10625
								   ,10624
								   ,1444
								   ,1338
								   ,20613
								   ,10446
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,8159
								   ,8165
								   ,8135
								   ,20780
								   ,20779} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7440, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class MeelaDawnstrider : BaseCreature 
	{ 
		public  MeelaDawnstrider() : base() 
		{ 
			Model = 10180;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Meela Dawnstrider" ;
			Flags1 = 0x08080066 ;
			Id = 3062 ; 
			Guild = "Shaman Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Meela Dawnstrider." ;
			BaseMana = 0 ;
			Trains = new int[] {8020
								   ,2076
								   ,1326
								   ,8043} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class SilnSkychaser : BaseCreature 
	{ 
		public  SilnSkychaser() : base() 
		{ 
			Model = 2123;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Siln Skychaser" ;
			Flags1 = 0x08480046 ;
			Id = 3030 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 50 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 3.75f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Siln Skychaser." ;
			BaseMana = 0 ;
			Trains = new int[] {8738
								   ,20778
								   ,20781
								   ,8164
								   ,8158
								   ,8144
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,6401
								   ,6400
								   ,1345
								   ,10625
								   ,10624
								   ,1444
								   ,1338
								   ,20613
								   ,10446
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,8159
								   ,8165
								   ,8135
								   ,20780
								   ,20779} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class TigorSkychaser : BaseCreature 
	{ 
		public  TigorSkychaser() : base() 
		{ 
			Model = 2102;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Tigor Skychaser" ;
			Flags1 = 0x08480046 ;
			Id = 3031 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Tigor Skychaser." ;
			BaseMana = 0 ;
			Trains = new int[] {1338
								   ,20613
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10446
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,8144
								   ,8159
								   ,8158
								   ,8165
								   ,8164
								   ,8135
								   ,20781
								   ,20780
								   ,20779
								   ,20778
								   ,8738
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,6401
								   ,6400
								   ,1345
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,1444
								   ,10625} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 5098, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class BeramSkychaser : BaseCreature 
	{ 
		public  BeramSkychaser() : base() 
		{ 
			Model = 2082;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Beram Skychaser" ;
			Flags1 = 0x08480046 ;
			Id = 3032 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 60 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2426 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Beram Skychaser." ;
			BaseMana = 0 ;
			Trains = new int[] {8738
								   ,20778
								   ,20781
								   ,8164
								   ,8158
								   ,8144
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,6401
								   ,6400
								   ,1345
								   ,10625
								   ,10624
								   ,1444
								   ,1338
								   ,20613
								   ,10446
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,8159
								   ,8165
								   ,8135
								   ,20780
								   ,20779} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5224, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class Haromm : BaseCreature 
	{ 
		public  Haromm() : base() 
		{ 
			Model = 4552;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Haromm" ;
			Flags1 = 0x08400046 ;
			Id = 986 ; 
			Guild = "Shaman Trainer";
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
			Level = RandomLevel( 50 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Haromm." ;
			BaseMana = 0 ;
			Trains = new int[] {8738
								   ,20778
								   ,20781
								   ,8164
								   ,8158
								   ,8144
								   ,16357
								   ,8234
								   ,8237
								   ,8231
								   ,8173
								   ,8186
								   ,8189
								   ,8183
								   ,8169
								   ,6401
								   ,6400
								   ,1345
								   ,10625
								   ,10624
								   ,1444
								   ,1338
								   ,20613
								   ,10446
								   ,15115
								   ,6496
								   ,8043
								   ,6381
								   ,6380
								   ,6379
								   ,6384
								   ,6383
								   ,6402
								   ,16317
								   ,16318
								   ,10402
								   ,17363
								   ,17362
								   ,16363
								   ,10488
								   ,16358
								   ,1356
								   ,8006
								   ,5731
								   ,5678
								   ,10616
								   ,16394
								   ,10528
								   ,16348
								   ,16347
								   ,10443
								   ,10440
								   ,10439
								   ,10465
								   ,10464
								   ,10398
								   ,10397
								   ,10434
								   ,10433
								   ,10430
								   ,10429
								   ,10457
								   ,10590
								   ,10589
								   ,10475
								   ,10474
								   ,10615
								   ,10471
								   ,10470
								   ,10469
								   ,10401
								   ,10603
								   ,10602
								   ,10394
								   ,10393
								   ,6043
								   ,10541
								   ,10540
								   ,8252
								   ,10628
								   ,8837
								   ,10450
								   ,10449
								   ,2863
								   ,2862
								   ,1340
								   ,10481
								   ,10480
								   ,10588
								   ,10417
								   ,10416
								   ,10415
								   ,10515
								   ,10514
								   ,10512
								   ,10411
								   ,10410
								   ,10409
								   ,8513
								   ,10597
								   ,8180
								   ,1357
								   ,1354
								   ,1305
								   ,8039
								   ,8031
								   ,8025
								   ,1325
								   ,1327
								   ,8021
								   ,1333
								   ,1304
								   ,1326
								   ,1324
								   ,2874
								   ,2014
								   ,8020
								   ,1315
								   ,8022
								   ,1303
								   ,8013
								   ,8059
								   ,5387
								   ,5386
								   ,1339
								   ,8057
								   ,8077
								   ,1355
								   ,1358
								   ,8011
								   ,8009
								   ,1363
								   ,8007
								   ,8049
								   ,1352
								   ,2076
								   ,8035
								   ,8055
								   ,8054
								   ,11317
								   ,11316
								   ,8501
								   ,8500
								   ,8086
								   ,8051
								   ,8032
								   ,8048
								   ,8047
								   ,15116
								   ,15113
								   ,15210
								   ,15209
								   ,8159
								   ,8165
								   ,8135
								   ,20780
								   ,20779} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	
}