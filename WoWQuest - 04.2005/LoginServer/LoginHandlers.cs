using System;
using System.IO;
using WoWDaemon.Common;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database.MemberValues;
using ICSharpCode.SharpZipLib.Zip.Compression;
namespace WoWDaemon.Login
{
	/// <summary>
	/// Summary description for LoginHandlers.
	/// </summary>
	[LoginPacketHandler()]
	public class LoginHandlers
	{
		static LogOut logOutEvent = null;
		static SerializeValue[] itemTemplateValues;
		static LoginHandlers()
		{
			MemberValue[] values = MemberValue.GetMemberValues(typeof(DBItemTemplate), typeof(Common.Attributes.DataElement), true, true);
			itemTemplateValues = SerializeValue.GetSerializeValues(values);
		}

		[LoginPacketDelegate(WORLDMSG.PLAYER_LEAVE_WORLD)]
		static void OnPlayerLeaveWorld(WorldConnection connection, WORLDMSG msgID, BinReader data)
		{
			LoginClient client = LoginServer.GetLoginClientByCharacterID(data.ReadUInt32());
			if(client == null)
				return;
			if(client.IsLoggingOut)
			{
				LoginServer.RemoveCharacter(client);
				BinWriter pkg = LoginClient.NewPacket(SMSG.LOGOUT_COMPLETE);
				client.Send(pkg);
				client.IsLoggingOut = false;
				client.WorldConnection = null;
			}
			else if(client.IsChangingMap)
			{

			}
			else
			{
				client.Close("Kicked from worldserver.");
			}
		}

		[LoginPacketDelegate(CMSG.LOGOUT_REQUEST)]
		static bool OnPlayerLogout(LoginClient client, CMSG msgID, BinReader data)
		{
			client.IsLoggingOut = true;
			LoginServer.LeaveWorld(client);
			return true;
			/*logOutEvent= new LogOut(client);
			EventManager.AddEvent(logOutEvent);
			BinWriter pkg = LoginClient.NewPacket(SMSG.LOGOUT_RESPONSE);
			pkg.Write((byte)12);
			client.Send(pkg);
			return true;*/
		}

		[LoginPacketDelegate(CMSG.PLAYER_LOGOUT)]
		static bool OnPlayerLogoutExecute(LoginClient client, CMSG msgID, BinReader data)
		{
			LoginServer.LeaveWorld(client);
			if(logOutEvent != null)
			{
				EventManager.RemoveEvent(logOutEvent);
				logOutEvent = null;
			}
			return true;
		}

		[LoginPacketDelegate(CMSG.LOGOUT_CANCEL)]
		static bool OnPlayerLogoutCancel(LoginClient client, CMSG msgID, BinReader data)
		{
			BinWriter pkg = LoginClient.NewPacket(SMSG.LOGOUT_CANCEL_ACK);
			client.Send(pkg);
			client.Send(pkg);
			client.IsLoggingOut=false;
			if(logOutEvent!=null)
			{
				EventManager.RemoveEvent(logOutEvent);
				logOutEvent = null;
			}
			return true;
		}

