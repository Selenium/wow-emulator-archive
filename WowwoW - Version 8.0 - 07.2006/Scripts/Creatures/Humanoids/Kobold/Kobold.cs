//	Script accepted by DrNexus - 13/05/05 21:47:17
//	Script made by Nivelo - 12/05/05 17:29:54
// Few kobolds with complete loot
// Dynamic parameters set value=base+on_level*Level
// Note to DrNexus... Beasts DO drop money and armor... just look at wow.allakhazam.com
// Another note...  You CAN get Leather OR Ruined Leather Scraps from beasts... it all depends on your leatherworking skill and luck (if we are talking about official servers, maybe you want it different way)

using System;
using Server.Items;
using HelperTools;


////////////////////// Kobold.cs
namespace Server.Creatures
{
	public class KoboldVermin : BaseCreature
	{
		public KoboldVermin() : base()
		{
			Name = "Kobold Vermin";
			Id = 6;
			Model = 10913;
			Level = RandomLevel(1,2);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 1*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana = 0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 0.7f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.NoFaction;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
//equipmodel=0 5010 2 10 2 17 2 0 0 0			
//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 5010, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.KoboldVermin , 100f )
										};
			/*****************************/
			BCAddon.Hp( this, 26, 1 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class KoboldWorker : BaseCreature
	{
		public KoboldWorker() : base()
		{
			Name = "Kobold Worker";
			Id = 257;
			Model = 10912;
			Level = RandomLevel(3,4);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 0.85f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 7f;
			Str = (int)(Level/2.5f);
			Faction = Factions.NoFaction;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 			
			Equip( new Item( 7440, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.KoboldWorker , 100f )
										};
			/*****************************/
			BCAddon.Hp( this, 46, 3 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class KoboldTunneler : BaseCreature
	{
		public KoboldTunneler() : base()
		{
			Name = "Kobold Tunneler";
			Id = 475;
			Model = 139;
			Level = RandomLevel(5,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana = 0;
			BoundingRadius = 0.660000f;
			CombatReach = 0.12f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Equip( new Item( 7440, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.KoboldTunneler , 100f )
										};
			/*****************************/
			BCAddon.Hp( this, 130, 5 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class KoboldMiner : BaseCreature
	{
		public KoboldMiner() : base()
		{
			Name = "Kobold Miner";
			Id = 40;
			Model = 373;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseHitPoints = 8+12*Level;
			BaseMana =0;
			BoundingRadius = 0.759000f;
			CombatReach = 0.12f;
			Size = 1.15f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 7f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Equip( new Item( 7493, InventoryTypes.OneHand,  0, 1, 13, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.KoboldMiner , 100f )
										};
			/*****************************/
			BCAddon.Hp( this, 80, 6 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class KoboldLaborer : BaseCreature
	{
		public KoboldLaborer() : base()
		{
			Id = 80;
			Level = RandomLevel( 3, 4 );
			RunSpeed = 7f;
			WalkSpeed = 3f;
			AttackSpeed = 2000;
			Armor = 1*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;			
			AIEngine = new PatrolAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana =0;
			BaseHitPoints = 16+4*Level;
			BoundingRadius = 0.726000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			NpcType = 7;
			Model = 365;
			NpcFlags = 0;
			Name = "Kobold Laborer";
			CombatReach = 0.12f;
			Unk3 = 7;
			Size=0.85f;
			Str = (int)(Level/2.5f);
			AIEngine = new PatrolAI( this );
			Faction = Factions.NoFaction;
			Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.KoboldLaborer , 100f )
										};
			/*****************************/
			BCAddon.Hp( this, 28, 3 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class KoboldGeomancer : BaseCreature
	{
		public KoboldGeomancer() : base()
		{
			Name = "Kobold Geomancer";
			Id = 476;
			Model = 163;
			Level = RandomLevel(7,8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 10*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =250+10*Level;
			BoundingRadius = 0.726000f;
			CombatReach = 0.25f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Str = (int)(Level/2.5f);
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) );
			LearnSpell( 143, SpellsTypes.Offensive );	
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.KoboldGeomancer, 100f )
										};			
			/*****************************/
			BCAddon.Hp( this, 117, 7 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class KoboldDigger : BaseCreature
	{
		public KoboldDigger() : base()
		{
			Name = "Kobold Digger";
			Id = 1236;
			Model = 373;
			Level = RandomLevel(12,13);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 25*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 1*Level;
			BaseMana =0;
			BoundingRadius = 0.66f;
			CombatReach = 0.15f;
			Speed = 5f;
			Size=1.15f;
			WalkSpeed = 5f;
			RunSpeed = 7f;
			Str = (int)(Level/2.5f);
			Faction = Factions.NoFaction;
			NpcText="Best deals in all of Stormwind my friend, won't find any better. Now, what can I help you with?" ;
			Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ) );			
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.KoboldDigger, 100f )
										};	
			/*****************************/
			BCAddon.Hp( this, 252, 12 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class TunnelRatKobold: BaseCreature
	{
		public TunnelRatKobold() : base()
		{
			Name = "Tunnel Rat Kobold";
			Id =1202;
			Model = 2153;
			Level = RandomLevel(11,12);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 2*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =0;
			BaseHitPoints = 35+15*Level;
			BoundingRadius = 0.66f;
			CombatReach = 0.12f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 5f;
			Str = (int)(Level/2.5f);
			Faction = Factions.NoFaction;
			AIEngine = new PatrolAI( this );
			Equip( new Item( 7428, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ) );						
			NpcText = "I hope that your interruption is for a good cause, I was in the middle of some important work. ";
			NpcType = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.TunnelRatKobold, 100f )
										};				
			/*****************************/
			BCAddon.Hp( this, 200, 11 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class Goldtooth : BaseCreature
	{
		public Goldtooth() : base()
		{
			Name = "Goldtooth";
			Id = 327;
			Model = 2299;
			Level = RandomLevel(8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 10*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			Size = 1.15f;
			BaseMana =250+10*Level;
			BoundingRadius = 0.726000f;
			CombatReach = 0.25f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			NpcType = 7;
			Str = (int)(Level/2.5f);
			Equip( new Item( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0 ) );
			LearnSpell( 143, SpellsTypes.Offensive );	
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyA , 100f )
										, new BaseTreasure( KoboldDrops.Goldtooth, 100f )
										};			
			/*****************************/
			BCAddon.Hp( this, 140, 8 );
			/*****************************/
		}
	}
}
