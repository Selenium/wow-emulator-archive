using System;
using Server.Items;
using System.Collections;
using Server;


////////////////////// Scarlet.cs
namespace Server.Creatures
{
	public class AnduinWrynn: BaseCreature
	{
		public AnduinWrynn() : base()
		{
			Name = "Anduin Wrynn";
			Id = 1747;
			Model = 11655;
			Level = RandomLevel(5,5);
			SetDamage(1f+1.8f*Level,1f+2.66*Level);			
			AttackSpeed = 2000;
			Armor = 0;
			Block = 0;
			Flags1=0x080066;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = 0;
			 BaseHitPoints = 150;
 			BaseMana = 0;
			BoundingRadius = 1.077550f;
			CombatReach = 0.400f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Alliance; 
			Guild = "King of Stormwind";
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item( 23174, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ) );		
			NpcType = 7;
			Unk3=1;
		}
	}
}

