namespace WorldServer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;

    internal class Core
    {
        private ChatHandler Chat = new ChatHandler();
        public ArrayList ConnectedClients = new ArrayList();
        public int CoreID = 0;
        private DatabaseManager DbManager = new DatabaseManager();
        public ArrayList DisconectingClients = new ArrayList();
        private LogoutHandler logout;
        private MySqlDataReader MySqlReader;
        public ArrayList NewClients = new ArrayList();
        private ByteArrayBuilderV2 OutPacket = new ByteArrayBuilderV2();
        private TimerHandler Timer = new TimerHandler();

        private void HandleDisconnect(ClientConnection Client)
        {
            if (Client.PlayerBase != null)
            {
                this.DbManager.Write("UPDATE characters SET online=0 WHERE accname='" + Client.User.Name + "'");
            }
            lock (StaticCore.RealmDbManager)
            {
                StaticCore.RealmDbManager.Write("UPDATE accounts SET inworld=0 WHERE name='" + Client.User.Name + "'");
                if (Client.PlayerBase != null)
                {
                    StaticCore.RealmDbManager.Write("UPDATE realms SET onlineplayers=onlineplayers-1 WHERE id='" + StaticCore.RealmID.ToString() + "'");
                }
            }
        }

        private void PacketHandle(ClientConnection Client)
        {
            this.Timer.Run(Client);
            if (Client.Data.Length > 1)
            {
                OpCodes oP = Client.GetOP(Client.Data);
                Console.WriteLine(oP.ToString());
                this.OutPacket.Clear();
                Client.Data.Seek(6);
                switch (oP)
                {
                    case OpCodes.CMSG_CHAR_CREATE:
                    {
                        CHAR_CREATE_Handler handler2 = new CHAR_CREATE_Handler();
                        Client.Send(OpCodes.SMSG_CHAR_CREATE, handler2.CreateCharacter(Client.Data, Client, this.DbManager));
                        break;
                    }
                    case OpCodes.CMSG_CHAR_ENUM:
                    {
                        CHAR_ENUM_Handler handler = new CHAR_ENUM_Handler();
                        Client.Send(OpCodes.SMSG_CHAR_ENUM, handler.CreateList(Client, this.DbManager));
                        break;
                    }
                    case OpCodes.CMSG_CHAR_DELETE:
                    {
                        CHAR_DELETE_Handler handler3 = new CHAR_DELETE_Handler();
                        Client.Send(OpCodes.SMSG_CHAR_DELETE, handler3.DeleteCharacter(Client.Data, Client, this.DbManager));
                        break;
                    }
                    case OpCodes.CMSG_PLAYER_LOGIN:
                    {
                        ulong num4;
                        EnterWorld world = new EnterWorld();
                        Client.Data.Get(out num4);
                        this.DbManager.Write("UPDATE characters SET online=1 WHERE guid='" + num4.ToString() + "'");
                        world.Login(Client, num4);
                        break;
                    }
                    case OpCodes.MSG_NULL_ACTION:
                        Client.Disconnect();
                        break;

                    case OpCodes.CMSG_TUTORIAL_FLAG:
                        uint num6;
                        Client.Data.Get(out num6);
                        this.DbManager.Write("UPDATE characters SET tutorialflags='" + num6.ToString() + "' WHERE guid='" + Client.PlayerBase.guid.ToString() + "'");
                        break;

                    case OpCodes.CMSG_TUTORIAL_CLEAR:
                    {
                        string[] strArray = new string[] { "UPDATE characters SET tutorialflags='", uint.MaxValue.ToString(), "' WHERE guid='", Client.PlayerBase.guid.ToString(), "'" };
                        this.DbManager.Write(string.Concat(strArray));
                        break;
                    }
                    case OpCodes.CMSG_TUTORIAL_RESET:
                        this.DbManager.Write("UPDATE characters SET tutorialflags=0 WHERE guid='" + Client.PlayerBase.guid.ToString() + "'");
                        break;

                    case OpCodes.CMSG_QUERY_TIME:
                        this.OutPacket.Add((uint) 0);
                        Client.Send(OpCodes.SMSG_QUERY_TIME_RESPONSE, this.OutPacket);
                        break;

                    case OpCodes.CMSG_PLAYER_LOGOUT:
                        this.logout = new LogoutHandler();
                        this.logout.LogoutRequest(0, Client);
                        break;

                    case OpCodes.CMSG_LOGOUT_REQUEST:
                        this.logout = new LogoutHandler();
                        this.logout.LogoutRequest(0x4e20, Client);
                        break;

                    case OpCodes.CMSG_LOGOUT_CANCEL:
                        this.logout.CancelLogout(Client);
                        break;

                    case OpCodes.CMSG_NAME_QUERY:
                        ulong num5;
                        Client.Data.Get(out num5);
                        if (num5 != Client.PlayerBase.guid)
                        {
                            this.MySqlReader = this.DbManager.Read("SELECT name, race, class, gender FROM characters WHERE guid='" + num5.ToString() + "'");
                            if (!this.MySqlReader.Read())
                            {
                                this.MySqlReader.Close();
                            }
                            else
                            {
                                this.OutPacket.Add(num5);
                                this.OutPacket.Add(this.MySqlReader[0].ToString());
                                this.OutPacket.Add((byte) 0);
                                this.OutPacket.Add((uint) this.MySqlReader.GetByte(1));
                                this.OutPacket.Add((uint) this.MySqlReader.GetByte(3));
                                this.OutPacket.Add((uint) this.MySqlReader.GetByte(2));
                                this.MySqlReader.Close();
                                Client.Send(OpCodes.SMSG_NAME_QUERY_RESPONSE, this.OutPacket);
                            }
                        }
                        else
                        {
                            this.OutPacket.Add(Client.PlayerBase.guid);
                            this.OutPacket.Add(Client.PlayerBase.name);
                            this.OutPacket.Add((byte) 0);
                            this.OutPacket.Add((uint) Client.PlayerBase.race);
                            this.OutPacket.Add((uint) Client.PlayerBase.gender);
                            this.OutPacket.Add((uint) Client.PlayerBase.class_);
                            Client.Send(OpCodes.SMSG_NAME_QUERY_RESPONSE, this.OutPacket);
                        }
                        break;

                    case OpCodes.CMSG_MESSAGECHAT:
                    case OpCodes.CMSG_UPDATE_ACCOUNT_DATA:
                    case OpCodes.CMSG_GMTICKET_GETTICKET:
                    case OpCodes.CMSG_SET_ACTIVE_MOVER:
                    case OpCodes.CMSG_MEETINGSTONE_INFO:
                    case OpCodes.CMSG_MOVE_TIME_SKIPPED:
                    case OpCodes.CMSG_BATTLEFIELD_STATUS:
                        break;

                    case OpCodes.CMSG_PING:
                        uint num3;
                        Client.Data.Get(out num3);
                        this.OutPacket.Add(num3);
                        Client.Send(OpCodes.SMSG_PONG, this.OutPacket);
                        break;

                    case OpCodes.CMSG_AUTH_SESSION:
                    {
                        uint num;
                        uint num2;
                        DatabaseManager manager;
                        Client.Data.Get(out num);
                        Client.Data.Seek(4);
                        Client.Data.Get(out Client.User.Name);
                        Client.User.Name = Client.User.Name.ToLower();
                        Client.User.Hash = new byte[40];
                        Client.Data.Get(out num2);
                        byte[] array = Client.Data.GetArray(20);
                        lock ((manager = StaticCore.RealmDbManager))
                        {
                            this.MySqlReader = StaticCore.RealmDbManager.Read("SELECT sessionkey, level FROM accounts WHERE name='" + Client.User.Name + "'");
                        }
                        if (!this.MySqlReader.Read())
                        {
                            Client.Disconnect();
                            this.MySqlReader.Close();
                        }
                        else
                        {
                            this.MySqlReader.GetBytes(0, (long) 0, Client.User.Hash, 0, 40);
                            Client.User.GMLevel = this.MySqlReader.GetInt32(1);
                            this.MySqlReader.Close();
                            lock ((manager = StaticCore.RealmDbManager))
                            {
                                StaticCore.RealmDbManager.Write("UPDATE accounts SET inworld=1, lastrealmid='" + StaticCore.RealmID.ToString() + "' WHERE name='" + Client.User.Name + "'");
                            }
                            SHA1 sha = new SHA1CryptoServiceProvider();
                            ByteArrayBuilderV2 rv = new ByteArrayBuilderV2();
                            rv.Add(Encoding.ASCII.GetBytes(Client.User.Name.ToUpper()));
                            rv.Add((uint) 0);
                            rv.Add(num2);
                            rv.Add((uint) 0xdeadbabe);
                            rv.Add(Client.User.Hash);
                            if (!WorldServer.Utils.IsSameByteArray(sha.ComputeHash((byte[]) rv), array))
                            {
                                this.OutPacket.Add((byte) 13);
                                Client.Send(OpCodes.SMSG_AUTH_RESPONSE, this.OutPacket);
                            }
                            else if (num != 0x16f3)
                            {
                                this.OutPacket.Add((byte) 13);
                                Client.Send(OpCodes.SMSG_AUTH_RESPONSE, this.OutPacket);
                            }
                            else
                            {
                                this.OutPacket.Add((byte) 12);
                                Client.Send(OpCodes.SMSG_AUTH_RESPONSE, this.OutPacket);
                            }
                        }
                        break;
                    }
                    case OpCodes.CMSG_REQUEST_RAID_INFO:
                        this.OutPacket.Add((uint) 0);
                        Client.Send(OpCodes.SMSG_RAID_INSTANCE_INFO, this.OutPacket);
                        break;

                    default:
                        Console.WriteLine("unhandled OpCode (" + oP.ToString() + ")");
                        break;
                }
                Client.MRE.Set();
            }
        }

        public void Run()
        {
            this.DbManager.Connect(DatabaseConfig.IP.ToString(), DatabaseConfig.Port, DatabaseConfig.Database, DatabaseConfig.User, DatabaseConfig.Password);
            this.DbManager.Write("UPDATE characters SET online=0");
            while (ServerBase.AuthServerRunning)
            {
                ArrayList list;
                lock ((list = this.NewClients))
                {
                    foreach (ClientConnection connection in this.NewClients)
                    {
                        this.ConnectedClients.Add(connection);
                    }
                    this.NewClients.Clear();
                }
                lock ((list = this.ConnectedClients))
                {
                    foreach (ClientConnection connection2 in this.ConnectedClients)
                    {
                        lock (connection2.Data)
                        {
                            this.PacketHandle(connection2);
                        }
                    }
                }
                lock ((list = this.DisconectingClients))
                {
                    foreach (ClientConnection connection in this.DisconectingClients)
                    {
                        this.HandleDisconnect(connection);
                        this.ConnectedClients.Remove(connection);
                        Console.WriteLine("Socket (" + connection.ConnectionSocket.Handle.ToString() + ") disconnected, client removed");
                    }
                    this.DisconectingClients.Clear();
                }
                Thread.Sleep(10);
            }
        }
    }
}

