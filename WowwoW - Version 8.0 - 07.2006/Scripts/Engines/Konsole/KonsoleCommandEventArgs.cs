// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;

namespace Server.Konsole
{
	public class KonsoleCommandEventArgs
	{

		private string m_Command;

		private string m_ArgString;

		private string[] m_Arguments;

		public string Command
		{ 
			get { return m_Command; }
		}

		public string ArgString
		{
			get { return m_ArgString; }
		}

		public string[] Arguments
		{
			get { return m_Arguments; }
		}

		public int Length
		{
			get { return (int)m_Arguments.Length; }
		}

		public KonsoleCommandEventArgs(string command, string argString, string[] arguments)
		{
			this.m_Command = command;
			this.m_ArgString = argString;
			this.m_Arguments = arguments;
		}
	}

}
