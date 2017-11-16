using System;
using System.IO;
using System.Net;


//Serialization v1.0
//Created by TUM 13.08.05
//Great Thanks to ShaiDeath for the help and bug fixing

//Serialization v1.1
//Modified by ShaiDeath 14.08.05

namespace Server.Serialization
{
	/// <summary>
	/// Summary description for GenWriter.
	/// </summary>
	public abstract class GenWriter
	{
		public GenWriter() { }

		public abstract void Close();

		public abstract long Position { get; }
		
		public abstract void Write( string value );
		public abstract void Write( DateTime value );
		public abstract void Write( TimeSpan value );
		public abstract void Write( decimal value );
		public abstract void Write( long value );
		public abstract void Write( ulong value );
		public abstract void Write( int value );
		public abstract void Write( uint value );
		public abstract void Write( short value );
		public abstract void Write( ushort value);
		public abstract void Write( double value );
		public abstract void Write( float value );
		public abstract void Write( char value );
		public abstract void Write( byte value );
		public abstract void Write( sbyte value );
		public abstract void Write( bool value );
		public abstract void WriteEncodedInt( int value );	
		public abstract void Write( IPAddress value );

		public abstract void Write( Character value );
		public abstract void Write( BaseCreature value);
		public abstract void Write( Account value);
		public abstract void Write( GameObject value);		

		public abstract void WriteDeltaTime( DateTime value );
	}
}
