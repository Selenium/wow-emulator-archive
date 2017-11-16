using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for CharDelete.
	/// </summary>
	[LoginPacketHandler()]
	public class CharDelete
	{
		[LoginPacketDelegate(CMSG.CHAR_DELETE)]
		static bool HandleCharDelete(LoginClient client, CMSG msgID, BinReader data)
		{
			uint id = data.ReadUInt32();
			if(client.Account.Characters == null)
			{
				client.Close(client.Account.Name + " tried to delete a character when there was none on the account.");
				return true;
			}
			foreach(DBCharacter c in client.Account.Characters)
			{
				if(id == c.ObjectId)
				{
					if (c.OnFriends!=null)
					{
						foreach (DBFriendList Friend in c.OnFriends)
						{
				
							LoginClient FriendOnline = LoginServer.GetLoginClientByCharacterID(Friend.Owner_ID);
							if (FriendOnline!=null)
							{
								BinWriter flist = LoginClient.NewPacket(SMSG.FRIEND_STATUS);
								Chat.System(FriendOnline, client.Character.Name+" is Online");
								flist.Write((char)0x05);
								flist.Write((ulong)c.ObjectId);
								FriendOnline.Send(flist);
								try
								{
									DataServer.Database.DeleteObject(Friend);
								}
								catch(Exception e)
								{
									Console.WriteLine("Deleting Friend failed! " + e.Message);
								}
								FriendOnline.Character.Friends=null;
								DataServer.Database.FillObjectRelations(FriendOnline.Character);

							}
							else
							{
								try
								{
									DataServer.Database.DeleteObject(Friend);
								}
								catch(Exception)
								{
									Console.WriteLine("Deleting Friend failed!");
								}
							}	

							FriendOnline=null;
						}
					}
					try
					{
						DataServer.Database.DeleteObject(c);
					}
					catch(Exception e)
					{
						Console.WriteLine("Deleting character " + c.ObjectId + " failed! " + e.Message);
					}
					DBGuildMembers cMember=(DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuild), c.ObjectId);
					if (cMember!=null)
					{
						DBGuild guild=(DBGuild)DataServer.Database.FindObjectByKey(typeof(DBGuild), c.GuildID);
						DataServer.Database.DeleteObject(cMember);
						if (guild!=null) DataServer.Database.FillObjectRelations(guild);
					}
					client.Account.Characters = null;
					DataServer.Database.FillObjectRelations(client.Account);
					BinWriter w = LoginClient.NewPacket(SMSG.CHAR_DELETE);
					w.Write((byte)0x36);
					client.Send(w);
					return true;
				}
			}
			client.Close(client.Account.Name + " tried to delete a character that didn't belong to him.");
			return true;
		}
	}
}
