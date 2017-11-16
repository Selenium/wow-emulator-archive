namespace Server.Network
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void OnPacketReceive(NetState state, PacketReader pvSrc);

}

