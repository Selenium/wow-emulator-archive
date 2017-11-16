using System;
using System.Reflection;
using System.Collections;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.MemberValues
{
	public abstract class MemberValue
	{
		public abstract MemberValueAttribute Attribute
		{
			get;
			set;
		}

		public abstract MemberInfo MemberInfo
		{
			get;
		}

		public abstract Type GetValueType();
		public abstract string GetName();
		public abstract object GetValue(object obj);
		public abstract void SetValue(object obj, object value);

		public static MemberValue[] GetMemberValues(Type type, Type attribType, bool useIndexers, bool getSubClasses)
		{
			return GetMemberValues(type, new Type[1] { attribType}, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, useIndexers, getSubClasses);
		}

		public static MemberValue[] GetMemberValues(Type type, Type attribType, BindingFlags bindingAttribs, bool useIndexers, bool getSubClasses)
		{
			return GetMemberValues(type, new Type[1] {attribType}, bindingAttribs, useIndexers, getSubClasses);
		}

		public static MemberValue[] GetMemberValues(Type type, Type[] attribTypes, bool useIndexers, bool getSubClasses)
		{
			return GetMemberValues(type, attribTypes, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, useIndexers, getSubClasses);
		}

		public static MemberValue[] GetMemberValues(Type type, Type[] attribTypes, BindingFlags bindingAttribs, bool useIndexers, bool getSubClasses)
		{
			foreach(Type t in attribTypes)
			{
				if(t == typeof(MemberValueAttribute))
					continue;
				Type baseType = t.BaseType;
				do
				{
					if(baseType == typeof(MemberValueAttribute))
						break;
					if(baseType == typeof(object))
						throw new Exception("All attributes must inherit MemberValueAttribute");
				} while((baseType = baseType.BaseType) != null);
			}
			return __getMemberValues(type, attribTypes, bindingAttribs, useIndexers, getSubClasses);
		}

		private static bool isSubClass(Type type)
		{
			if(type == typeof(ulong) ||
				type == typeof(long) ||
				type == typeof(uint) ||
				type == typeof(int) ||
				type == typeof(ushort) ||
				type == typeof(short) ||
				type == typeof(byte) ||
				type == typeof(string) ||
				type.IsEnum)
				return false;
			return true;
		}

		private static MemberValue[] __getMemberValues(Type type, Type[] attribTypes, BindingFlags bindingAttribs, bool useIndexers, bool getSubClasses)
		{
			ArrayList list = new ArrayList();
			foreach(MemberInfo member in type.GetMembers(bindingAttribs))
			{
				if(member is FieldInfo || member is PropertyInfo)
				{
					bool isArray = false;
					Type valueType;
					if(member is FieldInfo)
					{
						FieldInfo info = member as FieldInfo;
						valueType = info.FieldType;						
					}
					else
					{
						PropertyInfo info = member as PropertyInfo;
						valueType = info.PropertyType;
					}
					isArray = valueType.IsArray;
					if(isArray)
						valueType = valueType.GetElementType();
					
					foreach(Type attribType in attribTypes)
					{
						object[] memberattribs = GetCustomAttributes(type, attribType, member);
						if(memberattribs.Length == 0)
							continue;
						foreach(object attrib in memberattribs)
						{
							MemberValue memberValue = null;
							if(member is FieldInfo)
							{
								if(valueType.IsEnum)
									memberValue = new EnumFieldMemberValue(member as FieldInfo);
								else
									memberValue = new FieldMemberValue(member as FieldInfo);
							}
							else
							{
								if(valueType.IsEnum)
									memberValue = new EnumPropertyMemberValue(member as PropertyInfo);
								else
									memberValue = new PropertyMemberValue(member as PropertyInfo);
							}
							memberValue.Attribute = (MemberValueAttribute)attrib;
							bool subClass = isSubClass(valueType);
							if(!subClass)
							{
								if(useIndexers && isArray)
								{
									MemberValueAttribute mva = attrib as MemberValueAttribute;
									if(mva.ArraySize == -1)
										throw new Exception("ArraySize was not set on " + memberValue.GetName());
									for(int i = 0;i < mva.ArraySize;i++)
									{
										MemberValue memval = new IndexMemberValue(memberValue, i);
										list.Add(memval);
									}
								}
								else
								{
									list.Add(memberValue);
								}
							}
							else if(!useIndexers || !getSubClasses)
							{
								list.Add(memberValue);
							}
							else
							{
								MemberValue[] values = __getMemberValues(valueType, attribTypes, bindingAttribs, useIndexers, getSubClasses);
								if(values.Length > 0)
								{
									if(isArray)
									{
										MemberValueAttribute mva = attrib as MemberValueAttribute;
										if(mva.ArraySize == -1)
											throw new Exception("ArraySize was not set on " + memberValue.GetName());
										for(int i = 0;i < mva.ArraySize;i++)
										{
											MemberValue indexValue = new IndexMemberValue(memberValue, i);
											foreach(MemberValue val in values)
											{
												list.Add((MemberValue)new SubClassMemberValue(indexValue, val));
											}
										}
									}
									else
									{
										foreach(MemberValue val in values)
										{
											list.Add((MemberValue)new SubClassMemberValue(memberValue, val));
										}
									}
								}
								else
								{
									if(isArray)
									{
										MemberValueAttribute mva = attrib as MemberValueAttribute;
										if(mva.ArraySize == -1)
											throw new Exception("ArraySize was not set on " + memberValue.GetName());
										for(int i = 0;i < mva.ArraySize;i++)
										{
											list.Add((MemberValue)new IndexMemberValue(memberValue, i));
										}
									}
									else
										list.Add(memberValue);
								}
							}
						}
						break;
					}
				}
			}
			MemberValue[] array = new MemberValue[list.Count];
			if(list.Count > 0)
				list.CopyTo(array);
			return array;
		}

		#region GetCustomAttributes
		static object[] GetCustomAttributes(Type type, Type attribType, MemberInfo member)
		{
			if(member is FieldInfo)
				return GetFieldCustomAttributes(type, attribType, member.Name);
			if(member is PropertyInfo)
				return GetPropCustomAttributes(type, attribType, member.Name);
			return null;
		}
		#endregion
		#region GetPropUpdateValueAttributes
		/// <summary>
		/// Not sure this will work so good in certain cases, need to match the overloaded members better
		/// </summary>
		/// <param name="type"></param>
		/// <param name="attribType"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		static object[] GetPropCustomAttributes(Type type, Type attribType, string name)
		{
			PropertyInfo[] properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			foreach(PropertyInfo info in properties)
			{
				if(info.Name == name)
				{
					object[] attribs = info.GetCustomAttributes(attribType, true);
					if(attribs.Length > 0)
						return attribs;
				}
			}
			if(type.BaseType != typeof(object))
				return GetPropCustomAttributes(type.BaseType, attribType, name);
			else
				return new object[0];
		}
		#endregion
		#region GetFieldCustomAttributes
		static object[] GetFieldCustomAttributes(Type type, Type attribType, string name)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			foreach(FieldInfo info in fields)
			{
				if(info.Name == name)
				{
					try
					{
					object[] attribs = info.GetCustomAttributes(attribType, true);
					if(attribs.Length > 0)
						return attribs;
					}
					catch(Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			if(type.BaseType != typeof(object))
				return GetFieldCustomAttributes(type.BaseType, attribType, name);
			else
				return new object[0];
		}
		#endregion
	}

}
