//made by ccsman, 29-07-2005
//completed, except the 3 high-level bosses

using System;
using Server.Items;

namespace Server.Creatures
{
	public class Aman: BaseCreature //he is a NPC, appears on a quest and you can't fight him
	 { 
		public  Aman() : base() 
		 { 
			Id = 3582 ; 
			Model = 1698;
			AttackSpeed= 2000;
			Name = "Aman" ;
			Flags1 = 0x066 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level =  50 ;
			NpcType = (int)NpcTypes.Giant ;
			Armor= 3000;
			BaseHitPoints = 5000;
			BaseMana=0;
			NpcFlags = 00 ;
			BoundingRadius = 0.75f ;			
			CombatReach = 1.87f ;
			SetDamage(4f*Level, 6*Level);
			ManaType=0;
			Block=Level+20;
			Size = 0.75f;
			Speed = 4.5f ;
			WalkSpeed = 4.5f ;			
			RunSpeed = 7.5f ;			
                  NpcText00 = "Who hath summoned forth Aman?" ;
                  Faction = Factions.Friend;
                  AIEngine = new NonAgressiveAnimalAI( this );			
		}
	}	
}

namespace Server.Creatures
{
	public class Anathemus: BaseCreature 
	 { 
		public  Anathemus() : base() 
		 { 
			Id = 2754 ; 
			Model = 10040;
			AttackSpeed= 3000;
			Name = "Anathemus" ;
			Flags1 = 00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 45 ;
			NpcType = (int)NpcTypes.Giant ;
                  BaseMana=0;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);  
                  NpcFlags = 00 ;
			BoundingRadius = 0.485f ;			
			CombatReach = 2.6f ;
			SetDamage(6f*Level, 9*Level);  //giant, hitts really hard			
			ManaType=0;
			Elite=1; 
                  //Block=Level-10;
			Faction = Factions.Monster;
                  Size = 1.3f;
			Speed = 4f ;
			WalkSpeed = 4f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                  //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Anathemus, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class AncientProtector: BaseCreature 
	 { 
		public  AncientProtector() : base() 
		 { 
			Id = 2041 ; 
			Model = 2429;
			AttackSpeed= 4000;
			Name = "Ancient Protector" ;
			Flags1 = 0x0400006 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 60 );
			Str = (int)(Level*1.7f);
			Armor=(int)(Level*60f);
			NpcType = (int)NpcTypes.Giant;
                  float step=75f;
                  BaseHitPoints = 4500;
                  if (Level!=60)		
                    {
                    for (int i=1; i<=(Level-60); i++)
                        {
                            step=step+step;
                        }	
                    BaseHitPoints = BaseHitPoints + (int)step;
                    } 
                  NpcFlags = 00 ;
			BoundingRadius = 0.476f ;			
			CombatReach = 5f ;
			SetDamage(8f*Level, 12*Level);			
			ManaType=0;
			Faction = Factions.Darnasus;
			Size = 3f;
			Speed = 4f ;
			WalkSpeed = 4f ;			
			RunSpeed = 7f ;
			AIEngine = new StandingGuardAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
		}
	}	
}

