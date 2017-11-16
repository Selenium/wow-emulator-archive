namespace Server.Menus
{
    using Server.Network;
    using System;

    public interface IMenu
    {
        // Methods
        void OnCancel(NetState state);

        void OnResponse(NetState state, int index);

        void SendTo(NetState state);


        // Properties
        int EntryLength { get; }

        int Serial { get; }

    }
}

