using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ScriptPackets
{
	/// <summary>
	/// Summary description for SetSelection.
	/// </summary>
	[ScriptPacketHandler()]
	public class SetSelection
	{
		[ScriptPacketHandler(MsgID=0x06)]
		static void OnSetSelection(int msgID, BinReader data)
		{
			uint CharID = data.ReadUInt32();
			ulong guid = data.ReadUInt64();
			WorldClient client = WorldServer.GetClientByCharacterID(CharID);
			if(guid == 0)
			{
				client.Player.Selection = null;
			}
			else
			{
				WorldObject obj = null;
				if((obj = ObjectManager.GetWorldObject(OBJECTTYPE.PLAYER, guid)) == null) {
					if((obj = ObjectManager.GetWorldObject(OBJECTTYPE.UNIT, guid)) == null) {
						obj = ObjectManager.GetWorldObject(OBJECTTYPE.GAMEOBJECT, guid);
					}// else
						//Chat.System(client, "Selected mob: " + ((UnitBase)obj).Name + " - HP: " + ((UnitBase)obj).Health);
				}// else
					//Chat.System(client, "Selected player: " + ((PlayerObject)obj).Name + " - HP: " + ((PlayerObject)obj).Health);
				client.Player.Selection = obj;


			}
			client.Player.UpdateData();
		}
	}
}
