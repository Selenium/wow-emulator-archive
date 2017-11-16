using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;


namespace LoginScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Test.
	/// </summary>
	[ChatCmdHandler()]
	public class GetItem
	{
		[ChatCmdAttribute("GetItem", "GetItem <ItemTemplateID>")]
		static bool OnGiveitem(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}

			string[] split=input.Split(' ');
			if (split.Length<2) {return false;}
			uint templateId = (uint)int.Parse(split[1]);
			DBItemTemplate template=(DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), templateId);
            if (!(template==null))
			{
					DBItem newItem = new DBItem();
					newItem.OwnerID = client.Character.ObjectId;
					newItem.OwnerSlot = 0; 
					newItem.TemplateID = templateId;
					newItem.Template=template;
					DataServer.Database.AddNewObject(newItem);
					client.WorldConnection.Send(newItem);

					ScriptPacket Item = new ScriptPacket(SCRMSG.BUYITEM);

					Item.Write(client.Character.ObjectId);
					Item.Write(newItem.ObjectId);
					Item.Write((int)0);
					client.WorldConnection.Send(Item);
					return true;
			}
			Chat.System(client, "Item not found");
			return true;

		}
	}
}
