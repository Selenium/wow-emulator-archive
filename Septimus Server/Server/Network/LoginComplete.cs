namespace Server.Network
{
    using System;

    public sealed class LoginComplete : Packet
    {
        // Methods
        static LoginComplete()
        {
            LoginComplete.Instance = new LoginComplete();
        }

        public LoginComplete() : base(85, 1)
        {
        }


        // Fields
        public static readonly LoginComplete Instance;
    }
}

