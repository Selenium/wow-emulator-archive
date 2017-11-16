using System;
using System.Collections;

namespace Server
{
	/// <summary>
	/// Summary description for TalentDescription.
	/// </summary>
	public class TalentDescription
	{
		int id;
		int rank;
		int []effects;
		int reqEffect;
		int reqLevel;
		public static Hashtable all = new Hashtable();
		public static Hashtable talentList = new Hashtable();
		public TalentDescription( int i, int r, int []fx, int reqfx, int reql )
		{
			id = i;
			rank = r;
			effects = fx;
			reqEffect = reqfx;
			reqLevel = reql;
		}
		public BaseAbility AuraFX( int l )
		{
			return (BaseAbility)Abilities.abilities[ effects[ l ] ];
		}
		public int AuraFXId( int l )
		{
			return effects[ l ];
		}
		public static bool IsTalent( int id )
		{
			if ( talentList[ id ] == null )
				return false;
			return true;
		}
	}
}
