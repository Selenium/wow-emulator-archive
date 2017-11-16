using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
        public class MogroshMystic : BaseCreature
        {
                public MogroshMystic() : base()
                {
                        Name = "Mo'grosh Mystic";
                        Id = 1183;
                        Model = 1052;
                        Level = RandomLevel(19,20);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = 0;
                        ResistHoly = 0;
                        ResistNature = Level;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 1200+Level;
                        AttackSpeed = 2000;
                        BoundingRadius = 1.0f;
                        CombatReach = 1.7f;
                        Size = 1.15f;
                        Speed = 2.9f;
                        WalkSpeed = 2.9f;
                        RunSpeed = 5.9f;
                        Faction = Factions.Monster;
                        AIEngine = new HealerAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        LearnSpell( 529, SpellsTypes.Offensive );
                        LearnSpell( 331, SpellsTypes.Healing );
                        Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
                        BCAddon.Hp( this, 976, 19 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( MogroshDrops.MogroshMystic , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}




namespace Server.Creatures
{
        public class MogroshOgre : BaseCreature
        {
                public MogroshOgre() : base()
                {
                        Name = "Mo'grosh Ogre";
                        Id = 1178;
                        Model = 1122;
                        Level = RandomLevel(18,19);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = 0;
                        ResistHoly = 0;
                        ResistNature = Level;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 1200+Level;
                        AttackSpeed = 2000;
                        BoundingRadius = 0.9f;
                        CombatReach = 1.6f;
                        Size = 1.1f;
                        Speed = 2.5f;
                        WalkSpeed = 2.5f;
                        RunSpeed = 5.5f;
                        Faction = Factions.Monster;
                        AIEngine = new PatrolAI( this );
                        Flags1 = 0x020;
                        Elite = 1;
                        LearnSpell( 5164, SpellsTypes.Offensive );
                        LearnSpell( 3229, SpellsTypes.Defensive );
                        Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0));
                        BCAddon.Hp( this, 1272, 18 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( MogroshDrops.MogroshOgre , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}




namespace Server.Creatures
{
        public class MogroshEnforcer : BaseCreature
        {
                public MogroshEnforcer() : base()
                {
                        Name = "Mo'grosh Enforcer";
                        Id = 1179;
                        Model = 6692;
                        Level = RandomLevel(18,19);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = 0;
                        ResistHoly = 0;
                        ResistNature = Level;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 1200+Level;
                        AttackSpeed = 2000;
                        BoundingRadius = 0.7f;
                        CombatReach = 1.2f;
                        Size = 0.85f;
                        Speed = 2.6f;
                        WalkSpeed = 2.6f;
                        RunSpeed = 5.6f;
                        Faction = Factions.Monster;
                        AIEngine = new PatrolAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0));
                        BCAddon.Hp( this, 1410, 18 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( MogroshDrops.MogroshEnforcer , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}




namespace Server.Creatures
{
        public class MogroshBrute : BaseCreature
        {
                public MogroshBrute() : base()
                {
                        Name = "Mo'grosh Brute";
                        Id = 1180;
                        Model = 14403;
                        Level = RandomLevel(19,20);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = 0;
                        ResistHoly = 0;
                        ResistNature = Level;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=1;
                        BaseMana = 100;
                        AttackSpeed = 3000;
                        BoundingRadius = 1f;
                        CombatReach = 1.7f;
                        Size = 1.15f;
                        Speed = 2.5f;
                        WalkSpeed = 2.5f;
                        RunSpeed = 5.5f;
                        Faction = Factions.Monster;
                        AIEngine = new PatrolAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        LearnSpell( 6190, SpellsTypes.Defensive );
                        LearnSpell( 8198, SpellsTypes.Defensive );
                        Equip( new Item ( 3502, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0));
                        BCAddon.Hp( this, 1463, 19 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( MogroshDrops.MogroshBrute , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}




namespace Server.Creatures
{
        public class MogroshShaman : BaseCreature
        {
                public MogroshShaman() : base()
                {
                        Name = "Mo'grosh Shaman";
                        Id = 1181;
                        Model = 1045;
                        Level = RandomLevel(18,19);
                        ResistArcane = 0;
                        ResistFire = 0;
                        ResistFrost = 0;
                        ResistHoly = 0;
                        ResistNature = Level;
                        ResistShadow = 0;
                        Str = (int)(Level*4.85f);
                        NpcType = (int)NpcTypes.Humanoid ;
                        Armor = (int)(Level*29.2);
                        Block= Level;
                        SetDamage(1f+3.5f*Level,1f+4.0*Level);
                        ManaType=0;
                        BaseMana = 333;
                        AttackSpeed = 2000;
                        BoundingRadius = 0.8f;
                        CombatReach = 1.5f;
                        Size = 1.15f;
                        Speed = 2.5f;
                        WalkSpeed = 2.5f;
                        RunSpeed = 5.5f;
                        Faction = Factions.Monster;
                        AIEngine = new PatrolAI( this );
                        Flags1 = 0x080000;
                        Elite = 1;
                        LearnSpell( 529, SpellsTypes.Defensive );
                        Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
                        BCAddon.Hp( this, 1191, 18 );
                        Loots = new BaseTreasure[]{  new BaseTreasure( MogroshDrops.MogroshShaman , 100f )
                        ,new BaseTreasure(DropsME.MoneyElite1, 100f )};
                }
        }
}


