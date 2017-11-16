using System; 
using System.Collections;
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.TradeScripts
{
	
	[LoginPacketHandler()]
	public class Trade
	{
		[LoginPacketDelegate(CMSG.INITIATE_TRADE)]
		static bool TradeInvite(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong inviteeGUID = data.ReadUInt64();

			uint inviterGUID = client.Character.ObjectId;
			string inviterNAME = client.Character.Name;
			LoginClient invitee = LoginServer.GetLoginClientByCharacterID((uint)inviteeGUID);
			
			BinWriter pkga1 = LoginClient.NewPacket(SMSG.TRADE_STATUS);

			pkga1.Write((int)1);
			pkga1.Write((ulong)inviteeGUID);
			
			client.Send(pkga1);

			BinWriter pkgb1 = LoginClient.NewPacket(SMSG.TRADE_STATUS);
						
			pkgb1.Write((int)1);
			pkgb1.Write((ulong)inviterGUID);
						
			invitee.Send(pkgb1);

			BinWriter pkga2 = LoginClient.NewPacket(SMSG.TRADE_STATUS);

			pkga2.Write((int)2);

			client.Send(pkga2);
			invitee.Send(pkga2);

			client.Character.LastTradeID = invitee.Character.ObjectId;
			invitee.Character.LastTradeID= client.Character.ObjectId;
			
			return true;
		}

		[LoginPacketDelegate(CMSG.SET_TRADE_GOLD)]
		static bool TradeGold(LoginClient client, CMSG msgID, BinReader data)
		{
			uint gold = data.ReadUInt32();
			uint inviteeGUID=client.Character.LastTradeID;

			BinWriter pkg = LoginClient.NewPacket(SMSG.TRADE_STATUS_EXTENDED);

			pkg.Write((byte)0);			// 0 for giving, 1 for recieving
			pkg.Write((int)1);			// Message Count
			pkg.Write(gold);			// Money Amount
			pkg.Write((int)0);			// ?
			pkg.Write((int)0);			// ?
			
			client.Send(pkg);

			client.Character.TradeMoney = gold;
			
			LoginClient invitee = LoginServer.GetLoginClientByCharacterID((uint)inviteeGUID);

			BinWriter pkg2 = LoginClient.NewPacket(SMSG.TRADE_STATUS_EXTENDED);

			pkg2.Write((byte)1);		// 0 for giving, 1 for recieving
			pkg2.Write((int)1);			// Message Count
			pkg2.Write(gold);			// Money Amount
			pkg2.Write((int)0);			// ?
			pkg2.Write((int)0);			// ?
			
			invitee.Send(pkg2);

			invitee.Character.TradeCompleted = false;
			
			return true;
		}

		[LoginPacketDelegate(CMSG.SET_TRADE_ITEM)]
		static bool TradeItem(LoginClient client, CMSG msgID, BinReader data)
		{
			byte tradeslot = data.ReadByte();
			byte sourcebag = data.ReadByte();
			byte sourceslot= data.ReadByte();

			client.Character.TradeItemCount++;
			uint itemcount = client.Character.TradeItemCount;

			uint inviteeGUID = client.Character.LastTradeID;

			LoginClient invitee = LoginServer.GetLoginClientByCharacterID((uint)inviteeGUID);

			BinWriter pkg = LoginClient.NewPacket(SMSG.TRADE_STATUS_EXTENDED);

			pkg.Write((byte)1);							// 0 for giving, 1 for recieving
			pkg.Write((int)1);							// Message Count
			pkg.Write(client.Character.TradeMoney);		// Money Amount
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			
			pkg.Write(tradeslot);						// Trade Slot
			pkg.Write((int)1);							// Item Template ID
			pkg.Write((int)1542);						// Item Display ID
			pkg.Write((int)0);							// Item Count
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?
			pkg.Write((int)0);							// ?

			invitee.Send(pkg);

			return true;
		}

		[LoginPacketDelegate(CMSG.CLEAR_TRADE_ITEM)]
		static bool ClearTradeItem(LoginClient client, CMSG msgID, BinReader data)
		{
			uint inviteeGUID=client.Character.LastTradeID;

			uint count = client.Character.TradeItemCount--;

			LoginClient invitee = LoginServer.GetLoginClientByCharacterID((uint)inviteeGUID);
			
			byte slot = data.ReadByte();
			
			Chat.System(client, "Clear Trade Item from slot "+slot+" Working");

			invitee.Character.TradeCompleted = false;

			return true;
		}

		[LoginPacketDelegate(CMSG.ACCEPT_TRADE)]
		static bool AcceptTrade(LoginClient client, CMSG msgID, BinReader data)
		{
			uint flag = data.ReadUInt32();
			uint inviteeGUID=client.Character.LastTradeID;

			LoginClient invitee = LoginServer.GetLoginClientByCharacterID((uint)inviteeGUID);

			BinWriter pkg = LoginClient.NewPacket(SMSG.TRADE_STATUS);

			if (invitee.Character.TradeCompleted==true)
			{
				ScriptPacket Money = new ScriptPacket(SCRMSG.TRADEMONEY);

				Money.Write(client.Character.ObjectId);
				Money.Write(invitee.Character.ObjectId);
				Money.Write(client.Character.TradeMoney);
				Money.Write(invitee.Character.TradeMoney);

				client.WorldConnection.Send(Money);

				pkg.Write((int)8);
				
				invitee.Send(pkg);
				client.Send(pkg);

				client.Character.LastTradeID = 0;
				client.Character.TradeMoney = 0;
				client.Character.TradeCompleted = false;
				
				invitee.Character.LastTradeID = 0;
				invitee.Character.TradeMoney = 0;
				invitee.Character.TradeCompleted = false;

			}
			else
			{
				pkg.Write((int)4);
				client.Character.TradeCompleted = true;
				
				invitee.Send(pkg);
			}

			return true;
		}

		[LoginPacketDelegate(CMSG.CANCEL_TRADE)]
		static bool CancelTrade(LoginClient client, CMSG msgID, BinReader data)
		{
			uint inviteeGUID=client.Character.LastTradeID;

			LoginClient invitee = LoginServer.GetLoginClientByCharacterID((uint)inviteeGUID);
			
			client.Character.LastTradeID = 0;
			invitee.Character.LastTradeID = 0;
			
			BinWriter pkg = LoginClient.NewPacket(SMSG.TRADE_STATUS);

			pkg.Write((int)3);
			
			invitee.Send(pkg);

			invitee.Character.TradeCompleted = false;
			
			return true;
		}
	}
}
