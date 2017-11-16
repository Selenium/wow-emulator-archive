using System;
using Server.Items;


namespace Server.Creatures
{
	public class ScoutGaliaan : BaseNPC
	{
		public ScoutGaliaan() : base()
		{
			Name = "Scout Galiaan";
			Guild="The People's Militia";
			Id = 878;
			Model = 2373;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			NpcFlags = (int)NpcActions.Dialog ; 
			Faction = Factions.Stormwind;
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ScoutGaliaan, 100f ),
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
	public class GryanStoutmantle : BaseNPC
	{
		public GryanStoutmantle() : base()
		{
			Name = "Gryan Stoutmantle";
			Guild="The People's Militia";
			Id = 234;
			Model = 1690;
			Level = RandomLevel(30);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 1500;
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
			BaseHitPoints = 4804;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.77f;
			WalkSpeed = 3.77f;
			RunSpeed = 6.77f;
			Faction = Factions.Stormwind;
			NpcType = (int)NpcTypes.Humanoid;
			Elite=1;
			Size = 1.0f;
			Equip( new Item( 2466, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
			BCAddon.Hp( this, 2500, 30 );
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.GryanStoutmantle, 100f ),
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
	public class ProtectorBialon : BaseCreature
	{
		public ProtectorBialon() : base()
		{
			Name = "Protector Bialon";
			Guild="The People's Militia";
			Id = 487;
			Model = 2373;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 2, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorBialon, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ProtectorWeaver : BaseCreature
	{
		public ProtectorWeaver() : base()
		{
			Name = "Protector Weaver";
			Guild="The People's Militia";
			Id = 488;
			Model = 2371;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 2, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorWeaver, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class ProtectorDutfield : BaseCreature
	{
		public ProtectorDutfield() : base()
		{
			Name = "Protector Dutfield";
			Guild="The People's Militia";
			Id = 489;
			Model = 2371;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 2, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorDutfield, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ProtectorGariel : BaseCreature
	{
		public ProtectorGariel() : base()
		{
			Name = "Protector Gariel";
			Guild="The People's Militia";
			Id = 490;
			Model = 2367;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorGariel, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class ProtectorDorana : BaseCreature
	{
		public ProtectorDorana() : base()
		{
			Name = "Protector Dorana";
			Guild="The People's Militia";
			Id = 869;
			Model = 2367;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new PatrolAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorDorana, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class ProtectorDeni : BaseCreature
	{
		public ProtectorDeni() : base()
		{
			Name = "Protector Deni";
			Guild="The People's Militia";
			Id = 870;
			Model = 2367;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorDeni, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ProtectorKorelor : BaseCreature
	{
		public ProtectorKorelor() : base()
		{
			Name = "Protector Korelor";
			Guild="The People's Militia";
			Id = 874;
			Model = 2369;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new PatrolAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorKorelor, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ProtectorLeick : BaseCreature
	{
		public ProtectorLeick() : base()
		{
			Name = "Protector Leick";
			Guild="The People's Militia";
			Id = 876;
			Model = 2370;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorLeick, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class ProtectorofthePeople : BaseCreature
	{
		public ProtectorofthePeople() : base()
		{
			Name = "Protector of the People";
			Guild="The People's Militia";
			Id = 8096;
			Model = 7308;
			Level = RandomLevel(40);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 1400;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0400002;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 780;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.22f;
			WalkSpeed = 3.22f;
			RunSpeed = 6.22f;
			NpcFlags = 0; 
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ProtectorofthePeople, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ScoutRiell : BaseCreature
	{
		public ScoutRiell() : base()
		{
			Name = "Scout Riell";
			Guild="The People's Militia";
			Id = 820;
			Model = 2374;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = (int)NpcActions.Dialog ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			NpcText00="Welcome to my Inn, weary traveler. What can I do for you?";
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.ScoutRiell, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class CaptainDanuvin : BaseNPC
	{
		public CaptainDanuvin() : base()
		{
			Name = "Captain Danuvin";
			Guild="The People's Militia";
			Id = 821;
			Model = 2372;
			Level = RandomLevel(30);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 680;
 			BaseMana = 0;
 			BoundingRadius = 0.3077550f;
			CombatReach = 1.5f;
			Speed = 3.14f;
			WalkSpeed = 3.14f;
			RunSpeed = 6.14f;
			NpcFlags = (int)NpcActions.Dialog ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			NpcText00="Welcome to my Inn, weary traveler. What can I do for you?";
			Equip( new Item( 7426, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1757, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.OneHand, 2, 2, 2, 0, 0, 0, 0 ));			
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( AllianceGuardsDrops.CaptainDanuvin, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}

