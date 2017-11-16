using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
        public class UrokEnforcer : BaseCreature
        {
                public UrokEnforcer() : base()
                {
                        Name = "Urok Enforcer";
                        Id = 10601;
                        Model = 11584;
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
                        CombatReach = 19f;
                        Size = 1f;
                        Speed = 3f;
                        WalkSpeed = 3f;
                        RunSpeed = 6f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x024;
                        Elite = 1;
                        //Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0));
                        BCAddon.Hp( this, 7415, 53 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( UrokDrops.UrokEnforcer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}




namespace Server.Creatures
{
        public class UrokOgreMagus : BaseCreature
        {
                public UrokOgreMagus() : base()
                {
                        Name = "Urok Ogre Magus";
                        Id = 10602;
                        Model = 11585;
                        Level = RandomLevel(54,55);
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
                        AttackSpeed = 1000;
                        BoundingRadius = 1.0f;
                        CombatReach = 19f;
                        Size = 1f;
                        Speed = 3f;
                        WalkSpeed = 3f;
                        RunSpeed = 6f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x024;
                        Elite = 1;
                        //Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0));
                        BCAddon.Hp( this, 7955, 54 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( UrokDrops.UrokOgreMagus, 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}




namespace Server.Creatures
{
        public class UrokDoomhowl : BaseCreature
        {
                public UrokDoomhowl() : base()
                {
                        Name = "Urok Ogre Magus";
                        Id = 10584;
                        Model = 11583;
                        Level = RandomLevel(60);
                        ResistArcane = Level*2;
                        ResistFire = Level*2;
                        ResistFrost = Level*2;
                        ResistHoly = Level*2;
                        ResistNature = Level*2;
                        ResistShadow = Level*2;
                        Str = (int)(Level*5f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*31.2);
                        Block= Level;
                        SetDamage(1f+4f*Level,1f+4.5*Level);
                        ManaType=0;
                        BaseMana = 0;
                        AttackSpeed = 1000;
                        BoundingRadius = 1.0f;
                        CombatReach = 19f;
                        Size = 1f;
                        Speed = 2.2f;
                        WalkSpeed = 2.2f;
                        RunSpeed = 5.2f;
                        Faction = Factions.Monster;
                        AIEngine = new AgressiveAnimalAI( this );
                        Flags1 = 0x081000;
                        Elite = 2;
                        //Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0));
                        BCAddon.Hp( this, 12255, 60 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( UrokDrops.UrokDoomhowl, 100f )
                        ,new BaseTreasure(DropsME.MoneyElite2, 100f )};
                }
        }
}


