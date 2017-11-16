namespace WorldServer
{
    using MySql.Data.MySqlClient;
    using System;

    internal class CHAR_CREATE_Handler
    {
        private MySqlDataReader Reader;

        public byte[] CreateCharacter(ByteArrayBuilderV2 data, ClientConnection Client, DatabaseManager DbManager)
        {
            byte num;
            byte num2;
            byte num3;
            byte num4;
            ByteArrayBuilderV2 rv = new ByteArrayBuilderV2();
            if (Client.Characters.Count >= 10)
            {
                rv.Add((byte) 0x34);
                return (byte[]) rv;
            }
            CharacterBase base2 = new CharacterBase();
            data.Get(out base2.name);
            this.Reader = DbManager.Read("SELECT guid FROM characters WHERE name='" + base2.name + "'");
            if (this.Reader.Read())
            {
                rv.Add((byte) 0x31);
                this.Reader.Close();
                return (byte[]) rv;
            }
            this.Reader.Close();
            data.Get(out num);
            data.Get(out num2);
            base2.class_ = (Classes) num2;
            base2.race = (Races) num;
            if (Client.User.team != Side.NONE)
            {
                if ((Client.User.team != base2.GetSide()) && (StaticCore.RealmType == 1))
                {
                    rv.Add((byte) 0x33);
                    return (byte[]) rv;
                }
                if ((Client.User.team != base2.GetSide()) && (StaticCore.RealmType == 8))
                {
                    rv.Add((byte) 0x33);
                    return (byte[]) rv;
                }
            }
            data.Get(out num3);
            base2.gender = (Gender) num3;
            data.Get(out base2.skin);
            data.Get(out base2.face);
            data.Get(out base2.hairstyle);
            data.Get(out base2.haircolor);
            data.Get(out base2.facialhair);
            data.Get(out num4);
            base2.level = 1;
            base2.displayid = base2.GetDisplayId();
            string[] strArray = new string[] { "SELECT * FROM playercreateinfo WHERE race='", ((byte) base2.race).ToString(), "' AND class='", ((byte) base2.class_).ToString(), "'" };
            this.Reader = DbManager.Read(string.Concat(strArray));
            this.Reader.Read();
            base2.map = this.Reader.GetUInt32(2);
            base2.zoneid = this.Reader.GetUInt32(3);
            base2.x = this.Reader.GetFloat(4);
            base2.y = this.Reader.GetFloat(5);
            base2.z = this.Reader.GetFloat(6);
            this.Reader.Close();
            MySqlCommand command = new MySqlCommand();
            command.Connection = DbManager.Connection;
            command.CommandText = "INSERT INTO characters (accname, name, race, class, gender, skin, face, hairstyle, haircolor, facialhair, level, zoneid, map, x, y, z, guildid, flags, rest, petinfoid, petlevel, petfamilyid, realmid, displayid, tutorialflags) VALUES(?accname, ?name, ?race, ?class, ?gender, ?skin, ?face, ?hairstyle, ?haircolor, ?facialhair, ?level, ?zoneid, ?map, ?x, ?y, ?z, ?guildid, ?flags, ?rest, ?petinfoid, ?petlevel, ?petfamilyid, ?realmid, ?displayid, ?tutorialflags)";
            command.Parameters.Add("?accname", Client.User.Name);
            command.Parameters.Add("?name", base2.name);
            command.Parameters.Add("?race", base2.race);
            command.Parameters.Add("?class", base2.class_);
            command.Parameters.Add("?gender", base2.gender);
            command.Parameters.Add("?skin", base2.skin);
            command.Parameters.Add("?face", base2.face);
            command.Parameters.Add("?hairstyle", base2.hairstyle);
            command.Parameters.Add("?haircolor", base2.haircolor);
            command.Parameters.Add("?facialhair", base2.facialhair);
            command.Parameters.Add("?level", base2.level);
            command.Parameters.Add("?zoneid", base2.zoneid);
            command.Parameters.Add("?map", base2.map);
            command.Parameters.Add("?x", base2.x);
            command.Parameters.Add("?y", base2.y);
            command.Parameters.Add("?z", base2.z);
            command.Parameters.Add("?guildid", base2.guildid);
            command.Parameters.Add("?flags", base2.flags);
            command.Parameters.Add("?rest", base2.rest);
            command.Parameters.Add("?petinfoid", base2.petinfoid);
            command.Parameters.Add("?petlevel", base2.petlevel);
            command.Parameters.Add("?petfamilyid", base2.petfamilyid);
            command.Parameters.Add("?realmid", StaticCore.RealmID);
            command.Parameters.Add("?displayid", base2.displayid);
            command.Parameters.Add("?tutorialflags", base2.tutorialflags);
            if (command.ExecuteNonQuery() < 1)
            {
                rv.Add((byte) 0x30);
                return (byte[]) rv;
            }
            rv.Add((byte) 0x2e);
            return (byte[]) rv;
        }
    }
}

