namespace WorldServer
{
    using System;
    using System.Collections;
    using System.Net.Sockets;
    using System.Threading;

    internal class ClientConnection
    {
        public bool Authed = false;
        public byte[] Buffer = new byte[0x400];
        public bool CanBeCleared = false;
        public ArrayList Characters = new ArrayList();
        public Socket ConnectionSocket;
        public int CoreID;
        public ByteArrayBuilderV2 DataBuffer = new ByteArrayBuilderV2();
        private ByteArrayBuilderV2 input = new ByteArrayBuilderV2();
        private byte[] key = new byte[4];
        public WorldServer.Timer LogoutTimer;
        public ManualResetEvent MRE = new ManualResetEvent(false);
        private ByteArrayBuilderV2 pack = new ByteArrayBuilderV2();
        public int PacketLength = 0;
        public ArrayList Packets = new ArrayList();
        public CharacterBase PlayerBase;
        public Side Team = Side.NONE;
        private ByteArrayBuilderV2 temp = new ByteArrayBuilderV2();
        public ByteArrayBuilderV2 teszt = new ByteArrayBuilderV2();
        public Account User = new Account();

        private void Decode(ByteArrayBuilderV2 data)
        {
            for (int i = 0; i < 6; i++)
            {
                byte num2 = this.key[0];
                this.key[0] = data[i];
                byte num3 = data[i];
                num3 = (byte) (num3 - num2);
                byte index = this.key[1];
                num2 = this.User.Hash[index];
                num2 = (byte) (num2 ^ num3);
                data[i] = num2;
                num2 = this.key[1];
                num2 = (byte) (num2 + 1);
                this.key[1] = (byte) (num2 % 40);
            }
        }

        public void Disconnect()
        {
            try
            {
                this.ConnectionSocket.Shutdown(SocketShutdown.Both);
                lock (((Core) ServerBase.AuthCores[this.CoreID]).DisconectingClients)
                {
                    ((Core) ServerBase.AuthCores[this.CoreID]).DisconectingClients.Add(this);
                }
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
                this.Disconnect();
            }
        }

        private void Encode(ByteArrayBuilderV2 data)
        {
            for (int i = 0; i < 4; i++)
            {
                byte index = this.key[3];
                index = (byte) (this.User.Hash[index] ^ data[i]);
                byte num3 = this.key[2];
                index = (byte) (index + num3);
                data[i] = index;
                this.key[2] = index;
                index = this.key[3];
                index = (byte) (index + 1);
                this.key[3] = (byte) (index % 40);
            }
        }

        public OpCodes GetOP(ByteArrayBuilderV2 data)
        {
            this.PacketLength = 0;
            int num = 0;
            int num2 = 0;
            this.input.Clear();
            OpCodes codes = OpCodes.MSG_NULL_ACTION;
            this.input.Add((byte[]) data);
            while (this.input.Length >= 6)
            {
                if (this.User.Hash != null)
                {
                    this.Decode(this.input);
                }
                num++;
                this.input.pos = 0;
                ushort num3 = Endian.Swap(this.input.GetWord());
                num2 += num3;
                codes = (OpCodes) (this.input[2] + (this.input[3] << 8));
                this.input.Remove(0, num3 + 2);
            }
            this.PacketLength = num2 + (num * 2);
            return codes;
        }

        public void ReadCallback(IAsyncResult ar)
        {
            ArrayList list;
            lock ((list = this.Packets))
            {
                if (this.CanBeCleared)
                {
                    this.Packets.Clear();
                }
            }
            int count = 0;
            try
            {
                count = this.ConnectionSocket.EndReceive(ar);
                if (count <= 0x400)
                {
                    this.temp.Clear();
                    this.temp.Add(this.Buffer);
                    lock (this.DataBuffer)
                    {
                        this.DataBuffer.Add(this.temp.GetArray(0, count));
                    }
                }
                if (this.ConnectionSocket.Available > 0)
                {
                    this.Buffer = new byte[0x400];
                    this.ConnectionSocket.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReadCallback), null);
                    return;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                this.Disconnect();
            }
            if (count <= 0)
            {
                this.Disconnect();
            }
            else
            {
                lock ((list = this.Packets))
                {
                    this.Packets.Add(this.DataBuffer);
                    this.DataBuffer = new ByteArrayBuilderV2();
                }
                this.Buffer = new byte[0x400];
                try
                {
                    this.ConnectionSocket.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReadCallback), null);
                }
                catch (SocketException exception2)
                {
                    Console.WriteLine(exception2);
                    this.Disconnect();
                }
            }
        }

        public void Send(OpCodes op)
        {
            this.pack.Clear();
            this.pack.Add((ushort) 2);
            this.pack.Add((ushort) op);
            if (this.User.Hash != null)
            {
                this.Encode(this.pack);
                this.Send((byte[]) this.pack);
            }
            else
            {
                this.Send((byte[]) this.pack);
            }
        }

        public void Send(byte[] tosend)
        {
            try
            {
                this.ConnectionSocket.BeginSend(tosend, 0, tosend.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), null);
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
                this.Disconnect();
            }
        }

        public void Send(OpCodes op, ByteArrayBuilderV2 data)
        {
            this.pack.Clear();
            this.pack.Add(Endian.Swap((ushort) (data.Length + 2)));
            this.pack.Add((ushort) op);
            this.pack.Add((byte[]) data);
            if (this.User.Hash != null)
            {
                this.Encode(this.pack);
                this.Send((byte[]) this.pack);
            }
            else
            {
                this.Send((byte[]) this.pack);
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                this.ConnectionSocket.EndSend(ar);
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
                this.Disconnect();
            }
        }
    }
}

