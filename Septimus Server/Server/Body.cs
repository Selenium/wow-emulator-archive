namespace Server
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Body
    {
        // Methods
        static Body()
        {
            int num1;
            if (File.Exists("Data/Binary/BodyTypes.bin"))
            {
                using (BinaryReader reader1 = new BinaryReader(new FileStream("Data/Binary/BodyTypes.bin", FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    Body.m_Types = new BodyType[((int) reader1.BaseStream.Length)];
                    for (num1 = 0; (num1 < Body.m_Types.Length); ++num1)
                    {
                        Body.m_Types[num1] = ((BodyType) reader1.ReadByte());
                    }
                    return;
                }
            }
            Console.WriteLine("Warning: Data/Binary/BodyTypes.bin does not exist");
            Body.m_Types = new BodyType[0];
        }

        public Body(int bodyID)
        {
            this.m_BodyID = bodyID;
        }

        public override bool Equals(object o)
        {
            if ((o == null) || !(o is Body))
            {
                return false;
            }
            Body body1 = ((Body) o);
            return (body1.m_BodyID == this.m_BodyID);
        }

        public override int GetHashCode()
        {
            return this.m_BodyID;
        }

        public static bool operator ==(Body l, Body r)
        {
            return (l.m_BodyID == r.m_BodyID);
        }

        public static bool operator >(Body l, Body r)
        {
            return (l.m_BodyID > r.m_BodyID);
        }

        public static bool operator >=(Body l, Body r)
        {
            return (l.m_BodyID >= r.m_BodyID);
        }

        public static implicit operator int(Body a)
        {
            return a.m_BodyID;
        }

        public static implicit operator Body(int a)
        {
            return new Body(a);
        }

        public static bool operator !=(Body l, Body r)
        {
            return (l.m_BodyID != r.m_BodyID);
        }

        public static bool operator <(Body l, Body r)
        {
            return (l.m_BodyID < r.m_BodyID);
        }

        public static bool operator <=(Body l, Body r)
        {
            return (l.m_BodyID <= r.m_BodyID);
        }

        public override string ToString()
        {
            return string.Format("0x{0:X}", this.m_BodyID);
        }


        // Properties
        public int BodyID
        {
            get
            {
                return this.m_BodyID;
            }
        }

        public bool IsAnimal
        {
            get
            {
                if ((this.m_BodyID >= 0) && (this.m_BodyID < Body.m_Types.Length))
                {
                    return (Body.m_Types[this.m_BodyID] == BodyType.Animal);
                }
                return false;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if ((this.m_BodyID >= 0) && (this.m_BodyID < Body.m_Types.Length))
                {
                    return (Body.m_Types[this.m_BodyID] == BodyType.Empty);
                }
                return false;
            }
        }

        public bool IsEquipment
        {
            get
            {
                if ((this.m_BodyID >= 0) && (this.m_BodyID < Body.m_Types.Length))
                {
                    return (Body.m_Types[this.m_BodyID] == BodyType.Equipment);
                }
                return false;
            }
        }

        public bool IsFemale
        {
            get
            {
                if (((this.m_BodyID != 184) && (this.m_BodyID != 186)) && ((this.m_BodyID != 401) && (this.m_BodyID != 403)))
                {
                    return (this.m_BodyID == 751);
                }
                return true;
            }
        }

        public bool IsGhost
        {
            get
            {
                if ((this.m_BodyID != 402) && (this.m_BodyID != 403))
                {
                    return (this.m_BodyID == 970);
                }
                return true;
            }
        }

        public bool IsHuman
        {
            get
            {
                if ((((this.m_BodyID >= 0) && (this.m_BodyID < Body.m_Types.Length)) && ((Body.m_Types[this.m_BodyID] == BodyType.Human) && (this.m_BodyID != 402))) && (this.m_BodyID != 404))
                {
                    return (this.m_BodyID != 970);
                }
                return false;
            }
        }

        public bool IsMale
        {
            get
            {
                if (((this.m_BodyID != 183) && (this.m_BodyID != 185)) && ((this.m_BodyID != 400) && (this.m_BodyID != 402)))
                {
                    return (this.m_BodyID == 750);
                }
                return true;
            }
        }

        public bool IsMonster
        {
            get
            {
                if ((this.m_BodyID >= 0) && (this.m_BodyID < Body.m_Types.Length))
                {
                    return (Body.m_Types[this.m_BodyID] == BodyType.Monster);
                }
                return false;
            }
        }

        public bool IsSea
        {
            get
            {
                if ((this.m_BodyID >= 0) && (this.m_BodyID < Body.m_Types.Length))
                {
                    return (Body.m_Types[this.m_BodyID] == BodyType.Sea);
                }
                return false;
            }
        }

        public BodyType Type
        {
            get
            {
                if ((this.m_BodyID >= 0) && (this.m_BodyID < Body.m_Types.Length))
                {
                    return Body.m_Types[this.m_BodyID];
                }
                return BodyType.Empty;
            }
        }


        // Fields
        private int m_BodyID;
        private static BodyType[] m_Types;
    }
}

