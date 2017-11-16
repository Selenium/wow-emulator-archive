using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class AkumaiFisher: BaseCreature 
	 { 
		public  AkumaiFisher() : base() 
		 { 
			Id = 4824 ;
			Model = 1244;
			AttackSpeed= 2000;
			Name = "Aku'mai Fisher" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 23,24 );
			ResistArcane = 0;
			ResistFire = Level*3;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*39);
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.35500000f ;
			SetDamage(1f+3.7f*Level,1f+4.0*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Elite=1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.5f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1660, 23 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.AkumaiFisher, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class AkumaiSnapjaw: BaseCreature 
	 { 
		public  AkumaiSnapjaw() : base() 
		 { 
			Id = 4825 ;
			Model = 5026;
			AttackSpeed= 2000;
			Name = "Aku'mai Snapjaw" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 26,27 );
			ResistArcane = 0;
			ResistFire = Level*3;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*39);
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.35500000f ;
			SetDamage(1f+3.7f*Level,1f+4.0*Level);			
			ManaType=1; 
			BaseMana = 100;
			Family=21;
			Elite=1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			BCAddon.Hp( this, 2163, 26 );
LearnSpell( 3242, SpellsTypes.Offensive );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.AkumaiSnapjaw, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class CoralshellLurker: BaseCreature 
	 { 
		public  CoralshellLurker() : base() 
		 { 
			Id = 6352 ;
			Model = 10947;
			AttackSpeed= 2000;
			Name = "Coralshell Lurker" ;
			Level = RandomLevel( 53,54 );
			Flags1 = 0x010080010;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.52500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.5f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2163, 53 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.CoralshellLurker, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class CoralshellTortoise: BaseCreature 
	 { 
		public  CoralshellTortoise() : base() 
		 { 
			Id = 6369 ;
			Model = 2308;
			AttackSpeed= 1400;
			Name = "Coralshell Tortoise" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 50,52 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.5f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2887, 50 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.CoralshellTortoise, 100f ) };
		}
	}	
}


/*Cranky Benj 
id 14223
Elite=4;
*/



