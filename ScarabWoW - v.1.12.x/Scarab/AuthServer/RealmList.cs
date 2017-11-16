namespace AuthServer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections;

    internal class RealmList
    {
        public DateTime LastCheck;
        public ArrayList List = new ArrayList();

        public byte[] GetList()
        {
            ByteArrayBuilderV2 rv = new ByteArrayBuilderV2();
            rv.Add((byte) 0x10);
            rv.Add((ushort) 0);
            rv.Add((uint) 0);
            rv.Add((byte) this.List.Count);
            foreach (RealmStruct struct2 in this.List)
            {
                rv.Add(struct2.Type);
                rv.Add(struct2.Color);
                rv.Add(struct2.Name);
                rv.Add(struct2.Address);
                rv.Add(struct2.Population);
                rv.Add(struct2.CorrentCharacters);
                rv.Add((byte) 1);
                rv.Add((byte) 0);
            }
            rv.Add((ushort) 0);
            rv.Set(1, (ushort) (rv.Length - 3));
            return (byte[]) rv;
        }

        public void LoadRealmList(MySqlDataReader Reader)
        {
            this.List = new ArrayList();
            while (Reader.Read())
            {
                RealmStruct struct2 = new RealmStruct();
                struct2.RealmID = Reader.GetUInt32(0);
                struct2.Name = Reader[1].ToString();
                struct2.Type = Reader.GetUInt32(2);
                struct2.OnlinePlayer = Reader.GetUInt32(3);
                struct2.MaxPlayers = Reader.GetUInt32(4);
                struct2.Address = Reader[5].ToString();
                struct2.IsOnline = Reader.GetBoolean(6);
                this.List.Add(struct2);
            }
        }

        public void MakeList(MySqlDataReader Reader)
        {
            Hashtable hashtable = new Hashtable();
            while (Reader.Read())
            {
                hashtable.Add(Reader.GetUInt32(1), Reader.GetByte(2));
            }
            foreach (RealmStruct struct2 in this.List)
            {
                if (!struct2.IsOnline)
                {
                    struct2.Color = 3;
                }
                else if (struct2.OnlinePlayer >= struct2.MaxPlayers)
                {
                    struct2.Color = 1;
                }
                else
                {
                    struct2.Color = 0;
                }
                if (hashtable.ContainsKey(struct2.RealmID))
                {
                    struct2.CorrentCharacters = (byte) hashtable[struct2.RealmID];
                }
                else
                {
                    struct2.CorrentCharacters = 0;
                }
                float num = 100f / (((float) struct2.MaxPlayers) / ((float) struct2.OnlinePlayer));
                if (num <= 33f)
                {
                    struct2.Population = 0.5f;
                }
                if ((num > 33f) && (num <= 66f))
                {
                    struct2.Population = 1f;
                }
                if (num > 66f)
                {
                    struct2.Population = 2f;
                }
            }
        }
    }
}

