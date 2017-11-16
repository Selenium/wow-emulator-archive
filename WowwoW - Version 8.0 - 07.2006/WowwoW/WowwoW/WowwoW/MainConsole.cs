using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Security.Cryptography;
using HelperTools;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.IO;
//using zLibWrapper;
//using NZlib.Streams;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using Server.Items;
using Server;
using System.Diagnostics;
using System.Xml;
using DDB;

namespace Server
{
	/// <summary>
	/// Summary description for MainConsole.
	/// </summary>
	public class MainConsole
	{
		static Thread []th;
		static SynchronousSocketListener listen80;
		static SynchronousSocketListener listen3724;
		//SynchronousSocketListener listen8085;
		static Thread worldThread1ms;
		//static Thread worldThread500ms;
		public static World world;
		static string []fileNames;
		static string []fileNamesItems;
		static string []batchSources;
		public static StreamWriter sw1 = null;
		public static RealmServer realmServer;
		public static AuthServer authServer;
		public static HttpServer httpServer;
		public static DBServer dbServer;

		public MainConsole()
		{
		//	Process.GetCurrentProcess().EnableRaisingEvents = true;
		//	Process.GetCurrentProcess().Exited += new EventHandler( captureStdout );
		}

		private void captureStdout(object sender, EventArgs e) 
		{
			if ( sw1 != null )
				sw1.Close();
		}


		private class TestTimer : WowTimer
		{
			public TestTimer( int time ) : base( time, "TestTimer" )
			{
				Start();
			}
			public override void OnTick()
			{
				Console.WriteLine("Tick test1" );
				base.OnTick ();
			}

		}


