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
	public class Speed
	{
		[ChatCmdAttribute("speed", "speed <number>")]
		static bool OnSpeed(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client, "You do not have access to this command");
				return false;
			}

			string[] split = input.Split(' ');
			if(split.Length != 2)
			{
				Chat.System(client,"!speed <number>");
				return false;
			}
			float Speed;
			try
			{
				if(split[1].StartsWith("0x"))
					Speed= float.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					Speed = float.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid speed ratio.");
				return false;
			}

			if(Speed <= 0)
			{
				Chat.System(client, "Speed cannot be 0 or negative!");
				return false;			
			}
			if(Speed > 60)
			{
				Chat.System(client, "Speed cannot be superior to 255!");
				return false;			
			}
			BinWriter pkg = new BinWriter();
			pkg.Write((UInt64)client.Player.GUID);
			pkg.Write((float)Speed);
			client.Send(SMSG.FORCE_RUN_SPEED_CHANGE,pkg);
			Chat.System(client,"Speed Set from : "+client.Player.RunningSpeed+" to : "+Speed);
			client.Player.RunningSpeed = Speed;
			client.Player.UpdateData();
			return true;
		}
	}
}

       
