namespace Server
{
    using System;
    using System.Collections;

    public class DamageEntry
    {
        // Methods
        static DamageEntry()
        {
            DamageEntry.m_ExpireDelay = TimeSpan.FromMinutes(2);
        }

        public DamageEntry(Mobile damager)
        {
            this.m_Damager = damager;
        }


        // Properties
        public int DamageGiven
        {
            get
            {
                return this.m_DamageGiven;
            }
            set
            {
                this.m_DamageGiven = value;
            }
        }

        public Mobile Damager
        {
            get
            {
                return this.m_Damager;
            }
        }

        public static TimeSpan ExpireDelay
        {
            get
            {
                return DamageEntry.m_ExpireDelay;
            }
            set
            {
                DamageEntry.m_ExpireDelay = value;
            }
        }

        public bool HasExpired
        {
            get
            {
                return (DateTime.Now > (this.m_LastDamage + DamageEntry.m_ExpireDelay));
            }
        }

        public DateTime LastDamage
        {
            get
            {
                return this.m_LastDamage;
            }
            set
            {
                this.m_LastDamage = value;
            }
        }

        public ArrayList Responsible
        {
            get
            {
                return this.m_Responsible;
            }
            set
            {
                this.m_Responsible = value;
            }
        }


        // Fields
        private int m_DamageGiven;
        private Mobile m_Damager;
        private static TimeSpan m_ExpireDelay;
        private DateTime m_LastDamage;
        private ArrayList m_Responsible;
    }
}

