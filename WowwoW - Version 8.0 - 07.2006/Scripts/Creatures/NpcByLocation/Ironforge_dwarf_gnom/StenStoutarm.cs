using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class StenStoutarm : BaseCreature
	{
		public StenStoutarm() : base()
		{
			Name = "Sten Stoutarm";
			Id = 658;
			Model = 1362;
			Level = RandomLevel(2);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 150;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400066;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			NpcText00 = "ah, well aren't you a sturdy-looking one ? Perhaps you can assist me with a thing or two . Not much help around here except for green apprentices, and they've other things to worry about .";
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog; 
			//Equip( new Item( 7493, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 150, 5 );
			/*****************************/
		}
	}
}


