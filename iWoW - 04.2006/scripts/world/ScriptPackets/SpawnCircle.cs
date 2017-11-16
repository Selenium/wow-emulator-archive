using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Database.DataTables;
using WoWDaemon.World;
namespace WorldScripts.ScriptPackets
{
	/// <summary>
	/// Summary description for Spawn.
	/// </summary>
	[ScriptPacketHandler()]
	public class SpawnCircle
	{
		static UnitBase GetNewUnit(DBCreature creature, int displayID)
		{
			UnitBase unit = new UnitBase(creature);
			unit.DisplayID = displayID;
			unit.MaxHealth = unit.Health = 100;
			unit.MaxPower = unit.Power = 100;
			unit.PowerType = POWERTYPE.MANA;
			unit.Level = new Random().Next(10);
			unit.Faction = 0;
			return unit;
		}

		[ScriptPacketHandler(MsgID=0x02)]
		static void OnSpawnCircle(int msgID, BinReader data)
		{
			uint charID = data.ReadUInt32();
			uint creatureID = data.ReadUInt32();
			int displayID = data.ReadInt32();

			WorldClient client = WorldServer.GetClientByCharacterID(charID);
			if(client == null)
				return;
			DBCreature creature = (DBCreature)DBManager.GetDBObject(typeof(DBCreature), creatureID);
			float ypos = client.Player.Position.Y;
			float xpos = client.Player.Position.X;
			float zpos = client.Player.Position.Z+50.0f;
			
			for(int nIndex = 18; nIndex <= 378; nIndex+= 18)
			{
				double theta = DegreeToRadians((double)nIndex);
				double x = 10.0*Math.Cos(theta)+xpos;
				double y = 10.0*Math.Sin(theta)+ypos;

				UnitBase unit = GetNewUnit(creature, displayID);
				unit.Position = new Vector((float)x, (float)y, zpos);
				unit.Facing = GetFacing(unit.Position, client.Player.Position);
				client.Player.MapTile.Map.Enter(unit);
			}
		}

		static float GetFacing(Vector pos1, Vector pos2)
		{
			double dx = pos2.X-pos1.X;
			double dy = pos2.Y-pos1.Y;
			return (float)Math.Atan2(dy, dx);
		}

		static double DegreeToRadians(double degree)
		{
			if(degree > 360.0)
				degree -= 360.0;
			return ((2*Math.PI)/360)*degree;
		}
	}
}
