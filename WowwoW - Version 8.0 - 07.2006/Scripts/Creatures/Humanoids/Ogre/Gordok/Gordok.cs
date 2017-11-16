using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
        public class GordokEnforcer : BaseCreature
        {
                public GordokEnforcer() : base()
                {
                        Name = "Gordok Enforcer";
                        Id = 11440;
                        Model = 12471;
                        Level = RandomLevel(53,54);
                        ResistArcane = Level;
                        ResistFire = Level;
                        ResistFrost = Level;
                        ResistHoly = Level;
                        ResistNature = Level;
                        ResistShadow = Level;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.9f;
                        CombatReach = 3.3f;
                        Size = 2.2f;
                        Speed = 2.9f;
                        WalkSpeed = 2.9f;
                        RunSpeed = 5.9f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0));
                        BCAddon.Hp( this, 7415, 53 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( GordokDrops.GordokEnforcer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}




namespace Server.Creatures
{
        public class GordokBrute : BaseCreature
        {
                public GordokBrute() : base()
                {
                        Name = "Gordok Brute";
                        Id = 11441;
                        Model = 12473;
                        Level = RandomLevel(52,58);
                        ResistArcane = Level;
                        ResistFire = Level;
                        ResistFrost = Level;
                        ResistHoly = Level;
                        ResistNature = Level;
                        ResistShadow = Level;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.0f;
                        CombatReach = 3.3f;
                        Size = 1.5f;
                        Speed = 2.5f;
                        WalkSpeed = 2.5f;
                        RunSpeed = 5.5f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        //Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0));
                        BCAddon.Hp( this, 7415, 52 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( GordokDrops.GordokBrute , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}



namespace Server.Creatures
{
        public class GordokMauler : BaseCreature
        {
                public GordokMauler() : base()
                {
                        Name = "Gordok Mauler";
                        Id = 11442;
                        Model = 12473;
                        Level = RandomLevel(53,54);
                        ResistArcane = Level;
                        ResistFire = Level;
                        ResistFrost = Level;
                        ResistHoly = Level;
                        ResistNature = Level;
                        ResistShadow = Level;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.0f;
                        CombatReach = 3.3f;
                        Size = 2.2f;
                        Speed = 2.9f;
                        WalkSpeed = 2.9f;
                        RunSpeed = 5.9f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        //Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0));
                        BCAddon.Hp( this, 7415, 53 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( GordokDrops.GordokMauler , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}



namespace Server.Creatures
{
        public class GordokOgreMage : BaseCreature
        {
                public GordokOgreMage() : base()
                {
                        Name = "Gordok Ogre-Mage";
                        Id = 11443;
                        Model = 12472;
                        Level = RandomLevel(52,53);
                        ResistArcane = Level;
                        ResistFire = Level;
                        ResistFrost = Level;
                        ResistHoly = Level;
                        ResistNature = Level;
                        ResistShadow = Level;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.0f;
                        CombatReach = 3.3f;
                        Size = 2.2f;
                        Speed = 2.9f;
                        WalkSpeed = 2.9f;
                        RunSpeed = 5.9f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 2388, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
                        BCAddon.Hp( this, 6061, 52 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( GordokDrops.GordokOgreMage , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}



namespace Server.Creatures
{
        public class GordokMageLord : BaseCreature
        {
                public GordokMageLord() : base()
                {
                        Name = "Gordok Mage-Lord";
                        Id = 11444;
                        Model = 11537;
                        Level = RandomLevel(58);
                        ResistArcane = Level;
                        ResistFire = Level;
                        ResistFrost = Level;
                        ResistHoly = Level;
                        ResistNature = Level;
                        ResistShadow = Level;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.0f;
                        CombatReach = 3.3f;
                        Size = 2.2f;
                        Speed = 2.9f;
                        WalkSpeed = 2.9f;
                        RunSpeed = 5.9f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                       // Equip( new Item ( 2388, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
                        BCAddon.Hp( this, 8061, 58 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( GordokDrops.GordokMageLord , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}


