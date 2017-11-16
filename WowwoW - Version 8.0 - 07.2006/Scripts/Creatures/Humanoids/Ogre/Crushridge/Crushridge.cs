using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
        public class CrushridgePlunderer : BaseCreature
        {
                public CrushridgePlunderer() : base()
                {
                        Name = "Crushridge Plunderer";
                        Id = 2416;
                        Model = 415;
                        Level = RandomLevel(36,37);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = Level;
                        ResistHoly = 0;
                        ResistNature = 0;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 0.8f;
                        CombatReach = 1.5f;
                        Size = 1.5f;
                        Speed = 2.9f;
                        WalkSpeed = 2.9f;
                        RunSpeed = 5.9f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 7478, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0));
                        BCAddon.Hp( this, 3415, 36 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( CrushridgeDrops.CrushridgePlunderer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}



namespace Server.Creatures
{
        public class CrushridgeWarmonger : BaseCreature
        {
                public CrushridgeWarmonger() : base()
                {
                        Name = "Crushridge Warmonger";
                        Id = 2287;
                        Model = 536;
                        Level = RandomLevel(39,40);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = Level;
                        ResistHoly = 0;
                        ResistNature = 0;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.5f;
                        CombatReach = 2.6f;
                        Size = 1.75f;
                        Speed = 2.8f;
                        WalkSpeed = 2.8f;
                        RunSpeed = 5.8f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0));
                        BCAddon.Hp( this, 3640, 39 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( CrushridgeDrops.CrushridgePlunderer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}



namespace Server.Creatures
{
	public class CrushridgeOgre : BaseCreature
	{
		public CrushridgeOgre() : base()
		{
			Name = "Crushridge Ogre";
			Id = 2252;
			Model = 11567;
			Level = RandomLevel(34,35);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = Level;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 1.7f;
			Size = 1.15f;
			Speed = 2.16f;
			WalkSpeed = 2.16f;
			RunSpeed = 5.16f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1184, 34 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrushridgeDrops.CrushridgePlunderer , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class CrushridgeBrute : BaseCreature
	{
		public CrushridgeBrute() : base()
		{
			Name = "Crushridge Brute";
			Id = 2253;
			Model = 610;
			Level = RandomLevel(35,36);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = Level;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 3000;			
			BoundingRadius = 1.1f;
			CombatReach = 1.9f;
			Size = 1.3f;
			Speed = 2.18f;
			WalkSpeed = 2.18f;
			RunSpeed = 5.18f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 3879, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			BCAddon.Hp( this, 1270, 35 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrushridgeDrops.CrushridgePlunderer , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}



namespace Server.Creatures
{
        public class CrushridgeMauler : BaseCreature
        {
                public CrushridgeMauler() : base()
                {
                        Name = "Crushridge Mauler";
                        Id = 2254;
                        Model = 655;
                        Level = RandomLevel(36,37);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = Level;
                        ResistHoly = 0;
                        ResistNature = 0;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.2f;
                        CombatReach = 2.1f;
                        Size = 1.45f;
                        Speed = 2.78f;
                        WalkSpeed = 2.78f;
                        RunSpeed = 5.78f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0));
                        BCAddon.Hp( this, 3035, 36 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( CrushridgeDrops.CrushridgePlunderer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}



namespace Server.Creatures
{
        public class CrushridgeMage : BaseCreature
        {
                public CrushridgeMage() : base()
                {
                        Name = "Crushridge Mage";
                        Id = 2255;
                        Model = 6705;
                        Level = RandomLevel(37,38);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = Level;
                        ResistHoly = 0;
                        ResistNature = 0;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.1f;
                        CombatReach = 1.7f;
                        Size = 1.15f;
                        Speed = 2.79f;
                        WalkSpeed = 2.79f;
                        RunSpeed = 5.79f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
                        BCAddon.Hp( this, 2739, 37 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( CrushridgeDrops.CrushridgePlunderer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}



namespace Server.Creatures
{
        public class CrushridgeEnforcer : BaseCreature
        {
                public CrushridgeEnforcer() : base()
                {
                        Name = "Crushridge Mage";
                        Id = 2256;
                        Model = 416;
                        Level = RandomLevel(38,39);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = Level;
                        ResistHoly = 0;
                        ResistNature = 0;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.4f;
                        CombatReach = 2.4f;
                        Size = 1.6f;
                        Speed = 2.8f;
                        WalkSpeed = 2.8f;
                        RunSpeed = 5.8f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 3502, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0));
                        BCAddon.Hp( this, 2425, 38 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( CrushridgeDrops.CrushridgePlunderer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}
