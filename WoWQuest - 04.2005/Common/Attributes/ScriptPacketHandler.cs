using System;

namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Summary description for ScriptPacketHandler.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple=true)]
	public class ScriptPacketHandler : Attribute
	{
		int m_msgID = -1;
		public ScriptPacketHandler()
		{
		}
		public ScriptPacketHandler(int msgID)
		{
			m_msgID = msgID;
		}

		public int MsgID
		{
			get { return m_msgID;}
			set { m_msgID = value;}
		}
	}
}
