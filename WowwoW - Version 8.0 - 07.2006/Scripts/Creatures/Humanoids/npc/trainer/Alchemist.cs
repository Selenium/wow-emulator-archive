//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Whuut : BaseCreature 
	{ 
		public  Whuut() : base() 
		{ 
			Model = 10578;
			Level = RandomLevel( 23 );
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Whuut" ;
			Flags1 = 0x08480046 ;
			Id = 11046 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 944 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 25, 32 );
			NpcText00 = "Greetings $N, I am Whuut." ;
			BaseMana = 0 ;
			Trains = new int[] {2280
								   ,2339
								   ,2341
								   ,2275
								   ,3184
								   ,11536
								   ,2340} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 0, 0, 0, 0 ), new Item( 6531, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class Kray : BaseCreature 
	{ 
		public  Kray() : base() 
		{ 
			Model = 10577;
			Level = RandomLevel( 25 );
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Kray" ;
			Flags1 = 0x08480046 ;
			Id = 11047 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 4.05f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Kray." ;
			BaseMana = 0 ;
			Trains = new int[] {2339
								   ,2341
								   ,2275
								   ,3184
								   ,11536} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 0, 0, 0, 0 ), new Item( 6531, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class DoctorMartinFelben : BaseCreature 
	{ 
		public  DoctorMartinFelben() : base() 
		{ 
			Model = 10576;
			AttackSpeed= 2000;
			Level = RandomLevel( 25 );
			BoundingRadius = 0.383000f ;
			Name = "Doctor Martin Felben" ;
			Flags1 = 0x018480046 ;
			Id = 11044 ; 
			Guild = "Journeyman Alchemist Trainer";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.500000f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Doctor Martin Felben." ;
			BaseMana = 0 ;
			Trains = new int[] {2280
								   ,2339
								   ,2341
								   ,2275
								   ,3184
								   ,11536
								   ,2340} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7431, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 6532, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class SylvannaForestmoon : BaseCreature 
	{ 
		public  SylvannaForestmoon() : base() 
		{ 
			Model = 10574;
			AttackSpeed= 2000;
			Level = RandomLevel( 32 );
			BoundingRadius = 0.306000f ;
			Name = "Sylvanna Forestmoon" ;
			Flags1 = 0x08480046 ;
			Id = 11042 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings $N, I am Sylvanna Forestmoon." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 0, 0, 0, 0 ), new Item( 6531, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class MillaFairancora : BaseCreature 
	{ 
		public  MillaFairancora() : base() 
		{ 
			Model = 10573;
			AttackSpeed= 2000;
			Level = RandomLevel( 24 );
			BoundingRadius = 0.306000f ;
			Name = "Milla Fairancora" ;
			Flags1 = 0x08480046 ;
			Id = 11041 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 984 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Milla Fairancora." ;
			BaseMana = 0 ;
			Trains = new int[] {2339
								   ,2341
								   ,11536
								   ,2340
								   ,2275} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7446, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ), new Item( 6534, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class KylannaWindwhisper : BaseCreature 
	{ 
		public  KylannaWindwhisper() : base() 
		{ 
			Model = 7018;
			AttackSpeed= 2000;
			Level = RandomLevel( 52 );
			BoundingRadius = 0.306000f ;
			Name = "Kylanna Windwhisper" ;
			Flags1 = 0x08480006 ;
			Id = 7948 ; 
			Guild = "Master Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2105 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 57, 73 );
			NpcText00 = "Greetings $N, I am Kylanna Windwhisper." ;
			BaseMana = 0 ;
			Trains = new int[] {17581
								   ,7842
								   ,7846
								   ,3186
								   ,3185
								   ,3181
								   ,3179
								   ,3184
								   ,2341
								   ,2340
								   ,2339
								   ,2280
								   ,11501
								   ,11498
								   ,11497
								   ,11496
								   ,11495
								   ,11491
								   ,11488
								   ,11486
								   ,11484
								   ,7838
								   ,7839
								   ,7182
								   ,7180
								   ,12610
								   ,11612
								   ,11483
								   ,15834
								   ,11536
								   ,3461
								   ,3459
								   ,3458
								   ,3465
								   ,3178
								   ,2275
								   ,22809
								   ,17581
								   ,7842
								   ,7846
								   ,3186
								   ,3185
								   ,3181
								   ,3179
								   ,3184
								   ,2341
								   ,2340
								   ,2339
								   ,2280
								   ,11501
								   ,11498
								   ,11497
								   ,11496
								   ,11495
								   ,11491
								   ,11488
								   ,11486
								   ,11484
								   ,7838
								   ,7839
								   ,7182
								   ,7180
								   ,12610
								   ,11612
								   ,11483
								   ,15834
								   ,11536
								   ,3461
								   ,3459
								   ,3458
								   ,3465
								   ,3178
								   ,2275
								   ,22809
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7465, InventoryTypes.MainGauche, 2, 14, 1, 2, 0, 0, 0 ));
		}
	}
	public class TelAthir : BaseCreature 
	{ 
		public  TelAthir() : base() 
		{ 
			Model = 3298;
			AttackSpeed= 2000;
			Level = RandomLevel( 31 );
			BoundingRadius = 0.389000f ;
			Name = "Tel'Athir" ;
			Flags1 = 0x08480046 ;
			Id = 5500 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1264 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 33, 43 );
			NpcText00 = "Greetings $N, I am Tel'Athir." ;
			BaseMana = 0 ;
			Trains = new int[] {2339
								   ,2341
								   ,11536
								   ,2340
								   ,2275
							   };
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class LilyssiaNightbreeze : BaseCreature 
	{ 
		public  LilyssiaNightbreeze() : base() 
		{ 
			Model = 3295;
			AttackSpeed= 2000;
			Level = RandomLevel( 35 );
			BoundingRadius = 0.306000f ;
			Name = "Lilyssia Nightbreeze" ;
			Flags1 = 0x08480046 ;
			Id = 5499 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Lilyssia Nightbreeze." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7446, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class TallyBerryfizz : BaseCreature 
	{ 
		public  TallyBerryfizz() : base() 
		{ 
			Model = 3124;
			Level = RandomLevel( 35 );
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Tally Berryfizz" ;
			Flags1 = 0x08480046 ;
			Id = 5177 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.725f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Tally Berryfizz." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7446, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ), new Item( 6593, InventoryTypes.Back, 2, 3, 1, 7, 0, 0, 0 ));
		}
	}
	public class AlchemistNarett : BaseCreature 
	{ 
		public  AlchemistNarett() : base() 
		{ 
			Model = 4832;
			Level = RandomLevel( 37 );
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Alchemist Narett" ;
			Flags1 = 0x08480046 ;
			Id = 4900 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 40, 52 );
			NpcText00 = "Greetings $N, I am Alchemist Narett." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 2, 0, 0, 0 ),new Item( 6531, InventoryTypes.HeldInHand, 3, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class DoctorHerbertHalsey : BaseCreature 
	{ 
		public  DoctorHerbertHalsey() : base() 
		{ 
			Model = 2623;
			AttackSpeed= 2000;
			Level = RandomLevel( 50 );
			BoundingRadius = 0.383000f ;
			Name = "Doctor Herbert Halsey" ;
			Flags1 = 0x018480046 ;
			Id = 4611 ; 
			Guild = "Artisan Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.500000f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Doctor Herbert Halsey." ;
			BaseMana = 0 ;
			Trains = new int[] {11612
								   ,22809
								   ,2340
								   ,3458
								   ,3465
								   ,3178
								   ,3186
								   ,3185
								   ,3181
								   ,3179
								   ,3184
								   ,2341
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7839
								   ,7182
								   ,7180
								   ,12610
								   ,11491
								   ,11488
								   ,11486
								   ,11484
								   ,11483
								   ,11536
								   ,3461
								   ,3459
								   ,2339
								   ,2280
								   ,22809
								   ,2340
								   ,3458
								   ,3465
								   ,3178
								   ,3186
								   ,3185
								   ,3181
								   ,3179
								   ,3184
								   ,2341
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7839
								   ,7182
								   ,7180
								   ,12610
								   ,11491
								   ,11488
								   ,11486
								   ,11484
								   ,11483
								   ,11536
								   ,3461
								   ,3459
								   ,2339
								   ,2280
								   ,22809
								   ,2340
								   ,3458
								   ,3465
								   ,3178
								   ,3186
								   ,3185
								   ,3181
								   ,3179
								   ,3184
								   ,2341
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7839
								   ,7182
								   ,7180
								   ,12610
								   ,11491
								   ,11488
								   ,11486
								   ,11484
								   ,11483
								   ,11536
								   ,3461
								   ,3459
								   ,2339
								   ,2280
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ),new Item( 6536, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class DoctorMarsh : BaseCreature 
	{ 
		public  DoctorMarsh() : base() 
		{ 
			Model = 2624;
			AttackSpeed= 2000;
			Level = RandomLevel( 35 );
			BoundingRadius = 0.383000f ;
			Name = "Doctor Marsh" ;
			Flags1 = 0x018480046 ;
			Id = 4609 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Doctor Marsh." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 0, 0, 0, 0 ));
		}
	}
	public class Ainethil : BaseCreature 
	{ 
		public  Ainethil() : base() 
		{ 
			Model = 10624;
			AttackSpeed= 2000;
			Level = RandomLevel( 46 );
			BoundingRadius = 0.306000f ;
			Name = "Ainethil" ;
			Flags1 = 0x08480046 ;
			Id = 4160 ; 
			Guild = "Artisan Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Ainethil." ;
			BaseMana = 0 ;
			Trains = new int[] {22809
								   ,2340
								   ,3458
								   ,3465
								   ,3178
								   ,3186
								   ,3185
								   ,3181
								   ,3179
								   ,3184
								   ,2341
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7839
								   ,7182
								   ,7180
								   ,12610
								   ,11491
								   ,11488
								   ,11486
								   ,11484
								   ,11483
								   ,11536
								   ,3461
								   ,3459
								   ,2339
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7446, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ),new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class Kylanna : BaseCreature 
	{ 
		public  Kylanna() : base() 
		{ 
			Model = 4181;
			AttackSpeed= 2000;
			Level = RandomLevel( 31 );
			BoundingRadius = 0.306000f ;
			Name = "Kylanna" ;
			Flags1 = 0x08480046 ;
			Id = 3964 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Kylanna." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7465, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class CyndraKindwhisper : BaseCreature 
	{ 
		public  CyndraKindwhisper() : base() 
		{ 
			Model = 1702;
			AttackSpeed= 2000;
			Level = RandomLevel( 28 );
			BoundingRadius = 0.306000f ;
			Name = "Cyndra Kindwhisper" ;
			Flags1 = 0x08480046 ;
			Id = 3603 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 944 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 25, 32 );
			NpcText00 = "Greetings $N, I am Cyndra Kindwhisper." ;
			BaseMana = 0 ;
			Trains = new int[] {2280
								   ,2339
								   ,2341
								   ,2275
								   ,3184
								   ,11536
								   ,2340
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 2, 0, 0, 0 ),new Item( 6531, InventoryTypes.HeldInHand, 3, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class Yelmak : BaseCreature 
	{ 
		public  Yelmak() : base() 
		{ 
			Model = 1368;
			AttackSpeed= 1739;
			Level = RandomLevel( 35 );
			BoundingRadius = 0.372000f ;
			Name = "Yelmak" ;
			Flags1 = 0x08480046 ;
			Id = 3347 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Yelmak." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 2, 0, 0, 0 ),new Item( 6531, InventoryTypes.HeldInHand, 3, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class Miaozan : BaseCreature 
	{ 
		public  Miaozan() : base() 
		{ 
			Model = 4071;
			AttackSpeed= 2000;
			Level = RandomLevel( 25 );
			BoundingRadius = 0.306000f ;
			Name = "Miao'zan" ;
			Flags1 = 0x08480046 ;
			Id = 3184 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 13, 16 );
			NpcText00 = "Greetings $N, I am Miao'zan." ;
			BaseMana = 0 ;
			Trains = new int[] {2339
								   ,2341
								   ,2275
								   ,3184
								   ,11536} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 18607, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ),new Item( 6531, InventoryTypes.HeldInHand, 3, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class BenaWinterhoof : BaseCreature 
	{ 
		public  BenaWinterhoof() : base() 
		{ 
			Model = 2108;
			AttackSpeed= 2000;
			Level = RandomLevel( 35 );
			BoundingRadius = 0.872500f ;
			Name = "Bena Winterhoof" ;
			Flags1 = 0x08480046 ;
			Id = 3009 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 3.75f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Bena Winterhoof." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 2, 0, 0, 0 ),new Item( 6531, InventoryTypes.HeldInHand, 3, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class JaxinChong : BaseCreature 
	{ 
		public  JaxinChong() : base() 
		{ 
			Model = 7174;
			AttackSpeed= 2000;
			Level = RandomLevel( 46 );
			BoundingRadius = 0.306000f ;
			Name = "Jaxin Chong" ;
			Flags1 = 0x08080046 ;
			Id = 2837 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1865 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Greetings $N, I am Jaxin Chong." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7465, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class SergeHinott : BaseCreature 
	{ 
		public  SergeHinott() : base() 
		{ 
			Model = 3678;
			AttackSpeed= 2000;
			Level = RandomLevel( 32 );
			BoundingRadius = 0.383000f ;
			Name = "Serge Hinott" ;
			Flags1 = 0x08400046 ;
			Id = 2391 ; 
			Guild = "Expert Alchemist";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings $N, I am Serge Hinott." ;
			BaseMana = 0 ;
			Trains = new int[] {3465
								   ,2280
								   ,3184
								   ,3181
								   ,3186
								   ,11536
								   ,7839
								   ,2275
								   ,7846
								   ,7842
								   ,7838
								   ,7180
								   ,3458
								   ,3185
								   ,3179
								   ,2341
								   ,2339
								   ,2340
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ),new Item( 6532, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class CarolaiAnise : BaseCreature 
	{ 
		public  CarolaiAnise() : base() 
		{ 
			Model = 1601;
			AttackSpeed= 2000;
			Level = RandomLevel( 25 );
			BoundingRadius = 0.383000f ;
			Name = "Carolai Anise" ;
			Flags1 = 0x08400046 ;
			Id = 2132 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 744 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 19, 25 );
			NpcText00 = "Greetings $N, I am Carolai Anise." ;
			BaseMana = 0 ;
			Trains = new int[] {2280
								   ,2339
								   ,2341
								   ,2275
								   ,3184
								   ,11536
								   ,2340
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 2, 0, 0, 0 ),new Item( 6531, InventoryTypes.HeldInHand, 3, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class GhakHealtouch : BaseCreature 
	{ 
		public  GhakHealtouch() : base() 
		{ 
			Model = 1834;
			AttackSpeed= 2000;
			Level = RandomLevel( 25 );
			BoundingRadius = 0.347000f ;
			Name = "Ghak Healtouch" ;
			Flags1 = 0x08480046 ;
			Id = 1470 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 624 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Greetings $N, I am Ghak Healtouch." ;
			BaseMana = 0 ;
			Trains = new int[] {11788
								   ,11720
								   ,11676
								   ,11718
								   ,18940
								   ,18939
								   ,18929
								   ,18928
								   ,18927
								   ,18648
								   ,18753
								   ,18169
								   ,18158
								   ,18157
								   ,18156
								   ,18155
								   ,18154
								   ,2945
								   ,8290
								   ,8291
								   ,3707
								   ,3706
								   ,3705
								   ,3704
								   ,2972
								   ,1394
								   ,6204
								   ,7661
								   ,6203
								   ,1369
								   ,5783
								   ,2942
								   ,11731
								   ,5702
								   ,11680
								   ,11679
								   ,11724
								   ,11723
								   ,11664
								   ,11663
								   ,11662
								   ,11674
								   ,11673
								   ,11698
								   ,11697
								   ,11696
								   ,11706
								   ,11705
								   ,11728
								   ,11727
								   ,11710
								   ,11709
								   ,11686
								   ,11685
								   ,11742
								   ,11741
								   ,11670
								   ,11669
								   ,11666
								   ,11738
								   ,11737
								   ,11736
								   ,11716
								   ,11715
								   ,11714
								   ,11692
								   ,11691
								   ,11690
								   ,18935
								   ,18934
								   ,18933
								   ,18878
								   ,1477
								   ,1476
								   ,1404
								   ,1376
								   ,1375
								   ,1384
								   ,1382
								   ,1393
								   ,1383
								   ,1381
								   ,1377
								   ,1374
								   ,1368
								   ,1367
								   ,7650
								   ,6232
								   ,6228
								   ,6225
								   ,6224
								   ,6221
								   ,6216
								   ,6214
								   ,5741
								   ,5736
								   ,5139
								   ,1478
								   ,1406
								   ,2971
								   ,7662
								   ,7649
								   ,7652
								   ,7647
								   ,7666
								   ,7665
								   ,7642
								   ,1407
								   ,7664
								   ,20769
								   ,20768
								   ,20767
								   ,20766
								   ,18877
								   ,18876
								   ,18875
								   ,18872
								   ,18171
								   ,18170
								   ,607
								   ,1197
								   ,5486
								   ,17938
								   ,17865
								   ,18162
								   ,18161
								   ,1572
								   ,18160
								   ,1571
								   ,17733
								   ,17732
								   ,6485
								   ,5501
								   ,11702
								   ,11701
								   ,7663
								   ,6220
								   ,6227
								   ,6218
								   ,6206
								   ,1297
								   ,1296
								   ,5709
								   ,7660
								   ,5700
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Rogvar : BaseCreature 
	{ 
		public  Rogvar() : base() 
		{ 
			Model = 4380;
			AttackSpeed= 2000;
			Level = RandomLevel( 53 );
			BoundingRadius = 0.372000f ;
			Name = "Rogvar" ;
			Flags1 = 0x08400046 ;
			Id = 1386 ; 
			Guild = "Superior Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1865 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Greetings $N, I am Rogvar." ;
			BaseMana = 0 ;
			Trains = new int[] {  11612   // Artisan Alchemist (316514)
								   , 11522   // Restorative Elixir (313119)
								   , 22809   // Elixir of Greater Water Breathing (618000)
								   , 11491   // Superior Healing Potion (313205)
								   , 11493   // Transmute: Iron to Gold (313728)
								   , 11495   // Elixir of Detect Undead (313249)
								   , 15834   // Dreamless Sleep Potion (417199)
								   , 11497   // Elixir of Greater Intellect (313363)
								   , 11496   // Arcane Elixir (309897)
								   , 17581   // Stonescale Oil (469377)
								   , 11498   // Elixir of Greater Agility (313391)
								   , 11501   // Elixir of Detect Demon (313705)
								   , 17605   // Recipe: Greater Holy Protection Potion (472409)
								   , 22432   // Refined Scale of Onyxia (609729)
								   , 17640   // Recipe: Alchemist's Stone (474417)
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7465, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class VosurBrakthel : BaseCreature 
	{ 
		public  VosurBrakthel() : base() 
		{ 
			Model = 10635;
			AttackSpeed= 2000;
			Level = RandomLevel( 30 );
			BoundingRadius = 0.347000f ;
			Name = "Vosur Brakthel" ;
			Flags1 = 0x08480046 ;
			Id = 1246 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Vosur Brakthel." ;
			BaseMana = 0 ;
			Trains = new int[] {2339
								   ,2341
								   ,2275
								   ,2280
								   ,3184
								   ,11536
								   ,2340
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ),new Item( 6536, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
		}
	}
	public class AlchemistMallory : BaseCreature 
	{ 
		public  AlchemistMallory() : base() 
		{ 
			Model = 3237;
			AttackSpeed= 1500;
			Level = RandomLevel( 26 );
			BoundingRadius = 0.306000f ;
			Name = "Alchemist Mallory" ;
			Flags1 = 0x08480046 ;
			Id = 1215 ; 
			Guild = "Journeyman Alchemist";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 100 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings $N, I am Alchemist Mallory." ;
			BaseMana = 0 ;
			Trains = new int[] {2280
								   ,2339
								   ,2341
								   ,2275
								   ,3184
								   ,11536
								   ,2340
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7465, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6434, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	
}