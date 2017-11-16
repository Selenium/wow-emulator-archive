// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using System.Collections;

namespace Server.Konsole
{
	public class KonsoleCommands
	{
		private static Hashtable m_KonsoleCMDs = new Hashtable(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);

		public static Hashtable Commands
		{ 
			get { return m_KonsoleCMDs; } 
		}

		public static void Register(string command, KonsoleCommandEventHandler handler)
		{
			m_KonsoleCMDs[command] = new KonsoleCommandEntry(command, handler);
		}

		public static bool ProcessKonsoleInput(string text)
		{
			string strCommand = text;
			string strArgument = "";
			string[] strArgumentList = {};
			string[] strtSplit = {};

			try
			{

			strtSplit = text.Split(' ');
			if (strtSplit.Length >= 2)
			{
				strCommand = strtSplit[0];
				ArrayList list = new ArrayList();
				for ( int i = 1; i < strtSplit.Length; ++i )
				{
					strArgument = strArgument + " " + strtSplit[i];
					list.Add( strtSplit[i] );
				}
				strArgumentList = (string[])list.ToArray( typeof( string ) );
			}

				KonsoleCommandEntry commandEntry = (KonsoleCommandEntry)m_KonsoleCMDs[strCommand];
				if (commandEntry == null)
				{
					return false;
				}
				else if (commandEntry.Handler != null)
				{
					commandEntry.Handler(new KonsoleCommandEventArgs(strCommand, strArgument, strArgumentList));
					return true;
				}
			}
			catch
			{
				throw new ArgumentException();
			}
			return false;
		}
	}
}