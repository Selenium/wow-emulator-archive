namespace Server.Network
{
    using Server;
    using System;

    public class EquipmentInfo
    {
        // Methods
        public EquipmentInfo(int number, Mobile crafter, bool unidentified, EquipInfoAttribute[] attributes)
        {
            this.m_Number = number;
            this.m_Crafter = crafter;
            this.m_Unidentified = unidentified;
            this.m_Attributes = attributes;
        }


        // Properties
        public EquipInfoAttribute[] Attributes
        {
            get
            {
                return this.m_Attributes;
            }
        }

        public Mobile Crafter
        {
            get
            {
                return this.m_Crafter;
            }
        }

        public int Number
        {
            get
            {
                return this.m_Number;
            }
        }

        public bool Unidentified
        {
            get
            {
                return this.m_Unidentified;
            }
        }


        // Fields
        private EquipInfoAttribute[] m_Attributes;
        private Mobile m_Crafter;
        private int m_Number;
        private bool m_Unidentified;
    }
}

