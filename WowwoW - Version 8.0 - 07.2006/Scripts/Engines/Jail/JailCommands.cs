using System;
using Server;
using Server.Scripts.Commands;
//using Server.Scripts.Properties;

//Jail System v0.2
//Created by TUM 13.08.05
//Modified 16.08.05

namespace Server.Scripts.Commands.JailSystem
{
	public class JailCommands : IInitialize
	{
		public static void Initialize() 
		{ 
			Commands.Register( "Jail", AccessLevels.GM, new CommandEventHandler( Jail_OnCommand ), Scripts.Commands.TargetType.PlayerOnly );
			Commands.Register( "WhoJailed", AccessLevels.GM, new CommandEventHandler( WhoJailed_OnCommand ));
			Commands.Register( "UnJail", AccessLevels.GM, new CommandEventHandler( UnJail_OnCommand ), Scripts.Commands.TargetType.PlayerOnly);

		} 
		private static bool Jail_OnCommand( CommandEventArgs e ) 
		{
			if (e.Length == 1 && e.GetInt32(0) != 0)
			{
				if (e.Target != null && e.Target is Character) 
				{ 
					Jail.JailCharacter(e.Target as Character, 0, 0, e.GetInt32(0));					
					e.Player.SendMessage(String.Format("Player '{0}' successfully jailed on {1} minutes.", (e.Target as Character).Name, e.GetInt32(0)));
					return true;
				}								
			}
			if (e.Length == 2 && e.GetInt32(0) != 0)
			{
				if (e.Target != null && e.Target is Character) 
				{ 
					Jail.JailCharacter(e.Target as Character, 0, e.GetInt32(0), e.GetInt32(1));					
					e.SendMessage(String.Format("Player '{0}' successfully jailed on {1} hours {2} minutes.", (e.Target as Character).Name, e.GetInt32(0), e.GetInt32(1)));
					return true;
				}								
			}
			if (e.Length == 3 && e.GetInt32(0) != 0)
			{
				if (e.Target != null && e.Target is Character) 
				{ 
					Jail.JailCharacter(e.Target as Character, e.GetInt32(0), e.GetInt32(1), e.GetInt32(2));					
					e.Player.SendMessage(String.Format("Player '{0}' successfully jailed on {1} days {2} hours {3} minutes.", (e.Target as Character).Name, e.GetInt32(0), e.GetInt32(1), e.GetInt32(3)));
					return true;
				}								
			}
			e.Player.SendMessage("Usage : .Jail <Minutes>"); 
			e.Player.SendMessage("Usage : .Jail <Hours> <Minutes>");
			e.Player.SendMessage("Usage : .Jail <Days> <Hours> <Minutes>");
			return false;			
		}
		private static bool WhoJailed_OnCommand( CommandEventArgs e ) 
		{
			if (Jail.JailInfo.Count > 0)
			{
				for (int i=0; i<Jail.JailInfo.Count; i++)
				{
					JailInfo info = Jail.JailInfo[i] as JailInfo;
					e.SendMessage("{0}) {1} jailed {2}.{3}.{4} {5}:{6}:{7} on {8} days, {9} hours, {10} minutes", i, info.Character.Name, info.JailedDate.Day, info.JailedDate.Month, info.JailedDate.Year, info.JailedDate.Hour, info.JailedDate.Minute, info.JailedDate.Second, info.JailTime.Days, info.JailTime.Hours, info.JailTime.Minutes);
				}
				return true;
			}
			else
			{
				e.SendMessage("Nobody jailed.");
				return true;
			}
		}
		private static bool UnJail_OnCommand( CommandEventArgs e ) 
		{
			Character m = e.Target as Character;
			foreach(JailInfo info in Jail.JailInfo )
			{
				if (info.Character == m)
				{
					Jail.UnJailCharacter(m);
					return true;
				}
			}
			e.SendMessage("Character '{0}' isn't jailed.", m.Name);
			return true;
		}
	}
}