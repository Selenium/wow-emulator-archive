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
	public class Get : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Get", AccessLevels.GM, new CommandEventHandler( Get_OnCommand ), TargetType.AnyMobile );
		}

		private static bool Get_OnCommand( CommandEventArgs e )
		{
			if ( e.Length >= 1 )
			{
				for ( int i = 0; i < e.Length; i ++ )
				{
					if ( e.Target is Character )
					{
						if (!Server.Scripts.Properties.CharacterProperties.HasProperty(e.GetString( i )))
						{

						}
						else if ( (Server.Scripts.Properties.CharacterProperties.GetAccessLevel(e.GetString( i ) ) ) > e.Player.Player.AccessLevel)
						{
							e.SendMessage("You dont have access to read this property.");
							//return false;
						} 
						else
						{							
							string val = Server.Scripts.Properties.CharacterProperties.GetValue(e.Target, e.GetString( i ));
							e.Player.SendMessage(e.GetString( i ) + " : " + val);
						}
					} 
						
					if (!Server.Scripts.Properties.MobileProperties.HasProperty(e.GetString( i )))
					{
						e.SendMessage("This property dont exist.");
						//return false;
					}
					else if ( (Server.Scripts.Properties.MobileProperties.GetAccessLevel(e.GetString( i ) ) ) > e.Player.Player.AccessLevel)
					{
						e.SendMessage("You dont have access to read this property.");
						//return false;
					} 
					else
					{							
						string val = Server.Scripts.Properties.MobileProperties.GetValue(e.Target, e.GetString( i ));
						e.Player.SendMessage(e.GetString( i ) + " : " + val);
					}
				}
				return true;
			}
			else
			{
				e.SendMessage( "Format: Get <propertyName> [ <propertyName> ...]" );
				return false;
			}
		}

	}
}