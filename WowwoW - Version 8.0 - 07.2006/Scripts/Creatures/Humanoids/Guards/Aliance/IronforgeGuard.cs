using System;
using Server.Items;

namespace Server.Creatures
{
	public class MountaineerThalos : BaseCreature
	{
		public MountaineerThalos() : base()
		{
			Name = "Mountaineer Thalos";
			Id = 1965;
			Model = 1567;
			Level = RandomLevel(15);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08080046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Equip( new Hammer()); 
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerThalos, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 321, 15 );
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
	public class MountedIronforgeMountaineer : BaseCreature
	{
		public MountedIronforgeMountaineer() : base()
		{
			Name = "Mounted Ironforge Mountaineer";
			Id = 12996;
			Model = 1567;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountedIronforgeMountaineer, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 751, 30 );
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
	public class IronforgeMountaineer : BaseCreature
	{
		public IronforgeMountaineer() : base()
		{
			Name = "Ironforge Mountaineer";
			Id = 727;
			Model = 1598;
			Level = RandomLevel(18,30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new BronzeWarhammer(), new MasterHuntersRifle());
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.IronforgeMountaineer, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 384, 18 );
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
	public class ColdridgeMountaineer : BaseCreature
	{
		public ColdridgeMountaineer() : base()

		{
			Name = "Coldridge Mountaineer";
			Id = 853;
			Model = 1598;
			Level = RandomLevel(30,60);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new BronzeWarhammer(), new MasterHuntersRifle());
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.ColdridgeMountaineer, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 758, 30 );
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
	public class MenethilGuard : BaseCreature
	{
		public MenethilGuard() : base()
		{
			Name = "Menethil Guard";
			Id = 1475;
			Model = 790;
			Level = RandomLevel(38,42);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x010480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Longsword(), new SmallRoundShield());
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MenethilGuard, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 958, 38 );
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
	public class IronforgeGuard : BaseCreature
	{
		public IronforgeGuard() : base()
		{
			Name = "Ironforge Guard";
			Id = 5595;
			Model = 3524;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x010480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Equip( new DwarvenHatchet(), new Item( 10968, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )); 
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.IronforgeGuard, 100f ),
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
	public class BaeldunOfficer : BaseCreature
	{
		public BaeldunOfficer() : base()
		{
			Name = "Bael'dun Officer";
			Id = 3378;
			Model = 3870;
			Level = RandomLevel(26);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 0.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7484, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.BaeldunOfficer, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 421, 26 );
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
	public class AnvilrageOfficer : BaseCreature
	{
		public AnvilrageOfficer() : base()
		{
			Name = "Anvilrage Officer";
			Id = 8895;
			Model = 3524;
			Level = RandomLevel(55);
			SetDamage(1f+3.5f*Level,1f+4*Level);			
			AttackSpeed = 2000;
			Armor = 200*Level;
			Block = 3*Level;
			Flags1 = 0x010480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.9f;
			WalkSpeed = 3.9f;
			RunSpeed = 6.9f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Elite=1;
			Equip( new Item( 5175, InventoryTypes.TwoHanded, 2, 8, 1, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));			
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.AnvilrageOfficer, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BaseMana = 3964;
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
	public class MountaineerFlint : BaseCreature
	{
		public MountaineerFlint() : base()
		{
			Name = "Mountaineer Flint";
			Id = 1279;
			Model = 1783;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3777550f;
			CombatReach = 1.5f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			if ( !World.Loading ) 
			{ 
				BaseCreature bc = (BaseCreature)new BlackRam();          
				World.Add( bc, X, Y, Z, MapId );          
				this.Mount( bc ); 
			}
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));			
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerFlint, 100f ),
										  new BaseTreasure(Drops.MoneyB, 100f )};
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
	public class MountaineerCobbleflint : BaseCreature
	{
		public MountaineerCobbleflint() : base()
		{
			Name = "Mountaineer Cobbleflint";
			Id = 1089;
			Model = 1628;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerCobbleflint, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerWallbang : BaseCreature
	{
		public MountaineerWallbang() : base()
		{
			Name = "Mountaineer Wallbang";
			Id = 1090;
			Model = 1629;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerWallbang, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerGravelgaw : BaseCreature
	{
		public MountaineerGravelgaw() : base()
		{
			Name = "Mountaineer Gravelgaw";
			Id = 1091;
			Model = 1625;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerGravelgaw, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerBrokk : BaseCreature
	{
		public MountaineerBrokk() : base()
		{
			Name = "Mountaineer Brokk";
			Id = 1276;
			Model = 1777;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerBrokk, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerGanin : BaseCreature
	{
		public MountaineerGanin() : base()
		{
			Name = "Mountaineer Ganin";
			Id = 1277;
			Model = 1784;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerGanin, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerStenn : BaseCreature
	{
		public MountaineerStenn() : base()
		{
			Name = "Mountaineer Stenn";
			Id = 1278;
			Model = 1784;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerStenn, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerDroken : BaseCreature
	{
		public MountaineerDroken() : base()
		{
			Name = "Mountaineer Droken";
			Id = 1280;
			Model = 1781;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerDroken, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerZaren : BaseCreature
	{
		public MountaineerZaren() : base()
		{
			Name = "Mountaineer Zaren";
			Id = 1281;
			Model = 1812;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerZaren, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerVeek : BaseCreature
	{
		public MountaineerVeek() : base()
		{
			Name = "Mountaineer Veek";
			Id = 1282;
			Model = 1809;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerVeek, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerKalmir : BaseCreature
	{
		public MountaineerKalmir() : base()
		{
			Name = "Mountaineer Kalmir";
			Id = 1283;
			Model = 1793;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerKalmir, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerNaarh : BaseCreature
	{
		public MountaineerNaarh() : base()
		{
			Name = "Mountaineer Naarh";
			Id = 1329;
			Model = 1800;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerNaarh, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerTyraw : BaseCreature
	{
		public MountaineerTyraw() : base()
		{
			Name = "Mountaineer Tyraw";
			Id = 1330;
			Model = 1807;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerTyraw, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerLuxst : BaseCreature
	{
		public MountaineerLuxst() : base()
		{
			Name = "Mountaineer Luxst";
			Id = 1331;
			Model = 1796;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerLuxst, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerMorran : BaseCreature
	{
		public MountaineerMorran() : base()
		{
			Name = "Mountaineer Morran";
			Id = 1332;
			Model = 1799;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerMorran, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerHammerfall : BaseCreature
	{
		public MountaineerHammerfall() : base()
		{
			Name = "Mountaineer Hammerfall";
			Id = 1334;
			Model = 1789;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerHammerfall, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerYuttha : BaseCreature
	{
		public MountaineerYuttha() : base()
		{
			Name = "Mountaineer Yuttha";
			Id = 1335;
			Model = 1811;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerYuttha, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerZwarn : BaseCreature
	{
		public MountaineerZwarn() : base()
		{
			Name = "Mountaineer Zwarn";
			Id = 1336;
			Model = 1813;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerZwarn, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerGwarth : BaseCreature
	{
		public MountaineerGwarth() : base()
		{
			Name = "Mountaineer Gwarth";
			Id = 1337;
			Model = 1786;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerGwarth, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerDalk : BaseCreature
	{
		public MountaineerDalk() : base()
		{
			Name = "Mountaineer Dalk";
			Id = 1338;
			Model = 1779;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerDalk, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerKadrell : BaseCreature
	{
		public MountaineerKadrell() : base()
		{
			Name = "Mountaineer Kadrellk";
			Id = 1340;
			Model = 1892;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			NpcText="Welcome to Thelsamar, your home away from home in Loch Modan!$B$BThelsamar is a nice place, but it's not all beer and salted meat for those who answer the call to duty!  If you're willing to face danger in the name of the Alliance, then read the poster outside the Thelsamar branch of the Explorers' League.";
			Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));//, new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerKadrell, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerRockgar : BaseCreature
	{
		public MountaineerRockgar() : base()
		{
			Name = "Mountaineer Rockgar";
			Id = 1342;
			Model = 1893;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerRockgar, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerStormpike : BaseCreature
	{
		public MountaineerStormpike() : base()
		{
			Name = "Mountaineer Stormpike";
			Id = 1343;
			Model = 1894;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerStormpike, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerBarleybrew : BaseCreature
	{
		public MountaineerBarleybrew() : base()
		{
			Name = "Mountaineer Barleybrew";
			Id = 1959;
			Model = 1891;
			Level = RandomLevel(20,30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));//, new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerBarleybrew, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 786, 20 );
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
	public class MountaineerDokkin : BaseCreature
	{
		public MountaineerDokkin() : base()
		{
			Name = "Mountaineer Dokkin";
			Id = 2105;
			Model = 1780;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerDokkin, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerGrugelm : BaseCreature
	{
		public MountaineerGrugelm() : base()
		{
			Name = "Mountaineer Grugelm";
			Id = 2466;
			Model = 1785;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerGrugelm, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerThar : BaseCreature
	{
		public MountaineerThar() : base()
		{
			Name = "Mountaineer Thar";
			Id = 2468;
			Model = 1785;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerThar, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerRharen : BaseCreature
	{
		public MountaineerRharen() : base()
		{
			Name = "Mountaineer Rharen";
			Id = 2469;
			Model = 1802;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7438, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerRharen, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerHarn : BaseCreature
	{
		public MountaineerHarn() : base()
		{
			Name = "Mountaineer Harn";
			Id = 2506;
			Model = 1790;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerHarn, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerUthan : BaseCreature
	{
		public MountaineerUthan() : base()
		{
			Name = "Mountaineer Uthan";
			Id = 2507;
			Model = 1808;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerUthan, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerWuar : BaseCreature
	{
		public MountaineerWuar() : base()
		{
			Name = "Mountaineer Wuar";
			Id = 2508;
			Model = 1810;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerWuar, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerCragg : BaseCreature
	{
		public MountaineerCragg() : base()
		{
			Name = "Mountaineer Cragg";
			Id = 2509;
			Model = 1778;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerCragg, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerOzmok : BaseCreature
	{
		public MountaineerOzmok() : base()
		{
			Name = "Mountaineer Ozmok";
			Id = 2510;
			Model = 1801;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerOzmok, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerBludd : BaseCreature
	{
		public MountaineerBludd() : base()
		{
			Name = "Mountaineer Bludd";
			Id = 2511;
			Model = 1776;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerBludd, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerRoghan : BaseCreature
	{
		public MountaineerRoghan() : base()
		{
			Name = "Mountaineer Roghan";
			Id = 2512;
			Model = 1803;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerRoghan, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerJanha : BaseCreature
	{
		public MountaineerJanha() : base()
		{
			Name = "Mountaineer Janha";
			Id = 2513;
			Model = 1803;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerJanha, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerModax : BaseCreature
	{
		public MountaineerModax() : base()
		{
			Name = "Mountaineer Modax";
			Id = 2514;
			Model = 1797;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerModax, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerFazgard : BaseCreature
	{
		public MountaineerFazgard() : base()
		{
			Name = "Mountaineer Fazgard";
			Id = 2515;
			Model = 1782;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerFazgard, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerKamdar : BaseCreature
	{
		public MountaineerKamdar() : base()
		{
			Name = "Mountaineer Kamdar";
			Id = 2516;
			Model = 1794;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerKamdar, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerLangarr : BaseCreature
	{
		public MountaineerLangarr() : base()
		{
			Name = "Mountaineer Langarr";
			Id = 2517;
			Model = 1795;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerLangarr, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerSwarth : BaseCreature
	{
		public MountaineerSwarth() : base()
		{
			Name = "Mountaineer Swarth";
			Id = 2518;
			Model = 1805;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerSwarth, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerHaggis : BaseCreature
	{
		public MountaineerHaggis() : base()
		{
			Name = "Mountaineer Haggis";
			Id = 2524;
			Model = 1805;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerHaggis, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerBarn : BaseCreature
	{
		public MountaineerBarn() : base()
		{
			Name = "Mountaineer Barn";
			Id = 2525;
			Model = 1775;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerBarn, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerMorlic : BaseCreature
	{
		public MountaineerMorlic() : base()
		{
			Name = "Mountaineer Morlic";
			Id = 2526;
			Model = 1798;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerMorlic, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerAngst : BaseCreature
	{
		public MountaineerAngst() : base()
		{
			Name = "Mountaineer Angst";
			Id = 2527;
			Model = 1774;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerAngst, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerHaggil : BaseCreature
	{
		public MountaineerHaggil() : base()
		{
			Name = "Mountaineer Haggil";
			Id = 2528;
			Model = 1787;
			Level = RandomLevel(30);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerHaggil, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerPebblebitty : BaseCreature
	{
		public MountaineerPebblebitty() : base()
		{
			Name = "Mountaineer Pebblebitty";
			Id = 3836;
			Model = 1927;
			Level = RandomLevel(44);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.25f;
			WalkSpeed = 3.25f;
			RunSpeed = 6.25f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerPebblebitty, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class ThelsamarMountaineer : BaseCreature
	{
		public ThelsamarMountaineer() : base()
		{
			Name = "Thelsamar Mountaineer";
			Id = 8055;
			Model = 1598;
			Level = RandomLevel(40);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.25f;
			WalkSpeed = 3.25f;
			RunSpeed = 6.25f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.ThelsamarMountaineer, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class MountaineerDolf : BaseCreature
	{
		public MountaineerDolf() : base()
		{
			Name = "Mountaineer Dolf";
			Id = 12427;
			Model = 12474;
			Level = RandomLevel(7);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x08480406;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.MountaineerDolf, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class DunMoroghMountaineer : BaseCreature
	{
		public DunMoroghMountaineer() : base()
		{
			Name = "Dun Morogh Mountaineer";
			Id = 13076;
			Model = 1598;
			Level = RandomLevel(7);
			SetDamage(1f+2.5f*Level,1f+3*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;			
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.DunMoroghMountaineer, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
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
	public class ExpeditionaryMountaineer : BaseCreature
	{
		public ExpeditionaryMountaineer() : base()
		{
			Name = "Expeditionary Mountaineer";
			Id = 14390;
			Model = 1598;
			Level = RandomLevel(7);
			SetDamage(1f+3.5f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 160*Level;;
			Block = 2*Level;
			Flags1 = 0x080080;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.5f);
			BoundingRadius = 0.3477550f;
			CombatReach = 1.500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.IronForge;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Elite=1;			
			Equip( new Item( 7440, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( IronForgeGuardsDrops.ExpeditionaryMountaineer, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 986, 30 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


