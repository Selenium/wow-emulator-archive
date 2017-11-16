using System;

namespace Server
{
	/// <summary>
	/// Summary description for Ability.
	/// </summary>
	public class Ability : BaseAbility
	{
		/*	int type1;
			int type2;
			int type3;
			int type4;
	*/
		int degatMin;
		int degatMax;
		Resistances resistance;
		DispelType dispeltype;
		int classe;
		int manaCost;
		

		int castingTime;
		byte range;
		int duration;
		int cooldown;	

		public Ability( ushort _id,int _customFlags1,    
			int _degatMin, int _degatMax, Resistances _res,DispelType _dis, 
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _classe	) : base( _id,_customFlags1,  _cooldown )
		{
			degatMin = _degatMin;
			degatMax = _degatMax;
			resistance = _res;
			dispeltype = _dis;
			classe = _classe;
			manaCost = _manacost;
			castingTime = _castingtime;
			range = _range;
			duration = _duration;
		}

		public int ManaCost
		{
			get { return manaCost; }
		}

		public override int CastingTime( Mobile from )
		{
			return castingTime;
		}

		public int S1
		{
			get { return degatMin; }
		}
		public int Bonus1
		{
			get { return degatMax; }
		}
		public virtual void CastSpellOn( Mobile target )
		{
		}
	}
}
