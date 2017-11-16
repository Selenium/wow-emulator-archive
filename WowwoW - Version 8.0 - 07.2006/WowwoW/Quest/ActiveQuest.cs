// Created by: DrNexus
// Changed by: Volhv at 26.10.05
using System;
using System.Collections;
using Server.Items;
using HelperTools;
using System.Reflection;

namespace Server
{
	/// <summary>
	/// ActiveQuest class contain status of Quest
	/// </summary>
	public class ActiveQuest
	{
		// private variables for this ActiveQuest
		// serialisation ver = 0
		private Hashtable	delivery = new Hashtable();							// Changed 24.09.05 ( format: delivery[int]=int )
		private Hashtable	npcobj = new Hashtable();							// Changed 24.09.05 ( format: npcobj[int]=int )
		private ArrayList	areas = new ArrayList();							// Changed 24.09.05
		private BaseQuest	activeQuest;										// ( link to BaseQuest )
		private bool		completed;											// ( quest is done )

		#region Constructors ( public ), changed: 24.09.05

		/// <summary>
		/// Constructor 
		/// 24.09.05: Removed initialisations of arrays
		/// </summary>
		public ActiveQuest( BaseQuest bq )
		{
			ConstructorInfo []ct = bq.GetType().GetConstructors();
			activeQuest = (BaseQuest)ct[ 0 ].Invoke( null );
		}
		
		/// <summary>
		/// Deserialise function
		/// </summary>
		public ActiveQuest( GenericReader gr )
		{
			Deserialisation( gr );
		}

		#endregion

		#region Serialisations ( public ), changed: 24.09.05

		/// <summary>
		/// Deserialisation
		/// changed: 24.09.05
		/// </summary>
		public void Deserialisation( GenericReader gr )
		{
			int version = gr.ReadInt();

			switch ( version )
			{
				case 0: // version = 0;
				{
					// Delivery obj
					int nDel = gr.ReadInt();
					if ( nDel > 0 )
					{
						for ( int t = 0; t<nDel; t++ )
						{
							int _id = gr.ReadInt();
							int _amount = gr.ReadInt();
							delivery.Add( _id, _amount );
						}
					}
					// Npc obj
					int nNpc = gr.ReadInt();
					if ( nNpc > 0 )
					{
						for ( int t = 0; t<nNpc; t++ )
						{
							int _id = gr.ReadInt();
							int _amount = gr.ReadInt();
							npcobj.Add( _id, _amount );
						}
					}
					// Areas
					int nAreas = gr.ReadInt();
					if ( nAreas > 0 )
					{
						for ( int t = 0; t<nAreas; t++ )
						{
							areas.Add( gr.ReadInt() );
						}
					}
					// init section
					activeQuest = World.CreateQuestById( gr.ReadInt() );
					completed = gr.ReadBool();
					break;
				}
			}
		}

		/// <summary>
		/// Serialisation
		/// changed: 24.09.05
		/// </summary>
		public void Serialisation( GenericWriter gw )
		{
			int version = 0; 
			gw.Write( version );

			/// version = 0; -------------------------------------
			// Delivery obj
			gw.Write( (int)delivery.Keys.Count );				// Delivery Objectives amount
			foreach ( int id in delivery.Keys )
			{
				gw.Write( (int)id );							// delivery Id
				gw.Write( (int)delivery[ id ] );				// amount 
			}
			// Npc obj
			gw.Write( (int)npcobj.Keys.Count );					// Npc Objectives amount
			foreach ( int id in npcobj.Keys )
			{
				gw.Write( (int)id );							// Mobile/Gameobj Id
				gw.Write( (int)npcobj[ id ] );					// amount
			}
			// Areas
			gw.Write( (int)areas.Count );						// Amount of areas
			foreach ( int aId in areas )
			{
				gw.Write( (int)aId );							// write each areaTriggerId
			}
			// init section
			gw.Write( (int)Id );								// write Id number of quest
			gw.Write( (bool)completed );						// write bool status of completion quest
		}

		#endregion

		#region Accessors ( public, get ), changed: 18.10.05

		/// <summary>
		/// progress of done quest
		/// </summary>
		public bool Done
		{
			get { return completed; }
			set { completed = value; }
		}

		/// <summary>
		/// Id of BaseQuest
		/// </summary>
		public int Id
		{
			get { return activeQuest == null ? -1 : activeQuest.Id; }
		}

