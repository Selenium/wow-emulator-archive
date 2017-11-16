//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class HesuwaThunderhorn : BaseCreature 
	{ 
		public  HesuwaThunderhorn() : base() 
		{ 
			Model = 9337;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Hesuwa Thunderhorn" ;
			Flags1 = 0x08480046 ;
			Id = 10086 ; 
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
			NpcText00 = "Greetings $N, I am Hesuwa Thunderhorn." ;
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
			Equip( new Item( 6234, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class Harruk : BaseCreature 
	{ 
		public  Harruk() : base() 
		{ 
			Model = 4296;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Harruk" ;
			Flags1 = 0x08480046 ;
			Id = 3620 ; 
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
			BaseHitPoints = 1344 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 28, 36 );
			NpcText00 = "Greetings $N, I am Harruk." ;
			BaseMana = 0 ;
			Trains = new int[] {15147
								   ,15150
								   ,15151
								   ,15149} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7429, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class AlenndaarLapidaar : BaseCreature 
	{ 
		public  AlenndaarLapidaar() : base() 
		{ 
			Model = 7538;
			AttackSpeed= 1735;
			BoundingRadius = 1.00f ;
			Name = "Alenndaar Lapidaar" ;
			Flags1 = 0x08480046 ;
			Id = 8308 ; 
			Guild = "Hunter Trainer";
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
			CombatReach = 11.00f ;
			SetDamage ( 29, 38 );
			NpcText00 = "Greetings $N, I am Alenndaar Lapidaar." ;
			BaseMana = 1353 ;
			Trains = new int[] {  2978
								   , 1547
								   , 13164
								   , 2003 
								   , 5298 
								   , 3048 
								   , 14332
								   , 5117 
								   , 1579 
								   , 5335 
								   , 6385 
								   , 1236 
								   , 1584 
								   , 20160
								   , 13556
								   , 1117 
								   , 2979 
								   , 14352
								   , 20738
								   , 6198 
								   , 2899 
								   , 1567 
								   , 1549 
								   , 14333
								   , 13799
								   , 14374
								   , 20161
								   , 13557
								   , 5338 
								   , 5131 
								   , 796  
								   , 6791 
								   , 1552 
								   , 14353
								   , 14346
								   , 14431
								   , 3047 
								   , 6792 
								   , 14334
								   , 20159
								   , 14364
								   , 20157
								   , 13558
								   , 3049 
								   , 14375
								   , 3663 
								   , 13811
								   , 14354
								   , 14445
								   , 13162
								   , 14341
								   , 5385 
								   , 6999 
								   , 15637
								   , 14335
								   , 20155
								   , 1603 
								   , 14347
								   , 13814
								   , 14344
								   , 13559
								   , 3664 
								   , 14365
								   , 14355
								   , 2898 
								   , 14376
								   , 14339
								   , 13160
								   , 20158
								   , 14336
								   , 14368
								   , 14432
								   , 15638
								   , 1564 
								   , 14359
								   , 14348
								   , 13560
								   , 13545
								   , 14342
								   , 14372
								   , 14356
								   , 20044
								   , 14446
								   , 14366
								   , 14350
								   , 14377
								   , 14337
								   , 14345
								   , 20917
								   , 20156
								   , 20940
								   , 14361
								   , 15639
								   , 13561
								   , 13546
								   , 14357
								   , 14349
								   , 14373
								   , 14360
								   , 20191
								   , 14338
								   , 14367
								   , 14351
								   , 14378
								   , 14343
								   , 14434
								   , 14362
								   , 13562
								   , 19877
								   , 20926
								   , 13547
								   , 14340
								   , 20941
								   , 14370
								   , 14358
							   } ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class EinrisBrightspear : BaseCreature 
	{ 
		public  EinrisBrightspear() : base() 
		{ 
			Model = 3312;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Einris Brightspear" ;
			Flags1 = 0x08480046 ;
			Id = 5515 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Einris Brightspear." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class UlfirIronbeard : BaseCreature 
	{ 
		public  UlfirIronbeard() : base() 
		{ 
			Model = 3309;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Ulfir Ironbeard" ;
			Flags1 = 0x08480046 ;
			Id = 5516 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Ulfir Ironbeard." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7446, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class ThorfinStoneshield : BaseCreature 
	{ 
		public  ThorfinStoneshield() : base() 
		{ 
			Model = 3310;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Thorfin Stoneshield" ;
			Flags1 = 0x08480046 ;
			Id = 5517 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Thorfin Stoneshield." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7426, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ),new Item( 6235, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class Kaerbrus : BaseCreature 
	{ 
		public  Kaerbrus() : base() 
		{ 
			Model = 3299;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Kaerbrus" ;
			Flags1 = 0x08480046 ;
			Id = 5501 ; 
			Guild = "Hunter Trainer";
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
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Kaerbrus." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class DaeraBrightspear : BaseCreature 
	{ 
		public  DaeraBrightspear() : base() 
		{ 
			Model = 3056;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Daera Brightspear" ;
			Flags1 = 0x08480046 ;
			Id = 5115 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Daera Brightspear." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7480, InventoryTypes.MainGauche, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class OlminBurningbeard : BaseCreature 
	{ 
		public  OlminBurningbeard() : base() 
		{ 
			Model = 3072;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Olmin Burningbeard" ;
			Flags1 = 0x08480046 ;
			Id = 5116 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Olmin Burningbeard." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class RegnusThundergranite : BaseCreature 
	{ 
		public  RegnusThundergranite() : base() 
		{ 
			Model = 3073;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Regnus Thundergranite" ;
			Flags1 = 0x08480046 ;
			Id = 5117 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Regnus Thundergranite." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class Dorion : BaseCreature 
	{ 
		public  Dorion() : base() 
		{ 
			Model = 2251;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Dorion" ;
			Flags1 = 0x08480046 ;
			Id = 4205 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Dorion." ;
			BaseMana = 4393 ;
			Trains = new int[] {1424
								   ,15640
								   ,15639
								   ,15638
								   ,15637
								   ,13811
								   ,14354
								   ,14364
								   ,3049
								   ,13558
								   ,6792
								   ,14334
								   ,14431
								   ,3047
								   ,1552
								   ,14353
								   ,6791
								   ,14374
								   ,13557
								   ,13799
								   ,3664
								   ,1549
								   ,14333
								   ,1564
								   ,3663
								   ,14352
								   ,2979
								   ,1567
								   ,3128
								   ,5338
								   ,1603
								   ,5298
								   ,5131
								   ,5117
								   ,6385
								   ,796
								   ,1117
								   ,13556
								   ,14332
								   ,3048
								   ,2003
								   ,13562
								   ,20942
								   ,6999
								   ,13164
								   ,2899
								   ,14362
								   ,14361
								   ,14373
								   ,14372
								   ,13547
								   ,13546
								   ,13545
								   ,14360
								   ,14359
								   ,14434
								   ,14432
								   ,13160
								   ,14370
								   ,14368
								   ,14378
								   ,14377
								   ,14376
								   ,14346
								   ,14340
								   ,14339
								   ,14367
								   ,14366
								   ,14365
								   ,14358
								   ,14357
								   ,14356
								   ,14355
								   ,14351
								   ,14350
								   ,6198
								   ,2898
								   ,13814
								   ,20941
								   ,20940
								   ,20938
								   ,1563
								   ,20935
								   ,20934
								   ,20933
								   ,20932
								   ,20931
								   ,20926
								   ,20917
								   ,20738
								   ,20191
								   ,20044
								   ,20156
								   ,20158
								   ,20155
								   ,20157
								   ,20159
								   ,20161
								   ,20160
								   ,1547
								   ,20943
								   ,8738
								   ,13561
								   ,13560
								   ,13559
								   ,14345
								   ,14344
								   ,14349
								   ,14348
								   ,14347
								   ,14338
								   ,14337
								   ,14336
								   ,14335
								   ,5385
								   ,14446
								   ,14445
								   ,13162
								   ,14343
								   ,14342
								   ,14341
								   ,14375} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class Jocaste : BaseNPC 
	{ 
		public  Jocaste() : base() 
		{ 
			Model = 2206;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Jocaste" ;
			Flags1 = 0x08480046 ;
			Id = 4146 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Jocaste." ;
			BaseMana = 3191 ;
			Trains = new int[] {1424
								   ,15640
								   ,15639
								   ,15638
								   ,15637
								   ,13811
								   ,14354
								   ,14364
								   ,3049
								   ,13558
								   ,6792
								   ,14334
								   ,14431
								   ,3047
								   ,1552
								   ,14353
								   ,6791
								   ,14374
								   ,13557
								   ,13799
								   ,3664
								   ,1549
								   ,14333
								   ,1564
								   ,3663
								   ,14352
								   ,2979
								   ,1567
								   ,3128
								   ,5338
								   ,1603
								   ,5298
								   ,5131
								   ,5117
								   ,6385
								   ,796
								   ,1117
								   ,13556
								   ,14332
								   ,3048
								   ,2003
								   ,13562
								   ,20942
								   ,6999
								   ,13164
								   ,2899
								   ,14362
								   ,14361
								   ,14373
								   ,14372
								   ,13547
								   ,13546
								   ,13545
								   ,14360
								   ,14359
								   ,14434
								   ,14432
								   ,13160
								   ,14370
								   ,14368
								   ,14378
								   ,14377
								   ,14376
								   ,14346
								   ,14340
								   ,14339
								   ,14367
								   ,14366
								   ,14365
								   ,14358
								   ,14357
								   ,14356
								   ,14355
								   ,14351
								   ,14350
								   ,6198
								   ,2898
								   ,13814
								   ,20941
								   ,20940
								   ,20938
								   ,1563
								   ,20935
								   ,20934
								   ,20933
								   ,20932
								   ,20931
								   ,20926
								   ,20917
								   ,20738
								   ,20191
								   ,20044
								   ,20156
								   ,20158
								   ,20155
								   ,20157
								   ,20159
								   ,20161
								   ,20160
								   ,1547
								   ,20943
								   ,8738
								   ,13561
								   ,13560
								   ,13559
								   ,14345
								   ,14344
								   ,14349
								   ,14348
								   ,14347
								   ,14338
								   ,14337
								   ,14336
								   ,14335
								   ,5385
								   ,14446
								   ,14445
								   ,13162
								   ,14343
								   ,14342
								   ,14341} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7441, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class JeenraNightrunner : BaseCreature 
	{ 
		public  JeenraNightrunner() : base() 
		{ 
			Model = 2205;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Jeen'ra Nightrunner" ;
			Flags1 = 0x08480046 ;
			Id = 4138 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Jeen'ra Nightrunner." ;
			BaseMana = 5751 ;
			Trains = new int[] {1424
								   ,15640
								   ,15639
								   ,15638
								   ,15637
								   ,13811
								   ,14354
								   ,14364
								   ,3049
								   ,13558
								   ,6792
								   ,14334
								   ,14431
								   ,3047
								   ,1552
								   ,14353
								   ,6791
								   ,14374
								   ,13557
								   ,13799
								   ,3664
								   ,1549
								   ,14333
								   ,1564
								   ,3663
								   ,14352
								   ,2979
								   ,1567
								   ,3128
								   ,5338
								   ,1603
								   ,5298
								   ,5131
								   ,5117
								   ,6385
								   ,796
								   ,1117
								   ,13556
								   ,14332
								   ,3048
								   ,2003
								   ,13562
								   ,20942
								   ,6999
								   ,13164
								   ,2899
								   ,14362
								   ,14361
								   ,14373
								   ,14372
								   ,13547
								   ,13546
								   ,13545
								   ,14360
								   ,14359
								   ,14434
								   ,14432
								   ,13160
								   ,14370
								   ,14368
								   ,14378
								   ,14377
								   ,14376
								   ,14346
								   ,14340
								   ,14339
								   ,14367
								   ,14366
								   ,14365
								   ,14358
								   ,14357
								   ,14356
								   ,14355
								   ,14351
								   ,14350
								   ,6198
								   ,2898
								   ,13814
								   ,20941
								   ,20940
								   ,20938
								   ,1563
								   ,20935
								   ,20934
								   ,20933
								   ,20932
								   ,20931
								   ,20926
								   ,20917
								   ,20738
								   ,20191
								   ,20044
								   ,20156
								   ,20158
								   ,20155
								   ,20157
								   ,20159
								   ,20161
								   ,20160
								   ,1547
								   ,20943
								   ,8738
								   ,13561
								   ,13560
								   ,13559
								   ,14345
								   ,14344
								   ,14349
								   ,14348
								   ,14347
								   ,14338
								   ,14337
								   ,14336
								   ,14335
								   ,5385
								   ,14446
								   ,14445
								   ,13162
								   ,14343
								   ,14342
								   ,14341
								   ,14375} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 6434, InventoryTypes.Ranged, 2, 2, 2, 3, 0, 0, 0 ));
		}
	}
	public class DanlaarNightstride : BaseCreature 
	{ 
		public  DanlaarNightstride() : base() 
		{ 
			Model = 2066;
			AttackSpeed= 1623;
			BoundingRadius = 1.00f ;
			Name = "Danlaar Nightstride" ;
			Flags1 = 0x08480046 ;
			Id = 3963 ; 
			Guild = "Hunter Trainer";
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
			CombatReach = 11.00f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Danlaar Nightstride." ;
			BaseMana = 1754 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Dazalar : BaseNPC 
	{ 
		public  Dazalar() : base() 
		{ 
			Model = 1703;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Dazalar" ;
			Flags1 = 0x08480046 ;
			Id = 3601 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Dazalar." ;
			BaseMana = 0 ;
			Trains = new int[] {1424
								   ,15640
								   ,15639
								   ,15638
								   ,15637
								   ,13811
								   ,14354
								   ,14364
								   ,3049
								   ,13558
								   ,6792
								   ,14334
								   ,14431
								   ,3047
								   ,1552
								   ,14353
								   ,6791
								   ,14374
								   ,13557
								   ,13799
								   ,3664
								   ,1549
								   ,14333
								   ,1564
								   ,3663
								   ,14352
								   ,2979
								   ,1567
								   ,3128
								   ,5338
								   ,1603
								   ,5298
								   ,5131
								   ,5117
								   ,6385
								   ,796
								   ,1117
								   ,13556
								   ,14332
								   ,3048
								   ,2003
								   ,13562
								   ,20942
								   ,6999
								   ,13164
								   ,2899
								   ,14362
								   ,14361
								   ,14373
								   ,14372
								   ,13547
								   ,13546
								   ,13545
								   ,14360
								   ,14359
								   ,14434
								   ,14432
								   ,13160
								   ,14370
								   ,14368
								   ,14378
								   ,14377
								   ,14376
								   ,14346
								   ,14340
								   ,14339
								   ,14367
								   ,14366
								   ,14365
								   ,14358
								   ,14357
								   ,14356
								   ,14355
								   ,14351
								   ,14350
								   ,6198
								   ,2898
								   ,13814
								   ,20941
								   ,20940
								   ,20938
								   ,1563
								   ,20935
								   ,20934
								   ,20933
								   ,20932
								   ,20931
								   ,20926
								   ,20917
								   ,20738
								   ,20191
								   ,20044
								   ,20156
								   ,20158
								   ,20155
								   ,20157
								   ,20159
								   ,20161
								   ,20160
								   ,1547
								   ,20943
								   ,8738
								   ,13561
								   ,13560
								   ,13559
								   ,14345
								   ,14344
								   ,14349
								   ,14348
								   ,14347
								   ,14338
								   ,14337
								   ,14336
								   ,14335
								   ,5385
								   ,14446
								   ,14445
								   ,13162
								   ,14343
								   ,14342
								   ,14341
								   ,14375} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class AyannaEverstride : BaseNPC 
	{ 
		public  AyannaEverstride() : base() 
		{ 
			Model = 1723;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Ayanna Everstride" ;
			Flags1 = 0x08080066 ;
			Id = 3596 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Ayanna Everstride." ;
			BaseMana = 0 ;
			Trains = new int[] {5298
								   ,1547
								   ,13164
								   ,3048} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class Siandur : BaseCreature 
	{ 
		public  Siandur() : base() 
		{ 
			Model = 4241;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Sian'dur" ;
			Flags1 = 0x08480046 ;
			Id = 3407 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Sian'dur." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class Xorjuul : BaseCreature 
	{ 
		public  Xorjuul() : base() 
		{ 
			Model = 4239;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Xor'juul" ;
			Flags1 = 0x08480046 ;
			Id = 3406 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Xor'juul." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7480, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class OrmakGrimshot : BaseCreature 
	{ 
		public  OrmakGrimshot() : base() 
		{ 
			Model = 1373;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Ormak Grimshot" ;
			Flags1 = 0x08480046 ;
			Id = 3352 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Ormak Grimshot." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6235, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class Thotar : BaseCreature 
	{ 
		public  Thotar() : base() 
		{ 
			Model = 3744;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Thotar" ;
			Flags1 = 0x08480046 ;
			Id = 3171 ; 
			Guild = "Hunter Trainer";
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
			Level = RandomLevel( 16 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 624 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings $N, I am Thotar." ;
			BaseMana = 0 ;
			Trains = new int[] {1424
								   ,1603
								   ,5338
								   ,5298
								   ,1567
								   ,3048
								   ,13556
								   ,796
								   ,14341
								   ,14375
								   ,13811
								   ,14354
								   ,14364
								   ,3049
								   ,13558
								   ,6792
								   ,14334
								   ,14337
								   ,14336
								   ,14335
								   ,5385
								   ,14446
								   ,14445
								   ,13162
								   ,14343
								   ,14342
								   ,14431
								   ,3047
								   ,1552
								   ,14353
								   ,6791
								   ,14374
								   ,13557
								   ,13799
								   ,3664
								   ,1549
								   ,14333
								   ,1564
								   ,3663
								   ,14352
								   ,2979
								   ,6385
								   ,13561
								   ,13560
								   ,13559
								   ,14345
								   ,14344
								   ,14349
								   ,14348
								   ,14347
								   ,14338
								   ,20941
								   ,20940
								   ,20938
								   ,1563
								   ,20935
								   ,20934
								   ,20933
								   ,20932
								   ,20931
								   ,20926
								   ,20917
								   ,20738
								   ,20191
								   ,20044
								   ,20156
								   ,20158
								   ,20155
								   ,20157
								   ,20159
								   ,20161
								   ,20160
								   ,1547
								   ,15640
								   ,15639
								   ,15638
								   ,15637
								   ,20943
								   ,8738
								   ,20942
								   ,6999
								   ,13164
								   ,2899
								   ,14362
								   ,14361
								   ,14373
								   ,14372
								   ,13547
								   ,13546
								   ,13545
								   ,14360
								   ,14359
								   ,14434
								   ,14432
								   ,13160
								   ,14370
								   ,14368
								   ,14378
								   ,14377
								   ,14376
								   ,14346
								   ,14340
								   ,14339
								   ,14367
								   ,14366
								   ,14365
								   ,14358
								   ,14357
								   ,14356
								   ,14355
								   ,14351
								   ,14350
								   ,6198
								   ,2898
								   ,13562
								   ,1117
								   ,14332
								   ,2003
								   ,3128
								   ,5117
								   ,5131} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class Jenshan : BaseCreature 
	{ 
		public  Jenshan() : base() 
		{ 
			Model = 1882;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Jen'shan" ;
			Flags1 = 0x08080066 ;
			Id = 3154 ; 
			Guild = "Hunter Trainer";
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
			CombatReach = 1.5f ;
			SetDamage ( 8, 11 );
			NpcText00 = "Greetings $N, I am Jen'shan." ;
			BaseMana = 0 ;
			Trains = new int[] {13164
								   ,2003
								   ,3048
								   ,5298
								   ,1547} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class YawSharpmane : BaseCreature 
	{ 
		public  YawSharpmane() : base() 
		{ 
			Model = 3811;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Yaw Sharpmane" ;
			Flags1 = 0x08480046 ;
			Id = 3065 ; 
			Guild = "Hunter Trainer";
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
			Level = RandomLevel( 11 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Yaw Sharpmane." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 3385, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));
		}
	}
	public class LankaFarshot : BaseCreature 
	{ 
		public  LankaFarshot() : base() 
		{ 
			Model = 3810;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Lanka Farshot" ;
			Flags1 = 0x08080066 ;
			Id = 3061 ; 
			Guild = "Hunter Trainer";
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
			Level = RandomLevel( 11 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 464 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Lanka Farshot." ;
			BaseMana = 0 ;
			Trains = new int[] {5298
								   ,3048
								   ,13164
								   ,1547} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 25260, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class KaryThunderhorn : BaseCreature 
	{ 
		public  KaryThunderhorn() : base() 
		{ 
			Model = 2112;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Kary Thunderhorn" ;
			Flags1 = 0x08480046 ;
			Id = 3038 ; 
			Guild = "Hunter Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Kary Thunderhorn." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class HoltThunderhorn : BaseCreature 
	{ 
		public  HoltThunderhorn() : base() 
		{ 
			Model = 2087;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Holt Thunderhorn" ;
			Flags1 = 0x08480046 ;
			Id = 3039 ; 
			Guild = "Hunter Trainer";
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
			CombatReach = 4.05f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Holt Thunderhorn." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7480, InventoryTypes.MainGauche, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class UrekThunderhorn : BaseCreature 
	{ 
		public  UrekThunderhorn() : base() 
		{ 
			Model = 2105;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Urek Thunderhorn" ;
			Flags1 = 0x08480046 ;
			Id = 3040 ; 
			Guild = "Hunter Trainer";
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
			CombatReach = 4.05f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Urek Thunderhorn." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22366, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 22637, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ),new Item( 6234, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class Kragg : BaseCreature 
	{ 
		public  Kragg() : base() 
		{ 
			Model = 4372;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Kragg" ;
			Flags1 = 0x08480046 ;
			Id = 1404 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Kragg." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class GrifWildheart : BaseCreature 
	{ 
		public  GrifWildheart() : base() 
		{ 
			Model = 3558;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Grif Wildheart" ;
			Flags1 = 0x08480046 ;
			Id = 1231 ; 
			Guild = "Hunter Trainer";
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
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 9, 12 );
			NpcText00 = "Greetings $N, I am Grif Wildheart." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class Ogromm : BaseCreature 
	{ 
		public  Ogromm() : base() 
		{ 
			Model = 4560;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Ogromm" ;
			Flags1 = 0x08400046 ;
			Id = 987 ; 
			Guild = "Hunter Trainer";
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
			NpcText00 = "Greetings $N, I am Ogromm." ;
			BaseMana = 0 ;
			Trains = new int[] {2978  // Raptor Strike 1
								   ,1547  // Track Beasts
								   ,13164  //Aspect of the Monkey
								   ,2003  // Serpent Sting 1
								   ,5298  // Hunter's Mark 1
								   ,3048  // Arcane Shot 1
								   ,14332  //Raptor Strike 2
								   ,5117  // Concussive Shot
								   ,1579  // Tame Beast
								   ,5335  // Beast Call ??
								   ,6385  // Aspect of the Hawk 1
								   ,1236  // Revive Pet
								   ,1584  // Feed Pet
								   ,20160  //Track Humanoids
								   ,13556  //Serpent Sting 2
								   ,1117  // Mend Pet 1
								   ,2979  // Wing Clip 1
								   ,14352  //Arcane Shot 2
								   ,20738  //Distracting Shot 1
								   ,6198  // Eagle Eye
								   ,2899  // Eyes of the Beast
								   ,1567  // Scare Beast 1
								   ,1549  // Mongoose Bite 1
								   ,14333  //Raptor Strike 3
								   ,13799  //Immolation Trap 1
								   ,14374  //Aspect of the Hawk 2
								   ,20161  //Track Undead
								   ,13557  //Serpent Sting 3
								   ,5338  // Multi-Shot 1
								   ,5131  // Aspect of the Cheetah
								   ,796  //  Mend Pet 2
								   ,6791  // Disengage 1
								   ,1552  // Freezing Trap 1
								   ,14353  //Arcane Shot 3
								   ,14346  //Distracting Shot 2
								   ,14431  //Hunter's Mark 2
								   ,3047  // Scorpid Sting 1
								   ,6792  // Beast Lore
								   ,14334  //Raptor Strike 4
								   ,20159  //Track Hidden
								   ,14364  //Immolation Trap 2
								   ,20157  //Track Elementals
								   ,13558  //Serpent Sting 4
								   ,3049  // Rapid Fire
								   ,14375  //Aspect of the Hawk 3
								   ,3663  // Mend Pet 3
								   ,13811  //Frost Trap
								   ,14354  //Arcane Shot 4
								   ,14445  //Scare Beast 2
								   ,13162  //Aspect of the Beast
								   ,14341  //Mongoose Bite 2
								   ,5385  // Feign Death
								   ,6999  // Multi-Shot 2
								   ,15637  //Distracting Shot 3
								   ,14335  //Raptor Strike 5
								   ,20155  //Track Demons
								   ,1603  // Flare
								   ,14347  //Scorpid Sting 2
								   ,13814  //Explosive Trap 1
								   ,14344  //Disengage 2
								   ,13559  //Serpent Sting 5
								   ,3664  // Mend Pet 4
								   ,14365  //Immolation Trap 3
								   ,14355  //Arcane Shot 5
								   ,2898  // Viper Sting 1
								   ,14376  //Aspect of the Hawk 4
								   ,14339  //Wing Clip 2
								   ,13160  //Aspect of the Pack
								   ,20158  //Track Giants
								   ,14336  //Raptor Strike 6
								   ,14368  //Freezing Trap 2
								   ,14432  //Hunter's Mark 3
								   ,15638  //Distracting Shot 4
								   ,1564  // Volly 1
								   ,14359  //Multi-Shot 3
								   ,14348  //Scorpid Sting 3
								   ,13560  //Serpent Sting 6
								   ,13545  //Mend Pet 5
								   ,14342  //Mongoose Bite 3
								   ,14372  //Explosive Trap 2
								   ,14356  //Arcane Shot 6
								   ,20044  //Aspect of the Wild 1
								   ,14446  //Scare Beast 3
								   ,14366  //Immolation Trap 4
								   ,14350  //Viper Sting 2
								   ,14377  //Aspect of the Hawk 5
								   ,14337  //Raptor Strike 7
								   ,14345  //Disengage 3
								   ,20917  //Spirit Bond 2 (Talent)
								   ,20156  //Track Dragonkin
								   ,20940  //Lacerate 2 (Talent)
								   ,14361  //Volley 2
								   ,15639  //Distracting Shot 5
								   ,13561  //Serpent Sting 7
								   ,13546  //Mend Pet 6
								   ,14357  //Arcane Shot 7
								   ,14349  //Scorpid Sting 4
								   ,14373  //Explosive Trap 3
								   ,14360  //Multi-Shot 4
								   ,20191  //Aspect of the Wild 2
								   ,14338  //Raptor Strike 8
								   ,14367  //Immolation Trap 5
								   ,14351  //Viper Sting 3
								   ,14378  //Aspect of the Hawk 6
								   ,14343  //Mongoose Bite 4
								   ,14434  //Hunter's Mark 4
								   ,14362  //Volley 3
								   ,13562  //Serpent Sting 8
								   ,19877  //Tranquilizing Shot
								   ,20926  //Spirit Bond 3 (Talent)
								   ,13547  //Mend Pet 7
								   ,14340  //Wing Clip 3
								   ,20941  //Lacerate 3 (Talent)
								   ,14370  //Freezing Trap 3
								   ,14358  //Arcane Shot 8
								   ,15640  //Distracting Shot 6
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class ThorgasGrimson : BaseCreature 
	{ 
		public  ThorgasGrimson() : base() 
		{ 
			Model = 3395;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Thorgas Grimson" ;
			Flags1 = 0x08080066 ;
			Id = 895 ; 
			Guild = "Hunter Trainer";
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
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Thorgas Grimson." ;
			BaseMana = 0 ;
			Trains = new int[] {13164
								   ,2003
								   ,3048
								   ,5298} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	
}