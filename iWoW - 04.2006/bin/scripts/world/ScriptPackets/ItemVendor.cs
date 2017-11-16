using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.World;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace WorldScripts.ScriptPackets
{
	/// <summary>
	/// Summary description for ItemVendor.
	/// </summary>
	[ScriptPacketHandler()]
	public class ItemVendor
	{
		[ScriptPacketHandler(MsgID=0x05)]
		static void OnItemVendor(int msgID, BinReader data)
		{
			
			uint charID = data.ReadUInt32();
			uint itemId = data.ReadUInt32();
			int price = data.ReadInt32();

			WorldClient client = WorldServer.GetClientByCharacterID(charID);
			if(client == null)
				return;
			if(client.Player.Money<price)
			{
				Chat.System(client, "You do not have the required funds for this item");
				return;
			}
			DBItem newitem = (DBItem)DBManager.GetDBObject(typeof(DBItem), itemId);

			if (newitem == null)
			{
				Chat.System(client, "Item not found");
				return;
			}

			newitem.Template = (DBItemTemplate)DBManager.GetDBObject(typeof(DBItemTemplate), newitem.TemplateID);
			if (newitem.Template == null)
			{
				Chat.System(client, "Item Template not found");
				return;
			}
			Console.WriteLine("Slot:"+newitem.OwnerSlot);
			if (newitem.OwnerSlot==0)
				newitem.OwnerSlot = client.Player.Inventory.GetOpenBackpackSlot();
			DBManager.SaveDBObject(newitem);
			ItemObject NewObj = (ItemObject)client.Player.Inventory.CreateItem(newitem);

//			client.Player.MapTile.Map.Enter(NewObj);

			BinWriter w = new BinWriter();
			w.Write(1);
			w.Write((byte)0);
			NewObj.AddCreateObject(w, false, true);

			ServerPacket pkg = new ServerPacket(SMSG.COMPRESSED_UPDATE_OBJECT);
			byte[] compressed = ZLib.Compress(w.GetBuffer(), 0, (int)w.BaseStream.Length);
			pkg.Write((int)w.BaseStream.Length);
			pkg.Write(compressed);
			pkg.Finish();
			client.Player.MapTile.SendSurrounding(pkg);
			client.Player.Money = client.Player.Money - price;
			client.Player.UpdateData();
			
//			Chat.System (client, "Buy Item working on Worldserver side");

		}
	}
}
