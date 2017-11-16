// Created by Volhv
using System;
using System.IO;
using System.Threading;
using System.Collections;
using Server.Creatures;
using Server.Quests;
using Server.Items;

namespace Server
{
#if !VOLHV
	public enum InitStatus:byte
	{
		None=0, Started, Done
	}
	public class NPCQuests
	{
		public const string Version = "04.10.05";

		private static InitStatus	status		= InitStatus.None;
		private static Hashtable	_NPCQuests	= new Hashtable();
		/// <summary>
		/// Status of initialisations for each NPC quests
		/// </summary>
		public static InitStatus Status
		{
			get { return status; }
		}

		#region Internal functions
		/// <summary>
		/// internal function
		/// </summary>
		private static BaseQuest[] GetAllQuestsInWorld()
		{
			ArrayList result = new ArrayList();
			result.AddRange( World.QuestPool.Values );
			return (BaseQuest[])result.ToArray( typeof(BaseQuest) );
		}
		/// <summary>
		/// internal function
		/// </summary>
		private static bool QuestExists( int qId )
		{
			return World.QuestPool[ qId ] != null;
		}
		/// <summary>
		/// internal function
		/// </summary>
		private static BaseCreature[] GetAllCreaturesInWorld()
		{
			ArrayList result = new ArrayList();
			foreach ( BaseCreature bc in World.allMobs )
			{
				result.Add( bc );
			}
 			return (BaseCreature[])result.ToArray( typeof(BaseCreature) );
		}
		/// <summary>
		/// internal function
		/// </summary>
		private static void AddTo( Hashtable _list, int _key, int _val )
		{
			if ( _list.ContainsKey( _key ) )
			{
				ArrayList values = (ArrayList)_list[ _key ];
				if ( !values.Contains( _val ) ) values.Add( _val );
			}
			else
			{
				ArrayList values = new ArrayList();
				values.Add( _val );
				_list.Add( _key, values );
			}
		}
		/// <summary>
		/// internal function
		/// </summary>
		private static ArrayList GetFrom( Hashtable _list, int _key )
		{
			ArrayList result = new ArrayList();
			if ( _list.ContainsKey( _key ) ) result.AddRange( ( ArrayList )_list[ _key ] );
			return result;
		}
		/// <summary>
		/// internal function
		/// BaseQuest.npcId
		/// </summary>
		private static void AddQuest( int npcId, int questId )
		{
            AddTo( _NPCQuests, npcId, questId );
		}
		/// <summary>
		/// internal function
		/// Check quest links to BaseCreature.Id
		/// </summary>
		private static void CheckQuest( Hashtable _cArr, int _cId, BaseQuest bq, bool addQuest, string nameVar )
		{
			if ( _cId > 0 )//CreatureId - link from quest (npcId, SpeakToId, DeliveryId )
			{
				if ( _cArr.ContainsKey( _cId ) )// creatures array have this CreatureId
				{
					if ( ((BaseCreature)_cArr[ _cId ]) is BaseNPC )//this Id is BaseNPC class old
					{
						if ( addQuest ) AddQuest( _cId, bq.Id );//add int Id to array
					}
					else 
					{
						string text = string.Format( "* {0} have bad \"{1} = {2};\" link", bq.GetType().Name, nameVar, _cId );
						string data1 = string.Format( "\t> Need change \"BaseCreature\" to \"BaseNPC\" in inherite (header) area." );
						string data2 = string.Format( "\t-> Ex: \"public class {0}: BaseNPC\"", ((BaseCreature)_cArr[ _cId ]).GetType().Name );
						AddErr( text, data1, data2 );
					}
				}
				else 
				{
					string text = string.Format( "* {0} have bad \"{1}\" link ( Creature \"Id = {2}\" is not exist: need remark this and use questisBugged or write this creature script )", bq.GetType().Name, nameVar, _cId );
					string data1 = string.Format( "\t> Need create this creature \"Id = {0};\"", _cId );
					string data2 = string.Format( "\t> Or Remark line \"//{1} = {0};\" and use \"questIsBugged = true;\"", _cId, nameVar );
					AddErr( text, data1, data2 );
				}
			}
			else 
			{	
				if ( addQuest )//if this is a npcId
				{
					string text = string.Format( "* {0} have bad \"{1} = ?;\" link ( need use Id from NPC questOwner )", bq.GetType().Name, nameVar );
					string data1 = string.Format( "\t> Need search and find this creature questOwner and then use Id number to \"npcId = (Id);\"" );
					string data2 = string.Format( "\t> Or create this creature and then use it number.." );
					AddErr( text, data1, data2 );
				}
			}
		}
		#endregion

