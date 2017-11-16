//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class BixiWobblebonk : BaseCreature 
	{ 
		public  BixiWobblebonk() : base() 
		{ 
			Model = 12992;
			AttackSpeed= 1500;
			BoundingRadius = 0.351900f ;
			Name = "Bixi Wobblebonk" ;
			Flags1 = 0x08480006 ;
			Id = 13084 ; 
			Guild = "Weapon Master";
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
			BaseHitPoints = 6075 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.725f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Bixi Wobblebonk." ;
			BaseMana = 0 ;
			Trains = new int[] {15995
								   ,15997 
								   ,15988 
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 )); 
		}
	}
	public class WooPing : BaseCreature 
	{ 
		public  WooPing() : base() 
		{ 
			Model = 11804;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Woo Ping" ;
			Flags1 = 0x08480006 ;
			Id = 11867 ; 
			Guild = "Weapon Master";
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
			NpcText00 = "Have you come seeking training in the ways of armed combat ?" ;
			BaseMana = 0 ;
			Trains = new int[] {15988
								   ,1847
								   ,15995} ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
	public class Sayoc : BaseCreature 
	{ 
		public  Sayoc() : base() 
		{ 
			Model = 11801;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Sayoc" ;
			Flags1 = 0x08480006 ;
			Id = 11868 ; 
			Guild = "Weapon Master";
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
			NpcText00 = "Greetings $N, I am Sayoc." ;
			BaseMana = 0 ;
			Trains = new int[] {15997
								   ,15988
								   ,15984
								   ,15985
								   ,15994
								   ,15992} ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 19555, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 19555, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 )); 
		}
	}
	public class Ansekhwa : BaseCreature 
	{ 
		public  Ansekhwa() : base() 
		{ 
			Model = 11803;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Ansekhwa" ;
			Flags1 = 0x08480006 ;
			Id = 11869 ; 
			Guild = "Weapon Master";
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
			CombatReach = 4.05f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Ansekhwa." ;
			BaseMana = 0 ;
			Trains = new int[] { 15986   // One-Handed Maces (5917)
								   ,15996   // Guns (6458)
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 25139, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ), new Item( 6234, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 )); 
		}
	}
	public class Archibald : BaseCreature 
	{ 
		public  Archibald() : base() 
		{ 
			Model = 11805;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Archibald" ;
			Flags1 = 0x018480046 ;
			Id = 11870 ; 
			Guild = "Weapon Master";
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
			NpcText00 = "Greetings $N, I am Archibald." ;
			BaseMana = 0 ;
			Trains = new int[] {1847 
								   ,15983
								   ,15991
								   ,15995
								   ,15988
							   };
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 25152, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 )); 
		}
	}
	public class IlyeniaMoonfire : BaseCreature 
	{ 
		public  IlyeniaMoonfire() : base() 
		{ 
			Model = 11802;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Ilyenia Moonfire" ;
			Flags1 = 0x08480006 ;
			Id = 11866 ; 
			Guild = "Weapon Master";
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
			NpcText00 = "Greetings $N, I am Ilyenia Moonfire." ;
			BaseMana = 0 ;
			Trains = new int[] {15994 
								   ,15989 
								   ,15988 
								   ,15992 
								   ,15997 
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 5098, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
		}
	}
	public class BuliwyfStonehand : BaseCreature 
	{ 
		public  BuliwyfStonehand() : base() 
		{ 
			Model = 11806;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Buliwyf Stonehand" ;
			Flags1 = 0x08480006 ;
			Id = 11865 ; 
			Guild = "Weapon Master";
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
			BaseHitPoints = 6075 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 1.5f ;
			SetDamage ( 54, 70 );
			NpcText00 = "Greetings $N, I am Buliwyf Stonehand." ;
			BaseMana = 0 ;
			Trains = new int[] {15992
								   ,15996
								   ,15986
								   ,15987
								   ,15984
								   ,15985} ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 25154, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 252153, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 )); 
		}
	}
	public class Xurgyl : BaseCreature 
	{ 
		public  Xurgyl() : base() 
		{ 
			Model = 9769;
			AttackSpeed= 1554;
			BoundingRadius = 1.00f ;
			Name = "Xur'gyl" ;
			Flags1 = 0x08400046 ;
			Id = 10370 ; 
			Guild = "Axe Trainer";
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
			NpcType = 10 ;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Trainer ;
			CombatReach = 11.00f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Xur'gyl." ;
			BaseMana = 2004 ;
			Trains = new int[] {  15985   // Two-Handed Axes (5901)
							   } ;
			Faction = Factions.Beast;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
	public class Hanashi : BaseCreature 
	{ 
		public  Hanashi() : base() 
		{ 
			Model = 12989;
			AttackSpeed= 1739;
			BoundingRadius = 0.306000f ;
			Name = "Hanashi" ;
			Flags1 = 0x08480006 ;
			Id = 2704 ; 
			Guild = "Weapon Master";
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
			NpcText00 = "Greetings $N, I am Hanashi." ;
			BaseMana = 0 ;
			Trains = new int[] {15984
								   ,15989
								   ,15994
								   ,15997} ;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 22598, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 )); 
		}
	}	
}