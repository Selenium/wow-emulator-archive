using System;

namespace Server
{
	/// <summary>
	/// Summary description for AbilitySummoning.
	/// </summary>
	public class AbilitySummoning : Ability
	{
		int summon;
		public AbilitySummoning( ushort _id,int _customFlags1,  int _summon, 
			int _degatMin, int _degatMax, 
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _classe	) : base( _id,_customFlags1, 
			_degatMin, _degatMax, Resistances.Armor, DispelType.None,
			_manacost, _castingtime, _range, _duration, _cooldown, 
			_classe )


		{
			summon = _summon;
		}
	}
}
