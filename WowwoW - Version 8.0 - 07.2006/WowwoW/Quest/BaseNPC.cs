// Created by Volhv
using System;
using System.Collections;
using Server.Items;
using Server.Creatures;
using HelperTools;
using Server;

namespace Server.Creatures
{
#if !VOLHV

	#region NPCTextRec addon, created 09.10.05
	public class NPCTextRec
	{
		private string[] lines = null;
		private string line = null;

		/// <summary>
		/// Init by one string
		/// </summary>
		public NPCTextRec( /*int id, int sub, */string text )
		{
			line = text;
		}

		/// <summary>
		/// Init by Text array
		/// </summary>
		public NPCTextRec( /*int id, int sub, */params string[] textLines )
		{
			lines = textLines;
		}

		/// <summary>
		/// If text -> return text
		/// If textLines -> return Rnd(textLines)
		/// </summary>
		public string GetText
		{
			get
			{
				if ( line != null ) return line;
				else return (string)Rnd.RandomObjectArr( lines );
			}
		}
	}
	#endregion

	#region enums
	public enum NPCMenuId: int
	{
		None		= 0,
		MainMenu	= 1,
		Quests		= 2,
		Hello		= 3,
		HelloBad	= 4
	}
	public enum NPCSubMenuId: int
	{
		Taxi			= 1,
		Vendor			= 2, 
		Trainer			= 3,
		Banker			= 4,
		InKeeperBind	= 5,
		InKeeperMsg		= 6
	}
	#endregion

	public class BaseNPC : BaseCreature
	{
		public BaseNPC(): base() {}

		public const string Version = "07.10.05";

		#region BaseQuestInit addon, created: 05.10.05

		private class BaseQuestInit: IInitialize
		{
			public static void Initialize() 
			{
				BaseQuest.onQuestStatus = new QuestDialogStatusDelegate( QDS ); 
			}
		}

		#endregion

		#region Type NPC ( private, public ), checked: 01.10.05

		/// <summary>
		/// Have ActionFlag
		/// </summary>
		public bool HaveFlag( NpcActions flag )
		{
			return ( NpcFlags | (uint)flag ) == NpcFlags;
		}

		private object _haveQuests = null;
		/// <summary>
		/// Have Quest flag
		/// </summary>
		public bool HaveQuests
		{
			get 
			{
				if (_haveQuests == null) _haveQuests = (bool)( Quests != null  && Quests.Length > 0 && HaveFlag( NpcActions.Dialog ));
				return (bool)_haveQuests;
			}
		}

		private object _vendor = null;
		/// <summary>
		/// Have Vendor flag
		/// </summary>
		public bool Vendor
		{
			get 
			{	
				if ( _vendor == null ) _vendor = (bool)(Sells != null && HaveFlag( NpcActions.Vendor ));
				return (bool)_vendor;
			}
		}

		private object _taxi = null;
		/// <summary>
		/// Have Taxi flag
		/// </summary>
		public bool Taxi
		{
			get 
			{ 
				if ( _taxi == null ) _taxi = (bool)(HaveFlag( NpcActions.Taxi ));
				return (bool)_taxi;
			}
		}

		private object _trainer = null;
		/// <summary>
		/// Have Trainer flag
		/// </summary>
		public bool Trainer
		{
			get 
			{ 
				if ( _trainer == null ) _trainer = (bool)(Trains != null && Trains.Length > 0 && HaveFlag( NpcActions.Trainer ));
				return (bool)_trainer; 
			}
		}

		private object _banker = null;
		/// <summary>
		/// Have Banker flag
		/// </summary>
		public bool Banker
		{
			get 
			{ 
				if ( _banker == null ) _banker = (bool)(HaveFlag( NpcActions.Banker ));
				return (bool)_banker; 
			}
		}

