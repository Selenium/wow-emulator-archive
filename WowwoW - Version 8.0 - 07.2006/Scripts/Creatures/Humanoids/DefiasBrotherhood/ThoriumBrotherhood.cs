// Script made by Albyore - 23/05/05 09:59
// Defias Brotherhood under lvl 12
//the current formulas for defias are: 
//FIGHTERS 
//HP: 48+32.4*lvl 
//mana: none 
//attack speed: 2000-(Level-2)*13 
//armor: based on leather items armor for current lvl mobs (+-10) 
//MAGE
//HP:24+22.3*lvl 
//mana: 100+32.4*lvl 
//attack speed: 2000-(Level-2)*10 
//armor based in cloath items for the mob lvl (+-10)

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class DefiasThug : BaseCreature
	{
		public DefiasThug() : base()
		{
			Name = "Defias Thug";
			Id = 38;
			Model = 5035;
			Level = RandomLevel(3,4);
			//SetDamage(3f,4f);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			//AttackSpeed = 1948;
			AttackSpeed = 2000;
			Armor = 18*Level;
			Block = 1*Level;
			BaseHitPoints = 48+33*Level;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Defias Brotherhood";
			/*****************************/
			BCAddon.Hp( this, 147, 3 );
			/*****************************/
			Equip(new BloodwovenMask());
			Equip(new Shortsword()); //Equip(new JeweledDagger());			
			Loots = new BaseTreasure[]{new BaseTreasure( DefiasDrops.DefiasThug , 5f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasCutpurse : BaseCreature
	{
		public DefiasCutpurse() : base()
		{
			Name = "Defias Cutpurse";
			Id = 94;
			Model = 2361;
			Level = RandomLevel(5,6);
			//SetDamage(5f,8f);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			//AttackSpeed = 1946;
			AttackSpeed = 2000;
			Armor = 14*Level;
			Block = 2*Level;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Defias Brotherhood";
			/*****************************/
			BCAddon.Hp( this, 213, 5 );
			/*****************************/
			Equip(new BloodwovenMask());
			Equip(new SimpleDagger());			
			Equip(new SimpleDagger());
			Loots = new BaseTreasure[]{new BaseTreasure( DefiasDrops.DefiasCutpurse , 5f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasBandit : BaseCreature
	{
		public DefiasBandit() : base()
		{
			Name = "Defias Bandit";
			Id = 116;
			Model = 2357;
			Level = RandomLevel(7,9);
			//SetDamage(7f,12f);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			//AttackSpeed = 1944;
			AttackSpeed = 2000;
			Armor = 14*Level;
			Block = 2*Level;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			/*****************************/
			BCAddon.Hp( this, 279, 7 );
			/*****************************/
			//Guild = "Defias Brotherhood";			
			Equip(new BloodwovenMask());
			Equip(new BuzzerBlade());			
			Loots = new BaseTreasure[]{new BaseTreasure( DefiasDrops.DefiasBandit , 100f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasRogueWizard : BaseCreature
	{
		public DefiasRogueWizard() : base()
		{
			Name = "Defias Rogue Wizard";
			Id = 474;
			Model = 2359;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000-(Level-2)*10;
			Armor = 10*Level;
			ResistFrost = 1*Level;
			Block = 1;
			BaseMana = 100+33*Level;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;
			//Guild = "Defias Brotherhood";
			/*****************************/
			BCAddon.Hp( this, 222, 9 );
			/*****************************/
			Equip(new BloodwovenMask());
			Equip(new FoamspittleStaff());			
			LearnSpell( 116, SpellsTypes.Offensive );
			LearnSpell( 6136, SpellsTypes.Healing );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasDrops.DefiasRogueWizard , 100f )
							,new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasAmbusher : BaseCreature
	{
		public DefiasAmbusher() : base()
		{
			Name = "Defias Ambusher";
			Id = 583;
			Model = 184;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 11*Level;
			Block = 2*Level;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Defias Brotherhood";
			/*****************************/
			BCAddon.Hp( this, 345, 9 );
			/*****************************/
			Equip(new BloodwovenMask());
			Equip(new PittedDefiasShortsword());			
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasDrops.DefiasAmbusher , 100f )
								, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasFootpad : BaseCreature
	{
		public DefiasFootpad() : base()
		{
			Name = "Defias Footpad";
			Id = 481;
			Model = 2333;
			Level = RandomLevel(9,11);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 14*Level;
			Block = 2*Level;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Defias Brotherhood";
			/*****************************/
			BCAddon.Hp( this, 345, 9 );
			/*****************************/
			Equip(new BloodwovenMask());
			Equip(new BroadBladedKnife());			
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasDrops.DefiasFootpad , 100f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasDockmaster : BaseCreature
	{
		public DefiasDockmaster() : base()
		{
			Name = "Defias Dockmaster";
			Id = 6846;
			Model = 7849;
			Level = RandomLevel(8,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 11*Level;
			Block = 2*Level;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Defias Brotherhood";
			/*****************************/
			BCAddon.Hp( this, 312, 8 );
			/*****************************/
			Equip(new BloodwovenMask());			
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasDrops.DefiasDockmaster , 100f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasBodyguard : BaseCreature
	{
		public DefiasBodyguard() : base()
		{
			Name = "Defias Bodyguard";
			Id = 6866;
			Model = 2340;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 14*Level;
			Block = 1;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Defias Brotherhood";
			Equip(new BloodwovenMask());
			LearnSpell( 53, SpellsTypes.Offensive );
			LearnSpell( 676, SpellsTypes.Offensive );
			/*****************************/
			BCAddon.Hp( this, 345, 9 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasDrops.DefiasBodyguard , 100f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DefiasDockworker : BaseCreature
	{
		public DefiasDockworker() : base()
		{
			Name = "Defias Dockworker";
			Id = 6927;
			Model = 2357;
			Level = RandomLevel(7, 9);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = 1;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			/*****************************/
			BCAddon.Hp( this, 279, 7 );
			/*****************************/
			//Guild = "Defias Brotherhood";
			Equip(new BloodwovenMask());
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasDrops.DefiasDockworker , 100f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}


namespace Server.Creatures
{
	public class DefiasBlackguard : BaseCreature
	{
		public DefiasBlackguard() : base()
		{
			Name = "Defias Blackguard";
			Id = 636;
			Model = 2314;
			Level = RandomLevel(19, 20);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.100f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 1045, 19 );
			/*****************************/
			Equip( new Item( 6469, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasDrops.DefiasBlackguard, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}


namespace Server.Creatures
{
	public class GarrickPadfoot : BaseCreature
	{
		public GarrickPadfoot() : base()
		{
			Name = "Garrick Padfoot";
			Id = 103;
			Model = 2073;
			Level = RandomLevel(5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			Equip(new PittedDefiasShortsword());
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.GarrickPadfoot , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasSmuggler : BaseCreature
	{
		public DefiasSmuggler() : base()
		{
			Name = "Defias Smuggler";
			Id = 95;
			Model = 4418;
			Level = RandomLevel(11,12);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.208f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 2764, SpellsTypes.Offensive );
			NpcType = 7;
			Equip( new Item( 6443, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 16752, InventoryTypes.Thrown, 2, 16, 1, 0, 0, 0, 0 ));
			BCAddon.Hp( this, 207, 11 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasSmuggler , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasPathstalker : BaseCreature
	{
		public DefiasPathstalker() : base()
		{
			Name = "Defias Pathstalker";
			Id = 121;
			Model = 2336;
			Level = RandomLevel(15,16);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.208f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 1604, SpellsTypes.Offensive );
			LearnSpell( 6554, SpellsTypes.Offensive );
			NpcType = 7;
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 279, 15 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasPathstalker , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasHighwayman : BaseCreature
	{
		public DefiasHighwayman() : base()
		{
			Name = "Defias Highwayman";
			Id = 122;
			Model = 2342;
			Level = RandomLevel(17,18);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 1604, SpellsTypes.Offensive );
			LearnSpell( 53, SpellsTypes.Defensive );
			NpcType = 7;
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 7488, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			BCAddon.Hp( this, 365, 17 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasHighwayman , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasNightRunner : BaseCreature
	{
		public DefiasNightRunner() : base()
		{
			Name = "Defias Night Runner";
			Id = 215;
			Model = 4276;
			Level = RandomLevel(24,25);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));//, new Item( 7488, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			BCAddon.Hp( this, 649, 24 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasNightRunner , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasKnuckleduster : BaseCreature
	{
		public DefiasKnuckleduster() : base()
		{
			Name = "Defias Knuckleduster";
			Id = 449;
			Model = 2344;
			Level = RandomLevel(16,17);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 1604, SpellsTypes.Offensive );
			LearnSpell( 1671, SpellsTypes.Offensive );
			LearnSpell( 71, SpellsTypes.Defensive );
			NpcType = 7;
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 315, 16 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasKnuckleduster , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasRenegadeMage : BaseCreature
	{
		public DefiasRenegadeMage() : base()
		{
			Name = "Defias Renegade Mage";
			Id = 450;
			Model = 4420;
			Level = RandomLevel(16,17);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 315, 16 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasRenegadeMage , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class TheDefiasTraitor : BaseCreature
	{
		public TheDefiasTraitor() : base()
		{
			Name = "The Defias Traitor";
			Id = 467;
			Model = 2311;
			Level = RandomLevel(16,17);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x08480006;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Alliance;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			//Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 315, 16 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.TheDefiasTraitor , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasTrapper : BaseCreature
	{
		public DefiasTrapper() : base()
		{
			Name = "Defias Trapper";
			Id = 504;
			Model = 2331;
			Level = RandomLevel(12,13);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 13*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			BaseMana = Level + 90;
			LearnSpell( 53, SpellsTypes.Offensive );
			NpcType = 7;
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 198, 12 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasTrapper , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new SpellCasterAI( this );
		}

	}
}



namespace Server.Creatures
{
	public class DefiasMessenger : BaseCreature
	{
		public DefiasMessenger() : base()
		{
			Name = "Defias Messenger";
			Id = 550;
			Model = 2312;
			Level = RandomLevel(14,15);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Equip( new Item( 6463, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 265, 14 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasMessenger , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasPillager : BaseCreature
	{
		public DefiasPillager() : base()
		{
			Name = "Defias Pillager";
			Id = 589;
			Model = 2338;
			Level = RandomLevel(13,15);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			BaseMana = Level + 90;
			LearnSpell( 133, SpellsTypes.Offensive );
			LearnSpell( 168, SpellsTypes.Defensive );
			LearnSpell( 18392, SpellsTypes.Offensive );
			NpcType = 7;
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 178, 13 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasPillager , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
public override void OnAddToWorld()
                {
                if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new SpellCasterAI( this );
		}
									
	}
}




namespace Server.Creatures
{
	public class DefiasLooter : BaseCreature
	{
		public DefiasLooter() : base()
		{
			Name = "Defias Looter";
			Id = 590;
			Model = 2312;
			Level = RandomLevel(13,14);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.3068f;
			CombatReach = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood; 
			BaseMana = Level + 90;
			LearnSpell( 1604, SpellsTypes.Offensive );
			LearnSpell( 53, SpellsTypes.Offensive );
			NpcType = 7;
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 191, 13 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasLooter , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new SpellCasterAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class DefiasHenchman : BaseCreature
	{
		public DefiasHenchman() : base()
		{
			Name = "Defias Henchman";
			Id = 594;
			Model = 2323;
			Level = RandomLevel(15,16);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.100f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 2121, SpellsTypes.Offensive );
			LearnSpell( 5115, SpellsTypes.Defensive );
			LearnSpell( 6435, SpellsTypes.Offensive );
			LearnSpell( 3248, SpellsTypes.Defensive );			
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 741, 15 );
			/*****************************/
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops.DefiasHenchman, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasMiner : BaseCreature
	{
		public DefiasMiner() : base()
		{
			Name = "Defias Miner";
			Id = 598;
			Model = 308;
			Level = RandomLevel(17,18);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 452, 17 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasMiner , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasConjurer : BaseCreature
	{
		public DefiasConjurer() : base()
		{
			Name = "Defias Conjurer";
			Id = 619;
			Model = 2329;
			Level = RandomLevel(15,16);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.100f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 143, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 895, 15 );
			/*****************************/
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasConjurer, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasOverseer : BaseCreature
	{
		public DefiasOverseer() : base()
		{
			Name = "Defias Overseer";
			Id = 634;
			Model = 2316;
			Level = RandomLevel(17,18);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.100f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 2121, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 718, 17 );
			/*****************************/
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasOverseer, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class EdwinVanCleef : BaseCreature
	{
		public EdwinVanCleef() : base()
		{
			Name = "Edwin VanCleef";
			Guild="Defias Kingpin";
			Id = 639;
			Model = 2029;
			Level = RandomLevel(21,22);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 1500;
			Armor = 200*Level;
			Block = 4*Level;
			Flags1 = 0x081000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.8f;
			Speed = 3.7f;
			WalkSpeed = 3.7f;
			RunSpeed = 6.7f;
			Size = 1;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 2121, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=2;
			/*****************************/
			BCAddon.Hp( this, 4293, 21 );
			/*****************************/
			Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 7419, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.EdwinVanCleef, 100f ),
							new BaseTreasure(DropsME.MoneyElite2, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasPirate : BaseCreature
	{
		public DefiasPirate() : base()
		{
			Name = "Defias Pirate";
			Id = 657;
			Model = 2347;
			Level = RandomLevel(19,20);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 5172, SpellsTypes.Defensive );
			LearnSpell( 6660, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 986, 19 );
			/*****************************/
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasPirate, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasDigger : BaseCreature
	{
		public DefiasDigger() : base()
		{
			Name = "Defias Digger";
			Id = 824;
			Model = 2441;
			Level = RandomLevel(15,16);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Size = 0.95f;
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 614, 15 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasDigger , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasNightBlade : BaseCreature
	{
		public DefiasNightBlade() : base()
		{
			Name = "Defias Night Blade";
			Id = 909;
			Model = 2441;
			Level = RandomLevel(25,26);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Size = 1;
			Equip( new Item( 6469, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 654, 25 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasNightBlade , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasEnchanter : BaseCreature
	{
		public DefiasEnchanter() : base()
		{
			Name = "Defias Enchanter";
			Id = 910;
			Model = 4281;
			Level = RandomLevel(26,27);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Size = 1f;
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 721, 26 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasEnchanter , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasPrisoner : BaseCreature
	{
		public DefiasPrisoner() : base()
		{
			Name = "Defias Prisoner";
			Id = 1706;
			Model = 2148;
			Level = RandomLevel(18,24);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 1768, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 986, 18 );
			/*****************************/
			Equip( new Item( 7432, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasPrisoner, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class DefiasCaptive : BaseCreature
	{
		public DefiasCaptive() : base()
		{
			Name = "Defias Captive";
			Id = 1707;
			Model = 2144;
			Level = RandomLevel(18,24);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 1019, 18 );
			/*****************************/
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasCaptive, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class DefiasInmate : BaseCreature
	{
		public DefiasInmate() : base()
		{
			Name = "Defias Inmate";
			Id = 1708;
			Model = 2146;
			Level = RandomLevel(19,25);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Family = 7;
			Size = 1f;
			Elite=1;
			NpcText00 = "Looks like this is a dungeon in Stormwind City.";
			/*****************************/
			BCAddon.Hp( this, 1318, 19 );
			/*****************************/
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ),new Item( 1685, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasInmate, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasConvict : BaseCreature
	{
		public DefiasConvict() : base()
		{
			Name = "Defias Convict";
			Id = 1711;
			Model = 2145;
			Level = RandomLevel(22,25);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 6253, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 1428, 22 );
			/*****************************/
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasConvict, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class DefiasInsurgent : BaseCreature
	{
		public DefiasInsurgent() : base()
		{
			Name = "Defias Insurgent";
			Id = 1715;
			Model = 2147;
			Level = RandomLevel(25,26);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 11554, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 1254, 25 );
			/*****************************/
			Equip( new Item( 2777, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasInsurgent, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class DefiasWatchman : BaseCreature
	{
		public DefiasWatchman() : base()
		{
			Name = "Defias Watchman";
			Id = 1725;
			Model = 184;
			Level = RandomLevel(16,17);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 5019, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 1116, 16 );
			/*****************************/
			Equip( new Item( 2777, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ),new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasWatchman, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasMagician : BaseCreature
	{
		public DefiasMagician() : base()
		{
			Name = "Defias Magician";
			Id = 1726;
			Model = 2321;
			Level = RandomLevel(16,17);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 143, SpellsTypes.Offensive );
			LearnSpell( 5110, SpellsTypes.Defensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 1116, 16 );
			/*****************************/
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasMagician, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasWorker : BaseCreature
	{
		public DefiasWorker() : base()
		{
			Name = "Defias Worker";
			Id = 1727;
			Model = 341;
			Level = RandomLevel(16,17);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Size = 1f;
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 218, 16 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasWorker , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class DefiasEvoker : BaseCreature
	{
		public DefiasEvoker() : base()
		{
			Name = "Defias Evoker";
			Id = 1729;
			Model = 2318;
			Level = RandomLevel(19,25);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Family = 7;
			Size = 1f;
			Elite=1;
			NpcText00 = "Looks like this is a dungeon in Stormwind City.";
			/*****************************/
			BCAddon.Hp( this, 1318, 19 );
			/*****************************/
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasEvoker, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasSquallshaper : BaseCreature
	{
		public DefiasSquallshaper() : base()
		{
			Name = "Defias Squallshaper";
			Id = 1732;
			Model = 2349;
			Level = RandomLevel(19,20);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 6131, SpellsTypes.Offensive );
			LearnSpell( 2137, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 1588, 19 );
			/*****************************/
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasSquallshaper, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasCompanion : BaseCreature
	{
		public DefiasCompanion() : base()
		{
			Name = "Defias Companion";
			Id = 3450;
			Model = 5207;
			Level = RandomLevel(14);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x04;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast ;
			Size = 0.25f;
			BCAddon.Hp( this, 218, 14 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasCompanion , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasStripMiner : BaseCreature
	{
		public DefiasStripMiner() : base()
		{
			Name = "Defias Strip Miner";
			Id = 4416;
			Model = 2438;
			Level = RandomLevel(18,19);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 6016, SpellsTypes.Offensive );
			NpcType = 7;
			Size = 1f;
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 262, 18 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasStripMiner , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasTaskmaster : BaseCreature
	{
		public DefiasTaskmaster() : base()
		{
			Name = "Defias Taskmaster";
			Id = 4417;
			Model = 2440;
			Level = RandomLevel(18,19);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 6660, SpellsTypes.Offensive );
			LearnSpell( 6685, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 2200, 18 );
			/*****************************/
			Equip( new Item( 5175, InventoryTypes.TwoHanded, 2, 8, 1, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasTaskmaster, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasWizard : BaseCreature
	{
		public DefiasWizard() : base()
		{
			Name = "Defias Wizard";
			Id = 4418;
			Model = 2447;
			Level = RandomLevel(18,19);
			SetDamage(1f+2.8f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 10;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 10;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new SpellCasterAI( this ); BaseMana = Level + 90;
			LearnSpell( 133, SpellsTypes.Offensive );
			LearnSpell( 205, SpellsTypes.Offensive );
			LearnSpell( 113, SpellsTypes.Offensive );
			Family = 7;
			Size = 1f;
			Elite=1;
			/*****************************/
			BCAddon.Hp( this, 920, 18 );
			/*****************************/
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasWizard, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class DefiasRioter : BaseCreature
	{
		public DefiasRioter() : base()
		{
			Name = "Defias Rioter";
			Id = 5043;
			Model = 2147;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Size = 1;
			//Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 318, 20 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasRioter , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class DefiasRaider : BaseCreature
	{
		public DefiasRaider() : base()
		{
			Name = "Defias Raider";
			Id = 6180;
			Model = 4908;
			Level = RandomLevel(17,18);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 1800;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Size = 1;
			//Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 236, 17 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasRaider , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasDrone : BaseCreature
	{
		public DefiasDrone() : base()
		{
			Name = "Defias Drone";
			Id = 7050;
			Model = 5812;
			Level = RandomLevel(22);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080000;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 6;
			Size = 1;
			Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 236, 22 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasDrone , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class MalformedDefiasDrone : BaseCreature
	{
		public MalformedDefiasDrone() : base()
		{
			Name = "Malformed Defias Drone";
			Id = 7051;
			Model = 5813;
			Level = RandomLevel(24);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080004;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Size = 1.2f;
			Equip( new Item( 5527, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));//, new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			BCAddon.Hp( this, 276, 24 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.MalformedDefiasDrone , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class DefiasTowerPatroller : BaseCreature
	{
		public DefiasTowerPatroller() : base()
		{
			Name = "Defias Tower Patroller";
			Id = 7052;
			Model = 5811;
			Level = RandomLevel(23);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080004;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Size = 1f;
			Equip( new Item( 7488, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			BCAddon.Hp( this, 427, 23 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasTowerPatroller , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class DefiasTowerSentry : BaseCreature
	{
		public DefiasTowerSentry() : base()
		{
			Name = "Defias Tower Sentry";
			Id = 7056;
			Model = 5806;
			Level = RandomLevel(24,25);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = Level;
			Flags1 = 0x080004;
			BaseHitPoints = 213;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.4f;
			Speed = 3.11f;
			WalkSpeed = 3.11f;
			RunSpeed = 6.11f;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Size = 1f;
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			BCAddon.Hp( this, 427, 24 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DefiasBanditDrops2.DefiasTowerSentry , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};
		}
	}
}


