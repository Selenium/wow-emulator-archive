using System;
using System.Collections;
using Server;
using Server.Items;


/*Air Spirit - ID 5898*/

namespace Server.Creatures
{
	public class AkumaiServant: BaseCreature 
	 { 
		public  AkumaiServant() : base() 
		 { 
			Id = 4978 ;
			Model = 110;
			AttackSpeed= 2000;
			Name = "Aku'mai Servant" ;
			Level = RandomLevel( 26 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 0.913f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1978, 26 );

			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.AkumaiServant, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class AmbassadorInfernus: BaseCreature 
	 { 
		public  AmbassadorInfernus() : base() 
		 { 
			Id = 2745 ;
			Model = 5488;
			AttackSpeed= 2000;
			Name = "Ambassador Infernus" ;
			Level = RandomLevel( 42 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 9.25f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			
			Elite = 1;
			Speed = 3.84f ;
			WalkSpeed = 3.84f ;
			RunSpeed = 6.84f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4699, 42 );
	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.AmbassadorInfernus, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class AmbershardCrusher: BaseCreature 
	 { 
		public  AmbershardCrusher() : base() 
		 { 
			Id = 11781 ;
			Model = 11711;
			AttackSpeed= 2000;
			Name = "Ambershard Crusher" ;
			Level = RandomLevel( 40,41 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.390f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			
			Elite = 1;
			Speed = 3.84f ;
			WalkSpeed = 3.84f ;
			RunSpeed = 6.84f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4582, 40 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.AmbershardCrusher, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class AmbershardDestroyer: BaseCreature 
	 { 
		public  AmbershardDestroyer() : base() 
		 { 
			Id = 11782 ;
			Model = 11711;
			AttackSpeed= 2000;
			Name = "Ambershard Destroyer" ;
			Level = RandomLevel( 42,43 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.390f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			
			Elite = 1;
			Speed = 3.84f ;
			WalkSpeed = 3.84f ;
			RunSpeed = 6.84f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 5023, 42 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.AmbershardDestroyer, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class AncientStoneKeeper: BaseCreature 
	 { 
		public  AncientStoneKeeper() : base() 
		 { 
			Id = 7206 ;
			Model = 10798;
			AttackSpeed= 2800;
			Name = "Ancient Stone Keeper" ;
			Level = RandomLevel( 44 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*5.75f);
			NpcType = 4;
			Armor= Level*10;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.390f ;
			SetDamage(1f+4.8f*Level,1f+5.5*Level);			
			ManaType=0;
			
			Elite = 1;
			Speed = 3.87f ;
			WalkSpeed = 3.87f ;
			RunSpeed = 6.87f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 6823, 44 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.AncientStoneKeeper, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class AquaGuardian: BaseCreature 
	 { 
		public  AquaGuardian() : base() 
		 { 
			Id = 6047 ;
			Model = 525;
			AttackSpeed= 2000;
			Name = "Aqua Guardian" ;
			Level = RandomLevel( 21,23 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.2f ;
			BoundingRadius = 0.50f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=0.85f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 953, 21 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.AquaGuardian, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Aquementas: BaseCreature 
	 { 
		public  Aquementas() : base() 
		 { 
			Id = 9453 ;
			Model = 5564;
			AttackSpeed= 1400;
			Name = "Aquementas" ;
			Level = RandomLevel( 54 );
			Flags1 = 0x06;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 11.2f ;
			BoundingRadius = 0.50f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3325, 54 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.Aquementas, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ArcaneAberration: BaseCreature 
	 { 
		public  ArcaneAberration() : base() 
		 { 
			Id = 11480 ;
			Model = 14253;
			AttackSpeed= 2000;
			Name = "Arcane Aberration" ;
			Level = RandomLevel( 58,60 );
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 11.5f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.84f ;
			WalkSpeed = 3.84f ;
			RunSpeed = 6.84f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7023, 58 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.ArcaneAberration, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class ArcaneFeedback: BaseCreature 
	 { 
		public  ArcaneFeedback() : base() 
		 { 
			Id = 14400 ;
			Model = 5490;
			AttackSpeed= 1400;
			Name = "Arcane Feedback" ;
			Level = RandomLevel( 59,60 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 11.2f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4325, 59 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.ArcaneFeedback, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ArcaneTorrent: BaseCreature 
	 { 
		public  ArcaneTorrent() : base() 
		 { 
			Id = 14399 ;
			Model = 10315;
			AttackSpeed= 2000;
			Name = "Arcane Torrent" ;
			Level = RandomLevel( 59,60 );
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 11.0f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.84f ;
			WalkSpeed = 3.84f ;
			RunSpeed = 6.84f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7023, 59 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.ArcaneTorrent, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Arei: BaseCreature 
	 { 
		public  Arei() : base() 
		 { 
			Id = 9598;
			Model = 11362;
			AttackSpeed= 1400;
			Name = "Arei" ;
			Flags1 = 0x010480006;			 
			Level = RandomLevel( 55,56 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 11.0f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;			
			Size=1f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2966, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.Arei, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}


namespace Server.Creatures
{
	public class Avalanchion: BaseCreature 
	 { 
		public  Avalanchion() : base() 
		 { 
			Id = 14464 ;
			Model = 1068;
			AttackSpeed= 2000;
			Name = "Avalanchion" ;
			Level = RandomLevel( 58 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 0.913f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7424, 58 );

			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.AkumaiServant, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{	public class BaronAquanis: BaseCreature 
	 { 
		public  BaronAquanis() : base() 
		 { 
			Id = 12876 ;
			Model = 110;
			AttackSpeed= 2000;
			Name = "Baron Aquanis" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 28 );
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 0.19f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2152, 28 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BaronAquanis, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{	public class BaronCharr: BaseCreature 
	 { 
		public  BaronCharr() : base() 
		 { 
			Id = 14461 ;
			Model = 14517;
			AttackSpeed= 2000;
			Name = "Baron Charr" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 58 );
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 0.19f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=2f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7424, 58 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BaronAquanis, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BaronGeddon: BaseCreature 
	 { 
		public  BaronGeddon() : base() 
		 { 
			Id = 12056;
			Model = 12129;
			AttackSpeed= 2000;
			Name = "Baron Geddon" ;
			Flags1 = 0x0C0811000;			 
			Level = RandomLevel( 63 );
			ResistArcane = Level*8;
			ResistFire = Level*10;
			ResistFrost = Level*8;
			ResistHoly = Level*8;
			ResistNature = Level*8;
			ResistShadow = Level*8;
			Str = (int)(Level*6.75f);
			NpcType = 4;
			Armor= Level*52;
			ManaType=0;
			Block=Level+50;
			NpcFlags = 0;
			CombatReach = 4.5f ;
			BoundingRadius = 4.167f ;
			SetDamage(1f+5.5f*Level,1f+6.5*Level);			
			Elite = 3;
			Speed = 4.16f ;
			WalkSpeed = 4.16f ;
			RunSpeed = 7.16f ;			
			Size=3f;
			Faction = Factions.Monster;
			AIEngine = new StandingNpcAI( this );
			BCAddon.Hp( this, 77671, 63 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BaronAquanis, 100f ),
								new BaseTreasure(DropsME.MoneyBoss, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BefouledWaterElemental: BaseCreature 
	 { 
		public  BefouledWaterElemental() : base() 
		 { 
			Id = 3917 ;
			Model = 525;
			AttackSpeed= 1400;
			Name = "Befouled Water Elemental" ;
			Level = RandomLevel( 23,25 );
			Flags1 = 0x080000;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 0.51f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=0.85f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 495, 23 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BefouledWaterElemental, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BlackenedAncient: BaseCreature 
	 { 
		public  BlackenedAncient() : base() 
		 { 
			Id = 4029 ;
			Model = 2168;
			AttackSpeed= 2000;
			Name = "Blackened Ancient" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 27,28 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.61f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.75f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 917, 27 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BlackenedAncient, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BlackmosstheFetid: BaseNPC 
	 { 
		public  BlackmosstheFetid() : base() 
		 { 
			Id = 3535 ;
			Model = 1549;
			AttackSpeed= 2000;
			Level = RandomLevel( 13 );
			Name = "Blackmoss the Fetid" ;
			Flags1 = 0x080000;			 
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.7485f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.41f ;
			WalkSpeed = 3.41f ;
			RunSpeed = 6.41f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 917, 13 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BlackmosstheFetid, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{	public class Blazerunner: BaseCreature 
	 { 
		public  Blazerunner() : base() 
		 { 
			Id = 9376 ;
			Model = 1204;
			AttackSpeed= 2000;
			Name = "Blazerunner" ;
			Level = RandomLevel( 56 );
			Flags1 = 0x080000;			 
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 1.5f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 9152, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.Blazerunner, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class BlazingElemental: BaseCreature 
	 { 
		public  BlazingElemental() : base() 
		 { 
			Id = 5850 ;
			Model = 1070;
			AttackSpeed= 2000;
			Name = "Blazing Elemental" ;
			Level = RandomLevel( 46,47 );
			Flags1 = 0x080000;			 
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.61f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.26f ;
			WalkSpeed = 3.26f ;
			RunSpeed = 6.26f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1891, 46 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BlazingElemental, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}



namespace Server.Creatures
{	public class BlazingFireguard: BaseCreature 
	 { 
		public  BlazingFireguard() : base() 
		 { 
			Id = 8910 ;
			Model = 1070;
			AttackSpeed= 2000;
			Name = "Blazing Fireguard" ;
			Level = RandomLevel( 52,54 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 2f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 5797, 52 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BlazingFireguard, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BlazingInvader: BaseCreature 
	 { 
		public  BlazingInvader() : base() 
		 { 
			Id = 14460 ;
			Model = 14527;
			AttackSpeed= 2000;
			Name = "Blazing Invader" ;
			Level = RandomLevel( 54,56 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.61f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.26f ;
			WalkSpeed = 3.26f ;
			RunSpeed = 6.26f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2890, 54 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BlazingInvader, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class BlightedHorror: BaseCreature 
	 { 
		public  BlightedHorror() : base() 
		 { 
			Id = 8521 ;
			Model = 11171;
			AttackSpeed= 1400;
			Name = "Blighted Horror" ;
			Flags1 = 0x010080000;			 
			Level = RandomLevel( 56,57 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.61f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.33f ;
			WalkSpeed = 3.33f ;
			RunSpeed = 6.33f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3990, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BlightedHorror, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class BlightedSurge: BaseCreature 
	 { 
		public  BlightedSurge() : base() 
		 { 
			Id = 8519 ;
			Model = 5497;
			AttackSpeed= 1400;
			Name = "Blighted Surge" ;
			Level = RandomLevel( 54,55 );
			Flags1 = 0x080000;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.61f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.33f ;
			WalkSpeed = 3.33f ;
			RunSpeed = 6.33f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3714, 54 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BlightedSurge, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Bogling: BaseCreature 
	 { 
		public  Bogling() : base() 
		 { 
			Id = 3569 ;
			Model = 1081;
			AttackSpeed= 1900;
			Name = "Bogling" ;
			Level = RandomLevel( 5 );
			Flags1 = 0x080000;			 
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11.0f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 136, 5 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.Bogling, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class BoilingElemental: BaseCreature 
	 { 
		public  BoilingElemental() : base() 
		 { 
			Id = 10757 ;
			Model = 5561;
			AttackSpeed= 3000;
			Name = "Boiling Elemental" ;
			Flags1 = 0x010080000;			 
			Level = RandomLevel( 27,28 );
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.609f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.12f ;
			WalkSpeed = 3.12f ;
			RunSpeed = 6.12f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 813, 27 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BoilingElemental, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class BranchSnapper: BaseCreature 
	 { 
		public  BranchSnapper() : base() 
		 { 
			Id = 10641 ;
			Model = 8389;
			AttackSpeed= 1600;
			Name = "Branch Snapper" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 25 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*15;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11.95f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2917, 25 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BranchSnapper, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class Brutus: BaseCreature 
	 { 
		public  Brutus() : base() 
		 { 
			Id = 2551 ;
			Model = 1102;
			AttackSpeed= 1500;
			Name = "Brutus" ;
			Level = RandomLevel( 43 );
			Flags1 = 0x010080000;			 
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11.0f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.23f ;
			WalkSpeed = 3.23f ;
			RunSpeed = 6.23f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2200, 43 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.Brutus, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BurningDestroyer: BaseCreature 
	 { 
		public  BurningDestroyer() : base() 
		 { 
			Id = 4038 ;
			Model = 1070;
			AttackSpeed= 2000;
			Name = "Burning Destroyer" ;
			Flags1 = 0x010080000;			 
			Level = RandomLevel( 26,27 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.11f ;
			WalkSpeed = 3.11f ;
			RunSpeed = 6.11f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 730, 26 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BurningDestroyer, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BurningExile: BaseCreature 
	 { 
		public  BurningExile() : base() 
		 { 
			Id = 2760;
			Model = 2172;
			AttackSpeed= 2000;
			Name = "Burning Exile" ;
			Flags1 = 0x010080000;			 
			Level = RandomLevel( 38,39 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.75f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=0.75f;
			NpcText00="What do ye need directions to?";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1136, 38 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BurningExile, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BurningRavager: BaseCreature 
	 { 
		public  BurningRavager() : base() 
		 { 
			Id = 4037;
			Model = 2172;
			AttackSpeed= 2000;
			Name = "Burning Ravager" ;
			Level = RandomLevel( 24,25 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.75f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=0.75f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 666, 24 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BurningRavager, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class BurningServan: BaseCreature 
	 { 
		public  BurningServan() : base() 
		 { 
			Id = 7738;
			Model = 2172;
			AttackSpeed= 2000;
			Level = RandomLevel( 30 );
			Name = "Burning Servan" ;
			Flags1 = 0x06;			 
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.75f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=0.75f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 966, 30 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BurningServan, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class BurningSpirit: BaseCreature 
	 { 
		public  BurningSpirit() : base() 
		 { 
			Id = 9178;
			Model = 4607;
			AttackSpeed= 1600;
			Name = "Burning Spirit" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 30 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 11.0f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.12f ;
			WalkSpeed = 3.12f ;
			RunSpeed = 6.12f ;			
			Size=0.75f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 966, 30 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.BurningSpirit, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{	public class CavernLurker: BaseCreature 
	 { 
		public  CavernLurker() : base() 
		 { 
			Id = 12223;
			Model = 3386;
			AttackSpeed= 2500;
			Name = "Cavern Lurker" ;
			//Flags1 = 0x080000;			 
			Level = RandomLevel( 45,46 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.748f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.89f ;
			WalkSpeed = 3.89f ;
			RunSpeed = 6.89f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 5797, 45 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CavernLurker, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{	public class CavernShambler: BaseCreature 
	 { 
		public  CavernShambler() : base() 
		 { 
			Id = 12224;
			Model = 9014;
			AttackSpeed= 2500;
			Name = "Cavern Shambler" ;
			Level = RandomLevel( 46,47 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 2.018f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 5997, 46 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CavernShambler, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CharredAncient: BaseCreature 
	 { 
		public  CharredAncient() : base() 
		 { 
			Id = 4028;
			Model = 2079;
			AttackSpeed= 2000;
			Name = "Charred Ancient" ;
			Level = RandomLevel( 25,26 );
			Flags1 = 0x06;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 0.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.10f ;
			WalkSpeed = 3.10f ;
			RunSpeed = 6.10f ;			
			Size=1.5f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 594, 25 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CharredAncient, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CharredStoneSpirit: BaseCreature 
	 { 
		public  CharredStoneSpirit() : base() 
		 { 
			Id = 4033;
			Model = 2169;
			AttackSpeed= 1700;
			Name = "Charred Stone Spirit" ;
			Level = RandomLevel( 23 );
			Flags1 = 0x06;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.10f ;
			WalkSpeed = 3.10f ;
			RunSpeed = 6.10f ;			
			Size=1.5f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 594, 23 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CharredStoneSpirit, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CorruptForceofNature: BaseCreature 
	 { 
		public  CorruptForceofNature() : base() 
		 { 
			Id = 13743;
			Model = 9593;
			AttackSpeed= 2000;
			Name = "Corrupt Force of Nature" ;
			Level = RandomLevel( 44 );
			Flags1 = 0x06;			 
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 0.52f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=1.5f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 994, 44 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CorruptForceofNature, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CorruptMinorManifestationofWater: BaseCreature 
	 { 
		public  CorruptMinorManifestationofWater() : base() 
		 { 
			Id = 5894;
			Model = 5493;
			AttackSpeed= 2000;
			Name = "Corrupt Minor Manifestation of Water" ;
			Level = RandomLevel( 22 );
			Flags1 = 0x06;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 0.425f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.10f ;
			WalkSpeed = 3.10f ;
			RunSpeed = 6.10f ;			
			Size=1.5f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 526, 22 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CorruptMinorManifestationofWater, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CorruptWaterSpirit: BaseCreature 
	 { 
		public  CorruptWaterSpirit() : base() 
		 { 
			Id = 5897;
			Model = 5492;
			AttackSpeed= 2000;
			Name = "Corrupt Water Spirit" ;
			Level = RandomLevel( 19 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.425f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=0.85f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 326, 19 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CorruptWaterSpirit, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CrackedGolem: BaseCreature 
	 { 
		public  CrackedGolem() : base() 
		 { 
			Id = 2156;
			Model = 10799;
			AttackSpeed= 2000;
			Name = "Cracked Golem" ;
			Level = RandomLevel( 18,19 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.2f ;
			BoundingRadius = 0.425f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;			
			Size=0.85f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 224, 18 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CrackedGolem, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CrazedAncient: BaseCreature 
	 { 
		public  CrazedAncient() : base() 
		 { 
			Id = 3834;
			Model = 2077;
			AttackSpeed= 2000;
			Name = "Crazed Ancient" ;
			Level = RandomLevel( 27,28 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 0.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.12f ;
			WalkSpeed = 3.12f ;
			RunSpeed = 6.12f ;			
			Size=1.5f;
			NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 844, 27 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CrazedAncient, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class CrestingExile: BaseCreature 
	 { 
		public  CrestingExile() : base() 
		 { 
			Id = 2761;
			Model = 5561;
			AttackSpeed= 2000;
			Name = "Cresting Exile" ;
			Level = RandomLevel( 38,39 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.605f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.5f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1219, 38 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CrestingExile, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class CursedSycamore: BaseCreature 
	 { 
		public  CursedSycamore() : base() 
		 { 
			Id = 5881;
			Model = 1988;
			AttackSpeed= 2000;
			Name = "Cursed Sycamore" ;
			Level = RandomLevel( 45 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.625f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.25f;
			WalkSpeed = 3.25f;
			RunSpeed = 3.25f;			
			Size=1.75f;
//			NpcText00="What do ye need directions to?";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2204, 45 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CursedSycamore, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class CycloneWarrior: BaseCreature 
	 { 
		public  CycloneWarrior() : base() 
		 { 
			Id = 11745;
			Model = 8716;
			AttackSpeed= 2000;
			Name = "Cyclone Warrior" ;
			Level = RandomLevel( 57,58 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 0.91f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 2.9f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1919, 57 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.CycloneWarrior, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Cyclonian: BaseCreature 
	 { 
		public  Cyclonian() : base() 
		 { 
			Id = 6239;
			Model = 5187;
			AttackSpeed= 2000;
			Name = "Cyclonian" ;
			Level = RandomLevel( 40 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*5;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.25f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2976, 40 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.Cyclonian, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DarnassianProtector: BaseCreature 
	 { 
		public  DarnassianProtector() : base() 
		 { 
			Id = 4423;
			Model = 2451;
			AttackSpeed= 2000;
			Name = "Darnassian Protector" ;
			Flags1 = 0x010400002;			 
			Level = RandomLevel( 55,60 );
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2f ;
			BoundingRadius = 0.34f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.48f ;
			WalkSpeed = 3.48f ;
			RunSpeed = 3.48f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Darnasus;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2719, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DarnassianProtector, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DeathLash: BaseCreature 
	 { 
		public  DeathLash() : base() 
		 { 
			Id = 13285;
			Model = 13172;
			AttackSpeed= 2000;
			Name = "Death Lash" ;
			Level = RandomLevel( 57,58 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*5;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3276, 57 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DeathLash, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class DecayingHorror: BaseCreature 
	 { 
		public  DecayingHorror() : base() 
		 { 
			Id = 1813;
			Model = 2832;
			AttackSpeed= 1300;
			Name = "Decaying Horror" ;
			Level = RandomLevel( 56,57 );
			Flags1 = 0x080000;			 
			ResistArcane = Level*2;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2252, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DecayingHorror, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DeepLurker: BaseCreature 
	 { 
		public  DeepLurker() : base() 
		 { 
			Id = 8334;
			Model = 631;
			AttackSpeed= 2000;
			Name = "Deep Lurker" ;
			Level = RandomLevel( 47,49 );
			Flags1 = 0x080000;			 
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.7f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2276, 47 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DeepLurker, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DeeprotStomper: BaseCreature 
	 { 
		public  DeeprotStomper() : base() 
		 { 
			Id = 13141;
			Model = 2079;
			AttackSpeed= 2000;
			Name = "Deeprot Stomper" ;
			Level = RandomLevel( 43,44 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 0.56f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4483, 43 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DeeprotStomper, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DeeprotTangler: BaseCreature 
	 { 
		public  DeeprotTangler() : base() 
		 { 
			Id = 13142;
			Model = 13098;
			AttackSpeed= 2000;
			Name = "Deeprot Tangler" ;
			Level = RandomLevel( 44,45 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 0.56f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;
			RunSpeed = 6.8f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4671, 44 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DeeprotTangler, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DesertRager: BaseCreature 
	 { 
		public  DesertRager() : base() 
		 { 
			Id = 11747;
			Model = 1162;
			AttackSpeed= 1300;
			Name = "Desert Rager" ;
			Level = RandomLevel( 59,60 );
			Flags1 = 0x080000;			 
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3152, 59 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DesertRager, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class DesertRumbler: BaseCreature 
	 { 
		public  DesertRumbler() : base() 
		 { 
			Id = 11746;
			Model = 8550;
			AttackSpeed= 1300;
			Name = "Desert Rumbler" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 56,58 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2852, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DesertRumbler, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Dessecus: BaseCreature 
	 { 
		public  Dessecus() : base() 
		 { 
			Id = 7104;
			Model = 9013;
			AttackSpeed= 1100;
			Name = "Dessecus" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 56 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*10;
			Str = (int)(Level*5.75f);
			NpcType = 4;
			Armor= Level*42;
			ManaType=0;
			Block=Level+40;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+4.8f*Level,1f+5.5*Level);			
			Elite = 2;
			Speed = 4.16f ;
			WalkSpeed = 4.16f ;
			RunSpeed = 7.16f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7671, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.Dessecus, 100f ),
								new BaseTreasure(DropsME.MoneyElite2, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class DeviateShambler: BaseCreature 
	 { 
		public  DeviateShambler() : base() 
		 { 
			Id = 5761;
			Model = 1084;
			AttackSpeed= 2000;
			Name = "Deviate Shambler" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 19,20 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.3f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.58f ;
			WalkSpeed = 3.58f ;
			RunSpeed = 6.58f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 929, 19 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DeviateShambler, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DiscordantSurge: BaseCreature 
	 { 
		public  DiscordantSurge() : base() 
		 { 
			Id = 13279;
			Model = 11172;
			AttackSpeed= 1300;
			Name = "Discordant Surge" ;
			Flags1 = 0x010080000;			 
			Level = RandomLevel( 55,57 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1094, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DiscordantSurge, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DrogoththeRoamer: BaseCreature 
	 { 
		public  DrogoththeRoamer() : base() 
		 { 
			Id = 14231 ;
			Model = 631;
			AttackSpeed= 2000;
			Name = "Drogoth the Roamer" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 37 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.7485f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.41f ;
			WalkSpeed = 3.41f ;
			RunSpeed = 6.41f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3917, 37 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DrogoththeRoamer, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class DukeHydraxis: BaseCreature 
	 { 
		public  DukeHydraxis() : base() 
		 { 
			Id = 13278;
			Model = 10849;
			AttackSpeed= 2000;
			Name = "Duke Hydraxis" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 60 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 3.3f ;
			BoundingRadius = 1.3f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.58f ;
			WalkSpeed = 3.58f ;
			RunSpeed = 6.58f ;			
			Size=2.2f;
			Faction = Factions.Friend;
			NpcText00="I am Hydraxis, Duke of the Waterlords.  You are not an elemental and so cannot understand our struggle, but perhaps we can strike a deal that will benefit us both...";
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2929, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DukeHydraxis, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DustDevil: BaseCreature 
	 { 
		public  DustDevil() : base() 
		 { 
			Id = 832;
			Model = 5327;
			AttackSpeed= 2000;
			Name = "Dust Devil" ;
			Level = RandomLevel( 18,19 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			BaseMana=526;
			NpcFlags = 0;
			CombatReach = 0.93f ;
			BoundingRadius = 0.75f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=0.75f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			LearnSpell( 6982, SpellsTypes.Offensive );
			BCAddon.Hp( this, 436, 18 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DustDevil, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class DustStormer: BaseCreature 
	 { 
		public  DustStormer() : base() 
		 { 
			Id = 11744;
			Model = 8715;
			AttackSpeed= 1400;
			Name = "Dust Stormer" ;
			Level = RandomLevel( 55,57 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3154, 55 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops2.DustStormer, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class EarthElemental: BaseCreature 
	 { 
		public  EarthElemental() : base() 
		 { 
			Id = 329;
			Model = 453;
			AttackSpeed= 2000;
			Name = "Earth Elemental" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 51,53 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3154, 51 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.EarthElemental, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class Eckalom: BaseCreature 
	 { 
		public  Eckalom() : base() 
		 { 
			Id = 10642;
			Model = 5561;
			AttackSpeed= 1600;
			Name = "Eck'alom" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 27 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 115f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.12f ;
			WalkSpeed = 3.12f ;
			RunSpeed = 6.12f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3917, 27 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Eckalom, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ElderLakeCreeper: BaseCreature 
	 { 
		public  ElderLakeCreeper() : base() 
		 { 
			Id = 1956;
			Model = 631;
			AttackSpeed= 2000;
			Name = "Elder Lake Creeper" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 18,19 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.74f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;			
			Size=1.2f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 595, 18 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.ElderLakeCreeper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ElderLakeSkulker: BaseCreature 
	 { 
		public  ElderLakeSkulker() : base() 
		 { 
			Id = 1954;
			Model = 9009;
			AttackSpeed= 2000;
			Name = "Elder Lake Skulker" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 16,17 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.74f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 341, 16 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.ElderLakeSkulker, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class ElementalSlave: BaseCreature 
	 { 
		public  ElementalSlave() : base() 
		 { 
			Id = 2359;
			Model = 1068;
			AttackSpeed= 2000;
			Name = "Elemental Slave" ;
			Level = RandomLevel( 33,34 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 1.174f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Alliance;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 941, 33 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.ElementalSlave, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Ember: BaseCreature 
	 { 
		public  Ember() : base() 
		 { 
			Id = 7266;
			Model = 6537;
			AttackSpeed= 2000;
			Name = "Ember" ;
			Level = RandomLevel( 32 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 1.174f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Alliance;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 841, 32 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Ember, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class EnragedRockElemental: BaseCreature 
	 { 
		public  EnragedRockElemental() : base() 
		 { 
			Id = 2791;
			Model = 8550;
			AttackSpeed= 2000;
			Name = "Enraged Rock Elemental" ;
			Level = RandomLevel( 42,43 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.389f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1438, 42 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.EnragedRockElemental, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class EnragedStoneSpirit: BaseCreature 
	 { 
		public  EnragedStoneSpirit() : base() 
		 { 
			Id = 4034;
			Model = 2170;
			AttackSpeed= 2000;
			Name = "Enraged Stone Spirit" ;
			Level = RandomLevel( 24,25 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 1.189f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 592, 24 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.EnragedStoneSpirit, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class EntropicBeast: BaseCreature 
	 { 
		public  EntropicBeast() : base() 
		 { 
			Id = 9878;
			Model = 9449;
			AttackSpeed= 2000;
			Name = "Entropic Beast" ;
			Level = RandomLevel( 51,52 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2.5f ;
			BoundingRadius = 0.35f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.31f ;
			WalkSpeed = 3.31f ;
			RunSpeed = 6.31f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3001, 51 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.EntropicBeast, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



/* Faltering Draenethyst Sphere id 7409 */


namespace Server.Creatures
{
	public class FamretorGuardian: BaseCreature 
	 { 
		public  FamretorGuardian() : base() 
		 { 
			Id = 2919;
			Model = 1162;
			AttackSpeed= 1500;
			Name = "Fam'retor Guardian" ;
			Level = RandomLevel( 45 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.26f ;
			WalkSpeed = 3.26f ;
			RunSpeed = 6.26f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2247, 45 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FamretorGuardian, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FaultyWarGolem: BaseCreature 
	 { 
		public  FaultyWarGolem() : base() 
		 { 
			Id = 8279;
			Model = 10800;
			AttackSpeed= 2000;
			Name = "Faulty War Golem" ;
			Level = RandomLevel( 46 );
			ResistArcane = Level*10;
			ResistFire = Level*15;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.339f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.78f ;
			WalkSpeed = 3.78f ;
			RunSpeed = 6.78f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3917, 46 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FaultyWarGolem, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class FelLash: BaseCreature 
	 { 
		public  FelLash() : base() 
		 { 
			Id = 13197;
			Model = 13110;
			AttackSpeed= 1600;
			Name = "Fel Lash" ;
			Level = RandomLevel( 56 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.36f ;
			WalkSpeed = 3.36f ;
			RunSpeed = 6.36f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2976, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FelLash, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class FenCreepe: BaseCreature 
	 { 
		public  FenCreepe() : base() 
		 { 
			Id = 1040;
			Model = 2023;
			AttackSpeed= 2000;
			Name = "Fen Creepe" ;
			Level = RandomLevel( 24,25 );
			Flags1 = 0x080000;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.54f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.10f ;
			WalkSpeed = 3.10f ;
			RunSpeed = 6.10f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Visible = InvisibilityLevel.Medium;
			BCAddon.Hp( this, 502, 24 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FenCreepe, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class FenDweller: BaseCreature 
	 { 
		public  FenDweller() : base() 
		 { 
			Id = 1039;
			Model = 713;
			AttackSpeed= 2000;
			Name = "Fen Dweller" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 20,21 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.34f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.05f ;
			WalkSpeed = 3.05f ;
			RunSpeed = 6.05f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 517, 20 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FenDweller, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FenLord: BaseCreature 
	 { 
		public  FenLord() : base() 
		 { 
			Id = 1041;
			Model = 2024;
			AttackSpeed= 2000;
			Name = "Fen Lord" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 25,26 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.748f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.10f ;
			WalkSpeed = 3.10f ;
			RunSpeed = 6.10f ;			
			Size=1.3f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 753, 25 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FenLord, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FireElemental: BaseCreature 
	 { 
		public  FireElemental() : base() 
		 { 
			Id = 575;
			Model = 1405;
			AttackSpeed= 2000;
			Name = "Fire Elemental" ;
			Level = RandomLevel( 35,36 );
			Flags1 = 0x06;			 
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.748f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.18f ;
			WalkSpeed = 3.18f ;
			RunSpeed = 6.18f ;			
			Size=0.6f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1753, 35 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FireElemental, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class FireSpirit: BaseCreature 
	 { 
		public  FireSpirit() : base() 
		 { 
			Id = 5896;
			Model = 4607;
			AttackSpeed= 2000;
			Name = "Fire Spirit" ;
			Level = RandomLevel( 10 );
			Flags1 = 0x0266;			 
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1f ;
			BoundingRadius = 0.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=0.5f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 253, 10 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FireSpirit, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class Fireguard: BaseCreature 
	 { 
		public  Fireguard() : base() 
		 { 
			Id = 8909;
			Model = 2172;
			AttackSpeed= 2000;
			Name = "Fireguard" ;
			Level = RandomLevel( 50,52 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.75f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=0.75f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 5393, 50 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Fireguard, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FireguardDestroyer: BaseCreature 
	 { 
		public  FireguardDestroyer() : base() 
		 { 
			Id = 8911;
			Model = 5488;
			AttackSpeed= 2000;
			Name = "Fireguard Destroyer" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 54,56 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2.5f ;
			BoundingRadius = 1.25f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;			
			Size=1.25f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2573, 54 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FireguardDestroyer, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Firelord: BaseCreature 
	 { 
		public  Firelord() : base() 
		 { 
			Id = 11668;
			Model = 12231;
			AttackSpeed= 1000;
			Name = "Firelord" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 60,62 );
			ResistArcane = Level;
			ResistFire = Level*15;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
BaseMana = 9165;
			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
BCAddon.Hp( this, 5573, 60 );	
LearnSpell( 19392, SpellsTypes.Defensive );
LearnSpell( 19393, SpellsTypes.Offensive );
LearnSpell( 19396, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Firelord, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Firesworn: BaseCreature 
	 { 
		public  Firesworn() : base() 
		 { 
			Id = 12099;
			Model = 5781;
			AttackSpeed= 2000;
			Name = "Firesworn" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 60 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.59f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1.15f;
			BCAddon.Hp( this, 4573, 60 );	
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Firesworn, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class Firewalker: BaseCreature 
	 { 
		public  Firewalker() : base() 
		 { 
			Id = 11666;
			Model = 1070;
			AttackSpeed= 2000;
			Name = "Firewalker" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 61,62 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 BaseMana = 5200;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1.15f;
BCAddon.Hp( this, 5200, 61 );				
LearnSpell( 19636, SpellsTypes.Offensive );
LearnSpell( 19635, SpellsTypes.Offensive );			
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Firewalker, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FlameImp: BaseCreature 
	 { 
		public  FlameImp() : base() 
		 { 
			Id = 11669;
			Model = 12190;
			AttackSpeed= 1000;
			Name = "Flame Imp" ;
			Flags1 = 0x080800006;			 
			Level = RandomLevel( 60,62 );
			ResistArcane = Level*2;
			ResistFire = Level*5;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1.15f;
			BCAddon.Hp( this, 5973, 60 );	
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FlameImp, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Flameguard: BaseCreature 
	 { 
		public  Flameguard() : base() 
		 { 
			Id = 11667;
			Model = 5488;
			AttackSpeed= 2000;
			Name = "Flameguard" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 61,62 );
			ResistArcane = Level*2;
			ResistFire = Level*5;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 BaseMana = 7589;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1.15f;
BCAddon.Hp( this, 5973, 60 );				
LearnSpell( 19630, SpellsTypes.Offensive );
LearnSpell( 19626, SpellsTypes.Offensive );			
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Flameguard, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FlawlessDraenethystFragment: BaseCreature 
	 { 
		public  FlawlessDraenethystFragment() : base() 
		 { 
			Id = 7365;
			Model = 1825;
			AttackSpeed= 1400;
			Name = "Flawless Draenethyst Fragment" ;
			Flags1 = 0x066;			 
			Level = RandomLevel( 40 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1253, 40 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FlawlessDraenethystFragment, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FlawlessDraenethystSphere: BaseCreature 
	 { 
		public  FlawlessDraenethystSphere() : base() 
		 { 
			Id = 7364;
			Model = 6148;
			AttackSpeed= 1200;
			Name = "Flawless Draenethyst Sphere" ;
			Flags1 = 0x066;			 
			Level = RandomLevel( 60 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.4f ;
			WalkSpeed = 3.4f ;
			RunSpeed = 6.4f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3253, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FlawlessDraenethystSphere, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class FuriousStoneSpirit: BaseCreature 
	 { 
		public  FuriousStoneSpirit() : base() 
		 { 
			Id = 4035;
			Model = 2075;
			AttackSpeed= 2000;
			Name = "Furious Stone Spirit" ;
			Level = RandomLevel( 26,27 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.4f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.11f ;
			WalkSpeed = 3.11f ;
			RunSpeed = 6.11f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 887, 26 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.FuriousStoneSpirit, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Garr: BaseCreature 
	 { 
		public  Garr() : base() 
		 { 
			Id = 12057;
			Model = 12110;
			AttackSpeed= 2000;
			Name = "Garr" ;
			Level = RandomLevel( 63 );
			Flags1 = 0x0C0811000;			 
			ResistArcane = Level*8;
			ResistFire = Level*10;
			ResistFrost = Level*8;
			ResistHoly = Level*8;
			ResistNature = Level*8;
			ResistShadow = Level*8;
			Str = (int)(Level*6.75f);
			NpcType = 4;
			Armor= Level*52;
			ManaType=0;
			Block=Level+50;

			NpcFlags = 0;
			CombatReach = 4.5f ;
			BoundingRadius = 4.167f ;
			SetDamage(1f+5.5f*Level,1f+6.5*Level);			
			Elite = 3;
			Speed = 4.16f ;
			WalkSpeed = 4.16f ;
			RunSpeed = 7.16f ;			
			Size=3f;
			Faction = Factions.Monster;
			AIEngine = new StandingNpcAI( this );
			BCAddon.Hp( this, 77671, 63 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Garr, 100f ),
								new BaseTreasure(DropsME.MoneyBoss, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class GelkisRumbler: BaseCreature 
	 { 
		public  GelkisRumbler() : base() 
		 { 
			Id = 4661;
			Model = 1068;
			AttackSpeed= 2000;
			Name = "Gelkis Rumbler" ;
			Flags1 = 0x04;			 
			Level = RandomLevel( 29,30 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.14f ;
			WalkSpeed = 3.14f ;
			RunSpeed = 6.14f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 653, 29 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.GelkisRumbler, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}


/*Gnarl Leafbrother id 5354 */



namespace Server.Creatures
{
	public class GnarledThistleshrub: BaseCreature 
	 { 
		public  GnarledThistleshrub() : base() 
		 { 
			Id = 5490;
			Model = 1068;
			AttackSpeed= 2000;
			Name = "Gnarled Thistleshrub" ;
			Level = RandomLevel( 48,49 );
			Flags1 = 0x080000;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.74f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1892, 48 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.GnarledThistleshrub, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class GreaterObsidianElemental: BaseCreature 
	 { 
		public  GreaterObsidianElemental() : base() 
		 { 
			Id = 7032;
			Model = 5781;
			AttackSpeed= 2000;
			Name = "Greater Obsidian Elemental" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 55,57 );
			ResistArcane = Level*2;
			ResistFire = Level*3;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.6f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.35f ;
			WalkSpeed = 3.35f ;
			RunSpeed = 6.35f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3004, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.GreaterObsidianElemental, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class GreaterRockElemental: BaseCreature 
	 { 
		public  GreaterRockElemental() : base() 
		 { 
			Id = 2736;
			Model = 14328;
			AttackSpeed= 2000;
			Name = "Greater Rock Elemental" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 42,44 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1686, 42 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.GreaterRockElemental, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class GroundPounder: BaseCreature 
	 { 
		public  GroundPounder() : base() 
		 { 
			Id = 9396;
			Model = 1161;
			AttackSpeed= 2000;
			Name = "Ground Pounder" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 41,43 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 1.18f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1413, 41 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.GroundPounder, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class GustingVortex: BaseCreature 
	 { 
		public  GustingVortex() : base() 
		 { 
			Id = 8667;
			Model = 8715;
			AttackSpeed= 2000;
			Name = "Gusting Vortex" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 43,45 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.85f ;
			BoundingRadius = 1.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;			
			Size=1.5f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2159, 43 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.GustingVortex, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class HeavyWarGolem: BaseCreature 
	 { 
		public  HeavyWarGolem() : base() 
		 { 
			Id = 5854;
			Model = 10801;
			AttackSpeed= 2000;
			Name = "Heavy War Golem" ;
			Level = RandomLevel( 48,49 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 1.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;			
			Size=1.5f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2068, 48 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.HeavyWarGolem, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Huricanian: BaseCreature 
	 { 
		public  Huricanian() : base() 
		 { 
			Id = 14478 ;
			Model = 14525;
			AttackSpeed= 2000;
			Name = "Huricanian" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 58 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.7485f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.41f ;
			WalkSpeed = 3.41f ;
			RunSpeed = 6.41f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3917, 58 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Huricanian, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class HydraxianHonorGuard: BaseCreature 
	 { 
		public  HydraxianHonorGuard() : base() 
		 { 
			Id = 13322 ;
			Model = 5564;
			AttackSpeed= 2000;
			Name = "Hydraxian Honor Guard" ;
			Flags1 = 0x01;			 
			Level = RandomLevel( 58 );
			ResistArcane = Level*5;
			ResistFire = Level;
			ResistFrost = Level*5;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 1.218f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=2f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2976, 26 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.HydraxianHonorGuard, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Hydroling: BaseCreature 
	 { 
		public  Hydroling() : base() 
		 { 
			Id = 14350;
			Model = 5561;
			AttackSpeed= 2000;
			Name = "Hydroling" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 55,57 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2868, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Hydroling, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Hydrospawn: BaseCreature 
	 { 
		public  Hydrospawn() : base() 
		 { 
			Id = 13280 ;
			Model = 5489;
			AttackSpeed= 2000;
			Name = "Hydrospawn" ;
			Flags1 = 0x01000;			 
			Level = RandomLevel( 57 );
			ResistArcane = Level*5;
			ResistFire = Level;
			ResistFrost = Level*5;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.218f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2976, 26 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.Hydrospawn, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class InfernoElemental: BaseCreature 
	 { 
		public  InfernoElemental() : base() 
		 { 
			Id = 5852;
			Model = 5488;
			AttackSpeed= 2000;
			Name = "Inferno Elemental" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 47,49 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2.5f ;
			BoundingRadius = 1.25f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2546, 47 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.InfernoElemental, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}


/*Ironbark Protector id 11459*/



namespace Server.Creatures
{
	public class IronbarktheRedeemed: BaseCreature 
	 { 
		public  IronbarktheRedeemed() : base() 
		 { 
			Id = 14241;
			Model = 1461;
			AttackSpeed= 2000;
			Name = "Ironbark the Redeemed" ;
			Flags1 = 0x04;			 
			Level = RandomLevel( 58 );
			ResistArcane = Level*5;
			ResistFire = Level;
			ResistFrost = Level*5;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.218f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1f;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2976, 26 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.IronbarktheRedeemed, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class IronhandGuardian: BaseCreature 
	 { 
		public  IronhandGuardian() : base() 
		 { 
			Id = 8982;
			Model = 9189;
			AttackSpeed= 1600;
			Name = "Ironhand Guardian" ;
			Flags1 = 0x0306;			 
			Level = RandomLevel( 58 );
			ResistArcane = Level*5;
			ResistFire = Level;
			ResistFrost = Level*5;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.36f ;
			WalkSpeed = 3.36f ;
			RunSpeed = 6.36f ;			
			Size=1f;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2976, 26 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.IronhandGuardian, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class IrontreeStomper: BaseCreature 
	 { 
		public  IrontreeStomper() : base() 
		 { 
			Id = 7139;
			Model = 6351;
			AttackSpeed= 2000;
			Name = "Irontree Stomper" ;
			Level = RandomLevel( 52,53 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.65f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1.75f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2454, 52 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.IrontreeStomper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class IrontreeWanderer: BaseCreature 
	 { 
		public  IrontreeWanderer() : base() 
		 { 
			Id = 7138;
			Model = 2078;
			AttackSpeed= 2000;
			Name = "Irontree Wanderer" ;
			Level = RandomLevel( 52,53 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 4f ;
			BoundingRadius = 0.695f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=2f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2406, 52 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.IrontreeWanderer, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class IrradiatedHorror: BaseCreature 
	 { 
		public  IrradiatedHorror() : base() 
		 { 
			Id = 6220;
			Model = 4907;
			AttackSpeed= 2000;
			Name = "Irradiated Horror" ;
			Level = RandomLevel( 28,29 );
			ResistArcane = Level*5;
			ResistFire = Level;
			ResistFrost = Level*5;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.5f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Visible = InvisibilityLevel.Lesser;
			BCAddon.Hp( this, 2226, 28 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops.IrradiatedHorror, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LakeCreeper: BaseCreature 
	 { 
		public  LakeCreeper() : base() 
		 { 
			Id = 1955;
			Model = 2567;
			AttackSpeed= 2000;
			Name = "Lake Creeper" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 17,18 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.55f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 498, 17 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LakeCreeper, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LakeSkulker: BaseCreature 
	 { 
		public  LakeSkulker() : base() 
		 { 
			Id = 1953;
			Model = 863;
			AttackSpeed= 2000;
			Name = "Lake Skulker" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 15,16 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.3455f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 331, 15 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LakeSkulker, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LavaAnnihilator: BaseCreature 
	 { 
		public  LavaAnnihilator() : base() 
		 { 
			Id = 11665;
			Model = 12164;
			AttackSpeed= 1000;
			Name = "Lava Annihilator" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 60,62 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Visible = InvisibilityLevel.Lesser;
			BCAddon.Hp( this, 9165, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LavaAnnihilator, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LavaElemental: BaseCreature 
	 { 
		public  LavaElemental() : base() 
		 { 
			Id = 12076;
			Model = 5781;
			AttackSpeed= 2000;
			Name = "Lava Elemental" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 61,62 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 BaseMana = 9250;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			LearnSpell( 19641, SpellsTypes.Offensive );
			BCAddon.Hp( this, 9165, 61 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LavaElemental, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class LavaReaver: BaseCreature 
	 { 
		public  LavaReaver() : base() 
		 { 
			Id = 12100;
			Model = 12163;
			AttackSpeed= 2000;
			Name = "Lava Reaver" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 62 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 BaseMana = 9650;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			LearnSpell( 19642, SpellsTypes.Offensive );
			BCAddon.Hp( this, 9465, 62 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LavaReaver, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LavaSpawn: BaseCreature 
	 { 
		public  LavaSpawn() : base() 
		 { 
			Id = 12265;
			Model = 2172;
			AttackSpeed= 1000;
			Name = "Lava Spawn" ;
			Flags1 = 0x080800006;			 
			Level = RandomLevel( 59,60 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 BaseMana = 9250;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			LearnSpell( 18392, SpellsTypes.Offensive );
			LearnSpell( 19569, SpellsTypes.Defensive );
			BCAddon.Hp( this, 9250, 59 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LavaSpawn, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LavaSurger: BaseCreature 
	 { 
		public  LavaSurger() : base() 
		 { 
			Id = 12101;
			Model = 12239;
			AttackSpeed= 1000;
			Name = "Lava Surger" ;
			Flags1 = 0x080800000;			 
			Level = RandomLevel( 60,62 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 BaseMana = 9650;
			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			LearnSpell( 19196, SpellsTypes.Offensive );
			BCAddon.Hp( this, 9565, 59 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LavaSurger, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LesserRockElemental: BaseCreature 
	 { 
		public  LesserRockElemental() : base() 
		 { 
			Id = 2735;
			Model = 1161;
			AttackSpeed= 2000;
			Name = "Lesser Rock Elemental" ;
			Level = RandomLevel( 37,39 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 1.185f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.20f ;
			WalkSpeed = 3.20f ;
			RunSpeed = 6.20f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1252, 37 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LesserRockElemental, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LesserWaterElemental: BaseCreature 
	 { 
		public  LesserWaterElemental() : base() 
		 { 
			Id = 691;
			Model = 5561;
			AttackSpeed= 2000;
			Name = "Lesser Water Elemental" ;
			Flags1 = 0x010080000;
			Level = RandomLevel( 36,37 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.609f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.20f ;
			WalkSpeed = 3.20f ;
			RunSpeed = 6.20f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1270, 6036 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LesserWaterElemental, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LivingBlaze: BaseCreature 
	 { 
		public  LivingBlaze() : base() 
		 { 
			Id = 6521;
			Model = 5488;
			AttackSpeed= 2000;
			Name = "Living Blaze" ;
			Level = RandomLevel( 54,55 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2.5f ;
			BoundingRadius = 1.25f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3081, 54 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LivingBlaze, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LivingStorm: BaseCreature 
	 { 
		public  LivingStorm() : base() 
		 { 
			Id = 9397;
			Model = 8716;
			AttackSpeed= 1300;
			Name = "Living Storm" ;
			Level = RandomLevel( 47,49 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2081, 47 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LivingStorm, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LokholartheIceLord: BaseCreature 
	 { 
		public  LokholartheIceLord() : base() 
		 { 
			Id = 13256;
			Model = 13174;
			AttackSpeed= 2000;
			Name = "Lokholar the Ice Lord" ;
			Flags1 = 0x080C01000;			 
			Level = RandomLevel( 63 );
			ResistArcane = Level*8;
			ResistFire = Level*8;
			ResistFrost = Level*10;
			ResistHoly = Level*8;
			ResistNature = Level*8;
			ResistShadow = Level*8;
			Str = (int)(Level*6.75f);
			NpcType = 4;
			Armor= Level*52;
			ManaType=0;
			Block=Level+50;
			NpcFlags = 0;
			CombatReach = 4.5f ;
			BoundingRadius = 4.167f ;
			SetDamage(1f+5.5f*Level,1f+6.5*Level);			
			Elite = 3;
			Speed = 4.16f ;
			WalkSpeed = 4.16f ;
			RunSpeed = 7.16f ;			
			Size=3f;
			Faction = Factions.Monster;
			AIEngine = new StandingNpcAI( this );
			BCAddon.Hp( this, 77671, 63 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LokholartheIceLord, 100f ),
								new BaseTreasure(DropsME.MoneyBoss, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LordIncendius: BaseCreature 
	 { 
		public  LordIncendius() : base() 
		 { 
			Id = 9017;
			Model = 1204;
			AttackSpeed= 1000;
			Name = "Lord Incendius" ;
			Flags1 = 0x01000;			 
			Level = RandomLevel( 55,56 );
			ResistArcane = Level;
			ResistFire = Level*5;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 BaseHitPoints = 9565;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 1.5f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			LearnSpell( 19196, SpellsTypes.Offensive );
			BCAddon.Hp( this, 9565, 55 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LordIncendius, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class LordRoccor: BaseCreature 
	 { 
		public  LordRoccor() : base() 
		 { 
			Id = 9025;
			Model = 5781;
			AttackSpeed= 1100;
			Name = "Lord Roccor" ;
			Flags1 = 0x01000;			 
			Level = RandomLevel( 51 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*10;
			Str = (int)(Level*5.75f);
			NpcType = 4;
			Armor= Level*42;
			ManaType=0;
			Block=Level+40;
 
			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.5f ;
			SetDamage(1f+4.8f*Level,1f+5.5*Level);			
			Elite = 2;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7671, 51 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.LordRoccor, 100f ),
								new BaseTreasure(DropsME.MoneyElite2, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class MagmaElemental: BaseCreature 
	 { 
		public  MagmaElemental() : base() 
		 { 
			Id = 5855;
			Model = 2075;
			AttackSpeed= 1300;
			Name = "Magma Elemental" ;
			Level = RandomLevel( 46,48 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.4f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2013, 46 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MagmaElemental, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




/*Magmakin id 12806*/



namespace Server.Creatures
{
	public class MalfunctioningReaver: BaseCreature 
	 { 
		public  MalfunctioningReaver() : base() 
		 { 
			Id = 8981;
			Model = 10802;
			AttackSpeed= 1200;
			Name = "Malfunctioning Reaver" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 55 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*6;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 16f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.88f ;
			WalkSpeed = 3.88f ;
			RunSpeed = 6.88f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 8917, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MalfunctioningReaver, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}


/*Mana Burst id 14397 */




namespace Server.Creatures
{
	public class ManaRemnant: BaseCreature 
	 { 
		public  ManaRemnant() : base() 
		 { 
			Id = 11483;
			Model = 14272;
			AttackSpeed= 2000;
			Name = "Mana Remnant" ;
			Level = RandomLevel( 57,59 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
			BaseMana = 10585;
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4.1f ;
			WalkSpeed = 4.1f ;
			RunSpeed = 7.1f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			LearnSpell( 19196, SpellsTypes.Offensive );
			BCAddon.Hp( this, 9565, 55 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.ManaRemnant, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class ManaSurge: BaseCreature 
	 { 
		public  ManaSurge() : base() 
		 { 
			Id = 6550;
			Model = 14252;
			AttackSpeed= 1300;
			Name = "Mana Surge" ;
			Flags1 = 0x04;
			Level = RandomLevel( 40 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.4f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2013, 40 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.ManaSurge, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ManifestationofWater: BaseCreature 
	 { 
		public  ManifestationofWater() : base() 
		 { 
			Id = 11256;
			Model = 13444;
			AttackSpeed= 1000;
			Name = "Manifestation of Water" ;
			Flags1 = 0x066;			 
			Level = RandomLevel( 60 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=2.2f;
			Faction = Factions.Friend;
			//NpcText00="I am Hydraxis, Duke of the Waterlords.  You are not an elemental and so cannot understand our struggle, but perhaps we can strike a deal that will benefit us both...";
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 9929, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.ManifestationofWater, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class MesaEarthSpirit: BaseCreature 
	 { 
		public  MesaEarthSpirit() : base() 
		 { 
			Id = 5889;
			Model = 1128;
			AttackSpeed= 2000;
			Name = "Mesa Earth Spirit" ;
			Flags1 = 0x0266;
			Level = RandomLevel( 1 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 90, 1 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MesaEarthSpirit, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class MeshloktheHarvester: BaseCreature 
	 { 
		public  MeshloktheHarvester() : base() 
		 { 
			Id = 12237;
			Model = 9014;
			AttackSpeed= 1600;
			Name = "Meshlok the Harvester" ;
			Level = RandomLevel( 48 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*10;
			Str = (int)(Level*5.75f);
			NpcType = 4;
			Armor= Level*42;
			ManaType=0;
			Block=Level+40;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+4.8f*Level,1f+5.5*Level);			
			Elite = 2;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed = 6.5f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7671, 48 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MeshloktheHarvester, 100f ),
								new BaseTreasure(DropsME.MoneyElite2, 100f )};
		}
	}	
}


/*Minor Manifestation of Air id 5902*/



namespace Server.Creatures
{
	public class MinorManifestationofEarth: BaseCreature 
	 { 
		public  MinorManifestationofEarth() : base() 
		 { 
			Id = 5891;
			Model = 12110;
			AttackSpeed= 1500;
			Name = "Minor Manifestation of Earth" ;
			Flags1 = 0x066;
			Level = RandomLevel( 13,15 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 4.5f ;
			BoundingRadius = 4.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;			
			Size=3f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 390, 13 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MinorManifestationofEarth, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class MinorManifestationofFire: BaseCreature 
	 { 
		public  MinorManifestationofFire() : base() 
		 { 
			Id = 5893;
			Model = 2172;
			AttackSpeed= 2000;
			Name = "Minor Manifestation of Fire" ;
			Flags1 = 0x02;
			Level = RandomLevel( 12 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.75f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;			
			Size=0.75f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 350, 12 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MinorManifestationofFire, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class MinorManifestationofWater: BaseCreature 
	 { 
		public  MinorManifestationofWater() : base() 
		 { 
			Id = 5895;
			Model = 525;
			AttackSpeed= 2000;
			Name = "Minor Manifestation of Water" ;
			Flags1 = 0x066;
			Level = RandomLevel( 13,15 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level*2;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.27f ;
			BoundingRadius = 0.51f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 390, 13 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MinorManifestationofWater, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class MinorWaterGuardian: BaseCreature 
	 { 
		public  MinorWaterGuardian() : base() 
		 { 
			Id = 3950;
			Model = 4606;
			AttackSpeed= 2000;
			Name = "Minor Water Guardian" ;
			Flags1 = 0x0C006;
			Level = RandomLevel( 1 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 90, 1 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MinorWaterGuardian, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class MireLord: BaseCreature 
	 { 
		public  MireLord() : base() 
		 { 
			Id = 1081;
			Model = 9010;
			AttackSpeed= 1300;
			Name = "Mire Lord" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 42 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2151, 42 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MireLord, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Mirelow: BaseCreature 
	 { 
		public  Mirelow() : base() 
		 { 
			Id = 14424 ;
			Model = 631;
			AttackSpeed= 2000;
			Name = "Blackmoss the Fetid" ;
			Flags1 = 0x0800000;			 
			Level = RandomLevel( 25 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.7485f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1917, 25 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.Mirelow, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class MoltThorn: BaseCreature 
	 { 
		public  MoltThorn() : base() 
		 { 
			Id = 14448 ;
			Model = 14497;
			AttackSpeed= 2000;
			Name = "Blackmoss the Fetid" ;
			Flags1 = 0x0800000;			 
			Level = RandomLevel( 42 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.7485f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4917, 42 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MoltThorn, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class MoltenElemental: BaseCreature 
	 { 
		public  MoltenElemental() : base() 
		 { 
			Id = 11321;
			Model = 2075;
			AttackSpeed= 2000;
			Name = "Molten Elemental" ;
			Level = RandomLevel( 13,15 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.390f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed = 6.5f ;			
			Size=2.2f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 886, 13 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MoltenElemental, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class MoltenWarGolem: BaseCreature 
	 { 
		public  MoltenWarGolem() : base() 
		 { 
			Id = 8908;
			Model = 8179;
			AttackSpeed= 1100;
			Name = "Molten War Golem" ;
			Flags1 = 0x066;			 
			Level = RandomLevel( 55,56 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1f;
			BCAddon.Hp( this, 8929, 55 );
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MoltenWarGolem, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class MuckSplash: BaseCreature 
	 { 
		public  MuckSplash() : base() 
		 { 
			Id = 8837;
			Model = 5561;
			AttackSpeed= 2000;
			Name = "Muck Splash" ;
			Level = RandomLevel( 47,49 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 0.609f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2151, 47 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.MuckSplash, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}


/*Mushgog id 11447*/


namespace Server.Creatures
{
	public class Myzrael: BaseCreature 
	 { 
		public  Myzrael() : base() 
		 { 
			Id = 2755;
			Model = 1165;
			AttackSpeed= 1100;
			Name = "Myzrael" ;
			Level = RandomLevel( 44,50 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*6;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1f;
			BCAddon.Hp( this, 4699, 44 );
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.Myzrael, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Noxxion: BaseCreature 
	 { 
		public  Noxxion() : base() 
		 { 
			Id = 13282;
			Model = 11172;
			AttackSpeed= 2000;
			Name = "Noxxion" ;
			Flags1 = 0x01000;			 
			Level = RandomLevel( 48 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=2f;
			Faction = Factions.Monster;
			BCAddon.Hp( this, 4699, 48 );
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.Noxxion, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class NoxxionsSpawn: BaseCreature 
	 { 
		public  NoxxionsSpawn() : base() 
		 { 
			Id = 13456;
			Model = 5492;
			AttackSpeed= 2000;
			Name = "Noxxion's Spawn" ;
			Level = RandomLevel( 43,46 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.05f ;
			BoundingRadius = 0.35f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=0.7f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2151, 43 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.NoxxionsSpawn, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class NoxxiousEssence: BaseCreature 
	 { 
		public  NoxxiousEssence() : base() 
		 { 
			Id = 13736;
			Model = 13732;
			AttackSpeed= 2000;
			Name = "Noxxious Essence" ;
			Level = RandomLevel( 45,46 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3509, 45 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.NoxxiousEssence, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class NoxxiousScion: BaseCreature 
	 { 
		public  NoxxiousScion() : base() 
		 { 
			Id = 13696;
			Model = 13749;
			AttackSpeed= 1200;
			Name = "Noxxious Scion" ;
			Level = RandomLevel( 46 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1f;
			Faction = Factions.Monster;
			BCAddon.Hp( this, 6500, 46 );
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.NoxxiousScion, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Oakenscowl: BaseCreature 
	 { 
		public  Oakenscowl() : base() 
		 { 
			Id = 2166;
			Model = 2567;
			AttackSpeed= 2700;
			Name = "Oakenscowl" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 9 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*3;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.54f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.46f ;
			WalkSpeed = 3.46f ;
			RunSpeed = 6.46f ;			
			Size=1.15f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 545, 9 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.Oakenscowl, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 50f )};
		}
	}	
}



namespace Server.Creatures
{
	public class ObsidianElemental: BaseCreature 
	 { 
		public  ObsidianElemental() : base() 
		 { 
			Id = 7031;
			Model = 2075;
			AttackSpeed= 2000;
			Name = "Obsidian Elemental" ;
			Level = RandomLevel( 51,53 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.389f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2676, 51 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.ObsidianElemental, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Obsidion: BaseCreature 
	 { 
		public  Obsidion() : base() 
		 { 
			Id = 8400;
			Model = 13929;
			AttackSpeed= 2000;
			Name = "Obsidion" ;
			Flags1 = 0x020;			 
			Level = RandomLevel( 52 );
			ResistArcane = Level*2;
			ResistFire = Level*4;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*3;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 4.5f ;
			BoundingRadius = 3.09f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=3f;
			Faction = Factions.Monster;
			BCAddon.Hp( this, 7545, 52 );
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.Obsidion, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class OldIronbark: BaseCreature 
	 { 
		public  OldIronbark() : base() 
		 { 
			Id = 11491;
			Model = 13170;
			AttackSpeed= 2000;
			Name = "Old Ironbark" ;
			Level = RandomLevel( 58 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.58f ;
			WalkSpeed = 3.58f ;
			RunSpeed = 6.58f ;			
			Size=1f;
			Faction = Factions.Friend;
			//NpcText00="I am Hydraxis, Duke of the Waterlords.  You are not an elemental and so cannot understand our struggle, but perhaps we can strike a deal that will benefit us both...";
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2929, 58 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.OldIronbark, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class OvermasterPyron: BaseCreature 
	 { 
		public  OvermasterPyron() : base() 
		 { 
			Id = 9026;
			Model = 1070;
			AttackSpeed= 1600;
			Name = "Overmaster Pyron" ;
			Level = RandomLevel( 52 );
			ResistArcane = Level*2;
			ResistFire = Level*4;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*3;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.97f ;
			WalkSpeed = 3.97f ;
			RunSpeed = 6.97f ;			
			Size=3f;
			Faction = Factions.Monster;
			BCAddon.Hp( this, 7545, 52 );
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.OvermasterPyron, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class PanzortheInvincible: BaseCreature 
	 { 
		public  PanzortheInvincible() : base() 
		 { 
			Id = 8923;
			Model = 8270;
			AttackSpeed= 2000;
			Name = "Panzor the Invincible" ;
			Level = RandomLevel( 57 );
			ResistArcane = Level*8;
			ResistFire = Level*10;
			ResistFrost = Level*8;
			ResistHoly = Level*8;
			ResistNature = Level*8;
			ResistShadow = Level*8;
			Str = (int)(Level*5.75f);
			NpcType = 4;
			Armor= Level*42;
			ManaType=0;
			Block=Level+40;

			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+4.8f*Level,1f+5.5*Level);			
			Elite = 2;
			Speed = 4.16f ;
			WalkSpeed = 4.16f ;
			RunSpeed = 7.16f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 8671, 57 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PanzortheInvincible, 100f ),
								new BaseTreasure(DropsME.MoneyElite2, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class PetrifiedGuardian: BaseCreature 
	 { 
		public  PetrifiedGuardian() : base() 
		 { 
			Id = 14303;
			Model = 5848;
			AttackSpeed= 2000;
			Name = "Petrified Guardian" ;
			Level = RandomLevel( 57,59 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*4;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.97f ;
			WalkSpeed = 3.97f ;
			RunSpeed = 6.97f ;			
			Size=1f;
			Faction = Factions.Monster;
			BCAddon.Hp( this, 8245, 57 );
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PetrifiedGuardian, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class PetrifiedTreant: BaseCreature 
	 { 
		public  PetrifiedTreant() : base() 
		 { 
			Id = 11458;
			Model = 2078;
			AttackSpeed= 2000;
			Name = "Petrified Treant" ;
			Level = RandomLevel( 57,59 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*4;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.97f ;
			WalkSpeed = 3.97f ;
			RunSpeed = 6.97f ;			
			Size=1f;
			BCAddon.Hp( this, 8245, 57 );
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PetrifiedTreant, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Phalanx: BaseCreature 
	 { 
		public  Phalanx() : base() 
		 { 
			Id = 9502;
			Model = 8177;
			AttackSpeed= 2000;
			Name = "Phalanx" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 55 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = (int)NpcActions.Dialog;
			CombatReach = 2.25f ;
			BoundingRadius = 2.25f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1.5f;
			Faction = Factions.Alliance;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4929, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Phalanx, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class PhaseLasher: BaseCreature 
	 { 
		public  PhaseLasher() : base() 
		 { 
			Id = 13196;
			Model = 13109;
			AttackSpeed= 2000;
			Name = "Phase Lasher" ;
			Level = RandomLevel( 54,55 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.97f ;
			WalkSpeed = 3.97f ;
			RunSpeed = 6.97f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 8245, 54 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PhaseLasher, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class PlagueMonstrosity: BaseCreature 
	 { 
		public  PlagueMonstrosity() : base() 
		 { 
			Id = 8522;
			Model = 11172;
			AttackSpeed= 1200;
			Name = "Plague Monstrosity" ;
			Flags1 = 0x010080000;
			Level = RandomLevel( 57,58 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.00f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.36f ;
			WalkSpeed = 3.36f ;
			RunSpeed = 6.36f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2676, 57 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PlagueMonstrosity, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class PlagueRavager: BaseCreature 
	 { 
		public  PlagueRavager() : base() 
		 { 
			Id = 8520;
			Model = 5563;
			AttackSpeed= 1200;
			Name = "Plague Ravager" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 55,56 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.00f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3730, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PlagueRavager, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class PrinceThunderaan: BaseCreature 
	 { 
		public  PrinceThunderaan() : base() 
		 { 
			Id = 14435;
			Model = 5234;
			AttackSpeed= 1200;
			Name = "Prince Thunderaan" ;
			Guild = "The Wind Seeker";
			Flags1 = 0x080000;
			Level = RandomLevel( 62 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*35;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.00f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 9730, 62 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PlagueRavager, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}


/*Princess Tempestria id 14457 */



namespace Server.Creatures
{
	public class PrincessTheradras: BaseCreature 
	 { 
		public  PrincessTheradras() : base() 
		 { 
			Id = 12201;
			Model = 12292;
			AttackSpeed= 2000;
			Name = "Princess Theradras" ;
			Flags1 = 0x080801000;
			Level = RandomLevel( 51 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.95f ;
			WalkSpeed = 3.95f ;
			RunSpeed = 6.95f ;			
			Size=2f;
			BCAddon.Hp( this, 4438, 51 );
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PrincessTheradras, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class PrismaticExile: BaseCreature 
	 { 
		public  PrismaticExile() : base() 
		 { 
			Id = 2887;
			Model = 9588;
			AttackSpeed= 1400;
			Name = "Prismatic Exile" ;
			Flags1 = 0x04;
			Level = RandomLevel( 38,43 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1.00f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.22f ;
			WalkSpeed = 3.22f ;
			RunSpeed = 6.22f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 2430, 38 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PrismaticExile, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class PyroguardEmberseer: BaseCreature 
	 { 
		public  PyroguardEmberseer() : base() 
		 { 
			Id = 9816;
			Model = 2172;
			AttackSpeed= 1000;
			Name = "Pyroguard Emberseer" ;
			Flags1 = 0x0801000;			 
			Level = RandomLevel( 63 );
			ResistArcane = Level*8;
			ResistFire = Level*10;
			ResistFrost = Level*8;
			ResistHoly = Level*8;
			ResistNature = Level*8;
			ResistShadow = Level*8;
			Str = (int)(Level*6.75f);
			NpcType = 4;
			Armor= Level*52;
			ManaType=0;
			Block=Level+50;

			NpcFlags = 0;
			CombatReach = 21.0f ;
			BoundingRadius = 1f ;
			SetDamage(1f+5.5f*Level,1f+6.5*Level);			
			Elite = 3;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=3f;
			Faction = Factions.Monster;
			AIEngine = new StandingNpcAI( this );
			BCAddon.Hp( this, 75698, 63 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.PyroguardEmberseer, 100f ),
								new BaseTreasure(DropsME.MoneyBoss, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class RagereaverGolem: BaseCreature 
	 { 
		public  RagereaverGolem() : base() 
		 { 
			Id = 8906;
			Model = 8177;
			AttackSpeed= 1100;
			Name = "Ragereaver Golem" ;
			Flags1 = 0x080801000;
			Level = RandomLevel( 54,55 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.95f ;
			WalkSpeed = 3.95f ;
			RunSpeed = 6.95f ;			
			Size=1f;
			Faction = Factions.Monster;
			BCAddon.Hp( this, 7438, 54 );
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RagereaverGolem, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Ragnaros: BaseCreature 
	 { 
		public  Ragnaros() : base() 
		 { 
			Id = 11502;
			Model = 11121;
			AttackSpeed= 1000;
			Name = "Ragnaros" ;
			Flags1 = 0x0801000;			 
			Level = RandomLevel( 63 );
			ResistArcane = Level*8;
			ResistFire = Level*10;
			ResistFrost = Level*8;
			ResistHoly = Level*8;
			ResistNature = Level*8;
			ResistShadow = Level*8;
			Str = (int)(Level*6.75f);
			NpcType = 4;
			Armor= Level*52;
			ManaType=0;
			Block=Level+50;
			NpcFlags = 0;
			CombatReach = 21.0f ;
			BoundingRadius = 1f ;
			SetDamage(1f+5.5f*Level,1f+6.5*Level);			
			Elite = 3;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=3f;
			Faction = Factions.Monster;
			AIEngine = new StandingNpcAI( this );
			BCAddon.Hp( this, 75698, 63 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.Ragnaros, 100f ),
								new BaseTreasure(DropsME.MoneyBoss, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Raze: BaseCreature 
	 { 
		public  Raze() : base() 
		 { 
			Id = 8441;
			Model = 10905;
			AttackSpeed= 2000;
			Name = "Raze" ;
			Guild="Nilith's Guardian";
			Flags1 = 0x046;
			Level = RandomLevel( 48 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = (int)NpcActions.Dialog;
			CombatReach = 2.9f ;
			BoundingRadius = 1.30f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.28f ;
			WalkSpeed = 3.28f ;
			RunSpeed = 6.28f ;			
			Size=1.45f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 3430, 48 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Raze, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class RedrockEarthSpirit: BaseCreature 
	 { 
		public  RedrockEarthSpirit() : base() 
		 { 
			Id = 5890;
			Model = 1128;
			AttackSpeed= 2000;
			Name = "Redrock Earth Spirit" ;
			Flags1 = 0x0266;
			Level = RandomLevel( 1 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 0.75f ;
			BoundingRadius = 0.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=0.5f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 90, 1 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RedrockEarthSpirit, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}
		




namespace Server.Creatures
{
	public class ResidualMonstrosity: BaseCreature 
	 { 
		public  ResidualMonstrosity() : base() 
		 { 
			Id = 11484;
			Model = 14254;
			AttackSpeed= 2000;
			Name = "Residual Monstrosity" ;
			Level = RandomLevel( 59,60 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.95f ;
			WalkSpeed = 3.95f ;
			RunSpeed = 6.95f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7438, 59 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ResidualMonstrosity, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class RethieltheGreenwarden: BaseCreature 
	 { 
		public  RethieltheGreenwarden() : base() 
		 { 
			Id = 1244;
			Model = 480;
			AttackSpeed= 3000;
			Name = "Rethiel the Greenwarden" ;
			Flags1 = 0x08480046;
			Level = RandomLevel( 30 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 3f ;
			BoundingRadius = 2.69f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.14f ;
			WalkSpeed = 3.14f ;
			RunSpeed = 6.14f ;			
			Size=2f;
			BCAddon.Hp( this, 1045, 30 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Alliance;
			AIEngine = new PredatorAI( this );			BCAddon.Hp( this, 2929, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RethieltheGreenwarden, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class RiftSpawn: BaseCreature 
	 { 
		public  RiftSpawn() : base() 
		 { 
			Id = 6492;
			Model = 14273;
			AttackSpeed= 2000;
			Name = "Rift Spawn" ;
			Flags1 = 0x0C;
			Level = RandomLevel( 16,17 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 1.25f ;
			BoundingRadius = 0.175f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=0.5f;
			BCAddon.Hp( this, 545, 16 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RiftSpawn, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class RockElemental: BaseCreature 
	 { 
		public  RockElemental() : base() 
		 { 
			Id = 92;
			Model = 171;
			AttackSpeed= 2000;
			Name = "Rock Elemental" ;
			Level = RandomLevel( 39,40 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 1.5f ;
			BoundingRadius = 1.4f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1f;
			BCAddon.Hp( this, 1442, 39 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RockElemental, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class RogueFlameSpirit: BaseCreature 
	 { 
		public  RogueFlameSpirit() : base() 
		 { 
			Id = 4036;
			Model = 4607;
			AttackSpeed= 2000;
			Name = "Rogue Flame Spirit" ;
			Level = RandomLevel( 23,24 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1f ;
			BoundingRadius = 0.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=0.5f;
			BCAddon.Hp( this, 530, 23 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RogueFlameSpirit, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class RokAlimthePounder: BaseCreature 
	 { 
		public  RokAlimthePounder() : base() 
		 { 
			Id = 4499;
			Model = 4766;
			AttackSpeed= 2000;
			Name = "Rok'Alim the Pounder" ;
			Level = RandomLevel( 30 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 1.18f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=0.85f;
			BCAddon.Hp( this, 2434, 30 );
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RokAlimthePounder, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class RottingBehemoth: BaseCreature 
	 { 
		public  RottingBehemoth() : base() 
		 { 
			Id = 1812;
			Model = 8389;
			AttackSpeed= 2000;
			Name = "Rotting Behemoth" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 55,56 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1f;
			BCAddon.Hp( this, 3532, 55 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RottingBehemoth, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Rumbler: BaseCreature 
	 { 
		public  Rumbler() : base() 
		 { 
			Id = 2752;
			Model = 8550;
			AttackSpeed= 1800;
			Name = "Rumbler" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 45 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 16f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.27f ;
			WalkSpeed = 3.27f ;
			RunSpeed = 6.27f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4917, 45 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Rumbler, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class RumblingExile: BaseCreature 
	 { 
		public  RumblingExile() : base() 
		 { 
			Id = 2592;
			Model = 9587;
			AttackSpeed= 2000;
			Name = "Rumbling Exile" ;
			Level = RandomLevel( 38,39 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.27f ;
			BoundingRadius = 1.18f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=0.85f;
			BCAddon.Hp( this, 1348, 38 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.RumblingExile, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class SandStorm: BaseCreature 
	 { 
		public  SandStorm() : base() 
		 { 
			Id = 7226;
			Model = 11686;
			AttackSpeed= 4000;
			Name = "Sand Storm" ;
			Flags1 = 0x020E;
			Level = RandomLevel( 46 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1f ;
			BoundingRadius = 0.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1f;
			BCAddon.Hp( this, 1948, 46 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SandStorm, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class Scald: BaseCreature 
	 { 
		public  Scald() : base() 
		 { 
			Id = 8281;
			Model = 1204;
			AttackSpeed= 1200;
			Name = "Scald" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 49 );
			ResistArcane = Level*6;
			ResistFire = Level*6;
			ResistFrost = Level*6;
			ResistHoly = Level*6;
			ResistNature = Level*6;
			ResistShadow = Level*6;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 16f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;
			RunSpeed = 6.8f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4917, 49 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Scald, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class ScaldingElemental: BaseCreature 
	 { 
		public  ScaldingElemental() : base() 
		 { 
			Id = 10756;
			Model = 5562;
			AttackSpeed= 3000;
			Name = "Scalding Elemental" ;
			Flags1 = 0x010080000;
			Level = RandomLevel( 28,29 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.72f ;
			BoundingRadius = 0.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			BCAddon.Hp( this, 855, 28 );
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ScaldingElemental, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class ScorchingElemental: BaseCreature 
	 { 
		public  ScorchingElemental() : base() 
		 { 
			Id = 6520;
			Model = 1070;
			AttackSpeed= 2000;
			Name = "Scorching Elemental" ;
			Level = RandomLevel( 53,54 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 2f;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1f;
			BCAddon.Hp( this, 2301, 53 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ScorchingElemental, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class SeaElemental: BaseCreature 
	 { 
		public  SeaElemental() : base() 
		 { 
			Id = 5461;
			Model = 5450;
			AttackSpeed= 2000;
			Name = "Sea Elemental" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 48,49 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 0.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			BCAddon.Hp( this, 1931, 48 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SeaElemental, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class SeaSpray: BaseCreature 
	 { 
		public  SeaSpray() : base() 
		 { 
			Id = 5462;
			Model = 5562;
			AttackSpeed= 2000;
			Name = "Sea Spray" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 47,48 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 0.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.15f;
			BCAddon.Hp( this, 1889, 47 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SeaSpray, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class SeekerAqualon: BaseCreature 
	 { 
		public  SeekerAqualon() : base() 
		 { 
			Id = 14269;
			Model = 525;
			AttackSpeed= 2000;
			Name = "Seeker Aqualon" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 21 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 1.7485f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.41f ;
			WalkSpeed = 3.41f ;
			RunSpeed = 6.41f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1917, 21 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SeekerAqualon, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ShadethicketBarkRipper: BaseCreature 
	 { 
		public  ShadethicketBarkRipper() : base() 
		 { 
			Id = 3784;
			Model = 2024;
			AttackSpeed= 2000;
			Name = "Shadethicket Bark Ripper" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 26,27 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 1.74f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.3f;
			BCAddon.Hp( this, 856, 26 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadethicketBarkRipper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ShadethicketMossEater: BaseCreature 
	 { 
		public  ShadethicketMossEater() : base() 
		 { 
			Id = 3780;
			Model = 168;
			AttackSpeed= 1700;
			Name = "Shadethicket Moss Eater" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 21,23 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.0f;
			BCAddon.Hp( this, 585, 21 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadethicketMossEater, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ShadethicketOracle: BaseCreature 
	 { 
		public  ShadethicketOracle() : base() 
		 { 
			Id = 3931;
			Model = 1549;
			AttackSpeed= 2000;
			Name = "Shadethicket Oracle" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 30 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 1.74f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.14f ;
			WalkSpeed = 3.14f ;
			RunSpeed = 6.14f ;			
			Size=1.3f;
			BCAddon.Hp( this, 1083, 30 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadethicketOracle, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ShadethicketRaincaller: BaseCreature 
	 { 
		public  ShadethicketRaincaller() : base() 
		 { 
			Id = 3783;
			Model = 2023;
			AttackSpeed= 2000;
			Name = "Shadethicket Raincaller" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 22,23 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.725f;
			BoundingRadius = 1.54f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.15f;
			BCAddon.Hp( this, 516, 22 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadethicketRaincaller, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ShadethicketWoodShaper: BaseCreature 
	 { 
		public  ShadethicketWoodShaper() : base() 
		 { 
			Id = 3781;
			Model = 2022;
			AttackSpeed= 2000;
			Name = "Shadethicket Wood Shaper" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 22,23 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.5f;
			BoundingRadius = 1.35f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.15f;
			BCAddon.Hp( this, 516, 22 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadethicketWoodShaper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class ShadowshardRumbler: BaseCreature 
	 { 
		public  ShadowshardRumbler() : base() 
		 { 
			Id = 11777;
			Model = 11710;
			AttackSpeed= 2000;
			Name = "Shadowshard Rumbler" ;
			Level = RandomLevel( 40,41 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 1.25f ;
			BoundingRadius = 1.9f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;
			RunSpeed = 6.8f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4576, 40 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadowshardRumbler, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class ShadowshardSmasher: BaseCreature 
	 { 
		public  ShadowshardSmasher() : base() 
		 { 
			Id = 11778;
			Model = 11710;
			AttackSpeed= 2000;
			Name = "Shadowshard Smasher" ;
			Level = RandomLevel( 41,42 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.25f ;
			BoundingRadius = 1.9f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4976, 41 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadowshardSmasher, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class SiegeGolem: BaseCreature 
	 { 
		public  SiegeGolem() : base() 
		 { 
			Id = 2749;
			Model = 13869;
			AttackSpeed= 1100;
			Name = "Siege Golem" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 40 );
			ResistArcane = Level*8;
			ResistFire = Level*8;
			ResistFrost = Level*8;
			ResistHoly = Level*8;
			ResistNature = Level*8;
			ResistShadow = Level*8;
			Str = (int)(Level*5.75f);
			NpcType = 4;
			Armor= Level*42;
			ManaType=0;
			Block=Level+40;

			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 2.25f ;
			SetDamage(1f+4.8f*Level,1f+5.5*Level);			
			Elite = 2;
			Speed = 4.16f ;
			WalkSpeed = 4.16f ;
			RunSpeed = 7.16f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 6671, 40 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SiegeGolem, 100f ),
								new BaseTreasure(DropsME.MoneyElite2, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Smoldar: BaseCreature 
	 { 
		public  Smoldar() : base() 
		 { 
			Id = 8278;
			Model = 5781;
			AttackSpeed= 2000;
			Name = "Smoldar" ;
			Level = RandomLevel( 50 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.725f ;
			BoundingRadius = 1.5485f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;
			RunSpeed = 6.8f ;			
			Size=1.15f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 6917, 50 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Smoldar, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class SonofFlame: BaseCreature 
	 { 
		public  SonofFlame() : base() 
		 { 
			Id = 12143;
			Model = 1204;
			AttackSpeed= 2000;
			Name = "Son of Flame" ;
			Level = RandomLevel( 60 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.25f ;
			BoundingRadius = 1.9f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 7680, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ShadowshardSmasher, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class StoneBehemoth: BaseCreature 
	 { 
		public  StoneBehemoth() : base() 
		 { 
			Id = 2157;
			Model = 473;
			AttackSpeed= 2000;
			Name = "Stone Behemoth" ;
			Level = RandomLevel( 19,20 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.5f;
			BoundingRadius = 1.035f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.0f ;
			WalkSpeed = 3.0f ;
			RunSpeed = 6.0f ;			
			Size=1.15f;
			BCAddon.Hp( this, 357, 19 );
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 357, 19 );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.StoneBehemoth, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class StoneFury: BaseCreature 
	 { 
		public  StoneFury() : base() 
		 { 
			Id = 2258;
			Model = 1162;
			AttackSpeed= 1500;
			Name = "Stone Fury" ;
			Level = RandomLevel( 37 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 16f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3917, 37 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.StoneFury, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class StoneGolem: BaseCreature 
	 { 
		public  StoneGolem() : base() 
		 { 
			Id = 2723;
			Model = 10804;
			AttackSpeed= 1500;
			Name = "Stone Golem" ;
			Level = RandomLevel( 38,39 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.0f;
			BCAddon.Hp( this, 1650, 38 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.StoneGolem, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class StoneGuardian: BaseCreature 
	 { 
		public  StoneGuardian() : base() 
		 { 
			Id = 6560;
			Model = 8395;
			AttackSpeed= 2000;
			Name = "Stone Guardian" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 60,61 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 3f;
			BoundingRadius = 2.06f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=0;
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;			
			Size=2f;
			Faction = Factions.NoFaction;
			BCAddon.Hp( this, 7650, 60 );
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.StoneGuardian, 100f ),
									new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class StoneKeeper: BaseCreature 
	 { 
		public  StoneKeeper() : base() 
		 { 
			Id = 4857;
			Model = 10805;
			AttackSpeed= 2800;
			Name = "Stone Keeper" ;
			Level = RandomLevel( 46 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2.625f ;
			BoundingRadius = 1.8f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.9f ;
			WalkSpeed = 3.9f ;
			RunSpeed = 6.9f ;			
			Size=1.75f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4576, 46 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.StoneKeeper, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class StoneRumbler: BaseCreature 
	 { 
		public  StoneRumbler() : base() 
		 { 
			Id = 4528;
			Model = 9589;
			AttackSpeed= 2000;
			Name = "Stone Rumbler" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 21 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.05f ;
			BoundingRadius = 0.9f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.64f ;
			WalkSpeed = 3.64f ;
			RunSpeed = 6.64f ;			
			Size=0.7f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2576, 21 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.StoneRumbler, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class StoneSteward: BaseCreature 
	 { 
		public  StoneSteward() : base() 
		 { 
			Id = 4860;
			Model = 2234;
			AttackSpeed= 2000;
			Name = "Stone Steward" ;
			Level = RandomLevel( 43,44 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.03f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.87f ;
			WalkSpeed = 3.87f ;
			RunSpeed = 6.87f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2576, 43 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.StoneSteward, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class SummonedGuardian: BaseCreature 
	 { 
		public  SummonedGuardian() : base() 
		 { 
			Id = 2794;
			Model = 4606;
			AttackSpeed= 2000;
			Name = "Summoned Guardian" ;
			Level = RandomLevel( 38 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.05f ;
			BoundingRadius = 0.42f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;
			RunSpeed = 6.8f ;			
			Size=0.7f;
			Faction = Factions.Alliance;
			AIEngine = new StandingGuardAI( this ); 
			BCAddon.Hp( this, 2929, 38 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SummonedGuardian, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class SummonedWaterElemental: BaseCreature 
	 { 
		public  SummonedWaterElemental() : base() 
		 { 
			Id = 10955;
			Model = 4606;
			AttackSpeed= 1500;
			Name = "Summoned Water Elemental" ;
			Flags1 = 0x06;
			Level = RandomLevel( 55,60 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.36f ;
			WalkSpeed = 3.36f ;
			RunSpeed = 6.36f ;			
			Size=1.0f;
			BCAddon.Hp( this, 3650, 55 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SummonedWaterElemental, 100f ),
									new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class SwampSpirit: BaseCreature 
	 { 
		public  SwampSpirit() : base() 
		 { 
			Id = 6932;
			Model = 5712;
			AttackSpeed= 1500;
			Name = "Swamp Spirit" ;
			Flags1 = 0x080006;
			Level = RandomLevel( 40 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.22f ;
			WalkSpeed = 3.22f ;
			RunSpeed = 6.22f ;			
			Size=1.0f;
			BCAddon.Hp( this, 2650, 40 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SwampSpirit, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new PredatorAI( this );
		}

	}	
}





namespace Server.Creatures
{
	public class Swampwalker: BaseCreature 
	 { 
		public  Swampwalker() : base() 
		 { 
			Id = 764;
			Model = 2024;
			AttackSpeed= 2000;
			Name = "Swampwalker" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 38,39 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 1.74f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.22f ;
			WalkSpeed = 3.22f ;
			RunSpeed = 6.22f ;			
			Size=1.3f;
			BCAddon.Hp( this, 1252, 38 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Swampwalker, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class SwampwalkerElder: BaseCreature 
	 { 
		public  SwampwalkerElder() : base() 
		 { 
			Id = 765;
			Model = 9012;
			AttackSpeed= 1400;
			Name = "Swampwalker Elder" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 39,40 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.22f ;
			WalkSpeed = 3.22f ;
			RunSpeed = 6.22f ;			
			Size=1.33f;
			BCAddon.Hp( this, 1576, 39 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SwampwalkerElder, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class SwirlingVortex: BaseCreature 
	 { 
		public  SwirlingVortex() : base() 
		 { 
			Id = 9377;
			Model = 8549;
			AttackSpeed= 2000;
			Name = "Swirling Vortex" ;
			Level = RandomLevel( 33,34 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.56f;
			BoundingRadius = 1.250f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.16f ;
			WalkSpeed = 3.16f ;
			RunSpeed = 6.16f ;			
			Size=1.25f;
			BCAddon.Hp( this, 1315, 33 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.SwirlingVortex, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TangledHorror: BaseCreature 
	 { 
		public  TangledHorror() : base() 
		 { 
			Id = 766;
			Model = 697;
			AttackSpeed= 2000;
			Name = "Tangled Horror" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 40,41 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2.25f;
			BoundingRadius = 2.0175f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.22f ;
			WalkSpeed = 3.22f ;
			RunSpeed = 6.22f ;			
			Size=1.5f;
			BCAddon.Hp( this, 1542, 40 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TangledHorror, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TarBeast: BaseCreature 
	 { 
		public  TarBeast() : base() 
		 { 
			Id = 6517;
			Model = 1549;
			AttackSpeed= 2000;
			Name = "Tar Beast" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 50,51 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 1.75f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.3f;
			BCAddon.Hp( this, 2574, 50 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TarBeast, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TarCreeper: BaseCreature 
	 { 
		public  TarCreeper() : base() 
		 { 
			Id = 6527;
			Model = 3018;
			AttackSpeed= 2000;
			Name = "Tar Creeper" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 51,52 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 1.75f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=1.5f;
			BCAddon.Hp( this, 2437, 51 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TarCreeper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TarLord: BaseCreature 
	 { 
		public  TarLord() : base() 
		 { 
			Id = 6519;

			Model = 480;
			AttackSpeed= 2000;
			Name = "Tar Lord" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 53,54 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*3;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3f;
			BoundingRadius = 2.59f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;			
			Size=2f;
			BCAddon.Hp( this, 2673, 53 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TarLord, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class TarLurker: BaseCreature 
	 { 
		public  TarLurker() : base() 
		 { 
			Id = 6518;
			Model = 9010;
			AttackSpeed= 2000;
			Name = "Tar Lurker" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 52,54 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2.625f;
			BoundingRadius = 2.359f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1.75f;
			BCAddon.Hp( this, 2851, 52 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TarLurker, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TemperedWarGolem: BaseCreature 
	 { 
		public  TemperedWarGolem() : base() 
		 { 
			Id = 5853;
			Model = 9010;
			AttackSpeed= 2000;
			Name = "Tempered War Golem" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 45,47 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 1.339f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.26f ;
			WalkSpeed = 3.26f ;
			RunSpeed = 6.26f ;			
			Size=1.3f;
			BCAddon.Hp( this, 1724, 45 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TemperedWarGolem, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class TendrisWarpwood: BaseCreature 
	 { 
		public  TendrisWarpwood() : base() 
		 { 
			Id = 11489;
			Model = 14383;
			AttackSpeed= 2000;
			Name = "Tendris Warpwood" ;
			Flags1 = 0x080001000;			 
			Level = RandomLevel( 60 );
			ResistArcane = Level*5;
			ResistFire = Level;
			ResistFrost = Level*5;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 5976, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TendrisWarpwood, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TheHusk: BaseCreature 
	 { 
		public  TheHusk() : base() 
		 { 
			Id = 1851;
			Model = 9013;
			AttackSpeed= 1200;
			Name = "The Husk" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 62 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 16f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.95f ;
			WalkSpeed = 3.95f ;
			RunSpeed = 6.95f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 9917, 62 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TheHusk, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class TheWindreaver: BaseCreature 
	 { 
		public  TheWindreaver() : base() 
		 { 
			Id = 14454;
			Model = 5490;
			AttackSpeed= 1200;
			Name = "The Windreaver" ;
			//Flags1 = 0x080000;			 
			Level = RandomLevel( 60 );
			ResistArcane = Level*10;
			ResistFire = Level*10;
			ResistFrost = Level*10;
			ResistHoly = Level*10;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 16f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.95f ;
			WalkSpeed = 3.95f ;
			RunSpeed = 6.95f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 9917, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops3.TheWindreaver, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class TheradrimGuardian: BaseCreature 
	 { 
		public  TheradrimGuardian() : base() 
		 { 
			Id = 11784;
			Model = 11712;
			AttackSpeed= 2000;
			Name = "Theradrim Guardian" ;
			Flags1 = 0x080001000;			 
			Level = RandomLevel( 47,48 );
			ResistArcane = Level*5;
			ResistFire = Level;
			ResistFrost = Level*5;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 1.5f ;
			BoundingRadius = 1.389f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.89f ;
			WalkSpeed = 3.89f ;
			RunSpeed = 6.89f ;			
			Size=1.0f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3976, 47 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TheradrimGuardian, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TheradrimShardling: BaseCreature 
	 { 
		public  TheradrimShardling() : base() 
		 { 
			Id = 11783;
			Model = 12310;
			AttackSpeed= 2000;
			Name = "Theradrim Shardling" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 46 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 0.75f;
			BoundingRadius = 0.6f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.26f ;
			WalkSpeed = 3.26f ;
			RunSpeed = 6.26f ;			
			Size=0.5f;
			BCAddon.Hp( this, 1224, 46 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TheradrimShardling, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class ThistleshrubDewCollector: BaseCreature 
	 { 
		public  ThistleshrubDewCollector() : base() 
		 { 
			Id = 5481;
			Model = 3386;
			AttackSpeed= 2000;
			Name = "Thistleshrub Dew Collector" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 47,48 );
			ResistArcane = Level*2;
			ResistFire = Level*2;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.95f;
			BoundingRadius = 1.74f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.26f ;
			WalkSpeed = 3.26f ;
			RunSpeed = 6.26f ;			
			Size=1.3f;
			BCAddon.Hp( this, 2112, 47 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ThistleshrubDewCollector, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ThistleshrubRootshaper: BaseCreature 
	 { 
		public  ThistleshrubRootshaper() : base() 
		 { 
			Id = 5485;
			Model = 9014;
			AttackSpeed= 2000;
			Name = "Thistleshrub Rootshaper" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 49,50 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 2.25f;
			BoundingRadius = 2.017f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.28f ;
			WalkSpeed = 3.28f ;
			RunSpeed = 6.28f ;			
			Size=1.5f;
			BCAddon.Hp( this, 1550, 49 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ThistleshrubRootshaper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Thornling: BaseCreature 
	 { 
		public  Thornling() : base() 
		 { 
			Id = 14362;
			Model = 14392;
			AttackSpeed= 2000;
			Name = "Thornling" ;
			Flags1 = 0x0100506;
			Level = RandomLevel( 50 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 0.3f;
			BoundingRadius = 0.2f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;			
			Size=0.2f;
			BCAddon.Hp( this, 3550, 60 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Thornling, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class ThunderingBoulderkin: BaseCreature 
	 { 
		public  ThunderingBoulderkin() : base() 
		 { 
			Id = 4120;
			Model = 9587;
			AttackSpeed= 3000;
			Name = "Thundering Boulderkin" ;
			Flags1 = 0x0100506;
			Level = RandomLevel( 28,29 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.275f;
			BoundingRadius = 1.180f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=0.85f;
			BCAddon.Hp( this, 894, 28 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ThunderingBoulderkin, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}


/*Thundering Invader 14462*/



namespace Server.Creatures
{
	public class Tideress: BaseCreature 
	 { 
		public  Tideress() : base() 
		 { 
			Id = 12759;
			Model = 7853;
			AttackSpeed= 2000;
			Name = "Tideress" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 27 );
			ResistArcane = Level;
			ResistFire = Level*2;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.725f;
			BoundingRadius = 0.575f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.15f;
			BCAddon.Hp( this, 810, 27 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Tideress, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}






namespace Server.Creatures
{
	public class ToxicHorror: BaseCreature 
	 { 
		public  ToxicHorror() : base() 
		 { 
			Id = 7132;
			Model = 5498;
			AttackSpeed= 1400;
			Name = "Toxic Horror" ;
			Flags1 = 0x080000;
			Level = RandomLevel( 53,54 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 11f;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1.0f;
			BCAddon.Hp( this, 2555, 53 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ToxicHorror, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class TreantAlly: BaseCreature 
	 { 
		public  TreantAlly() : base() 
		 { 
			Id = 5806;
			Model = 9590;
			AttackSpeed= 2000;
			Name = "Treant Ally" ;
			Level = RandomLevel( 22,23 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2f ;
			BoundingRadius = 0.34f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.23f ;
			WalkSpeed = 3.23f ;
			RunSpeed = 6.23f ;			
			Size=1f;
			BCAddon.Hp( this, 579, 22 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Alliance;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2929, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TreantAlly, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class TreantSpirit: BaseCreature 
	 { 
		public  TreantSpirit() : base() 
		 { 
			Id = 9601;
			Model = 8824;
			AttackSpeed= 1300;
			Name = "Treant Spirit" ;
			Level = RandomLevel( 52,53 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.23f ;
			WalkSpeed = 3.23f ;
			RunSpeed = 6.23f ;			
			Size=1f;
			BCAddon.Hp( this, 3097, 52 );
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Alliance;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2929, 60 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.TreantSpirit, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Tsunaman: BaseCreature 
	 { 
		public  Tsunaman() : base() 
		 { 
			Id = 11862;
			Model = 5562;
			AttackSpeed= 2000;
			Name = "Tsunaman" ;
			Flags1 = 0x0400046;			 
			Level = RandomLevel( 25 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 1.7f ;
			BoundingRadius = 0.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.15f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Horde;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1097, 25 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.Tsunaman, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class VaultWarder: BaseCreature 
	 { 
		public  VaultWarder() : base() 
		 { 
			Id = 10120;
			Model = 5989;
			AttackSpeed= 2500;
			Name = "Vault Warder" ;
			Level = RandomLevel( 45 );
			Flags1 = 0x0260;			 
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2.25f ;
			BoundingRadius = 0.913f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.87f ;
			WalkSpeed = 3.87f ;
			RunSpeed = 6.87f ;			
			Size=1.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 3976, 45 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.VaultWarder, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class VengefulAncient: BaseCreature 
	 { 
		public  VengefulAncient() : base() 
		 { 
			Id = 4030;
			Model = 9591;
			AttackSpeed= 2000;
			Name = "Vengeful Ancient" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 30 );
			ResistArcane = Level*8;
			ResistFire = Level*8;
			ResistFrost = Level*8;
			ResistHoly = Level*8;
			ResistNature = Level*10;
			ResistShadow = Level*8;
			Str = (int)(Level)*5;
			NpcType = 4;
			Armor= Level*50;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.6f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			Elite = 4;
			Speed = 3.41f ;
			WalkSpeed = 3.41f ;
			RunSpeed = 6.41f ;			
			Size=1.75f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4917, 30 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.VengefulAncient, 100f ),
									new BaseTreasure(DropsME.MoneyRare, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class VengefulSurge: BaseCreature 
	 { 
		public  VengefulSurge() : base() 
		 { 
			Id = 2776;
			Model = 5562;
			AttackSpeed= 1400;
			Name = "Vengeful Surge" ;
			Level = RandomLevel( 40 );
			Flags1 = 0x06;			 
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.22f ;
			WalkSpeed = 3.22f ;
			RunSpeed = 6.22f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1997, 40 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.VengefulSurge, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class VerdantheEverliving: BaseCreature 
	 { 
		public  VerdantheEverliving() : base() 
		 { 
			Id = 5775;
			Model = 4256;
			AttackSpeed= 3500;
			Name = "Verdan the Everliving" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 21,22 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 6.7f ;
			BoundingRadius = 6f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.6f ;
			WalkSpeed = 3.6f ;
			RunSpeed = 6.6f ;			
			Size=4.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4046, 21 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.VerdantheEverliving, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class ViscousFallout: BaseCreature 
	 { 
		public  ViscousFallout() : base() 
		 { 
			Id = 7079;
			Model = 5497;
			AttackSpeed= 2000;
			Name = "Viscous Fallout" ;
			Flags1 = 0x01000;			 
			Level = RandomLevel( 30 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 1.95f ;
			BoundingRadius = 0.65f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.71f ;
			WalkSpeed = 3.71f ;
			RunSpeed = 6.71f ;			
			Size=1.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2956, 30 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.ViscousFallout, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WanderingForestWalker: BaseCreature 
	 { 
		public  WanderingForestWalker() : base() 
		 { 
			Id = 7584;
			Model = 9592;
			AttackSpeed= 2000;
			Name = "Wandering Forest Walker" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 43,46 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 3.5f ;
			BoundingRadius = 0.6f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.88f ;
			WalkSpeed = 3.88f ;
			RunSpeed = 6.88f ;			
			Size=1.75f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 4628, 43 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WanderingForestWalker, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class WarGolem: BaseCreature 
	 { 
		public  WarGolem() : base() 
		 { 
			Id = 2751;
			Model = 5747;
			AttackSpeed= 1800;
			Name = "War Golem" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 36 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 16f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.22f ;
			WalkSpeed = 3.22f ;
			RunSpeed = 6.22f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1997, 36 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarGolem, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarReaver: BaseCreature 
	 { 
		public  WarReaver() : base() 
		 { 
			Id = 7039;
			Model = 10806;
			AttackSpeed= 2000;
			Name = "War Reaver" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 54,55 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = (int)NpcActions.Dialog ;
			CombatReach = 2.6f ;
			BoundingRadius = 1.8f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1.75f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2610, 54 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarReaver, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarbringerConstruct: BaseCreature 
	 { 
		public  WarbringerConstruct() : base() 
		 { 
			Id = 8905;
			Model = 8289;
			AttackSpeed= 2000;
			Name = "Warbringer Construct" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 53,54 );
			ResistArcane = Level*2;
			ResistFire = Level*5;
			ResistFrost = Level*2;
			ResistHoly = Level*2;
			ResistNature = Level*2;
			ResistShadow = Level*2;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 2.163f ;
			BoundingRadius = 3.15f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;			
			Size=2.1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4628, 53 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarbringerConstruct, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarpwoodCrusher: BaseCreature 
	 { 
		public  WarpwoodCrusher() : base() 
		 { 
			Id = 13021;
			Model = 12929;
			AttackSpeed= 2000;
			Name = "Warpwood Crusher" ;
			Level = RandomLevel( 56 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level*5;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;			
			Size=2.1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4628, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarpwoodCrusher, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class WarpwoodGuardian: BaseCreature 
	 { 
		public  WarpwoodGuardian() : base() 
		 { 
			Id = 11461;
			Model = 13173;
			AttackSpeed= 2000;
			Name = "Warpwood Guardian" ;
			Level = RandomLevel( 55,58 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level*5;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4628, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarpwoodGuardian, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarpwoodMossFlayer: BaseCreature 
	 { 
		public  WarpwoodMossFlayer() : base() 
		 { 
			Id = 7100;
			Model = 8389;
			AttackSpeed= 1300;
			Name = "Warpwood Moss Flayer" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 52,53 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2683, 52 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarpwoodMossFlayer, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarpwoodShredder: BaseCreature 
	 { 
		public  WarpwoodShredder() : base() 
		 { 
			Id = 7101;
			Model = 2832;
			AttackSpeed= 2000;
			Name = "Warpwood Shredder" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 53,54 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 2.6f ;
			BoundingRadius = 2.3f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1.75f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2374, 53 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarpwoodShredder, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarpwoodStomper: BaseCreature 
	 { 
		public  WarpwoodStomper() : base() 
		 { 
			Id = 11465;
			Model = 6350;
			AttackSpeed= 2000;
			Name = "Warpwood Stomper" ;
			Level = RandomLevel( 55,58 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level*5;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4628, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarpwoodStomper, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarpwoodTangler: BaseCreature 
	 { 
		public  WarpwoodTangler() : base() 
		 { 
			Id = 11464;
			Model = 9592;
			AttackSpeed= 2000;
			Name = "Warpwood Tangler" ;
			Level = RandomLevel( 55,56 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4628, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarpwoodTangler, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WarpwoodTreant: BaseCreature 
	 { 
		public  WarpwoodTreant() : base() 
		 { 
			Id = 11462;
			Model = 10621;
			AttackSpeed= 2000;
			Name = "Warpwood Treant" ;
			Level = RandomLevel( 54,55 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;			
			Size=1f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4628, 54 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WarpwoodTreant, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WaterSpirit: BaseCreature 
	 { 
		public  WaterSpirit() : base() 
		 { 
			Id = 6748;
			Model = 525;
			AttackSpeed= 2000;
			Name = "Water Spirit" ;
			Flags1 = 0x0266;			 
			Level = RandomLevel( 19 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 0.51f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=0.85f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 374, 19 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WaterSpirit, 100f ),
									new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WateryInvader: BaseCreature 
	 { 
		public  WateryInvader() : base() 
		 { 
			Id = 14458;
			Model = 5489;
			AttackSpeed= 2000;
			Name = "Watery Invader" ;
			Level = RandomLevel( 56,58 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level*2;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.275f ;
			BoundingRadius = 0.51f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1818, 56 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WateryInvader, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class WhipLasher: BaseCreature 
	 { 
		public  WhipLasher() : base() 
		 { 
			Id = 13022;
			Model = 12962;
			AttackSpeed= 2000;
			Name = "Whip Lasher" ;
			Level = RandomLevel( 50,54 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.32f ;
			WalkSpeed = 3.32f ;
			RunSpeed = 6.32f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1505, 50 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WhipLasher, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}


/*Whirling Invader 14455*/



namespace Server.Creatures
{
	public class WhirlwindRipper: BaseCreature 
	 { 
		public  WhirlwindRipper() : base() 
		 { 
			Id = 11576;
			Model = 8714;
			AttackSpeed= 1400;
			Name = "Whirlwind Ripper" ;
			Level = RandomLevel( 32,34 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.25f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.16f ;
			WalkSpeed = 3.16f ;
			RunSpeed = 6.16f ;			
			Size=1f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1202, 32 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WhirlwindRipper, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WhirlwindShredder: BaseCreature 
	 { 
		public  WhirlwindShredder() : base() 
		 { 
			Id = 11578;
			Model = 11374;
			AttackSpeed= 1400;
			Name = "Whirlwind Shredder" ;
			Level = RandomLevel( 32,34 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.56f ;
			BoundingRadius = 1.25f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.16f ;
			WalkSpeed = 3.16f ;
			RunSpeed = 6.16f ;			
			Size=1.25f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1222, 32 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WhirlwindShredder, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WhirlwindStormwalker: BaseCreature 
	 { 
		public  WhirlwindStormwalker() : base() 
		 { 
			Id = 11577;
			Model = 11373;
			AttackSpeed= 2000;
			Name = "Whirlwind Stormwalker" ;
			Level = RandomLevel( 35,37 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level;
			ResistShadow = Level*2;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.25f ;
			BoundingRadius = 1.0f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.19f ;
			WalkSpeed = 3.19f ;
			RunSpeed = 6.19f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1232, 35 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WhirlwindStormwalker, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WindHowler: BaseCreature 
	 { 
		public  WindHowler() : base() 
		 { 
			Id = 4526;
			Model = 5494;
			AttackSpeed= 1500;
			Name = "Wind Howler" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 25,26 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;
 
			NpcFlags = 0;
			CombatReach = 0.93f;
			BoundingRadius = 0.75f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 3.65f ;
			WalkSpeed = 3.65f ;
			RunSpeed = 6.65f ;			
			Size=0.75f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2628, 25 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WindHowler, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WitheredAncient: BaseCreature 
	 { 
		public  WitheredAncient() : base() 
		 { 
			Id = 3919;
			Model = 9593;
			AttackSpeed= 2000;
			Name = "Withered Ancient" ;
			Level = RandomLevel( 26,27 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 3f ;
			BoundingRadius = 0.5f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;			
			Size=1.5f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 781, 26 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WitheredAncient, 100f ),
									new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WitheredProtector: BaseCreature 
	 { 
		public  WitheredProtector() : base() 
		 { 
			Id = 7149;
			Model = 12929;
			AttackSpeed= 1200;
			Name = "Withered Protector" ;
			Level = RandomLevel( 55,56 );
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 11f ;
			BoundingRadius = 1f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;			
			Size=1.0f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4212, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WitheredProtector, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WithervineBarkRipper: BaseCreature 
	 { 
		public  WithervineBarkRipper() : base() 
		 { 
			Id = 4386;
			Model = 631;
			AttackSpeed= 2000;
			Name = "Withervine Bark Ripper" ;
			Level = RandomLevel( 36,37);
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;

			NpcFlags = 0;
			CombatReach = 1.9f ;
			BoundingRadius = 1.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.19f ;
			WalkSpeed = 3.19f ;
			RunSpeed = 6.19f ;			
			Size=1.3f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 783, 36 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WithervineBarkRipper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class WithervineCreeper: BaseCreature 
	 { 
		public  WithervineCreeper() : base() 
		 { 
			Id = 4382;
			Model = 2024;
			AttackSpeed= 2000;
			Name = "Withervine Creeper" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 35,36);
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.9f ;
			BoundingRadius = 1.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.19f ;
			WalkSpeed = 3.19f ;
			RunSpeed = 6.19f ;			
			Size=1.3f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1443, 35 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WithervineCreeper, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WithervineMireBeast: BaseCreature 
	 { 
		public  WithervineMireBeast() : base() 
		 { 
			Id = 4387;
			Model = 1549;
			AttackSpeed= 2000;
			Name = "Withervine Mire Beast" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 37,38);
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 1.9f ;
			BoundingRadius = 1.7f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.3f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 1414, 37 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WithervineMireBeast, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class WithervineRager: BaseCreature 
	 { 
		public  WithervineRager() : base() 
		 { 
			Id = 4385;
			Model = 697;
			AttackSpeed= 2000;
			Name = "Withervine Rager" ;
			Flags1 = 0x080000;			 
			Level = RandomLevel( 38,39);
			ResistArcane = Level;
			ResistFire = Level;
			ResistFrost = Level;
			ResistHoly = Level;
			ResistNature = Level*2;
			ResistShadow = Level;
			Str = (int)(Level);
			NpcType = 4;
			Armor= Level*25;
			Block=Level+10;
 
			NpcFlags = 0;
			CombatReach = 2.2f ;
			BoundingRadius = 2f ;
			SetDamage(1f+2.8f*Level,1f+3.0*Level);			
			ManaType=0;
			//Elite = 1;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;			
			Size=1.5f;
			//NpcText00="I'm afraid you won't find an Auction House here in Stormwind.  However the dwarves run one up in Ironforge.  Just hop on a gryphon to get there.";
			//NpcText01="We used to have an auction house in Stormwind, but the streets were so full of people, we had to close it down for public health reasons.??? The one in Ironforge is still open, as far as I know.";
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 2124, 38 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WithervineRager, 100f ),
									new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}




namespace Server.Creatures
{
	public class WrathHammerConstruct: BaseCreature 
	 { 
		public  WrathHammerConstruct() : base() 
		 { 
			Id = 8907;
			Model = 8178;
			AttackSpeed= 1500;
			Name = "Wrath Hammer Construct" ;
			Flags1 = 0x06;			 
			Level = RandomLevel( 55,56 );
			ResistArcane = Level*5;
			ResistFire = Level*5;
			ResistFrost = Level*5;
			ResistHoly = Level*5;
			ResistNature = Level*5;
			ResistShadow = Level*5;
			Str = (int)(Level*2.75f);
			NpcType = 4;
			Armor= Level*32;
			ManaType=0;
			Block=Level+30;

			NpcFlags = 0;
			CombatReach = 2.7f;
			BoundingRadius = 2.7f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			Elite = 1;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 4f ;			
			Size=1.8f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 4628, 55 );	
			Loots = new BaseTreasure[]{ new BaseTreasure( ElementalDrops4.WrathHammerConstruct, 100f ),
								new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}	
}

