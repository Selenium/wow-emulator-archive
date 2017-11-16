//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class MaginorDumas : BaseCreature 
	{ 
		public  MaginorDumas() : base() 
		{ 
			Model = 1484;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Maginor Dumas" ;
			Flags1 = 0x08480046 ;
			Id = 331 ; 
			Guild = "Master Mage";
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
			NpcText00 = "Greetings $N, I am Maginor Dumas." ;
			BaseMana = 0 ;
			Trains = new int[] { 1472
								   ,5507
								   ,608
								   ,477
								   ,5143
								   ,3696
								   ,619
								   ,1266
								   ,3141
								   ,1473
								   ,1467
								   ,5144
								   ,2858
								   ,1267
								   ,486
								   ,665
								   ,3577
								   ,3580
								   ,12827
								   ,3581
								   ,517
								   ,1481
								   ,5566
								   ,991
								   ,8440
								   ,5145
								   ,1053
								   ,8452
								   ,1210
								   ,8496
								   ,1474
								   ,3579
								   ,8456
								   ,3578
								   ,6128
								   ,8441
								   ,8416
								   ,6130
								   ,8453
								   ,8497
								   ,3553
								   ,8442
								   ,11423
								   ,8417
								   ,11421
								   ,10141
								   ,11425
								   ,12828
								   ,1851
								   ,10171
								   ,1475
								   ,10146
								   ,10194
								   ,10203
								   ,10211
								   ,10175
								   ,10055
								   ,10142
								   ,11424
								   ,11422
								   ,10195
								   ,10147
								   ,10172
								   ,10204
								   ,10212
								   ,10158
								   ,10056
								   ,12829
								   ,10176
								   ,10196
								   ,2141
								   ,483
								   ,502
								   ,2142
								   ,846
								   ,854
								   ,874
								   ,1811
								   ,2143
								   ,1830
								   ,872
								   ,8403
								   ,8447
								   ,13011
								   ,8414
								   ,8404
								   ,1831
								   ,8459
								   ,8425
								   ,8448
								   ,8405
								   ,13023
								   ,13012
								   ,8415
								   ,8449
								   ,8460
								   ,8426
								   ,10152
								   ,13014
								   ,13024
								   ,10208
								   ,10198
								   ,13015
								   ,10217
								   ,10153
								   ,10224
								   ,13025
								   ,10209
								   ,10154
								   ,13016
								   ,10200
								   ,10218
								   ,10210
								   ,13017
								   ,13026
								   ,10226
								   ,10155
								   ,6116
								   ,478
								   ,494
								   ,484
								   ,497
								   ,838
								   ,7323
								   ,1196
								   ,1200
								   ,3723
								   ,1241
								   ,866
								   ,8409
								   ,3068
								   ,506
								   ,8410
								   ,8463
								   ,8493
								   ,8428
								   ,8411
								   ,2890
								   ,844
								   ,6132
								   ,8464
								   ,10162
								   ,10182
								   ,10188
								   ,13037
								   ,10183
								   ,10163
								   ,10221
								   ,13038
								   ,10178
								   ,10189
								   ,10231
								   ,10184
								   ,13039
								   ,10164
								   ,10190
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Theocritus : BaseCreature 
	{ 
		public  Theocritus() : base() 
		{ 
			Model = 3348;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Theocritus" ;
			Flags1 = 0x08480046 ;
			Id = 313 ; 
			Guild = "Mage of Tower Azora";
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
			NpcFlags = 0x2;
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Theocritus." ;
			BaseMana = 0 ;
			/*Trains = new int[] {  6116   // Frost Armor (5262)
									   , 1472   // Arcane Intellect (39595)
									   , 1142   // Frostbolt (3368)
									   , 5507   // Conjure Water (92843)
									   , 1173   // Fireball (4717)
									   , 2141   // Fire Blast (53034)
									   , 1249   // Conjure Food (14199)
									   , 1191   // Frostbolt (3368)
									   , 1168   // Polymorph (3520)
									   , 5146   // Arcane Missiles (135530)
									   , 1194   // Frost Nova (4035)
									   , 1174   // Frost Armor (5262)
									   , 5565   // Conjure Water (92843)
			  } ;*/
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7465, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class Uthelnay : BaseCreature 
	{ 
		public  Uthelnay() : base() 
		{ 
			Model = 6060;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Uthel'nay" ;
			Flags1 = 0x08480046 ;
			Id = 7311 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405
							   } ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22394, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Enyo : BaseCreature 
	{ 
		public  Enyo() : base() 
		{ 
			Model = 4522;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Enyo" ;
			Flags1 = 0x08480046 ;
			Id = 5883 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8073, InventoryTypes.MainGauche, 2, 4, 2, 0, 0, 0, 0 ));
		}
	}
	public class Maiah : BaseCreature 
	{ 
		public  Maiah() : base() 
		{ 
			Model = 4526;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Mai'ah" ;
			Flags1 = 0x08080066 ;
			Id = 5884 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {1173
								   ,1142
								   ,2141
								   ,1249
								   ,1472
								   ,5507} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 5010, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Deino : BaseCreature 
	{ 
		public  Deino() : base() 
		{ 
			Model = 4523;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Deino" ;
			Flags1 = 0x08480046 ;
			Id = 5885 ; 
			Guild = "Mage Trainer";
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
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405 } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 21094, InventoryTypes.RangeRight, 2, 19, 2, 0, 0, 0, 0 ));
		}
	}
	public class Pephredo : BaseCreature 
	{ 
		public  Pephredo() : base() 
		{ 
			Model = 4524;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Pephredo" ;
			Flags1 = 0x08480046 ;
			Id = 5882 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7459, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class UnThuwa : BaseCreature 
	{ 
		public  UnThuwa() : base() 
		{ 
			Model = 10171;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Un'Thuwa" ;
			Flags1 = 0x08480046 ;
			Id = 5880 ; 
			Guild = "Mage Trainer";
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
			CombatReach = 1.5f ;
			SetDamage ( 15, 19 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 5010, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class JenneaCannon : BaseCreature 
	{ 
		public  JenneaCannon() : base() 
		{ 
			Model = 3292;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Jennea Cannon" ;
			Flags1 = 0x08480046 ;
			Id = 5497 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};

		}
	}
	public class Elsharin : BaseCreature 
	{ 
		public  Elsharin() : base() 
		{ 
			Model = 3293;
			AttackSpeed= 2000;
			BoundingRadius = 0.214000f ;
			Name = "Elsharin" ;
			Flags1 = 0x08480046 ;
			Id = 5498 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] { 8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Bink : BaseCreature 
	{ 
		public  Bink() : base() 
		{ 
			Model = 3108;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Bink" ;
			Flags1 = 0x08480046 ;
			Id = 5144 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405
							   } ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class JuliStormkettle : BaseCreature 
	{ 
		public  JuliStormkettle() : base() 
		{ 
			Model = 10214;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Juli Stormkettle" ;
			Flags1 = 0x08480046 ;
			Id = 5145 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class NittleburSparkfizzle : BaseCreature 
	{ 
		public  NittleburSparkfizzle() : base() 
		{ 
			Model = 3109;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Nittlebur Sparkfizzle" ;
			Flags1 = 0x08480046 ;
			Id = 5146 ; 
			Guild = "Mage Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class KaelystiaHatebringer : BaseCreature 
	{ 
		public  KaelystiaHatebringer() : base() 
		{ 
			Model = 10733;
			AttackSpeed= 2000;
			BoundingRadius = 0.500000f ;
			Name = "Kaelystia Hatebringer" ;
			Flags1 = 0x08400046 ;
			Id = 4566 ; 
			Guild = "Mage Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 2426 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.25f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class PierceShackleton : BaseCreature 
	{ 
		public  PierceShackleton() : base() 
		{ 
			Model = 2644;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Pierce Shackleton" ;
			Flags1 = 0x08400046 ;
			Id = 4567 ; 
			Guild = "Mage Trainer";
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
			BaseHitPoints = 2226 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 60, 77 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class AnastasiaHartwell : BaseCreature 
	{ 
		public  AnastasiaHartwell() : base() 
		{ 
			Model = 2657;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Anastasia Hartwell" ;
			Flags1 = 0x08400046 ;
			Id = 4568 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class UrsynGhull : BaseCreature 
	{ 
		public  UrsynGhull() : base() 
		{ 
			Model = 6058;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Ursyn Ghull" ;
			Flags1 = 0x08400046 ;
			Id = 3048 ; 
			Guild = "Mage Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class ThurstonXane : BaseCreature 
	{ 
		public  ThurstonXane() : base() 
		{ 
			Model = 2135;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Thurston Xane" ;
			Flags1 = 0x08400046 ;
			Id = 3049 ; 
			Guild = "Mage Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 23324, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 23455, InventoryTypes.RangeRight, 2, 19, 2, 0, 0, 0, 0 ));
		}
	}
	public class ArchmageShymm : BaseCreature 
	{ 
		public  ArchmageShymm() : base() 
		{ 
			Model = 2134;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Archmage Shymm" ;
			Flags1 = 0x08400046 ;
			Id = 3047 ; 
			Guild = "Mage Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 2426 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ),new Item( 23322, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
		}
	}
	public class CainFiresong : BaseCreature 
	{ 
		public  CainFiresong() : base() 
		{ 
			Model = 1600;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Cain Firesong" ;
			Flags1 = 0x08400046 ;
			Id = 2128 ; 
			Guild = "Mage Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 15, 19 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Isabella : BaseCreature 
	{ 
		public  Isabella() : base() 
		{ 
			Model = 1592;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Isabella" ;
			Flags1 = 0x08000066 ;
			Id = 2124 ; 
			Guild = "Mage Trainer";
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
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {1173
								   ,1142
								   ,2141
								   ,1249
								   ,1472
								   ,5507} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 21251, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class MagisSparkmantle : BaseCreature 
	{ 
		public  MagisSparkmantle() : base() 
		{ 
			Model = 10215;
			AttackSpeed= 1500;
			BoundingRadius = 0.351900f ;
			Name = "Magis Sparkmantle" ;
			Flags1 = 0x08480046 ;
			Id = 1228 ; 
			Guild = "Mage Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class MarrykNurribit : BaseCreature 
	{ 
		public  MarrykNurribit() : base() 
		{ 
			Model = 10216;
			AttackSpeed= 1500;
			BoundingRadius = 0.351900f ;
			Name = "Marryk Nurribit" ;
			Flags1 = 0x08080066 ;
			Id = 944 ; 
			Guild = "Mage Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {1173
								   ,1142
								   ,2141
								   ,1249
								   ,1472
								   ,5507} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class ZaldimarWefhellt : BaseCreature 
	{ 
		public  ZaldimarWefhellt() : base() 
		{ 
			Model = 1294;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Zaldimar Wefhellt" ;
			Flags1 = 0x08480046 ;
			Id = 328 ; 
			Guild = "Mage Trainer";
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
			BaseHitPoints = 150 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Hello, mage!  Ready for some training?" ;
			BaseMana = 0 ;
			Trains = new int[] {8420
								   ,8421
								   ,8404
								   ,8428
								   ,8426
								   ,8410
								   ,8459
								   ,8463
								   ,8447
								   ,10056
								   ,10055
								   ,3553
								   ,12828
								   ,12827
								   ,1168
								   ,8449
								   ,8448
								   ,1811
								   ,10146
								   ,10158
								   ,1475
								   ,10155
								   ,10154
								   ,10153
								   ,10152
								   ,10142
								   ,10141
								   ,10189
								   ,10188
								   ,10184
								   ,10183
								   ,10182
								   ,10178
								   ,8464
								   ,10172
								   ,10171
								   ,10164
								   ,10163
								   ,10162
								   ,10147
								   ,13015
								   ,13014
								   ,13012
								   ,13011
								   ,1830
								   ,22785
								   ,6121
								   ,13017
								   ,22784
								   ,7323
								   ,8414
								   ,6132
								   ,6142
								   ,6130
								   ,6128
								   ,1228
								   ,1196
								   ,6493
								   ,2125
								   ,2124
								   ,2142
								   ,2141
								   ,1474
								   ,8497
								   ,8496
								   ,1481
								   ,3142
								   ,5507
								   ,5499
								   ,5148
								   ,5147
								   ,5146
								   ,1035
								   ,1200
								   ,3576
								   ,6144
								   ,12829
								   ,10231
								   ,10226
								   ,10224
								   ,10222
								   ,10221
								   ,10218
								   ,10217
								   ,10176
								   ,10175
								   ,10214
								   ,10213
								   ,10210
								   ,10209
								   ,10208
								   ,10204
								   ,10203
								   ,10200
								   ,10198
								   ,10196
								   ,10195
								   ,10194
								   ,10190
								   ,2858
								   ,8493
								   ,1241
								   ,8453
								   ,8452
								   ,1266
								   ,8456
								   ,1267
								   ,8442
								   ,8441
								   ,8440
								   ,1467
								   ,1473
								   ,1472
								   ,1198
								   ,1194
								   ,8415
								   ,1191
								   ,1176
								   ,1174
								   ,1173
								   ,1142
								   ,8403
								   ,5566
								   ,5565
								   ,1214
								   ,1210
								   ,1251
								   ,1250
								   ,1249
								   ,1225
								   ,2143
								   ,1211
								   ,13039
								   ,13038
								   ,13037
								   ,13026
								   ,13025
								   ,13024
								   ,13023
								   ,13016
								   ,8460
								   ,8411
								   ,8409
								   ,8425
								   ,8405} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	
}