		[STAThread]
		static void Main(string[] args)
		{
#if !DEBUG			
			try
			{
#endif
			/*TextWriter tw = new StreamWriter( "loot.cs" );
				tw.WriteLine("using System;using Server.Items;using System.Collections;using Server;namespace Server{public class LootTemplate {" );
				
				for(int t = 0;t < 10000;t++ )
				{
					tw.WriteLine("public static Loot[] loottemplate" + t.ToString() + " = null;" );//new Loot[] { new Loot( typeof( Money ), 9, 20, 60.480000f ) };" );
				}
				tw.WriteLine("}}");
				tw.Close();*/
			/*
							byte []aaa = new byte[] { 0x32, 0x9D, 0x33, 0x40, 0xA2, 0x63, 0x0B, 0xC6, 0x5A, 0xB5, 0xFB, 0xC2, 0x7B, 0xD9, 0xA2, 0x42, 0xE0, 0xF0, 0x63, 0x40, 0x3F, 0x03, 0x00, 0x00, 0x00, 0x00, 0x60, 0x40 };
							for(int t = 0;t < aaa.Length;t+=4 )
							{
								Console.WriteLine("{0} ", BitConverter.ToSingle( aaa, t ) );
							}*/
			if ( args.Length > 0 )
			{
				foreach( string s in args )
				{
					if ( s == "outfile" )
					{
						FileStream fs1 = new FileStream("log" + Utility.Random1024().ToString() + ".txt", FileMode.Create);
						sw1 = new StreamWriter(fs1);
						Console.SetOut( sw1 );
					}
					if ( s == "realmserver" )
					{
						World.RealmServer = true;
						World.StandardServer = false;
					}
				}
			}

			new MainConsole();	
			

			Process []p = Process.GetProcessesByName( "WowwoW.exe" );
				
			if ( p.Length > 0 )
				p[ 0 ].WaitForExit();
			//	float a = Converter.ToFloat( new byte[]{ 0x
			Console.WriteLine("WowwoW version {0} (c) 2005 DrNexus", World.Version );
			/*	if ( !BuildExternalEnvironements() )
				{
					return;
				}*/
			if ( !World.RealmServer )
			{
				if ( !BuildAllDlls() )
					return;				
				Utility.FillConstructorList();
				ConstructorInfo ct = Utility.FindConstructor( "CustomHandlers", Utility.externAsm[ "globals" ] );
				ct.Invoke( null );
			}
			else
				Utility.FillConstructorList();
				
			world = new World();
				
			worldThread1ms = new Thread( new ThreadStart( world.Slice1ms ) );
				
			//	worldThread500ms = new Thread( new ThreadStart( world.Slice500ms ) );
			if ( !World.RealmServer )
				worldThread1ms.Start();

			th = new Thread[ 1 ];
			if ( !World.RealmServer )
			{
				Listen3724();
				Listen8085();
			}
			else
			{
				dbServer = new DBServer( "localhost", 8087 );
			}
			Listen80();

			worldThread1ms.Priority = ThreadPriority.AboveNormal;//.Highest;
			Area a = new Area();
			if ( sw1 != null )
				sw1.Flush();
/*

			if ( World.StandardServer )
			{
				DBConnectoid dbc = new DBConnectoid();
				dbc.ConnectTo( "127.0.0.1", 8087 );
				byte []buffer = new byte[ 13 ];
				int offset = 0;
				Converter.ToBytes( (ushort)13, buffer, ref offset );
				Converter.ToBytes( (byte)1, buffer, ref offset );
				Converter.ToBytes( (ushort)0, buffer, ref offset );
				Converter.ToBytes( (UInt64)15051385, buffer, ref offset );			
				dbc.SendGet( buffer );

			}*/
			while( !end )
			{							
				/*	Process proc = Process.GetCurrentProcess();
					Console.WriteLine("Virtual memory usage : {0} mb",proc.VirtualMemorySize / ( 1024 * 1024 ));
					Console.WriteLine("Memory usage : {0} mb",proc.PrivateMemorySize / ( 1024 * 1024 ));
					Console.WriteLine("Peak Virtual memory usage : {0} mb",proc.PeakVirtualMemorySize / ( 1024 * 1024 ) );
					Console.WriteLine("Peak Memory usage : {0} mb",proc.PeakWorkingSet / ( 1024 * 1024 ) );
					*/
				/*	world.TimerReport();
					
					int t = 0;
					if ( World.localTime != null )
						foreach( long l in World.localTime )
							Console.WriteLine("Time {0} : {1} ({2},{3})", t++, (100*(double)l / (double)World.total).ToString("G5") , l, World.total );
					*/		
				Thread.Sleep( 3000 );
			}
#if !DEBUG
			}
			catch(Exception e )
			{
				Console.WriteLine("Error in main console !" );
				Console.WriteLine( e.Message );
				Console.WriteLine( e.Source );
				Console.WriteLine( e.StackTrace );
			}
#endif
		}
		public static bool end = false;
		public static void StopAllThread()
		{
			/*listen80.ClientTask.Stop();
			listen80.Stop();
			th[ 2 ].Abort();*/
			
			//worldThread1ms.Abort();
			/*listen80.Stop();
			th[ 0 ].Abort();*/
			end = true;
			realmServer.Dispose();			
			authServer.Dispose();
			httpServer.Dispose();
			
			Process p = Process.GetCurrentProcess();
			
			ProcessThreadCollection procs = p.Threads;
			World.notEnded = false;
			//Thread.Sleep( 2000 );
			foreach( ProcessThread thread in procs )
			{				
				Console.WriteLine("thread id {0} CPU {1}", thread.Id, thread.TotalProcessorTime.TotalMilliseconds );				
			}
			p.Close();
		}

		public static void Listen80()
		{
			httpServer = new HttpServer( World.ServerIP, World.HttpServerPort );			
		}
		public static void Listen3724()
		{
			authServer = new AuthServer( World.ServerIP, 3724 );
		}
		public static void Listen8085()
		{
			realmServer = new RealmServer( World.ServerIP, World.ServerPort ); 
		}

