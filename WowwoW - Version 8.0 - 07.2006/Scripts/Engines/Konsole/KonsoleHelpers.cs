// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	/// <summary>
	/// Konsole HelperTools
	/// </summary>
	public class HelperTools
	{
		/// <summary>
		/// Tests if a passed value is numeric
		/// </summary>
		/// <param name="val">value to test</param>
		/// <returns>true/false</returns>
		public static bool IsNumeric(string val)
		{
			double testInt = 0;
			return double.TryParse(val, System.Globalization.NumberStyles.Integer, null, out testInt);
		}

		/// <summary>
		/// Broadcasts text to all online characters
		/// </summary>
		/// <param name="text">Text to broadcast</param>
		public static void BroadcastToAll(string text)
		{
			World.allConnectedAccounts.BroadCastMessage(text);
		}
		
		public static Account GetAccByName( string name ) 
		{ 
			Account result   = null; 
			string lname   = name.ToLower(); 
			foreach ( Account a in World.allAccounts ) 
			{ 
				if ( a.Username.ToLower() == lname ) 
				{ 
					result = a; 
					break; 
				} 
			} 
			return result; 
		}
		public static bool AccExists( string name ) 
		{ 
			bool result      = false; 
			string lname   = name.ToLower(); 
			foreach ( Account a in World.allAccounts ) 
			{ 
				if ( a.Username.ToLower() == lname ) 
				{ 
					result = true; 
					break; 
				} 
			} 
			return result; 
		
	}
}
}
