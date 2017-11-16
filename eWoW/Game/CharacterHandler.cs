using System;
using System.Collections;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace eWoW
{
	public class CharacterHandler
	{
		private GameServer gameServer;
		#region constructor
		public CharacterHandler(GameServer gs, PlayerConnection c, string chars)
		{
			gameServer = gs;
			if(chars!=null)
			{
				string[] schars = chars.Split(' ');
				foreach(string s in schars)
				{
					charids.Add( s );
				}
			}

			c.AddHandler(OP.CMSG_CHAR_CREATE, new DoMessageFunction(DoMsgCreate), this);
			c.AddHandler(OP.CMSG_CHAR_ENUM, new DoMessageFunction(DoMsgEnum), this);
			c.AddHandler(OP.CMSG_CHAR_DELETE, new DoMessageFunction(DoMsgDelete), this);
			c.AddHandler(OP.CMSG_PLAYER_LOGIN, new DoMessageFunction(DoMsgLogin), this);
		}
		#endregion

		ArrayList charids = new ArrayList();

		int Side(RACE r)
		{
			switch(r)
			{
				case RACE.HUMAN:
				case RACE.NIGHT_ELF:
				case RACE.GNOME:
				case RACE.DWARF: 
					return 1;

				case RACE.ORC:
				case RACE.UNDEAD:
				case RACE.TROLL:
				case RACE.TAUREN:
					return 2;
			}
			return 0;
		}

        void DoMsgCreate(eWoW.OP code, PlayerConnection conn)
		{
			if(charids.Count >= 10)
			{
                conn.Send(OP.SMSG_CHAR_CREATE, new byte[] { (byte)CHAR.CREATE_MAX_PLAYER_REALM });  
				return;
			}

			string name;
			conn.Seek(2).Get(out name);

			if(gameServer.GetCharacter(name) != 0)
			{
                gameServer.LogMessage( "Create character error nametaken:" + conn.userName + " name: " + name );
                conn.Send(OP.SMSG_CHAR_CREATE, new byte[] { (byte)CHAR.CREATE_NAME_IN_USE });
                return;
			}

			Character c = new Character(gameServer);

			if(!c.CreateNew(conn, name))
			{
                conn.Send(OP.SMSG_CHAR_CREATE, new byte[] { (byte)CHAR.CREATE_FAILED });
				return;
			}

			if(gameServer.Type.ToLower() == "pvp")
			{
				int side = Side(c.Race);
				foreach(string id in charids)
				{
					Character nc=gameServer.LoadCharacter(conn, id);
					if(nc != null && Side(nc.Race) != side )
					{
						gameServer.DelCharacter(c);
						gameServer.LogMessage( "CMSG_CHAR_CREATE NotSameSide" + conn.userName + " name: " + name );
                        conn.Send(OP.SMSG_CHAR_CREATE, new byte[] { (byte)CHAR.CREATE_NOT_SAME_SIDE });
						return;
					}
				}
			}
			gameServer.AddCharacter(name, c.GUID, (byte)c.Race, (byte)c.Gender, (byte)c.Class);
			gameServer.AddObj(c);

			charids.Add( name );
			string str = "";
			foreach(string n in charids)
			{
				str+=n + " ";
			}
			gameServer.SetChar(conn.userName, str.Trim());

            conn.Send(OP.SMSG_CHAR_CREATE, new byte[]{ (byte)CHAR.CREATE_OK }); // create ok
		}

        void DoMsgEnum(eWoW.OP code, PlayerConnection conn)
		{
			gameServer.LogMessage( "DoMsgEnum OP: " + code );

			ByteArrayBuilder pack = new ByteArrayBuilder(false);
            
            pack.Add((byte)0);
			string idremove = null;

			foreach(string n in charids)
			{
				Character c = gameServer.LoadCharacter(conn, n);
				
                if(c == null)
                { 
                    idremove = n; 
                    continue; 
                }

				pack[0]++;
				
                c.GetEnumData(pack);
			}

			if(idremove != null)
                charids.Remove(idremove);

			//  Odstraneno jelikoz to hazelo chybu error retriving characters.
            //  while(pack.Length <= 159) 
            //    pack.Add((uint)0);  // need >= 159*/

			conn.Send(OP.SMSG_CHAR_ENUM, pack);
        
		}

        void DoMsgDelete(eWoW.OP code, PlayerConnection conn)
		{
			ulong guid;
			conn.Seek(2).Get(out guid);
			gameServer.LogMessage( "OP: " + code + "GUID: " + guid);

			Character c = gameServer.LoadCharacter(conn, guid);
			if(c != null)
			{
				gameServer.DelCharacter(c);
				charids.Remove(c.Name);
				gameServer.DelObj(c);
			}
            conn.Send(OP.SMSG_CHAR_DELETE, new byte[] { (byte)CHAR.DELETE_OK });
		}

        void DoMsgLogin(eWoW.OP code, PlayerConnection conn)
		{
			uint guid;
			conn.Seek(2).Get(out guid);

			Character p=gameServer.LoadCharacter(conn, guid);
			if(p==null)
			{
				conn.Dispose();
				return;
			}

			foreach(string n in charids)
			{
				if(n==p.Name)continue;

				Character c=gameServer.LoadCharacter(conn, n);
				if(c == null)continue;

				gameServer.DelObj(c);
			}

			gameServer.LogMessage( "Player logging in: ", p.Name + " from: " + conn.sock.LocalEndPoint.ToString());
			p.Login(conn);

            string str = "Vitej na MyWoW-test server.";

            //foreach (string s in str.Split('\n'))
           // {
               // if (s == "") continue;
                p.MessageChat(CHAT.SYSTEM, 0, str, p.Name);
            //}*/

            
		}
	}
}