using System;
using HelperTools;
using System.Collections;

namespace Server
{
	/// <summary>
	/// Summary description for AIType.
	/// </summary>
	public class BaseAIType
	{
	//	Allele allele;
		AITypes aiType;
		BaseCreature from;
		ArrayList customBehaviours = new ArrayList();

		public static BaseAIType []aiTypes = new BaseAIType[ 32 ];

		public BaseAIType( AITypes _aiType, BaseCreature bc )
		{
			aiType = _aiType;
			from = bc;
		}

		public static BaseAIType NonAgressiveAnimalsAI
		{
			get { return aiTypes[ 0 ]; }
		}
		
		public virtual AIStates OnGetHit( Mobile by, AIStates AIState, int dmg )
		{
			return AIStates.Flee;
		}
		public virtual void OnTick()
		{
		}
		#region ACCESSORS
		protected int MaxViewDistance
		{
			get 
			{ 
				/*int dist = 200 + From.Level * From.Level / 2;
				if ( dist > 20 * 20 )
					return 400;*/
				if ( From.Level > 60 )
					return 945;
				return World.ViewingDistance[ From.Level ];
			}
		}
		public ArrayList CustomBehaviours
		{
			get { return customBehaviours; }
		}
		public AIStates AIState
		{
			get { return From.AIState; }
			set { From.AIState = value; }
		}
		public AITypes AIType
		{
			get { return aiType; }
		}
		public BaseCreature From
		{
			get { return from; }
		}
		#endregion

		public void OnBeginFight( Mobile m )
		{
			int offset = 4;
			Converter.ToBytes( From.Guid, From.tempBuff, ref offset );
			Converter.ToBytes( 2, From.tempBuff, ref offset );
			From.ToAllPlayerNear( OpCodes.SMSG_AI_REACTION, From.tempBuff, offset );
		}
	}
}
