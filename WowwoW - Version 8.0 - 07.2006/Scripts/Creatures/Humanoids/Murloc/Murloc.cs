// script by komareka (vortex)
// Editing and fix DrilLer
using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class Murloc : BaseCreature
	{
		public Murloc() : base()
		{
			Name = "Murloc";
			Id = 285;
			Model = 617;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(6f,10f);
			AttackSpeed = 2000;
			Block = 3;
			ResistArcane = 1;
			ResistFire = 1;
			ResistFrost = 1;
			ResistHoly = 1;
			ResistNature = 1;
			ResistShadow = 0;
			BoundingRadius = 0.375300f;
			CombatReach = 10.38f;
			ManaType=0;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 130;
			Size = 1f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 0; 
			Flags1 = 0x010080000;
			Equip(new FeebleSword());
			LearnSpell( 133, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurloclootDrops.Murlocloot , 100f )
			, new BaseTreasure( Drops.MoneyA , 100f ) };

			BCAddon.Hp( this, 113, 6 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocCoastrunner : BaseCreature
	{
		public MurlocCoastrunner() : base()
		{
			Name = "Murloc Coastrunner";
			Id = 126;
			Model = 983;
			Level = RandomLevel(12,13);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(13f,20f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 3;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 1;
			BoundingRadius = 0.375300f;
			CombatReach = 0.380000f;
			ManaType=0;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 251;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BronzeShortsword());
			LearnSpell( 7357, SpellsTypes.Offensive );
			LearnSpell( 16656, SpellsTypes.Offensive );					
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocCoastrunnerDrops.MurlocCoastrunner , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 229, 12 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocFlesheater : BaseCreature
	{
		public MurlocFlesheater() : base()
		{
			Name = "Murloc Flesheater";
			Id = 422;
			Model = 506;
			Level = RandomLevel(18,19);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(19f,28f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 3;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 1;
			ResistNature = 3;
			ResistShadow = 3;
			BoundingRadius = 0.479550f;
			CombatReach = 0.48f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 320;
			Size = 1.75f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BronzeShortsword());
			LearnSpell( 3393, SpellsTypes.Offensive );			
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocFlesheaterDrops.MurlocFlesheater , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 300, 18 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocForager : BaseCreature
	{
		public MurlocForager() : base()
		{
			Name = "Murloc Forager";
			Id = 46;
			Model = 441;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(9f,14f);
			AttackSpeed = 2000;
			Block = 2;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			BoundingRadius = 0.375300f;
			CombatReach = 0.38f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 250;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new EluniteSword());
			LearnSpell( 3368, SpellsTypes.Healing );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocForagerDrops.MurlocForager , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 216, 9 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocHunter : BaseCreature
	{
		public MurlocHunter() : base()
		{
			Name = "Murloc Hunter";
			Id = 458;
			Model = 757;
			Level = RandomLevel(16,17);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(18f,26f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 2;
			ResistFire = 3;
			ResistFrost = 2;
			ResistHoly = 1;
			ResistNature = 2;
			ResistShadow = 2;
			BoundingRadius = 0.437850f;
			CombatReach = 0.44f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 345;
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip( new Item( 7485, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ),new Item( 22671, InventoryTypes.Thrown, 2, 16, 1, 0, 0, 0, 0 ) ); 			
			//Equip(new BronzeShortsword());
			LearnSpell( 1604, SpellsTypes.Offensive );
			LearnSpell( 10277, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocHunterDrops.MurlocHunter , 90f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 360, 16 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocLurker : BaseCreature
	{
		public MurlocLurker() : base()
		{
			Name = "Murloc Lurker";
			Id = 732;
			Model = 983;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(10f,15f);
			AttackSpeed = 2000;
			Block = 2;
			ResistArcane = 2;
			ResistFire = 1;
			ResistFrost = 1;
			ResistHoly = 1;
			ResistNature = 1;
			ResistShadow = 1;
			BoundingRadius = 0.375300f;
			CombatReach = 0.38f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 205;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new CopperShortsword());
			LearnSpell( 1604, SpellsTypes.Offensive );
			LearnSpell( 2589, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocLurkerDrops.MurlocLurker , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 190, 9 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocMinorOracle : BaseCreature
	{
		public MurlocMinorOracle() : base()
		{
			Name = "Murloc Minor Oracle";
			Id = 456;
			Model = 486;
			Level = RandomLevel(13,14);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(16f,30f);
			AttackSpeed = 2000;
			Block = 3;
			ResistArcane = 3;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 1;
			ResistNature = 1;
			ResistShadow = 1;
			BoundingRadius = 0.375f;
			CombatReach = 0.350000f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 264;
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BarbedClub());
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocMinorOracleDrops.MurlocMinorOracle , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 286, 13 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocMinorTidecaller : BaseCreature
	{
		public MurlocMinorTidecaller() : base()
		{
			Name = "Murloc Minor Tidecaller";
			Id = 548;
			Model = 1079;
			Level = RandomLevel(17,18);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(20f,23f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 3;
			ResistFire = 3;
			ResistFrost = 3;
			ResistHoly = 3;
			ResistNature = 3;
			ResistShadow = 3;
			BoundingRadius = 0.417000f;
			CombatReach = 0.500000f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 390;
			Size = 1.5f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BarbedClub());
			LearnSpell( 205, SpellsTypes.Offensive );
			LearnSpell( 331, SpellsTypes.Healing );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocMinorTidecallerDrops.MurlocMinorTidecaller , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 262, 17 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocNetter : BaseCreature
	{
		public MurlocNetter() : base()
		{
			Name = "Murloc Netter";
			Id = 513;
			Model = 1994;
			Level = RandomLevel(14,15);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(15f,23f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 5;
			ResistFire = 2;
			ResistFrost = 3;
			ResistHoly = 3;
			ResistNature = 2;
			ResistShadow = 1;
			BoundingRadius = 0.375300f;
			CombatReach = 0.38f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 390;
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BlackMetalShortsword());
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocNetterDrops.MurlocNetter , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 262, 14 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocNightcrawler : BaseCreature
	{
		public MurlocNightcrawler() : base()
		{
			Name = "Murloc Nightcrawler";
			Id = 544;
			Model = 5243;
			Level = RandomLevel(21,22);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(22f,32f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 5;
			ResistFire = 2;
			ResistFrost = 3;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 5;
			BoundingRadius = 1.000000f;
			CombatReach = 0.80f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 390;
			Size = 2f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00;
			Flags1 = 0x010080000;
			Equip(new BaronsScepter());
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocNightcrawlerDrops.MurlocNightcrawler , 100f )
										  , new BaseTreasure( Drops.MoneyB , 100f )
									  };
			BCAddon.Hp( this, 357, 21 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocOracle : BaseCreature
	{
		public MurlocOracle() : base()
		{
			Name = "Murloc Oracle";
			Id = 517;
			Model = 1079;
			Level = RandomLevel(17,18);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(21f,25f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 3;
			ResistFire = 1;
			ResistFrost = 1;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 4;
			BoundingRadius = 0.625500f;
			CombatReach = 0.650000f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 457;
			Size = 1.5f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BarbedClub());
			LearnSpell( 13519, SpellsTypes.Offensive );	
			LearnSpell( 6074, SpellsTypes.Healing );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocOracleDrops.MurlocOracle , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 399, 17 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocRaider : BaseCreature
	{
		public MurlocRaider() : base()
		{
			Name = "Murloc Raider";
			Id = 515;
			Model = 441;
			Level = RandomLevel(11,12);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(10f,11f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			BoundingRadius = 0.354450f;
			CombatReach = 0.35f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 215;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BillyClub());	
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocRaiderDrops.MurlocRaider , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 233, 11 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocScout : BaseCreature
	{
		public MurlocScout() : base()
		{
			Name = "Murloc Scout";
			Id = 578;
			Model = 391;
			Level = RandomLevel(19,20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(20f,29f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 2;
			ResistFire = 3;
			ResistFrost = 4;
			ResistHoly = 2;
			ResistNature = 1;
			ResistShadow = 5;
			BoundingRadius = 0.500400f;
			CombatReach = 0.50f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 362;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new BarbedClub());
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocScoutDrops.MurlocScout , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 335, 19 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocShorestriker : BaseCreature
	{
		public MurlocShorestriker() : base()
		{
			Name = "Murloc Shorestriker";
			Id = 1083;
			Model = 1305;
			Level = RandomLevel(16,17);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(17f,25f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 3;
			ResistFire = 3;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 1;
			ResistShadow = 2;
			BoundingRadius = 0.458700f;
			CombatReach = 0.46f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 278;
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new RedridgeMachete());
			LearnSpell( 6268, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocShorestrikerDrops.MurlocShorestriker , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 258, 16 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocStreamrunner : BaseCreature
	{
		public MurlocStreamrunner() : base()
		{
			Name = "Murloc Streamrunner";
			Id = 735;
			Model = 527;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(7f,8f);
			AttackSpeed = 2000;
			Block = 2;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			BoundingRadius = 1.354450f;
			CombatReach = 1.275000f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 159;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new AnvilmarHammer());
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocStreamrunnerDrops.MurlocStreamrunner , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 127, 6 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocTidecaller : BaseCreature
	{
		public MurlocTidecaller() : base()
		{
			Name = "Murloc Tidecaller";
			Id = 545;
			Model = 5293;
			Level = RandomLevel(19,20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(21f,31f);
			AttackSpeed = 2000;
			Block = 5;
			ResistArcane = 3;
			ResistFire = 3;
			ResistFrost = 3;
			ResistHoly = 3;
			ResistNature = 3;
			ResistShadow = 3;
			BoundingRadius = 0.500400f;
			CombatReach = 0.50f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 456;
			Size = 2f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new KeenAxe());
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocTidecallerDrops.MurlocTidecaller , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 359, 19 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocTidehunter : BaseCreature
	{
		public MurlocTidehunter() : base()
		{
			Name = "Murloc Tidehunter";
			Id = 127;
			Model = 1995;
			Level = RandomLevel(18,19);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(20f,29f);
			AttackSpeed = 2000;
			Block = 4;
			ResistArcane = 2;
			ResistFire = 3;
			ResistFrost = 3;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			BoundingRadius = 0.500400f;
			CombatReach = 0.500000f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.045);
			BaseMana = 456;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new ThungrimsAxe());
			LearnSpell( 744, SpellsTypes.Offensive );
			LearnSpell( 865, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocTidehunterDrops.MurlocTidehunter , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 389, 18 );
		}
	}
}

namespace Server.Creatures
{
	public class MurlocWarrior : BaseCreature
	{
		public MurlocWarrior() : base()
		{
			Name = "Murloc Warrior";
			Id = 171;
			Model = 1305;
			Level = RandomLevel(15,16);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);//(15f,23f);
			AttackSpeed = 2000;
			Block = 4;
			ResistArcane = 2;
			ResistFire = 3;
			ResistFrost = 2;
			ResistHoly = 3;
			ResistNature = 2;
			ResistShadow = 2;
			BoundingRadius = 0.500400f;
			CombatReach = 0.500000f;
			Str = (int)(Level*1.5f);
			Armor=(int)(Level*1.1);
			BaseMana = 310;
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new CowardAI( this );
			NpcType = (int)NpcTypes.Humanoid; 
			NpcFlags = 00 ; Flags1 = 0x010080000;
			Equip(new DeadminesCleaver());
			Loots = new BaseTreasure[]{  new BaseTreasure( MurlocWarriorDrops.MurlocWarrior , 100f )
										  , new BaseTreasure( Drops.MoneyA , 100f )
									  };
			BCAddon.Hp( this, 369, 15 );
		}
	}
}
