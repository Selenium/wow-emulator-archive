using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientPackets
{
	[LoginPacketHandler]
	public class ZoneUpdate
	{
		[LoginPacketDelegate(CMSG.ZONEUPDATE)]
		static bool Zoneupdate(LoginClient client, CMSG msgID, BinReader data)
		{
			uint newZone = (uint)data.ReadUInt32();
			client.Character.Zone = newZone;
			client.Character.Dirty=true;
			DataServer.Database.SaveObject(client.Character);
			ScriptPacket WorldZoneUpdate = new ScriptPacket(SCRMSG.ZONEUPDATE);
			WorldZoneUpdate.Write(client.Character.ObjectId);
			WorldZoneUpdate.Write(newZone);
			client.WorldConnection.Send(WorldZoneUpdate);
			if (client.Character.OnFriends!=null)
			{
				foreach (DBFriendList Friend in client.Character.OnFriends)
				{
					LoginClient FriendOnline = LoginServer.GetLoginClientByCharacterID(Friend.Owner_ID);
					if (FriendOnline!=null)
					{
						BinWriter flist = LoginClient.NewPacket(SMSG.FRIEND_STATUS);
						Chat.System(FriendOnline, client.Character.Name+"'s zone updated");
						flist.Write((char)0x02);
						flist.Write((ulong)client.Character.ObjectId);
						flist.Write((int)newZone);
						flist.Write((int)client.Character.Level);
						flist.Write((int)client.Character.Class);
						client.Send(flist);
					}
				}
			}
			return true;
		}
	}
}

