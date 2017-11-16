// DrNexus notes : MangyDuskbat is duplicate, I remove it
//	Script made by Reguj - 20/05/05 16:16:15
// These are the bats up to lvl. 10
// Reguj

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class BlindHunter: BaseCreature 
	 { 
		public  BlindHunter() : base() 
		 { 
			Id = 4425 ;
			Model = 4735;
			AttackSpeed= 2000;
			Name = "Blind Hunter" ;
			Level = RandomLevel( 32 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level+20;
			ResistShadow = Level+20;
			Str = (int)(Level*4.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
			Block=Level+40;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.500000f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Elite = 2;
			Speed = 3.96f ;
			WalkSpeed = 3.96f ;
			RunSpeed = 6.96f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( HeavyLeather), 1.25786f ) 
,new Loot( typeof( MediumHide), 0.628931f ) 
,new Loot( typeof( MediumLeather), 5.03145f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.BlindHunter, 100f ) };
			BCAddon.Hp( this, 2821, 32 );
		}
	}	
}



namespace Server.Creatures
{
	public class BloodSeeker: BaseCreature 
	 { 
		public  BloodSeeker() : base() 
		 { 
			Id = 3868 ;
			Model = 1955;
			AttackSpeed= 2000;
			Name = "Blood Seeker" ;
			Level = RandomLevel( 23,24 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level+10;
			ResistShadow = Level+10;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*3;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.100000f ;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=0.517f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.743955f ) 
,new Loot( typeof( LightLeather), 3.47179f ) 
,new Loot( typeof( MediumHide), 0.929944f ) 
,new Loot( typeof( MediumLeather), 4.46373f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.BloodSeeker, 100f ) };
			BCAddon.Hp( this, 1853, 23 );
		}
	}	
}


namespace Server.Creatures
{
	public class DarkScreecher: BaseCreature 
	 { 
		public  DarkScreecher() : base() 
		 { 
			Id = 8927 ;
			Model = 3956;
			AttackSpeed= 1300;
			Name = "Dark Screecher" ;
			Level = RandomLevel( 50,52 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*1.2);
			Block= Level;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuggedLeather), 6.01248f ) 
,new Loot( typeof( ThickHide), 1.75837f ) 
,new Loot( typeof( ThickLeather), 15.8253f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.DarkScreecher, 100f ) };
			BCAddon.Hp( this, 1198, 50 ); 
		}
	}	
}




namespace Server.Creatures
{
	public class Duskbat: BaseCreature 
	 { 
		public  Duskbat() : base() 
		 { 
			Id = 1512 ;
			Model = 4732;
			AttackSpeed= 2000;
			Name = "Duskbat" ;
			Level = RandomLevel( 1,2 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*1.2);
			Block= Level;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.1400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 2.7f ;
			WalkSpeed = 2.7f ;
			RunSpeed = 5.7f ;			
			Size=0.4f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 6.79253f ) 
,new Loot( typeof( LightLeather), 4.56264f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.Duskbat, 100f ) };
			BCAddon.Hp( this, 43, 1 );
		}
	}	
}



namespace Server.Creatures
{
	public class GreaterDuskbat: BaseCreature 
	 { 
		public  GreaterDuskbat() : base() 
		 { 
			Id = 1553 ;
			Model = 4734;
			AttackSpeed= 2000;
			Name = "Greater Duskbat" ;
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
			Armor= (int)(Level*1.2);
			Block= Level;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.1400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 2.4f ;
			WalkSpeed = 2.4f ;
			RunSpeed = 5.4f ;			
			Size=0.425f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 7.96848f ) 
,new Loot( typeof( LightLeather), 5.13623f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.GreaterDuskbat, 100f ) };
			BCAddon.Hp( this, 132, 6 );
		}
	}	
}



