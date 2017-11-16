// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole
{
	public class KonsoleCommandEntry
	{
		private string m_Command;

		private KonsoleCommandEventHandler m_Handler;

		public string Command
		{
			get { return m_Command; }
		}

		public KonsoleCommandEventHandler Handler
		{
			get { return m_Handler; }
		}

		public KonsoleCommandEntry(string command, KonsoleCommandEventHandler handler)
		{
			m_Command = command;
			m_Handler = handler;
		}
	}
}
