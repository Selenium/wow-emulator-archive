//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class GimrizzShadowcog : BaseCreature 
	{ 
		public  GimrizzShadowcog() : base() 
		{ 
			Model = 3607;
			AttackSpeed= 1500;
			BoundingRadius = 0.351900f ;
			Name = "Gimrizz Shadowcog" ;
			Flags1 = 0x08480046 ;
			Id = 5612 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.725f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 23573, InventoryTypes.TwoHanded, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class UrsulaDeline : BaseCreature 
	{ 
		public  UrsulaDeline() : base() 
		{ 
			Model = 3291;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Ursula Deline" ;
			Flags1 = 0x08480046 ;
			Id = 5495 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =   (int)NpcActions.Trainer;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Sandahl : BaseCreature 
	{ 
		public  Sandahl() : base() 
		{ 
			Model = 3286;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Sandahl" ;
			Flags1 = 0x08480046 ;
			Id = 5496 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Thistleheart : BaseCreature 
	{ 
		public  Thistleheart() : base() 
		{ 
			Model = 3115;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Thistleheart" ;
			Flags1 = 0x08480046 ;
			Id = 5171 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.725f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Briarthorn : BaseCreature 
	{ 
		public  Briarthorn() : base() 
		{ 
			Model = 3116;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Briarthorn" ;
			Flags1 = 0x08480046 ;
			Id = 5172 ; 
			Guild = "Warlock Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class AlexanderCalder : BaseCreature 
	{ 
		public  AlexanderCalder() : base() 
		{ 
			Model = 3122;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Alexander Calder" ;
			Flags1 = 0x08480046 ;
			Id = 5173 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!." ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class KaalSoulreaper : BaseCreature 
	{ 
		public  KaalSoulreaper() : base() 
		{ 
			Model = 2675;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Kaal Soulreaper" ;
			Flags1 = 0x08400046 ;
			Id = 4563 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class LutherPickman : BaseCreature 
	{ 
		public  LutherPickman() : base() 
		{ 
			Model = 2637;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Luther Pickman" ;
			Flags1 = 0x08400046 ;
			Id = 4564 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 20502, InventoryTypes.TwoHanded, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class RichardKerwin : BaseCreature 
	{ 
		public  RichardKerwin() : base() 
		{ 
			Model = 2646;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Richard Kerwin" ;
			Flags1 = 0x08400046 ;
			Id = 4565 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.500000f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 23586, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Mirket : BaseCreature 
	{ 
		public  Mirket() : base() 
		{ 
			Model = 1325;
			AttackSpeed= 2000;
			BoundingRadius = 0.236000f ;
			Name = "Mirket" ;
			Flags1 = 0x08480046 ;
			Id = 3325 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Zevrost : BaseCreature 
	{ 
		public  Zevrost() : base() 
		{ 
			Model = 1326;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Zevrost" ;
			Flags1 = 0x08480046 ;
			Id = 3326 ; 
			Guild = "Warlock Trainer";
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
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Groldar : BaseCreature 
	{ 
		public  Groldar() : base() 
		{ 
			Model = 1324;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Grol'dar" ;
			Flags1 = 0x08480046 ;
			Id = 3324 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Grol'dar." ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class DhugruGorelust : BaseCreature 
	{ 
		public  DhugruGorelust() : base() 
		{ 
			Model = 3745;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Dhugru Gorelust" ;
			Flags1 = 0x08480046 ;
			Id = 3172 ; 
			Guild = "Warlock Trainer";
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
			Level = RandomLevel( 37 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1504 ;
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 40, 52 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] { 20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Nartok : BaseCreature 
	{ 
		public  Nartok() : base() 
		{ 
			Model = 1884;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Nartok" ;
			Flags1 = 0x08080066 ;
			Id = 3156 ; 
			Guild = "Warlock Trainer";
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
			Level = RandomLevel( 9 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {172
								   ,1393 
								   ,1476 
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 21251, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Maximillion : BaseCreature 
	{ 
		public  Maximillion() : base() 
		{ 
			Model = 1581;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Maximillion" ;
			Flags1 = 0x08000066 ;
			Id = 2126 ; 
			Guild = "Warlock Trainer";
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
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {1374
								   ,1381
								   ,1476
								   ,1393 } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 5010, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class RupertBoch : BaseCreature 
	{ 
		public  RupertBoch() : base() 
		{ 
			Model = 1604;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Rupert Boch" ;
			Flags1 = 0x08400046 ;
			Id = 2127 ; 
			Guild = "Warlock Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 624 ;
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 21251, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Kartosh : BaseCreature 
	{ 
		public  Kartosh() : base() 
		{ 
			Model = 4567;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Kartosh" ;
			Flags1 = 0x08400046 ;
			Id = 988 ; 
			Guild = "Warlock Trainer";
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
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] { 20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class MaximillianCrowe : BaseCreature 
	{ 
		public  MaximillianCrowe() : base() 
		{ 
			Model = 3271;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Maximillian Crowe" ;
			Flags1 = 0x08480046 ;
			Id = 906 ; 
			Guild = "Warlock Trainer";
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
			BaseHitPoints = 150 ;
			NpcFlags =  (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!." ;
			BaseMana = 0 ;
			Trains = new int[] {11788
								   ,11720
								   ,11676
								   ,11718
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,18753
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,8291
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5741
								   ,5736
								   ,5139
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,20769
								   ,20768
								   ,20767
								   ,20766
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,5501
								   ,11702
								   ,11701
								   ,7663
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,1297
								   ,1296
								   ,5709
								   ,7660
								   ,5700
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class DemisetteCloyce : BaseCreature 
	{ 
		public  DemisetteCloyce() : base() 
		{ 
			Model = 1469;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Demisette Cloyce" ;
			Flags1 = 0x08480046 ;
			Id = 461 ; 
			Guild = "Warlock Trainer";
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
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {20766
								   ,20767
								   ,20769
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,172
								   ,6216
								   ,6214
								   ,5709
								   ,7660
								   ,5700
								   ,5698
								   ,11718
								   ,11676
								   ,11720
								   ,11788
								   ,18753
								   ,5501
								   ,5139
								   ,5741
								   ,5736
								   ,1297
								   ,1296
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,11702
								   ,11701
								   ,7663
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,8291
								   ,20768
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class AlamarGrimm : BaseCreature 
	{ 
		public  AlamarGrimm() : base() 
		{ 
			Model = 1930;
			AttackSpeed= 1500;
			BoundingRadius = 0.351900f ;
			Name = "Alamar Grimm" ;
			Flags1 = 0x08080066 ;
			Id = 460 ; 
			Guild = "Warlock Trainer";
			Size = 1.15f;
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
			CombatReach = 1.725f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {172
								   ,1393
								   ,1476
							   } ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class DrusillaLaSalle : BaseCreature 
	{ 
		public  DrusillaLaSalle() : base() 
		{ 
			Model = 3345;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Drusilla La Salle" ;
			Flags1 = 0x08080066 ;
			Id = 459 ; 
			Guild = "Warlock Trainer";
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
			BaseHitPoints = 110 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 6, 8 );
			NpcText00 = "The arcane only corrupts those who are weak. Even if you do not follow the path of the warlock, you would do well to remember that.";
			NpcText01 = "Greetings, I'm warlock trainer. And you're NOT a warlock, go away!" ;
			BaseMana = 0 ;
			Trains = new int[] {172
								   ,1393
								   ,1476
								   ,1381
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	
}