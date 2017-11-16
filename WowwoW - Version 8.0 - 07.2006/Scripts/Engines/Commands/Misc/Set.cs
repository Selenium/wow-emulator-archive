/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/
using System;
using System.Collections;
using Server;
using Server.Scripts;

using Server.Scripts.Properties;

namespace Server.Scripts.Commands
{
	public class Set : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Set", AccessLevels.GM, new CommandEventHandler( Set_OnCommand ), TargetType.AnyMobile );
		}

		private static bool Set_OnCommand( CommandEventArgs e )
		{
			if ( e.Length >= 2 )
			{
				for ( int i = 0; (i+1) < e.Length; i += 2 )
				{
					if ( e.Target is Character )
					{
						if (!Server.Scripts.Properties.CharacterProperties.HasProperty(e.GetString( i )))
						{

						}
						else if (e.Player.Player.AccessLevel < Server.Scripts.Properties.CharacterProperties.GetAccessLevel(e.GetString( i )) )
						{
							e.SendMessage("You dont have access to change this property.");
							continue;
						}
						else if (Server.Scripts.Properties.CharacterProperties.SetValue(e.Target, e.GetString( i ), e.GetString( i+1 ) ))
						{
							e.SendMessage("Property \"{0}\" of character \"{2}\" set to value \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
							continue;
						}
					}

					if (!Server.Scripts.Properties.MobileProperties.HasProperty(e.GetString( i )))
					{
						e.SendMessage("Property \"{0}\" on mobile \"{2}\" dont exist.", e.GetString(i), e.Target.Name);
						continue;
					}
					else if (e.Player.Player.AccessLevel < Server.Scripts.Properties.MobileProperties.GetAccessLevel(e.GetString( i )) )
					{
						e.SendMessage("You dont have access to change this property.");
						continue;
					}
					else if (Server.Scripts.Properties.MobileProperties.SetValue(e.Target, e.GetString( i ), e.GetString( i+1 ) ))
					{
						e.SendMessage( "Property \"{0}\" of mobile \"{2}\" set to value \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
						continue;
					} 
					else
					{
						e.SendMessage( "Cannot set property \"{0}\" of mobile \"{2}\" to value \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
						continue;
					}
				}
				return true;
			}
			else
			{
				e.SendMessage( "Format: Set <propertyName> <value> [...]" );
				return false;
			}
		}

	}
}