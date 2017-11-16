using System;
using System.Collections;

namespace eWoW
{
	/// <summary>
	/// QueryHandler 的摘要说明。
	/// </summary>
	public class QueryHandler
	{
		private GameServer gameServer;
		public QueryHandler(GameServer gs, PlayerConnection c)
		{
			gameServer = gs;
			c.AddHandler( OP.CMSG_NAME_QUERY, new DoMessageFunction( NameQuery ), c.player);
            c.AddHandler(OP.CMSG_MEETING_STONE_INFO, new DoMessageFunction(MeetingStoneQuery), c.player);
			c.AddHandler( OP.CMSG_GMTICKET_GETTICKET, new DoMessageFunction( GMTicketQuery ), c.player);
			c.AddHandler( OP.CMSG_QUERY_TIME, new DoMessageFunction( TimeQuery ), c.player);
			c.AddHandler( OP.MSG_QUERY_NEXT_MAIL_TIME, new DoMessageFunction( NextMailTimeQuery ), c.player);

			c.AddHandler(OP.CMSG_ITEM_QUERY_SINGLE, new DoMessageFunction(QuerySingle), c.player);
			c.AddHandler( OP.CMSG_CREATURE_QUERY, new DoMessageFunction( CreatureQuery ), c.player);
			// c.AddHandler( OP.MSG_CORPSE_QUERY, new DoMessageFunction( CorpseQuery ), c.player);
		}

		void NextMailTimeQuery(OP code, PlayerConnection c)
		{
			//gameServer.LogMessage("NextMailTimeQuery: code: " + code);
			c.Send(OP.MSG_QUERY_NEXT_MAIL_TIME, new byte[]{0, 0, 0, 0});
		}

		void GMTicketQuery(OP code, PlayerConnection c)
		{
			//gameServer.LogMessage("GMTicketQuery: code: " + code);
			c.Send(OP.SMSG_GMTICKET_GETTICKET, new byte[]{1, 0, 0, 0});
		}

		void TimeQuery(OP code, PlayerConnection c)
		{
			//gameServer.LogMessage("TimeQuery: code: " + code);
			ByteArrayBuilder b=new ByteArrayBuilder(false);
			b.Add( Const.GetTimeStamp() );
			c.Send(OP.SMSG_QUERY_TIME_RESPONSE, b);
		}

		void MeetingStoneQuery(OP code, PlayerConnection c)
		{
			//gameServer.LogMessage("MeetingStoneQuery: code: " + code);
            c.Send(OP.SMSG_MEETING_STONE_INFO, new byte[8]);
		}

		void NameQuery(OP code, PlayerConnection c)
		{
			uint guid;
			c.Seek(2).Get(out guid);

			ByteArrayBuilder pack=new ByteArrayBuilder(false);
			pack.Add( guid , 0);

			byte race,gender, cls;
			string nm=gameServer.GetCharacter(guid, out race, out gender, out cls);
			if(nm!=null)
			{
				pack.Add( nm ).Add( (uint)race, (uint)gender, (uint)cls);
			} 
			else 
			{
				pack.Add( "Unknown" ).Add( (uint)0, 0, 0);
			}
			c.Send(OP.SMSG_NAME_QUERY_RESPONSE, pack);
		}


		uint Get(Hashtable data, string name, uint def)
		{
			try 
			{
				if(data.Contains(name))return (uint)(int)data[name];
			}
			catch(FormatException e)
			{
				gameServer.LogMessage( "ItemHandler error name:" + name + " error: "+ e.Message );
			}
			return def;
		}

		float Get(Hashtable data, string name, float def)
		{
			try 
			{
				if(data.Contains(name))return (float)data[name];
			}
			catch(FormatException e)
			{
				gameServer.LogMessage( "ItemHandler error name:" + name + " error: "+ e.Message );
			}
			return def;
		}

