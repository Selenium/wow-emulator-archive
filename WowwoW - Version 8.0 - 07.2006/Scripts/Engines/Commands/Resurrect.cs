//	Script modified by gandhar - 07/07/05 14:30:20
 //	Script made by gandhar - 06/07/05 15:51:44
//resurrects any mobile
using System;
using Server;
using Server.Scripts;

namespace Server.Scripts.Commands 
{ 
	public class Resurrect : IInitialize
	{ 
		public static void Initialize() 
		{ 
			Commands.Register( "Resurrect", AccessLevels.GM, new CommandEventHandler( Resurrect_OnCommand ),TargetType.AnyMobile ); 
		} 

		private static bool Resurrect_OnCommand( CommandEventArgs e ) 
		{ 
			if( e.Target is Corps )
			{                                   
				e.SendMessage("select a npc or player"); 
				return true;                     
			}
			else
			{
				e.Target.HitPoints = e.Target.BaseHitPoints;
				e.Target.HitPointsUpdate(e.Target);
				e.SendMessage("mobile {0} resurrected",e.Target.Name); 
				return true;
			}
		} 

	} 
} 