namespace Server
{
    using System;
    using System.Collections;

    [Parsable]
    public abstract class Poison
    {
        // Methods
        static Poison()
        {
            Poison.m_Poisons = new ArrayList();
        }

        protected Poison()
        {
        }

        public abstract Timer ConstructTimer(Mobile m);

        public static Poison Deserialize(GenericReader reader)
        {
            switch (reader.ReadByte())
            {
                case 1:
                {
                    goto Label_0019;
                }
                case 2:
                {
                    goto Label_0025;
                }
            }
            goto Label_0041;
        Label_0019:
            return Poison.GetPoison(reader.ReadByte());
        Label_0025:
            reader.ReadInt();
            reader.ReadDouble();
            reader.ReadInt();
            reader.ReadTimeSpan();
        Label_0041:
            return null;
        }

        public static Poison GetPoison(int level)
        {
            int num1;
            Poison poison1;
            for (num1 = 0; (num1 < Poison.m_Poisons.Count); ++num1)
            {
                poison1 = ((Poison) Poison.m_Poisons[num1]);
                if (poison1.Level == level)
                {
                    return poison1;
                }
            }
            return null;
        }

        public static Poison GetPoison(string name)
        {
            int num1;
            Poison poison1;
            for (num1 = 0; (num1 < Poison.m_Poisons.Count); ++num1)
            {
                poison1 = ((Poison) Poison.m_Poisons[num1]);
                if (Utility.InsensitiveCompare(poison1.Name, name) == 0)
                {
                    return poison1;
                }
            }
            return null;
        }

        public static Poison Parse(string value)
        {
            Poison poison1 = null;
            try
            {
                poison1 = Poison.GetPoison(Convert.ToInt32(value));
            }
            catch
            {
            }
            if (poison1 == null)
            {
                poison1 = Poison.GetPoison(value);
            }
            return poison1;
        }

        public static void Register(Poison reg)
        {
            int num1;
            string text1 = reg.Name.ToLower();
            for (num1 = 0; (num1 < Poison.m_Poisons.Count); ++num1)
            {
                if (reg.Level == ((Poison) Poison.m_Poisons[num1]).Level)
                {
                    throw new Exception("A poison with that level already exists.");
                }
                if (text1 == ((Poison) Poison.m_Poisons[num1]).Name.ToLower())
                {
                    throw new Exception("A poison with that name already exists.");
                }
            }
            Poison.m_Poisons.Add(reg);
        }

        public static void Serialize(Poison p, GenericWriter writer)
        {
            if (p == null)
            {
                writer.Write(((byte) 0));
                return;
            }
            writer.Write(((byte) 1));
            writer.Write(((byte) p.Level));
        }

        public override string ToString()
        {
            return this.Name;
        }


        // Properties
        public static Poison Deadly
        {
            get
            {
                return Poison.GetPoison("Deadly");
            }
        }

        public static Poison Greater
        {
            get
            {
                return Poison.GetPoison("Greater");
            }
        }

        public static Poison Lesser
        {
            get
            {
                return Poison.GetPoison("Lesser");
            }
        }

        public static Poison Lethal
        {
            get
            {
                return Poison.GetPoison("Lethal");
            }
        }

        public abstract int Level { get; }

        public abstract string Name { get; }

        public static ArrayList Poisons
        {
            get
            {
                return Poison.m_Poisons;
            }
        }

        public static Poison Regular
        {
            get
            {
                return Poison.GetPoison("Regular");
            }
        }


        // Fields
        private static ArrayList m_Poisons;
    }
}

