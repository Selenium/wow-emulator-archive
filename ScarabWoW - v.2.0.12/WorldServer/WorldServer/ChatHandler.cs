namespace WorldServer
{
    using System;

    internal class ChatHandler
    {
        private ByteArrayBuilderV2 pack = new ByteArrayBuilderV2();

        public void SendMessage(ClientConnection Client, ChatMsgType type, Language lang, string msg)
        {
        }

        public void SendWelcome(ClientConnection Client, string msg)
        {
            this.pack.Clear();
            this.pack.Add((byte) 10);
            this.pack.Add((uint) 0);
            this.pack.Add(Client.PlayerBase.guid);
            this.pack.Add((uint) (msg.Length + 1));
            this.pack.Add(msg);
            this.pack.Add((byte) 0);
            Client.Send(OpCodes.SMSG_MESSAGECHAT, this.pack);
        }
    }
}

