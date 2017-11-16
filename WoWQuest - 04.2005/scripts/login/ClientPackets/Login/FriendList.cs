using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;

namespace LoginScripts.FriendList
{
	
	[LoginPacketHandler]
	public class OnFriendList
	{
		#region AddFriend
		[LoginPacketDelegate(CMSG.ADD_FRIEND)]
		static bool AddFriend(LoginClient client, CMSG msgID, BinReader data)
		{
			BinWriter FriendStatus=LoginClient.NewPacket(SMSG.FRIEND_STATUS);
			string newfriend = data.ReadString();
			string name = newfriend.ToLower();
			DBCharacter character = null;
			try
			{
				character = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name);
			}
			catch(WoWDaemon.Database.DatabaseException)
			{
				FriendStatus.Write((char)FRIEND.DB_ERROR);
				client.Send(FriendStatus);
				return true;
			}
			if(character == null)
			{
				FriendStatus.Write((char)FRIEND.NOT_FOUND);
				client.Send(FriendStatus);
				return true;
			}
			else
			{
				if (client.Character.Friends!=null)
				{
					foreach (DBFriendList Friend in client.Character.Friends)
					{
						if (Friend.Friend_ID==character.ObjectId)
						{
							FriendStatus.Write((char)0x08);
							client.Send(FriendStatus);
							return true;
						}
					}
				}
				DBFriendList newentry = new DBFriendList();
				newentry.Owner_ID = client.Character.ObjectId;
				newentry.Friend_ID = character.ObjectId;
				DataServer.Database.AddNewObject(newentry);
				DataServer.Database.FillObjectRelations(client.Character);
				DataServer.Database.FillObjectRelations(character);

				LoginClient FriendOnline = LoginServer.GetLoginClientByCharacterID(character.ObjectId);
				if (FriendOnline==null)
				{
					FriendStatus.Write((char)FRIEND.ADDED_OFFLINE);
					FriendStatus.Write((ulong)character.ObjectId);
					FriendStatus.Write((int)character.Zone);
					FriendStatus.Write((int)character.Level);
					FriendStatus.Write((int)character.Class);
				}
				else
				{
					DataServer.Database.FillObjectRelations(FriendOnline.Character);
					FriendStatus.Write((char)FRIEND.ADDED_ONLINE);
					FriendStatus.Write((ulong)FriendOnline.Character.ObjectId);
					FriendStatus.Write((int)FriendOnline.Character.Zone);
					FriendStatus.Write((int)FriendOnline.Character.Level);
					FriendStatus.Write((int)FriendOnline.Character.Class);
				}
				client.Send(FriendStatus);
				return true;
			}
		}
	#endregion

		#region DelFriend
		[LoginPacketDelegate(CMSG.DEL_FRIEND)]
		static bool DelFriend(LoginClient client, CMSG msgID, BinReader data)
		{	
//			BinWriter FriendStatus=LoginClient.NewPacket(SMSG.FRIEND_STATUS);
			uint delfriend = data.ReadUInt32();
			Console.WriteLine(delfriend);
			foreach (DBFriendList Friend in client.Character.Friends)
			{
				if (Friend.Friend_ID==delfriend)
				{
					BinWriter w = LoginClient.NewPacket(SMSG.FRIEND_STATUS);
					try
					{
						DataServer.Database.DeleteObject(Friend);
					}
					catch(Exception e)
					{
						Console.WriteLine("Deleting Friend failed! " + e.Message);
						w.Write((char)0x05);
						w.Write((ulong)delfriend);
						client.Send(w);
					}
					client.Character.Friends = null;
					DataServer.Database.FillObjectRelations(client.Character);
//					BinWriter w = LoginClient.NewPacket(SMSG.FRIEND_STATUS));
					w.Write((char)0x05);
					w.Write((ulong)delfriend);
					client.Send(w);
					return true;
				}
			}
	

			return true;
		}
		#endregion

		
		
		[LoginPacketDelegate(CMSG.FRIEND_LIST)]
		static bool ListFriend(LoginClient client, CMSG msgID, BinReader data)
		{
			BinWriter flist = LoginClient.NewPacket(SMSG.FRIEND_LIST);
			if (client.Character.Friends==null)
			{
				flist.Write((byte)0);
				client.Send(flist);
			}
			else
			{
				byte tmpByte=(byte)client.Character.Friends.Length;
				flist.Write((char)tmpByte);
				LoginClient FriendOnline=null;
				foreach (DBFriendList Friend in client.Character.Friends)
				{
					FriendOnline = LoginServer.GetLoginClientByCharacterID(Friend.Friend_ID);
					if (FriendOnline==null)
					{
						flist.Write((ulong)Friend.Friend_ID);
						flist.Write((char)0x00);
					}
					else
					{
						flist.Write((ulong)Friend.Friend_ID);
						flist.Write((char)0x02);
						flist.Write((int)FriendOnline.Character.Zone);
						flist.Write((int)FriendOnline.Character.Level);
						flist.Write((int)FriendOnline.Character.Class);
					}
					FriendOnline=null;
				}
				client.Send(flist);
			}
			return true;
		}
	}
}
	