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
using HelperTools;
using Server.Scripts.Properties;

namespace Server.Scripts.Commands
{
	public class Inc : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Inc", AccessLevels.GM, new CommandEventHandler( Inc_OnCommand ), TargetType.AnyMobile );
		}

		private static bool Inc_OnCommand( CommandEventArgs e )
		{
			if ( e.Length >= 2 )
			{
				for ( int i = 0; (i+1) < e.Length; i += 2 )
				{
					if ( e.Target is Character )
					{
						string now = Server.Scripts.Properties.CharacterProperties.GetValue(e.Target, e.GetString( i ));
						if ( (Utility.ToInt32(now) !=0) && (e.GetInt32( i+1 ) != 0 ) )
						{
							if (Server.Scripts.Properties.CharacterProperties.SetValue(e.Target, e.GetString( i ), (Utility.ToInt32(now)+e.GetInt32(i+1)).ToString() ))
							{
								e.SendMessage("Property \"{0}\" of character \"{2}\" incresed on \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
								return true;
							} 
						}

						if ( ! Server.Scripts.Properties.MobileProperties.HasProperty(e.GetString(i) ) )
						{
							e.SendMessage( "Property \"{0}\" on mobile \"{1}\" dont exist.", e.GetString( i ), e.Target.Name );
							return false;
						}

						now = Server.Scripts.Properties.MobileProperties.GetValue(e.Target, e.GetString( i ));
						if ( (Utility.ToInt32(now) !=0) && (e.GetInt32( i+1 ) != 0 ) )
						{
							if (Server.Scripts.Properties.MobileProperties.SetValue(e.Target, e.GetString( i ), (Utility.ToInt32(now)+e.GetInt32(i+1)).ToString() ))
							{
								e.SendMessage( "Property \"{0}\" of mobile \"{2}\" incresed on \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
								return true;
							} 
							else
							{
								e.SendMessage( "Cannot incrise property \"{0}\" of mobile \"{2}\" on value \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
								return false;
							}
						}
						else
						{
							e.SendMessage( "\"{0}\" is not integer value", e.GetString( i+1 ) );
							return false;
						}
					} 
					else
					{
						if ( ! Server.Scripts.Properties.MobileProperties.HasProperty(e.GetString(i) ) )
						{
							e.SendMessage( "Property \"{0}\" on mobile \"{1}\" dont exist.", e.GetString( i ), e.Target.Name );
							return false;
						}
						string now = Server.Scripts.Properties.MobileProperties.GetValue(e.Target, e.GetString( i ));
						if ( (Utility.ToInt32(now) !=0) && (e.GetInt32( i+1 ) != 0 ) )
						{
							if (Server.Scripts.Properties.MobileProperties.SetValue(e.Target, e.GetString( i ), (Utility.ToInt32(now)+e.GetInt32(i+1)).ToString() ))
							{
								e.SendMessage( "Property \"{0}\" of mobile \"{2}\" incresed on \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
								return true;
							} 
							else
							{
								e.SendMessage( "Cannot incrise property \"{0}\" of mobile \"{2}\" on value \"{1}\".", e.GetString( i ), e.GetString( i+1 ), e.Target.Name );
								return false;
							}
						}
						else
						{
							e.SendMessage( "\"{0}\" is not integer value", e.GetString( i+1 ) );
							return false;
						}
					}
				}
				return false;

			}
			else
			{
				e.SendMessage( "Format: Inc <propertyName> <value> [<propertyName> <value> ...]" );
				return false;
			}

		}
	}
}