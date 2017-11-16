using System;
using HelperTools;
using DDB;
using System.IO;

namespace Server
{
	/// <summary>
	/// Summary description for DBReader.
	/// </summary>
	public class DBReader : GenericReader
	{
		public DBReader( string filename )
		{
			try
			{
				if ( World.StandardServer )
				{
					ms = File.OpenRead( filename );
					int len = (int)ms.Seek(0, SeekOrigin.End );
					ms.Seek(0, SeekOrigin.Begin);
					byte []temp = new byte[ len ];
					ms.Read( temp, 0, len );
					ms.Close();
					fs = new MemoryStream( temp );
				}
				else
				{

				}
			}
			catch(IOException )
			{
				notFound = true;
			}			
		}
	}
}
