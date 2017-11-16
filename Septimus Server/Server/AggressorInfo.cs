namespace Server
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;

    public class AggressorInfo
    {
        // Methods
        static AggressorInfo()
        {
            AggressorInfo.m_Pool = new Queue();
            AggressorInfo.m_ExpireDelay = TimeSpan.FromMinutes(2);
        }

        private AggressorInfo(Mobile attacker, Mobile defender, bool criminal)
        {
            this.m_Attacker = attacker;
            this.m_Defender = defender;
            this.m_CanReportMurder = criminal;
            this.m_CriminalAggression = criminal;
            this.Refresh();
        }

        public static AggressorInfo Create(Mobile attacker, Mobile defender, bool criminal)
        {
            AggressorInfo info1;
            if (AggressorInfo.m_Pool.Count > 0)
            {
                info1 = ((AggressorInfo) AggressorInfo.m_Pool.Dequeue());
                info1.m_Attacker = attacker;
                info1.m_Defender = defender;
                info1.m_CanReportMurder = criminal;
                info1.m_CriminalAggression = criminal;
                info1.m_Queued = false;
                info1.Refresh();
                return info1;
            }
            return new AggressorInfo(attacker, defender, criminal);
        }

        public static void DumpAccess()
        {
            using (StreamWriter writer1 = new StreamWriter("warnings.log", true))
            {
                writer1.WriteLine("Warning: Access to queued AggressorInfo:");
                writer1.WriteLine(new StackTrace());
                writer1.WriteLine();
                writer1.WriteLine();
                return;
            }
        }

        public void Free()
        {
            if (this.m_Queued)
            {
                return;
            }
            this.m_Queued = true;
            AggressorInfo.m_Pool.Enqueue(this);
        }

        public void Refresh()
        {
            if (this.m_Queued)
            {
                AggressorInfo.DumpAccess();
            }
            this.m_LastCombatTime = DateTime.Now;
            this.m_Reported = false;
        }


        // Properties
        public Mobile Attacker
        {
            get
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                return this.m_Attacker;
            }
        }

        public bool CanReportMurder
        {
            get
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                return this.m_CanReportMurder;
            }
            set
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                this.m_CanReportMurder = value;
            }
        }

        public bool CriminalAggression
        {
            get
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                return this.m_CriminalAggression;
            }
            set
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                this.m_CriminalAggression = value;
            }
        }

        public Mobile Defender
        {
            get
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                return this.m_Defender;
            }
        }

        public bool Expired
        {
            get
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                if (!this.m_Attacker.Deleted && !this.m_Defender.Deleted)
                {
                    return (DateTime.Now >= (this.m_LastCombatTime + AggressorInfo.m_ExpireDelay));
                }
                return true;
            }
        }

        public static TimeSpan ExpireDelay
        {
            get
            {
                return AggressorInfo.m_ExpireDelay;
            }
            set
            {
                AggressorInfo.m_ExpireDelay = value;
            }
        }

        public DateTime LastCombatTime
        {
            get
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                return this.m_LastCombatTime;
            }
        }

        public bool Reported
        {
            get
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                return this.m_Reported;
            }
            set
            {
                if (this.m_Queued)
                {
                    AggressorInfo.DumpAccess();
                }
                this.m_Reported = value;
            }
        }


        // Fields
        private Mobile m_Attacker;
        private bool m_CanReportMurder;
        private bool m_CriminalAggression;
        private Mobile m_Defender;
        private static TimeSpan m_ExpireDelay;
        private DateTime m_LastCombatTime;
        private static Queue m_Pool;
        private bool m_Queued;
        private bool m_Reported;
    }
}

