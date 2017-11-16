using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for DefensiveAnimalAI.
	/// </summary>
	public class DefensiveAnimalAI : BaseAIType
	{
		public DefensiveAnimalAI( BaseCreature bc ) : base( AITypes.NonAgressiveAnimalAI, bc )
		{
		//	Automate reg = new Automate();
			From.AIState = AIStates.Explore;
			//	reg.RegisterAssertion( new Assert( bc.Card1 ) );
			//	reg.RegisterAction( new Action( bc.Start ) );
		}
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int dmg )
		{
			if ( AIState != AIStates.Attack && AIState != AIStates.Fighting )
			{
				OnBeginFight( by );
				if ( by == From )
					From.AttackTarget = From.LastOffender;
				else
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
			}/*
			if ( From.AIState == AIStates.BeingAttacked && ( From.AttackTarget == null || From.AttackTarget.Dead ) )
			{
				ArrayList mobs = From.KnownObjects();
				foreach( Object o in mobs )
				{
					if ( o is Mobile )
					{
						Mobile mob = o as Mobile;
						if ( From.IsHostile( mob ) && From.CanSee( mob ) && 
							!mob.Dead && From.Distance( mob ) < 30 * 30 * 2 )
						{
							From.AIState = AIStates.BeingAttacked;
							From.AttackTarget = mob;
							return;
						}
					}
				}
			}*/
			switch( AIState )
			{
				case AIStates.DoingNothing:
					//	retour a l'ai par defaut
					AIState = AIStates.Explore;
					break;
				case AIStates.Explore:
					if ( Utility.Random16() < 2 )
						AIState = AIStates.Pause1;
					else
						if ( Utility.Random16() < 4 )
						AIState = AIStates.Pause2;
					break;
				case AIStates.Pause1:
					AIState = AIStates.Pause2;
					break;
				case AIStates.Pause2:
					AIState = AIStates.Pause3;
					break;
				case AIStates.Pause3:
					AIState = AIStates.Explore;
					break;
			}
		}
	}
}
