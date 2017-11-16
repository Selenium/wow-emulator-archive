using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class AngerclawBear: BaseCreature 
	 { 
		public  AngerclawBear() : base() 
		 { 
			Id = 8956 ;
			Model = 9276;
			AttackSpeed= 2000;
			BoundingRadius = 1.045500000f ;
			Name = "Angerclaw Bear" ;
			Level = RandomLevel( 47,48 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;
			RunSpeed = 7.2f ;			
			Size=1.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickHide), 20.0f )
					          ,new Loot( typeof( RuggedHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.AngerclawBear, 100f ) };
			BCAddon.Hp( this, 2809, 47 );
		}
	}	
}



namespace Server.Creatures
{
	public class AngerclawGrizzly: BaseCreature 
	 { 
		public  AngerclawGrizzly() : base() 
		 { 
			Id = 8957;
			Model = 9277;
			AttackSpeed= 2000;
			BoundingRadius = 1.045500000f ;
			Name = "Angerclaw Grizzly" ;
			Level = RandomLevel( 51,52 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 4;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.3f ;
			WalkSpeed = 4.3f ;
			RunSpeed = 7.3f ;			
			Size=1.75f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( ThickHide), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( RuggedHide), 20.0f )
					          ,new Loot( typeof( ThickLeather), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.AngerclawGrizzly, 100f ) };
			BCAddon.Hp( this, 3404, 51 );
		}
	}	
}



namespace Server.Creatures
{
	public class AngerclawMauler: BaseCreature 
	 { 
		public  AngerclawMauler() : base() 
		 { 
			Id = 8958;
			Model = 1083;
			AttackSpeed= 2000;
			BoundingRadius = 1.045500000f ;
			Name = "Angerclaw Mauler" ;
			Level = RandomLevel( 49,50 );
			Flags1 = 0x010 ;			 
			Size = 1.0455f;
			ResistArcane = 0;
			ResistFire = 4;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.3f ;
			WalkSpeed = 4.3f ;
			RunSpeed = 7.3f ;			
			Size=1.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( ThickHide), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( RuggedHide), 20.0f )
					          ,new Loot( typeof( ThickLeather), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.AngerclawMauler, 100f ) };
			BCAddon.Hp( this, 2668, 49 );
		}
	}	
}



namespace Server.Creatures
{
	public class AshenvaleBear: BaseCreature 
	 { 
		public  AshenvaleBear() : base() 
		 { 
			Id = 3809;
			Model = 820;
			AttackSpeed= 2000;
			Name = "Ashenvale Bear" ;
			Level = RandomLevel( 21,22 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 4;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
			NpcFlags = 0;
			BoundingRadius = 0.745500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.03f ;
			WalkSpeed = 4.03f ;
			RunSpeed = 7.03f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.AshenvaleBear, 100f ) };
			BCAddon.Hp( this, 1022, 21 );
		}
	}	
}


namespace Server.Creatures
{
	public class BigSamras: BaseCreature 
	 { 
		public  BigSamras() : base() 
		 { 
			Id = 14280;
			Model = 706;
			AttackSpeed= 2000;
			Name = "Big Samras" ;
			Level = RandomLevel( 27 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0*2;
			ResistHoly = Level*2;
			ResistNature = 0*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 418;
			Block=Level+20;
			NpcFlags = 0;
			BoundingRadius = 0.745500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.3f ;
			WalkSpeed = 4.3f ;
			RunSpeed = 7.3f ;			
			Size=1.3f;
			Elite=4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.BigSamras, 100f ) };
			BCAddon.Hp( this, 1080, 27 );
		}
	}	
}



namespace Server.Creatures
{
	public class Bjarn: BaseCreature 
	 { 
		public  Bjarn() : base() 
		 { 
			Id = 1130;
			Model = 706;
			AttackSpeed= 2000;
			Name = "Bjarn" ;
			Level = RandomLevel( 12 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0*2;
			ResistHoly = Level*2;
			ResistNature = 0*2;
			ResistShadow = Level*2;
			Str = (int)(33);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 609;
			Block=Level+20;
			NpcFlags = 0;
			BoundingRadius = 0.745500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.3f ;
			WalkSpeed = 4.3f ;
			RunSpeed = 7.3f ;			
			Size=1.0f;
			Elite=4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 60.0f )
					          ,new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.Bjarn, 100f ) };
			BCAddon.Hp( this, 262, 12 );
/*Lvl 12, Rebellious. 
Life-262 
Strength-33 
Agility-28 
Stamina-38 
Intellect-23 
Spirit-25 
Attack-60 
Power-46 
Damage-14-19 
Attack Speed-2.00 
Damage Per Second-8.4 
Defense-60 
Armor-609 */
		}
	}	
}


