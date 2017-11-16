using System;

namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Summary description for ChatCmdAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple=true)]
	public class ChatCmdAttribute : Attribute
	{
		string m_cmd = string.Empty;
		string m_usage = string.Empty;
		public ChatCmdAttribute()
		{
		}
		public ChatCmdAttribute(string cmd, string usage)
		{
			m_cmd = cmd;
			m_usage = usage;
		}

		public string Cmd
		{
			get { return m_cmd;}
			set { m_cmd = value;}
		}

		public string Usage
		{
			get { return m_usage;}
			set { m_usage = value;}
		}
	}
}
