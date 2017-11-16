using System;

namespace DDB
{
	/// <summary>
	/// Summary description for Guid.
	/// </summary>
	public class Guid
	{
		UInt64 guid;
		public Guid()
		{
		}
		public Guid( UInt64 g )
		{
			guid = g;
		}
		public override bool Equals(object obj)
		{
			if ( guid == ( obj as Guid ).GUID )
				return true;
			return false;
		}
		public UInt64 GUID
		{
			get { return guid; }
		}

	}
}
