using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class HillsbradPeasant : BaseCreature
	{
		public HillsbradPeasant() : base()
		{
			Name = "Hillsbrad Peasant";
			Id = 2267;
			Model = 11035;
			Level = RandomLevel(24,25);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x080000;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 1f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 487, 24 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeasantDrops.HillsbradPeasant , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};

		}
	}
} 



namespace Server.Creatures
{
	public class ShadowforgePeasant : BaseCreature
	{
		public ShadowforgePeasant() : base()
		{
			Name = "Shadowforge Peasant";
			Id = 8896;
			Model = 8793;
			Level = RandomLevel(52,54);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x080000;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 0.37f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 397, 52 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeasantDrops.ShadowforgePeasant , 100f )
						, new BaseTreasure( Drops.MoneyD , 100f )};

		}
	}
} 



namespace Server.Creatures
{
	public class NorthshirePeasant : BaseCreature
	{
		public NorthshirePeasant() : base()
		{
			Name = "Northshire Peasant";
			Id = 11260;
			Model = 11354;
			Level = RandomLevel(1);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x08080026;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 60, 1 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeasantDrops.NorthshirePeasant , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};

		}
	}
}




namespace Server.Creatures
{
	public class EastvalePeasant : BaseCreature
	{
		public EastvalePeasant() : base()
		{
			Name = "Eastvale Peasant";
			Id = 11328;
			Model = 310;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x08480000;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 101, 6 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeasantDrops.EastvalePeasant , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};

		}
	}
}