		private object _inKeeper = null;
		/// <summary>
		/// Have InKeeper flag
		/// </summary>
		public bool InKeeper
		{
			get 
			{ 
				if ( _inKeeper == null ) _inKeeper = (bool)(HaveFlag( NpcActions.InKeeper ));
				return (bool)_inKeeper; 
			}
		}
        
		private object _onlyQuests = null;
		/// <summary>
		/// Only quests have
		/// </summary>
		public bool OnlyQuests
		{
			get 
			{
				if ( _onlyQuests == null ) _onlyQuests = (bool)( NpcFlags == (uint)NpcActions.Dialog && Quests.Length > 0 );
				return (bool)_onlyQuests;
			}
		}
		#endregion

		#region onHello Rewards ( public ), checked: 25.09.05
		public bool HaveRewardOnHello( Character c )
		{
			bool result = false;
			ActiveQuest[] list = c.GetActiveQuests;
			if ( list != null )
			{
				foreach ( ActiveQuest aq in list )
				{
					if ( aq != null && aq.baseQuest != null )
					{
						BaseQuest bq = aq.baseQuest;
						if ( bq.HaveNPCTargetId && bq.NPCTargetId == this.Id )
						{
							if ( bq.HasReward() || bq.HasRewardChoice() )
							{
								if ( HaveFreeSlot( c ) ) 
								{
									c.OfferReward( this, bq.Id, bq.FinishTitle, bq.FinishDialog, getEmoteOnEnd( bq ) );
								}
								else
								{
									c.QuestFailed( qFailedReason.InventoryFull );
								}
							}
							else
							{
								c.OfferReward( this, bq.Id, bq.FinishTitle, bq.FinishDialog, getEmoteOnEnd( bq ) );
							}
							result = true; 
							break;
						}
					}
				}
			}
			return result;
		}
		#endregion

		#region Some static values ( public ), changed: 02.10.05
		public static string Dialog_Taxi			= "Taxi";
		public static string Dialog_Inkeeper_Bind	= "Make this inn your home.";
		public static string Dialog_Inkeeper_Msg	= "What Can I do at an inn?";
		public static string Dialog_Vendor			= "I want to browse your goods.";
		public static string Dialog_Teach			= "I can teach you somthing.";
		public static string Dialog_Bank			= "Bank";
		public static string Message_Hello			= "Hello.";
		#endregion

		#region Auto fill Quest[] system addon ( public ), checked: 25.09.05
		/// <summary>
		/// Support Auto fill quests system
		/// </summary>
		public override BaseQuest[] Quests
		{
			get
			{
				if ( base.Quests != null ) return base.Quests;
				else
				{
					switch ( NPCQuests.Status )
					{
						case InitStatus.None:// first get - initialise all
						{
							NPCQuests.Init();
							goto default;
						}
						default:
						{
							base.Quests = NPCQuests.GetQuestsFor( this.Id );
							return base.Quests;
						}
						
					}
				}
			}
			set {}
		}
		#endregion

		#region Some checks ( private ), checked: 25.09.05

		/// <summary>
		/// Check, for Race, Class, Skills, and Bugable quest
		/// </summary>
		private static bool AllowedTo( BaseQuest bq, Character c )
		{
			return ( bq.MinLevel <= c.Level ) && bq.AllowedClass( c ) && bq.AllowedRace( c ) && bq.AllowedSkills( c ) && !bq.QuestIsBugged ;
		}

		/// <summary>
		/// Have free slot in backpack or else containers
		/// </summary>
		private bool HaveFreeSlot( Character c )
		{
			return c.FindAFreeSlot() != Slots.None;
		}

		/// <summary>
		/// Character have Active quest for me ( NPCTargetId = Me.Id quests only )
		/// changed: 01.10.05, need mod
		/// </summary>
		private bool HaveCompleatedQuestForMe( Character c )
		{
			bool result = false;
			foreach ( ActiveQuest aq in c.GetActiveQuests ) 
			{ 
				if ( aq!=null && aq.baseQuest!=null ) 
				{ 
					BaseQuest bq = aq.baseQuest; 
					if ( bq.NPCTargetId == Id ) 
					{
						result = true; //aq.CompletedFor( c );
						break; 
					} 
				} 
			}
			return result;
		}

