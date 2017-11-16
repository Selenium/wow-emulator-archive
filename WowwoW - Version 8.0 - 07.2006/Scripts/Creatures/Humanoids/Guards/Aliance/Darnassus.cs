using System;
using Server.Items;

namespace Server.Creatures
{
	public class SentinelKyraStarsong : BaseCreature
	{
		public SentinelKyraStarsong() : base()
		{
			Name = "Sentinel Kyra Starsong";
			Id = 2081;
			Model = 1682;
			Level = RandomLevel(12);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 1000;
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelKyraStarsong, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 375, 12 );
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
	public class SentinelShaylaNightbreeze : BaseCreature
	{
		public SentinelShaylaNightbreeze() : base()
		{
			Name = "Sentinel Shayla Nightbreeze";
			Id = 2155;
			Model = 2866;
			Level = RandomLevel(8);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x080066;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelShaylaNightbreeze, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 213, 8 );
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
	public class SentinelGlyndaNalShea : BaseCreature
	{
		public SentinelGlyndaNalShea() : base()
		{
			Name = "Sentinel Glynda Nal'Shea";
			Id = 2930;
			Model = 2865;
			Level = RandomLevel(17,45);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 7420, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelGlyndaNalShea, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 413, 17 );
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
	public class SentinelAryniaCloudsbreak : BaseNPC
	{
		public SentinelAryniaCloudsbreak() : base()
		{
			Name = "Sentinel Arynia Cloudsbreak";
			Id = 3519;
			Model = 1543;
			Level = RandomLevel(10);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7429, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelAryniaCloudsbreak, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 132, 10 );
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
	public class TeldrassilSentinel : BaseCreature
	{
		public TeldrassilSentinel() : base()
		{
			Name = "Teldrassil Sentinel";
			Id = 3571;
			Model = 4849;
			Level = RandomLevel(20,55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 0, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.TeldrassilSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 589, 20 );
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
	public class SentinelTyshaMoonblade : BaseCreature
	{
		public SentinelTyshaMoonblade() : base()
		{
			Name = "Sentinel Tysha Moonblade";
			Id = 3639;
			Model = 1750;
			Level = RandomLevel(10);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7437, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelTyshaMoonblade, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 190, 10 );
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
	public class SentinelElissaStarbreeze : BaseCreature
	{
		public SentinelElissaStarbreeze() : base()
		{
			Name = "Sentinel Elissa Starbreeze";
			Id = 3657;
			Model = 2529;
			Level = RandomLevel(18,20);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7437, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelElissaStarbreeze, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 450, 18 );
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
	public class SentinelSelarin : BaseCreature
	{
		public SentinelSelarin() : base()
		{
			Name = "Sentinel Selarin";
			Id = 3694;
			Model = 1982;
			Level = RandomLevel(19,20);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08400046;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 7437, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelSelarin, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 450, 19 );
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
	public class SentinelMelyriaFrostshadow : BaseCreature
	{
		public SentinelMelyriaFrostshadow() : base()
		{
			Name = "Sentinel Melyria Frostshadow";
			Id = 3880;
			Model = 1957;
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
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 6231, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelMelyriaFrostshadow, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 490, 25 );
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
	public class SentinelVeleneStarstrike : BaseCreature
	{
		public SentinelVeleneStarstrike() : base()
		{
			Name = "Sentinel Velene Starstrike";
			Id = 3885;
			Model = 2867;
			Level = RandomLevel(25);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 6231, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelVeleneStarstrike, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 490, 25 );
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
	public class ShandrisFeathermoon : BaseCreature
	{
		public ShandrisFeathermoon() : base()
		{
			Name = "Shandris Feathermoone";
			Guild="General of the Sentinel Army";
			Id = 3936;
			Model = 2035;
			Level = RandomLevel(62);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 6231, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.ShandrisFeathermoon, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2490, 62 );
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
	public class DarnassusSentinel : BaseCreature
	{
		public DarnassusSentinel() : base()
		{
			Name = "Darnassus Sentinel";
			Id = 4262;
			Model = 14613;
			Level = RandomLevel(55,75);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480002;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.DarnassusSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1490, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class AuberdineSentinel : BaseCreature
	{
		public AuberdineSentinel() : base()
		{
			Name = "Auberdine Sentinel";
			Id = 6086;
			Model = 4845;
			Level = RandomLevel(25,40);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.AuberdineSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 490, 25 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class AstranaarSentinel : BaseCreature
	{
		public AstranaarSentinel() : base()
		{
			Name = "Astranaar Sentinel";
			Id = 6087;
			Model = 4845;
			Level = RandomLevel(40);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.AstranaarSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 990, 40 );
			/*****************************/
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}





namespace Server.Creatures
{	public class FeathermoonSentinel : BaseCreature
	{
		public FeathermoonSentinel() : base()
		{
			Name = "Feathermoon Sentinel";
			Id = 7939;
			Model = 7012;
			Level = RandomLevel(55,62);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.FeathermoonSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1990, 55 );
			/*****************************/
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class AshenvaleSentinel : BaseCreature
	{
		public AshenvaleSentinel() : base()
		{
			Name = "Ashenvale Sentinel";
			Id = 8015;
			Model = 4841;
			Level = RandomLevel(40);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.AshenvaleSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1990, 40 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class SentinelDaliaSunblade : BaseCreature
	{
		public SentinelDaliaSunblade() : base()
		{
			Name = "Sentinel Dalia Sunblade";
			Id = 8396;
			Model = 7602;
			Level = RandomLevel(44);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelDaliaSunblade, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1990, 44 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class SentinelKeldaraSunblade : BaseCreature
	{
		public SentinelKeldaraSunblade() : base()
		{
			Name = "Sentinel Keldara Sunblade";
			Id = 8397;
			Model = 7603;
			Level = RandomLevel(44);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.25f;
			WalkSpeed = 3.25f;
			RunSpeed = 6.25f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelKeldaraSunblade, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1990, 44 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class AzsharaSentinel : BaseCreature
	{
		public AzsharaSentinel() : base()
		{
			Name = "Azshara Sentinel";
			Id = 11276;
			Model = 2306;
			Level = RandomLevel(44);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.25f;
			WalkSpeed = 3.25f;
			RunSpeed = 6.25f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.AzsharaSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1990, 44 );
			/*****************************/
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class SentinelAynasha : BaseCreature
	{
		public SentinelAynasha() : base()
		{
			Name = "Sentinel Aynasha";
			Id = 11711;
			Model = 11663;
			Level = RandomLevel(20);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0180004;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 24931, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelAynasha, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 390, 20 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class SentinelOnaeya : BaseCreature
	{
		public SentinelOnaeya() : base()
		{
			Name = "Sentinel Onaeya";
			Id = 11806;
			Model = 11729;
			Level = RandomLevel(20);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0180004;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Darnasus;	//FAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelOnaeya, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 390, 20 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class ShadowglenSentinel : BaseCreature
	{
		public ShadowglenSentinel() : base()
		{
			Name = "Shadowglen Sentinel";
			Id = 12160;
			Model = 4841;
			Level = RandomLevel(50,55);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.ShadowglenSentinel, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2390, 50 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class SentinelShaya : BaseCreature
	{
		public SentinelShaya() : base()
		{
			Name = "Sentinel Shaya";
			Id = 12429;
			Model = 12476;
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.SentinelShaya, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 190, 7 );
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
	public class AeanSwiftriver: BaseCreature 
	 { 
		public  AeanSwiftriver() : base() 
		 { 
			Id = 5797;
			Model = 4345;
			Level = RandomLevel( 25 );
			AttackSpeed= 1100;
			Name = "Aean Swiftriver" ;
			Guild="Alliance Outrunner";
			Flags1 = 0x080000;			 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.75f);
			NpcType = (int)NpcTypes.Humanoid; 
			Armor= Level*42;
			ManaType=0;
			Block=Level+40;
			NpcFlags = 0;
			CombatReach = 19f ;
			BoundingRadius = 1f ;
			SetDamage(1f+4.8f*Level,1f+5.5*Level);			
			Elite = 2;
			Speed = 3.76f ;
			WalkSpeed = 3.76f ;
			RunSpeed = 6.76f ;			
			Size=1.0f;
			Faction = Factions.Darnasus;

			Equip( new Item( 8378, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{ new BaseTreasure( DarnassusGuardsDrops.AeanSwiftriver, 100f ),
								new BaseTreasure(DropsME.MoneyElite2, 100f )};
			/*****************************/
			BCAddon.Hp( this, 3671, 25 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}	
}



namespace Server.Creatures
{	public class AncientofWar : BaseCreature
	{
		public AncientofWar() : base()
		{
			Name = "Ancient of War";
			Id = 3469;
			Model = 1461;
			Level = RandomLevel(62);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Darnasus;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 3f;
			//Elite=1;
			//Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( DarnassusGuardsDrops.AncientofWar, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 3190, 62 );
			/*****************************/
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}
