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
        private MovementHandler Movement = new MovementHandler();
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
            ArrayList list = new ArrayList();
            lock (Client.Packets)
            {
                foreach (ByteArrayBuilderV2 rv in Client.Packets)
                {
                    list.Add(rv);
                }
                Client.Packets.Clear();
            }
            foreach (ByteArrayBuilderV2 rv2 in list)
            {
                ulong num5;
                this.Timer.Run(Client);
                OpCodes oP = Client.GetOP(rv2);
                Console.WriteLine(oP.ToString());
                this.OutPacket.Clear();
                rv2.pos = 6;
                switch (oP)
                {
                    case OpCodes.CMSG_PLAYER_LOGOUT:
                        this.logout = new LogoutHandler();
                        this.logout.LogoutRequest(0, Client);
                        goto Label_0E44;

                    case OpCodes.CMSG_LOGOUT_REQUEST:
                        this.logout = new LogoutHandler();
                        this.logout.LogoutRequest(0x4e20, Client);
                        goto Label_0E44;

                    case OpCodes.CMSG_LOGOUT_CANCEL:
                        this.logout.CancelLogout(Client);
                        goto Label_0E44;

                    case OpCodes.CMSG_NAME_QUERY:
                        rv2.Get(out num5);
                        Console.WriteLine("name guid:{0}", num5);
                        if (num5 != Client.PlayerBase.guid)
                        {
                            break;
                        }
                        this.OutPacket.Add(Client.PlayerBase.guid);
                        this.OutPacket.Add(Client.PlayerBase.name);
                        this.OutPacket.Add((byte) 0);
                        this.OutPacket.Add((uint) Client.PlayerBase.race);
                        this.OutPacket.Add((uint) Client.PlayerBase.gender);
                        this.OutPacket.Add((uint) Client.PlayerBase.class_);
                        Client.Send(OpCodes.SMSG_NAME_QUERY_RESPONSE, this.OutPacket);
                        goto Label_0E44;

                    case OpCodes.CMSG_ITEM_QUERY_SINGLE:
                        ulong num9;
                        uint num10;
                        rv2.Get(out num10);
                        rv2.Get(out num9);
                        Console.WriteLine("\nitem entry: " + num10.ToString() + " guid: " + num9.ToString());
                        this.OutPacket.Add(num10);
                        this.OutPacket.Add((uint) 4);
                        this.OutPacket.Add((uint) 1);
                        this.OutPacket.Add("Circle of Flame");
                        this.OutPacket.Add("qname");
                        this.OutPacket.Add("honorname");
                        this.OutPacket.Add("enchname");
                        this.OutPacket.Add((uint) 0x6e6c);
                        this.OutPacket.Add((uint) 4);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 100);
                        this.OutPacket.Add((uint) 10);
                        this.OutPacket.Add((uint) 1);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0x3b);
                        this.OutPacket.Add((uint) 1);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 1);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add(new byte[0x48]);
                        this.OutPacket.Add((uint) 7);
                        this.OutPacket.Add((uint) 100);
                        this.OutPacket.Add(new byte[60]);
                        this.OutPacket.Add((uint) 5);
                        this.OutPacket.Add((uint) 10);
                        this.OutPacket.Add((uint) 5);
                        this.OutPacket.Add((uint) 20);
                        this.OutPacket.Add((uint) 5);
                        this.OutPacket.Add((uint) 50);
                        this.OutPacket.Add((uint) 10);
                        this.OutPacket.Add(new byte[120]);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        this.OutPacket.Add((uint) 0);
                        Client.Send(OpCodes.SMSG_ITEM_QUERY_SINGLE_RESPONSE, this.OutPacket);
                        goto Label_0E44;

                    case OpCodes.CMSG_PLAYER_LOGIN:
                    {
                        ulong num4;
                        EnterWorld world = new EnterWorld();
                        rv2.Get(out num4);
                        Console.WriteLine("PlayerBase guid:{0}", num4);
                        this.DbManager.Write("UPDATE characters SET online=1 WHERE guid='" + num4.ToString() + "'");
                        world.Login(Client, num4);
                        goto Label_0E44;
                    }
                    case OpCodes.CMSG_CHAR_CREATE:
                    {
                        CHAR_CREATE_Handler handler2 = new CHAR_CREATE_Handler();
                        Client.Send(OpCodes.SMSG_CHAR_CREATE, handler2.CreateCharacter(rv2, Client, this.DbManager));
                        goto Label_0E44;
                    }
                    case OpCodes.CMSG_CHAR_ENUM:
                    case OpCodes.CMSG_UNKNOWN_908:
                    {
                        CHAR_ENUM_Handler handler = new CHAR_ENUM_Handler();
                        Client.Send(OpCodes.SMSG_CHAR_ENUM, handler.CreateList(Client, this.DbManager));
                        goto Label_0E44;
                    }
                    case OpCodes.CMSG_CHAR_DELETE:
                    {
                        CHAR_DELETE_Handler handler3 = new CHAR_DELETE_Handler();
                        Client.Send(OpCodes.SMSG_CHAR_DELETE, handler3.DeleteCharacter(rv2, Client, this.DbManager));
                        goto Label_0E44;
                    }
                    case OpCodes.MSG_NULL_ACTION:
                        Client.Disconnect();
                        goto Label_0E44;

                    case OpCodes.MSG_MOVE_START_FORWARD:
                    case OpCodes.MSG_MOVE_START_BACKWARD:
                    case OpCodes.MSG_MOVE_STOP:
                    case OpCodes.MSG_MOVE_START_STRAFE_LEFT:
                    case OpCodes.MSG_MOVE_START_STRAFE_RIGHT:
                    case OpCodes.MSG_MOVE_STOP_STRAFE:
                    case OpCodes.MSG_MOVE_JUMP:
                    case OpCodes.MSG_MOVE_START_TURN_LEFT:
                    case OpCodes.MSG_MOVE_START_TURN_RIGHT:
                    case OpCodes.MSG_MOVE_STOP_TURN:
                    case OpCodes.MSG_MOVE_START_PITCH_UP:
                    case OpCodes.MSG_MOVE_START_PITCH_DOWN:
                    case OpCodes.MSG_MOVE_STOP_PITCH:
                    case OpCodes.MSG_MOVE_SET_RUN_MODE:
                    case OpCodes.MSG_MOVE_SET_WALK_MODE:
                    case OpCodes.MSG_MOVE_START_SWIM:
                    case OpCodes.MSG_MOVE_STOP_SWIM:
                    case OpCodes.MSG_MOVE_SET_FACING:
                    case OpCodes.MSG_MOVE_SET_PITCH:
                    case OpCodes.MSG_MOVE_HEARTBEAT:
                        this.Movement.Move(Client, rv2);
                        goto Label_0E44;

                    case OpCodes.CMSG_MESSAGECHAT:
                    case OpCodes.CMSG_UPDATE_ACCOUNT_DATA:
                    case OpCodes.CMSG_GMTICKET_GETTICKET:
                    case OpCodes.CMSG_SET_ACTIVE_MOVER:
                    case OpCodes.CMSG_MEETINGSTONE_INFO:
                    case OpCodes.CMSG_MOVE_TIME_SKIPPED:
                    case OpCodes.CMSG_BATTLEFIELD_STATUS:
                        goto Label_0E44;

                    case OpCodes.CMSG_TUTORIAL_FLAG:
                        uint num6;
                        rv2.Get(out num6);
                        this.DbManager.Write("UPDATE characters SET tutorialflags='" + num6.ToString() + "' WHERE guid='" + Client.PlayerBase.guid.ToString() + "'");
                        goto Label_0E44;

                    case OpCodes.CMSG_TUTORIAL_CLEAR:
                    {
                        string[] strArray = new string[] { "UPDATE characters SET tutorialflags='", uint.MaxValue.ToString(), "' WHERE guid='", Client.PlayerBase.guid.ToString(), "'" };
                        this.DbManager.Write(string.Concat(strArray));
                        goto Label_0E44;
                    }
                    case OpCodes.CMSG_TUTORIAL_RESET:
                        this.DbManager.Write("UPDATE characters SET tutorialflags=0 WHERE guid='" + Client.PlayerBase.guid.ToString() + "'");
                        goto Label_0E44;

                    case OpCodes.CMSG_PING:
                        uint num3;
                        rv2.Get(out num3);
                        this.OutPacket.Add(num3);
                        Client.Send(OpCodes.SMSG_PONG, this.OutPacket);
                        goto Label_0E44;

                    case OpCodes.CMSG_AUTH_SESSION:
                    {
                        uint num;
                        uint num2;
                        DatabaseManager manager;
                        rv2.Get(out num);
                        rv2.Seek(4);
                        rv2.Get(out Client.User.Name);
                        Client.User.Name = Client.User.Name.ToLower();
                        Client.User.Hash = new byte[40];
                        rv2.Get(out num2);
                        byte[] array = rv2.GetArray(20);
                        lock ((manager = StaticCore.RealmDbManager))
                        {
                            this.MySqlReader = StaticCore.RealmDbManager.Read("SELECT sessionkey, level, burning FROM accounts WHERE name='" + Client.User.Name + "'");
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
                            Client.User.BCEnabled = this.MySqlReader.GetBoolean(2);
                            this.MySqlReader.Close();
                            lock ((manager = StaticCore.RealmDbManager))
                            {
                                StaticCore.RealmDbManager.Write("UPDATE accounts SET inworld=1, lastrealmid='" + StaticCore.RealmID.ToString() + "' WHERE name='" + Client.User.Name + "'");
                            }
                            SHA1 sha = new SHA1CryptoServiceProvider();
                            ByteArrayBuilderV2 rv3 = new ByteArrayBuilderV2();
                            rv3.Add(Encoding.ASCII.GetBytes(Client.User.Name.ToUpper()));
                            rv3.Add((uint) 0);
                            rv3.Add(num2);
                            rv3.Add((uint) 0xdeadbabe);
                            rv3.Add(Client.User.Hash);
                            if (!WorldServer.Utils.IsSameByteArray(sha.ComputeHash((byte[]) rv3), array))
                            {
                                this.OutPacket.Add((byte) 13);
                                Client.Send(OpCodes.SMSG_AUTH_RESPONSE, this.OutPacket);
                            }
                            else if (num != 0x1992)
                            {
                                this.OutPacket.Add((byte) 13);
                                Client.Send(OpCodes.SMSG_AUTH_RESPONSE, this.OutPacket);
                            }
                            else
                            {
                                this.OutPacket.Add((byte) 12);
                                this.OutPacket.Add((byte) 0xb0);
                                this.OutPacket.Add((byte) 9);
                                this.OutPacket.Add((byte) 2);
                                this.OutPacket.Add((byte) 0);
                                this.OutPacket.Add((byte) 2);
                                this.OutPacket.Add((uint) 0);
                                if (Client.User.BCEnabled)
                                {
                                    this.OutPacket.Add((byte) 1);
                                }
                                else
                                {
                                    this.OutPacket.Add((byte) 0);
                                }
                                Client.Send(OpCodes.SMSG_AUTH_RESPONSE, this.OutPacket);
                            }
                        }
                        goto Label_0E44;
                    }
                    case OpCodes.CMSG_SWAP_INV_ITEM:
                        byte num7;
                        byte num8;
                        rv2.Get(out num7);
                        rv2.Get(out num8);
                        Console.WriteLine("from: {0} to: {1}", num7, num8);
                        this.OutPacket.Add((byte) 4);
                        this.OutPacket.Add((ulong) 400);
                        this.OutPacket.Add((ulong) 0);
                        this.OutPacket.Add((byte) 0);
                        Client.Send(OpCodes.SMSG_INVENTORY_CHANGE_FAILURE, this.OutPacket);
                        goto Label_0E44;

                    case OpCodes.CMSG_QUERY_TIME:
                        this.OutPacket.Add((uint) 0);
                        Client.Send(OpCodes.SMSG_QUERY_TIME_RESPONSE, this.OutPacket);
                        goto Label_0E44;

                    case OpCodes.CMSG_REQUEST_RAID_INFO:
                        this.OutPacket.Add((uint) 0);
                        Client.Send(OpCodes.SMSG_RAID_INSTANCE_INFO, this.OutPacket);
                        goto Label_0E44;

                    default:
                        WorldServer.Utils.konzol((byte[]) rv2);
                        Console.WriteLine("unhandled OpCode (" + oP.ToString() + ")");
                        goto Label_0E44;
                }
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
            Label_0E44:;
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
                        this.PacketHandle(connection2);
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

