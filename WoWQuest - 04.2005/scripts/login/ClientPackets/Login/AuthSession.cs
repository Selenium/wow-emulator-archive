using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for AuthSession.
	/// </summary>
	[LoginPacketHandler()]
	public class AuthSession
	{
		[LoginPacketDelegate(CMSG.AUTH_SESSION)]
		static bool HandleAuthSession(LoginClient client, CMSG msgID, BinReader data)
		{
			data.BaseStream.Position += 8;
			string name = data.ReadString().ToLower();
			if(name.Length < 3)
			{
				client.Close("Too short account name");
				return true;
			}
			if(client.Account != null)
			{
				client.Close(client.Account.Name + " tried to log in again as " + name);
				return true;
			}
			
			BinWriter w = LoginClient.NewPacket(SMSG.AUTH_RESPONSE);
			if(LoginClient.IsAccountLoggedIn(name))
			{
				w.Write((byte)0x19);
				client.Send(w);
				client.Close("Client tried to log in with an already logged in account.");
				return true;
			}
			DBAccount account = null;
			try
			{
				account = (DBAccount)DataServer.Database.FindObjectByKey(typeof(DBAccount), name);
			}
			catch(WoWDaemon.Database.DatabaseException e)
			{
				client.Close(e.Message);
				return true;
			}

			if(account == null) 
			{
				/*account = new DBAccount();
				account.Name = name;
				account.Password = name;
				DataServer.Database.AddNewObject(account);
				Console.WriteLine("Created account: " + name);*/
				w.Write((byte)0x1a);
				client.Send(w);
				client.Close("Invalid account");
				return true;
			}

			client.Account = account;

			if (client.Account.SessionKey == null)
			{
				w.Write((byte)0x1a);
				client.Send(w);
				client.Close("No SessionKey found");
				return true;
			}
			
			int c = 0;
			client.Hash = new byte[40];
			string[] split = client.Account.SessionKey.Split('-');

			foreach (string b in split)
			{
				client.Hash[c] = byte.Parse(b,System.Globalization.NumberStyles.HexNumber);
				c += 1;
			}
	
			client.Authenticated = true;
			Console.WriteLine("Account " + name + " logged in from " + client.RemoteEndPoint);
			w.Write((byte)0x0C);
			client.Send(w);
			return true;
		}
	}
}
