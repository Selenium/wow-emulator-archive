using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;
using WoWDaemon.World;
using WorldScripts.Living;

namespace WorldScripts.Combat
{
	/// <summary>
	/// Summary description for Combat.
	/// </summary>
	[WorldPacketHandler()]
	public class Combat
	{
		[WorldPacketDelegate(CMSG.ATTACKSWING)]
		static void OnAttackSwing(WorldClient client, CMSG msgID, BinReader data)
		{
			ulong CombatTarget=data.ReadUInt64();
			//			LivingObject targetObject = (LivingObject)ObjectManager.GetWorldObjectByGUID(CombatTarget);
			if(client.Player.RezSickness)
			{
				Chat.System(client, "You cannot attack being a ghost!");
				return;
			}
			else
			{
				WorldClient tmpClient=WorldServer.GetClientByCharacterID((uint)CombatTarget);
				if (tmpClient==null)
				{
					UnitBase targetMonster=(UnitBase)ObjectManager.GetWorldObject(OBJECTTYPE.UNIT, CombatTarget);
					if (targetMonster==null)
					{
						Chat.System(client, "Invalid Target");
						return;
					}
					else
					{
						targetMonster.StartCombat(client.Player.GUID);
						client.Player.StartCombat(CombatTarget);//targetMonster);
					}
				}
				else //if (targetObject is PlayerObject)
				{
					if (!client.Player.PvP)
					{
						Chat.System(client, "You may not attack another player while your PvP is OFF");
						Chat.System(client, "To turn on PvP, type !PvP");
						return;
					}
					//				WorldClient tmpClient = WorldServer.GetClientByCharacterID(((PlayerObject)targetObject).CharacterID);
					if (tmpClient.Player.PvP)
					{
						Chat.System(tmpClient, client.Player.Name+" has attacked you!");
						client.Player.StartCombat(CombatTarget);
						return;
					}
					else
					{
						Chat.System(client, tmpClient.Player.Name+" declines your offer to duel.");
						return;
					}
				}
				return;
			}
		}
		[WorldPacketDelegate(CMSG.ATTACKSTOP)]
		static void OnAttackStop(WorldClient client, CMSG msgID, BinReader data)
		{
			uint newData=0;
			try
			{
				newData = data.ReadUInt32();
			}
			catch(Exception){}

			//Chat.System(client, "Data:"+newData);
			client.Player.Attacking=false;
			((PlayerObject)client.Player).StopCombat();
		}
	}
}	


