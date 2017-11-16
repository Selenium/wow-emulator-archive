using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientScripts
{
	[LoginPacketHandler()]
	public class Gossip
	{
		[LoginPacketDelegate(CMSG.GOSSIP_HELLO)]
		static bool GossipHello(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong vendorGUID = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.GOSSIP_MESSAGE);

			string message  = "Welcome to World of WoWCraft!";
			string message2 = "Known Bugs: Read this!";

			pkg.Write(vendorGUID);		// Vendor GUID
			pkg.Write((int)1);			// Message ID
			pkg.Write((int)2);			// Counter

			pkg.Write((int)1);			// Counter Number
			pkg.Write((int)7);			// Message Type
			pkg.Write(message);			// Message Text

			pkg.Write((int)2);			// Counter Number
			pkg.Write((int)2);			// Message Type
			pkg.Write(message2);		// Message Text



			pkg.Write(0);				// ?

			client.Send(pkg);

			return true;
		}

		[LoginPacketDelegate(CMSG.NPC_TEXT_QUERY)]
		static bool GossipTextQuery(LoginClient client, CMSG msgID, BinReader data)
		{
			uint msgid = data.ReadUInt32();
			ulong vendorGUID = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.NPC_TEXT_UPDATE);

			string topic = "Out team welcome you!";
			string message = "Please, visit us in irc.gotwow.net #wowcraft";

			pkg.Write(msgid);			// Message ID
			pkg.Write(1);				// ?
			pkg.Write(topic);			// Topic Message
			pkg.Write(message);			// Message 1
			pkg.Write((int)0);			// Lenguage ID

			client.Send(pkg);

			return true;
		}
		
		[LoginPacketDelegate(CMSG.GOSSIP_SELECT_OPTION)]
		static bool GossipSelectOption(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong vendorGUID = data.ReadUInt64();
			uint msgid = data.ReadUInt32();

			BinWriter pkg = LoginClient.NewPacket(SMSG.GOSSIP_MESSAGE);

			string message  = "Welcome to World of WoWCraft! Please report bugs on our Home-Page: http://www.worldofwowcraft.com";
			string message2 = "Visit our Page for the list of known bugs: http://www.worldofwowcraft.com";

			pkg.Write(vendorGUID);				// Vendor GUID
			pkg.Write(msgid);					// Message ID
			pkg.Write((int)1);					// Counter

			pkg.Write((int)1);					// Counter Number
			pkg.Write((int)7);					// Message Type
			if (msgid == 1)pkg.Write(message);	// Message Text 1
			if (msgid == 2)pkg.Write(message2);	// Message Text 2
			pkg.Write(0);						// ?

			client.Send(pkg);

			return true;
		}
	}
}
