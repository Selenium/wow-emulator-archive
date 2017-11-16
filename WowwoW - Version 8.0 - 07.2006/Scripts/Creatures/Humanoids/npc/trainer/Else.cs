//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Talar : BaseCreature 
	{ 
		public  Talar() : base() 
		{ 
			Model = 262;
			AttackSpeed= 1554;
			BoundingRadius = 1.00f ;
			Name = "Talar" ;
			Flags1 = 0x102 ;
			Id = 4206 ; 
			Guild = "Bear Trainer";
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
			NpcText00 = "Greetings $N, I am Talar." ;
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
								   ,6290
								   ,6289} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class ElissaDumas : BaseCreature 
	{ 
		public  ElissaDumas() : base() 
		{ 
			Model = 7669;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Elissa Dumas" ;
			Flags1 = 0x08480046 ;
			Id = 4165 ; 
			Guild = "Portal Trainer";
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
			NpcText00 = "Hey good man.Do you want to learn somethin' about portals ?" ;
			BaseMana = 2680 ;
			Trains = new int[] {  3578   // Teleport: Darnassus (88718)
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Thuul : BaseCreature 
	{ 
		public  Thuul() : base() 
		{ 
			Model = 12849;
			AttackSpeed= 870;
			BoundingRadius = 0.306000f ;
			Name = "Thuul" ;
			Flags1 = 0x08480046 ;
			Id = 5958 ; 
			Guild = "Portal Trainer";
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
			CombatReach = 1.5f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Hey good man.Do you want to learn somethin' about portals ?" ;
			BaseMana = 0 ;
			Trains = new int[] {3581   // Teleport: Ironforge (88535)
								   ,11421  } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class BirgitteCranston : BaseCreature 
	{ 
		public  BirgitteCranston() : base() 
		{ 
			Model = 4665;
			AttackSpeed= 1000;
			BoundingRadius = 0.383000f ;
			Name = "Birgitte Cranston" ;
			Flags1 = 0x08400046 ;
			Id = 5957 ; 
			Guild = "Portal Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1825 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Hey good man.Do you want to learn somethin' about portals ?" ;
			BaseMana = 0 ;
			Trains = new int[] {3577   // Teleport: Undercity (88590)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Kysandia : BaseCreature 
	{ 
		public  Kysandia() : base() 
		{ 
			Model = 262;
			AttackSpeed= 1903;
			BoundingRadius = 1.00f ;
			Name = "Kysandia" ;
			Flags1 = 0x102 ;
			Id = 4153 ; 
			Guild = "Cat Trainer";
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
			CombatReach = 11.00f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings $N, I am Kysandia." ;
			BaseMana = 753 ;
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
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class TharnariunTreetender : BaseCreature 
	{ 
		public  TharnariunTreetender() : base() 
		{ 
			Model = 4485;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Tharnariun Treetender" ;
			Flags1 = 0x08480006 ;
			Id = 3701 ; 
			Guild = "Bear Trainer";
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
			BaseHitPoints = 824 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Greetings $N, I am Tharnariun Treetender." ;
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
			Faction = Factions.Alliance;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class Nerra : BaseCreature 
	{ 
		public  Nerra() : base() 
		{ 
			Model = 262;
			AttackSpeed= 1903;
			BoundingRadius = 1.00f ;
			Name = "Nerra" ;
			Flags1 = 0x102 ;
			Id = 3699 ; 
			Guild = "Cat Trainer";
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
			CombatReach = 11.00f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings $N, I am Nerra." ;
			BaseMana = 753 ;
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
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class JunderBrokk : BaseCreature 
	{ 
		public  JunderBrokk() : base() 
		{ 
			Model = 3481;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Junder Brokk" ;
			Flags1 = 0x08480046 ;
			Id = 3182 ; 
			Guild = "Lockpicking Trainer";
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
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Greetings $N, I am Junder Brokk." ;
			BaseMana = 0 ;
			Trains = new int[] {1809
								   ,1810
								   ,6460
								   ,1186} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class AldricHunter : BaseCreature 
	{ 
		public  AldricHunter() : base() 
		{ 
			Model = 262;
			AttackSpeed= 2100;
			BoundingRadius = 1.00f ;
			Name = "Aldric Hunter" ;
			Flags1 = 0x102 ;
			Id = 2938 ; 
			Guild = "Bear Trainer";
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
			Level = RandomLevel( 1 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 64 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 11.00f ;
			SetDamage ( 0, 1 );
			NpcText00 = "Greetings $N, I am Aldric Hunter." ;
			BaseMana = 53 ;
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
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class DurdekKarrin : BaseCreature 
	{ 
		public  DurdekKarrin() : base() 
		{ 
			Model = 5227;
			AttackSpeed= 1413;
			BoundingRadius = 1.00f ;
			Name = "Durdek Karrin" ;
			Flags1 = 0x08400046 ;
			Id = 2881 ; 
			Guild = "Bear Trainer";
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
			CombatReach = 11.00f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Durdek Karrin." ;
			BaseMana = 2504 ;
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
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class Faelyssa : BaseCreature 
	{ 
		public  Faelyssa() : base() 
		{ 
			Model = 2232;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Faelyssa" ;
			Flags1 = 0x08480046 ;
			Id = 2796 ; 
			Guild = "Lockpicking Trainer";
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
			NpcText00 = "Greetings $N, I am Faelyssa." ;
			BaseMana = 0 ;
			Trains = new int[] {1809
								   ,1810
								   ,6460
								   ,1186} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class LennyFingersMcCoy : BaseCreature 
	{ 
		public  LennyFingersMcCoy() : base() 
		{ 
			Model = 1505;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Lenny Fingers McCoy" ;
			Flags1 = 0x08480046 ;
			Id = 2795 ; 
			Guild = "Lockpicking Trainer";
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
			NpcText00 = "Greetings $N, I am Lenny 'Fingers' McCoy." ;
			BaseMana = 0 ;
			Trains = new int[] {1809
								   ,1810
								   ,6460
								   ,1186} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class DurthamGreldon : BaseCreature 
	{ 
		public  DurthamGreldon() : base() 
		{ 
			Model = 9817;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Durtham Greldon" ;
			Flags1 = 0x08480046 ;
			Id = 2737 ; 
			Guild = "Lockpicking Trainer";
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
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Durtham Greldon." ;
			BaseMana = 0 ;
			Trains = new int[] {1809
								   ,1810
								   ,6460
								   ,1186} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7430, InventoryTypes.MainGauche, 2, 13, 1, 7, 0, 0, 0 ), new Item( 21144, InventoryTypes.OffHand, 2, 13, 1, 7, 0, 0, 0 ));
		}
	}
	public class LexingtonMortaim : BaseCreature 
	{ 
		public  LexingtonMortaim() : base() 
		{ 
			Model = 2810;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Lexington Mortaim" ;
			Flags1 = 0x08400046 ;
			Id = 2492 ; 
			Guild = "Portal Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Hey good man.Do you want to learn somethin' about portals ?" ;
			BaseMana = 0 ;
			Trains = new int[] {3577   // Teleport: Undercity (88590)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class MilstaffStormeye : BaseCreature 
	{ 
		public  MilstaffStormeye() : base() 
		{ 
			Model = 10548;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Milstaff Stormeye" ;
			Flags1 = 0x08480046 ;
			Id = 2489 ; 
			Guild = "Portal Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Hey good man.Do you want to learn somethin' about portals ?" ;
			BaseMana = 0 ;
			Trains = new int[] {3988
								   ,3987
								   ,9272
								   ,8336
								   ,7431
								   ,15256
								   ,6459
								   ,12638
								   ,12637
								   ,12636
								   ,12635
								   ,12634
								   ,12633
								   ,12632
								   ,12631
								   ,12630
								   ,12629
								   ,12628
								   ,3986
								   ,3985
								   ,3984
								   ,4041
								   ,4040
								   ,4039
								   ,4023
								   ,4022
								   ,4019
								   ,4018
								   ,4017
								   ,4016
								   ,4014
								   ,4013
								   ,4012
								   ,4010
								   ,4009
								   ,4008
								   ,4007
								   ,4006
								   ,4005
								   ,4003
								   ,4001
								   ,4000
								   ,3999
								   ,3998
								   ,3997
								   ,3995
								   ,3990
								   ,3991
								   ,3992
								   ,3994} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class LarimainePurdue : BaseCreature 
	{ 
		public  LarimainePurdue() : base() 
		{ 
			Model = 1470;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Larimaine Purdue" ;
			Flags1 = 0x08480046 ;
			Id = 2485 ; 
			Guild = "Portal Trainer";
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
			NpcText00 = "Hey good man.Do you want to learn somethin' about portals ?" ;
			BaseMana = 0 ;
			Trains = new int[] {665   // Teleport: Stormwind (18619)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5098, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	
}