using System;
using System.Collections;

namespace eWoW
{

    public struct Position
	{
		public float x, y, z;

		public Position(float cx, float cy, float cz)
		{
			x = cx;
			y = cy;
			z = cz;
		}

		public float Distance(Position t)
		{
			float cx = x - t . x;
			float cy = y - t . y;
			float cz = z - t . z;
			return (float)Math.Sqrt( cx * cx + cy * cy + cz * cz );
		}

		public float Orientation(Position t)
		{
			float cx= t . x - x;
			float cy=t.y-y;
			if(cx>=-0.001 && cx<=0.001 && cy>=0)return 0;
			if(cx>=-0.001 && cx<=0.001 && cy<0)return (float)Math.PI;
			if(cx<0)return (float)(Math.PI/2 +  Math.Atan(cy/cx));
			return (float)(Math.PI*3/2 + Math.Atan(cy/cx));
		}

		public void CalPoint(float ang, float distance, out Position next)
		{
			if(ang>=Math.PI)
			{
				next.x=(float)( x+Math.Sin(ang - Math.PI*3/2) * distance );
				next.y=(float)( y+Math.Cos(ang - Math.PI*3/2) * distance );
			} 
			else 
			{
				next.x=(float)( x-Math.Sin(ang - Math.PI/2) * distance );
				next.y=(float)( y-Math.Cos(ang - Math.PI/2) * distance );
			}
			next.z=z;
		}

		public static Position Null=new Position(0, 0, 0);
	};

	public class MapPosition : IComparable
	{
		public const uint FlagLand = 1;
		public const uint FlagWater = 2;

		Position pos;
		uint flags=0;

		public MapPosition(float[] c)
		{
			pos.x=c[0];
			pos.y=c[1];
			pos.z=c[2];
		}

		public MapPosition(Position p, uint f)
		{
			pos=p;
			flags=f;
		}

		public MapPosition(DBSerial fs)
		{
			pos.x=fs.pack.GetFloat();
			pos.y=fs.pack.GetFloat();
			pos.z=fs.pack.GetFloat();
			flags=fs.pack.GetDWord();
		}

		public float Distance(MapPosition t)
		{
			float cx=pos.x-t.pos.x;
			float cy=pos.y-t.pos.y;
			float cz=pos.z-t.pos.z;
			return (float)Math.Sqrt( cx*cx+cy*cy+cz*cz );
		}

		public float Distance(Position t)
		{
			return pos.Distance(t);
		}

		public Position Pos
		{
			get 
			{
				return pos;
			}
		}

		public uint Flags
		{
			get 
			{
				return flags;
			}
		}

		public override int GetHashCode()
		{
			return (int)(pos.x*pos.x + pos.y*pos.y);
		}

		public override bool Equals(object obj)
		{
			if(obj==null && this==null)return true;
			if(obj==null || this==null)return false;
			if(! (obj is MapPosition) )return false;
			Position p=(obj as MapPosition).pos;
			return p.x==pos.x && p.y==pos.y && p.z==pos.z;
		}


		public void Add(DBSerial fs)
		{
			fs.pack.Add(pos.x, pos.y, pos.z).Add(flags);
		}

		#region IComparable 成员

		public int CompareTo(object obj)
		{
			return GetHashCode().CompareTo(obj.GetHashCode());
		}

		#endregion
	};

	public class Path
	{
		ArrayList data=new ArrayList();

		public Path()
		{
		}

		public void Add(MapPosition t)
		{
			data.Add(t);
		}

		public void RemoveAt(int idx)
		{
			data.RemoveAt(idx);
		}

		public MapPosition this[int idx]
		{
			get 
			{
				return (MapPosition)data[idx];
			}
		}

		public int Count 
		{
			get 
			{
				return data.Count;
			}
		}

		public float TotalLength()
		{
			if(data.Count<2)return 0;

			float t=0;
			for(int i=0; i<data.Count-1; i++)
			{
				t+=this[i].Distance( this[i+1] );
			}
			return t;
		}

		public float[] Data()
		{
			float[] t=new float[data.Count*3];
			for(int i=0; i<data.Count; i++)
			{
				t[i*3]=this[i].Pos.x;
				t[i*3+1]=this[i].Pos.y;
				t[i*3+2]=this[i].Pos.z;
			}
			return t;
		}
	}

	public abstract class ByteArrayBase
	{
		protected bool le=true;  // 小的在后面
		public   int   pos=0;

		public ByteArrayBase()
		{
		}

		public ByteArrayBase(bool le)
		{
			this.le=le;
		}

		public abstract ByteArrayBase Add(byte b);
		public abstract byte[] GetArray(int start, int count);
		public abstract void Insert(int pos, byte b);
		public abstract int Length { get; set; }
		public abstract byte this[int idx] { get; set; }


		public virtual ByteArrayBase Seek(int len)
		{
			pos+=len;
			return this;
		}

