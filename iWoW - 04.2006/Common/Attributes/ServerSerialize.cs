using System;

namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Summary description for Serialize.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class ServerSerialize : MemberValueAttribute
	{
		public ServerSerialize()
		{
		}
	}
}
