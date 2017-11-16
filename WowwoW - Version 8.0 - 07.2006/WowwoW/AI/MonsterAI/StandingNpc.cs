using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for DefensiveAnimalAI.
	/// </summary>
	public class StandingNpcAI : BaseAIType
	{
		public StandingNpcAI( BaseCreature bc ) : base( AITypes.NonAgressiveAnimalAI, bc )
		{
			//	Automate reg = new Automate();
			From.AIState = AIStates.Explore;
			//	reg.RegisterAssertion( new Assert( bc.Card1 ) );
			//	reg.RegisterAction( new Action( bc.Start ) );
			CustomBehaviours.Add( CustomBehavioursTypes.Stay ); 
			CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation ); 
		}
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int dmg )
		{
			if ( AIState != AIStates.Attack && AIState != AIStates.Fighting )
			{
				OnBeginFight( by );
				From.AttackTarget = by;
				return AIStates.BeingAttacked;
			}
			return AIState;
		}
		public override void OnTick()
		{
			if ( From.AIState == AIStates.Attack && From.AttackTarget != null )
			{
				if ( From.Distance( From.AttackTarget ) > 30 * 30 * 2 )
				{
					From.AIState = AIStates.Explore;
					From.AttackTarget = null;
					return;
				}
			}
		
			switch( AIState )
			{
				case AIStates.DoingNothing:
					//	retour a l'ai par defaut
					AIState = AIStates.Explore;
					break;
				case AIStates.Explore:
					AIState = AIStates.Pause1;
					break;
				case AIStates.Pause1:
					break;
			}
		}
	}
}
