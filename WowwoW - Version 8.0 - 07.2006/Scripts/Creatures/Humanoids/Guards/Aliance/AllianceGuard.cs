using System;
using Server.Items;


namespace Server.Creatures
{
	public class NightWatchGuard : BaseCreature
	{
		public NightWatchGuard() : base()
		{
			Name = "Night Watch Guard";
			Guild="The Night Watch";
			Id = 10038;
			Model = 2381;
			Level = RandomLevel(40);
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
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 780;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Alliance;

			Equip( new NightWatchShortsword(), new PhalanxShield() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.NightWatchGuard, 100f ),
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
	public class AnvilrageMarshal : BaseCreature
	{
		public AnvilrageMarshal() : base()
		{
			Name = "Anvilrage Marshal";
			Id = 8898;
			Model = 8751;
			Level = RandomLevel(54);
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
			BaseHitPoints = 2504;
 			BaseMana = 4469;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Alliance;

			Equip( new GrandMarshalsBattleHammer() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.AnvilrageMarshal, 100f ),
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
	public class MarshalWindsor : BaseCreature
	{
		public MarshalWindsor() : base()
		{
			Name = "Marshal Windsor";
			Id = 9023;
			Model = 8707;
			Level = RandomLevel(52);
			SetDamage(1f+3.5f*Level,1f+4*Level);			
			AttackSpeed = 2000;
			Armor = 50*Level;
			Block = 3*Level;
			Flags1 = 0x0480020;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BaseHitPoints = 2541;
 			BaseMana = 3469;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.9f;
			WalkSpeed = 3.9f;
			RunSpeed = 6.9f;
			Faction = Factions.Alliance;

			//Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Elite=1;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.MarshalWindsor, 100f ),
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
	public class MarshalMaxwell : BaseCreature
	{
		public MarshalMaxwell() : base()
		{
			Name = "Marshal Maxwell";
			Id = 9560;
			Model = 8685;
			Level = RandomLevel(55);
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
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Alliance;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Equip( new Longsword()); 
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.MarshalMaxwell, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1321, 55 );
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
	public class NethergardeOfficer : BaseCreature
	{
		public NethergardeOfficer() : base()
		{ 
			Name = "Nethergarde Officer";
			Id = 6003;
			Model = 6752;
			Level = RandomLevel(50);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x080080;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Alliance;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Longsword()); 
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.NethergardeOfficer, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1321, 55 );
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
	public class SentinelThenysil : BaseCreature
	{
		public SentinelThenysil() : base()
		{
			Name = "Sentinel Thenysil";
			Id = 4079;
			Model = 2182;
			Level = RandomLevel(23);
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
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Alliance;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7437, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.SentinelThenysil, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 490, 23 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class SilverwingSentinel : BaseCreature
	{
		public SilverwingSentinel() : base()
		{
			Name = "Silverwing Sentinel";
			Id = 12896;
			Model = 4148;
			Level = RandomLevel(22,23);
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
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Alliance;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.SilverwingSentinel, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 222, 22 );
			/*****************************/
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class SilverwingWarrior : BaseCreature
	{
		public SilverwingWarrior() : base()
		{
			Name = "Silverwing Warrior";
			Id = 12897;
			Model = 4841;
			Level = RandomLevel(21,22);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
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
			Faction = Factions.Alliance;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.SilverwingWarrior, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 458, 21 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


 