namespace Server.Creatures
{
	public class GreaterKraulBat: BaseCreature 
	 { 
		public  GreaterKraulBat() : base() 
		 { 
			Id = 4539 ;
			Model = 1954;
			AttackSpeed= 2000;
			Name = "Greater Kraul Bat" ;
			Level = RandomLevel( 32 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level+10;
			ResistShadow = Level+10;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*3;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.2100000f ;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);			
			ManaType=0;
			Family=24;
			Elite = 1;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=0.6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			LearnSpell( 8281, SpellsTypes.Defensive );	
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.545094f ) 
,new Loot( typeof( HeavyLeather), 10.2329f ) 
,new Loot( typeof( LightHide), 0.024777f ) 
,new Loot( typeof( LightLeather), 0.024777f ) 
,new Loot( typeof( MediumHide), 1.2884f ) 
,new Loot( typeof( MediumLeather), 7.82953f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.GreaterKraulBat, 100f ) };
			BCAddon.Hp( this, 3219, 32 );
		}
	}	
}



namespace Server.Creatures
{
	public class KraulBat: BaseCreature 
	 { 
		public  KraulBat() : base() 
		 { 
			Id = 4538 ;
			Model = 1955;
			AttackSpeed= 2000;
			Name = "Kraul Bat" ;
			Level = RandomLevel( 30,31 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level+10;
			ResistShadow = Level+10;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*3;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.1900000f ;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Elite = 1;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=0.54f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.527279f ) 
,new Loot( typeof( MediumHide), 1.34749f ) 
,new Loot( typeof( MediumLeather), 12.9476f ) 
,new Loot( typeof( HeavyLeather), 4.64299f ) };	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.KraulBat, 100f ) };
			BCAddon.Hp( this, 2964, 30 );
		}
	}	
}



namespace Server.Creatures
{
	public class MangyDuskbat: BaseCreature 
	 { 
		public  MangyDuskbat() : base() 
		 { 
			Id = 1513 ;
			Model = 9535;
			AttackSpeed= 2000;
			Name = "Mangy Duskbat" ;
			Level = RandomLevel( 3,4 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*1.2);
			Block= Level;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.1400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 2.4f ;
			WalkSpeed = 2.4f ;
			RunSpeed = 5.4f ;			
			Size=0.4f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 6.79253f ) 
,new Loot( typeof( LightLeather), 4.56264f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.MangyDuskbat, 100f ) };
			BCAddon.Hp( this, 58, 3 );
		}
	}	
}



namespace Server.Creatures
{
	public class MonstrousPlaguebat: BaseCreature 
	 { 
		public  MonstrousPlaguebat() : base() 
		 { 
			Id = 8602 ;
			Model = 7897;
			AttackSpeed= 2000;
			Name = "Monstrous Plaguebat" ;
			Level = RandomLevel( 56,58 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*1.2);
			Block= Level;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.31400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed = 6.5f ;			
			Size=0.9f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuggedHide), 0.757301f ) 
,new Loot( typeof( RuggedLeather), 14.552f ) 
,new Loot( typeof( ThickLeather), 2.81154f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.MonstrousPlaguebat, 100f ) };
			BCAddon.Hp( this, 2805, 56 );
		}
	}	
}


namespace Server.Creatures
{
	public class NoxiousPlaguebat: BaseCreature 
	 { 
		public  NoxiousPlaguebat() : base() 
		 { 
			Id = 8601 ;
			Model = 7896;
			AttackSpeed= 2000;
			Name = "Noxious Plaguebat" ;
			Level = RandomLevel( 54,56 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*1.2);
			Block= Level;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.260000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=0.75f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuggedHide), 0.825858f ) 
,new Loot( typeof( RuggedLeather), 10.5444f ) 
,new Loot( typeof( ThickHide), 0.615527f ) 
,new Loot( typeof( ThickLeather), 8.82462f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.NoxiousPlaguebat, 100f ) };
			BCAddon.Hp( this, 2942, 54 );
		}
	}	
}



