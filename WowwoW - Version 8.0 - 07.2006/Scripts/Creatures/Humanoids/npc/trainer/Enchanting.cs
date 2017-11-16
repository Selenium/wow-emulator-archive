//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Jhag : BaseCreature 
	{ 
		public  Jhag() : base() 
		{ 
			Model = 10589;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Jhag" ;
			Flags1 = 0x08480046 ;
			Id = 11066 ; 
			Guild = "Journeyman Enchanter";
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
			BaseHitPoints = 944 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 25, 32 );
			NpcText00 = "Greetings $N, I am Jhag." ;
			BaseMana = 0 ;
			Trains = new int[] {7414
								   ,7415   
								   ,14805  
								   ,7422   
								   ,7429
								   ,13373
								   ,7441
								   ,7459
								   ,7749
								   ,7461
								   ,14808
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23177, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
		}
	}
	public class MalcombWynn : BaseCreature 
	{ 
		public  MalcombWynn() : base() 
		{ 
			Model = 10590;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Malcomb Wynn" ;
			Flags1 = 0x018480046 ;
			Id = 11067 ; 
			Guild = "Journeyman Enchanter";
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
			Level = RandomLevel( 23 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 944 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 25, 32 );
			NpcText00 = "Greetings $N, I am Malcomb Wynn." ;
			BaseMana = 0 ;
			Trains = new int[] {13373
								   ,7429
								   ,14805
								   ,7422
								   ,7461
								   ,7749
								   ,7414
								   ,7459
								   ,7441
								   ,14808} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7443, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ), new Item( 23321, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
		}
	}
	public class BettyQuin : BaseCreature 
	{ 
		public  BettyQuin() : base() 
		{ 
			Model = 10591;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Betty Quin" ;
			Flags1 = 0x08480046 ;
			Id = 11068 ; 
			Guild = "Journeyman Enchanter";
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
			NpcText00 = "Greetings $N, I am Betty Quin." ;
			BaseMana = 0 ;
			Trains = new int[] {7414
								   ,7415
								   ,14805
								   ,7422
								   ,7429
								   ,13373
								   ,7441
								   ,7459
								   ,7749
								   ,7461
								   ,14808
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}

	public class LalinaSummermoon : BaseCreature 
	{ 
		public  LalinaSummermoon() : base() 
		{ 
			Model = 10592;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Lalina Summermoon" ;
			Flags1 = 0x08480046 ;
			Id = 11070 ; 
			Guild = "Journeyman Enchanter";
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
			BaseHitPoints = 1104 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 29, 38 );
			NpcText00 = "Greetings $N, I am Lalina Summermoon." ;
			BaseMana = 0 ;
			Trains = new int[] {13373
								   ,14805
								   ,14808
								   ,7441
								   ,7459
								   ,7414
								   ,7749
								   ,7461
								   ,7422
								   ,7429} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23590, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class MotDawnstrider : BaseCreature 
	{ 
		public  MotDawnstrider() : base() 
		{ 
			Model = 10614;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Mot Dawnstrider" ;
			Flags1 = 0x08480046 ;
			Id = 11071 ; 
			Guild = "Journeyman Enchanter";
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
			CombatReach = 4.05f ;
			SetDamage ( 22, 29 );
			NpcText00 = "Greetings $N, I am Mot Dawnstrider." ;
			BaseMana = 0 ;
			Trains = new int[] {13373
								   ,7422
								   ,7461
								   ,7749
								   ,7414
								   ,7459
								   ,7441
								   ,14808
								   ,7429
								   ,14805} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23171, InventoryTypes.MainGauche, 2, 14, 1, 2, 0, 0, 0 ));
		}
	}
	public class KittaFirewind : BaseCreature 
	{ 
		public  KittaFirewind() : base() 
		{ 
			Model = 10610;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Kitta Firewind" ;
			Flags1 = 0x08480046 ;
			Id = 11072 ; 
			Guild = "Artisan Enchanter";
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
			Level = RandomLevel( 44 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1785 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 48, 62 );
			NpcText00 = "Greetings $N, I am Kitta Firewind." ;
			BaseMana = 0 ;
			Trains = new int[] {13921
								   ,13749
								   ,13798
								   ,13829
								   ,13816
								   ,13837
								   ,13861
								   ,13888
								   ,13891
								   ,17184
								   ,17182
								   ,13906
								   ,13919
								   ,13936
								   ,13940
								   ,13938
								   ,13944
								   ,13942
								   ,13946
								   ,13950
								   ,7858
								   ,13422
								   ,7796
								   ,7789
								   ,13392
								   ,7746
								   ,7797} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class Annora : BaseCreature 
	{ 
		public  Annora() : base() 
		{ 
			Model = 10609;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Annora" ;
			Flags1 = 0x066 ;
			Id = 11073 ; 
			Guild = "Apprentice Enchanter";
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
			BaseHitPoints = 2186 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 59, 76 );
			NpcText00 = "Greetings $N, I am Annora." ;
			BaseMana = 0 ;
			Trains = new int[] {13660
								   ,13499
								   ,13392
								   ,7414
								   ,7796
								   ,7862
								   ,7858
								   ,7789
								   ,7797
								   ,7749
								   ,7746
								   ,7459
								   ,7461
								   ,7441
								   ,7422
								   ,7416
								   ,7415
								   ,14812
								   ,14811
								   ,17182
								   ,17184
								   ,14808
								   ,14805
								   ,13950
								   ,13944
								   ,13942
								   ,13940
								   ,13641
								   ,13638
								   ,13634
								   ,13636
								   ,13629
								   ,13539
								   ,13531
								   ,13504
								   ,13502
								   ,13701
								   ,13696
								   ,13694
								   ,13666
								   ,13662
								   ,13658
								   ,13649
								   ,13645
								   ,13643
								   ,13888
								   ,13861
								   ,13837
								   ,13829
								   ,13816
								   ,13798
								   ,13749
								   ,13921
								   ,13703
								   ,13938
								   ,13936
								   ,13919
								   ,13906
								   ,13891
								   ,13422
								   ,13623
								   ,13373
								   ,13391
								   ,7429
								   ,13627
								   ,13609} ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Hgarth : BaseCreature 
	{ 
		public  Hgarth() : base() 
		{ 
			Model = 10611;
			AttackSpeed= 1470;
			BoundingRadius = 1.00f ;
			Name = "Hgarth" ;
			Flags1 = 0x08480046 ;
			Id = 11074 ; 
			Guild = "Artisan Enchanter";
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
			BaseHitPoints = 1865 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 11.00f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Greetings $N, I am Hgarth." ;
			BaseMana = 2304 ;
			Trains = new int[] {13921
								   ,13749
								   ,13798
								   ,13829
								   ,13816
								   ,13837
								   ,13861
								   ,13888
								   ,13891
								   ,17184
								   ,17182
								   ,13906
								   ,13919
								   ,13936
								   ,13940
								   ,13938
								   ,13944
								   ,13942
								   ,13946
								   ,13950
								   ,7858 
								   ,13422
								   ,7796 
								   ,7789 
								   ,13392
								   ,7746
								   ,7797} ;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class ThonysPillarstone : BaseCreature 
	{ 
		public  ThonysPillarstone() : base() 
		{ 
			Model = 10588;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Thonys Pillarstone" ;
			Flags1 = 0x08480046 ;
			Id = 11065 ; 
			Guild = "Journeyman Enchanter";
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
			NpcText00 = "Greetings $N, I am Thonys Pillarstone." ;
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
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23177, InventoryTypes.MainGauche, 2, 14, 1, 2, 0, 0, 0 ));
		}
	}
	public class XylinniaStarshine : BaseCreature 
	{ 
		public  XylinniaStarshine() : base() 
		{ 
			Model = 7020;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Xylinnia Starshine" ;
			Flags1 = 0x08480006 ;
			Id = 7949 ; 
			Guild = "Expert Enchanter";
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
			NpcText00 = "Greetings $N, I am Xylinnia Starshine." ;
			BaseMana = 0 ;
			Trains = new int[] {7416
								   ,7862 
								   ,13499
								   ,13502
								   ,13539
								   ,13504
								   ,13609
								   ,13531
								   ,14811
								   ,13636
								   ,13627
								   ,13623
								   ,13634
								   ,13629
								   ,13638
								   ,13641
								   ,13643
								   ,13645
								   ,13649
								   ,14812
								   ,13658
								   ,13660
								   ,13662
								   ,13666
								   ,13694
								   ,13701
								   ,13696
								   ,13703} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class VanceUndergloom : BaseCreature 
	{ 
		public  VanceUndergloom() : base() 
		{ 
			Model = 4039;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Vance Undergloom" ;
			Flags1 = 0x08400046 ;
			Id = 5695 ; 
			Guild = "Journeyman Enchanter";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1264 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 33, 43 );
			NpcText00 = "Greetings $N, I am Vance Undergloom." ;
			BaseMana = 0 ;
			Trains = new int[] {7414
								   ,7415 
								   ,14805
								   ,7422 
								   ,7429 
								   ,13373
								   ,7441
								   ,7459
								   ,7749
								   ,7461
								   ,14808} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class GimbleThistlefuzz : BaseCreature 
	{ 
		public  GimbleThistlefuzz() : base() 
		{ 
			Model = 3111;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Gimble Thistlefuzz" ;
			Flags1 = 0x08480046 ;
			Id = 5157 ; 
			Guild = "Expert Enchanter";
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
			BaseHitPoints = 4272 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.725f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Gimble Thistlefuzz." ;
			BaseMana = 0 ;
			Trains = new int[] {7416
								   ,7862
								   ,13499
								   ,13502
								   ,13539
								   ,13504
								   ,13609
								   ,13531
								   ,14811
								   ,13636
								   ,13627
								   ,13623
								   ,13634
								   ,13629
								   ,13638
								   ,13641
								   ,13643
								   ,13645
								   ,13649
								   ,14812
								   ,13658
								   ,13660
								   ,13662
								   ,13666
								   ,13694
								   ,13701
								   ,13696
								   ,13703} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23455, InventoryTypes.RangeRight, 2, 19, 2, 0, 0, 0, 0 ));
		}
	}
	public class LaviniaCrowe : BaseCreature 
	{ 
		public  LaviniaCrowe() : base() 
		{ 
			Model = 12955;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Lavinia Crowe" ;
			Flags1 = 0x018480046 ;
			Id = 4616 ; 
			Guild = "Expert Enchanter";
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
			NpcText00 = "Greetings $N, I am Lavinia Crowe." ;
			BaseMana = 0 ;
			Trains = new int[] {7416
								   ,7862
								   ,13499
								   ,13502
								   ,13539
								   ,13504
								   ,13609
								   ,13531
								   ,14811
								   ,13636
								   ,13627
								   ,13623
								   ,13634
								   ,13629
								   ,13638
								   ,13641
								   ,13643
								   ,13645
								   ,13649
								   ,14812
								   ,13658
								   ,13660
								   ,13662
								   ,13666
								   ,13694
								   ,13701
								   ,13696
								   ,13703} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Taladan : BaseCreature 
	{ 
		public  Taladan() : base() 
		{ 
			Model = 2266;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Taladan" ;
			Flags1 = 0x08480046 ;
			Id = 4213 ; 
			Guild = "Expert Enchanter";
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
			NpcText00 = "Greetings $N, I am Taladan." ;
			BaseMana = 0 ;
			Trains = new int[] {7416
								   ,7862
								   ,13499
								   ,13502
								   ,13539
								   ,13504
								   ,13609
								   ,13531
								   ,14811
								   ,13636
								   ,13627
								   ,13623
								   ,13634
								   ,13629
								   ,13638
								   ,13641
								   ,13643
								   ,13645
								   ,13649
								   ,14812
								   ,13658
								   ,13660
								   ,13662
								   ,13666
								   ,13694
								   ,13701
								   ,13696
								   ,13703} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class AlannaRaveneye : BaseCreature 
	{ 
		public  AlannaRaveneye() : base() 
		{ 
			Model = 1717;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Alanna Raveneye" ;
			Flags1 = 0x08480046 ;
			Id = 3606 ; 
			Guild = "Journeyman Enchanter";
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
			BaseHitPoints = 1184 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 31, 41 );
			NpcText00 = "Greetings $N, I am Alanna Raveneye." ;
			BaseMana = 0 ;
			Trains = new int[] {13373
								   ,14805
								   ,14808
								   ,7441
								   ,7459
								   ,7414
								   ,7749
								   ,7461
								   ,7422} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Godan : BaseCreature 
	{ 
		public  Godan() : base() 
		{ 
			Model = 1366;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Godan" ;
			Flags1 = 0x08480046 ;
			Id = 3345 ; 
			Guild = "Expert Enchanter";
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
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Godan." ;
			BaseMana = 0 ;
			Trains = new int[] {7416
								   ,7862   
								   ,13499
								   ,13502
								   ,13539
								   ,13504
								   ,13609
								   ,13531
								   ,14811
								   ,13636
								   ,13627
								   ,13623
								   ,13634
								   ,13629
								   ,13638
								   ,13641
								   ,13643
								   ,13645
								   ,13649
								   ,14812
								   ,13658
								   ,13660
								   ,13662
								   ,13666
								   ,13694
								   ,13701
								   ,13696
								   ,13703} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class TegDawnstrider : BaseCreature 
	{ 
		public  TegDawnstrider() : base() 
		{ 
			Model = 2101;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Teg Dawnstrider" ;
			Flags1 = 0x08480046 ;
			Id = 3011 ; 
			Guild = "Expert Enchanter";
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
			NpcText00 = "Greetings $N, I am Teg Dawnstrider." ;
			BaseMana = 0 ;
			Trains = new int[] {7416
								   ,7862 
								   ,13499
								   ,13502
								   ,13539
								   ,13504
								   ,13609
								   ,13531
								   ,14811
								   ,13636
								   ,13627
								   ,13623
								   ,13634
								   ,13629
								   ,13638
								   ,13641
								   ,13643
								   ,13645
								   ,13649
								   ,14812
								   ,13658
								   ,13660
								   ,13662
								   ,13666
								   ,13694
								   ,13701
								   ,13696
								   ,13703} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23590, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class LucanCordell : BaseCreature 
	{ 
		public  LucanCordell() : base() 
		{ 
			Model = 1492;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Lucan Cordell" ;
			Flags1 = 0x08480046 ;
			Id = 1317 ; 
			Guild = "Expert Enchanter";
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
			NpcText00 = "Greetings $N, I am Lucan Cordell." ;
			BaseMana = 0 ;
			Trains = new int[] {7416
								   ,7862 
								   ,13499
								   ,13502
								   ,13539
								   ,13504
								   ,13609
								   ,13531
								   ,14811
								   ,13636
								   ,13627
								   ,13623
								   ,13634
								   ,13629
								   ,13638
								   ,13641
								   ,13643
								   ,13645
								   ,13649
								   ,14812
								   ,13658
								   ,13660
								   ,13662
								   ,13666
								   ,13694
								   ,13701
								   ,13696
								   ,13703} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	
}