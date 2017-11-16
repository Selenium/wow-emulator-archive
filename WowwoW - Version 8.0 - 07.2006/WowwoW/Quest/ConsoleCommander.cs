// Coded by Volhv 
// Date: 04.10.05 
// Helpers: TUM, Driller, ShaiDeath, DrNexus 
// v2.1

using System; 
using System.Collections; 
using System.Threading; 
using System.Diagnostics; 
using System.ComponentModel; 
using Server; 

namespace Server.ConsoleCommander 
{
	#region Console Commander 

	#region BaseCommand class - for overload 
	public class BaseCommand 
	{ 
		public BaseCommand( string[] commands, string description )
		{
			Init( commands, description, "", "" );
		}

		public BaseCommand( string[] commands, string description, string aboutInfo )
		{ 
			Init( commands, description, aboutInfo, "" );
		} 

		public BaseCommand( string[] commands, string description, string aboutInfo, string syntax )
		{ 
			Init( commands, description, aboutInfo, syntax );
		} 

		private void Init( string[] commands, string description, string aboutInfo, string syntax )
		{
			cmdlist = commands; 
			descr = description; 
			about = aboutInfo;
			_syntax = syntax;
		}

		private string[] cmdlist; 
		private string descr;
		private string about;
		private string _syntax;
       
		protected virtual void Event( params string[] list )
		{
		}

		public void Execute( params string[] list )
		{
			Event( list );
		}

		public string Description 
		{ 
			get { return descr; } 
		} 

		public string[] Commands 
		{ 
			get { return cmdlist; } 
		} 

		public string About 
		{ 
			get { return about; } 
		} 

		public string Syntax 
		{ 
			get { return _syntax; } 
		} 
	} 
	#endregion 

	public class ConsoleCommander : IInitialize 
	{ 
		private static Hashtable commandList = new Hashtable();
		public static Hashtable CommandList
		{
			get { return commandList; }
		}

		public static void AddCommand( BaseCommand cmd ) 
		{ 
			Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
			
			foreach ( string cmdName in cmd.Commands )
			{
				commandList.Add( cmdName.ToLower(), cmd ); 
			}
		} 

		public static void Initialize() 
		{ 
			Console.WriteLine( "Console Commander addon v2.0" ); 
			StartConsole();
		} 
       
		public static void StartConsole() 
		{ 
			AutoResetEvent asyncOpIsDone = new AutoResetEvent( false ); 
			ThreadPool.QueueUserWorkItem( new WaitCallback( ConsoleThread ), asyncOpIsDone ); 
		} 
       
		private static void ConsoleThread( object state ) 
		{ 
			Thread.CurrentThread.Priority = ThreadPriority.Lowest;
			while ( World.Loading )
			{
				Thread.Sleep( 1000 );
			}
			bool Done = true;
			while ( Done )
			{
				try
				{
					Console.Write( ">" );
					string[] command = Console.ReadLine().ToLower().Split(new char[] {' '} );
					
					if ( command.Length > 0 ) 
					{ 
						string cmd = command[0];
						if ( commandList[ cmd ] != null )
						{
							( commandList[ cmd ] as BaseCommand ).Execute( command );
						}
					}
				}
				catch ( Exception e )
				{
					Console.WriteLine( "==> Console Exsption <==" );
                    Console.WriteLine( "Message: {0}", e.Message );
					Console.WriteLine( "Source: {0}", e.Source );
					Console.WriteLine( "Stack: {0}", e.StackTrace );
					Console.WriteLine( "Target: {0}", e.TargetSite );
					Console.WriteLine( "Help: {0}", e.HelpLink );
				}
			}
		}

		#region Help Command (internal)
		public class HelpCommand : BaseCommand, IInitialize 
		{ 
			public static void Initialize() 
			{ 
				ConsoleCommander.AddCommand( new HelpCommand() ); 
			} 