		public ByteArrayBase Add(params byte[] bs)
		{
			foreach(byte b in bs)Add(b);
			return this;
		}

		public ByteArrayBase Add(params ushort[] bs)
		{
			foreach(ushort b in bs)Add(b);
			return this;
		}

		public ByteArrayBase Add(params uint[] bs)
		{
			foreach(uint b in bs)Add(b);
			return this;
		}

		public ByteArrayBase Add(params float[] bs)
		{
			foreach(float b in bs)Add(b);
			return this;
		}

		public ByteArrayBase Add(ushort b)
		{
			if(le)
			{
				Add( (byte)(b>>8) );
				Add( (byte)b );
			}
			else 
			{
				Add( (byte)b );
				Add( (byte)(b>>8) );
			}
			return this;
		}

		public ByteArrayBase Add(uint b)
		{
			if(le)
			{
				Add( (byte)(b>>24) );
				Add( (byte)(b>>16) );
				Add( (byte)(b>>8) );
				Add( (byte)b );
			} 
			else 
			{
				Add( (byte)b );
				Add( (byte)(b>>8) );
				Add( (byte)(b>>16) );
				Add( (byte)(b>>24) );
			}
			return this;
		}

		public ByteArrayBase Add(ulong u)
		{
			if(le)
			{
				Add( (uint)(u>>32) );
				Add( (uint)(u) );
			}
			else 
			{
				Add( (uint)(u) );
				Add( (uint)(u>>32) );
			}
			return this;
		}

		public ByteArrayBase Add(string s)
		{
			byte[] b=System.Text.Encoding.UTF7.GetBytes(s);
			byte[] nb=new byte[b.Length+1];
			b.CopyTo(nb,0);
			return Add(nb);
		}


		public ByteArrayBase Add(float f)
		{
			return Add( BitConverter.ToUInt32(BitConverter.GetBytes(f), 0) );
		}

		public ByteArrayBase Add(double f)
		{
			return Add( (float)f );
		}

		public void Set(int pos, ushort b)
		{
			if(le)
			{
				this[pos]=(byte)( b>> 8);
				this[pos+1]=(byte)( b);
			} 
			else 
			{
				this[pos+1]=(byte)( b>> 8);
				this[pos]=(byte)( b);
			}
		}

		public void Set(int pos, uint b)
		{
			if(le)
			{
				this[pos]=(byte)( b>> 24);
				this[pos+1]=(byte)( b>> 16);
				this[pos+2]=(byte)( b>> 8);
				this[pos+3]=(byte)( b);
			} 
			else 
			{
				this[pos+3]=(byte)( b>> 24);
				this[pos+2]=(byte)( b>> 16);
				this[pos+1]=(byte)( b>> 8);
				this[pos+0]=(byte)( b);
			}
		}

		public void Set(int pos, params byte[] bs)
		{
			foreach(byte b in bs)
			{
				this[pos++]=b;
			}
		}

		public void Insert(int pos, ushort b)
		{
			if(le)
			{
				Insert(pos,(byte)( b>> 8));
				Insert(pos+1,(byte)( b));
			} 
			else 
			{
				Insert(pos+1,(byte)( b>> 8));
				Insert(pos,(byte)( b));
			}
		}

		public void Insert(int pos, uint b)
		{
			if(le)
			{
				Insert(pos++,(byte)( b>> 24));
				Insert(pos++,(byte)( b>> 16));
				Insert(pos++,(byte)( b>> 8));
				Insert(pos++,(byte)( b));
			} 
			else 
			{
				Insert(pos++,(byte)( b>> 0));
				Insert(pos++,(byte)( b>> 8));
				Insert(pos++,(byte)( b>> 16));
				Insert(pos++,(byte)( b>> 24));
			}
		}

		public void Insert(int pos, params byte[] bs)
		{
			foreach(byte b in bs)
			{
				Insert(pos++,b);
			}
		}

		public ByteArrayBase Get(out byte b)
		{
			b=GetByte();
			return this;
		}

		public ByteArrayBase Get(out ushort b)
		{
			b=GetWord();
			return this;
		}

		public ByteArrayBase Get(out uint b)
		{
			b=GetDWord();
			return this;
		}

		public ByteArrayBase Get(out float b)
		{
			b=GetFloat();
			return this;
		}

		public ByteArrayBase Get(out string b)
		{
			b=GetString();
			return this;
		}

		public ByteArrayBase Get(out ulong b)
		{
			b=GetULong();
			return this;
		}

		public byte GetByte()
		{
			return this[pos++];
		}

		public byte[] GetArray(int count)
		{
			int p=pos; pos+=count;
			return GetArray(p, count);
		}

		public uint GetDWord()
		{
			int p=pos; pos+=4;
			if(le)
			{
				return (uint)( (this[p]<<24)+(this[p+1]<<16)+(this[p+2]<<8)+this[p+3] );
			} 
			else 
			{
				return (uint)( (this[p+3]<<24)+(this[p+2]<<16)+(this[p+1]<<8)+this[p+0] );
			}
		}

