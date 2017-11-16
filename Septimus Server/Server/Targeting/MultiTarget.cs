namespace Server.Targeting
{
    using Server;
    using Server.Network;
    using System;

    public abstract class MultiTarget : Target
    {
        // Methods
        public MultiTarget(int multiID, Point3D offset) : this(multiID, offset, 10, true, TargetFlags.None)
        {
        }

        public MultiTarget(int multiID, Point3D offset, int range, bool allowGround, TargetFlags flags) : base(range, allowGround, flags)
        {
            this.m_MultiID = multiID;
            this.m_Offset = offset;
        }

        public override Packet GetPacket()
        {
            return new MultiTargetReq(this);
        }


        // Properties
        public int MultiID
        {
            get
            {
                return this.m_MultiID;
            }
            set
            {
                this.m_MultiID = value;
            }
        }

        public Point3D Offset
        {
            get
            {
                return this.m_Offset;
            }
            set
            {
                this.m_Offset = value;
            }
        }


        // Fields
        private int m_MultiID;
        private Point3D m_Offset;
    }
}