			public HelpCommand (): base( new string[] { "Help", "?" }, "show list of commands", "allow see help about commands", "\"Help [cmdName]\" or \"? [cmdName]\"") 
			{} 

			protected override void Event(params string[] list) 
			{
				if ( list.Length > 1 )
				{
					HelpCmd( list[1] );
				}
				else
				{
					ShowHelp();
				}
			} 

			private void ShowHelp()
			{
				Console.WriteLine("--------=[( Comands List )]=--------");
				ArrayList showed = new ArrayList();
				showed.Add( this );

				foreach ( BaseCommand bc in CommandList.Values ) 
				{ 
					if ( !showed.Contains( bc ) )
					{
						string cmd = "["; 
						foreach ( string s in bc.Commands ) 
						{ 
							cmd += "\"" + s + "\", "; 
						} 
						cmd = cmd.Substring( 0, cmd.Length - 2 ); 
						cmd += "]";
						Console.WriteLine( cmd ); 
						showed.Add( bc );
					}
				} 
				Console.WriteLine( "[\"help\", \"?\"]" );
				Console.WriteLine( "--------====================--------" );
				Console.WriteLine( " Total: {0} commands", showed.Count );
				Console.WriteLine( " Try \"Help [cmdName]\" to see more information " ); 
				Console.WriteLine( " ( Commands are NOT case sensitive )" ); 
				Console.WriteLine( "--------====================--------" ); 
				showed.Clear();
			}

			private void HelpCmd( string cmd )
			{
				if ( CommandList[ cmd ] != null )
				{
					BaseCommand bc = (BaseCommand)CommandList[ cmd ];

					bool a1 = bc.About.Length > 0;
					bool a2 = bc.Syntax.Length > 0;
					bool a3 = bc.Description.Length > 0;

					if ( a1 || a2 || a3 )
					{
						if ( a1 )		Console.WriteLine( "Help> About: {0}", bc.About );
						if ( a2 )		Console.WriteLine( "Help> Syntax: {0}", bc.Syntax );
						if ( a3 )		Console.WriteLine( "Help> Descr: {0}", bc.Description ); 
					}
					else Console.WriteLine( "Help> Info is empty" );
				}
				else Console.WriteLine( "Help> Unknown command" );
			}
		}
		#endregion

		#region Internal static functions

