using System;
using System.Text;
using System.IO;
using System.Collections;

namespace eWoW
{
	public delegate bool FindCompare(object ob);

	class FindString
	{
		string v;
		public FindString(string v)
		{
			this.v=v;
		}
		public bool Compare(object ob)
		{
			return v==(string)ob;
		}
	};

	public class DBSerial
	{
		Stream stream;
		public DBSerial(Stream s)
		{
			stream=s;
		}

		Hashtable codes=new Hashtable();
		public ByteArrayBase pack=null;
		public object Deserialize()
		{
			byte[] b=new byte[4];
			stream.Read(b, 0, b.Length);

			pack=new ByteArray(b);
			uint pos=pack.GetDWord();

			stream.Seek(pos, SeekOrigin.Begin);
			b=new byte[stream.Length - pos];
			stream.Read(b, 0, b.Length);
			pack=new ByteArray(b);

			codes.Clear();
			ArrayList n=Get() as ArrayList;
			for(int i=0; i<n.Count; i++)
			{
				codes.Add((uint)i, n[i]);
			}

			stream.Seek(4, SeekOrigin.Begin);
			b=new byte[pos - 4];
			stream.Read(b, 0, b.Length);
			pack=new ByteArray(b);

			return Get();
		}

		public object Get()
		{
			byte type=pack.GetByte();
			switch(type)
			{
				case 0:
				{
					int n=(int)pack.GetDWord();
					return n;
				}
				case 1:
				{
					uint cnt=pack.GetDWord();
					int[] n=new int[cnt];
					for(uint i=0; i<cnt; i++)
					{
						n[i]=(int)pack.GetDWord();
					}
					return n;
				}
				case 2:
				{
					float n=pack.GetFloat();
					return n;
				}
				case 3:
				{
					uint cnt=pack.GetDWord();
					float[] n=new float[cnt];
					for(uint i=0; i<cnt; i++)
					{
						n[i]=pack.GetFloat();
					}
					return n;
				}
				case 4:
				{
					return pack.GetString();
				}
				case 5:
				{
					uint c=pack.GetDWord();
					return codes[c];
				}
				case 6:
				{
					uint cnt=pack.GetDWord();
					return pack.GetArray((int)cnt);
				}
				case 10:
				{
					uint cnt=pack.GetDWord();

					ArrayList n=new ArrayList();
					while(cnt>0)
					{
						n.Add( Get() );
						cnt--;
					}
					return n;
				}
				case 11:
				{
					uint cnt=pack.GetDWord();

					Hashtable n=new Hashtable();
					while(cnt>0)
					{
						object ob=Get();
						n[ ob ] = Get();
						cnt--;
					}
					return n;
				}

				case 12: // SpawnData
				{
					return new SpawnData(this);
				}

				case 13: // MapPosition
				{
					return new MapPosition(this);
				}
			}
			return null;
		}

		public void Serialize(object h)
		{
			pack=new ByteArrayBuilder();
			pack.Add((uint)0);
			Add(h);
			WriteAll();

			long pos=stream.Position;
			pack.Add((uint)pos);
			stream.Seek(0, SeekOrigin.Begin);
			WriteAll();
			stream.Seek(pos, SeekOrigin.Begin);

			ArrayList n=new ArrayList();
			n.AddRange(new int[codes.Count]);
			IDictionaryEnumerator pe=codes.GetEnumerator();
			while(pe.MoveNext())
			{
				n[ (int)pe.Value ] = (string)pe.Key;
			}
			Add(n);
			WriteAll();
		}

		void WriteAll()
		{
			if(pack.Length==0)return;

			byte[] b=pack.GetArray(0, pack.Length);
			pack.Length=0;

			stream.Write(b, 0, b.Length);
		}

