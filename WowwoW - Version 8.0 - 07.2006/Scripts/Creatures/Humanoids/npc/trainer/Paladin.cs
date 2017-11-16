//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class BrotherKarman : BaseCreature 
	{ 
		public  BrotherKarman() : base() 
		{ 
			Model = 7356;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Brother Karman" ;
			Flags1 = 0x08480046 ;
			Id = 8140 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Brother Karman." ;
			BaseMana = 0 ;
			Trains = new int[] {7109
								   ,10323
								   ,20774
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20730
								   ,20949
								   ,20948
								   ,20775
								   ,10325
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,10304
								   ,10303
								   ,10302
								   ,10309
								   ,10311
								   ,10279
								   ,1897
								   ,10297
								   ,10296
								   ,10295
								   ,10294
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,19855
								   ,19743} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 2839, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
		}
	}
	public class ArthurTheFaithful : BaseCreature 
	{ 
		public  ArthurTheFaithful() : base() 
		{ 
			Model = 3284;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Arthur the Faithful" ;
			Flags1 = 0x08480046 ;
			Id = 5491 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Arthur the Faithful." ;
			BaseMana = 0 ;
			Trains = new int[] {10294
								   ,10295
								   ,10296
								   ,1897
								   ,10311
								   ,10302
								   ,10304
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,19855
								   ,19743
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20949
								   ,20948
								   ,20730
								   ,20775
								   ,20774
								   ,10325
								   ,10323
								   ,7109
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10303
								   ,10309
								   ,10279} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 8011, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class KatherineThePure : BaseCreature 
	{ 
		public  KatherineThePure() : base() 
		{ 
			Model = 3289;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Katherine the Pure" ;
			Flags1 = 0x08480046 ;
			Id = 5492 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Katherine the Pure." ;
			BaseMana = 0 ;
			Trains = new int[] {7109
								   ,10323
								   ,20774
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20730
								   ,20949
								   ,20948
								   ,20775
								   ,10325
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,10304
								   ,10303
								   ,10302
								   ,10309
								   ,10311
								   ,10279
								   ,1897
								   ,10297
								   ,10296
								   ,10295
								   ,10294
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,19855
								   ,19743} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8011, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class ValgarHighforge : BaseCreature 
	{ 
		public  ValgarHighforge() : base() 
		{ 
			Model = 3089;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Valgar Highforge" ;
			Flags1 = 0x08480046 ;
			Id = 5147 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Valgar Highforge." ;
			BaseMana = 0 ;
			Trains = new int[] {7109
								   ,10323
								   ,20774
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20730
								   ,20949
								   ,20948
								   ,20775
								   ,10325
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,10304
								   ,10303
								   ,10302
								   ,10309
								   ,10311
								   ,10279
								   ,1897
								   ,10297
								   ,10296
								   ,10295
								   ,10294
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,19855
								   ,19743} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
		}
	}
	public class BeldrukDoombrow : BaseCreature 
	{ 
		public  BeldrukDoombrow() : base() 
		{ 
			Model = 3088;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Beldruk Doombrow" ;
			Flags1 = 0x08480046 ;
			Id = 5148 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Beldruk Doombrow." ;
			BaseMana = 0 ;
			Trains = new int[] {7109
								   ,10323
								   ,20774
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20730
								   ,20949
								   ,20948
								   ,20775
								   ,10325
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,10304
								   ,10303
								   ,10302
								   ,10309
								   ,10311
								   ,10279
								   ,1897
								   ,10297
								   ,10296
								   ,10295
								   ,10294
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,19855
								   ,19743} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8011, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class BrandurIronhammer : BaseCreature 
	{ 
		public  BrandurIronhammer() : base() 
		{ 
			Model = 3087;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Brandur Ironhammer" ;
			Flags1 = 0x08480046 ;
			Id = 5149 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Brandur Ironhammer." ;
			BaseMana = 0 ;
			Trains = new int[] {7109
								   ,10323
								   ,20774
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20730
								   ,20949
								   ,20948
								   ,20775
								   ,10325
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,10304
								   ,10303
								   ,10302
								   ,10309
								   ,10311
								   ,10279
								   ,1897
								   ,10297
								   ,10296
								   ,10295
								   ,10294
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,19855
								   ,19743} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8011, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class AzarStronghammer : BaseCreature 
	{ 
		public  AzarStronghammer() : base() 
		{ 
			Model = 1622;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Azar Stronghammer" ;
			Flags1 = 0x08480006 ;
			Id = 1232 ; 
			Guild = "Paladin Trainer";
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
			BaseHitPoints = 504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 13, 16 );
			NpcText00 = "Greetings $N, I am Azar Stronghammer." ;
			BaseMana = 0 ;
			Trains = new int[] {7109
								   ,10323
								   ,20774
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20730
								   ,20949
								   ,20948
								   ,20775
								   ,10325
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,10304
								   ,10303
								   ,10302
								   ,10309
								   ,10311
								   ,10279
								   ,1897
								   ,10297
								   ,10296
								   ,10295
								   ,10294
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,19855
								   ,19743} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 24595, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class BrotherSammuel : BaseCreature 
	{ 
		public  BrotherSammuel() : base() 
		{ 
			Model = 3346;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Brother Sammuel" ;
			Flags1 = 0x08080066 ;
			Id = 925 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Brother Sammuel." ;
			BaseMana = 0 ;
			Trains = new int[] {5572
								   ,19741
								   ,21083
								   ,10321
								   ,1873} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class BromosGrummner : BaseCreature 
	{ 
		public  BromosGrummner() : base() 
		{ 
			Model = 3393;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Bromos Grummner" ;
			Flags1 = 0x08080066 ;
			Id = 926 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Bromos Grummner." ;
			BaseMana = 0 ;
			Trains = new int[] {5572
								   ,19741
								   ,21083
								   ,10321
								   ,1873} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class BrotherWilhelm : BaseCreature 
	{ 
		public  BrotherWilhelm() : base() 
		{ 
			Model = 1299;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Brother Wilhelm" ;
			Flags1 = 0x08480046 ;
			Id = 927 ; 
			Guild = "Paladin Trainer";
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
			BaseHitPoints = 100 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Brother Wilhelm." ;
			BaseMana = 0 ;
			Trains = new int[] {7109
								   ,10323
								   ,20774
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20730
								   ,20949
								   ,20948
								   ,20775
								   ,10325
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,10304
								   ,10303
								   ,10302
								   ,10309
								   ,10311
								   ,10279
								   ,1897
								   ,10297
								   ,10296
								   ,10295
								   ,10294
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,19855
								   ,19743} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ),new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class LordGraysonShadowbreaker : BaseCreature 
	{ 
		public  LordGraysonShadowbreaker() : base() 
		{ 
			Model = 1499;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Lord Grayson Shadowbreaker" ;
			Flags1 = 0x08480006 ;
			Id = 928 ; 
			Guild = "Paladin Trainer";
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
			NpcText00 = "Greetings $N, I am Lord Grayson Shadowbreaker." ;
			BaseMana = 0 ;
			Trains = new int[] {10294
								   ,10295
								   ,10296
								   ,1897
								   ,10311
								   ,10302
								   ,10304
								   ,10331
								   ,10330
								   ,10320
								   ,10327
								   ,10317
								   ,10316
								   ,10315
								   ,10305
								   ,19754
								   ,19997
								   ,19996
								   ,19995
								   ,20960
								   ,20958
								   ,20957
								   ,20956
								   ,20955
								   ,20954
								   ,20953
								   ,20952
								   ,20947
								   ,20946
								   ,20945
								   ,20944
								   ,10321
								   ,20461
								   ,20460
								   ,20459
								   ,20458
								   ,20457
								   ,20456
								   ,20455
								   ,20454
								   ,20453
								   ,20452
								   ,20451
								   ,20450
								   ,20462
								   ,20443
								   ,20442
								   ,20441
								   ,20440
								   ,20439
								   ,20438
								   ,20437
								   ,20448
								   ,20447
								   ,20446
								   ,20445
								   ,20444
								   ,19948
								   ,19947
								   ,19946
								   ,19945
								   ,19944
								   ,19843
								   ,19842
								   ,19841
								   ,19840
								   ,19839
								   ,19741
								   ,1909
								   ,19751
								   ,19909
								   ,19908
								   ,19894
								   ,19907
								   ,19906
								   ,19893
								   ,19905
								   ,19904
								   ,19892
								   ,19858
								   ,19857
								   ,19856
								   ,19855
								   ,19743
								   ,19747
								   ,21083
								   ,20951
								   ,20950
								   ,20949
								   ,20948
								   ,20730
								   ,20775
								   ,20774
								   ,10325
								   ,10323
								   ,7109
								   ,1913
								   ,1874
								   ,1876
								   ,1873
								   ,1878
								   ,1875
								   ,5253
								   ,1911
								   ,2804
								   ,5600
								   ,1937
								   ,3128
								   ,685
								   ,1898
								   ,1877
								   ,3473
								   ,1914
								   ,7296
								   ,4990
								   ,6941
								   ,1912
								   ,5617
								   ,5616
								   ,5613
								   ,5574
								   ,5591
								   ,5590
								   ,5584
								   ,5629
								   ,5572
								   ,10303
								   ,10309
								   ,10279} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
		}
	}
	
}