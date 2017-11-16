using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for PatrolAI.
	/// </summary>
	public class TravellerSalesmanAI : BaseAIType
	{
		public TravellerSalesmanAI( BaseCreature bc ) : base( AITypes.NonAgressiveAnimalAI, bc )
		{
		//	Automate reg = new Automate();
			From.AIState = AIStates.LookingForPrey;
		}
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int dmg )
		{
			if ( AIState != AIStates.Attack && AIState != AIStates.Fighting )
				return AIStates.BeingAttacked;
			return AIState;
		}
		public override void OnTick()
		{
			if ( From.DebugSniffer != null )
				From.DebugSniffer.SendMessage( "PredatorAI::OnTick" );
			if ( From.AIState == AIStates.Attack && From.AttackTarget != null )
			{
				if ( From.Distance( From.AttackTarget ) > 35  * 35  * 2 )
				{
					From.AIState = AIStates.LookingForPrey;
					From.AttackTarget = null;
					return;
				}
			}
			switch( AIState )
			{
				case AIStates.DoingNothing:
					//	retour a l'ai par defaut
					AIState = AIStates.LookingForPrey;
					From.Running = false;
					break;
				case AIStates.LookingForPrey:
					From.Running = false;
					break;
			}
		}
	}
}
