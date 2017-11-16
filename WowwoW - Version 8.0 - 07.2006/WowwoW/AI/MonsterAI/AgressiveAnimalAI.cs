using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for AgressiveAnimalAI.
	/// </summary>
	public class AgressiveAnimalAI : BaseAIType
	{
		public AgressiveAnimalAI( BaseCreature bc ) : base( AITypes.NonAgressiveAnimalAI, bc )
		{
			From.AIState = AIStates.Explore;
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
			
			if ( From.AIState == AIStates.Attack && From.AttackTarget != null )
			{
				if ( From.Distance( From.AttackTarget ) > 25 * 25 )
				{
					From.AIState = AIStates.Explore;
					From.AttackTarget = null;
					return;
				}
			}
			if ( From.AttackTarget == null || From.AttackTarget.Dead )
			{
				ArrayList mobs = From.KnownObjects();
				int dist = 10 + 4 * ( 256 - Utility.Random16() * Utility.Random16() );
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
					//	return to the default AI
					AIState = AIStates.Explore;
					break;
				case AIStates.Explore:
					if ( Utility.Random16() < 2 )
						AIState = AIStates.Pause1;
					else
						if ( Utility.Random16() < 4 )
						AIState = AIStates.Pause4;
					break;
				case AIStates.Pause1://	make a pause
					AIState = AIStates.Pause2;
					break;
				case AIStates.Pause2://	make a pause
					AIState = AIStates.Pause3;
					break;
				case AIStates.Pause3://	make a pause
					AIState = AIStates.Pause4;
					break;
				case AIStates.Pause4://	make a pause
					AIState = AIStates.Pause5;
					break;
				case AIStates.Pause5://	make a pause
					AIState = AIStates.Explore;
					break;
			}
		}
	}
}