		/// <summary>
		/// get amount of active quests for character
		/// </summary>
		private int AmountActiveQuests( Character c ) 
		{
			int result = 0;
			foreach ( ActiveQuest aq in c.GetActiveQuests ) 
			{ 
				if ( aq!=null && aq.baseQuest!=null ) 
				{ 
					result++;
				}
			}
			return result;
		}

		#endregion

		#region GetQuest, GetStatus ( private ), checked: 25.09.05
		/// <summary>
		/// get array with count statuses for any QuestStatus
		/// </summary>
		private ArrayList GetStatusQuests( Character c )
		{
			ArrayList result = new ArrayList();
			for( int i=0; i<8; i++ )	//8 statuses
			{
				result.Add( (int)0 ); 
			}
			foreach ( BaseQuest bq in GetUnDoneQuestsFor( c ) ) 
			{
				int stat = (int)bq.QuestStatus( this, c ); 
				result[ stat ] = (int)result[ stat ] + 1; 
			}
			return result;
		}

		/// <summary>
		/// All not Done quests from this NPC
		/// </summary>
		private BaseQuest[] GetUnDoneQuestsFor( Character c )
		{
			ArrayList result = new ArrayList();
			for ( int i=0; i<Quests.Length; i++ ) 
			{ 
				BaseQuest q = Quests[i]; 
				if ( q != null && !c.QuestDone( q ) ) result.Add( q ); 
			}
			return (BaseQuest[])result.ToArray( typeof(BaseQuest));
		}

		/// <summary>
		/// All Available quests for character (Sort by level)
		/// </summary>
		private BaseQuest[] GetQuestsFor( Character c )
		{
			ArrayList result = new ArrayList();
			for ( int i=0; i<Quests.Length; i++ )
			{
				BaseQuest q = Quests[i];
				if ( q != null && AllowedTo( q, c ) && !c.QuestDone( q ) )
				{
					if ( q.PreviousQuest > 0 ) 
					{ 
						BaseQuest bq = World.CreateQuestById( q.PreviousQuest ); 
						if ( bq!=null && c.QuestDone( bq ) ) result.Add( q ); 
					}
					else result.Add( q );
				}
			}
			return ( BaseQuest[] )result.ToArray( typeof( BaseQuest ) );
		}

		/// <summary>
		/// User have [result] quests from NPC
		/// </summary>
		public static int AmountMyQuests( Character c, BaseNPC npc )
		{
			int result = 0;
			if ( npc.Quests != null ) 
			{
				foreach ( BaseQuest bq in npc.Quests ) 
				{ 
					result += c.HaveQuest( bq ) ? 1 : 0; 
				}
			}
			return result;
		}

		#endregion

		#region NPCText addon, created: 09.10.05

		#region Static
		
		private static Hashtable _sNpcTextArr = new Hashtable();
		
		/// <summary>
		/// For all NPC's - global texts
		/// </summary>
		public static void AddNpcText( int id, params string[] lines )
		{
			AddNpcText( id, new NPCTextRec( lines ) );
		}

		/// <summary>
		/// For all NPC's - global texts
		/// </summary>
		public static void AddNpcText( int id, string line )
		{
			AddNpcText( id, new NPCTextRec( line ) );
		}
		
		/// <summary>
		/// For all NPC's - global texts
		/// </summary>
		public static void AddNpcText( int id, NPCTextRec val )
		{
			if ( _sNpcTextArr.ContainsKey( id ) ) _sNpcTextArr.Remove( id );
			_sNpcTextArr.Add( id, val );
		}

		#endregion

		#region Private

		private Hashtable _npcTextArr = new Hashtable();

		/// <summary>
		/// For all NPC's - private texts
		/// </summary>
		public void addNpcText( int id, params string[] lines )
		{
			addNpcText( id, new NPCTextRec( lines ) );
		}

