using System;
using System.IO;
using System.Reflection;
using System.Collections;

namespace eWoW
{
	public class GameDB
	{
		public DB areaTable=null;
		public DB emotesText=null;
		public DB faction=null;
		public DB factionTemplate=null;
		public DB spell=null;
		public DB spellCastTimes=null;
		public DB spellDuration=null;
		public DB spellRadius=null;
		public DB talent=null;
		public DB taxiNodes=null;
		public DB taxiPath=null;
		public DB worldMapArea=null;
		public DB worldSafeLocs=null;

		public DB creatures=null;
		public DB items=null;
		public DB classes=null;
		public DB areaTriggers=null;
		public DB gameObjects=null;
		public DB spellCost=null;
		public DB pages=null;
		public DB quests=null;

		public GameServer gameServer;
		public GameDB(GameServer gs, string dbPath)
		{
			gameServer = gs;
			foreach(MemberInfo m in GetType().GetMembers())
			{
				FieldInfo f=m as FieldInfo;
				if(f==null || !f.IsPublic || f.FieldType.Name != "DB")continue;
				f.SetValue(this, Load(dbPath, f.Name));
			}

			Hashtable h=new Hashtable();
			h["level"]=(int)1;
			h["type"]=(int)6;
			h["size"]=(float)0.5;
			h["model"]=(int)262;
			h["name"]="+SpawnPoint+";
			h["guild"]="Only GM Can See it";
			creatures.Set("creature " + Const.SpawnPointEntry.ToString(), h);
		}

		DB Load(string dbPath, string name)
		{
			// Nacitani cesty ke skriptum a dbc souborum
            string filescp = dbPath + "/scripts/" + name; // cesta ke skriptum
            string filedbc = dbPath + "/dbc/" + name; // cesta k dbc souborum

			DB db;
            // Nacitani SCP souboru

            if (File.Exists(filescp + ".scp"))
            {
                db = new DBMemory(filescp + ".scp", true, new DB.ReadSectionFunction(DB.ConvertType));
                gameServer.LogMessage("Load script " + name + " count=" + db.Count());
                return db;
            }

			ArrayList a = GetDBCStruct(name);
			if(a.Count == 0)return null;

            // Nacitani DBC souboru
            if (File.Exists(filedbc + ".dbc"))
            {
                db = new DBDBC(filedbc + ".dbc", a);
                gameServer.LogMessage("Load DBC " + name + " count=" + db.Count());
                return db;
            }

            gameServer.LogMessage("Can't load script or dbc file - filename: " + name);
            return null;
            
		}

		ArrayList GetDBCStruct(string name)
		{
			ArrayList a=new ArrayList();

			switch(name)
			{
				case "spell":
					a.Add(new DBCStruct("costType", 26, "int"));
					a.Add(new DBCStruct("cost", 27, "int"));
					break;

				case "factionTemplate":
					a.Add(new DBCStruct("ID", 0, "int"));
					a.Add(new DBCStruct("faction", 1, "int"));
					a.Add(new DBCStruct("factionGroup", 2, "int"));
					a.Add(new DBCStruct("friendGroup", 3, "int"));
					a.Add(new DBCStruct("enemyGroup", 4, "int"));
					for(ushort i=0; i<4; i++)
					{
						a.Add(new DBCStruct("friend" + i.ToString(), i+5, "int"));
						a.Add(new DBCStruct("enemy" + i.ToString(),  i+9, "int"));
					}
					break;

				case "faction":
					a.Add(new DBCStruct("ID", 0, "int"));
					a.Add(new DBCStruct("reputationIndex", 1, "int"));
					for(int i=0; i<4; i++)
						a.Add(new DBCStruct("reputationRaceMask" + i.ToString(), 2+i, "int"));
					for(int i=0; i<4; i++)
						a.Add(new DBCStruct("reputationClassMask" + i.ToString(), 6+i, "int"));
					for(int i=0; i<4; i++)
						a.Add(new DBCStruct("reputationBase" + i.ToString(), 10+i, "int"));
					for(int i=0; i<8; i++)
						a.Add(new DBCStruct("name" + i.ToString(), 14+i, "string"));
					a.Add(new DBCStruct("nameFlag", 22, "int"));
					break;

				case "worldMapArea":
					a.Add(new DBCStruct("ID", 0, "int"));
					a.Add(new DBCStruct("map", 1, "int"));
					a.Add(new DBCStruct("area", 2, "int"));
					a.Add(new DBCStruct("name", 3, "string"));
					a.Add(new DBCStruct("left", 4, "float"));
					a.Add(new DBCStruct("right", 5, "float"));
					a.Add(new DBCStruct("top", 6, "float"));
					a.Add(new DBCStruct("bottom", 7, "float"));
					break;

				case "worldSafeLocs":
					a.Add(new DBCStruct("ID", 0, "int"));
					a.Add(new DBCStruct("map", 1, "int"));
					a.Add(new DBCStruct("x", 2, "float"));
					a.Add(new DBCStruct("y", 3, "float"));
					a.Add(new DBCStruct("z", 4, "float"));
					for(int i=0; i<8; i++)
						a.Add(new DBCStruct("name" + i.ToString(), 5+i, "string"));
					a.Add(new DBCStruct("nameFlag", 13, "int"));
					break;
			}
			return a;
		}

//		void Log(string fmt, params object[] obs)
//		{
//			Const.Log("GameDB", fmt, obs);
//		}
	}
}
