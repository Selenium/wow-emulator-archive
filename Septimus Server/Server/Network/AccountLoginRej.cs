namespace Server.Network
{
    using System;

    public sealed class AccountLoginRej : Packet
    {
        // Methods
        public AccountLoginRej(ALRReason reason) : base(130, 2)
        {
            this.m_Stream.Write(((byte) reason));
        }

    }
}

