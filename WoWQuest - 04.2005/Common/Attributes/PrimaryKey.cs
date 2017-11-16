using System;

namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Attribute to indicate the PrimaryKey of an DatabaseObject .
	/// </summary>
	/// 
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class PrimaryKey : DataElement
	{
		/// <summary>
		/// Constructor for Attribute
		/// </summary>
		public PrimaryKey()
		{
		}
	}
}
