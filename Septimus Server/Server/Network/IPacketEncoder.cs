namespace Server.Network
{
    using System;

    public interface IPacketEncoder
    {
        // Methods
        void DecodeIncomingPacket(NetState from, ref byte[] buffer, ref int length);

        void EncodeOutgoingPacket(NetState to, ref byte[] buffer, ref int length);

    }
}

