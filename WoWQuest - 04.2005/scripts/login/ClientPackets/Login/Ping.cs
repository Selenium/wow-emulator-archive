using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for Ping.
	/// </summary>
	[LoginPacketHandler()]
	public class Ping
	{
		[LoginPacketDelegate(CMSG.PING)]
		static bool HandlePing(LoginClient client, CMSG msgID, BinReader data)
		{
			BinWriter w = LoginClient.NewPacket(SMSG.PONG);
			w.Write(data.ReadUInt32());
			client.Send(w);
			return true;
		}
	}
}
