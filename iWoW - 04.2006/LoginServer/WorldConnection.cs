using System;
using System.Reflection;
using System.Data;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;

namespace WoWDaemon.Login
{
	/// <summary>
	/// Summary description for WorldConnection.
	/// </summary>
	[LoginPacketHandler()]
	public class WorldConnection
	{
		ClientBase m_client;
		DBWorldMap[] m_worldMaps;
		public WorldConnection(ClientBase client, DBWorldMap[] worldMaps)
		{
			m_client = client;
			m_client.RecievedDataHandler += OnWorldServerData;
			m_worldMaps = worldMaps;
			InitGuids(this);
			InitMaps();
		}

		~WorldConnection()
		{
			if (m_client != null)
				m_client.RecievedDataHandler -= OnWorldServerData;
		}

		public void InitMaps()
		{
			InitSpells();
			WorldPacket pkg = new WorldPacket(WORLDMSG.INIT_MAPS);
			pkg.Write(m_worldMaps.Length);
			foreach(DBWorldMap map in m_worldMaps)
			{
				map.Serialize(pkg);
				if(map.Spawns == null)
					pkg.Write(0);
				else
				{
					pkg.Write(map.Spawns.Length);
					foreach(DBSpawn spawn in map.Spawns)
					{
						//if(spawn.Creature == null)
						//{
						//	Console.WriteLine("Spawn " + spawn.ObjectId + " is missing creature object.");
						//}
						//else
						//	Send(spawn.Creature);
						Send(spawn);
						spawn.Serialize(pkg);
					}
				}
			}
			Send(pkg);
		}

		public void InitSpells()
		{
			DataTable t = DataServer.Database.GetDataSet("Spell").Tables["Spell"];
			DataObject[] spell = DataServer.Database.SelectAllObjects(typeof(DBSpell));
			WorldPacket pkg = new WorldPacket(WORLDMSG.INIT_SPELLS);
			pkg.Write(spell.Length);
			for(int i = 0; i < spell.Length; i++)
			{
				((DBSpell)spell[i]).Serialize(pkg);
			}
			Send(pkg);
		}


		public override string ToString()
		{
			return m_client.RemoteEndPoint.ToString();
		}


		internal void OnEnterWorld(DBCharacter c, ACCESSLEVEL accesslevel)
		{
			Send(c);
			SendEnterWorld(c, accesslevel);
		}

		#region sending data

		private void SendEnterWorld(DBCharacter c, ACCESSLEVEL accesslevel)
		{
			WorldPacket pkg = new WorldPacket(WORLDMSG.PLAYER_ENTER_WORLD);
			pkg.Write(c.ObjectId);
			pkg.Write((byte)accesslevel);
			Send(pkg);
		}

		private void Send(DBCharacter c)
		{
			if(c.Items != null)
			{
				foreach(DBItem item in c.Items)
					Send(item.Template);
			}
			SendDBObject(c);
		}

		GrowableBitArray m_hasItemTemplate = new GrowableBitArray(65536);
		public void Send(DBItemTemplate template)
		{
			if(m_hasItemTemplate[(int)template.ObjectId])
				return;
			m_hasItemTemplate[(int)template.ObjectId] = true;
			SendDBObject(template);
		}

		public void Send(DBItem item)
		{
			Send(item.Template);
			SendDBObject(item);
		}


		public void Resend(DBItemTemplate template)
		{
			m_hasItemTemplate[(int)template.ObjectId] = true;
			SendDBObject(template);
		}

		GrowableBitArray m_hasSpawn = new GrowableBitArray(65536);
		public void Send(DBSpawn spawn)
		{
			if(m_hasSpawn[(int)spawn.ObjectId])
				return;
			m_hasSpawn[(int)spawn.ObjectId] = true;

			if(spawn.Creature == null)
			{
				Console.WriteLine("Spawn " + spawn.ObjectId + " is missing creature object.");
			}
			else
				Send(spawn.Creature);

			SendDBObject(spawn);
		}