		/*
		3A 09 00 00 04 00 00 00 06 00 00 00 57 6F 72 6E 20 57 6F 6F 64 65 6E 20 53 68 69 65 6C 64 00 00 00 00 2A 49 00 00 00 00 00 00 00 00 00 00 07 00 00 00 01 00 00 00 0E 00 00 00 FF 7F 00 00 FF 01 00 00 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 04 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 14 00 00 00
		3A 09 00 00 04 00 00 00 06 00 00 00 57 6F 72 6E 20 57 6F 6F 64 65 6E 20 53 68 69 65 6C 64 00 00 00 00 2A 49 00 00 00 00 00 00 00 00 00 00 07 00 00 00 01 00 00 00 0E 00 00 00 FF 7F 00 00 FF 01 00 00 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 14 00 00 00

		E8 17 00 00 
		04 00 00 00 
		00 00 00 00 
		52 65 63 72 75 69 74 27 73 20 53 68 69 72 74 00 
		00 
		00 
		00 

		FF 26 00 00 
		01 00 00 00 
		00 00 00 00 
		01 00 00 00 // bprice
		01 00 00 00 // sprice
		04 00 00 00 // itype
		FF 7F 00 00 // classes
		FF 01 00 00 // races
		01 00 00 00 // level
		00 00 00 00 // reqlevel
		00 00 00 00 // skill
		00 00 00 00 // skillrank
		00 00 00 00 // 2
		00 00 00 00 // 3
		00 00 00 00 // 4
		00 00 00 00 // maxcou
		01 00 00 00 // stackable
		00 00 00 00 // containerslots

		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 
		FF FF FF FF 00 00 00 00 

		00 00 00 00 00 00 00 00 FF FF FF FF 
		00 00 00 00 00 00 00 00 FF FF FF FF 
		00 00 00 00 00 00 00 00 FF FF FF FF 
		00 00 00 00 00 00 00 00 FF FF FF FF 
		00 00 00 00 00 00 00 00 FF FF FF FF 

																																													00 00 00 00 
		00 00 00 00 00 00 00 00 
		00 00 00 00 00 00 00 00 
		00 00 00 00 00 00 00 00 
		00 00 00 00 00 00 00 00 
		00 00 00 00 


		FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 

		00 00 00 00 // bonding
		00          // desc
		00 00 00 00 // Pagetext
		00 00 00 00 // LanguageID
		00 00 00 00 // PageMaterial
		00 00 00 00 // StartQuestID
		00 00 00 00 // LockID
		07 00 00 00 // material
		00 00 00 00 // Sheathetype
		00 00 00 00 // Unknown1
		00 00 00 00 // block
		00 00 00 00 // Unknown3
		00 00 00 00 // durability
		*/

