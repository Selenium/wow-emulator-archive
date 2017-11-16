using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class LordMelenas : BaseCreature
	{
		public LordMelenas() : base()
		{
			Name = "Lord Melenas";
			Id = 2038;
			Model = 1013;
			Level = RandomLevel(8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.0f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Demon;
			NpcFlags = 0; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			//Equip( new Item( 24930, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) 
			,new BaseTreasure( LordMelenasDrops.LordMelenas , 100f ) }; 
			/*****************************/
			BCAddon.Hp( this, 120, 8 );
			/*****************************/
		}
	}
}

namespace Server.Items
{
public class LordMelenasDrops
	{
		public static Loot[] LordMelenas = new Loot[] {new Loot( typeof( CarvingKnife), 0.0708717f ) 
,new Loot( typeof( HuntingBow), 0.0708717f ) 
,new Loot( typeof( Malachite), 0.566974f ) 
,new Loot( typeof( NotchedShortsword), 0.0236239f ) 
,new Loot( typeof( PatternRedLinenRobe), 0.165367f ) 
,new Loot( typeof( PatternWhiteLeatherJerkin), 0.0236239f ) 
,new Loot( typeof( PlansCopperChainVest), 0.259863f ) 
,new Loot( typeof( PlansGemmedCopperGauntlets), 0.0236239f ) 
,new Loot( typeof( ScalpingTomahawk), 0.0236239f ) 
,new Loot( typeof( SchematicMechanicalSquirrel), 0.0236239f ) 
,new Loot( typeof( SeveringAxe), 0.141743f ) 
,new Loot( typeof( Tigerseye), 0.259863f ) 
,new Loot( typeof( Beatstick), 0.188991f ) 
,new Loot( typeof( BillyClub), 0.0236239f ) 
,new Loot( typeof( DarnassianBleu), 0.0472478f ) 
,new Loot( typeof( FlangedMace), 0.0472478f ) 
,new Loot( typeof( ForestMushroomCap), 0.0236239f ) 
,new Loot( typeof( HuntingRifle), 0.0472478f ) 
,new Loot( typeof( JourneymansCloak), 0.0236239f ) 
,new Loot( typeof( LinenCloth), 24.0728f ) 
,new Loot( typeof( LongBoStaff), 0.11812f ) 
,new Loot( typeof( MelenasHead), 90.3378f ) 
,new Loot( typeof( MinorHealingPotion), 1.88991f ) 
,new Loot( typeof( PelletRifle), 0.11812f ) 
,new Loot( typeof( PracticeSword), 0.165367f ) 
,new Loot( typeof( RefreshingSpringWater), 3.11836f ) 
,new Loot( typeof( ScrollOfProtection), 0.590598f ) 
,new Loot( typeof( ScrollOfSpirit), 0.779589f ) 
,new Loot( typeof( ShinyRedApple), 0.0236239f ) 
,new Loot( typeof( SmallBlackPouch), 0.0472478f ) 
,new Loot( typeof( SmallBluePouch), 0.0708717f ) 
,new Loot( typeof( SmallBrownPouch), 0.141743f ) 
,new Loot( typeof( SmallGreenPouch), 0.0472478f ) 
,new Loot( typeof( SmallRedPouch), 0.0472478f ) 
,new Loot( typeof( ToughJerky), 6.26034f ) 
,new Loot( typeof( WoodChopper), 0.236239f ) 
,new Loot( typeof( BeatenBattleAxe), 0.377983f ) 
,new Loot( typeof( CarpentersMallet), 0.448854f ) 
,new Loot( typeof( CrackedBuckler), 0.401606f ) 
,new Loot( typeof( CrackedShortbow), 0.448854f ) 
,new Loot( typeof( CrackedSledge), 0.401606f ) 
,new Loot( typeof( CrudeBastardSword), 0.519726f ) 
,new Loot( typeof( FeebleSword), 0.401606f ) 
,new Loot( typeof( LooseChainBelt), 0.354359f ) 
,new Loot( typeof( LooseChainBoots), 0.259863f ) 
,new Loot( typeof( LooseChainBracers), 0.259863f ) 
,new Loot( typeof( LooseChainCloak), 0.307111f ) 
,new Loot( typeof( LooseChainGloves), 0.330735f ) 
,new Loot( typeof( LooseChainPants), 0.307111f ) 
,new Loot( typeof( LooseChainVest), 0.283487f ) 
,new Loot( typeof( PatchworkArmor), 0.42523f ) 
,new Loot( typeof( PatchworkBelt), 0.330735f ) 
,new Loot( typeof( PatchworkBracers), 0.519726f ) 
,new Loot( typeof( PatchworkCloak), 0.330735f ) 
,new Loot( typeof( PatchworkGloves), 0.259863f ) 
,new Loot( typeof( PatchworkPants), 0.283487f ) 
,new Loot( typeof( PatchworkShoes), 0.401606f ) 
,new Loot( typeof( RustCoveredBlunderbuss), 0.496102f ) 
,new Loot( typeof( RustyHatchet), 0.732341f ) 
,new Loot( typeof( SharpenedLetterOpener), 0.472478f ) 
,new Loot( typeof( WitheredStaff), 0.472478f ) 
,new Loot( typeof( WornHideCloak), 0.330735f ) 
,new Loot( typeof( WornLargeShield), 0.188991f ) 
,new Loot( typeof( WornLeatherBelt), 0.259863f ) 
,new Loot( typeof( WornLeatherBoots), 0.42523f ) 
,new Loot( typeof( WornLeatherBracers), 0.330735f ) 
,new Loot( typeof( WornLeatherGloves), 0.42523f ) 
,new Loot( typeof( WornLeatherPants), 0.377983f ) 
,new Loot( typeof( WornLeatherVest), 0.330735f ) 
};
}}