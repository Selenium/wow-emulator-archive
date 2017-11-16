namespace Server.Network
{
    using System;

    public sealed class AccountLoginAck : Packet
    {
        // Methods
        public AccountLoginAck(ServerInfo[] info) : base(168)
        {
            int num1;
            ServerInfo info1;
            base.EnsureCapacity((6 + (info.Length * 40)));
            this.m_Stream.Write(((byte) 93));
            this.m_Stream.Write(((ushort) info.Length));
            for (num1 = 0; (num1 < info.Length); ++num1)
            {
                info1 = info[num1];
                this.m_Stream.Write(((ushort) num1));
                this.m_Stream.WriteAsciiFixed(info1.Name, 32);
                this.m_Stream.Write(((byte) info1.FullPercent));
                this.m_Stream.Write(((sbyte) info1.TimeZone));
                this.m_Stream.Write(((int) info1.Address.Address.Address));
            }
        }

    }
}

