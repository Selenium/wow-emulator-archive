using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.WhoList
{
	[LoginPacketHandler]
	public class WhoisOnline
	{
		[LoginPacketDelegate(CMSG.WHO)]
		static bool Whois(LoginClient client, CMSG msgID, BinReader data)
		{
			LoginServer.SendWhoList(client);
			return true;

		}
	}
}
