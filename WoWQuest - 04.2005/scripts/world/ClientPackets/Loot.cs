using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;

namespace WorldScripts.ClientPackets
{
	[WorldPacketHandler]
	public class Loot
	{
		[WorldPacketDelegate(CMSG.LOOT)]
		static void OnLoot(WorldClient client, CMSG msgID, BinReader data)
		{
			ulong targetguid = (ulong)data.ReadInt64();
			UnitBase target = (UnitBase)ObjectManager.GetWorldObject(OBJECTTYPE.UNIT, targetguid);
			if (target == null)
			{
				Chat.System(client, "Invalid corpsetarget.");
				return;
			}
			BinWriter writer = new BinWriter();
			writer.Write(targetguid);

			if (target.LootOwner != client.Player.GUID)
			{
				writer.Write((byte)0);
			}
			else
			{
				writer.Write((byte)0x01);
				writer.Write((uint)target.Money);
				writer.Write((byte)0);
			}

			client.Send(SMSG.LOOT_RESPONSE, writer);

			// TODO: Get items.
			return;
		}

		[WorldPacketDelegate(CMSG.LOOT_MONEY)]
		static void OnLootMoney(WorldClient client, CMSG msgID, BinReader data)
		{
			// TODO: Group support and loot order for group
			if (client.Player.Selection == null) {
				Chat.System(client, "Invalid corpsetarget.");
			}
			else
			{
				UnitBase target = (UnitBase)client.Player.Selection;
				client.Player.Money += target.Money;
				client.Player.UpdateData();
				Chat.System(client, "You looted " + target.Money + " coins.");
				target.Money = 0;
//				target.UpdateData();
			}
			return;
		}

		[WorldPacketDelegate(CMSG.LOOT_RELEASE)]
		static void OnLootRelease(WorldClient client, CMSG msgID, BinReader data)
		{
			ulong targetguid = (ulong)data.ReadInt64();
			BinWriter writer = new BinWriter();
			writer.Write(targetguid);
			writer.Write((byte)0x01);
			client.Send(SMSG.LOOT_RELEASE_RESPONSE, writer);

/*			UnitBase target = (UnitBase)ObjectManager.GetWorldObject(OBJECTTYPE.UNIT, targetguid);
			if (target == null)
			{
				Chat.System(client, "Invalid corpsetarget.");
				return;
			}

			// If no loot left.. Make corpse nonlootable.
			if (target.Money == 0) 
			{
				target.DynamicFlags = 0;
				target.UpdateData();
			}
*/
			return;
		}
	} 
}
