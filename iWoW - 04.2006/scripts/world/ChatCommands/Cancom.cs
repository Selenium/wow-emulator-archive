using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Cancom.
	/// </summary>
	[ChatCmdHandler()]
	public class Cancom
	{
		[ChatCmdAttribute("Cancom", "Cancom")]
		static bool OnCancom(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
//			ServerPacket CombatCancel = new ServerPacket(SMSG.CANCEL_COMBAT);
			BinWriter CombatCancel = new BinWriter();		
//			CombatCancel.Write((char)1);
			CombatCancel.Write(client.Player.GUID);
//			CombatCancel.Write(client.Player.Selection.GUID);
			CombatCancel.Write((int)2);

//			CombatCancel.Finish();
//			CombatCancel.AddDestination(client.CharacterID);
//			client.Player.MapTile.Map.Send(CombatCancel, client.Player.Position, 25.0f);
			client.Send(SMSG.CANCEL_COMBAT, CombatCancel);
			return true;
		}
	}
}
