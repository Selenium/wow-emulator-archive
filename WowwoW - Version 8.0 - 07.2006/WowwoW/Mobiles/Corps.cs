using System;
using System.Collections;
using HelperTools;
using System.Diagnostics;

namespace Server
{
	/// <summary>
	/// Summary description for Corps.
	/// </summary>
	public class Corps : Mobile
	{
		UInt64 owner;
		uint bytes2;
		uint bytes3;
		DateTime decay;

		public Corps()
		{
		}
		public Corps( UInt64 guid )
		{
			owner = guid;			
		}

		#region SERIALISATION
		public override void Deserialize( GenericReader gr )
		{
			base.Deserialize( gr );
			int version = gr.ReadInt();
			owner = gr.ReadInt64();		
			bytes2 = (uint)gr.ReadInt();
			bytes3 = (uint)gr.ReadInt();
		}
		public override void Serialize( GenericWriter gw )
		{
			base.Serialize( gw );
			gw.Write( (int)0 );			
			gw.Write( owner );
			gw.Write( bytes2 );
			gw.Write( bytes3 );
		}
		#endregion

		#region ACCESSORS
		public DateTime Decay
		{
			set { decay = value; }
			get { return decay; }
		}
		public uint Bytes2
		{
			get { return bytes2; }
			set { bytes2 = value; }
		}
		public uint Bytes3
		{
			get { return bytes3; }
			set { bytes3 = value; }
		}
		#endregion

		public override bool SeenBy( Character c )
		{
			return true;
		}

		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther )
		{
			int o = offset;
/*			int offset = 4;
			Converter.ToBytes( 1, tempBuff, ref offset );	
			Converter.ToBytes( (byte)0, tempBuff, ref offset );	*/
			tempBuff[ offset++ ] = 2;
			Converter.ToBytes( Guid, tempBuff, ref offset );			
			ResetBitmap();
			Converter.ToBytes( (byte)7, tempBuff, ref offset );
			Converter.ToBytes( (int)0, tempBuff, ref offset );
			Converter.ToBytes( (int)0, tempBuff, ref offset );//	Movement flags
			Converter.ToBytes( X, tempBuff, ref offset );
			Converter.ToBytes( Y, tempBuff, ref offset );
			Converter.ToBytes( Z, tempBuff, ref offset );
			Converter.ToBytes( Orientation, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 2.5f, tempBuff, ref offset );
			Converter.ToBytes( 7f, tempBuff, ref offset );
			Converter.ToBytes( 2.5f, tempBuff, ref offset );
			Converter.ToBytes( (float)4.5f, tempBuff, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)4.7222f, tempBuff, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, tempBuff, ref offset );//	turn rate
			Converter.ToBytes( (uint)0, tempBuff, ref offset );
			Converter.ToBytes( (uint)1, tempBuff, ref offset );

			Converter.ToBytes( (uint)0, tempBuff, ref offset );
			Converter.ToBytes( (uint)0, tempBuff, ref offset );
			Converter.ToBytes( (uint)0, tempBuff, ref offset );
		
			setUpdateValue( Const.OBJECT_FIELD_GUID, Guid );			
			setUpdateValue( Const.OBJECT_FIELD_TYPE, 0x81 );
			setUpdateValue( Const.OBJECT_FIELD_SCALE_X, (float)1.0f );
			setUpdateValue( 6, owner );
			setUpdateValue( 8, Orientation );
			setUpdateValue( 9, X );
			setUpdateValue( 10, Y );
			setUpdateValue( 11, Z );
			int last = 0;
			setUpdateValue( last = (int)UpdateFields.CORPSE_FIELD_DISPLAY_ID, Model );
			setUpdateValue( (int)UpdateFields.CORPSE_FIELD_BYTES_1, bytes2 );
			setUpdateValue( (int)UpdateFields.CORPSE_FIELD_BYTES_2, bytes3 );
			setUpdateValue( last = (int)UpdateFields.CORPSE_FIELD_FLAGS, 4 );
			
			
	
			FlushUpdateData( tempBuff, ref offset, 2 + ( last / 32 ) );
			/*Console.WriteLine("teleport");
			string s = "";
			for(int t = o;t < offset;t++ )
				s += tempBuff[ t ].ToString( "X2" ) + " ";
			Debug.WriteLine(s);
*/
			//World.ToNearestPlayer( this, tempBuff, offset );
		}
	}
}
