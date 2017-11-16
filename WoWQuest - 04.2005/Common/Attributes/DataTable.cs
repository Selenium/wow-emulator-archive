using System;

namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Attribute to mark a Derived Class of DataObject as Table
	/// Mainly to set the TableName differnt to Classname
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class DataTable : Attribute
	{
		private string tableName;

		/// <summary>
		/// Constrctor of DataTable sets the TableName-Property to null.
		/// </summary>
		public DataTable()
		{
			tableName = null;
		}

		/// <summary>
		/// TableName-Property if null the Classname is used as Tablename.
		/// </summary>
		/// <value>The TableName that sould be used or <c>null</c> for Classname</value>

		public string TableName
		{
			get
			{
				return tableName;
			}
			set
			{
				tableName=value;
			}
		}
	}
}
