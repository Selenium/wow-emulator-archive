namespace WorldServer
{
    using System;

    internal class TimerHandler
    {
        public void Run(ClientConnection Client)
        {
            if ((Client.LogoutTimer != null) && Client.LogoutTimer.IsExpired())
            {
                ByteArrayBuilderV2 data = new ByteArrayBuilderV2();
                data.Add((byte) 0);
                data.Add((uint) 0);
                Client.Send(OpCodes.SMSG_LOGOUT_COMPLETE, data);
                Console.WriteLine(Client.PlayerBase.name + " logged out");
                Client.LogoutTimer = null;
                lock (StaticCore.RealmDbManager)
                {
                    StaticCore.RealmDbManager.Write("UPDATE realms SET onlineplayers=onlineplayers-1 WHERE id='" + StaticCore.RealmID.ToString() + "'");
                }
            }
        }
    }
}