	/*	[LoginPacketDelegate(CMSG.REQUEST_UI_CONFIG)]
		static bool OnRequestUIConfig(LoginClient client, CMSG msgID, BinReader data)
		{
			client.SendConfig(data.ReadInt32());
			return true;
		}
*/
//		[LoginPacketDelegate(CMSG.REQUEST_UI_CONFIG)]
		[LoginPacketDelegate(CMSG.REQUEST_ACCOUNT_DATA)]
		static bool OnRequestUIConfig(LoginClient client, CMSG msgID, BinReader data)
		{
			client.SendConfig(data.ReadInt32());
			return true;
		}
		
//		[LoginPacketDelegate(CMSG.SAVE_UI_CONFIG)]
		[LoginPacketDelegate(CMSG.UPDATE_ACCOUNT_DATA)]
		static bool OnSaveUIConfig(LoginClient client, CMSG msgID, BinReader data)
		{
			if(client.Character == null)
				return true;
			uint type = data.ReadUInt32();
			int len = data.ReadInt32();
			string conf = string.Empty;
			if(len > 0)
			{
				try
				{
					byte[] compressed = data.ReadBytes((int)(data.BaseStream.Length-data.BaseStream.Position));
					Inflater inflater = new Inflater();
					inflater.SetInput(compressed);
					byte[] decompressed = new byte[len];
					inflater.Inflate(decompressed);
					conf = System.Text.ASCIIEncoding.ASCII.GetString(decompressed);
				}
				catch(Exception e)
				{
					Console.WriteLine("Failed to decompress config type " + type + ": " + e.Message);
					return true;
				}
			}
			switch(type)
			{
				case 0:
					client.Character.UIConfig0 = conf;
					client.Character.Dirty = true;
					break;
				case 1:
					client.Character.UIConfig1 = conf;
					client.Character.Dirty = true;
					break;
				case 2:
					client.Character.UIConfig2 = conf;
					client.Character.Dirty = true;
					break;
				case 3:
					client.Character.UIConfig3 = conf;
					client.Character.Dirty = true;
					break;
				case 4:
					client.Character.UIConfig4 = conf;
					client.Character.Dirty = true;
					break;
				default:
					Console.WriteLine("Unknown config type: " + type);
					Console.WriteLine(conf);
					return true;
			}
			DataServer.Database.SaveObject(client.Character);
			return true;
		}
		[LoginPacketDelegate(CMSG.CREATURE_QUERY)]
		static bool OnCreatureQuery(LoginClient client, CMSG msgID, BinReader data)
		{
			uint id = data.ReadUInt32();
			DBCreature creature = (DBCreature)DataServer.Database.FindObjectByKey(typeof(DBCreature), id);
			if(creature == null)
			{
				client.Close("OnCreatureQuery(): id didn't exists.");
				return true;
			}
			BinWriter w = LoginClient.NewPacket(SMSG.CREATURE_QUERY_RESPONSE);
			w.Write(creature.ObjectId);
			w.Write(creature.Name);
			w.Write(creature.Name1);
			w.Write(creature.Name2);
			w.Write(creature.Name3);
			w.Write(creature.Title);
			w.Write(creature.Flags);
			w.Write(creature.CreatureType);
			w.Write(creature.CreatureFamily);
			w.Write(0); // unknown
			client.Send(w);
			return true;
		}

		[LoginPacketDelegate(CMSG.ITEM_QUERY_SINGLE)]
		static bool OnItemQuerySingle(LoginClient client, CMSG msgID, BinReader data)
		{
			uint id = data.ReadUInt32();
			DBItemTemplate template = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), id);
			if(template == null)
			{
				Console.WriteLine("Client requested an item template that didn't exist:"+id);
				return true;
			}
			BinWriter w = LoginClient.NewPacket(SMSG.ITEM_QUERY_SINGLE_RESPONSE);
			w.Write(id);
			foreach(SerializeValue value in itemTemplateValues)
				value.Serialize(template, w);
			client.Send(w);
			return true;
		}

		[LoginPacketDelegate(CMSG.NAME_QUERY)]
		static bool OnNameQuery(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong uid = data.ReadUInt32();
			BinWriter pkg = LoginClient.NewPacket(SMSG.NAME_QUERY_RESPONSE);
			uint id = (uint)uid;
			LoginClient other = LoginServer.GetLoginClientByCharacterID(id);
			if(other == null)
			{
				DataObject[] objTemp = DataServer.Database.SelectObjects(typeof(DBCharacter), "Character_ID = '"+id+"'");
				if (objTemp.Length==0)
					Console.WriteLine("Character not found");
				else
				{
					DBCharacter objCharacter = (DBCharacter)objTemp[0];
					pkg.Write((ulong)objCharacter.ObjectId);
//					pkg.Write((uint)0); // high id
					pkg.Write(objCharacter.Name);
					pkg.Write((int)objCharacter.Race);
					pkg.Write((int)objCharacter.Gender);
					pkg.Write((int)objCharacter.Class);
					client.Send(pkg);
				}
				return true;
			}
			pkg.Write((ulong)other.Character.ObjectId);
//			pkg.Write((uint)0); // high id
//			pkg.Write(0);
			pkg.Write(other.Character.Name);
			pkg.Write((int)other.Character.Race);
			pkg.Write((int)other.Character.Gender);
			pkg.Write((int)other.Character.Class);
			client.Send(pkg);
			return true;
		}		
	}
	public class LogOut : LoginEvent
	{
		LoginClient client;
		public LogOut(LoginClient client) : base(TimeSpan.FromSeconds(20))
		{
			this.client = client;
		}

		public override void FireEvent()
		{
			LoginServer.LeaveWorld(client);
		}
	}
}		