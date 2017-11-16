using System; 
using System.Collections; 
using Server; 

// Created by TUM 04.07.05 

namespace Server.Scripts.Commands 
{ 
   public class ToStartLocation : IInitialize
   { 
      public static void Initialize() 
      { 
         Commands.Register( "ToStartLocation", AccessLevels.GM, new CommandEventHandler( ToStartLocation_OnCommand )); 
      } 

      private static bool ToStartLocation_OnCommand( CommandEventArgs e ) 
      { 
         if (e.Length == 1) 
         { 
            foreach (Account acct in World.allAccounts) 
            { 
               foreach (Mobile m in acct.characteres) 
               { 
                  Character ch = m as Character; 
                  if (ch.Name.ToLower() == e.GetString(0).ToLower()) 
                  {    
                     TeleportToStartingLocation(ch); 
                     e.Player.SendMessage(String.Format("Player '{0}' successfully teleported to starting location.", ch.Name)); 
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
                     TeleportToStartingLocation(acct.SelectedChar); 
                     e.Player.SendMessage(String.Format("Player '{0}' successfully teleported to starting location.", acct.SelectedChar.Name)); 
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
            if (e.Target != null && e.Target is Character) 
            { 
               TeleportToStartingLocation(e.Target as Character); 
               e.Player.SendMessage(String.Format("Player '{0}' successfully teleported to starting location.", (e.Target as Character).Name)); 
            } 
            e.Player.SendMessage("Select player first."); 
         } 
         e.Player.SendMessage("Usage : .ToStartLocation"); 
         e.Player.SendMessage("Usage : .ToStartLocation <Character Name>"); 
         e.Player.SendMessage("Usage : .ToStartLocation Account <Account Name>"); 
         return false; 
      } 
      public static void TeleportToStartingLocation (Character ch) 
      { 
         float X,Y,Z; 
         X = Y = Z = 0f; 
         int MapId = 0; 
         switch (ch.Race) 
         { 
            case Races.Dwarf: 
               X = -6240.32f; 
               Y = 331.033f; 
               Z = 382.758f; 
               MapId = 0; 
               break; 
            case Races.Gnome: 
               X = -6240.32f; 
               Y = 331.033f; 
               Z = 382.758f; 
               MapId = 0; 
               break; 
            case Races.Human: 
               X = -8949.95f; 
               Y = -132.493f; 
               Z = 83.5312f; 
               MapId = 0; 
               break; 
            case Races.NightElf: 
               X = 10311.3f; 
               Y = 832.463f; 
               Z = 1326.41f; 
               MapId = 1; 
               break; 
            case Races.Orc: 
               X = -618.518f; 
               Y = -4251.67f; 
               Z = 38.718f; 
               MapId = 1; 
               break; 
            case Races.Tauren: 
               X = -2917.58f; 
               Y = -257.98f; 
               Z = 52.9968f; 
               MapId = 1; 
               break; 
            case Races.Troll: 
               X = -618.518f; 
               Y = -4251.67f; 
               Z = 38.718f; 
               MapId = 1; 
               break; 
            case Races.Undead: 
               X = 1676.35f; 
               Y = 1677.45f; 
               Z = 121.67f; 
               MapId = 0; 
               break;             
         } 
         if (World.allConnectedChars.Contains(ch)) 
            ch.Teleport(X, Y, Z, MapId); 
         else 
         {                   
            ch.X = X; 
            ch.Y = Y; 
            ch.Z = Z; 
            ch.MapId = (ushort)MapId; 
         } 
          
      } 
   } 
} 