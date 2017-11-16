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
	public class SpeedTime
	{
		[ChatCmdAttribute("speedtime", "speedtime <number>")]
		static bool OnSpeedTime(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.ADMIN)
			{
				Chat.System(client, "You do not have access to this command");
				return false;
			}

			string[] split = input.Split(' ');
			if(split.Length != 2)
			{
				Chat.System(client,"!speedtime <number>");
				return false;
			}
			int SpeedRatio;
			try
			{
				if(split[1].StartsWith("0x"))
					SpeedRatio = int.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					SpeedRatio = int.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid speedtime ratio.");
				return false;
			}

			if(SpeedRatio <= 0)
			{
				Chat.System(client, "Time Ratio cannot be 0 or negative!");
				return false;			
			}
			if(SpeedRatio >= 255)
			{
				Chat.System(client, "Time Ratio cannot be superior to 255!");
				return false;			
			}
			Chat.System(client,"Time Ratio Set from : "+WorldServer.m_clock.SpeedRatio+" to : "+SpeedRatio);
            WorldServer.m_clock.SpeedRatio = SpeedRatio;
			return true;
		}
	}
}

       
