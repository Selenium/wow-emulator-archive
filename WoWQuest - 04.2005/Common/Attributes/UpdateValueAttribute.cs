using System;
using WoWDaemon.Common;
namespace WoWDaemon.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple=true, Inherited=true)]
	public class UpdateValueAttribute : MemberValueAttribute
	{
		int m_field = -1;
		int m_bytesIndex = -1;
		int m_shortsIndex = -1;
		Type m_onlyfortype = null;
		int m_numSubFields = -1;
		public UpdateValueAttribute()
		{
		}

		public UpdateValueAttribute(OBJECTFIELDS field)
		{
			m_field = (int)field;
		}

		public UpdateValueAttribute(ITEMFIELDS field)
		{
			m_field = (int)field;
		}

		public UpdateValueAttribute(CONTAINERFIELDS field)
		{
			m_field = (int)field;
		}

		public UpdateValueAttribute(UNITFIELDS field)
		{
			m_field = (int)field;
		}

		public UpdateValueAttribute(PLAYERFIELDS field)
		{
			m_field = (int)field;
		}

		public UpdateValueAttribute(GAMEOBJECTFIELDS field)
		{
			m_field = (int)field;
		}

		public UpdateValueAttribute(DYNAMICOBJECTFIELDS field)
		{
			m_field = (int)field;
		}

		public UpdateValueAttribute(CORPSEFIELDS field)
		{
			m_field = (int)field;
		}

		/// <summary>
		/// Field must be unique in class, unless it's a byte or short value
		/// </summary>
		public int Field
		{
			get { return m_field;}
			set { m_field = value;}
		}

		/// <summary>
		/// 0-3 byte index in a 32 bit value
		/// </summary>
		public int BytesIndex
		{
			get { return m_bytesIndex;}
			set { m_bytesIndex = value;}
		}

		/// <summary>
		/// 0 for low short value, 1 for high short value
		/// </summary>
		public int ShortsIndex
		{
			get { return m_shortsIndex;}
			set { m_shortsIndex = value;}
		}

		public Type OnlyForType
		{
			get { return m_onlyfortype;}
			set { m_onlyfortype = value;}
		}

		public int NumSubFields
		{
			get { return m_numSubFields;}
			set { m_numSubFields = value;}
		}
	}
}
