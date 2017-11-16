using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for SummonedAI.
	/// </summary>
	public class SummonedAI : BaseAIType
	{
		Mobile summonedFrom;
		public SummonedAI( Mobile s, BaseCreature bc ) : base( AITypes.Custom, bc )
		{
			summonedFrom = s;
		//	Automate reg = new Automate();
			bc.AIState = AIStates.Follow;
			bc.AIStance = AIStances.Defensive;
		}
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int dmg )
		{			
			if ( by != summonedFrom && AIState != AIStates.Attack && AIState != AIStates.Fighting )
				return AIStates.BeingAttacked;
			return AIState;
		}

		public override void OnTick()
		{			
			if ( From.DebugSniffer != null )
				From.DebugSniffer.SendMessage( "SummonedAI::OnTick" );
			
			if ( From.AIState == AIStates.Attack && From.AttackTarget != null )
			{
				if ( From.Distance( From.AttackTarget ) > 30 * 30 * 2 )
				{
					From.AIState = AIStates.Follow;
					From.AttackTarget = null;
					return;
				}
			}
			if ( ( From.AttackTarget == null || From.AttackTarget.Dead ) && From.AIStance != AIStances.Passive )
			{
				if ( summonedFrom == null )
				{
					Console.WriteLine( "Stage summonedFrom NULL" );
					return;
				}
				if ( ( summonedFrom as Character ).Player == null )
				{
					From.X = -2000f;
					From.Y = -2000f;
					From.Z = 1000f;
					From.MapId = 2;					
					return;
				}
				foreach( Object o in ( summonedFrom as Character ).Player.KnownObjects )
				{
					if ( o is Mobile )
					{
						Mobile c = o as Mobile;
						if ( c != summonedFrom && From.AIStance == AIStances.Agressive )
						{
							if ( ( summonedFrom as Mobile ).Reputation( c ) < 0.3f && From.CanSee( c ) && !c.Dead && From.Distance( c ) < MaxViewDistance )
							{
								OnBeginFight( c );
								From.AIState = AIStates.BeingAttacked;
								From.AttackTarget = (Mobile)c;
								if ( From.DebugSniffer != null )
									From.DebugSniffer.SendMessage( "SummonedAI::OnTick::SeePrey" );
								return;
							}
						}
						/*else
							if ( From.Faction != c.Faction && From.CanSee( c ) && c.Visible && !c.Dead && From.Distance( c ) < 30 * 30 * 2 )
						{
							From.AIState = AIStates.BeingAttacked;
							From.AttackTarget = (Mobile)c;
							if ( From.DebugSniffer != null )
								From.DebugSniffer.SendMessage( "SummonedAI::OnTick::SeePrey" );
							return;
						}*/
					}
				}
			}
			switch( AIState )
			{
				case AIStates.DoingNothing:
					From.AIState = AIStates.Follow;
					break;
				case AIStates.Pause1:
					break;
				case AIStates.Follow:
					float dist = summonedFrom.Distance( From );
					float ndist = ( From.CombatReach + summonedFrom.CombatReach );
					if ( dist > 5 )
					{
						if ( dist > ndist )
							From.Running = true;
						else
							From.Running = false;
						double angle = (float)Math.Atan2( summonedFrom.Y - From.Y, summonedFrom.X - From.X );
						angle += Math.PI;
						From.MoveTo( (float)( summonedFrom.X + Math.Cos( angle ) * ndist * 1.5 ), (float)( summonedFrom.Y + Math.Sin( angle ) * ndist * 1.5 ), (float)( summonedFrom.Z ) );
					}
					break;
			}
		}
	}
}
