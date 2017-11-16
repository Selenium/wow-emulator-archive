//     Script made by nirvan   - 07.06.2005
// Skeletons.cs

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class SkeletalWarrior : BaseCreature 
	{ 
		public  SkeletalWarrior() : base() 
		{ 
			Model = 200;
			AttackSpeed= 2000;
			Level = RandomLevel(21);
			BoundingRadius = 1f ;
			Name = "Skeletal Warrior" ;
			Id = 48 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 904 ;
			CombatReach = 1.275f ;
			SetDamage ( 23,34);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalWarrior , 100f )};
			
		}
	}

	public class SkeletalHorror : BaseCreature 
	{ 
		public  SkeletalHorror() : base() 
		{ 
			Model = 9786;
			AttackSpeed= 2000;
			Level = RandomLevel(23);
			BoundingRadius = 1f ;
			Name = "Skeletal Horror" ;
			Id = 202 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 984 ;
			CombatReach = 1.5f ;
			SetDamage (25,37);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalHorror , 100f )};


		}
	}

	public class SkeletalMage : BaseCreature 
	{ 
		public  SkeletalMage() : base() 
		{ 
			Model = 9783;
			AttackSpeed= 3000;
			Level = RandomLevel(23);
			BoundingRadius = 1f ;
			Name = "Skeletal Mage" ;
			Id = 203 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 944;
			CombatReach = 1.5f;
			SetDamage (24,35);
			BaseMana = 1443 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalMage , 100f )};


		}
	}

	public class SkeletalFiend : BaseCreature 
	{ 
		public  SkeletalFiend() : base() 
		{ 
			Model = 7550;
			AttackSpeed= 2000;
			Level = RandomLevel( 25 );
			BoundingRadius = 1f ;
			Name = "Skeletal Fiend" ;
			Id = 531 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 1024 ;
			CombatReach = 1.5f ;
			SetDamage (26,39);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalFiend , 100f )};


		}
	}

	public class SkeletalMiner : BaseCreature 
	{ 
		public  SkeletalMiner() : base() 
		{ 
			Model = 11402;
			AttackSpeed= 2000;
			Level = RandomLevel( 18 );
			BoundingRadius = 1f ;
			Name = "Skeletal Miner" ;
			Id = 623 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 2112 ;
			CombatReach = 1.275f ;
			SetDamage (43,50);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalMiner , 100f )};

		}
	}

	public class SkeletalWarder : BaseCreature 
	{ 
		public  SkeletalWarder() : base() 
		{ 
			Model = 612;
			AttackSpeed= 2000;
			BoundingRadius = 0.453100f ;
			Level = RandomLevel( 28 );
			Name = "Skeletal Warder" ;
			Id = 785 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 1144 ;
			CombatReach = 1.725f ;
			SetDamage (29,43);
			BaseMana = 756 ;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalWarder , 100f )};


		}
public override void OnAddToWorld()
    {
        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new AgressiveAnimalAI( this );
    }
	    
	    		
	}

	public class SkeletalHealer : BaseCreature 
	{ 
		public  SkeletalHealer() : base() 
		{ 
			Model = 7555;
			AttackSpeed= 2000;
			Level = RandomLevel(26);
			BoundingRadius = 1f ;
			Name = "Skeletal Healer" ;
			Id = 787 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 1024 ;
			CombatReach = 1.5f ;
			SetDamage (26,39);
			BaseMana = 1040 ;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalHealer , 100f )};

		}
public override void OnAddToWorld()
    {
    if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new AgressiveAnimalAI( this );
    }
			
					
	}

	public class SkeletalRaider : BaseCreature 
	{ 
		public  SkeletalRaider() : base() 
		{ 
			Model = 734;
			AttackSpeed= 2000;
			Level = RandomLevel( 27 );
			BoundingRadius = 1f ;
			Name = "Skeletal Raider" ;
			Id = 1110 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 1104 ;
			CombatReach = 1.725f ;
			SetDamage (28,42);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalRaider , 100f )};
		}
