using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientScripts
{
	[LoginPacketHandler()]
	public class Taxi
	{
		[LoginPacketDelegate(CMSG.TAXINODE_STATUS_QUERY)]
		static bool TaxiQuery(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong taxiGUID = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.TAXINODE_STATUS);
			pkg.Write(taxiGUID);
			pkg.Write((byte)2);		// Taxi Status
			client.Send(pkg);

			Chat.System(client, "Taxi NPC status query working");

			return true;
		}

		[LoginPacketDelegate(CMSG.TAXIQUERYAVAILABLENODES)]
		static bool TaxiQueryNodes(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong taxiGUID = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.SHOWTAXINODES);

			pkg.Write((int)1);		// Show Map
			pkg.Write(taxiGUID);
			pkg.Write((int)11);		// Node Location*

			client.Send(pkg);

			Chat.System(client, "Query Avaliable Nodes Working");

			return true;
		}

		[LoginPacketDelegate(CMSG.ACTIVATETAXI)]
		static bool TaxiActivate(LoginClient client, CMSG msgID, BinReader data)
		{

			ulong taxiGUID = data.ReadUInt64();
			uint startnode = data.ReadUInt32();
			uint destnode = data.ReadUInt32();

			BinWriter pkg = LoginClient.NewPacket(SMSG.ACTIVATETAXIREPLY);

			pkg.Write((int)10); // Code*

			client.Send(pkg);

			Chat.System(client, "Activate Taxi Working...");
			
			return true;
		}
	}
}

/*
 * 
 * Code : 
TAXINOERROR = 0x0, 
TAXIUNSPECIFIEDSERVERERROR = 0x1, 
TAXINOSUCHPATH = 0x2, 
TAXINOTENOUGHMONEY = 0x3, 
TAXITOOFARAWAY = 0x4, 
TAXINOVENDORNEARBY = 0x5, 
TAXINOTVISITED = 0x6, 
TAXIPLAYERBUSY = 0x7, 
TAXIPLAYERALREADYMOUNTED = 0x8, 
TAXIPLAYERSHAPESHIFTED = 0x9, 
TAXIPLAYERMOVING = 0xA, 
TAXINOPATHS = 0xB,


* Node Locations :

1 Northshire Abbey (1) 
2 Stormwind, Elwynn (1 
3 Programmer Isle (36) 
4 Sentinel Hill, Westfall (52) 
5 Lakeshire, Redridge (76) 
6 Ironforge, Dun Morogh (96) 
7 Menethil Harbor, Wetlands (118) 
8 Thelsamar, Loch Modan (144) 
9 Booty Bay, Stranglethorn (166) 
10 Sepulcher, Silverpine (191) 
11 Undercity, Tirisfal (213) 
12 Darkshire, Duskwood (233) 
13 Tarren Mill, Hillsbrad (253) 
14 Southshore, Hillsbrad (276) 
15 Eastern Plaguelands (298) 
16 Refuge Pointe - Arathi (318) 
17 Hammerfall - Arathi (341) 
18 Booty Bay - Stranglethorn (361) 
19 Booty Bay - Stranglethorn (361) 
20 Grom'gol - Stranglethorn (387) 
21 Kargath - Badlands (412) 
22 Thunder Bluff - Mulgore (431) 
23 Orgrimmar - Durotar (455) 
24 Badlands - Kargath - Bat - UNUSED (475) 
25 Crossroads - The Barrens (509) 
26 Auberdine, Darkshore (534) 
27 Rut'theran Village - Teldrassil (555) 
28 Astranaar - Ashenvale (587) 
29 Sun Rock Retreat - Stonetalon Mountains (609) 
30 Freewind Post - Thousand Needles (649) 
31 Thalanaar - Thousand Needles (682) 
32 Theramore - Dustwallow Marsh (711) 
33 Stonetalon Peak - Stonetalon Mountains (740) 
34 The Barrens - Ratchet Boat Return TEST (779) 
35 The Barrens - Ratchet Boat TEST (818) 
36 TEST (850) 
56 Stonard - Swamp of Sorrows (855) 
57 FIshing Village - Teldrassil (882) 
*
*/

