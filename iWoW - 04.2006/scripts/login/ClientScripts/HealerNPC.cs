using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientScripts
{
	[LoginPacketHandler()]
	public class Healer
	{
		[LoginPacketDelegate(CMSG.BINDER_ACTIVATE)]
		static bool HealerHello(LoginClient client, CMSG msgID, BinReader data)
		{
			Chat.System(client, "Healer working soon...");

			return true;
		}
	}
}
