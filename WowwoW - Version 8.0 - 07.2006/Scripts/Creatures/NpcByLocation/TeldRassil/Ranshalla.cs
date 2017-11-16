using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class Ranshalla : BaseNPC
	{
		public Ranshalla() : base()
		{
			Name = "Ranshalla";
			Id = 10300;
			Model = 9775;
			Level = RandomLevel(58);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080006;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1.0f;
			Speed = 3.36f;
			WalkSpeed = 3.36f;
			RunSpeed = 6.36f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = 0; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 24503, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 3573, 58 );
			/*****************************/
		}
	}
}