		public ushort GetWord()
		{
			int p=pos; pos+=2;
			if(le)
			{
				return (ushort)( (this[p]<<8)+this[p+1] );
			} 
			else 
			{
				return (ushort)( (this[p+1]<<8)+this[p] );
			}
		}

		public ulong GetULong()
		{
			if(le)
			{
				return ((ulong)GetDWord()<<32) + (ulong)GetDWord();
			} 
			else 
			{
				return (ulong)GetDWord() + ((ulong)GetDWord()<<32);
			}
		}

		public float GetFloat()
		{
			uint n=GetDWord(); 
			return BitConverter.ToSingle( BitConverter.GetBytes(n), 0 );
		}

		public string GetString()
		{
			int p=pos;
			while(p<Length)
			{
				if( this[p] == 0 )break;
				p++;
			}
			byte[] b=GetArray(pos, p-pos);
			pos=p+1;
			return System.Text.Encoding.UTF7.GetString( b );
		}

	}

	public class ByteArray : ByteArrayBase
	{
		byte[] data;

		public ByteArray(byte[] d)
		{
			data=d;
		}

		public ByteArray(byte[] d, bool le) : base(le)
		{
			data=d;
		}

		public override ByteArrayBase Add(byte b)
		{
			data[pos++]=b;
			return this;
		}

		public override byte[] GetArray(int start, int count)
		{
			byte[] b=new byte[count];
			for(int i=0; i<count; i++)b[i]=data[i+start];
			return b;
		}

		public override void Insert(int pos, byte b)
		{
		}

		public override int Length
		{
			get
			{
				return data.Length;
			}
			set
			{
			}
		}

		public override byte this[int idx]
		{
			get
			{
				return data[idx];
			}
			set
			{
				data[idx]=value;
			}
		}

		public static UInt16 GetWord(byte[] b, int pos)
		{
			return (UInt16)( (b[pos]<<8)+b[pos+1] );
		}

		public static UInt32 GetDWord(byte[] b, int pos)
		{
			return (UInt32)( (b[pos]<<24)+(b[pos+1]<<16)+(b[pos+2]<<8)+b[pos+3] );
		}

		public static byte[] GetByteArray(byte[] b, int pos, int len)
		{
			byte[] cb=new byte[len];
			for(int i=0;i<len;i++)cb[i]=b[pos+i];
			return cb;
		}

		public static void SetWord(byte[] b, int pos, UInt16 v)
		{
			b[pos]=(byte)(v>>8);
			b[pos+1]=(byte)(v>>0);
		}

		public static void SetDWord(byte[] b, int pos, UInt32 v)
		{
			b[pos]=(byte)(v>>24);
			b[pos+1]=(byte)(v>>16);
			b[pos+2]=(byte)(v>>8);
			b[pos+3]=(byte)(v>>0);
		}

		public static bool Same(byte[] m1, byte[] m2)
		{
			if(m1.Length!=m2.Length)return false;
			for(int i=0; i<m1.Length; i++)
			{
				if(m1[i] != m2[i])return false;
			}
			return true;
		}
	}


	/// <summary>
	/// 一个字节数组的构造函数，规则是高字节在前
	/// </summary>
	public class ByteArrayBuilder : ByteArrayBase
	{
		ArrayList data=new ArrayList();

		public ByteArrayBuilder()
		{
		}

		public ByteArrayBuilder(bool le) : base(le)
		{
		}

		/// <summary>
		/// 长度，设置它将导致数组容量变化
		/// </summary>
		public override int Length
		{
			get
			{
				return data.Count;
			}
			set
			{
				while(value>data.Count)
				{
					data.Add( (byte) 0 );
				}
				if(value<data.Count)
				{
					data.RemoveRange(value,data.Count-value);
				}
			}
		}

		public override ByteArrayBase Seek(int len)
		{
			Length=Length+len;
			return this;
		}

		public void Remove(int start, int count)
		{
			data.RemoveRange(start,count);
		}

		public void Remove(int idx)
		{
			data.RemoveAt(idx);
		}

		public override byte this[int i]
		{
			get 
			{
				return (byte)data[i];
			}
			set
			{
				data[i]=value;
			}
		}

		public override byte[] GetArray(int start, int count)
		{
			byte[] b=new byte[count];
			data.CopyTo(start,b,0,count);
			return b;
		}

		public override ByteArrayBase Add(byte b)
		{
			data.Add(b);
			return this;
		}

		public override void Insert(int pos, byte b)
		{
			data.Insert(pos, b);
		}

		public static implicit operator byte[](ByteArrayBuilder m)
		{
			return m.GetArray(0, m.Length);
		}
		public static implicit operator ByteArrayBuilder(byte[] m)
		{
			ByteArrayBuilder b=new ByteArrayBuilder();
			b.Add(m);
			return b;
		}
	}
}
