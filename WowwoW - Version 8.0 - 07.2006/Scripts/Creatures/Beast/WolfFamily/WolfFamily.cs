//DrilLer
using System;
using Server.Items;
using Server;

namespace Server.Creatures
{
	public class Barnabus : BaseCreature 
	 { 
		public  Barnabus() : base() 
		 { 
			Model = 9372;
			AttackSpeed= 2000;
			BoundingRadius = 1.300000f ;
			Name = "Barnabus" ;
			Flags1 = 0x010 ;
			Id = 2753; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 7;
			ResistFrost = 4;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 38 );
			Armor= Level*20;
			NpcType = (int)NpcTypes.Beast ;
			
			NpcFlags = 00 ;
			CombatReach = 1.625f ;
			SetDamage ( 44, 60 );
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/2.5f);
			Family=1; 
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1544, 38 );	
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( HeavyLeather), 80.0f )
					          ,new Loot( typeof( ThickWolfhide), 20.0f )
					          ,new Loot( typeof( HeavyHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Barnabus, 100f ) };
		}
	}	
}	

namespace Server.Creatures
{
	public class BlackRavager: BaseCreature 
	 { 
		public  BlackRavager() : base() 
		 { 
			Model = 741;
			AttackSpeed= 2000;
			BoundingRadius = 1.045500000f ;
			Name = "Black Ravager" ;
			Flags1 = 0x010 ;
			Id = 628 ; 
			Size = 1.0455f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 4;
			ResistFrost = 7;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 1;
			Level = RandomLevel( 24,25 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 656, 24 );	
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.BlackRavager, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class BlackRavagerMastiff: BaseCreature 
	 { 
		public  BlackRavagerMastiff () : base() 
		 { 
			Id = 1258 ; 
			Model = 9562;
			AttackSpeed= 2000;
			Name = "Black Ravager Mastiff" ;
			Flags1 = 0x010 ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 5;
			ResistFrost = 8;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 2;
			Level = RandomLevel( 25,26 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.300000f ;			
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1;
			Faction = Factions.EvilBeast;
			Size = 1.3f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 773, 25 );	
			NpcText="Speak quietly and with great care, the wrong word in these parts could get your throat cut. Now, what is it you need from me?";
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};					          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.BlackRavagerMastiff , 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class BlackrockWorg: BaseCreature 
	 { 
		public  BlackrockWorg() : base() 
		 { 
			Id = 7055 ; 
			Model = 741;
			AttackSpeed= 2000;
			Name = "Blackrock Worg" ;
			Flags1 = 0x010 ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 55 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.300000f ;			
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Monster;
			Size = 1.0455f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 			
			BCAddon.Hp( this, 773, 55 );	
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( RuggedHide), 20.0f )
					          ,new Loot( typeof( ThickWolfhide), 20.0f )					          
					          ,new Loot( typeof( ThickHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.BlackrockWorg, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class BleakWorg: BaseCreature 
	 { 
		public  BleakWorg() : base() 
		 { 
			Id = 3861 ; 
			Model = 801;
			AttackSpeed= 2000;
			Name = "Bleak Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Level = RandomLevel( 18, 19 );
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);

float step=1.2f; //step by incrase Heals in elite mobs first rang
if (Level==18)		
{
 BaseHitPoints = 1476;
} 
else
{
for (int i=1; i<=(Level-18); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1476*(float)step);
} 
			NpcFlags = 00 ;
			BoundingRadius = 1.270000f ;			
			CombatReach = 1.0625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=1; BaseMana = 100;
			Elite=1; Block=Level+20;		
			Family=1;
			Faction = Factions.Monster;
			Size = 0.85f;
			Speed = 3.55f ;
			WalkSpeed = 3.55f ;			
			RunSpeed = 6.5f ;			
			AIEngine = new SpellCasterAI( this );
			BCAddon.Hp( this, 1476, 18 );	
LearnSpell( 7127, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.BleakWorg, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class BloodaxeWorg: BaseCreature 
	 { 
		public  BloodaxeWorg() : base() 
		 { 
			Id = 9696 ; 
			Model = 9562;
			AttackSpeed= 1400;
			Name = "Bloodaxe Worg" ;
			Guild="Scarshield Legion";
			Flags1 = 0x010 ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 56,57 );
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.300000f ;			
			CombatReach = 1.025f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Monster;
			Size = 1.0455f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2226, 56 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickHide), 20.0f )
					          ,new Loot( typeof( ThickWolfhide), 20.0f )					          
					          ,new Loot( typeof( RuggedHide), 40.0f )};					          						          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.BloodaxeWorg, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class BloodaxeWorgPup: BaseCreature 
	 { 
		public  BloodaxeWorgPup() : base() 
		 { 
			Model = 9563;
			AttackSpeed= 1400;
			BoundingRadius = 1.045500000f ;
			Name = "Bloodaxe Worg Pup" ;
			Flags1 = 0x010 ;
			Id = 10221; 
			Size = 1.0f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;
			ResistArcane = 0;
			ResistFire = 4;
			ResistFrost = 7;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 1;
			Level = RandomLevel( 52,53 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2243, 52 );	
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedHide), 20.0f )
					          ,new Loot( typeof( ThickWolfhide), 20.0f )					          
					          ,new Loot( typeof( ThickHide), 40.0f )};					          						          					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.BloodaxeWorgPup, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Bloodshot: BaseCreature 
	 { 
		public  Bloodshot() : base() 
		 { 
			Id = 11614 ; 
			Model = 3203;
			AttackSpeed= 1400;
			Name = "Bloodshot" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 1;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 1;
			ResistShadow = 0;
			Level = RandomLevel( 50,54 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.300000f ;			
			CombatReach = 1.025f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.0f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;			
			RunSpeed = 6.5f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2033, 50 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( RuggedHide), 20.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};					          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Bloodshot, 100f ) }; 
		}
	}	
}

namespace Server.Creatures
{
	public class BloodsnoutWorg: BaseCreature 
	 { 
		public  BloodsnoutWorg() : base() 
		 { 
			Id = 1923 ; 
			Model = 741;
			AttackSpeed= 2000;
			Name = "Bloodsnout Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 1;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 1;
			ResistShadow = 0;
			Level = RandomLevel( 16,17 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.1500000f ;			
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Monster;
			Size = 1.15f;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;			
			RunSpeed = 6.1f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 380, 16 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.BloodsnoutWorg, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Coyote: BaseCreature 
	 { 
		public  Coyote() : base() 
		 { 
			Id = 834 ; 
			Model = 643;
			AttackSpeed= 2000;
			Name = "Coyote" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 1;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 10,11 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.1500000f ;			
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 5.1f ;
			WalkSpeed = 5.1f ;			
			RunSpeed = 8.1f ;
			AIEngine = new SpellCasterAI( this );
BCAddon.Hp( this, 169, 10 );	
LearnSpell( 3149, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 40.0f )
					     ,new Loot( typeof( RuinedLeatherScraps), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Coyote, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CoyotePackleader: BaseCreature 
	 { 
		public  CoyotePackleader() : base() 
		 { 
			Id = 833 ; 
			Model = 161;
			AttackSpeed= 2000;
			Name = "Coyote Packleader" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 1;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 11,12 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.1500000f ;			
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=1 ;
			Faction = Factions.Beast;
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new SpellCasterAI( this );
BCAddon.Hp( this, 212, 11 );	
LearnSpell( 3149, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 60.0f )
					          ,new Loot( typeof( LightLeather), 50.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};				
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.CoyotePackleader, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CragCoyote: BaseCreature 
	 { 
		public  CragCoyote() : base() 
		 { 
			Id = 2727 ; 
			Model = 161;
			AttackSpeed= 2000;
			Name = "Crag Coyote" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 5;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35,36 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.500000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1117, 35 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( HeavyLeather), 80.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};									          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.CragCoyote, 100f ) };
		}
	}	
}


/*
Death Howl - i cabt find ¹ model
Id 14339
Level 49 (Rare) EvilBeast , Family: Wolf
    Str: 110      Atk: 245 
    AGI: 80        Pwr: 200 
    STA: 202      Dmg: 72-91 
    Int: 42        Def: 245 
    Spi: 66        Arm: 3111 
            Dps: 40.6 

*/
namespace Server.Creatures
{
	public class Deathmaw: BaseCreature 
	 { 
		public  Deathmaw() : base() 
		 { 
			Id = 10077 ; 
			Model = 9562;
			AttackSpeed= 1200;
			Name = "Deathmaw" ;
			Flags1 = 0x010 ;
			ResistArcane = 100;
			ResistFire = 100;
			ResistFrost = 100;
			ResistHoly = 100;
			ResistNature =100;
			ResistShadow = 100;
			Armor=2826;
			Level = RandomLevel( 53,55 );
			Str = (int)(Level*1.5f);
			Armor=2826;
			NpcType = (int)NpcTypes.Beast ;

			NpcFlags = 00 ;
			BoundingRadius = 1.000000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+5.88f*Level,1f+6.1*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Elite=4; Block=Level+50;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new BerserkerAI( this );
			BCAddon.Hp( this, 17000, 53 );
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickLeather), 61.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Deathmaw, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Della: BaseCreature 
	 { 
		public  Della() : base() 
		 { 
			Id = 11024 ; 
			Model = 1030;
			AttackSpeed= 2000;
			Name = "Della" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 5;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 49 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 0.9500000f ;			
			CombatReach = 1.8525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Friend;
			Size = 1f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			Guild="Jessir's Pet";
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1117, 49 );
		}
	}	
}


namespace Server.Creatures
{
	public class DiseasedWolf: BaseCreature 
	 { 
		public  DiseasedWolf() : base() 
		 { 
			Id = 1817 ; 
			Model = 4124;
			AttackSpeed= 2000;
			Name = "Diseased Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 1;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 53,54 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.500000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 3112, 53 );
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedHide), 20.0f )
					          ,new Loot( typeof( ThickWolfhide), 20.0f )					          
					          ,new Loot( typeof( ThickHide), 40.0f )};					          						          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.DiseasedWolf, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class ElderCragCoyote: BaseCreature 
	 { 
		public  ElderCragCoyote() : base() 
		 { 
			Id = 2729 ; 
			Model = 1164;
			AttackSpeed= 2000;
			Name = "Elder Crag Coyote" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 5;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 39,40 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;


			NpcFlags = 00 ;
			BoundingRadius = 1.500000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.3f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1392, 39 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( HeavyLeather), 80.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};						          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.ElderCragCoyote, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class EmberWorg: BaseCreature 
	 { 
		public  EmberWorg() : base() 
		 { 
			Id = 9690 ; 
			Model = 9371;
			AttackSpeed= 2000;
			Name = "Ember Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 51,52 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.00000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Monster;
			Size = 1f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ) ); 				
			BCAddon.Hp( this, 2577, 51 );
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedHide), 20.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};						          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.EmberWorg, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class EnragedStanley: BaseCreature 
	 { 
		public  EnragedStanley() : base() 
		 { 
			Id = 2275 ; 
			Model = 11411;
			AttackSpeed= 1600;
			Name = "Enraged Stanley" ;
			Flags1 = 014 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 24 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

 
			NpcFlags = 00 ;
			BoundingRadius = 1.00000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.NoFaction;
			Size = 1f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 656, 24 );
			NpcText = "Besides the Grunts outside, my brothers and I fought at the battle of Hyjal. Any who seek to steal from the bank must face us first.";
			NpcText00 = "I guarantee this bank's security with my own blood, is that good enough for you?";			
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( MediumHide), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )
					          ,new Loot( typeof( ThickWolfhide), 20.0f )					          
					          ,new Loot( typeof( MediumHide ), 40.0f )};						          
		}
	}	
}

namespace Server.Creatures
{
	public class FelpawRavager: BaseCreature 
	 { 
		public  FelpawRavager() : base() 
		 { 
			Id = 8961 ; 
			Model = 9280;
			AttackSpeed= 2000;
			Name = "Felpaw Ravager" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 9;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 51,52 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.950000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.3f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2924, 51 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.2f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickHide), 20.0f )
					          ,new Loot( typeof( RuggedHide), 40.0f )};					          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.FelpawRavager, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class FelpawScavenger: BaseCreature 
	 { 
		public  FelpawScavenger() : base() 
		 { 
			Id = 8960 ; 
			Model = 9278;
			AttackSpeed= 2000;
			Name = "Felpaw Scavenger" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 49,50 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

 
			NpcFlags = 00 ;
			BoundingRadius = 1.720000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2458, 49 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.2f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickHide), 20.0f )
					          ,new Loot( typeof( RuggedHide), 40.0f )};					          					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.FelpawScavenger, 100f ) };					          
		}
	}	
}

