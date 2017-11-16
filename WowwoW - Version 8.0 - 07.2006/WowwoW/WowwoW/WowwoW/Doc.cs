//	Script made by RaVeN - 03/06/05 05:11:10
//Based on Docs.cs from RunUO, modified for WowwoW by RaVeN.
//Has only ClassOverview

using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections;
using Server;
using HelperTools;

namespace Server
{
	public class Docs
	{/*
		public static void Initialize()
		{
			Commands.Register( "DocGen", AccessLevels.Admin, new CommandEventHandler( DocGen_OnCommand ) );
		}

		private static bool DocGen_OnCommand( CommandEventArgs e )
		{
			e.SendMessage("Documentation is being generated, please wait.");
			
			Console.WriteLine( "Documentation is being generated, please wait." );

			DateTime startTime = DateTime.Now;

			Document();

			DateTime endTime = DateTime.Now;

			Console.WriteLine("Documentation has been completed. The entire process took {0:F1} seconds.", (endTime - startTime).TotalSeconds );

			e.SendMessage("Documentation has been completed. The entire process took {0:F1} seconds.", (endTime - startTime).TotalSeconds );

			return true;
		}

	 */
		private class MemberComparer : IComparer
		{
			public int Compare( object x, object y )
			{
				if ( x == y )
					return 0;

				ConstructorInfo aCtor = x as ConstructorInfo;
				ConstructorInfo bCtor = y as ConstructorInfo;

				PropertyInfo aProp = x as PropertyInfo;
				PropertyInfo bProp = y as PropertyInfo;

				MethodInfo aMethod = x as MethodInfo;
				MethodInfo bMethod = y as MethodInfo;

				bool aStatic = GetStaticFor( aCtor, aProp, aMethod );
				bool bStatic = GetStaticFor( bCtor, bProp, bMethod );

				if ( aStatic && !bStatic )
					return -1;
				else if ( !aStatic && bStatic )
					return 1;

				int v = 0;

				if ( aCtor != null )
				{
					if ( bCtor == null )
						v = -1;
				}
				else if ( bCtor != null )
				{
					if ( aCtor == null )
						v = 1;
				}
				else if ( aProp != null )
				{
					if ( bProp == null )
						v = -1;
				}
				else if ( bProp != null )
				{
					if ( aProp == null )
						v = 1;
				}

				if ( v == 0 )
				{
					v = GetNameFrom( aCtor, aProp, aMethod ).CompareTo( GetNameFrom( bCtor, bProp, bMethod ) );
				}

				if ( v == 0 && aCtor != null && bCtor != null )
				{
					v = aCtor.GetParameters().Length.CompareTo( bCtor.GetParameters().Length );
				}
				else if ( v == 0 && aMethod != null && bMethod != null )
				{
					v = aMethod.GetParameters().Length.CompareTo( bMethod.GetParameters().Length );
				}

				return v;
			}

			private bool GetStaticFor( ConstructorInfo ctor, PropertyInfo prop, MethodInfo method )
			{
				if ( ctor != null )
					return ctor.IsStatic;
				else if ( method != null )
					return method.IsStatic;

				if ( prop != null )
				{
					MethodInfo getMethod = prop.GetGetMethod();
					MethodInfo setMethod = prop.GetGetMethod();

					return (getMethod != null && getMethod.IsStatic) || (setMethod != null && setMethod.IsStatic);
				}

				return false;
			}

			private string GetNameFrom( ConstructorInfo ctor, PropertyInfo prop, MethodInfo method )
			{
				if ( ctor != null )
					return ctor.DeclaringType.Name;
				else if ( prop != null )
					return prop.Name;
				else if ( method != null )
					return method.Name;
				else
					return "";
			}
		}

		private class TypeComparer : IComparer
		{
			public int Compare( object x, object y )
			{
				if ( x == null && y == null )
					return 0;
				else if ( x == null )
					return -1;
				else if ( y == null )
					return 1;

				TypeInfo a = x as TypeInfo;
				TypeInfo b = y as TypeInfo;

				if ( a == null || b == null )
					throw new ArgumentException();

				return a.m_TypeName.CompareTo( b.m_TypeName );
			}
		}

