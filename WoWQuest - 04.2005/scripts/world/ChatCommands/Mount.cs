using System;
using System.Text.RegularExpressions;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Mount.
	/// </summary>
	[ChatCmdHandler()]
	public class Mounts
	{
		static Mounts()
		{
			AddMounts("evilhorse 235");
			AddMounts("whitehorse 236");
			AddMounts("palimino 237");
			AddMounts("pintohorse 238");
			AddMounts("blackhorse 239");
			AddMounts("chestnut 908");
			AddMounts("zebra 1531");
			AddMounts("nightmare 2346");
			AddMounts("undead 5050");
			AddMounts("drake 5145");
			AddMounts("gryphon 1147");
			AddMounts("hippogryph 479");
			AddMounts("blackram 2784");
			AddMounts("blueram 2787");
			AddMounts("brownram 2785");
			AddMounts("grayram 2736");
			AddMounts("whiteram 2786");
			AddMounts("orangerapture 180");
			AddMounts("greenrapture 322");
			AddMounts("bluerapture 675");
			AddMounts("yellowrapture 787");
			AddMounts("redrapture 1960");
			AddMounts("purplerapture 960");
			AddMounts("grayrapture 1337");
			AddMounts("blacktiger 321");
			AddMounts("browntiger 1056");
			AddMounts("darktiger 3029");
			AddMounts("redtiger 320");
			AddMounts("snowtiger 748");
			AddMounts("whitetiger 616");
			AddMounts("yellowtiger 632");
			AddMounts("evilunicorn 2185");
			AddMounts("ivoryunicorn 2186");
			AddMounts("stripedunicorn 2190");
			AddMounts("brownwapiti 1917");
			AddMounts("blackwapiti 1991");
			AddMounts("wyvern 295");
			AddMounts("blackdire 207");
			AddMounts("reddire 246");
			AddMounts("browndire 247");
			AddMounts("bluedire 720");
			AddMounts("graydire 2320");
			AddMounts("darkdire 2327");
		}
		static Regex parseMounts = new Regex(
			@"(?<name>\S+)\s" +
			@"(?<id>\S+)", RegexOptions.Compiled);
		class Ride
		{
			public string name;
			public int id;
		}
		static void AddMounts(string str)
		{
			Match aMatch = parseMounts.Match(str);
			if(aMatch.Success == false)
			{
				Console.WriteLine("Failed to match mount: " + str);
				return;
			}
			Ride aRide = new Ride();
			try
			{
				aRide.name = aMatch.Groups["name"].Value.ToLower();
				aRide.id = int.Parse(aMatch.Groups["id"].Value);
	
			}
			catch(Exception)
			{
				Console.WriteLine("Failed to parse mount: " + str);
				return;
			}
			rides[aRide.name] = aRide;
		}
		static Hashtable rides = new Hashtable();
		[ChatCmdAttribute("mount", "mount <name>")]
		static bool OnMount(WorldClient client, string input)
		{
			if(client.Player.Level<10)
			{
				Chat.System(client,"You have to be level 10 or more to mount.");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			Ride aRide = (Ride)rides[split[1]];
   
			if(client.Player.MountDisplayID != 0)
			{
				Chat.System(client, "You must '!dismount' first.");
				return true;
			}
			if(aRide == null)
			{
				IEnumerator e = rides.Keys.GetEnumerator();
				int i = 0;
				string str = "";
				Chat.System(client, "Available mounts are: ");
				while(e.MoveNext())
				{
					str += (string)e.Current;
					str += ", ";
					i++;
					if(i == 8)
					{
						Chat.System(client, str);
						str = string.Empty;
						i = 0;
					}
				}
				if(i != 0)
					Chat.System(client, str);
				return true;
			}
			client.Player.RunningSpeed = 13.0f;
			BinWriter pkg = new BinWriter();
			pkg.Write((UInt64)client.Player.GUID);
			pkg.Write((float)client.Player.RunningSpeed);
			client.Send(SMSG.FORCE_RUN_SPEED_CHANGE,pkg);

			client.Player.Flags |= 0x3000;
			client.Player.MountDisplayID = (aRide.id);
			client.Player.UpdateData();
			Chat.System(client, "You mount upon the " + (aRide.name));
			return true;
		}
		[ChatCmdAttribute("dismount", "No usage.")]
		[ChatCmdAttribute("unmount", "No usage.")]
		static bool OnDismount(WorldClient client, string input)
		{
			if(client.Player.MountDisplayID == 0)
			{
				Chat.System(client, "You must be mounted to dismount");
				return true;
			}
			client.Player.MountDisplayID = 0;

			client.Player.RunningSpeed = 7.5f;
			BinWriter pkg = new BinWriter();
			pkg.Write((UInt64)client.Player.GUID);
			pkg.Write((float)client.Player.RunningSpeed);
			client.Send(SMSG.FORCE_RUN_SPEED_CHANGE,pkg);

			client.Player.Flags &= ~(uint)0x3000;
			client.Player.UpdateData();
			Chat.System(client, "You dismount the beast.");
			return true;
		} 
	}
}

