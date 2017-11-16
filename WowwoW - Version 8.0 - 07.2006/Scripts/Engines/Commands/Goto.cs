using System; 
using System.Collections; 
using Server; 


// Created by TUM 04.07.05 

namespace Server.Scripts.Commands 
{ 
   public class GoTo : IInitialize
   { 
      public static void Initialize() 
      { 
         Commands.Register( "GoTo", AccessLevels.GM, new CommandEventHandler( GoTo_OnCommand )); 
      } 

      private static bool GoTo_OnCommand( CommandEventArgs e ) 
      { 
         if (e.Length == 1) 
         { 
            foreach(Account acct in World.allAccounts) 
            { 
               foreach (Mobile m in acct.characteres) 
               { 
                  if (m.Name.ToLower() == e.GetString(0).ToLower()) 
                  { 
                     e.Player.Teleport(m.X, m.Y, m.Z, m.MapId); 
                     return true; 
                  } 
               } 
            } 
            e.Player.SendMessage(String.Format("Character with name '{0}' not found.", e.GetString(0))); 
            return false; 
         } 
         else if (e.Length == 2 && e.GetString(0).ToLower() == "account") 
         { 
            foreach(Account acct in World.allAccounts) 
            { 
               if (acct.Username.ToLower() == e.GetString(1).ToLower()) 
               { 
                  if (acct.SelectedChar != null) 
                  { 
                     Character m = acct.SelectedChar; 
                     e.Player.Teleport(m.X, m.Y, m.Z, m.MapId); 
                     return true; 
                  } 
                  else 
                  { 
                     e.Player.SendMessage(String.Format("Account with name '{0}' is not online.", e.GetString(1))); 
                     return false; 
                  } 
               } 
                
            } 
            e.Player.SendMessage(String.Format("Account with name '{0}' not found.", e.GetString(1))); 
            return false;             
         } 
         else if (e.Length == 0) 
         { 
            if (e.Target != null) 
            { 
               e.Player.Teleport(e.Target.X, e.Target.Y, e.Target.Z, e.Target.MapId); 
               return true; 
            } 
            e.Player.SendMessage("Select something first."); 
         } 
         e.Player.SendMessage("Usage : .GoTo"); 
         e.Player.SendMessage("Usage : .GoTo <Character Name>"); 
         e.Player.SendMessage("Usage : .GoTo Account <Account Name>"); 
         return false; 
      } 
   } 
} 