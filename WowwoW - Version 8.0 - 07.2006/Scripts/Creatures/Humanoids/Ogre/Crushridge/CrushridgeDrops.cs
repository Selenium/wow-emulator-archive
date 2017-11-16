using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server
{
	public class CrushridgeDrops
	{
		public static Loot[] CrushridgePlunderer = new Loot[] {new Loot( typeof( StalvansReaper), 0.0472367f ) 
,new Loot( typeof( SutarnsRing), 0.0472367f ) 
,new Loot( typeof( Aquamarine), 0.188947f ) 
,new Loot( typeof( ArchersBelt), 0.0472367f ) 
,new Loot( typeof( ArchersBuckler), 0.0472367f ) 
,new Loot( typeof( ArchersGloves), 0.0944733f ) 
,new Loot( typeof( ArchersShoulderpads), 0.188947f ) 
,new Loot( typeof( ArchersTrousers), 0.0472367f ) 
,new Loot( typeof( AuroraCloak), 0.0472367f ) 
,new Loot( typeof( AuroraSash), 0.0472367f ) 
,new Loot( typeof( BallastMaul), 0.0472367f ) 
,new Loot( typeof( CarnelianLoop), 0.0472367f ) 
,new Loot( typeof( CeruleanRing), 0.0472367f ) 
,new Loot( typeof( ChiefBrigadierCloak), 0.0944733f ) 
,new Loot( typeof( Citrine), 0.42513f ) 
,new Loot( typeof( ConjurersBreeches), 0.188947f ) 
,new Loot( typeof( ConjurersGloves), 0.0944733f ) 
,new Loot( typeof( ConjurersHood), 0.0944733f ) 
,new Loot( typeof( ConjurersMantle), 0.0944733f ) 
,new Loot( typeof( ConjurersSphere), 0.0472367f ) 
,new Loot( typeof( DeadlyKris), 0.188947f ) 
,new Loot( typeof( EldersAmberStave), 0.0944733f ) 
,new Loot( typeof( GiantClub), 0.188947f ) 
,new Loot( typeof( GloomReaper), 0.14171f ) 
,new Loot( typeof( GlyphedBoots), 0.0472367f ) 
,new Loot( typeof( GlyphedBracers), 0.0472367f ) 
,new Loot( typeof( GlyphedCloak), 0.0472367f ) 
,new Loot( typeof( GlyphedEpaulets), 0.0944733f ) 
,new Loot( typeof( GlyphedHelm), 0.188947f ) 
,new Loot( typeof( HuntsmansBands), 0.0472367f ) 
,new Loot( typeof( HuntsmansBelt), 0.0472367f ) 
,new Loot( typeof( HuntsmansCape), 0.0944733f ) 
,new Loot( typeof( InfiltratorArmor), 0.0472367f ) 
,new Loot( typeof( InsigniaChestguard), 0.188947f ) 
,new Loot( typeof( Jade), 0.14171f ) 
,new Loot( typeof( JazeraintCloak), 0.0472367f ) 
,new Loot( typeof( JetChain), 0.0944733f ) 
,new Loot( typeof( KnightsBoots), 0.0944733f ) 
,new Loot( typeof( KnightsBracers), 0.0472367f ) 
,new Loot( typeof( KnightsGauntlets), 0.14171f ) 
,new Loot( typeof( KnightsHeadguard), 0.0472367f ) 
,new Loot( typeof( KnightsLegguards), 0.0472367f ) 
,new Loot( typeof( KnightlyLongsword), 0.14171f ) 
,new Loot( typeof( MailCombatArmor), 0.0472367f ) 
,new Loot( typeof( MailCombatBoots), 0.0472367f ) 
,new Loot( typeof( MercenaryBlade), 0.14171f ) 
,new Loot( typeof( MindbenderLoop), 0.0472367f ) 
,new Loot( typeof( Murphstar), 0.0472367f ) 
,new Loot( typeof( NightskyArmor), 0.0472367f ) 
,new Loot( typeof( PatternEarthenSilkBelt), 0.0472367f ) 
,new Loot( typeof( PendantOfMyzrael), 0.0472367f ) 
,new Loot( typeof( PlansFrostTigerBlade), 0.0472367f ) 
,new Loot( typeof( RenegadeBelt), 0.0472367f ) 
,new Loot( typeof( RenegadeChestguard), 0.14171f ) 
,new Loot( typeof( RenegadeCirclet), 0.0472367f ) 
,new Loot( typeof( RenegadePauldrons), 0.0472367f ) 
,new Loot( typeof( SavageAxe), 0.0472367f ) 
,new Loot( typeof( ScorchingWand), 0.0944733f ) 
,new Loot( typeof( SentinelBoots), 0.0944733f ) 
,new Loot( typeof( SentinelBracers), 0.0472367f ) 
,new Loot( typeof( SentinelCap), 0.0472367f ) 
,new Loot( typeof( SentinelGirdle), 0.0472367f ) 
,new Loot( typeof( SentinelTrousers), 0.0472367f ) 
,new Loot( typeof( StoneHammer), 0.0944733f ) 
,new Loot( typeof( StonecutterClaymore), 0.0944733f ) 
,new Loot( typeof( StrongIronLockbox), 0.472367f ) 
,new Loot( typeof( ThalliumChoker), 0.0472367f ) 
,new Loot( typeof( TwilightBelt), 0.0472367f ) 
,new Loot( typeof( TwilightCape), 0.236183f ) 
,new Loot( typeof( TwilightGloves), 0.0944733f ) 
,new Loot( typeof( DirtyKnucklebones), 1.22815f ) 
,new Loot( typeof( GreaterHealingPotion), 0.85026f ) 
,new Loot( typeof( IronOre), 0.0472367f ) 
,new Loot( typeof( LargeKnapsack), 0.0472367f ) 
,new Loot( typeof( LesserManaPotion), 0.85026f ) 
,new Loot( typeof( MageweaveCloth), 3.7317f ) 
,new Loot( typeof( MulgoreSpiceBread), 0.0472367f ) 
,new Loot( typeof( RecoveredTome), 0.614077f ) 
,new Loot( typeof( ScrollOfAgilityII), 0.0944733f ) 
,new Loot( typeof( ScrollOfProtectionIII), 0.0944733f ) 
,new Loot( typeof( ScrollOfSpiritIII), 0.14171f ) 
,new Loot( typeof( ScrollOfStrengthII), 0.0944733f ) 
,new Loot( typeof( SilkCloth), 26.8777f ) 
,new Loot( typeof( SweetNectar), 2.78696f ) 
,new Loot( typeof( WildHogShank), 4.81814f ) 
,new Loot( typeof( BroadClaymore), 0.0944733f ) 
,new Loot( typeof( DoubleMailBelt), 0.14171f ) 
,new Loot( typeof( DoubleMailBoots), 0.0472367f ) 
,new Loot( typeof( DoubleMailBracers), 0.0472367f ) 
,new Loot( typeof( DoubleMailCoif), 0.14171f ) 
,new Loot( typeof( DoubleMailGloves), 0.0472367f ) 
,new Loot( typeof( DoubleMailPants), 0.14171f ) 
,new Loot( typeof( DoubleMailShoulderpads), 0.188947f ) 
,new Loot( typeof( DoubleMailVest), 0.188947f ) 
,new Loot( typeof( DoubleStitchedCloak), 0.0944733f ) 
,new Loot( typeof( HardenedCloak), 0.0472367f ) 
,new Loot( typeof( HardenedLeatherBelt), 0.14171f ) 
,new Loot( typeof( HardenedLeatherBoots), 0.0944733f ) 
,new Loot( typeof( HardenedLeatherBracers), 0.0472367f ) 
,new Loot( typeof( HardenedLeatherGloves), 0.188947f ) 
,new Loot( typeof( HardenedLeatherHelm), 0.28342f ) 
,new Loot( typeof( HardenedLeatherPants), 0.14171f ) 
,new Loot( typeof( HardenedLeatherShoulderpads), 0.188947f ) 
,new Loot( typeof( HardenedLeatherTunic), 0.188947f ) 
,new Loot( typeof( HeftyWarAxe), 0.42513f ) 
,new Loot( typeof( InterlacedBelt), 0.188947f ) 
,new Loot( typeof( InterlacedBoots), 0.0472367f ) 
,new Loot( typeof( InterlacedBracers), 0.377893f ) 
,new Loot( typeof( InterlacedCloak), 0.14171f ) 
,new Loot( typeof( InterlacedCowl), 0.28342f ) 
,new Loot( typeof( InterlacedGloves), 0.0944733f ) 
,new Loot( typeof( InterlacedPants), 0.188947f ) 
,new Loot( typeof( InterlacedShoulderpads), 0.188947f ) 
,new Loot( typeof( InterlacedVest), 0.330657f ) 
,new Loot( typeof( KeenAxe), 0.28342f ) 
,new Loot( typeof( LargeWarClub), 0.0944733f ) 
,new Loot( typeof( LightScimitar), 0.28342f ) 
,new Loot( typeof( LongBarreledMusket), 0.519603f ) 
,new Loot( typeof( MetalStave), 0.236183f ) 
,new Loot( typeof( ReflectiveHeater), 0.377893f ) 
,new Loot( typeof( ReinforcedBuckler), 0.188947f ) 
,new Loot( typeof( ShinyDirk), 0.519603f ) 
,new Loot( typeof( StoneClub), 0.236183f ) 
,new Loot( typeof( TautCompoundBow), 0.28342f ) 
};
		
	
	}
}