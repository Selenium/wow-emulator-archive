namespace Server.Network
{
    using Server;
    using System;

    public sealed class LoginConfirm : Packet
    {
        // Methods
        public LoginConfirm(Mobile m) : base(27, 37)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(0);
            this.m_Stream.Write(((short) Body.op_Implicit(m.Body)));
            this.m_Stream.Write(((short) m.X));
            this.m_Stream.Write(((short) m.Y));
            this.m_Stream.Write(((short) m.Z));
            this.m_Stream.Write(((byte) m.Direction));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(-1);
            Map map1 = m.Map;
            if ((map1 == null) || (map1 == Map.Internal))
            {
                map1 = m.LogoutMap;
            }
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) ((map1 == null) ? 6144 : map1.Width)));
            this.m_Stream.Write(((short) ((map1 == null) ? 4096 : map1.Height)));
            this.m_Stream.Fill();
        }

    }
}

