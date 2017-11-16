using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class TallonkaiSwiftroot : BaseNPC
	{
		public TallonkaiSwiftroot() : base()
		{
			Name = "Tallonkai Swiftroot";
			Id = 3567;
			Model = 2686;
			Level = RandomLevel(11);
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
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 69f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new TravellerSalesmanAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog ;
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 22394, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )};
			/*****************************/
			BCAddon.Hp( this, 253, 11 );
			/*****************************/
		}
	}
}