		private class NamespaceComparer : IComparer
		{
			public int Compare( object x, object y )
			{
				DictionaryEntry a = (DictionaryEntry)x;
				DictionaryEntry b = (DictionaryEntry)y;

				return ((string)a.Key).CompareTo( (string)b.Key );
			}
		}

		private class TypeInfo
		{
			public Type m_Type, m_BaseType, m_Declaring;
			public string m_FileName, m_TypeName;
			public ArrayList m_Derived, m_Nested;
			public Type[] m_Interfaces;
			public StreamWriter m_Writer;

			public TypeInfo( Type type )
			{
				m_Type = type;

				m_BaseType = type.BaseType;
				m_Declaring = type.DeclaringType;

				m_Interfaces = type.GetInterfaces();

				m_TypeName = type.Name;
				m_FileName = Docs.GetFileName( "docs/types/", m_TypeName, ".html" );

				m_Writer = Docs.GetWriter( "docs/types/", m_FileName );
			}
		}

		public static string GetFileName( string root, string name, string ext )
		{
			int index = 0;
			string file = String.Concat( name, ext );

			while ( File.Exists( Path.Combine( root, file ) ) )
				file = String.Concat( name, ++index, ext );

			return file;
		}

		private static string[,] m_Aliases = new string[,]
			{
				{ "System.Object",	"<font color=\"blue\">object</font>" },
				{ "System.String",	"<font color=\"blue\">string</font>" },
				{ "System.Boolean",	"<font color=\"blue\">bool</font>" },
				{ "System.Byte",	"<font color=\"blue\">byte</font>" },
				{ "System.SByte",	"<font color=\"blue\">sbyte</font>" },
				{ "System.Int16",	"<font color=\"blue\">short</font>" },
				{ "System.UInt16",	"<font color=\"blue\">ushort</font>" },
				{ "System.Int32",	"<font color=\"blue\">int</font>" },
				{ "System.UInt32",	"<font color=\"blue\">uint</font>" },
				{ "System.Int64",	"<font color=\"blue\">long</font>" },
				{ "System.UInt64",	"<font color=\"blue\">ulong</font>" },
				{ "System.Single",	"<font color=\"blue\">float</font>" },
				{ "System.Double",	"<font color=\"blue\">double</font>" },
				{ "System.Decimal",	"<font color=\"blue\">decimal</font>" },
				{ "System.Char",	"<font color=\"blue\">char</font>" },
				{ "System.Void",	"<font color=\"blue\">void</font>" }
			};

		private static string m_RootDirectory = Path.GetDirectoryName( Environment.GetCommandLineArgs()[0] );

		private const string RefString = "<font color=\"blue\">ref</font> ";

		private static int m_AliasLength = m_Aliases.GetLength( 0 );

		public static string GetPair( Type varType, string name, bool ignoreRef )
		{
			string prepend = "";
			StringBuilder append = new StringBuilder();

			Type realType = varType;

			if ( varType.IsByRef )
			{
				if ( !ignoreRef )
					prepend = RefString;

				realType = varType.GetElementType();
			}

			if ( realType.IsPointer )
			{
				if ( realType.IsArray )
				{
					append.Append( '*' );

					do
					{
						append.Append( '[' );

						for ( int i = 1; i < realType.GetArrayRank(); ++i )
							append.Append( ',' );

						append.Append( ']' );

						realType = realType.GetElementType();
					} while ( realType.IsArray );

					append.Append( ' ' );
				}
				else
				{
					realType = realType.GetElementType();
					append.Append( " *" );
				}
			}
			else if ( realType.IsArray )
			{
				do
				{
					append.Append( '[' );

					for ( int i = 1; i < realType.GetArrayRank(); ++i )
						append.Append( ',' );

					append.Append( ']' );

					realType = realType.GetElementType();
				} while ( realType.IsArray );

				append.Append( ' ' );
			}
			else
			{
				append.Append( ' ' );
			}

			string fullName = realType.FullName;
			string aliased = null;// = realType.Name;

			TypeInfo info = (TypeInfo)m_Types[realType];

			if ( info != null )
			{
				aliased = String.Format( "<a href=\"{0}\">{1}</a>", info.m_FileName, info.m_TypeName );
			}
			else
			{
				for ( int i = 0; i < m_AliasLength; ++i )
				{
					if ( m_Aliases[i, 0] == fullName )
					{
						aliased = m_Aliases[i, 1];
						break;
					}
				}

				if ( aliased == null )
					aliased = realType.Name;
			}

			return String.Concat( prepend, aliased, append, name );
		}

