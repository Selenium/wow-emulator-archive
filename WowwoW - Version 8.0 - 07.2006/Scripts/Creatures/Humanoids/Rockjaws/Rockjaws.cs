//change aatack speed
//	Script made by Reguj - 22/05/05 12:31:49
// The Rockjaws (requested)

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class RockjawTrogg : BaseCreature
	{
		public RockjawTrogg() : base()
		{
			Name = "Rockjaw Trogg";
			Id = 707;
			Model = 606;
			Level = RandomLevel(1,2);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseMana = 53+33*Level; ManaType = 1; //86			
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.55f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Rockjaw";
			Loots = new BaseTreasure[]{  new BaseTreasure( TroggDrops.Trogg , 100f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
			BCAddon.Hp( this, 86, 1 );
		}
	}
}

namespace Server.Creatures
{
	public class BurlyRockjawTrogg : BaseCreature
	{
		public BurlyRockjawTrogg() : base()
		{
			Name = "Burly Rockjaw Trogg";
			Id = 724;
			Model = 611;
			Level = RandomLevel(2);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			//2000 - (level-1) * 13.33
			AttackSpeed = 2000;
			Armor = 60;
			Block = 5;
			ResistArcane = 10;
			BaseHitPoints = 138;
			BaseMana = 119; 
			ManaType = 1;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.55f;
			Speed = 2.5f;
			WalkSpeed = 2.5f;
			RunSpeed = 5.5f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			//Guild = "Rockjaw";
			Loots = new BaseTreasure[]{  new BaseTreasure( TroggDrops.Trogg , 100f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class RockjawSkullthumper : BaseCreature
	{
		public RockjawSkullthumper() : base()
		{
			Name = "Rockjaw Skullthumper";
			Id = 1115;
			Model = 726;
			Level = RandomLevel(8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 240;
			Block = 30;
			ResistArcane = 30;
			BaseHitPoints = 336;
			BaseMana = 317; 
			ManaType = 1;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.85f;
			Speed = 2.7f;
			WalkSpeed = 2.7f;
			RunSpeed = 5.7f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Guild = "Rocjaw";
			LearnSpell( 3148, SpellsTypes.Offensive );
			Equip(new ForsakenMaul());
			Loots = new BaseTreasure[]{  new BaseTreasure( TroggDrops.Trogg , 70f )
										, new BaseTreasure( Trogg2Drops.Trogg2 , 70f )
										, new BaseTreasure( BeginnersLeatherArmorsDrops.BeginnersLeatherArmors , 1f )
										, new BaseTreasure( Drops.ChainArmor , 2f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( Drops.Pouch , 3f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class RockjawAmbusher : BaseCreature
	{
		public RockjawAmbusher() : base()
		{
			Name = "Rockjaw Ambusher";
			Id = 1116;
			Model = 726;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 300;
			Block = 50;
			ResistArcane = 50;
			BaseHitPoints = 72+33*Level;
			BaseMana = 53+33*Level; ManaType = 1;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.85f;
			Speed = 2.85f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Guild = "Rockjaw";
			LearnSpell( 15571, SpellsTypes.Offensive ); 
			LearnSpell( 53, SpellsTypes.Offensive ); 
			Equip(new SmallDagger());	
			//equipmodel=0 7434 2 15 1 13 3 0 0 0		
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.Pouch , 6f )
										, new BaseTreasure( TroggDrops.Trogg , 60f )
										, new BaseTreasure( Trogg2Drops.Trogg2 , 70f )
										, new BaseTreasure( Drops.RaggedLeatherArmor , 20f )
										, new BaseTreasure( LowBowsAndCrossbowsDrops.LowBowsAndCrossbows , 10f )
										, new BaseTreasure( LowAxesDrops.LowAxes , 10f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( BeginnersPlansAndRecipesDrops.BeginnersPlansAndRecipes , 10f )
										, new BaseTreasure( LowMusketsDrops.LowMuskets , 10f )
										, new BaseTreasure( LowSwordsAndDaggersDrops.LowSwordsAndDaggers , 10f )
										};
			BCAddon.Hp( this, 350, 9 );
		}
	}
}

namespace Server.Creatures
{
	public class RockjawBonesnapper : BaseCreature
	{
		public RockjawBonesnapper() : base()
		{
			Name = "Rockjaw Bonesnapper";
			Id = 1117;
			Model = 726;
			Level = RandomLevel(11);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 330;
			Block = 50;
			ResistArcane = 50;
			BaseHitPoints = 435;
			BaseMana = 416; 
			ManaType = 1;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.85f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0;
			LearnSpell( 5164, SpellsTypes.Offensive ); 
			//Equip(new SmallKnife());
			Equip( new Item( 7444, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ) );
			//equipmodel=0 7444 2 4 2 13 3 0 0 0
			//Guild = "Rockjaw";
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.Pouch , 6f )
										, new BaseTreasure( TroggDrops.Trogg , 60f )
										, new BaseTreasure( Trogg2Drops.Trogg2 , 70f )
										, new BaseTreasure( Drops.RaggedLeatherArmor , 20f )
										, new BaseTreasure( LowBowsAndCrossbowsDrops.LowBowsAndCrossbows , 10f )
										, new BaseTreasure( LowAxesDrops.LowAxes , 10f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( BeginnersPlansAndRecipesDrops.BeginnersPlansAndRecipes , 10f )
										, new BaseTreasure( LowMusketsDrops.LowMuskets , 10f )
										, new BaseTreasure( LowSwordsAndDaggersDrops.LowSwordsAndDaggers , 10f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class RockjawBackbreaker : BaseCreature
	{
		public RockjawBackbreaker() : base()
		{
			Name = "Rockjaw Backbreaker";
			Id = 1118;
			Model = 723;
			Level = RandomLevel(11);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 330;
			Block = 50;
			ResistArcane = 50;
			BaseHitPoints = 435;
			BaseMana = 416; ManaType = 1;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.9f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			NpcType = 7;
			NpcFlags = 0;
			LearnSpell( 15571, SpellsTypes.Offensive ); 
			LearnSpell( 5164, SpellsTypes.Offensive );
			Equip(new Maul());
			//Equip( new Item( 7444, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ) );			
			//Guild = "Rockjaw";
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.Pouch , 6f )
										, new BaseTreasure( TroggDrops.Trogg , 60f )
										, new BaseTreasure( Trogg2Drops.Trogg2 , 70f )
										, new BaseTreasure( Drops.RaggedLeatherArmor , 20f )
										, new BaseTreasure( LowBowsAndCrossbowsDrops.LowBowsAndCrossbows , 10f )
										, new BaseTreasure( LowAxesDrops.LowAxes , 10f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( BeginnersPlansAndRecipesDrops.BeginnersPlansAndRecipes , 10f )
										, new BaseTreasure( LowMusketsDrops.LowMuskets , 10f )
										, new BaseTreasure( LowSwordsAndDaggersDrops.LowSwordsAndDaggers , 10f )
										};
		}
public override void OnAddToWorld()
    {
    if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new DefensiveAnimalAI( this );
    }
	    
	    		
	}
}

namespace Server.Creatures
{
	public class RockjawRaider : BaseCreature
	{
		public RockjawRaider() : base()
		{
			Name = "Rockjaw Raider";
			Id = 1718;
			Model = 730;
			Level = RandomLevel(3,4);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 100;
			Block = 5;
			ResistArcane = 10;
			BaseMana = 152; ManaType = 1;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 0.7f;
			Speed = 2.6f;
			WalkSpeed = 2.5f;
			RunSpeed = 5.6f;
			Faction = Factions.Monster;
			LearnSpell( 5164, SpellsTypes.Offensive );
			Equip( new Item( 7444, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Guild = "Rockjaw";
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.Pouch , 6f )
										, new BaseTreasure( TroggDrops.Trogg , 60f )
										, new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( BeginnersAxesDrops.BeginnersAxes , 10f )
										, new BaseTreasure( BeginnersClothsDrops.BeginnersCloths , 10f )
										};
			BCAddon.Hp( this, 152, 3 );
		}
	}
}