namespace Server.Creatures
{
	public class Ghamoora: BaseCreature 
	 { 
		public  Ghamoora() : base() 
		 { 
			Id = 4887 ;
			Model = 5027;
			AttackSpeed= 2000;
			Name = "Ghamoo-ra" ;
			Level = RandomLevel(25 );
			Flags1 = 0x010081010;			 
			ResistArcane = 0;
			ResistFire = Level*3;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*39);
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.5500000f ;
			SetDamage(1f+3.7f*Level,1f+4.0*Level);			
			ManaType=1; BaseMana = 100;
			Family=21;
			Elite=1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
BCAddon.Hp( this, 4234, 25 );
LearnSpell( 5568, SpellsTypes.Offensive );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.Ghamoora, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class GiantSurfGlider: BaseCreature 
	 { 
		public  GiantSurfGlider() : base() 
		 { 
			Id = 5432 ;
			Model = 5127;
			AttackSpeed= 1200;
			Name = "Giant Surf Glider" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 48,50 );
			ResistArcane = 0;
			ResistFire = Level*3;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*39);
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.5500000f ;
			SetDamage(1f+3.7f*Level,1f+4.0*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Elite=1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 4234, 48 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.GiantSurfGlider, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class Ironback: BaseCreature 
	 { 
		public  Ironback() : base() 
		 { 
			Id = 8213 ;
			Model = 7840;
			AttackSpeed= 1300;
			Name = "Ironback" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 51 );
			ResistArcane = Level;
			ResistFire = Level*3;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 6060;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 1.00000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Elite=4;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2980, 51 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.Ironback, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class Kresh: BaseCreature 
	 { 
		public  Kresh() : base() 
		 { 
			Id = 3653 ;
			Model = 5126;
			AttackSpeed= 2000;
			Name = "Kresh" ;
			Flags1 = 0x010081010;			 
			Level = RandomLevel( 20 );
			ResistArcane = 0;
			ResistFire = Level*3;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*39);
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.3500000f ;
			SetDamage(1f+3.7f*Level,1f+4.0*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Elite=1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1222, 20 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.Kresh, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class MudrockBorer: BaseCreature 
	 { 
		public  MudrockBorer() : base() 
		 { 
			Id = 4399 ;
			Model = 7840;
			AttackSpeed= 2000;
			Name = "Mudrock Borer" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 42,43 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.52500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.75f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1747, 42 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.MudrockBorer, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class MudrockBurrower: BaseCreature 
	 { 
		public  MudrockBurrower() : base() 
		 { 
			Id = 4398 ;
			Model = 7837;
			AttackSpeed= 2000;
			Name = "Mudrock Burrower" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 39,40 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.452500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.3f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1658, 39 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.MudrockBurrower, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class MudrockSnapjaw: BaseCreature 
	 { 
		public  MudrockSnapjaw() : base() 
		 { 
			Id = 4400 ;
			Model = 7839;
			AttackSpeed= 2000;
			Name = "Mudrock Snapjaw" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 41,42 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.52500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.3f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1658, 39 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.MudrockSnapjaw, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class MudrockSpikeshell: BaseCreature 
	 { 
		public  MudrockSpikeshell() : base() 
		 { 
			Id = 4397 ;
			Model = 7836;
			AttackSpeed= 2000;
			Name = "Mudrock Spikeshell" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 37,38 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.42500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.15f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1372, 37 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.MudrockSpikeshell, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class MudrockTortoise: BaseCreature 
	 { 
		public  MudrockTortoise() : base() 
		 { 
			Id = 4396 ;
			Model = 4829;
			AttackSpeed= 2000;
			Name = "Mudrock Tortoise" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 36,37 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.3500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1183, 36 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.MudrockTortoise, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class OasisSnapjaw: BaseCreature 
	 { 
		public  OasisSnapjaw() : base() 
		 { 
			Id = 3461 ;
			Model = 6368;
			AttackSpeed= 2000;
			Name = "Oasis Snapjaw" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 15,16 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.20100000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=0.57f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 303, 15 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.OasisSnapjaw, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class SaltwaterSnapjaw: BaseCreature 
	 { 
		public  SaltwaterSnapjaw() : base() 
		 { 
			Id = 2505 ;
			Model = 5027;
			AttackSpeed= 2000;
			Name = "Saltwater Snapjaw" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 49,50 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.3500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.5f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2035, 49 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.SaltwaterSnapjaw, 100f ) };
		}
	}	
}


/*
Scalebeard
id 13896
Elite=4;
*/



namespace Server.Creatures
{
	public class Snapjaw: BaseCreature 
	 { 
		public  Snapjaw() : base() 
		 { 
			Id = 2408 ;
			Model = 1244;
			AttackSpeed= 2000;
			Name = "Snapjaw" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 30,31 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.3500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 840, 30 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.Snapjaw, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class SparkleshellBorer: BaseCreature 
	 { 
		public  SparkleshellBorer() : base() 
		 { 
			Id = 4144 ;
			Model = 2307;
			AttackSpeed= 2000;
			Name = "Sparkleshell Borer" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 32,33 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.15f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1137, 32 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.SparkleshellBorer, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class SparkleshellSnapper: BaseCreature 
	 { 
		public  SparkleshellSnapper() : base() 
		 { 
			Id = 4143 ;
			Model = 2308;
			AttackSpeed= 2000;
			Name = "Sparkleshell Snapper" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 34,35 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.400000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.3f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1129, 34 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.SparkleshellSnapper, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class SparkleshellTortoise: BaseCreature 
	 { 
		public  SparkleshellTortoise() : base() 
		 { 
			Id = 4142 ;
			Model = 5052;
			AttackSpeed= 2000;
			Name = "Sparkleshell Tortoise" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 30,31 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.3500000f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.3f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 989, 30 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.SparkleshellTortoise, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class SteeljawSnapper: BaseCreature 
	 { 
		public  SteeljawSnapper() : base() 
		 { 
			Id = 14123 ;
			Model = 7114;
			AttackSpeed= 2000;
			Name = "Steeljaw Snapper" ;
			Flags1 = 0x010080010;			 
			Level = RandomLevel( 42,43 );
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.45500f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=1.3f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1470, 42 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.SteeljawSnapper, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class StolidSnapjaw: BaseCreature 
	 { 
		public  StolidSnapjaw() : base() 
		 { 
			Id = 13599 ;
			Model = 6368;
			AttackSpeed= 2000;
			Name = "Stolid Snapjaw" ;
			Level = RandomLevel( 46,47 );
			Flags1 = 0x010080010;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;
 
			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.25600f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=0.733f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 1670, 46 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.StolidSnapjaw, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class SurfGlider: BaseCreature 
	 { 
		public  SurfGlider() : base() 
		 { 
			Id = 5431 ;
			Model = 7114;
			AttackSpeed= 2000;
			Level = RandomLevel( 48,50 );
			Name = "Surf Glider" ;
			Flags1 = 0x010080010;			 
			ResistArcane = 0;
			ResistFire = Level*2;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.95f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*32);
			Block=Level+20;

			NpcFlags = 0;
			CombatReach = 0.8f ;
			BoundingRadius = 0.25600f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1; BaseMana = 0;
			Family=21;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2057, 48 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( TurtleDrops.SurfGlider, 100f ) };
		}
	}	
}