		private static Hashtable m_Types;
		private static Hashtable m_Namespaces;

		private static void EnsureDirectory( string path )
		{
			path = Path.Combine( m_RootDirectory, path );

			if ( !Directory.Exists( path ) )
				Directory.CreateDirectory( path );
		}

		private static void DeleteDirectory( string path )
		{
			path = Path.Combine( m_RootDirectory, path );

			if ( Directory.Exists( path ) )
				Directory.Delete( path, true );
		}

		public static void Document()
		{
			DeleteDirectory( "docs/" );
			EnsureDirectory( "docs/" );
			EnsureDirectory( "docs/namespaces/" );
			EnsureDirectory( "docs/types/" );

			GenerateStyles();
			GenerateIndex();


			m_Types = new Hashtable();
			m_Namespaces = new Hashtable();

			ArrayList assemblies = new ArrayList();
/*			DrNexus : Not nice
			assemblies.Add(Assembly.GetEntryAssembly());

			assemblies.Add( Assembly.LoadFrom( m_RootDirectory + "\res.dll" ) );
*/
			// Prefere this way
			assemblies.Add( Utility.externAsm );
			assemblies.Add( Assembly.GetAssembly( typeof( Mobile ) ) );

			Assembly[] asms = (Assembly[])assemblies.ToArray( typeof( Assembly ) );

			for ( int i = 0; i < asms.Length; ++i )
				LoadTypes( asms[i], asms );

			DocumentLoadedTypes();
		}

		private static void AddIndexLink( StreamWriter html, string filePath, string label, string desc )
		{
			html.WriteLine( "      <h2><a href=\"{0}\" title=\"{1}\">{2}</a></h2>", filePath, desc, label );
		}

		private static void GenerateStyles()
		{
			using ( StreamWriter css = GetWriter( "docs/", "styles.css" ) )
			{
				css.WriteLine( "body { background-color: #FFFFFF; font-family: verdana, arial; font-size: 11px; }" );
				css.WriteLine( "a { color: #28435E; }" );
				css.WriteLine( "a:hover { color: #4878A9; }" );
				css.WriteLine( "td.header { background-color: #9696AA; font-weight: bold; font-size: 12px; }" );
				css.WriteLine( "td.lentry { background-color: #D7D7EB; width: 10%; }" );
				css.WriteLine( "td.rentry { background-color: #FFFFFF; width: 90%; }" );
				css.WriteLine( "td.entry { background-color: #FFFFFF; }" );
				css.WriteLine( "td { font-size: 11px; }" );
				css.WriteLine( ".tbl-border { background-color: #46465A; }" );
			}
		}

		private static void GenerateIndex()
		{
			using ( StreamWriter html = GetWriter( "docs/", "index.html" ) )
			{
				html.WriteLine( "<html>" );
				html.WriteLine( "   <head>" );
				html.WriteLine( "      <title>WowwoW {0} Documentation - Index</title>", World.Version );
				html.WriteLine( "      <link rel=\"stylesheet\" type=\"text/css\" href=\"styles.css\" />" );
				html.WriteLine( "   </head>" );
				html.WriteLine( "   <body>" );

				AddIndexLink( html, "overview.html", "Class Overview", "Scripting reference. Contains every class type and contained methods in the core and scripts." );

				html.WriteLine( "   </body>" );
				html.WriteLine( "</html>" );
			}
		}

