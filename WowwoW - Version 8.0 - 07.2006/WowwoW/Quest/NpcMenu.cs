using System;
using HelperTools;
using System.Collections;
using Server.Items;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace Server
{

	public class NpcMenu
	{
		ArrayList menus = new ArrayList();
		ArrayList icons = new ArrayList();
		public NpcMenu()
		{
		}
		public void AddMenu( int icon, string menu )
		{
			menus.Add( menu );
			icons.Add( (short)icon );
		}
		public void AddMenu( string menu )
		{
			menus.Add( menu );
			icons.Add( 0 );
		}
		public ArrayList Menu
		{
			get { return menus; }
		}
		public ArrayList Icon
		{
			get { return icons; }
		}
	}
}