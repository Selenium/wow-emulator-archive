// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;
using Server.Scripts.Commands.JailSystem;

namespace Server.Konsole.Commands
{
	public class KonsoleJail : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Jail", new KonsoleCommandEventHandler( Jail_OnCommand ) );
			KonsoleCommands.Register( "J", new KonsoleCommandEventHandler( Jail_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "Jail <name><d><h><m>" )]
		[Aliases( "\tJ" )]
		[Description( "Sends a player to jail" )]
		public static void Jail_OnCommand( KonsoleCommandEventArgs e )
		{
			if(e.Arguments.Length != 4)
			{
				ShowJailUsage();
				return;
			}

			if(HelperTools.IsNumeric(e.Arguments[1]) &&
				HelperTools.IsNumeric(e.Arguments[2]) &&
				HelperTools.IsNumeric(e.Arguments[3]))
			{
				//Validate player exists
				Character player = GetCharacterByName(e.Arguments[0]);
				if(player == null)
				{
					Console.WriteLine("Could not find a character with the name: ", e.Arguments[0]);
					ShowJailUsage();
					return;
				}

				Jail.JailCharacter(player, int.Parse(e.Arguments[1]), int.Parse(e.Arguments[2]), int.Parse(e.Arguments[3]));
				Console.WriteLine(player.Name, " has been jailed!");

				//Some fun
				//HelperTools.BroadcastToAll("Admin is on a rampage! ", e.Arguments[0], " has been jailed!");

				if(player.Logged)
				{
					player.SendMessage("You have been jailed!");
				}
			}
			else
			{
				Console.WriteLine("<d> <h> <m> parameters must be numeric");
				ShowJailUsage();
				return;
			}
		}
		#endregion

		#region Private Methods
		private static void ShowJailUsage()
		{
			Console.WriteLine("Usage: Jail <player name> <days> <hours> <minutes>");
			Console.WriteLine("Example: Jail JackRipper 1 12 30");
			Console.WriteLine("The above will jail JackRipper for 1 day 12 hours and 30 minutes");
		}

		//This method will move to the Konsole Core after next release
		/// <summary>
		/// Finds a character by it's name
		/// </summary>
		/// <param name="name">Name of the character to find</param>
		/// <returns>Instance of a Character object</returns>
		private static Character GetCharacterByName( string name )
		{
			foreach ( Account acc in World.allAccounts ) 
			{ 
				foreach( Character ch in acc.characteres )
				{
					if(ch.Name.ToUpper() == name.ToUpper() )
					{
						return ch;
					}
				}
			}

			return null;
		}
		#endregion
	}
}