namespace Server.Creatures
{
	public class BlackBear: BaseCreature 
	 { 
		public  BlackBear() : base() 
		 { 
			Id = 1129 ;
			Model = 719;
			AttackSpeed= 2000;
			BoundingRadius = 0.545500000f ;
			Name = "Black Bear" ;
			Level = RandomLevel( 6,7 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=0.85f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 60.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.BlackBear, 100f ) };
			BCAddon.Hp( this, 123, 5 );
		}
	}	
}


namespace Server.Creatures
{
	public class DenMother: BaseCreature 
	 { 
		public  DenMother() : base() 
		 { 
			Id = 6788 ;
			Model = 1007;
			AttackSpeed= 2000;
			BoundingRadius = 0.700000f ;
			Name = "Den Mother" ;
			Level = RandomLevel( 18,19 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 867;
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.DenMother, 100f ) };
			BCAddon.Hp( this, 489, 18 );
		}
	}	
}



namespace Server.Creatures
{
	public class DiseasedBlackBear: BaseCreature 
	 { 
		public  DiseasedBlackBear() : base() 
		 { 
			Id = 1815 ;
			Model = 1082;
			AttackSpeed= 2000;
			BoundingRadius = 0.95500000f ;
			Name = "Diseased Black Bear" ;
			Level = RandomLevel( 51,52 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickHide), 20.0f )
					          ,new Loot( typeof( RuggedHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.DiseasedBlackBear, 100f ) };
			BCAddon.Hp( this, 2538, 51 );
		}
	}	
}



namespace Server.Creatures
{
	public class DiseasedGrizzly: BaseCreature 
	 { 
		public  DiseasedGrizzly() : base() 
		 { 
			Id = 1816 ;
			Model = 1083;
			AttackSpeed= 2000;
			BoundingRadius = 0.95500000f ;
			Name = "Diseased Grizzly" ;
			Level = RandomLevel( 55,56 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( RuggedHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.DiseasedGrizzly, 100f ) };
			BCAddon.Hp( this, 4014, 55 );
		}
	}	
}



namespace Server.Creatures
{
	public class ElderAshenvaleBear: BaseCreature 
	 { 
		public  ElderAshenvaleBear() : base() 
		 { 
			Id = 3810 ;
			Model = 982;
			AttackSpeed= 2000;
			Name = "Elder Ashenvale Bear" ;
			Level = RandomLevel( 25,26 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.6100000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ElderAshenvaleBear, 100f ) };
			BCAddon.Hp( this, 983, 25 );
		}
	}	
}



namespace Server.Creatures
{
	public class ElderBlackBear: BaseCreature 
	 { 
		public  ElderBlackBear() : base() 
		 { 
			Id = 1186 ;
			Model = 707;
			AttackSpeed= 2000;
			Name = "Elder Black Bear" ;
			Level = RandomLevel( 11,12 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.6100000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 2.8f ;
			WalkSpeed = 2.8f ;
			RunSpeed = 5.8f ;			
			Size=0.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 60.0f )
					          ,new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ElderBlackBear, 100f ) };
			BCAddon.Hp( this, 269, 11 );
		}
	}	
}



namespace Server.Creatures
{
	public class ElderShardtooth: BaseCreature 
	 { 
		public  ElderShardtooth() : base() 
		 { 
			Id = 7445 ;
			Model = 8837;
			AttackSpeed= 2000;
			Name = "Elder Shardtooth" ;
			Level = RandomLevel( 57,58 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.75f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( RuggedHide), 60.0f )
					          ,new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickLeather), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ElderShardtooth, 100f ) };
			BCAddon.Hp( this, 3911, 57 );
		}
	}	
}


