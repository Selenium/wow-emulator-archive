using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Morph.
	/// </summary>
	[ChatCmdHandler()]
	public class TestSMSG
	{
		[ChatCmdAttribute("TestSMSG", "TestSMSG <SMSG number or name> <patamater>")]
		static bool OnTestSMSG(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length < 2)
				return false;
			SMSG testMsg;
			try
			{
				testMsg=(SMSG)Enum.Parse(typeof(SMSG),split[1].ToUpper());
			}
			catch (System.ArgumentException  )
			{
				Chat.System(client, "Invalid SMSG:"+ split[1]);
				return true;
			}
//			int param1=int.Parse(split[2]);
//			int param2=int.Parse(split[3]);
//			int param3=int.Parse(split[4]);
			BinWriter TestPacket = new BinWriter();
			TestPacket.Write(client.Player.Selection.GUID);
//			TestPacket.Write(param1);
//			TestPacket.Write(param2);
//			TestPacket.Write(param3);
//			TestPacket.Finish();
			client.Send(testMsg, TestPacket);
			return true;
		}

		[ChatCmdAttribute("Moneybags", "Moneybags")]
		static bool OnMoneybags(WorldClient client, string input)
		{
			client.Player.Money+=10000000;
			client.Player.Save();
			client.Player.UpdateData();
			return true;
		}

		[ChatCmdAttribute("tvend", "tv")]
		static bool OntVend(WorldClient client, string input)
		{
			BinWriter TestPacket = new BinWriter();
			TestPacket.Write(client.Player.Selection.GUID);
			client.Send(SMSG.TABARDVENDOR_ACTIVATE, TestPacket);
			return true;
		}

		[ChatCmdAttribute("bat", "bat <attacktime0> <attacktime1>")]
		static bool OnBat(WorldClient client, string input)
		{
			string[] split = input.Split(' ');
			if(split.Length < 3)
				return false;

			client.Player.BaseAttackTime = int.Parse(split[1]);
			client.Player.BaseAttackTime1 = int.Parse(split[2]);
			if (split.Length>3)
				client.Player.ModDamageDone = int.Parse(split[3]);
			if (split.Length>4)
				client.Player.AttackPower = int.Parse(split[4]);
			if (split.Length>3)
				client.Player.AttackPowerModifier = int.Parse(split[5]);

//			client.Player.Save();
			client.Player.UpdateData();
			return true;
		}

		[ChatCmdAttribute("rs", "rs <restedstate>")]
		static bool OnRs(WorldClient client, string input)
		{
			string[] split = input.Split(' ');
			if(split.Length < 2)
				return false;

			client.Player.RestedState = (RESTEDSTATE)Enum.Parse(typeof(RESTEDSTATE), split[1]);
			//			client.Player.Save();
			client.Player.UpdateData();
			return true;
		}

	}
}
