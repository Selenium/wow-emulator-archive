//	Script modified by Sapphiron - 03/06/05 15:14:24
//Script created by Sapphiron, please feel free to do any correction
//File: Spider.CS 
//June 01, 2005
//script completed by ccsman 11/08/05
//i've used :
//size formula : Size = 0.4f + Level/100f;    0.5 for elite/rare
//dmg formula : SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );    to get a stable DPS   

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class Besseleth : BaseCreature 
	{ 
		public  Besseleth() : base() 
		{ 
			Model = 11348;
			AttackSpeed= 2000;
			BoundingRadius = 0.99f ;
			Name = "Besseleth" ;
			Flags1 = 0x010 ;
			Id = 11921 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 20, 21 );
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
			Armor = MobArmorHP.GetMobArmor ( Level);   
			NpcFlags = 0 ;
			LearnSpell( 6751, SpellsTypes.Curse );
			Elite = 4;
			CombatReach = 1.875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Besseleth, 100f ) };	
		}
	}

	public class BlackWidowHatchling : BaseCreature 
	{ 
		public  BlackWidowHatchling() : base() 
		{ 
			Model = 368;
			AttackSpeed= 2000;
			BoundingRadius = 1.0285f ;
			Name = "Black Widow Hatchling" ;
			Flags1 = 0x010 ;
			Id = 930 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 20, 25 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level);   
			NpcFlags = 0 ;
			CombatReach = 0.825f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			LearnSpell( 6751, SpellsTypes.Curse );
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.BlackWidowHatchling, 100f ) };
		}
	}            

	public class CarrionLurker : BaseCreature 
	{ 
		public  CarrionLurker() : base() 
		{ 
			Model = 1091;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Carrion Lurker" ;
			Flags1 = 0x010 ;
			Id = 1821 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 49, 53 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level);   
			NpcFlags = 011 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.CarrionLurker, 100f ) };
		}
	}

	public class CarrionRecluse : BaseCreature 
	{ 
		public  CarrionRecluse() : base() 
		{ 
			Model = 545;
			AttackSpeed= 2000;
			BoundingRadius = 1.5895f ;
			Name = "Carrion Recluse" ;
			Flags1 = 0x010 ;
			Id = 949 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 22, 26 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level);   
			NpcFlags = 0 ;
			CombatReach = 1.275f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.CarrionRecluse, 100f ) };
		}
	}            

	public class CaveCreeper : BaseCreature 
	{ 
		public  CaveCreeper() : base() 
		{ 
			Model = 8014;
			AttackSpeed= 1399;
			BoundingRadius = 1.00f ;
			Name = "Cave Creeper" ;
			Flags1 = 0x010 ;
			Id = 8933 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 50, 52 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level);  
			NpcFlags = 0 ;
			CombatReach = 1f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.CaveCreeper, 100f ) }; 
		}
	}

	public class CaveStalker : BaseCreature 
	{ 
		public  CaveStalker() : base() 
		{ 
			Model = 959;
			AttackSpeed= 1819;
			BoundingRadius = 1.00f ;
			Name = "Cave Stalker" ;
			Flags1 = 0x010 ;
			Id = 4040 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 21, 22 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.CaveStalker, 100f ) };
		}
	}
   
	public class Chatter : BaseCreature 
	{ 
		public  Chatter() : base() 
		{ 
			Model = 821;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Chatter" ;
			Flags1 = 0x010 ;
			Id = 616 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 23;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Chatter, 100f ) };
		}
	}

	public class CliffLurker : BaseCreature 
	{ 
		public  CliffLurker() : base() 
		{ 
			Model = 827;
			AttackSpeed= 2000;
			BoundingRadius = 0.363f ;
			Name = "Cliff Lurker" ;
			Flags1 = 0x010 ;
			Id = 1184 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 10, 14 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.6875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.CliffLurker, 100f ) };
		}
	}

	public class Creepthess : BaseCreature 
	{ 
		public  Creepthess() : base() 
		{ 
			Model = 1091;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Creepthess" ;
			Flags1 = 0x010 ;
			Id = 14279 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 24;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			Faction = Factions.EvilBeast;
			LearnSpell( 6751, SpellsTypes.Curse );
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Creepthess, 100f ) };
		}
	} 

	public class DarkfangCreeper : BaseCreature 
	{ 
		public  DarkfangCreeper() : base() 
		{ 
			Model = 2546;
			AttackSpeed= 2000;
			BoundingRadius = 0.858f ;
			Name = "Darkfang Creeper" ;
			Flags1 = 0x010 ;
			Id = 4412 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 38, 39 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkfangCreeper, 100f ) };
		}
	}

	public class DarkfangLurker : BaseCreature 
	{ 
		public  DarkfangLurker() : base() 
		{ 
			Model = 2424;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Darkfang Lurker" ;
			Flags1 = 0x010 ;
			Id = 4411 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 33, 37 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkfangLurker, 100f ) };
		}
	}

	public class DarkfangSpider : BaseCreature 
	{ 
		public  DarkfangSpider() : base() 
		{ 
			Model = 2543;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Darkfang Spider" ;
			Flags1 = 0x010 ;
			Id = 4413 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35, 36 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkfangSpider, 100f ) };
		}
	}

	public class DarkfangVenomspitter : BaseCreature 
	{ 
		public  DarkfangVenomspitter() : base() 
		{ 
			Model = 2542;
			AttackSpeed= 2000;
			BoundingRadius = 0.759f ;
			Name = "Darkfang Venomspitter" ;
			Flags1 = 0x010 ;
			Id = 4414 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35, 38 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.4375f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			LearnSpell( 6751, SpellsTypes.Curse );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkfangVenomspitter, 100f ) };
		}
	}

	public class DarkmistLurker : BaseCreature 
	{ 
		public  DarkmistLurker() : base() 
		{ 
			Model = 2539;
			AttackSpeed= 2000;
			BoundingRadius = 1.5895f ;
			Name = "Darkmist Lurker" ;
			Flags1 = 0x010 ;
			Id = 4377 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35, 38 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.275f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkmistLurker, 100f ) };
		}
	}

	public class DarkmistRecluse : BaseCreature 
	{ 
		public  DarkmistRecluse() : base() 
		{ 
			Model = 2538;
			AttackSpeed= 2000;
			BoundingRadius = 1.5895f ;
			Name = "Darkmist Recluse" ;
			Flags1 = 0x010 ;
			Id = 4378 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 36, 37 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.275f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkmistRecluse, 100f ) };
		}
	}

	public class DarkmistSilkspinner : BaseCreature 
	{ 
		public  DarkmistSilkspinner() : base() 
		{ 
			Model = 2541;
			AttackSpeed= 2000;
			BoundingRadius = 1.309f ;
			Name = "Darkmist Silkspinner" ;
			Flags1 = 0x010 ;
			Id = 4379 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 36, 39 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.05f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkmistSilkspinner, 100f ) };
		}
	}

	public class DarkmistSpider : BaseCreature 
	{ 
		public  DarkmistSpider() : base() 
		{ 
			Model = 545;
			AttackSpeed= 2000;
			BoundingRadius = 1.5895f ;
			Name = "Darkmist Spider" ;
			Flags1 = 0x010 ;
			Id = 4376 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35, 36 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.275f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkmistSpider, 100f ) };
		}
	}

	public class DarkmistWidow : BaseCreature 
	{ 
		public  DarkmistWidow() : base() 
		{ 
			Model = 2537;
			AttackSpeed= 1412;
			BoundingRadius = 1.00f ;
			Name = "Darkmist Widow" ;
			Flags1 = 0x010 ;
			Id = 4380 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 40 ;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 16.00f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DarkmistWidow, 100f ) };
		}
	}

	public class DeathstrikeTarantula : BaseCreature 
	{ 
		public  DeathstrikeTarantula() : base() 
		{ 
			Model = 336;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Deathstrike Tarantula" ;
			Flags1 = 0x010 ;
			Id = 769 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 39, 41 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DeathstrikeTarantula, 100f ) };
		}
	}

	public class DeepmossCreeper : BaseCreature 
	{ 
		public  DeepmossCreeper() : base() 
		{ 
			Model = 760;
			AttackSpeed= 2000;
			BoundingRadius = 0.363f ;
			Name = "Deepmoss Creeper" ;
			Flags1 = 0x010 ;
			Id = 4005 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 14, 18 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.6875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DeepmossCreeper, 100f ) };
		}
	}

	public class DeepmossHatchling : BaseCreature 
	{ 
		public  DeepmossHatchling() : base() 
		{ 
			Model = 957;
			AttackSpeed= 2000;
			BoundingRadius = 0.830407f ;
			Name = "Deepmoss Hatchling" ;
			Flags1 = 0x010 ;
			Id = 4263 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 12, 15 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.666102f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DeepmossHatchling, 100f ) };
		}
	}

	public class DeepmossMatriarch : BaseCreature 
	{ 
		public  DeepmossMatriarch() : base() 
		{ 
			Model = 336;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Deepmoss Matriarch" ;
			Flags1 = 0x010 ;
			Id = 4264 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 22 ;
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DeepmossMatriarch, 100f ) };
		}
	}

	public class DeepmossVenomspitter : BaseCreature 
	{ 
		public  DeepmossVenomspitter() : base() 
		{ 
			Model = 759;
			AttackSpeed= 2000;
			BoundingRadius = 0.462f ;
			Name = "Deepmoss Venomspitter" ;
			Flags1 = 0x010 ;
			Id = 4007 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 15, 19 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DeepmossVenomspitter, 100f ) };
		}
	}

	public class DeepmossWebspinner : BaseCreature 
	{ 
		public  DeepmossWebspinner() : base() 
		{ 
			Model = 1989;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Deepmoss Webspinner" ;
			Flags1 = 0x010 ;
			Id = 4006 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 18, 21 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 8312, SpellsTypes.Curse );    //spider web
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.DeepmossWebspinner, 100f ) };
		}
	}

	public class ElderMossCreeper : BaseCreature 
	{ 
		public  ElderMossCreeper() : base() 
		{ 
			Model = 8014;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Elder Moss Creeper" ;
			Flags1 = 0x010 ;
			Id = 2348 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 26, 27 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.ElderMossCreeper, 100f ) };
		}
	}

	public class ForestLurker : BaseCreature
	{
		public ForestLurker() : base()
		{
			Name = "Forest Lurker";
			Id = 1195;
			Model = 827;
			Level = RandomLevel( 6, 13 );
			Size = 0.4f + Level/100f;  
			AttackSpeed = 1960;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.ForestLurker, 100.0f )};
		}
	}

	public class ForestMossCreeper : BaseCreature 
	{ 
		public  ForestMossCreeper() : base() 
		{ 
			Model = 1989;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Forest Moss Creeper" ;
			Flags1 = 0x010 ;
			Id = 2350 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 17, 21 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.ForestMossCreeper, 100f ) };
		}
	}

	public class ForestSpider : BaseCreature
	{
		public ForestSpider() : base()
		{
			Name = "Forest Spider";
			Id = 30;
			Model = 382;
			Level = RandomLevel( 2, 6 );
			Size = 0.4f + Level/100f;
			AttackSpeed = 1960;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );  
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.ForestSpider, 100.0f )};

		}
	}

	public class GiantDarkfangSpider : BaseCreature 
	{ 
		public  GiantDarkfangSpider() : base() 
		{ 
			Model = 11348;
			AttackSpeed= 2000;
			BoundingRadius = 0.99f ;
			Name = "Giant Darkfang Spider" ;
			Flags1 = 0x010 ;
			Id = 4415 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 39, 41 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GiantDarkfangSpider, 100f ) };
		}
	}

	public class GiantMossCreeper : BaseCreature 
	{ 
		public  GiantMossCreeper() : base() 
		{ 
			Model = 6808;
			AttackSpeed= 2000;
			BoundingRadius = 0.759f ;
			Name = "Giant Moss Creeper" ;
			Flags1 = 0x010 ;
			Id = 2349 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 24, 25 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.4375f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GiantMossCreeper, 100f ) };
		}
	}

	public class GiantPlagueLurker : BaseCreature 
	{ 
		public  GiantPlagueLurker() : base() 
		{ 
			Model = 1089;
			AttackSpeed= 2100;
			BoundingRadius = 1.00f ;
			Name = "Giant Plague Lurker" ;
			Flags1 = 0x010 ;
			Id = 1825 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 1 ;
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 11.00f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI (this);
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GiantPlagueLurker, 100f ) };
		}
	} 

	public class GiantPlainsCreeper : BaseCreature 
	{ 
		public  GiantPlainsCreeper() : base() 
		{ 
			Model = 1104;
			AttackSpeed= 2000;
			BoundingRadius = 0.759f ;
			Name = "Giant Plains Creeper" ;
			Flags1 = 0x010 ;
			Id = 2565 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35, 36 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.4375f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GiantPlainsCreeper, 100f ) };
		}
	}

	public class GiantVenomMistLurker : BaseCreature 
	{ 
		public  GiantVenomMistLurker() : base() 
		{ 
			Model = 1090;
			AttackSpeed= 2100;
			BoundingRadius = 1.00f ;
			Name = "Giant Venom Mist Lurker" ;
			Flags1 = 0x010 ;
			Id = 1823 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 1 ;
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 11.00f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GiantVenomMistLurker, 100f ) };
		}
	}

	public class GiantWebwoodSpider : BaseCreature
	{
		public GiantWebwoodSpider() : base()
		{
			Name = "Giant Webwood Spider";
			Id = 2001;
			Model = 6808;
			Level = RandomLevel ( 10, 11 );
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GiantWebwoodSpider, 100.0f )};
		}
	}

	public class GithyissTheVile : BaseCreature
	{
		public GithyissTheVile() : base()
		{
			Name = "Githyiss the Vile";
			Id = 1994;
			Model = 759;
			Level = 5;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.5f + Level/100f;
			Elite = 4;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GithyissTheVile, 100.0f )};

		}
	}

	public class GlasswebSpider : BaseCreature 
	{ 
		public  GlasswebSpider() : base() 
		{ 
			Model = 4456;
			AttackSpeed= 2000;
			BoundingRadius = 1.5895f ;
			Name = "Glassweb Spider" ;
			Flags1 = 0x010 ;
			Id = 5856 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 39, 45 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.275f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GlasswebSpider, 100f ) };
		}
	}

	public class GreaterLavaSpider : BaseCreature 
	{ 
		public  GreaterLavaSpider() : base() 
		{ 
			Model = 7510;
			AttackSpeed= 2000;
			BoundingRadius = 0.759f ;
			Name = "Greater Lava Spider" ;
			Flags1 = 0x010 ;
			Id = 5858 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 43, 49 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); NpcFlags = 0 ;
			CombatReach = 1.4375f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GreaterLavaSpider, 100f ) };
		}
	}

	public class GreaterTarantula : BaseCreature 
	{ 
		public  GreaterTarantula() : base() 
		{ 
			Model = 520;
			AttackSpeed= 2000;
			BoundingRadius = 0.462f ;
			Name = "Greater Tarantula" ;
			Flags1 = 0x010 ;
			Id = 505 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 14, 20 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GreaterTarantula, 100f ) };
		}
	}

	public class GreenRecluse : BaseCreature 
	{ 
		public  GreenRecluse() : base() 
		{ 
			Model = 2541;
			AttackSpeed= 2000;
			BoundingRadius = 1.309f ;
			Name = "Green Recluse" ;
			Flags1 = 0x010 ;
			Id = 569 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 20, 22 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 013 ;
			CombatReach = 1.05f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.GreenRecluse, 100f ) };
		}
	}

	public class Gretheer : BaseCreature 
	{ 
		public  Gretheer() : base() 
		{ 
			Model = 513;
			AttackSpeed= 2000;
			BoundingRadius = 1.309f ;
			Name = "Gretheer" ;
			Flags1 = 0x010 ;
			Id = 14472 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 57;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0;
			CombatReach = 1.05f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Gretheer, 100f ) };
		}
	}

	public class KrethisShadowspinner : BaseCreature 
	{ 
		public  KrethisShadowspinner() : base() 
		{ 
			Model = 368;
			AttackSpeed= 2000;
			BoundingRadius = 1.0285f ;
			Name = "Krethis Shadowspinner" ;
			Flags1 = 0x010 ;
			Id = 12433 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 15 ;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.825f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.KrethisShadowspinner, 100f ) };
		}
	}

	public class LadySathrah : BaseCreature
	{
		public LadySathrah() : base()
		{
			Name = "Lady Sathrah";
			Id = 7319;
			Model = 6214;
			Level = 12;
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Elite = 4;  
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.LadySathrah, 100.0f )};
		}
	}

	public class LeechStalker : BaseCreature 
	{ 
		public  LeechStalker() : base() 
		{ 
			Model = 711;
			AttackSpeed= 2000;
			BoundingRadius = 1.0285f ;
			Name = "Leech Stalker" ;
			Flags1 = 0x010 ;
			Id = 1111 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 18, 22 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.825f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			LearnSpell( 6751, SpellsTypes.Curse );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.LeechStalker, 100f ) };
		}
	}

	public class LeechWidow : BaseCreature 
	{ 
		public  LeechWidow() : base() 
		{ 
			Model = 955;
			AttackSpeed= 2000;
			BoundingRadius = 0.931831f ;
			Name = "Leech Widow" ;
			Flags1 = 0x010 ;
			Id = 1112 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 24;
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.747458f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new EvilInteligentMonsterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.LeechWidow, 100f ) };
		}
	} 

	public class MineSpider : BaseCreature
	{
		public MineSpider() : base()
		{
			Name = "Mine Spider";
			Id = 43;
			Model = 368;
			Level = RandomLevel(7,9);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
//			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.MineSpider, 100.0f )};
		}
public override void OnAddToWorld()
    {
    if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new SpellCasterAI( this );
    }
							 
	}

	public class MistCreeper : BaseCreature 
	{ 
		public  MistCreeper() : base() 
		{ 
			Model = 760;
			AttackSpeed= 2000;
			BoundingRadius = 0.363f ;
			Name = "Mist Creeper" ;
			Flags1 = 0x010 ;
			Id = 1781 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 13, 14 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.6875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			LearnSpell( 6751, SpellsTypes.Curse );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.MistCreeper, 100f ) };
		}
	}

	public class MossStalker : BaseCreature
	{
		public MossStalker() : base()
		{
			Name = "Moss Stalker";
			Id = 1780;
			Model = 827;
			Level = RandomLevel(12,13);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.MossStalker, 100.0f )};
		}
	}

	public class MotherFang : BaseCreature
	{
		public MotherFang() : base()
		{
			Name = "Mother Fang";
			Id = 471;
			Model = 2541;
			Level = 10;
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			Elite = 4;
//			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.MotherFang, 100.0f )};
		}
public override void OnAddToWorld()
    {
    if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new SpellCasterAI( this );
    }
	    
	    
	}

	public class Naraxis : BaseCreature 
	{ 
		public  Naraxis() : base() 
		{ 
			Model = 963;
			AttackSpeed= 1578;
			BoundingRadius = 1.00f ;
			Name = "Naraxis" ;
			Flags1 = 0x010 ;
			Id = 574 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 27 ;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); ;
			NpcFlags = 0 ;
			CombatReach = 16.00f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			LearnSpell( 6751, SpellsTypes.Curse );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Naraxis, 100f ) };
		}
	}

	public class NightWebMatriarch : BaseCreature 
	{ 
		public  NightWebMatriarch() : base() 
		{ 
			Model = 368;
			AttackSpeed= 2000;
			BoundingRadius = 1.0285f ;
			Name = "Night Web Matriarch" ;
			Flags1 = 0x010 ;
			Id = 1688 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 5 ;
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.825f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.NightWebMatriarch, 100f ) };
		}
	} 

	public class NightWebSpider : BaseCreature
	{
		public NightWebSpider() : base()
		{
			Name = "Night Web Spider";
			Id = 1505;
			Model = 30;
			Level = RandomLevel(3,4);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.NightWebSpider, 100.0f )};
		}
	}

	public class PlagueLurker : BaseCreature 
	{ 
		public  PlagueLurker() : base() 
		{ 
			Model = 1088;
			AttackSpeed= 2000;
			BoundingRadius = 1.87f ;
			Name = "Plague Lurker" ;
			Flags1 = 0x010 ;
			Id = 1824 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 53, 55 );
			Size = 0.4f + Level/100f;
			NpcType = 1 ;
			BaseHitPoints = 1722 ;
			NpcFlags = 0 ;
			CombatReach = 1.5f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.PlagueLurker, 100f ) };
		}
	}

	public class PlainsCreeper : BaseCreature 
	{ 
		public  PlainsCreeper() : base() 
		{ 
			Model = 1103;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Plains Creeper" ;
			Flags1 = 0x010 ;
			Id = 2563 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 28, 33 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.PlainsCreeper, 100f ) };
		}
	}

	public class PygmyVenomWebSpider : BaseCreature 
	{ 
		public  PygmyVenomWebSpider() : base() 
		{ 
			Model = 958;
			AttackSpeed= 2000;
			BoundingRadius = 1.0285f ;
			Name = "Pygmy Venom Web Spider" ;
			Flags1 = 0x010 ;
			Id = 539 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 15, 19 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.825f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.PygmyVenomWebSpider, 100f ) };
		}
	}

	public class Rekktilac : BaseCreature 
	{ 
		public  Rekktilac() : base() 
		{ 
			Model = 4458;
			AttackSpeed= 2000;
			BoundingRadius = 0.858f ;
			Name = "Rekk'tilac" ;
			Flags1 = 0x010 ;
			Id = 8277 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 48;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Rekktilac, 100f ) };
		}
	}

	public class RockStalker : BaseCreature 
	{ 
		public  RockStalker() : base() 
		{ 
			Model = 711;
			AttackSpeed= 2100;
			BoundingRadius = 1.00f ;
			Name = "Rock Stalker" ;
			Flags1 = 0x00000000 ;
			Id = 11739 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 58, 60 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 11.00f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			LearnSpell( 6751, SpellsTypes.Curse );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.RockStalker, 100f ) };
		}
	}

	public class SandSkitterer : BaseCreature 
	{ 
		public  SandSkitterer() : base() 
		{ 
			Model = 8014;
			AttackSpeed= 1344;
			BoundingRadius = 1.00f ;
			Name = "Sand Skitterer" ;
			Flags1 = 0x010 ;
			Id = 11738 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 53, 56 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 11.00f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.SandSkitterer, 100f ) };
		}
	}

	public class SearingLavaSpider : BaseCreature 
	{ 
		public  SearingLavaSpider() : base() 
		{ 
			Model = 4457;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Searing Lava Spider" ;
			Flags1 = 0x010 ;
			Id = 5857 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 42, 47 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.SearingLavaSpider, 100f ) };
		}
	}

	public class ShandaTheSpinner : BaseNPC 
	{ 
		public  ShandaTheSpinner() : base() 
		{ 
			Model = 1103;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Shanda the Spinner" ;
			Flags1 = 0x010 ;
			Id = 14266 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = 19;
			Size = 0.5f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			Elite = 4;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.ShandaTheSpinner, 100f ) };
		}
	}

	public class SorrowSpinner : BaseCreature 
	{ 
		public  SorrowSpinner() : base() 
		{ 
			Model = 2543;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Sorrow Spinner" ;
			Flags1 = 0x010 ;
			Id = 858 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 32, 37 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.SorrowSpinner, 100f ) };
		}
	} 

	public class SpireSpiderling : BaseCreature 
	{ 
		public  SpireSpiderling() : base() 
		{ 
			Model = 9756;
			AttackSpeed= 1371;
			BoundingRadius = 1.00f ;
			Name = "Spire Spiderling" ;
			Flags1 = 0x010 ;
			Id = 10375 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 50, 56 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.00f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			LearnSpell( 6751, SpellsTypes.Curse );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.SpireSpiderling, 100f ) };
		}
	}

	public class Sriskulk : BaseCreature
	{
		public Sriskulk() : base()
		{
			Name = "Sri'skulk";
			Id = 10359;
			Model = 418;
			Level = 13;
			AttackSpeed = 2020;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Sriskulk, 100.0f )};
		}
	}

	public class Tarantula : BaseCreature 
	{ 
		public  Tarantula() : base() 
		{ 
			Model = 366;
			AttackSpeed= 2000;
			BoundingRadius = 0.363f ;
			Name = "Tarantula" ;
			Flags1 = 0x010 ;
			Id = 442 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 10, 16 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.6875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.Tarantula, 100f ) };
		}
	}

	public class TimberwebRecluse : BaseCreature 
	{ 
		public  TimberwebRecluse() : base() 
		{ 
			Model = 8014;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Timberweb Recluse" ;
			Flags1 = 0x010 ;
			Id = 8762 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 45, 48 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.TimberwebRecluse, 100f ) };
		}
	}

	public class VenomMistLurker : BaseCreature 
	{ 
		public  VenomMistLurker() : base() 
		{ 
			Model = 1087;
			AttackSpeed= 2000;
			BoundingRadius = 1.5895f ;
			Name = "Venom Mist Lurker" ;
			Flags1 = 0x010 ;
			Id = 1822 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 45, 51 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.275f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.VenomMistLurker, 100f ) };
		}
	}

	public class VenomWebSpider : BaseCreature 
	{ 
		public  VenomWebSpider() : base() 
		{ 
			Model = 955;
			AttackSpeed= 2000;
			BoundingRadius = 1.309f ;
			Name = "Venom Web Spider" ;
			Flags1 = 0x010 ;
			Id = 217 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 17, 20 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.05f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.VenomWebSpider, 100f ) };
		}
	}

	public class ViciousNightWebSpider : BaseCreature
	{
		public ViciousNightWebSpider() : base()
		{
			Name = "Vicious Night Web Spider";
			Id = 1555;
			Model = 368;
			Level = RandomLevel(9,10);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.NightWebSpider, 100.0f )};
		}
	}

	public class WebwoodLurker : BaseCreature
	{
		public WebwoodLurker() : base()
		{
			Name = "Webwood Lurker";
			Id = 1998;
			Model = 760;
			Level = RandomLevel(2,6);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 6751, SpellsTypes.Curse );
			LearnSpell( 744, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.ForestLurker, 100.0f )};
		}
	}

	public class WebwoodSilkspinner : BaseCreature
	{
		public WebwoodSilkspinner() : base()
		{
			Name = "Webwood Silkspinner";
			Id = 2000;
			Model = 1989;
			Level = RandomLevel(8,9);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 8312, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WebwoodSilkspinner, 100.0f )};
		}
	}

	public class WebwoodSpider : BaseCreature
	{
		public WebwoodSpider() : base()
		{
			Name = "Webwood Spider";
			Id = 1986;
			Model = 709;
			Level = RandomLevel(3,4);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WebwoodSpider, 100.0f )};
		}
	}

	public class WebwoodVenomfang : BaseCreature
	{
		public WebwoodVenomfang() : base()
		{
			Name = "Webwood Venomfang";
			Id = 1999;
			Model = 759;
			Level = RandomLevel(4,8);
			AttackSpeed = 1950;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WebwoodVenomfang, 100.0f )};
		}
	}

	public class WildthornLurker : BaseCreature 
	{ 
		public  WildthornLurker() : base() 
		{ 
			Model = 1104;
			AttackSpeed= 2000;
			BoundingRadius = 0.759f ;
			Name = "Wildthorn Lurker" ;
			Flags1 = 0x010 ;
			Id = 3821 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 28, 29 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.4375f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WildthornLurker, 100f ) };
		}
	} 

	public class WildthornStalker : BaseCreature 
	{ 
		public  WildthornStalker() : base() 
		{ 
			Model = 1103;
			AttackSpeed= 2000;
			BoundingRadius = 0.561f ;
			Name = "Wildthorn Stalker" ;
			Flags1 = 0x010 ;
			Id = 3819 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 15, 21 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.0625f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WildthornStalker, 100f ) };
		}
	}

	public class WildthornVenomspitter : BaseCreature 
	{ 
		public  WildthornVenomspitter() : base() 
		{ 
			Model = 336;
			AttackSpeed= 2000;
			BoundingRadius = 0.66f ;
			Name = "Wildthorn Venomspitter" ;
			Flags1 = 0x010 ;
			Id = 3820 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 23, 25 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.25f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WildthornVenomspitter, 100f ) };
		}
	}

	public class WitherbarkBroodguard : BaseCreature 
	{ 
		public  WitherbarkBroodguard() : base() 
		{ 
			Model = 1157;
			AttackSpeed= 2000;
			BoundingRadius = 1.87f ;
			Name = "Witherbark Broodguard" ;
			Flags1 = 0x010 ;
			Id = 2686 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 39, 45 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 1.5f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WitherbarkBroodguard, 100f ) };

		}
	}

	public class WoodLurker : BaseCreature 
	{ 
		public  WoodLurker() : base() 
		{ 
			Model = 520;
			AttackSpeed= 2000;
			BoundingRadius = 0.462f ;
			Name = "Wood Lurker" ;
			Flags1 = 0x010 ;
			Id = 1185 ; 
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 13, 18 );
			Size = 0.4f + Level/100f;
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			NpcFlags = 0 ;
			CombatReach = 0.875f ;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.WoodLurker, 100f ) };
		}
	} 

	public class YoungNightWebSpider : BaseCreature
	{
		public YoungNightWebSpider() : base()
		{
			Name = "Young Night Web Spider";
			Id = 1504;
			Model = 513;
			Level = RandomLevel(2,3);
			AttackSpeed = 2000;
			SetDamage ((1f*AttackSpeed/1000f)*Level, (2f*AttackSpeed/1000f)*Level );
			NpcType = (int)NpcTypes.Beast ;
			ManaType = 1;    
			BaseMana = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
			Armor = MobArmorHP.GetMobArmor ( Level); 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.4f + Level/100f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;			
			NpcType = 1;
			LearnSpell( 6751, SpellsTypes.Curse );
			Loots = new BaseTreasure[]{ new BaseTreasure( SpiderFamilyDrops.YoungNightWebSpider, 100.0f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new SpellCasterAI( this );
		}
	}
}