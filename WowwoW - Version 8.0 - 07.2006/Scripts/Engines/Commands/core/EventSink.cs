/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/

using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using Server;

using Server.Scripts.Commands;
using Server.Scripts.Properties;

namespace Server.Scripts
{
	public class EventSink
	{
		public static event CommandEventHandler Command;
		public static event PropertyEventHandler Property;
		public static event GetPropertyEventHandler GetProperty;

		public static bool InvokeCommand( CommandEventArgs e )
		{
			if ( Command != null )
			{
				return Command( e );
			}
			return false;

		}
		public static void InvokeProperty( PropertyEventArgs e )
		{
			if ( Property != null )
				Property( e );
		}
		public static string InvokeGetProperty( GetPropertyEventArgs e )
		{
			if ( GetProperty != null )
			{
				return GetProperty( e );
			}
			return "";
		}

		public static void Reset()
		{
			Command = null;
			Property = null;
			GetProperty = null;
		}

	}
}