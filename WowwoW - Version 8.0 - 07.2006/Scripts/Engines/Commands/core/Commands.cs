/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/
using System;
using System.IO;
using System.Collections;
using HelperTools;

using Server;

namespace Server.Scripts.Commands
{

	public enum TargetType
	{
		None = 0,
		AnyMobile = 1,
		CreatureOnly = 2,
        PlayerOnly
	}

	public delegate bool CommandEventHandler( CommandEventArgs e );

	public class CommandEventArgs : EventArgs
	{
		private Character m_Player;
		private Mobile m_Target;
		private string m_Command, m_ArgString;
		private string[] m_Arguments;
		private TargetType m_TargetType;
		private bool m_IsImpl;
		private AccessLevels m_AccessLevel;

		public Character Player
		{
			get
			{
				return m_Player;
			}
		}		
		
		public Mobile Target
		{
			get
			{
				return m_Target;
			}
		}		

		public string Command
		{
			get
			{
				return m_Command;
			}
		}

		public string ArgString
		{
			get
			{
				return m_ArgString;
			}
		}

		public string[] Arguments
		{
			get
			{
				return m_Arguments;
			}
		}

		public int Length
		{
			get
			{
				return m_Arguments.Length;
			}
		}

		public TargetType TargetType
		{
			get
			{
				return m_TargetType;
			}
		}

		public bool IsImpl
		{
			get
			{
				return m_IsImpl;
			}
		}

		public AccessLevels AccessLevel
		{
			get
			{
				return m_AccessLevel;
			}
		}

		public void SendMessage( string format, params object[] args )
		{
			Console.WriteLine( "Format : {0} {1}", format, args.Length );
			if (!m_IsImpl) m_Player.SendMessage(String.Format( format, args ) );
		}

		public string GetString( int index )
		{
			if ( index < 0 || index >= m_Arguments.Length )
				return "";

			return m_Arguments[index];
		}

		public int GetInt32( int index )
		{
			if ( index < 0 || index >= m_Arguments.Length )
				return 0;

			return Utility.ToInt32( m_Arguments[index] );
		}

		public bool GetBoolean( int index )
		{
			if ( index < 0 || index >= m_Arguments.Length )
				return false;

			return Utility.ToBoolean( m_Arguments[index] );
		}

		public double GetDouble( int index )
		{
			if ( index < 0 || index >= m_Arguments.Length )
				return 0.0;

			return Utility.ToDouble( m_Arguments[index] );
		}

		public TimeSpan GetTimeSpan( int index )
		{
			if ( index < 0 || index >= m_Arguments.Length )
				return TimeSpan.Zero;

			return Utility.ToTimeSpan( m_Arguments[index] );
		}

		public CommandEventArgs( Character player, Mobile target, string command, string argString, string[] arguments, TargetType targType, bool isimpl, AccessLevels accLevel )
		{
			m_Player = player;
			m_Target = target;
			m_Command = command;
			m_ArgString = argString;
			m_Arguments = arguments;
			m_TargetType = targType;
			m_IsImpl = isimpl;
			m_AccessLevel = accLevel;
		}
	}

	public class CommandEntry : IComparable
	{
		private string m_Command;
		private CommandEventHandler m_Handler;
		private AccessLevels m_AccessLevel;
		private TargetType m_TargetType;

		public string Command
		{
			get
			{
				return m_Command;
			}
		}

		public CommandEventHandler Handler
		{
			get
			{
				return m_Handler;
			}
		}

		public AccessLevels AccessLevel
		{
			get
			{
				return m_AccessLevel;
			}
		}

		public TargetType TargetType
		{
			get
			{
				return m_TargetType;
			}
		}

		public CommandEntry( string command, CommandEventHandler handler, AccessLevels accessLevel, TargetType targ )
		{
			m_TargetType = targ;
			m_Command = command;
			m_Handler = handler;
			m_AccessLevel = accessLevel;
		}

		public int CompareTo( object obj )
		{
			if ( obj == this )
				return 0;
			else if ( obj == null )
				return 1;

			CommandEntry e = obj as CommandEntry;

			if ( e == null )
				throw new ArgumentException();

			return m_Command.CompareTo( e.m_Command );
		}
	}

	public class Commands
	{

