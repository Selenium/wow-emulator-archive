using System;
using WoWDaemon.Common;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database.MemberValues;
using WoWDaemon.Login.ClientPackets;

namespace WoWDaemon.Login.ClientScripts
{
	[LoginPacketHandler]
	public class MOTD
	{
		[LoginPacketDelegate(CMSG.UPDATE_ACCOUNT_DATA)]
		static bool Send(LoginClient client, CMSG msgID, BinReader data)
		{
			if (AccountData.IsPopulatedAccountData(msgID, data) == false)
				return false;

			Chat.System(client, "Welcome to the iWoW server!");
			return true;
		}
	}
}
