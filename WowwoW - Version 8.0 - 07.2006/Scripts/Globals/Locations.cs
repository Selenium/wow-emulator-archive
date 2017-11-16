using System;

namespace Server
{
	public class Locations : IInitialize
	{
		public static void Initialize()
		{
			//Azeroth 

			//Alterac Mountains: 
			World.Locations[ "LordamereInternmentCamp" ] = new Position( -74.6376f, 201.212f, 53.2755f, 0 ); 
			World.Locations[ "DalaranInsidetheDome" ] = new Position( 258f, 351f, 41.9076f, 0 ); 
			World.Locations[ "DalaranRuins" ] = new Position( 386.938f, 212.299f, 43.6994f, 0 ); 
			World.Locations[ "TheUplands" ] = new Position( 1239.12f, -286.705f, 42.4764f, 0 ); 
			World.Locations[ "Strahnbrad" ] = new Position( 679.813f, -965.173f, 164.598f, 0 ); 
			World.Locations[ "RuinsofAlterac" ] = new Position( 522.608f, -275.392f, 150.689f, 0 ); 

			//Arathi Highlands: 
			World.Locations[ "FaldirsCove" ] = new Position( -2086.88f, -2074.57f, 5.72927f, 0 ); 
			World.Locations[ "BoulderfistHall" ] = new Position( -1969.08f, -2789.04f, 81.2105f, 0 ); 
			World.Locations[ "GoShekFarm" ] = new Position( -1505.51f, -3030.52f, 12.627f, 0 ); 
			World.Locations[ "WitherbarkVillage" ] = new Position( -1763.41f, -3371.67f, 40.609f, 0 ); 
			World.Locations[ "Hammerfall" ] = new Position( -950.584f, -3533.13f, 71.8318f, 0 ); 
			World.Locations[ "DabyriesFarmstead" ] = new Position( -1065.89f, -2905.56f, 42.0958f, 0 ); 
			World.Locations[ "RefugePointe" ] = new Position( -1262.79f, -2521.75f, 20.8021f, 0 ); 
			World.Locations[ "NorthfoldManor" ] = new Position( -797.235f, -2068.95f, 33.8337f, 0 ); 
			World.Locations[ "CircleofWestBinding" ] = new Position( -863.118f, -1784.72f, 39.6118f, 0 ); 
			World.Locations[ "ThoradinsWall" ] = new Position( -839.599f, -1590.32f, 54.1962f, 0 ); 
			World.Locations[ "StormgardeKeep" ] = new Position( -1661.42f, -1804.2f, 83.0723f, 0 ); 
			World.Locations[ "CircleofInnerBinding" ] = new Position( -1529.75f, -2166.7f, 17.3717f, 0 ); 
			World.Locations[ "CircleofOuterBinding" ] = new Position( -1354.4f, -2738.07f, 58.9657f, 0 ); 
			World.Locations[ "CircleofEastBinding" ] = new Position( -842.604f, -3270.04f, 78.3588f, 0 ); 

			//Badlands: 
			World.Locations[ "ExcavatinSite" ] = new Position( -6092.32f, -3214.55f, 262.727f, 0 ); 
			World.Locations[ "HamertoesDigsite" ] = new Position( -6411.58f, -3409.85f, 241.537f, 0 ); 
			World.Locations[ "CampCosh" ] = new Position( -6247.73f, -3776.6f, 249.06f, 0 ); 
			World.Locations[ "LethlorRavine" ] = new Position( -6935.86f, -4092.06f, 285.906f, 0 ); 
			World.Locations[ "CampBoff" ] = new Position( -7033.94f, -3669.89f, 245.91f, 0 ); 
			World.Locations[ "AgmondsEnd" ] = new Position( -7027.81f, -3330.11f, 241.51f, 0 ); 
			World.Locations[ "CampCagg" ] = new Position( -7147.67f, -2430.87f, 240.51f, 0 ); 
			World.Locations[ "ApocryphansRest" ] = new Position( -6894.29f, -2465.82f, 247.978f, 0 ); 
			World.Locations[ "KargathOrcOutpost" ] = new Position( -6675.96f, -2188.29f, 246.152f, 0 ); 
			World.Locations[ "UnknownDwarfFortress" ] = new Position( -6380.77f, -3139.89f, 301.111f, 0 ); 
			World.Locations[ "TwoGiantSittingDwarfs" ] = new Position( -5829.66f, -2585.59f, 311.971f, 0 ); 

			//Blasted Lands: 
			World.Locations[ "OrcOutpost" ] = new Position( -10859f, -2663.38f, 7.80049f, 0 ); 
			World.Locations[ "AltarofStorms" ] = new Position( -11272.8f, -2547.59f, 102.02f, 0 ); 
			World.Locations[ "DarkPortal" ] = new Position( -11853.6f, -3197.44f, -27.2186f, 0 ); 
			World.Locations[ "AzureloadHumanTown" ] = new Position( -11033f, -3095.22f, 89.8189f, 0 ); 

			//Burning Steppes: 
			World.Locations[ "DreadmaulRock" ] = new Position( -7924.68f, -2624.44f, 220.958f, 0 ); 
			World.Locations[ "GiantOrcStatue" ] = new Position( -8066.68f, -1621.66f, 132.982f, 0 ); 
			World.Locations[ "AltarofStorms" ] = new Position( -7613.13f, -761.492f, 190.807f, 0 ); 
			World.Locations[ "TopofBlackrockMountain" ] = new Position( -7468f, -1082f, 896f, 0 ); 

			//Darrowmere Lake: 
			World.Locations[ "DarrowmereLake" ] = new Position( 1234.83f, -2118.49f, 50.8011f, 0 ); 
			World.Locations[ "CaerDarrowTheDarkPortal" ] = new Position( 1125.31f, -2541.35f, 78.3562f, 0 ); 

			//Dun Morogh: 
			World.Locations[ "DwarfOutpost" ] = new Position( -5475.44f, -2425.32f, 413.455f, 0 ); 
			World.Locations[ "DwarfOutpost" ] = new Position( -5231.95f, -2366.98f, 398.807f, 0 ); 
			World.Locations[ "HelmsBedLake" ] = new Position( -5607.39f, -1984.16f, 396.373f, 0 ); 
			World.Locations[ "GolBolarQuarry" ] = new Position( -5826.35f, -1586.57f, 364.269f, 0 ); 
			World.Locations[ "Kharanos" ] = new Position( -5582.32f, -463.982f, 402f, 0 ); 
			World.Locations[ "SteelgrillsDepot" ] = new Position( -5470.37f, -662.312f, 392.674f, 0 ); 
			World.Locations[ "MistyPineRefuge" ] = new Position( -5353.18f, -1043.02f, 394.772f, 0 ); 
			World.Locations[ "CityofIronforge" ] = new Position( -4981.25f, -881.542f, 501.66f, 0 ); 
			World.Locations[ "ColdridgeValley" ] = new Position( -6325.7f, 294.835f, 379.791f, 0 ); 
			World.Locations[ "Anvilmar" ] = new Position( -6110.8f, 388.517f, 395.542f, 0 ); 
			World.Locations[ "BrewnallVillage" ] = new Position( -5368.81f, 319.498f, 394.123f, 0 ); 
			World.Locations[ "IceflowLake" ] = new Position( -5259.74f, 107.593f, 392.567f, 0 ); 
			World.Locations[ "Gnomeregan" ] = new Position( -5179.58f, 660.421f, 388.391f, 0 ); 

			//Duskwood: 
			World.Locations[ "BrightwoodGrove" ] = new Position( -10649.7f, -884.01f, 50.8196f, 0 ); 
			World.Locations[ "TwilightGrove" ] = new Position( -10385f, -424.696f, 63.534f, 0 ); 
			World.Locations[ "YorgenFarmstead" ] = new Position( -11105.4f, -500.791f, 32.8518f, 0 ); 
			World.Locations[ "TheRottingOrchard" ] = new Position( -11069.3f, -927.315f, 63.502f, 0 ); 
			World.Locations[ "TranquilGardensCemetery" ] = new Position( -10993.3f, -1331.19f, 52.7805f, 0 ); 
			World.Locations[ "DarkShire" ] = new Position( -10567.5f, -1169.86f, 29.0826f, 0 ); 
			World.Locations[ "DeadwindPass" ] = new Position( -10435.4f, -1809.28f, 98.3851f, 0 ); 
			World.Locations[ "RavenHill" ] = new Position( -10750.1f, 323.644f, 38.0417f, 0 ); 
			World.Locations[ "RavenhillCemetery" ] = new Position( -10316.7f, 342.295f, 59.6454f, 0 ); 
			World.Locations[ "AddlesStead" ] = new Position( -10992.6f, 268.794f, 27.5101f, 0 ); 
			World.Locations[ "BeggarsHaunt" ] = new Position( -10359.9f, -1531.75f, 91.5352f, 0 ); 
			World.Locations[ "MedivhsTower" ] = new Position( -11078.9f, -2078.53f, 206.878f, 0 ); 

			//Eastern Plaguelands: 
			World.Locations[ "Ziggaraut" ] = new Position( 2433.31f, -3782.06f, 185.472f, 0 ); 
			World.Locations[ "Village" ] = new Position( 2016.11f, -4486.36f, 73.6226f, 0 ); 
			World.Locations[ "ZiggarautinMushroomField" ] = new Position( 2823.83f, -3727.76f, 124.971f, 0 ); 
			World.Locations[ "SlaughterhouseinMushroomField" ] = new Position( 3097.32f, -3562.77f, 134.093f, 0 ); 
			World.Locations[ "UnknownCity" ] = new Position( 3653.67f, -3609.77f, 137.118f, 0 ); 
			World.Locations[ "CoolTemple" ] = new Position( 3452.83f, -4992.61f, 196.981f, 0 ); 
			World.Locations[ "Slaughterhouse" ] = new Position( 2719.29f, -5479.3f, 159.542f, 0 ); 
			World.Locations[ "TyrsHand" ] = new Position( 1612.63f, -5524.9f, 111.148f, 0 ); 

			//Elwynn Forest: 
			World.Locations[ "StormwindCity" ] = new Position( -8913.23f, 554.633f, 93.7944f, 0 ); 
			World.Locations[ "ValleyofHeroes" ] = new Position( -8951.62f, 524.373f, 96.6275f, 0 ); 
			World.Locations[ "StormwindTradeDistrict" ] = new Position( -8852.03f, 652.878f, 96.46f, 0 ); 
			World.Locations[ "StormwindCanals" ] = new Position( -8675.39f, 635.774f, 96.9275f, 0 ); 
			World.Locations[ "StormwindOldTown" ] = new Position( -8662.9f, 498.212f, 100.833f, 0 ); 
			World.Locations[ "StormwindCathedralSquare" ] = new Position( -8635.62f, 762.727f, 103.667f, 0 ); 
			World.Locations[ "StormwindCathedralofLight" ] = new Position( -8513.49f, 861.197f, 111.039f, 0 ); 
			World.Locations[ "StormwindWizardsSanctum" ] = new Position( -9007.65f, 870.424f, 148.618f, 0 ); 
			World.Locations[ "StormwindMageQuarter" ] = new Position( -8896.36f, 834.148f, 99.5207f, 0 ); 
			World.Locations[ "StormwindBank" ] = new Position( -8937.08f, 640.4f, 100.645f, 0 ); 
			World.Locations[ "NorthshireValley" ] = new Position( -9043.76f, -41.5906f, 88.3589f, 0 ); 
			World.Locations[ "NorthshireVineyards" ] = new Position( -9092.38f, -368.684f, 73.6163f, 0 ); 
			World.Locations[ "Goldshire" ] = new Position( -9443.45f, 59.8944f, 56.0704f, 0 ); 
			World.Locations[ "MirrorLake" ] = new Position( -9355.84f, 537.441f, 52.5171f, 0 ); 
			World.Locations[ "MirrorLakeOrchard" ] = new Position( -9469.08f, 467.583f, 54.0913f, 0 ); 
			World.Locations[ "ForestsEdge" ] = new Position( -9646.46f, 679.589f, 37.4136f, 0 ); 
			World.Locations[ "TheStonefiledFarm" ] = new Position( -9964.72f, 391.509f, 35.6555f, 0 ); 
			World.Locations[ "TheMaclureVineyards" ] = new Position( -9881.4f, 88.8972f, 33.3196f, 0 ); 
			World.Locations[ "CrystalLake" ] = new Position( -9462.99f, -161.312f, 60.7274f, 0 ); 
			World.Locations[ "BrackwellPumpkinPatch" ] = new Position( -9769.82f, -811.712f, 40.9564f, 0 ); 
			World.Locations[ "EastvaleLoggingCamp" ] = new Position( -9549f, -1407.04f, 54.7673f, 0 ); 
			World.Locations[ "HerosVigil" ] = new Position( -9136.28f, -1053.89f, 70.624f, 0 ); 
			World.Locations[ "StoneCairnLake" ] = new Position( -9325.33f, -1038.92f, 65.3535f, 0 ); 

			//Hillsbrad Foothills: 
			World.Locations[ "NethanderStead" ] = new Position( -898.266f, -1044.33f, 30.3478f, 0 ); 
			World.Locations[ "UnknownDwarfFortress" ] = new Position( -1266.15f, -1198.95f, 40.1765f, 0 ); 
			World.Locations[ "DurnholdeKeep" ] = new Position( -489.832f, -1391.35f, 53.3854f, 0 ); 
			World.Locations[ "SouthshoreHumanHarborTown" ] = new Position( -821.604f, -544.654f, 15.0387f, 0 ); 
			World.Locations[ "WesternStrand" ] = new Position( -1019.67f, -359.442f, 5.13463f, 0 ); 
			World.Locations[ "EasternStrand" ] = new Position( -1234.91f, -943.205f, 8.62585f, 0 ); 
			World.Locations[ "HillsbradFieldsHumanTown" ] = new Position( -501.505f, 91.4121f, 59.0582f, 0 ); 
			World.Locations[ "UnknownMine" ] = new Position( -870.601f, 233.102f, 9.93092f, 0 ); 
			World.Locations[ "TarrenMill" ] = new Position( -28.1484f, -899.243f, 56.0704f, 0 ); 

			//Hinterlands: 
			World.Locations[ "SeradeneNightElfPortalandGiantWorldTree" ] = new Position( 724.846f, -3996.11f, 149.735f, 0 ); 
			World.Locations[ "SkulkRock" ] = new Position( 362.039f, -3796.03f, 153.998f, 0 ); 
			World.Locations[ "OverlookCliffs" ] = new Position( -69.8514f, -4536f, 7.28923f, 0 ); 
			World.Locations[ "JinthaAlor" ] = new Position( -678.757f, -4018.61f, 238.351f, 0 ); 
			World.Locations[ "TheAltarofZul" ] = new Position( -295.384f, -3459.12f, 194.005f, 0 ); 
			World.Locations[ "ShadraAlor" ] = new Position( -464.208f, -2837.23f, 110.073f, 0 ); 
			World.Locations[ "QuelDanilNightElfLodge" ] = new Position( 266.941f, -2751.41f, 122.544f, 0 ); 
			World.Locations[ "ZunWatha" ] = new Position( -35.7245f, -2479.51f, 120.423f, 0 ); 
			World.Locations[ "AeriePeak" ] = new Position( 327.814f, -1959.99f, 197.724f, 0 ); 

			//Loch Modan: 
			World.Locations[ "Thelsamar" ] = new Position( -5335.61f, -2982.58f, 332.669f, 0 ); 
			World.Locations[ "TheLochLake" ] = new Position( -5201.86f, -3136.59f, 298.761f, 0 ); 
			World.Locations[ "WreckfromBattle" ] = new Position( -4939.1f, -3423.74f, 305.595f, 0 ); 
			World.Locations[ "MoGroshStronghold" ] = new Position( -4871.78f, -4025.77f, 313.141f, 0 ); 
			World.Locations[ "PurpleNightElfBuilding" ] = new Position( -5675.42f, -4244.87f, 407.002f, 0 ); 
			World.Locations[ "IronbandsExcavationSite" ] = new Position( -5755.53f, -3998.42f, 330.436f, 0 ); 
			World.Locations[ "StonewroughDam" ] = new Position( -4771.99f, -3329.01f, 345.504f, 0 ); 
			World.Locations[ "DunAlgaz" ] = new Position( -4231.86f, -2361.37f, 204.069f, 0 ); 

			//Offshore: 
			World.Locations[ "IslandofDoctorLapidis" ] = new Position( -12380.3f, 3400.92f, 48.865f, 0 ); 
			World.Locations[ "GilijimsIsle" ] = new Position( -13693.5f, 2806.3f, 56.6918f, 0 ); 
			World.Locations[ "TheDrownedReef" ] = new Position( -2200.52f, -1685.18f, -34.4569f, 0 ); 

			//Red Ridge Mountains: 
			World.Locations[ "LakeEverstill" ] = new Position( -9319f, -1937.94f, 58.0698f, 0 ); 
			World.Locations[ "Lakeshire" ] = new Position( -9282.98f, -2269.64f, 69.39f, 0 ); 
			World.Locations[ "AlthersMill" ] = new Position( -9168.66f, -2726.31f, 90.0426f, 0 ); 
			World.Locations[ "Stonewatch" ] = new Position( -9385.46f, -3039.27f, 139.437f, 0 ); 
			World.Locations[ "OrcOutpost" ] = new Position( -8687.39f, -2330.38f, 155.916f, 0 ); 

			//Searing Gorge: 
			World.Locations[ "TheCauldron" ] = new Position( -6892.24f, -1342.38f, 239.913f, 0 ); 
			World.Locations[ "BlackrockMountain" ] = new Position( -7317.34f, -1072.33f, 277.069f, 0 ); 
			World.Locations[ "GrimeslitDigSite" ] = new Position( -6986.92f, -1705.54f, 241.667f, 0 ); 

			//Silverpine Forest: 
			World.Locations[ "Ambermill" ] = new Position( -126.954f, 815.624f, 66.0224f, 0 ); 
			World.Locations[ "PyrewoodVillage" ] = new Position( -416.466f, 1543.87f, 17.5941f, 0 ); 
			World.Locations[ "ShadowfangKeep" ] = new Position( -202.557f, 1666.88f, 79.7641f, 0 ); 
			World.Locations[ "SouthTidesRun" ] = new Position( -577.865f, 1807.08f, 8.2492f, 0 ); 
			World.Locations[ "TheGreymaneWall" ] = new Position( -757.376f, 1527.28f, 17.2465f, 0 ); 
			World.Locations[ "BehindTheGreymaneWallUnfinishedLocation" ] = new Position( -987.449f, 1585.69f, 53.4298f, 0 ); 
			World.Locations[ "Mine" ] = new Position( 374.222f, 1083.9f, 106.509f, 0 ); 
			World.Locations[ "TheSepulcher" ] = new Position( 507.784f, 1611.33f, 124.921f, 0 ); 
			World.Locations[ "OlsensFarthing" ] = new Position( 134.209f, 1496.64f, 114.394f, 0 ); 
			World.Locations[ "TheDecrepitFairy" ] = new Position( 675.698f, 974.873f, 34.8849f, 0 ); 
			World.Locations[ "LordamereLake" ] = new Position( 762.653f, 909.072f, 31.2142f, 0 ); 
			World.Locations[ "FenrisIsle" ] = new Position( 731.866f, 727.793f, 37.0975f, 0 ); 
			World.Locations[ "FenrisIsleFortressRuins" ] = new Position( 960.45f, 689.611f, 59.7365f, 0 ); 
			World.Locations[ "TheDawningIsles" ] = new Position( 982.34f, 201.239f, 34.9509f, 0 ); 
			World.Locations[ "MaldensOrchard" ] = new Position( 1414.28f, 1073.22f, 52.4649f, 0 ); 
			World.Locations[ "TheIvarPatch" ] = new Position( 1285.69f, 1242.33f, 52.6914f, 0 ); 
			World.Locations[ "ValgansField" ] = new Position( 964.877f, 1238.75f, 48.0979f, 0 ); 
			World.Locations[ "TheDeadField" ] = new Position( 1035.91f, 1540.85f, 30.525f, 0 ); 
			World.Locations[ "TheSkitteringDark" ] = new Position( 1293.65f, 1957.71f, 19.5619f, 0 ); 
			World.Locations[ "NorthTidesRun" ] = new Position( 873.391f, 1852.5f, 5.0548f, 0 ); 

			//Strangelthon Vale: 
			World.Locations[ "WildShore" ] = new Position( -14692.4f, 506.162f, 1.78241f, 0 ); 
			World.Locations[ "JagueroIsle(StatueofLiberty)" ] = new Position( -14740.7f, -432.482f, 4.00624f, 0 ); 
			World.Locations[ "BootyBay" ] = new Position( -14406.6f, 419.353f, 22.3907f, 0 ); 
			World.Locations[ "JaneirosPoint" ] = new Position( -14178.2f, 712.03f, 29.1868f, 0 ); 
			World.Locations[ "TheSavageCoast" ] = new Position( -13274.4f, 769.951f, 2.45505f, 0 ); 
			World.Locations[ "RuinsofJubuwal" ] = new Position( -13382.6f, 2.10815f, 21.8683f, 0 ); 
			World.Locations[ "Arena" ] = new Position( -13152.9f, 342.729f, 52.1328f, 0 ); 
			World.Locations[ "GromGolBaseCamp" ] = new Position( -12352.8f, 211.452f, 4.5846f, 0 ); 
			World.Locations[ "BallalRuins" ] = new Position( -11977.4f, 332.254f, 3.20626f, 0 ); 
			World.Locations[ "TheVileReef" ] = new Position( -12258.9f, 621.105f, -68.3247f, 0 ); 
			World.Locations[ "ZuuldaiaRuins" ] = new Position( -11683.1f, 925.209f, 3.64735f, 0 ); 
			World.Locations[ "RuinsofZulKunda" ] = new Position( -11693.9f, 702.532f, 49.9689f, 0 ); 
			World.Locations[ "KurzensCompound" ] = new Position( -11586.5f, -657.662f, 32.9941f, 0 ); 
			World.Locations[ "UnfinishedTemple" ] = new Position( -11845f, -1199.29f, 77.2075f, 0 ); 
			World.Locations[ "RandomBayRuins" ] = new Position( -11712.7f, -1758.67f, 22.4509f, 0 ); 
			World.Locations[ "FloatingBridge" ] = new Position( -11988f, -1484.99f, 78.9735f, 0 ); 
			World.Locations[ "UnfinishedHills" ] = new Position( -13010.2f, -1617.82f, 146.263f, 0 ); 
			World.Locations[ "RebelCamp" ] = new Position( -11311.5f, -195.19f, 76.3198f, 0 ); 

			//Swamp of Sorrows: 
			World.Locations[ "MistyValley" ] = new Position( -10103.4f, -2431.61f, 28.4491f, 0 ); 
			World.Locations[ "StonardOrcOutpost" ] = new Position( -10452.5f, -3263.59f, 20.1782f, 0 ); 
			World.Locations[ "FallowSanctuaryMurlocOutpost" ] = new Position( -9980.38f, -3568.28f, 22.0569f, 0 ); 
			World.Locations[ "MistyreedStrand" ] = new Position( -10022.2f, -4266.67f, 7.26064f, 0 ); 
			World.Locations[ "PoolofTears" ] = new Position( -10303.5f, -3972.28f, 20.2882f, 0 ); 
			World.Locations[ "SunkenTemple" ] = new Position( -10349.1f, -3849.67f, -25.6078f, 0 ); 

			//Trisfal Glades: 
			World.Locations[ "Deathknell" ] = new Position( 1871.14f, 1587.91f, 91.2143f, 0 ); 
			World.Locations[ "SollidenFarmstead" ] = new Position( 2268.03f, 1333.63f, 34.7835f, 0 ); 
			World.Locations[ "WhisperingShore" ] = new Position( 2538.92f, 1407.01f, 5.69061f, 0 ); 
			World.Locations[ "AgamandMills" ] = new Position( 2803.27f, 847.119f, 111.841f, 0 ); 
			World.Locations[ "GarrensHaunt" ] = new Position( 2861.67f, 398.526f, 21.1504f, 0 ); 
			World.Locations[ "TheNorthCoast" ] = new Position( 2955.79f, 99.8215f, 3.32947f, 0 ); 
			World.Locations[ "BrightwaterLake" ] = new Position( 2685.13f, -198.851f, 31.4095f, 0 ); 
			World.Locations[ "GunthersRetreat" ] = new Position( 2563.98f, -51.7975f, 31.7441f, 0 ); 
			World.Locations[ "BrillForsakenVillage" ] = new Position( 2260.64f, 289.021f, 34.1291f, 0 ); 
			World.Locations[ "ColdHearthManor" ] = new Position( 2146.99f, 658.485f, 33.59f, 0 ); 
			World.Locations[ "RuinsofLordaeron" ] = new Position( 1832.44f, 236.426f, 60.4171f, 0 ); 
			World.Locations[ "TheThroneRoom" ] = new Position( 1628.3f, 239.925f, 64.5006f, 0 ); 
			World.Locations[ "TheUndercityTradeQuarter" ] = new Position( 1586.48f, 239.562f, -52.149f, 0 ); 
			World.Locations[ "TheUndercityCaves" ] = new Position( 1614.68f, 643.289f, 37.0547f, 0 ); 
			World.Locations[ "TheUndercityWarQuarter" ] = new Position( 1658.95f, 303.76f, -42.6923f, 0 ); 
			World.Locations[ "TheUndercityMagicQuarter" ] = new Position( 1786.82f, 47.9279f, -29.1457f, 0 ); 
			World.Locations[ "TheUndercityRoguesQuarter" ] = new Position( 1466.11f, 49.6445f, -62.2932f, 0 ); 
			World.Locations[ "TheUndercityTheApothecarium" ] = new Position( 1410.31f, 430.512f, -80.3588f, 0 ); 
			World.Locations[ "BalnirFarmstead" ] = new Position( 2032.01f, -432.954f, 35.4329f, 0 ); 
			World.Locations[ "WhisperingGardens" ] = new Position( 2795.02f, -753.797f, 138.036f, 0 ); 
			World.Locations[ "TerraceofRepose" ] = new Position( 2922.59f, -740.071f, 153.983f, 0 ); 
			World.Locations[ "UnfinishedMansion" ] = new Position( 2853.92f, -718.217f, 148.381f, 0 ); 
			World.Locations[ "ScarletWatchPost" ] = new Position( 3040.8f, -552.374f, 122.216f, 0 ); 
			World.Locations[ "TheBulwark" ] = new Position( 1716.02f, -788.217f, 56.844f, 0 ); 

			//Western Plaguelands: 
			World.Locations[ "RuinsofAnderhol" ] = new Position( 1386.47f, -1518.8f, 72.4034f, 0 ); 
			World.Locations[ "SorrowHill" ] = new Position( 1064.09f, -1718.04f, 61.1348f, 0 ); 
			World.Locations[ "PaladinStatue" ] = new Position( 981.477f, -1821.84f, 80.4872f, 0 ); 
			World.Locations[ "GahrronsWithering" ] = new Position( 1738.52f, -2319.93f, 59.5751f, 0 ); 
			World.Locations[ "TheWrithingHaunt" ] = new Position( 1487.77f, -1884.87f, 59.2039f, 0 ); 
			World.Locations[ "DalsonsTears" ] = new Position( 1835.04f, -1568.1f, 59.1818f, 0 ); 
			World.Locations[ "FelstoneField" ] = new Position( 1782.26f, -1211.93f, 59.4057f, 0 ); 
			World.Locations[ "NorthridgeLumberCamp" ] = new Position( 2423.42f, -1646.44f, 60.5098f, 0 ); 
			World.Locations[ "Hearthglenn" ] = new Position( 2918.72f, -1439.39f, 150.782f, 0 ); 

			//Westfall: 
			World.Locations[ "SentinelHill" ] = new Position( -10510f, 1046.89f, 60.518f, 0 ); 
			World.Locations[ "MoonbrookWestfall" ] = new Position( -11018.4f, 1513.69f, 43.0152f, 0 ); 
			World.Locations[ "AlexstonFarmsted" ] = new Position( -10644.8f, 1681.3f, 42.0338f, 0 ); 
			World.Locations[ "Longshore" ] = new Position( -10513.9f, 2075.23f, 12.1819f, 0 ); 
			World.Locations[ "SaldeansFarm" ] = new Position( -10171.8f, 1195.41f, 36.4345f, 0 ); 
			World.Locations[ "WestfallLighthouse" ] = new Position( -11399.2f, 1947.85f, 10.1451f, 0 ); 
			World.Locations[ "FurlbrowsPumpkinPatch" ] = new Position( -9903.53f, 1245.26f, 42.0563f, 0 ); 

			//Wetlands: 
			World.Locations[ "UnknownBigDwarfCity" ] = new Position( -4053.99f, -3450.62f, 283.383f, 0 ); 
			World.Locations[ "BigBrokenGates" ] = new Position( -3465.16f, -3727.56f, 64.5778f, 0 ); 
			World.Locations[ "WeirdFlowers" ] = new Position( -3256.88f, -2718.36f, 9.41205f, 0 ); 
			World.Locations[ "IronbeadsTomb" ] = new Position( -2849.21f, -2220.06f, 31.3835f, 0 ); 
			World.Locations[ "BaradinBay" ] = new Position( -2955f, -1022.21f, 10.0919f, 0 ); 
			World.Locations[ "MenethilBay" ] = new Position( -3754.19f, -1087.3f, -1.71875f, 0 ); 
			World.Locations[ "MenethilHarbor" ] = new Position( -3740.29f, -755.08f, 10.9643f, 0 ); 
			World.Locations[ "DunModr" ] = new Position( -2605.21f, -2341.09f, 83.3551f, 0 ); 
			World.Locations[ "ThandolSpan" ] = new Position( -2336.47f, -2509.82f, 85.2212f, 0 ); 
			World.Locations[ "WhelgarsExcavationSite" ] = new Position( -3522.96f, -1848.58f, 25.1502f, 0 ); 

			//Kalimdor 

			//Ashenvale: 
			World.Locations[ "Xavian" ] = new Position( 2867.03f, -2595.67f, 219.911f, 1 ); 
			World.Locations[ "Astrnaar" ] = new Position( 2745.85f, -378.33f, 108.253f, 1 ); 
			World.Locations[ "NightElfPortal" ] = new Position( 3155f, -3702f, 121f, 1 ); 
			World.Locations[ "MastersGlaive" ] = new Position( 4577.61f, 419.307f, 33.7161f, 1 ); 
			World.Locations[ "KargathiaOrcOutpost" ] = new Position( 2439.16f, -3500.08f, 98.5954f, 1 ); 
			World.Locations[ "Satyrnaar" ] = new Position( 2757.59f, -2967.58f, 143.882f, 1 ); 
			World.Locations[ "Moonwell" ] = new Position( 2454.38f, -2943.27f, 124f, 1 ); 
			World.Locations[ "FelfireHill" ] = new Position( 2114.86f, -2998.32f, 111.396f, 1 ); 
			World.Locations[ "DemonFallCanyon" ] = new Position( 1626.91f, -3057.36f, 89.4942f, 1 ); 
			World.Locations[ "TheDordanilBarrowDen" ] = new Position( 1775.1f, -2679.19f, 111.666f, 1 ); 
			World.Locations[ "FalfarrenRiver" ] = new Position( 1669.74f, -1714.14f, 97.9564f, 1 ); 
			World.Locations[ "RaynewoodRetreat" ] = new Position( 2673.51f, -1859.72f, 188.112f, 1 ); 

			//Aszhara: 
			World.Locations[ "UnderwaterDarkPortal" ] = new Position( 3466.36f, -6656.29f, -58.5217f, 1 ); 
			World.Locations[ "AszharaNagaCity" ] = new Position( 3546.8f, -5287.96f, 109.935f, 1 ); 

			//Barrens: 
			World.Locations[ "BarrensMerchantCoast" ] = new Position( -1719.08f, -3824.99f, 12.0836f, 1 ); 
			World.Locations[ "BarrensFieldofGiants" ] = new Position( -3120.86f, -2327.89f, 93.1243f, 1 ); 
			World.Locations[ "BaelModan" ] = new Position( -4095.7f, -2305.74f, 124.914f, 1 ); 
			World.Locations[ "BarrensGnollOutpostInsideaGiantBeast" ] = new Position( -4319.38f, -2110.38f, 80.8662f, 1 ); 
			World.Locations[ "BarrensTheGreatLift" ] = new Position( -4619.15f, -1850.91f, 86.0563f, 1 ); 
			World.Locations[ "CampTaurajo" ] = new Position( -2388.95f, -1918.82f, 96.7422f, 1 ); 
			World.Locations[ "LushwaterOasis" ] = new Position( -964.776f, -2039.74f, 81.3491f, 1 ); 
			World.Locations[ "TheStagnantOasis" ] = new Position( -1330.17f, -3120.07f, 91.6667f, 1 ); 
			World.Locations[ "RatchetTrollPortOutpost" ] = new Position( -943.935f, -3715.49f, 11.8385f, 1 ); 
			World.Locations[ "TheCrossroads" ] = new Position( -456.263f, -2652.7f, 95.615f, 1 ); 
			World.Locations[ "TheForgottenPools" ] = new Position( 110.197f, -1891.39f, 93.5444f, 1 ); 
			World.Locations[ "TheSludgeFen" ] = new Position( 1059.54f, -3003.53f, 91.6441f, 1 ); 

			//Dark Shore: 
			World.Locations[ "GroveofTheAncients" ] = new Position( 4995.94f, 82.9197f, 54.3857f, 1 ); 
			World.Locations[ "TheLongWash" ] = new Position( 5028.14f, 534.745f, 7.28397f, 1 ); 
			World.Locations[ "Auberdine" ] = new Position( 6439.28f, 614.957f, 5.98831f, 1 ); 
			World.Locations[ "BashalAran" ] = new Position( 6735.43f, 6.71422f, 42.7028f, 1 ); 
			World.Locations[ "CliffspringRiver" ] = new Position( 6931.74f, -569.077f, 44.8192f, 1 ); 
			World.Locations[ "TowerofAlthalaxx" ] = new Position( 7177.46f, -761.607f, 59.6101f, 1 ); 
			World.Locations[ "RuinsofMathystra" ] = new Position( 7373.38f, -938.331f, 32.6196f, 1 ); 
			World.Locations[ "MistsEdge" ] = new Position( 7742.92f, -769.867f, 5.22102f, 1 ); 

			//Desolace: 
			World.Locations[ "ThunderAxeFortress" ] = new Position( -439.192f, 1708.22f, 125.856f, 1 ); 
			World.Locations[ "Sargeron" ] = new Position( -242.347f, 764.848f, 98.7113f, 1 ); 
			World.Locations[ "KolkarVillage" ] = new Position( -939.787f, 1091.4f, 93.8119f, 1 ); 
			World.Locations[ "MagramVillage" ] = new Position( -1754.33f, 967.89f, 92.5626f, 1 ); 
			World.Locations[ "MannorocCoven" ] = new Position( -1879.28f, 1745.49f, 78.8892f, 1 ); 
			World.Locations[ "GelkisVillage" ] = new Position( -2222.47f, 2522.4f, 68.4424f, 1 ); 
			World.Locations[ "ValleyofSpears" ] = new Position( -1482.87f, 2855.86f, 112.854f, 1 ); 
			World.Locations[ "SarTherisStrand" ] = new Position( -592.792f, 2592.84f, 15.467f, 1 ); 
			World.Locations[ "KodoGraveyard" ] = new Position( -1305.19f, 1837.56f, 55.731f, 1 ); 
			World.Locations[ "GhostWalkerPost" ] = new Position( -1156.34f, 1894.49f, 86.2854f, 1 ); 

			//Felwood: 
			World.Locations[ "ThreeFrozenAncients" ] = new Position( 6200f, -1035f, 387f, 1 ); 
			World.Locations[ "ZoramsStand" ] = new Position( 3652.24f, 928.308f, 7.01517f, 1 ); 

			//Feralas: 
			World.Locations[ "FeralasIslandNightElfCity" ] = new Position( -4358.88f, 3241f, 12.3636f, 1 ); 
			World.Locations[ "Feralas" ] = new Position( -2871.76f, 1885.29f, 52.6501f, 1 ); 
			World.Locations[ "FeralasRuins" ] = new Position( -2858.35f, 2611.48f, 58.3777f, 1 ); 
			World.Locations[ "FeralasCoast" ] = new Position( -4522.22f, 2038.54f, 50.1436f, 1 ); 
			World.Locations[ "BigFeralasRuins" ] = new Position( -5566.04f, 1449.82f, 20.1135f, 1 ); 
			World.Locations[ "TaurenVillage" ] = new Position( -4369.68f, 242.294f, 25.4133f, 1 ); 
			World.Locations[ "Thalanaar" ] = new Position( -4517.1f, -780.415f, -40.736f, 1 ); 

			//Durotar: 
			World.Locations[ "EchoIsles" ] = new Position( -1124.19f, -5535.02f, 8.62076f, 1 ); 
			World.Locations[ "ValleyofTrialsBindpoint" ] = new Position( -636.469f, -4243.52f, 38.1339f, 1 ); 
			World.Locations[ "SenJinVillage" ] = new Position( -844.586f, -4924.29f, 20.8708f, 1 ); 
			World.Locations[ "KolkarCrag" ] = new Position( -1028.63f, -4599.8f, 25.5756f, 1 ); 
			World.Locations[ "TiragardeKeep" ] = new Position( -250.245f, -5070.41f, 22.5875f, 1 ); 
			World.Locations[ "ScuttleCoast" ] = new Position( 242.548f, -5151.46f, 1.60441f, 1 ); 
			World.Locations[ "Razorhill" ] = new Position( 304.762f, -4734.97f, 9.30458f, 1 ); 
			World.Locations[ "SouthfuryRiver" ] = new Position( 114.769f, -3758.95f, 17.8907f, 1 ); 
			World.Locations[ "ThunderRidge" ] = new Position( 925.127f, -4038.29f, -13.338f, 1 ); 
			World.Locations[ "Orgimmar" ] = new Position( 1484.36f, -4417.03f, 24.4709f, 1 ); 
			World.Locations[ "BladefistBay" ] = new Position( 1525.73f, -4968.13f, 17.1397f, 1 ); 
			World.Locations[ "DeadeyeShore" ] = new Position( 918.715f, -5115.69f, 2.85835f, 1 ); 

			//Dustwallow Marsh: 
			World.Locations[ "ShadyRestInn" ] = new Position( -3719.26f, -2530.63f, 69.58f, 1 ); 
			World.Locations[ "LostPoint" ] = new Position( -3922.24f, -2839.21f, 44.6212f, 1 ); 
			World.Locations[ "TheDenofFlame" ] = new Position( -4336.82f, -3018.67f, 33.1744f, 1 ); 
			World.Locations[ "TheDragonmurk" ] = new Position( -4197.56f, -2873.76f, 44.6771f, 1 ); 
			World.Locations[ "StonemaulRuins" ] = new Position( -4354.46f, -3275.34f, 46.0475f, 1 ); 
			World.Locations[ "BeezilsZepellinsWreck" ] = new Position( -4006.19f, -3777.83f, 40.6804f, 1 ); 
			World.Locations[ "BrackenwallOrcVillage" ] = new Position( -3129.38f, -2864.51f, 34.8711f, 1 ); 
			World.Locations[ "NorthPointTower" ] = new Position( -2855.96f, -3422.66f, 36.7473f, 1 ); 
			World.Locations[ "SentryPoint" ] = new Position( -3459.39f, -4130.3f, 16.3786f, 1 ); 
			World.Locations[ "DreadmurkShore" ] = new Position( -3012.72f, -4345.51f, 6.83608f, 1 ); 

			//Mulgore: 
			World.Locations[ "BloodhoofTaurenVillage" ] = new Position( -2321.74f, -378.941f, -9.40597f, 1 ); 
			World.Locations[ "TaurenCampNarache" ] = new Position( -2905.3f, -253.768f, 56.0612f, 1 ); 
			World.Locations[ "BramblebladeRavine" ] = new Position( -2933.37f, -963.993f, 58.2343f, 1 ); 
			World.Locations[ "RedCloudMesa" ] = new Position( -2928.26f, -46.1054f, 188.892f, 1 ); 
			World.Locations[ "BaelDunDigside" ] = new Position( -1897.98f, 400.675f, 134.787f, 1 ); 
			World.Locations[ "WildmaneWaterWell" ] = new Position( -758.744f, -149.474f, -27.712f, 1 ); 
			World.Locations[ "RedRocks" ] = new Position( -1008.68f, -1115.72f, 46.046f, 1 ); 
			World.Locations[ "MulgoreMine" ] = new Position( -1915.66f, -1107.44f, 87.572f, 1 ); 

			//Shimmering Flats: 
			World.Locations[ "TheRustmaulDigSite" ] = new Position( -6495.56f, -3472.69f, -58.7786f, 1 ); 
			World.Locations[ "TheRacetrack" ] = new Position( -6202.16f, -3901.68f, -60.2858f, 1 ); 

			//South Kalimdor: 
			World.Locations[ "Tanaris" ] = new Position( -6942.47f, -4847.1f, 0.667853f, 1 ); 
			World.Locations[ "UngoroCrater" ] = new Position( -7434.56f, -1983.21f, -270.149f, 1 ); 
			World.Locations[ "TerrorRun" ] = new Position( -7866.75f, -630.03f, -260.563f, 1 ); 
			World.Locations[ "FloatingCrystalGates" ] = new Position( -8185.09f, 1528.22f, 2.98973f, 1 ); 
			World.Locations[ "UnkownCity" ] = new Position( -9678.11f, 1530.11f, 43.025f, 1 ); 
			World.Locations[ "NerubianPits" ] = new Position( -7245.6f, 1678.94f, -65.9066f, 1 ); 

			//Stonetalon Mountains: 
			World.Locations[ "StonetalonMountains" ] = new Position( -239.089f, -809.973f, 8.78944f, 1 ); 
			World.Locations[ "GreatwoodVale" ] = new Position( -87.9634f, -565.775f, -12.1339f, 1 ); 
			World.Locations[ "SunrockRetreat" ] = new Position( -191.661f, -301.87f, 12.2698f, 1 ); 
			World.Locations[ "WindshearCrag" ] = new Position( 1160.25f, 51.3229f, 1.072f, 1 ); 
			World.Locations[ "CragpoolLake" ] = new Position( 1618.33f, 161.796f, 133.084f, 1 ); 
			World.Locations[ "StonetalonPeak" ] = new Position( 2506.3f, 1470.14f, 262.722f, 1 ); 
			World.Locations[ "CharredVale" ] = new Position( 821.99f, 1599.07f, -21.1896f, 1 ); 

			//Thousand Needles: 
			World.Locations[ "FreewoodPost" ] = new Position( -5437.4f, -2437.47f, 89.3083f, 1 ); 
			World.Locations[ "TheScreechingCanyon" ] = new Position( -5467.33f, -1633.45f, 29.4245f, 1 ); 
			World.Locations[ "Highperch" ] = new Position( -5000.46f, -940.209f, -5.58816f, 1 ); 

			//Teldrassil: 
			World.Locations[ "Dolanaar" ] = new Position( 9892.57f, 982.424f, 1313.83f, 1 ); 
			World.Locations[ "LakeAlAmeth" ] = new Position( 9477.19f, 1005.74f, 1249.01f, 1 ); 
			World.Locations[ "GnarlpineHold" ] = new Position( 9114.65f, 1846.06f, 1327.5f, 1 ); 
			World.Locations[ "PoolsofArilthrien" ] = new Position( 9561.33f, 1743f, 1291.91f, 1 ); 
			World.Locations[ "Darnassus" ] = new Position( 9948.55f, 2413.59f, 1327.23f, 1 ); 
			World.Locations[ "Shadowglen" ] = new Position( 10699.8f, 738.73f, 1325.881f, 1 ); 
			World.Locations[ "Aldrassil" ] = new Position( 10455.7f, 798.455f, 1346.75f, 1 ); 

			//Theramore Isle: 
			World.Locations[ "TheramoreIsleLighthouse" ] = new Position( -3688.18f, -4760.14f, 0.909682f, 1 ); 
			World.Locations[ "TheramoreIsleCity" ] = new Position( -3729.36f, -4421.41f, 30.4474f, 1 );
		}
	}
}
			