namespace WorldServer
{
    using System;
    using System.Collections;

    internal class EnterWorld
    {
        private uint GetTimeStamp()
        {
            DateTime now = DateTime.Now;
            return (uint) (((((now.Minute | (now.Hour << 6)) | (((int) now.DayOfWeek) << 11)) | (now.Day << 14)) | (now.Year << 0x12)) | (now.Month << 20));
        }

        public void Login(ClientConnection Client, ulong guid)
        {
            ByteArrayBuilderV2 data = new ByteArrayBuilderV2();
            foreach (CharacterBase base2 in Client.Characters)
            {
                if (base2.guid == guid)
                {
                    Client.PlayerBase = base2;
                }
            }
            if (Client.PlayerBase == null)
            {
                Client.Disconnect();
            }
            else
            {
                lock (StaticCore.RealmDbManager)
                {
                    StaticCore.RealmDbManager.Write("UPDATE realms SET onlineplayers=onlineplayers+1 WHERE id='" + StaticCore.RealmID.ToString() + "'");
                }
                Client.PlayerBase.ObjectsInRange = new Hashtable();
                Client.Send(OpCodes.SMSG_ACCOUNT_DATA_MD5, new byte[80]);
                data.Add(Client.PlayerBase.tutorialflags);
                Client.Send(OpCodes.SMSG_TUTORIAL_FLAGS, data);
                data.Clear();
                data.Add(this.GetTimeStamp());
                data.Add((float) 0.017f);
                Client.Send(OpCodes.SMSG_LOGIN_SETTIMESPEED, data);
                Client.PlayerBase.PowerType = Client.PlayerBase.GetPowerType();
                Client.PlayerBase.BaseObject.Create(Client.PlayerBase, Client);
                UpdateBuilder builder = new UpdateBuilder();
                builder.AddObject(Client.PlayerBase.BaseObject);
                builder.CreateUpdate(Client.PlayerBase.guid);
                Client.Send(OpCodes.SMSG_UPDATE_OBJECT, builder.GetUpdate());
                Client.Send(OpCodes.SMSG_MOVE_UNLOCK_MOVEMENT, new byte[4]);
                new ChatHandler().SendWelcome(Client, "Welcome to Scarabeus Server (alpha)\nEnjoy your stay!");
            }
        }
    }
}