		private static void LoadTypes( Assembly a, Assembly[] asms )
		{
			Type[] types = a.GetTypes();

			for ( int i = 0; i < types.Length; ++i )
			{
				Type type = types[i];

				string nspace = type.Namespace;
				if ( nspace == null )
					continue;
				if ( nspace.StartsWith( "Server" ) || nspace.StartsWith( "Utility" ) || 
					nspace.StartsWith( "HelperTools" )
					)
				{
				}
				else 
					continue;

				string cl = type.Name;
				if ( cl.StartsWith( "TcpIPSocketClient" ) || 
					cl.StartsWith( "Trajet" ) || 
					cl.StartsWith( "TcpClientBis" ) || 
					cl.StartsWith( "SocketClient" ) || 
					cl.StartsWith( "ServerGroup" ) || 
					cl.StartsWith( "ServerGroupHandler" ) || 
					cl.StartsWith( "ServerGroupMessageType" ) || 
					cl.StartsWith( "PlayerHandler" ) || 
					cl.StartsWith( "NetWork" ) || 
					cl.StartsWith( "ISocket" ) || 
					cl.StartsWith( "GameServer" ) || 
					cl.StartsWith( "Data" ) || 
					cl.StartsWith( "ClientConnection" ) || 
					cl.StartsWith( "ClientConnectionPool" ) || 
					cl.StartsWith( "ClientHandler" ) || 
					cl.StartsWith( "ClientService" ) || 
					cl.StartsWith( "ClientConnection" ) || 
					cl.StartsWith( "Coord" ) || 
					cl.StartsWith( "Docs" ) || 
					cl.StartsWith( "MainConsole" ) || 					
					cl.StartsWith( "Packet" ) || 						
					cl.StartsWith( "Base64Decoder" ) ||
					cl.StartsWith( "Base64Encoder" ) ||
					cl.StartsWith( "ByteArray" ) ||
					cl.StartsWith( "ByteArrayBase" ) ||
					cl.StartsWith( "ByteArrayBuilder" ) ||
					cl.StartsWith( "Converter" ) ||
					cl.StartsWith( "HexViewer" ) ||
					cl.StartsWith( "Logs" ) ||
					cl.StartsWith( "RandomList" ) ||
					cl.StartsWith( "Zip" ) ||
					cl.StartsWith( "ClientConnectionPool" ) )
					continue;
				if ( nspace == null || type.IsSpecialName )
					continue;

				TypeInfo info = new TypeInfo( type );
				m_Types[type] = info;

				ArrayList nspaces = (ArrayList)m_Namespaces[nspace];

				if ( nspaces == null )
					m_Namespaces[nspace] = nspaces = new ArrayList();

				nspaces.Add( info );

				Type baseType = info.m_BaseType;

				if ( baseType != null && InAssemblies( baseType, asms ) )
				{
					TypeInfo baseInfo = (TypeInfo)m_Types[baseType];

					if ( baseInfo == null )
						m_Types[baseType] = baseInfo = new TypeInfo( baseType );

					if ( baseInfo.m_Derived == null )
						baseInfo.m_Derived = new ArrayList();

					baseInfo.m_Derived.Add( info );
				}

				Type decType = info.m_Declaring;

				if ( decType != null )
				{
					TypeInfo decInfo = (TypeInfo)m_Types[decType];

					if ( decInfo == null )
						m_Types[decType] = decInfo = new TypeInfo( decType );

					if ( decInfo.m_Nested == null )
						decInfo.m_Nested = new ArrayList();

					decInfo.m_Nested.Add( info );
				}

				for ( int j = 0; j < info.m_Interfaces.Length; ++j )
				{
					Type iface = info.m_Interfaces[j];

					if ( !InAssemblies( iface, asms ) )
						continue;

					TypeInfo ifaceInfo = (TypeInfo)m_Types[iface];

					if ( ifaceInfo == null )
						m_Types[iface] = ifaceInfo = new TypeInfo( iface );

					if ( ifaceInfo.m_Derived == null )
						ifaceInfo.m_Derived = new ArrayList();

					ifaceInfo.m_Derived.Add( info );
				}
			}
		}

