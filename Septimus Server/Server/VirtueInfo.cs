namespace Server
{
    using System;

    [PropertyObject]
    public class VirtueInfo
    {
        // Methods
        public VirtueInfo()
        {
        }

        public VirtueInfo(GenericReader reader)
        {
            int num3;
            int num4 = reader.ReadByte();
            if (num4 != 0)
            {
                return;
            }
            int num2 = reader.ReadByte();
            if (num2 == 0)
            {
                return;
            }
            this.m_Values = new int[8];
            for (num3 = 0; (num3 < 8); ++num3)
            {
                if ((num2 & (1 << (num3 & 31))) != 0)
                {
                    this.m_Values[num3] = reader.ReadInt();
                }
            }
        }

        public int GetValue(int index)
        {
            if (this.m_Values == null)
            {
                return 0;
            }
            return this.m_Values[index];
        }

        public static void Serialize(GenericWriter writer, VirtueInfo info)
        {
            int num2;
            int num3;
            writer.Write(((byte) 0));
            if (info.m_Values == null)
            {
                writer.Write(((byte) 0));
                return;
            }
            int num1 = 0;
            for (num2 = 0; (num2 < 8); ++num2)
            {
                if (info.m_Values[num2] != 0)
                {
                    num1 |= (1 << (num2 & 31));
                }
            }
            writer.Write(((byte) num1));
            for (num3 = 0; (num3 < 8); ++num3)
            {
                if (info.m_Values[num3] != 0)
                {
                    writer.Write(info.m_Values[num3]);
                }
            }
        }

        public void SetValue(int index, int value)
        {
            if (this.m_Values == null)
            {
                this.m_Values = new int[8];
            }
            this.m_Values[index] = value;
        }

        public override string ToString()
        {
            return "...";
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Compassion
        {
            get
            {
                return this.GetValue(2);
            }
            set
            {
                this.SetValue(2, value);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Honesty
        {
            get
            {
                return this.GetValue(7);
            }
            set
            {
                this.SetValue(7, value);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Honor
        {
            get
            {
                return this.GetValue(5);
            }
            set
            {
                this.SetValue(5, value);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Humility
        {
            get
            {
                return this.GetValue(0);
            }
            set
            {
                this.SetValue(0, value);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Justice
        {
            get
            {
                return this.GetValue(6);
            }
            set
            {
                this.SetValue(6, value);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Sacrifice
        {
            get
            {
                return this.GetValue(1);
            }
            set
            {
                this.SetValue(1, value);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Spirituality
        {
            get
            {
                return this.GetValue(3);
            }
            set
            {
                this.SetValue(3, value);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Valor
        {
            get
            {
                return this.GetValue(4);
            }
            set
            {
                this.SetValue(4, value);
            }
        }

        public int[] Values
        {
            get
            {
                return this.m_Values;
            }
        }


        // Fields
        private int[] m_Values;
    }
}