		/// <summary>
		/// For all NPC's - private texts
		/// </summary>
		public void addNpcText( int id, string line )
		{
			addNpcText( id, new NPCTextRec( line ) );
		}
		
		/// <summary>
		/// For all NPC's - private texts
		/// adding new - only overload old values
		/// </summary>
		public void addNpcText( int id, NPCTextRec val )
		{
			if ( _npcTextArr.ContainsKey( id ) ) _npcTextArr.Remove( id );
			_npcTextArr.Add( id, val );
		}

		#endregion

		#region QuestList support ( Messages, Emotions )

		/// <summary>
		/// Random messages for each NPC
		/// Work with Gossip
		/// </summary>
		public static string[] OnQuestListMessages = null;

		/// <summary>
		/// Random messages for custom NPC
		/// Work with Gossip
		/// </summary>
		public string[] onQuestListMessages = null;

		/// <summary>
		/// With array optimisations
		/// if have custom - use custom, else use default
		/// </summary>
		private string GetRndQLMessage
		{
			get
			{
				if ( onQuestListMessages!= null && onQuestListMessages.Length > 0 )
				{
					if ( onQuestListMessages.Length == 0 ) return (string)onQuestListMessages[0];
					else return (string)Rnd.RandomObjectArr( onQuestListMessages );
				}
				if ( OnQuestListMessages!= null && OnQuestListMessages.Length > 0 )
				{
					if ( OnQuestListMessages.Length == 0 ) return (string)OnQuestListMessages[0];
					return (string)Rnd.RandomObjectArr( OnQuestListMessages );
				}
				return "If you see this strings$B please contact with developers$B for correct Information";
			}
		}

		/// <summary>
		/// Emote for each npc on Quest List Shown
		/// </summary>
		public static object OnQuestListEmote = null;
		
		/// <summary>
		/// Emote for custom npc on Quest List Shown
		/// </summary>
		public object onQuestListEmote = null;
		
		private static qEmote _default_emote = new qEmote( Emote.ONESHOT_TALK, 500 );

		/// <summary>
		/// if have custom - use custom, else use default
		/// </summary>
		private qEmote GetQLEmote
		{
			get
			{
				if ( onQuestListEmote!= null && onQuestListEmote is qEmote ) return (qEmote)onQuestListEmote;
				if ( OnQuestListEmote!= null && OnQuestListEmote is qEmote ) return (qEmote)OnQuestListEmote;
				return _default_emote;
			}
		}

		#endregion

		#endregion

		/// <summary>
		/// On Quest Events
		/// added: 02.10.05
		/// </summary>
		public override void OnChooseQuest( Character c, int id )
		{
			foreach ( BaseQuest bq in Quests )
			{
				if ( bq!=null && bq.Id == id )
				{
					DoQuestEvents( c, bq ); 
					return;
				}
			}
			c.QuestFailed( qFailedReason.Failed );
		}

		/// <summary>
		/// Need Fill in Globals 
		/// changed: 09.10.05
		/// </summary>
		public override string QueryNpcText( int id )
		{
			Console.WriteLine( "querry: {0}, {1}", this.npcMenuId, id );

			if ( _npcTextArr.ContainsKey( id ) )
			{
				return (_npcTextArr[id] as NPCTextRec).GetText;
			}
			if ( _sNpcTextArr.ContainsKey( id ) )
			{
				return (_sNpcTextArr[id] as NPCTextRec).GetText;
			}
			//Else int m_id = npcMenuId;
			/*
			if( id == 10 )
			{
				return this.NpcText00;
			}
			else if(id==2)
			{
				return "Well when you stay at inn, you rest very comfortably. Because of this ,you will become more \"well rested\" much more quickly that you would in the wilderness. When you are well rested you learn more from experience.\n You may also speak with any innkeeper to get a hearthstone, and can later use the hearthstone in order to quickly return to that inn.\n";
			}*/
			return "If you see this strings$N please contact with developers$N for correct Information";
		} 

