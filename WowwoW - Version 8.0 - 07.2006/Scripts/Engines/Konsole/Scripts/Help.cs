// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.Diagnostics; 
using System.ComponentModel;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleHelp : IInitialize
	{
		#region Static Properties
		private static ArrayList _categories;
		public static ArrayList categories
		{
			get
			{
				if(_categories == null)
				{
					ArrayList list = new ArrayList( Server.Konsole.KonsoleCommands.Commands.Values );
					Clean( list );

					_categories = new ArrayList();

					CategoryAttribute cat = new CategoryAttribute("[General]");
					_categories.Add(cat);

					foreach ( KonsoleCommandEntry c in list )
					{
						MethodInfo mi = c.Handler.Method;
						object[] attrs = mi.GetCustomAttributes( typeof( CategoryAttribute ), false );

						if(attrs.Length != 0)
						{
							CategoryAttribute category = attrs[0] as CategoryAttribute;

							if(!_categories.Contains(category))
							{
								_categories.Add(category);
							}
						}
					}
				}

				return _categories;
			}
		}
		#endregion

		#region Initialize
		public static void Initialize() 
		{
			KonsoleCommands.Register( "Help", new KonsoleCommandEventHandler( Help_OnCommand ) );
			KonsoleCommands.Register( "?", new KonsoleCommandEventHandler( Help_OnCommand ) );
		}
		#endregion
	
		#region Commands
		[Category( "[Help]" )]
		[Usage( "Help <command>" )]
		[Aliases( "?" )]
		[Description( "Displays console command help" )]
		public static void Help_OnCommand( KonsoleCommandEventArgs e )
		{
			try
			{
				if (e.Length > 0 && e.Arguments[0].ToUpper() != "ALL")
				{
					KonsoleCommandEntry c = (KonsoleCommandEntry)Server.Konsole.KonsoleCommands.Commands[e.Arguments[0]];
					if (c == null)
					{
						Console.WriteLine("\nType 'help all' for a list of commands or help <command>");
						return;
					}
					else
					{
						HelpHeader();
						ShowCommandInfo(c, null);
						HelpFooter();
					}
				}
				else if (e.Length > 0 && e.Arguments[0].ToUpper() == "ALL")
				{
					HelpHeader();
					ArrayList list = new ArrayList( Server.Konsole.KonsoleCommands.Commands.Values );
					Clean( list );

					foreach( CategoryAttribute cat in categories)
					{
						Console.WriteLine("|=- {0} -=|", cat.Category);
						foreach ( KonsoleCommandEntry c in list )
						{
							ShowCommandInfo(c, cat);
						}
						Console.WriteLine("|");
					}

					HelpFooter();
				}
				else
				{
					Console.WriteLine("\nType 'help all' for a list of commands or help <command>");
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message, "\r\n", ex.StackTrace);
			}
		}
		#endregion

		#region Private Helpers
		private static void ShowCommandInfo( KonsoleCommandEntry e, CategoryAttribute cat )
		{
			try
			{
				MethodInfo mi = e.Handler.Method;

				object[] attrs = mi.GetCustomAttributes( typeof( CategoryAttribute ), false );

				CategoryAttribute category;
				if ( attrs.Length == 0 )
				{
					category = new CategoryAttribute("[General]");
				}
				else
				{
					category = attrs[0] as CategoryAttribute;
				}

				if(cat != null && category.Category != cat.Category)
					return;

				attrs = mi.GetCustomAttributes( typeof( UsageAttribute ), false );

				if ( attrs.Length == 0 )
					return;

				UsageAttribute usage = attrs[0] as UsageAttribute;

				attrs = mi.GetCustomAttributes( typeof( DescriptionAttribute ), false );

				if ( attrs.Length == 0 )
					return;

				DescriptionAttribute desc = attrs[0] as DescriptionAttribute;

				if ( usage == null || desc == null )
					return;

				attrs = mi.GetCustomAttributes( typeof( AliasesAttribute ), false );

				AliasesAttribute aliases = ( attrs.Length == 0 ? null : attrs[0] as AliasesAttribute );

				string alias = "";
				if (aliases != null)
				{
					string[] v = aliases.Aliases;

					for ( int i = 0; i < v.Length; ++i )
					{
						if ( i != 0 )
							alias = alias + ", ";

						alias = alias + v[i];
					}
				}

				string strInfo = usage.Usage + "\t" + desc.Description + "\t" + alias;
				Console.WriteLine("| " + strInfo);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error retrieving method information: " + ex.Message);
			}
		}

		private static void HelpHeader()
		{
			Console.WriteLine("\nConsole Command list");
			Console.WriteLine(" -=Usage=-\t\t-=Description=-\t\t\t-=Aliases=-");
			Console.WriteLine(".-------------------------------------------------------------------- - -  -");
		}

		private static void HelpFooter()
		{
			Console.WriteLine("'------- - -  -\n");
		}

		private static void Clean( ArrayList list )
		{
			for ( int i = 0; i < list.Count; ++i )
			{
				KonsoleCommandEntry e = (KonsoleCommandEntry)list[i];

				for ( int j = i + 1; j < list.Count; ++j )
				{
					KonsoleCommandEntry c = (KonsoleCommandEntry)list[j];

					if ( e.Handler.Method == c.Handler.Method )
					{
						list.RemoveAt( j );
						--j;
					}
				}
			}
		}
		#endregion

	}
}