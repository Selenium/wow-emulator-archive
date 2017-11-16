using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;

namespace WorldScripts.ClientPackets
{
	/// <summary>
	/// Summary description for TextEmote.
	/// </summary>
	[WorldPacketHandler]
	public class StandStateChange
	{
		[WorldPacketDelegate(CMSG.STANDSTATECHANGE)]
		static void OnStandStateChange(WorldClient client, CMSG msgID, BinReader data)
		{
			if(client.Player.MountDisplayID != 0)
				return;

			if (data.BaseStream.Length > (data.BaseStream.Position + 8))
			{
				data.BaseStream.Position += 8;

				client.Player.StandState = (UNITSTANDSTATE)data.ReadByte();
				client.Player.UpdateData();
			}
		}
	}
}