		private static bool InAssemblies( Type t, Assembly[] asms )
		{
			Assembly a = t.Assembly;

			for ( int i = 0; i < asms.Length; ++i )
				if ( a == asms[i] )
					return true;

			return false;
		}

		private static StreamWriter GetWriter( string root, string name )
		{
			return new StreamWriter( Path.Combine( Path.Combine( m_RootDirectory, root ), name ) );
		}

		private static StreamWriter GetWriter( string path )
		{
			return new StreamWriter( Path.Combine( m_RootDirectory, path ) );
		}

		private const string HtmlNewLine = "";

		private const string GetString = " <font color=\"blue\">get</font>;";
		private const string SetString = " <font color=\"blue\">set</font>;";

		private const string  InString = "<font color=\"blue\">in</font> ";
		private const string OutString = "<font color=\"blue\">out</font> ";

		private const string  VirtString  = "<font color=\"blue\">virtual</font> ";
		private const string  CtorString  ="(<font color=\"blue\">ctor</font>) ";
		private const string StaticString = "(<font color=\"blue\">static</font>) ";

		private static void DocumentLoadedTypes()
		{
			using ( StreamWriter indexHtml = GetWriter( "docs/", "overview.html" ) )
			{
				indexHtml.WriteLine( "<html>" );
				indexHtml.WriteLine( "   <head>" );
				indexHtml.WriteLine( "      <title>WowwoW {0} Documentation - Class Overview</title>", World.Version );
				indexHtml.WriteLine( "   </head>" );
				indexHtml.WriteLine( "   <body bgcolor=\"white\" style=\"font-family: Courier New\" text=\"#000000\" link=\"#000000\" vlink=\"#000000\" alink=\"#808080\">" );
				indexHtml.WriteLine( "      <h4><a href=\"index.html\">Back to the index</a></h4>" );
				indexHtml.WriteLine( "      <h2>Namespaces</h2>" );

				ArrayList nspaces = new ArrayList( m_Namespaces );

				nspaces.Sort( new NamespaceComparer() );

				for ( int i = 0; i < nspaces.Count; ++i )
				{
					DictionaryEntry de = (DictionaryEntry)nspaces[i];
					string name = (string)de.Key;
					ArrayList types = (ArrayList)de.Value;

					types.Sort( new TypeComparer() );

					SaveNamespace( name, types, indexHtml );
				}

				indexHtml.WriteLine( "   </body>" );
				indexHtml.WriteLine( "</html>" );
			}
		}

		private static void SaveNamespace( string name, ArrayList types, StreamWriter indexHtml )
		{
			string fileName = GetFileName( "docs/namespaces/", name, ".html" );

			indexHtml.WriteLine( "      <a href=\"namespaces/{0}\">{1}</a><br>", fileName, name );

			using ( StreamWriter nsHtml = GetWriter( "docs/namespaces/", fileName ) )
			{
				nsHtml.WriteLine( "<html>" );
				nsHtml.WriteLine( "   <head>" );
				nsHtml.WriteLine( "      <title>WowwoW {0} Documentation - Class Overview - {1}</title>", World.Version, name );
				nsHtml.WriteLine( "   </head>" );
				nsHtml.WriteLine( "   <body bgcolor=\"white\" style=\"font-family: Courier New\" text=\"#000000\" link=\"#000000\" vlink=\"#000000\" alink=\"#808080\">" );
				nsHtml.WriteLine( "      <h4><a href=\"../overview.html\">Back to the namespace index</a></h4>" );
				nsHtml.WriteLine( "      <h2>{0}</h2>", name );

				for ( int i = 0; i < types.Count; ++i )
					SaveType( (TypeInfo)types[i], nsHtml, fileName, name );

				nsHtml.WriteLine( "   </body>" );
				nsHtml.WriteLine( "</html>" );
			}
		}

