namespace Server.Network
{
    using System;

    public sealed class DeleteResult : Packet
    {
        // Methods
        public DeleteResult(DeleteResultType res) : base(133, 2)
        {
            this.m_Stream.Write(((byte) res));
        }

    }
}

