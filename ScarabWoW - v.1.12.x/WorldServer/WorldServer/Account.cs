namespace WorldServer
{
    using System;

    internal class Account
    {
        public int GMLevel = 0;
        public byte[] Hash;
        public string Name;
        public string Password;
        public Side team = Side.NONE;
    }
}