		/// <summary>
		/// Search in all Accounts, find first Character by this name
		/// </summary>
		public static Character GetCharByName( string name ) 
		{ 
			string lname = name.ToLower(); 
			foreach ( Account acc in World.allAccounts )
			{
				foreach ( Character c in acc.characteres )
				{
					if ( c.Name.ToLower() == lname )
					{
						return c;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Search in all connected Accounts, find first Character by this name
		/// </summary>
		public static Character GetConnectedCharByName( string name ) 
		{ 
			Character result = null; 
			string lname = name.ToLower(); 
			foreach ( Character c in World.allConnectedChars ) 
			{
				if ( c.Name.ToLower() == lname )
				{
					result = c;
					break;
				}
			}
			return result; 
		}

		/// <summary>
		/// Get account by name
		/// </summary>
		public static Account GetAccountByName( string name ) 
		{ 
			Account result = null; 
			string lname = name.ToLower(); 
			foreach ( Account a in World.allAccounts ) 
			{ 
				if ( a.Username.ToLower() == lname ) 
				{ 
					result = a; 
					break; 
				} 
			} 
			return result; 
		}

		/// <summary>
		/// Check existing account
		/// </summary>
		public static bool AccountExists( string name ) 
		{ 
			bool result = false; 
			string lname = name.ToLower(); 
			foreach ( Account a in World.allAccounts ) 
			{ 
				if ( a.Username.ToLower() == lname ) 
				{ 
					result = true; 
					break; 
				} 
			} 
			return result; 
		} 

		#endregion

	} 
	#endregion
}

namespace Server.ConsoleCommander 
{
	#region Info Command 
	public class InfoCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new InfoCommand() ); 
		} 

		public InfoCommand (): base( new string[] { "Info" }, "Show usage information" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			try 
			{
				Process p = Process.GetCurrentProcess();
				Console.WriteLine("--------=[( Usage Information )]=--------"); 
				Console.WriteLine("> Handles total:\t{0}",            p.HandleCount); 
				Console.WriteLine("> Threads total:\t{0}",            p.Threads.Count); 
				Console.WriteLine("> Physical Memory:\t{0}",         p.WorkingSet / 1024 + "k"); 
				Console.WriteLine("> Peak Physical Memory:\t{0}",      p.PeakWorkingSet / 1024 + "k"); 
				Console.WriteLine("> Virtual Memory:\t{0}",            p.VirtualMemorySize / 1024 + "k"); 
				Console.WriteLine("> Peak Virtual Memory:\t{0}",      p.PeakVirtualMemorySize / 1024 + "k"); 
				Console.WriteLine("> NonPaged Memory:\t{0}",         p.NonpagedSystemMemorySize / 1024 + "k"); 
				Console.WriteLine("> Paged Memory:\t\t{0}",            p.PagedMemorySize / 1024 + "k"); 
				Console.WriteLine("> Private Memory: \t{0}",         p.PrivateMemorySize / 1024 + "k"); 
				Console.WriteLine("> Total Processor Time:\t{0}",      p.TotalProcessorTime); 
				Console.WriteLine("> User Processor Time:\t{0}",      p.UserProcessorTime); 
				Console.WriteLine("--------=========================--------");  
			}
			catch 
			{ 
				Console.WriteLine( "Could not find 'WoWWoW' process" ); 
			} 
		} 
	} 
	#endregion 

