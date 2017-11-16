using System;
using System.Text.RegularExpressions;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Worldport.
	/// </summary>
	[ChatCmdHandler()]
	public class Goto
	{
		static Goto()
		{
			AddGoto("Undercity 0 1628.3 239.925 64.5006");
			AddGoto("Stormwind 0 -8913.23 554.633 93.7944");
			AddGoto("Orgimmar 1 1484.36 -4417.03 24.4709");
			AddGoto("Ironforge 0 -4981.25 -881.542 501.66");
			AddGoto("Gnomeregan 0 -5179.58 660.421 388.391");
			AddGoto("Dalaran 0 386.938 212.299 43.6994");
			AddGoto("Darkshire 0 -10567.5 -1169.86 29.0826");
			AddGoto("AeriePeak 0 327.814 -1959.99 197.724");
			AddGoto("Lakeshire 0 -9282.98 -2269.64 69.39");
			AddGoto("Ambermill 0 -126.954 815.624 66.0224");
			AddGoto("BootyBay 0 -14406.6 419.353 22.3907");
			AddGoto("Stonard 0 -10452.5 -3263.59 20.1782");
			AddGoto("Brill 0 2260.64 289.021 34.1291");
			AddGoto("Moonbrook 0 -11018.4 1513.69 43.0152");
			AddGoto("Menethil 0 -3740.29 -755.08 10.9643");
			AddGoto("Astrnaar 1 2745.85 -378.33 108.253");
			AddGoto("Aszhara 1 3546.8 -5287.96 109.935");
			AddGoto("BaelModan 1 -4095.7 -2305.74 124.914");
			AddGoto("Crossroads 1 -456.263 -2652.7 95.615");
			AddGoto("Auberdine 1 6439.28 614.957 5.98831");
			AddGoto("Thalanaar 1 -4517.1 -780.415 -40.736");
			AddGoto("Razorhill 1 304.762 -4734.97 9.30458");
			AddGoto("Bloodhoof 1 -2321.74 -378.941 -9.40597");
			AddGoto("Racetrack 1 -6202.16 -3901.68 -60.2858");
			AddGoto("Tanaris 1 -6942.47 -4847.1 0.667853");
			AddGoto("StonetalonPeak 1 2506.3 1470.14 262.722");
			AddGoto("FreewindPost 1 -5437.4 -2437.47 89.3083");
			AddGoto("Darnassus 1 9948.55 2413.59 1327.23");
			AddGoto("Dolanaar 1 9892.57 982.424 1313.83");
			AddGoto("TheramoreIsle 1 -3729.36 -4421.41 30.4474");
			AddGoto("Hyjal 1 4674.88 -3638.37 965.264");
			AddGoto("Thunderbluff 1 -1200 -50 200");
			AddGoto("Winterspring 1 5468.852 -4706.866 792.8879");
			AddGoto("WorldTree 1 5369.888 -3372.989 1655.519");
			AddGoto("Moonglade 1 7892.251 -2571.341 487.4597");
			AddGoto("DarkPortal 0 -11826.16 -3192.274 -30.60934");
			AddGoto("DeadwindTower 0 -11081.19 -2067.794 207.8472");
			AddGoto("Plaguelands 0 3127.066 -3284.693 134.1926");
			AddGoto("UngoroCrater 1 -8126.3 -2080.994 -133.928");
			AddGoto("SlitheringScar 1 -7867.831 -1349.741 -273.7796");
			AddGoto("Construction 1 6558.301 -2068.364 571.6768");
			AddGoto("Undead 0 1676.458 1678.227 121.6705");
			AddGoto("Orc 1 -601.8857 -4250.712 38.95608");
			AddGoto("Troll 1 -601.8857 -4250.712 38.95608");
			AddGoto("Tauren 1 -2873.756 -218.8642 54.77188");
			AddGoto("Human 0 -8898.118 -173.2708 81.57769");
			AddGoto("Dwarf 0 -6102.929 395.7565 395.5409");
			AddGoto("Gnome 0 -6102.929 395.7565 395.5409");
			AddGoto("Elf 1 10479.66 811.8455 1322.744");
		}
		static Regex parseGoto = new Regex(
			@"(?<name>\S+)\s" +
			@"(?<continent>\S+)\s" +
			@"(?<x>\S+)\s" +
			@"(?<y>\S+)\s" +
			@"(?<z>\S+)", RegexOptions.Compiled);
		class Place
		{
			public string name;
			public uint worldmapID;
			public float x;
			public float y;
			public float z;
		}
		static void AddGoto(string str)
		{
			Match aMatch = parseGoto.Match(str);
			if(aMatch.Success == false)
			{
				Console.WriteLine("Failed to match goto: " + str);
				return;
			}
			Place aPlace = new Place();
			try
			{
				aPlace.name = aMatch.Groups["name"].Value.ToLower();
				aPlace.worldmapID = (uint)( aMatch.Groups["continent"].Value == "0" ? 1 : 2);
				aPlace.x = float.Parse(aMatch.Groups["x"].Value);
				aPlace.y = float.Parse(aMatch.Groups["y"].Value);
				aPlace.z = float.Parse(aMatch.Groups["z"].Value);
			}
			catch(Exception)
			{
				Console.WriteLine("Failed to parse goto: " + str);
				return;
			}
			places[aPlace.name] = aPlace;
		}

		static Hashtable places = new Hashtable();

		[ChatCmdAttribute("goto", "goto <name>")]
		static bool OnGoto(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			Place aPlace = (Place)places[split[1]];
			if(aPlace == null)
			{
				IEnumerator e = places.Keys.GetEnumerator();
				int i = 0;
				string str = "Available places are: ";
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
			client.Player.Position = new Vector(aPlace.x, aPlace.y, aPlace.z);
			client.Player.WorldMapID = aPlace.worldmapID;
			MapManager.ChangeMap(client);
			return true;
		}

		[ChatCmdAttribute("massgoto", "massgoto <name>")]
		static bool OnMassGoto(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			Place aPlace = (Place)places[split[1]];
			if(aPlace == null)
			{
				IEnumerator e = places.Keys.GetEnumerator();
				int i = 0;
				string str = "Available places are: ";
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
			foreach(PlayerObject player in client.Player.MapTile.Map.GetObjectsInRange(OBJECTTYPE.PLAYER,client.Player.Position,25.0f))
			{
				player.Position = new Vector(aPlace.x, aPlace.y, aPlace.z);
				player.WorldMapID = aPlace.worldmapID;
				MapManager.ChangeMap(WorldServer.GetClientByCharacterID((uint)(player.GUID)));
			}
			client.Player.Position = new Vector(aPlace.x, aPlace.y, aPlace.z);
			client.Player.WorldMapID = aPlace.worldmapID;
			MapManager.ChangeMap(client);
			return true;
		}
	}


}
