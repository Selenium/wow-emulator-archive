//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Silvaria : BaseCreature 
	{ 
		public  Silvaria() : base() 
		{ 
			Model = 9339;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Silvaria" ;
			Flags1 = 0x08480046 ;
			Id = 10089 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Silvaria." ;
			BaseMana = 0 ;
			Trains = new int[] {15147
								   ,15148
								   ,15149
								   ,15150
								   ,15151} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class BeliaThundergranite : BaseCreature 
	{ 
		public  BeliaThundergranite() : base() 
		{ 
			Model = 9338;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Belia Thundergranite" ;
			Flags1 = 0x08480046 ;
			Id = 10090 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Belia Thundergranite." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 0, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class Xaotsu : BaseCreature 
	{ 
		public  Xaotsu() : base() 
		{ 
			Model = 9336;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Xao'tsu" ;
			Flags1 = 0x08480046 ;
			Id = 10088 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Xao'tsu." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class BinjyFeatherwhistle : BaseCreature 
	{ 
		public  BinjyFeatherwhistle() : base() 
		{ 
			Model = 7038;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Binjy Featherwhistle" ;
			Flags1 = 0x08480046 ;
			Id = 7954 ; 
			Guild = "Mechanostrider Pilot";
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
			NpcText00 = "Greetings $N, I am Binjy Featherwhistle." ;
			BaseMana = 0 ;
			Trains = new int[] {  10908   // Mechanostrider Piloting (297878)
							   } ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5569, InventoryTypes.TwoHanded, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}

	public class XarTi : BaseCreature 
	{ 
		public  XarTi() : base() 
		{ 
			Model = 7040;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Xar'Ti" ;
			Flags1 = 0x08480046 ;
			Id = 7953 ; 
			Guild = "Raptor Riding Trainer";
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
			NpcText00 = "Greetings $N, I am Xar'Ti." ;
			BaseMana = 0 ;
			Trains = new int[] {  10863   // Raptor Riding (297326)
							   } ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class Jartsam : BaseCreature 
	{ 
		public  Jartsam() : base() 
		{ 
			Model = 5070;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Jartsam" ;
			Flags1 = 0x08480046 ;
			Id = 4753 ; 
			Guild = "Nightsaber Riding Instructor";
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
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Jartsam." ;
			BaseMana = 0 ;
			Trains = new int[] {  6745   // Tiger Riding (26624)
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class UlthamIronhorn : BaseCreature 
	{ 
		public  UlthamIronhorn() : base() 
		{ 
			Model = 3410;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Ultham Ironhorn" ;
			Flags1 = 0x08480046 ;
			Id = 4772 ; 
			Guild = "Ram Riding Instructor";
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
			NpcText00 = "Greetings $N, I am Ultham Ironhorn." ;
			BaseMana = 0 ;
			Trains = new int[] {  6744   // Ram Riding (26565)
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7460, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class VelmaWarnam : BaseCreature 
	{ 
		public  VelmaWarnam() : base() 
		{ 
			Model = 3945;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Velma Warnam" ;
			Flags1 = 0x08400046 ;
			Id = 4773 ; 
			Guild = "Undead Horse Riding Instructor";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Velma Warnam." ;
			BaseMana = 0 ;
			Trains = new int[] {  10921   // Skeletal Horse Riding (298083)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Kilda : BaseCreature 
	{ 
		public  Kilda() : base() 
		{ 
			Model = 4464;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Kilda" ;
			Flags1 = 0x08480046 ;
			Id = 4752 ; 
			Guild = "Wolf Riding Instructor";
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
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.500000f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Kilda." ;
			BaseMana = 0 ;
			Trains = new int[] {  6746   // Wolf Riding (26553)
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class RandalHunter : BaseCreature 
	{ 
		public  RandalHunter() : base() 
		{ 
			Model = 3274;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Randal Hunter" ;
			Flags1 = 0x08480046 ;
			Id = 4732 ; 
			Guild = "Horse Riding Instructor";
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
			NpcText00 = "Greetings $N, I am Randal Hunter." ;
			BaseMana = 0 ;
			Trains = new int[] {  6743   // Horse Riding (26540)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class Caelyb : BaseCreature 
	{ 
		public  Caelyb() : base() 
		{ 
			Model = 2416;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Caelyb" ;
			Flags1 = 0x08480046 ;
			Id = 4320 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Caelyb." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Bolyun : BaseCreature 
	{ 
		public  Bolyun() : base() 
		{ 
			Model = 4304;
			AttackSpeed= 1554;
			BoundingRadius = 1.00f ;
			Name = "Bolyun" ;
			Flags1 = 0x08480046 ;
			Id = 3698 ; 
			Guild = "Pet Trainer";
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
			CombatReach = 11.00f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Bolyun." ;
			BaseMana = 2004 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290} ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class KarStormsinger : BaseCreature 
	{ 
		public  KarStormsinger() : base() 
		{ 
			Model = 4298;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Kar Stormsinger" ;
			Flags1 = 0x08480046 ;
			Id = 3690 ; 
			Guild = "Kodo Riding Instructor";
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
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Kar Stormsinger." ;
			BaseMana = 0 ;
			Trains = new int[] {18377
								   ,18996 } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class RebanFreerunner : BaseCreature 
	{ 
		public  RebanFreerunner() : base() 
		{ 
			Model = 4299;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Reban Freerunner" ;
			Flags1 = 0x08480046 ;
			Id = 3688 ; 
			Guild = "Pet Trainer";
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
			CombatReach = 4.05f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Reban Freerunner." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Zudd : BaseCreature 
	{ 
		public  Zudd() : base() 
		{ 
			Model = 4292;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Zudd" ;
			Flags1 = 0x08400046 ;
			Id = 3624 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Zudd." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 12857, InventoryTypes.MainGauche, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class Grokor : BaseCreature 
	{ 
		public  Grokor() : base() 
		{ 
			Model = 4295;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Grokor" ;
			Flags1 = 0x08400046 ;
			Id = 3622 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Grokor." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class ClaudeErksine : BaseCreature 
	{ 
		public  ClaudeErksine() : base() 
		{ 
			Model = 7915;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Claude Erksine" ;
			Flags1 = 0x08480046 ;
			Id = 3545 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Claude Erksine." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class Keldas : BaseCreature 
	{ 
		public  Keldas() : base() 
		{ 
			Model = 12729;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Keldas" ;
			Flags1 = 0x08480046 ;
			Id = 3306 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Keldas." ;
			BaseMana = 0 ;
			Trains = new int[] {15147
								   ,15148
								   ,15149
								   ,15150} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class KarrinaMekenda : BaseCreature 
	{ 
		public  KarrinaMekenda() : base() 
		{ 
			Model = 5043;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Karrina Mekenda" ;
			Flags1 = 0x08480046 ;
			Id = 2879 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Karrina Mekenda." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class PeriaLamenur : BaseCreature 
	{ 
		public  PeriaLamenur() : base() 
		{ 
			Model = 5040;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Peria Lamenur" ;
			Flags1 = 0x08480046 ;
			Id = 2878 ; 
			Guild = "Pet Trainer";
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
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Peria Lamenur." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class NalesetteWildbringer : BaseCreature 
	{ 
		public  NalesetteWildbringer() : base() 
		{ 
			Model = 12749;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Nalesette Wildbringer" ;
			Flags1 = 0x08480046 ;
			Id = 543 ; 
			Guild = "Pet Trainer";
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
			NpcText00 = "Greetings $N, I am Nalesette Wildbringer." ;
			BaseMana = 0 ;
			Trains = new int[] {6337
								   ,6338
								   ,6336
								   ,6329
								   ,6335
								   ,6452
								   ,6453
								   ,6451
								   ,6448
								   ,6450
								   ,6318
								   ,6312
								   ,6284
								   ,6321
								   ,6320
								   ,6319
								   ,6287
								   ,6288
								   ,6290
								   ,6289} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 1599, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	
}