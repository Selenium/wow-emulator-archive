namespace Server
{
    using System;

    public class SkillInfo
    {
        // Methods
        static SkillInfo()
        {
            SkillInfo[] infoArray1 = new SkillInfo[52];
            infoArray1[0] = new SkillInfo(0, "Alchemy", 0, 5, 5, "Alchemist", null, 0, 0.5, 0.5, 1);
            infoArray1[1] = new SkillInfo(1, "Anatomy", 0, 0, 0, "Healer", null, 0.15, 0.15, 0.7, 1);
            infoArray1[2] = new SkillInfo(2, "Animal Lore", 0, 0, 0, "Ranger", null, 0, 0, 1, 1);
            infoArray1[3] = new SkillInfo(3, "Item Identification", 0, 0, 0, "Merchant", null, 0, 0, 1, 1);
            infoArray1[4] = new SkillInfo(4, "Arms Lore", 0, 0, 0, "Warrior", null, 0.75, 0.15, 0.1, 1);
            infoArray1[5] = new SkillInfo(5, "Parrying", 7.5, 2.5, 0, "Warrior", null, 0.75, 0.25, 0, 1);
            infoArray1[6] = new SkillInfo(6, "Begging", 0, 0, 0, "Beggar", null, 0, 0, 0, 1);
            infoArray1[7] = new SkillInfo(7, "Blacksmithy", 10, 0, 0, "Smith", null, 1, 0, 0, 1);
            infoArray1[8] = new SkillInfo(8, "Bowcraft/Fletching", 6, 16, 0, "Bowyer", null, 0.6, 1.6, 0, 1);
            infoArray1[9] = new SkillInfo(9, "Peacemaking", 0, 0, 0, "Bard", null, 0, 0, 0, 1);
            infoArray1[10] = new SkillInfo(10, "Camping", 20, 15, 15, "Ranger", null, 2, 1.5, 1.5, 1);
            infoArray1[11] = new SkillInfo(11, "Carpentry", 20, 5, 0, "Carpenter", null, 2, 0.5, 0, 1);
            infoArray1[12] = new SkillInfo(12, "Cartography", 0, 7.5, 7.5, "Cartographer", null, 0, 0.75, 0.75, 1);
            infoArray1[13] = new SkillInfo(13, "Cooking", 0, 20, 30, "Chef", null, 0, 2, 3, 1);
            infoArray1[14] = new SkillInfo(14, "Detecting Hidden", 0, 0, 0, "Scout", null, 0, 0.4, 0.6, 1);
            infoArray1[15] = new SkillInfo(15, "Discordance", 0, 2.5, 2.5, "Bard", null, 0, 0.25, 0.25, 1);
            infoArray1[16] = new SkillInfo(16, "Evaluating Intelligence", 0, 0, 0, "Scholar", null, 0, 0, 1, 1);
            infoArray1[17] = new SkillInfo(17, "Healing", 6, 6, 8, "Healer", null, 0.6, 0.6, 0.8, 1);
            infoArray1[18] = new SkillInfo(18, "Fishing", 0, 0, 0, "Fisherman", null, 0.5, 0.5, 0, 1);
            infoArray1[19] = new SkillInfo(19, "Forensic Evaluation", 0, 0, 0, "Detective", null, 0, 0.2, 0.8, 1);
            infoArray1[20] = new SkillInfo(20, "Herding", 16.25, 6.25, 2.5, "Shepherd", null, 1.625, 0.625, 0.25, 1);
            infoArray1[21] = new SkillInfo(21, "Hiding", 0, 0, 0, "Rogue", null, 0, 0.8, 0.2, 1);
            infoArray1[22] = new SkillInfo(22, "Provocation", 0, 4.5, 0.5, "Bard", null, 0, 0.45, 0.05, 1);
            infoArray1[23] = new SkillInfo(23, "Inscription", 0, 2, 8, "Scribe", null, 0, 0.2, 0.8, 1);
            infoArray1[24] = new SkillInfo(24, "Lockpicking", 0, 25, 0, "Rogue", null, 0, 2, 0, 1);
            infoArray1[25] = new SkillInfo(25, "Magery", 0, 0, 15, "Mage", null, 0, 0, 1.5, 1);
            infoArray1[26] = new SkillInfo(26, "Resisting Spells", 0, 0, 0, "Mage", null, 0.25, 0.25, 0.5, 1);
            infoArray1[27] = new SkillInfo(27, "Tactics", 0, 0, 0, "Warrior", null, 0, 0, 0, 1);
            infoArray1[28] = new SkillInfo(28, "Snooping", 0, 25, 0, "Pickpocket", null, 0, 2.5, 0, 1);
            infoArray1[29] = new SkillInfo(29, "Musicianship", 0, 0, 0, "Bard", null, 0, 0.8, 0.2, 1);
            infoArray1[30] = new SkillInfo(30, "Poisoning", 0, 4, 16, "Assassin", null, 0, 0.4, 1.6, 1);
            infoArray1[31] = new SkillInfo(31, "Archery", 2.5, 7.5, 0, "Archer", null, 0.25, 0.75, 0, 1);
            infoArray1[32] = new SkillInfo(32, "Spirit Speak", 0, 0, 0, "Medium", null, 0, 0, 1, 1);
            infoArray1[33] = new SkillInfo(33, "Stealing", 0, 10, 0, "Rogue", null, 0, 1, 0, 1);
            infoArray1[34] = new SkillInfo(34, "Tailoring", 3.75, 16.25, 5, "Tailor", null, 0.38, 1.63, 0.5, 1);
            infoArray1[35] = new SkillInfo(35, "Animal Taming", 14, 2, 4, "Tamer", null, 1.4, 0.2, 0.4, 1);
            infoArray1[36] = new SkillInfo(36, "Taste Identification", 0, 0, 0, "Chef", null, 0.2, 0, 0.8, 1);
            infoArray1[37] = new SkillInfo(37, "Tinkering", 5, 2, 3, "Tinker", null, 0.5, 0.2, 0.3, 1);
            infoArray1[38] = new SkillInfo(38, "Tracking", 0, 12.5, 12.5, "Ranger", null, 0, 1.25, 1.25, 1);
            infoArray1[39] = new SkillInfo(39, "Veterinary", 8, 4, 8, "Veterinarian", null, 0.8, 0.4, 0.8, 1);
            infoArray1[40] = new SkillInfo(40, "Swordsmanship", 7.5, 2.5, 0, "Swordsman", null, 0.75, 0.25, 0, 1);
            infoArray1[41] = new SkillInfo(41, "Mace Fighting", 9, 1, 0, "Armsman", null, 0.9, 0.1, 0, 1);
            infoArray1[42] = new SkillInfo(42, "Fencing", 4.5, 5.5, 0, "Fencer", null, 0.45, 0.55, 0, 1);
            infoArray1[43] = new SkillInfo(43, "Wrestling", 9, 1, 0, "Wrestler", null, 0.9, 0.1, 0, 1);
            infoArray1[44] = new SkillInfo(44, "Lumberjacking", 20, 0, 0, "Lumberjack", null, 2, 0, 0, 1);
            infoArray1[45] = new SkillInfo(45, "Mining", 20, 0, 0, "Miner", null, 2, 0, 0, 1);
            infoArray1[46] = new SkillInfo(46, "Meditation", 0, 0, 0, "Stoic", null, 0, 0, 0, 1);
            infoArray1[47] = new SkillInfo(47, "Stealth", 0, 0, 0, "Rogue", null, 0, 0, 0, 1);
            infoArray1[48] = new SkillInfo(48, "Remove Trap", 0, 0, 0, "Rogue", null, 0, 0, 0, 1);
            infoArray1[49] = new SkillInfo(49, "Necromancy", 0, 0, 0, "Necromancer", null, 0, 0, 0, 1);
            infoArray1[50] = new SkillInfo(50, "Focus", 0, 0, 0, "Stoic", null, 0, 0, 0, 1);
            infoArray1[51] = new SkillInfo(51, "Chivalry", 0, 0, 0, "Paladin", null, 0, 0, 0, 1);
            SkillInfo.m_Table = infoArray1;
        }

        public SkillInfo(int skillID, string name, double strScale, double dexScale, double intScale, string title, SkillUseCallback callback, double strGain, double dexGain, double intGain, double gainFactor)
        {
            this.m_Name = name;
            this.m_Title = title;
            this.m_SkillID = skillID;
            this.m_StrScale = (strScale / 100);
            this.m_DexScale = (dexScale / 100);
            this.m_IntScale = (intScale / 100);
            this.m_Callback = callback;
            this.m_StrGain = strGain;
            this.m_DexGain = dexGain;
            this.m_IntGain = intGain;
            this.m_GainFactor = gainFactor;
            this.m_StatTotal = ((strScale + dexScale) + intScale);
        }


        // Properties
        public SkillUseCallback Callback
        {
            get
            {
                return this.m_Callback;
            }
            set
            {
                this.m_Callback = value;
            }
        }

        public double DexGain
        {
            get
            {
                return this.m_DexGain;
            }
            set
            {
                this.m_DexGain = value;
            }
        }

        public double DexScale
        {
            get
            {
                return this.m_DexScale;
            }
            set
            {
                this.m_DexScale = value;
            }
        }

        public double GainFactor
        {
            get
            {
                return this.m_GainFactor;
            }
            set
            {
                this.m_GainFactor = value;
            }
        }

        public double IntGain
        {
            get
            {
                return this.m_IntGain;
            }
            set
            {
                this.m_IntGain = value;
            }
        }

        public double IntScale
        {
            get
            {
                return this.m_IntScale;
            }
            set
            {
                this.m_IntScale = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        public int SkillID
        {
            get
            {
                return this.m_SkillID;
            }
        }

        public double StatTotal
        {
            get
            {
                return this.m_StatTotal;
            }
            set
            {
                this.m_StatTotal = value;
            }
        }

        public double StrGain
        {
            get
            {
                return this.m_StrGain;
            }
            set
            {
                this.m_StrGain = value;
            }
        }

        public double StrScale
        {
            get
            {
                return this.m_StrScale;
            }
            set
            {
                this.m_StrScale = value;
            }
        }

        public static SkillInfo[] Table
        {
            get
            {
                return SkillInfo.m_Table;
            }
            set
            {
                SkillInfo.m_Table = value;
            }
        }

        public string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }


        // Fields
        private SkillUseCallback m_Callback;
        private double m_DexGain;
        private double m_DexScale;
        private double m_GainFactor;
        private double m_IntGain;
        private double m_IntScale;
        private string m_Name;
        private int m_SkillID;
        private double m_StatTotal;
        private double m_StrGain;
        private double m_StrScale;
        private static SkillInfo[] m_Table;
        private string m_Title;
    }
}

