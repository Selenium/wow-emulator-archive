//	Script modified by zehamster - 28/08/05 02:01:03
 //	Script made by Anonymous - 28/08/05 02:00:28
using System;

namespace Server
{
	public class CemeteryList : IInitialize
	{
		public static void Initialize()
		{
			//	Cemetery list
			World.Cemetery.Add( new Position( -637.3295f, -4293.471f, 40.36089f, 0 ) );//	Valley of trials
			World.Cemetery.Add( new Position( -8935.325195f, -188.646271f, 80.416466f, 0 ) );//	human starting zone cemetery
			World.Cemetery.Add( new Position( -9341.788f, 177.7866f, 61.56488f, 0 ) );//	Goldshire
			World.Cemetery.Add( new Position( -5681.76f, -520.6374f, 396.2743f, 0 ) );//	Kharanos
			// Complete Cemetery list - made by SneakerXZ (last update 28.4.2005)
			World.Cemetery.Add( new Position( 10384.810f, 811.531f, 1317.538f, 1 ) ); // Aldrassil - elfs starting zone cemetery
			World.Cemetery.Add( new Position( 2603.311f, -534.657f, 89.000f, 0 ) ); // Faol's Rest
			World.Cemetery.Add( new Position( -6164.226f, 336.321f, 399.793f, 0 ) ); // Coldridge valley - gnomes and dwarws starting zone cemetery
			World.Cemetery.Add( new Position( -3525.706f, -4315.455f, 6.996f, 1 ) ); //	Dustwallow Marsh
			World.Cemetery.Add( new Position( -3127.690f, -3046.940f, 33.831f, 1 ) ); //	Dustwallow Marsh
			World.Cemetery.Add( new Position( -1072.589f, -3481.849f, 62.695f, 1 ) ); //	Ratchet
			World.Cemetery.Add( new Position( -592.601f, -2523.492f, 91.788f, 1 ) ); //	The Barrens
			World.Cemetery.Add( new Position( -2515.993f, -1966.481f, 91.784f, 1 ) ); //	Southern Barrens
			World.Cemetery.Add( new Position( -778.000f, -4985.000f, 18.944f, 1 ) ); //	Sen'jin Village
			World.Cemetery.Add( new Position( 238.027f, -4792.516f, 10.213f, 1 ) ); //	Razor Hill
			World.Cemetery.Add( new Position( -1443.488f, 1973.370f, 85.491f, 1 ) ); //	Kodo Graveyard
			World.Cemetery.Add( new Position( 4291.283f, 96.956f, 43.075f, 1 ) ); //	Twilight Vale
			World.Cemetery.Add( new Position( 6739.190f, 209.993f, 23.285f, 1 ) ); //	Darkshore
			World.Cemetery.Add( new Position( 2681.058f, -4009.754f, 107.849f, 1 ) ); //	Azshara
			World.Cemetery.Add( new Position( 2942.760f, -6037.130f, 4.104f, 1 ) ); //	Southbridge Beach
			World.Cemetery.Add( new Position( 2633.411f, -629.735f, 107.581f, 1 ) ); //	Astranaar
			World.Cemetery.Add( new Position( 2421.724f, -2953.619f, 123.473f, 1 ) ); //	Nightsong Woods
			World.Cemetery.Add( new Position( -7490.450f, -2132.620f, 142.186f, 0 ) ); //	Flame Crest
			World.Cemetery.Add( new Position( -5351.229f, -2881.582f, 340.942f, 0 ) ); //	Loch Modan
			World.Cemetery.Add( new Position( -732.799f, -592.502f, 22.663f, 0 ) ); //	Southshore
			World.Cemetery.Add( new Position( -2175.190f, -342.027f, -5.512f, 1 ) ); //	Bloodhoof Village
			World.Cemetery.Add( new Position( 908.323f, -1520.286f, 55.037f, 0 ) ); //	Chillwind Camp
			World.Cemetery.Add( new Position( -10546.900f, 1197.240f, 31.724f, 0 ) ); //	Sentinel Hill
			World.Cemetery.Add( new Position( -3289.124f, -2435.991f, 18.597f, 0 ) ); //	Wetlands
			World.Cemetery.Add( new Position( -3349.342f, -856.986f, 1.060f, 0 ) ); //	Baradin Bay
			World.Cemetery.Add( new Position( 1880.739f, 1624.735f, 94.434f, 0 ) ); //	Deathknell  - undeads starting zone cemetery
			World.Cemetery.Add( new Position( 2349.608f, 485.208f, 33.373f, 0 ) ); //	Brill
			World.Cemetery.Add( new Position( 1750.344f, -669.790f, 44.570f, 0 ) ); //	The Bulwark
			World.Cemetery.Add( new Position( 7426.000f, -2809.000f, 463.961f, 1 ) ); //	Moonglade
			World.Cemetery.Add( new Position( 323.513f, -2227.196f, 137.617f, 0 ) ); //	Aerie Peak
			World.Cemetery.Add( new Position( -10567.813f, -3377.203f, 22.253f, 0 ) ); //	Stonard
			World.Cemetery.Add( new Position( -11542.560f, -228.637f, 27.843f, 0 ) ); //	Stranglehorn Vale
			World.Cemetery.Add( new Position( -14284.962f, 288.447f, 32.332f, 0 ) ); //	The Cape of Stranglehorn
			World.Cemetery.Add( new Position( 516.194f, 1589.807f, 127.545f, 0 ) ); //	The Sepulcher
			World.Cemetery.Add( new Position( -6450.610f, -1113.510f, 308.021f, 0 ) ); //	Searing Gorge
			World.Cemetery.Add( new Position( -9403.245f, -2037.692f, 58.369f, 0 ) ); //	Redridge Mountains
			World.Cemetery.Add( new Position( 2116.790f, -5287.337f, 81.132f, 0 ) ); //	Light's Hope Chapel
			World.Cemetery.Add( new Position( 1392.000f, -3701.000f, 76.701f, 0 ) ); //	Darrowshire
			World.Cemetery.Add( new Position( -10774.263f, -1189.672f, 33.149f, 0 ) ); //	Darkshire
			World.Cemetery.Add( new Position( -11110.377f, -1833.241f, 71.864f, 0 ) ); //	Morgan's Plot
			World.Cemetery.Add( new Position( -10846.574f, -2949.488f, 13.227f, 0 ) ); //	Dreadmaul Hold
			World.Cemetery.Add( new Position( -6808.382f, -2286.167f, 280.752f, 0 ) ); //	Badlands
			World.Cemetery.Add( new Position( -1472.289f, -2617.959f, 49.277f, 0 ) ); //	Arathi Highlands
			World.Cemetery.Add( new Position( -18.678f, -981.171f, 55.838f, 0 ) ); //	Tarren Mill
			World.Cemetery.Add( new Position( 6858.564f, -4663.245f, 701.363f, 1 ) ); //	Everlook
			World.Cemetery.Add( new Position( -7205.565f, -2436.674f, -218.161f, 1 ) ); //	The Marshlands
			World.Cemetery.Add( new Position( -5530.283f, -3459.280f, -45.744f, 1 ) ); //	Thousand Needles
			World.Cemetery.Add( new Position( 9701.255f, 945.620f, 1291.355f, 1 ) ); //	Dolanaar
			World.Cemetery.Add( new Position( -7190.949f, -3944.652f, 9.227f, 1 ) ); //	Gadgetzan
			World.Cemetery.Add( new Position( 899.100f, 437.556f, 65.742f, 1 ) ); //	Webwinder Path
			World.Cemetery.Add( new Position( -6432.256f, -278.292f, 3.794f, 1 ) ); //	Valor's Rest
			World.Cemetery.Add( new Position( -4596.404f, 3229.434f, 8.994f, 1 ) ); //	Feathermoon Stronghold
			World.Cemetery.Add( new Position( -4439.967f, 370.153f, 51.357f, 1 ) ); //	Camp Mojache
			World.Cemetery.Add( new Position( -4656.000f, -1765.000f, -41.173f, 1 ) ); //	Thousand Needles
			World.Cemetery.Add( new Position( 3806.540f, -1600.291f, 218.831f, 1 ) ); //	Morlos'Aran
			World.Cemetery.Add( new Position( 5935.470f, -1217.750f, 383.202f, 1 ) ); //	Irontree Woods
			World.Cemetery.Add( new Position( 4788.780f, -6845.000f, 89.790f, 1 ) ); //	Legash Encampent
			// Added Battleground Cemeteries by ZeHaMStEr (28/08/2005)
			World.Cemetery.Add( new Position( -1078.000f, -305.000f, 58.000f, 30 ) ); // Frostwolf, Alterac Valley
			World.Cemetery.Add( new Position( 667.186f, -307.983f, 30.291f, 30 ) ); // Stormpike, Alterac Valley
			World.Cemetery.Add( new Position( -198.000f, -113.000f, 79.000f, 30 ) ); // Snow Cemetery, Alterac Valley
			World.Cemetery.Add( new Position( 1415.330f, 1554.790f, 343.156f, 489 ) ); // Alliance Cemetery, Warsong Gulch
			World.Cemetery.Add( new Position( 1029.140f, 1387.490f, 340.836f, 489 ) ); // Horde Cemetery, Warsong Gulch
		}
	}
}