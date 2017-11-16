/*
 * Created by SharpDevelop.
 * User: POSTE152
 * Date: 02/09/2004
 * Time: 12:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Xml;


namespace HelperTools
{
	/// <summary>
	/// Description of Utility.	
	/// </summary>
	
	public class RandomList
	{
		public int []val = new int[ 0x100000 ];
		public RandomList()
		{
			for(int t = 0;t < val.Length;t++ )
				val[ t ] = Utility2.Random( int.MaxValue );
		}
	}
	

	public class XmlFile : XmlDocument 
	{ 

		/// <summary> 
		/// Create instance XmlFile with "load from file" 
		/// </summary> 
		/// <param name="file">filename with path</param> 
		public XmlFile( string file ): base() 
		{ 
			Load( file ); 
		} 

		/// <summary> 
		/// Create new instance of XmlFile with root tag "elements" 
		/// </summary> 
		public XmlFile():base() 
		{ 
			Init( false, "", "elements" ); 
		} 

		/// <summary> 
		/// Create new instance of XmlFile with parameters 
		/// </summary> 
		/// <param name="UseXsl">use xsl technology</param> 
		/// <param name="XslFile">link to file with xsl</param> 
		/// <param name="RootTeg">base tag "documentelement"</param> 
		public XmlFile( bool UseXsl, string XslFile, string RootTag ):base() 
		{ 
			Init( UseXsl, XslFile, RootTag ); 
		} 

		protected void Init( bool UseXsl, string XslFile, string RootTag ) 
		{ 
			LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + ( UseXsl ? "<?xml-stylesheet type=\"text/xsl\" href=\"" + XslFile + "\"?>" : "" ) + "<" + RootTag + "></" + RootTag + ">"); 
		} 

		/// <summary> 
		/// Create new instance of XmlNode 
		/// </summary> 
		/// <param name="NodeName">name of node</param> 
		/// <param name="InnerText">text into tegs</param> 
		public XmlNode CreateNode( string NodeName, string InnerText ) 
		{ 

			XmlNode node   = CreateNode( XmlNodeType.Element, NodeName, "" ); 
			node.InnerText   = InnerText; 
			return node; 
		} 

		/// <summary> 
		/// Adding with creating new node 
		/// </summary> 
		/// <param name="Into">where add</param> 
		/// <param name="NodeName">name of node</param> 
		/// <param name="InnerText">text into tegs</param> 
		public XmlNode AddNode( XmlNode Into, string NodeName, string InnerText ) 
		{ 
			return Into.AppendChild( CreateNode( NodeName, InnerText ) ); 
		} 

		/// <summary> 
		/// Adding attributes into node 
		/// </summary> 
		/// <param name="Into">where add</param> 
		/// <param name="AttributeName">name of attribute</param> 
		/// <param name="Text">value of attribute</param> 
		public XmlAttribute AddAttribute( XmlNode Into, string AttributeName, string Text ) 
		{ 
			XmlAttribute attr   = CreateAttribute( AttributeName ); 
			attr.Value         = Text; 
			return Into.Attributes.Append( attr ); 
		} 

		/// <summary> 
		/// Test for exist and result value of inner text 
		/// </summary> 
		/// <param name="node">from</param> 
		/// <param name="def_value">default value, return if null</param> 
		public string GetInnerText( XmlNode node, string def_value ) 
		{ 
			return node.InnerText != null ? node.InnerText : def_value; 
		} 

		/// <summary> 
		/// Test for exist and result value of attribute 
		/// </summary> 
		/// <param name="node">from</param> 
		/// <param name="attr_name">name of atrtribute</param> 
		/// <param name="def_value">default value, return if null</param> 
		public string GetAttributeVal( XmlNode node, string attr_name, string def_value ) 
		{ 
			return node.Attributes[attr_name] != null ? node.Attributes[attr_name].Value : def_value; 
		} 
	} 

	
	public class Utility2
	{
		static public Random seed = new Random();
		public Utility2()
		{						
		}
		public static double RandomDouble()
		{
			return seed.NextDouble();
		}
		public static int Random( int max )
		{
			return seed.Next( max );
		}		
		public static void Seed( int s )
		{
			seed = new Random( s );
		}
	}
	public class Utility
	{
		static public AssemblyList externAsm = new AssemblyList();
		//static public Assembly externAsmItem;
		static public int seed = 1;
		static public RandomList rlist = new RandomList();
		public Utility()
		{						
		}

		private static Encoding m_UTF8, m_UTF8WithEncoding;

		public static Encoding UTF8
		{
			get
			{
				if ( m_UTF8 == null )
					m_UTF8 = new UTF8Encoding( false, false );

				return m_UTF8;
			}
		}

		public static Encoding UTF8WithEncoding
		{
			get
			{
				if ( m_UTF8WithEncoding == null )
					m_UTF8WithEncoding = new UTF8Encoding( true, false );

				return m_UTF8WithEncoding;
			}
		}

		public static bool ToBoolean( string value )
		{
			try
			{
				return Convert.ToBoolean( value );
			}
			catch
			{
				return false;
			}
		}

		public static double ToDouble( string value )
		{
			try
			{
				return Convert.ToDouble( value );
			}
			catch
			{
				return 0.0;
			}
		}

		public static TimeSpan ToTimeSpan( string value )
		{
			try
			{
				return TimeSpan.Parse( value );
			}
			catch
			{
				return TimeSpan.Zero;
			}
		}

		public static int ToInt32( string value )
		{
			try
			{
				if ( value.StartsWith( "0x" ) )
				{
					return Convert.ToInt32( value.Substring( 2 ), 16 );
				}
				else
				{
					return Convert.ToInt32( value );
				}
			}
			catch
			{
				return 0;
			}
		}
		public static string ClassName( object o )
		{
			string cls = o.GetType().ToString();
			char []sep = {'.'};
			string []classname = cls.Split( sep );
			return classname[ classname.Length - 1 ];
		}
		public static string ClassName( string cls )
		{
			char []sep = {'.'};
			string []classname = cls.Split( sep );
			return classname[ classname.Length - 1 ];
		}

		public static void FillConstructorList()
		{
			char []sep = {'.'};
			Module[] moduleArray;   
			Type[] tArray;
			AssemblyListEnumerator asmEnum = externAsm.GetEnumerator();
			while ( asmEnum.MoveNext() )
			{				     
				moduleArray = asmEnum.Value.GetModules( false );   
				Module myModule = moduleArray[ 0 ];	
				tArray = myModule.FindTypes( Module.FilterTypeName, "*" );
				foreach( Type t in tArray )
				{
					if ( t.Name.StartsWith( "$$" ) )
						continue;
					ConstructorInfo []m = t.GetConstructors();//GetMethods( BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly
					foreach( ConstructorInfo method in m )
					{
						ParameterInfo []param = method.GetParameters();
						if ( param.Length == 0 )
						{
							allConstructors[ ClassName( t.Name ) ] = method;
							break;
						}
					}
				}
			}
			
			moduleArray = Assembly.GetAssembly( typeof( Utility ) ).GetModules( false );   
			Module myLocalModule = moduleArray[ 0 ];
			tArray = myLocalModule.FindTypes( Module.FilterTypeName, "*" );
			foreach( Type t in tArray )
			{
				if ( t.Name.StartsWith( "$$" ) )
					continue;
				ConstructorInfo []m = t.GetConstructors();//GetMethods( BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly
				foreach( ConstructorInfo method in m )
				{
					ParameterInfo []param = method.GetParameters();
					if ( param.Length == 0 )
					{
						Utility.allConstructors[ ClassName( t.Name ) ] = method;
						break;
					}
				}
			}/*
			moduleArray = externAsmItem.GetModules( false );  
			myModule = moduleArray[ 0 ];
			tArray = myModule.FindTypes( Module.FilterTypeName, "*" );
			foreach( Type t in tArray )
			{
				if ( t.Name.StartsWith( "$$" ) )
					continue;
				ConstructorInfo []m = t.GetConstructors();//GetMethods( BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly
				foreach( ConstructorInfo method in m )
				{
					ParameterInfo []param = method.GetParameters();
					if ( param.Length == 0 )
					{
						Utility.allConstructors[ ClassName( t.Name ) ] = method;
						break;
					}
				}
			}*/
		}
		static public Hashtable allConstructors = new Hashtable();
		public static ConstructorInfo FindMobConstructor( string cls )
		{
			return (ConstructorInfo)allConstructors[ ClassName( cls ) ];
		}
		public static ConstructorInfo FindConstructor( string cls )
		{
			return (ConstructorInfo)allConstructors[ ClassName( cls ) ];
		}
		public static ConstructorInfo FindConstructor( string cls, Assembly fromAssembly )
		{
			return (ConstructorInfo)allConstructors[ ClassName( cls ) ];
		}
		/*
		public static ConstructorInfo FindConstructor( string cls )
		{
			char []sep = {'.'};
			string []classname = cls.Split( sep );
			Module[] moduleArray;            
			moduleArray = Assembly.GetAssembly( typeof( Utility ) ).GetModules( false );   
			Module myModule = moduleArray[ 0 ];
			Type[] tArray;
			tArray = myModule.FindTypes(Module.FilterTypeName, classname[ classname.Length - 1 ] );
			if ( tArray.Length == 0 )
				return FindConstructor( cls, Utility.externAsm );
			ConstructorInfo []m = tArray[ 0 ].GetConstructors();//GetMethods( BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly
			
			foreach( ConstructorInfo method in m )
			{
				ParameterInfo []param = method.GetParameters();
				if ( param.Length == 0 )
					return method;
			}
			return null;
		}

		public static ConstructorInfo FindConstructor( string cls, Assembly fromAssembly )
		{
			char []sep = {'.'};
			string []classname = cls.Split( sep );
			Module[] moduleArray;            
			moduleArray = fromAssembly.GetModules( false );   
			Module myModule = moduleArray[ 0 ];
			Type[] tArray;
			tArray = myModule.FindTypes(Module.FilterTypeName, classname[ classname.Length - 1 ] );
			if ( tArray.Length == 0 )
				return null;	
			ConstructorInfo []m = tArray[ 0 ].GetConstructors();//GetMethods( BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly
			
			foreach( ConstructorInfo method in m )
			{
				ParameterInfo []param = method.GetParameters();
				if ( param.Length == 0 )
					return method;
			}
			return null;
		}*/

		public static double RandomDouble()
		{
			int i1 = rlist.val[ seed++ & 0xFFFFF ] & 0xfffffff;
			int i2 = rlist.val[ seed++ & 0xFFFFF ] & 0xfffffff;
			double res = (double)i1 / ( (double)0x10000000 * (double)0x10000000 ); 
			res += (double)i2 / (double)0x10000000;
			return res;
		}
		public static int Random( int max )
		{
			return rlist.val[ seed++ & 0xFFFFF ] % max;
		}	
		public static int Random( int min, int max )
		{
			if ( min == max )
				return min;
			return min + ( rlist.val[ seed++ & 0xFFFFF ] % ( max - min ) );
		}	
		public static int Random4()
		{
			return rlist.val[ seed++ & 0xFFFFF ] & 3;
		}
		public static int Random8()
		{
			return rlist.val[ seed++ & 0xFFFFF ] & 7;
		}	
		public static int Random16()
		{
			return rlist.val[ seed++ & 0xFFFFF ] & 0xf;
		}	
		public static int Random1024()
		{
			return rlist.val[ seed++ & 0xFFFFF ] & 0x3ff;
		}
		public static int Random1024x1024()
		{
			return rlist.val[ seed++ & 0xFFFFF ] & 0xfffff;//	1024*1024 - 1
		}
	}

	public class Logs
	{
		public Logs()
		{}
		public static void DBS( string s, params object[]arg )
		{
			StreamWriter fs = File.AppendText( "log.txt" );
			fs.WriteLine( s, arg );
			fs.Close();
		}
	}

	public class RemoteReader : GenericReader
	{
		public static string host;
		public static int port;
		public RemoteReader()
		{
		}
		public RemoteReader( string filename )
		{
			if ( host == "*" )//	no remote process
			{
				try
				{
					ms = File.OpenRead( filename );
					int len = (int)ms.Seek(0, SeekOrigin.End );
					ms.Seek(0, SeekOrigin.Begin);
					byte []temp = new byte[ len ];
					ms.Read( temp, 0, len );
					ms.Close();
					fs = new MemoryStream( temp );
				}
				catch(IOException )
				{
					notFound = true;
				}
			}
			else
			{
			}
		}
	}

	public class GenericReader
	{
		byte []buffer = new byte[ 256 ];
		protected FileStream ms;
		ArrayList envs = new ArrayList();
		ArrayList prots = new ArrayList();
		public bool notFound = false;
		protected MemoryStream fs;

		public GenericReader()
		{
		}
		public GenericReader( string filename )
		{
			try
			{
				ms = File.OpenRead( filename );
				int len = (int)ms.Seek(0, SeekOrigin.End );
				ms.Seek(0, SeekOrigin.Begin);
				byte []temp = new byte[ len ];
				ms.Read( temp, 0, len );
				ms.Close();
				fs = new MemoryStream( temp );
			}
			catch(IOException )
			{
				notFound = true;
			}
		}
		public int Position
		{
			get { return (int)fs.Position; }
		}
		public int ReadInt()
		{
			fs.Read( buffer, 0, 4 );
			return BitConverter.ToInt32( buffer , 0 );
		}
		public short ReadShort()
		{
			fs.Read( buffer, 0, 2 );
			return BitConverter.ToInt16( buffer , 0 );
		}

		public UInt64 ReadInt64()
		{
			fs.Read( buffer, 0, 8 );
			return BitConverter.ToUInt64( buffer , 0 );
		}

		public bool ReadBool()
		{
			if ( fs.ReadByte() == 0 )
				return false;
			return true;
		}
		public string ReadString()
		{
			string s = "";
			int size = ReadInt();
			for(int t = 0;t < size;t++ )
				s += (char)fs.ReadByte();
			return s;
		}
		public byte ReadByte()
		{
			return (byte)fs.ReadByte(); 
		}
		public char ReadChar()
		{
			return (char)fs.ReadByte(); 
		}
		public double ReadDouble()
		{
			fs.Read( buffer, 0, 8 );
			return BitConverter.ToDouble( buffer , 0 );
		}
		
		public float ReadFloat()
		{
			fs.Read( buffer, 0, 4 );
			return BitConverter.ToSingle( buffer , 0 );
		}
		public void Close()
		{
			fs.Close();
		}
	}
	public class MemoryWriter : GenericWriter
	{
		public byte []buff;
		public MemoryWriter()
		{
			fs = new MemoryStream();
		}
		public override void Close()
		{
			buff = new byte[ fs.Position ];
			fs.Seek( 0, SeekOrigin.Begin );
			fs.Read( buff, 0, buff.Length );
			fs.Close();
		}
	}
	public class GenericWriter// : FileStream
	{
		byte []buffer = new byte[ 128 ];
		protected FileStream ms;
		protected MemoryStream fs;
		public GenericWriter()
		{
		}
		public GenericWriter( string filename )
		{
			if ( filename == "" )
				return;
			try
			{
				ms = File.Create( filename ); 
				fs = new MemoryStream(); 
			}
			catch(IOException)
			{
				Console.WriteLine("Erreur de sauvegarde" );
			}
		}
		public void Write( int a )
		{
			int t = 0;
			Converter.ToBytes( a, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public void Write( uint a )
		{
			int t = 0;
			Converter.ToBytes( a, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public void Write( short a )
		{
			int t = 0;
			Converter.ToBytes( a, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public void Write( ushort a )
		{
			int t = 0;
			Converter.ToBytes( a, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public void Write( UInt64 a )
		{
			int t = 0;
			Converter.ToBytes( a, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public void Write( Int64 a )
		{
			int t = 0;
			Converter.ToBytes( a, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public void Write( bool a )
		{
			if ( a )
				fs.WriteByte( 1 ); 
			else
				fs.WriteByte( 0 ); 
		}
		public void Write( byte a )
		{
			fs.WriteByte( a ); 
		}
		public void Write( char a )
		{
			fs.WriteByte( (byte)a ); 
		}
		public void Write( string s )
		{
			Write( s.Length );
			char []c = s.ToCharArray();
			foreach( byte byt in c )
				fs.WriteByte( byt ); 
		}
		public void Write( double d )
		{
			int t = 0;
			Converter.ToBytes( d, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public void Write( float d )
		{
			int t = 0;
			Converter.ToBytes( d, buffer, ref t );
			fs.Write( buffer, 0, t );
		}
		public virtual void Close()
		{
			fs.Seek( 0, SeekOrigin.Begin );
			byte []temp = new byte[ 32768 ];
			while( true )
			{
				int len = fs.Read( temp, 0, 32768 );
				if ( len <= 0 )
					break;
				ms.Write( temp, 0, len );
			}
			ms.Flush();
			ms.Close();
			fs.Close();
		}
	}

	public class GenericReaderSpe
	{
		public GenericReaderSpe()
		{
		}


	}
	public class GenericWriterSpe// : FileStream
	{
		public GenericWriterSpe()
		{
		}
	}

	public class Converter
	{
		public static UInt32 ToUInt32( byte []d, ref int offset )
		{
			UInt32 i = BitConverter.ToUInt32( d, offset );
			offset += 4;
			return i;
		}
		public static UInt64 ToUInt64( byte []d, ref int offset )
		{
			UInt64 i = BitConverter.ToUInt64( d, offset );
			offset += 8;
			return i;
		}
		public static Int32 ToInt32( byte []d, ref int offset )
		{
			Int32 i = BitConverter.ToInt32( d, offset );
			offset += 4;
			return i;
		}
		public static Int64 ToInt64( byte []d, ref int offset )
		{
			Int64 i = BitConverter.ToInt64( d, offset );
			offset += 8;
			return i;
		}
		public static float ToFloat( byte []d, ref int offset )
		{
			Single i = BitConverter.ToSingle( d, offset );
			offset += 4;
			return i;
		}
		public static double ToDouble( byte []d, ref int offset )
		{
			double i = BitConverter.ToDouble( d, offset );
			offset += 8;
			return i;
		}
		public static UInt16 ToUInt16( byte []d, ref int offset )
		{
			UInt16 i = BitConverter.ToUInt16( d, offset );
			offset += 2;
			return i;
		}
		public static Int16 ToInt16( byte []d, ref int offset )
		{
			Int16 i = BitConverter.ToInt16( d, offset );
			offset += 2;
			return i;
		}
		public static byte ToByte( byte []d, ref int offset )
		{
			return d[ offset++ ];
		}

		public static void ToBytes( object a, byte []b, ref int t )
		{
			if ( a is int )
				ToBytes( (int)a, b, ref t );
			if ( a  is uint )
				ToBytes( (uint)a, b, ref t );
			else
				if ( a is UInt64 )
				ToBytes( (UInt64)a, b, ref t );
			else
				if ( a is Int64 )
				ToBytes( (Int64)a, b, ref t );
			else
				if ( a is UInt16 )
				ToBytes( (UInt16)a, b, ref t );
			else
				if ( a is Int16 )
				ToBytes( (Int16)a, b, ref t );
			else
				if ( a is byte  )
				ToBytes( (byte)a, b, ref t );
			else
				if ( a is string )
				ToBytes( (string)a, b, ref t );
		}

		public static void ToBytes( int a, byte []b, ref int t )
		{
			b[ t++ ] = (byte)(( a ) & 0xff);
			b[ t++ ] = (byte)(( a >> 8 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 16 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 24 ) & 0xff);
		}


		public static void ToBytes( BitArray a, byte []b, ref int t )
		{			
			a.CopyTo( b, t );
			t += a.Length / 8;
		}

		public static void ToBytes( BitArray a, byte []b, ref int t, int len )
		{
			a.CopyTo( b, t );
			t += len;
		}

		public static void ToBytes( string a, byte []b, ref int t )
		{
			char []s = a.ToCharArray();
			foreach( char c in s )
				b[ t++ ] = (byte)c;
		}
		public static void ToBytes( uint a, byte []b, ref int t )
		{
			b[ t++ ] = (byte)(( a ) & 0xff);
			b[ t++ ] = (byte)(( a >> 8 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 16 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 24 ) & 0xff);
			//byte []temp = BitConverter.GetBytes( a );
			//Buffer.BlockCopy( temp, 0, b, t, temp.Length );
			//t += temp.Length;
		}
		public static void ToBytes( UInt64 a, byte []b, ref int t )
		{
			/*
			byte []temp = BitConverter.GetBytes( a );
			Buffer.BlockCopy( temp, 0, b, t, temp.Length );
			t += temp.Length;*/

			b[ t++ ] = (byte)(( a ) & 0xff);
			b[ t++ ] = (byte)(( a >> 8 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 16 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 24 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 32 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 40 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 48 ) & 0xff);
			b[ t++ ] = (byte)(( a >> 56 ) & 0xff);
		}
		public static void ToBytes( float a, byte []b, ref int t )
		{
			byte []temp = BitConverter.GetBytes( a );
			Buffer.BlockCopy( temp, 0, b, t, temp.Length );
			t += temp.Length;
		}
		public static void ToBytes( double a, byte []b, ref int t )
		{
			byte []temp = BitConverter.GetBytes( a );
			Buffer.BlockCopy( temp, 0, b, t, temp.Length );
			t += temp.Length;
		}
		public static void ToBytes( UInt16 a, byte []b, ref int t )
		{
			/*byte []temp = BitConverter.GetBytes( a );
			Buffer.BlockCopy( temp, 0, b, t, temp.Length );
			t += temp.Length;*/
			b[ t++ ] = (byte)(( a ) & 0xff);
			b[ t++ ] = (byte)(( a >> 8 ) & 0xff);			
		}
		public static void ToBytes( Int16 a, byte []b, ref int t )
		{/*
			byte []temp = BitConverter.GetBytes( a );
			Buffer.BlockCopy( temp, 0, b, t, temp.Length );
			t += temp.Length;*/
			b[ t++ ] = (byte)(( a ) & 0xff);
			b[ t++ ] = (byte)(( a >> 8 ) & 0xff);
			
		}
		public static void ToBytes( byte a, byte []b, ref int t )
		{
			b[ t++ ] = a;
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

	public class ByteArrayBuilder : ByteArrayBase
	{
		ArrayList data=new ArrayList();

		public ByteArrayBuilder()
		{
		}

		public ByteArrayBuilder( bool le ) : base( le )
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
	public class HexViewer
	{
		public static void View( byte []b, int offset, int len )
		{
			for(int t = 0;t < len;t+=16)
			{
				for(int i = t;i < t+16 && i + offset < b.Length; i++ )
					if (  i < len )
						Console.Write( "{0} ", b[ i + offset ].ToString( "X2" ) );
					else
						Console.Write( "   " );
				for(int i = t; i + offset < b.Length && i < t+16 && i < len; i++ )
				{
					if ( b[ i + offset ] > 31 && b[ i + offset ] < 128 )
						Console.Write( "{0}", "" + (char)b[ i + offset ] );
					else
						Console.Write( "." );
				}
				Console.WriteLine( "" );
			}
		}

		public static void View( byte []b, int offset, int len, bool noChar )
		{
			for(int t = 0;t < len;t+=32)
			{
				for(int i = t;i < t+32 && i + offset < b.Length; i++ )
					if (  i < len )
						Console.Write( "0x{0}, ", b[ i + offset ].ToString( "X2" ) );
					else
						Console.Write( "   " );
				Console.WriteLine( "" );
			}
		}
	}
}