		public static void Restart()
		{		
			Thread.CurrentThread.Priority = ThreadPriority.Highest;
			if ( File.Exists( "./wow_start.sh" ) )
				Process.Start( "./wow_start.sh" );
			else
				Process.Start( "Wowwow.exe" );
			//Process.Start( "mono WowwoW.exe" );
			

			Process p = Process.GetCurrentProcess();
			if ( sw1 != null )
				sw1.Flush();
			Console.WriteLine("Terminating..");
			p.Kill();			
		}

		

		



		static DateTime sourcesCodeCRC;
		static bool sourcesCodeDirty;


		public static ArrayList BuildSources( string path )
		{
			DirectoryInfo   dir = new DirectoryInfo( path );
			FileInfo[]      files;
			DirectoryInfo[] dirs;
			ArrayList fileNames = new ArrayList();
        
			dirs = dir.GetDirectories( "*" );
			foreach( DirectoryInfo di in dirs )
			{
				ArrayList ret = BuildSources( path + "/" + di.Name );
				foreach( object o in ret )
				{
					if ( di.LastWriteTime > sourcesCodeCRC )
					{
						sourcesCodeDirty = true;
						sourcesCodeCRC = di.LastWriteTime;
					}					
					fileNames.Add( o );
				}
			}

			files = dir.GetFiles();
			foreach(FileInfo file in files)
			{
				if ( file.Extension.EndsWith( ".cs" ) )
				{
					if ( file.LastWriteTime > sourcesCodeCRC )
					{
						sourcesCodeDirty = true;
						sourcesCodeCRC = file.LastWriteTime;
					}		
					fileNames.Add( file.FullName );
				}
				else
					if ( file.Extension.EndsWith( ".cod" ) )
				{
				}
			}
			return fileNames;
		}

		public static bool BuildAllDlls()
		{
			Console.WriteLine( "Building scripts, please wait..." );
			int itemsDll = BuildDll( World.Path + "/Scripts/Items", null );
			if ( itemsDll == 2 )
				Console.WriteLine( "Items scripts rebuilt" );
			else
				Console.WriteLine( "Items scripts loaded" );
			int questsDll = BuildDll( World.Path + "/Scripts/Quests", new string[] { "Items" } );		
			if ( questsDll == 2 )
				Console.WriteLine( "Quests scripts rebuilt" );
			else
				Console.WriteLine( "Quests scripts loaded" );	
			int treasureDll = BuildDll( World.Path + "/Scripts/TreasureTables", new string[] { "Items" } );
			if ( treasureDll == 2 )
				Console.WriteLine( "Treasures list scripts rebuilt" );
			else
				Console.WriteLine( "Treasures list scripts loaded" );
			int goDll = BuildDll( World.Path + "/Scripts/Game Objects", new string[] { "Items", "TreasureTables" } );			
			if ( goDll == 2 )
				Console.WriteLine( "Game objects scripts rebuilt" );
			else
				Console.WriteLine( "Game objects scripts loaded" );
			int enginesDll = BuildDll( World.Path + "/Scripts/Engines", null );
			if ( enginesDll == 2 )
				Console.WriteLine( "Engines scripts rebuilt" );
			else
				Console.WriteLine( "Engines scripts loaded" );
			int creatureDll = BuildDll( World.Path + "/Scripts/Creatures", new string[]{ "TreasureTables", "Quests", "Items", "Engines" } );			
			if ( creatureDll == 2 )
				Console.WriteLine( "Creatures scripts rebuilt" );
			else
				Console.WriteLine( "Creatures scripts loaded" );
			int characterDll = BuildDll( World.Path + "/Scripts/Character", new string[] { "Items" } );
			if ( characterDll == 2 )
				Console.WriteLine( "Characters scripts rebuilt" );
			else
				Console.WriteLine( "Characters scripts loaded" );
			int globalsDll = BuildDll( World.Path + "/Scripts/Globals", new string[] { "Engines", "Items", "Character" } );
			if ( globalsDll == 2 )
				Console.WriteLine( "Globals scripts rebuilt" );
			else
				Console.WriteLine( "Globals scripts loaded" );
			int spellsDll = BuildDll( World.Path + "/Scripts/Spells", new string[] { "Creatures", "Engines", "Character" } );
			if ( spellsDll == 2 )
				Console.WriteLine( "Spells scripts rebuilt" );
			else
				Console.WriteLine( "Spells scripts loaded" );
			return true;
		}