		GrowableBitArray m_hasCreature = new GrowableBitArray(65536);
		public void Send(DBCreature creature)
		{
			if(m_hasCreature[(int)creature.ObjectId])
				return;
			m_hasCreature[(int)creature.ObjectId] = true;
			SendDBObject(creature);
		}

		private void SendDBObject(DBCharacter obj)
		{
			WorldPacket pkg = new WorldPacket(WORLDMSG.DESERIALIZE_OBJ);
			pkg.Write(obj.GetType().ToString());
			pkg.Write(obj.ObjectId);
			obj.Serialize(pkg);
			obj.SerializeItems(pkg);
			Send(pkg);
		}

		private void SendDBObject(DBObject obj)
		{
			WorldPacket pkg = new WorldPacket(WORLDMSG.DESERIALIZE_OBJ);
			pkg.Write(obj.GetType().ToString());
			pkg.Write(obj.ObjectId);
			obj.Serialize(pkg);
			Send(pkg);
		}

		public void Send(WorldPacket pkg)
		{
			pkg.Set(0, (int)(pkg.BaseStream.Length-4));
			pkg.Flush();
			m_client.Send(pkg.GetBuffer(), pkg.BaseStream.Length);
		}
		#endregion


		/*
		internal bool processWorldServerData()
		{
			if(m_client.PendingSendData)
				m_client.SendWork();
			if(m_client.Connected == false)
				return false;
			byte[] data;
			while((data = m_client.GetNextPacketData()) != null)
				OnWorldServerData(data);
			return m_client.Connected;
		}*/

		private void OnWorldServerData(ClientBase c, byte[] data)
		{
			BinReader read = new BinReader(data);
			read.BaseStream.Position += 4; // skip len
			WORLDMSG msgID = (WORLDMSG)read.ReadInt32();
			if(msgID == WORLDMSG.SERVER_MESSAGE)
			{
				SMSG smsg = (SMSG)read.ReadInt32();
				Console.WriteLine("WorldServer sent: " + smsg);
				int len = read.ReadInt32();
				BinWriter pkg = LoginClient.NewPacket(smsg);
				if(len > 0)
					pkg.Write(read.ReadBytes(len));
				while(read.BaseStream.Position < read.BaseStream.Length)
				{
					uint plrID = read.ReadUInt32();
					LoginClient client = LoginServer.GetLoginClientByCharacterID(plrID);
					if(client == null)
						Console.WriteLine("client missing for plrID " + plrID + " while sending " + smsg.ToString());
					else
					{
						client.Send(pkg);
					}
				}
			}
			else if(msgID == WORLDMSG.SCRIPT_MESSAGE)
			{
				LoginServer.Scripts.OnScriptMessage(read.ReadInt32(), read);
			}
			else
			{
				LoginPacketManager.HandlePacket(this, msgID, read);
			}
		}

		static ulong current_guid = ((ulong)uint.MaxValue) + 1;

		static void InitGuids(WorldConnection connection)
		{
			WorldPacket pkg = new WorldPacket(WORLDMSG.INIT_GUIDS);
			pkg.Write(current_guid);
			current_guid += 200000;
			pkg.Write(current_guid);
			pkg.Write(++current_guid);
			current_guid += 200000;
			pkg.Write(current_guid++);
			connection.Send(pkg);

		}

		[LoginPacketDelegate(WORLDMSG.ACQUIRE_GUIDS)]
		static void OnAcquireGuids(WorldConnection connection, WORLDMSG msgID, BinReader data)
		{
			WorldPacket pkg = new WorldPacket(WORLDMSG.ACQUIRE_GUIDS_REPLY);
			pkg.Write(current_guid);
			current_guid += 200000;
			pkg.Write(current_guid++);
			connection.Send(pkg);
		}

