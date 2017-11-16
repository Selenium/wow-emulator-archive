namespace WorldServer
{
    using System;

    internal class LogoutHandler
    {
        private ByteArrayBuilderV2 pack = new ByteArrayBuilderV2();

        public void CancelLogout(ClientConnection Client)
        {
            this.pack.Clear();
            Client.LogoutTimer = null;
            this.pack.Add((byte) 0);
            this.pack.Add((uint) 0);
            Client.Send(OpCodes.SMSG_LOGOUT_CANCEL_ACK, this.pack);
        }

        public void LogoutRequest(int Time, ClientConnection Client)
        {
            this.pack.Clear();
            if ((Time <= 0) || (Client.User.GMLevel > 0))
            {
                this.pack.Add((byte) 0);
                this.pack.Add((uint) 0);
                Client.Send(OpCodes.SMSG_LOGOUT_COMPLETE, this.pack);
                Console.WriteLine(Client.PlayerBase.name + " logged out");
                lock (StaticCore.RealmDbManager)
                {
                    StaticCore.RealmDbManager.Write("UPDATE realms SET onlineplayers=onlineplayers-1 WHERE id='" + StaticCore.RealmID.ToString() + "'");
                }
            }
            else
            {
                this.pack.Add((byte) 0);
                this.pack.Add((uint) 0);
                Client.Send(OpCodes.SMSG_LOGOUT_RESPONSE, this.pack);
                Client.LogoutTimer = new Timer();
                Client.LogoutTimer.SetTimeOut(Time);
                Console.WriteLine(string.Concat(new object[] { Client.PlayerBase.name, " logout requested (", Time, ")" }));
            }
        }
    }
}

