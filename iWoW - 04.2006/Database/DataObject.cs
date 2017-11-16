using System;
using System.ComponentModel;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database
{
	/// <summary>
	/// Abstract Baseclass for all DataObject's. All Classes that are derived from this class
	/// are stored in a Datastore
	/// </summary>
	public abstract class DataObject
	{
		[ServerSerialize]
		protected uint objectId;

		[ServerSerialize]
		protected bool dirty;

		[ServerSerialize]
		protected bool valid;

		/// <summary>
		/// Default-Construktor that generates a new Object-ID and set
		/// Dirty and Valid to <c>false</c>
		/// </summary>
		public DataObject()
		{
			//objectId = IdGenerator.generateId(this.GetType());
			objectId = 0;
			dirty = false;
			valid = false;
		}

		/// <summary>
		/// Returns the Tablename for an Objecttype. 
		/// Reads the DataTable-Attribute or if
		/// not defined returns the Classname
		/// </summary>
		/// <param name="myType">get the Tablename for this DataObject</param>
		/// <returns>The </returns>
		public static string GetTableName(Type myType)
		{
			object[] attri = myType.GetCustomAttributes(typeof(DataTable), true);

			if((attri.Length >= 1) && (attri[0] is DataTable))
			{
				DataTable tab = attri[0] as DataTable;
					
				string name = tab.TableName;

				if(name != null)
					return name;
			}

			return myType.Name;
		}

		[Browsable(false)]
		public virtual string TableName
		{
			get
			{
				Type myType = this.GetType();

				return DataObject.GetTableName(myType);
			}
		}

		[Browsable(false)]
		public bool IsValid
		{
			get
			{
				return valid;
			}
			set
			{
				valid = value;
			}
		}

		[Browsable(false)]
		abstract public bool AutoSave
		{
			get;
			set;
		}

		[Browsable(false)]
		public uint ObjectId
		{
			get
			{
				return objectId;
			}
			set
			{
				objectId = value;
			}
		}

		[Browsable(false)]
		public bool Dirty
		{
			set
			{
				dirty = value;
			}
			get
			{
				return dirty;
			}
		}
	}
}
