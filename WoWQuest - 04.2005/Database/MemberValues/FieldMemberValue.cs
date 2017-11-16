using System;
using System.Reflection;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.MemberValues
{
	public class FieldMemberValue : MemberValue
	{
		protected FieldInfo m_info;
		public FieldMemberValue(FieldInfo info)
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
			return m_info.FieldType;
		}

		public override string GetName()
		{
			if(m_attribute.Name != string.Empty)
				return m_attribute.Name;
			return m_info.Name;
		}

		public override object GetValue(object obj)
		{
			return m_info.GetValue(obj);
		}

		public override void SetValue(object obj, object value)
		{
			m_info.SetValue(obj, value);
		}
	}

	public class EnumFieldMemberValue : FieldMemberValue
	{
		public EnumFieldMemberValue(FieldInfo info) : base(info)
		{

		}

		public override Type GetValueType()
		{
			return Enum.GetUnderlyingType(m_info.FieldType);
		}


		public override void SetValue(object obj, object value)
		{
			m_info.SetValue(obj, Enum.ToObject(m_info.FieldType, value));
		}

	}

}