namespace Server.Creatures
{
	public class FelpawWolf: BaseCreature 
	 { 
		public  FelpawWolf() : base() 
		 { 
			Id = 8959 ; 
			Model = 4124;
			AttackSpeed= 2000;
			Name = "Felpaw Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 48,49 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

 
			NpcFlags = 00 ;
			BoundingRadius = 1.50000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2358, 48 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.2f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickHide), 20.0f )
					          ,new Loot( typeof( RuggedHide), 40.0f )};					          					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.FelpawWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class FeralCragCoyote: BaseCreature 
	 { 
		public  FeralCragCoyote() : base() 
		 { 
			Id = 2728 ; 
			Model = 557;
			AttackSpeed= 2000;
			Name = "Feral Crag Coyote" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 4;
			ResistFrost = 2;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 37,38 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.720000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1329, 37 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.2f )
					          ,new Loot( typeof( HeavyLeather), 80.0f )
					          ,new Loot( typeof( HeavyHide), 40.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.FeralCragCoyote, 100f ) };					          
		}
	}	
}


/*
Frostwolf Bloodhound 
Id 14282
level 53-54
*/

namespace Server.Creatures
{
	public class GhostpawAlpha : BaseCreature 
	 { 
		public  GhostpawAlpha() : base() 
		 { 
			Id = 3825 ; 
			Model = 776;
			AttackSpeed= 1300;
			Name = "Ghostpaw Alpha" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 2;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 27,28 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.720000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.3f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 855, 27 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.2f )
					          ,new Loot( typeof( HeavyLeather), 60.0f )
					          ,new Loot( typeof( HeavyHide), 40.2f)
					          ,new Loot( typeof( MediumHide), 10.2f)};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.GhostpawAlpha, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class GhostpawHowler: BaseCreature 
	 { 
		public  GhostpawHowler() : base() 
		 { 
			Id = 3824 ; 
			Model = 1207;
			AttackSpeed= 2000;
			Name = "Ghostpaw Howler" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 1;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 23,24 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.720000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 507, 23 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.2f )
					          ,new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumHide), 40.2f)
					          ,new Loot( typeof( LightHide), 10.2f)};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.GhostpawHowler , 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class GhostpawRunner: BaseCreature 
	 { 
		public  GhostpawRunner() : base() 
		 { 
			Id = 3823 ; 
			Model = 801;
			AttackSpeed= 2000;
			Name = "Ghostpaw Runner" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 1;
			ResistFrost = 5;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 19,20 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.50000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 4f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 401, 19 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( LightHide), 40.2f)
					          ,new Loot( typeof( MediumHide), 10.2f)};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.GhostpawRunner, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class GiantEmberWorg: BaseCreature 
	 { 
		public  GiantEmberWorg() : base() 
		 { 
			Id = 9697 ; 
			Model = 9370;
			AttackSpeed= 2000;
			Name = "Giant Ember Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 5;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 19,20 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.50000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.5f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 401, 19 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickHide), 40.2f)
					          ,new Loot( typeof( ThickWolfhide), 5.2f)					          
					          ,new Loot( typeof( RuggedHide), 10.2f)};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.GiantEmberWorg, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class Gorefang: BaseCreature 
	 { 
		public  Gorefang() : base() 
		 { 
			Id = 12431 ; 
			Model = 11413;
			AttackSpeed= 2000;
			Name = "Gorefang" ;
			Flags1 = 0x010 ;
			ResistArcane = 70;
			ResistFire = 70;
			ResistFrost = 70;
			ResistHoly = 70;
			ResistNature =70;
			ResistShadow = 70;
			Level = RandomLevel( 12,13 );
			Str = (int)(Level*1.5f);			
			NpcType = (int)NpcTypes.Beast ;

			NpcFlags = 00 ;
			BoundingRadius = 1.000000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Elite=4; Block=Level+50;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.4f ;
			WalkSpeed = 3.4f ;			
			RunSpeed = 6.4f ;
			AIEngine = new BerserkerAI( this );
			BCAddon.Hp( this, 182, 12 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 60.0f )
			 		          ,new Loot( typeof( LightLeather), 50.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Gorefang, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class GrayForestWolf: BaseCreature 
	 { 
		public  GrayForestWolf() : base() 
		 { 
			Id = 1922 ; 
			Model = 380;
			AttackSpeed= 1700;
			Name = "Gray Forest Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 7,8 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.270000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 127, 7 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 80.2f ) 
					     ,new Loot( typeof( LightLeather), 60.2f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.GrayForestWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class GrinningDog: BaseCreature 
	 { 
		public  GrinningDog() : base() 
		 { 
			Id = 11871; 
			Model = 782;
			AttackSpeed= 1700;
			Name = "Grinning Dog" ;
			Flags1 = 06 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Level = RandomLevel( 48 );
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);

			NpcFlags = 00 ;
			BoundingRadius = 1.70000f ;			
			CombatReach = 1.0625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=1; BaseMana = 0;
			Elite=1; Block=Level+20;
			Family=1;
			Faction = Factions.Ogrimmar;
			Size = 1.5f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;			
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 3500, 48 );
/*			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
no loot in this mob					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Grinning Dog, 100f ) };*/
		}
	}	
}


namespace Server.Creatures
{
	public class LongtoothHowler: BaseCreature 
	 { 
		public  LongtoothHowler() : base() 
		 { 
			Id = 5287 ; 
			Model = 3202;
			AttackSpeed= 2000;
			Name = "Longtooth Howler" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 43,44 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.720000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1858, 43 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( HeavyLeather), 60.0f )
					          ,new Loot( typeof( HeavyHide), 40.2f)
					          ,new Loot( typeof( ThickHide), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.LongtoothHowler, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class LongtoothRunner: BaseCreature 
	 { 
		public  LongtoothRunner() : base() 
		 { 
			Id = 5286 ; 
			Model = 165;
			AttackSpeed= 2000;
			Name = "Longtooth Runner" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 40,41 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.50000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1584, 40 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( HeavyLeather), 60.0f )
					          ,new Loot( typeof( HeavyHide), 40.2f)
					          ,new Loot( typeof( ThickHide), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.LongtoothRunner, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class Lupos: BaseCreature 
	 { 
		public  Lupos() : base() 
		 { 
			Id = 521 ; 
			Model = 9562;
			AttackSpeed= 1200;
			Name = "Lupos" ;
			Flags1 = 0x010 ;
			ResistArcane = 80;
			ResistFire = 80;
			ResistFrost = 80;
			ResistHoly = 80;
			ResistNature = 80;
			ResistShadow = 80;
			Level = RandomLevel( 23 );
			Str = (int)(Level*1.5f);
			Armor=967;
			NpcType = (int)NpcTypes.Beast ;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.1500000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Elite=4; Block=Level+50;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new BerserkerAI( this );
			BCAddon.Hp( this, 617, 23 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 61.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Lupos, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class MangySilvermane: BaseCreature 
	 { 
		public  MangySilvermane() : base() 
		 { 
			Id = 2923 ; 
			Model = 11413;
			AttackSpeed= 2000;
			Name = "Mangy Silvermane" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 41,42 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.00000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1512, 41 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( HeavyLeather), 60.0f )
					          ,new Loot( typeof( HeavyHide), 40.2f)
					          ,new Loot( typeof( ThickHide), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.MangySilvermane, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class MangyWolf: BaseCreature 
	 { 
		public  MangyWolf() : base() 
		 { 
			Id = 525 ; 
			Model = 903;
			AttackSpeed= 1700;
			Name = "Mangy Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 5,6 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.00000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.725424f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 114, 5 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.MangyWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class MistHowler: BaseCreature 
	 { 
		public  MistHowler() : base() 
		 { 
			Id = 10644; 
			Model = 165;
			AttackSpeed= 1300;
			Name = "Mist Howler" ;
			Flags1 = 0x010 ;
			ResistArcane = 80;
			ResistFire = 80;
			ResistFrost = 80;
			ResistHoly = 80;
			ResistNature = 80;
			ResistShadow = 80;
			Level = RandomLevel( 22 );
			Str = (int)(Level*1.5f);
			Armor=Level*100;
			NpcType = (int)NpcTypes.Beast ;

			NpcFlags = 00 ;
			BoundingRadius = 1.100000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+5.88f*Level,1f+6.1*Level);			
			ManaType=1; BaseMana = 100;
			Family=1 ;
			Elite=4; Block=Level+50;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new SpellCasterAI( this );
			BCAddon.Hp( this, 7500, 22 );
LearnSpell( 6548, SpellsTypes.Offensive );
LearnSpell( 3604, SpellsTypes.Offensive );
LearnSpell( 8715, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.MistHowler, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class MottledWorg: BaseCreature 
	 { 
		public  MottledWorg() : base() 
		 { 
			Id = 1766 ; 
			Model = 246;
			AttackSpeed= 1700;
			Name = "Mottled Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 11,12 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.00000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 175, 11 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( LightHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.MottledWorg, 100f ) };					          
		}
	}	
}



namespace Server.Creatures
{
	public class OldCliffJumper: BaseCreature 
	 { 
		public  OldCliffJumper() : base() 
		 { 
			Id = 8211 ; 
			Model = 11414;
			AttackSpeed= 2000;
			Name = "Old Cliff Jumper" ;
			Flags1 = 0x010 ;
			ResistArcane = 90;
			ResistFire = 90;
			ResistFrost = 90;
			ResistHoly = 90;
			ResistNature = 90;
			ResistShadow = 90;
			Level = RandomLevel( 42 );
			Str = (int)(Level*1.5f);
			Armor=2262;
			NpcType = (int)NpcTypes.Beast ;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.000000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Elite=4; Block=Level+50;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new BerserkerAI( this );
			BCAddon.Hp( this, 1981, 42 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather), 80.0f )
					          ,new Loot( typeof( ThickLeather), 61.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )
					          ,new Loot( typeof( HeavyHide), 10.0f )
					          ,new Loot( typeof( ThickWolfhide), 10.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.OldCliffJumper, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class PrairieStalker: BaseCreature 
	 { 
		public  PrairieStalker() : base() 
		 { 
			Id = 2959 ; 
			Model = 246;
			AttackSpeed= 1500;
			Name = "Prairie Stalker" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 7,8 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.27000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new SpellCasterAI( this );
BCAddon.Hp( this, 116, 7 );	
LearnSpell( 1604, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 40.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 80.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.PrairieStalker, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class PrairieWolf: BaseCreature 
	 { 
		public  PrairieWolf() : base() 
		 { 
			Id = 2958 ; 
			Model = 1100;
			AttackSpeed= 1500;
			Name = "Prairie Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 5,6 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.08000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.72f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new SpellCasterAI( this );
BCAddon.Hp( this, 112, 5 );	
LearnSpell( 5781, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 40.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 80.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.PrairieWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class PrairieWolfAlpha: BaseCreature 
	 { 
		public  PrairieWolfAlpha() : base() 
		 { 
			Id = 2960 ; 
			Model = 161;
			AttackSpeed= 1400;
			Name = "Prairie Wolf Alpha" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 9,10 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.5000f ;			
			CombatReach = 0.825f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new SpellCasterAI( this );
			BCAddon.Hp( this, 163, 9 );
	LearnSpell( 1604, SpellsTypes.Offensive );
	LearnSpell( 5781, SpellsTypes.Offensive );			
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 80.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.PrairieWolfAlpha, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class Prowler: BaseCreature 
	 { 
		public  Prowler() : base() 
		 { 
			Id = 118 ; 
			Model = 11415;
			AttackSpeed= 1500;
			Name = "Prowler" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 9,10 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
			NpcFlags = 00 ;
			BoundingRadius = 0.85000f ;			
			CombatReach = 0.525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 180, 9 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 40.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 80.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Prowler, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class RabidCragCoyote: BaseCreature 
	 { 
		public  RabidCragCoyote() : base() 
		 { 
			Id = 2370 ; 
			Model = 161;
			AttackSpeed= 1500;
			Name = "Rabid Crag Coyote" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 3;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 42,43);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.05000f ;			
			CombatReach = 0.525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1700, 42 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.RabidCragCoyote, 100f ) };					          
		}
	}	
}

namespace Server.Creatures
{
	public class RabidDireWolf: BaseCreature 
	 { 
		public  RabidDireWolf() : base() 
		 { 
			Id = 565 ; 
			Model = 802;
			AttackSpeed= 2000;
			Name = "Rabid Dire Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 20,21);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.5000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 4f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 504, 20 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( MediumLeather), 40.2f)
					          ,new Loot( typeof( MediumHide), 5.2f)
					          ,new Loot( typeof( LightHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.RabidDireWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class RabidLongtooth: BaseCreature 
	 { 
		public  RabidLongtooth() : base() 
		 { 
			Id = 5288 ; 
			Model = 3203;
			AttackSpeed= 2000;
			Name = "Rabid Longtooth" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 47,48);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.95000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.3f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2580, 47 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( RuggedLeather), 40.2f)
					          ,new Loot( typeof( ThickWolfhide), 50.2f)
					          ,new Loot( typeof( ThickHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.RabidLongtooth, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class RaggedScavenger: BaseCreature 
	 { 
		public  RaggedScavenger() : base() 
		 { 
			Id = 1509 ; 
			Model = 604;
			AttackSpeed= 2000;
			Name = "Ragged Scavenger" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 2,3);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.05000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Beast;
			Size = 0.7f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 53, 2 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.RaggedScavenger, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class RaggedTimberWolf: BaseCreature 
	 { 
		public  RaggedTimberWolf() : base() 
		 { 
			Id = 704 ; 
			Model = 11416;
			AttackSpeed= 2000;
			Name = "Ragged Timber Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 2);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.05000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Beast;
			Size = 0.705f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;			
			RunSpeed = 6.5f ;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 53, 2 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.RaggedTimberWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class RaggedYoungWolf: BaseCreature 
	 { 
		public  RaggedYoungWolf() : base() 
		 { 
			Id = 705 ; 
			Model = 855;
			AttackSpeed= 2000;
			Name = "Ragged Young Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 1);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.05000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Beast;
			Size = 1f;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;			
			RunSpeed = 6.6f ;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 53, 1 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.RaggedYoungWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class RazormaneWolf: BaseCreature 
	 { 
		public  RazormaneWolf() : base() 
		 { 
			Id = 3939 ; 
			Model = 643;
			AttackSpeed= 2000;
			Name = "Razormane Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 7,8);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.27000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 143, 7 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.RazormaneWolf, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class ScarshieldWorg: BaseCreature 
	 { 
		public  ScarshieldWorg() : base() 
		 { 
			Id = 9416 ; 
			Model = 741;
			AttackSpeed= 1400;
			Name = "Scarshield Worg" ;
			Guild="Scarshield Legion";
			Flags1 = 0x010 ;
			RunSpeed = 6.3f ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 53,54 );
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.300000f ;			
			CombatReach = 1.025f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Monster;
			Size = 1f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2151, 53 );
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedHide), 10.0f )
					          ,new Loot( typeof( ThickWolfhide), 20.0f )					          
					          ,new Loot( typeof( ThickHide), 40.0f )};					          						          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.ScarshieldWorg, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class SilvermaneHowler: BaseCreature 
	 { 
		public  SilvermaneHowler() : base() 
		 { 
			Id = 2925 ; 
			Model = 11417;
			AttackSpeed= 2000;
			Name = "Silvermane Howler" ;
			Flags1 = 0x010 ;
			RunSpeed = 6.2f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 45,46);
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.300000f ;			
			CombatReach = 1.025f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.3f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1997, 45 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )					          
					          ,new Loot( typeof( MediumHide), 40.0f )};					          						          
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.SilvermaneHowler, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class SilvermaneStalker: BaseCreature 
	 { 
		public  SilvermaneStalker() : base() 
		 { 
			Id = 2926 ; 
			Model = 11418;
			AttackSpeed= 2000;
			Name = "Silvermane Stalker" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 47,48);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.5000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.5f;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;			
			RunSpeed = 6.6f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2455, 47 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( RuggedLeather), 40.2f)
					          ,new Loot( typeof( ThickHide), 30.2f)
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.SilvermaneStalker, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class SilvermaneWolf: BaseCreature 
	 { 
		public  SilvermaneWolf() : base() 
		 { 
			Id = 2924 ; 
			Model = 11419;
			AttackSpeed= 2000;
			Name = "Silvermane Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 43,44);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.15000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1263, 43 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( HeavyHide), 40.2f)
					          ,new Loot( typeof( HeavyLeather), 30.2f)
					          ,new Loot( typeof( ThickWolfhide), 5.2f)
					          ,new Loot( typeof( ThickHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.SilvermaneWolf, 100f ) };					          
		}
	}	
}

namespace Server.Creatures
{
	public class SlaveringEmberWorg: BaseCreature 
	 { 
		public  SlaveringEmberWorg() : base() 
		 { 
			Id = 9694 ; 
			Model = 11420;
			AttackSpeed= 2000;
			Name = "Slavering Ember Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 53,54);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.15000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 1.15f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2714, 53 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( RuggedLeather), 40.2f)
					          ,new Loot( typeof( ThickWolfhide), 30.2f)
					          ,new Loot( typeof( ThickHide), 10.2f)
					          ,new Loot( typeof( RuggedHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.SlaveringEmberWorg, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class SlaveringWorg: BaseCreature 
	 { 
		public  SlaveringWorg() : base() 
		 { 
			Id = 3862 ; 
			Model = 11421;
			AttackSpeed= 1200;
			Name = "Slavering Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Level = RandomLevel( 18, 19 );
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);

			NpcFlags = 00 ;
			BoundingRadius = 0.8570000f ;			
			CombatReach = 1.0625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=1; BaseMana = 0;
			Elite=1; Block=Level+20;
			Family=1;
			Faction = Factions.Monster;
			Size = 0.85f;
			Speed = 3.55f ;
			WalkSpeed = 3.55f ;			
			RunSpeed = 6.5f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1476, 18 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.SlaveringWorg, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class Snarler: BaseCreature 
	 { 
		public  Snarler() : base() 
		 { 
			Id = 5356 ; 
			Model = 780;
			AttackSpeed= 1300;
			Name = "Snarler" ;
			Flags1 = 0x010 ;
			ResistArcane = 100;
			ResistFire = 100;
			ResistFrost = 100;
			ResistHoly = 100;
			ResistNature =100;
			ResistShadow = 100;
			Armor=2826;
			Level = RandomLevel( 42,47 );
			Str = (int)(Level*1.9f);
			Armor=2375;
			NpcType = (int)NpcTypes.Beast ;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.000000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Elite=4; Block=Level+50;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;			
			RunSpeed = 6.7f ;
			AIEngine = new BerserkerAI( this );
			BCAddon.Hp( this, 1250, 42 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 81.0f )
					          ,new Loot( typeof( HeavyLeather), 80.0f )
					          ,new Loot( typeof( ThickHide), 50.0f )
					          ,new Loot( typeof( HeavyHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Snarler, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class SnowTrackerWolf: BaseCreature 
	 { 
		public  SnowTrackerWolf() : base() 
		 { 
			Id = 1138 ; 
			Model = 604;
			AttackSpeed= 2000;
			Name = "Snow Tracker Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 6,7);
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.08000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.72f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;			
			RunSpeed = 6.5f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 104, 6 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 80.2f )
					          ,new Loot( typeof( LightLeather), 40.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.SnowTrackerWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class SpotWolf: BaseCreature 
	 { 
		public  SpotWolf() : base() 
		 { 
			Id = 4950 ; 
			Model = 1100;
			AttackSpeed= 2000;
			Name = "Spot" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.38000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.872881f;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;			
			RunSpeed = 6.8f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 986, 35 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather), 80.2f )};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.SpotWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class StarvingDireWolf: BaseCreature 
	 { 
		public  StarvingDireWolf() : base() 
		 { 
			Id = 213 ; 
			Model = 801;
			AttackSpeed= 2000;
			Name = "Starving Dire Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 19,20);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.38000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 4f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 439, 19 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.2f )
					          ,new Loot( typeof( LightLeather), 40.2f)
					          ,new Loot( typeof( MediumHide), 30.2f)
					          ,new Loot( typeof( LightHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.StarvingDireWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class StarvingWinterWolf: BaseCreature 
	 { 
		public  StarvingWinterWolf() : base() 
		 { 
			Id = 1133 ; 
			Model = 11416;
			AttackSpeed= 2000;
			Name = "Starving Winter Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 8,9);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

 
			NpcFlags = 00 ;
			BoundingRadius = 1.11000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.740678f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 251, 8 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 80.2f )
					          ,new Loot( typeof( LightLeather), 40.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.StarvingWinterWolf, 100f ) };					          
		}
	}	
}



namespace Server.Creatures
{
	public class Timber: BaseCreature 
	 { 
		public  Timber() : base() 
		 { 
			Id = 1132 ; 
			Model = 11422;
			AttackSpeed= 2000;
			Name = "Timber" ;
			Flags1 = 0x010 ;
			ResistArcane = 40;
			ResistFire = 40;
			ResistFrost = 60;
			ResistHoly =40;
			ResistNature = 40;
			ResistShadow = 40;
			Level = RandomLevel( 10);
			Str = (int)(Level*2.5f);
			Armor=518;
			NpcType = (int)NpcTypes.Beast ;

			NpcFlags = 00 ;
			BoundingRadius = 0.72000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Elite=4; Block=Level+50;
			Faction = Factions.EvilBeast;
			Size = 0.745763f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			BCAddon.Hp( this, 210, 10 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 80.2f )
					          ,new Loot( typeof( LightLeather), 75.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Timber, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class TimberWolf: BaseCreature 
	 { 
		public  TimberWolf() : base() 
		 { 
			Id = 69 ; 
			Model = 604;
			AttackSpeed= 2000;
			Name = "Timber Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 2);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Beast;
			Size = 0.705f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 70, 2 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.TimberWolf, 100f ) };					          
		}
	}	
}

namespace Server.Creatures
{
	public class VilebranchRaidingWolf: BaseCreature 
	 { 
		public  VilebranchRaidingWolf() : base() 
		 { 
			Id = 2681; 
			Model = 782;
			AttackSpeed= 1200;
			Name = "Vilebranch Raiding Wolf" ;
			Flags1 = 06 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Level = RandomLevel( 50,51 );
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
 
			NpcFlags = 00 ;
			BoundingRadius = 1.0f ;	
			CombatReach = 1.0625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=1; BaseMana = 0;
			Elite=1; Block=Level+20;
			Family=1;
			Faction = Factions.EvilBeast;
			Size = 1f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 5250, 50 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedLeather), 60.0f )
						,new Loot( typeof( ThickWolfhide), 20.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.VilebranchRaidingWolf, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class VilebranchWolfPup: BaseCreature 
	 { 
		public  VilebranchWolfPup() : base() 
		 { 
			Id = 2680 ; 
			Model = 781;
			AttackSpeed= 2000;
			Name = "Vilebranch Wolf Pup" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 1;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 46,47);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.4000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.933f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;			
			RunSpeed = 6.2f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2488, 46 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.2f )
					          ,new Loot( typeof( RuggedLeather), 40.2f)
					          ,new Loot( typeof( ThickHide), 30.2f)
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.VilebranchWolfPup, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class WinterWolf: BaseCreature 
	 { 
		public  WinterWolf() : base() 
		 { 
			Id = 1131 ; 
			Model = 785;
			AttackSpeed= 2000;
			Name = "Winter Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 7,8);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

float step=1.045f;
if (Level==7)		
{
 BaseHitPoints = 125;
} 
else
{
for (int i=1; i<=(Level-7); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(125*(float)step);
} 
			NpcFlags = 00 ;
			BoundingRadius = 1.4000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.73f;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;			
			RunSpeed = 6.6f ;
			AIEngine = new SpellCasterAI( this );
BCAddon.Hp( this, 125, 7 );	
LearnSpell( 1604, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 80.2f )
					          ,new Loot( typeof( LightLeather), 40.2f)	};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.WinterWolf, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class WolfguardWorg: BaseCreature 
	 { 
		public  WolfguardWorg() : base() 
		 { 
			Id = 5058 ; 
			Model = 246;
			AttackSpeed= 2000;
			Name = "Wolfguard Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 7,8);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.0000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Monster;
			Size = 1f;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;			
			RunSpeed = 6.6f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 125 ,7 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 90.2f )
					          ,new Loot( typeof( MediumHide), 80.2f)
					          ,new Loot( typeof( MediumLeather), 75.2f)
					          ,new Loot( typeof( LightHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.WolfguardWorg, 100f ) };					          
		}
	}	
}



namespace Server.Creatures
{
	public class Worg: BaseCreature 
	 { 
		public  Worg() : base() 
		 { 
			Id = 1765 ; 
			Model = 11421;
			AttackSpeed= 2000;
			Name = "Worg" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 10,11);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 0.85000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.85f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 197, 10 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 80.2f )
					          ,new Loot( typeof( LightLeather), 40.2f)	};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.Worg, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class YoungBlackRavager: BaseCreature 
	 { 
		public  YoungBlackRavager() : base() 
		 { 
			Id = 923 ; 
			Model = 246;
			AttackSpeed= 2000;
			Name = "Young Black Ravager" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 23,24);
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 0.85000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.75f;
			Speed = 3.09f ;
			WalkSpeed = 3.09f ;			
			RunSpeed = 6.09f ;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 611, 23 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.2f )
					          ,new Loot( typeof( LightLeather), 60.2f)
					          ,new Loot( typeof( MediumHide), 40.2f)
					          ,new Loot( typeof( LightHide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.YoungBlackRavager, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class YoungScavenger: BaseCreature 
	 { 
		public  YoungScavenger() : base() 
		 { 
			Id = 1508 ; 
			Model = 447;
			AttackSpeed= 2000;
			Name = "Young Scavenger" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 1);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.05000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.EvilBeast;
			Size = 0.75f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 67, 1 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.YoungScavenger, 100f ) };					          
		}
	}	
}


namespace Server.Creatures
{
	public class YoungWolf: BaseCreature 
	 { 
		public  YoungWolf() : base() 
		 { 
			Id = 299 ; 
			Model = 447;
			AttackSpeed= 2000;
			Name = "Young Wolf" ;
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 1);
			Str = (int)(Level/1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*20;

			NpcFlags = 00 ;
			BoundingRadius = 1.05000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=1 ;
			Faction = Factions.Beast;
			Size = 0.70f;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;			
			RunSpeed = 6.9f ;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 67, 1 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.2f )
					          ,new Loot( typeof( RuinedLeatherScraps), 40.2f)					          
					          ,new Loot( typeof( ThickWolfhide), 10.2f)};
			Loots = new BaseTreasure[]{ new BaseTreasure( WolfDrops.YoungWolf, 100f ) };					          
		}
	}	
}
