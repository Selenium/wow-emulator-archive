using System; 
using System.Collections; 
using Server; 

// Created by TUM 04.07.05 

namespace Server.Scripts.Commands 
{ 
   public class Bring : IInitialize
   { 
      public static void Initialize() 
      { 
         Commands.Register( "Bring", AccessLevels.GM, new CommandEventHandler( Bring_OnCommand )); 
      } 

      private static bool Bring_OnCommand( CommandEventArgs e ) 
      { 
         if (e.Length == 1) 
         { 
            foreach(Account acct in World.allAccounts) 
            { 
               foreach (Mobile m in acct.characteres) 
               { 
                  Character ch = m as Character; 
                  if (ch.Name.ToLower() == e.GetString(0).ToLower()) 
                  {       
                     if (World.allConnectedChars.Contains(ch)) 
                     { 
                        ch.Teleport(e.Player.X, e.Player.Y, e.Player.Z, e.Player.MapId); 
                        return true; 
                     } 
                     else 
                     {                                           
                        Console.WriteLine("Player is not online."); 
                        ch.X = e.Player.X; 
                        ch.Y = e.Player.Y; 
                        ch.Z = e.Player.Z; 
                        ch.MapId = e.Player.MapId; 
                        return true; 
                     } 
                      
                  } 
               } 
            } 
            e.Player.SendMessage(String.Format("Character with name {0} not found.", e.GetString(0))); 
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
                     m.Teleport(e.Player.X, e.Player.Y, e.Player.Z, e.Player.MapId); 
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
               if (e.Target is Character) 
               { 
                  Character ch = e.Target as Character; 
                  ch.Teleport(e.Player.X, e.Player.Y, e.Player.Z, e.Player.MapId); 
                  return true; 
               }                
            } 
            e.Player.SendMessage("Select player first."); 
         } 
         e.Player.SendMessage("Usage : .Bring"); 
         e.Player.SendMessage("Usage : .Bring <Character Name>"); 
         e.Player.SendMessage("Usage : .Bring Account <Account Name>"); 
         return false; 
      } 
   } 
} 