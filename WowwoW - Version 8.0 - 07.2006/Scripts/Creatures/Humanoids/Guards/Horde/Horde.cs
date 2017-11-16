using System;
using Server.Items;


namespace Server.Creatures
{	public class HammerfallGrunt : BaseCreature
	{
		public HammerfallGrunt() : base()
		{
			Name = "Hammerfall Grunt";
			Id = 2619;
			Model = 4032;
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
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Horde;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( HordeGuardsDrops.HammerfallGrunt, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 757, 34 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}

namespace Server.Creatures
{	public class GruntDogran : BaseCreature
	{
		public GruntDogran() : base()
		{
			Name = "Grunt Dogran";
			Id = 5908;
			Model = 4544;
			Level = RandomLevel(20);
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
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Horde;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( HordeGuardsDrops.GruntDogran, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 557, 20 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}

namespace Server.Creatures
{	public class GruntLogmar : BaseCreature
	{
		public GruntLogmar() : base()
		{
			Name = "Grunt Logmar";
			Id = 5911;
			Model = 4547;
			Level = RandomLevel(20);
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
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Horde;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 18607, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( HordeGuardsDrops.GruntLogmar, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 557, 20 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class GruntGargal : BaseCreature
	{
		public GruntGargal() : base()
		{
			Name = "Grunt Gargal";
			Guild="Kargath Expeditionary Force";
			Id = 9086;
			Model = 8352;
			Level = RandomLevel(52);
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
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Horde;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( HordeGuardsDrops.GruntGargal, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2557, 52 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class HordeGrunt : BaseCreature
	{
		public HordeGrunt() : base()
		{
			Name = "Horde Grunt";
			Id = 11682;
			Model = 11862;
			Level = RandomLevel(29,30);
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
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Horde;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 20502, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 22635, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( HordeGuardsDrops.HordeGrunt, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 857, 29 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}