		/// <summary>
		/// public link to basequest
		/// </summary>
		public BaseQuest baseQuest
		{
			get { return activeQuest; }
		}

		/// <summary>
		/// Type of BaseQuest
		/// </summary>
		public Type QuestType
		{
			get { return activeQuest.GetType(); }
		}

		/// <summary>
		/// Allow repeate quest
		/// </summary>
		public bool Repeatable
		{
			get { return activeQuest == null ? false : activeQuest.Repeatable; }
		}

		#endregion

		#region Quest Types ( public, get ), changed: 18.10.05

		/// <summary>
		/// have Discovery objective?
		/// </summary>
		public bool HaveDiscoveryObj
		{ 
			get { return activeQuest == null ? false : activeQuest.HaveDiscoveryObj; }
		}

		/// <summary>
		/// have Delivery objective?
		/// </summary>
		public bool HaveDeliveryObj
		{
			get { return activeQuest == null ? false : activeQuest.HaveDeliveryObj; }
		}

		/// <summary>
		/// Have TargetId for speak
		/// </summary>
		public bool HaveNPCTargetId
		{
			get { return activeQuest == null ? false : activeQuest.HaveNPCTargetId; }
		}

		/// <summary>
		/// Have NPC Objectives
		/// </summary>
		public bool HaveNPCObj
		{
			get { return activeQuest == null ? false : activeQuest.HaveNPCObj; }
		}

		/// <summary>
		/// Delivery to other Npc
		/// is Delivery quest And Have NPCTargetId
		/// </summary>
		public bool DeliveryNotForOwner
		{
			get { return activeQuest == null ? false : activeQuest.DeliveryNotForOwner; }
		}

		/// <summary>
		/// Quest is bugged?
		/// </summary>
		public bool QuestIsBugged
		{
			get { return activeQuest == null ? false : activeQuest.QuestIsBugged; }
		}
		#endregion

		#region Special functions ( public ), changed: 26.10.05

		#region Discovery Objectives
		/// <summary>
		/// Set status function for AreaTrigger
		/// 24.09.05
		/// </summary>
		public bool DiscoverAreaId( int aId )
		{
			bool result = false;
			if ( HaveDiscoveryObj ) // optimisation
			{
				if ( activeQuest.DiscoverigArea.Contains( aId ) )
				{
					if ( !areas.Contains( aId ) )
					{
						areas.Add( aId );
					}
					result = true;
				}
			}
			return result;
		}
		/// <summary>
		/// Check status function for AreaTrigger
		/// 24.09.05
		/// </summary>
		public bool CheckAreaId( int aId )
		{
			bool result = false;
			if ( HaveDiscoveryObj ) // optimisation
			{
				if ( activeQuest.DiscoverigArea.Contains( aId ) )
				{
					result = areas.Contains( aId );
				}
			}
			return result;
		}
		/// <summary>
		/// check status of discovered all areaTriggers
		/// 24.09.05
		/// </summary>
		public bool AllAreaDiscovered()
		{
			bool result = true;
			if ( HaveDiscoveryObj ) // optimisation
			{
				foreach ( int i in activeQuest.DiscoverigArea.Items )
				{
					if ( !areas.Contains( i ) ) result = false;
				}
			}
			return result;
		}
		#endregion

		#region Delivery Objectives

		/// <summary>
		/// Check item need for this quest
		/// 24.09.05
		/// </summary>
		public bool NeedItem( Item it )
		{
			return NeedItem( it.Id );
		}

		/// <summary>
		/// Check item need for this quest
		/// by Item.Id
		/// 24.09.05
		/// </summary>
		public bool NeedItem( int id )
		{
			bool result = false;
			if ( HaveDeliveryObj ) // optimisation
			{
				DeliveryObjective d = activeQuest.DeliveryObjectives.GetById( id );
				if ( d!= null ) // for quest need this item
				{
					if ( delivery.ContainsKey( id ) )
					{
						result = ((int)delivery[ id ]) < d.Amount;
					}
					else result = true;
				}
			}
			return result;
		}
	
		/// <summary>
		/// Increase status of dilivery quest item
		/// 24.09.05
		/// </summary>
		public int IncreaseDelivery( Item it )
		{
			return IncreaseDelivery( it.Id );
		}

