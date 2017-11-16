using System;
using System.Collections;
using Server.Items;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for SpellTemplate.
	/// </summary>
	public class AuraEffect : SpellTemplate
	{
		int aura;
		public int applications;

		#region CONSTRUCTORS
		public AuraEffect( ushort _id,int _customFlags1,   
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, int _s1, int _s2, int _s3, 
			int _t1, int _t2, Resistances _res,DispelType _dis, 
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _aura, int _h, int _radius1, int _radius2, int _radius3, int _classe) : base( _id, _customFlags1, 
			_levelMin, _levelMax, _bonus1, _bonus2, _s1, _s2, _s3, _t1, _t2, _res,_dis,
			_manacost, _castingtime, _range, _duration, _cooldown, _h, _radius1, _radius2, _radius3, _classe )
		{
			aura = _aura;
			
		}
		public AuraEffect( ushort _id,int _customFlags1,  int _add,
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, int _s1, int _s2, int _s3, 
			int _t1, int _t2, Resistances _res,DispelType _dis, 
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _aura, int _h, int _radius1, int _radius2, int _radius3, int _classe	) : base( _id,_customFlags1,  _add,
			_levelMin, _levelMax, _bonus1, _bonus2, _s1, _s2, _s3, _t1, _t2, _res,_dis,
			_manacost, _castingtime, _range, _duration, _cooldown, _h, _radius1, _radius2, _radius3, _classe )
		{
			aura = _aura;
			
		}
		public AuraEffect( ushort _id,int _customFlags1,    
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, int _s1, int _s2, int _s3, 
			int _t1, int _t2, Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _aura, int _h, int _classe	) : base( _id,_customFlags1,  
			_levelMin, _levelMax, _bonus1, _bonus2, _s1, _s2, _s3, _t1, _t2, _res,_dis,
			_manacost, _castingtime, _range, _duration, _cooldown, _h, 0, 0, 0, _classe )
		{
			aura = _aura;
			
		}
		public AuraEffect( ushort _id,int _customFlags1,  int _add,
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, int _s1, int _s2, int _s3, 
			int _t1, int _t2, Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _aura, int _h, int _classe	) : base( _id,_customFlags1,  _add,
			_levelMin, _levelMax, _bonus1, _bonus2, _s1, _s2, _s3, _t1, _t2, _res,_dis,
			_manacost, _castingtime, _range, _duration, _cooldown, _h, 0, 0, 0, _classe )
		{
			aura = _aura;
			
		}
		#endregion

		#region ACCESSORS
		public int Applications
		{
			get { return applications; }
			set { applications = value; }
		}
		public int Aura
		{
			get { return aura; }
		}
		
		#endregion

	}
}

