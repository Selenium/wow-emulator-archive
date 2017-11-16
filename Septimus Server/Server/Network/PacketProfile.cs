namespace Server.Network
{
    using Server;
    using System;

    public class PacketProfile
    {
        // Methods
        static PacketProfile()
        {
            PacketProfile.m_OutgoingProfiles = new PacketProfile[256];
            PacketProfile.m_IncomingProfiles = new PacketProfile[256];
        }

        public PacketProfile(bool outgoing)
        {
            this.m_Outgoing = outgoing;
        }

        public static PacketProfile GetIncomingProfile(int packetID)
        {
            if (!Core.Profiling)
            {
                return null;
            }
            PacketProfile profile1 = PacketProfile.m_IncomingProfiles[packetID];
            if (profile1 == null)
            {
                PacketProfile.m_IncomingProfiles[packetID] = (profile1 = new PacketProfile(false));
            }
            return profile1;
        }

        public static PacketProfile GetOutgoingProfile(int packetID)
        {
            if (!Core.Profiling)
            {
                return null;
            }
            PacketProfile profile1 = PacketProfile.m_OutgoingProfiles[packetID];
            if (profile1 == null)
            {
                PacketProfile.m_OutgoingProfiles[packetID] = (profile1 = new PacketProfile(true));
            }
            return profile1;
        }

        public void Record(int byteLength, TimeSpan processTime)
        {
            ++this.m_Count;
            this.m_TotalByteLength += byteLength;
            this.m_TotalProcTime += processTime;
        }

        public void RegConstruct()
        {
            ++this.m_Constructed;
        }


        // Properties
        [CommandProperty(AccessLevel.Administrator)]
        public double AverageByteLength
        {
            get
            {
                if (this.m_Count == 0)
                {
                    return 0;
                }
                return Math.Round(((double) (this.m_TotalByteLength / this.m_Count)), 2);
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public TimeSpan AverageProcTime
        {
            get
            {
                if (this.m_Count == 0)
                {
                    return TimeSpan.Zero;
                }
                return TimeSpan.FromTicks((this.m_TotalProcTime.Ticks / this.m_Count));
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int Constructed
        {
            get
            {
                return this.m_Constructed;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int Count
        {
            get
            {
                return this.m_Count;
            }
        }

        public static PacketProfile[] IncomingProfiles
        {
            get
            {
                return PacketProfile.m_IncomingProfiles;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public bool Outgoing
        {
            get
            {
                return this.m_Outgoing;
            }
        }

        public static PacketProfile[] OutgoingProfiles
        {
            get
            {
                return PacketProfile.m_OutgoingProfiles;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int TotalByteLength
        {
            get
            {
                return this.m_TotalByteLength;
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
        private int m_Constructed;
        private int m_Count;
        private static PacketProfile[] m_IncomingProfiles;
        private bool m_Outgoing;
        private static PacketProfile[] m_OutgoingProfiles;
        private int m_TotalByteLength;
        private TimeSpan m_TotalProcTime;
    }
}

