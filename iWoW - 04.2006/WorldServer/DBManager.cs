using System;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using System.Reflection;
namespace WoWDaemon.World
{
	/// <summary>
	/// 
	/// </summary>
	[WorldPacketHandler()]
	public class DBManager
	{
		static Assembly dbTypes = Assembly.GetAssembly(typeof(DBItemTemplate));

		[WorldPacketDelegate(WORLDMSG.DESERIALIZE_OBJ)]
		static void DeserializeObject(WORLDMSG msgID, BinReader data)
		{
			string str = data.ReadString();
			Type type = dbTypes.GetType(str);
			if(type == null)
				throw new Exception("Failed to deserialize " + str + ": type == null");
			uint ObjectID = data.ReadUInt32();
			DBObject obj = GetDBObject(type, ObjectID);
			if(obj != null)
			{
				obj.Deserialize(data);
				// we will probably never deserialized an existing object
				Console.WriteLine("woooah! WorldServer deserialized a " + str + " that already exists. Notify something!");
			}
			else
			{
				obj = (DBObject)Activator.CreateInstance(type);
				obj.Deserialize(data);
				AddDBObject(obj);
			}

			if(type == typeof(DBCharacter))
			{
				int n = data.ReadInt32();
				DBCharacter c = (DBCharacter)obj;
				if(n > 0)
				{
					c.Items = new DBItem[n];
					for(int i = 0;i < n;i++)
					{
						ObjectID = data.ReadUInt32();
						DBItem item = (DBItem)GetDBObject(typeof(DBItem), ObjectID);
						if(item == null)
						{
							item = new DBItem();
							item.Deserialize(data);
							AddDBObject(item);
						}
						else
							item.Deserialize(data);
						item.Template = (DBItemTemplate)GetDBObject(typeof(DBItemTemplate), item.TemplateID);
						if(item.Template == null)
							Console.WriteLine("Missing Item Template " + item.TemplateID);
						c.Items[i] = item;
					}
				}
				else
					c.Items = null;				
			}
		}


		static Hashtable m_dbobjects = new Hashtable();
		public static void AddDBObject(DBObject obj)
		{
			Hashtable tmp = (Hashtable)m_dbobjects[obj.GetType()];
			if(tmp == null)
			{
				tmp = new Hashtable();
				m_dbobjects[obj.GetType()] = tmp;
			}
			tmp[obj.ObjectId] = obj;
		}

		internal static void RemoveDBObject(DBObject obj)
		{
			Hashtable tmp = (Hashtable)m_dbobjects[obj.GetType()];
			if(tmp != null)
				tmp.Remove(obj.ObjectId);
		}

		public static DBObject GetDBObject(Type type, uint id)
		{
			Hashtable tmp = (Hashtable)m_dbobjects[type];
			if(tmp == null)
				return null;
			return (DBObject)tmp[id];
		}

		public static void SaveDBObject(DBObject obj)
		{
			if(obj.Dirty == false)
			{
				return;
			}
			if(obj.PendingCreate)
			{
				obj.PendingSave = true;
				return;
			}
			Console.WriteLine(obj.GetType().ToString());
			WorldPacket pkg = new WorldPacket(WORLDMSG.DESERIALIZE_OBJ);
			pkg.Write(obj.GetType().ToString());
			pkg.Write(obj.ObjectId);
			obj.Serialize(pkg);
			WorldServer.Send(pkg);
			obj.Dirty = false;
		}

		static Hashtable createDBRequests = new Hashtable();
		static int currentRequestID = 0;

		public static void CreateDBObject(DBObject obj)
		{
			if(obj.PendingCreate)
				return;
			obj.PendingCreate = true;
			int id = currentRequestID++;
			createDBRequests[id] = obj;
			WorldPacket pkg = new WorldPacket(WORLDMSG.CREATE_DBOBJECT);
			pkg.Write(id);
			pkg.Write(obj.GetType().ToString());
			WorldServer.Send(pkg);
			AddDBObject(obj);
		}
		
		internal static int CreateRequestsPending()
		{
			return createDBRequests.Count;
		}

		[WorldPacketDelegate(WORLDMSG.CREATE_DBOBJECT_REPLY)]
		static void OnCreateDBObjectReply(WORLDMSG msgID, BinReader data)
		{
			int requestid = data.ReadInt32();
			/*string str =*/ data.ReadString();
			uint objid = data.ReadUInt32();
			DBObject obj = (DBObject)createDBRequests[requestid];
			createDBRequests.Remove(requestid);
			obj.OnDBCreate(objid);
			obj.PendingCreate = false;
			AddDBObject(obj);
			
			if(obj.PendingDelete == true)
			{
				obj.PendingDelete = false;
				DeleteDBObject(obj);
				return;
			}

			if(obj.PendingSave == true)
			{
				obj.PendingSave = false;
				SaveDBObject(obj);
			}
		}

		public static void DeleteDBObject(DBObject obj)
		{
			if(obj.PendingCreate)
			{
				obj.PendingDelete = true;
				return;
			}
			RemoveDBObject(obj);
			WorldPacket pkg = new WorldPacket(WORLDMSG.DELETE_DBOBJECT);
			pkg.Write(obj.GetType().ToString());
			pkg.Write(obj.ObjectId);
			WorldServer.Send(pkg);
		}

		internal static void CheckBeforeShutdown()
		{
			IDictionaryEnumerator e = m_dbobjects.GetEnumerator();
			while(e.MoveNext())
			{
				Hashtable tbl = (Hashtable)e.Value;
				if(tbl.Count > 0)
				{
					Console.WriteLine("Still " + tbl.Count + " " + e.Key.ToString() + " left in DBManager.");
				}
			}
		}
		public static Hashtable spellsDB = new Hashtable();
		[WorldPacketDelegate(WORLDMSG.INIT_SPELLS)]
		static void InitSpells(WORLDMSG msgID, BinReader data)
		{
			int numSpells = data.ReadInt32();
			for(int j = 0;j < numSpells;j++)
			{
				DBSpell spell = new DBSpell();
				spell.Deserialize(data);
				spellsDB.Add(spell.ObjectId,spell);
			}
			Console.WriteLine("WorldServer successfully received " + spellsDB.Count + " spells!");
		}
	}
}
