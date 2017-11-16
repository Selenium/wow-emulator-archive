//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class NaraMeideros : BaseCreature 
	{ 
		public  NaraMeideros() : base() 
		{ 
			Model = 11044;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Nara Meideros" ;
			Flags1 = 0x0400006 ;
			Id = 11397 ; 
			Guild = "Priest Trainer";
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
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Nara Meideros." ;
			BaseMana = 2175 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Alliance;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class PriestessAlathea : BaseNPC 
	{ 
		public  PriestessAlathea() : base() 
		{ 
			Model = 11048;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Priestess Alathea" ;
			Flags1 = 0x0480006 ;
			Id = 11401 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Priestess Alathea." ;
			BaseMana = 5751 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Alliance;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class Urkyo : BaseCreature 
	{ 
		public  Urkyo() : base() 
		{ 
			Model = 4711;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Urkyo" ;
			Flags1 = 0x08480046 ;
			Id = 6018 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Urkyo." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class Xyera : BaseCreature 
	{ 
		public  Xyera() : base() 
		{ 
			Model = 10473;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "X'yera" ;
			Flags1 = 0x08480046 ;
			Id = 6014 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am X'yera." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 22598, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 )); 
		}
	}
	public class BrotherJoshua : BaseCreature 
	{ 
		public  BrotherJoshua() : base() 
		{ 
			Model = 3283;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Brother Joshua" ;
			Flags1 = 0x08480046 ;
			Id = 5489 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Brother Joshua." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class BrotherBenjamin : BaseCreature 
	{ 
		public  BrotherBenjamin() : base() 
		{ 
			Model = 3282;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Brother Benjamin" ;
			Flags1 = 0x08480046 ;
			Id = 5484 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Brother Benjamin." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class TheodrusFrostbeard : BaseCreature 
	{ 
		public  TheodrusFrostbeard() : base() 
		{ 
			Model = 3086;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Theodrus Frostbeard" ;
			Flags1 = 0x08480046 ;
			Id = 5141 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Theodrus Frostbeard." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1926, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class BraennaFlintcrag : BaseCreature 
	{ 
		public  BraennaFlintcrag() : base() 
		{ 
			Model = 3066;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Braenna Flintcrag" ;
			Flags1 = 0x08480046 ;
			Id = 5142 ; 
			Guild = "Priest Trainer";
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
			BaseHitPoints = 2426 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Braenna Flintcrag." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ),new Item( 21094, InventoryTypes.RangeRight, 2, 19, 2, 0, 0, 0, 0 )); 
		}
	}
	public class ToldrenDeepiron : BaseCreature 
	{ 
		public  ToldrenDeepiron() : base() 
		{ 
			Model = 3085;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Toldren Deepiron" ;
			Flags1 = 0x08480046 ;
			Id = 5143 ; 
			Guild = "Priest Trainer";
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
			BaseHitPoints = 1825 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Toldren Deepiron." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class Aelthalyste : BaseCreature 
	{ 
		public  Aelthalyste() : base() 
		{ 
			Model = 10723;
			AttackSpeed= 2000;
			BoundingRadius = 0.500000f ;
			Name = "Aelthalyste" ;
			Flags1 = 0x08480046 ;
			Id = 4606 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Aelthalyste." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class FatherLankester : BaseCreature 
	{ 
		public  FatherLankester() : base() 
		{ 
			Model = 2626;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Father Lankester" ;
			Flags1 = 0x018480046 ;
			Id = 4607 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Father Lankester." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 2388, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class FatherLazarus : BaseCreature 
	{ 
		public  FatherLazarus() : base() 
		{ 
			Model = 2618;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Father Lazarus" ;
			Flags1 = 0x018480046 ;
			Id = 4608 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Father Lazarus." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7479, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 )); 
		}
	}
	public class Lariia : BaseCreature 
	{ 
		public  Lariia() : base() 
		{ 
			Model = 2202;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Lariia" ;
			Flags1 = 0x08480046 ;
			Id = 4092 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Lariia." ;
			BaseMana = 3191 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class AstariiStarseeker : BaseCreature 
	{ 
		public  AstariiStarseeker() : base() 
		{ 
			Model = 2200;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Astarii Starseeker" ;
			Flags1 = 0x08480046 ;
			Id = 4090 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Astarii Starseeker." ;
			BaseMana = 5751 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1926, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class Jandria : BaseCreature 
	{ 
		public  Jandria() : base() 
		{ 
			Model = 2201;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Jandria" ;
			Flags1 = 0x08480046 ;
			Id = 4091 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Jandria." ;
			BaseMana = 4393 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class Taijin : BaseCreature 
	{ 
		public  Taijin() : base() 
		{ 
			Model = 1897;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Tai'jin" ;
			Flags1 = 0x08480046 ;
			Id = 3706 ; 
			Guild = "Priest Trainer";
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
			Level = RandomLevel( 18 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 664 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 17, 22 );
			NpcText00 = "Greetings $N, I am Tai'jin." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1926, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class Kenjai : BaseCreature 
	{ 
		public  Kenjai() : base() 
		{ 
			Model = 4068;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Ken'jai" ;
			Flags1 = 0x08080066 ;
			Id = 3707 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Ken'jai." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,2051
								   ,1275
								   ,1258} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7442, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 )); 
		}
	}
	public class LaurnaMorninglight : BaseNPC 
	{ 
		public  LaurnaMorninglight() : base() 
		{ 
			Model = 1708;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Laurna Morninglight" ;
			Flags1 = 0x08480046 ;
			Id = 3600 ; 
			Guild = "Priest Trainer";
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
			Level = RandomLevel( 21 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 864 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 22, 29 );
			NpcText00 = "Greetings $N, I am Laurna Morninglight." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1926, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class Shanda : BaseNPC 
	{ 
		public  Shanda() : base() 
		{ 
			Model = 1733;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Shanda" ;
			Flags1 = 0x08080066 ;
			Id = 3595 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Shanda." ;
			BaseMana = 0 ;
			Trains = new int[] {1255 
								   ,2851 
								   ,2051 
								   ,1275 
								   ,1258 } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7478, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 )); 
		}
	}
	public class DarkClericBeryl : BaseCreature 
	{ 
		public  DarkClericBeryl() : base() 
		{ 
			Model = 1602;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Dark Cleric Beryl" ;
			Flags1 = 0x08400046 ;
			Id = 2129 ; 
			Guild = "Priest Trainer";
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
			Level = RandomLevel( 17 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 704 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 18, 23 );
			NpcText00 = "Greetings $N, I am Dark Cleric Beryl." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7478, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 )); 
		}
	}
	public class DarkClericDuesten : BaseCreature 
	{ 
		public  DarkClericDuesten() : base() 
		{ 
			Model = 1579;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Dark Cleric Duesten" ;
			Flags1 = 0x08000066 ;
			Id = 2123 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Dark Cleric Duesten." ;
			BaseMana = 0 ;
			Trains = new int[] {2056
								   ,1275
								   ,2851
								   ,1258} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7478, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 )); 
		}
	}
	public class MaxanAnvol : BaseCreature 
	{ 
		public  MaxanAnvol() : base() 
		{ 
			Model = 3429;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Maxan Anvol" ;
			Flags1 = 0x08480046 ;
			Id = 1226 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Maxan Anvol." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 24595, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 )); 
		}
	}
	public class BranstockKhalder : BaseCreature 
	{ 
		public  BranstockKhalder() : base() 
		{ 
			Model = 3401;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Branstock Khalder" ;
			Flags1 = 0x08080066 ;
			Id = 837 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Branstock Khalder." ;
			BaseMana = 0 ;
			Trains = new int[] {1255 
								   ,2851 
								   ,2051 
								   ,1275 
								   ,1258 } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class HighPriestessLaurena : BaseCreature 
	{ 
		public  HighPriestessLaurena() : base() 
		{ 
			Model = 1495;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "High Priestess Laurena" ;
			Flags1 = 0x08480046 ;
			Id = 376 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am High Priestess Laurena." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1926, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class PriestessJosetta : BaseCreature 
	{ 
		public  PriestessJosetta() : base() 
		{ 
			Model = 1295;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Priestess Josetta" ;
			Flags1 = 0x08480046 ;
			Id = 377 ; 
			Guild = "Priest Trainer";
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
			NpcText00 = "Greetings $N, I am Priestess Josetta." ;
			BaseMana = 0 ;
			Trains = new int[] {1255
								   ,2851
								   ,1252
								   ,1256
								   ,1277
								   ,1283
								   ,1278
								   ,19351
								   ,7130
								   ,1425
								   ,8130
								   ,1257
								   ,1298
								   ,19352
								   ,19358
								   ,1253
								   ,6067
								   ,8132
								   ,6492
								   ,19353
								   ,1284
								   ,2793
								   ,6068
								   ,19359
								   ,1254
								   ,10877
								   ,9486
								   ,6386
								   ,10902
								   ,19354
								   ,10878
								   ,10939
								   ,10903
								   ,19360
								   ,11025
								   ,19355
								   ,14820
								   ,10904
								   ,10879
								   ,19356
								   ,19361
								   ,11026
								   ,10940
								   ,10905
								   ,10956
								   ,2056
								   ,1275
								   ,6073
								   ,2057
								   ,2013
								   ,1268
								   ,6079
								   ,1276
								   ,2058
								   ,2066
								   ,6080
								   ,2059
								   ,2016
								   ,1300
								   ,15452
								   ,9475
								   ,6081
								   ,6071
								   ,15454
								   ,1287
								   ,1301
								   ,1269
								   ,9476
								   ,6082
								   ,6072
								   ,10882
								   ,15455
								   ,9477
								   ,6083
								   ,6062
								   ,2065
								   ,1288
								   ,15457
								   ,10918
								   ,10930
								   ,2069
								   ,10883
								   ,10935
								   ,15459
								   ,10919
								   ,3046
								   ,2049
								   ,10931
								   ,2067
								   ,15460
								   ,10936
								   ,10920
								   ,10932
								   ,2068
								   ,15434
								   ,20771
								   ,18806
								   ,10962
								   ,1258
								   ,1265
								   ,8093
								   ,1259
								   ,8123
								   ,8107
								   ,1260
								   ,9580
								   ,8126
								   ,8108
								   ,2097
								   ,1261
								   ,8109
								   ,7378
								   ,8125
								   ,9581
								   ,1293
								   ,1279
								   ,8110
								   ,2799
								   ,17316
								   ,8193
								   ,9593
								   ,8111
								   ,10889
								   ,1280
								   ,10895
								   ,10913
								   ,17317
								   ,10910
								   ,10948
								   ,10943
								   ,10896
								   ,10949
								   ,17318
								   ,10954
								   ,10891
								   ,10959
								   ,10950
								   ,10914
								   ,10897
								   ,10944
								   ,18808} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class PriestessAnetta : BaseCreature 
	{ 
		public  PriestessAnetta() : base() 
		{ 
			Model = 3344;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Priestess Anetta" ;
			Flags1 = 0x08080066 ;
			Id = 375 ; 
			Guild = "Priest Trainer";
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
			SetDamage ( 14, 18 );
			NpcText00 = "Greetings $N, I am Priestess Anetta." ;
			BaseMana = 0 ;
			Trains = new int[] {1255 
								   ,2851 
								   ,2051 
								   ,1275 
								   ,1258 } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	
}