namespace Server.Creatures
{
	public class FerociousGrizzledBear: BaseCreature 
	 { 
		public  FerociousGrizzledBear() : base() 
		 { 
			Id = 1778 ;
			Model = 902;
			AttackSpeed= 2000;
			Name = "Ferocious Grizzled Bear" ;
			Level = RandomLevel( 11,12 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=0.85f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 60.0f )
					          ,new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.FerociousGrizzledBear, 100f ) };
			BCAddon.Hp( this, 259, 11 );
		}
	}	
}



namespace Server.Creatures
{
	public class GiantAshenvaleBear: BaseCreature 
	 { 
		public  GiantAshenvaleBear() : base() 
		 { 
			Id = 3811 ;
			Model = 14315;
			AttackSpeed= 2000;
			Name = "Giant Ashenvale Bear" ;
			Level = RandomLevel( 29,30 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.80000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.45f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.GiantAshenvaleBear, 100f ) };
			BCAddon.Hp( this, 1600, 29 );
		}
	}	
}



namespace Server.Creatures
{
	public class GiantGrizzledBear: BaseCreature 
	 { 
		public  GiantGrizzledBear() : base() 
		 { 
			Id = 1797 ;
			Model = 820;
			AttackSpeed= 2000;
			Name = "Giant Grizzled Bear" ;
			Level = RandomLevel( 12,13 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.70000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps), 60.0f )
					          ,new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.GiantGrizzledBear, 100f ) };
			BCAddon.Hp( this, 297, 12 );
		}
	}	
}


namespace Server.Creatures
{
	public class GrayBear: BaseCreature 
	 { 
		public  GrayBear() : base() 
		 { 
			Id = 2351 ;
			Model = 806;
			AttackSpeed= 2000;
			Name = "Gray Bear" ;
			Level = RandomLevel( 21,22 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.70000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.496583f ) 
,new Loot( typeof( LightLeather), 6.75614f ) 
,new Loot( typeof( MediumHide), 0.858565f ) 
,new Loot( typeof( MediumLeather), 8.27202f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.GrayBear, 100f ) };
			BCAddon.Hp( this, 553, 21 );
		}
	}	
}



namespace Server.Creatures
{
	public class GrizzledBlackBear: BaseCreature 
	 { 
		public  GrizzledBlackBear() : base() 
		 { 
			Id = 1188 ;
			Model = 762;
			AttackSpeed= 2000;
			Name = "Grizzled Black Bear" ;
			Level = RandomLevel( 13,14 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.70000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.959281f ) 
,new Loot( typeof( LightLeather), 11.1966f )
,new Loot( typeof( RuinedLeatherScraps), 6.94729f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.GrizzledBlackBear, 100f ) };
			BCAddon.Hp( this, 298, 13 );
		}
	}	
}



namespace Server.Creatures
{
	public class GrizzledIronfurBear: BaseCreature 
	 { 
		public  GrizzledIronfurBear() : base() 
		 { 
			Id = 5272 ;
			Model = 8838;
			AttackSpeed= 2000;
			Name = "Grizzled Ironfur Bear" ;
			Level = RandomLevel( 44,45 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.90000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.732185f ) 
,new Loot( typeof( HeavyLeather), 10.4465f ) 
,new Loot( typeof( ThickHide), 1.00031f ) 
,new Loot( typeof( ThickLeather), 12.0862f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.GrizzledIronfurBear, 100f ) };
			BCAddon.Hp( this, 1566, 44 );
		}
	}	
}



namespace Server.Creatures
{
	public class GrizzledThistleBear: BaseCreature 
	 { 
		public  GrizzledThistleBear() : base() 
		 { 
			Id = 2165 ;
			Model = 14316;
			AttackSpeed= 2000;
			Name = "Grizzled Thistle Bear" ;
			Level = RandomLevel( 16,17 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.90000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=4;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
LearnSpell( 3242, SpellsTypes.Offensive );
LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 1.07357f ) 
,new Loot( typeof( LightLeather), 14.8994f ) 
,new Loot( typeof( MediumHide), 0.398509f ) 
,new Loot( typeof( MediumLeather), 4.21355f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.GrizzledThistleBear, 100f ) };
			BCAddon.Hp( this, 195, 16 );
		}
	}	
}




