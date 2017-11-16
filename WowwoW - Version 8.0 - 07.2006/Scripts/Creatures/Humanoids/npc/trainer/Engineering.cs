//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class JennaLemkenilli : BaseCreature 
	{ 
		public  JennaLemkenilli() : base() 
		{ 
			Model = 10575;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Jenna Lemkenilli" ;
			Flags1 = 0x08480046 ;
			Id = 11037 ; 
			Guild = "Journeyman Engineer";
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
			CombatReach = 1.725f ;
			SetDamage ( 28, 36 );
			NpcText00 = "Greetings $N, I am Jenna Lemkenilli." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3988
								   ,3991
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class FranklinLloyd : BaseCreature 
	{ 
		public  FranklinLloyd() : base() 
		{ 
			Model = 10572;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Franklin Lloyd" ;
			Flags1 = 0x018480046 ;
			Id = 11031 ; 
			Guild = "Expert Engineer";
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
			Level = RandomLevel( 33 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1344 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 36, 46 );
			NpcText00 = "Greetings $N, I am Franklin Lloyd." ;
			BaseMana = 0 ;
			Trains = new int[] {6459
								   ,7431
								   ,9272
								   ,4001
								   ,4000
								   ,3999
								   ,3998
								   ,3997
								   ,3995
								   ,3994
								   ,3993
								   ,3992
								   ,3991
								   ,3990
								   ,3988
								   ,3987
								   ,12628
								   ,3986
								   ,3985
								   ,3984
								   ,4040
								   ,4039
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
								   ,8336} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23171, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class JemmaQuikswitch : BaseCreature 
	{ 
		public  JemmaQuikswitch() : base() 
		{ 
			Model = 10571;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Jemma Quikswitch" ;
			Flags1 = 0x08480046 ;
			Id = 11028 ; 
			Guild = "Journeyman Engineer";
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
			NpcText00 = "Greetings $N, I am Jemma Quikswitch." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,4040
								   ,3991
								   ,3988} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ),new Item( 21144, InventoryTypes.OffHand, 2, 13, 1, 7, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class TrixieQuikswitch : BaseCreature 
	{ 
		public  TrixieQuikswitch() : base() 
		{ 
			Model = 10722;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Trixie Quikswitch" ;
			Flags1 = 0x08480046 ;
			Id = 11029 ; 
			Guild = "Expert Engineer";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1264 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.725f ;
			SetDamage ( 33, 43 );
			NpcText00 = "Greetings $N, I am Trixie Quikswitch." ;
			BaseMana = 0 ;
			Trains = new int[] {13373
								   ,7429
								   ,14805
								   ,7422
								   ,7461
								   ,7749
								   ,7414
								   ,7459
								   ,7441} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ),new Item( 23321, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class SpriteJumpsprocket : BaseCreature 
	{ 
		public  SpriteJumpsprocket() : base() 
		{ 
			Model = 10569;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Sprite Jumpsprocket" ;
			Flags1 = 0x08480046 ;
			Id = 11026 ; 
			Guild = "Journeyman Engineer";
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
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,4040
								   ,3991
								   ,3988} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Mukdrak : BaseCreature 
	{ 
		public  Mukdrak() : base() 
		{ 
			Model = 10570;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Mukdrak" ;
			Flags1 = 0x08480046 ;
			Id = 11025 ; 
			Guild = "Journeyman Engineer";
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
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,3991} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Roxxik : BaseCreature 
	{ 
		public  Roxxik() : base() 
		{ 
			Model = 10472;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Roxxik" ;
			Flags1 = 0x08080046 ;
			Id = 11017 ; 
			Guild = "Artisan Engineer";
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
			NpcText00 = "Greetings $N, I am Roxxik." ;
			BaseMana = 0 ;
			Trains = new int[] {3988
								   ,3990
								   ,3992
								   ,3997
								   ,3999
								   ,4001
								   ,4005
								   ,9272
								   ,8336
								   ,7431
								   ,4016
								   ,4014
								   ,4013
								   ,4012
								   ,4010
								   ,4009
								   ,4008
								   ,4007
								   ,4006
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
								   ,3987
								   ,4003
								   ,4000
								   ,3998
								   ,3995
								   ,3994
								   ,3993
								   ,3991} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class TwizwickSprocketgrind : BaseCreature 
	{ 
		public  TwizwickSprocketgrind() : base() 
		{ 
			Model = 10454;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Twizwick Sprocketgrind" ;
			Flags1 = 0x046 ;
			Id = 10993 ; 
			Guild = "Journeyman Engineer";
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
			NpcText00 = "Greetings $N, I am Twizwick Sprocketgrind." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,3994
								   ,3993
								   ,3991
								   ,3992} ;
			Faction = Factions.Ratchet;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ),new Item( 6737, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
		}
	}
	public class VazarioLinkgrease : BaseCreature 
	{ 
		public  VazarioLinkgrease() : base() 
		{ 
			Model = 8009;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Vazario Linkgrease" ;
			Flags1 = 0x08080006 ;
			Id = 8738 ; 
			Guild = "Master Goblin Engineer";
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
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Trains = new int[] {  13716
								   , 14648
								   , 7380
								   , 11272
								   , 15396
							   } ;
			Faction = Factions.Ratchet;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class BuzzekBracketswing : BaseCreature 
	{ 
		public  BuzzekBracketswing() : base() 
		{ 
			Model = 8010;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Buzzek Bracketswing" ;
			Flags1 = 0x08080006 ;
			Id = 8736 ; 
			Guild = "Master Engineer";
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
			Level = RandomLevel( 53 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1865 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Trains = new int[] {  595
								   , 610
								   , 609
								   , 5421
								   , 204
								   , 1366
								   , 5420
								   , 1355
								   , 5418
								   , 5415
								   , 4740
								   ,4269
								   ,10634
								   ,7789
								   ,9246
								   ,10632
								   ,10636
								   ,9245
								   ,9898
								   ,9237
								   ,9244
								   ,14650
								   ,12808
								   ,4788
								   ,15525
								   ,14362
								   ,11230
								   ,726
								   ,37230
							   } ;
			Faction = Factions.Gadgetzan;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class NixxSprocketspring : BaseCreature 
	{ 
		public  NixxSprocketspring() : base() 
		{ 
			Model = 7340;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Nixx Sprocketspring" ;
			Flags1 = 0x08080006 ;
			Id = 8126 ; 
			Guild = "Master Goblin Engineer";
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
			NpcText00 = "Greetings $N, I am Nixx Sprocketspring." ;
			BaseMana = 0 ;
			Trains = new int[] {  13716
								   , 12859
								   , 14648
								   , 14343
								   , 14649
								   , 7198
								   , 7380
								   , 11272
								   , 15396
								   ,10407
							   } ;
			Faction = Factions.Gadgetzan;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class TinkmasterOverspark : BaseCreature 
	{ 
		public  TinkmasterOverspark() : base() 
		{ 
			Model = 7028;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Tinkmaster Overspark" ;
			Flags1 = 0x08480046 ;
			Id = 7944 ; 
			Guild = "Master Gnome Engineer";
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
			Level = RandomLevel( 57 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2306 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.725f ;
			SetDamage ( 62, 80 );
			NpcText00 = "Greetings $N, I am Tinkmaster Overspark." ;
			BaseMana = 0 ;
			Trains = new int[] {12909
								   ,12910
								   ,12913
								   ,12916
								   ,12918
								   ,12779
								   ,12917
								   ,12914
								   ,12911} ;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class OglethorpeObnoticus : BaseCreature 
	{ 
		public  OglethorpeObnoticus() : base() 
		{ 
			Model = 6710;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Oglethorpe Obnoticus" ;
			Flags1 = 0x08080046 ;
			Id = 7406 ; 
			Guild = "Master Gnome Engineer";
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
			NpcText00 = "Greetings $N, I am Oglethorpe Obnoticus." ;
			BaseMana = 0 ;
			Trains = new int[] {  3518
								   , 8096
								   , 12822
								   , 11225
								   , 7907
								   , 5256
								   , 4492
								   , 9916
								   , 15911
							   } ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class LilliamSparkspindle : BaseCreature 
	{ 
		public  LilliamSparkspindle() : base() 
		{ 
			Model = 3314;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Lilliam Sparkspindle" ;
			Flags1 = 0x08480046 ;
			Id = 5518 ; 
			Guild = "Expert Engineer";
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
			NpcText00 = "Greetings $N, I am Lilliam Sparkspindle." ;
			BaseMana = 0 ;
			Trains = new int[] {6459
								   ,9272
								   ,3987
								   ,3988
								   ,3992
								   ,3994
								   ,3997
								   ,3999
								   ,4010
								   ,4009
								   ,4008
								   ,4007
								   ,4006
								   ,4005
								   ,4003
								   ,4001
								   ,4000
								   ,12628
								   ,3986
								   ,3985
								   ,3984
								   ,4040
								   ,4041
								   ,4039
								   ,4014
								   ,4013
								   ,4012
								   ,3998
								   ,3995
								   ,3993
								   ,3991
								   ,3990
								   ,8336
								   ,7431} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class SpringspindleFizzlegear : BaseCreature 
	{ 
		public  SpringspindleFizzlegear() : base() 
		{ 
			Model = 3117;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Springspindle Fizzlegear" ;
			Flags1 = 0x08480046 ;
			Id = 5174 ; 
			Guild = "Artisan Engineer";
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
			CombatReach = 1.725f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Springspindle Fizzlegear." ;
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
								   ,12657
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
								   ,3994
								   ,3993} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class GrahamVanTalen : BaseCreature 
	{ 
		public  GrahamVanTalen() : base() 
		{ 
			Model = 2630;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Graham Van Talen" ;
			Flags1 = 0x018480046 ;
			Id = 4586 ; 
			Guild = "Journeyman Engineer";
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
			NpcText00 = "Greetings $N, I am Graham Van Talen." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,4040
								   ,3991
								   ,3988} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class Tinkerwiz : BaseCreature 
	{ 
		public  Tinkerwiz() : base() 
		{ 
			Model = 7073;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Tinkerwiz" ;
			Flags1 = 0x08080006 ;
			Id = 3494 ; 
			Guild = "Journeyman Engineer";
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
			NpcText00 = "Greetings $N, I am Tinkerwiz." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,3994
								   ,3993
								   ,3991
								   ,3992} ;
			Faction = Factions.Ratchet;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class Nogg : BaseCreature 
	{ 
		public  Nogg() : base() 
		{ 
			Model = 7135;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Nogg" ;
			Flags1 = 0x08080046 ;
			Id = 3412 ; 
			Guild = "Expert Engineer";
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
			NpcText00 = "Greetings $N, I am Nogg." ;
			BaseMana = 0 ;
			Trains = new int[] {6459
								   ,9272
								   ,3987
								   ,3988
								   ,3992
								   ,3994
								   ,3997
								   ,3999
								   ,4010
								   ,4009
								   ,4008
								   ,4007
								   ,4006
								   ,4005
								   ,4003
								   ,4001
								   ,4000
								   ,12628
								   ,3986
								   ,3985
								   ,3984
								   ,4040
								   ,4039
								   ,4014
								   ,4013
								   ,4012
								   ,3998
								   ,3995
								   ,3993
								   ,3991
								   ,3990
								   ,8336} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class DeekFizzlebizz : BaseCreature 
	{ 
		public  DeekFizzlebizz() : base() 
		{ 
			Model = 1832;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Deek Fizzlebizz" ;
			Flags1 = 0x08480046 ;
			Id = 3290 ; 
			Guild = "Journeyman Engineer";
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
			BaseHitPoints = 904 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.725f ;
			SetDamage ( 24, 31 );
			NpcText00 = "Greetings $N, I am Deek Fizzlebizz." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,4040
								   ,3991
								   ,3988} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Thund : BaseCreature 
	{ 
		public  Thund() : base() 
		{ 
			Model = 4386;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Thund" ;
			Flags1 = 0x08480046 ;
			Id = 2857 ; 
			Guild = "Journeyman Engineer";
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
			NpcText00 = "Greetings $N, I am Thund." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,4040
								   ,3991
								   ,3988} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ),new Item( 7469, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class FraddSwiftgear : BaseCreature 
	{ 
		public  FraddSwiftgear() : base() 
		{ 
			Model = 3482;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Fradd Swiftgear" ;
			Flags1 = 0x08480046 ;
			Id = 2682 ; 
			Guild = "Engineering Supplies";
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
			BaseHitPoints = 1825 ;
			NpcFlags = (int)NpcActions.Trainer ; 
			CombatReach = 1.725f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Greetings $N, I am Fradd Swiftgear." ;
			BaseMana = 0 ;
			Trains = new int[] {4036
								   ,4037
								   ,4038
								   ,12656
								   ,20220
								   ,20221} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class BronkGuzzlegear : BaseCreature 
	{ 
		public  BronkGuzzlegear() : base() 
		{ 
			Model = 3394;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Bronk Guzzlegear" ;
			Flags1 = 0x08480046 ;
			Id = 1702 ; 
			Guild = "Journeyman Engineer";
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
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Bronk Guzzlegear." ;
			BaseMana = 0 ;
			Trains = new int[] {3987
								   ,3992
								   ,3994
								   ,3993
								   ,7431
								   ,3986
								   ,3985
								   ,3984
								   ,4039
								   ,4040
								   ,3991
								   ,3988} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class FinbusGeargrind : BaseCreature 
	{ 
		public  FinbusGeargrind() : base() 
		{ 
			Model = 4285;
			AttackSpeed= 1000;
			BoundingRadius = 0.351900f ;
			Name = "Finbus Geargrind" ;
			Flags1 = 0x08480046 ;
			Id = 1676 ; 
			Guild = "Expert Engineer";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.725f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Finbus Geargrind." ;
			BaseMana = 0 ;
			Trains = new int[] {6459
								   ,9272
								   ,3987
								   ,3988
								   ,3992
								   ,3994
								   ,3997
								   ,3999
								   ,4010
								   ,4009
								   ,4008
								   ,4007
								   ,4006
								   ,4005
								   ,4003
								   ,4001
								   ,4000
								   ,12628
								   ,3986
								   ,3985
								   ,3984
								   ,4040
								   ,4041
								   ,4039
								   ,4014
								   ,4013
								   ,4012
								   ,3998
								   ,3995
								   ,3993
								   ,3991
								   ,3990
								   ,8336
								   ,7431} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	
}