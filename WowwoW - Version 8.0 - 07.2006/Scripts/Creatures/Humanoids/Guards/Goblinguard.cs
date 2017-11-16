using System;
using Server.Items;


namespace Server.Creatures
{	public class RotHideBruiser : BaseCreature
	{
		public RotHideBruiser() : base()
		{
			Name = "Rot Hide Bruiser";
			Id = 1944;
			Model = 10850;
			Level = RandomLevel(22);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 1500;
			Armor = 80*Level;
			Block = 6*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Str = (int)(Level*1.5f);
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;

			NpcType = (int)NpcTypes.Undead;
			Size = 1f;
			Elite=4;
			//Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( GoblinGuardDrops.RotHideBruiser, 100f ),
							new BaseTreasure(DropsME.MoneyRare, 100f )};
			/*****************************/
			BCAddon.Hp( this, 597, 22 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BurningBladeBruiser : BaseCreature
	{
		public BurningBladeBruiser() : base()
		{
			Name = "Burning Blade Bruiser";
			Id = 3379;
			Model = 4198;
			Level = RandomLevel(10,11);
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
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;

			
			NpcType = (int)NpcTypes.Humanoid;
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( GoblinGuardDrops.BurningBladeBruiser, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			/*****************************/
			BCAddon.Hp( this, 186, 10 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class RatchetBruiser : BaseCreature
	{
		public RatchetBruiser() : base()
		{
			Name = "Ratchet Bruiser";
			Id = 3502;
			Model = 7060;
			Level = RandomLevel(57);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010080006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ratchet;

			
			NpcType = (int)NpcTypes.Humanoid;
			Size = 1f;
			//Elite=1;
			Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( GoblinGuardDrops.RatchetBruiser, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2186, 57 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class BootyBayBruiser : BaseCreature
	{
		public BootyBayBruiser() : base()
		{
			Name = "Booty Bay Bruiser";
			Id = 4624;
			Model = 7102;
			Level = RandomLevel(57);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010080004;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.BootyBay;
			
			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.05f;
			//Elite=1;
			Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( GoblinGuardDrops.BootyBayBruiser, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2186, 57 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class GadgetzanBruiser : BaseCreature
	{
		public GadgetzanBruiser() : base()
		{
			Name = "Gadgetzan Bruiser";
			Id = 9460;
			Model = 11376;
			Level = RandomLevel(57);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010080002;
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
			Faction = Factions.Gadgetzan;
			
			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.05f;
			//Elite=1;
			Equip( new Item( 5224, InventoryTypes.Ranged, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( GoblinGuardDrops.GadgetzanBruiser, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2186, 57 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class EverlookBruiser : BaseCreature
	{
		public EverlookBruiser() : base()
		{
			Name = "Everlook Bruiser";
			Id = 11190;
			Model = 10747;
			Level = RandomLevel(55,65);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x010080002;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Everlook;
			
			NpcType = (int)NpcTypes.Humanoid;
			Size = 1.05f;
			//Elite=1;
			Equip( new Item( 5224, InventoryTypes.Ranged, 2, 4, 2, 3, 0, 0, 0 ), new Item( 21540, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( GoblinGuardDrops.EverlookBruiser, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1886, 55 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


