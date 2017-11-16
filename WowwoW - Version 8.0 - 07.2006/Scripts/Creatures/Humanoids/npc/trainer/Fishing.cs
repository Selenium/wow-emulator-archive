//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class LauTiki : BaseCreature 
	{ 
		public  LauTiki() : base() 
		{ 
			Model = 4609;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Lau'Tiki" ;
			Flags1 = 0x08400046 ;
			Id = 5941 ; 
			Guild = "Fisherman";
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
			NpcText00 = "Greetings $N, I am Lau'Tiki." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
							   } ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
		}
	}
	public class UthanStillwater : BaseCreature 
	{ 
		public  UthanStillwater() : base() 
		{ 
			Model = 4604;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Uthan Stillwater" ;
			Flags1 = 0x08400046 ;
			Id = 5938 ; 
			Guild = "Fisherman";
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
			CombatReach = 4.05f ;
			SetDamage ( 15, 19 );
			NpcText00 = "Greetings $N, I am Uthan Stillwater." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class ArnoldLeland : BaseCreature 
	{ 
		public  ArnoldLeland() : base() 
		{ 
			Model = 3285;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Arnold Leland" ;
			Flags1 = 0x08480046 ;
			Id = 5493 ; 
			Guild = "Fishing Trainer";
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
			NpcText00 = "Greetings $N, I am Arnold Leland." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
								   , 18249   // Artisan Fishing (493980)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class GrimnurStonebrand : BaseCreature 
	{ 
		public  GrimnurStonebrand() : base() 
		{ 
			Model = 3096;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Grimnur Stonebrand" ;
			Flags1 = 0x08480046 ;
			Id = 5161 ; 
			Guild = "Fishing Trainer";
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
			NpcText00 = "Greetings $N, I am Grimnur Stonebrand." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
								   , 18249   // Artisan Fishing (493980)
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class ArmandCromwell : BaseCreature 
	{ 
		public  ArmandCromwell() : base() 
		{ 
			Model = 2612;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Armand Cromwell" ;
			Flags1 = 0x018480046 ;
			Id = 4573 ; 
			Guild = "Fishing Trainer";
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
			NpcText00 = "Greetings $N, I am Armand Cromwell." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
								   , 18249   // Artisan Fishing (493980)
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 

		}
	}
	public class Astaia : BaseCreature 
	{ 
		public  Astaia() : base() 
		{ 
			Model = 2211;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Astaia" ;
			Flags1 = 0x08480046 ;
			Id = 4156 ; 
			Guild = "Fishing Trainer";
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
			NpcText00 = "Greetings $N, I am Astaia." ;
			BaseMana = 0 ;
			Trains = new int[] {  7736   // Expert Fishing (218821)
								   , 18249   // Artisan Fishing (493980)
								   , 7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class AndrolOakhand : BaseCreature 
	{ 
		public  AndrolOakhand() : base() 
		{ 
			Model = 1718;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Androl Oakhand" ;
			Flags1 = 0x08480046 ;
			Id = 3607 ; 
			Guild = "Fisherman";
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
			BaseHitPoints = 1504 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 40, 52 );
			NpcText00 = "Greetings $N, I am Androl Oakhand." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class Lumak : BaseCreature 
	{ 
		public  Lumak() : base() 
		{ 
			Model = 1332;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Lumak" ;
			Flags1 = 0x08480046 ;
			Id = 3332 ; 
			Guild = "Fishing Trainer";
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
			NpcText00 = "Greetings $N, I am Lumak." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
								   , 18249   // Artisan Fishing (493980)
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class HaroldRiggs : BaseCreature 
	{ 
		public  HaroldRiggs() : base() 
		{ 
			Model = 3470;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Harold Riggs" ;
			Flags1 = 0x08480046 ;
			Id = 3179 ; 
			Guild = "Fishing Trainer";
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
			NpcText00 = "Greetings $N, I am Harold Riggs." ;
			BaseMana = 0 ;
			Trains = new int[] {  7736   // Expert Fishing (218821)
								   , 18249   // Artisan Fishing (493980)
								   , 7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class KahMistrunner : BaseCreature 
	{ 
		public  KahMistrunner() : base() 
		{ 
			Model = 2088;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Kah Mistrunner" ;
			Flags1 = 0x08480046 ;
			Id = 3028 ; 
			Guild = "Fishing Trainer";
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
			CombatReach = 4.05f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Greetings $N, I am Kah Mistrunner." ;
			BaseMana = 0 ;
			Trains = new int[] {7733
								   ,7734} ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class MatthewHooper : BaseCreature 
	{ 
		public  MatthewHooper() : base() 
		{ 
			Model = 3362;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Matthew Hooper" ;
			Flags1 = 0x08480046 ;
			Id = 1680 ; 
			Guild = "Fishing Trainer";
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
			NpcText00 = "Greetings $N, I am Matthew Hooper." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
								   , 18249   // Artisan Fishing (493980)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	public class LeeBrown : BaseCreature 
	{ 
		public  LeeBrown() : base() 
		{ 
			Model = 3272;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Lee Brown" ;
			Flags1 = 0x08480046 ;
			Id = 1651 ; 
			Guild = "Fisherman";
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
			BaseHitPoints = 304 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 7, 9 );
			NpcText00 = "Greetings $N, I am Lee Brown." ;
			BaseMana = 0 ;
			Trains = new int[] {  7733   // Apprentice Fishing (218783)
								   , 7734   // Journeyman Fishing (218802)
								   , 7736   // Expert Fishing (218821)
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7453, InventoryTypes.MainGauche, 2, 4, 2, 2, 0, 0, 0 ));
 
		}
	}
	
}