		public void Add(object o)
		{
			if(o is int)
			{
				pack.Add((byte)0)
					.Add((uint)(int)o);
			}
			else if(o is int[])
			{
				int[] c=(int[])o;
				pack.Add((byte)1).Add((uint)c.Length);
				for(int i=0; i<c.Length; i++)
					pack.Add((uint)c[i]);
			}
			else if(o is float)
			{
				pack.Add((byte)2)
					.Add((float)o);
			}
			else if(o is float[])
			{
				float[] fo=(float[])o;
				pack.Add((byte)3)
					.Add((uint)fo.Length)
					.Add(fo);
			}
			else if(o is string)
			{
				pack.Add((byte)4)
					.Add((string)o);
			}
			else if(o is StringBuilder)
			{
				pack.Add((byte)4)
					.Add((o as StringBuilder).ToString());
			}
			else if(o is byte[])
			{
				byte[] bo=o as byte[];
				pack.Add((byte)6)
					.Add((uint)bo.Length)
					.Add(bo);
			}
			else if(o is ArrayList)
			{
				ArrayList h=(ArrayList)o;
				pack.Add( (byte)10 )
					.Add( (uint)h.Count);
				foreach(object oh in h)Add(oh);
			}
			else if(o is Hashtable)
			{
				Hashtable h=(Hashtable)o;

				pack.Add( (byte)11 )
					.Add( (uint)h.Count);

				IDictionaryEnumerator pe=h.GetEnumerator();
				while(pe.MoveNext())
				{
					if(pe.Key is String)
						Add((string)pe.Key);
					else
						Add((int)pe.Key);
					Add(pe.Value);

					WriteAll();
				}
			}
			else if(o is SpawnData)
			{
				pack.Add( (byte)12 );
				((SpawnData)o).Add(this);
				WriteAll();
			}
			else if(o is MapPosition)
			{
				pack.Add( (byte)13 );
				((MapPosition)o).Add(this);
				WriteAll();
			}
			else 
			{
				throw new FormatException("unknown object " + o.GetType().Name);
			}
		}

		public void Add(string s)
		{
			int idx;
			object n=codes[s];
			if(n==null)
			{
				idx=codes.Count;
				codes.Add(s, idx);
			} 
			else 
			{
				idx=(int)codes[s];
			}
			pack.Add((byte)5)
				.Add((uint)idx);
		}

	}

	public abstract class DB 
	{
		public abstract ArrayList FindByTag(string tag, FindCompare f);
		public abstract ArrayList Keys();
		public abstract Hashtable Get(string nm);
		public abstract int  Count();

		public virtual ArrayList FindByTag(string tag, string v)
		{
			return FindByTag(tag, new FindCompare( (new FindString(v)).Compare ) );
		}

		public virtual void Set(string nm, Hashtable row)
		{
		}

		public virtual object Get(string idx, string row)
		{
			Hashtable n=Get(idx);
			if(n==null)return null;
			return n[row];
		}

		public delegate void ReadSectionFunction(string sec, Hashtable h);
		public static bool ReadFile(string file, Hashtable data, ReadSectionFunction readOneSection)
		{
			StreamReader r=new StreamReader(file, System.Text.Encoding.Default);
			string line;
			string sec=null;
			while( (line=r.ReadLine()) != null )
			{
				line=FixMacro( line.Replace('\t', ' ') );
				if(line=="")continue;

				if(line[0]=='[')
				{
					if(readOneSection!=null)readOneSection(sec, data);
					sec=line.Substring(1, line.Length-2);
					data.Remove(sec);
					continue;
				}
				int pos=line.IndexOf("=");
				if(pos<0)continue;

				Hashtable h;
				if(sec==null)
				{
					h=data;
				} 
				else 
				{
					h=data[ sec ] as Hashtable;
					if(h==null)
					{
						h=new Hashtable();
						data[ sec ]=h;
					}
				}
				string key=line.Substring(0, pos).Trim();
				if(h.Contains(key))
				{
					object v=h[key];
					if(v is StringBuilder)
					{
						StringBuilder sv=(StringBuilder)v;
						sv.Append("\t");
						sv.Append(line.Substring(pos+1).Trim());
					} 
					else 
					{
						h[key]=new StringBuilder( (v as string) + "\t" + line.Substring(pos+1).Trim() );
					}
				} 
				else 
				{
					h[key]=line.Substring(pos+1).Trim();
				}
			}
			r.Close();
			if(readOneSection!=null)readOneSection(sec, data);
			return true;
		}

