using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ClientPackets
{
	/// <summary>
	/// Summary description for SetSelection.
	/// </summary>
	[WorldPacketHandler()]
	public class OpeningCinematic
	{
		[WorldPacketDelegate(CMSG.OPENING_CINEMATIC)]
		static void OnOpeningCinematic(WorldClient client, CMSG msgID, BinReader data)
		{
			ulong param1 = data.ReadUInt32();
			BinWriter TestPacket = new BinWriter();
			TestPacket.Write(param1);	
			client.Send(SMSG.TRIGGER_CINEMATIC, TestPacket);

		}
	}
}
