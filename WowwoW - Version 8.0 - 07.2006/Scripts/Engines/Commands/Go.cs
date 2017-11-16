using System;
using Server;

// Created by TUM 11.05.05

namespace Server.Scripts.Commands
{
	public class Go : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Go", AccessLevels.GM, new CommandEventHandler( Go_OnCommand ) );
			Commands.Register( "Locations", AccessLevels.GM, new CommandEventHandler( Locations_OnCommand ) );
		}

		private static bool Go_OnCommand( CommandEventArgs e )
		{
			Character m = e.Player as Character;
			if (e.Length == 4)
			{
				float x,y,z;
				int MapId;
				try
				{
					x = Convert.ToSingle(e.GetString(0));
					y = Convert.ToSingle(e.GetString(1));
					z = Convert.ToSingle(e.GetString(2));
					MapId = Convert.ToInt32(e.GetString(3));
					m.Teleport(x,y,z,MapId);
					return true;
				}
				catch (Exception)
				{	
				}				
			}
			else if (e.Length == 1)
			{
				if (World.Locations.ContainsKey(e.GetString(0)))
				{
					Position position = (Position) World.Locations[e.GetString(0)];
					m.Teleport(position.X, position.Y, position.Z, position.MapId);
					return true;
				}
				else
				{
					e.SendMessage("Location {0} not found.",e.GetString(0));
					return false;
				}
			}
	        			
			e.SendMessage("Usage: .Go <X> <Y> <Z> <Map Id>");
			e.SendMessage("Usage: .Go <Location Name>");
			return false;
					
		}
		private static bool Locations_OnCommand( CommandEventArgs e )
		{
			foreach (object obj in World.Locations.Keys)
			{
				Position pos = (Position)World.Locations[obj];
                e.SendMessage("Location: {0}, X: {1}, Y: {2}, Z: {3}, MapId: {4}", obj.ToString(), pos.X, pos.Y, pos.Z, pos.MapId);
			}
			return true;
		}
	}
}