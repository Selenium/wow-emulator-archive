using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class TalinKeeneye : BaseCreature
	{
		public TalinKeeneye() : base()
		{
			Name = "Talin Keeneye";
			Id = 714;
			Model = 1363;
			Level = RandomLevel(5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Armor = 150;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08080066;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog; 
			NpcText00= "Greetings, $C! Fine day for hunting, wouldn't you say? I've been having more than a little luck with boars, myself. Perhaps you'd like a shot?";
			Equip( new Item( 7481, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 60, 5 );
			/*****************************/
		}
	}
}