		public static int BuildDll( string path, string []refs )
		{
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			ICodeCompiler compiler = codeProvider.CreateCompiler();
			CompilerParameters parameters = new CompilerParameters();
			parameters.GenerateExecutable = false;
			parameters.GenerateInMemory = true;
			parameters.MainClass = "";
			sourcesCodeDirty = false;
			World.Path = AppDomain.CurrentDomain.BaseDirectory;
			string []fs = path.Split( new char[] { '/' } );
			string dllName = fs[ fs.Length - 1 ];
			parameters.OutputAssembly = World.Path + dllName + ".dll";
			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) 
			{
				if ( asm.Location != "" )
				{
				//	Console.WriteLine( "Reference {0}", asm.Location );
					parameters.ReferencedAssemblies.Add( asm.Location );
				}
			}			
			
			
			if ( refs != null )
			{
				DateTime dllDate = DateTime.Now;
				if ( File.Exists( parameters.OutputAssembly ) )
					dllDate = File.GetLastWriteTime( parameters.OutputAssembly );
				else 
					sourcesCodeDirty = true;
				foreach( string refer in refs )
				{
					string r = World.Path + refer + ".dll";
					if ( !sourcesCodeDirty && dllDate.CompareTo( File.GetLastWriteTime( r ) ) < 0 )
						sourcesCodeDirty = true;
					parameters.ReferencedAssemblies.Add( r );
				//	Console.WriteLine("Add reference {0}", r );
				}
			}
			parameters.IncludeDebugInformation = false;
			ArrayList files = null;
			parameters.WarningLevel = 4;	
			parameters.TreatWarningsAsErrors = false;

			if ( !sourcesCodeDirty && File.Exists( parameters.OutputAssembly ) )
			{
				sourcesCodeCRC = File.GetLastWriteTime( parameters.OutputAssembly );
				
			}
			else 
				sourcesCodeDirty = true;
			files = BuildSources( path );
			if ( !sourcesCodeDirty )
			{
				Utility.externAsm[ dllName ] = Assembly.LoadFile( parameters.OutputAssembly );
				return 1;
			}			
			string []filenames = (string[])files.ToArray( typeof( string ) );
			CompilerResults results = compiler.CompileAssemblyFromFileBatch( parameters, filenames );
			
