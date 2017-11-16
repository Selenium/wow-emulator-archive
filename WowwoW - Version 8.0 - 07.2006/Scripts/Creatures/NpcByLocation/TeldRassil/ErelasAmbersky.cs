using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class ErelasAmbersky : BaseNPC
	{
		public ErelasAmbersky() : base()
		{
			Name = "Erelas Ambersky";
			Id = 7916;
			Model = 7026;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog ; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			//Equip( new Item( 24930, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 385, 30 );
			/*****************************/
		}
	}
}

