using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ChatCommands
{
	/// <summary>
	/// Summary description for vAddItem.
	/// </summary>
	[ChatCmdHandler()]
	public class VendorCommands
	{
		[ChatCmdAttribute("vAddItem", "vAddItem <template> <qty> [<price>]")]
		static bool OnvAddItem(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}

			string[] split = input.Split(' ');
			if (split.Length < 3)
				return false;
			DBVendorItem item = new DBVendorItem();
			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID='"+client.Character.Selected+"'");
			if (obj==null || obj.Length==0)
			{
				Chat.System(client, "Vendor not found");
				return true;
			}
			DBVendor vendor = (DBVendor)obj[0];
			item.VendorID=vendor.ObjectId;
			
			item.TemplateID=(uint)int.Parse(split[1]);
			DBItemTemplate template = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), item.TemplateID);
			if (template==null)
			{
				Chat.System(client, "Item template not found for "+item.TemplateID);
				item=null;
				return false;
			}
			item.CurrentQty=int.Parse(split[2]);
			if (split.Length>3)
				item.Price=int.Parse(split[3]);
			else if (template.BuyPrice>0)
				item.Price=template.BuyPrice;
			else 
				item.Price=(int)10;
			DataServer.Database.AddNewObject(item);
			DataServer.Database.SaveObject(item);
			Chat.System(client, "Added item "+template.Name+ " to vendor "+ vendor.Name);
			DataServer.Database.FillObjectRelations(vendor);
			DataServer.Database.FillObjectRelations(item);

			return true;
		}

		[ChatCmdAttribute("vRemoveItem", "vRemoveItem <template> <qty> [<price>]")]
		static bool OnvRemoveItem(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');			
			if (split.Length < 2)
				return false;

			uint targetItem=(uint)int.Parse(split[1]);
			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID='"+client.Character.Selected+"'");
			if (obj==null || obj.Length==0)
			{
				Chat.System(client, "Vendor not found");
				return true;
			}
			DBVendor vendor = (DBVendor)obj[0];
			foreach (DBVendorItem item in vendor.VendorItems)
			{
				if (item.TemplateID==targetItem)
				{
					Chat.System(client, "Removed item "+item.Name+" from vendor "+vendor.Name);
					DataServer.Database.DeleteObject(item);
					DataServer.Database.FillObjectRelations(vendor);
					return true;
				}

			}
			Chat.System(client, "Item not found on this vendor");
			return true;
		}
		
		[ChatCmdAttribute("vAddTrain", "vAddTrain <class> <spell_id> <trainspell_id> <price>")]
		static bool OnvAddTrain(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}

			string[] split = input.Split(' ');
			if (split.Length < 4)
				return false;
			DBTraining item = new DBTraining();
			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID='"+client.Character.Selected+"'");
			if (obj==null || obj.Length==0)
			{
				Chat.System(client, "Vendor not found");
				return true;
			}
			DBVendor vendor = (DBVendor)obj[0];
			item.VendorID=vendor.ObjectId;
			CLASS tmpClass=CLASS.MAGE;
			try 
			{
				tmpClass=(CLASS)Enum.Parse(typeof(CLASS), split[1], true);
			}
			catch(Exception) {Chat.System(client, "Invalid class");return false;}
			item.Class=(int)tmpClass;
			item.SpellID=(uint)int.Parse(split[2]);
			DBSpell spell = (DBSpell)DataServer.Database.FindObjectByKey(typeof(DBSpell), item.SpellID);
			if (spell==null)
			{
				Chat.System(client, "Spell not found for ID "+item.SpellID);
				item=null;
				return false;
			}
			item.TeachSpellID=uint.Parse(split[3]);

			DBSpell trainspell = (DBSpell)DataServer.Database.FindObjectByKey(typeof(DBSpell), item.TeachSpellID);
			if (trainspell==null)
			{
				Chat.System(client, "Spell not found for ID "+item.TeachSpellID);
				item=null;
				return false;
			}
//			if (split.Length>3)
				item.Price=int.Parse(split[4]);
//			else if (template.BuyPrice>0)
//				item.Price=template.BuyPrice;
//			else 
//				item.Price=(int)10;
			DataServer.Database.AddNewObject(item);
			DataServer.Database.SaveObject(item);
			DataServer.Database.FillObjectRelations(vendor);
			DataServer.Database.FillObjectRelations(item);
			Chat.System(client, "Added item "+item.Spell.Name+ " to vendor "+ vendor.Name);

			return true;
		}

		[ChatCmdAttribute("inittrainer", "inittrainer <class>")]
		static bool OnInitTrainer(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}

			string[] split = input.Split(' ');			
			if (split.Length < 2)
				return false;

			
			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID='"+client.Character.Selected+"'");
			if (obj==null || obj.Length==0)
			{
				Chat.System(client, "Vendor not found");
				return true;
			}
			DBVendor vendor = (DBVendor)obj[0];
			CLASS tmpClass=CLASS.MAGE;
			try 
			{
				tmpClass=(CLASS)Enum.Parse(typeof(CLASS), split[1].ToUpper());
			}
			catch(Exception) {Chat.System(client, "Invalid class");return false;}
			vendor.Class=(int)tmpClass;
			Chat.System(client, "Setting Trainer Class:"+vendor.Class);
			DataServer.Database.SaveObject(vendor);
			DataServer.Database.FillObjectRelations(vendor);
			string classstr = tmpClass.ToString();
			classstr = classstr.Substring(0,1).ToUpper()+classstr.Substring(1).ToLower();
			string chatcmd = "!title "+'\"'+classstr+" Trainer"+'\"';
			WorldPacket pkg = new WorldPacket(WORLDMSG.CLIENT_MESSAGE);
			pkg.Write(client.Character.ObjectId);
			pkg.Write((int)CMSG.MESSAGECHAT);
			pkg.Write((int)0);
			pkg.Write((int)0);
			pkg.Write(chatcmd);
			client.SendWorldServer(pkg);
			return true;
		}
	
	}
}
