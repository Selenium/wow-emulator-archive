//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;
using Server.Quests;

////////////////////
namespace Server.Creatures
{
	public class GroumStonebeard : BaseCreature 
	{ 
		public  GroumStonebeard() : base() 
		{ 
			Model = 9740;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Groum Stonebeard" ;
			Flags1 = 0x08480046 ;
			Id = 10277 ; 
			Guild = "Journeyman Blacksmith";
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
			NpcText00 = "Greetings $N, I am Groum Stonebeard." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class ThragStonehoof : BaseCreature 
	{ 
		public  ThragStonehoof() : base() 
		{ 
			Model = 9742;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Thrag Stonehoof" ;
			Flags1 = 0x08480046 ;
			Id = 10278 ; 
			Guild = "Journeyman Blacksmith";
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
			CombatReach = 4.05f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Thrag Stonehoof." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class RotgathStonebeard : BaseCreature 
	{ 
		public  RotgathStonebeard() : base() 
		{ 
			Model = 9741;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Rotgath Stonebeard" ;
			Flags1 = 0x08480046 ;
			Id = 10276 ; 
			Guild = "Expert Blacksmith";
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
			NpcText00 = "Greetings $N, I am Rotgath Stonebeard." ;
			BaseMana = 0 ;
			Trains = new int[] {2021
								   ,3539
								   ,2665
								   ,3116
								   ,7408
								   ,2666
								   ,3294
								   ,3326
								   ,2664
								   ,3292
								   ,7817
								   ,3491
								   ,7818
								   ,19666
								   ,2670
								   ,2668
								   ,3328
								   ,2740
								   ,2741
								   ,6517
								   ,2742
								   ,2672
								   ,9985
								   ,3337
								   ,2752
								   ,3117
								   ,9986
								   ,3296
								   ,3331
								   ,9987
								   ,3333
								   ,2675
								   ,14379
								   ,19667
								   ,8768} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 7439, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}

	public class Ugthok : BaseCreature 
	{ 
		public  Ugthok() : base() 
		{ 
			Model = 9739;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Ug'thok" ;
			Flags1 = 0x08480046 ;
			Id = 10266 ; 
			Guild = "Journeyman Blacksmith";
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
			NpcText00 = "Greetings $N, I am Ug'thok." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 8078, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ));
		}
	}
	public class DelfrumFlintbeard : BaseCreature 
	{ 
		public  DelfrumFlintbeard() : base() 
		{ 
			Model = 5021;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Delfrum Flintbeard" ;
			Flags1 = 0x08480046 ;
			Id = 6299 ; 
			Guild = "Journeyman Blacksmith";
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
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Delfrum Flintbeard." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class TherumDeepforge : BaseCreature 
	{ 
		public  TherumDeepforge() : base() 
		{ 
			Model = 3307;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Therum Deepforge" ;
			Flags1 = 0x08480046 ;
			Id = 5511 ; 
			Guild = "Expert Blacksmith";
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
			Level = RandomLevel( 33 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Therum Deepforge." ;
			BaseMana = 0 ;
			Trains = new int[] {2021
								   ,3539
								   ,2665
								   ,3116
								   ,7408
								   ,2666
								   ,3294
								   ,3326
								   ,2664
								   ,3292
								   ,7817
								   ,3491
								   ,7818
								   ,19666
								   ,2670
								   ,2668
								   ,3328
								   ,2740
								   ,2741
								   ,6517
								   ,2742
								   ,2672
								   ,9985
								   ,3337
								   ,2752
								   ,3117
								   ,9986
								   ,3296
								   ,3331
								   ,9987
								   ,3333
								   ,2675
								   ,14379
								   ,19667
								   ,8768} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class BasilFrye : BaseCreature 
	{ 
		public  BasilFrye() : base() 
		{ 
			Model = 2615;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Basil Frye" ;
			Flags1 = 0x018480046 ;
			Id = 4605 ; 
			Guild = "Journeyman Blacksmith";
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
			BaseHitPoints = 1144 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 30, 39 );
			NpcText00 = "Greetings $N, I am Basil Frye." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class JamesVanBrunt : BaseCreature 
	{ 
		public  JamesVanBrunt() : base() 
		{ 
			Model = 2632;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "James Van Brunt" ;
			Flags1 = 0x018480046 ;
			Id = 4596 ; 
			Guild = "Expert Blacksmith";
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
			NpcText00 = "Greetings $N, I am James Van Brunt." ;
			BaseMana = 0 ;
			Trains = new int[] {2021
								   ,3539
								   ,2665
								   ,3116
								   ,7408
								   ,2666
								   ,3294
								   ,3326
								   ,2664
								   ,3292
								   ,7817
								   ,3491
								   ,7818
								   ,19666
								   ,2670
								   ,2668
								   ,3328
								   ,2740
								   ,2741
								   ,6517
								   ,2742
								   ,2672
								   ,9985
								   ,3337
								   ,2752
								   ,3117
								   ,9986
								   ,3296
								   ,3331
								   ,9987
								   ,3333
								   ,2675
								   ,14379
								   ,19667
								   ,8768} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 8078, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ));
		}
	}
	public class BengusDeepforge : BaseCreature 
	{ 
		public  BengusDeepforge() : base() 
		{ 
			Model = 3097;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Bengus Deepforge" ;
			Flags1 = 0x08480046 ;
			Id = 4258 ; 
			Guild = "Artisan Blacksmith";
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
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Bengus Deepforge." ;
			BaseMana = 0 ;
			Trains = new int[] {9786
								   ,9788
								   ,9789
								   ,11454
								   ,3515
								   ,9928
								   ,9926
								   ,3497
								   ,11643
								   ,3500
								   ,9916
								   ,9933
								   ,9931
								   ,9993
								   ,9935
								   ,9937
								   ,9939
								   ,9950
								   ,9945
								   ,9942
								   ,9996
								   ,9954
								   ,9952
								   ,9997
								   ,9959
								   ,9957
								   ,9961
								   ,9970
								   ,9968
								   ,16640
								   ,16639
								   ,16641
								   ,9966
								   ,9964
								   ,10001
								   ,10003
								   ,9972
								   ,9974
								   ,10005
								   ,9979
								   ,9980
								   ,10007
								   ,16643
								   ,10009
								   ,16642
								   ,10011
								   ,16644
								   ,16645
								   ,10013
								   ,16960
								   ,16647
								   ,16646
								   ,15292
								   ,10015
								   ,16650
								   ,15293
								   ,16648
								   ,16649
								   ,16965
								   ,16967
								   ,15294
								   ,16651
								   ,16970
								   ,16652
								   ,16653
								   ,15295
								   ,16969
								   ,16978
								   ,16973
								   ,16971
								   ,16667
								   ,15296
								   ,16654
								   ,16655
								   ,16660
								   ,16656
								   ,16983
								   ,16980
								   ,16984
								   ,16985
								   ,16661
								   ,16659
								   ,16659
								   ,16657
								   ,16658
								   ,16665
								   ,16724
								   ,16725
								   ,16662
								   ,16663
								   ,16664
								   ,16726
								   ,16741
								   ,16746
								   ,16742
								   ,16745
								   ,16744
								   ,16728
								   ,16730
								   ,16729
								   ,16732
								   ,16731
								   ,16994
								   ,16995
								   ,16993
								   ,16988
								   ,16987
								   ,16986
								   ,16992
								   ,16991
								   ,16990} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 20736, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class GuillaumeSorouy : BaseCreature 
	{ 
		public  GuillaumeSorouy() : base() 
		{ 
			Model = 3549;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Guillaume Sorouy" ;
			Flags1 = 0x08480046 ;
			Id = 3557 ; 
			Guild = "Journeyman Blacksmith";
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
			Level = RandomLevel( 28 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Guillaume Sorouy." ;
			BaseMana = 0 ;
			Trains = new int[] {2659
								   ,10097
								   ,16153
								   ,10098
								   ,3569
								   ,3307
								   ,3308
								   ,3304
								   ,2658
								   ,2659
								   ,10097
								   ,16153
								   ,10098
								   ,3569
								   ,3307
								   ,3308
								   ,3304
								   ,2658} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class Traugh : BaseCreature 
	{ 
		public  Traugh() : base() 
		{ 
			Model = 3865;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Traugh" ;
			Flags1 = 0x08480046 ;
			Id = 3478 ; 
			Guild = "Journeyman Blacksmith";
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
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 33, 43 );
			NpcText00 = "Greetings $N, I am Traugh." ;
			BaseMana = 0 ;
			Trains = new int[] {2021
								   ,3539
								   ,2665
								   ,3116
								   ,7408
								   ,2666
								   ,3294
								   ,3326
								   ,2664
								   ,3292
								   ,7817
								   ,3491
								   ,7818
								   ,19666
								   ,2670
								   ,2668
								   ,3328
								   ,2740
								   ,2741
								   ,6517
								   ,2742
								   ,2672
								   ,9985
								   ,3337
								   ,2752
								   ,3117
								   ,9986
								   ,3296
								   ,3331
								   ,9987
								   ,3333
								   ,2675
								   ,14379
								   ,19667
								   ,8768} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class SaruSteelfury : BaseCreature 
	{ 
		public  SaruSteelfury() : base() 
		{ 
			Model = 1377;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Saru Steelfury" ;
			Flags1 = 0x08480046 ;
			Id = 3355 ; 
			Guild = "Artisan Blacksmith";
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
			NpcText00 = "Greetings $N, I am Saru Steelfury." ;
			BaseMana = 0 ;
			Trains = new int[] {9786
								   ,9788
								   ,9789
								   ,11454
								   ,3515
								   ,9928
								   ,9926
								   ,3497
								   ,11643
								   ,3500
								   ,9916
								   ,9933
								   ,9931
								   ,9993
								   ,9935
								   ,9937
								   ,9939
								   ,9950
								   ,9945
								   ,9942
								   ,9996
								   ,9954
								   ,9952
								   ,9997
								   ,9959
								   ,9957
								   ,9961
								   ,9970
								   ,9968
								   ,16640
								   ,16639
								   ,16641
								   ,9966
								   ,9964
								   ,10001
								   ,10003
								   ,9972
								   ,9974
								   ,10005
								   ,9979
								   ,9980
								   ,10007
								   ,16643
								   ,10009
								   ,16642
								   ,10011
								   ,16644
								   ,16645
								   ,10013
								   ,16960
								   ,16647
								   ,16646
								   ,15292
								   ,10015
								   ,16650
								   ,15293
								   ,16648
								   ,16649
								   ,16965
								   ,16967
								   ,15294
								   ,16651
								   ,16970
								   ,16652
								   ,16653
								   ,15295
								   ,16969
								   ,16978
								   ,16973
								   ,16971
								   ,16667
								   ,15296
								   ,16654
								   ,16655
								   ,16660
								   ,16656
								   ,16983
								   ,16980
								   ,16984
								   ,16985
								   ,16661
								   ,16659
								   ,16659
								   ,16657
								   ,16658
								   ,16665
								   ,16724
								   ,16725
								   ,16662
								   ,16663
								   ,16664
								   ,16726
								   ,16741
								   ,16746
								   ,16742
								   ,16745
								   ,16744
								   ,16728
								   ,16730
								   ,16729
								   ,16732
								   ,16731
								   ,16994
								   ,16995
								   ,16993
								   ,16988
								   ,16987
								   ,16986
								   ,16992
								   ,16991
								   ,16990} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class Dwukk : BaseCreature 
	{ 
		public  Dwukk() : base() 
		{ 
			Model = 3747;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Dwukk" ;
			Flags1 = 0x08480046 ;
			Id = 3174 ; 
			Guild = "Journeyman Blacksmith";
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
			Level = RandomLevel( 27 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 664 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 17, 22 );
			NpcText00 = "Greetings $N, I am Dwukk." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 6, 0, 0, 0 ));
		}
	}
	public class ClariseGnarltree : BaseCreature 
	{ 
		public  ClariseGnarltree() : base() 
		{ 
			Model = 4330;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Clarise Gnarltree" ;
			Flags1 = 0x08480046 ;
			Id = 3136 ; 
			Guild = "Expert Blacksmith";
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
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Clarise Gnarltree." ;
			BaseMana = 0 ;
			Trains = new int[] {2021
								   ,3539
								   ,2665
								   ,3116
								   ,7408
								   ,2666
								   ,3294
								   ,3326
								   ,2664
								   ,3292
								   ,7817
								   ,3491
								   ,7818
								   ,19666
								   ,2670
								   ,2668
								   ,3328
								   ,2740
								   ,2741
								   ,6517
								   ,2742
								   ,2672
								   ,9985
								   ,3337
								   ,2752
								   ,3117
								   ,9986
								   ,3296
								   ,3331
								   ,9987
								   ,3333
								   ,2675
								   ,14379
								   ,19667
								   ,8768} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class KarnStonehoof : BaseCreature 
	{ 
		public  KarnStonehoof() : base() 
		{ 
			Model = 2090;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Karn Stonehoof" ;
			Flags1 = 0x08480046 ;
			Id = 2998 ; 
			Guild = "Expert Blacksmith";
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
			CombatReach = 4.05f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Karn Stonehoof." ;
			BaseMana = 0 ;
			Trains = new int[] {2021
								   ,3539
								   ,2665
								   ,3116
								   ,7408
								   ,2666
								   ,3294
								   ,3326
								   ,2664
								   ,3292
								   ,7817
								   ,3491
								   ,7818
								   ,19666
								   ,2670
								   ,2668
								   ,3328
								   ,2740
								   ,2741
								   ,6517
								   ,2742
								   ,2672
								   ,9985
								   ,3337
								   ,2752
								   ,3117
								   ,9986
								   ,3296
								   ,3331
								   ,9987
								   ,3333
								   ,2675
								   ,14379
								   ,19667
								   ,8768} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class BrikkKeencraft : BaseCreature 
	{ 
		public  BrikkKeencraft() : base() 
		{ 
			Model = 7161;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Brikk Keencraft" ;
			Flags1 = 0x08080046 ;
			Id = 2836 ; 
			Guild = "Master Blacksmith";
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
			Level = RandomLevel( 54 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1985 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 53, 69 );
			NpcText00 = "Greetings $N, I am Brikk Keencraft." ;
			BaseMana = 0 ;
			Trains = new int[] {3539
								   ,17041
								   ,17040
								   ,17039
								   ,8768
								   ,2742
								   ,2672
								   ,14379
								   ,3295
								   ,9985
								   ,3330
								   ,3296
								   ,2673
								   ,9986
								   ,3331
								   ,9987
								   ,3333
								   ,8368
								   ,6518
								   ,3297
								   ,3334
								   ,2675
								   ,7221
								   ,3494
								   ,3506
								   ,3336
								   ,12259
								   ,3504
								   ,3492
								   ,9813
								   ,9811
								   ,3501
								   ,7222
								   ,3495
								   ,3507
								   ,3502
								   ,9921
								   ,9814
								   ,9920
								   ,3505
								   ,3493
								   ,9918
								   ,14380
								   ,15972
								   ,3508
								   ,9818
								   ,3496
								   ,7223
								   ,9820
								   ,3498
								   ,3513
								   ,15973
								   ,7224
								   ,3503
								   ,3511
								   ,9786
								   ,9788
								   ,9789
								   ,11454
								   ,3515
								   ,9928
								   ,9926
								   ,3497
								   ,11643
								   ,3500
								   ,9916
								   ,9933
								   ,9931
								   ,9993
								   ,9935
								   ,9937
								   ,9939
								   ,9950
								   ,9945
								   ,9942
								   ,9996
								   ,9954
								   ,9952
								   ,9997
								   ,9959
								   ,9957
								   ,9961
								   ,9970
								   ,9968
								   ,16640
								   ,16639
								   ,16641
								   ,9966
								   ,9964
								   ,10001
								   ,10003
								   ,9972
								   ,9974
								   ,10005
								   ,9979
								   ,9980
								   ,10007
								   ,16643
								   ,10009
								   ,16642
								   ,10011
								   ,16644
								   ,16645
								   ,10013
								   ,16960
								   ,16647
								   ,16646
								   ,15292
								   ,10015
								   ,16650
								   ,15293
								   ,16648
								   ,16649
								   ,16965
								   ,16967
								   ,15294
								   ,16651
								   ,16970
								   ,16652
								   ,16653
								   ,15295
								   ,16969
								   ,16978
								   ,16973
								   ,16971
								   ,16667
								   ,15296
								   ,16654
								   ,16655
								   ,16660
								   ,16656
								   ,16983
								   ,16980
								   ,16984
								   ,16985
								   ,16661
								   ,16659
								   ,16659
								   ,16657
								   ,16658
								   ,16665
								   ,16724
								   ,16725
								   ,16662
								   ,16663
								   ,16664
								   ,16726
								   ,16741
								   ,16746
								   ,16742
								   ,16745
								   ,16744
								   ,16728
								   ,16730
								   ,16729
								   ,16732
								   ,16731
								   ,16994
								   ,16995
								   ,16993
								   ,16988
								   ,16987
								   ,16986
								   ,16992
								   ,16991
								   ,16990} ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}


	public class Snarl : BaseCreature 
	{ 
		public  Snarl() : base() 
		{ 
			Model = 4382;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Snarl" ;
			Flags1 = 0x08480046 ;
			Id = 1383 ; 
			Guild = "Expert Blacksmith";
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
			BaseHitPoints = 0 ;
			NpcFlags = (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Snarl." ;
			BaseMana = 0 ;
			Trains = new int[] {2021
								   ,3539
								   ,2665
								   ,3116
								   ,7408
								   ,2666
								   ,3294
								   ,3326
								   ,2664
								   ,3292
								   ,7817
								   ,3491
								   ,7818
								   ,19666
								   ,2670
								   ,2668
								   ,3328
								   ,2740
								   ,2741
								   ,6517
								   ,2742
								   ,2672
								   ,9985
								   ,3337
								   ,2752
								   ,3117
								   ,9986
								   ,3296
								   ,3331
								   ,9987
								   ,3333
								   ,2675
								   ,14379
								   ,19667
								   ,8768} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class TognusFlintfire : BaseCreature 
	{ 
		public  TognusFlintfire() : base() 
		{ 
			Model = 3422;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Tognus Flintfire" ;
			Flags1 = 0x08480046 ;
			Id = 1241 ; 
			Guild = "Journeyman Blacksmith";
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
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Tognus Flintfire." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class DaneLindgren : BaseCreature 
	{ 
		public  DaneLindgren() : base() 
		{ 
			Model = 3354;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Dane Lindgren" ;
			Flags1 = 0x08480046 ;
			Id = 957 ; 
			Guild = "Journeyman Blacksmith";
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
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 904 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 24, 31 );
			NpcText00 = "Greetings $N, I am Dane Lindgren." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class SmithArgus : BaseNPC 
	{ 
		public  SmithArgus() : base() 
		{ 
			Model = 1288;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Smith Argus" ;
			Flags1 = 0x08480046 ;
			Id = 514 ; 
			Guild = "Journeyman Blacksmith";
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
			BaseHitPoints = 504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 13, 16 );
			NpcText00 = "Greetings $N, I am Smith Argus." ;
			BaseMana = 0 ;
			Trains = new int[] {3293
								   ,3319
								   ,3324
								   ,3323
								   ,3320
								   ,3294
								   ,3326
								   ,3116
								   ,2666
								   ,2665
								   ,2661
								   ,2662
								   ,2739
								   ,2738
								   ,2754
								   ,2020
								   ,8880
								   ,7408
								   ,9983
								   ,2021} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
			//Quests = new BaseQuest[] { new Elmores_Task() };
		}
	}
	
}