		static string FixMacro(string line)
		{
			int pos=line.IndexOf("//");
			if(pos>=0)line=line.Substring(0, pos);
			pos=line.IndexOf(";");
			if(pos>=0)line=line.Substring(0, pos);
			line=line.Trim();
			if(line=="")return "";

			int start=0;
			string ret=line;
			while(start<line.Length)
			{
				pos=line.IndexOf('#', start);
				if(pos<0)break;
				start=pos+1;

				int cnt=0;
				while(cnt<40)
				{
					if(pos+cnt>=line.Length)break;
					char ch=line[pos+cnt];
					if(ch=='#' || (ch>='a' && ch<='z') || (ch>='A' && ch<='Z') || (ch>='0' && ch<='9') || ch=='_')
						cnt++;
					else
						break;
				}
				string s=line.Substring(pos, cnt);
				if(s.StartsWith("#RACE_"))
				{
					for(RACE t=RACE.HUMAN; t<=RACE.GOBLIN; t++)
					{
						if(s=="#RACE_"+t.ToString())ret=ret.Replace(s, ((int)t).ToString());
					}
				}
				else if(s.StartsWith("#CLASS_"))
				{
					for(CLASS t=CLASS.WARRIOR; t<=CLASS.DRUID; t++)
					{
						if(s=="#CLASS_"+t.ToString())ret=ret.Replace(s, ((int)t).ToString());
					}
				}
				else ret="";
			}
			return ret;
		}

		static int ParseNumber(string v)
		{
			if(v=="")return 0;
			if(v[0]=='0')return int.Parse(v, System.Globalization.NumberStyles.HexNumber);
			return int.Parse(v);
		}

		static object GetInt(string vs)
		{
			if(vs.IndexOf(' ')>0 || vs.IndexOf('\t')>0)
			{
				string[] vss=vs.Split(' ', '\t');
				int[] va=new int[vss.Length];
				for(int i=0; i<va.Length; i++)
				{
					va[i]=ParseNumber(vss[i]);
				}
				return va;
			} 
			else 
			{
				return ParseNumber(vs);
			}
		}

		static object GetFloat(string vs)
		{
			if(vs.IndexOf(' ')>0 || vs.IndexOf('\t')>0)
			{

				string[] vss=vs.Split(' ', '\t');
				float[] va=new float[vss.Length];
				for(int i=0; i<va.Length; i++)
				{
					va[i]=float.Parse(vss[i]);
				}
				return va;
			} 
			else 
			{
				return float.Parse(vs);
			}
		}

		static object GetLootHash(string vs)
		{
			string[] vss=vs.Split(' ', '\t');
			int[] v=new int[vss.Length];
			for(int i=0; i<vss.Length-1; i+=2)
			{
				v[i]=(int)GetInt(vss[i]);
				v[i+1]=(int)( (float)GetFloat(vss[i+1])*10000 );
			}
			return v;
		}

		static object GetPP(string vs)
		{
			string[] vss=vs.Split('\t');
			ArrayList n=new ArrayList();
			foreach(string v in vss)
			{
				n.Add( new MapPosition( GetFloat(v) as float[] ) );
			}
			n.Sort();
			return n;
		}

