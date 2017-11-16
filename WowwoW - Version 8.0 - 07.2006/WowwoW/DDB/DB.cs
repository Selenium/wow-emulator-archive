using System;
using System.Collections;
using HelperTools;

namespace DDB
{
	public enum Results
	{
		Ok = 0,
		UnknownObject = 1,
		Removed = 2,
		CustomConstructorNotDefined = 3
	}
	/// <summary>
	/// Summary description for DB.
	/// </summary>
	public class DB
	{
		public static DB theDB;
		public static DBConnectoid theConnectoid;
		public string serverIP;
		DBServer theServer;
		ClassDescriptorList allObjectTypes = new ClassDescriptorList();
		public DB( string type )
		{
			if ( type == "realmserver" )
			{
				theServer = new DBServer( "127.0.0.1", 8087 );
			}
			else
			{
				theConnectoid = new DBConnectoid();
				serverIP = type;				
			}
		}
	/*	public static TestObj1 Get( Guid g )
		{
			return (TestObj1)DB.Get( typeof( TestObj1 ), g );
		}*/
		public static object Get( Type typeObj, Guid g )
		{
			theDB.allObjectTypes[ g.GUID ] = new ClassDescriptor();
			theConnectoid.ConnectTo( theDB.serverIP, 8086 );
			byte []ask = new byte[ 16 ];
			int offset = 2;
			Converter.ToBytes( (ushort)1, ask, ref offset ); 
			Converter.ToBytes( g.GUID, ask, ref offset ); 
			byte []test = theConnectoid.SendGet( ask );
			//	Ask for the object of guid g
		//	byte []test = theConnectoid.Recv();
		/*	byte []test = new byte[] { 1, 0, 0, 0, // int
										 2, 0, 0, 0,//int 
										 3,// byte
										 0x3E, 0, 0, 0, // float
										 2, 0, 0, 0, //	array length
										 8, 0, 0, 0,
										 10, 0, 0, 0};*/
			theConnectoid.Dispose();
			ClassDescriptor cd = theDB.allObjectTypes[ g.GUID ];
			if ( cd == null )
				return null;
			return cd.Construct( typeObj, test );
		}
	}
}
