using System;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.MemberValues
{
	public class SubClassMemberValue : MemberValue
	{
		MemberValue m_classValue;
		MemberValue m_memberValue;
		public SubClassMemberValue(MemberValue classValue, MemberValue memberValue)
		{
			m_classValue = classValue;
			m_memberValue = memberValue;
		}

		public override System.Reflection.MemberInfo MemberInfo
		{
			get
			{
				return m_memberValue.MemberInfo;
			}
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

		public MemberValueAttribute ClassAttribute
		{
			get
			{
				return m_classValue.Attribute;
			}
			set
			{
				m_classValue.Attribute = value;
			}
		}

		public override Type GetValueType()
		{
			return m_memberValue.GetValueType();
		}

		public override string GetName()
		{
			return m_classValue.GetName() + "." + m_memberValue.GetName();
		}

		public override object GetValue(object obj)
		{
			object target = m_classValue.GetValue(obj);
			if(target != null)
				return m_memberValue.GetValue(target);
			return null;
		}

		public override void SetValue(object obj, object value)
		{
			object target = m_classValue.GetValue(obj);
			if(target != null) {
				m_memberValue.SetValue(target, value);
				m_classValue.SetValue(obj, target);
			}
		}
	}
}