		/// <summary>
		/// Increase status of delivery quest item
		/// by Item.Id
		/// 24.09.05
		/// need correction (amount of item)
		/// </summary>
		public int IncreaseDelivery( int id )
		{
			int result = 0;
			if ( HaveDeliveryObj ) // optimisation
			{
				DeliveryObjective d = activeQuest.DeliveryObjectives.GetById( id );
				if ( d!= null ) // for quest need this item
				{
					if ( delivery.ContainsKey( id ) )
					{
						int curr = (int)delivery[ id ];
						if ( curr < d.Amount )
						{
							//curr += it.MaxCount;
							curr ++;
							delivery[ id ] = curr;
							result = curr;
						}
					}
					else 
					{
						delivery.Add( id, (int)1 );
						result = 1;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Current Amount of Delivery Objectives
		/// </summary>
		public int DeliveryCurrentAmount()
		{
			int result = 0;
			if ( HaveDeliveryObj ) // optimisation
			{
				foreach ( int id in delivery.Keys )
				{
					result += (int)delivery[ id ];
				}
			}
			return result;
		}

		/// <summary>
		/// Amount of deliveryObjectives needed
		/// 24.09.05
		/// </summary>
		public int DeliveryCurrentAmount( Item it )
		{
			return DeliveryCurrentAmount( it.Id );
		}
		
		/// <summary>
		/// Amount of deliveryObjectives needed 
		/// by Item.Id
		/// 24.09.05
		/// </summary>
		public int DeliveryCurrentAmount( int id )
		{
			int result = 0;
			if ( HaveDeliveryObj ) // optimisation
			{
				DeliveryObjective d = activeQuest.DeliveryObjectives.GetById( id );
				if ( d!= null ) // for quest need this item
				{
					if ( delivery.ContainsKey( id ) )
					{
						result = (int)delivery[ id ];
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Amount of deliveryObjectives needed 
		/// 24.09.05
		/// </summary>
		public int DeliveryAmount( Item it )
		{
			return DeliveryAmount( it.Id );
		}

		/// <summary>
		/// Amount of deliveryObjectives needed 
		/// by Item.Id
		/// 24.09.05
		/// </summary>
		public int DeliveryAmount( int id )
		{
			int result = -1;
			if ( HaveDeliveryObj ) // optimisation
			{
				DeliveryObjective d = activeQuest.DeliveryObjectives.GetById( id );
				if ( d!= null ) // for quest need this item
				{
					result = d.Amount;
				}
			}
			return result;
		}

		/// <summary>
		/// Have all Delivery Objectives done
		/// 24.09.05
		/// </summary>
		public bool DoneAllDeliveryObj()
		{
			bool result = true;
			if ( HaveDeliveryObj ) // optimisation
			{
				foreach ( DeliveryObjective it in activeQuest.DeliveryObjectives.Items )
				{
					if ( delivery.ContainsKey( it.Id ) )
					{
						if ( ((int)delivery[ it.Id ]) < it.Amount ) { result = false; break; }
					}
					else { result = false; break; }
				}
			}
			return result;
		}

		#endregion

		#region Npc Objectives

		/// <summary>
		/// Increase NPCObj counter for creature
		/// 24.09.05
		/// </summary>
		public int IncreaseNpcObj( Mobile mob )
		{
			return IncreaseNpcObj( mob.Id );
		}

		/// <summary>
		/// Increase NPCObj counter for creature
		/// by Mobile.Id
		/// 24.09.05
		/// </summary>
		public int IncreaseNpcObj( int id )
		{
			int result = 0;
			if ( HaveNPCObj ) // optimisation
			{
				NPCObjective npc = activeQuest.NPCObjectives.GetById( id );
				if ( npc!= null ) // for quest need this item
				{
					if ( npcobj.ContainsKey( id ) )
					{
						int curr = (int)(npcobj[ id ]);
						if ( curr < npc.Amount )
						{
							curr ++;
							npcobj[ id ] = curr;
						}
						result = curr;
					}
					else 
					{
						npcobj.Add( id, (int)1 );
						result = 1;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Amount of current NPC Objectives
		/// 24.09.05
		/// </summary>
		public int NpcObjCurrentAmount( Mobile mob )
		{
			return NpcObjCurrentAmount( mob.Id );
		}

		/// <summary>
		/// Amount of current NPC Objectives
		/// by Mobile.Id
		/// 24.09.05
		/// </summary>
		public int NpcObjCurrentAmount( int id )
		{
			int result = 0;
			if ( HaveNPCObj ) // optimisation
			{
				NPCObjective npc = activeQuest.NPCObjectives.GetById( id );
				if ( npc!= null ) // for quest need this item
				{
					if ( npcobj.ContainsKey( id ) )
					{
						result = (int)npcobj[ id ];
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Amount of NPC Objectives
		/// by Mobile.Id
		/// 24.09.05
		/// </summary>
		public int NpcObjAmount( Mobile mob )
		{
			return NpcObjAmount( mob.Id );
		}

		/// <summary>
		/// Amount of NPC Objectives
		/// by Mobile.Id
		/// 24.09.05
		/// </summary>
		public int NpcObjAmount( int id )
		{
			int result = -1;
			if ( HaveNPCObj ) // optimisation
			{
				NPCObjective npc = activeQuest.NPCObjectives.GetById( id );
				if ( npc!=null ) 
				{
					result = npc.Amount;
				}
			}
			return result;
		}

		/// <summary>
		/// Have all NPC Objectives done
		/// 24.09.05
		/// </summary>
		public bool DoneAllNpcObj()
		{
			bool result = true;
			if ( HaveNPCObj ) // optimisation
			{
				foreach ( NPCObjective npc in activeQuest.NPCObjectives.Items )
				{
					if ( npcobj.ContainsKey( npc.Id2 ) )
					{
						if ( (int)npcobj[ npc.Id2 ] < npc.Amount ) { result = false; break; }
					}
					else { result = false; break; }

				}
			}
			return result;
		}

		/// <summary>
		/// Get total count of Npc Objectives
		/// (Count each npcObjective state)
		/// 26.10.05
		/// </summary>
		public int NpcObjGetTotalAmount()
		{
			int result = 0;
			if ( HaveNPCObj ) // optimisation
			{
				foreach ( int id in npcobj.Keys )
				{
					if ( npcobj[ id ] != null && (int)npcobj[ id ] > 0 )
					{
						result += (int)npcobj[ id ];
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Get count of Npc Objectives
		/// 26.10.05
		/// </summary>
		public int NpcObjGetCount()
		{
			int result = 0;
			if ( HaveNPCObj ) // optimisation
			{
				result = npcobj.Keys.Count;
			}
			return result;
		}

		#endregion
		
		/// <summary>
		/// Status of Compleate quest
		/// 18.10.05
		/// </summary>
		public bool Completed
		{
			get 
			{ 
				if ( Done || activeQuest == null ) return true;		//+ quest ready done or not exist

				if ( HaveNPCTargetId ) return false;				//+ need talk to targetId for done of quest

				if ( HaveDiscoveryObj )								//+ have Discovery Objectives
				{
					if ( !AllAreaDiscovered() ) return false;		//- need discover some areas before end quest
				}

				if ( HaveNPCObj )									//+ have Npc Objectives
				{
					if ( !DoneAllNpcObj() ) return false;			//- need end all Npc Objectives before end quest
				}

				if ( HaveDeliveryObj )								//+ have Delivery Objectives
				{
					if ( !DoneAllDeliveryObj() ) return false;		//- need end all Delivery Objectives before end quest
				}
				return true; 
			}
		}

		/// <summary>
		/// Status of Compleate quest for Character
		/// 18.10.05
		/// </summary>
		public bool CompletedFor( Character c )
		{
			if ( Done || activeQuest == null ) return true;			// quest ready done or not exist

			if ( !( HaveNPCTargetId && activeQuest.NPCTargetId == c.Id ) ) return false; // if TargetNPC = Character.Id

			if ( HaveDiscoveryObj )									// have Discovery Objectives
			{
				if ( !AllAreaDiscovered() ) return false;			// need discover some areas before end quest
			}

			if ( HaveNPCObj )										// have Npc Objectives
			{
				if ( !DoneAllNpcObj() ) return false;				// need end all Npc Objectives before end quest
			}

			if ( HaveDeliveryObj )									// have Delivery Objectives
			{
				if ( !DoneAllDeliveryObj() ) return false;			// need end all Delivery Objectives before end quest
			}
			return true; 
		}
		#endregion

	}
}
