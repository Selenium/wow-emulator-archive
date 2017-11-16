//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class RandalWorth : BaseCreature 
	{ 
		public  RandalWorth() : base() 
		{ 
			Model = 10625;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Randal Worth" ;
			Flags1 = 0x08480046 ;
			Id = 11096 ; 
			Guild = "Journeyman Leatherworker";
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
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23171, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class DrakkStonehand : BaseCreature 
	{ 
		public  DrakkStonehand() : base() 
		{ 
			Model = 10622;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Drakk Stonehand" ;
			Flags1 = 0x08480046 ;
			Id = 11097 ; 
			Guild = "Master Leatherworking Trainer";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {3811
								   ,9145
								   ,3766
								   ,3768
								   ,3818
								   ,3770
								   ,9194
								   ,9193
								   ,3764
								   ,3760
								   ,3780
								   ,3772
								   ,7148
								   ,3774
								   ,4096
								   ,4097
								   ,9196
								   ,7152
								   ,10482
								   ,3776
								   ,9212
								   ,3778
								   ,9201
								   ,7156
								   ,6661
								   ,9206
								   ,10487
								   ,10662
								   ,10507
								   ,10499
								   ,10518
								   ,10511
								   ,14932
								   ,14930
								   ,10621
								   ,10550
								   ,10548
								   ,10630
								   ,10552
								   ,10558
								   ,10556
								   ,10632
								   ,10647
								   ,10660
								   ,10658
								   ,10656
								   ,10619
								   ,10650} ;
			Faction = Factions.WildHammerClan;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class HahranaIronhide : BaseCreature 
	{ 
		public  HahranaIronhide() : base() 
		{ 
			Model = 10623;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Hahrana Ironhide" ;
			Flags1 = 0x08480046 ;
			Id = 11098 ; 
			Guild = "Master Leatherworker";
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
			CombatReach = 3.75f ;
			SetDamage ( 60, 77 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {5244  //Pattern: Kodo Hide Bag
								   ,2163  //Pattern: White Leather Jerkin
								   ,2164  //Pattern: Fine Leather Gloves
								   ,8322  //Pattern: Moonglow Vest
								   ,7953  //Pattern: Deviate Scale Cloak
								   ,2158  //Pattern: Fine Leather Boots
								   ,6702  //Pattern: Murloc Scale Bracers
								   ,6703  //Pattern: Murloc Scale Breastplate
								   ,2169  //Pattern: Dark Leather Tunic
								   ,3762  //Pattern: Hillman's Leather Vest
								   ,7954  //Pattern: Deviate Scale Gloves
								   ,7133  //Pattern: Fine Leather Pants
								   ,7955  //Pattern: Deviate Scale Belt
								   ,3767  //Pattern: Hillman's Belt
								   ,3765  //Pattern: Dark Leather Gloves
								   ,9147  //Pattern: Earthen Leather Shoulders
								   ,9146  //Pattern: Herbalist's Gloves
								   ,3769  //Pattern: Dark Leather Shoulders
								   ,9148  //Pattern: Pilferer's Gloves
								   ,3771  //Pattern: Barbaric Gloves
								   ,9149  //Pattern: Heavy Earthen Gloves
								   ,9195  //Pattern: Dusky Leather Leggings
								   ,7150  //Pattern: Barbaric Leggings
								   ,3775  //Pattern: Guardian Belt
								   ,6704  //Pattern: Thick Murloc Armor
								   ,9197  //Pattern: Green Whelp Armor
								   ,3773  //Pattern: Guardian Armor
								   ,7153  //Pattern: Guardian Cloak
								   ,9202  //Pattern: Green Whelp Bracers
								   ,6705  //Pattern: Murloc Scale Bracers
								   ,3777  //Pattern: Guardian Leather Bracers
								   ,9208  //Pattern: Swift Boots
								   ,10490 //Pattern: Comfortable Leather Hat
								   ,3779  //Pattern: Barbaric Belt
								   ,9207  //Pattern: Dusky Boots
								   ,10509 //Pattern: Turtle Scale Gloves
								   ,10516 //Pattern: Nightscape Shoulders
								   ,10520 //Pattern: Big Voodoo Robe
								   ,10531 //Pattern: Big Voodoo Mask
								   ,10533 //Pattern: Tough Scorpid Bracers
								   ,10525 //Pattern: Tough Scorpid Breastplate
								   ,10529 //Pattern: Wild Leather Shoulders
								   ,10546 //Pattern: Wild Leather Helmet
								   ,10544 //Pattern: Wild Leather Vest
								   ,10542 //Pattern: Tough Scorpid Gloves
								   ,10554 //Pattern: Tough Scorpid Boots
								   ,10564 //Pattern: Tough Scorpid Shoulders
								   ,10562 //Pattern: Big Voodoo Cloak
								   ,10560 //Pattern: Big Voodoo Pants
								   ,10568 //Pattern: Tough Scorpid Leggings
								   ,10566 //Pattern: Wild Leather Boots
								   ,10574 //Pattern: Wild Leather Cloak
								   ,10572 //Pattern: Wild Leather Leggings
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class Tarn : BaseCreature 
	{ 
		public  Tarn() : base() 
		{ 
			Model = 10617;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Tarn" ;
			Flags1 = 0x08480046 ;
			Id = 11084 ; 
			Guild = "Expert Leatherworker";
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
			Level = RandomLevel( 36 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 39, 50 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22319, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 6531, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class Darianna : BaseCreature 
	{ 
		public  Darianna() : base() 
		{ 
			Model = 10615;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Darianna" ;
			Flags1 = 0x08480046 ;
			Id = 11083 ; 
			Guild = "Journeyman Leatherworker";
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
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Faldron : BaseCreature 
	{ 
		public  Faldron() : base() 
		{ 
			Model = 10616;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Faldron" ;
			Flags1 = 0x08480046 ;
			Id = 11081 ; 
			Guild = "Expert Leatherworker";
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
			Level = RandomLevel( 32 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class ThorkafDragoneye : BaseCreature 
	{ 
		public  ThorkafDragoneye() : base() 
		{ 
			Model = 6916;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Thorkaf Dragoneye" ;
			Flags1 = 0x08400046 ;
			Id = 7867 ; 
			Guild = "Master Dragonscale Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {10619
								   ,10650
								   ,10656
								   ,10656
								   ,10619
								   ,10650 } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 3776, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));
		}
	}
	public class SarahTanner : BaseCreature 
	{ 
		public  SarahTanner() : base() 
		{ 
			Model = 7030;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Sarah Tanner" ;
			Flags1 = 0x08480046 ;
			Id = 7868 ; 
			Guild = "Master Elemental Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {10658} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class BrumnWinterhoof : BaseCreature 
	{ 
		public  BrumnWinterhoof() : base() 
		{ 
			Model = 6918;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Brumn Winterhoof" ;
			Flags1 = 0x08480046 ;
			Id = 7869 ; 
			Guild = "Master Elemental Leatherworker";
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
			BaseHitPoints = 1945 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 52, 67 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {0};
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5224, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class CaryssiaMoonhunter : BaseCreature 
	{ 
		public  CaryssiaMoonhunter() : base() 
		{ 
			Model = 6919;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Caryssia Moonhunter" ;
			Flags1 = 0x08480046 ;
			Id = 7870 ; 
			Guild = "Tribal Leatherworking Trainer";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {10660} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class SeJib : BaseCreature 
	{ 
		public  SeJib() : base() 
		{ 
			Model = 7042;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Se'Jib" ;
			Flags1 = 0x08480046 ;
			Id = 7871 ; 
			Guild = "Master Tribal Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {10660} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class PeterGalen : BaseCreature 
	{ 
		public  PeterGalen() : base() 
		{ 
			Model = 6917;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Peter Galen" ;
			Flags1 = 0x08480046 ;
			Id = 7866 ; 
			Guild = "Master Dragonscale Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {10656
								   ,10619
								   ,10650} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class Kamari : BaseCreature 
	{ 
		public  Kamari() : base() 
		{ 
			Model = 4350;
			AttackSpeed= 1739;
			BoundingRadius = 0.236000f ;
			Name = "Kamari" ;
			Flags1 = 0x08480046 ;
			Id = 5811 ; 
			Guild = "Journeyman Leatherworker";
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
			BaseHitPoints = 1064 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 28, 36 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Waldor : BaseCreature 
	{ 
		public  Waldor() : base() 
		{ 
			Model = 4288;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Waldor" ;
			Flags1 = 0x066 ;
			Id = 5784 ; 
			Guild = "Journeyman Leatherworker";
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
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class SimonTanner : BaseCreature 
	{ 
		public  SimonTanner() : base() 
		{ 
			Model = 3449;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Simon Tanner" ;
			Flags1 = 0x08480046 ;
			Id = 5564 ; 
			Guild = "Expert Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class FimbleFinespindle : BaseCreature 
	{ 
		public  FimbleFinespindle() : base() 
		{ 
			Model = 3104;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Fimble Finespindle" ;
			Flags1 = 0x08480046 ;
			Id = 5127 ; 
			Guild = "Expert Leatherworker";
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
			CombatReach = 1.725f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ),new Item( 20537, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ),new Item( 6235, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class ArthurMoore : BaseCreature 
	{ 
		public  ArthurMoore() : base() 
		{ 
			Model = 2613;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Arthur Moore" ;
			Flags1 = 0x018480046 ;
			Id = 4588 ; 
			Guild = "Expert Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 22367, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Telonis : BaseCreature 
	{ 
		public  Telonis() : base() 
		{ 
			Model = 2270;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Telonis" ;
			Flags1 = 0x08480046 ;
			Id = 4212 ; 
			Guild = "Artisan Leatherworker";
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
			CombatReach = 1.5f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {3811
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760
								   ,3774
								   ,7148
								   ,7152
								   ,9196
								   ,9212
								   ,3776
								   ,9201
								   ,6661
								   ,7156
								   ,9206
								   ,10482
								   ,10487
								   ,20650
								   ,10507
								   ,10499
								   ,10518
								   ,10511
								   ,14930
								   ,14932} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class AayndiaFloralwind : BaseCreature 
	{ 
		public  AayndiaFloralwind() : base() 
		{ 
			Model = 2053;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Aayndia Floralwind" ;
			Flags1 = 0x08480046 ;
			Id = 3967 ; 
			Guild = "Expert Leatherworker";
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
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class KrulmooFullmoon : BaseCreature 
	{ 
		public  KrulmooFullmoon() : base() 
		{ 
			Model = 3895;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Krulmoo Fullmoon" ;
			Flags1 = 0x08400046 ;
			Id = 3703 ; 
			Guild = "Expert Leatherworker";
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
			Level = RandomLevel( 42 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1705 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 46, 59 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class NadyiaManeweaver : BaseCreature 
	{ 
		public  NadyiaManeweaver() : base() 
		{ 
			Model = 1719;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Nadyia Maneweaver" ;
			Flags1 = 0x08480046 ;
			Id = 3605 ; 
			Guild = "Journeyman Leatherworker";
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
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class SheleneRhobart : BaseCreature 
	{ 
		public  SheleneRhobart() : base() 
		{ 
			Model = 1607;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Shelene Rhobart" ;
			Flags1 = 0x08400046 ;
			Id = 3549 ; 
			Guild = "Journeyman Leatherworker";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 744 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 19, 25 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Karolek : BaseCreature 
	{ 
		public  Karolek() : base() 
		{ 
			Model = 1387;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Karolek" ;
			Flags1 = 0x08480046 ;
			Id = 3365 ; 
			Guild = "Expert Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class ChawStronghide : BaseCreature 
	{ 
		public  ChawStronghide() : base() 
		{ 
			Model = 3772;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Chaw Stronghide" ;
			Flags1 = 0x08400046 ;
			Id = 3069 ; 
			Guild = "Journeyman Leatherworker";
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
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Mak : BaseCreature 
	{ 
		public  Mak() : base() 
		{ 
			Model = 2094;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Mak" ;
			Flags1 = 0x08480046 ;
			Id = 3008 ; 
			Guild = "Journeyman Leatherworker";
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
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 19555, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Una : BaseCreature 
	{ 
		public  Una() : base() 
		{ 
			Model = 2127;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Una" ;
			Flags1 = 0x08480046 ;
			Id = 3007 ; 
			Guild = "Artisan Leatherworker";
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
			CombatReach = 3.75f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {3811
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760
								   ,3774
								   ,7148
								   ,7152
								   ,9196
								   ,9212
								   ,3776
								   ,9201
								   ,6661
								   ,7156
								   ,9206
								   ,10482
								   ,10487
								   ,20650
								   ,10507
								   ,10499
								   ,10518
								   ,10511
								   ,14930
								   ,14932} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class AdeleFielder : BaseCreature 
	{ 
		public  AdeleFielder() : base() 
		{ 
			Model = 3335;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Adele Fielder" ;
			Flags1 = 0x08480046 ;
			Id = 1632 ; 
			Guild = "Journeyman Leatherworker";
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
			BaseHitPoints = 504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 13, 16 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class GrettaFinespindle : BaseCreature 
	{ 
		public  GrettaFinespindle() : base() 
		{ 
			Model = 10619;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Gretta Finespindle" ;
			Flags1 = 0x08480046 ;
			Id = 1466 ; 
			Guild = "Journeyman Leatherworker";
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
			CombatReach = 1.725f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Brawn : BaseCreature 
	{ 
		public  Brawn() : base() 
		{ 
			Model = 4365;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Brawn" ;
			Flags1 = 0x08400046 ;
			Id = 1385 ; 
			Guild = "Expert Leatherworker";
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
			BaseHitPoints = 1504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 40, 52 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2154
								   ,2162
								   ,9065
								   ,3759
								   ,3763
								   ,2159
								   ,3761
								   ,3817
								   ,7135
								   ,2165
								   ,20648
								   ,2168
								   ,9074
								   ,2166
								   ,3766
								   ,9145
								   ,3768
								   ,3770
								   ,3764
								   ,3818
								   ,3780
								   ,20649
								   ,9194
								   ,9193
								   ,3760} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class DanGolthas : BaseCreature 
	{ 
		public  DanGolthas() : base() 
		{ 
			Model = 10619;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Dan Golthas" ;
			Flags1 = 0x08480046 ;
			Id = 223 ; 
			Guild = "Journeyman Leatherworker";
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
			CombatReach = 1.500000f ;
			SetDamage ( 25, 32 );
			NpcText00 = "Greetings!  Can I teach you how to turn beast hides into armor?" ;
			BaseMana = 0 ;
			Trains = new int[] {2153
								   ,3753
								   ,2160
								   ,2155
								   ,9065
								   ,9062
								   ,9060
								   ,3759
								   ,2162
								   ,2177
								   ,3756
								   ,3816} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	
}