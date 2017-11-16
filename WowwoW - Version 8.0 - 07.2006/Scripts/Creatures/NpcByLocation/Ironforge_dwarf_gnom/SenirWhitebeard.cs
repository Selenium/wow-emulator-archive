using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class SenirWhitebeard : BaseCreature
	{
		public SenirWhitebeard() : base()
		{
			Name = "Senir Whitebeard";
			Id = 1252;
			Model = 1376;
			Level = RandomLevel(9);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Armor = 150;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
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
			Equip( new Item( 24595, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 160, 9 );
			/*****************************/
		}
	}
}

