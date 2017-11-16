//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Byancie : BaseCreature 
	{ 
		public  Byancie() : base() 
		{ 
			Model = 4862;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Byancie" ;
			Flags1 = 0x08480046 ;
			Id = 6094 ; 
			Guild = "First Aid Trainer";
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
			NpcText00 = "Greetings $N, I am Byancie." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,3281
								   ,7936
								   ,7930
								   ,3282
								   ,3283} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Rawrk : BaseCreature 
	{ 
		public  Rawrk() : base() 
		{ 
			Model = 4611;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Rawrk" ;
			Flags1 = 0x08480046 ;
			Id = 5943 ; 
			Guild = "First Aid Trainer";
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
			BaseHitPoints = 664 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 17, 22 );
			NpcText00 = "Greetings $N, I am Rawrk." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,3281
								   ,7936
								   ,7930
								   ,3282
								   ,3283} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class ViraYounghoof : BaseCreature 
	{ 
		public  ViraYounghoof() : base() 
		{ 
			Model = 4605;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Vira Younghoof" ;
			Flags1 = 0x08480046 ;
			Id = 5939 ; 
			Guild = "First Aid Trainer";
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
			CombatReach = 3.75f ;
			SetDamage ( 14, 18 );
			NpcText00 = "Greetings $N, I am Vira Younghoof." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,7936
								   ,7930
								   ,3282
								   ,3283} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 22394, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class NurseNeela : BaseCreature 
	{ 
		public  NurseNeela() : base() 
		{ 
			Model = 4179;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Nurse Neela" ;
			Flags1 = 0x08400046 ;
			Id = 5759 ; 
			Guild = "First Aid Trainer";
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
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Nurse Neela." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,3281
								   ,7936
								   ,7930
								   ,3282
								   ,3283} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class NissaFirestone : BaseCreature 
	{ 
		public  NissaFirestone() : base() 
		{ 
			Model = 3068;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Nissa Firestone" ;
			Flags1 = 0x08480046 ;
			Id = 5150 ; 
			Guild = "First Aid Trainer";
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
			NpcText00 = "Greetings $N, I am Nissa Firestone." ;
			BaseMana = 0 ;
			Trains = new int[] {7930
								   ,3282
								   ,3283
								   ,3281
								   ,7936
								   ,3280} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class MaryEdras : BaseCreature 
	{ 
		public  MaryEdras() : base() 
		{ 
			Model = 2670;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Mary Edras" ;
			Flags1 = 0x018480046 ;
			Id = 4591 ; 
			Guild = "First Aid Trainer";
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
			NpcText00 = "Greetings $N, I am Mary Edras." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,3281
								   ,7936
								   ,7930
								   ,3282
								   ,3283} ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class Dannelor : BaseCreature 
	{ 
		public  Dannelor() : base() 
		{ 
			Model = 2248;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Dannelor" ;
			Flags1 = 0x08480046 ;
			Id = 4211 ; 
			Guild = "First Aid Trainer";
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
			NpcText00 = "Greetings $N, I am Dannelor." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,7936
								   ,7930
								   ,3282
								   ,3283} ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Arnok : BaseCreature 
	{ 
		public  Arnok() : base() 
		{ 
			Model = 1395;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Arnok" ;
			Flags1 = 0x08480046 ;
			Id = 3373 ; 
			Guild = "First Aid Trainer";
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
			NpcText00 = "Greetings $N, I am Arnok." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,7936
								   ,7930
								   ,3282
								   ,3283
								   ,3281
								   ,3279
								   ,3280
								   ,7936
								   ,7930
								   ,3282
								   ,3283
								   ,3281} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class FremalDoohickey : BaseCreature 
	{ 
		public  FremalDoohickey() : base() 
		{ 
			Model = 3469;
			AttackSpeed= 1000;
			BoundingRadius = 0.351900f ;
			Name = "Fremal Doohickey" ;
			Flags1 = 0x08480046 ;
			Id = 3181 ; 
			Guild = "First Aid Trainer";
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
			CombatReach = 1.725f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Fremal Doohickey." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,3281
								   ,7936
								   ,7930
								   ,3282
								   ,3283} ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class PandStonebinder : BaseCreature 
	{ 
		public  PandStonebinder() : base() 
		{ 
			Model = 2131;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Pand Stonebinder" ;
			Flags1 = 0x08480046 ;
			Id = 2798 ; 
			Guild = "First Aid Trainer";
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
			NpcText00 = "Greetings $N, I am Pand Stonebinder." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,3281
								   ,7936
								   ,7930
								   ,3282} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class ShainaFuller : BaseCreature 
	{ 
		public  ShainaFuller() : base() 
		{ 
			Model = 1496;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Shaina Fuller" ;
			Flags1 = 0x08480046 ;
			Id = 2327 ; 
			Guild = "First Aid Trainer";
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
			NpcText00 = "Greetings $N, I am Shaina Fuller." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,3281
								   ,7936
								   ,7930
								   ,3282} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class MichelleBelle : BaseCreature 
	{ 
		public  MichelleBelle() : base() 
		{ 
			Model = 1296;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Michelle Belle" ;
			Flags1 = 0x08480046 ;
			Id = 2329 ; 
			Guild = "Physician";
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
			BaseHitPoints = 220 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 11, 15 );
			NpcText00 = "I can train you in First Aid techniques" ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3281
								   ,3280
								   ,7936
								   ,3282
								   ,3283
								   ,7937
								   ,7925
								   ,7930
								   ,7931
								   ,10842
								   ,10847
								   ,10843
								   ,18631
								   ,18632} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class ThamnerPol : BaseCreature 
	{ 
		public  ThamnerPol() : base() 
		{ 
			Model = 3433;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Thamner Pol" ;
			Flags1 = 0x08480046 ;
			Id = 2326 ; 
			Guild = "Physician";
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
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Thamner Pol." ;
			BaseMana = 0 ;
			Trains = new int[] {3279
								   ,3280
								   ,7936
								   ,7930
								   ,3282
								   ,3283
								   ,3281} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 24595, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	
}