namespace WorldServer
{
    using System;

    internal class Account
    {
        public bool BCEnabled = false;
        public int GMLevel = 0;
        public byte[] Hash;
        public string Name;
        public Side team = Side.NONE;
    }
}

