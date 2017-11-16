namespace Server.Network
{
    using System;

    public class EquipInfoAttribute
    {
        // Methods
        public EquipInfoAttribute(int number) : this(number, -1)
        {
        }

        public EquipInfoAttribute(int number, int charges)
        {
            this.m_Number = number;
            this.m_Charges = charges;
        }


        // Properties
        public int Charges
        {
            get
            {
                return this.m_Charges;
            }
        }

        public int Number
        {
            get
            {
                return this.m_Number;
            }
        }


        // Fields
        private int m_Charges;
        private int m_Number;
    }
}