namespace Server.Creatures
{
	public class Plaguebat: BaseCreature 
	 { 
		public  Plaguebat() : base() 
		 { 
			Id = 8600 ;
			Model = 7894;
			AttackSpeed= 2000;
			Name = "Plaguebat" ;
			Level = RandomLevel( 53,55 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*1.2);
			Block= Level;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.230000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=0.667f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.471029f ) 
,new Loot( typeof( ThickLeather), 6.41009f ) 
,new Loot( typeof( RuggedHide), 0.645893f ) 
,new Loot( typeof( RuggedLeather), 7.464f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.Plaguebat, 100f ) };
			BCAddon.Hp( this, 1086, 53 );
		}
	}	
}



namespace Server.Creatures
{
	public class RessanTheNeedler: BaseCreature 
	 { 
		public  RessanTheNeedler() : base() 
		 { 
			Id = 10357;
			Model = 9750;
			AttackSpeed= 2000;
			Name = "Ressan the Needler" ;
			Flags1 = 0x010 ;			 
			Level = RandomLevel( 11 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0*2;
			ResistHoly = Level*2;
			ResistNature = 0*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 861;
			Block=Level+20;
			NpcFlags = 0;
			BoundingRadius = 0.15500000f ;
			CombatReach = 0.8f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=4;
			Speed = 4.3f ;
			WalkSpeed = 4.3f ;
			RunSpeed = 7.3f ;			
			Size=0.45f;
			Elite=4;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightLeather), 5.19031f ) 
,new Loot( typeof( RuinedLeatherScraps), 3.11419f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.RessanTheNeedler, 100f ) };
			BCAddon.Hp( this, 278, 11 );
		}
	}	
}



namespace Server.Creatures
{
	public class ShrikeBat: BaseCreature 
	 { 
		public  ShrikeBat() : base() 
		 { 
			Id = 4861 ;
			Model = 1954;
			AttackSpeed= 2000;
			Name = "Shrike Bat" ;
			Level = RandomLevel( 38,39 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level+10;
			ResistShadow = Level+10;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*3;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.100000f ;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=0.6f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 3.65119f ) 
,new Loot( typeof( HeavyHide), 0.812422f ) 
,new Loot( typeof( HeavyLeather), 10.4956f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.ShrikeBat, 100f ) };
			BCAddon.Hp( this, 2451, 38 );
		}
	}	
}



namespace Server.Creatures
{
	public class VampiricDuskbat: BaseCreature 
	 { 
		public  VampiricDuskbat() : base() 
		 { 
			Id = 1554 ;
			Model = 8808;
			AttackSpeed= 2000;
			Name = "Vampiric Duskbat" ;
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
			Armor= (int)(Level*1.2);
			Block= Level;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.230000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Speed = 2.5f ;
			WalkSpeed = 2.5f ;
			RunSpeed = 5.5f ;			
			Size=0.435593f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 6.56834f ) 
,new Loot( typeof( LightLeather), 4.22995f ) 
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.VampiricDuskbat, 100f ) };
			BCAddon.Hp( this, 165, 8 );
		}
	}	
}



namespace Server.Creatures
{
	public class VileBat: BaseCreature 
	 { 
		public  VileBat() : base() 
		 { 
			Id = 3866 ;
			Model = 8808;
			AttackSpeed= 2000;
			Name = "Vile Bat" ;
			Level = RandomLevel( 22,23 );
			Flags1 = 0x010 ;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level+10;
			ResistShadow = Level+10;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*3;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.180000f ;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=24;
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=0.5f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1604, SpellsTypes.Offensive );	
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.260417f ) 
,new Loot( typeof( LightLeather), 2.73438f ) 
,new Loot( typeof( MediumHide), 0.455729f ) 
,new Loot( typeof( MediumLeather), 3.51563f )
};	
			Loots = new BaseTreasure[]{ new BaseTreasure( BatDrops.VileBat, 100f ) };
			BCAddon.Hp( this, 1956, 22 );
		}
	}	
}