namespace Server.Creatures
{
	public class IceClawBear: BaseCreature 
	 { 
		public  IceClawBear() : base() 
		 { 
			Id = 1196 ;
			Model = 8840;
			AttackSpeed= 2000;
			Name = "Ice Claw Bear" ;
			Level = RandomLevel( 7,8 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.50000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=4;
			Speed = 2.6f ;
			WalkSpeed = 2.6f ;
			RunSpeed = 5.6f ;			
			Size=0.85f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
LearnSpell( 3130, SpellsTypes.Offensive );
LearnSpell( 1604, SpellsTypes.Offensive );
			SkinLoot = new Loot[] {new Loot( typeof( LightLeather), 5.36218f ) 
,new Loot( typeof( RuinedLeatherScraps), 8.49237f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.IceClawBear, 100f ) };
			BCAddon.Hp( this, 169, 7 );
		}
	}	
}



namespace Server.Creatures
{
	public class IronfurBear: BaseCreature 
	 { 
		public  IronfurBear() : base() 
		 { 
			Id = 5268 ;
			Model = 3201;
			AttackSpeed= 2000;
			Name = "Ironfur Bear" ;
			Level = RandomLevel( 41,42 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.50000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.902887f ) 
,new Loot( typeof( HeavyLeather), 13.2971f ) 
,new Loot( typeof( ThickHide), 1.27788f ) 
,new Loot( typeof( ThickLeather), 15.4859f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.IronfurBear, 100f ) };
			BCAddon.Hp( this, 1742, 41 );
		}
	}	
}



namespace Server.Creatures
{
	public class IronfurPatriarch: BaseCreature 
	 { 
		public  IronfurPatriarch() : base() 
		 { 
			Id = 5274 ;
			Model = 3200;
			AttackSpeed= 2000;
			Name = "Ironfur Patriarch" ;
			Level = RandomLevel( 48,49 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.75f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuggedLeather), 4.88495f ) 
,new Loot( typeof( ThickHide), 0.731279f ) 
,new Loot( typeof( ThickLeather), 19.413f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.IronfurPatriarch, 100f ) };
			BCAddon.Hp( this, 2233, 48 );
		}
	}	
}



namespace Server.Creatures
{
	public class Mangeclaw: BaseCreature 
	 { 
		public  Mangeclaw() : base() 
		 { 
			Id = 1961 ;
			Model = 913;
			AttackSpeed= 1900;
			Name = "Mangeclaw" ;
			Level = RandomLevel( 11 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=4;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.0f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
LearnSpell( 3242, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.884956f ) 
,new Loot( typeof( LightLeather), 6.84139f )
,new Loot( typeof( RuinedLeatherScraps), 1.70184f )  
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.Mangeclaw, 100f ) };
			BCAddon.Hp( this, 214, 11 );
		}
	}	
}



namespace Server.Creatures
{
	public class Mongress: BaseCreature 
	 { 
		public  Mongress() : base() 
		 { 
			Id = 14344;
			Model = 14315;
			AttackSpeed= 2000;
			Name = "Mongress" ;
			Level = RandomLevel( 50 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0*2;
			ResistHoly = Level*2;
			ResistNature = 0*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 918;
			Block=Level+20;
 
			NpcFlags = 0;
			BoundingRadius = 0.885500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.3f ;
			WalkSpeed = 4.3f ;
			RunSpeed = 7.3f ;			
			Size=1.45f;
			Elite=4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 60.0f )
					          ,new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.Mongress, 100f ) };
			BCAddon.Hp( this, 2980, 50 );
		}
	}	
}



namespace Server.Creatures
{
	public class OlSooty: BaseCreature 
	 { 
		public  OlSooty() : base() 
		 { 
			Id = 1225;
			Model = 706;
			AttackSpeed= 2000;
			Name = "Ol' Sooty" ;
			ResistShadow = Level*2;
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0*2;
			ResistHoly = Level*2;
			ResistNature = 0*2;
			Level = RandomLevel( 20 );
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 818;
			Block=Level+30;
 
			NpcFlags = 0;
			BoundingRadius = 0.75500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed = 6.5f ;			
			Size=1.3f;
			Elite=1;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.747791f ) 
,new Loot( typeof( LightLeather), 5.50646f ) 
,new Loot( typeof( MediumHide), 0.509857f ) 
,new Loot( typeof( MediumLeather), 2.07342f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.OlSooty, 100f ) };
			BCAddon.Hp( this, 1509, 20 );
		}
	}	
}


