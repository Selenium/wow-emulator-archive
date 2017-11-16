namespace Server
{
    using System;
    using System.Collections;

    [PropertyObject]
    public class Skill
    {
        // Methods
        public Skill(Skills owner, SkillInfo info, GenericReader reader)
        {
            this.m_Owner = owner;
            this.m_Info = info;
            int num1 = reader.ReadByte();
            int num2 = num1;
            if (num2 != 0)
            {
                if (num2 == 255)
                {
                    goto Label_0050;
                }
                goto Label_006A;
            }
            this.m_Base = reader.ReadUShort();
            this.m_Cap = reader.ReadUShort();
            this.m_Lock = ((SkillLock) reader.ReadByte());
            return;
        Label_0050:
            this.m_Base = 0;
            this.m_Cap = 1000;
            this.m_Lock = SkillLock.Up;
            return;
        Label_006A:
            if ((num1 & 192) != 0)
            {
                return;
            }
            if ((num1 & 1) != 0)
            {
                this.m_Base = reader.ReadUShort();
            }
            if ((num1 & 2) != 0)
            {
                this.m_Cap = reader.ReadUShort();
            }
            else
            {
                this.m_Cap = 1000;
            }
            if ((num1 & 4) != 0)
            {
                this.m_Lock = ((SkillLock) reader.ReadByte());
            }
        }

        public Skill(Skills owner, SkillInfo info, int baseValue, int cap, SkillLock skillLock)
        {
            this.m_Owner = owner;
            this.m_Info = info;
            this.m_Base = ((ushort) baseValue);
            this.m_Cap = ((ushort) cap);
            this.m_Lock = skillLock;
        }

        public void Serialize(GenericWriter writer)
        {
            if (((this.m_Base == 0) && (this.m_Cap == 1000)) && (this.m_Lock == SkillLock.Up))
            {
                writer.Write(((byte) 255));
                return;
            }
            int num1 = 0;
            if (this.m_Base != 0)
            {
                num1 |= 1;
            }
            if (this.m_Cap != 1000)
            {
                num1 |= 2;
            }
            if (this.m_Lock != SkillLock.Up)
            {
                num1 |= 4;
            }
            writer.Write(((byte) num1));
            if (this.m_Base != 0)
            {
                writer.Write(((short) this.m_Base));
            }
            if (this.m_Cap != 1000)
            {
                writer.Write(((short) this.m_Cap));
            }
            if (this.m_Lock != SkillLock.Up)
            {
                writer.Write(((byte) this.m_Lock));
            }
        }

        public void SetLockNoRelay(SkillLock skillLock)
        {
            this.m_Lock = skillLock;
        }

        public override string ToString()
        {
            return string.Format("[{0}: {1}]", this.Name, this.Base);
        }

        public void Update()
        {
            this.m_Owner.OnSkillChange(this);
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public double Base
        {
            get
            {
                return (this.m_Base / 10);
            }
            set
            {
                this.BaseFixedPoint = ((int) (value * 10));
            }
        }

        public int BaseFixedPoint
        {
            get
            {
                return this.m_Base;
            }
            set
            {
                Mobile mobile1;
                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= 65536)
                {
                    value = 65535;
                }
                ushort num1 = ((ushort) value);
                int num2 = this.m_Base;
                if (this.m_Base != num1)
                {
                    this.m_Owner.Total = ((this.m_Owner.Total - this.m_Base) + num1);
                    this.m_Base = num1;
                    this.m_Owner.OnSkillChange(this);
                    mobile1 = this.m_Owner.Owner;
                    if (mobile1 != null)
                    {
                        mobile1.OnSkillChange(this.SkillName, (num2 / 10));
                    }
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public double Cap
        {
            get
            {
                return (this.m_Cap / 10);
            }
            set
            {
                this.CapFixedPoint = ((int) (value * 10));
            }
        }

        public int CapFixedPoint
        {
            get
            {
                return this.m_Cap;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= 65536)
                {
                    value = 65535;
                }
                ushort num1 = ((ushort) value);
                if (this.m_Cap != num1)
                {
                    this.m_Cap = num1;
                    this.m_Owner.OnSkillChange(this);
                }
            }
        }

        public int Fixed
        {
            get
            {
                return ((int) (this.Value * 10));
            }
        }

        public SkillInfo Info
        {
            get
            {
                return this.m_Info;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public SkillLock Lock
        {
            get
            {
                return this.m_Lock;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public string Name
        {
            get
            {
                return this.m_Info.Name;
            }
        }

        public Skills Owner
        {
            get
            {
                return this.m_Owner;
            }
        }

        public int SkillID
        {
            get
            {
                return this.m_Info.SkillID;
            }
        }

        public SkillName SkillName
        {
            get
            {
                return ((SkillName) this.m_Info.SkillID);
            }
        }

        public static bool UseStatMods
        {
            get
            {
                return Skill.m_UseStatMods;
            }
            set
            {
                Skill.m_UseStatMods = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public double Value
        {
            get
            {
                int num8;
                SkillMod mod1;
                double num1 = this.Base;
                double num2 = (100 - num1);
                if (num2 < 0)
                {
                    num2 = 0;
                }
                num2 /= 100;
                double num3 = ((((Skill.m_UseStatMods ? this.m_Owner.Owner.Str : this.m_Owner.Owner.RawStr) * this.m_Info.StrScale) + ((Skill.m_UseStatMods ? this.m_Owner.Owner.Dex : this.m_Owner.Owner.RawDex) * this.m_Info.DexScale)) + ((Skill.m_UseStatMods ? this.m_Owner.Owner.Int : this.m_Owner.Owner.RawInt) * this.m_Info.IntScale));
                double num4 = (this.m_Info.StatTotal * num2);
                num3 *= num2;
                if (num3 > num4)
                {
                    num3 = num4;
                }
                double num5 = (num1 + num3);
                this.m_Owner.Owner.ValidateSkillMods();
                ArrayList list1 = this.m_Owner.Owner.SkillMods;
                double num6 = 0;
                double num7 = 0;
                for (num8 = 0; (num8 < list1.Count); ++num8)
                {
                    mod1 = ((SkillMod) list1[num8]);
                    if (mod1.Skill == this.m_Info.SkillID)
                    {
                        if (mod1.Relative)
                        {
                            if (mod1.ObeyCap)
                            {
                                num6 += mod1.Value;
                            }
                            else
                            {
                                num7 += mod1.Value;
                            }
                        }
                        else
                        {
                            num6 = 0;
                            num7 = 0;
                            num5 = mod1.Value;
                        }
                    }
                }
                num5 += num7;
                if (num5 < this.Cap)
                {
                    num5 += num6;
                    if (num5 > this.Cap)
                    {
                        num5 = this.Cap;
                    }
                }
                return num5;
            }
        }


        // Fields
        private ushort m_Base;
        private ushort m_Cap;
        private SkillInfo m_Info;
        private SkillLock m_Lock;
        private Skills m_Owner;
        private static bool m_UseStatMods;
    }
}

