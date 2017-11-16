//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class DarnathBladesinger : BaseCreature 
	{ 
		public  DarnathBladesinger() : base() 
		{ 
			Model = 6071;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Darnath Bladesinger" ;
			Flags1 = 0x08480046 ;
			Id = 7315 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 55 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2226 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 60, 77 );
			NpcText00 = "Greetings $N, I am Darnath Bladesinger." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 )); 
		}
	}
	public class WuShen : BaseCreature 
	{ 
		public  WuShen() : base() 
		{ 
			Model = 3280;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Wu Shen" ;
			Flags1 = 0x08480046 ;
			Id = 5479 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Wu Shen." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7491, InventoryTypes.MainGauche, 2, 8, 1, 3, 0, 0, 0 )); 
		}
	}
	public class IlsaCorbin : BaseCreature 
	{ 
		public  IlsaCorbin() : base() 
		{ 
			Model = 3287;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Ilsa Corbin" ;
			Flags1 = 0x08480046 ;
			Id = 5480 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Ilsa Corbin." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 )); 
		}
	}
	public class KelvSternhammer : BaseCreature 
	{ 
		public  KelvSternhammer() : base() 
		{ 
			Model = 3054;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Kelv Sternhammer" ;
			Flags1 = 0x08480046 ;
			Id = 5113 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Kelv Sternhammer." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 3879, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 )); 
		}
	}
	public class BilbanTosslespanner : BaseCreature 
	{ 
		public  BilbanTosslespanner() : base() 
		{ 
			Model = 3055;
			AttackSpeed= 1500;
			BoundingRadius = 0.351900f ;
			Name = "Bilban Tosslespanner" ;
			Flags1 = 0x08480046 ;
			Id = 5114 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Greetings $N, I am Bilban Tosslespanner." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 7485, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class ChristophWalker : BaseCreature 
	{ 
		public  ChristophWalker() : base() 
		{ 
			Model = 2620;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Christoph Walker" ;
			Flags1 = 0x018480046 ;
			Id = 4593 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 1.5f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Christoph Walker." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8016, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 )); 
		}
	}
	public class AngelaCurthas : BaseCreature 
	{ 
		public  AngelaCurthas() : base() 
		{ 
			Model = 2658;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Angela Curthas" ;
			Flags1 = 0x018480046 ;
			Id = 4594 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Angela Curthas." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7419, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1706, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class BaltusFowler : BaseCreature 
	{ 
		public  BaltusFowler() : base() 
		{ 
			Model = 2614;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Baltus Fowler" ;
			Flags1 = 0x018480046 ;
			Id = 4595 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Baltus Fowler." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ),new Item( 1685, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class Sildanair : BaseCreature 
	{ 
		public  Sildanair() : base() 
		{ 
			Model = 2198;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Sildanair" ;
			Flags1 = 0x08480046 ;
			Id = 4089 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Sildanair." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class AriastaBladesinger : BaseCreature 
	{ 
		public  AriastaBladesinger() : base() 
		{ 
			Model = 2196;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Arias'ta Bladesinger" ;
			Flags1 = 0x08480046 ;
			Id = 4087 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 1.5f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Arias'ta Bladesinger." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8378, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 )); 
		}
	}
	public class KyraWindblade : BaseNPC 
	{ 
		public  KyraWindblade() : base() 
		{ 
			Model = 1707;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Kyra Windblade" ;
			Flags1 = 0x08480046 ;
			Id = 3598 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 19 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 784 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 20, 26 );
			NpcText00 = "Greetings $N, I am Kyra Windblade." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 )); 
		}
	}
	public class Zelmak : BaseCreature 
	{ 
		public  Zelmak() : base() 
		{ 
			Model = 4242;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Zel'mak" ;
			Flags1 = 0x08480046 ;
			Id = 3408 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Zel'mak." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22319, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 )); 
		}
	}
	public class Sorek : BaseCreature 
	{ 
		public  Sorek() : base() 
		{ 
			Model = 1375;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Sorek" ;
			Flags1 = 0x08480046 ;
			Id = 3354 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Sorek." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7490, InventoryTypes.TwoHanded, 2, 8, 1, 1, 0, 0, 0 )); 
		}
	}
	public class GrezzRagefist : BaseCreature 
	{ 
		public  GrezzRagefist() : base() 
		{ 
			Model = 1374;
			AttackSpeed= 1739;
			BoundingRadius = 0.409200f ;
			Name = "Grezz Ragefist" ;
			Flags1 = 0x08480046 ;
			Id = 3353 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 1.65f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Grezz Ragefist." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ),new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 )); 
		}
	}
	public class TarshawJaggedscar : BaseCreature 
	{ 
		public  TarshawJaggedscar() : base() 
		{ 
			Model = 3743;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Tarshaw Jaggedscar" ;
			Flags1 = 0x08480046 ;
			Id = 3169 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 43 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1745 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 47, 60 );
			NpcText00 = "Greetings $N, I am Tarshaw Jaggedscar." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class Frang : BaseCreature 
	{ 
		public  Frang() : base() 
		{ 
			Model = 1880;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Frang" ;
			Flags1 = 0x08080066 ;
			Id = 3153 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 11 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Frang." ;
			BaseMana = 0 ;
			Trains = new int[] {1423
								   ,1738
								   ,1343
								   ,6674} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 )); 
		}
	}
	public class KrangStonehoof : BaseCreature 
	{ 
		public  KrangStonehoof() : base() 
		{ 
			Model = 3794;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Krang Stonehoof" ;
			Flags1 = 0x08400046 ;
			Id = 3063 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 14 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 584 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 15, 19 );
			NpcText00 = "Greetings $N, I am Krang Stonehoof." ;
			BaseMana = 0 ;
			Trains = new int[] {6543
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,3434
								   ,11583
								   ,11582
								   ,11599
								   ,11598
								   ,11579
								   ,11607
								   ,11606
								   ,11603
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,3433
								   ,8207
								   ,8206
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1722
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,7375
								   ,7374
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,7401
								   ,1738
								   ,1716
								   ,2570
								   ,1055
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1065
								   ,7403
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,6158
								   ,1611
								   ,11553
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,1424
								   ,1677
								   ,8821
								   ,1482
								   ,8381
								   ,797
								   ,3435
								   ,11602
								   ,11587
								   ,11586
								   ,1610
								   ,1423
								   ,11577
								   ,11576
								   ,11575
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ),new Item( 33637, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class HaruttThunderhorn : BaseCreature 
	{ 
		public  HaruttThunderhorn() : base() 
		{ 
			Model = 3793;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Harutt Thunderhorn" ;
			Flags1 = 0x08080066 ;
			Id = 3059 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 4.05f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Harutt Thunderhorn." ;
			BaseMana = 0 ;
			Trains = new int[] {1423
								   ,1738
								   ,1343
								   ,6674
								   ,3128} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 )); 
		}
	}
	public class TormRagetotem : BaseCreature 
	{ 
		public  TormRagetotem() : base() 
		{ 
			Model = 2103;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Torm Ragetotem" ;
			Flags1 = 0x08480046 ;
			Id = 3041 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 4.05f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Torm Ragetotem." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ),new Item( 22635, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class SarkRagetotem : BaseCreature 
	{ 
		public  SarkRagetotem() : base() 
		{ 
			Model = 2096;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Sark Ragetotem" ;
			Flags1 = 0x08480046 ;
			Id = 3042 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Sark Ragetotem." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 3797, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ),new Item( 22635, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class KerRagetotem : BaseCreature 
	{ 
		public  KerRagetotem() : base() 
		{ 
			Model = 2113;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Ker Ragetotem" ;
			Flags1 = 0x08480046 ;
			Id = 3043 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Ker Ragetotem." ;
			BaseMana = 0 ;
			Trains = new int[] {6543
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,3434
								   ,11583
								   ,11582
								   ,11599
								   ,11598
								   ,11579
								   ,11607
								   ,11606
								   ,11603
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,3433
								   ,8207
								   ,8206
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1722
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,7375
								   ,7374
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,7401
								   ,1738
								   ,1716
								   ,2570
								   ,1055
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1065
								   ,7403
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,6158
								   ,1611
								   ,11553
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,1424
								   ,1677
								   ,8821
								   ,1482
								   ,8381
								   ,797
								   ,3435
								   ,11602
								   ,11587
								   ,11586
								   ,1610
								   ,1423
								   ,11577
								   ,11576
								   ,11575} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22366, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 22637, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class AustildeMon : BaseCreature 
	{ 
		public  AustildeMon() : base() 
		{ 
			Model = 1599;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Austil de Mon" ;
			Flags1 = 0x08400046 ;
			Id = 2131 ; 
			Guild = "Warrior Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 664 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 17, 22 );
			NpcText00 = "Greetings $N, I am Austil de Mon." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 )); 
		}
	}
	public class DannalStern : BaseCreature 
	{ 
		public  DannalStern() : base() 
		{ 
			Model = 1578;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Dannal Stern" ;
			Flags1 = 0x08000066 ;
			Id = 2119 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 5 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 7, 9 );
			NpcText00 = "Greetings $N, I am Dannal Stern." ;
			BaseMana = 0 ;
			Trains = new int[] {1423
								   ,1343
								   ,3128
								   ,6674 } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 )); 
		}
	}
	public class KelstrumStonebreaker : BaseCreature 
	{ 
		public  KelstrumStonebreaker() : base() 
		{ 
			Model = 3053;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Kelstrum Stonebreaker" ;
			Flags1 = 0x08480046 ;
			Id = 1901 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Kelstrum Stonebreaker." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7508, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ),new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class GranisSwiftaxe : BaseCreature 
	{ 
		public  GranisSwiftaxe() : base() 
		{ 
			Model = 3431;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Granis Swiftaxe" ;
			Flags1 = 0x08480046 ;
			Id = 1229 ; 
			Guild = "Warrior Trainer";
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
			BaseHitPoints = 504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 13, 16 );
			NpcText00 = "Greetings $N, I am Granis Swiftaxe." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 24594, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 )); 
		}
	}
	public class Malosh : BaseCreature 
	{ 
		public  Malosh() : base() 
		{ 
			Model = 4556;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Malosh" ;
			Flags1 = 0x08400046 ;
			Id = 985 ; 
			Guild = "Warrior Trainer";
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
			NpcText00 = "Greetings $N, I am Malosh." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 20640, InventoryTypes.MainGauche, 2, 8, 1, 1, 0, 0, 0 )); 
		}
	}
	public class LlaneBeshere : BaseCreature 
	{ 
		public  LlaneBeshere() : base() 
		{ 
			Model = 3343;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Llane Beshere" ;
			Flags1 = 0x08080066 ;
			Id = 911 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 5 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 100 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings $N, I am Llane Beshere." ;
			BaseMana = 0 ;
			Trains = new int[] {1423
								   ,1738
								   ,1343
								   ,6674
								   ,3128} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1685, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class ThranKhorman : BaseCreature 
	{ 
		public  ThranKhorman() : base() 
		{ 
			Model = 3399;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Thran Khorman" ;
			Flags1 = 0x08080066 ;
			Id = 912 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 5 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 544 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Greetings $N, I am Thran Khorman." ;
			BaseMana = 0 ;
			Trains = new int[] {1423
								   ,1738
								   ,1343
								   ,6674
								   ,3128} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1685, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class LyriaDuLac : BaseCreature 
	{ 
		public  LyriaDuLac() : base() 
		{ 
			Model = 1300;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Lyria Du Lac" ;
			Flags1 = 0x08480046 ;
			Id = 913 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 12 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 150 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Greetings $N, I am Lyria Du Lac." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1706, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	public class AnderGermaine : BaseCreature 
	{ 
		public  AnderGermaine() : base() 
		{ 
			Model = 1504;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Ander Germaine" ;
			Flags1 = 0x08480046 ;
			Id = 914 ; 
			Guild = "Warrior Trainer";
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
			CombatReach = 1.5f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Ander Germaine." ;
			BaseMana = 0 ;
			Trains = new int[] {11576
								   ,11577
								   ,11586
								   ,11587
								   ,11602
								   ,11603
								   ,11606
								   ,11607
								   ,8821
								   ,1482
								   ,8381
								   ,6573
								   ,7380
								   ,6193
								   ,6575
								   ,6191
								   ,6180
								   ,6158
								   ,1611
								   ,11553
								   ,11552
								   ,6543
								   ,6556
								   ,6553
								   ,21558
								   ,21557
								   ,11575
								   ,11559
								   ,11558
								   ,11557
								   ,11571
								   ,11570
								   ,21555
								   ,1685
								   ,20622
								   ,20621
								   ,18556
								   ,20704
								   ,20703
								   ,20571
								   ,797
								   ,11579
								   ,11598
								   ,11599
								   ,11582
								   ,11583
								   ,3434
								   ,3435
								   ,3433
								   ,2688
								   ,7889
								   ,7385
								   ,7109
								   ,20724
								   ,798
								   ,6551
								   ,1343
								   ,6549
								   ,1424
								   ,7375
								   ,7374
								   ,8207
								   ,8206
								   ,1610
								   ,1423
								   ,1677
								   ,1722
								   ,1607
								   ,6550
								   ,1676
								   ,3128
								   ,1606
								   ,1344
								   ,1675
								   ,1646
								   ,5247
								   ,5243
								   ,7406
								   ,7382
								   ,1055
								   ,6177
								   ,6674
								   ,6176
								   ,5283
								   ,20562
								   ,20561
								   ,1065
								   ,7403
								   ,7401
								   ,1738
								   ,1716
								   ,2570 } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 12274, InventoryTypes.MainGauche, 2, 1, 1, 1, 0, 0, 0 )); 
		}
	}
	public class Alyissia : BaseNPC 
	{ 
		public  Alyissia() : base() 
		{ 
			Model = 1721;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Alyissia" ;
			Flags1 = 0x08080066 ;
			Id = 3593 ; 
			Guild = "Warrior Trainer";
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
			Level = RandomLevel( 11 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 544 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Hello, warrior!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {1423
								   ,1738
								   ,1343
								   ,6674
								   ,3128} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			//Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1685, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
		}
	}
	
}