public override void OnAddToWorld()
        {
        if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new AgressiveAnimalAI( this );
        }
							 
	}

	public class SkeletalFlayer : BaseCreature 
	{ 
		public  SkeletalFlayer() : base() 
		{ 
			Model = 733;
			Level = RandomLevel( 51 );
			AttackSpeed= 1300;
			BoundingRadius = 1f ;
			Name = "Skeletal Flayer" ;
			Id = 1783 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 1945 ;
			CombatReach = 1.725f ;
			SetDamage (49,73);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalFlayer , 100f )};
		}
	}

	public class SkeletalSorcerer : BaseCreature 
	{ 
		public  SkeletalSorcerer() : base() 
		{ 
			Model = 11403;
			AttackSpeed= 2000;
			Level = RandomLevel( 51 );
			BoundingRadius = 1.15f ;
			Name = "Skeletal Sorcerer" ;
			Id = 1784 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 2025 ;
			CombatReach = 1.725f ;
			SetDamage (51,76);
			BaseMana = 1864 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalSorcerer , 100f )};

		}
	}

	public class SkeletalTerror : BaseCreature 
	{ 
		public  SkeletalTerror() : base() 
		{ 
			Model = 11404;
			AttackSpeed= 2000;
			Level = RandomLevel(54);
			BoundingRadius = 1.15f ;
			Name = "Skeletal Terror" ;
			Id = 1785 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 2105 ;
			CombatReach = 1.725f ;
			SetDamage (53,79);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalTerror , 100f )};

		}
	}
	public class SkeletalExecutioner : BaseCreature 
	{ 
		public  SkeletalExecutioner() : base() 
		{ 
			Model = 11401;
			AttackSpeed= 2700;
			Level = RandomLevel( 55 );
			BoundingRadius = 1.3f ;
			Name = "Skeletal Executioner" ;
			Id = 1787 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 2105 ;
			CombatReach = 1.95f ;
			SetDamage ( 53, 79 );
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalExecutioner , 100f )};

		}
	}
	public class SkeletalWarlord : BaseCreature 
	{ 
		public  SkeletalWarlord() : base() 
		{ 
			Model = 775;
			AttackSpeed= 2500;
			Level = RandomLevel( 57 );
			BoundingRadius = 1f ;
			Name = "Skeletal Warlord" ;
			Id = 1788 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = 5000 ;
			CombatReach = 2.25f ;
			SetDamage (50,800);
			BaseMana = 0 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalWarlord , 100f )};

		}
	}
	public class SkeletalAcolyte : BaseCreature 
	{ 
		public  SkeletalAcolyte() : base() 
		{ 
			Model = 9790;
			AttackSpeed= 2000;
			Level = RandomLevel( 55 );
			BoundingRadius = 1.3f ;
			Name = "Skeletal Acolyte" ;
			Id = 1789 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 2145 ;
			CombatReach = 1.95f ;
			SetDamage (54,80);
			BaseMana = 2117 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalAcolyte , 100f )};
		}
	}

	public class SkeletalShadowcaster : BaseCreature 
	{ 
		public  SkeletalShadowcaster() : base() 
		{ 
			Model = 9786;
			AttackSpeed= 2000;
			Level = RandomLevel( 36 );
			BoundingRadius = 1f ;
			Name = "Skeletal Shadowcaster" ;
			Id = 7340 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 1424 ;
			CombatReach = 1.5f ;
			SetDamage (37,55);
			BaseMana = 2763 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalShadowcaster , 100f )};			
		}
	}
	public class SkeletalFrostweaver : BaseCreature 
	{ 
		public  SkeletalFrostweaver() : base() 
		{ 
			Model = 9783;
			Level = RandomLevel( 37 );
			AttackSpeed= 2000;
			BoundingRadius = 1f ;
			Name = "Skeletal Frostweaver" ;
			Id = 7341 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 4512 ;
			CombatReach = 1.5f ;
			SetDamage (56, 82);
			BaseMana = 2861 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalFrostweaver , 100f )};

		}
	}
	public class SkeletalSummoner : BaseCreature 
	{ 
		public  SkeletalSummoner() : base() 
		{ 
			Model = 1245;
			AttackSpeed= 2000;
			Level = RandomLevel( 40 );
			BoundingRadius = 1f ;
			Name = "Skeletal Summoner" ;
			Id = 7342 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 4755 ;
			CombatReach = 1.25f ;
			SetDamage ( 59, 87 );
			BaseMana = 3191 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.SkeletalSummoner , 100f )};			
		}
	}
	public class RattlecageSkeleton : BaseCreature 
	{ 
		public  RattlecageSkeleton() : base() 
		{ 
			Model = 11400;
			Level = RandomLevel(3);
			AttackSpeed= 2000;
			BoundingRadius = 0.85f ;
			Name = "Rattlecage Skeleton" ;
			Id = 1890 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcType = 6 ;
			BaseHitPoints = 41;
			CombatReach = 1.275f ;
			SetDamage ( 3, 4.15);
			BaseMana = 0 ;
                        Faction = Factions.NoFaction;
                        AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )
						  , new BaseTreasure( SkeletonLoot.RattlecageSkeleton , 100f )};                        
                }
	}
}