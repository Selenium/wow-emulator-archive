using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.GroupScripts
{
	[LoginPacketHandler()]
	public class Group
	{
		[LoginPacketDelegate(CMSG.GROUP_INVITE)]
		static bool GroupInvite(LoginClient client, CMSG msgID, BinReader data)
		{
			string inviteeName = data.ReadString();
			string inviter = client.Character.Name;

			if (client.Character.Name==inviteeName)
			{
				Chat.System(client, "You cannot invite yourself to a group");
				return true;
			}
			
			DBCharacter invitee = null;
			invitee = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), inviteeName);
			if (invitee==null)
			{
				Chat.System(client, "Player not found");
				return true;
			}
			LoginClient invited = LoginServer.GetLoginClientByCharacterID(invitee.ObjectId);
			if (invited==null)
			{
				Chat.System(client, "Player is not online");
				return true;
			}
			if (invited.Character.LastGroupInviterID!=0)
			{
				Chat.System("That player has already been invited to a group");
				return true;
			}
			invited.Character.LastGroupInviterID=client.Character.ObjectId;
			BinWriter pkg = LoginClient.NewPacket(SMSG.GROUP_INVITE);
			
			pkg.Write(inviter);
			
			invited.Send(pkg);
			return true;
		}

		[LoginPacketDelegate(CMSG.GROUP_ACCEPT)]
		static bool GroupAccept(LoginClient client, CMSG msgID, BinReader data)
		{
			WorldPacket scrpkg = new WorldPacket(WORLDMSG.GROUPCREATE);
			scrpkg.Write(client.Character.ObjectId);
			scrpkg.Write(client.Character.LastGroupInviterID);
			client.WorldConnection.Send(scrpkg);
			client.Character.LastGroupInviterID=0;
			client.Character.GroupLook=0x00;
			return true;
		}

		[LoginPacketDelegate(CMSG.GROUP_DECLINE)]
		static bool GroupDecline(LoginClient client, CMSG msgID, BinReader data)
		{
			LoginClient inviter=LoginServer.GetLoginClientByCharacterID(client.Character.LastGroupInviterID);
			client.Character.LastGroupInviterID=0;
			if (inviter==null)
				return true;

			BinWriter pkg = LoginClient.NewPacket(SMSG.GROUP_DECLINE);
			pkg.Write(client.Character.Name);
			inviter.Send(pkg);		
			return true;
		}

		
		[LoginPacketDelegate(CMSG.SET_LOOKING_FOR_GROUP)]
		static bool GroupLooking(LoginClient client, CMSG msgID, BinReader data)
		{
			byte lfg=data.ReadByte();
			client.Character.GroupLook=lfg;
			return true;
		}

	}
} 

