/* ======================================================================

NAME: <Hate System>

DATE  : 01.09.2005

VERSION : v 0.9 for Alpha 7.1
====================================================================== */
using System; 
using Server; 
using Server.Items;
using HelperTools;
using System.Collections; 
using System.Reflection; 
using Server.Creatures;

namespace Server
{	
	public struct HateUnit
	{
		Mobile bc;
		float cHate;
		public HateUnit(Mobile _bc, float _cHate)
		{
			bc = _bc;
			cHate = _cHate;
		}
		public float Hate
		{
			get
			{
				return cHate;
			}
			set
			{
				if(value > 0)this.cHate = 0;
				this.cHate = value;
			}
		}
		public Mobile HatedMobile
		{
			get
			{
				return bc;
			}
			set
			{
				this.bc = value;
			}
		}
	}
	//=================================================================//
	public class AIHate : BaseAIType 
	{ 
		public float Area;
		public float HateLimit;
		public AIHate( BaseCreature _bc, AITypes _AiTypes, AIStates _AiState,float _area) : base( _AiTypes, _bc ) 
		{ 
			Area = _area;
			From.AIState = _AiState;
		} 
		public AIHate( BaseCreature _bc, float _area ) : base( AITypes.NonAgressiveAnimalAI, _bc ) 
		{ 
			Area = _area;
			From.AIState = AIStates.Explore; 
			
		} 
		//=================================================================//
		public void AddUnit(Mobile by, float _dmg)//add hate to hateList equal 'dmg'
		{
			float dmg=_dmg;
			dmg = dmg/((float)From.BaseHitPoints/100);
			HateUnit Addhu = new HateUnit(null, 0);
			for(int i=0; From.HateList.Count > i;i++)
			{
				Addhu = (HateUnit)From.HateList[i];
				if( Addhu.HatedMobile == by )
				{
					Addhu.Hate = (Addhu.Hate + dmg > 100) ? 100 : Addhu.Hate + dmg ;
					From.HateList[i]=Addhu;
					return;
					//					if(by != From.attackTarget)
					//					{
					//						double tempHate = Addhu.Hate;
					//						HateUnit tempUnit = Addhu;
					//						for( i=0; this.HateList.Count > i;i++)
					//						{
					//							Addhu = (HateUnit)this.HateList[i];
					//							if( Addhu.HatedMobile == From.attackTarget )
					//							{
					//								if((tempHate - Addhu.Hate) >= 30)
					//								{
					//									From.attackTarget = tempUnit.HatedMobile;
					//								}
					//								return;
					//							}
					//						}
					//					}
				}
			}
			Addhu.HatedMobile = by;
			Addhu.Hate = dmg;
			From.HateList.Add(Addhu);
		}
		//=================================================================//
		public void AddForAllGroup(Mobile by, float _dmg, float area)//add hate to all creature equal faction in range 
		{
			foreach( object obj in From.KnownObjects() )
			{
				if( obj is BaseCreature)
				{
					BaseCreature mob = obj as BaseCreature;
					if( this.From.Distance( mob ) < area && !mob.Dead && this.From.Faction == mob.Faction )
					{
						float dmg = (_dmg/((float)mob.BaseHitPoints/100))/3;
						
						HateUnit Addhu = new HateUnit(null, 0);
						for(int j=0; mob.HateList.Count > j;j++)
						{
							Addhu = (HateUnit)mob.HateList[j];
							if( Addhu.HatedMobile == by )
							{	
								Addhu.Hate = (Addhu.Hate + dmg > 100) ? 100 : Addhu.Hate + dmg ;
								System.Console.WriteLine("Hate amount {0}", Addhu.Hate);
								mob.HateList[j]=Addhu;
								break;
							}
						}
					}
				}
			}
		}
		//=================================================================//
		public void ChooseAction()//if no target for attack, choose some action.
		{
			switch( AIState ) 
			{ 
				case AIStates.DoingNothing: 
					//   return to the default AI 
					AIState = AIStates.Explore; 
					break; 
				case AIStates.Explore: 
					if ( Utility.Random16() < 2 ) 
						AIState = AIStates.MoveNear; 
					else 
						if ( Utility.Random16() < 4 ) 
						AIState = AIStates.Pause4; 
					break; 
				case AIStates.Pause1://   make a pause 
					AIState = AIStates.MoveNear; 
					break; 
				case AIStates.Pause2://   make a pause 
					AIState = AIStates.Pause3; 
					break; 
				case AIStates.Pause3://   make a pause 
					AIState = AIStates.MoveNear; 
					break; 
				case AIStates.Pause4://   make a pause 
					AIState = AIStates.Pause5; 
					break; 
				case AIStates.Pause5://   make a pause 
					AIState = AIStates.Explore; 
					break;
			} 
		}
		//=================================================================//
		public Mobile ChooseAttackTarget(float AttackDistance, float HateLimit)
		{
			HateUnit AttackTarget = new HateUnit(null, 0);
			foreach(HateUnit unit in this.From.HateList)
			{
				if (AttackTarget.HatedMobile != null)
				{
					if ( From.Distance(unit.HatedMobile) < AttackDistance & !unit.HatedMobile.Dead )
					{
						if (this.From.Distance( unit.HatedMobile ) < this.From.Distance( AttackTarget.HatedMobile ) && unit.Hate > AttackTarget.Hate |
							this.From.Distance( unit.HatedMobile ) == this.From.Distance( AttackTarget.HatedMobile ) && unit.Hate > AttackTarget.Hate )
						{
							if (AttackTarget.Hate < unit.Hate && unit.Hate > this.HateLimit && unit.HatedMobile.Level + 8 > this.From.Level)
							{
								//if (( From.Reputation( From.attackTarget ) < 0.5f )) From.BeginCombatWith( From.attackTarget );
								AttackTarget.HatedMobile = unit.HatedMobile;
							}
						}
					}
				}
				else
				{
					if ( unit.Hate > this.HateLimit && unit.HatedMobile.Level + 8 > this.From.Level)
					{
						AttackTarget.HatedMobile = unit.HatedMobile;
					}
				}
			}
			return AttackTarget.HatedMobile;
		}
		//=================================================================//
		public void ChooseAttackAction(Mobile target)
		{
			if(target != null)
			{
				if( From.KnownAbilities.Count > 0 && Utility.Random( From.Mana, From.BaseMana )> From.HitPoints )
				{
					From.BeginCast( Utility.Random(0, From.KnownAbilities.Count), target );
				}
			}
		}
		//=================================================================//
		public void UpdateTargetHateList( float HatePoint, float area )
		{
			foreach(object obj in this.From.KnownObjects())
			{
				if(obj is Mobile)
				{
					Mobile target = obj as Mobile;
					if(this.From.HateList.Count>0)
					{
						foreach(HateUnit unit in this.From.HateList)
						{
							if(unit.HatedMobile == target )
							{
								break;
							}
							else if( this.From.CanSee( target ) && 
								!target.Dead && this.From.Distance( target ) < area && target.Faction != this.From.Faction)
							{
								HateUnit AddUnit = new HateUnit(target, HatePoint);
								this.From.HateList.Add(AddUnit);
								break;
							}
						}
					}
					else if( this.From.CanSee( target ) && 
						!target.Dead && this.From.Distance( target ) < area && target.Faction != this.From.Faction )
					{
						HateUnit AddUnit = new HateUnit(target, HatePoint);
						this.From.HateList.Add(AddUnit);
					}
				}
			}
		}
	}
}