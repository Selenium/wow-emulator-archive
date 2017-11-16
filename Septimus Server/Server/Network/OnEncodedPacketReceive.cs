namespace Server.Network
{
    using Server;
    using System;
    using System.Runtime.CompilerServices;

    public delegate void OnEncodedPacketReceive(NetState state, IEntity ent, EncodedReader pvSrc);

}

