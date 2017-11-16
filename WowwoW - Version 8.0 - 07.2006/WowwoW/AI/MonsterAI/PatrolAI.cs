using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for PatrolAI.
	/// </summary>
	public class PatrolAI : BaseAIType
	{
		public PatrolAI( BaseCreature bc ) : base( AITypes.NonAgressiveAnimalAI, bc )
		{
		//	Automate reg = new Automate();
			From.AIState = AIStates.LookingForPrey;
		}
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int dmg )
		{
			if ( AIState != AIStates.Attack && AIState != AIStates.Fighting )
			{
				OnBeginFight( by );
				return AIStates.BeingAttacked;
			}
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
			if ( From.AttackTarget == null || From.AttackTarget.Dead )
			{
				ArrayList mobs = From.KnownObjects();
				
				foreach( Object o in mobs )
				{
					if ( o is Mobile )
					{
						Mobile mob = o as Mobile;
						if ( From.Distance( mob ) < MaxViewDistance && Utility.Random4() == 0 && From.IsHostile( mob ) && From.CanSee( mob ) && 
							!mob.Dead )
						{
							OnBeginFight( mob );
							From.AIState = AIStates.BeingAttacked;
							From.AttackTarget = mob;
							return;
						}
					}
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
				case AIStates.Speaking:
					From.Running = false;
					TimeSpan ts = DateTime.Now.Subtract( From.SpeakingFrom );
					if ( ts.TotalSeconds > 15 )
						AIState = AIStates.LookingForPrey;
					break;
			}
		}
	}
}
