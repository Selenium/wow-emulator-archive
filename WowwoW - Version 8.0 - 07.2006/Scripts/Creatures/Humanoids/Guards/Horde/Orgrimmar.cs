using System;
using Server.Items;

namespace Server.Creatures
{	public class DenGrunt : BaseCreature
	{
		public DenGrunt() : base()
		{
			Name = "Den Grunt";
			Id = 5952;
			Model = Rnd.RandomIntArr( 9794, 3564);
			Level = RandomLevel(50, 55);
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
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 3797, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.DenGrunt, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1828, 50 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}

namespace Server.Creatures
{	public class StonardGrunt : BaseCreature
	{
		public StonardGrunt() : base()
		{
			Name = "Stonard Grunt";
			Id = 866;
			Model = 4503;
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
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.34f;
			WalkSpeed = 3.34f;
			RunSpeed = 6.34f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 22635, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.StonardGrunt, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1928, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class GromgolGrunt : BaseCreature
	{
		public GromgolGrunt() : base()
		{
			Name = "Grom'gol Grunt";
			Id = 1064;
			Model = 4369;
			Level = RandomLevel(55);
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
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.34f;
			WalkSpeed = 3.34f;
			RunSpeed = 6.34f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.GromgolGrunt, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1928, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class OrgrimmarGrunt : BaseCreature
	{
		public OrgrimmarGrunt() : base()
		{
			Name = "Orgrimmar Grunt";
			Id = 3296;
			Model = 4259;
			Level = RandomLevel(50,55);
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
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
LearnSpell( 11609, SpellsTypes.Defensive );
			Equip( new Item( 3797, InventoryTypes.TwoHanded, 0, 2, 1, 1, 1, 0, 0 ));//, new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			//equipmodel=0 3797 2 1 1 17 1 0 0 0
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.OrgrimmarGrunt, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1828, 50 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class GruntZuul : BaseCreature
	{
		public GruntZuul() : base()
		{
			Name = "Grunt Zuul";
			Id = 5546;
			Model = 4550;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.GruntZuul, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1928, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class GruntTharlak : BaseCreature
	{
		public GruntTharlak() : base()
		{
			Name = "Grunt Tharlak";
			Id = 5547;
			Model = 4548;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.GruntTharlak, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1928, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class GruntKomak : BaseCreature
	{
		public GruntKomak() : base()
		{
			Name = "Grunt Komak";
			Id = 5597;
			Model = 3456;
			Level = RandomLevel(38);
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
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 3385, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.GruntKomak, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1228, 38 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}

namespace Server.Creatures
{	public class GruntMojka : BaseCreature
	{
		public GruntMojka() : base()
		{
			Name = "Grunt Mojka";
			Id = 5603;
			Model = 3564;
			Level = RandomLevel(38);
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
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 3385, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.GruntMojka, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1228, 38 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class RazorHillGrunt : BaseCreature
	{
		public RazorHillGrunt() : base()
		{
			Name = "Razor Hill Grunt";
			Id = 5953;
			Model = 9798;
			Level = RandomLevel(28,32);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 50*Level;
			Block = 2*Level;
			Flags1 = 0x010480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 3797, InventoryTypes.TwoHanded, 1, 1, 2, 1 ,0 ,0 ,0));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.RazorHillGrunt, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 888, 28 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class StonetalonGrunt : BaseCreature
	{
		public StonetalonGrunt() : base()
		{
			Name = "Stonetalon Grunt";
			Id = 7730;
			Model = 9803;
			Level = RandomLevel(40);
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
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 3797, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.StonetalonGrunt, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1828, 48 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class KargathGrunt : BaseCreature
	{
		public KargathGrunt() : base()
		{
			Name = "Kargath Grunt";
			Id = 8155;
			Model = 7375;
			Level = RandomLevel(55);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010480042;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 3385, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.KargathGrunt, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
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
{	public class GruntKorja : BaseCreature
	{
		public GruntKorja() : base()
		{
			Name = "Grunt Kor'ja";
			Id = 12430;
			Model = 12477;
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
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 2.9f;
			Faction = Factions.Ogrimmar;

			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Equip( new Item( 3797, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));//, new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OgrimmarGuardsDrops.GruntKorja, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};
			/*****************************/
			BCAddon.Hp( this, 250, 7 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


