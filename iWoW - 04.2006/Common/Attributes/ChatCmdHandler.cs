using System;

namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Summary description for ChatCmdHandler.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class ChatCmdHandler : Attribute
	{
		public ChatCmdHandler()
		{
		}
	}
}
