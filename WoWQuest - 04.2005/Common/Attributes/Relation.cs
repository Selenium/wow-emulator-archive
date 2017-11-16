using System;
namespace WoWDaemon.Common.Attributes
{
	/// <summary>
	/// Attribute to indicate an Relationship to another DatabaseObject.
	/// </summary>
	/// 
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class Relation : MemberValueAttribute
	{
		private string localField;
		private string remoteField;
		private bool autoLoad;
		private bool autoDelete;

		/// <summary>
		/// Constructor for the Relation-Attribute.
		/// Standartsettings are:
		///		AutoLoad = true
		///		AutoDelete = false
		/// </summary>
		public Relation()
		{
			localField = null;
			remoteField = null;
			autoLoad=true;
			autoDelete = false;
		}

		/// <summary>
		/// Property to set/get the Name of the LocalField for the Relation
		/// </summary>
		/// <value>Name of the Local Field</value>
		public string LocalField
		{
			get
			{
				return localField;
			}
			set
			{
				localField = value;
			}
		}

		/// <summary>
		/// Property to set/get the RemoteField of the Relation
		/// </summary>
		/// <value>Name of the Remote Field</value>
		public string RemoteField
		{
			get
			{
				return remoteField;
			}
			set
			{
				remoteField = value;
			}
		}

		/// <summary>
		/// Property to set/get Autoload
		/// If Autoload is true the Releation is filled on Object load/reload
		/// If false you have to fill the Relation with Database.FillObjectRelations(DataObject)
		/// </summary>
		/// <value><c>true</c> if Relation sould be filled automatical</value>
		public bool AutoLoad
		{
			get
			{
				return autoLoad;
			}
			set
			{
				autoLoad = value;
			}
		}

		/// <summary>
		/// AutoDelete-Property to set/get AutoDelete
		/// If set to true, all related Objects are deleted from Database when the Object is deleted
		/// If set to false, the related Objects are NOT deleted.
		/// </summary>
		/// <value><c>true</c> if related objects are deleted as well</value>
		public bool AutoDelete
		{
			get
			{
				return autoDelete;
			}
			set
			{
				autoDelete = value;
			}
		}

	}
}
