using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;

namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Experience.
	/// </summary>
	[ChatCmdHandler()]
	public class Broadcast
	{
		[ChatCmdAttribute("Broadcast", "Broadcaste <msg>")]
		static bool OnBroadcast(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return false;
			}

			string[] split = input.Split(' ');
			if(split.Length <= 1)
			{
				Chat.System(client,"!Broadcast <msg>");
				return false;
			}
			string msg;
			try
			{
					msg = input.Substring(10);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid message");
				return false;
			}

			if(msg == null)
			{
				Chat.System(client, "You have to set a message!");
				return false;			
			}

			System.Collections.IDictionaryEnumerator EnumClients;
			EnumClients = WorldServer.GetClientsEnum();
			while(EnumClients.MoveNext())
			{
				Chat.System(((WorldClient)(EnumClients.Value)),"Broadcast : "+msg);
			}

			return true;
		}
	}
}

       
