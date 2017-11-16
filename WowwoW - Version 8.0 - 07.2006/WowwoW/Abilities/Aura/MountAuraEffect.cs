using System;
using System.Reflection;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for MountAura.
	/// </summary>
	public class MountAuraEffect : AuraEffect
	{
		int mountId;
		float speedModifier;

		public MountAuraEffect( ushort _id,int _customFlags1,   int _mountid,
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, int _s1, int _s2, int _s3, 
			int _t1, int _t2, Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, int _duration, int _cooldown, 
			int _aura, int _h, int _classe) : base( _id, _customFlags1, 
			_levelMin, _levelMax, _bonus1, _bonus2, _s1, _s2, _s3, _t1, _t2, _res,_dis,
			_manacost, _castingtime, 0, _duration, _cooldown, _aura, _h, _classe )
		{
			mountId = _mountid;
			speedModifier = ( (float)_s2 ) / 100f;
			World.MountsList[ mountId ] = this;
		}
		public int MountId
		{
			get { return mountId; }
		}
		public float SpeedModifier
		{
			get { return speedModifier; }
		}

		public void Summon( Mobile c )
		{
			if ( c.Summon != null )
			{
				c.Summon.Delete();
				if ( World.allMobiles.Contains( c.Summon ) )
					World.Remove( c.Summon, c );
			}
			ConstructorInfo ci = World.MobilePool( mountId );
			BaseCreature bc = (BaseCreature)ci.Invoke( null );			
			bc.Faction = c.Faction;
			bc.AIEngine = new SummonedAI( c, bc );
			bc.SummonedBy = c;
			c.Summon = bc;			
			bc.Level = c.Level;
			bc.Stamina = bc.Str = bc.Iq = bc.Spirit = bc.HitPoints = bc.BaseHitPoints = bc.Agility = bc.BaseMana = 0;
			bc.InitStats();
			//	bc.AIEngine = new SummonedAI( c, bc );
			if ( c.Classe == Classes.Warlock )
			{
				#region Fel Intellect
				if ( bc.Id == 416 || bc.Id == 1863 || bc.Id == 1860 || bc.Id == 417 )
				{
					if ( c.HaveTalent( Talents.FelIntellect ) )
					{
						AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.FelIntellect );
						float bm = (float)bc.BaseMana;
						bm += bm * ( (float)ae.S1 ) / 100f;
						bc.BaseMana = bc.Mana = (int)bm;
					}
				}
				#endregion
				#region Fel Stamina
				if ( bc.Id == 416 || bc.Id == 1863 || bc.Id == 1860 || bc.Id == 417 )
				{
					if ( c.HaveTalent( Talents.FelStamina ) )
					{
						AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.FelStamina );
						float bm = (float)bc.BaseHitPoints;
						bm += bm * ( (float)ae.S1 ) / 100f;
						bc.BaseHitPoints = bc.HitPoints = (int)bm;
					}
				}
				#endregion
			}

			World.Add( bc, c.X, c.Y, c.Z, c.MapId );
			if ( c is Character )
			{
				//	c.SendSmallUpdate( new int[] { (int)UpdateFields.UNIT_FIELD_CHARM, (int)UpdateFields.UNIT_FIELD_SUMMON }, new object[] { bc.Guid, bc.Guid } );

				Character ch = c as Character;
				int offset = 4;
				Converter.ToBytes( 1, c.tempBuff, ref offset );
				Converter.ToBytes( (byte)0, c.tempBuff, ref offset );				
				c.PrepareUpdateData( c.tempBuff, ref offset , UpdateType.UpdateFull, false );
				//				bc.PrepareUpdateData( c.tempBuff, ref offset , UpdateType.UpdateFull, false );
				ch.Send( OpCodes.SMSG_UPDATE_OBJECT, c.tempBuff, offset );
				ch.ItemsUpdate();

				if ( bc.Id == 89 || bc.Id == 416 || bc.Id == 1863 || bc.Id == 1860 || bc.Id == 304 || bc.Id == 417 )
					ch.SendPetActionBar();
			}
		}
	}
}
