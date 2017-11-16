using System;

namespace Server
{
	public class Reactions : IInitialize
	{

		public static void Initialize()
		{
			Console.WriteLine( "Reaction system activated" );
			//	set the reaction with the same faction to 0.8 by default
			for(int t = 0;t < 134;t++ )
				Mobile.SetReaction( (Factions)t, (Factions)t, 0.8f );
			//	the Monster faction hate and is hated by everyone except the other monsters
			for(int t = 0;t < 134;t++ )
			{
				Mobile.SetReaction( (Factions)t, Factions.Monster, 0.1f );
				Mobile.SetReaction( Factions.Monster, (Factions)t, 0.1f );
				Mobile.SetReaction( (Factions)t, Factions.EvilBeast, 0.1f );
				Mobile.SetReaction( Factions.EvilBeast, (Factions)t, 0.1f );
			}
			Mobile.SetReaction( Factions.Monster, Factions.Monster, 0.8f );
			Mobile.SetReaction( Factions.EvilBeast, Factions.EvilBeast, 0.8f );
			Mobile.SetReaction( Factions.Beast, Factions.Monster, 0.8f );

			for(int t = 0;t < 126;t++ )
				Mobile.SetReaction( Factions.Beast, (Factions)t, 0.3f );
			//	The beasts hate prey
			Mobile.SetReaction( Factions.Beast, Factions.Prey, 0.1f );
			Mobile.SetReaction( Factions.EvilBeast, Factions.Prey, 0.1f );

			//	Prey are pacifists
			for(int t = 0;t < 134;t++ )
			{		
				Mobile.SetReaction( Factions.Prey, (Factions)t, 0.8f );
				Mobile.SetReaction( (Factions)t, Factions.NoFaction, 0.8f );
				Mobile.SetReaction( (Factions)t, Factions.Beast, 0.8f );
			} 				
			//	Monsters are neutral with beasts
			Mobile.SetReaction( Factions.Monster, Factions.Beast, 0.5f );
			Mobile.SetReaction( Factions.Monster, Factions.EvilBeast, 0.5f );
			Mobile.SetReaction( Factions.Monster, Factions.NoFaction, 0.5f );
			Mobile.SetReaction( Factions.EvilBeast, Factions.NoFaction, 0.5f );
			//Mobile.SetReaction( Factions.Beast, Factions.NoFaction, 0.5f );
			//Mobile.SetReaction( Factions.Stormwind, Factions.NoFaction, 0.5f );
			
			Mobile.SetReaction( Factions.IronForge, Factions.Alliance, 0.7f );
			Mobile.SetReaction( Factions.IronForge, Factions.GnomereganExiles, 0.7f );
			Mobile.SetReaction( Factions.IronForge, Factions.Darnasus, 0.7f );
			Mobile.SetReaction( Factions.IronForge, Factions.Stormwind, 0.7f );
			Mobile.SetReaction( Factions.IronForge, Factions.BootyBay, 0.5f );
			
			Mobile.SetReaction( Factions.GnomereganExiles, Factions.Alliance, 0.7f );
			Mobile.SetReaction( Factions.GnomereganExiles, Factions.Darnasus, 0.7f );
			Mobile.SetReaction( Factions.GnomereganExiles, Factions.IronForge, 0.7f );
			Mobile.SetReaction( Factions.GnomereganExiles, Factions.Stormwind, 0.7f );
			Mobile.SetReaction( Factions.GnomereganExiles, Factions.BootyBay, 0.5f );
			
			Mobile.SetReaction( Factions.Stormwind, Factions.Alliance, 0.7f );
			Mobile.SetReaction( Factions.Stormwind, Factions.GnomereganExiles, 0.7f );
			Mobile.SetReaction( Factions.Stormwind, Factions.IronForge, 0.7f );
			Mobile.SetReaction( Factions.Stormwind, Factions.Darnasus, 0.7f );
			Mobile.SetReaction( Factions.Stormwind, Factions.BootyBay, 0.5f );
			
			Mobile.SetReaction( Factions.Darnasus, Factions.IronForge, 0.7f );
			Mobile.SetReaction( Factions.Darnasus, Factions.Alliance, 0.7f );
			Mobile.SetReaction( Factions.Darnasus, Factions.GnomereganExiles, 0.7f );
			Mobile.SetReaction( Factions.Darnasus, Factions.Stormwind, 0.7f );
			Mobile.SetReaction( Factions.Darnasus, Factions.BootyBay, 0.5f );
			
			Mobile.SetReaction( Factions.Alliance, Factions.BootyBay, 0.5f );
			
			
			Mobile.SetReaction( Factions.Horde, Factions.BootyBay, 0.5f );
			Mobile.SetReaction( Factions.Undercity, Factions.Horde, 0.7f );
			Mobile.SetReaction( Factions.Undercity, Factions.Ogrimmar, 0.7f );
			Mobile.SetReaction( Factions.Undercity, Factions.Ratchet, 0.7f );
			Mobile.SetReaction( Factions.Undercity, Factions.ThunderBluff, 0.7f );
			Mobile.SetReaction( Factions.Undercity, Factions.DarkspearTrolls, 0.7f );
			
			Mobile.SetReaction( Factions.Ogrimmar, Factions.Horde, 0.7f );
			Mobile.SetReaction( Factions.Ogrimmar, Factions.Ratchet, 0.6f );			
			Mobile.SetReaction( Factions.Ogrimmar, Factions.DarkspearTrolls, 0.6f );
			Mobile.SetReaction( Factions.Ogrimmar, Factions.ThunderBluff, 0.6f );
			Mobile.SetReaction( Factions.Ogrimmar, Factions.Undercity, 0.6f );
			
			Mobile.SetReaction( Factions.DarkspearTrolls, Factions.Horde, 0.7f );
			Mobile.SetReaction( Factions.DarkspearTrolls, Factions.Ratchet, 0.7f );
			
			Mobile.SetReaction( Factions.Ratchet, Factions.Horde, 0.7f );	
			
			Mobile.SetReaction( Factions.ThunderBluff, Factions.Horde, 0.7f );	
			Mobile.SetReaction( Factions.ThunderBluff, Factions.Undercity, 0.7f );	
			Mobile.SetReaction( Factions.ThunderBluff, Factions.Ogrimmar, 0.7f );
			Mobile.SetReaction( Factions.ThunderBluff, Factions.Ratchet, 0.7f );
			Mobile.SetReaction( Factions.ThunderBluff, Factions.DarkspearTrolls, 0.7f );			
			
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.NoFaction, 0.7f );

			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.Horde, 0.1f );	
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.ThunderBluff, 0.1f );	
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.Ogrimmar, 0.1f );
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.DarkspearTrolls, 0.1f );	
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.Ratchet, 0.1f );
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.DarkspearTrolls, 0.1f );
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.IronForge, 0.1f );	
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.Alliance, 0.1f );
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.GnomereganExiles, 0.1f );	
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.Darnasus, 0.1f );	
			Mobile.SetReaction( Factions.EvilBeast, Factions.ThoriumBrotherhood, 0.5f );
			Mobile.SetReaction( Factions.ThoriumBrotherhood, Factions.EvilBeast, 0.5f );
			
			Mobile.SetReaction( Factions.BootyBay, Factions.Darnasus, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.Ogrimmar, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.ThunderBluff, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.DarkspearTrolls, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.Undercity, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.Stormwind, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.GnomereganExiles, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.IronForge, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.Horde, 0.5f );
			Mobile.SetReaction( Factions.BootyBay, Factions.Alliance, 0.5f );
			#region General player reactions
			for(int t = 1;t < 12;t++ )
			{				
				Mobile.SetReaction( Factions.BootyBay, (Factions)t, 0.5f );
				Mobile.SetReaction( Factions.ThoriumBrotherhood, (Factions)t, 0.1f );				
			}
			#endregion
			#region Horde
			Mobile.SetReaction( Factions.Player_Orc, Factions.Horde, 0.5f );
			Mobile.SetReaction( Factions.Player_Orc, Factions.Ratchet, 0.5f );			
			Mobile.SetReaction( Factions.Player_Orc, Factions.Ogrimmar, 0.6f );
			Mobile.SetReaction( Factions.Player_Orc, Factions.DarkspearTrolls, 0.5f );
			Mobile.SetReaction( Factions.Player_Orc, Factions.ThunderBluff, 0.5f );
			Mobile.SetReaction( Factions.Player_Orc, Factions.Undercity, 0.5f );		
	
			Mobile.SetReaction( Factions.Player_Undead, Factions.Horde, 0.5f );
			Mobile.SetReaction( Factions.Player_Undead, Factions.Ratchet, 0.5f );	
			Mobile.SetReaction( Factions.Player_Undead, Factions.Ogrimmar, 0.5f );
			Mobile.SetReaction( Factions.Player_Undead, Factions.DarkspearTrolls, 0.5f );
			Mobile.SetReaction( Factions.Player_Undead, Factions.ThunderBluff, 0.5f );
			Mobile.SetReaction( Factions.Player_Undead, Factions.Undercity, 0.51f );	

			Mobile.SetReaction( Factions.Player_Tauren, Factions.Horde, 0.5f );
			Mobile.SetReaction( Factions.Player_Tauren, Factions.Ratchet, 0.5f );
			Mobile.SetReaction( Factions.Player_Tauren, Factions.Ogrimmar, 0.5f );
			Mobile.SetReaction( Factions.Player_Tauren, Factions.DarkspearTrolls, 0.5f );
			Mobile.SetReaction( Factions.Player_Tauren, Factions.ThunderBluff, 0.51f );
			Mobile.SetReaction( Factions.Player_Tauren, Factions.Undercity, 0.5f );		
	
			Mobile.SetReaction( Factions.Player_Troll, Factions.Horde, 0.5f );
			Mobile.SetReaction( Factions.Player_Troll, Factions.Ratchet, 0.5f );
			Mobile.SetReaction( Factions.Player_Troll, Factions.Ogrimmar, 0.5f );
			Mobile.SetReaction( Factions.Player_Troll, Factions.DarkspearTrolls, 0.51f );
			Mobile.SetReaction( Factions.Player_Troll, Factions.ThunderBluff, 0.5f );
			Mobile.SetReaction( Factions.Player_Troll, Factions.Undercity, 0.5f );	
			#endregion
			#region Alliance
			Mobile.SetReaction( Factions.Player_Human, Factions.Alliance, 0.51f );
			Mobile.SetReaction( Factions.Player_Human, Factions.IronForge, 0.5f );			
			Mobile.SetReaction( Factions.Player_Human, Factions.GnomereganExiles, 0.5f );
			Mobile.SetReaction( Factions.Player_Human, Factions.Stormwind, 0.51f );
			Mobile.SetReaction( Factions.Player_Human, Factions.Darnasus, 0.5f );

			Mobile.SetReaction( Factions.Player_Dwarf, Factions.Alliance, 0.5f );
			Mobile.SetReaction( Factions.Player_Dwarf, Factions.IronForge, 0.51f );			
			Mobile.SetReaction( Factions.Player_Dwarf, Factions.GnomereganExiles, 0.5f );
			Mobile.SetReaction( Factions.Player_Dwarf, Factions.Stormwind, 0.5f );
			Mobile.SetReaction( Factions.Player_Dwarf, Factions.Darnasus, 0.5f );

			Mobile.SetReaction( Factions.Player_Gnome, Factions.Alliance, 0.5f );
			Mobile.SetReaction( Factions.Player_Gnome, Factions.IronForge, 0.5f );			
			Mobile.SetReaction( Factions.Player_Gnome, Factions.GnomereganExiles, 0.5f );
			Mobile.SetReaction( Factions.Player_Gnome, Factions.Stormwind, 0.51f );
			Mobile.SetReaction( Factions.Player_Gnome, Factions.Darnasus, 0.5f );

			Mobile.SetReaction( Factions.Player_Elf, Factions.Alliance, 0.5f );
			Mobile.SetReaction( Factions.Player_Elf, Factions.IronForge, 0.5f );			
			Mobile.SetReaction( Factions.Player_Elf, Factions.GnomereganExiles, 0.5f );
			Mobile.SetReaction( Factions.Player_Elf, Factions.Stormwind, 0.5f );
			Mobile.SetReaction( Factions.Player_Elf, Factions.Darnasus, 0.51f );
			#endregion
		} 
	}
}
