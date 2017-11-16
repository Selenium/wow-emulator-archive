namespace Server
{
    using System;

    public class ResistanceMod
    {
        // Methods
        public ResistanceMod(ResistanceType type, int offset)
        {
            this.m_Type = type;
            this.m_Offset = offset;
        }


        // Properties
        public int Offset
        {
            get
            {
                return this.m_Offset;
            }
            set
            {
                if (this.m_Offset != value)
                {
                    this.m_Offset = value;
                    if (this.m_Owner != null)
                    {
                        this.m_Owner.UpdateResistances();
                    }
                }
            }
        }

        public Mobile Owner
        {
            get
            {
                return this.m_Owner;
            }
            set
            {
                this.m_Owner = value;
            }
        }

        public ResistanceType Type
        {
            get
            {
                return this.m_Type;
            }
            set
            {
                if (this.m_Type != value)
                {
                    this.m_Type = value;
                    if (this.m_Owner != null)
                    {
                        this.m_Owner.UpdateResistances();
                    }
                }
            }
        }


        // Fields
        private int m_Offset;
        private Mobile m_Owner;
        private ResistanceType m_Type;
    }
}