namespace Server.Creatures
{
	public class OldGrizzlegut: BaseCreature 
	 { 
		public  OldGrizzlegut() : base() 
		 { 
			Id = 5352 ;
			Model = 3200;
			AttackSpeed= 2000;
			Name = "Old Grizzlegut" ;
			Level = RandomLevel( 43 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 2414;
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
LearnSpell( 3242, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 6.32911f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.OldGrizzlegut, 100f ) };
			BCAddon.Hp( this, 2574, 43 );
		}
	}	
}



namespace Server.Creatures
{
	public class OldVicejaw: BaseCreature 
	 { 
		public  OldVicejaw() : base() 
		 { 
			Id = 12432;
			Model = 982;
			AttackSpeed= 2000;
			Name = "Old Vicejaw" ;
			Level = RandomLevel( 14 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0*2;
			ResistHoly = Level*2;
			ResistNature = 0*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 650;
			Block=Level+20;
 
			NpcFlags = 0;
			BoundingRadius = 0.885500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.3f ;
			WalkSpeed = 4.3f ;
			RunSpeed = 7.3f ;			
			Size=1.15f;
			Elite=4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 2.18254f ) 
,new Loot( typeof( LightHide), 0.595238f ) 
,new Loot( typeof( LightLeather), 3.1746f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.OldVicejaw, 100f ) };
			BCAddon.Hp( this, 375, 14 );
		}
	}	
}



namespace Server.Creatures
{
	public class RabidShardtooth: BaseCreature 
	 { 
		public  RabidShardtooth() : base() 
		 { 
			Id = 7446 ;
			Model = 3200;
			AttackSpeed= 2000;
			Name = "Rabid Shardtooth" ;
			Level = RandomLevel( 59,60 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 4.18843f ) 
,new Loot( typeof( RuggedHide), 2.0203f ) 
,new Loot( typeof( RuggedLeather), 26.9735f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.RabidShardtooth, 100f ) };
			BCAddon.Hp( this, 4814, 59 );
		}
	}	
}




namespace Server.Creatures
{
	public class ShardtoothBear: BaseCreature 
	 { 
		public  ShardtoothBear() : base() 
		 { 
			Id = 7444 ;
			Model = 865;
			AttackSpeed= 2000;
			Name = "Shardtooth Bear" ;
			Level = RandomLevel( 53,54 );			
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.700000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 3242, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.576727f ) 
,new Loot( typeof( ThickLeather), 7.89166f ) 
,new Loot( typeof( RuggedHide), 0.897941f ) 
,new Loot( typeof( RuggedLeather), 9.93576f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ShardtoothBear, 100f ) };
			BCAddon.Hp( this, 3619, 53 );
		}
	}	
}


namespace Server.Creatures
{
	public class ShardtoothMauler: BaseCreature 
	 { 
		public  ShardtoothMauler() : base() 
		 { 
			Id = 7443 ;
			Model = 8842;
			AttackSpeed= 2000;
			Name = "Shardtooth Mauler" ;
			Level = RandomLevel( 55,56 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.700000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 3242, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.81521f ) 
,new Loot( typeof( ThickLeather), 10.0279f ) 
,new Loot( typeof( RuggedHide), 0.987278f ) 
,new Loot( typeof( RuggedLeather), 11.853f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ShardtoothMauler, 100f ) };
			BCAddon.Hp( this, 3401, 55 );
		}
	}	
}



namespace Server.Creatures
{
	public class ThistleBear: BaseCreature 
	 { 
		public  ThistleBear() : base() 
		 { 
			Id = 2164 ;
			Model = 8840;
			AttackSpeed= 2000;
			Name = "Thistle Bear" ;
			Level = RandomLevel( 11,12 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.700000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 100;
			Family=4;
			Speed = 3.03f ;
			WalkSpeed = 3.03f ;
			RunSpeed = 6.03f ;			
			Size=0.85f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
LearnSpell( 3242, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 7.43654f ) 
,new Loot( typeof( LightHide), 1.06567f ) 
,new Loot( typeof( LightLeather), 12.4413f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ThistleBear, 100f ) };
			BCAddon.Hp( this, 214, 11 );
		}
	}	
}