		/// <summary>
		/// General Dialogs from character
		/// changed: 01.10.05
		/// </summary>
		public override void OnHello( Character c )
		{
			if ( Reputation( c ) > 0.5f )
			{
				GMenu gMenu = new GMenu();
				GQMenu gQMenu = new GQMenu();

				if ( HaveQuests )
				{
					if ( HaveRewardOnHello( c ) ) return;			// if ready Rewarded onHello

					BaseQuest[] Qlist = GetQuestsFor( c );			// get all quests for this character

					if ( Qlist.Length == 1 )
					{
						DoQuestEvents( c, Qlist[0] ); 
						return;
					}
					for ( int i = 0; i< Qlist.Length; i++ ) 
					{
						gQMenu.Add( (uint)Qlist[i].Id, Qlist[i].QuestStatus( this, c ), Qlist[i].Name );
					}
					if ( OnlyQuests )
					{
						if ( gQMenu.Count > 0 )
						{
							c.QuestList( this, GetRndQLMessage, GetQLEmote, Qlist );
						}
						else
						{
							c.SendGossip( this, (int)NPCMenuId.Hello, null, null );
							//c.ResponseMessage( this, (int)NPCMenuId.Hello, Message_Hello );
						}
						return;
					}
				}
				
				if ( Taxi )			gMenu.Add( (int)NPCSubMenuId.Taxi,		GMenuIcons.Taxi,		false, Dialog_Taxi );
				if ( Vendor )		gMenu.Add( (int)NPCSubMenuId.Vendor,	GMenuIcons.Vendor,	false, Dialog_Vendor );
				if ( Trainer )		gMenu.Add( (int)NPCSubMenuId.Trainer,	GMenuIcons.Trainer,	false, Dialog_Teach );
				if ( Banker )		gMenu.Add( (int)NPCSubMenuId.Banker,	GMenuIcons.Banker,	false, Dialog_Bank );
				if ( InKeeper )
				{
					gMenu.Add( (int)NPCSubMenuId.Vendor,		GMenuIcons.Vendor,	false, Dialog_Vendor );
					gMenu.Add( (int)NPCSubMenuId.InKeeperBind,	GMenuIcons.Binder,	false, Dialog_Inkeeper_Bind );
					//NPCSubMenuId.InKeeperMsg
				}

				if ( gMenu.Count > 0 || gQMenu.Count > 0 )
				{
					c.SendGossip( this, (int)NPCMenuId.MainMenu, gMenu, gQMenu );
				}
				else 
				{
					c.SendGossip( this, (int)NPCMenuId.Hello, null, null );
					//c.ResponseMessage( this, (int)NPCMenuId.Hello, Message_Hello );
				}
			}
			else c.SendGossip( this, (int)NPCMenuId.HelloBad, null, null );//*/
			//else c.ResponseMessage( this, (int)NPCMenuId.HelloBad, "Get lost skum.." );
		}

