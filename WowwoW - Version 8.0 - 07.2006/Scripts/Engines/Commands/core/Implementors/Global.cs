/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/
using System;
using Server;
using System.Collections;

namespace Server.Scripts.Commands
{
	public class Global : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Global", AccessLevels.Admin, new CommandEventHandler( Global_OnCommand ) );
		}

		private static bool HaveSpaces(string str)
		{
			for (int i=0; i<str.Length; i++)
			{
				if (str[i] == ' ')
				{
					return true;
				}
			}
			return false;
		}

		private static bool Global_OnCommand( CommandEventArgs e )
		{
			if (e.Length == 0) 
			{
				e.SendMessage("Need some parametrs");
				return false;
			}
			int CorrectCount = 0;
			int AllCount = 0;

			PropsChecker prop = new PropsChecker();
			int i = -1;
			int startSumbol = 0;
			if (e.GetString(0) == "if")
			{
				startSumbol = 8;
				for ( i = 1; (i+2) < e.Length; i += 3 )
				{
					if (e.GetString(i)=="then")
					{
						break;
					}
					if (!Server.Scripts.Properties.CharacterProperties.HasProperty(e.GetString(i)) && !Server.Scripts.Properties.MobileProperties.HasProperty(e.GetString(i)))
					{
						e.SendMessage("Wrong property \"{0}\" in if_then block", e.GetString(i));
					}

					if ( !prop.AddProperty(e.GetString(i), e.GetString(i+1), e.GetString(i+2)) )
					{
						e.SendMessage("Wrong sumbol(s) \"{0}\" in if_then block or incorrect type of value \"{1}\"", e.GetString(i+1), e.GetString(i+2));
						return false;
					}
					startSumbol+=e.GetString(i).Length  + e.GetString(i+1).Length + e.GetString(i+2).Length + 3;
				}
			}

			int startNum = i+1;

			string str = ".";
			for (i = startNum; i<e.Length; i++)
			{
				if ( HaveSpaces(e.GetString(i)))
				{
					str+="\"";
					str+=e.GetString(i);
					str+="\"";
				}
				else
				{
					str+=e.GetString(i);
				}
				if (i!=e.Length-1)
				{
					str+=" ";
				}
			}
			if (!Commands.HasCommand(e.GetString(startNum)))
			{
				e.SendMessage("Command \"{0}\" dont exist.", e.GetString(startNum));
				return false;
			}
			if (Commands.TargetType(e.GetString(startNum)) == TargetType.None)
			{
				e.SendMessage("Command \"{0}\" dont have target variable.", e.GetString(startNum));
				return false;
			}

			
			MobileList.MobileEnumerator enumerator = World.allMobiles.GetEnumerator();
			{
				try
				{
					while( enumerator.MoveNext() )
					{
						Mobile targ = (Mobile) enumerator.Current;
						if (prop.Check( targ ) )
						{
							if (Commands.Handle(e.Player, targ, str, true )) CorrectCount++;
							AllCount++;
						}
					}
				}
				finally
				{
				}
			}
			e.SendMessage(String.Format( "Command correctly used on {0} of {1} Mobiles in the world", CorrectCount, AllCount ));
			return true;
		}
	}
}