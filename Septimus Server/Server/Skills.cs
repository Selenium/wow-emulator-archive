namespace Server
{
    using Server.Network;
    using System;
    using System.Reflection;

    [PropertyObject]
    public class Skills
    {
        // Methods
        public Skills(Mobile owner)
        {
            this.m_Owner = owner;
            this.m_Cap = 7000;
            SkillInfo[] infoArray1 = SkillInfo.Table;
            this.m_Skills = new Skill[infoArray1.Length];
        }

        public Skills(Mobile owner, GenericReader reader)
        {
            int num3;
            Skill skill1;
            this.m_Owner = owner;
            int num1 = reader.ReadInt();
            switch (num1)
            {
                case 0:
                {
                    reader.ReadInt();
                    goto Label_003B;
                }
                case 1:
                {
                    goto Label_003B;
                }
                case 2:
                case 3:
                {
                    goto Label_002F;
                }
            }
            return;
        Label_002F:
            this.m_Cap = reader.ReadInt();
        Label_003B:
            if (num1 < 2)
            {
                this.m_Cap = 7000;
            }
            if (num1 < 3)
            {
                reader.ReadInt();
            }
            SkillInfo[] infoArray1 = SkillInfo.Table;
            this.m_Skills = new Skill[infoArray1.Length];
            int num2 = reader.ReadInt();
            for (num3 = 0; (num3 < num2); ++num3)
            {
                if (num3 < infoArray1.Length)
                {
                    skill1 = new Skill(this, infoArray1[num3], reader);
                    if (((skill1.BaseFixedPoint != 0) || (skill1.CapFixedPoint != 1000)) || (skill1.Lock != SkillLock.Up))
                    {
                        this.m_Skills[num3] = skill1;
                        this.m_Total += skill1.BaseFixedPoint;
                    }
                }
                else
                {
                    new Skill(this, null, reader);
                }
            }
        }

        public void OnSkillChange(Skill skill)
        {
            if (skill == this.m_Highest)
            {
                this.m_Highest = null;
            }
            else if ((this.m_Highest != null) && (skill.BaseFixedPoint > this.m_Highest.BaseFixedPoint))
            {
                this.m_Highest = skill;
            }
            this.m_Owner.OnSkillInvalidated(skill);
            NetState state1 = this.m_Owner.NetState;
            if (state1 != null)
            {
                state1.Send(new SkillChange(skill));
            }
        }

        public void Serialize(GenericWriter writer)
        {
            int num1;
            Skill skill1;
            this.m_Total = 0;
            writer.Write(3);
            writer.Write(this.m_Cap);
            writer.Write(this.m_Skills.Length);
            for (num1 = 0; (num1 < this.m_Skills.Length); ++num1)
            {
                skill1 = this.m_Skills[num1];
                if (skill1 == null)
                {
                    writer.Write(((byte) 255));
                }
                else
                {
                    skill1.Serialize(writer);
                    this.m_Total += skill1.BaseFixedPoint;
                }
            }
        }

        public override string ToString()
        {
            return "...";
        }

        public static bool UseSkill(Mobile from, SkillName name)
        {
            return Skills.UseSkill(from, ((int) name));
        }

        public static bool UseSkill(Mobile from, int skillID)
        {
            SkillInfo info1;
            if (!from.CheckAlive())
            {
                return false;
            }
            if (!from.Region.OnSkillUse(from, skillID))
            {
                return false;
            }
            if (!from.AllowSkillUse(((SkillName) skillID)))
            {
                return false;
            }
            if ((skillID >= 0) && (skillID < SkillInfo.Table.Length))
            {
                info1 = SkillInfo.Table[skillID];
                if (info1.Callback != null)
                {
                    if ((from.NextSkillTime <= DateTime.Now) && (from.Spell == null))
                    {
                        from.DisruptiveAction();
                        from.NextSkillTime = (DateTime.Now + info1.Callback.Invoke(from));
                        return true;
                    }
                    from.SendSkillMessage();
                }
                else
                {
                    from.SendLocalizedMessage(500014);
                }
            }
            return false;
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor)]
        public Skill Alchemy
        {
            get
            {
                return this[SkillName.Alchemy];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Anatomy
        {
            get
            {
                return this[SkillName.Anatomy];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill AnimalLore
        {
            get
            {
                return this[SkillName.AnimalLore];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill AnimalTaming
        {
            get
            {
                return this[SkillName.AnimalTaming];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Archery
        {
            get
            {
                return this[SkillName.Archery];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill ArmsLore
        {
            get
            {
                return this[SkillName.ArmsLore];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Begging
        {
            get
            {
                return this[SkillName.Begging];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Blacksmith
        {
            get
            {
                return this[SkillName.Blacksmith];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Camping
        {
            get
            {
                return this[SkillName.Camping];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Cap
        {
            get
            {
                return this.m_Cap;
            }
            set
            {
                this.m_Cap = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Carpentry
        {
            get
            {
                return this[SkillName.Carpentry];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Cartography
        {
            get
            {
                return this[SkillName.Cartography];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Chivalry
        {
            get
            {
                return this[SkillName.Chivalry];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Cooking
        {
            get
            {
                return this[SkillName.Cooking];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill DetectHidden
        {
            get
            {
                return this[SkillName.DetectHidden];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Discordance
        {
            get
            {
                return this[SkillName.Discordance];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill EvalInt
        {
            get
            {
                return this[SkillName.EvalInt];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Fencing
        {
            get
            {
                return this[SkillName.Fencing];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Fishing
        {
            get
            {
                return this[SkillName.Fishing];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Fletching
        {
            get
            {
                return this[SkillName.Fletching];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Focus
        {
            get
            {
                return this[SkillName.Focus];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Forensics
        {
            get
            {
                return this[SkillName.Forensics];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Healing
        {
            get
            {
                return this[SkillName.Healing];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Herding
        {
            get
            {
                return this[SkillName.Herding];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Hiding
        {
            get
            {
                return this[SkillName.Hiding];
            }
            set
            {
            }
        }

        public Skill Highest
        {
            get
            {
                Skill skill1;
                int num1;
                int num2;
                Skill skill2;
                if (this.m_Highest == null)
                {
                    skill1 = null;
                    num1 = -2147483648;
                    for (num2 = 0; (num2 < this.m_Skills.Length); ++num2)
                    {
                        skill2 = this.m_Skills[num2];
                        if ((skill2 != null) && (skill2.BaseFixedPoint > num1))
                        {
                            num1 = skill2.BaseFixedPoint;
                            skill1 = skill2;
                        }
                    }
                    if ((skill1 == null) && (this.m_Skills.Length > 0))
                    {
                        skill1 = this[0];
                    }
                    this.m_Highest = skill1;
                }
                return this.m_Highest;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Inscribe
        {
            get
            {
                return this[SkillName.Inscribe];
            }
            set
            {
            }
        }

        public Skill this[int skillID]
        {
            get
            {
                if ((skillID < 0) || (skillID >= this.m_Skills.Length))
                {
                    return null;
                }
                Skill skill1 = this.m_Skills[skillID];
                if (skill1 == null)
                {
                    this.m_Skills[skillID] = (skill1 = new Skill(this, SkillInfo.Table[skillID], 0, 1000, SkillLock.Up));
                }
                return skill1;
            }
        }

        public Skill this[SkillName name]
        {
            get
            {
                return this[name];
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill ItemID
        {
            get
            {
                return this[SkillName.ItemID];
            }
            set
            {
            }
        }

        public int Length
        {
            get
            {
                return this.m_Skills.Length;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Lockpicking
        {
            get
            {
                return this[SkillName.Lockpicking];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Lumberjacking
        {
            get
            {
                return this[SkillName.Lumberjacking];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Macing
        {
            get
            {
                return this[SkillName.Macing];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Magery
        {
            get
            {
                return this[SkillName.Magery];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill MagicResist
        {
            get
            {
                return this[SkillName.MagicResist];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Meditation
        {
            get
            {
                return this[SkillName.Meditation];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Mining
        {
            get
            {
                return this[SkillName.Mining];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Musicianship
        {
            get
            {
                return this[SkillName.Musicianship];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Necromancy
        {
            get
            {
                return this[SkillName.Necromancy];
            }
            set
            {
            }
        }

        public Mobile Owner
        {
            get
            {
                return this.m_Owner;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Parry
        {
            get
            {
                return this[SkillName.Parry];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Peacemaking
        {
            get
            {
                return this[SkillName.Peacemaking];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Poisoning
        {
            get
            {
                return this[SkillName.Poisoning];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Provocation
        {
            get
            {
                return this[SkillName.Provocation];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill RemoveTrap
        {
            get
            {
                return this[SkillName.RemoveTrap];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Snooping
        {
            get
            {
                return this[SkillName.Snooping];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill SpiritSpeak
        {
            get
            {
                return this[SkillName.SpiritSpeak];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Stealing
        {
            get
            {
                return this[SkillName.Stealing];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Stealth
        {
            get
            {
                return this[SkillName.Stealth];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Swords
        {
            get
            {
                return this[SkillName.Swords];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Tactics
        {
            get
            {
                return this[SkillName.Tactics];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Tailoring
        {
            get
            {
                return this[SkillName.Tailoring];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill TasteID
        {
            get
            {
                return this[SkillName.TasteID];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Tinkering
        {
            get
            {
                return this[SkillName.Tinkering];
            }
            set
            {
            }
        }

        public int Total
        {
            get
            {
                return this.m_Total;
            }
            set
            {
                this.m_Total = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Tracking
        {
            get
            {
                return this[SkillName.Tracking];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Veterinary
        {
            get
            {
                return this[SkillName.Veterinary];
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skill Wrestling
        {
            get
            {
                return this[SkillName.Wrestling];
            }
            set
            {
            }
        }


        // Fields
        private int m_Cap;
        private Skill m_Highest;
        private Mobile m_Owner;
        private Skill[] m_Skills;
        private int m_Total;
    }
}

