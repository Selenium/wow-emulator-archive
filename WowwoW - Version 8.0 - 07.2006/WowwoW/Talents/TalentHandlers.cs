using System;

namespace Server
{
	/// <summary>
	/// Summary description for TalentHandlers.
	/// </summary>
	public class TalentHandlers
	{
		public delegate void TalentHandler( BaseAbility ba, Mobile src );
		public TalentHandlers()
		{/*
			#region MAGE
			#region ARCANE
			Mobile.onInitialiseTalent[ 11210 ] = 
			Mobile.onInitialiseTalent[ 12592 ] = 
			Mobile.onInitialiseTalent[ 12593 ] = new TalentHandler( MageTalents.OnArcaneSubtlety );
			#endregion
			#endregion
			*/
		}
	}
}
