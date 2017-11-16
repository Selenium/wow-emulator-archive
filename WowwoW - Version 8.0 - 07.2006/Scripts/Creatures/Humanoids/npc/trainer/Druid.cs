//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class GolhineTheHooded : BaseCreature 
	{ 
		public  GolhineTheHooded() : base() 
		{ 
			Model = 10738;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Golhine the Hooded" ;
			Flags1 = 0x08480006 ;
			Id = 9465 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Golhine the Hooded." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 24015, InventoryTypes.TwoHanded, 2, 10, 2, 1, 0, 0, 0 ));
		}
	}
	public class JannosLighthoof : BaseCreature 
	{ 
		public  JannosLighthoof() : base() 
		{ 
			Model = 7357;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Jannos Lighthoof" ;
			Flags1 = 0x08480046 ;
			Id = 8142 ; 
			Guild = "Druid Trainer";
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
			BaseHitPoints = 1745 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 47, 60 );
			NpcText00 = "Greetings $N, I am Jannos Lighthoof." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 1, 0, 0, 0 ));
		}
	}
	public class SheldrasMoontree : BaseCreature 
	{ 
		public  SheldrasMoontree() : base() 
		{ 
			Model = 3300;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Sheldras Moontree" ;
			Flags1 = 0x08400046 ;
			Id = 5504 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Sheldras Moontree." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 22394, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Theridran : BaseCreature 
	{ 
		public  Theridran() : base() 
		{ 
			Model = 3301;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Theridran" ;
			Flags1 = 0x08480046 ;
			Id = 5505 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Theridran." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6799, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ),new Item( 10968, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ),new Item( 6799, InventoryTypes.RangeRight, 2, 19, 2, 0, 0, 0, 0 ));
		}
	}
	public class Maldryn : BaseCreature 
	{ 
		public  Maldryn() : base() 
		{ 
			Model = 3302;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Maldryn" ;
			Flags1 = 0x08400046 ;
			Id = 5506 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Maldryn." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 3879, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
		}
	}
	public class MathrengylBearwalker : BaseNPC 
	{ 
		public  MathrengylBearwalker() : base() 
		{ 
			Model = 2261;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Mathrengyl Bearwalker" ;
			Flags1 = 0x08480046 ;
			Id = 4217 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Mathrengyl Bearwalker." ;
			BaseMana = 5751 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8379, InventoryTypes.MainGauche, 2, 13, 1, 7, 0, 0, 0 ));
		}
	}
	public class Denatharion : BaseCreature 
	{ 
		public  Denatharion() : base() 
		{ 
			Model = 2250;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Denatharion" ;
			Flags1 = 0x08480046 ;
			Id = 4218 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Denatharion." ;
			BaseMana = 4393 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6799, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
		}
	}
	public class FylerianNightwing : BaseCreature 
	{ 
		public  FylerianNightwing() : base() 
		{ 
			Model = 2255;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Fylerian Nightwing" ;
			Flags1 = 0x08480046 ;
			Id = 4219 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Fylerian Nightwing." ;
			BaseMana = 3191 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7430, InventoryTypes.MainGauche, 2, 13, 1, 7, 0, 0, 0 ));
		}
	}
	public class Kal : BaseCreature 
	{ 
		public  Kal() : base() 
		{ 
			Model = 1706;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Kal" ;
			Flags1 = 0x08480046 ;
			Id = 3602 ; 
			Guild = "Druid Trainer";
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
			BaseHitPoints = 904 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 24, 31 );
			NpcText00 = "Greetings $N, I am Kal." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class MardantStrongoak : BaseNPC 
	{ 
		public  MardantStrongoak() : base() 
		{ 
			Model = 1732;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Mardant Strongoak" ;
			Flags1 = 0x08080066 ;
			Id = 3597 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Mardant Strongoak." ;
			BaseMana = 0 ;
			Trains = new int[] {8922
								   ,1420 
								   ,5181 
								   ,5231 } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 2777, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
		}
	}
	public class GenniaRunetotem : BaseCreature 
	{ 
		public  GenniaRunetotem() : base() 
		{ 
			Model = 3820;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Gennia Runetotem" ;
			Flags1 = 0x08480046 ;
			Id = 3064 ; 
			Guild = "Druid Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 13, 16 );
			NpcText00 = "Greetings $N, I am Gennia Runetotem." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 22391, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class GartMistrunner : BaseCreature 
	{ 
		public  GartMistrunner() : base() 
		{ 
			Model = 3819;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Gart Mistrunner" ;
			Flags1 = 0x08080066 ;
			Id = 3060 ; 
			Guild = "Druid Trainer";
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
			BaseHitPoints = 384 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 9, 12 );
			NpcText00 = "Greetings $N, I am Gart Mistrunner." ;
			BaseMana = 0 ;
			Trains = new int[] {8922
								   ,1420
								   ,5181
								   ,5231} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class KymWildmane : BaseCreature 
	{ 
		public  KymWildmane() : base() 
		{ 
			Model = 2115;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Kym Wildmane" ;
			Flags1 = 0x08480046 ;
			Id = 3036 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Kym Wildmane." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 21514, InventoryTypes.TwoHanded, 2, 10, 2, 1, 0, 0, 0 ));
		}
	}
	public class TurakRunetotem : BaseCreature 
	{ 
		public  TurakRunetotem() : base() 
		{ 
			Model = 2106;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Turak Runetotem" ;
			Flags1 = 0x08480046 ;
			Id = 3033 ; 
			Guild = "Druid Trainer";
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
			NpcText00 = "Greetings $N, I am Turak Runetotem." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 22391, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class ShealRunetotem : BaseCreature 
	{ 
		public  ShealRunetotem() : base() 
		{ 
			Model = 2121;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Sheal Runetotem" ;
			Flags1 = 0x08480046 ;
			Id = 3034 ; 
			Guild = "Druid Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Sheal Runetotem." ;
			BaseMana = 0 ;
			Trains = new int[] {20485
								   ,20744
								   ,20750
								   ,20749
								   ,1416
								   ,9748
								   ,9746
								   ,1441
								   ,9495
								   ,9494
								   ,1445
								   ,9491
								   ,5228
								   ,9844
								   ,9843
								   ,9842
								   ,9838
								   ,9837
								   ,9836
								   ,9832
								   ,9831
								   ,9828
								   ,1429
								   ,1421
								   ,6784
								   ,1432
								   ,2897
								   ,1420
								   ,22898
								   ,22897
								   ,22826
								   ,22832
								   ,22831
								   ,22830
								   ,22569
								   ,17397
								   ,17396
								   ,3739
								   ,17395
								   ,3061
								   ,17376
								   ,17375
								   ,17374
								   ,17373
								   ,5230
								   ,17406
								   ,16915
								   ,17394
								   ,9914
								   ,9883
								   ,10343
								   ,9909
								   ,2889
								   ,9905
								   ,9902
								   ,9899
								   ,9897
								   ,9895
								   ,9893
								   ,9891
								   ,9890
								   ,9887
								   ,9886
								   ,9882
								   ,9878
								   ,9877
								   ,9868
								   ,9869
								   ,9865
								   ,9864
								   ,9861
								   ,9860
								   ,9859
								   ,9855
								   ,9854
								   ,9851
								   ,5204
								   ,9848
								   ,9847
								   ,9825
								   ,9822
								   ,9911
								   ,9759
								   ,9757
								   ,9753
								   ,9755
								   ,9751
								   ,8935
								   ,8934
								   ,8933
								   ,8932
								   ,8931
								   ,8930
								   ,8922
								   ,8915
								   ,11594
								   ,2920
								   ,2919
								   ,1436
								   ,1435
								   ,8954
								   ,8953
								   ,8952
								   ,2914
								   ,18660
								   ,18659
								   ,5299
								   ,3030
								   ,6786
								   ,1422
								   ,2092
								   ,1431
								   ,1439
								   ,5235
								   ,5233
								   ,5231
								   ,5226
								   ,8904
								   ,5203
								   ,1829
								   ,1828
								   ,5222
								   ,5218
								   ,5216
								   ,5212
								   ,5210
								   ,5194
								   ,5193
								   ,5192
								   ,5190
								   ,6790
								   ,5184
								   ,5183
								   ,5182
								   ,5181
								   ,499
								   ,3139
								   ,1448
								   ,20722
								   ,6812
								   ,6811
								   ,6779
								   ,6782
								   ,6801
								   ,6799
								   ,6781
								   ,6794
								   ,1428
								   ,1827
								   ,22894
								   ,1433
								   ,8993
								   ,8911
								   ,3628
								   ,2093
								   ,8973
								   ,8908
								   ,8984
								   ,1415
								   ,1414
								   ,8945
								   ,8944
								   ,8943
								   ,8942
								   ,8937
								   ,8906
								   ,8920
								   ,9006
								   ,9001
								   ,8999
								   ,1151
								   ,2788
								   ,8956
								   ,2910
								   ,1737
								   ,1736
								   ,20745} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 24015, InventoryTypes.TwoHanded, 2, 10, 2, 1, 0, 0, 0 ));
		}
	}
	
}