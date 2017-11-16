using System;
using Server.Items;

namespace Server.Creatures
{
	public class GravelsnoutKobold: BaseCreature
	{
		public GravelsnoutKobold() : base()
		{
			Name = "Gravelsnout Kobold";
			Id =4111;
			Model = 2153;
			Level = RandomLevel(25,27);
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			AttackSpeed = 2000;
			Armor = 25*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =0;
			BoundingRadius = 0.66f;
			CombatReach = 0.12f;
			Speed = 5f;
			Size=1.3f;
			Speed=5.5f;
			WalkSpeed = 5.5f;
			RunSpeed = 7.3f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			NpcType = 7;
			/*****************************/
			BCAddon.Hp( this, 700, 25 );
			/*****************************/
			Equip( new Item( 7478, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyC , 100f )
										, new BaseTreasure( GravelsnoutDrops.GravelsnoutKobold, 100f )
										};				
		}
	}
}

namespace Server.Creatures
{
	public class GravelsnoutVermin: BaseCreature
	{
		public GravelsnoutVermin() : base()
		{
			Name = "Gravelsnout Vermin";
			Id =4112;
			Model = 373;
			Level = RandomLevel(23,26);
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			AttackSpeed = 2000;
			Armor = 25*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =0;
			BoundingRadius = 0.75f;
			CombatReach = 0.12f;
			Speed = 5.5f;
			Size=1.15f;
			WalkSpeed = 5.5f;
			RunSpeed = 7.5f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			NpcType = 7;
			/*****************************/
			BCAddon.Hp( this, 537, 23 );
			/*****************************/
			Equip( new Item( 7434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ) );			
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyC , 100f )
										, new BaseTreasure( GravelsnoutDrops.GravelsnoutVermin, 100f )
										};				
		}
	}
}

namespace Server.Creatures
{
	public class GravelsnoutDigger: BaseCreature
	{
		public GravelsnoutDigger() : base()
		{
			Name = "Gravelsnout Digger";
			Id =4113;
			Model = 511;
			Level = RandomLevel(28,29);
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			AttackSpeed = 2000;
			Armor = 25*Level;
			Block = 3;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =0;
			BoundingRadius = 0.99f;
			CombatReach = 0.2f;
			Speed = 5.7f;
			Size=1.5f;
			WalkSpeed = 5.7f;
			RunSpeed = 7.7f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			NpcType = 7;			
			/*****************************/
			BCAddon.Hp( this, 1024, 28 );
			/*****************************/
			Equip( new Item( 7495, InventoryTypes.TwoHanded, 6, 1, 17, 2, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyC , 100f )
										, new BaseTreasure( GravelsnoutDrops.GravelsnoutDigger, 100f )
										};				
		}
	}
}

namespace Server.Creatures
{
	public class GravelsnoutForager: BaseCreature
	{
		public GravelsnoutForager() : base()
		{
			Name = "Gravelsnout Forager";
			Id =4114;
			Model = 2299;
			Level = RandomLevel(27,28);
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			AttackSpeed = 2000-(Level-1)*13;
			Armor = Level;
			Block = 3;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =0;
			BaseHitPoints = 100+18*Level;
			BoundingRadius = 0.759f;
			CombatReach = 0.2f;
			Speed = 5.7f;
			Size=1.15f;
			WalkSpeed = 5.7f;
			RunSpeed = 7.7f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			NpcType = 7;			
			/*****************************/
			BCAddon.Hp( this, 586, 27 );
			/*****************************/
			Equip( new Item( 10815, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyC , 100f )
										, new BaseTreasure( GravelsnoutDrops.GravelsnoutForager, 100f )
										};				
		}
	}
}

namespace Server.Creatures
{
	public class GravelsnoutSurveyor: BaseCreature
	{
		public GravelsnoutSurveyor() : base()
		{
			Name = "Gravelsnout Surveyor";
			Id =4116;
			Model = 774;
			Level = RandomLevel(29,30);
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			AttackSpeed = 2000;
			Armor = Level;
			Block = 3;
			ResistArcane = 0;
			ResistFire = 3*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana =0;
			BoundingRadius = 0.858f;
			CombatReach = 0.2f;
			Speed = 2.7f;
			Size=1.3f;
			WalkSpeed = 2.7f;
			RunSpeed = 4.7f;
			Faction = Factions.Monster;
			AIEngine = new PredatorAI( this );
			NpcType = 7;			
			/*****************************/
			BCAddon.Hp( this, 738, 29 );
			/*****************************/
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.MoneyC , 100f )
										, new BaseTreasure( GravelsnoutDrops.GravelsnoutSurveyor, 100f )
										};				
		}
	}
}

