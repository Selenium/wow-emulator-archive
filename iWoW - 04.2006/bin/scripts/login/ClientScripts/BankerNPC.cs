using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientScripts
{
	[LoginPacketHandler()]
	public class Banker
	{
		[LoginPacketDelegate(CMSG.BANKER_ACTIVATE)]
		static bool BankActivate(LoginClient client, CMSG msgID, BinReader data)
		{
            ulong vendorGUID = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.SHOW_BANK);

			pkg.Write(vendorGUID);

			client.Send(pkg);

			Chat.System(client, "Bank Working on : "+vendorGUID);

			return true;
		}

		[LoginPacketDelegate(CMSG.BUY_BANK_SLOT)]
		static bool BankBuySlot(LoginClient client, CMSG msgID, BinReader data)
		{
			//TODO SLOT 63 TO 70 ARE NOT WORKING (PURCHASABLE SLOTS ON BANK)
			
			ulong vendorGUID = data.ReadUInt64();
			uint slot = data.ReadUInt32();

			//BinWriter pkg = LoginClient.NewPacket(SMSG.BUY_BANK_SLOT_RESULT);
			//pkg.Write(0);
			//client.Send(pkg);
			
			Chat.System(client, "Buying Bank Slot Number "+slot+" on banker "+vendorGUID);

			return true;
		}
	}
}