		public static void ConvertType(string sec, Hashtable table)
		{
			if(sec==null)return;
			Hashtable h=table[sec] as Hashtable;
			if(h==null)return;

			ArrayList hname=new ArrayList();
			hname.AddRange(h.Keys);

			string name="";
			string vs="";
			try 
			{
				foreach(string _name in hname)
				{
					name=_name;

					object v=null;
					vs=h[name] as string;
					if(vs==null)
						vs=(h[name] as StringBuilder).ToString();
					switch(name.ToLower())
					{
							// items.scp
						case "skill": 
						case "stackable": 
						case "class": 
						case "subclass": 
						case "model": 
						case "quality":
						case "buyprice":
						case "sellprice":
						case "inventorytype":
						case "classes":
						case "level":
						case "races":
						case "reqlevel":
						case "delay":
						case "language":
						case "material":
						case "sheath":
						case "durability":
					
							// classes.scp
						case "startmap":
						case "startzone":
						case "startpos":
						case "startstats":
						case "bodyfemale":
						case "bodymale":
						case "health":
						case "healthmodifier":
						case "attackpower":
						case "attacktime":
						case "powermod":
						case "item":
						
							// creatures.scp
						case "npcflags":
						case "maxhealth":
						case "maxmana":
						case "faction":
						case "bounding_radius":
						case "combat_reach":
						case "attack":
						case "sell":
					    case "flags1":
						case "type":
						case "questscript":
						
						
					    // world.save
					    case "map":
						case "spawntime":
						case "spawn":
						case "entry":
						case "gtype":

							// player.save
						case "race":
						case "zone":
						case "maxpowers":
						case "buttons":
						case "slot":
						case "resists":
						case "spell":
						case "flags":
						case "guid":
						case "expl":
						case "tutorial":
						case "link":
						case "resistance1":
						case "resistance2":
						case "resistance3":
						case "resistance4":
						case "resistance5":
						case "resistance6":
						case "resistance7":
							v=GetInt(vs);
							break;

						
						case "xyz":
						case "spawndist":
						case "bindpoint":
						case "size":
							v=GetFloat(vs);
							break;

                        case "damage":
							if(sec.StartsWith("item"))
								v=GetInt(vs);
							else
								v=GetFloat(vs);
							break;

						case "loot":
							v=GetLootHash(vs);
							break;

						case "pp":
							v=GetPP(vs);
							break;
					}
					if(v!=null)h[name]=v;
				}
			}
			catch(FormatException e)
			{
				Const.Log("DB", "INVALID {0}/{1}=\"{2}\" {3}", sec, name, vs, e.Message);
				table.Remove(sec);
			}
		}

	};



	public class DBMemory : DB
	{
		Hashtable data=new Hashtable();

		public DBMemory()
		{
		}

		public DBMemory(string file)
		{
			ReadFile(file, data, null);
		}

		public DBMemory(string file, bool bCacheAble, ReadSectionFunction func)
		{
			if(bCacheAble)
			{
				string bin=file + ".cache";
				if( File.Exists(bin) && File.GetLastWriteTime(bin) > File.GetLastWriteTime(file) )
				{
					try 
					{
						using(FileStream fs=new FileStream(bin, FileMode.Open, FileAccess.Read))
						{
							data=(new DBSerial(fs)).Deserialize() as Hashtable;
							return;
						}
					}
					catch(Exception e)
					{
						Const.Log("DB", "load {0} ERROR: {1}", bin, e.Message);
					}
				}
			}

			ReadFile(file, data, func);

			if(bCacheAble)SaveCache(file);
		}

		public void SaveCache(string file)
		{
			string bin=file + ".cache";
			using(FileStream fs=new FileStream(bin, FileMode.Create, FileAccess.Write))
			{
				(new DBSerial(fs)).Serialize(data);
			}
		}


		void Serialize(FileStream fs, Hashtable h)
		{
		}

		Hashtable Deserialize(FileStream fs)
		{
			return null;
		}

		public override Hashtable Get(string nm)
		{
			return data[nm] as Hashtable;
		}

		public override ArrayList Keys()
		{
			ArrayList nms=new ArrayList();
			nms.AddRange(data.Keys);
			return nms;
		}

		public override ArrayList FindByTag(string tag, FindCompare f)
		{
			ArrayList nms=new ArrayList();
			foreach(string nm in data.Keys)
			{
				Hashtable h=data[nm] as Hashtable;
				if(h==null)continue;
				if(!h.Contains(tag))
				{
					if(f==null)nms.Add(nm);
					continue;
				}
				if( f(h[tag]) )nms.Add(nm);
			}
			return nms;
		}


		public override void Set(string nm, Hashtable row)
		{
			data[nm]=row;
		}

		public override int Count()
		{
			return data.Count;
		}

	};


	public class DBDir : DB
	{
		string path;
		Hashtable keys=new Hashtable();

		public DBDir(string path)
		{
			this.path=path;
			LoadFiles();
		}

		void LoadFiles()
		{
			keys.Clear();

			for(int i=-1; i<10000; i++)
			{
				string p=path;
				if(i>=0)p+="/" + i.ToString();
				if(!Directory.Exists(p))break;

				string[] files=Directory.GetFiles(p, "*.*");

				foreach(string f in files)
				{
					string[] fs=f.Split('/', '\\');

					keys.Add( fs[ fs.Length-1 ].ToLower(), f );
				}
			}
		}

