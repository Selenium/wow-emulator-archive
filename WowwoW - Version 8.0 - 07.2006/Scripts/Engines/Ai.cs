/* ======================================================================

NAME: <Ai for Hate System>

DATE  : 01.09.2005

VERSION : v 0.9 for Alpha 7.1

DESCRIPTION : For using Hate System need change in Creatures classes 
"AIEngine" field on some AI form this file; 
====================================================================== */
using System; 
using Server; 
using Server.Items;
using HelperTools;
using System.Collections; 
using System.Reflection; 
using Server.Creatures;


namespace Server.AI
{
	class AIFighterWithoutAbility : AIHate
	{
		public AIFighterWithoutAbility(BaseCreature _bc, float _area, float hateLimit ) : base( _bc, _area ) 
		{ 
			From.HateList = new ArrayList();
			HateLimit = hateLimit;
			Area = _area;
			From.AIState = AIStates.MoveNear;
			UpdateTargetHateList( 5f, Area );
		} 
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int d ) 
		{ 
			float dmg = (float)d;
			if(dmg>0)
			{
				AddUnit(by, dmg);
				AddForAllGroup(by, dmg, Area);
			}
			if ( AIState != AIStates.Attack && AIState != AIStates.Fighting ) 
			{
				return AIStates.BeingAttacked;
			}
			return AIState;
		} 
		public override void OnTick() 
		{ 
			HateUnit hu = new HateUnit(null,0);
			for(int i=0; From.HateList.Count > i;i++)
			{
				if( From.HateList.Count > 0 )
				{
					hu = (HateUnit)From.HateList[i];
					if (hu.Hate < 3 | this.From.Distance(hu.HatedMobile)>Area)//if mob too far, remove from list
					{
						this.From.HateList.Remove(hu);
						i--;
						continue;
					}
// 					else
//					{
//						hu.Hate = hu.Hate - 0.5f;//decrease a hate, may be need change or delete this string.
//						bc.HateList[i] =  hu;
//					}
				}
				if(!From.InCombat)
				{
					From.AttackTarget = ChooseAttackTarget(Area, HateLimit);
					if(From.AttackTarget != null)From.BeginCombatWith( From.AttackTarget ); 
					return;
				}
			}
			ChooseAction();
			UpdateTargetHateList(5f, Area);
		}
	}
	//=================================================================//
	class AIFighterWithAbility : AIHate
	{
		//bool Range;
		public AIFighterWithAbility( BaseCreature _bc, float area, float hateLimit  ) : base( _bc, area ) 
		{ 
			//Range = RangeAttack;
			HateLimit = hateLimit;
			Area= area;
			From.AIState = AIStates.BeingAttacked;
			UpdateTargetHateList( 5f , Area);
			From.HateList = new ArrayList();
		} 
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int d ) 
		{ 
			float dmg = (float)d;
			if(dmg>0)
			{
				AddUnit(by, dmg);
				AddForAllGroup(by, dmg, Area);
			}
			if ( AIState != AIStates.Attack && AIState != AIStates.Fighting ) 
			{
				return AIStates.BeingAttacked;
			}
			return AIState;
		} 
		//=================================================================//
		public override void OnTick() 
		{ 
			HateUnit hu = new HateUnit(null,0);
			for(int i=0; From.HateList.Count > i;i++)
			{
				if( From.HateList.Count > 0 )
				{
					hu = (HateUnit)From.HateList[i];
					if (hu.Hate < 3 | this.From.Distance(hu.HatedMobile)>Area)//if mob too far, remove from list
					{
						this.From.HateList.Remove(hu);
						i--;
					}
// 					else
//					{
//						hu.Hate = hu.Hate - 0.5f;//decrease a hate, may be need change or delete this string.
//						bc.HateList[i] =  hu;
//					}
				}
				if(!From.InCombat)
				{
					From.AttackTarget = ChooseAttackTarget(Area, HateLimit);
					if(From.AttackTarget != null)From.BeginCombatWith( From.AttackTarget ); return;
				}
				if(From.InCombat)ChooseAttackAction(From.AttackTarget);
			}
			ChooseAction();
			UpdateTargetHateList(5f, Area);
		}
	}
	class AIHealer : AIHate
	{
		public AIHealer( BaseCreature _bc, float hateLimit ,float area ) : base( _bc, area ) 
		{ 
			HateLimit = hateLimit;
			Area= area;
			From.AIState = AIStates.BeingAttacked;
			UpdateTargetHateList( 5f , Area);
			From.HateList = new ArrayList();

		} 
		public override AIStates OnGetHit( Mobile by, AIStates AIState, int d ) 
		{ 
			float dmg = (float)d;
			if(dmg>0)
			{
				AddUnit(by, dmg);
				AddForAllGroup(by, dmg, Area);
			}
			if ( AIState != AIStates.Attack && AIState != AIStates.Fighting ) 
			{
				return AIStates.BeingAttacked;
			}
			return AIState;
		} 
		//=================================================================//
		public override void OnTick() 
		{ 
			HateUnit hu = new HateUnit(null,0);
			for(int i=0; From.HateList.Count > i;i++)
			{
				if( From.HateList.Count > 0 )
				{
					hu = (HateUnit)From.HateList[i];
					if (hu.Hate < 3 | this.From.Distance(hu.HatedMobile)>Area)//if mob too far, remove from list
					{
						this.From.HateList.Remove(hu);
						i--;
					}
// 					else
//					{
//						hu.Hate = hu.Hate - 0.5f;//decrease a hate, may be need change or delete this string.
//						bc.HateList[i] =  hu;
//					}
				}
				HealAction();
			}
			ChooseAction();
			UpdateTargetHateList(5f, Area);
		}
		public void HealAction()
		{
			foreach(object obj in From.KnownObjects())
			{
				if(obj is Mobile)
				{
					Mobile t = obj as Mobile;
					if( From.Faction == t.Faction && !t.Dead && t.HitPoints != t.BaseHitPoints )
					{
						Console.WriteLine("HitPoint = {0}, BaseHitPoint = {1}", t.HitPoints, t.BaseHitPoints);
						From.BeginCast( Utility.Random(0, From.KnownAbilities.Count), t );
						break;
					}
				}
			}
		}
	}
}