		private static void SaveType( TypeInfo info, StreamWriter nsHtml, string nsFileName, string nsName )
		{
			if ( info.m_Declaring == null )
				nsHtml.WriteLine( "      <a href=\"../types/{0}\">{1}<br>", info.m_FileName, info.m_TypeName );

			using ( StreamWriter typeHtml = info.m_Writer )
			{
				typeHtml.WriteLine( "<html>" );
				typeHtml.WriteLine( "   <head>" );
				typeHtml.WriteLine( "      <title>WowwoW {0} Documentation - Class Overview - {1}</title>", World.Version, info.m_TypeName );
				typeHtml.WriteLine( "   </head>" );
				typeHtml.WriteLine( "   <body bgcolor=\"white\" style=\"font-family: Courier New\" text=\"#000000\" link=\"#000000\" vlink=\"#000000\" alink=\"#808080\">" );
				typeHtml.WriteLine( "      <h4><a href=\"../namespaces/{0}\">Back to {1}</a></h4>", nsFileName, nsName );

				if ( info.m_Type.IsEnum )
					WriteEnum( info, typeHtml );
				else
					WriteType( info, typeHtml );

				typeHtml.WriteLine( "   </body>" );
				typeHtml.WriteLine( "</html>" );
			}
		}

		private static void WriteEnum( TypeInfo info, StreamWriter typeHtml )
		{
			Type type = info.m_Type;

			typeHtml.WriteLine( "      <h2>{0} (Enum)</h2>", info.m_TypeName );

			string[] names = Enum.GetNames( type );

			bool flags = type.IsDefined( typeof( FlagsAttribute ), false );
			string format;

			if ( flags )
				format = "      {0:G} = 0x{1:X}{2}<br>";
			else
				format = "      {0:G} = {1:D}{2}<br>";

			for ( int i = 0; i < names.Length; ++i )
			{
				object value = Enum.Parse( type, names[i] );

				typeHtml.WriteLine( format, names[i], value, i < (names.Length - 1) ? "," : "" );
			}
		}

		private static void WriteType( TypeInfo info, StreamWriter typeHtml )
		{
			Type type = info.m_Type;

			typeHtml.Write( "      <h2>" );

			Type decType = info.m_Declaring;

			if ( decType != null )
			{
				typeHtml.Write( '(' );

				TypeInfo decInfo = (TypeInfo)m_Types[decType];

				if ( decInfo == null )
					typeHtml.Write( decType.Name );
				else
					typeHtml.Write( "<a href=\"{0}\">{1}</a>", decInfo.m_FileName, decInfo.m_TypeName );

				typeHtml.Write( ") - " );
			}

			typeHtml.Write( info.m_TypeName );

			Type[] ifaces = info.m_Interfaces;
			Type baseType = info.m_BaseType;

			int extendCount = 0;

			if ( baseType != null && baseType != typeof( object ) && baseType != typeof( ValueType ) && !baseType.IsPrimitive )
			{
				typeHtml.Write( " : " );

				TypeInfo baseInfo = (TypeInfo)m_Types[baseType];

				if ( baseInfo == null )
					typeHtml.Write( baseType.Name );
				else
					typeHtml.Write( "<a href=\"{0}\">{1}</a>", baseInfo.m_FileName, baseInfo.m_TypeName );

				++extendCount;
			}

			if ( ifaces.Length > 0 )
			{
				if ( extendCount == 0 )
					typeHtml.Write( " : " );

				for ( int i = 0; i < ifaces.Length; ++i )
				{
					Type iface = ifaces[i];
					TypeInfo ifaceInfo = (TypeInfo)m_Types[iface];

					if ( extendCount != 0 )
						typeHtml.Write( ", " );

					++extendCount;

					if ( ifaceInfo == null )
						typeHtml.Write( iface.Name );
					else
						typeHtml.Write( "<a href=\"{0}\">{1}</a>", ifaceInfo.m_FileName, ifaceInfo.m_TypeName );
				}
			}

			typeHtml.WriteLine( "</h2>" );

			ArrayList derived = info.m_Derived;

			if ( derived != null )
			{
				typeHtml.Write( "<h4>Derived Types: " );

				derived.Sort( new TypeComparer() );

				for ( int i = 0; i < derived.Count; ++i )
				{
					TypeInfo derivedInfo = (TypeInfo)derived[i];

					if ( i != 0 )
						typeHtml.Write( ", " );

					typeHtml.Write( "<a href=\"{0}\">{1}</a>", derivedInfo.m_FileName, derivedInfo.m_TypeName );
				}

				typeHtml.WriteLine( "</h4>" );
			}

			ArrayList nested = info.m_Nested;

			if ( nested != null )
			{
				typeHtml.Write( "<h4>Nested Types: " );

				nested.Sort( new TypeComparer() );

				for ( int i = 0; i < nested.Count; ++i )
				{
					TypeInfo nestedInfo = (TypeInfo)nested[i];

					if ( i != 0 )
						typeHtml.Write( ", " );

					typeHtml.Write( "<a href=\"{0}\">{1}</a>", nestedInfo.m_FileName, nestedInfo.m_TypeName );
				}

				typeHtml.WriteLine( "</h4>" );
			}

			MemberInfo[] membs = type.GetMembers( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly );

			Array.Sort( membs, new MemberComparer() );

			for ( int i = 0; i < membs.Length; ++i )
			{
				MemberInfo mi = membs[i];

				if ( mi is PropertyInfo )
					WriteProperty( (PropertyInfo)mi, typeHtml );
				else if ( mi is ConstructorInfo )
					WriteCtor( info.m_TypeName, (ConstructorInfo)mi, typeHtml );
				else if ( mi is MethodInfo )
					WriteMethod( (MethodInfo)mi, typeHtml );
			}
		}

