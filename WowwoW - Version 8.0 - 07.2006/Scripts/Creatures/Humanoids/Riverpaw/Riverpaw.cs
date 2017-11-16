using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class RiverpawRunt : BaseCreature
	{
		public RiverpawRunt() : base()
		{
			Name = "Riverpaw Runt";
			Id = 97;
			Model = 10791;
			Level = RandomLevel(8,9);
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
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 7488, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawRunt , 100f )};
			/*****************************/
			BCAddon.Hp( this, 97, 8 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawTaskmaster : BaseCreature
	{
		public RiverpawTaskmaster() : base()
		{
			Name = "Riverpaw Taskmaster";
			Id = 98;
			Model = 376;
			Level = RandomLevel(17,18);
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
			BoundingRadius = 0.420f;
			CombatReach = 1.95f;
			Size = 1.3f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawTaskmaster , 100f )};
			/*****************************/
			BCAddon.Hp( this, 368, 17 );
			/*****************************/
		}
	}
}



namespace Server.Creatures
{
	public class RiverpawGnoll : BaseCreature
	{
		public RiverpawGnoll() : base()
		{
			Name = "Riverpaw Gnoll";
			Id = 117;
			Model = 175;
			Level = RandomLevel(11,12);
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
			BoundingRadius = 0.420f;
			CombatReach = 1.5f;
			Size = 1.3f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 7488, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawGnoll , 100f )};
			/*****************************/
			BCAddon.Hp( this, 192, 11 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawMongrel : BaseCreature
	{
		public RiverpawMongrel() : base()
		{
			Name = "Riverpaw Mongrel";
			Id = 123;
			Model = 383;
			Level = RandomLevel(13,14);
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
			BoundingRadius = 0.50f;
			CombatReach = 1.725f;
			Size = 1.15f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 7;
			BaseMana = 356;
			LearnSpell( 1604, SpellsTypes.Offensive );
			LearnSpell( 8016, SpellsTypes.Offensive );			
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawMongrel , 100f )};
			/*****************************/
			BCAddon.Hp( this, 289, 13 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawBrute : BaseCreature
	{
		public RiverpawBrute() : base()
		{
			Name = "Riverpaw Brute";
			Id = 124;
			Model = 384;
			Level = RandomLevel(15,16);
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
			BoundingRadius = 0.420f;
			CombatReach = 1.7f;
			Size = 1.15f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 7;
			BaseMana = 512;
			LearnSpell( 1160, SpellsTypes.Defensive );
			Equip( new Item( 3502, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawBrute , 100f )};
			/*****************************/
			BCAddon.Hp( this, 439, 15 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawOverseer : BaseCreature
	{
		public RiverpawOverseer() : base()
		{
			Name = "Riverpaw Overseer";
			Id = 125;
			Model = 10790;
			Level = RandomLevel(19,20);
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
			BoundingRadius = 0.65f;
			CombatReach = 1.95f;
			Size = 1.3f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			Equip( new Item( 7490, InventoryTypes.TwoHanded, 2, 8, 1, 1, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawOverseer , 100f )};
			/*****************************/
			BCAddon.Hp( this, 592, 19 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawBandit : BaseCreature
	{
		public RiverpawBandit() : base()
		{
			Name = "Riverpaw Bandit";
			Id = 452;
			Model = 383;
			Level = RandomLevel(16,17);
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
			BoundingRadius = 0.5f;
			CombatReach = 1.7f;
			Size = 1.15f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawBandit , 100f )};
			/*****************************/
			BCAddon.Hp( this, 325, 16 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawMystic : BaseCreature
	{
		public RiverpawMystic() : base()
		{
			Name = "Riverpaw Mystic";
			Id = 453;
			Model = 502;
			Level = RandomLevel(18,19);
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
			BoundingRadius = 0.420f;
			CombatReach = 1.3f;
			Size = 1.3f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( LowClothsDrops.LowCloths , 100f )};
			/*****************************/
			BCAddon.Hp( this, 404, 18 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawOutrunner : BaseCreature
	{
		public RiverpawOutrunner() : base()
		{
			Name = "Riverpaw Outrunner";
			Id = 478;
			Model = 512;
			Level = RandomLevel(9,10);
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
			BoundingRadius = 0.3f;
			CombatReach = 1.2f;
			Size = 0.85f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawOutrunner , 100f )};
			/*****************************/
			BCAddon.Hp( this, 146, 9 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawScout : BaseCreature
	{
		public RiverpawScout() : base()
		{
			Name = "Riverpaw Scout";
			Id = 500;
			Model = 374;
			Level = RandomLevel(12,13);
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
			BoundingRadius = 0.5f;
			CombatReach = 1.2f;
			Size = 0.85f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 7;
			LearnSpell( 6730, SpellsTypes.Offensive );
			LearnSpell( 6016, SpellsTypes.Offensive );
			BaseMana = 299;
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ), new Item( 10671, InventoryTypes.RangeRight, 2, 18, 1, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawScout , 100f )};
			/*****************************/
			BCAddon.Hp( this, 241, 12 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawHerbalist : BaseCreature
	{
		public RiverpawHerbalist() : base()
		{
			Name = "Riverpaw Herbalist";
			Id = 501;
			Model = 374;
			Level = RandomLevel(14,15);
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
			BoundingRadius = 0.4f;
			CombatReach = 1.7f;
			Size = 1.15f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 7;
			LearnSpell( 8119, SpellsTypes.Defensive );
			BaseMana = 499;
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ), new Item( 10671, InventoryTypes.RangeRight, 2, 18, 1, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawHerbalist , 100f )};
			/*****************************/
			BCAddon.Hp( this, 302, 14 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawShaman : BaseCreature
	{
		public RiverpawShaman() : base()
		{
			Name = "Riverpaw Shaman";
			Id = 1065;
			Model = 204;
			Level = RandomLevel(12,13);
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
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			BaseMana = 0;
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawShaman , 100f )};
			/*****************************/
			BCAddon.Hp( this, 201, 12 );
			/*****************************/
		}
	}
}




namespace Server.Creatures
{
	public class RiverpawMiner : BaseCreature
	{
		public RiverpawMiner() : base()
		{
			Name = "Riverpaw Miner";
			Id = 1426;
			Model = 374;
			Level = RandomLevel(14,15);
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
			BoundingRadius = 0.5f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			NpcType = 7;
			BaseMana = 0;
			Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
						     , new BaseTreasure( RiverpawDrops.RiverpawMiner , 100f )};
			/*****************************/
			BCAddon.Hp( this, 201, 14 );
			/*****************************/
		}
public override void OnAddToWorld()
    {
    if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new GroupInteligentAI( this );
    }
								
	}
}


