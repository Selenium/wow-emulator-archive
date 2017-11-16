namespace Server
{
    using System;

    public class TimerProfile
    {
        // Methods
        public TimerProfile()
        {
        }

        public void RegCreation()
        {
            ++this.m_Created;
        }

        public void RegStart()
        {
            ++this.m_Started;
        }

        public void RegStopped()
        {
            ++this.m_Stopped;
        }

        public void RegTicked(TimeSpan procTime)
        {
            ++this.m_Ticked;
            this.m_TotalProcTime += procTime;
        }


        // Properties
        [CommandProperty(AccessLevel.Administrator)]
        public TimeSpan AverageProcTime
        {
            get
            {
                if (this.m_Ticked == 0)
                {
                    return TimeSpan.Zero;
                }
                return TimeSpan.FromTicks((this.m_TotalProcTime.Ticks / this.m_Ticked));
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int Created
        {
            get
            {
                return this.m_Created;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int Started
        {
            get
            {
                return this.m_Started;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int Stopped
        {
            get
            {
                return this.m_Stopped;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int Ticked
        {
            get
            {
                return this.m_Ticked;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public TimeSpan TotalProcTime
        {
            get
            {
                return this.m_TotalProcTime;
            }
        }


        // Fields
        private int m_Created;
        private int m_Started;
        private int m_Stopped;
        private int m_Ticked;
        private TimeSpan m_TotalProcTime;
    }
}

