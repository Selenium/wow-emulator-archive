//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Zarrin : BaseNPC 
	{ 
		public  Zarrin() : base() 
		{ 
			Model = 4989;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Zarrin" ;
			Flags1 = 0x08480046 ;
			Id = 6286 ; 
			Guild = "Cook";
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
			BaseHitPoints = 544 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Greetings $N, I am Zarrin." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7443, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class StephenRyback : BaseCreature 
	{ 
		public  StephenRyback() : base() 
		{ 
			Model = 3281;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Stephen Ryback" ;
			Flags1 = 0x08480046 ;
			Id = 5482 ; 
			Guild = "Cooking Trainer";
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
			NpcText00 = "Greetings $N, I am Stephen Ryback." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7431, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 7462, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class DarylRiknussun : BaseCreature 
	{ 
		public  DarylRiknussun() : base() 
		{ 
			Model = 3094;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Daryl Riknussun" ;
			Flags1 = 0x08480046 ;
			Id = 5159 ; 
			Guild = "Cooking Trainer";
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
			NpcText00 = "Greetings $N, I am Daryl Riknussun." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7462, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class EuniceBurch : BaseCreature 
	{ 
		public  EuniceBurch() : base() 
		{ 
			Model = 2662;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Eunice Burch" ;
			Flags1 = 0x018480046 ;
			Id = 4552 ; 
			Guild = "Cooking Trainer";
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
			NpcText00 = "Greetings $N, I am Eunice Burch." ;
			BaseMana = 0 ;
			Trains = new int[] {2551
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,6502
								   ,6503} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7468, InventoryTypes.MainGauche, 2, 14, 2, 3, 0, 0, 0 ));
		}
	}
	public class Alegorn : BaseCreature 
	{ 
		public  Alegorn() : base() 
		{ 
			Model = 2242;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Alegorn" ;
			Flags1 = 0x08480046 ;
			Id = 4210 ; 
			Guild = "Cooking Trainer";
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
			NpcText00 = "Greetings $N, I am Alegorn." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7462, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Zamja : BaseCreature 
	{ 
		public  Zamja() : base() 
		{ 
			Model = 2734;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Zamja" ;
			Flags1 = 0x08480046 ;
			Id = 3399 ; 
			Guild = "Cooking Trainer";
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
			NpcText00 = "Greetings $N, I am Zamja." ;
			BaseMana = 0 ;
			Trains = new int[] {2551
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,6502
								   ,6503
								   ,2563} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7431, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class CrystalBoughman : BaseCreature 
	{ 
		public  CrystalBoughman() : base() 
		{ 
			Model = 3379;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Crystal Boughman" ;
			Flags1 = 0x08480046 ;
			Id = 3087 ; 
			Guild = "Cooking Trainer";
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
			NpcText00 = "Greetings $N, I am Crystal Boughman." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7431, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class AskaMistrunner : BaseCreature 
	{ 
		public  AskaMistrunner() : base() 
		{ 
			Model = 2107;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Aska Mistrunner" ;
			Flags1 = 0x08480046 ;
			Id = 3026 ; 
			Guild = "Cooking Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Greetings $N, I am Aska Mistrunner." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7462, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class GremlockPilsnor : BaseCreature 
	{ 
		public  GremlockPilsnor() : base() 
		{ 
			Model = 3435;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Gremlock Pilsnor" ;
			Flags1 = 0x08480046 ;
			Id = 1699 ; 
			Guild = "Cooking Trainer";
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
			NpcText00 = "Greetings $N, I am Gremlock Pilsnor." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7462, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Tomas : BaseCreature 
	{ 
		public  Tomas() : base() 
		{ 
			Model = 1293;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Tomas" ;
			Flags1 = 0x08480046 ;
			Id = 1430 ; 
			Guild = "Cooking Trainer";
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
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Tomas." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563
							   };
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7443, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class CookGhilm : BaseCreature 
	{ 
		public  CookGhilm() : base() 
		{ 
			Model = 3416;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Cook Ghilm" ;
			Flags1 = 0x08480046 ;
			Id = 1355 ; 
			Guild = "Cooking Trainer";
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
			BaseHitPoints = 344 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 8, 11 );
			NpcText00 = "Greetings $N, I am Cook Ghilm." ;
			BaseMana = 0 ;
			Trains = new int[] {6503
								   ,6502
								   ,3412
								   ,2559
								   ,2562
								   ,2561
								   ,21176
								   ,2551
								   ,2563 } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7431, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}

	public class KendorKabonka : BaseCreature 
	{ 
		public  KendorKabonka() : base() 
		{ 
			Model = 5728;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Kendor Kabonka" ;
			Flags1 = 0x08480046 ;
			Id = 340 ; 
			Guild = "Master of Cooking Recipes";
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
			NpcFlags = (int)NpcActions.Trainer; 
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Kendor Kabonka." ;
			BaseMana = 0 ;
			Trains = new int[] {7757
								   ,7756
								   ,8605
								   ,15936
								   ,6423
								   ,6424
								   ,2796
								   ,6425
								   ,8608
								   ,6426
								   ,7759
								   ,7758
								   ,7830
								   ,6427
								   ,2553
								   ,9514
								   ,3382
								   ,2554
								   ,6534
								   ,2555
								   ,8239
								   ,6428
								   ,3381
								   ,2557
								   ,6504
								   ,2556
								   ,6429
								   ,7760
								   ,2558
								   ,3378
								   ,3401
								   ,6430
								   ,3380
								   ,15854
								   ,3379
								   ,3402
								   ,7831
								   ,3403
								   ,15864
								   ,15862
								   ,3404
								   ,15866
								   ,3383
								   ,7214
								   ,15858
								   ,15857
								   ,15908
								   ,15911
								   ,18250
								   ,18252
								   ,18251
								   ,18254
								   ,18253
								   ,18256
								   ,18255
								   ,18259
								   ,18257
								   ,18258} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 24595, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 23177, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
		}
	}
	
}