	#region Statistics Command 
	public class StatisticsCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new StatisticsCommand() ); 
		} 

		public StatisticsCommand (): base( new string[] { "Status" }, "Show world information" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			Console.WriteLine("--------=[( Statistics )]=--------"); 
			Console.WriteLine("> Accounts:{0}\t",      World.allAccounts.Count ); 
			Console.WriteLine("> Characters:{0}\t",      World.allConnectedChars.Count ); 
			Console.WriteLine("> GameObjects:{0}\t",   World.allGameObjects.Count ); 
			Console.WriteLine("> Mobiles:{0}\t",      World.allMobiles.Count ); 
			Console.WriteLine("--------==================--------"); 
		} 
	} 
	#endregion 

	#region Save Command 
	public class SaveCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new SaveCommand() ); 
		} 

		public SaveCommand (): base( new string[] { "Save", "S" }, "Initiate saving world" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			Console.WriteLine("Saving..."); 
			World.Save(); 
		} 
	} 
	#endregion 

	#region Restart Command 
	public class RestartCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new RestartCommand() ); 
		} 

		public RestartCommand (): base( new string[] { "Restart", "R" }, "Imidiatly restart server (with save)" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			Console.WriteLine( "Restarting..." ); 
			World.Restart( 0 ); 
		} 
	} 
	#endregion 

	#region Broadcast Command 
	public class BroadcastCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new BroadcastCommand() ); 
		} 

		public BroadcastCommand (): base( new string[] { "Broadcast", "B" }, "Broadcast message to world" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			Console.Write("Input text: "); 
			string text = Console.ReadLine(); 
			foreach ( Character c in World.allConnectedChars ) 
			{ 
				c.SendMessage( "[" + TextColor.Set( TextColors.Red, "Admin" ) + "]: " + text );
			} 
			Console.WriteLine("Broadcasted .. done"); 
		} 
	} 
	#endregion 

	#region CreateAccount Command 
	public class CreateAccountCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new CreateAccountCommand() ); 
		} 

		public CreateAccountCommand (): base( new string[] { "CreateAccount", "CrAcc" }, "Create new account and set priveleges", "","\"CrAcc [accName]\"" ) 
		{} 

		protected override void Event(params string[] list)
		{ 
			string name;
			if ( list.Length > 1 ) name = list[ 1 ];
			else
			{
				Console.Write("Input account name: "); 
				name = Console.ReadLine(); 
			}
			if ( ConsoleCommander.AccountExists( name ) ) 
			{ 
				Console.WriteLine( "This name already exists, try another.." ); 
				return; 
			} 
			Console.Write("Input account password: "); 
			string pass = Console.ReadLine(); 
			Console.Write("Input account plevel (0-player, 1-gm, 2-admin): "); 
			string splevel = Console.ReadLine(); 
			AccessLevels plevel = AccessLevels.PlayerLevel; 
			switch ( splevel ) 
			{ 
				case "2": { plevel = AccessLevels.Admin; break; } 
				case "1": { plevel = AccessLevels.GM; break; } 
				default:  { plevel = AccessLevels.PlayerLevel; break; } 
			} 
			World.allAccounts.Add( new Account( name, pass, plevel ) ); 
			Console.WriteLine( "Account: \"{0}\", pass: \"{1}\", plevel: \"{2}\" created", name, pass, plevel ); 
		} 
	} 
	#endregion 

	#region Shutdown Command 
	public class ShutdownCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new ShutdownCommand() ); 
		} 

		public ShutdownCommand (): base( new string[] { "Shutdown" }, "if \"Save\" or \"S\" string exists - server save before shutdown", "Imidiatly shutdown server", "\"Shutdown [Save]\"  or \"Shutdown [S]\"" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			Thread.CurrentThread.Priority = ThreadPriority.Highest;
			if ( list.Length > 1 && list[1].ToLower().StartsWith( "s" ) )
			{
				Console.WriteLine("Saving..."); 
				World.Save(); 
			}
			Console.WriteLine( "Shutdown..." ); 
			Process proc = Process.GetCurrentProcess(); 
			if ( MainConsole.sw1 != null)   MainConsole.sw1.Flush(); 
			proc.Kill(); 
		} 
	} 
	#endregion 

	#region SetPlevel Command 
	public class SetPlevelCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new SetPlevelCommand() ); 
		} 

		public SetPlevelCommand (): base( new string[] { "SetPlevel" }, "Set privilege level for account", "", "\"SetPlevel [accName]\"" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			string acc;
			if ( list.Length > 1 ) acc = list[ 1 ];
			else
			{
				Console.Write("Input acc name: "); 
				acc = Console.ReadLine(); 
			}
			if ( acc.Length <= 0 ) 
			{
				Console.WriteLine( "Wrong name" );
				return; 
			}
          
			Account a = ConsoleCommander.GetAccountByName( acc ); 
			if ( a == null )
			{
				Console.WriteLine("Cant find acc"); 
				return;
			}
          
			Console.WriteLine("Current plevel: {0}", a.AccessLevel ); 
			Console.Write("Input account plevel (0-player, 1-gm, 2-admin): "); 
          
			string plevel = Console.ReadLine(); 
			if ( plevel.Length <= 0 ) return; 

			switch ( plevel ) 
			{ 
				case "2": a.AccessLevel = AccessLevels.Admin; break; 
				case "1": a.AccessLevel = AccessLevels.GM; break; 
				default: a.AccessLevel = AccessLevels.PlayerLevel; break; 
			} 
			Console.WriteLine( "User: \"{0}\"; plevel: \"{1}\"", a.Username, a.AccessLevel ); 
		} 
	} 
	#endregion 
	
	#region AccountList Command 
	public class AccountListCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new AccountListCommand() ); 
		} 

		public AccountListCommand (): base( new string[] { "AccountList", "AccList" }, "show all accounts" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			Console.WriteLine( "Account list:" ); 
			foreach ( Account a in World.allAccounts ) 
			{ 
				Console.WriteLine( "\t\"{0}\"", a.Username ); 
			} 
			Console.WriteLine( "Total: {0} accounts.", World.allAccounts.Count ); 
		} 
	} 
	#endregion 

	#region WhoIs Command 
	public class WhoIsCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new WhoIsCommand() ); 
		} 

		public WhoIsCommand (): base( new string[] { "WhoIs" }, "List all users online" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			Console.WriteLine( "WhoIs list:" ); 
			foreach ( Character c in World.allConnectedChars ) 
			{ 
				Console.WriteLine( "\t\"{0}\"", c.Name ); 
			} 
			Console.WriteLine( "Total: {0} users.", World.allConnectedChars.Count ); 

		} 
	} 
	#endregion 

	#region Character Info Command 
	public class CharacterInfoCommand : BaseCommand, IInitialize 
	{ 
		public static void Initialize() 
		{ 
			ConsoleCommander.AddCommand( new CharacterInfoCommand() ); 
		} 

		public CharacterInfoCommand (): base( new string[] { "CharacterInf", "CInf" }, "if not use [charName], will dialog with question", "Information about character", "\"CInf [charName]\"" ) 
		{} 

		protected override void Event(params string[] list) 
		{ 
			string cname;
			if ( list.Length > 1 ) cname = list[ 1 ];
			else
			{
				Console.Write("Input character name: "); 
				cname = Console.ReadLine(); 
			}
			if ( cname.Length <= 0 )
			{
				Console.WriteLine( "Wrong name" );
				return;
			}
          
			Character c = ConsoleCommander.GetConnectedCharByName( cname ); 
			if ( c == null ) 
			{
				Console.WriteLine("\"{0}\" is offline or not exist.", cname ); 
				return; 
			}

			Console.WriteLine( "==========[ GUID: {0} ]==========", c.Guid );
			Console.WriteLine( "Name: {0}", c.Name );
			Console.WriteLine( "Level: {0}", c.Level );
			Console.WriteLine( "Race: {0}", c.Race );
			Console.WriteLine( "Class: {0}", c.Classe );
			Console.WriteLine( "Zone: {0}", c.ZoneId );
			Console.WriteLine( "Map: {0}", c.MapId );
			Console.WriteLine( "Coord X: {0}", c.X );
			Console.WriteLine( "Coord Y: {0}", c.Y );
			Console.WriteLine( "Coord Z: {0}", c.Z );
			Console.WriteLine( "Size: {0}", c.Size );
		
			Console.WriteLine(" ");
			Console.Write( "Show full info[y/n]: " );
			if ( Console.ReadLine().ToLower() != "y" ) return;

			Console.WriteLine(" ");
			Console.Write( "Show account info[y/n]: " );
			if ( Console.ReadLine().ToLower() == "y" )
			{
				Console.WriteLine( "==========[Account]==========" );
				if ( c.Player != null )
				{
					Console.WriteLine( "Login: {0}", c.Player.Username );
					Console.WriteLine( "AccessLevel: [{0}]{1}", (int)c.Player.AccessLevel, c.Player.AccessLevel );
					Console.WriteLine( "IP: {0}", c.Player.Ip );
					Console.WriteLine( "Port: {0}", c.Player.Port );
				}
				else Console.WriteLine( "cant find info" );
			}

			Console.WriteLine(" ");
			Console.Write( "Show states[y/n]: " );
			if ( Console.ReadLine().ToLower() == "y" )
			{
				Console.WriteLine( "==========[States]==========" );
				Console.WriteLine( "Hit points: {0}", c.HitPoints );
				Console.WriteLine( "Mana: {0}", c.Mana );
				Console.WriteLine( "Rage: {0}", c.Rage );
				Console.WriteLine( "Str: {0}", c.Str );
				Console.WriteLine(" ");
				Console.WriteLine( "PVP active: {0}", c.PvpActive );
				Console.WriteLine( "In combat: {0}", c.InCombat );
				Console.WriteLine( "Is in duel: {0}", c.IsInDuel );
				Console.WriteLine(" ");
				Console.WriteLine( "Running: {0}", c.Running );
				Console.WriteLine( "Run speed: {0}", c.RunSpeed );
				Console.WriteLine( "Speed: {0}", c.Speed );
				Console.WriteLine(" ");
				Console.WriteLine( "Resist arcane: {0}", c.ResistArcane );
				Console.WriteLine( "Resist fire: {0}", c.ResistFire );
				Console.WriteLine( "Resist frost: {0}", c.ResistFrost );
				Console.WriteLine( "Resist holy: {0}", c.ResistHoly );
				Console.WriteLine( "Resist nature: {0}", c.ResistNature );
				Console.WriteLine( "Resist shadow: {0}", c.ResistShadow );
				Console.WriteLine(" ");
				Console.WriteLine( "Immune all spells and abilites: {0}", c.ImmuneAllSpellsAndAbilites );
				Console.WriteLine( "Immune attack: {0}", c.ImmuneAttack );
				Console.WriteLine( "Immune disease: {0}", c.ImmuneDisease );
				Console.WriteLine( "Immune fire spell: {0}", c.ImmuneFireSpell );
				Console.WriteLine( "Immune frost spell: {0}", c.ImmuneFrostSpell );
				Console.WriteLine( "Immune magic: {0}", c.ImmuneMagic );
				Console.WriteLine( "Immune physical damage: {0}", c.ImmunePhysicalDamage );
				Console.WriteLine( "Immune poison: {0}", c.ImmunePoison );
				Console.WriteLine( "Immune to disarm: {0}", c.ImmuneToDisarm );
				Console.WriteLine( "Immune to fear: {0}", c.ImmuneToFear );
				Console.WriteLine( "Immune to immobilization: {0}", c.ImmuneToImmobilization );
				Console.WriteLine( "Immune to knock back: {0}", c.ImmuneToKnockBack );
			}

			Console.WriteLine(" ");
			Console.Write( "Show skills[y/n]: " );
			if ( Console.ReadLine().ToLower() == "y" )
			{
				Console.WriteLine( "==========[Skills]==========" );
				if ( c.AllSkills != null && c.AllSkills.Count > 0 )
				{
					foreach ( Skill sk in c.AllSkills.Values )
					{
						Console.WriteLine( "[{0}]=({1})", (qSkills)sk.Id, sk.Current );
					}
				}
				else Console.WriteLine( "skills is empty" );
			}

			Console.WriteLine(" ");
			Console.Write( "Show talents[y/n]: " );
			if ( Console.ReadLine().ToLower() == "y" )
			{
				Console.WriteLine( "==========[Talents]==========" );
				if ( c.TalentList != null && c.TalentList.Count > 0 )
				{
					foreach ( Talents tal in c.TalentList.Keys )
					{
						Console.WriteLine( "[{0}] = {1}", tal, c.TalentLevel( tal ) );
					}
				}
				else Console.WriteLine( "talents is empty" );
			}

			Console.WriteLine(" ");
			Console.Write( "Show target info[y/n]: " );
			if ( Console.ReadLine().ToLower() == "y" )
			{
				Console.WriteLine( "==========[Target]==========" );
				if ( c.Selection != null )
				{
					Console.WriteLine( "GUID: {0}", c.Selection.Guid );
					Console.WriteLine( "Zone: {0}", c.Selection.ZoneId );
					Console.WriteLine( "Map: {0}", c.Selection.MapId );
					Console.WriteLine( "Coord X: {0}", c.Selection.X );
					Console.WriteLine( "Coord Y: {0}", c.Selection.Y );
					Console.WriteLine( "Coord Z: {0}", c.Selection.Z );
					Console.WriteLine( "Type: {0}", c.Selection.GetType() );
				}
				else Console.WriteLine( "none selected" );
			}
		}
	}
	#endregion 

}