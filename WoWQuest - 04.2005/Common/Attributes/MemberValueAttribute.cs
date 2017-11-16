using System;

namespace WoWDaemon.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple=true)]
	public class MemberValueAttribute : Attribute
	{
		int m_arraySize = -1;
		string m_name = string.Empty;
		bool m_serialize = true;
		public MemberValueAttribute()
		{
		}

		public int ArraySize
		{
			get { return m_arraySize;}
			set { m_arraySize = value;}
		}

		public string Name
		{
			get { return m_name;}
			set { m_name = value;}
		}

		public bool Serialize
		{
			get { return m_serialize;}
			set { m_serialize = value;}
		}
	}
}
