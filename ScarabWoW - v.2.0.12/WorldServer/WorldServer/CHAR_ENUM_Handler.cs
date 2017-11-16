namespace WorldServer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections;

    internal class CHAR_ENUM_Handler
    {
        private MySqlDataReader Reader;

        public byte[] CreateList(ClientConnection Client, DatabaseManager DbManager)
        {
            Client.PlayerBase = null;
            ByteArrayBuilderV2 rv = new ByteArrayBuilderV2();
            this.Reader = DbManager.Read("SELECT * FROM characters WHERE accname='" + Client.User.Name + "' AND realmid='" + StaticCore.RealmID.ToString() + "'");
            Client.Characters = new ArrayList();
            while (this.Reader.Read())
            {
                CharacterBase base2 = new CharacterBase();
                base2.guid = this.Reader.GetUInt64(0);
                base2.name = this.Reader[2].ToString();
                byte @byte = this.Reader.GetByte(3);
                byte num2 = this.Reader.GetByte(4);
                byte num3 = this.Reader.GetByte(5);
                base2.gender = (Gender) num3;
                base2.race = (Races) @byte;
                base2.class_ = (Classes) num2;
                base2.skin = this.Reader.GetByte(6);
                base2.face = this.Reader.GetByte(7);
                base2.hairstyle = this.Reader.GetByte(8);
                base2.haircolor = this.Reader.GetByte(9);
                base2.facialhair = this.Reader.GetByte(10);
                base2.level = this.Reader.GetByte(11);
                base2.zoneid = this.Reader.GetUInt32(12);
                base2.map = this.Reader.GetUInt32(13);
                base2.x = this.Reader.GetFloat(14);
                base2.y = this.Reader.GetFloat(15);
                base2.z = this.Reader.GetFloat(0x10);
                base2.guildid = this.Reader.GetUInt32(0x11);
                base2.flags = this.Reader.GetByte(0x12);
                base2.rest = this.Reader.GetByte(0x13);
                base2.petinfoid = this.Reader.GetUInt32(20);
                base2.petlevel = this.Reader.GetUInt32(0x15);
                base2.petfamilyid = this.Reader.GetUInt32(0x16);
                base2.displayid = this.Reader.GetUInt32(0x18);
                base2.tutorialflags = this.Reader.GetUInt32(0x1a);
                Client.Characters.Add(base2);
            }
            Client.User.team = Side.NONE;
            rv.Add((byte) Client.Characters.Count);
            foreach (CharacterBase base3 in Client.Characters)
            {
                Client.User.team = base3.GetSide();
                rv.Add(base3.guid);
                rv.Add(base3.name);
                rv.Add((byte) base3.race);
                rv.Add((byte) base3.class_);
                rv.Add((byte) base3.gender);
                rv.Add(base3.skin);
                rv.Add(base3.face);
                rv.Add(base3.hairstyle);
                rv.Add(base3.haircolor);
                rv.Add(base3.facialhair);
                rv.Add(base3.level);
                rv.Add(base3.zoneid);
                rv.Add(base3.map);
                rv.Add(base3.x);
                rv.Add(base3.y);
                rv.Add(base3.z);
                rv.Add(base3.guildid);
                rv.Add((uint) 0);
                rv.Add(base3.rest);
                rv.Add(base3.petinfoid);
                rv.Add(base3.petlevel);
                rv.Add(base3.petfamilyid);
                Console.WriteLine("Guid:{0}", base3.guid);
                rv.Add(new byte[100]);
            }
            this.Reader.Close();
            lock (StaticCore.RealmDbManager)
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = StaticCore.RealmDbManager.Connection;
                command.CommandText = "REPLACE INTO realmcharacters (accname, realmid, charcount) VALUES(?accname, ?realmid, ?charcount)";
                command.Parameters.Add("?accname", Client.User.Name);
                command.Parameters.Add("?realmid", StaticCore.RealmID);
                command.Parameters.Add("?charcount", Client.Characters.Count);
                command.ExecuteNonQuery();
            }
            return (byte[]) rv;
        }
    }
}