		private static void WriteProperty( PropertyInfo pi, StreamWriter html )
		{
			html.Write( "      " );

			MethodInfo getMethod = pi.GetGetMethod();
			MethodInfo setMethod = pi.GetSetMethod();

			if ( (getMethod != null && getMethod.IsStatic) || (setMethod != null && setMethod.IsStatic) )
				html.Write( StaticString );

			html.Write( GetPair( pi.PropertyType, pi.Name, false ) );
			html.Write( '(' );

			if ( pi.CanRead )
				html.Write( GetString );

			if ( pi.CanWrite )
				html.Write( SetString );

			html.WriteLine( " )<br>" );
		}

		private static void WriteCtor( string name, ConstructorInfo ctor, StreamWriter html )
		{
			if ( ctor.IsStatic )
				return;

			html.Write( "      " );
			html.Write( CtorString );
			html.Write( name );
			html.Write( '(' );

			ParameterInfo[] parms = ctor.GetParameters();

			if ( parms.Length > 0 )
			{
				html.Write( ' ' );

				for ( int i = 0; i < parms.Length; ++i )
				{
					ParameterInfo pi = parms[i];

					if ( i != 0 )
						html.Write( ", " );

					if ( pi.IsIn )
						html.Write( InString );
					else if ( pi.IsOut )
						html.Write( OutString );

					html.Write( GetPair( pi.ParameterType, pi.Name, pi.IsOut ) );
				}

				html.Write( ' ' );
			}

			html.WriteLine( ")<br>" );
		}

		private static void WriteMethod( MethodInfo mi, StreamWriter html )
		{
			if ( mi.IsSpecialName )
				return;

			html.Write( "      " );

			if ( mi.IsStatic )
				html.Write( StaticString );

			if ( mi.IsVirtual )
				html.Write( VirtString );

			html.Write( GetPair( mi.ReturnType, mi.Name, false ) );
			html.Write( '(' );

			ParameterInfo[] parms = mi.GetParameters();

			if ( parms.Length > 0 )
			{
				html.Write( ' ' );

				for ( int i = 0; i < parms.Length; ++i )
				{
					ParameterInfo pi = parms[i];

					if ( i != 0 )
						html.Write( ", " );

					if ( pi.IsIn )
						html.Write( InString );
					else if ( pi.IsOut )
						html.Write( OutString );

					html.Write( GetPair( pi.ParameterType, pi.Name, pi.IsOut ) );
				}

				html.Write( ' ' );
			}

			html.WriteLine( ")<br>" );
		}
	}
}