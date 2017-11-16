/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/

using System;
using System.Collections;
using System.Reflection;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace Server.Scripts
{
	public class Utility
	{

		private static Encoding m_UTF8, m_UTF8WithEncoding;

		public static Encoding UTF8
		{
			get
			{
				if ( m_UTF8 == null )
					m_UTF8 = new UTF8Encoding( false, false );

				return m_UTF8;
			}
		}

		public static Encoding UTF8WithEncoding
		{
			get
			{
				if ( m_UTF8WithEncoding == null )
					m_UTF8WithEncoding = new UTF8Encoding( true, false );

				return m_UTF8WithEncoding;
			}
		}

		public static bool ToBoolean( string value )
		{
			try
			{
				return Convert.ToBoolean( value );
			}
			catch
			{
				return false;
			}
		}

		public static double ToDouble( string value )
		{
			try
			{
				return Convert.ToDouble( value );
			}
			catch
			{
				return 0.0;
			}
		}

		public static TimeSpan ToTimeSpan( string value )
		{
			try
			{
				return TimeSpan.Parse( value );
			}
			catch
			{
				return TimeSpan.Zero;
			}
		}

		public static int ToInt32( string value )
		{
			try
			{
				if ( value.StartsWith( "0x" ) )
				{
					return Convert.ToInt32( value.Substring( 2 ), 16 );
				}
				else
				{
					return Convert.ToInt32( value );
				}
			}
			catch
			{
				return 0;
			}
		}
	}
}