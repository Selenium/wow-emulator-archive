using System; 
using System.Collections; 
using Server; 

// Created by TUM 06.07.05 

namespace Server.Scripts.Commands 
{ 
   public class Dublicate : IInitialize
   { 
      public static void Initialize() 
      { 
         Commands.Register( "Dublicate", AccessLevels.GM, new CommandEventHandler( Dublicate_OnCommand )); 
      } 


      private static bool Dublicate_OnCommand( CommandEventArgs e ) 
      { 
         string name; 
         string toacctname; 
         Character from = new Character(); 
         if (e.Length == 2 && e.Target != null && e.Target is Character) 
         { 
            name = e.GetString(1); 
            from = e.Target as Character; 
            toacctname = e.GetString(0); 
         } 
         else if (e.Length == 3) 
         { 
            bool found = false; 
            name = e.GetString(2); 
            toacctname = e.GetString(1); 
            foreach(Account acct in World.allAccounts) 
            { 
               foreach (Mobile m in acct.characteres) 
               { 
                  Character ch = m as Character; 
                  if (ch.Name.ToLower() == e.GetString(0).ToLower()) 
                  { 
                     from = ch; 
                     found = true; 
                  } 
               } 
            } 
            if (!found) 
            { 
               e.Player.SendMessage(String.Format("Character with name {0} not found.", e.GetString(0))); 
               return false; 
            } 
             
         } 
         else 
         { 
            e.Player.SendMessage("Usage : .Dublicate <To Account> <New Name>"); 
            e.Player.SendMessage("Usage : .Dublicate <Character Name> <To Account> <New Name>"); 
            return false; 
         } 

         foreach (Account acct in World.allAccounts) 
         {    
            foreach (Mobile m in acct.characteres) 
            { 
               if (m.Name.ToLower() == name.ToLower()) 
               { 
                  e.Player.SendMessage(String.Format("Name '{0}' is allready exist.", name)); 
                  return false; 
               } 
            } 
         } 
         foreach (Account toacct in World.allAccounts) 
         { 
            if (toacct.Username.ToLower() == toacctname.ToLower()) 
            { 
                    DublicateCharacter (from, toacct, name); 
               e.Player.SendMessage(String.Format("Character '{0}' successfully dublicated to account '{1}'.", from.Name, toacct.Username)); 
               return true; 
            } 
         } 
         e.Player.SendMessage(String.Format("Account with name '{0}' not found.", toacctname)); 
         return false;          
      } 
      static void DublicateCharacter (Character from, Account toacct, string name) 
      {          
         Character toch = new Character(); 
         toch.CopyAllParameters(from); 
         toch.Name = name; 
         toch.X = from.X; 
         toch.Y = from.Y; 
         toch.Z = from.Z; 
         toch.MapId = from.MapId; 
         toch.ZoneId = from.ZoneId;                   
         toacct.characteres.Add(toch);             
      }       
   } 
} 