		void WriteFile(string file, Hashtable h)
		{
			using(StreamWriter fs=new StreamWriter(file, false))
			{
				foreach(string n in h.Keys)
				{
					fs.WriteLine("{0}={1}", n, h[n]);
				}
			}
		}



		#region DB ≥…‘±
		public override ArrayList Keys()
		{
			ArrayList nms=new ArrayList();
			nms.AddRange(keys.Keys);
			return nms;
		}

		public override void Set(string nm, Hashtable row)
		{
			string p;
			if(!keys.Contains(nm))
			{
				p=path + "/" + nm;
			} 
			else 
			{
				p=keys[nm] as string;
			}
			WriteFile( p, row );
		}



		public override ArrayList FindByTag(string tag, FindCompare f)
		{
			return null;
		}

		public override Hashtable Get(string nm)
		{
			if(!keys.Contains(nm))return null;

			Hashtable h=new Hashtable();
			if(! ReadFile( keys[nm] as string, h, null ) )return null;
			return h;
		}

		public override int Count()
		{
			return keys.Count;
		}
		#endregion
	}

	public class DBCStruct 
	{
		public string name;
		public int    pos;
		public string type;

		public DBCStruct(string name, int col, string type)
		{
			this.name=name;
			pos=col*4;
			this.type=type;
		}
	};


	public class DBDBC : DB
	{
		uint rows, cols, rowLen, strLen, strPos;
		ArrayList  dbcstruct;
		FileStream fdbc;
		Hashtable  keys=new Hashtable();

		public DBDBC(string file, ArrayList dbcstruct)
		{
			fdbc=new FileStream(file, FileMode.Open, FileAccess.Read);

			byte[] header=new byte[20];
			fdbc.Read(header, 0, header.Length);
			ByteArray pack=new ByteArray(header, false);

			if(pack.GetDWord() != 0x43424457)
				throw new FormatException("invalid WDBC file");

			pack.Get(out rows).Get(out cols).Get(out rowLen).Get(out strLen);

			foreach(DBCStruct dbc in dbcstruct)
			{
				if(dbc.pos<0 || dbc.pos>=rowLen)
					throw new FormatException("invalid COL " + dbc.name);
			}

			strPos=(uint)fdbc.Position;
			for(uint i=0; i<rows; i++)
			{
				keys.Add(i.ToString(), strPos);
				strPos+=rowLen;
			}

			this.dbcstruct=dbcstruct;
		}


		#region DB
		public override ArrayList Keys()
		{
			ArrayList nms=new ArrayList();
			nms.AddRange(keys.Keys);
			return nms;
		}

		public override ArrayList FindByTag(string tag, FindCompare f)
		{
			return null;
		}

		public override Hashtable Get(string nm)
		{
			if(!keys.Contains(nm))return null;
			uint pos=(uint)keys[nm];

			Hashtable h=new Hashtable();

			byte[] b=new byte[rowLen];
			fdbc.Seek(pos, SeekOrigin.Begin);
			fdbc.Read(b, 0, b.Length);

			ByteArray pack=new ByteArray(b, false);

			foreach(DBCStruct col in dbcstruct)
			{
				pack.pos=col.pos;

				switch(col.type)
				{
					case "ushort":
						h[ col.name ] = pack.GetWord();
						break;

					case "int":
						h[ col.name ] = (int)pack.GetDWord();
						break;

					case "uint":
						h[ col.name ] = pack.GetDWord();
						break;

					case "float":
						h[ col.name ] = pack.GetFloat();
						break;

					case "string":
					{
						uint p=pack.GetDWord();
						if(p==0)break;
						if(p>fdbc.Length-strPos)
						{
							throw new FormatException("invalid string pos");
						}
						fdbc.Seek(strPos + p, SeekOrigin.Begin);
						int len=(int)(fdbc.Length - fdbc.Position);
						if(len>1024)len=1024;
						byte[] data=new byte[len];
						fdbc.Read(data, 0, len);

						h[ col.name ] = (new ByteArray(data)).GetString();
					}
						break;
				}
			}
			return h;
		}

		public override int Count()
		{
			return keys.Count;
		}
		#endregion
	}

}
