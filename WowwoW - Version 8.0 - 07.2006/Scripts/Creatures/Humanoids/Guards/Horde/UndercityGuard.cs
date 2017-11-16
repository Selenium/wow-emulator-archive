using System;
using Server.Items;

namespace Server.Creatures
{
	public class DeathguardLinnea : BaseCreature
	{
		public DeathguardLinnea() : base()
		{
			Name = "Deathguard Linnea";
			Id = 1495;
			Model = 2858;
			Level = RandomLevel(22);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 350;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;

			Equip( new NordicLongshank(), new SmallRoundShield() ); //7485,1684
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardLinnea, 100f ),
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
	public class DeathguardDillinger : BaseCreature
	{
		public DeathguardDillinger() : base()
		{
			Name = "Deathguard Dillinger";
			Id = 1496;
			Model = 2855;
			Level = RandomLevel(22);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 350;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardDillinger, 100f ),
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
	public class DeathguardSimmer : BaseNPC
	{
		public DeathguardSimmer() : base()
		{
			Name = "Deathguard Simmer";
			Id = 1519;
			Model = 1648;
			Level = RandomLevel(23);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 400;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Item( 7460, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ) );
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardSimmer, 100f ),
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
	public class DeathguardBurgess : BaseCreature
	{
		public DeathguardBurgess() : base()
		{
			Name = "Deathguard Burgess";
			Id = 1652;
			Model = 1666;
			Level = RandomLevel(24);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 450;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardBurgess, 100f ),
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
	public class DeathguardAbraham : BaseCreature
	{
		public DeathguardAbraham() : base()
		{
			Name = "Deathguard Abraham";
			Id = 1735;
			Model = 2852;
			Level = RandomLevel(22);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 380;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardAbraham, 100f ),
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
	public class DeathguardRandolph : BaseCreature
	{
		public DeathguardRandolph() : base()
		{
			Name = "Deathguard Randolph";
			Id = 1736;
			Model = 1590;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010400002;
			NpcFlags = 0 ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1240;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardRandolph, 100f ),
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
	public class DeathguardOliver : BaseCreature
	{
		public DeathguardOliver() : base()
		{
			Name = "Deathguard Oliver";
			Id = 1737;
			Model = 1588;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010400002;
			NpcFlags = 0 ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1240;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardOliver, 100f ),
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
	public class DeathguardTerrence : BaseCreature
	{
		public DeathguardTerrence() : base()
		{
			Name = "Deathguard Terrence";
			Id = 1738;
			Model = 1588;
			Level = RandomLevel(21);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0 ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 340;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardTerrence, 100f ),
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
	public class DeathguardPhillip : BaseCreature
	{
		public DeathguardPhillip() : base()
		{
			Name = "Deathguard Phillip";
			Id = 1739;
			Model = 1589;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010400002;
			NpcFlags = 0 ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1240;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardPhillip, 100f ),
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
	public class DeathguardBartrand : BaseCreature
	{
		public DeathguardBartrand() : base()
		{
			Name = "Deathguard Bartrand";
			Id = 1741;
			Model = 1587;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010400002;
			NpcFlags = 0 ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1240;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardBartrand, 100f ),
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
	public class DeathguardBartholomew : BaseCreature
	{
		public DeathguardBartholomew() : base()
		{
			Name = "Deathguard Bartholomew";
			Id = 1742;
			Model = 2853;
			Level = RandomLevel(22);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 440;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardBartholomew, 100f ),
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
	public class DeathguardLawrence : BaseCreature
	{
		public DeathguardLawrence() : base()
		{
			Name = "Deathguard Lawrence";
			Id = 1743;
			Model = 2857;
			Level = RandomLevel(22);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 340;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardLawrence, 100f ),
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
	public class DeathguardMort : BaseCreature
	{
		public DeathguardMort() : base()
		{
			Name = "Deathguard Mort";
			Id = 1744;
			Model = 2860;
			Level = RandomLevel(24);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 300;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardMort, 100f ),
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
	public class DeathguardMorris : BaseCreature
	{
		public DeathguardMorris() : base()
		{
			Name = "Deathguard Morris";
			Id = 1745;
			Model = 2859;
			Level = RandomLevel(22);
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
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 340;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardMorris, 100f ),
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
	public class DeathguardCyrus : BaseCreature
	{
		public DeathguardCyrus() : base()
		{
			Name = "Deathguard Cyrus";
			Id = 1746;
			Model = 2854;
			Level = RandomLevel(21);
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
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 200;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardCyrus, 100f ),
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
	public class DeathguardGavin : BaseCreature
	{
		public DeathguardGavin() : base()
		{
			Name = "Deathguard Gavin";
			Id = 2209;
			Model = 2856;
			Level = RandomLevel(24);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 400;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardGavin, 100f ),
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
	public class DeathguardRoyann : BaseCreature
	{
		public DeathguardRoyann() : base()
		{
			Name = "Deathguard Royann";
			Id = 2210;
			Model = 2861;
			Level = RandomLevel(24);
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
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 400;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardRoyann, 100f ),
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
	public class TarrenMillDeathguard : BaseCreature
	{
		public TarrenMillDeathguard() : base()
		{
			Name = "Tarren Mill Deathguard";
			Id = 2405;
			Model = 3663;
			Level = RandomLevel(50);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010400002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1400;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;

			Equip( new Scimitar(), new SmallRoundShield() );
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.TarrenMillDeathguard, 100f ),
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
	public class DeathguardSamsa : BaseCreature
	{
		public DeathguardSamsa() : base()
		{
			Name = "Deathguard Samsa";
			Id = 2418;
			Model = 1646;
			Level = RandomLevel(32);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 710;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Undercity;

			Equip( new Shortsword(), new Club() ); //7487 6537
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardSamsa, 100f ),
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
	public class DeathguardHumbert : BaseCreature
	{
		public DeathguardHumbert() : base()
		{
			Name = "Deathguard Humbert";
			Id = 2419;
			Model = 1647;
			Level = RandomLevel(32);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 710;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Undercity;

			Equip( new Shortsword(), new Club() ); //7487 6537
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardHumbert, 100f ),
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
	public class UndercityGuardian : BaseCreature
	{
		public UndercityGuardian() : base()
		{
			Name = "Undercity Guardian";
			Id = 5624;
			Model = 10699;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4*Level);			
			AttackSpeed = 2000;
			Armor = 50*Level;
			Block = 2*Level;
			Flags1 = 0x010480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level*1.5f);
			BaseHitPoints = 710;
 			BaseMana = 0;
 			BoundingRadius = 0.6077550f;
			CombatReach = 1.600f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Undercity;

