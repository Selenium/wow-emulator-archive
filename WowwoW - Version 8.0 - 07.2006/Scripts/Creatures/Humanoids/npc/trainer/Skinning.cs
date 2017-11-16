//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Malux : BaseCreature 
	{ 
		public  Malux() : base() 
		{ 
			Model = 12041;
			AttackSpeed= 1707;
			BoundingRadius = 1.00f ;
			Name = "Malux" ;
			Flags1 = 0x08480046 ;
			Id = 12030 ; 
			Guild = "Skinning Trainer";
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
			Level = RandomLevel( 28, 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1184 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 11.00f ;
			SetDamage ( 31, 41 );
			NpcText00 = "Greetings $N, I am Malux." ;
			BaseMana = 0 ;
			Trains = new int[] {8619
								   ,10769
								   ,8620
								   ,8615} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class KullegStonehorn : BaseCreature 
	{ 
		public  KullegStonehorn() : base() 
		{ 
			Model = 7360;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Kulleg Stonehorn" ;
			Flags1 = 0x08480046 ;
			Id = 8144 ; 
			Guild = "Skinning Trainer";
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
			BaseHitPoints = 1665 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 44, 58 );
			NpcText00 = "Greetings $N, I am Kulleg Stonehorn." ;
			BaseMana = 0 ;
			Trains = new int[] {8619
								   ,10769
								   ,8620
								   ,8615} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class KillianHagey : BaseCreature 
	{ 
		public  KillianHagey() : base() 
		{ 
			Model = 5845;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Killian Hagey" ;
			Flags1 = 0x018480046 ;
			Id = 7087 ; 
			Guild = "Skinning Trainer";
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
			NpcText00 = "Greetings $N, I am Killian Hagey." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class Thuwd : BaseCreature 
	{ 
		public  Thuwd() : base() 
		{ 
			Model = 5846;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Thuwd" ;
			Flags1 = 0x08480046 ;
			Id = 7088 ; 
			Guild = "Skinning Trainer";
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
			NpcText00 = "Greetings $N, I am Thuwd." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Mooranta : BaseCreature 
	{ 
		public  Mooranta() : base() 
		{ 
			Model = 5847;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Mooranta" ;
			Flags1 = 0x08480046 ;
			Id = 7089 ; 
			Guild = "Skinning Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Mooranta." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Dranh : BaseCreature 
	{ 
		public  Dranh() : base() 
		{ 
			Model = 5108;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Dranh" ;
			Flags1 = 0x08480046 ;
			Id = 6387 ; 
			Guild = "Skinner";
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
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings $N, I am Dranh." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class HelenePeltskinner : BaseCreature 
	{ 
		public  HelenePeltskinner() : base() 
		{ 
			Model = 5365;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Helene Peltskinner" ;
			Flags1 = 0x08480046 ;
			Id = 6306 ; 
			Guild = "Skinner";
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
			NpcText00 = "Greetings $N, I am Helene Peltskinner." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class WilmaRanthal : BaseCreature 
	{ 
		public  WilmaRanthal() : base() 
		{ 
			Model = 4994;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Wilma Ranthal" ;
			Flags1 = 0x08400046 ;
			Id = 6295 ; 
			Guild = "Skinning Trainer";
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
			NpcText00 = "Greetings $N, I am Wilma Ranthal." ;
			BaseMana = 0 ;
			Trains = new int[] {  8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
								   , 8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class RadnaalManeweaver : BaseCreature 
	{ 
		public  RadnaalManeweaver() : base() 
		{ 
			Model = 4990;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Radnaal Maneweaver" ;
			Flags1 = 0x08480046 ;
			Id = 6287 ; 
			Guild = "Skinner";
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
			Level = RandomLevel( 19 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 784 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 20, 26 );
			NpcText00 = "Greetings $N, I am Radnaal Maneweaver." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class Jayla : BaseCreature 
	{ 
		public  Jayla() : base() 
		{ 
			Model = 4991;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Jayla" ;
			Flags1 = 0x08480046 ;
			Id = 6288 ; 
			Guild = "Skinner";
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
			NpcText00 = "Greetings $N, I am Jayla." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class RandRhobart : BaseCreature 
	{ 
		public  RandRhobart() : base() 
		{ 
			Model = 4993;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Rand Rhobart" ;
			Flags1 = 0x08400046 ;
			Id = 6289 ; 
			Guild = "Skinner";
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
			NpcText00 = "Greetings $N, I am Rand Rhobart." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class YonnDeepcut : BaseCreature 
	{ 
		public  YonnDeepcut() : base() 
		{ 
			Model = 4992;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Yonn Deepcut" ;
			Flags1 = 0x08480046 ;
			Id = 6290 ; 
			Guild = "Skinner";
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
			BaseHitPoints = 344 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 8, 11 );
			NpcText00 = "Greetings $N, I am Yonn Deepcut." ;
			BaseMana = 0 ;
			Trains = new int[] {  8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
								   , 8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class BalthusStoneflayer : BaseCreature 
	{ 
		public  BalthusStoneflayer() : base() 
		{ 
			Model = 4986;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Balthus Stoneflayer" ;
			Flags1 = 0x08480046 ;
			Id = 6291 ; 
			Guild = "Skinning Trainer";
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
			NpcText00 = "Greetings $N, I am Balthus Stoneflayer." ;
			BaseMana = 0 ;
			Trains = new int[] {  8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
								   , 8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class Eladriel : BaseCreature 
	{ 
		public  Eladriel() : base() 
		{ 
			Model = 4985;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Eladriel" ;
			Flags1 = 0x08480046 ;
			Id = 6292 ; 
			Guild = "Skinning Trainer";
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
			NpcText00 = "Greetings $N, I am Eladriel." ;
			BaseMana = 0 ;
			Trains = new int[] {  8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
								   , 8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class MarisGranger : BaseCreature 
	{ 
		public  MarisGranger() : base() 
		{ 
			Model = 1449;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Maris Granger" ;
			Flags1 = 0x08480046 ;
			Id = 1292 ; 
			Guild = "Skinning Trainer";
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
			NpcText00 = "Greetings $N, I am Maris Granger." ;
			BaseMana = 0 ;
			Trains = new int[] {  8615   // Apprentice Skinning (247572)
								   , 8619   // Journeyman Skinning (247970)
								   , 8620   // Expert Skinning (247990)
								   , 10769   // Artisan Skinning (295337)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	
}