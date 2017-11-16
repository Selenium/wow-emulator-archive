using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;
namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for PlayerLogin.
	/// </summary>
	[LoginPacketHandler()]
	public class PlayerLogin
	{
		[LoginPacketDelegate(CMSG.PLAYER_LOGIN)]
		static bool OnPlayerLogin(LoginClient client, CMSG msgID, BinReader data)
		{
			if(client.Character != null)
			{
				client.Close("Tried to login another character.");
				return true;
			}

			uint id = data.ReadUInt32();
			Console.WriteLine("LoginClient:"+client.Account.Name+" CharID:"+id);
			LoginServer.PlayerLogin(client, id);
			return true;
		}
	}
}
