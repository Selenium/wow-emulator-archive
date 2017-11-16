//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class LordTonyRomano : BaseCreature 
	{ 
		public  LordTonyRomano() : base() 
		{ 
			Model = 13171;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Lord Tony Romano" ;
			Flags1 = 0x08480046 ;
			Id = 13283 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Lord Tony Romano." ;
			BaseMana = 0 ;
			Trains = new int[] {8648
								   ,8652
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8622
								   ,8642
								   ,8641
								   ,8636
								   ,8635
								   ,8634
								   ,8626
								   ,1845
								   ,1846
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,6775
								   ,11288
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,11272
								   ,11271
								   ,11270
								   ,1859
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,5768
								   ,1424} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7492, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6454, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class OrmyrFlinteye : BaseCreature 
	{ 
		public  OrmyrFlinteye() : base() 
		{ 
			Model = 3100;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Ormyr Flinteye" ;
			Flags1 = 0x08480046 ;
			Id = 5166 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Ormyr Flinteye." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6443, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Fenthwick : BaseCreature 
	{ 
		public  Fenthwick() : base() 
		{ 
			Model = 3113;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Fenthwick" ;
			Flags1 = 0x08480046 ;
			Id = 5167 ; 
			Guild = "Rogue Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Fenthwick." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 6443, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class HulfdanBlackbeard : BaseCreature 
	{ 
		public  HulfdanBlackbeard() : base() 
		{ 
			Model = 3101;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Hulfdan Blackbeard" ;
			Flags1 = 0x08480046 ;
			Id = 5165 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Hulfdan Blackbeard." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6469, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class CarolynWard : BaseCreature 
	{ 
		public  CarolynWard() : base() 
		{ 
			Model = 2659;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Carolyn Ward" ;
			Flags1 = 0x018480046 ;
			Id = 4582 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Carolyn Ward." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 19557, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class MilesDexter : BaseCreature 
	{ 
		public  MilesDexter() : base() 
		{ 
			Model = 2639;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Miles Dexter" ;
			Flags1 = 0x018400046 ;
			Id = 4583 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Miles Dexter." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ),new Item( 6469, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class GregoryCharles : BaseCreature 
	{ 
		public  GregoryCharles() : base() 
		{ 
			Model = 2631;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Gregory Charles" ;
			Flags1 = 0x018480046 ;
			Id = 4584 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Gregory Charles." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6469, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class ErionShadewhisper : BaseNPC 
	{ 
		public  ErionShadewhisper() : base() 
		{ 
			Model = 2252;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Erion Shadewhisper" ;
			Flags1 = 0x08480046 ;
			Id = 4214 ; 
			Guild = "Rogue Trainer";
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
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Erion Shadewhisper." ;
			BaseMana = 0 ;
			Trains = new int[] {8648
								   ,8652
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8622
								   ,8642
								   ,8641
								   ,8636
								   ,8635
								   ,8634
								   ,8626
								   ,1845
								   ,1846
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,6775
								   ,11288
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,11272
								   ,11271
								   ,11270
								   ,1859
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,5768
								   ,1424
								   ,8651} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class Anishar : BaseCreature 
	{ 
		public  Anishar() : base() 
		{ 
			Model = 2243;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Anishar" ;
			Flags1 = 0x08480046 ;
			Id = 4215 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Anishar." ;
			BaseMana = 0 ;
			Trains = new int[] {8648
								   ,8652
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8622
								   ,8642
								   ,8641
								   ,8636
								   ,8635
								   ,8634
								   ,8626
								   ,1845
								   ,1846
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,6775
								   ,11288
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,11272
								   ,11271
								   ,11270
								   ,1859
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,5768
								   ,1424
								   ,8651} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class Syurna : BaseNPC 
	{ 
		public  Syurna() : base() 
		{ 
			Model = 2231;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Syurna" ;
			Flags1 = 0x08480046 ;
			Id = 4163 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Syurna." ;
			BaseMana = 0 ;
			Trains = new int[] {8648
								   ,8652
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8622
								   ,8642
								   ,8641
								   ,8636
								   ,8635
								   ,8634
								   ,8626
								   ,1845
								   ,1846
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,6775
								   ,11288
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,11272
								   ,11271
								   ,11270
								   ,1859
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,5768
								   ,1424
								   ,8651
								   ,8648
								   ,8652
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8622
								   ,8642
								   ,8641
								   ,8636
								   ,8635
								   ,8634
								   ,8626
								   ,1845
								   ,1846
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,6775
								   ,11288
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,11272
								   ,11271
								   ,11270
								   ,1859
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,5768
								   ,1424
								   ,8651} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 6443, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class JannokBreezesong : BaseNPC 
	{ 
		public  JannokBreezesong() : base() 
		{ 
			Model = 1704;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Jannok Breezesong" ;
			Flags1 = 0x08480046 ;
			Id = 3599 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Jannok Breezesong." ;
			BaseMana = 0 ;
			Trains = new int[] {8648
								   ,8652
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8622
								   ,8642
								   ,8641
								   ,8636
								   ,8635
								   ,8634
								   ,8626
								   ,1845
								   ,1846
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,6775
								   ,11288
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,11272
								   ,11271
								   ,11270
								   ,1859
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,5768
								   ,1424} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7482, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class FrahunShadewhisper : BaseNPC 
	{ 
		public  FrahunShadewhisper() : base() 
		{ 
			Model = 1725;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Frahun Shadewhisper" ;
			Flags1 = 0x08080066 ;
			Id = 3594 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Frahun Shadewhisper." ;
			BaseMana = 0 ;
			Trains = new int[] {1789
								   ,1762
								   ,1780
								   ,2592
								   ,5167} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6443, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Shenthul : BaseCreature 
	{ 
		public  Shenthul() : base() 
		{ 
			Model = 4360;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Shenthul" ;
			Flags1 = 0x08480046 ;
			Id = 3401 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Shenthul." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7492, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6443, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Gest : BaseCreature 
	{ 
		public  Gest() : base() 
		{ 
			Model = 1327;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Gest" ;
			Flags1 = 0x08480046 ;
			Id = 3327 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Gest." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Ormok : BaseCreature 
	{ 
		public  Ormok() : base() 
		{ 
			Model = 1328;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Ormok" ;
			Flags1 = 0x08480046 ;
			Id = 3328 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Ormok." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6443, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Kaplak : BaseCreature 
	{ 
		public  Kaplak() : base() 
		{ 
			Model = 3749;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Kaplak" ;
			Flags1 = 0x08480046 ;
			Id = 3170 ; 
			Guild = "Rogue Trainer";
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
			BaseHitPoints = 664 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 17, 22 );
			NpcText00 = "Greetings $N, I am Kaplak." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 22367, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Rwag : BaseCreature 
	{ 
		public  Rwag() : base() 
		{ 
			Model = 1886;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Rwag" ;
			Flags1 = 0x08080066 ;
			Id = 3155 ; 
			Guild = "Rogue Trainer";
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
			Level = RandomLevel( 8 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Rwag." ;
			BaseMana = 0 ;
			Trains = new int[] {1789
								   ,1762
								   ,1780
								   ,2592
								   ,5167} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class MarionCall : BaseCreature 
	{ 
		public  MarionCall() : base() 
		{ 
			Model = 1603;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Marion Call" ;
			Flags1 = 0x08400046 ;
			Id = 2130 ; 
			Guild = "Rogue Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 544 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Greetings $N, I am Marion Call." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 19555, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class DavidTrias : BaseCreature 
	{ 
		public  DavidTrias() : base() 
		{ 
			Model = 1580;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "David Trias" ;
			Flags1 = 0x08000066 ;
			Id = 2122 ; 
			Guild = "Rogue Trainer";
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
			BaseHitPoints = 224 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings $N, I am David Trias." ;
			BaseMana = 0 ;
			Trains = new int[] {1789
								   ,1762
								   ,1780
								   ,2592
								   ,5167 } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7492, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class IanStrom : BaseCreature 
	{ 
		public  IanStrom() : base() 
		{ 
			Model = 5146;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Ian Strom" ;
			Flags1 = 0x08080046 ;
			Id = 1411 ; 
			Guild = "Rogue Trainer";
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
			Level = RandomLevel( 47 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1905 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 51, 66 );
			NpcText00 = "Greetings $N, I am Ian Strom." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7484, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class HogralBakkan : BaseCreature 
	{ 
		public  HogralBakkan() : base() 
		{ 
			Model = 3436;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Hogral Bakkan" ;
			Flags1 = 0x08480046 ;
			Id = 1234 ; 
			Guild = "Rogue Trainer";
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
			BaseHitPoints = 344 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 8, 11 );
			NpcText00 = "Greetings $N, I am Hogral Bakkan." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class JorikKerridan : BaseCreature 
	{ 
		public  JorikKerridan() : base() 
		{ 
			Model = 3351;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Jorik Kerridan" ;
			Flags1 = 0x08080066 ;
			Id = 915 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Jorik Kerridan." ;
			BaseMana = 0 ;
			Trains = new int[] {1789
								   ,1762
								   ,1780
								   ,2592
								   ,5167} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class SolmHargrin : BaseCreature 
	{ 
		public  SolmHargrin() : base() 
		{ 
			Model = 3407;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Solm Hargrin" ;
			Flags1 = 0x08080066 ;
			Id = 916 ; 
			Guild = "Rogue Trainer";
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
			BaseHitPoints = 224 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings $N, I am Solm Hargrin." ;
			BaseMana = 0 ;
			Trains = new int[] {1762
								   ,5167
								   ,1789
								   ,1780
								   ,2592} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class KerynSylvius : BaseCreature 
	{ 
		public  KerynSylvius() : base() 
		{ 
			Model = 1297;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Keryn Sylvius" ;
			Flags1 = 0x08480046 ;
			Id = 917 ; 
			Guild = "Rogue Trainer";
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
			BaseHitPoints = 150 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Keryn Sylvius." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7492, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class OsborneTheNightMan : BaseCreature 
	{ 
		public  OsborneTheNightMan() : base() 
		{ 
			Model = 1507;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Osborne the Night Man" ;
			Flags1 = 0x08480046 ;
			Id = 918 ; 
			Guild = "Rogue Trainer";
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
			NpcText00 = "Greetings $N, I am Osborne the Night Man." ;
			BaseMana = 0 ;
			Trains = new int[] {1846
								   ,8635
								   ,8641
								   ,8622
								   ,1764
								   ,1791
								   ,1763
								   ,1858
								   ,3128
								   ,1838
								   ,1790
								   ,1762
								   ,5167
								   ,6775
								   ,11288
								   ,11287
								   ,8630
								   ,5278
								   ,5175
								   ,1789
								   ,652
								   ,2844
								   ,2595
								   ,2984
								   ,1765
								   ,8625
								   ,3422
								   ,2594
								   ,1780
								   ,1792
								   ,1774
								   ,11318
								   ,11304
								   ,8644
								   ,11302
								   ,11301
								   ,11298
								   ,11296
								   ,11295
								   ,11292
								   ,11291
								   ,11200
								   ,11199
								   ,11284
								   ,11283
								   ,2593
								   ,2592
								   ,11282
								   ,11278
								   ,11277
								   ,11276
								   ,11272
								   ,1862
								   ,1772
								   ,6771
								   ,6769
								   ,6765
								   ,6764
								   ,6763
								   ,6737
								   ,6736
								   ,6735
								   ,6734
								   ,1771
								   ,1781
								   ,6511
								   ,6505
								   ,6480
								   ,5768
								   ,1424
								   ,8652
								   ,8651
								   ,8648
								   ,13221
								   ,13027
								   ,6185
								   ,1728
								   ,11401
								   ,11361
								   ,11360
								   ,3423
								   ,11346
								   ,11345
								   ,11344
								   ,8638
								   ,1773
								   ,8810
								   ,8728
								   ,8727
								   ,8678
								   ,8723
								   ,11271
								   ,11270
								   ,1859
								   ,8695
								   ,8701
								   ,2843
								   ,13233
								   ,13232
								   ,13231
								   ,8697
								   ,8642
								   ,8636
								   ,8634
								   ,1845
								   ,8626} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ),new Item( 7433, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	
}