		#region Errors section
		private class Err
		{
			public int num = 1;
			private string _text = "";
			private string[] _data = null;
			public Err( string text, params string[] data )
			{
                _text = text;
				_data = data;
			}
			public override string ToString()
			{
				string result = _text;
				if ( _data != null )
				{
					foreach ( string txt in _data ) result += "\r\n"+txt;
				}
				return result;
			}
		}
		private static ArrayList errors = new ArrayList();
		private static int errorsCount
		{
			get 
			{
				int result = 0;
				for ( int i=0; i< errors.Count; i++ )
				{
					if ( errors[i] is Err ) result++;
				}
				return result; 
			}
		}
		private static void AddErr( string text, params string[] data )
		{
			errors.Add( new Err( text, data ) );
		}
		private static void AddErrHeader( string format, params object[] args )
		{
			errors.Add( string.Format( format, args ) );
		}
		public static void LOGErrors( string filename, bool overvrite )
		{
			using ( StreamWriter tw = new StreamWriter( filename, overvrite ) )
			{
				tw.WriteLine( " Warning List from [{0}], please read carefuly ", DateTime.Now );
				tw.WriteLine( "" );
				foreach ( object o in errors )
				{
					tw.WriteLine( o.ToString() );
				}
			}
		}
		#endregion

		/// <summary>
		/// BaseQuest[] for npcId
		/// </summary>
		public static BaseQuest[] GetQuestsFor( int npcId )
		{
			if ( _NPCQuests.ContainsKey( npcId ) )
			{
				if ( _NPCQuests[ npcId ] is BaseQuest[] )
				{
					return (BaseQuest[])_NPCQuests[ npcId ]; //optimized
				}
				else if ( _NPCQuests[ npcId ] is ArrayList )
				{
					ArrayList quests = new ArrayList();
					foreach ( int qId in (_NPCQuests[ npcId ] as ArrayList) )
					{
						BaseQuest bq = World.CreateQuestById( qId );
						if ( bq != null ) quests.Add( bq );
					}
					return (BaseQuest[])quests.ToArray( typeof( BaseQuest ) ); //support un optimized
				}
			}
			return new BaseQuest[] {};
		}

