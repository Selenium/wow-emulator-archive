using System;
using System.Text.RegularExpressions;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Uptime.
	/// </summary>
	[ChatCmdHandler()]
	public class Uptime
	{
		[ChatCmdAttribute("uptime", "No usage.")]
		static bool OnUptime(WorldClient client, string input)
		{
			TimeSpan uptime = DateTime.Now.Subtract(WorldServer.m_clock.FirstLaunch);
			Chat.System(client, "This server is running WoWDaemon 1.3 since: "+WorldServer.m_clock.FirstLaunch);
			Chat.System(client, "Uptime: "+uptime.Days+" days "+uptime.Hours+" hours "+uptime.Minutes+" minutes "+uptime.Seconds+" seconds.");
			return true;
		}
	}
}
