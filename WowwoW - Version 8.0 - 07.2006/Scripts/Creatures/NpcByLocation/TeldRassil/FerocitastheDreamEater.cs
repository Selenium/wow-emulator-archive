using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class FerocitastheDreamEater : BaseCreature
	{
		public FerocitastheDreamEater() : base()
		{
			Name = "Ferocitas the Dream Eater";
			Id = 7234;
			Model = 1996;
			Level = RandomLevel(8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1600;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana = 0;
			BoundingRadius = 1.3f;
			CombatReach = 1.6f;
			Size = 1.3f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			//Equip( new Item( 24930, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) 
			,new BaseTreasure( FerocitastheDreamEaterDrops.FerocitastheDreamEater , 100f ) }; 
			/*****************************/
			BCAddon.Hp( this, 177, 8 );
			/*****************************/
		}
	}
}

namespace Server.Items
{
public class FerocitastheDreamEaterDrops
	{
		public static Loot[] FerocitastheDreamEater = new Loot[] {new Loot( typeof( Malachite), 0.562914f ) 
,new Loot( typeof( NotchedShortsword), 0.0993377f ) 
,new Loot( typeof( PatternFineLeatherGloves), 0.0331126f ) 
,new Loot( typeof( PatternRedLinenVest), 0.0331126f ) 
,new Loot( typeof( PatternWhiteLeatherJerkin), 0.0496689f ) 
,new Loot( typeof( PlansCopperChainVest), 0.0827815f ) 
,new Loot( typeof( ScalpingTomahawk), 0.0993377f ) 
,new Loot( typeof( SeveringAxe), 0.0331126f ) 
,new Loot( typeof( Tigerseye), 0.165563f ) 
,new Loot( typeof( TrainingSword), 0.0662252f ) 
,new Loot( typeof( Beatstick), 0.182119f ) 
,new Loot( typeof( BillyClub), 0.0993377f ) 
,new Loot( typeof( FlangedMace), 0.0993377f ) 
,new Loot( typeof( GnarlpineNecklace), 75f ) 
,new Loot( typeof( HuntingRifle), 0.0331126f ) 
,new Loot( typeof( LinenCloth), 27.0364f ) 
,new Loot( typeof( LongBoStaff), 0.165563f ) 
,new Loot( typeof( LumberjackAxe), 0.0331126f ) 
,new Loot( typeof( MinorHealingPotion), 2.03642f ) 
,new Loot( typeof( Peacebloom), 0.0331126f ) 
,new Loot( typeof( PelletRifle), 0.115894f ) 
,new Loot( typeof( PracticeSword), 0.0331126f ) 
,new Loot( typeof( RefreshingSpringWater), 4.05629f ) 
,new Loot( typeof( ScrollOfProtection), 0.380795f ) 
,new Loot( typeof( ScrollOfSpirit), 0.993377f ) 
,new Loot( typeof( ShinyRedApple), 6.78808f ) 
,new Loot( typeof( SmallBlackPouch), 0.0331126f ) 
,new Loot( typeof( SmallBluePouch), 0.198675f ) 
,new Loot( typeof( SmallGreenPouch), 0.0662252f ) 
,new Loot( typeof( TallonkaisJewel), 1.20861f ) 
,new Loot( typeof( WoodChopper), 0.215232f ) 
,new Loot( typeof( BeatenBattleAxe), 0.496689f ) 
,new Loot( typeof( CarpentersMallet), 0.380795f ) 
,new Loot( typeof( CrackedBuckler), 0.198675f ) 
,new Loot( typeof( CrackedShortbow), 0.430464f ) 
,new Loot( typeof( CrackedSledge), 0.529801f ) 
,new Loot( typeof( CrudeBastardSword), 0.645695f ) 
,new Loot( typeof( FeebleSword), 0.529801f ) 
,new Loot( typeof( LooseChainBelt), 0.480132f ) 
,new Loot( typeof( LooseChainBoots), 0.182119f ) 
,new Loot( typeof( LooseChainBracers), 0.264901f ) 
,new Loot( typeof( LooseChainCloak), 0.231788f ) 
,new Loot( typeof( LooseChainGloves), 0.281457f ) 
,new Loot( typeof( LooseChainPants), 0.397351f ) 
,new Loot( typeof( LooseChainVest), 0.298013f ) 
,new Loot( typeof( PatchworkArmor), 0.298013f ) 
,new Loot( typeof( PatchworkBelt), 0.264901f ) 
,new Loot( typeof( PatchworkBracers), 0.413907f ) 
,new Loot( typeof( PatchworkCloak), 0.546358f ) 
,new Loot( typeof( PatchworkGloves), 0.397351f ) 
,new Loot( typeof( PatchworkPants), 0.480132f ) 
,new Loot( typeof( PatchworkShoes), 0.231788f ) 
,new Loot( typeof( RustCoveredBlunderbuss), 0.496689f ) 
,new Loot( typeof( RustyHatchet), 0.513245f ) 
,new Loot( typeof( SharpenedLetterOpener), 0.645695f ) 
,new Loot( typeof( WitheredStaff), 0.480132f ) 
,new Loot( typeof( WornHideCloak), 0.364238f ) 
,new Loot( typeof( WornLargeShield), 0.331126f ) 
,new Loot( typeof( WornLeatherBelt), 0.298013f ) 
,new Loot( typeof( WornLeatherBoots), 0.31457f ) 
,new Loot( typeof( WornLeatherBracers), 0.57947f ) 
,new Loot( typeof( WornLeatherGloves), 0.347682f ) 
,new Loot( typeof( WornLeatherPants), 0.496689f ) 
,new Loot( typeof( WornLeatherVest), 0.380795f ) 
};
}
}