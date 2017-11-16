using System;
using System.Collections;
using WoWDaemon.Common;
namespace WoWDaemon.Database.MemberValues
{
	public abstract class SerializeValue
	{
		protected MemberValue m_memberValue;
		public SerializeValue(MemberValue memberValue)
		{
			m_memberValue = memberValue;
		}
		
		public MemberValue MemberValue
		{
			get { return m_memberValue;}
		}

		public abstract void Serialize(object from, BinWriter data);
		public abstract void Deserialize(object to, BinReader data);

		public static SerializeValue[] GetSerializeValues(MemberValue[] values)
		{
			ArrayList list = new ArrayList();
			for(int i = 0;i < values.Length;i++)
			{
				if(values[i].Attribute.Serialize)
					list.Add(GetSerializeValue(values[i]));
			}
			SerializeValue[] serializeValues = new SerializeValue[list.Count];
			list.CopyTo(serializeValues);
			return serializeValues;
		}

		public static SerializeValue GetSerializeValue(MemberValue value)
		{
			Type valueType = value.GetValueType();
			if(valueType.IsEnum)
				valueType = Enum.GetUnderlyingType(valueType);
			if(valueType == typeof(ulong))
				return new UInt64SerializeValue(value);
			if(valueType == typeof(long))
				return new Int64SerializeValue(value);
			if(valueType == typeof(uint))
				return new UInt32SerializeValue(value);
			if(valueType == typeof(int))
				return new Int32SerializeValue(value);
			if(valueType == typeof(ushort))
				return new UInt16SerializeValue(value);
			if(valueType == typeof(short))
				return new Int16SerializeValue(value);
			if(valueType == typeof(byte))
				return new ByteSerializeValue(value);
			if(valueType == typeof(string))
				return new StringSerializeValue(value);
			if(valueType == typeof(float))
				return new SingleSerializeValue(value);
			if(valueType == typeof(double))
				return new DoubleSerializeValue(value);
			if(valueType == typeof(DateTime))
				return new DateTimeSerializeValue(value);
			if(valueType == typeof(bool))
				return new BoolSerializeValue(value);
			throw new Exception("Failed to get a serialization class for " + valueType.ToString());
		}
	}

	internal class UInt64SerializeValue : SerializeValue
	{
		public UInt64SerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((ulong)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadUInt64());
		}
	}

	internal class Int64SerializeValue : SerializeValue
	{
		public Int64SerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((long)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadInt64());
		}
	}


	internal class UInt32SerializeValue : SerializeValue
	{
		public UInt32SerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((uint)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadUInt32());
		}
	}

	internal class Int32SerializeValue : SerializeValue
	{
		public Int32SerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((int)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadInt32());
		}
	}

	internal class UInt16SerializeValue : SerializeValue
	{
		public UInt16SerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((ushort)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadUInt16());
		}
	}

	internal class Int16SerializeValue : SerializeValue
	{
		public Int16SerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((short)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadInt16());
		}
	}

	internal class ByteSerializeValue : SerializeValue
	{

		public ByteSerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((byte)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadByte());
		}
	}

	internal class StringSerializeValue : SerializeValue
	{
		public StringSerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			string str = (string)m_memberValue.GetValue(from);
			if(str == null)
				data.Write((byte)0);
			else
				data.Write(str);
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadString());
		}
	}

	internal class SingleSerializeValue : SerializeValue
	{
		public SingleSerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((Single)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadSingle());
		}
	}

	internal class DoubleSerializeValue : SerializeValue
	{
		public DoubleSerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			data.Write((double)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadDouble());
		}
	}

	internal class DateTimeSerializeValue : SerializeValue
	{
		public DateTimeSerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			DateTime time = (DateTime)m_memberValue.GetValue(from);
			data.Write(time.ToOADate());
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, DateTime.FromOADate(data.ReadDouble()));
		}
	}

	internal class BoolSerializeValue : SerializeValue
	{
		public BoolSerializeValue(MemberValue memberValue) : base(memberValue)
		{
		}

		public override void Serialize(object from, BinWriter data)
		{
			
			data.Write((bool)m_memberValue.GetValue(from));
		}

		public override void Deserialize(object to, BinReader data)
		{
			m_memberValue.SetValue(to, data.ReadBoolean());
		}
	}

}