		/// <summary>
		/// Overloaded Actions on dialog select event
		/// changed: 02.10.05
		/// </summary>
		public override void DialogCharacterSelection( Character c, int id, int num )
		{
			switch ( (NPCMenuId)id )
			{
				case NPCMenuId.MainMenu:// main menu
				{
					switch ( (NPCSubMenuId)num )
					{
						case NPCSubMenuId.Taxi: 
						{
							if ( Taxi ) //check for cracks
							{
								c.EndGossip();
								return;//do taxi events
							}
							else break;
						}
						case NPCSubMenuId.Vendor:
						{
							if ( Vendor || InKeeper )  //check for cracks
							{ 
								c.ShowMobileInventory( Guid ); 
								return; 
							}
							else break;
						}
						case NPCSubMenuId.Trainer:
						{
							if ( Trainer )  //check for cracks
							{ 
								c.TrainerList( Guid );
								return; 
							}
							else break;
						}
						case NPCSubMenuId.Banker:
						{
							if ( Banker )  //check for cracks
							{
								c.EndGossip();
								return;//do Banker events
							}
							else break;
						}
						case NPCSubMenuId.InKeeperBind://binder
						{
							if ( InKeeper ) //check for cracks
							{
								bool hsExist = false;
								foreach ( Item it in c.Items )
								{
									if ( it != null && it.Id == 6948 ) 
									{ 
										hsExist = true; break; 
									}
								}

								if ( !hsExist )//+Check for existing heartstone and if not exist - add to BP.
								{
									Item it = World.CreateItemInPoolById( 6948 ); //c.CreateAndAddObject( "Hearthstone" );
									if ( it != null ) c.PutObjectInBackpack( it, true );
								}
								// Check for distance from user to inkeeper
								c.BindingPointX = c.X;
								c.BindingPointY = c.Y;
								c.BindingPointZ = c.Z;
								c.BindingPointMapId = c.MapId;
								c.EndGossip();
								BindPointEffect( c );
								return;
							}
							else break;
						}
						case NPCSubMenuId.InKeeperMsg://gossip
						{
							if ( InKeeper ) 
							{
								c.EndGossip();
								return;//do InKeeper events
							}
							else break;
						}
					}
					c.ResponseMessage( this, (int)NPCMenuId.Hello, Message_Hello );	// if error in some dialogs
					return;
				}
			}
			if ( c.GossipOpened ) c.EndGossip();
		}

		/// <summary>
		/// private effect show bind
		/// created 30.10.05
		/// </summary>
		private void BindPointEffect( Character c )
		{
	//		SpellHelp.GraphicEffectTarget( this, 3286,c ); 
			int num1 = 4; 
			Converter.ToBytes((float)c.X, c.tempBuff, ref num1); 
			Converter.ToBytes((float)c.Y, c.tempBuff, ref num1); 
			Converter.ToBytes((float)c.Z, c.tempBuff, ref num1); 
			Converter.ToBytes((int)c.MapId, c.tempBuff, ref num1); 
			Converter.ToBytes((int)c.ZoneId, c.tempBuff, ref num1); 
			c.Send(OpCodes.SMSG_BINDPOINTUPDATE, c.tempBuff, num1); 
		}

		/// <summary>
		/// private internal Events on quest selections
		/// changed: 02.10.05
		/// </summary>
		private void DoQuestEvents( Character c, BaseQuest bq )
		{
			if ( c.QuestDone( bq ) ) return;

			if ( !c.QuestCompleted( bq ) ) 
			{
				if ( !c.HaveQuest( bq ) )
				{
					if ( bq.HaveDeliveryObj && !HaveFreeSlot( c ) ) // quest need free slot
					{
						c.QuestFailed( qFailedReason.InventoryFull );
					}
					else if ( AmountActiveQuests( c ) >= 20 ) // questLog is full
					{
						c.QuestLogIsFull();
					}
					else // can get quest
					{//need add questEmotion[] on get quest
						c.ResponseQuestDetails( this, bq.Id, bq.Name, bq.Desc, bq.Details, getEmoteOnStart( bq ) );
						//c.ResponseQuestDetails( this, bq.Id, bq.Name, bq.Desc, bq.Details, new qEmote[] { new qEmote( Emote.ONESHOT_TALK, 500 ) } );
					}
				}
				else
				{
					//c.QuestInvalid( qInvalidReason.ReadyHaveThatQuest );
					c.SendGossip( this, OnlyQuests ? (int)NPCMenuId.Quests : (int)NPCMenuId.MainMenu, null, null );
					//c.ResponseMessage( this, OnlyQuests ? (int)NPCMenuId.Quests : (int)NPCMenuId.MainMenu, bq.ProgressDialog );
				}
			}
			else if ( c.QuestCompleted( bq ) )
			{//need add questEmotion[] on complete quest
				c.OfferReward( this, bq.Id, bq.FinishTitle, bq.FinishDialog, getEmoteOnEnd( bq ) );
				//c.OfferReward( this, bq.Id, bq.FinishTitle, bq.FinishDialog, new qEmote[] { new qEmote( Emote.ONESHOT_TALK, 500 ) } );
			}
		}