		static Assembly dbTypes = Assembly.GetAssembly(typeof(DBItemTemplate));
		[LoginPacketDelegate(WORLDMSG.CREATE_DBOBJECT)]
		static void OnCreateDBObject(WorldConnection connection, WORLDMSG msgID, BinReader data)
		{
			try
			{
				int requestID = data.ReadInt32();
				string str = data.ReadString();
				Type type = dbTypes.GetType(str, true);
				DBObject obj = (DBObject)Activator.CreateInstance(type);
				DataServer.Database.AddNewObject(obj);
				WorldPacket pkg = new WorldPacket(WORLDMSG.CREATE_DBOBJECT_REPLY);
				pkg.Write(requestID);
				pkg.Write(str);
				pkg.Write(obj.ObjectId);
				connection.Send(pkg);
			}
			catch(Exception e)
			{
				Console.WriteLine("Error in OnCreateDBObject!");
				Console.WriteLine(e);
			}
		}


		[LoginPacketDelegate(WORLDMSG.DELETE_DBOBJECT)]
		static void OnDeleteDBObject(WorldConnection connection, WORLDMSG msgID, BinReader data)
		{
			try
			{
				string str = data.ReadString();
				Type type = dbTypes.GetType(str, true);
				uint objectID = data.ReadUInt32();
				string field = DataObject.GetTableName(type) + "_ID";
				DataObject[] objs = DataServer.Database.SelectObjects(type, field + " = '" + objectID + "'");
				if(objs.Length == 0)
					throw new Exception("Requested objectID " + objectID + " for " + str + " didn't exist!");
				DataServer.Database.DeleteObject(objs[0]);
			}
			catch(Exception e)
			{
				Console.WriteLine("Error in OnDeleteDBObject!");
				Console.WriteLine(e);
			}
		}

		[LoginPacketDelegate(WORLDMSG.DESERIALIZE_OBJ)]
		static void OnSaveDBObject(WorldConnection connection, WORLDMSG msgID, BinReader data)
		{
			try
			{
				string str = data.ReadString();
				Type type = dbTypes.GetType(str, true);
				uint objectID = data.ReadUInt32();
				string field = DataObject.GetTableName(type) + "_ID";
				DataObject[] objs = DataServer.Database.SelectObjects(type, field + " = '" + objectID + "'");
				if(objs.Length == 0)
					throw new Exception("Requested objectID " + objectID + " for " + str + " didn't exist!");
				DBObject obj = (DBObject)objs[0];
				obj.Deserialize(data);
				DataServer.Database.SaveObject(obj);
			}
			catch(Exception e)
			{
				Console.WriteLine("Error in OnSaveDBObject!");
				Console.WriteLine(e);
			}
		}

		[LoginPacketDelegate(WORLDMSG.CHANGE_MAP)]
		static void OnChangeMap(WorldConnection connection, WORLDMSG msgID, BinReader data)
		{
			uint id = data.ReadUInt32();
			LoginClient client = LoginServer.GetLoginClientByCharacterID(id);
			client.IsChangingMap = true;
		}

		[LoginPacketDelegate(WORLDMSG.REGISTERVENDOR)]
		static void OnRegisterVendor(WorldConnection connection, WORLDMSG msgID, BinReader data)
		{
            ulong vGUID = data.ReadUInt64();
			uint id	= data.ReadUInt32();
			uint level = data.ReadUInt32();
			string name = data.ReadString();
			DBVendor vendor;
			if (id==0)
				Console.WriteLine("SpawnID was 0 for vendor registration");
			DataObject[] objs = DataServer.Database.SelectObjects(typeof(DBVendor), "SpawnID = '" + id + "'");
			if(objs.Length == 0)
			{
				vendor = new DBVendor();
				vendor.SpawnID=id;
				vendor.GUID= vGUID;
				vendor.Name= name;
				vendor.Level=level;
				DataServer.Database.AddNewObject(vendor);
				Console.WriteLine("Vendor "+vendor.ObjectId+" created");
			}
			else
			{
				vendor = (DBVendor)objs[0];
				vendor.GUID=vGUID;
				vendor.Level=level;
				Console.WriteLine("Vendor "+vendor.ObjectId+" registered");
				DataServer.Database.SaveObject(vendor);
			}
			return;
		}
	}
}
