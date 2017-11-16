using System;
using Server.Items;
using HelperTools;
using Server.Quests;

namespace Server.Creatures
{
	public class StormwindCityGuard : BaseCreature
	{
		public StormwindCityGuard() : base()
		{
			Name = "Stormwind City Guard";
			Id = 68;
			Model = 3167;
			Level = RandomLevel(55,60);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			NpcText00="What are you looking for?";
			//Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Equip( new Longsword(), new StormwindGuardShield() ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.StormwindCityGuard, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1500, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class GuardThomas : BaseNPC
	{
		public GuardThomas(): base()
		{
			Name = "Guard Thomas";
			Id = 261;
			Model = 1984;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;			
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1200;
 			BaseMana = 0;
			BoundingRadius = 1.7077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="Hey citizen! You look like a stout one. We guards are spread a little thin out here, and I could use you help...";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			//Quests = new BaseQuest[] { new GuardThomas( ) };
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardThomas, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			//Quests = new BaseQuest[] { new Deliver_Thomas_Report(), new Bounty_On_Murlocs(), new Protect_The_Frontier(), new Report_To_Gryan_Stoutmantle() };
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class GuardParker : BaseCreature
	{
		public GuardParker(): base()
		{
			Name = "Guard Parker";
			Id = 464;
			Model = 2150;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;			
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1200;
 			BaseMana = 0;
			BoundingRadius = 1.7077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
		         if ( !World.Loading ) 
         { 
            BaseCreature bc = (BaseCreature)new WhiteStallion();          
            World.Add( bc, X, Y, Z, MapId );          
            this.Mount( bc ); 
         }
			//Elite=1;
			//NpcText00="Hey citizen! You look like a stout one. We guards are spread a little thin out here, and I could use you help...";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			//Quests = new BaseQuest[] { new GuardParker( ) };
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardParker, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class GuardBerton : BaseCreature
	{
		public GuardBerton(): base()
		{
			Name = "Guard Berton";
			Id = 859;
			Model = 3453;
			Level = RandomLevel(33);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;			
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1250;
 			BaseMana = 0;
			BoundingRadius = 1.7077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="Hey citizen! You look like a stout one. We guards are spread a little thin out here, and I could use you help...";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			//Quests = new BaseQuest[] { new GuardBerton( ) };
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardBerton, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class GuardHowe : BaseCreature
	{
		public GuardHowe(): base()
		{
			Name = "Guard Howe";
			Id = 903;
			Model = 3446;
			Level = RandomLevel(33);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;			
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1250;
 			BaseMana = 0;
			BoundingRadius = 1.7077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="Hey citizen! You look like a stout one. We guards are spread a little thin out here, and I could use you help...";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			//Quests = new BaseQuest[] { new GuardHowe( ) };
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardHowe, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class GuardAshlock : BaseCreature
	{
		public GuardAshlock(): base()
		{
			Name = "Guard Ashlock";
			Id = 932;
			Model = 3384;
			Level = RandomLevel(35);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;			
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
			BoundingRadius = 1.7077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="Hey citizen! You look like a stout one. We guards are spread a little thin out here, and I could use you help...";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			//Quests = new BaseQuest[] { new GuardAshlock( ) };
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardAshlock, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class GuardHiett : BaseCreature
	{
		public GuardHiett(): base()
		{
			Name = "Guard Hiett";
			Id = 933;
			Model = 3450;
			Level = RandomLevel(35);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;			
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
			BoundingRadius = 0.2077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			NpcText00="What do you need directions to?";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardHiett, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class GuardClarke : BaseCreature
	{
		public GuardClarke(): base()
		{
			Name = "Guard Clarke";
			Id = 934;
			Model = 3455;
			Level = RandomLevel(35);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;			
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
			BoundingRadius = 0.2077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			NpcText00="What do you need directions to?";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardClarke, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class GuardPearce : BaseCreature
	{
		public GuardPearce(): base()
		{
			Name = "Guard Pearce";
			Id = 935;
			Model = 3447;
			Level = RandomLevel(35);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;			
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
			BoundingRadius = 0.2077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			NpcText00="What do you need directions to?";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardPearce, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class GuardAdams : BaseCreature
	{
		public GuardAdams(): base()
		{
			Name = "Guard Adams";
			Id = 936;
			Model = 3641;
			Level = RandomLevel(35);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;			
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
			BoundingRadius = 0.2077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			NpcText00="What do you need directions to?";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.GuardAdams, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class StormwindGuard : BaseCreature
	{
		public StormwindGuard() : base()
		{
			Name = "Stormwind Guard";
			Id = 1423;
			Model = Rnd.RandomIntArr( 3258, 3641);
			Level = RandomLevel(22,25);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.StormwindGuard, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 689, 22 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class NorthshireGuard : BaseCreature
	{
		public NorthshireGuard() : base()
		{
			Name = "Northshire Guard";
			Id = 1642;
			Model = 3167;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1450;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Stormwind;
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.NorthshireGuard, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class StormwindRoyalGuard : BaseCreature
	{
		public StormwindRoyalGuard() : base()
		{
			Name = "Stormwind Royal Guard";
			Id = 1756;
			Model = 3167;
			Level = RandomLevel(60);
			SetDamage(1f+3.5f*Level,1f+4.0*Level);			
			AttackSpeed = 2000;
			Armor = 50*Level;
			Block = 5*Level;
			Flags1 = 0x010480006;
			NpcFlags = 0;
			ResistFire = 50;
			ResistFrost = 50;
			ResistHoly = 50;
			ResistNature = 50;
			ResistShadow = 50;
			Str = (int)(Level*1.5f);
 			BaseHitPoints = 1450;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.StormwindRoyalGuard, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class SouthshoreGuard : BaseCreature
	{
		public SouthshoreGuard() : base()
		{
			Name = "Southshore Guard";
			Id = 2386;
			Model = 3705;
			Level = RandomLevel(50);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.SouthshoreGuard, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class MajorSamuelson : BaseCreature
	{
		public MajorSamuelson() : base()
		{
			Name = "Major Samuelson";
			Guild="Stormwind City Guard";
			Id = 2439;
			Model = 5567;
			Level = RandomLevel(50);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 1500;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.MajorSamuelson, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class GuardLasiter : BaseCreature
	{
		public GuardLasiter() : base()
		{
			Name = "Guard Lasiter";
			Id = 4973;
			Model = 4835;
			Level = RandomLevel(50);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1350;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 5231, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.GuardLasiter, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class TheramoreGuard : BaseCreature
	{
		public TheramoreGuard() : base()
		{
			Name = "Theramore Guard";
			Id = 4979;
			Model = 4835;
			Level = RandomLevel(53,57);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.TheramoreGuard, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1300, 53 );
			/*****************************/		 			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class StockadeGuard : BaseCreature
	{
		public StockadeGuard() : base()
		{
			Name = "Stockade Guard";
			Id = 4995;
			Model = 2989;
			Level = RandomLevel(45);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BaseHitPoints = 1050;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.StockadeGuard, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class InjuredStockadeGuard : BaseCreature
	{
		public InjuredStockadeGuard() : base()
		{
			Name = "Injured Stockade Guard";
			Id = 4996;
			Model = 2985;
			Level = RandomLevel(45);
			SetDamage(1f+2.5f*Level,1f+3.0*Level);			
			AttackSpeed = 2000;
			Armor = 38*Level;
			Block = 2*Level-9;
			Flags1 = 0x08480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.6f);
 			BaseHitPoints = 1055;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.InjuredStockadeGuard, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class SentryPointGuard : BaseCreature
	{
		public SentryPointGuard() : base()
		{
			Name = "Sentry Point Guard";
			Id = 5085;
			Model = 2978;
			Level = RandomLevel(32,33);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.SentryPointGuard, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 975, 32 );
			/*****************************/		
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class SentryPointCaptain : BaseCreature
	{
		public SentryPointCaptain() : base()
		{
			Name = "Sentry Point Captain";
			Id = 5086;
			Model = 4667;
			Level = RandomLevel(34,35);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Longsword(), new StormwindGuardShield() );
			//Quests = new BaseQuest[] { new StormwindGuard( ) }; 
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.SentryPointCaptain, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 975, 34 );
			/*****************************/		
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class CaptainAndrews : BaseCreature
	{
		public CaptainAndrews() : base()
		{
			Name = "Captain Andrews";
			Guild="Red Team Captain";
			Id = 5095;
			Model = 3142;
			Level = RandomLevel(53);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480046;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1279;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			Equip( new Longsword(), new StormwindGuardShield() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.CaptainAndrews, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class CaptainThomas : BaseCreature
	{
		public CaptainThomas() : base()
		{
			Name = "Captain Thomas";
			Guild="Blue Team Captain";
			Id = 5096;
			Model = 3134;
			Level = RandomLevel(53);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480046;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;

			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1279;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			Equip( new Longsword(), new StormwindGuardShield() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.CaptainThomas, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class NijelsPointGuard : BaseCreature
	{
		public NijelsPointGuard() : base()
		{
			Name = "Nijel's Point Guard";
			Id = 8151;
			Model = 7368;
			Level = RandomLevel(45);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1279;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;
			
			Equip( new Longsword(), new StormwindGuardShield() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.NijelsPointGuard, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class LakeshireGuard : BaseCreature
	{
		public LakeshireGuard() : base()
		{
			Name = "Lakeshire Guard";
			Id = 10037;
			Model = 3447;
			Level = RandomLevel(35);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 450;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;
			
			Equip( new Longsword(), new StormwindGuardShield() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.LakeshireGuard, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class GuardRoberts : BaseCreature
	{
		public GuardRoberts() : base()
		{
			Name = "Guard Roberts";
			Id = 12423;
			Model = 3447;
			Level = RandomLevel(7);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480406;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 210;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Stormwind;
			
			Equip( new Longsword(), new StormwindGuardShield() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.GuardRoberts, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}






namespace Server.Creatures
{
	public class MarshalHaggard : BaseCreature
	{
		public MarshalHaggard() : base()
		{
			Name = "Marshal Haggard";
			Id = 294;
			Model = 1689;
			Level = RandomLevel(20);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 1000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 505;
 			BaseMana = 1069;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.MarshalHaggard, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class MarshalMarris : BaseCreature
	{
		public MarshalMarris() : base()
		{
			Name = "Marshal Marris";
			Id = 382;
			Model = 3454;
			Level = RandomLevel(35);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1505;
 			BaseMana = 2069;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			Equip( new ShortSabre() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.MarshalMarris, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class MarshalRedpath : BaseCreature
	{
		public MarshalRedpath() : base()
		{
			Name = "Marshal Redpath";
			Id = 2263;
			Model = 1861;
			Level = RandomLevel(41);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1804;
 			BaseMana = 2469;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			
			Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.MarshalRedpath, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class GeneralMarcusJonathan : BaseCreature
	{
		public GeneralMarcusJonathan() : base()
		{
			Name = "General Marcus Jonathan";
			Guild="High Commander of Stormwind Defense";
			Id = 466;
			Model = 1688;
			Level = RandomLevel(62);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 60*Level;
			Block = 5*Level;
			Flags1 = 0x08480000;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.5f);
			BaseHitPoints = 4804;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 4.3f;
			WalkSpeed = 4.3f;
			RunSpeed = 7.3f;
			Faction = Factions.Stormwind;
			
		         if ( !World.Loading ) 
         { 
            BaseCreature bc = (BaseCreature)new WhiteStallion();          
            World.Add( bc, X, Y, Z, MapId );          
            this.Mount( bc ); 
         }
			NpcType = (int)NpcTypes.Humanoid;  
			Elite=1;
			Size = 1.15f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.GeneralMarcusJonathan, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{
	public class MajorMattingly : BaseCreature
	{
		public MajorMattingly() : base()
		{
			Name = "Major Mattingly";
			Id = 14394;
			Model = 14431;
			Level = RandomLevel(60);
			SetDamage(1f+3.5f*Level,1f+4*Level);			
			AttackSpeed = 2000;
			Armor = 50*Level;
			Block = 3*Level;
			Flags1 = 0x04800060;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.5f);
			BaseHitPoints = 3804;
 			BaseMana = 2434;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			//Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Elite=1;
			Size = 1.1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.MajorMattingly, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class StormwindCityPatroller : BaseCreature
	{
		public StormwindCityPatroller() : base()
		{
			Name = "Stormwind City Patroller";
			Id = 1976;
			Model = 3167;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480006;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1954;
 			BaseMana = 2669;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Stormwind;
			
			Equip( new Longsword(), new StormwindGuardShield() ); 
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.StormwindCityPatroller, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class MelrisMalagan : BaseCreature
	{
		public MelrisMalagan() : base()
		{
			Name = "Melris Malagan";
			Guild="Captain of the Guard";
			Id = 12480;
			Model = 5567;
			Level = RandomLevel(58);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1954;
 			BaseMana = 2669;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Stormwind;
			
			Equip( new Longsword(), new StormwindGuardShield() ); 
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.MelrisMalagan, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class OfficerBrady : BaseCreature
	{
		public OfficerBrady() : base()
		{
			Name = "Officer Brady";
			Id = 14439;
			Model = 14493;
			Level = RandomLevel(60);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 60*Level;
			Block = 5*Level;
			Flags1 = 0x08480000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.5f);
			BaseHitPoints = 4804;
 			BaseMana = 0;
 			BoundingRadius = 0.3366f;
			CombatReach = 1.300f;
			Speed = 4.3f;
			WalkSpeed = 4.3f;
			RunSpeed = 7.3f;
			Faction = Factions.Stormwind;
			
			//Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Elite=1;
			Size = 1.1f;
			Equip( new Item( 7482, InventoryTypes.MainGauche, 7, 1, 13, 3, 0, 0, 0 ), new Item( 6454, InventoryTypes.MainGauche, 15, 1, 13, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.OfficerBrady, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class OfficerPomeroy : BaseCreature
	{
		public OfficerPomeroy() : base()
		{
			Name = "Officer Pomeroy";
			Id = 14438;
			Model = 14492;
			Level = RandomLevel(60);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 60*Level;
			Block = 5*Level;
			Flags1 = 0x010480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.5f);
			BaseHitPoints = 4804;
 			BaseMana = 0;
 			BoundingRadius = 0.3066f;
			CombatReach = 1.300f;
			Speed = 4.3f;
			WalkSpeed = 4.3f;
			RunSpeed = 7.3f;
			Faction = Factions.Stormwind;
			
			//Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Elite=1;
			Size = 1.0f;
			Equip( new Item( 7482, InventoryTypes.MainGauche, 7, 1, 13, 3, 0, 0, 0 ), new Item( 6454, InventoryTypes.MainGauche, 15, 1, 13, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.OfficerPomeroy, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{
	public class OfficerJaxon : BaseCreature
	{
		public OfficerJaxon() : base()
		{
			Name = "Officer Jaxon";
			Id = 14423;
			Model = 14472;
			Level = RandomLevel(60);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 60*Level;
			Block = 5*Level;
			Flags1 = 0x010480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.5f);
			BaseHitPoints = 4804;
 			BaseMana = 0;
 			BoundingRadius = 0.3066f;
			CombatReach = 1.300f;
			Speed = 4.3f;
			WalkSpeed = 4.3f;
			RunSpeed = 7.3f;
			Faction = Factions.Stormwind;
			
			//Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Elite=1;
			Size = 1.0f;
			Equip( new Item( 7482, InventoryTypes.MainGauche, 7, 1, 13, 3, 0, 0, 0 ), new Item( 6454, InventoryTypes.MainGauche, 15, 1, 13, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.OfficerJaxon, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{
	public class LieutenantDoren: BaseCreature
	{
		public LieutenantDoren() : base()
		{
			Name = "Lieutenant Doren";
			//Guild="High Commander of Stormwind Defense";
			Id = 469;
			Model = 2593;
			Level = RandomLevel(40);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 1000;
			Armor = 60*Level;
			Block = 5*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.5f);
			BaseHitPoints = 2545;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 4.3f;
			WalkSpeed = 4.3f;
			RunSpeed = 7.3f;
			Faction = Factions.Stormwind;
			
		         if ( !World.Loading ) 
         { 
            BaseCreature bc = (BaseCreature)new WhiteStallion();          
            World.Add( bc, X, Y, Z, MapId );          
            this.Mount( bc ); 
         }
			NpcType = (int)NpcTypes.Humanoid;  
			Elite=1;
			Size = 1.15f;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.LieutenantDoren, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{
	public class DeputyRainer : BaseNPC
	{
		public DeputyRainer() : base()
		{
			Name = "Deputy Rainer";
			//Guild="Captain of the Guard";
			Id = 963;
			Model = 3279;
			Level = RandomLevel(10);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1954;
 			BaseMana = 2669;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Stormwind;
			NpcText00="Hello, $C.  I hope you've come to bolster our ranks.  Beasts and thieves are spilling into our beloved Elwynn, and we barely have enough men to keep the roads safe!$B$BAnd if you haven't done so, read that notice about Hogger.  He's a beast in yonder woods that must be dealt with.";
			
			Equip( new Longsword());//, new StormwindGuardShield() ); 
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.DeputyRainer, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			//Quests = new BaseQuest[] { new Riverpaw_Gnoll_Bounty() };

		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}
