using System;
using System.IO;
using System.Collections;

namespace Server
{
	/// <summary>
	/// List with "Bad Id"
	/// Work with: Items, Mobiles
	/// </summary>
	public class BadIdList
	{
		private static ArrayList _items = new ArrayList();
		private static ArrayList _mobiles = new ArrayList();
		private static ArrayList _gobjects = new ArrayList();
		
		/// <summary>
		/// Add Item Id
		/// </summary>
		public static void AddItemId( int id )
		{
			if ( !_items.Contains( id ) ) _items.Add( id );
		}

		/// <summary>
		/// Add Mobile Id
		/// </summary>
		public static void AddMobileId( int id )
		{
			if ( !_items.Contains( id ) ) _items.Add( id );
		}

		/// <summary>
		/// Add Game Object Id
		/// </summary>
		public static void AddGameObjId( int id )
		{
			if ( !_gobjects.Contains( id ) ) _gobjects.Add( id );
		}

		/// <summary>
		/// Count Item Id Numbers
		/// </summary>
		private static int CountItems
		{
			get { return _items.Count; }
		}

		/// <summary>
		/// Count Mobile Id numbers
		/// </summary>
		private static int CountMobiles
		{
			get { return _mobiles.Count; }
		}

		/// <summary>
		/// Count Game Object Id numbers
		/// </summary>
		private static int CountGameObjects
		{
			get { return _gobjects.Count; }
		}

		/// <summary>
		/// only on-demand
		/// build list with needed MobileId and ItemId values
		/// </summary>
		public static void GenerateLog( string fileName, bool overrvrite )
		{
			using ( StreamWriter sw = new StreamWriter( fileName, overrvrite ) )
			{
				sw.WriteLine( "Does not exist yet lists [{0}]", DateTime.Now );
				sw.WriteLine( " " );
				sw.WriteLine( "[Mobile id numbers] Total: {0}", CountMobiles );
				foreach ( int i in _mobiles )
				{
					sw.WriteLine( " {0}", i );
				}
				sw.WriteLine( " " );
				sw.WriteLine( "[GameObject id numbers] Total: {0}", CountMobiles );
				foreach ( int i in _gobjects )
				{
					sw.WriteLine( " {0}", i );
				}
				sw.WriteLine( " " );
				sw.WriteLine( "[Item id numbers] Total: {0}", CountItems );
				foreach ( int i in _items )
				{
					sw.WriteLine( " {0}", i );
				}
			}
		}
	}
}
