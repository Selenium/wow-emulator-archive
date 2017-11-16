using System;
using HelperTools;
using System.Collections;

namespace Server
{
	/// <summary>
	/// Summary description for NonAgressiveAnimalAI.
	/// </summary>
	public class NonAgressiveAnimalAI : BaseAIType
	{
		public NonAgressiveAnimalAI( BaseCreature bc ) : base( AITypes.NonAgressiveAnimalAI, bc )
		{
		//	Automate reg = new Automate();
			From.AIState = AIStates.Explore;
			//	reg.RegisterAssertion( new Assert( bc.Card1 ) );
			//	reg.RegisterAction( new Action( bc.Start ) );
		}
		public override AIStates OnGetHit( Mobile from, AIStates AIState, int dmg )
		{//	flee
			From.AttackTarget = from;
			return AIStates.Flee;
		}
		public override void OnTick()
		{

			switch( AIState )
			{
				case AIStates.DoingNothing:
					//	retour a l'ai par defaut
					AIState = AIStates.Explore;
					break;
				case AIStates.Explore:
					if ( Utility.Random4() == 0 )
						AIState = AIStates.Pause1;
					else
						if ( Utility.Random4() < 3 )
						AIState = AIStates.Pause4;
					break;
				case AIStates.Pause1:
					AIState = AIStates.Pause2;
					break;
				case AIStates.Pause2:
					AIState = AIStates.Pause3;
					break;
				case AIStates.Pause3:
					AIState = AIStates.Pause4;
					break;
				case AIStates.Pause4:
					AIState = AIStates.Pause5;
					break;
				case AIStates.Pause5:
					AIState = AIStates.Pause6;
					break;
				case AIStates.Pause6:
					AIState = AIStates.Pause7;
					break;
				case AIStates.Pause7:
					AIState = AIStates.Pause8;
					break;
				case AIStates.Pause8:
					AIState = AIStates.Pause9;
					break;
				case AIStates.Pause9:
					AIState = AIStates.Explore;
					break;
			}
		}
	}
}