		public static string[] Split( string value )
		{
			char[] array = value.ToCharArray();
			ArrayList list = new ArrayList();

			int start = 0, end = 0;

			while ( start < array.Length )
			{
				char c = array[start];

				if ( c == '"' )
				{
					++start;
					end = start;

					while ( end < array.Length )
					{
						if ( array[end] != '"' || array[end - 1] == '\\' )
							++end;
						else
							break;
					}

					list.Add( value.Substring( start, end - start ) );

					start = end + 2;
				}
				else if ( c != ' ' )
				{
					end = start;

					while ( end < array.Length )
					{
						if ( array[end] != ' ' )
							++end;
						else
							break;
					}

					list.Add( value.Substring( start, end - start ) );

					start = end + 1;
				}
				else
				{
					++start;
				}
			}

			return (string[])list.ToArray( typeof( string ) );
		}

		private static Hashtable m_Entries;

		public static Hashtable Entries
		{
			get
			{
				return m_Entries;
			}
		}

		static Commands()
		{
			m_Entries = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );
		}

		public static void Register( string command, AccessLevels access, CommandEventHandler handler, TargetType targ )
		{
			m_Entries[command] = new CommandEntry( command, handler, access, targ );
		}

		public static void Register( string command, AccessLevels access, CommandEventHandler handler )
		{
			m_Entries[command] = new CommandEntry( command, handler, access, Server.Scripts.Commands.TargetType.None );
		}

		private static AccessLevels m_BadCommandIngoreLevel = AccessLevels.PlayerLevel;

		public static AccessLevels BadCommandIgnoreLevel{ get{ return m_BadCommandIngoreLevel; } set{ m_BadCommandIngoreLevel = value; } }

		public static bool HasCommand(string command)
		{
			CommandEntry entry = (CommandEntry)m_Entries[command];
			if ( entry!=null )
			{
				if ( entry.Handler != null )
				{
					return true;
				}
			}
			return false;
		}

		public static TargetType TargetType( string command)
		{
			CommandEntry entry = (CommandEntry)m_Entries[command];
			if ( entry!=null )
			{
				if ( entry.Handler != null )
				{
					return entry.TargetType;
				}
			}
			return Server.Scripts.Commands.TargetType.None;
		}

		public static bool Handle( Character ch, Mobile target, string text, bool isempl )
		{
			if ( text.StartsWith( "." ) )
			{
				text = text.Substring( 1 );

				int indexOf = text.IndexOf( ' ' );

				string command;
				string[] args;
				string argString;

				if ( indexOf >= 0 )
				{
					argString = text.Substring( indexOf + 1 );

					command = text.Substring( 0, indexOf );
					args = Split( argString );
				}
				else
				{
					argString = "";
					command = text.ToLower();
					args = new string[0];
				}

				CommandEntry entry = (CommandEntry)m_Entries[command];

				if ( entry != null )
				{
					if ( ch.Player.AccessLevel >= entry.AccessLevel )
					{
						if ( entry.Handler != null )
						{
							CommandEventArgs e = new CommandEventArgs( ch, target, command, argString, args, entry.TargetType, isempl, entry.AccessLevel );
							if ( (entry.TargetType != Server.Scripts.Commands.TargetType.None) && (e.Target==null) )
							{
								ch.SendMessage("You must sellect target first.");
								return false;
							} 
							else 
								if ( (entry.TargetType == Server.Scripts.Commands.TargetType.PlayerOnly) && !(e.Target is Character))
							{
								ch.SendMessage("Target must be a Player.");
								return false;
							} 							
							else 
								if ( (entry.TargetType == Server.Scripts.Commands.TargetType.CreatureOnly) && !(e.Target is BaseCreature))
							{
								ch.SendMessage("Target must be a Creature.");
								return false;
							} 
							else
							{
								bool isOK = entry.Handler( e );
								EventSink.InvokeCommand( e );
								return isOK;
							}
						}
						else
						{
							return false;
						}
					}
					else
					{
						if ( ch.Player.AccessLevel <= m_BadCommandIngoreLevel )
							return false;

						ch.SendMessage( "You do not have access to that command." );
					}
				}
				else
				{
					ch.SendMessage("Command " + command + " dont exist.");
					return false;
				}

			}
			return false;

		}

	}
}