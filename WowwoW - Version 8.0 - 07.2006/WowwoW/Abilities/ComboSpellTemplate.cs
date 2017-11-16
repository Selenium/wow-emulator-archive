using System;
using System.Collections;
using Server.Items;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for ComboSpellTemplate.
	/// </summary>
	public class ComboSpellTemplate : SpellTemplate
	{
		float comboModifier;

		#region CONSTRUCTORS
		public ComboSpellTemplate( ushort _id, int _customFlags1,   
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, 
			int _s1, int _s2, int _s3, 
			Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, byte _range, float _comboModifier, int _duration, int _cooldown, 
			int _h, int _classe	) : base( _id, _customFlags1, 
			_levelMin, _levelMax, _bonus1, _bonus2, _s1, _s2, _s3, _res, _dis,
			_manacost, _castingtime, _range, _duration, _cooldown, _h, 0, 0, 0,_classe )
		{
			comboModifier = _comboModifier;
		}
		#endregion

		public void ComboHit( Mobile from, Mobile target, SpellDamage typedamage )
		{
			float bonus = 1f;
			switch( typedamage )
			{
				case SpellDamage.TypeS1:
					bonus = (float)Bonus1;
					break;
				case SpellDamage.TypeS2:
					bonus = (float)Bonus2;
					break;
			}
			float dmg = from.Hit( target, bonus + from.ComboPoints * comboModifier );
			if ( dmg > 0f )
			{
				from.ResetCombo( target );
				target.LooseHits( from, (int)dmg, true );

//01 00 00 00 
//43 02 00 00 00 00 00 00 
//FF 01 00 00 00 00 00 00 
//00 00 00 00 
//01 00 00 00 
//00 00 00 00 
//00 00 00 00 
//00 00 00 00 
//00 
//01 00 00 00 
//E8 03 00 00 
//00 00 00 00 
//00 00 00 00 
//00 00 00 00

					int offset = 4;
					Converter.ToBytes( target.Guid, from.tempBuff, ref offset );
					Converter.ToBytes( from.Guid, from.tempBuff, ref offset );
					Converter.ToBytes( (int)Id, from.tempBuff, ref offset );
					Converter.ToBytes( (int)dmg, from.tempBuff, ref offset );
					Converter.ToBytes( 0x2, from.tempBuff, ref offset );
					Converter.ToBytes( target.Guid, from.tempBuff, ref offset );
					Converter.ToBytes( 0, from.tempBuff, ref offset );
					from.ToAllPlayerNear( OpCodes.SMSG_SPELLNONMELEEDAMAGELOG, from.tempBuff, offset );
/*
				int offset = 4;
				byte []tempBuff = from.tempBuff;
				if ( (int)dmg <= 0 )
					Converter.ToBytes( 1, tempBuff, ref offset );
				else
					Converter.ToBytes( 4, tempBuff, ref offset );

				Converter.ToBytes( from.Guid, tempBuff, ref offset );
				Converter.ToBytes( target.Guid, tempBuff, ref offset );
				Converter.ToBytes( (int)dmg, tempBuff, ref offset );
				Converter.ToBytes( 0x1, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
			//	float ang = (float)Math.Atan2( target.Y - from.Y, target.X - from.X );
				Converter.ToBytes( (float)dmg, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( 1, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );

				from.ToAllPlayerNear( OpCodes.SMSG_ATTACKERSTATEUPDATE, tempBuff, offset );					
				*/
		/*		data.Initialize(SMSG_ATTACKERSTATEUPDATE);
				data << (uint32)hit_status;   // Attack flags
				data << GetGUID();
				data << pVictim->GetGUID();
				data << (uint32)damage;
				data << (uint8)1;       // Damage type counter

				// for each...
				data << damageType;      // Damage type, // 0 - white font, 1 - yellow
				data << (uint32)0;      // damage float
				data << (uint32)damage; // Damage amount
				data << (uint32)0;      // damage absorbed

				data << (uint32)1;      // new victim state
				data << (uint32)0;      // victim round duraction
				data << (uint32)0;      // additional spell damage amount
				data << (uint32)0;      // additional spell damage id
				data << (uint32)0;      // Damage amount blocked*/
			}
		}

		#region ACCESSORS
		public float ComboModifier
		{
			get { return comboModifier; }
			set { comboModifier = value; }
		}
		#endregion

	}
}