namespace Server.Creatures
{
	public class Archaedas: BaseCreature //boss, not done
	 { 
		public  Archaedas() : base() 
		 { 
			Id = 2748 ; 
			Model = 5988;
			AttackSpeed= 2600;
			Name = "Archaedas" ;
                  Guild = "Ancient Stone Watcher";
			Flags1 = 0x01260 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 63;
			Str = (int)(Level*1.7f);
			Armor=(int)(Level*70f);
			NpcType = (int)NpcTypes.Giant;
                    BaseHitPoints = 88345;
			NpcFlags = 00 ;
			BoundingRadius = 0.525f ;			
			CombatReach = 3f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			Block=Level-30;
                  Elite= 3;  
			Faction = Factions.Monster;
			Size = 2.3f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
                  Equip( new SulfuronHammer()) ;
			AIEngine = new PredatorAI( this );
			BCAddon.Hp( this, 77671, 63 );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Archaedas, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class BaelGar: BaseCreature 
	 { 
		public  BaelGar() : base() 
		 { 
			Id = 9016 ; 
			Model = 12162;
			AttackSpeed= 1146;
			Name = "Bael'Gar" ;
			Flags1 = 0x080001000 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 49, 57 );
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
  		      NpcType = (int)NpcTypes.Giant;
                  NpcFlags = 00 ;
			BoundingRadius = 0.561f ;			
			CombatReach = 5f ;
			SetDamage(2.29f*Level, 3.43*Level);			
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.2f;
			Speed = 4f ;
			WalkSpeed = 4f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.BaelGar, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Boulderheart: BaseCreature 
	 { 
		public  Boulderheart() : base() 
		 { 
			Id = 14273 ; 
			Model = 5229;
			AttackSpeed= 2000;
			Name = "Boulderheart" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level =  25 ;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level);
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcType = (int)NpcTypes.Giant;
                  NpcFlags = 00 ;
			BoundingRadius = 0.561f ;			
			CombatReach = 2.0f ;
			SetDamage(4f*Level, 6*Level);			
			ManaType=0;
			Faction = Factions.Monster;
			Size = 1f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Boulderheart, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CliffBreaker: BaseCreature 
	 { 
		public  CliffBreaker() : base() 
		 { 
			Id = 6146 ; 
			Model = 1918;
			AttackSpeed= 2500;
			Name = "Cliff Breaker" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 52, 55 );
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcType = (int)NpcTypes.Giant;
                  NpcFlags = 00 ;
			BoundingRadius = 0.727f ;			
			CombatReach = 2.6f ;
			SetDamage(5f*Level, 7.5*Level);			
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.3f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.CliffBreaker, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CliffGiant: BaseCreature 
	 { 
		public  CliffGiant() : base() 
		 { 
			Id = 5358 ; 
			Model = 12813;
			AttackSpeed= 1190;
			Name = "Cliff Giant" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 44, 50 );
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcType = (int)NpcTypes.Giant;
                  NpcFlags = 00 ;
			BoundingRadius = 0.694f ;			
			CombatReach = 3f ;
			SetDamage(2.38f*Level, 3.57*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.45f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.CliffGiant, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CliffThunderer: BaseCreature 
	 { 
		public  CliffThunderer() : base() 
		 { 
			Id = 6147 ; 
			Model = 12814;
			AttackSpeed= 2500;
			Name = "Cliff Thunderer" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
                  NpcType= (int)NpcTypes.Giant;   
			Level = RandomLevel( 52, 54 );
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcFlags = 00 ;
			BoundingRadius = 0.646f ;			
			CombatReach = 3.2f ;
			SetDamage(5f*Level, 7.5*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.6f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.CliffThunderer, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CliffWalker: BaseCreature 
	 { 
		public  CliffWalker() : base() 
		 { 
			Id = 6148 ; 
			Model = 12813;
			AttackSpeed= 2500;
			Name = "Cliff Walker" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 50, 53 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.489f ;			
			CombatReach = 3f ;
			SetDamage(5f*Level, 7.5*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.45f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.CliffWalker, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CoastStrider: BaseCreature 
	 { 
		public  CoastStrider() : base() 
		 { 
			Id = 5466 ; 
			Model = 10039;
			AttackSpeed= 2600;
			Name = "Coast Strider" ;
			Flags1 = 0x080000 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 48, 49 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.799f ;			
			CombatReach = 3f ;
			SetDamage(5.2f*Level, 7.8*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.45f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.CoastStrider, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class DeepDweller: BaseCreature 
	 { 
		public  DeepDweller() : base() 
		 { 
			Id = 5467 ; 
			Model = 12812;
			AttackSpeed= 1189;
			Name = "Deep Dweller" ;
			Flags1 = 0x080000 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
                  ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 49, 50 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.561f ;			
			CombatReach = 5.5f ;
			SetDamage(2.38f*Level, 3.57*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.DeepDweller, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class DeepStrider: BaseCreature 
	 { 
		public  DeepStrider() : base() 
		 { 
			Id = 5360 ; 
			Model = 12812;
			AttackSpeed= 2700;
			Name = "Deep Strider" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 44, 49 );
			NpcType = (int)NpcTypes.Giant;
                 BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcFlags = 00 ;
			BoundingRadius = 0.788f ;			
			CombatReach = 3.2f ;
			SetDamage(5.4f*Level, 8.1*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.6f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.DeepStrider, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class DeepstriderGiant: BaseCreature 
	 { 
		public  DeepstriderGiant() : base() 
		 { 
			Id = 4686 ; 
			Model = 10043;
			AttackSpeed= 1320;
			Name = "Deepstrider Giant" ;
			Flags1 = 0x080000 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 37, 39 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.571f ;			
			CombatReach = 5f ;
			SetDamage(2.64f*Level, 3.96*Level);
			ManaType=0;
			Equip( new BruteHammer()) ;  
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 2f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.DeepstriderGiant, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class DeepstriderSearcher: BaseCreature 
	 { 
		public  DeepstriderSearcher() : base() 
		 { 
			Id = 4687 ; 
			Model = 10039;
			AttackSpeed= 3000;
			Name = "Deepstrider Searcher" ;
			Flags1 = 0x080000 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow =  0;
			Level = RandomLevel( 39, 40 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.507f ;			
			CombatReach = 3f ;
			SetDamage(6f*Level, 9*Level);
			ManaType=0;
			Equip( new SolidIronMaul()) ; 
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.45f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.DeepstriderSearcher, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class DuneSmasher: BaseCreature 
	 { 
		public  DuneSmasher() : base() 
		 { 
			Id = 5469 ; 
			Model = 6910;
			AttackSpeed= 2400;
			Name = "Dune Smasher" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 47, 49 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.437f ;			
			CombatReach = 3f ;
			SetDamage(4.8f*Level, 7.2*Level);
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.50f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.DuneSmasher, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Fozruk: BaseCreature 
	 { 
		public  Fozruk() : base() 
		 { 
			Id = 2611 ; 
			Model = 1918 ;
			AttackSpeed= 2000;
			Name = "Fozruk" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 39, 42 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);  
                  NpcFlags = 00 ;
			BoundingRadius = 1.3f ;			
			CombatReach = 2.6f ;
			SetDamage(4f*Level, 6*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 2f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Fozruk, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class FrostmaulGiant: BaseCreature 
	 { 
		public  FrostmaulGiant() : base() 
		 { 
			Id = 7428 ; 
			Model = 6209;
			AttackSpeed= 2000;
			Name = "Frostmaul Giant" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 55, 60 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.438f ;			
			CombatReach = 3.2f ;
			SetDamage(4*Level, 6*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.6f;
			Speed = 4f ;
			WalkSpeed = 4f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.FrostmaulGiant, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class FrostmaulPreserver: BaseCreature 
	 { 
		public  FrostmaulPreserver() : base() 
		 { 
			Id = 7429 ; 
			Model = 6209;
			AttackSpeed= 2000;
			Name = "Frostmaul Preserver" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 59, 60 );
			NpcType = (int)NpcTypes.Giant;
                  NpcFlags = 00 ;
			BoundingRadius = 0.606f ;			
			CombatReach = 3.5f ;
			SetDamage(4f*Level, 6*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.75f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.FrostmaulPreserver, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class GolemaggTheIncinerator: BaseCreature //boss, not done
	 { 
		public  GolemaggTheIncinerator() : base() 
		 { 
			Id = 11988 ; 
			Model = 11986;
			AttackSpeed= 2200;
			Name = "Golemagg the Incinerator" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 63;
			Str = (int)(Level*1.7f);
			Armor=(int)(Level*70f);
			NpcType = (int)NpcTypes.Giant;
                    BaseMana = 849345;  
			NpcFlags = 00 ;
			BoundingRadius = 1.3f ;			
			CombatReach = 2.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			Block=Level-30;
                  Elite=3;  
			Faction = Factions.Monster;
			Size = 2f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			BCAddon.Hp( this, 70000, 63 );	
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.GolemaggTheIncinerator, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Gorlash: BaseCreature 
	 { 
		public  Gorlash() : base() 
		 { 
			Id = 1492 ; 
			Model = 10039;
			AttackSpeed= 2000;
			Name = "Gorlash" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 45, 47 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.762f ;			
			CombatReach = 3f ;
			SetDamage(4f*Level, 6*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.45f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Gorlash, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Grimungous: BaseCreature 
	 { 
		public  Grimungous() : base() 
		 { 
			Id = 8215 ; 
			Model = 12816;
			AttackSpeed= 1180;
			Name = "Grimungous" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 46, 50 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcFlags = 00 ;
			BoundingRadius = 0.561f ;			
			CombatReach = 4.5f ;
			SetDamage(2.36f*Level, 3.54*Level);
			ManaType=0;
			Elite=4;  
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Grimungous, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Ironaya: BaseCreature //boss, not done
	 { 
		public  Ironaya() : base() 
		 { 
			Id = 7228 ; 
			Model = 6089;
			AttackSpeed= 2900;
			Name = "Ironaya" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 63;
			Str = (int)(Level*1.7f);
			Armor=(int)(Level*70f);
			NpcType = (int)NpcTypes.Giant;
                    BaseMana = 84484;  
			NpcFlags = 00 ;
			BoundingRadius = 0.611f ;			
			CombatReach = 3.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			Block=Level-30;                    //need equipped weapon
                  Elite=3;  
			Faction = Factions.Monster;
			Size = 1.2f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			BCAddon.Hp( this, 70000, 63 );
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Ironaya, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class LandWalker: BaseCreature 
	 { 
		public  LandWalker() : base() 
		 { 
			Id = 5357 ; 
			Model = 10037;
			AttackSpeed= 1250;
			Name = "Land Walker" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 43, 49 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.607f ;			
			CombatReach = 3f ;
			SetDamage(2.5f*Level, 3.75*Level);
			ManaType=0;
			Elite=1;  
			Faction = Factions.Monster;
			Size = 1.45f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.LandWalker, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Landslide: BaseCreature 
	 { 
		public  Landslide() : base() 
		 { 
			Id = 12003 ; 
			Model = 12293;
			AttackSpeed= 2000;
			Name = "Landslide" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 45, 50 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
                  NpcFlags = 00 ;
			BoundingRadius = 0.536f ;			
			CombatReach = 3.2f ;
			SetDamage(4f*Level, 6*Level);
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.6f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Landslide, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class LordArkkoroc: BaseCreature 
	 { 
		public  LordArkkoroc() : base() 
		 { 
			Id = 6134 ; 
			Model = 170;
			AttackSpeed= 2000;
			Name = "Lord Arkkoroc" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 60;
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
                 	NpcFlags = 00 ;
			BoundingRadius = 0.603f ;			
			CombatReach = 4f ;
			SetDamage(4f*Level, 6*Level);
			ManaType=0;
			Elite=1;
                  Equip( new Bonecrusher());
                  NpcText00 = "Greetings $N, I am Lord Arkkoroc." ;  
			Faction = Factions.Friend;
			Size = 1.8f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new NonAgressiveAnimalAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			
		}
	}	
}

namespace Server.Creatures
{
	public class LoreKeeperOfNorgannon: BaseCreature 
	 { 
		public  LoreKeeperOfNorgannon() : base() 
		 { 
			Id = 7172 ; 
			Model = 6589;
			AttackSpeed= 2000;
			Name = "Lore Keeper of Norgannon" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 60;
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
                  NpcFlags = 00 ;
			BoundingRadius = 0.262f ;			
			CombatReach = 1.5f ;
			SetDamage(4f*Level, 6*Level);
			ManaType=0;
			//Block=Level-30;
                  Faction = Factions.Friend;
			Size = 0.75f;
                  NpcText00 = "Greetings." ;  
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new NonAgressiveAnimalAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			
		}
	}	
}

namespace Server.Creatures
{
	public class Magmus: BaseCreature 
	 { 
		public  Magmus() : base() 
		 { 
			Id = 9938 ; 
			Model = 12162;
			AttackSpeed= 1100;
			Name = "Magmus" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 55, 57 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.561f ;			
			CombatReach = 5f ;
			SetDamage(2.2f*Level, 3.3*Level);
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Magmus, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Mokrash: BaseCreature 
	 { 
		public  Mokrash() : base() 
		 { 
			Id = 1493 ; 
			Model = 12812;
			AttackSpeed= 1100;
			Name = "Mok'rash" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 46, 50 );
			NpcType = (int)NpcTypes.Giant;
                  NpcFlags = 00 ;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
                  BoundingRadius = 0.749f ;			
			CombatReach = 6f ;
			SetDamage(2.2f*Level, 3.3*Level);
			ManaType=0;
			//Block=Level-30;
                  Equip(new WhirlwindWarhammer());
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.6f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Mokrash, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class MoltenDestroyer: BaseCreature 
	 { 
		public  MoltenDestroyer() : base() 
		 { 
			Id = 11659 ; 
			Model = 12162;
			AttackSpeed= 1050;
			Name = "Molten Destroyer" ;
			Flags1 = 0x080800000 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 58, 60 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.561f ;			
			CombatReach = 5.5f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.MoltenDestroyer, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class MoltenGiant: BaseCreature 
	 { 
		public  MoltenGiant() : base() 
		 { 
			Id = 11658 ; 
			Model = 8269;
			AttackSpeed= 1050;
			Name = "Molten Giant" ;
			Flags1 = 0x080800000 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 57, 62 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 1.3f ;			
			CombatReach = 2.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.MoltenGiant, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class MonnosTheElder: BaseCreature 
	 { 
		public  MonnosTheElder() : base() 
		 { 
			Id = 6646 ; 
			Model = 12162;  //model is not right
			AttackSpeed= 2000;
			Name = "Monnos the Elder" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 53, 54 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 1.3f ;			
			CombatReach = 2.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=4;  
			Faction = Factions.Monster;
			Size = 2f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.MonnosTheElder, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class Negolash: BaseCreature 
	 { 
		public  Negolash() : base() 
		 { 
			Id = 1494 ; 
			Model = 12162; //wrong model
			AttackSpeed= 2000;
			Name = "Negolash" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow =  0;
			Level = RandomLevel( 51, 52 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcFlags = 00 ;
			BoundingRadius = 1.3f ;			
			CombatReach = 2.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.2f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Negolash, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class PrimordialBehemoth: BaseCreature 
	 { 
		public  PrimordialBehemoth() : base() 
		 { 
			Id = 12206 ; 
			Model = 12309;
			AttackSpeed= 2500;
			Name = "Primordial Behemoth" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 43, 49 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 2.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.3f;
			Speed = 4f ;
			WalkSpeed = 4f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.PrimordialBehemoth, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class RagingDuneSmasher: BaseCreature 
	 { 
		public  RagingDuneSmasher() : base() 
		 { 
			Id = 5470 ; 
			Model = 12816;
			AttackSpeed= 2000;
			Name = "Raging Dune Smasher" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 49, 50 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 3.2f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.6f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.RagingDuneSmasher, 100f ) };
		}
	}	
}
namespace Server.Creatures
{
	public class Rockbiter: BaseCreature 
	 { 
		public  Rockbiter() : base() 
		 { 
			Id = 7765 ; 
			Model = 1918;
			AttackSpeed= 1500;
			Name = "Rockbiter" ;
			Flags1 = 0x08400046 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 45;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
                  Armor = MobArmorHP.GetMobArmor ( Level);
			NpcType = (int)NpcTypes.Giant;
                  NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 2.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Faction = Factions.Friend;
			Size = 1.3f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new NonAgressiveAnimalAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
	
		}
	}	
}
namespace Server.Creatures
{
	public class ServantOfArkkoroc: BaseCreature 
	 { 
		public  ServantOfArkkoroc() : base() 
		 { 
			Id = 6143 ; 
			Model = 12812;
			AttackSpeed= 2700;
			Name = "Servant of Arkkoroc" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 50, 54 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 3.2f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Equip(new BulkyMaul());
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.6f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.ServantOfArkkoroc, 100f ) };
		}
	}	
}
namespace Server.Creatures
{
	public class ShoreStrider: BaseCreature 
	 { 
		public  ShoreStrider() : base() 
		 { 
			Id = 5359 ; 
			Model = 4945;
			AttackSpeed= 2700;
			Name = "Shore Strider" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 44, 49 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 3.5f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;
                  Equip(new VerigansFist());  
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.ShoreStrider, 100f ) };
		}
	}	
}
namespace Server.Creatures
{
	public class SonOfArkkoroc: BaseCreature 
	 { 
		public  SonOfArkkoroc() : base() 
		 { 
			Id = 6144 ; 
			Model = 4945;
			AttackSpeed= 2800;
			Name = "Son of Arkkoroc" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 51, 55 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 2.6f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Equip( new ThePacifier());
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.7f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.SonOfArkkoroc, 100f ) };
		}
	}	
}
namespace Server.Creatures
{
	public class StoneWatcherOfNorgannon: BaseCreature 
	 { 
		public  StoneWatcherOfNorgannon() : base() 
		 { 
			Id = 7918 ; 
			Model = 6589;
			AttackSpeed= 2000;
			Name = "Stone Watcher of Norgannon" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 60;
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.262f ;			
			CombatReach = 1.5f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Faction = Factions.Friend;
			Size = 0.75f;
                  NpcText00 = "Greetings." ;  
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new NonAgressiveAnimalAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			
		}
	}	
}



namespace Server.Creatures
{
	public class Thenan: BaseCreature 
	 { 
		public  Thenan() : base() 
		 { 
			Id = 2763 ; 
			Model = 10040;
			AttackSpeed= 1260;
			Name = "Thenan" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 41, 42 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level);  
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 6.5f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.3f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Thenan, 100f ) };
		}
	}	
}
namespace Server.Creatures
{
	public class Volchan: BaseCreature 
	 { 
		public  Volchan() : base() 
		 { 
			Id = 10119 ; 
			Model = 12232;
			AttackSpeed= 2000;
			Name = "Volchan" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 58, 60 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 4f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 2f;
			Speed = 4.2f ;
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PatrolAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.Volchan, 100f ) };
		}
	}	
}
namespace Server.Creatures
{
	public class WanderingProtector: BaseCreature 
	 { 
		public  WanderingProtector() : base() 
		 { 
			Id = 12836 ; 
			Model = 12750;
			AttackSpeed= 2000;
			Name = "Wandering Protector" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 35;
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level);
                  Armor = MobArmorHP.GetMobArmor ( Level); NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 5f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Faction = Factions.Monster;
			Size = 2f;
			Speed = 4f ;
			WalkSpeed = 4f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.WanderingProtector, 100f ) };
		}
	}	
}
namespace Server.Creatures
{
	public class WaveStrider: BaseCreature 
	 { 
		public  WaveStrider() : base() 
		 { 
			Id = 5361 ; 
			Model = 10039;
			AttackSpeed= 2500;
			Name = "Wave Strider" ;
			Flags1 = 0x00 ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 45, 48 );
			NpcType = (int)NpcTypes.Giant;
                  BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
                  Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 00 ;
			BoundingRadius = 0.503f ;			
			CombatReach = 3f ;
			SetDamage(1f+6.50f*Level,1f+9.1*Level);			
			ManaType=0;
			//Block=Level-30;
                  Elite=1;  
			Faction = Factions.Monster;
			Size = 1.45f;
			Speed = 4.2f ;
                  Equip( new WarMaul());
			WalkSpeed = 4.2f ;			
			RunSpeed = 7f ;
			AIEngine = new PredatorAI( this );
                    //	LearnSpell( 15571, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( GiantFamilyDrops.WaveStrider, 100f ) };
		}
	}	
}
