namespace Server
{
    using Server.Accounting;
    using Server.Network;
    using System;

    public class CharacterCreatedEventArgs : EventArgs
    {
        // Methods
        public CharacterCreatedEventArgs(NetState state, IAccount a, string name, bool female, int hue, int str, int dex, int intel, CityInfo city, SkillNameValue[] skills, int shirtHue, int pantsHue, int hairID, int hairHue, int beardID, int beardHue, int profession)
        {
            this.m_State = state;
            this.m_Account = a;
            this.m_Name = name;
            this.m_Female = female;
            this.m_Hue = hue;
            this.m_Str = str;
            this.m_Dex = dex;
            this.m_Int = intel;
            this.m_City = city;
            this.m_Skills = skills;
            this.m_ShirtHue = shirtHue;
            this.m_PantsHue = pantsHue;
            this.m_HairID = hairID;
            this.m_HairHue = hairHue;
            this.m_BeardID = beardID;
            this.m_BeardHue = beardHue;
            this.m_Profession = profession;
        }


        // Properties
        public IAccount Account
        {
            get
            {
                return this.m_Account;
            }
        }

        public int BeardHue
        {
            get
            {
                return this.m_BeardHue;
            }
        }

        public int BeardID
        {
            get
            {
                return this.m_BeardID;
            }
        }

        public CityInfo City
        {
            get
            {
                return this.m_City;
            }
        }

        public int Dex
        {
            get
            {
                return this.m_Dex;
            }
        }

        public bool Female
        {
            get
            {
                return this.m_Female;
            }
        }

        public int HairHue
        {
            get
            {
                return this.m_HairHue;
            }
        }

        public int HairID
        {
            get
            {
                return this.m_HairID;
            }
        }

        public int Hue
        {
            get
            {
                return this.m_Hue;
            }
        }

        public int Int
        {
            get
            {
                return this.m_Int;
            }
        }

        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
            set
            {
                this.m_Mobile = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
        }

        public int PantsHue
        {
            get
            {
                return this.m_PantsHue;
            }
        }

        public int Profession
        {
            get
            {
                return this.m_Profession;
            }
        }

        public int ShirtHue
        {
            get
            {
                return this.m_ShirtHue;
            }
        }

        public SkillNameValue[] Skills
        {
            get
            {
                return this.m_Skills;
            }
        }

        public NetState State
        {
            get
            {
                return this.m_State;
            }
        }

        public int Str
        {
            get
            {
                return this.m_Str;
            }
        }


        // Fields
        private IAccount m_Account;
        private int m_BeardHue;
        private int m_BeardID;
        private CityInfo m_City;
        private int m_Dex;
        private bool m_Female;
        private int m_HairHue;
        private int m_HairID;
        private int m_Hue;
        private int m_Int;
        private Mobile m_Mobile;
        private string m_Name;
        private int m_PantsHue;
        private int m_Profession;
        private int m_ShirtHue;
        private SkillNameValue[] m_Skills;
        private NetState m_State;
        private int m_Str;
    }
}