			if (results.Errors.Count > 0) 
			{
				string errors = "Compilation failed:\n";
				foreach (CompilerError err in results.Errors) 
				{
					errors += err.ToString() + "\n";
				}
				Console.WriteLine( errors );
				throw( new Exception( errors ) );				
			}
			Utility.externAsm[ dllName ] = results.CompiledAssembly;
			return 2;
		}
/*

		public static bool BuildExternalEnvironements()
		{
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			ICodeCompiler compiler = codeProvider.CreateCompiler();
			CompilerParameters parameters = new CompilerParameters();
		//	parameters.CompilerOptions = "/nostdlib ";
			parameters.GenerateExecutable = false;
			parameters.GenerateInMemory = true;

			parameters.MainClass = "";




			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) 
			{
				parameters.ReferencedAssemblies.Add(asm.Location);
			}
			 
			parameters.IncludeDebugInformation = false;
			World.Path = AppDomain.CurrentDomain.BaseDirectory;
			parameters.OutputAssembly = World.Path + "res1.dll";
			parameters.WarningLevel = 4;
			sourcesCodeDirty = false;
			if ( File.Exists( parameters.OutputAssembly ) && File.Exists( World.Path + "res2.dll" ) )
				sourcesCodeCRC = File.GetLastWriteTime( parameters.OutputAssembly );
			else 
				sourcesCodeDirty = true;
			ArrayList files = BuildSources( World.Path + "Scripts/" );
			if ( !sourcesCodeDirty )
			{
				Utility.externAsmItem = Assembly.LoadFile( AppDomain.CurrentDomain.BaseDirectory + "res1.dll" );
				Utility.externAsm = Assembly.LoadFile( AppDomain.CurrentDomain.BaseDirectory + "res2.dll" );
				return true;
			}
			else
				if ( File.Exists( World.Path + "res2.dll" ) )
				 File.Delete( World.Path + "res2.dll" );

			int nfiles = 0;
			int nItemFiles = 0;
			//batchSources = new string[ files.Count + 1 ];//	pour les futurs compile d'immigrants
			for( int t = 0;t < files.Count;t++ )
			{				
				if ( ( files[ t ] as string ).ToLower().IndexOf( "scripts/items/" ) >= 0 ||
					( files[ t ] as string ).ToLower().IndexOf( "scripts\\items\\" ) >= 0 )
					nItemFiles++;
				else
					if ( !( ( files[ t ] as string ).ToLower().IndexOf( "scripts/creatures" ) > 0 ||
					( files[ t ] as string ).ToLower().IndexOf( "scripts\\creatures" ) > 0 ) )
					nfiles++;
			}
			fileNames = new string[ nfiles ];
			nfiles = 0;
			fileNamesItems = new string[ nItemFiles ];
			nItemFiles = 0;
			for( int t = 0;t < files.Count;t++ )
			{				
				if ( ( files[ t ] as string ).ToLower().IndexOf( "scripts/items/" ) >= 0 ||
					( files[ t ] as string ).ToLower().IndexOf( "scripts\\items\\" ) >= 0 )

					fileNamesItems[ nItemFiles++ ] = (string)files[ t ];
				else
					if ( !( ( files[ t ] as string ).ToLower().IndexOf( "scripts/creatures" ) > 0 ||
					( files[ t ] as string ).ToLower().IndexOf( "scripts\\creatures" ) > 0 ) )
						fileNames[ nfiles++ ] = (string)files[ t ];
				else
					Console.WriteLine("{0}", (string)files[ t ] );
			}
			CompilerResults results = compiler.CompileAssemblyFromFileBatch( parameters, fileNamesItems );
			
			if (results.Errors.Count > 0) 
			{
				string errors = "Compilation failed:\n";
				foreach (CompilerError err in results.Errors) 
				{
					errors += err.ToString() + "\n";
				}
				Console.WriteLine( errors );
				throw( new Exception( errors ) );
			}
			else	
			{
				Utility.externAsmItem = results.CompiledAssembly;
				if ( File.Exists( ( AppDomain.CurrentDomain.BaseDirectory + "res2.dll" ) ) )
				{
					Utility.externAsm = Assembly.LoadFile( AppDomain.CurrentDomain.BaseDirectory + "res2.dll" );
					return true;
				}
				
				parameters.ReferencedAssemblies.Add( World.Path + "res1.dll" );
				parameters.OutputAssembly = World.Path + "res2.dll";
				results = compiler.CompileAssemblyFromFileBatch( parameters, fileNames );
				if (results.Errors.Count > 0) 
				{
					string errors = "Compilation failed:\n";
					foreach (CompilerError err in results.Errors) 
					{
						errors += err.ToString() + "\n";
					}
					Console.WriteLine( errors );
					throw( new Exception( errors ) );
				}
				Console.WriteLine( "{0} scripts compiled." , fileNames.Length );
				Utility.externAsm = results.CompiledAssembly;
			}				
			return true;
		}*/


	}
}
