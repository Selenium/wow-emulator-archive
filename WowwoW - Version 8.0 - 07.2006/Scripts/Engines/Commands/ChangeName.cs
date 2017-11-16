using System; 
using Server; 

// Created by TUM 04.07.05 

namespace Server.Scripts.Commands 
{ 
	public class ChangeName : IInitialize
	{ 
		public static void Initialize() 
		{ 
			Commands.Register( "ChangeName", AccessLevels.GM, new CommandEventHandler( ChangeName_OnCommand ), TargetType.PlayerOnly ); 
		} 

		private static bool ChangeName_OnCommand( CommandEventArgs e ) 
		{ 
			if (e.Length == 1) 
			{ 
				Character ch = e.Target as Character; 
				if (e.Player.AccountLevel <= ch.AccountLevel && e.Player != ch) 
				{ 
					e.Player.SendMessage("Your access level is low."); 
					return false;                    
				} 
				foreach (Account acct in World.allAccounts) 
				{ 
					foreach (Mobile m in acct.characteres) 
					{ 
						if (m.Name.ToLower() == e.GetString(0).ToLower()) 
						{ 
							e.Player.SendMessage(String.Format("Name '{0}' is allready exist.", e.GetString(0))); 
							return false; 
						} 
					} 
				} 
				ch.Name = e.GetString(0); 
				e.Player.SendMessage("Name successfully changed."); 
				if (e.Player != ch) 
				{ 
					ch.SendMessage(String.Format("Your name has been changed to '{0}' by {1}.", ch.Name, e.Player.Name) ); 
					ch.SendMessage("Your status bar will update after reconnecting."); 
				} 
				return true; 
			} 
			e.Player.SendMessage("Usage : .ChangeName <NewName>"); 
			return false; 
		} 
	} 
} 