		/// <summary>
		/// total reinitialisation, check and fill quests to arrays
		/// </summary>
		public static void Init()
		{
			// second initialisation exclude
			if ( status != InitStatus.None || World.Loading ) return;
			status = InitStatus.Started;

			bool haveExeption = false;
			bool haveWarns = false;
			
			try // strongly recomended to use (for exclude server crush if uncorrect scripts)
			{
				BaseQuest[]		allQuests = GetAllQuestsInWorld();
				BaseCreature[]	allCreatures = GetAllCreaturesInWorld();

				//sort all Creatures by ID
				Hashtable SortedCreatures = new Hashtable();
				foreach ( BaseCreature bc in allCreatures )
				{
					if ( !SortedCreatures.ContainsKey( bc.Id ) )
					{
						SortedCreatures.Add( (int)bc.Id, bc );
					}
					else
					{
						if ( bc.Id>0 ) 
						{
							string text = string.Format( "* {0} is already have ( [{2}].Id = {1} )", bc.GetType().Name, bc.Id, ((BaseCreature)(SortedCreatures[bc.Id])).GetType().Name );
							string data1 = string.Format( "\t> Check this creatureId \"{0}\" in each script", bc.Id );
							AddErr( text, data1 );
						}
					}
					if ( bc.Quests != null && ( bc.GetType().Name != "BaseNPC" ) && bc.Quests.Length > 0 ) 
					{
						string text = string.Format( "* {0} already have Quests line", bc.GetType().Name );
						string data1 = string.Format( "\t> Need remove/remark this line \"Quests = new ...\"" );
						string data2 = string.Format( "\t-> remark mean \"//Quests = new ...\"" );
						AddErr( text, data1, data2 );
					}
				}
				// some text output
				if ( errors.Count > 0 ) 
				{
					errors.Insert( 0, "" );
					errors.Insert( 0, "Start checking Creatures [Server.Creatures]" );
					AddErrHeader( "" );
					AddErrHeader( "Start checking Quests [Server.Quests]" );
					AddErrHeader( "" );
					haveWarns = true;
				}
				// checking and fill quest arrays
				foreach ( BaseQuest bq in allQuests )
				{
					
					CheckQuest( SortedCreatures, bq.NPCId, bq, true, "NPCId" ); //checks NPC Id
					CheckQuest( SortedCreatures, bq.NPCTargetId, bq, false, "NpcTargetId" ); //checks Target Id
					
					if ( !bq.QuestIsBugged )
					{
						
						if ( bq.PreviousQuest > 0 && !QuestExists( bq.PreviousQuest ) ) //checks PreviousQuest
						{
							string text = string.Format( "* {0} have bad link to PreviousQuest (prev quest is not exist)", bq.GetType().Name );
							string data1 = string.Format( "\t> Try do quest by number {0}", bq.PreviousQuest );
							string data2 = string.Format( "\t> Or comment this line \"previousQuest = {0};\"", bq.PreviousQuest );
							AddErr( text, data1, data2 );
						}
						if ( bq.NextQuest > 0 && !QuestExists( bq.NextQuest )) //checks NextQuest
						{
							string text = string.Format( "* {0} have bad link to NextQuest (next quest is not exist)", bq.GetType().Name );
							string data1 = string.Format( "\t> Try do quest by number {0}", bq.NextQuest );
							string data2 = string.Format( "\t> Or comment this line \"nextQuest = {0};\"", bq.NextQuest );
							AddErr( text, data1, data2 );
						}
						if ( bq.QuestFlags == 0 ) //checks for bad questflag
						{
							string text = string.Format( "* {0} have bad questFlags ( value is 0 )", bq.GetType().Name );
							string data1 = string.Format( "\t> Try change value to \"questFlags = 0x20;\"" );
							AddErr( text, data1 );
						}
					}
				}
				// some text output
				if ( errors.Count > 0 && !haveWarns ) 
				{
					errors.Insert( 0, "" );
					errors.Insert( 0, "Start checking Quests [Server.Quests]" );
				}
				// optimisations (this operation allow use this code convertions only one time and then free some processor time )
				// int[] -> BaseQuest[] for each NPC
				Hashtable tmp = new Hashtable();
				foreach ( int cId in _NPCQuests.Keys )
				{
					ArrayList list = (ArrayList)_NPCQuests[ cId ];
					ArrayList quests = new ArrayList();
					foreach ( int qId in list )
					{
						BaseQuest bq = World.CreateQuestById( qId );
						if ( bq != null ) quests.Add( bq );
					}
					tmp.Add( cId, (BaseQuest[])quests.ToArray( typeof( BaseQuest ) ) );
				}
				_NPCQuests.Clear();
				_NPCQuests = tmp;
				//End Of Optimisations
			}
			catch ( Exception e )
			{
				haveExeption = true;
				AddErrHeader( "" );
				AddErrHeader( "Exeption: {0}", e );
				AddErrHeader( "" );
				AddErrHeader( "message: {0}", e.Message );
				AddErrHeader( "source: {0}", e.Source );
				AddErrHeader( "stack trace: {0}", e.StackTrace );
				AddErrHeader( "inner exeption: {0}", e.InnerException );
				AddErrHeader( "target site: {0}", e.TargetSite );
				AddErrHeader( "help link: {0}", e.HelpLink );
			}
			finally
			{
			}

			// each NPC can use this section after initialisations
			if ( !haveExeption ) status = InitStatus.Done; // if have exeprion - not allow use quests
		}
	}
#endif
}