		#region onDialogStatus, changed: 25.09.05

		/// <summary>
		/// Status viewed from NPC
		/// changed: 02.10.05
		/// </summary>
		public override DialogStatus OnDialogStatus( Character c )
		{
			if ( HaveCompleatedQuestForMe( c ) ) return DialogStatus.SingleQuestCompleate;

			ArrayList list = GetStatusQuests( c );
			for ( int i = 6; i>0; i-- )
			{
				if ( ( (int)list[ i ] ) > 0 ) return (DialogStatus)i;
			}
			
			if ( OnlyQuests ) return  DialogStatus.ChatUnAvailable;
            
			return  HaveFlag( NpcActions.Dialog ) ? DialogStatus.ChatAvailable : DialogStatus.ChatUnAvailable;	// support vendor/trainer/banker/taxi/
		}

		#endregion

		/// <summary>
		/// Static function for  using in all quests (for smaller code)
		/// changed: 01.10.05, need mod
		/// </summary>
		public static DialogStatus QDS( Mobile questOwner, Character c, BaseQuest bq )
		{
			DialogStatus result = DialogStatus.ChatUnAvailable;

			if ( questOwner.Reputation( c ) > bq.MinReputation )
			{
				if ( !c.QuestDone( bq ) )													// этот квест уже пройден
				{
					if ( !c.HaveQuest( bq ) )												// у чара нету этого квеста
					{
						if ( AllowedTo( bq, c ) )											// разрешено выдать, подходит ( расса, класс, скилл )
						{
							if ( bq.PreviousQuest > 0 )										// этот квест из серии, необходимо закончить предыдущий
							{
								BaseQuest q = World.CreateQuestById( bq.PreviousQuest );
								if ( q != null && c.QuestDone( q ) ) 
								{
									result = DialogStatus.SingleQuestAvailable;				//предыдущий закончен, этот можно получить
								}
							}
							else															// квест одиночный или начальный для серии
							{
								result = DialogStatus.SingleQuestAvailable;
							}
						}
					}
					else																	// Character have this quest already
					{
						ActiveQuest aq = c.FindPlayerQuest( bq );
						if ( aq.Completed )													// закончен квест, нужно наградить
						{
							result = aq.Repeatable ? DialogStatus.RepeatQuestCompleate : DialogStatus.SingleQuestCompleate;
						}
						else if ( !QuestForNPC( bq, (BaseNPC)questOwner  ) )				// квест не для этого нпс?
						{
							result = DialogStatus.QuestUnCompleate;
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Quest for this npc ?
		/// </summary>
		public static bool QuestForNPC( BaseQuest bq, BaseNPC npc )
		{
			return bq.HaveNPCTargetId && bq.NPCTargetId == npc.Id;
		}

		/// <summary>
		/// Extract emotion list from bq
		/// created: 09.10.05
		/// </summary>
		private static qEmote[] getEmoteOnStart( BaseQuest bq )
		{
			if ( bq.onStartQuestCustom != null ) return bq.onStartQuestCustom;
			if ( BaseQuest.onStartQuestDefault != null ) return BaseQuest.onStartQuestDefault;
			return null;
		}

		/// <summary>
		/// Extract emotion list from bq
		/// created: 09.10.05
		/// </summary>
		private static qEmote[] getEmoteOnEnd( BaseQuest bq )
		{
			if ( bq.onEndQuestCustom != null ) return bq.onEndQuestCustom;
			if ( BaseQuest.onEndQuestDefault != null ) return BaseQuest.onEndQuestDefault;
			return null;
		}

	}

#endif
}