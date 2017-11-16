namespace Server
{
    using System;

    public class MobileNotConnectedException : Exception
    {
        // Methods
        public MobileNotConnectedException(Mobile source, string message) : base(message)
        {
            this.Source = source.ToString();
        }

    }
}