			//Equip( new Shortsword(), new Club() ); //7487 6537
			NpcType = (int)NpcTypes.Undead;  
			Size = 1.3f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.UndercityGuardian, 100f ),
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
	public class DeathguardLundmark : BaseCreature
	{
		public DeathguardLundmark() : base()
		{
			Name = "Deathguard Lundmark";
			Id = 5725;
			Model = 10192;
			Level = RandomLevel(15);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 710;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Undercity;

		         if ( !World.Loading ) 
         { 
            BaseCreature bc = (BaseCreature)new BlackSkeletalWarhorse();          
            World.Add( bc, X, Y, Z, MapId );          
            this.Mount( bc ); 
         }			
			Equip( new Hatchet(), new Item(10968, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardLundmark, 100f ),
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
	public class DeathguardPodrig : BaseCreature
	{
		public DeathguardPodrig() : base()
		{
			Name = "Deathguard Podrig";
			Id = 6389;
			Model = 5345;
			Level = RandomLevel(25);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 710;
 			BaseMana = 2680;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardPodrig, 100f ),
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
	public class SilverpineDeathguard : BaseCreature
	{
		public SilverpineDeathguard() : base()
		{
			Name = "Silverpine Deathguard";
			Id = 7489;
			Model = 10797;
			Level = RandomLevel(40);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010400002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 612;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;

			Equip( new Hatchet(), new CrestedBuckler());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.SilverpineDeathguard, 100f ),
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
	public class DeathguardElite : BaseCreature
	{
		public DeathguardElite() : base()
		{
			Name = "Deathguard Elite";
			Id = 7980;
			Model = 7117;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4*Level);			
			AttackSpeed = 2000;
			Armor = 50*Level;
			Block = 3*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level*1.5f);
			BaseHitPoints = 1778;
 			BaseMana = 2680;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardElite, 100f ),
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
	public class DeathguardKel : BaseCreature
	{
		public DeathguardKel() : base()
		{
			Name = "Deathguard Kel";
			Id = 12428;
			Model = 12475;
			Level = RandomLevel(7);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400406;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 212;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.DeathguardKel, 100f ),
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
	public class RoyalDreadguard : BaseCreature
	{
		public RoyalDreadguard() : base()
		{
			Name = "Royal Dreadguard";
			Id = 13839;
			Model = 12475;
			Level = RandomLevel(60);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 60*Level;
			Block = 4*Level;
			Flags1 = 0x0480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level*3.5f);
			BaseHitPoints = 2510;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new RedridgeMachete(), new CrestedBuckler());
			
			Size = 1.15f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.RoyalDreadguard, 100f ),
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
	public class ExecutorZygand : BaseCreature
	{
		public ExecutorZygand() : base()
		{
			Name = "Executor Zygand";
			Id = 1515;
			Model = 1649;
			Level = RandomLevel(14);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 612;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			//Equip( new Hatchet());
		         if ( !World.Loading ) 
         { 
            BaseCreature bc = (BaseCreature)new BlackSkeletalWarhorse();  //need check for normal       
            World.Add( bc, X, Y, Z, MapId );          
            this.Mount( bc ); 
         }			
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.ExecutorZygand, 100f ),
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
	public class ExecutorArren : BaseNPC
	{
		public ExecutorArren() : base()
		{
			Name = "Executor Arren";
			Id = 1570;
			Model = 1583;
			Level = RandomLevel(5);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08000066;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 172;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Hatchet());
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.ExecutorArren, 100f ),
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
	public class JuniorApothecaryHolland : BaseCreature
	{
		public JuniorApothecaryHolland() : base()
		{
			Name = "Junior Apothecary Holland";
			Guild="Royal Apothecary Society";
			Id = 10665;
			Model = 9999;
			Level = RandomLevel(20);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 45*Level;
			Block = 3*Level;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/0.5f);
			BaseHitPoints = 540;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Undercity;

			Equip( new Item( 7467, InventoryTypes.MainGauche, 2, 14, 2, 0, 0, 0, 0 ), new Item( 6532, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ) ); 
			NpcType = (int)NpcTypes.Undead;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( UndercityGuardsDrops.JuniorApothecaryHolland, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}
