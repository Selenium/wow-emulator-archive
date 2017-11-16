using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Cleanup.
	/// </summary>
	[ChatCmdHandler()]
	public class Banish
	{
		[ChatCmdAttribute("banish", "no usage")]
		static bool OnBanish(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}

			LivingObject tmpObj=(LivingObject)client.Player.Selection;

			if ((tmpObj == null) || (tmpObj.ObjectType!=OBJECTTYPE.UNIT))
			{
				Chat.System(client, "Selection is not a monster");
				return false;
			}

			UnitBase mob = (UnitBase)client.Player.Selection;

			DBSpawn tmpSpawn = (DBSpawn)DBManager.GetDBObject(typeof(DBSpawn), (uint)mob.Spawn_ID);

			if (tmpSpawn == null )
			{
				Chat.System(client, "Spawn did not exist: "+mob.Spawn_ID);
			}
			else
			{
				Chat.System(client, "Removed Spawn: "+mob.Spawn_ID+" from the database.");
				DBManager.DeleteDBObject(tmpSpawn);
			}

			mob.SaveAndRemove();
			Chat.System(client, "Removed Monster: "+mob.Name+" with GUID: "+mob.GUID+" from the world.");

//			Console.WriteLine("This is GUID " + mob.GUID + " and spawn_id " + mob.Spawn_ID);
			return true;

		}
	}
}