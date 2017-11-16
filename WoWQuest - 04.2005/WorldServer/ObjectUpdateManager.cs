using System;
using System.Reflection;
using System.Collections;
using System.IO;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Database.MemberValues;

namespace WoWDaemon.World
{

	#region UpdateObjectAttribute
	[AttributeUsage(AttributeTargets.Class)]
	public class UpdateObjectAttribute : Attribute
	{
		int m_maxFields = -1;
		public UpdateObjectAttribute()
		{
		}
		public int MaxFields
		{
			get {return m_maxFields;}
			set {m_maxFields = value;}
		}
	}
	#endregion

	#region ObjectUpdateManagerException
	public class ObjectUpdateManagerException : Exception
	{
		public ObjectUpdateManagerException(string msg) : base(msg)
		{
		}
	}
	#endregion

	public class ObjectUpdateManager
	{
		static Hashtable m_updateObjectInfos = new Hashtable();

		private ObjectUpdateManager()
		{
		}

		#region WriteDataUpdate
		public static void WriteDataUpdate(BinWriter w, BinaryTree values, object obj, bool clear, bool isClient)
		{
			try {
				//Console.WriteLine("Type: "+obj.GetType());
				UpdateObjectInfo info = (UpdateObjectInfo)m_updateObjectInfos[obj.GetType()];
				if(info == null)
					throw new ObjectUpdateManagerException("UpdateObjectInfo is missing for type " + obj.GetType());
				if (!isClient && obj.GetType()==typeof(PlayerObject))
				{
					info.MaxFields=(int)PLAYERFIELDS.MAX_NOTCLIENT;
					info.BlockSize = (byte)((info.MaxFields+31)/32);
				}
				w.Write(info.BlockSize);
				byte[] mask = new byte[info.BlockSize*4];
				IEnumerator e = values.GetEnumerator();
				Hashtable tbl = info.tbl;
				long maskPos = w.BaseStream.Position;
				w.BaseStream.Position += mask.Length;
				while(e.MoveNext())
				{
					if ((!isClient && ((int)e.Current <= (int)PLAYERFIELDS.MAX_NOTCLIENT))||(isClient))
					{
						IUpdateValue updater = (IUpdateValue)tbl[(int)e.Current];
						if(updater == null)
							throw new ObjectUpdateManagerException("UpdateValue Handler is missing for field " + e.Current + " in " + obj.GetType().ToString());
						updater.WriteValue(obj, w, mask);
					}
				}
				long pos = w.BaseStream.Position;
				w.BaseStream.Position = maskPos;
				w.Write(mask, 0, mask.Length);
				w.BaseStream.Position = pos;
				if(clear)
					values.Clear();
				else
					e.Reset();
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}
		#endregion
		
		#region SearchAssemblyForUpdateObjects
		public static void SearchAssemblyForUpdateObjects(Assembly assembly)
		{
			try {
				foreach (Type type in assembly.GetTypes()) 
				{
					if(type.IsClass == false) 
						continue;
					if(type.IsAbstract == true)
						continue;
					if(type.IsDefined(typeof(UpdateObjectAttribute), true))
					{
						RegisterUpdateObject(type);
					}
				}
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}
		#endregion

		#region RegisterUpdateObject
		public static void RegisterUpdateObject(Type type)
		{
			try {
				object[] tmp = type.GetCustomAttributes(typeof(UpdateObjectAttribute), true);
				if(tmp.Length == 0)
					throw new ObjectUpdateManagerException(type.ToString() + " has no UpdateObjectAttribute");
				UpdateObjectAttribute updateObjectAttribute = (UpdateObjectAttribute)tmp[0];
				if(updateObjectAttribute.MaxFields == -1)
					throw new ObjectUpdateManagerException("MaxFields is not set in UpdateObjectAttribute on " + type.ToString());

				Hashtable tbl = new Hashtable();
				foreach(MemberValue value in MemberValue.GetMemberValues(type, typeof(UpdateValueAttribute), true, false))
				{
					UpdateValueAttribute attrib = (UpdateValueAttribute)value.Attribute;
					if(!checkType(attrib, type))
						continue;
					Type valueType = value.GetValueType();
					if(valueType.IsArray == false)
					{
						if(!IsSubClass(valueType))
						{
							if(attrib.Field == -1)
								throw new ObjectUpdateManagerException("Field was not set on " + type.Name + value.GetName());
							if(value is IndexMemberValue)
							{
								IndexMemberValue indexValue = value as IndexMemberValue;
								if(valueType == typeof(ulong) || valueType == typeof(long))
									AddUpdateValue(tbl, value, attrib.Field + indexValue.Index*2);
								else
									AddUpdateValue(tbl, value, attrib.Field + indexValue.Index);
							}
							else
							{
								AddUpdateValue(tbl, value, attrib.Field);
							}
						}
						else
						{
							GetSubClassUpdateValues(tbl, value, attrib.Field == -1 ? 0 : attrib.Field, valueType, type);
						}
					}
					else
					{
						if(attrib.ArraySize == -1)
							throw new ObjectUpdateManagerException("ArraySize was not set on " + type.Name + "." + value.GetName());
						if(attrib.Field == -1)
							throw new ObjectUpdateManagerException("Field was not set on the array " + type.Name + "." + value.GetName());
						if(attrib.NumSubFields == -1)
							throw new ObjectUpdateManagerException("NumFields was not set on the subclass array " + type.Name + "." + value.GetName());
						valueType = valueType.GetElementType();
						for(int i = 0;i < attrib.ArraySize;i++)
						{
							IndexMemberValue indexValue = new IndexMemberValue(value, i);
							GetSubClassUpdateValues(tbl, indexValue, attrib.Field + i*attrib.NumSubFields, valueType, type);
						}
					}
				}

				if(tbl.Count == 0)
					throw new ObjectUpdateManagerException("No update values in " + type.ToString());
				UpdateObjectInfo uoi = new UpdateObjectInfo(tbl, updateObjectAttribute.MaxFields);
				m_updateObjectInfos[type] = uoi;
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}
		#endregion

		#region Helper functions
		#region GetSubClassUpdateValues
		static void GetSubClassUpdateValues(Hashtable tbl, MemberValue parentValue, int baseField, Type type, Type updateObjectType)
		{
			foreach(MemberValue tmp in MemberValue.GetMemberValues(type, typeof(UpdateValueAttribute), true, false))
			{
				MemberValue value = new SubClassMemberValue(parentValue, tmp);
				UpdateValueAttribute attrib = (UpdateValueAttribute)value.Attribute;
				if(!checkType(attrib, updateObjectType))
					continue;
				Type valueType = value.GetValueType();
				if(valueType.IsArray == false)
				{
					if(!IsSubClass(valueType))
					{
						if(attrib.Field == -1)
							throw new ObjectUpdateManagerException("Field was not set on " + updateObjectType.Name + value.GetName());
						if(tmp is IndexMemberValue)
						{
							IndexMemberValue indexValue = tmp as IndexMemberValue;
							if(valueType == typeof(ulong) || valueType == typeof(long))
								AddUpdateValue(tbl, value, baseField + attrib.Field + indexValue.Index*2);
							else
								AddUpdateValue(tbl, value, baseField + attrib.Field + indexValue.Index);
						}
						else
						{
							AddUpdateValue(tbl, value, baseField + attrib.Field);
						}
					}
					else
					{
						GetSubClassUpdateValues(tbl, value, attrib.Field == -1 ? baseField : (baseField+attrib.Field), valueType, type);
					}
				}
				else
				{
					if(attrib.ArraySize == -1)
						throw new ObjectUpdateManagerException("ArraySize was not set on " + updateObjectType.Name + "." + value.GetName());
					if(attrib.Field == -1)
						throw new ObjectUpdateManagerException("Field was not set on the array " + updateObjectType.Name + "." + value.GetName());
					if(attrib.NumSubFields == -1)
						throw new ObjectUpdateManagerException("NumFields was not set on the subclass array " + updateObjectType.Name + "." + value.GetName());
					valueType = valueType.GetElementType();
					for(int i = 0;i < attrib.ArraySize;i++)
					{
						IndexMemberValue indexValue = new IndexMemberValue(value, i);
						GetSubClassUpdateValues(tbl, indexValue, baseField + attrib.Field + i*attrib.NumSubFields, valueType, updateObjectType);
					}
				}
			}
		}
		#endregion
		#region AddUpdateValue
		static void AddUpdateValue(Hashtable tbl, MemberValue value, int field)
		{
			Type valueType = value.GetValueType();

			if(valueType == typeof(short) || valueType == typeof(ushort))
			{
				GetShortsUpdateValue(tbl, value, field);
			}
			else if(valueType == typeof(byte))
			{
				GetBytesUpdateValue(tbl, value, field);
			}
			else
			{
				if(tbl.Contains(field) ||
					((valueType == typeof(ulong) || valueType == typeof(long)) && tbl.Contains(field+1)))
					throw new ObjectUpdateManagerException("There is already an updateval handler assigned to field " + field + " (" + value.GetName() + ")");
				tbl[field] = GetUpdateValue(valueType, value, field);
			}
			//Console.WriteLine(value.GetName() + " " + field);
		}
		#endregion
		#region checkType
		static bool checkType(UpdateValueAttribute attrib, Type type)
		{
			if(attrib.OnlyForType == null)
				return true;
			if(attrib.OnlyForType == type)
				return true;
			while(type.BaseType != typeof(object))
			{
				type = type.BaseType;
				if(attrib.OnlyForType == type)
					return true;
			}
			return false;
		}
		#endregion
		#region IsSubClass
		static bool IsSubClass(Type valueType)
		{
			if(valueType == typeof(ulong)
				|| valueType == typeof(long)
				|| valueType == typeof(uint)
				|| valueType == typeof(int)
				|| valueType == typeof(ushort)
				|| valueType == typeof(short)
				|| valueType == typeof(float)
				|| valueType == typeof(byte))
				return false;
			return true;
		}
		#endregion
		#region GetUpdateValue
		static IUpdateValue GetUpdateValue(Type valueType, MemberValue memberValue, int field)
		{
			if(valueType == typeof(ulong))
			{
				if((field % 2) == 0)
					return new UInt64UpdateValue(memberValue, field);
				else
					return new UInt64UpdateValueUneven(memberValue, field);
			}
			else if(valueType == typeof(long))
			{
				if((field % 2) == 0)
					return new Int64UpdateValue(memberValue, field);
				else
					return new Int64UpdateValueUneven(memberValue, field);
			}
			else if(valueType == typeof(uint))
				return new UInt32UpdateValue(memberValue, field);
			else if(valueType == typeof(int))
				return new Int32UpdateValue(memberValue, field);
			else if(valueType == typeof(float))
				return new FloatUpdateValue(memberValue, field);
			throw new ObjectUpdateManagerException("Invalid UpdateValue type " + valueType.ToString() + " on " + memberValue.GetName());
		}
		#endregion
		#region GetBytesUpdateValue
		static void GetBytesUpdateValue(Hashtable tbl, MemberValue value, int field)
		{
			UpdateValueAttribute attrib = (UpdateValueAttribute)value.Attribute;
			if(attrib.BytesIndex < 0 || attrib.BytesIndex > 3)
				throw new ObjectUpdateManagerException("BytesIndex out of range on " + value.GetName() + " BytesIndex = " + attrib.BytesIndex);
			BytesUpdateValue v;
			if(tbl.Contains(field))
			{
				IUpdateValue tmp = (IUpdateValue)tbl[field];
				if(!(tmp is BytesUpdateValue))
					throw new ObjectUpdateManagerException("Field " + field + " was a " + tmp.GetType() + " not a BytesUpdateValue (" + value.GetName() + ")");
				v = (BytesUpdateValue)tmp;
			}
			else
			{
				v = new BytesUpdateValue(field);
				tbl[field] = v;
			}
			v.SetMemberValue(value, attrib.BytesIndex);
		}
		#endregion
		#region GetShortsUpdateValue
		static void GetShortsUpdateValue(Hashtable tbl, MemberValue value, int field)
		{
			UpdateValueAttribute attrib = (UpdateValueAttribute)value.Attribute;

			if(attrib.ShortsIndex < 0 || attrib.ShortsIndex > 1)
				throw new ObjectUpdateManagerException("ShortsIndex out of range on " + value.GetName() + " ShortsIndex = " + attrib.ShortsIndex);
			if(tbl.Contains(field))
			{
				object tmp = tbl[field];
				Type cType = tmp.GetType();
				if(cType != typeof(ShortUU_UpdateValue) && cType != typeof(ShortSS_UpdateValue))
					throw new ObjectUpdateManagerException("Failed to combine short values on field " + field + ", type " + tmp.GetType() + " was already in hashtable (" + value.GetName() + ")");
				IShortsCombine c = (IShortsCombine)tmp;
				tbl[field] = c.ShortsCombine(value, attrib.ShortsIndex, value.GetValueType());
			}
			else
			{
				if(value.GetValueType() == typeof(short))
				{
					ShortSS_UpdateValue uv = new ShortSS_UpdateValue(field);
					uv.SetMemberValue(value, attrib.ShortsIndex);
					tbl[field] = uv;
				}
				else
				{
					ShortUU_UpdateValue uv = new ShortUU_UpdateValue(field);
					uv.SetMemberValue(value, attrib.ShortsIndex);
					tbl[field] = uv;
				}
			}
		}
		#endregion
		#endregion

		#region Private Classes
		#region UpdateObjectInfo
		class UpdateObjectInfo
		{
			public Hashtable tbl;
			public int MaxFields;
			public byte BlockSize;
			public UpdateObjectInfo(Hashtable t, int maxFields)
			{
				BlockSize = (byte)((maxFields+31)/32);
				tbl = t;
				MaxFields = maxFields;
			}
		}
		#endregion

		#region ZeroByteMemberValue
		class ZeroByteMemberValue : MemberValue
		{
			public ZeroByteMemberValue()
			{
			}

			public override MemberValueAttribute Attribute
			{
				get
				{
					return null;
				}
				set
				{
				}
			}


			public override MemberInfo MemberInfo
			{
				get
				{
					return null;
				}
			}

			public override Type GetValueType()
			{
				return typeof(byte);
			}

			public override string GetName()
			{
				return GetType().ToString();
			}

			public override object GetValue(object obj)
			{
				return (byte)0;
			}

			public override void SetValue(object obj, object value)
			{

			}

		}
		#endregion
		#region ZeroShortMemberValue
		class ZeroShortMemberValue : MemberValue
		{
			public ZeroShortMemberValue()
			{
			}
			public override MemberValueAttribute Attribute
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public override string GetName()
			{
				return GetType().ToString();
			}

			public override MemberInfo MemberInfo
			{
				get
				{
					return null;
				}
			}

			public override Type GetValueType()
			{
				return typeof(short);
			}

			public override object GetValue(object obj)
			{
				return (short)0;
			}

			public override void SetValue(object obj, object value)
			{

			}
		}
		#endregion
		#region ZeroUShortMemberValue
		class ZeroUShortMemberValue : MemberValue
		{
			public ZeroUShortMemberValue()
			{
			}
			public override MemberValueAttribute Attribute
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public override string GetName()
			{
				return GetType().ToString();
			}

			public override MemberInfo MemberInfo
			{
				get
				{
					return null;
				}
			}

			public override Type GetValueType()
			{
				return typeof(ushort);
			}

			public override object GetValue(object obj)
			{
				return (ushort)0;
			}

			public override void SetValue(object obj, object value)
			{

			}
		}
		#endregion

		#region IUpdateValue
		interface IUpdateValue
		{
			void WriteValue(object from, BinaryWriter w, byte[] mask);
		}
		#endregion
		#region UInt32UpdateValue
		class UInt32UpdateValue : IUpdateValue
		{
			MemberValue m_memberValue;
			int m_maskIndex;
			byte m_maskValue;
			public UInt32UpdateValue(MemberValue memberValue, int field)
			{
				m_memberValue = memberValue;
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((uint)m_memberValue.GetValue(from));
			}
		}
		#endregion
		#region Int32UpdateValue
		class Int32UpdateValue : IUpdateValue
		{
			MemberValue m_memberValue;
			int m_maskIndex;
			byte m_maskValue;
			public Int32UpdateValue(MemberValue memberValue, int field)
			{
				m_memberValue = memberValue;
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((int)m_memberValue.GetValue(from));
			}
		}
		#endregion
		#region UInt64UpdateValue
		class UInt64UpdateValue : IUpdateValue
		{
			MemberValue m_memberValue;
			int m_maskIndex;
			byte m_maskValue;
			public UInt64UpdateValue(MemberValue memberValue, int field)
			{
				m_memberValue = memberValue;
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
				m_maskValue |= (byte)(1 << ((field+1) % 8));
				if((field % 2) != 0)
					throw new Exception("Warning! UInt64UpdateValue needs to be changed. Field " + field + " is not an even value.");
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((ulong)m_memberValue.GetValue(from));
			}
		}
		#endregion
		#region UInt64UpdateValueUneven
		class UInt64UpdateValueUneven : IUpdateValue
		{
			MemberValue m_memberValue;
			int m_maskIndex;
			int m_maskIndex2;
			byte m_maskValue;
			byte m_maskValue2;
			public UInt64UpdateValueUneven(MemberValue memberValue, int field)
			{
				m_memberValue = memberValue;
				m_maskIndex = field/8;
				m_maskIndex2 = (field+1)/8;
				m_maskValue = (byte)(1 << (field % 8));
				m_maskValue2 = (byte)(1 << ((field+1) % 8));
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				mask[m_maskIndex2] |= m_maskValue2;
				w.Write((ulong)m_memberValue.GetValue(from));
			}
		}
		#endregion
		#region Int64UpdateValue
		class Int64UpdateValue : IUpdateValue
		{
			MemberValue m_memberValue;
			int m_maskIndex;
			byte m_maskValue;
			public Int64UpdateValue(MemberValue memberValue, int field)
			{
				m_memberValue = memberValue;
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
				m_maskValue |= (byte)(1 << ((field+1) % 8));
				if((field % 2) != 0)
					throw new Exception("Warning! Int64UpdateValue needs to be changed. Field " + field + " is not an even value.");
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((uint)m_memberValue.GetValue(from));
			}
		}
		#endregion
		#region Int64UpdateValueUneven
		class Int64UpdateValueUneven : IUpdateValue
		{
			MemberValue m_memberValue;
			int m_maskIndex;
			int m_maskIndex2;
			byte m_maskValue;
			byte m_maskValue2;
			public Int64UpdateValueUneven(MemberValue memberValue, int field)
			{
				m_memberValue = memberValue;
				m_maskIndex = field/8;
				m_maskIndex2 = (field+1)/8;
				m_maskValue = (byte)(1 << (field % 8));
				m_maskValue2 = (byte)(1 << ((field+1) % 8));
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				mask[m_maskIndex2] |= m_maskValue2;
				w.Write((long)m_memberValue.GetValue(from));
			}
		}
		#endregion
		#region FloatUpdateValue
		class FloatUpdateValue : IUpdateValue
		{
			MemberValue m_memberValue;
			int m_maskIndex;
			byte m_maskValue;
			public FloatUpdateValue(MemberValue memberValue, int field)
			{
				m_memberValue = memberValue;
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((float)m_memberValue.GetValue(from));
			}
		}
		#endregion
		#region BytesUpdateValue
		class BytesUpdateValue : IUpdateValue
		{
			MemberValue[] m_memberValues;
			int m_maskIndex;
			byte m_maskValue;
			public BytesUpdateValue(int field)
			{
				m_memberValues = new MemberValue[4];
				m_memberValues[0] = new ZeroByteMemberValue();
				m_memberValues[1] = new ZeroByteMemberValue();
				m_memberValues[2] = new ZeroByteMemberValue();
				m_memberValues[3] = new ZeroByteMemberValue();
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void SetMemberValue(MemberValue memberValue, int index)
			{
				m_memberValues[index] = memberValue;
			}

			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((byte)m_memberValues[0].GetValue(from));
				w.Write((byte)m_memberValues[1].GetValue(from));
				w.Write((byte)m_memberValues[2].GetValue(from));
				w.Write((byte)m_memberValues[3].GetValue(from));
			}
		}
		#endregion

		#region IShortsCombine
		interface IShortsCombine
		{
			IUpdateValue ShortsCombine(MemberValue memberValue, int index, Type valueType);
		}
		#endregion
		#region ShortSS_UpdateValue
		class ShortSS_UpdateValue : IUpdateValue, IShortsCombine
		{
			MemberValue[] m_memberValues;
			int m_maskIndex;
			byte m_maskValue;
			int m_field;
			public ShortSS_UpdateValue(int field)
			{
				m_field = field;
				m_memberValues = new MemberValue[2];
				m_memberValues[0] = new ZeroShortMemberValue();
				m_memberValues[1] = new ZeroShortMemberValue();
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void SetMemberValue(MemberValue memberValue, int index)
			{
				m_memberValues[index] = memberValue;
			}

			#region IUpdateValue Members
			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((short)m_memberValues[0].GetValue(from));
				w.Write((short)m_memberValues[1].GetValue(from));
			}
			#endregion

			#region IShortsCombine Members

			public IUpdateValue ShortsCombine(MemberValue memberValue, int index, Type valueType)
			{
				if(valueType == typeof(short))
				{
					SetMemberValue(memberValue, index);
					return this;
				}
				ShortSU_UpdateValue v = new ShortSU_UpdateValue(m_field);
				v.SetMemberValue(memberValue, index);
				index = index == 0 ? 1 : 0;
				v.SetMemberValue(m_memberValues[index], index);
				return v;
			}

			#endregion
		}
		#endregion
		#region ShortSU_UpdateValue
		class ShortSU_UpdateValue : IUpdateValue
		{
			MemberValue[] m_memberValues;
			int m_maskIndex;
			byte m_maskValue;
			public ShortSU_UpdateValue(int field)
			{
				m_memberValues = new MemberValue[2];
				m_memberValues[0] = new ZeroShortMemberValue();
				m_memberValues[1] = new ZeroUShortMemberValue();
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void SetMemberValue(MemberValue memberValue, int index)
			{
				m_memberValues[index] = memberValue;
			}

			#region IUpdateValue Members
			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((short)m_memberValues[0].GetValue(from));
				w.Write((ushort)m_memberValues[1].GetValue(from));
			}
			#endregion

		}
		#endregion
		#region ShortUU_UpdateValue
		class ShortUU_UpdateValue : IUpdateValue, IShortsCombine
		{
			MemberValue[] m_memberValues;
			int m_maskIndex;
			byte m_maskValue;
			int m_field;
			public ShortUU_UpdateValue(int field)
			{
				m_field = field;
				m_memberValues = new MemberValue[2];
				m_memberValues[0] = new ZeroUShortMemberValue();
				m_memberValues[1] = new ZeroUShortMemberValue();
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void SetMemberValue(MemberValue memberValue, int index)
			{
				m_memberValues[index] = memberValue;
			}

			#region IUpdateValue Members
			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((ushort)m_memberValues[0].GetValue(from));
				w.Write((ushort)m_memberValues[1].GetValue(from));
			}
			#endregion

			#region IShortsCombine Members

			public IUpdateValue ShortsCombine(MemberValue memberValue, int index, Type valueType)
			{
				if(valueType == typeof(ushort))
				{
					SetMemberValue(memberValue, index);
					return this;
				}
				ShortUS_UpdateValue v = new ShortUS_UpdateValue(m_field);
				v.SetMemberValue(memberValue, index);
				index = index == 0 ? 1 : 0;
				v.SetMemberValue(m_memberValues[index], index);
				return v;
			}

			#endregion
		}
		#endregion
		#region ShortUS_UpdateValue
		class ShortUS_UpdateValue : IUpdateValue
		{
			MemberValue[] m_memberValues;
			int m_maskIndex;
			byte m_maskValue;
			public ShortUS_UpdateValue(int field)
			{
				m_memberValues = new MemberValue[2];
				m_memberValues[0] = new ZeroUShortMemberValue();
				m_memberValues[1] = new ZeroShortMemberValue();
				m_maskIndex = field/8;
				m_maskValue = (byte)(1 << (field % 8));
			}

			public void SetMemberValue(MemberValue memberValue, int index)
			{
				m_memberValues[index] = memberValue;
			}

			#region IUpdateValue Members
			public void WriteValue(object from, BinaryWriter w, byte[] mask)
			{
				mask[m_maskIndex] |= m_maskValue;
				w.Write((ushort)m_memberValues[0].GetValue(from));
				w.Write((short)m_memberValues[1].GetValue(from));
			}
			#endregion

		}
		#endregion
		#endregion
	}
}
