using System;
namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Attribute that Marks a Property or Field as Column of the Table
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DataElement : MemberValueAttribute
	{
		private bool allowDbNull;
		private bool unique;
		/// <summary>
		/// Constructor that sets Options of the Column to AllowDBNull and not Unique
		/// </summary>
		public DataElement()
		{
			allowDbNull = true;
			unique = false;
		}

		/// <summary>
		/// Indicates if a value of null is allowed for this Collumn
		/// </summary>
		/// <value><c>true</c> if <c>null</c> is allowed</value>
		public bool AllowDbNull
		{
			get
			{
				return allowDbNull;
			}
			set
			{
				allowDbNull = value;
			}
		}
		/// <summary>
		/// Indicates if a Value has to be Unique in the Table
		/// </summary>
		/// <value><c>true</c> if a Value as to be Unique</value>
		public bool Unique
		{
			get
			{
				return unique;
			}
			set
			{
				unique = value;
			}
		}
	}
}