//Всем учить русский :) DrilLer
//edited by mmcs
using System;
using Server.Items;


namespace Server.Creatures
{
	public class CompactHarvestReaper: BaseCreature
	{
		public CompactHarvestReaper() : base()
		{
			Id = 2676;
			Name = "Compact Harvest Reaper";
			Model = 1159;
			AttackSpeed = 2000;
			BoundingRadius = 0.3748f;
			CombatReach = 0.6f;			
			Level = RandomLevel( 22, 35 );			
			BaseHitPoints = (int)(550*Math.Pow(1.045f,Level-22)) ;
			ManaType=2;
			BaseMana = 0 ;
			Str = (int)(2*Level);
			Armor = (int)(60.4f*Level);
			Block=Level+30;
			SetDamage( 1.08f*Level, 1.41f*Level ); 			
			Size = 0.4f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Flags1 = 0x02400 ;
			NpcType = (int)NpcTypes.Mechanical ;			
			Faction = Factions.NoFaction;
			AIEngine = new AgressiveAnimalAI( this );		
			Loots = new BaseTreasure[]{ new BaseTreasure( HarvestDrops.CompactHarvestReaper, 100f )};
		}
	}		
	public class FoeReaper4000: BaseCreature
	{
		public FoeReaper4000() : base()
		{
			Id = 573;
			Name = "Foe Reaper 4000";
			Model = 548;
			AttackSpeed = 2000;
			BoundingRadius = 1.218100f;
			CombatReach = 1.95f;			
			Level = RandomLevel( 20 );			
			BaseHitPoints = 1500 ;
			ManaType=2;
			BaseMana = 0 ;
			Str = (int)(2*Level);
			Armor = (int)(60.4f*Level);
			Block=Level+30;
			SetDamage( 1.08f*Level, 1.41f*Level ); 			
			Size = 1.0f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Elite = 4 ;
			NpcType = (int)NpcTypes.Mechanical ;			
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );		
			Loots = new BaseTreasure[]{ new BaseTreasure( HarvestDrops.FoeReaper4000, 100f )};
		}
	}	
	public class HarvestGolem: BaseCreature
	{			
		public HarvestGolem() : base()
		{
			Id = 36;
			Name = "Harvest Golem";
			Model = 367;
			AttackSpeed = 2000;
			BoundingRadius = 0.796450f;
			CombatReach = 0.275f;			
			Level = RandomLevel(11,12);			
			BaseHitPoints = (int)(188*Math.Pow(1.045f,Level-11));
			ManaType=2;
			BaseMana = (int)(140*Math.Pow(1.045f,Level-11));
			Str = (int)(Level);
			Armor = (int)(60.4f*Level);
			Block=Level+30;
			SetDamage( 1.08f*Level, 1.41f*Level ); 			
			Size = 0.85f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			NpcType = (int)NpcTypes.Mechanical ;			
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			LearnSpell( 8014, SpellsTypes.Offensive );			
			Loots = new BaseTreasure[]{ new BaseTreasure( HarvestDrops.HarvestGolem, 100f )};
		}
	}	
	public class HarvestReaper: BaseCreature
	{
		public HarvestReaper() : base()
		{
			Id = 115;
			Name = "Harvest Reaper";
			Model = 379;
			Level = RandomLevel(17,18);
			AttackSpeed = 2000;			
			BoundingRadius = 1.077550f;
			CombatReach = 0.3f;
			BaseHitPoints = (int)(300*Math.Pow(1.045f,Level-17));
			ManaType=2;
			BaseMana = (int)(100*Math.Pow(1.045f,Level-17));	
			Str = (int)(Level);
			Armor = (int)(60.4f*Level);
			Block=Level+30;
			SetDamage( 1.08f*Level, 1.41f*Level ); 		
			Size = 1.5f;
			Speed = 4.2f;
			WalkSpeed = 4.2f;
			RunSpeed = 6.2f;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure( HarvestDrops.HarvestReaper, 100f )};
		}
	}
	public class HarvestWatcher: BaseCreature
	{
		public HarvestWatcher() : base()
		{
			Id = 114;
			Name = "Harvest Watcher";
			Model = 378;
			Level = RandomLevel(14,15);			
			AttackSpeed = 2000;
			BoundingRadius = 0.030700f;
			CombatReach = 0.3000f;
			BaseHitPoints = (int)(238*Math.Pow(1.045f,Level-14));
			ManaType=2;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(60.4f*Level);
			Block=Level+30;
			SetDamage( 1.08f*Level, 1.41f*Level ); 	
			Size = 1.1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			NpcType = (int)NpcTypes.Mechanical ;				
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( HarvestDrops.HarvestWatcher, 100f )};
		}
	}
	public class RustyHarvestGolem: BaseCreature
	{
		public RustyHarvestGolem() : base()
		{
			Id = 480;
			Name = "Rusty Harvest Golem";			
			Model = 514;
			Level = RandomLevel(9,10);		
			AttackSpeed = 2000;
			BoundingRadius = 0.796450f;
			CombatReach = 0.3500f;
			BaseHitPoints = (int)(194*Math.Pow(1.045f,Level-9));
			ManaType=2;
			BaseMana = (int)(100*Math.Pow(1.045f,Level-9));
			Str = (int)(Level);
			Armor = (int)(60.4f*Level);
			Block=Level+30;
			SetDamage( 1.08f*Level, 1.41f*Level );	
			Size = 0.8500f;
			Speed =3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			NpcType = (int)NpcTypes.Mechanical ;	
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 8014, SpellsTypes.Offensive );				
			Loots = new BaseTreasure[]{ new BaseTreasure( HarvestDrops.RustyHarvestGolem, 100f )};
		}
	}
	public class TheThreshwackonator4100 : BaseCreature
	{
		public TheThreshwackonator4100() : base()
		{
			Id = 6669 ;
			Name = "The Threshwackonator 4100" ;
			Guild = "The First Mate" ;
			Model = 5386;
			Level = RandomLevel( 20 );
			AttackSpeed= 2000;
			BoundingRadius = 1.4055f ;
			CombatReach = 2.25f ;
			BaseHitPoints = 2000 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(80.2f*Level);
			Block=Level+50;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.5f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed = 6.5f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( HarvestDrops.TheThreshwackonator4100, 100f ) };
		}
	}	
}
