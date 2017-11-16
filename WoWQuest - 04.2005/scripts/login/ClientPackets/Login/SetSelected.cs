using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for SetSelection.
	/// </summary>
	[LoginPacketHandler()]
	public class SetSelected
	{
		[LoginPacketDelegate(CMSG.SET_SELECTION)]
		static bool OnSetSelected(LoginClient client, CMSG msgID, BinReader data)
		{
			try
			{
				client.Character.Selected = data.ReadUInt64();
				ScriptPacket pkg = new ScriptPacket(SCRMSG.SELECTION);
				pkg.Write(client.Character.ObjectId);
				pkg.Write(client.Character.Selected);
				client.WorldConnection.Send(pkg);
				return true;
			}
			catch (Exception) {}
			return true;
		}
	}
}
