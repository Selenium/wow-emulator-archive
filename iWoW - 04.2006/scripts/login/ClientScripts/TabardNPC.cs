using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientScripts
{
	[LoginPacketHandler()]
	public class TabardVendor
	{
		[LoginPacketDelegate(CMSG.TABARDVENDOR_ACTIVATE)]
		static bool Tabard(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong vendorGUID = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.TABARDVENDOR_ACTIVATE);

			pkg.Write(vendorGUID);
			
			client.Send(pkg);
			
			return true;

		}

		[LoginPacketDelegate(CMSG.PETITION_SHOWLIST)]
		static bool PetitionList(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong vendorGUID = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.PETITION_SHOWLIST);

			string msg = "This is a test msg for petition";

			pkg.Write(vendorGUID);
			pkg.Write((ulong)client.Character.ObjectId);
			pkg.Write("TestString");
			pkg.Write((byte)1);
			pkg.Write((byte)1);
			pkg.Write((byte)1);
			pkg.Write((byte)1);
			pkg.Write((int)1);
			pkg.Write((int)1);
			pkg.Write((string) "TestGuild");
			pkg.Write((int)1);
			pkg.Write((int)1);
			pkg.Write((int)1);
			pkg.Write(msg);


			client.Send(pkg);
	
			Chat.System(client, "Petition Query Working :"+vendorGUID);

			return true;

		}

	
	}
}
