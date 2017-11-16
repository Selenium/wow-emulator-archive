//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Ruw : BaseCreature 
	{ 
		public  Ruw() : base() 
		{ 
			Model = 7361;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Ruw" ;
			Flags1 = 0x08480046 ;
			Id = 8146 ; 
			Guild = "Herbalism Trainer";
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
			BaseHitPoints = 1785 ;
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 4.05f ;
			SetDamage ( 48, 62 );
			NpcText00 = "Greetings $N, I am Ruw." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,2372
								   ,2373
								   ,3571} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			//Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
		}
	}
	public class Tannysa : BaseCreature 
	{ 
		public  Tannysa() : base() 
		{ 
			Model = 3445;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Tannysa" ;
			Flags1 = 0x08480046 ;
			Id = 5566 ; 
			Guild = "Herbalism Trainer";
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
			NpcText00 = "Greetings $N, I am Tannysa." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 10822, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class Shylamiir : BaseCreature 
	{ 
		public  Shylamiir() : base() 
		{ 
			Model = 3296;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Shylamiir" ;
			Flags1 = 0x08400046 ;
			Id = 5502 ; 
			Guild = "Herbalism Trainer";
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
			NpcText00 = "Greetings $N, I am Shylamiir." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class ReynaStonebranch : BaseCreature 
	{ 
		public  ReynaStonebranch() : base() 
		{ 
			Model = 3063;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Reyna Stonebranch" ;
			Flags1 = 0x08480046 ;
			Id = 5137 ; 
			Guild = "Herbalism Trainer";
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
			NpcFlags = (int)NpcActions.Trainer  ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Reyna Stonebranch." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class MarthaAlliestar : BaseCreature 
	{ 
		public  MarthaAlliestar() : base() 
		{ 
			Model = 2669;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Martha Alliestar" ;
			Flags1 = 0x018480046 ;
			Id = 4614 ; 
			Guild = "Herbalism Trainer";
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
			NpcText00 = "Greetings $N, I am Martha Alliestar." ;
			BaseMana = 0 ;
			Trains = new int[] {  2372   // Apprentice Herbalist (56538)
								   , 2373   // Journeyman Herbalist (56559)
								   , 3571   // Expert Herbalist (89142)
								   , 11994   // Artisan Herbalist (324503)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 10825, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ), new Item( 1706, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class FirodrenMooncaller : BaseCreature 
	{ 
		public  FirodrenMooncaller() : base() 
		{ 
			Model = 2253;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Firodren Mooncaller" ;
			Flags1 = 0x08480046 ;
			Id = 4204 ; 
			Guild = "Herbalism Trainer";
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
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Firodren Mooncaller." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class CylaniaRootstalker : BaseCreature 
	{ 
		public  CylaniaRootstalker() : base() 
		{ 
			Model = 4182;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Cylania Rootstalker" ;
			Flags1 = 0x08480046 ;
			Id = 3965 ; 
			Guild = "Herbalist";
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
			CombatReach = 1.500000f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Cylania Rootstalker." ;
			BaseMana = 0 ;
			Trains = new int[] {8390
								   ,2372
								   ,2373
								   ,3571} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 10821, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class MalorneBladeleaf : BaseCreature 
	{ 
		public  MalorneBladeleaf() : base() 
		{ 
			Model = 1709;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Malorne Bladeleaf" ;
			Flags1 = 0x08480046 ;
			Id = 3604 ; 
			Guild = "Herbalist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 704 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 18, 23 );
			NpcText00 = "Greetings $N, I am Malorne Bladeleaf." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,2372
								   ,3571
								   ,2373} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class Jandi : BaseCreature 
	{ 
		public  Jandi() : base() 
		{ 
			Model = 4358;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Jandi" ;
			Flags1 = 0x08480046 ;
			Id = 3404 ; 
			Guild = "Herbalism Trainer";
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
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Jandi." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 10521, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
		}
	}
	public class Mishiki : BaseCreature 
	{ 
		public  Mishiki() : base() 
		{ 
			Model = 4085;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Mishiki" ;
			Flags1 = 0x08480046 ;
			Id = 3185 ; 
			Guild = "Herbalist";
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
			NpcText00 = "Greetings $N, I am Mishiki." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,2372
								   ,3571
								   ,2373} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 10821, InventoryTypes.MainGauche, 2, 14, 1, 2, 0, 0, 0 ));
		}
	}
	public class KominWinterhoof : BaseCreature 
	{ 
		public  KominWinterhoof() : base() 
		{ 
			Model = 2091;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Komin Winterhoof" ;
			Flags1 = 0x08480046 ;
			Id = 3013 ; 
			Guild = "Herbalism Trainer";
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
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 4.05f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings $N, I am Komin Winterhoof." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Angrun : BaseCreature 
	{ 
		public  Angrun() : base() 
		{ 
			Model = 4364;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Angrun" ;
			Flags1 = 0x08400046 ;
			Id = 2856 ; 
			Guild = "Superior Herbalist";
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
			NpcText00 = "Greetings $N, I am Angrun." ;
			BaseMana = 0 ;
			Trains = new int[] {8390
								   ,2372
								   ,2373
								   ,3571
								   ,11994} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class AranaeVenomblood : BaseCreature 
	{ 
		public  AranaeVenomblood() : base() 
		{ 
			Model = 3677;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Aranae Venomblood" ;
			Flags1 = 0x08400046 ;
			Id = 2390 ; 
			Guild = "Herbalist";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1184 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 31, 41 );
			NpcText00 = "Greetings $N, I am Aranae Venomblood." ;
			BaseMana = 0 ;
			Trains = new int[] {8390
								   ,2372
								   ,2373
								   ,3571
								   ,11994} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7456, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class Faruza : BaseCreature 
	{ 
		public  Faruza() : base() 
		{ 
			Model = 3520;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Faruza" ;
			Flags1 = 0x08400046 ;
			Id = 2114 ; 
			Guild = "Apprentice Herbalist";
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
			NpcText00 = "Greetings $N, I am Faruza." ;
			BaseMana = 0 ;
			Trains = new int[] {  2372   // Apprentice Herbalist (56538)
								   , 2373   // Journeyman Herbalist (56559)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 10825, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class TelurinonMoonshadow : BaseCreature 
	{ 
		public  TelurinonMoonshadow() : base() 
		{ 
			Model = 1898;
			AttackSpeed= 1500;
			BoundingRadius = 0.389000f ;
			Name = "Telurinon Moonshadow" ;
			Flags1 = 0x08480046 ;
			Id = 1458 ; 
			Guild = "Herbalism Trainer";
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
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Telurinon Moonshadow." ;
			BaseMana = 0;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}

	public class HerbalistPomeroy : BaseCreature 
	{ 
		public  HerbalistPomeroy() : base() 
		{ 
			Model = 3269;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Herbalist Pomeroy" ;
			Flags1 = 0x08480046 ;
			Id = 1218 ; 
			Guild = "Herbalism Trainer";
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
			BaseHitPoints = 0 ;
			NpcFlags = (int)NpcActions.Trainer;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Herbalist Pomeroy." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2372
								   ,2373} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class FloraSilverwind : BaseCreature 
	{ 
		public  FloraSilverwind() : base() 
		{ 
			Model = 4488;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Flora Silverwind" ;
			Flags1 = 0x08080006 ;
			Id = 908 ; 
			Guild = "Superior Herbalist";
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
			NpcText00 = "Greetings $N, I am Flora Silverwind." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 10821, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class AlmaJainrose : BaseCreature 
	{ 
		public  AlmaJainrose() : base() 
		{ 
			Model = 1745;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Alma Jainrose" ;
			Flags1 = 0x08480046 ;
			Id = 812 ; 
			Guild = "Herbalism Trainer";
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
			NpcFlags = (int)NpcActions.Trainer  ;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Greetings $N, I am Alma Jainrose." ;
			BaseMana = 0 ;
			Trains = new int[] {11994
								   ,3571
								   ,2373
								   ,2372} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7474, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	
}