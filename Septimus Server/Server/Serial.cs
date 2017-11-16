namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Serial : IComparable
    {
        // Methods
        static Serial()
        {
            Serial.m_LastMobile = Serial.Zero;
            Serial.m_LastItem = Serial.op_Implicit(1073741824);
            Serial.MinusOne = new Serial(-1);
            Serial.Zero = new Serial(0);
        }

        private Serial(int serial)
        {
            this.m_Serial = serial;
        }

        public int CompareTo(object o)
        {
            if (o == null)
            {
                return 1;
            }
            if (!(o is Serial))
            {
                throw new ArgumentException();
            }
            Serial serial1 = ((Serial) o);
            int num1 = serial1.m_Serial;
            if (this.m_Serial > num1)
            {
                return 1;
            }
            if (this.m_Serial < num1)
            {
                return -1;
            }
            return 0;
        }

        public override bool Equals(object o)
        {
            if ((o == null) || !(o is Serial))
            {
                return false;
            }
            Serial serial1 = ((Serial) o);
            return (serial1.m_Serial == this.m_Serial);
        }

        public override int GetHashCode()
        {
            return this.m_Serial;
        }

        public static bool operator ==(Serial l, Serial r)
        {
            return (l.m_Serial == r.m_Serial);
        }

        public static bool operator >(Serial l, Serial r)
        {
            return (l.m_Serial > r.m_Serial);
        }

        public static bool operator >=(Serial l, Serial r)
        {
            return (l.m_Serial >= r.m_Serial);
        }

        public static implicit operator int(Serial a)
        {
            return a.m_Serial;
        }

        public static implicit operator Serial(int a)
        {
            return new Serial(a);
        }

        public static bool operator !=(Serial l, Serial r)
        {
            return (l.m_Serial != r.m_Serial);
        }

        public static bool operator <(Serial l, Serial r)
        {
            return (l.m_Serial < r.m_Serial);
        }

        public static bool operator <=(Serial l, Serial r)
        {
            return (l.m_Serial <= r.m_Serial);
        }

        public override string ToString()
        {
            return string.Format("0x{0:X8}", this.m_Serial);
        }


        // Properties
        public bool IsItem
        {
            get
            {
                if (this.m_Serial >= 1073741824)
                {
                    return (this.m_Serial <= 2147483647);
                }
                return false;
            }
        }

        public bool IsMobile
        {
            get
            {
                if (this.m_Serial > 0)
                {
                    return (this.m_Serial < 1073741824);
                }
                return false;
            }
        }

        public bool IsValid
        {
            get
            {
                return (this.m_Serial > 0);
            }
        }

        public static Serial NewItem
        {
            get
            {
                while ((World.FindItem((Serial.m_LastItem = Serial.op_Implicit(((int) (Serial.op_Implicit(Serial.m_LastItem) + 1))))) != null))
                {
                }
                return Serial.m_LastItem;
            }
        }

        public static Serial NewMobile
        {
            get
            {
                while ((World.FindMobile((Serial.m_LastMobile = Serial.op_Implicit(((int) (Serial.op_Implicit(Serial.m_LastMobile) + 1))))) != null))
                {
                }
                return Serial.m_LastMobile;
            }
        }

        public int Value
        {
            get
            {
                return this.m_Serial;
            }
        }


        // Fields
        private static Serial m_LastItem;
        private static Serial m_LastMobile;
        private int m_Serial;
        public static readonly Serial MinusOne;
        public static readonly Serial Zero;
    }
}

