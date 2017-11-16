using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class CurgleCranklehop : BaseCreature
	{
		public CurgleCranklehop() : base()
		{
			Name = "Curgle Cranklehop";
			Id = 7763;
			Model = 6881;
			Level = RandomLevel(48);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480006;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1.15f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Alliance;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog ; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 685, 48 );
			/*****************************/
		}
	}
}

