namespace AuthServer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections;
    using System.Threading;

    internal class Core
    {
        private ushort build;
        public ArrayList ConnectedClients = new ArrayList();
        private DatabaseManager DbManager = new DatabaseManager();
        public ArrayList DisconectingClients = new ArrayList();
        private string ip;
        private byte ip1;
        private byte ip2;
        private byte ip3;
        private byte ip4;
        private MySqlDataReader MySqlReader;
        private byte NameLen;
        public ArrayList NewClients = new ArrayList();
        private ByteArrayBuilderV2 OutPacket = new ByteArrayBuilderV2();
        private RealmList r_list = new RealmList();

        private void PacketHandle(ClientConnection Client)
        {
            if (Client.Data.Length > 1)
            {
                AuthOpCode op = (AuthOpCode) Client.Data[0];
                Console.WriteLine(op.ToString());
                this.OutPacket.Clear();
                switch (op)
                {
                    case AuthOpCode.AUTH_LOGON_CHALLENGE:
                        if (Client.Data.Length > 0x23)
                        {
                            Client.Data.Seek(11);
                            Client.Data.Get(out this.build);
                            if (this.build != 0x1992)
                            {
                                this.OutPacket.Add((byte) 0);
                                this.OutPacket.Add((byte) 0);
                                this.OutPacket.Add((byte) 9);
                                Client.Send((byte[]) this.OutPacket);
                            }
                            else
                            {
                                Client.Data.Seek(0x10);
                                Client.Data.Get(out this.ip1);
                                Client.Data.Get(out this.ip2);
                                Client.Data.Get(out this.ip3);
                                Client.Data.Get(out this.ip4);
                                this.ip = string.Concat(new object[] { Convert.ToDecimal(this.ip1), ".", Convert.ToDecimal(this.ip2), ".", Convert.ToDecimal(this.ip3), ".", Convert.ToDecimal(this.ip4) });
                                Client.Data.Get(out this.NameLen);
                                Client.Data.Get(out Client.User.Name);
                                Client.User.Name = Client.User.Name.ToLower();
                                this.DbManager.Write("UPDATE accounts SET lastip='" + this.ip + "' WHERE name='" + Client.User.Name + "'");
                                this.MySqlReader = this.DbManager.Read("SELECT password,banned,locked,online,inworld FROM accounts WHERE name='" + Client.User.Name + "'");
                                if (!this.MySqlReader.Read())
                                {
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 4);
                                    Client.Send((byte[]) this.OutPacket);
                                    this.MySqlReader.Close();
                                }
                                else if (this.MySqlReader.GetBoolean(3) || this.MySqlReader.GetBoolean(4))
                                {
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 6);
                                    Client.Send((byte[]) this.OutPacket);
                                    this.MySqlReader.Close();
                                }
                                else if (this.MySqlReader.GetBoolean(1))
                                {
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 3);
                                    Client.Send((byte[]) this.OutPacket);
                                    this.MySqlReader.Close();
                                }
                                else if (this.MySqlReader.GetBoolean(2))
                                {
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 0);
                                    this.OutPacket.Add((byte) 15);
                                    Client.Send((byte[]) this.OutPacket);
                                    this.MySqlReader.Close();
                                }
                                else
                                {
                                    Client.User.Password = this.MySqlReader[0].ToString();
                                    this.MySqlReader.Close();
                                    this.DbManager.Write("UPDATE accounts SET online=1 WHERE name='" + Client.User.Name + "'");
                                    Client.Authed = true;
                                    Client.Send(Client.User.ServerChallange(op));
                                }
                            }
                            break;
                        }
                        return;

                    case AuthOpCode.AUTH_LOGON_PROOF:
                        Client.Send(Client.User.ServerProof(Client.Data));
                        if (Client.User.Hash != null)
                        {
                            this.DbManager.WriteSessionKey(Client.User.Name, Client.User.Hash);
                        }
                        this.DbManager.Write("UPDATE accounts SET last_access='" + DateTime.Now.ToString() + "' WHERE name='" + Client.User.Name + "'");
                        break;

                    case AuthOpCode.REALM_LIST:
                        this.MySqlReader = this.DbManager.Read("SELECT * FROM realms");
                        this.r_list.LoadRealmList(this.MySqlReader);
                        this.MySqlReader.Close();
                        this.MySqlReader = this.DbManager.Read("SELECT * FROM realmcharacters WHERE accname='" + Client.User.Name + "'");
                        this.r_list.MakeList(this.MySqlReader);
                        this.MySqlReader.Close();
                        Client.Send(this.r_list.GetList());
                        break;

                    default:
                        Console.WriteLine("unhandled Opcode (" + op.ToString() + ")");
                        break;
                }
                Client.MRE.Set();
            }
        }

        public void Run()
        {
            this.DbManager.Connect(DatabaseConfig.IP.ToString(), DatabaseConfig.Port, DatabaseConfig.Database, DatabaseConfig.User, DatabaseConfig.Password);
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
                        this.ConnectedClients.Remove(connection);
                        if (connection.Authed)
                        {
                            this.DbManager.Write("UPDATE accounts SET online=0 WHERE name='" + connection.User.Name + "'");
                        }
                        Console.WriteLine("Socket (" + connection.ConnectionSocket.Handle.ToString() + ") disconnected, client removed");
                    }
                    this.DisconectingClients.Clear();
                }
                Thread.Sleep(100);
            }
        }
    }
}

