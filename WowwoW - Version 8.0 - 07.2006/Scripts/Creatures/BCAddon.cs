// Idea: Driller
// Writed by Volhv
// Support and corrections: Driller
using System;
using Server;

namespace Server.Creatures
{
	public class BCAddon
	{
		/// <summary>
		/// SetCorrections for Any type of ellite/normal creature
		/// </summary>
		public static void Hp( BaseCreature c, int _hp, int _lvl )
		{
			switch ( c.Elite )
			{
				case 1: HpL1( c, _hp, _lvl ); break;
				case 2: HpL2( c, _hp, _lvl ); break;
				case 3: HpL3( c, _hp, _lvl ); break;
				case 4: HpL4( c, _hp, _lvl ); break;
				default: HpAll( c, _hp, _lvl ); break;
			}
		}
		/// <summary>
		/// All Non elite mobs
		/// </summary>
		public static void HpAll( BaseCreature c, int _hp, int _lvl )
		{
			if ( c.Level == _lvl ) c.BaseHitPoints = _hp;
			else
			{
				float step = 0;
				switch ( c.Level - _lvl )
				{
					case 1 : step = 1.04499995708466f; break;
					case 2 : step = 1.09202491030693f; break;
					case 3 : step = 1.14116598440612f; break;
					case 4 : step = 1.19251840473086f; break;
					case 5 : step = 1.24618168176641f; break;
					case 6 : step = 1.30225980396559f; break;
					case 7 : step = 1.36086143925711f; break;
					case 8 : step = 1.42210014562184f; break;
					case 9 : step = 1.48609459114491f; break;
					case 10 : step = 1.55296878397017f; break;
					case 11 : step = 1.62285231260264f; break;
					case 12 : step = 1.69588059702449f; break;
					case 13 : step = 1.77219515111129f; break;
					case 14 : step = 1.85194385685694f; break;
					case 15 : step = 1.93528125093869f; break;
					case 16 : step = 2.02236882417767f; break;
					case 17 : step = 2.11337533447501f; break;
					case 18 : step = 2.20847713383016f; break;
					case 19 : step = 2.30785851007496f; break;
					case 20 : step = 2.41171204398579f; break;
					case 21 : step = 2.5202389824657f; break;
					case 22 : step = 2.63364962851973f; break;
					case 23 : step = 2.75216374877914f; break;
					case 24 : step = 2.87601099936414f; break;
					case 25 : step = 3.00543137091053f; break;
					case 26 : step = 3.14067565362238f; break;
					case 27 : step = 3.28200592325221f; break;
					case 28 : step = 3.42969604895014f; break;
					case 29 : step = 3.58403222396631f; break;
					case 30 : step = 3.74531352023482f; break;
					case 31 : step = 3.91385246791397f; break;
					case 32 : step = 4.08997566100577f; break;
					case 33 : step = 4.27402439022832f; break;
					case 34 : step = 4.46635530436737f; break;
					case 35 : step = 4.66734110138872f; break;
					case 36 : step = 4.87737125065066f; break;
					case 37 : step = 5.09685274761588f; break;
					case 38 : step = 5.3262109025254f; break;
					case 39 : step = 5.56589016456287f; break;
					case 40 : step = 5.81635498310611f; break;
					case 41 : step = 6.07809070773501f; break;
					case 42 : step = 6.35160452873972f; break;
					case 43 : step = 6.63742645995172f; break;
					case 44 : step = 6.9361103658021f; break;
					case 45 : step = 7.24823503459763f; break;
					case 46 : step = 7.57440530009403f; break;
					case 47 : step = 7.91525321354005f; break;
					case 48 : step = 8.27143926846353f; break;
					case 49 : step = 8.64365368057273f; break;
					case 50 : step = 9.03261772525313f; break;
					case 51 : step = 9.43908513525162f; break;
					case 52 : step = 9.86384356125635f; break;
					case 53 : step = 10.3077160982026f; break;
					case 54 : step = 10.7715628802626f; break;
					case 55 : step = 11.2562827476091f; break;
					case 56 : step = 11.7628149881842f; break;
					case 57 : step = 12.2921411578473f; break;
					case 58 : step = 12.8452869824289f; break;
					case 59 : step = 13.4233243453783f; break;
					case 60 : step = 14.0273733648537f; break;
					default: step = 14.6586045642826f; break;
				}
				c.BaseHitPoints = (int)( _hp * (float)step );
			}
		}
		/// <summary>
		/// Ellite Level 1
		/// </summary>
		public static void HpL1( BaseCreature c, int _hp, int _lvl )
		{
			if ( c.Level == _lvl ) c.BaseHitPoints = _hp;
			else
			{
				float step = 0;
				switch ( c.Level - _lvl )
				{
					case 1 : step = 1.20000004768372f; break;
					case 2 : step = 1.44000011444092f; break;
					case 3 : step = 1.72800020599366f; break;
					case 4 : step = 2.07360032958986f; break;
					case 5 : step = 2.48832049438481f; break;
					case 6 : step = 2.98598471191413f; break;
					case 7 : step = 3.58318179667981f; break;
					case 8 : step = 4.29981832687519f; break;
					case 9 : step = 5.15978219728154f; break;
					case 10 : step = 6.19173888277544f; break;
					case 11 : step = 7.43008695457565f; break;
					case 12 : step = 8.91610469978493f; break;
					case 13 : step = 10.6993260648949f; break;
					case 14 : step = 12.8391917880575f; break;
					case 15 : step = 15.4070307578894f; break;
					case 16 : step = 18.4884376441318f; break;
					case 17 : step = 22.1861260545555f; break;
					case 18 : step = 26.6233523233836f; break;
					case 19 : step = 31.9480240575606f; break;
					case 20 : step = 38.3376303924733f; break;
					case 21 : step = 46.0051582990486f; break;
					case 22 : step = 55.2061921525552f; break;
					case 23 : step = 66.2474332155026f; break;
					case 24 : step = 79.4969230175269f; break;
					case 25 : step = 95.396311411741f; break;
					case 26 : step = 114.47557824294f; break;
					case 27 : step = 137.370699350149f; break;
					case 28 : step = 164.844845770524f; break;
					case 29 : step = 197.813822785043f; break;
					case 30 : step = 237.37659677455f; break;
					case 31 : step = 284.851927448458f; break;
					case 32 : step = 341.822326520948f; break;
					case 33 : step = 410.186808124497f; break;
					case 34 : step = 492.224189308627f; break;
					case 35 : step = 590.669050641431f; break;
					case 36 : step = 708.802888935012f; break;
					case 37 : step = 850.56350052037f; break;
					case 38 : step = 1020.67624118247f; break;
					case 39 : step = 1224.8115380886f; break;
					case 40 : step = 1469.77390410989f; break;
					case 41 : step = 1763.72875501615f; break;
					case 42 : step = 2116.47459012052f; break;
					case 43 : step = 2539.76960906599f; break;
					case 44 : step = 3047.72365198485f; break;
					case 45 : step = 3657.2685277086f; break;
					case 46 : step = 4388.72240764248f; break;
					case 47 : step = 5266.46709844157f; break;
					case 48 : step = 6319.7607692546f; break;
					case 49 : step = 7583.71322445519f; break;
					case 50 : step = 9100.45623096586f; break;
					case 51 : step = 10920.5479111026f; break;
					case 52 : step = 13104.6580140554f; break;
					case 53 : step = 15725.5902417453f; break;
					case 54 : step = 18870.7090399489f; break;
					case 55 : step = 22644.8517477642f; break;
					case 56 : step = 27173.8231771078f; break;
					case 57 : step = 32608.5891082782f; break;
					case 58 : step = 39130.3084848325f; break;
					case 59 : step = 46956.3720476775f; break;
					case 60 : step = 56347.6486962673f; break;
					default: step = 67617.1811223861f; break;
				}
				c.BaseHitPoints = (int)( _hp * (float)step );
			}
		}
		/// <summary>
		/// Ellite Level 2
		/// </summary>
		public static void HpL2( BaseCreature c, int _hp, int _lvl )
		{
			if ( c.Level == _lvl ) c.BaseHitPoints = _hp;
			else
			{
				float step = 0;
				switch ( c.Level - _lvl )
				{
					case 1 : step = 1.29999995231628f; break;
					case 2 : step = 1.68999987602234f; break;
					case 3 : step = 2.19699975824357f; break;
					case 4 : step = 2.85609958095553f; break;
					case 5 : step = 3.71292931905275f; break;
					case 6 : step = 4.8268079377223f; break;
					case 7 : step = 6.27485008887886f; break;
					case 8 : step = 8.15730481633435f; break;
					case 9 : step = 10.604495872264f; break;
					case 10 : step = 13.7858441282815f; break;
					case 11 : step = 17.9215967094057f; break;
					case 12 : step = 23.298074867659f; break;
					case 13 : step = 30.287496217018f; break;
					case 14 : step = 39.373743637903f; break;
					case 15 : step = 51.1858648517875f; break;
					case 16 : step = 66.5416218665915f; break;
					case 17 : step = 86.5041052536172f; break;
					case 18 : step = 112.455332704865f; break;
					case 19 : step = 146.191927154037f; break;
					case 20 : step = 190.049498329273f; break;
					case 21 : step = 247.064338765789f; break;
					case 22 : step = 321.18362861458f; break;
					case 23 : step = 417.538701883725f; break;
					case 24 : step = 542.800292539046f; break;
					case 25 : step = 705.640354418024f; break;
					case 26 : step = 917.332427095878f; break;
					case 27 : step = 1192.53211148282f; break;
					case 28 : step = 1550.29168806331f; break;
					case 29 : step = 2015.37912055863f; break;
					case 30 : step = 2619.99276062545f; break;
					case 31 : step = 3405.9904638821f; break;
					case 32 : step = 4427.78744063645f; break;
					case 33 : step = 5756.12346169402f; break;
					case 34 : step = 7482.96022572888f; break;
					case 35 : step = 9727.84793663219f; break;
					case 36 : step = 12646.2018537619f; break;
					case 37 : step = 16440.0618068726f; break;
					case 38 : step = 21372.0795650111f; break;
					case 39 : step = 27783.7024154143f; break;
					case 40 : step = 36118.8118152084f; break;
					case 41 : step = 46954.4536374918f; break;
					case 42 : step = 61040.7874897765f; break;
					case 43 : step = 79353.0208260579f; break;
					case 44 : step = 103158.923290028f; break;
					case 45 : step = 134106.595358036f; break;
					case 46 : step = 174338.567570746f; break;
					case 47 : step = 226640.129528859f; break;
					case 48 : step = 294632.157580474f; break;
					case 49 : step = 383021.790805459f; break;
					case 50 : step = 497928.309783195f; break;
					case 51 : step = 647306.778975082f; break;
					case 52 : step = 841498.781801614f; break;
					case 53 : step = 1093948.37621631f; break;
					case 54 : step = 1422132.83691768f; break;
					case 55 : step = 1848772.6201804f; break;
					case 56 : step = 2403404.31807818f; break;
					case 57 : step = 3124425.49889838f; break;
					case 58 : step = 4061752.99958368f; break;
					case 59 : step = 5280278.7057793f; break;
					case 60 : step = 6864362.06572979f; break;
					default: step = 8923670.35813043f; break;
				}
				c.BaseHitPoints = (int)( _hp * (float)step );
			}
		}
		/// <summary>
		/// Ellite Level 3
		/// </summary>
		public static void HpL3( BaseCreature c, int _hp, int _lvl )
		{
			if ( c.Level == _lvl ) c.BaseHitPoints = _hp;
			else
			{
				float step = 0;
				switch ( c.Level - _lvl )
				{
					case 1 : step = 1.39999997615814f; break;
					case 2 : step = 1.9599999332428f; break;
					case 3 : step = 2.74399985980988f; break;
					case 4 : step = 3.84159973831177f; break;
					case 5 : step = 5.37823954204561f; break;
					case 6 : step = 7.52953523063663f; break;
					case 7 : step = 10.5413491433732f; break;
					case 8 : step = 14.7578885493971f; break;
					case 9 : step = 20.6610436173004f; break;
					case 10 : step = 28.925460571623f; break;
					case 11 : step = 40.4956441106354f; break;
					case 12 : step = 56.6939007893982f; break;
					case 13 : step = 79.3714597534696f; break;
					case 14 : step = 111.120041762494f; break;
					case 15 : step = 155.568055818184f; break;
					case 16 : step = 217.795274436426f; break;
					case 17 : step = 304.913379018352f; break;
					case 18 : step = 426.878723355992f; break;
					case 19 : step = 597.630202520806f; break;
					case 20 : step = 836.682269280514f; break;
					case 21 : step = 1171.35515704466f; break;
					case 22 : step = 1639.89719193524f; break;
					case 23 : step = 2295.85602961114f; break;
					case 24 : step = 3214.19838671813f; break;
					case 25 : step = 4499.87766477291f; break;
					case 26 : step = 6299.82862339664f; break;
					case 27 : step = 8819.75992255567f; break;
					case 28 : step = 12347.6636812985f; break;
					case 29 : step = 17286.7288594266f; break;
					case 30 : step = 24201.4199910495f; break;
					case 31 : step = 33881.9874104625f; break;
					case 32 : step = 47434.781566838f; break;
					case 33 : step = 66408.6930626399f; break;
					case 34 : step = 92972.1687043893f; break;
					case 35 : step = 130161.033969516f; break;
					case 36 : step = 182225.444454041f; break;
					case 37 : step = 255115.617891064f; break;
					case 38 : step = 357161.85896506f; break;
					case 39 : step = 500026.594035682f; break;
					case 40 : step = 700037.219728391f; break;
					case 41 : step = 980052.09092956f; break;
					case 42 : step = 1372072.90393512f; break;
					case 43 : step = 1920902.0327964f; break;
					case 44 : step = 2689262.80011709f; break;
					case 45 : step = 3764967.8560469f; break;
					case 46 : step = 5270954.90870184f; break;
					case 47 : step = 7379336.74651321f; break;
					case 48 : step = 10331071.2691814f; break;
					case 49 : step = 14463499.530542f; break;
					case 50 : step = 20248898.9979221f; break;
					case 51 : step = 28348458.1143196f; break;
					case 52 : step = 39687840.6841676f; break;
					case 53 : step = 55562976.0116027f; break;
					case 54 : step = 77788165.0915193f; break;
					case 55 : step = 108903429.273513f; break;
					case 56 : step = 152464798.386458f; break;
					case 57 : step = 213450714.105996f; break;
					case 58 : step = 298830994.659333f; break;
					case 59 : step = 418363385.398381f; break;
					case 60 : step = 585708729.583173f; break;
					default: step = 819992207.452057f; break;
				}
				c.BaseHitPoints = (int)( _hp * (float)step );
			}
		}
		/// <summary>
		/// Ellite Level 4
		/// </summary>
		public static void HpL4( BaseCreature c, int _hp, int _lvl )
		{
			if ( c.Level == _lvl ) c.BaseHitPoints = _hp;
			else
			{
				float step = 0;
				switch ( c.Level - _lvl )
				{
					case 1 : step = 1.5f; break;
					case 2 : step = 2.25f; break;
					case 3 : step = 3.375f; break;
					case 4 : step = 5.0625f; break;
					case 5 : step = 7.59375f; break;
					case 6 : step = 11.390625f; break;
					case 7 : step = 17.0859375f; break;
					case 8 : step = 25.62890625f; break;
					case 9 : step = 38.443359375f; break;
					case 10 : step = 57.6650390625f; break;
					case 11 : step = 86.49755859375f; break;
					case 12 : step = 129.746337890625f; break;
					case 13 : step = 194.619506835938f; break;
					case 14 : step = 291.929260253906f; break;
					case 15 : step = 437.893890380859f; break;
					case 16 : step = 656.840835571289f; break;
					case 17 : step = 985.261253356934f; break;
					case 18 : step = 1477.8918800354f; break;
					case 19 : step = 2216.8378200531f; break;
					case 20 : step = 3325.25673007965f; break;
					case 21 : step = 4987.88509511948f; break;
					case 22 : step = 7481.82764267921f; break;
					case 23 : step = 11222.7414640188f; break;
					case 24 : step = 16834.1121960282f; break;
					case 25 : step = 25251.1682940423f; break;
					case 26 : step = 37876.7524410635f; break;
					case 27 : step = 56815.1286615953f; break;
					case 28 : step = 85222.6929923929f; break;
					case 29 : step = 127834.039488589f; break;
					case 30 : step = 191751.059232884f; break;
					case 31 : step = 287626.588849326f; break;
					case 32 : step = 431439.883273989f; break;
					case 33 : step = 647159.824910984f; break;
					case 34 : step = 970739.737366476f; break;
					case 35 : step = 1456109.60604971f; break;
					case 36 : step = 2184164.40907457f; break;
					case 37 : step = 3276246.61361186f; break;
					case 38 : step = 4914369.92041778f; break;
					case 39 : step = 7371554.88062667f; break;
					case 40 : step = 11057332.32094f; break;
					case 41 : step = 16585998.48141f; break;
					case 42 : step = 24878997.722115f; break;
					case 43 : step = 37318496.5831725f; break;
					case 44 : step = 55977744.8747588f; break;
					case 45 : step = 83966617.3121382f; break;
					case 46 : step = 125949925.968207f; break;
					case 47 : step = 188924888.952311f; break;
					case 48 : step = 283387333.428467f; break;
					case 49 : step = 425081000.1427f; break;
					case 50 : step = 637621500.21405f; break;
					case 51 : step = 956432250.321074f; break;
					case 52 : step = 1434648375.48161f; break;
					case 53 : step = 2151972563.22242f; break;
					case 54 : step = 3227958844.83363f; break;
					case 55 : step = 4841938267.25044f; break;
					case 56 : step = 7262907400.87566f; break;
					case 57 : step = 10894361101.3135f; break;
					case 58 : step = 16341541651.9702f; break;
					case 59 : step = 24512312477.9553f; break;
					case 60 : step = 36768468716.933f; break;
					default: step = 55152703075.3995f; break;
				}
				c.BaseHitPoints = (int)( _hp * (float)step );
			}
		}
	}
}
