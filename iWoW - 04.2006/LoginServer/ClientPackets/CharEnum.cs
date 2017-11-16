using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for CharEnum.
	/// </summary>
	[LoginPacketHandler()]
	public class CharEnum
	{
		[LoginPacketDelegate(CMSG.CHAR_ENUM)]
		static bool HandleCharEnum(LoginClient client, CMSG msgID, BinReader data)
		{
			BinWriter w = LoginClient.NewPacket(SMSG.CHAR_ENUM);
			if(client.Account == null)
			{
				client.Close("HandleCharEnum: Not logged in.");
				return true;
			}
			if(client.Account.Characters == null)
			{
				w.Write((byte)0);
				client.Send(w);
				return true;
			}
			w.Write((byte)client.Account.Characters.Length);
			foreach(DBCharacter c in client.Account.Characters)
			{
				w.Write((ulong)c.ObjectId);
				w.Write(c.Name);
				w.Write((byte)c.Race);
				w.Write((byte)c.Class);
				w.Write(c.Gender);
				w.Write(c.Skin);
				w.Write(c.Face);
				w.Write(c.HairStyle);
				w.Write(c.HairColor);
				w.Write(c.FacialHairStyle);
				w.Write(c.Level);
				w.Write(c.Zone);
				w.Write(c.Continent);
				w.WriteVector(c.Position);
				w.Write(c.GuildID);
				w.Write(0);
				w.Write((byte)c.RestedState);
				w.Write(0);
				w.Write(0);
				w.Write(0);
				long pos = w.BaseStream.Position;
				w.Write(new byte[100]);
				if(c.Items != null)
				{
					DataServer.Database.FillObjectRelations(c);
					foreach(DBItem item in c.Items)
					{
						if(item.OwnerSlot > 0x13)
							continue;
						if(item.Template == null)
						{
							Console.WriteLine("Database error: Item missing template object.");
							continue;
						}
						w.Set((int)(pos+item.OwnerSlot*5), item.Template.DisplayID);
						w.Set((int)(pos+item.OwnerSlot*5+4), (byte)item.Template.InvType);
					}
				}
			}
			client.Send(w);
			return true;
		}
	}
}