namespace Server.Creatures
{
	public class ThistleCub: BaseCreature 
	 { 
		public  ThistleCub() : base() 
		 { 
			Id = 6789 ;
			Model = 5510;
			AttackSpeed= 2000;
			Name = "Thistle Cub" ;
			Level = RandomLevel( 9,10 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.03f ;
			WalkSpeed = 3.03f ;
			RunSpeed = 6.03f ;			
			Size=0.65f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 3242, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 16.6442f ) 
,new Loot( typeof( LightLeather), 9.96857f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ThistleCub, 100f ) };
			BCAddon.Hp( this, 112, 9 );
		}
	}	
}



namespace Server.Creatures
{
	public class Ursius: BaseCreature 
	 { 
		public  Ursius() : base() 
		 { 
			Id = 10806 ;
			Model = 10618;
			AttackSpeed= 2000;
			Name = "Ursius" ;
			ResistNature = Level;
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistShadow = 0;
			Level = RandomLevel( 56 );
			Str = (int)(Level*4.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*4;
			Block=Level+40;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Elite=1;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;
			RunSpeed = 7.2f ;			
			Size=0.65f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 3242, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuggedHide), 0.333056f ) 
,new Loot( typeof( RuggedLeather), 20.3164f ) 
,new Loot( typeof( ThickLeather), 2.41465f )};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.Ursius, 100f ) };
			BCAddon.Hp( this, 2850, 56 );
		}
	}	
}



namespace Server.Creatures
{
	public class Ursollok: BaseCreature 
	 { 
		public  Ursollok() : base() 
		 { 
			Id = 12037;
			Model = 706;
			AttackSpeed= 1600;
			Name = "Ursol'lok" ;
			Level = RandomLevel(31 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0*2;
			ResistHoly = Level*2;
			ResistNature = 0*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 1247;
			Block=Level+20;

			NpcFlags = 0;
			BoundingRadius = 0.745500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.3f;
			Elite=4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.990099f ) 
,new Loot( typeof( HeavyLeather), 7.92079f ) 
,new Loot( typeof( MediumLeather), 0.990099f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.Ursollok, 100f ) };
			BCAddon.Hp( this, 1258, 31 );
		}
	}	
}



namespace Server.Creatures
{
	public class ViciousGrayBear: BaseCreature 
	 { 
		public  ViciousGrayBear() : base() 
		 { 
			Id = 2354 ;
			Model = 1007;
			AttackSpeed= 2000;
			Name = "Vicious Gray Bear" ;
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 22,23 );
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 3.03f ;
			WalkSpeed = 3.03f ;
			RunSpeed = 6.03f ;			
			Size=1.15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.591999f ) 
,new Loot( typeof( LightLeather), 8.85537f ) 
,new Loot( typeof( MediumHide), 1.11742f ) 
,new Loot( typeof( MediumLeather), 10.132f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.ViciousGrayBear, 100f ) };
			BCAddon.Hp( this, 557, 22 );
		}
	}	
}



namespace Server.Creatures
{
	public class YoungBlackBear: BaseCreature 
	 { 
		public  YoungBlackBear() : base() 
		 { 
			Id = 1128 ;
			Model = 8843;
			AttackSpeed= 2000;
			Name = "Young Black Bear" ;
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 2,6 );
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 2.56f ;
			WalkSpeed = 2.56f ;
			RunSpeed = 5.56f ;			
			Size=0.63f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightLeather), 5.82308f ) 
,new Loot( typeof( RuinedLeatherScraps), 8.9834f )
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.YoungBlackBear, 100f ) };
			BCAddon.Hp( this, 124, 2 );
		}
	}	
}


namespace Server.Creatures
{
	public class YoungForestBear: BaseCreature 
	 { 
		public  YoungForestBear() : base() 
		 { 
			Id = 822 ;
			Model = 1006;
			AttackSpeed= 2500;
			Name = "Young Forest Bear" ;
			Level = RandomLevel( 8,9 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 2.96f ;
			WalkSpeed = 2.96f ;
			RunSpeed = 5.96f ;			
			Size=0.85f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 6.79253f ) 
,new Loot( typeof( LightLeather), 4.56264f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BearDrops.YoungForestBear, 100f ) };
			BCAddon.Hp( this, 198, 8 );
		}
	}	
}
