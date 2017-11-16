using System;
using System.IO;
using System.Collections;

namespace eWoW
{
	public class SpawnData 
	{
		public delegate void LogMessageHandler				(string message);
		//public event LogMessageHandler						LogMessageEvent; 
         
		public ObjectType obtype=ObjectType.UNIT;
		public Position   point;
		public float      ang;
		public ushort     map=0;
		public float[]    spawnDist=null;
		public int[]      spawnEntry=null;
		public int[]      spawnMaxCount=null;
		public int[]      spawnTime=null;
		public Hashtable  data=null;

		public ArrayList  spawnUnits=null;  // -> object
		public Obj        spawnPoint=null;
		public int        spawnTick=0;

		public SpawnData()
		{
		}

		public SpawnData(DBSerial fs)
		{
			obtype=(ObjectType)fs.pack.GetByte();
			point.x=fs.pack.GetFloat();
			point.y=fs.pack.GetFloat();
			point.z=fs.pack.GetFloat();
			ang=fs.pack.GetFloat();
			map=fs.pack.GetWord();
			spawnDist=(float[])fs.Get();
			spawnEntry=(int[])fs.Get();
			spawnMaxCount=(int[])fs.Get();
			spawnTime=(int[])fs.Get();
			int havemap=(int)fs.Get();
			if(havemap==1)
			{
				data=fs.Get() as Hashtable;
			}
		}

		public void Add(DBSerial fs)
		{
			fs.pack.Add((byte)obtype).Add(point.x, point.y, point.z, ang).Add(map);
			fs.Add(spawnDist);
			fs.Add(spawnEntry);
			fs.Add(spawnMaxCount);
			fs.Add(spawnTime);
			if(data!=null)
			{
				fs.Add((int)1);
				fs.Add(data);
			} 
			else 
			{
				fs.Add((int)0);
			}
		}
	}


	public class Spawn
	{
		public delegate void LogMessageHandler				(string message);
		public event LogMessageHandler						LogMessageEvent;

		public ArrayList worldData=null;
		private GameServer gameServer;
		
		public Spawn(GameServer gs)
		{
			gameServer = gs;
		}

		public void Load(string dbPath)
		{
			string bin=dbPath + "/saves/world.bin";
			string file=dbPath + "/saves/world.save";
			worldData=new ArrayList();
			if(File.Exists(bin) && File.GetLastWriteTime(bin)>File.GetLastWriteTime(file))
			{
				try 
				{
					using(FileStream fs=new FileStream(bin, FileMode.Open, FileAccess.Read))
					{
						worldData=(new DBSerial(fs)).Deserialize() as ArrayList;
					}
				}
				catch
				{
				}
			}

			if(worldData.Count==0)
			{
				new DBMemory(file, false, new DB.ReadSectionFunction(SetWorldData));
				if(worldData.Count>0)
				{
					using(FileStream fs=new FileStream(bin, FileMode.Create, FileAccess.Write))
					{
						(new DBSerial(fs)).Serialize(worldData);
					}
				}
			}
		}

		void SetWorldData(string sec, Hashtable table)
		{
			if(sec==null)return;

			DB.ConvertType(sec, table);
			if(!table.Contains(sec))return;

			Hashtable data=table[sec] as Hashtable;
			table.Remove(sec);
			if(!data.Contains("TYPE"))return;

			ObjectType type=(ObjectType)(int)data["TYPE"];
			switch(type)
			{
				case ObjectType.AREATRIGGER:
				case ObjectType.CORPSE:
				case ObjectType.GAMEOBJECT:

					break;

				case ObjectType.UNIT:  // only add spawn object
				{
					if( (int)data["ENTRY"] != Const.SpawnPointEntry )break;
					int[] spawn=data["SPAWN"] as int[];
					if(spawn==null)break;

					SpawnData d=new SpawnData();
					float[] xyz=(float[])data["XYZ"];
					d.point=new Position(xyz[0], xyz[1], xyz[2]);
					d.ang=xyz[3];
					if(data.Contains("MAP"))d.map=(ushort)(int)data["MAP"];
					d.obtype=type;

					d.spawnEntry=new int[spawn.Length/2];
					d.spawnMaxCount=new int[spawn.Length/2];
					for(int i=0; i<spawn.Length-1; i+=2)
					{
						d.spawnEntry[i/2]=spawn[i];
						d.spawnMaxCount[i/2]=spawn[i+1];
					}

					if(data.Contains("SPAWNTIME"))d.spawnTime=(int[])data["SPAWNTIME"] ;
					if(data.Contains("SPAWNDIST"))d.spawnDist=(float[])data["SPAWNDIST"];

					worldData.Add( d );
					break;
				}
			}
		}


		public void Save(string dbPath)
		{
			string bin=dbPath + "/saves/world.bin";
			using(FileStream fs=new FileStream(bin, FileMode.Create, FileAccess.Write))
			{
				(new DBSerial(fs)).Serialize(worldData);
			}
		}


//		void Log(string fmt, params object[] obs)
//		{
//			Const.Log("Spawn", fmt, obs);
//		}

		Obj SpawnObj(SpawnData data, uint entry)
		{
			if(data.obtype==ObjectType.UNIT)
			{
				Unit u=new Unit( gameServer );

				Position pos=data.point;
				SpawnData p=null;
				if( entry != Const.SpawnPointEntry )
				{
					p=data;
					gameServer.PPoint.GetDest(data.map, pos, Const.rand.Next( 6 ), Const.rand.Next( (int)p.spawnDist[0] ), out pos);
				}
				if( !u.Create(entry, data.map, pos, data.ang, p) )
				{
					if (LogMessageEvent != null)
						LogMessageEvent("SpawnObj ERROR: unknown creature {0} entry :" + entry);
					return null;
				}
				gameServer.AddObj(u);
				return u;
			}
			return null;
		}

		public void TrySpawnObj(ushort map, Position pos)
		{
			for(int i=0; i<worldData.Count; i++)
			{
				SpawnData d=(SpawnData)worldData[i];
				if(d.map != map || d.point.Distance(pos) > Const.UPDATE_DISTANCE || d.spawnTick==-1 || d.spawnTick > Const.Tick)
					continue;

				uint cnt=0;
				for(int j=0; j<d.spawnMaxCount.Length; j++)
				{
					cnt+=(uint)d.spawnMaxCount[j];
				}

				// need respawn?
				if(d.spawnUnits != null)
				{
					if(d.spawnUnits.Count>=cnt)continue;
				} 
				else 
				{
					d.spawnUnits=new ArrayList();
					d.spawnPoint=SpawnObj(d, Const.SpawnPointEntry);
				}

				uint[] count=new uint[d.spawnMaxCount.Length];
				foreach(Obj ob in d.spawnUnits)
				{
					for(int j=0; j<d.spawnEntry.Length; j++)
					{
						if(ob.Entry == d.spawnEntry[j])count[j]++;
					}
				}
				for(int j=0; j<count.Length; j++)
				{
					if(d.spawnMaxCount[j] == count[j])continue;

					if (LogMessageEvent != null)
						LogMessageEvent("spawn {0} {1} entry " + d.spawnEntry[j] + " count " + Convert.ToString( d.spawnMaxCount[j]-count[j] ) );

					while(count[j]<d.spawnMaxCount[j])
					{
						Obj ob=SpawnObj(d, (uint)d.spawnEntry[j]);
						if(ob==null)break;
						count[j]++;
						d.spawnUnits.Add( ob );
					}
				}

				d.spawnTick=-1;
			}
		}


	}
}
