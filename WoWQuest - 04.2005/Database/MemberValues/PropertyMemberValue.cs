using System;
using System.Reflection;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.MemberValues
{
	public class PropertyMemberValue : MemberValue
	{
		protected PropertyInfo m_info;
		public PropertyMemberValue(PropertyInfo info)
		{
			m_info = info;
		}

		public override MemberInfo MemberInfo
		{
			get
			{
				return m_info;
			}
		}

		MemberValueAttribute m_attribute;
		public override MemberValueAttribute Attribute
		{
			get
			{
				return m_attribute;
			}
			set
			{
				m_attribute = value;
			}
		}

		public override Type GetValueType()
		{
			return m_info.PropertyType;
		}

		public override string GetName()
		{
			if(m_attribute.Name != string.Empty)
				return m_attribute.Name;
			return m_info.Name;
		}

		public override object GetValue(object obj)
		{
			return m_info.GetValue(obj, null);
		}

		public override void SetValue(object obj, object value)
		{
			m_info.SetValue(obj, value, null);
		}
	}

	public class EnumPropertyMemberValue : PropertyMemberValue
	{
		public EnumPropertyMemberValue(PropertyInfo info) : base(info)
		{

		}

		public override Type GetValueType()
		{
			return Enum.GetUnderlyingType(m_info.PropertyType);
		}

		public override void SetValue(object obj, object value)
		{
			m_info.SetValue(obj, Enum.ToObject(m_info.PropertyType, value), null);
		}
	}
}
