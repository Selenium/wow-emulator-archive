using System;
using Server.Items;


namespace Server.Creatures
{	public class Bluffwatcher : BaseCreature
	{
		public Bluffwatcher() : base()
		{
			Name = "Bluffwatcher";
			Id = 3084;
			Model = 2141;
			Level = RandomLevel(50,60);
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
			BoundingRadius = 0.9747f;
			CombatReach = 4.0500f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.8f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			Equip( new Item( 23198, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.Bluffwatcher, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 50 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveWindfeather : BaseCreature
	{
		public BraveWindfeather() : base()
		{
			Name = "Brave Windfeather";
			Id = 3209;
			Model = 3770;
			Level = RandomLevel(13);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08080066;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.25f;
			//Elite=1;
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveWindfeather, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 328, 13 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveProudsnout : BaseCreature
	{
		public BraveProudsnout() : base()
		{
			Name = "Brave Proudsnout";
			Id = 3210;
			Model = 3771;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveProudsnout, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveLightninghorn : BaseCreature
	{
		public BraveLightninghorn() : base()
		{
			Name = "Brave Lightninghorn";
			Id = 3211;
			Model = 3774;
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveLightninghorn, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveIronhorn : BaseCreature
	{
		public BraveIronhorn() : base()
		{
			Name = "Brave Ironhorn";
			Id = 3212;
			Model = 3775;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveIronhorn, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class BraveRunningWolf : BaseCreature
	{
		public BraveRunningWolf() : base()
		{
			Name = "Brave Running Wolf";
			Id = 3213;
			Model = 3776;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveRunningWolf, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveGreathoof : BaseCreature
	{
		public BraveGreathoof() : base()
		{
			Name = "Brave Greathoof";
			Id = 3214;
			Model = 3778;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveGreathoof, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveStrongbash : BaseCreature
	{
		public BraveStrongbash() : base()
		{
			Name = "Brave Strongbash";
			Id = 3215;
			Model = 3777;
			Level = RandomLevel(55);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveStrongbash, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveDawneagle : BaseCreature
	{
		public BraveDawneagle() : base()
		{
			Name = "Brave Dawneagle";
			Id = 3217;
			Model = 3780;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveDawneagle, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveSwiftwind : BaseCreature
	{
		public BraveSwiftwind() : base()
		{
			Name = "Brave Swiftwind";
			Id = 3218;
			Model = 3779;
			Level = RandomLevel(14);
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
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.25f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveSwiftwind, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveLeapingDeer : BaseCreature
	{
		public BraveLeapingDeer() : base()
		{
			Name = "Brave Leaping Deer";
			Id = 3219;
			Model = 3781;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.25f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveLeapingDeer, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveDarksky : BaseCreature
	{
		public BraveDarksky() : base()
		{
			Name = "Brave Darksky";
			Id = 3220;
			Model = 3782;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveDarksky, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class BraveRockhorn : BaseCreature
	{
		public BraveRockhorn() : base()
		{
			Name = "Brave Rockhorn";
			Id = 3221;
			Model = 3783;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveRockhorn, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveWildrunner : BaseCreature
	{
		public BraveWildrunner() : base()
		{
			Name = "Brave Wildrunner";
			Id = 3222;
			Model = 4265;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.32f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveWildrunner, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveRainchaser : BaseCreature
	{
		public BraveRainchaser() : base()
		{
			Name = "Brave Rainchaser";
			Id = 3223;
			Model = 3784;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.25f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveRainchaser, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BraveCloudmane : BaseCreature
	{
		public BraveCloudmane() : base()
		{
			Name = "Brave Cloudmane";
			Id = 3224;
			Model = 10181;
			Level = RandomLevel(14);
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveCloudmane, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 388, 14 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class CampMojacheBrave : BaseCreature
	{
		public CampMojacheBrave() : base()
		{
			Name = "Camp Mojache Brave";
			Id = 8147;
			Model = 7363;
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.25f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 3797, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.CampMojacheBrave, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class GhostWalkerBrave : BaseCreature
	{
		public GhostWalkerBrave() : base()
		{
			Name = "Ghost Walker Brave";
			Id = 8154;
			Model = 7374;
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.GhostWalkerBrave, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2128, 50 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}

namespace Server.Creatures
{	public class FreewindBrave : BaseCreature
	{
		public FreewindBrave() : base()
		{
			Name = "Freewind Brave";
			Id = 9525;
			Model = 7115;
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
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.26f;
			WalkSpeed = 3.26f;
			RunSpeed = 6.26f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 23198, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.FreewindBrave, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1828, 45 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}





namespace Server.Creatures
{	public class BraveMoonhorn : BaseCreature
	{
		public BraveMoonhorn() : base()
		{
			Name = "Brave Moonhorn";
			Id = 10079;
			Model = 9898;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.13f;
			WalkSpeed = 3.13f;
			RunSpeed = 6.13f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BraveMoonhorn, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 338, 30 );
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
		public class BloodvenomPostBrave : BaseCreature
	{
		public BloodvenomPostBrave() : base()
		{
			Name = "Bloodvenom Post Brave";
			Id = 11180;
			Model = 9898;
			Level = RandomLevel(55,62);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.9747f;
			CombatReach = 3.7500f;
			Speed = 3.36f;
			WalkSpeed = 3.36f;
			RunSpeed = 6.36f;
			Faction = Factions.ThunderBluff;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.35f;
			//Elite=1;
			//NpcText00="What are you looking for?";
			Equip( new Item( 12857, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ThunderBluffGuardsDrops.BloodvenomPostBrave, 100f ),
										  new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2228, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}