using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class SethirtheAncient : BaseCreature
	{
		public SethirtheAncient() : base()
		{
			Name = "Sethir the Ancient";
			Id = 6909;
			Model = 11339;
			Level = RandomLevel(12);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 1*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.062f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level*2.5f);
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			//Equip( new Item( 24930, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) 
			,new BaseTreasure( SethirtheAncientDreamEaterDrops.SethirtheAncient , 100f ) }; 
			/*****************************/
			BCAddon.Hp( this, 152, 12 );
			/*****************************/
		}
	}
}
namespace Server.Items
{
public class SethirtheAncientDreamEaterDrops
	{
		public static Loot[] SethirtheAncient = new Loot[] {new Loot( typeof( AncestralOrb), 0.0684463f ) 
,new Loot( typeof( AncestralWoollies), 0.0684463f ) 
,new Loot( typeof( BattleChainPants), 0.136893f ) 
,new Loot( typeof( BattleChainTunic), 0.136893f ) 
,new Loot( typeof( BeadedBritches), 0.136893f ) 
,new Loot( typeof( BeadedRobe), 0.273785f ) 
,new Loot( typeof( BrackwaterShield), 0.0684463f ) 
,new Loot( typeof( ChargersArmor), 0.0684463f ) 
,new Loot( typeof( CompactShotgun), 0.136893f ) 
,new Loot( typeof( CurvedDagger), 0.136893f ) 
,new Loot( typeof( FireWand), 0.273785f ) 
,new Loot( typeof( FormulaEnchantBracerMinorStrength), 0.0684463f ) 
,new Loot( typeof( HuntingBow), 0.136893f ) 
,new Loot( typeof( NativePants), 0.0684463f ) 
,new Loot( typeof( PlansGemmedCopperGauntlets), 0.0684463f ) 
,new Loot( typeof( PrimalWraps), 0.205339f ) 
,new Loot( typeof( ScalpingTomahawk), 0.0684463f ) 
,new Loot( typeof( SchematicMechanicalSquirrel), 0.0684463f ) 
,new Loot( typeof( ShadowWand), 0.0684463f ) 
,new Loot( typeof( Shadowgem), 0.0684463f ) 
,new Loot( typeof( ShortBastardSword), 0.0684463f ) 
,new Loot( typeof( SpikedClub), 0.136893f ) 
,new Loot( typeof( SturdyQuarterstaff), 0.205339f ) 
,new Loot( typeof( Tigerseye), 0.273785f ) 
,new Loot( typeof( TribalPants), 0.0684463f ) 
,new Loot( typeof( WarTornPants), 0.273785f ) 
,new Loot( typeof( WarTornShield), 0.0684463f ) 
,new Loot( typeof( WarTornTunic), 0.0684463f ) 
,new Loot( typeof( AboriginalBands), 0.273785f ) 
,new Loot( typeof( AncestralBoots), 0.0684463f ) 
,new Loot( typeof( AncestralGloves), 0.205339f ) 
,new Loot( typeof( BarbaricClothBracers), 0.0684463f ) 
,new Loot( typeof( BarbaricClothCloak), 0.273785f ) 
,new Loot( typeof( BattleChainBoots), 0.0684463f ) 
,new Loot( typeof( BattleChainGloves), 0.0684463f ) 
,new Loot( typeof( BrackwaterBracers), 0.205339f ) 
,new Loot( typeof( CeremonialLeatherBracers), 0.0684463f ) 
,new Loot( typeof( GrizzlyBelt), 0.136893f ) 
,new Loot( typeof( GrizzlyBracers), 0.205339f ) 
,new Loot( typeof( GrizzlySlippers), 0.136893f ) 
,new Loot( typeof( HaunchOfMeat), 6.22861f ) 
,new Loot( typeof( IceColdMilk), 3.62765f ) 
,new Loot( typeof( LesserHealingPotion), 1.71116f ) 
,new Loot( typeof( LinenCloth), 34.4969f ) 
,new Loot( typeof( MinorManaPotion), 0.54757f ) 
,new Loot( typeof( NativeBands), 0.205339f ) 
,new Loot( typeof( NativeHandwraps), 0.136893f ) 
,new Loot( typeof( NativeSash), 0.0684463f ) 
,new Loot( typeof( ScrollOfIntellect), 0.479124f ) 
,new Loot( typeof( ScrollOfProtection), 0.616016f ) 
,new Loot( typeof( ScrollOfSpirit), 0.479124f ) 
,new Loot( typeof( ScrollOfStamina), 0.273785f ) 
,new Loot( typeof( TribalBoots), 0.136893f ) 
,new Loot( typeof( WarTornGirdle), 0.136893f ) 
,new Loot( typeof( WarTornGreaves), 0.0684463f ) 
,new Loot( typeof( CalicoBelt), 0.479124f ) 
,new Loot( typeof( CalicoBracers), 0.205339f ) 
,new Loot( typeof( CalicoCloak), 0.479124f ) 
,new Loot( typeof( CalicoGloves), 0.205339f ) 
,new Loot( typeof( CalicoPants), 0.205339f ) 
,new Loot( typeof( CalicoShoes), 0.410678f ) 
,new Loot( typeof( CalicoTunic), 0.273785f ) 
,new Loot( typeof( CheapBlunderbuss), 0.273785f ) 
,new Loot( typeof( CommonersSword), 0.273785f ) 
,new Loot( typeof( CrudeBattleAxe), 0.205339f ) 
,new Loot( typeof( FeebleShortbow), 0.479124f ) 
,new Loot( typeof( FishermanKnife), 0.410678f ) 
,new Loot( typeof( HeavyHammer), 0.479124f ) 
,new Loot( typeof( OldGreatsword), 0.54757f ) 
,new Loot( typeof( RoughWoodenStaff), 0.273785f ) 
,new Loot( typeof( RustyWarhammer), 0.616016f ) 
,new Loot( typeof( WarpedCloak), 0.342231f ) 
,new Loot( typeof( WarpedLeatherBelt), 0.342231f ) 
,new Loot( typeof( WarpedLeatherBoots), 0.342231f ) 
,new Loot( typeof( WarpedLeatherBracers), 0.205339f ) 
,new Loot( typeof( WarpedLeatherGloves), 0.136893f ) 
,new Loot( typeof( WarpedLeatherPants), 0.205339f ) 
,new Loot( typeof( WarpedLeatherVest), 0.342231f ) 
,new Loot( typeof( WoodenBuckler), 0.136893f ) 
,new Loot( typeof( WoodenShield), 0.273785f ) 
,new Loot( typeof( WornCloak), 0.136893f ) 
,new Loot( typeof( WornHatchet), 0.205339f ) 
,new Loot( typeof( WornMailBelt), 0.136893f ) 
,new Loot( typeof( WornMailBoots), 0.136893f ) 
,new Loot( typeof( WornMailBracers), 0.136893f ) 
,new Loot( typeof( WornMailGloves), 0.410678f ) 
,new Loot( typeof( WornMailPants), 0.273785f ) 
,new Loot( typeof( WornMailVest), 0.205339f ) 
};
}}