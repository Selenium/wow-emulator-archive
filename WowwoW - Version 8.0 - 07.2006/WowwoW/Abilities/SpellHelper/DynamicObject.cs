// Decompiled by Salamander version 1.0.6
// Copyright 2002 Remotesoft Inc. All rights reserved.
// http://www.remotesoft.com/salamander

using HelperTools;
using Server.Items;
using System;
using System.Collections;

namespace Server
{
	public class DynamicObject : Object
	{
		private Mobile caster;
		private uint spell;
		private float radius;
		ArrayList aura = new ArrayList();
		
		
		public DynamicObject(float X, float Y, float Z, ushort MapId, Mobile _caster, uint _spell, float _radius)
			: base(++Object.GUID, X, Y, Z, 0.0F, MapId)
		{
			base.Guid = base.Guid | 0xF000700000000000;
			this.caster = _caster;
			this.spell = _spell;
			this.radius = _radius;
		}

		public void Start()
		{
			byte[] data = new byte[2500];
			int offset = 4;

			Converter.ToBytes((uint)1, data, ref offset);
			Converter.ToBytes((byte)0, data, ref offset);
			Converter.ToBytes((byte)UpdateType.UpdateFull, data, ref offset);
			Converter.ToBytes((ulong)base.Guid, data, ref offset);
			Converter.ToBytes((byte)6, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((float)base.X, data, ref offset);
			Converter.ToBytes((float)base.Y, data, ref offset);
			Converter.ToBytes((float)base.Z, data, ref offset);
			Converter.ToBytes((float)base.Orientation, data, ref offset);
			Converter.ToBytes((float)0.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((uint)1, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((ulong)0, data, ref offset);
			base.ResetBitmap();
			base.setUpdateValue(0, (ulong)base.Guid);
			base.setUpdateValue(2, (uint)65);
			base.setUpdateValue(3, (uint)spell);
			base.setUpdateValue(4, (float)1);
			base.setUpdateValue(6, (ulong)caster.Guid);
			base.setUpdateValue(8, (uint)1);
			base.setUpdateValue(9, (uint)spell);
			base.setUpdateValue(10, (float)radius);
			base.setUpdateValue(11, (float)base.X);
			base.setUpdateValue(12, (float)base.Y);
			base.setUpdateValue(13, (float)base.Z);
			base.setUpdateValue(14, (float)base.Orientation);
			
							
			base.FlushUpdateData(data, ref offset, 1);

			caster.ToAllPlayerNear(OpCodes.SMSG_UPDATE_OBJECT, data, offset);
		}
		
		public void End()
		{
			(caster as Character).DestroyObject(this.Guid);
		}
		
		public override void PrepareUpdateData(byte[] data, ref int offset, UpdateType type, bool forOther, Character f)
		{
			Converter.ToBytes((byte)UpdateType.UpdateFull, data, ref offset);
			Converter.ToBytes((ulong)base.Guid, data, ref offset);
			Converter.ToBytes((byte)6, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((float)base.X, data, ref offset);
			Converter.ToBytes((float)base.Y, data, ref offset);
			Converter.ToBytes((float)base.Z, data, ref offset);
			Converter.ToBytes((float)base.Orientation, data, ref offset);
			Converter.ToBytes((float)0.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((float)1.0f, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((uint)1, data, ref offset);
			Converter.ToBytes((uint)0, data, ref offset);
			Converter.ToBytes((ulong)0, data, ref offset);
			base.ResetBitmap();
			base.setUpdateValue(0, (ulong)base.Guid);
			base.setUpdateValue(2, (uint)65);
			base.setUpdateValue(3, (uint)spell);
			base.setUpdateValue(4, (float)1);
			base.setUpdateValue(6, (ulong)caster.Guid);
			base.setUpdateValue(8, (uint)1);
			base.setUpdateValue(9, (uint)spell);
			base.setUpdateValue(10, (float)radius);
			base.setUpdateValue(11, (float)base.X);
			base.setUpdateValue(12, (float)base.Y);
			base.setUpdateValue(13, (float)base.Z);
			base.setUpdateValue(14, (float)base.Orientation);
			base.FlushUpdateData(data, ref offset, 1);				
		}
		public virtual void ToAllPlayerNear( OpCodes code, byte []data )
		{
			
			caster.ToAllPlayerNear( code, data, data.Length );
		
		}
		public virtual void SendSmallUpdate( int []pos, object []val )
		{
			int offset = 4;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			int max = 2 + ( ( pos[ pos.Length - 1 ] + 1 ) / 32 );
			if ( max > 0x21 )
				max = 0x21;
			tempBuff[ offset++ ] = (byte)max;//0x1C;
			Buffer.BlockCopy( Object.Blank, 0, tempBuff, offset, Object.Blank.Length );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;//( 7 - m );	
					
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;// 112;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			
			caster.ToAllPlayerNear( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
	}
}
