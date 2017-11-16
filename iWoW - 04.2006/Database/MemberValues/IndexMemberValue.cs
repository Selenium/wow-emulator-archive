using System;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.MemberValues
{
	public class IndexMemberValue : MemberValue
	{
		MemberValue m_memberValue;
		int m_index;
		public IndexMemberValue(MemberValue memberValue, int index)
		{
			m_memberValue = memberValue;
			m_index = index;
		}

		public int Index
		{
			get { return m_index;}
		}
		public override MemberValueAttribute Attribute
		{
			get
			{
				return m_memberValue.Attribute;
			}
			set
			{
				m_memberValue.Attribute = value;
			}
		}

		public override System.Reflection.MemberInfo MemberInfo
		{
			get
			{
				return m_memberValue.MemberInfo;
			}
		}

		public override Type GetValueType()
		{
			return m_memberValue.GetValueType().GetElementType();
		}

		public override string GetName()
		{
			return m_memberValue.GetName() + "_" + m_index;
		}

		public override object GetValue(object obj)
		{
			Array array = m_memberValue.GetValue(obj) as Array;
			if(array != null)
				return array.GetValue(m_index);
			return null;
		}

		public override void SetValue(object obj, object value)
		{
			Array array = m_memberValue.GetValue(obj) as Array;
			if(array != null)
				array.SetValue(value, m_index);
		}
	}
}