		void QuerySingle(OP code, PlayerConnection c)
		{
			uint entry;
			ulong guid;
			c.Seek(2).Get(out entry).Get(out guid);

			Item n = new Item( gameServer );
			Hashtable data=n.GetData(entry);
			if(data==null)
			{
				gameServer.LogMessage("code not found! -> QuerySingle code: " + code + " entry: " + entry + "  guid:" + guid);
				return;
			}

			gameServer.LogMessage("QuerySingle code: " + code + " entry: " + entry + "  guid:" + guid);

			ByteArrayBuilder pack=new ByteArrayBuilder(false);
			pack.Add(entry);
			pack.Add( Get(data, "class", 1) );
			pack.Add( Get(data, "subclass", 0) );
			pack.Add( data["name"] as string );
			if(data.Contains("questname"))pack.Add( data["questname"] as string ); else pack.Add((byte)0);
			if(data.Contains("name3"))pack.Add( data["name3"] as string ); else pack.Add((byte)0);
			if(data.Contains("name4"))pack.Add( data["name4"] as string ); else pack.Add((byte)0);
			pack.Add( Get(data, "model", 0) );
			pack.Add( Get(data, "quality", 1) );
			pack.Add( Get(data, "flags", 0) );
			pack.Add( Get(data, "buyprice", 0) );
			pack.Add( Get(data, "sellprice", 0) );
			pack.Add( Get(data, "inventorytype", 0) );
			pack.Add( Get(data, "classes", 0x7fff) );
			pack.Add( Get(data, "races", 0x1ff) );
			pack.Add( Get(data, "level", 1) );
			pack.Add( Get(data, "reqlevel", 1) );
			pack.Add( Get(data, "skill", 0) );
			pack.Add( Get(data, "skillrank", 0) );
			pack.Add( (uint)0, 0, 0);
			pack.Add( Get(data, "maxcount", 0) );
			pack.Add( Get(data, "stackable", 1) );
			pack.Add( Get(data, "containerslots", 0) );

			int[] bonus=data["bonus"] as int[];
			for(int i=0; i<10; i++)
			{
				if(bonus!=null && i<bonus.Length/2)
				{
					pack.Add((uint)bonus[i*2], (uint)bonus[i*2+1]);
				} 
				else 
				{
					pack.Add((uint)0xffffffff, 0);
				}
			}

			int[] damage=data["damage"] as int[];
			for(int i=0; i<5; i++)
			{
				if(damage!=null && i<damage.Length/3)
				{
					pack.Add((float)damage[i*3], (float)damage[i*3+1], (uint)damage[i*3+2]);
				} 
				else 
				{
					pack.Add((uint)0, 0, (uint)0xffffffff);
				}
			}

			pack.Add( Get(data, "resistance1", 0) );
			pack.Add( Get(data, "resistance2", 0) );
			pack.Add( Get(data, "resistance3", 0) );
			pack.Add( Get(data, "resistance4", 0) );
			pack.Add( Get(data, "resistance5", 0) );
			pack.Add( Get(data, "resistance6", 0) );
			pack.Add( Get(data, "resistance7", 0) );
			pack.Add( Get(data, "delay", 3000) );
			pack.Add( (uint)0 );

			int[] spell=data["spell"] as int[];
			for(int i=0; i<5; i++)
			{
				if(spell!=null && i<spell.Length/6)
				{
					pack.Add((uint)spell[i*6],
						(uint)spell[i*6+1],
						(uint)spell[i*6+2],
						(uint)spell[i*6+3],
						(uint)spell[i*6+4],
						(uint)spell[i*6+5]);
				} 
				else 
				{
					pack.Add((uint)0xffffffff, 0, 0, 0, 0, 0);
				}
			}

			pack.Add( Get(data, "bonding", 0) );
			pack.Add( (byte)0 );
			pack.Add( Get(data, "pagetext", 0) );
			pack.Add( Get(data, "language", 0) );
			pack.Add( Get(data, "pagematerial", 0) );
			pack.Add( Get(data, "startquest", 0) );
			pack.Add( Get(data, "lockid", 0) );
			pack.Add( Get(data, "material", 0) );
			pack.Add( Get(data, "sheath", 0) );
			pack.Add( Get(data, "ukn1", 0) );
			pack.Add( Get(data, "block", 0) );
			pack.Add( Get(data, "ukn3", 0) );
			pack.Add( Get(data, "durability", 0) );

			c.Send(OP.SMSG_ITEM_QUERY_SINGLE_RESPONSE, pack);
		}

		/*
		// query packet
		79 32 00 00 
		49 6D 70 20 4D 69 6E 69 6F 6E 00   // name
		00 
		00 
		00 
		43 43 43 43 43 43 43 43 43 43 43 43 43 43 00  // guild name
		06 00 10 00 // flags1
		00 00 00 00 
		04 00 00 00 // type
		02 00 00 00 // unk4
		00 00 00 00 
		00 00 00 00

		// MSG_CORPSE_QUERY
		// {01 00 00 00 00 8F 56 D1 44 7B AE D1 44 0A 57 F3 42 00 00 00 00 }
		*/

		void CreatureQuery(OP code, PlayerConnection c)
		{
			uint entry;
			ulong guid;
			c.Seek(2).Get(out entry).Get(out guid);

			Hashtable data=gameServer.DB.creatures.Get("creature " + entry.ToString());
			if(data==null)
			{
				gameServer.LogMessage("CreatureQuery code not found! : " + code + " entry: " + entry + "  guid:" + guid);
				return;
			}
			gameServer.LogMessage("CreatureQuery code: " + code + " entry: " + entry + "  guid:" + guid);

			ByteArrayBuilder pack=new ByteArrayBuilder(false);
			pack.Add(entry);
			pack.Add(data["name"] as string);
			if(data.Contains("name2"))pack.Add(data["name2"] as string); else pack.Add((byte)0);
			if(data.Contains("name3"))pack.Add(data["name3"] as string); else pack.Add((byte)0);
			if(data.Contains("name4"))pack.Add(data["name4"] as string); else pack.Add((byte)0);
			if(data.Contains("guild"))pack.Add(data["guild"] as string); else pack.Add((byte)0);
			pack.Add( Get(data, "flags1", 0) );
			pack.Add( (uint)0 );
			pack.Add( Get(data, "type", 0) );
			pack.Add( Get(data, "unk4", 0) );
			pack.Add( (uint)0 );
			pack.Add( (uint)0 );
			c.Send(OP.SMSG_CREATURE_QUERY_RESPONSE, pack);
		}

	}
}
