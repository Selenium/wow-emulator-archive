//	Script modified by Voffka - 24/08/05 06:36:08
 //	Script made by Voffka - 23/08/05 08:11:22
using System; 
using Server;
/*
 * Now script give all spells, talents and tradeskills of your class
 * and sets your level to 60. Added spells,talents and tradeskills for all classes.
 */ 
  
namespace Server.Scripts.Commands 
{ 
	public class GiveAll : IInitialize
	{ 
		public static void Initialize() 
		{ 
			Commands.Register( "giveall", AccessLevels.Admin, new CommandEventHandler( giveall_OnCommand )); 
		} 
  
		private static bool giveall_OnCommand( CommandEventArgs e ) 
		{ 
			#region TRADESKILLS
			#region PRIMARY
			/*Alchemy*/
			e.Player.LearnSpell(2259);	//Apprentice
			e.Player.LearnSpell(3101);	//Journeyman
			e.Player.LearnSpell(3464);	//Expert
			e.Player.LearnSpell(11611);	//Artisan
			/*Blacksmithing*/
			e.Player.LearnSpell(2018);	//Apprentice
			e.Player.LearnSpell(3100);	//Journeyman
			e.Player.LearnSpell(3538);	//Expert
			e.Player.LearnSpell(9785);	//Artisan
			/*Enchanting*/
			e.Player.LearnSpell(7411);	//Apprentice
			e.Player.LearnSpell(7412);	//Journeyman
			e.Player.LearnSpell(7413);	//Expert
			e.Player.LearnSpell(13920);	//Artisan
			/*Engineering*/
			e.Player.LearnSpell(4036);	//Apprentice
			e.Player.LearnSpell(4037);	//Journeyman
			e.Player.LearnSpell(4038);	//Expert
			e.Player.LearnSpell(12656);	//Artisan
			/*Herbalism*///not work
			e.Player.LearnSpell(2366);	//Apprentice
			e.Player.LearnSpell(2368);	//Journeyman
			e.Player.LearnSpell(3570);	//Expert
			e.Player.LearnSpell(11993);	//Artisan
			/*Leatherworking*/
			e.Player.LearnSpell(2108);	//Apprentice
			e.Player.LearnSpell(3104);	//Journeyman
			e.Player.LearnSpell(3811);	//Expert
			e.Player.LearnSpell(10662);	//Artisan
			/*Mining*///not work
			e.Player.LearnSpell(2575);	//Apprentice
			e.Player.LearnSpell(2576);	//Journeyman
			e.Player.LearnSpell(3564);	//Expert
			e.Player.LearnSpell(10248);	//Artisan
			/*Skinning*/
			e.Player.LearnSpell(8613);	//Apprentice
			e.Player.LearnSpell(8617);	//Journeyman
			e.Player.LearnSpell(8618);	//Expert
			e.Player.LearnSpell(10768);	//Artisan
			/*Tailoring*/
			e.Player.LearnSpell(3908);	//Apprentice
			e.Player.LearnSpell(3909);	//Journeyman
			e.Player.LearnSpell(3910);	//Expert
			e.Player.LearnSpell(12180);	//Artisan
			#endregion
			#region SECONDARY
			/*Cooking*/
			e.Player.LearnSpell(2550);	//Apprentice
			e.Player.LearnSpell(3102);	//Journeyman
			e.Player.LearnSpell(3413);	//Expert
			e.Player.LearnSpell(18260);	//Artisan
			/*First Aid*/
			e.Player.LearnSpell(3273);	//Apprentice
			e.Player.LearnSpell(3274);	//Journeyman
			e.Player.LearnSpell(7924);	//Expert
			e.Player.LearnSpell(10846);	//Artisan
			/*Fishing*/
			e.Player.LearnSpell(7620);	//Apprentice
			e.Player.LearnSpell(7731);	//Journeyman
			e.Player.LearnSpell(7732);	//Expert
			e.Player.LearnSpell(18248);	//Artisan
			#endregion
			#endregion
			e.Player.EarnXP(3608800); 
			switch(e.Player.Classe) 
			{ 
					#region Druid
				case Classes.Druid:
					#region SPELLS
					#region Balance
					/*Barkskin*/
					e.Player.LearnSpell(22812);
					/*Entangling Roots*/
					e.Player.LearnSpell(339);	//1
					e.Player.LearnSpell(1062);	//2
					e.Player.LearnSpell(5195);	//3
					e.Player.LearnSpell(5196);	//4
					e.Player.LearnSpell(9852);	//5
					e.Player.LearnSpell(9853);	//6
					/*Faerie Fire*/
					e.Player.LearnSpell(770);	//1
					e.Player.LearnSpell(778);	//2
					e.Player.LearnSpell(9749);	//3
					e.Player.LearnSpell(9907);	//4
					/*Hibernate*/
					e.Player.LearnSpell(2637);	//1
					e.Player.LearnSpell(18657);	//2
					e.Player.LearnSpell(18658);	//3
					/*Hurricane*/
					e.Player.LearnSpell(17401);	//2
					e.Player.LearnSpell(17402);	//3
					/*Moonfire*/
					e.Player.LearnSpell(8921);	//1
					e.Player.LearnSpell(8924);	//2
					e.Player.LearnSpell(8925);	//3
					e.Player.LearnSpell(8926);	//4
					e.Player.LearnSpell(8927);	//5
					e.Player.LearnSpell(8928);	//6
					e.Player.LearnSpell(8929);	//7
					e.Player.LearnSpell(9833);	//8
					e.Player.LearnSpell(9834);	//9
					e.Player.LearnSpell(9835);	//10
					/*Nature's Grasp*/
					e.Player.LearnSpell(16810);	//2
					e.Player.LearnSpell(16811);	//3
					e.Player.LearnSpell(16812);	//4
					e.Player.LearnSpell(16813);	//5
					/*Soothe Animal*/
					e.Player.LearnSpell(2908);	//1
					e.Player.LearnSpell(8955);	//2
					e.Player.LearnSpell(9901);	//3
					/*Starfire*/
					e.Player.LearnSpell(2912);	//1
					e.Player.LearnSpell(8949);	//2
					e.Player.LearnSpell(8950);	//3
					e.Player.LearnSpell(8951);	//4
					e.Player.LearnSpell(9875);	//5
					e.Player.LearnSpell(9876);	//6
					/*Teleport: Moonglade*/
					e.Player.LearnSpell(18960);
					/*Thorns*/
					e.Player.LearnSpell(467);	//1
					e.Player.LearnSpell(782);	//2
					e.Player.LearnSpell(1075);	//3
					e.Player.LearnSpell(8914);	//4
					e.Player.LearnSpell(9756);	//5
					e.Player.LearnSpell(9910);	//6
					/*Wrath*/
					e.Player.LearnSpell(5177);	//2
					e.Player.LearnSpell(5178);	//3
					e.Player.LearnSpell(5179);	//4
					e.Player.LearnSpell(5180);	//5
					e.Player.LearnSpell(6780);	//6
					e.Player.LearnSpell(8905);	//7
					e.Player.LearnSpell(9912);	//8
					#endregion
					#region Feral Combat
					/*Aquatic Form*/
					e.Player.LearnSpell(1066);
					/*Aquatic Form (Passive)*/
					e.Player.LearnSpell(5421);
					/*Bash*/
					e.Player.LearnSpell(5211);	//1
					e.Player.LearnSpell(6798);	//2
					e.Player.LearnSpell(8983);	//3
					/*Bear Form Shapeshift*/
					e.Player.LearnSpell(5487);
					/*Cat Form Shapeshift*/
					e.Player.LearnSpell(768);
					/*Challenging Roar*/
					e.Player.LearnSpell(5209);
					/*Claw*/
					e.Player.LearnSpell(1082);	//1
					e.Player.LearnSpell(3029);	//2
					e.Player.LearnSpell(5201);	//3
					e.Player.LearnSpell(9849);	//4
					e.Player.LearnSpell(9850);	//5
					/*Cower*/
					e.Player.LearnSpell(8998);	//1
					e.Player.LearnSpell(9000);	//2
					e.Player.LearnSpell(9892);	//3
					/*Dash*/
					e.Player.LearnSpell(1850);	//1
					e.Player.LearnSpell(9821);	//2
					/*Demoralizing Roar*/
					e.Player.LearnSpell(99);	//1
					e.Player.LearnSpell(1735);	//2
					e.Player.LearnSpell(9490);	//3
					e.Player.LearnSpell(9747);	//4
					/*Dire Bear Form Shapeshift*/
					e.Player.LearnSpell(9634);
					/*Enrage*/
					e.Player.LearnSpell(5229);
					/*Faerie Fire (Bear)*/
					e.Player.LearnSpell(17387);	//2
					e.Player.LearnSpell(17388);	//3
					e.Player.LearnSpell(17389);	//4
					/*Faerie Fire (Cat)*/
					e.Player.LearnSpell(17390);	//2
					e.Player.LearnSpell(17391);	//3
					e.Player.LearnSpell(17392);	//4
					/*Feline Grace Passive*/
					e.Player.LearnSpell(20719);
					/*Ferocious Bite*/
					e.Player.LearnSpell(22568);	//1
					e.Player.LearnSpell(22827);	//2
					e.Player.LearnSpell(22828);	//3
					e.Player.LearnSpell(22829);	//4
					/*Frenzied Regeneration*/
					e.Player.LearnSpell(22842);	//1
					e.Player.LearnSpell(22895);	//2
					e.Player.LearnSpell(22896);	//3
					/*Growl*/
					e.Player.LearnSpell(6795);
					/*Maul*/
					e.Player.LearnSpell(6807);	//1
					e.Player.LearnSpell(6808);	//2
					e.Player.LearnSpell(6809);	//3
					e.Player.LearnSpell(8972);	//4
					e.Player.LearnSpell(9745);	//5
					e.Player.LearnSpell(9880);	//6
					e.Player.LearnSpell(9881);	//7
					/*Pounce*/
					e.Player.LearnSpell(9005);	//1
					e.Player.LearnSpell(9823);	//2
					e.Player.LearnSpell(9827);	//3
					/*Prowl*/
					e.Player.LearnSpell(5215);	//1
					e.Player.LearnSpell(6783);	//2
					e.Player.LearnSpell(9913);	//3
					/*Rake*/
					e.Player.LearnSpell(1822);	//1
					e.Player.LearnSpell(1823);	//2
					e.Player.LearnSpell(1824);	//3
					e.Player.LearnSpell(9904);	//4
					/*Ravage*/
					e.Player.LearnSpell(6785);	//1
					e.Player.LearnSpell(6787);	//2
					e.Player.LearnSpell(9866);	//3
					e.Player.LearnSpell(9867);	//4
					/*Rip*/
					e.Player.LearnSpell(1079);	//1
					e.Player.LearnSpell(9492);	//2
					e.Player.LearnSpell(9493);	//3
					e.Player.LearnSpell(9752);	//4
					e.Player.LearnSpell(9894);	//5
					e.Player.LearnSpell(9896);	//6
					/*Shred*/
					e.Player.LearnSpell(5221);	//1
					e.Player.LearnSpell(6800);	//2
					e.Player.LearnSpell(8992);	//3
					e.Player.LearnSpell(9829);	//4
					e.Player.LearnSpell(9830);	//5
					/*Swipe*/
					e.Player.LearnSpell(779);	//1
					e.Player.LearnSpell(780);	//2
					e.Player.LearnSpell(769);	//3
					e.Player.LearnSpell(9754);	//4
					e.Player.LearnSpell(9908);	//5
					/*Tiger's Fury*/
					e.Player.LearnSpell(5217);	//1
					e.Player.LearnSpell(6793);	//2
					e.Player.LearnSpell(9845);	//3
					e.Player.LearnSpell(9846);	//4
					/*Track Humanoids*/
					e.Player.LearnSpell(5225);
					/*Travel Form Shapeshift*/
					e.Player.LearnSpell(783);
					/*Tree Form Shapeshift*/
					e.Player.LearnSpell(775);
					#endregion
					#region Restoration
					/*Abolish Poison*/
					e.Player.LearnSpell(2893);
					/*Cure Poison*/
					e.Player.LearnSpell(8946);
					/*Gift of the Wild*/
					e.Player.LearnSpell(21849);	//1
					e.Player.LearnSpell(21850);	//2
					/*Healing Touch*/
					e.Player.LearnSpell(5186);	//2
					e.Player.LearnSpell(5187);	//3
					e.Player.LearnSpell(5188);	//4
					e.Player.LearnSpell(5189);	//5
					e.Player.LearnSpell(6778);	//6
					e.Player.LearnSpell(8903);	//7
					e.Player.LearnSpell(9758);	//8
					e.Player.LearnSpell(9888);	//9
					e.Player.LearnSpell(9889);	//10
					/*Mark of the Wild*/
					e.Player.LearnSpell(1126);	//1
					e.Player.LearnSpell(5232);	//2
					e.Player.LearnSpell(6756);	//3
					e.Player.LearnSpell(5234);	//4
					e.Player.LearnSpell(8907);	//5
					e.Player.LearnSpell(9884);	//6
					e.Player.LearnSpell(9885);	//7
					/*Rebirth*/
					e.Player.LearnSpell(20484);	//1
					e.Player.LearnSpell(20739);	//2
					e.Player.LearnSpell(20742);	//3
					e.Player.LearnSpell(20747);	//4
					e.Player.LearnSpell(20748);	//5
					/*Regrowth*/
					e.Player.LearnSpell(8936);	//1
					e.Player.LearnSpell(8938);	//2
					e.Player.LearnSpell(8939);	//3
					e.Player.LearnSpell(8940);	//4
					e.Player.LearnSpell(8941);	//5
					e.Player.LearnSpell(9750);	//6
					e.Player.LearnSpell(9856);	//7
					e.Player.LearnSpell(9857);	//8
					e.Player.LearnSpell(9858);	//9
					/*Rejuvenation*/
					e.Player.LearnSpell(774);	//1
					e.Player.LearnSpell(1058);	//2
					e.Player.LearnSpell(1430);	//3
					e.Player.LearnSpell(2090);	//4
					e.Player.LearnSpell(2091);	//5
					e.Player.LearnSpell(3627);	//6
					e.Player.LearnSpell(8910);	//7
					e.Player.LearnSpell(9839);	//8
					e.Player.LearnSpell(9840);	//9
					e.Player.LearnSpell(9841);	//10
					/*Remove Curse*/
					e.Player.LearnSpell(2782);
					/*Tranquility*/
					e.Player.LearnSpell(740);	//1
					e.Player.LearnSpell(8918);	//2
					e.Player.LearnSpell(9862);	//3
					e.Player.LearnSpell(9863);	//4
					#endregion
					#endregion
					#region TALENTS
					#region Balance
					/*Hurricane*/
					e.Player.LearnSpell(16914);
					/*Improved Entangling Roots*/
					e.Player.LearnSpell(16920);
					/*Improved Moonfire*/
					e.Player.LearnSpell(16825);
					/*Improved Nature's Grasp*/
					e.Player.LearnSpell(17249);
					/*Improved Starfire*/
					e.Player.LearnSpell(16926);
					/*Improved Thorns*/
					e.Player.LearnSpell(16842);
					/*Improved Wrath*/
					e.Player.LearnSpell(16818);
					/*Moonfury*/
					e.Player.LearnSpell(16901);
					/*Moonglow*/
					e.Player.LearnSpell(16849);
					/*Nature's Grace*/
					e.Player.LearnSpell(16880);
					/*Nature's Grasp*/
					e.Player.LearnSpell(16689);
					/*Nature's Reach*/
					e.Player.LearnSpell(16820);
					/*Omen of Clarity*/
					e.Player.LearnSpell(16864);
					/*Swiftshifting*/
					e.Player.LearnSpell(16835);
					/*Vengeance*/
					e.Player.LearnSpell(16913);
					/*Weapon Balance*/
					e.Player.LearnSpell(16906);
					#endregion
					#region Feral Combat
					/*Blood Frenzy*/
					e.Player.LearnSpell(16957);
					/*Faerie Fire (Bear)*/
					e.Player.LearnSpell(16855);
					/*Faerie Fire (Cat)*/
					e.Player.LearnSpell(16857);
					/*Feline Swiftness*/
					e.Player.LearnSpell(17002);
					/*Feral Charge*/
					e.Player.LearnSpell(16979);
					/*Ferocity*/
					e.Player.LearnSpell(16938);
					/*Improved Bash*/
					e.Player.LearnSpell(16941);
					/*Improved Demoralizing Roar*/
					e.Player.LearnSpell(16862);
					/*Improved Pounce*/
					e.Player.LearnSpell(17001);
					/*Improved Prowl*/
					e.Player.LearnSpell(16951);
					/*Improved Ravage*/
					e.Player.LearnSpell(16999);
					/*Improved Shred*/
					e.Player.LearnSpell(16968);
					/*Predatory Strikes*/
					e.Player.LearnSpell(16977);
					/*Primal Fury*/
					e.Player.LearnSpell(16964);
					/*Primal Instinct*/
					e.Player.LearnSpell(17007);
					/*Sharpened Claws*/
					e.Player.LearnSpell(16946);
					/*Strength of the Wild*/
					e.Player.LearnSpell(17006);
					/*Thick Hide*/
					e.Player.LearnSpell(16933);
					#endregion
					#region Restoration
					/*Combat Endurance*/
					e.Player.LearnSpell(17431);
					/*Furor*/
					e.Player.LearnSpell(17061);
					/*Gift of Nature*/
					e.Player.LearnSpell(17104);
					/*Improved Enrage*/
					e.Player.LearnSpell(17082);
					/*Improved Healing Touch*/
					e.Player.LearnSpell(17073);
					/*Improved Mark of the Wild*/
					e.Player.LearnSpell(17055);
					/*Improved Regrowth*/
					e.Player.LearnSpell(17078);
					/*Improved Rejuvenation*/
					e.Player.LearnSpell(17115);
					/*Improved Tranquility*/
					e.Player.LearnSpell(17124);
					/*Innervate*/
					e.Player.LearnSpell(18562);
					/*Intensity*/
					e.Player.LearnSpell(17103);
					/*Nature's Focus*/
					e.Player.LearnSpell(17068);
					/*Nature's Swiftness*/
					e.Player.LearnSpell(17116);
					/*Reflection*/
					e.Player.LearnSpell(17110);
					/*Subtlety*/
					e.Player.LearnSpell(17122);
					#endregion
					#endregion
					break;
					#endregion
					#region Hunter
				case Classes.Hunter:
					#region SPELLS
					#region Beast Mastery
					/*Aspect of the Beast*/
					e.Player.LearnSpell(13161);
					/*Aspect of the Cheetah*/
					e.Player.LearnSpell(5118);
					/*Aspect of the Hawk*/
					e.Player.LearnSpell(13165);	//1
					e.Player.LearnSpell(14318);	//2
					e.Player.LearnSpell(14319);	//3
					e.Player.LearnSpell(14320);	//4
					e.Player.LearnSpell(14321);	//5
					e.Player.LearnSpell(14322);	//6
					/*Aspect of the Monkey*/
					e.Player.LearnSpell(13163);
					/*Aspect of the Pack*/
					e.Player.LearnSpell(13159);
					/*Aspect of the Wild*/
					e.Player.LearnSpell(20043);	//1
					e.Player.LearnSpell(20190);	//2
					/*Beast Lore*/
					e.Player.LearnSpell(1462);
					/*Beast Training*/
					e.Player.LearnSpell(5149);
					/*Call Pet*/
					e.Player.LearnSpell(883);
					/*Dismiss Pet*/
					e.Player.LearnSpell(2641);
					/*Eagle Eye*/
					e.Player.LearnSpell(6197);
					/*Eyes of the Beast*/
					e.Player.LearnSpell(1002);
					/*Feed Pet*/
					e.Player.LearnSpell(6991);
					/*Mend Pet*/
					e.Player.LearnSpell(136);	//1
					e.Player.LearnSpell(3111);	//2
					e.Player.LearnSpell(3661);	//3
					e.Player.LearnSpell(3662);	//4
					e.Player.LearnSpell(13542);	//5
					e.Player.LearnSpell(13543);	//6
					e.Player.LearnSpell(13544);	//7
					/*Revive Pet*/
					e.Player.LearnSpell(982);
					/*Scare Beast*/
					e.Player.LearnSpell(1513);	//1
					e.Player.LearnSpell(14326);	//2
					e.Player.LearnSpell(14327);	//3
					/*Spirit Bond*/
					e.Player.LearnSpell(20895);	//2
					e.Player.LearnSpell(20896);	//3
					/*Tame Beast*/
					e.Player.LearnSpell(1515);
					/*Tranquilizing Shot*/
					e.Player.LearnSpell(19801);
					#endregion
					#region Marksmanship
					/*Auto Shot*/
					e.Player.LearnSpell(75);
					/*Arcane Shot*/
					e.Player.LearnSpell(3044);	//1
					e.Player.LearnSpell(14281);	//2
					e.Player.LearnSpell(14282);	//3
					e.Player.LearnSpell(14283);	//4
					e.Player.LearnSpell(14284);	//5
					e.Player.LearnSpell(14285);	//6
					e.Player.LearnSpell(14286);	//7
					e.Player.LearnSpell(14287);	//8
					/*Concussive Shot*/
					e.Player.LearnSpell(5116);
					/*Distracting Shot*/
					e.Player.LearnSpell(20736);	//1
					e.Player.LearnSpell(14274);	//2
					e.Player.LearnSpell(15629);	//3
					e.Player.LearnSpell(15630);	//4
					e.Player.LearnSpell(15631);	//5
					e.Player.LearnSpell(15632);	//6
					/*Flare*/
					e.Player.LearnSpell(1543);
					/*Hunter's Mark*/
					e.Player.LearnSpell(1130);	//1
					e.Player.LearnSpell(14323);	//2
					e.Player.LearnSpell(14324);	//3
					e.Player.LearnSpell(14325);	//4
					/*Multi-Shot*/
					e.Player.LearnSpell(2643);	//1
					e.Player.LearnSpell(14288);	//2
					e.Player.LearnSpell(14289);	//3
					e.Player.LearnSpell(14290);	//4
					/*Rapid Fire*/
					e.Player.LearnSpell(3045);
					/*Scorpid Sting*/
					e.Player.LearnSpell(3043);	//1
					e.Player.LearnSpell(14275);	//2
					e.Player.LearnSpell(14276);	//3
					e.Player.LearnSpell(14277);	//4
					/*Serpent Sting*/
					e.Player.LearnSpell(1978);	//1
					e.Player.LearnSpell(13549);	//2
					e.Player.LearnSpell(13550);	//3
					e.Player.LearnSpell(13551);	//4
					e.Player.LearnSpell(13552);	//5
					e.Player.LearnSpell(13553);	//6
					e.Player.LearnSpell(13554);	//7
					e.Player.LearnSpell(13555);	//8
					/*Viper Sting*/
					e.Player.LearnSpell(3034);	//1
					e.Player.LearnSpell(14279);	//2
					e.Player.LearnSpell(14280);	//3
					/*Volley*/
					e.Player.LearnSpell(1510);	//1
					e.Player.LearnSpell(14294);	//2
					e.Player.LearnSpell(14295);	//3
					#endregion
					#region Survival
					/*Disengage*/
					e.Player.LearnSpell(781);	//1
					e.Player.LearnSpell(14272);	//2
					e.Player.LearnSpell(14273);	//3
					/*Explosive Trap*/
					e.Player.LearnSpell(13813);	//1
					e.Player.LearnSpell(14316);	//2
					e.Player.LearnSpell(14317);	//3
					/*Feign Death*/
					e.Player.LearnSpell(5384);
					/*Freezing Trap*/
					e.Player.LearnSpell(1499);	//1
					e.Player.LearnSpell(14310);	//2
					e.Player.LearnSpell(14311);	//3
					/*Frost Trap*/
					e.Player.LearnSpell(13809);
					/*Immolation Trap*/
					e.Player.LearnSpell(13795);	//1
					e.Player.LearnSpell(14302);	//2
					e.Player.LearnSpell(14303);	//3
					e.Player.LearnSpell(14304);	//4
					e.Player.LearnSpell(14305);	//5
					/*Mongoose Bite*/
					e.Player.LearnSpell(1495);	//1
					e.Player.LearnSpell(14269);	//2
					e.Player.LearnSpell(14270);	//3
					e.Player.LearnSpell(14271);	//4
					/*Raptor Strike*/
					e.Player.LearnSpell(2973);	//1
					e.Player.LearnSpell(14260);	//2
					e.Player.LearnSpell(14261);	//3
					e.Player.LearnSpell(14262);	//4
					e.Player.LearnSpell(14263);	//5
					e.Player.LearnSpell(14264);	//6
					e.Player.LearnSpell(14265);	//7
					e.Player.LearnSpell(14266);	//8
					/*Track Beasts*/
					e.Player.LearnSpell(1494);
					/*Track Demons*/
					e.Player.LearnSpell(19878);
					/*Track Dragonkin*/
					e.Player.LearnSpell(19879);
					/*Track Elementals*/
					e.Player.LearnSpell(19880);
					/*Track Giants*/
					e.Player.LearnSpell(19882);
					/*Track Hidden*/
					e.Player.LearnSpell(19885);
					/*Track Humanoids*/
					e.Player.LearnSpell(19883);
					/*Track Undead*/
					e.Player.LearnSpell(19884);
					/*Wing Clip*/
					e.Player.LearnSpell(2974);	//1
					e.Player.LearnSpell(14267);	//2
					e.Player.LearnSpell(14268);	//3
					#endregion
					#endregion
					#region TALENTS
					#region Beast Mastery
					/*Bestial Discipline*/
					e.Player.LearnSpell(19595);
					/*Bestial Swiftness*/
					e.Player.LearnSpell(19596);
					/*Endurance Training*/
					e.Player.LearnSpell(19587);
					/*Ferocity*/
					e.Player.LearnSpell(19602);
					/*Frenzy*/
					e.Player.LearnSpell(19625);
					/*Improved Aspect of the Hawk*/
					e.Player.LearnSpell(19556);
					/*Improved Aspect of the Monkey*/
					e.Player.LearnSpell(19551);
					/*Improved Eyes of the Beast*/
					e.Player.LearnSpell(19558);
					/*Improved Mend Pet*/
					e.Player.LearnSpell(19573);
					/*Improved Revive Pet*/
					e.Player.LearnSpell(19575);
					/*Intimidation*/
					e.Player.LearnSpell(19577);
					/*Pathfinding*/
					e.Player.LearnSpell(19563);
					/*Spirit Bond*/
					e.Player.LearnSpell(19578);
					/*Thick Hide*/
					e.Player.LearnSpell(19613);
					/*Unleashed Fury*/
					e.Player.LearnSpell(19620);
					#endregion
					#region Marksmanship
					/*Aimed Shot*/
					e.Player.LearnSpell(19434);
					/*Barrage*/
					e.Player.LearnSpell(19462);
					/*Efficiency*/
					e.Player.LearnSpell(19420);
					/*Hawk Eye*/
					e.Player.LearnSpell(19500);
					/*Improved Arcane Shot*/
					e.Player.LearnSpell(19458);
					/*Improved Concussive Shot*/
					e.Player.LearnSpell(19415);
					/*Improved Hunter's Mark*/
					e.Player.LearnSpell(19425);
					/*Improved Serpent Sting*/
					e.Player.LearnSpell(19468);
					/*Improved Scorpid Sting*/
					e.Player.LearnSpell(19494);
					/*Lethal Shots*/
					e.Player.LearnSpell(19431);
					/*Mortal Shots*/
					e.Player.LearnSpell(19490);
					/*Ranged Weapon Specialization*/
					e.Player.LearnSpell(19511);
					/*Scatter Shot*/
					e.Player.LearnSpell(19503);
					/*Trueshot Aura*/
					e.Player.LearnSpell(19506);
					#endregion
					#region Survival
					/*Counterattack*/
					e.Player.LearnSpell(19306);
					/*Deflection*/
					e.Player.LearnSpell(19300);
					/*Deterrence*/
					e.Player.LearnSpell(19263);
					/*Entrapment*/
					e.Player.LearnSpell(19390);
					/*Improved Disengage*/
					e.Player.LearnSpell(19294);
					/*Improved Explosive Trap*/
					e.Player.LearnSpell(19379);
					/*Improved Freezing Trap*/
					e.Player.LearnSpell(19288);
					/*Improved Frost Trap*/
					e.Player.LearnSpell(19377);
					/*Improved Immolation Trap*/
					e.Player.LearnSpell(19248);
					/*Improved Mongoose Bite*/
					e.Player.LearnSpell(19259);
					/*Improved Raptor Strike*/
					e.Player.LearnSpell(19165);
					/*Improved Wing Clip*/
					e.Player.LearnSpell(19235);
					/*Lacerate*/
					e.Player.LearnSpell(19386);
					/*Lightning Reflexes*/
					e.Player.LearnSpell(19181);
					/*Melee Specialization*/
					e.Player.LearnSpell(19385);
					/*Precision*/
					e.Player.LearnSpell(19155);
					/*Savage Strikes*/
					e.Player.LearnSpell(19375);
					#endregion
					#endregion
					break;
					#endregion
					#region Mage
				case Classes.Mage:
					#region SPELLS
					#region ARCANE
					/*Amplify Magic*/
					e.Player.LearnSpell(1008);	//1
					e.Player.LearnSpell(8455);	//2
					e.Player.LearnSpell(10169);	//3
					e.Player.LearnSpell(10170);	//4
					/*Arcane Brilliance*/
					e.Player.LearnSpell(23028);
					/*Arcane Explosion*/
					e.Player.LearnSpell(1449);	//1
					e.Player.LearnSpell(8437);	//2
					e.Player.LearnSpell(8438);	//3
					e.Player.LearnSpell(8439);	//4
					e.Player.LearnSpell(10201);	//5
					e.Player.LearnSpell(10202);	//6
					/*Arcane Intellect*/
					e.Player.LearnSpell(1460);	//2
					e.Player.LearnSpell(1461);	//3
					e.Player.LearnSpell(10156);	//4
					e.Player.LearnSpell(10157);	//5
					/*Arcane Missiles*/
					e.Player.LearnSpell(5143);	//1
					e.Player.LearnSpell(5144);	//2
					e.Player.LearnSpell(5145);	//3
					e.Player.LearnSpell(8416);	//4
					e.Player.LearnSpell(8417);	//5
					e.Player.LearnSpell(10211);	//6
					e.Player.LearnSpell(10212);	//7
					/*Blink*/
					e.Player.LearnSpell(1953);
					/*Conjure Food*/
					//e.Player.LearnSpell(587);	//1
					e.Player.LearnSpell(597);	//2
					e.Player.LearnSpell(990);	//3
					e.Player.LearnSpell(6129);	//4
					e.Player.LearnSpell(10144);	//5
					e.Player.LearnSpell(10145);	//6
					/*Conjure Mana Agate*/
					e.Player.LearnSpell(759);
					/*Conjure Mana Citrine*/
					e.Player.LearnSpell(10053);
					/*Conjure Mana Jade*/
					e.Player.LearnSpell(3552);
					/*Conjure Mana Ruby*/
					e.Player.LearnSpell(10054);
					/*Conjure Water*/
					e.Player.LearnSpell(5505);	//2
					e.Player.LearnSpell(5506);	//3
					e.Player.LearnSpell(6127);	//4
					e.Player.LearnSpell(10138);	//5
					e.Player.LearnSpell(10139);	//6
					e.Player.LearnSpell(10140);	//7
					/*Counterspell*/
					e.Player.LearnSpell(2139);
					/*Dampen Magic*/
					e.Player.LearnSpell(604);	//1
					e.Player.LearnSpell(8450);	//2
					e.Player.LearnSpell(8451);	//3
					e.Player.LearnSpell(10173);	//4
					e.Player.LearnSpell(10174);	//5
					/*Detect Magic*/
					e.Player.LearnSpell(2855);
					/*Mage Armor*/
					e.Player.LearnSpell(6117);	//1
					e.Player.LearnSpell(22782);	//2
					e.Player.LearnSpell(22783);	//3
					/*Mana Shield*/
					e.Player.LearnSpell(1463);	//1
					e.Player.LearnSpell(8494);	//2
					e.Player.LearnSpell(8495);	//3
					e.Player.LearnSpell(10191);	//4
					e.Player.LearnSpell(10192);	//5
					e.Player.LearnSpell(10193);	//6
					/*Polymorph*/
					e.Player.LearnSpell(118);	//1
					e.Player.LearnSpell(12824);	//2
					e.Player.LearnSpell(12825);	//3
					e.Player.LearnSpell(12826);	//4
					/*Remove Lesser Curse*/
					e.Player.LearnSpell(475);
					/*Slow Fall*/
					e.Player.LearnSpell(130);
				switch (e.Player.Faction)
				{
					case Factions.Alliance:
						/*Portal: Darnassus*/
						e.Player.LearnSpell(11419);
						/*Portal: Ironforge*/
						e.Player.LearnSpell(11416);
						/*Portal: Stormwind*/
						e.Player.LearnSpell(10059);
						/*Teleport: Darnassus*/
						e.Player.LearnSpell(3565);
						/*Teleport: Ironforge*/
						e.Player.LearnSpell(3562);
						/*Teleport: Stormwind*/
						e.Player.LearnSpell(3561);
						break;
					case Factions.Horde:
						/*Portal: Orgrimmar*/
						e.Player.LearnSpell(11417);
						/*Portal: Thunder Bluff*/
						e.Player.LearnSpell(11420);
						/*Portal: Undercity*/
						e.Player.LearnSpell(11418);
						/*Teleport: Orgrimmar*/
						e.Player.LearnSpell(3567);
						/*Teleport: Thunder Bluff*/
						e.Player.LearnSpell(3566);
						/*Teleport: Undercity*/
						e.Player.LearnSpell(3563);
						break;
				}
					#endregion
					#region FIRE
					/*Blast Wave*/
					e.Player.LearnSpell(13018);	//2
					e.Player.LearnSpell(13019);	//3
					e.Player.LearnSpell(13020);	//4
					e.Player.LearnSpell(13021);	//5
					/*Fire Ward*/
					e.Player.LearnSpell(543);	//1
					e.Player.LearnSpell(8457);	//2
					e.Player.LearnSpell(8458);	//3
					e.Player.LearnSpell(10223);	//4
					e.Player.LearnSpell(10225);	//5
					/*Fireball*/
					e.Player.LearnSpell(143);	//2
					e.Player.LearnSpell(145);	//3
					e.Player.LearnSpell(3140);	//4
					e.Player.LearnSpell(8400);	//5
					e.Player.LearnSpell(8401);	//6
					e.Player.LearnSpell(8402);	//7
					e.Player.LearnSpell(10148);	//8
					e.Player.LearnSpell(10149);	//9
					e.Player.LearnSpell(10150);	//10
					e.Player.LearnSpell(10151);	//11
					/*Fire Blast*/
					e.Player.LearnSpell(2136);	//1
					e.Player.LearnSpell(2137);	//2
					e.Player.LearnSpell(2138);	//3
					e.Player.LearnSpell(8412);	//4
					e.Player.LearnSpell(8413);	//5
					e.Player.LearnSpell(10197);	//6
					e.Player.LearnSpell(10199);	//7
					/*Flamestrike*/
					e.Player.LearnSpell(2120);	//1
					e.Player.LearnSpell(2121);	//2
					e.Player.LearnSpell(8422);	//3
					e.Player.LearnSpell(8423);	//4
					e.Player.LearnSpell(10215);	//5
					e.Player.LearnSpell(10216);	//6
					/*Pyroblast*/
					e.Player.LearnSpell(12505);	//2
					e.Player.LearnSpell(12522);	//3
					e.Player.LearnSpell(12523);	//4
					e.Player.LearnSpell(12524);	//5
					e.Player.LearnSpell(12525);	//6
					e.Player.LearnSpell(12526);	//7
					e.Player.LearnSpell(18809);	//8
					/*Scorch*/
					e.Player.LearnSpell(2948);	//1
					e.Player.LearnSpell(8444);	//2
					e.Player.LearnSpell(8445);	//3
					e.Player.LearnSpell(8446);	//4
					e.Player.LearnSpell(10205);	//5
					e.Player.LearnSpell(10206);	//6
					e.Player.LearnSpell(10207);	//7

					#endregion
					#region FROST
					/*Blizzard*/
					e.Player.LearnSpell(10);	//1
					e.Player.LearnSpell(6141);	//2
					e.Player.LearnSpell(8427);	//3
					e.Player.LearnSpell(10185);	//4
					e.Player.LearnSpell(10186);	//5
					e.Player.LearnSpell(10187);	//6
					/*Chilled*/
					e.Player.LearnSpell(12484);	//1
					e.Player.LearnSpell(12485);	//2
					e.Player.LearnSpell(12486);	//3
					/*Cone of Cold*/
					e.Player.LearnSpell(120);	//1
					e.Player.LearnSpell(8492);	//2
					e.Player.LearnSpell(10159);	//3
					e.Player.LearnSpell(10160);	//4
					e.Player.LearnSpell(10161);	//5
					/*Frost Armor*/
					e.Player.LearnSpell(7300);	//2
					e.Player.LearnSpell(7301);	//3
					/*Frost Nova*/
					e.Player.LearnSpell(122);	//1
					e.Player.LearnSpell(865);	//2
					e.Player.LearnSpell(6131);	//3
					e.Player.LearnSpell(10230);	//4
					/*Frost Ward*/
					e.Player.LearnSpell(6143);	//1
					e.Player.LearnSpell(8461);	//2
					e.Player.LearnSpell(8462);	//3
					e.Player.LearnSpell(10177);	//4
					/*Frostbolt*/
					e.Player.LearnSpell(205);	//2
					e.Player.LearnSpell(837);	//3
					e.Player.LearnSpell(7322);	//4
					e.Player.LearnSpell(8406);	//5
					e.Player.LearnSpell(8407);	//6
					e.Player.LearnSpell(8408);	//7
					e.Player.LearnSpell(10179);	//8
					e.Player.LearnSpell(10180);	//9
					e.Player.LearnSpell(10181);	//10
					/*Ice Armor*/
					e.Player.LearnSpell(7302);	//1
					e.Player.LearnSpell(7320);	//2
					e.Player.LearnSpell(10219);	//3
					e.Player.LearnSpell(10220);	//4
					/*Ice Barrier*/
					e.Player.LearnSpell(11426);	//1
					e.Player.LearnSpell(13031);	//2
					e.Player.LearnSpell(13032);	//3
					e.Player.LearnSpell(13033);	//4
					#endregion
					#endregion
					#region TALENTS
					#region ARCANE
					/*Arcane Concentration*/
					e.Player.LearnSpell(12577);
					/*Arcane Focus*/
					e.Player.LearnSpell(12842);
					/*Arcane Instability*/
					e.Player.LearnSpell(15060);
					/*Arcane Meditation*/
					e.Player.LearnSpell(18466);
					/*Arcane Mind*/
					e.Player.LearnSpell(12502);
					/*Arcane Power*/
					e.Player.LearnSpell(12042);
					/*Arcane Subtlety*/
					e.Player.LearnSpell(12593);
					/*Evocation*/
					e.Player.LearnSpell(12051);
					/*Improved Arcane Explosion*/
					e.Player.LearnSpell(18468);
					/*Improved Arcane Missiles*/
					e.Player.LearnSpell(16770);
					/*Improved Counterspell*/
					e.Player.LearnSpell(12598);
					/*Improved Dampen Magic*/
					e.Player.LearnSpell(12606);
					/*Improved Mana Shield*/
					e.Player.LearnSpell(12605);
					/*Presence of Mind*/
					e.Player.LearnSpell(12043);
					/*Wand Specialization*/
					e.Player.LearnSpell(6088);
					#endregion
					#region FIRE
					/*Blast Wave*/
					e.Player.LearnSpell(11113);
					/*Burning Soul*/
					e.Player.LearnSpell(12352);
					/*Combustion*/
					e.Player.LearnSpell(11129);
					/*Critical Mass*/
					e.Player.LearnSpell(11368);
					/*Fire Power*/
					e.Player.LearnSpell(12400);
					/*Flame Throwing*/
					e.Player.LearnSpell(12353);
					/*Ignite*/
					e.Player.LearnSpell(12848);
					/*Impact*/
					e.Player.LearnSpell(12360);
					/*Improved Fireball*/
					e.Player.LearnSpell(12341);
					/*Improved Fire Blast*/
					e.Player.LearnSpell(12344);
					/*Improved Fire Ward*/
					e.Player.LearnSpell(13043);
					/*Improved Flamestrike*/
					e.Player.LearnSpell(12350);
					/*Improved Scorch*/
					e.Player.LearnSpell(12875);
					/*Incinerate*/
					e.Player.LearnSpell(18460);
					/*Pyroblast*/
					e.Player.LearnSpell(11366);
					#endregion
					#region FROST
					/*Arctic Reach*/
					e.Player.LearnSpell(16758);
					/*Cold Snap*/
					e.Player.LearnSpell(12472);
					/*Frost Channeling*/
					e.Player.LearnSpell(12519);
					/*Frostbite*/
					e.Player.LearnSpell(12499);
					/*Ice Barrier*/
					e.Player.LearnSpell(11426);
					/*Ice Block*/
					e.Player.LearnSpell(11958);
					/*Ice Shards*/
					e.Player.LearnSpell(15053);
					/*Improved Blizzard*/
					e.Player.LearnSpell(12488);
					/*Improved Cone of Cold*/
					e.Player.LearnSpell(12490);
					/*Improved Frostbolt*/
					e.Player.LearnSpell(16766);
					/*Improved Frost Nova*/
					e.Player.LearnSpell(12475);
					/*Improved Frost Ward*/
					e.Player.LearnSpell(11189);
					/*Permafrost*/
					e.Player.LearnSpell(12573);
					/*Piercing Ice*/
					e.Player.LearnSpell(12953);
					/*Shatter*/
					e.Player.LearnSpell(12985);
					/*Winter's Chill*/
					e.Player.LearnSpell(12580);
					#endregion
					#endregion			
					break;
					#endregion
					#region Paladin 
				case Classes.Paladin:
					#region SPELLS
					#region Holy
					/*Blessing of Light*/
					e.Player.LearnSpell(19977);	//1
					e.Player.LearnSpell(19978);	//2
					e.Player.LearnSpell(19979);	//3
					/*Blessing of Wisdom*/
					e.Player.LearnSpell(19742);	//1
					e.Player.LearnSpell(19850);	//2
					e.Player.LearnSpell(19852);	//3
					e.Player.LearnSpell(19853);	//4
					e.Player.LearnSpell(19854);	//5
					/*Cleanse*/
					e.Player.LearnSpell(4987);
					/*Exorcism*/
					e.Player.LearnSpell(879);	//1
					e.Player.LearnSpell(5614);	//2
					e.Player.LearnSpell(5615);	//3
					e.Player.LearnSpell(10312);	//4
					e.Player.LearnSpell(10313);	//5
					e.Player.LearnSpell(10314);	//6
					/*Flash of Light*/
					e.Player.LearnSpell(19750);	//1
					e.Player.LearnSpell(19939);	//2
					e.Player.LearnSpell(19940);	//3
					e.Player.LearnSpell(19941);	//4
					e.Player.LearnSpell(19942);	//5
					e.Player.LearnSpell(19943);	//6
					/*Holy Light*/
					e.Player.LearnSpell(639);	//2
					e.Player.LearnSpell(647);	//3
					e.Player.LearnSpell(1026);	//4
					e.Player.LearnSpell(1042);	//5
					e.Player.LearnSpell(3472);	//6
					e.Player.LearnSpell(10328);	//7
					e.Player.LearnSpell(10329);	//8
					/*Holy Wrath*/
					e.Player.LearnSpell(2812);	//1
					e.Player.LearnSpell(10318);	//2
					/*Lay on Hands*/
					e.Player.LearnSpell(633);	//1
					e.Player.LearnSpell(2800);	//2
					e.Player.LearnSpell(10310);	//3
					/*Purify*/
					e.Player.LearnSpell(1152);
					/*Redemption*/
					e.Player.LearnSpell(7328);	//1
					e.Player.LearnSpell(10322);	//2
					e.Player.LearnSpell(10324);	//3
					e.Player.LearnSpell(20772);	//4
					e.Player.LearnSpell(20773);	//5
					/*Seal of Light*/
					e.Player.LearnSpell(20165);	//1
					e.Player.LearnSpell(20347);	//2
					e.Player.LearnSpell(20348);	//3
					e.Player.LearnSpell(20349);	//4
					/*Seal of Righteousness*/
					e.Player.LearnSpell(20287);	//2
					e.Player.LearnSpell(20288);	//3
					e.Player.LearnSpell(20289);	//4
					e.Player.LearnSpell(20290);	//5
					e.Player.LearnSpell(20291);	//6
					e.Player.LearnSpell(20292);	//7
					e.Player.LearnSpell(20293);	//8
					/*Seal of Wisdom*/
					e.Player.LearnSpell(20166);	//1
					e.Player.LearnSpell(20356);	//2
					e.Player.LearnSpell(20357);	//3
					/*Sense Undead*/
					e.Player.LearnSpell(5502);
					/*Summon Charger*/
					e.Player.LearnSpell(23214);
					/*Summon Warhorse*/
					e.Player.LearnSpell(13819);
					/*Turn Undead*/
					e.Player.LearnSpell(2878);	//1
					e.Player.LearnSpell(5627);	//2
					e.Player.LearnSpell(10326);	//3

					#endregion
					#region Protection
					/*Blessing of Freedom*/
					e.Player.LearnSpell(1044);
					/*Blessing of Protection*/
					e.Player.LearnSpell(1022);	//1
					e.Player.LearnSpell(5599);	//2
					e.Player.LearnSpell(10278);	//3
					/*Blessing of Sacrifice*/
					e.Player.LearnSpell(6940);	//1
					e.Player.LearnSpell(20729);	//2
					/*Blessing of Salvation*/
					e.Player.LearnSpell(1038);
					/*Concentration Aura*/
					e.Player.LearnSpell(19746);
					/*Devotion Aura*/
					e.Player.LearnSpell(465);	//1
					e.Player.LearnSpell(10290);	//2
					e.Player.LearnSpell(643);	//3
					e.Player.LearnSpell(10291);	//4
					e.Player.LearnSpell(1032);	//5
					e.Player.LearnSpell(10292);	//6
					e.Player.LearnSpell(10293);	//7
					/*Divine Intervention*/
					e.Player.LearnSpell(19752);
					/*Divine Protection*/
					e.Player.LearnSpell(498);	//1
					e.Player.LearnSpell(5573);	//2
					/*Divine Shield*/
					e.Player.LearnSpell(642);	//1
					e.Player.LearnSpell(1020);	//2
					/*Fire Resistance Aura*/
					e.Player.LearnSpell(19891);	//1
					e.Player.LearnSpell(19899);	//2
					e.Player.LearnSpell(19900);	//3
					/*Frost Resistance Aura*/
					e.Player.LearnSpell(19888);	//1
					e.Player.LearnSpell(19897);	//2
					e.Player.LearnSpell(19898);	//3
					/*Seal of Fury*/
					e.Player.LearnSpell(20163);	//1
					e.Player.LearnSpell(20419);	//2
					e.Player.LearnSpell(20421);	//3
					e.Player.LearnSpell(20422);	//4
					e.Player.LearnSpell(20423);	//5
					/*Seal of Justice*/
					e.Player.LearnSpell(20164);
					/*Shadow Resistance Aura*/
					e.Player.LearnSpell(19876);	//1
					e.Player.LearnSpell(19895);	//2
					e.Player.LearnSpell(19896);	//3


					#endregion
					#region Retribution
					/*Blessing of Might*/
					e.Player.LearnSpell(19740);	//1
					e.Player.LearnSpell(19834);	//2
					e.Player.LearnSpell(19835);	//3
					e.Player.LearnSpell(19836);	//4
					e.Player.LearnSpell(19837);	//5
					e.Player.LearnSpell(19838);	//6
					/*Hammer of Justice*/
					e.Player.LearnSpell(853);	//1
					e.Player.LearnSpell(5588);	//2
					e.Player.LearnSpell(5589);	//3
					e.Player.LearnSpell(10308);	//4
					/*Judgement*/
					e.Player.LearnSpell(20271);
					/*Retribution Aura*/
					e.Player.LearnSpell(7294);	//1
					e.Player.LearnSpell(10298);	//2
					e.Player.LearnSpell(10299);	//3
					e.Player.LearnSpell(10300);	//4
					e.Player.LearnSpell(10301);	//5
					/*Seal of the Crusader*/
					e.Player.LearnSpell(21082);	//1
					e.Player.LearnSpell(20162);	//2
					e.Player.LearnSpell(20305);	//3
					e.Player.LearnSpell(20306);	//4
					e.Player.LearnSpell(20307);	//5
					e.Player.LearnSpell(20308);	//6
					
					#endregion
					#endregion
					#region TALENTS
					#region Holy
					/*Divine Favor*/
					e.Player.LearnSpell(20216);
					/*Divine Strength*/
					e.Player.LearnSpell(20266);
					/*Divine Wisdom*/
					e.Player.LearnSpell(20261);
					/*Holy Shock*/
					e.Player.LearnSpell(20473);
					/*Spiritual Focus*/
					e.Player.LearnSpell(20208);
					/*Illumination*/
					e.Player.LearnSpell(20215);
					/*Improved Blessing of Wisdom*/
					e.Player.LearnSpell(20248);
					/*Improved Concentration Aura*/
					e.Player.LearnSpell(20256);
					/*Improved Flash of Light*/
					e.Player.LearnSpell(20251);
					/*Improved Holy Light*/
					e.Player.LearnSpell(20239);
					/*Improved Lay on Hands*/
					e.Player.LearnSpell(20235);
					/*Improved Seal of Light*/
					e.Player.LearnSpell(20363);
					/*Improved Seal of Righteousness*/
					e.Player.LearnSpell(20332);
					/*Revelation*/
					e.Player.LearnSpell(20242);
					/*Sanctity Aura*/
					e.Player.LearnSpell(20218);
					#endregion
					#region Protection
					/*Blessing of Sanctuary*/
					e.Player.LearnSpell(20204);
					/*Holy Shield*/
					e.Player.LearnSpell(20169);
					/*Improved Blessing of Freedom*/
					e.Player.LearnSpell(20110);
					/*Improved Blessing of Protection*/
					e.Player.LearnSpell(20175);
					/*Improved Blessing of Salvation*/
					e.Player.LearnSpell(20195);
					/*Improved Devotion Aura*/
					e.Player.LearnSpell(20142);
					/*Improved Seal of Fury*/
					e.Player.LearnSpell(20472);
					/*Improved Seal of Justice*/
					e.Player.LearnSpell(20491);
					/*One-Handed Weapon Specialization*/
					e.Player.LearnSpell(20200);
					/*Reckoning*/
					e.Player.LearnSpell(20182);
					/*Redoubt*/
					e.Player.LearnSpell(20137);
					/*Repentance*/
					e.Player.LearnSpell(20066);
					/*Shield Specialization*/
					e.Player.LearnSpell(20152);
					/*Toughness*/
					e.Player.LearnSpell(20147);
					#endregion
					#region Retribution
					/*Anticipation*/
					e.Player.LearnSpell(20100);
					/*Benediction*/
					e.Player.LearnSpell(20105);
					/*Blessing of Kings*/
					e.Player.LearnSpell(20217);
					/*Consecration*/
					e.Player.LearnSpell(20116);
					/*Conviction*/
					e.Player.LearnSpell(20121);
					/*Deflection*/
					e.Player.LearnSpell(20064);
					/*Improved Blessing of Might*/
					e.Player.LearnSpell(20048);
					/*Improved Retribution Aura*/
					e.Player.LearnSpell(20095);
					/*Improved Seal of the Crusader*/
					e.Player.LearnSpell(20338);
					/*Precision*/
					e.Player.LearnSpell(20193);
					/*Seal of Command*/
					e.Player.LearnSpell(20375);
					/*Two-Handed Weapon Specialization*/
					e.Player.LearnSpell(20115);
					/*Vengeance*/
					e.Player.LearnSpell(20059);
					#endregion
					#endregion
					break; 
					#endregion
					#region Priest
				case Classes.Priest: 
					#region SPELLS
					#region Discipline
					/*Dispel Magic*/
					e.Player.LearnSpell(527);	//1
					e.Player.LearnSpell(988);	//2
					/*Divine Spirit*/
					e.Player.LearnSpell(14818);	//2
					e.Player.LearnSpell(14819);	//3
					/*Inner Fire*/
					e.Player.LearnSpell(588);	//1
					e.Player.LearnSpell(7128);	//2
					e.Player.LearnSpell(602);	//3
					e.Player.LearnSpell(1006);	//4
					e.Player.LearnSpell(10951);	//5
					e.Player.LearnSpell(10952);	//6
					/*Levitate*/
					e.Player.LearnSpell(1706);
					/*Mana Burn*/
					e.Player.LearnSpell(8129);	//1
					e.Player.LearnSpell(8131);	//2
					e.Player.LearnSpell(10874);	//3
					e.Player.LearnSpell(10875);	//4
					e.Player.LearnSpell(10876);	//5
					/*Power Word: Fortitude*/
					e.Player.LearnSpell(1243);	//1
					e.Player.LearnSpell(1244);	//2
					e.Player.LearnSpell(1245);	//3
					e.Player.LearnSpell(2791);	//4
					e.Player.LearnSpell(10937);	//5
					e.Player.LearnSpell(10938);	//6
					/*Power Word: Shield*/
					e.Player.LearnSpell(17);	//1
					e.Player.LearnSpell(592);	//2
					e.Player.LearnSpell(600);	//3
					e.Player.LearnSpell(3747);	//4
					e.Player.LearnSpell(6065);	//5
					e.Player.LearnSpell(6066);	//6
					e.Player.LearnSpell(10898);	//7
					e.Player.LearnSpell(10899);	//8
					e.Player.LearnSpell(10900);	//9
					e.Player.LearnSpell(10901);	//10
					/*Prayer of Fortitude*/
					e.Player.LearnSpell(21562);	//1
					e.Player.LearnSpell(21564);	//2
					/*Shackle Undead*/
					e.Player.LearnSpell(9484);	//1
					e.Player.LearnSpell(9485);	//2
					e.Player.LearnSpell(10955);	//3
				switch (e.Player.Race)
				{
					case Races.NightElf:
						/*Elune's Grace*/
						e.Player.LearnSpell(2651);	//1
						e.Player.LearnSpell(19289);	//2
						e.Player.LearnSpell(19291);	//3
						e.Player.LearnSpell(19292);	//4
						e.Player.LearnSpell(19293);	//5
						/*Starshards*/
						e.Player.LearnSpell(10797);	//1
						e.Player.LearnSpell(19296);	//2
						e.Player.LearnSpell(19299);	//3
						e.Player.LearnSpell(19302);	//4
						e.Player.LearnSpell(19303);	//5
						e.Player.LearnSpell(19304);	//6
						e.Player.LearnSpell(19305);	//7
						break;
					case Races.Human:
						/*Feedback*/
						e.Player.LearnSpell(13896);	//1
						e.Player.LearnSpell(19271);	//2
						e.Player.LearnSpell(19273);	//3
						e.Player.LearnSpell(19274);	//4
						e.Player.LearnSpell(19275);	//5
						break;
				}
					#endregion
					#region Holy
					/*Abolish Disease*/
					e.Player.LearnSpell(552);
					/*Cure Disease*/
					e.Player.LearnSpell(528);
					/*Flash Heal*/
					e.Player.LearnSpell(2061);	//1
					e.Player.LearnSpell(9472);	//2
					e.Player.LearnSpell(9473);	//3
					e.Player.LearnSpell(9474);	//4
					e.Player.LearnSpell(10915);	//5
					e.Player.LearnSpell(10916);	//6
					e.Player.LearnSpell(10917);	//7
					/*Greater Heal*/
					e.Player.LearnSpell(2060);	//1
					e.Player.LearnSpell(10963);	//2
					e.Player.LearnSpell(10964);	//3
					e.Player.LearnSpell(10965);	//4
					/*Heal*/
					e.Player.LearnSpell(2054);	//1
					e.Player.LearnSpell(2055);	//2
					e.Player.LearnSpell(6063);	//3
					e.Player.LearnSpell(6064);	//4
					/*Holy Fire*/
					e.Player.LearnSpell(15262);	//2
					e.Player.LearnSpell(15263);	//3
					e.Player.LearnSpell(15264);	//4
					e.Player.LearnSpell(15265);	//5
					e.Player.LearnSpell(15266);	//6
					e.Player.LearnSpell(15267);	//7
					e.Player.LearnSpell(15261);	//8
					/*Holy Nova*/
					e.Player.LearnSpell(15430);	//1
					e.Player.LearnSpell(15431);	//3
					/*Lesser Heal*/
					e.Player.LearnSpell(2050);	//1
					e.Player.LearnSpell(2052);	//2
					e.Player.LearnSpell(2053);	//3
					/*Prayer of Healing*/
					e.Player.LearnSpell(596);	//1
					e.Player.LearnSpell(996);	//2
					e.Player.LearnSpell(10960);	//3
					e.Player.LearnSpell(10961);	//4
					/*Renew*/
					e.Player.LearnSpell(139);	//1
					e.Player.LearnSpell(6074);	//2
					e.Player.LearnSpell(6075);	//3
					e.Player.LearnSpell(6076);	//4
					e.Player.LearnSpell(6077);	//5
					e.Player.LearnSpell(6078);	//6
					e.Player.LearnSpell(10927);	//7
					e.Player.LearnSpell(10928);	//8
					e.Player.LearnSpell(10929);	//9
					/*Resurrection*/
					e.Player.LearnSpell(2006);	//1
					e.Player.LearnSpell(2010);	//2
					e.Player.LearnSpell(10880);	//3
					e.Player.LearnSpell(10881);	//4
					e.Player.LearnSpell(20770);	//5
					/*Smite*/
					e.Player.LearnSpell(585);	//1
					e.Player.LearnSpell(591);	//2
					e.Player.LearnSpell(598);	//3
					e.Player.LearnSpell(984);	//4
					e.Player.LearnSpell(1004);	//5
					e.Player.LearnSpell(6060);	//7
					e.Player.LearnSpell(10933);	//8
					e.Player.LearnSpell(10934);	//9
				switch (e.Player.Race)
				{
					case Races.Human:
						/*Desperate Prayer*/
						e.Player.LearnSpell(13908);	//1
						e.Player.LearnSpell(19236);	//2
						e.Player.LearnSpell(19238);	//3
						e.Player.LearnSpell(19240);	//4
						e.Player.LearnSpell(19241);	//5
						e.Player.LearnSpell(19242);	//6
						e.Player.LearnSpell(19243);	//7
						break;
					case Races.Dwarf:
						/*Fear Ward*/
						e.Player.LearnSpell(6346);
						/*Desperate Prayer*/
						e.Player.LearnSpell(13908);	//1
						e.Player.LearnSpell(19236);	//2
						e.Player.LearnSpell(19238);	//3
						e.Player.LearnSpell(19240);	//4
						e.Player.LearnSpell(19241);	//5
						e.Player.LearnSpell(19242);	//6
						e.Player.LearnSpell(19243);	//7
						break;
				}
					#endregion
					#region Shadow
					/*Fade*/
					e.Player.LearnSpell(586);	//1
					e.Player.LearnSpell(9578);	//2
					e.Player.LearnSpell(9579);	//3
					e.Player.LearnSpell(9592);	//4
					e.Player.LearnSpell(10941);	//5
					e.Player.LearnSpell(10942);	//6	
					/*Mind Blast*/
					e.Player.LearnSpell(8092);	//1
					e.Player.LearnSpell(8102);	//2
					e.Player.LearnSpell(8103);	//3
					e.Player.LearnSpell(8104);	//4
					e.Player.LearnSpell(8105);	//5
					e.Player.LearnSpell(8106);	//6
					e.Player.LearnSpell(10945);	//7
					e.Player.LearnSpell(10946);	//8
					e.Player.LearnSpell(10947);	//9
					/*Mind Control*/
					e.Player.LearnSpell(605);	//1
					e.Player.LearnSpell(10911);	//2
					e.Player.LearnSpell(10912);	//3
					/*Mind Flay*/
					e.Player.LearnSpell(17311);	//2
					e.Player.LearnSpell(17312);	//3
					e.Player.LearnSpell(17313);	//4
					e.Player.LearnSpell(17314);	//5
					e.Player.LearnSpell(18807);	//6
					/*Mind Soothe*/
					e.Player.LearnSpell(453);	//1
					e.Player.LearnSpell(8192);	//2
					e.Player.LearnSpell(10953);	//3
					/*Mind Vision*/
					e.Player.LearnSpell(2096);	//1
					e.Player.LearnSpell(10909);	//2
					/*Psychic Scream*/
					e.Player.LearnSpell(8122);	//1
					e.Player.LearnSpell(8124);	//2
					e.Player.LearnSpell(10888);	//3
					e.Player.LearnSpell(10890);	//4
					/*Shadow Protection*/
					e.Player.LearnSpell(976);	//1
					e.Player.LearnSpell(10957);	//2
					e.Player.LearnSpell(10958);	//3
					/*Shadow Word: Pain*/
					e.Player.LearnSpell(589);	//1
					e.Player.LearnSpell(594);	//2
					e.Player.LearnSpell(970);	//3
					e.Player.LearnSpell(992);	//4
					e.Player.LearnSpell(2767);	//5
					e.Player.LearnSpell(10892);	//6
					e.Player.LearnSpell(10893);	//7
					e.Player.LearnSpell(10894);	//8
				switch (e.Player.Race)
				{
					case Races.Undead:
						/*Devouring Plague*/
						e.Player.LearnSpell(2944);	//1
						e.Player.LearnSpell(19276);	//2
						e.Player.LearnSpell(19277);	//3
						e.Player.LearnSpell(19278);	//4
						e.Player.LearnSpell(19279);	//5
						e.Player.LearnSpell(19280);	//6
						/*Touch of Weakness*/
						e.Player.LearnSpell(2652);	//1
						e.Player.LearnSpell(19261);	//2
						e.Player.LearnSpell(19262);	//3
						e.Player.LearnSpell(19264);	//4
						e.Player.LearnSpell(19265);	//5
						e.Player.LearnSpell(19266);	//6
						break;
					case Races.Troll:
						/*Hex of Weakness*/
						e.Player.LearnSpell(9035);	//1
						e.Player.LearnSpell(19281);	//2
						e.Player.LearnSpell(19282);	//3
						e.Player.LearnSpell(19283);	//4
						e.Player.LearnSpell(19284);	//5
						e.Player.LearnSpell(19285);	//6
						/*Shadowguard*/
						e.Player.LearnSpell(18137);	//1
						e.Player.LearnSpell(19308);	//2
						e.Player.LearnSpell(19309);	//3
						e.Player.LearnSpell(19310);	//4
						e.Player.LearnSpell(19311);	//5
						e.Player.LearnSpell(19312);	//6
						break;
				}

					#endregion
					#endregion
					#region TALENTS
					#region Discipline
					/*Divine Spirit*/
					e.Player.LearnSpell(14752);
					/*Focused Casting*/
					e.Player.LearnSpell(14529);
					/*Force of Will*/
					e.Player.LearnSpell(18550);
					/*Improved Inner Fire*/
					e.Player.LearnSpell(14771);
					/*Improved Mana Burn*/
					e.Player.LearnSpell(14772);
					/*Improved Power Word: Fortitude*/
					e.Player.LearnSpell(14767);
					/*Improved Power Word: Shield*/
					e.Player.LearnSpell(14769);
					/*Inner Focus*/
					e.Player.LearnSpell(14751);
					/*Martyrdom*/
					e.Player.LearnSpell(14774);
					/*Meditation*/
					e.Player.LearnSpell(14779);
					/*Mental Agility*/
					e.Player.LearnSpell(14783);
					/*Mental Strength*/
					e.Player.LearnSpell(18555);
					/*Silent Resolve*/
					e.Player.LearnSpell(14787);
					/*Unbreakable Will*/
					e.Player.LearnSpell(14791);
					/*Wand Specialization*/
					e.Player.LearnSpell(14528);
					#endregion
					#region Holy
					/*Divine Fury*/
					e.Player.LearnSpell(18535);
					/*Holy Fire*/
					e.Player.LearnSpell(14914);
					/*Holy Nova*/
					e.Player.LearnSpell(15237);
					/*Holy Specialization*/
					e.Player.LearnSpell(15011);
					/*Improved Flash Heal*/
					e.Player.LearnSpell(15012);
					/*Improved Healing*/
					e.Player.LearnSpell(15016);
					/*Improved Prayer of Healing*/
					e.Player.LearnSpell(15018);
					/*Improved Renew*/
					e.Player.LearnSpell(17193);
					/*Improved Smite*/
					e.Player.LearnSpell(18539);
					/*Inspiration*/
					e.Player.LearnSpell(15365);
					/*Master Healer*/
					e.Player.LearnSpell(15027);
					/*Spirit of Redemption*/
					e.Player.LearnSpell(20711);
					/*Spiritual Healing*/
					e.Player.LearnSpell(15356);
					/*Subtlety*/
					e.Player.LearnSpell(15031);
					#endregion
					#region Shadow
					/*Blackout*/
					e.Player.LearnSpell(15326);
					/*Darkness*/
					e.Player.LearnSpell(15310);
					/*Improved Fade*/
					e.Player.LearnSpell(15311);
					/*Improved Mind Blast*/
					e.Player.LearnSpell(15316);
					/*Improved Psychic Scream*/
					e.Player.LearnSpell(15448);
					/*Improved Shadow Word: Pain*/
					e.Player.LearnSpell(15317);
					/*Mind Flay*/
					e.Player.LearnSpell(15407);
					/*Shadow Affinity*/
					e.Player.LearnSpell(15322);
					/*Shadow Focus*/
					e.Player.LearnSpell(15330);
					/*Shadowform*/
					e.Player.LearnSpell(15473);
					/*Shadow Reach*/
					e.Player.LearnSpell(17325);
					/*Shadow Weaving*/
					e.Player.LearnSpell(15334);
					/*Silence*/
					e.Player.LearnSpell(15487);
					/*Spirit Tap*/
					e.Player.LearnSpell(15338);
					/*Vampiric Embrace*/
					e.Player.LearnSpell(15286);
					#endregion
					#endregion
					break; 
					#endregion
					#region Rogue
				case Classes.Rogue: 
					#region SPELLS
					#region Assassination
					/*Ambush*/
					e.Player.LearnSpell(8676);	//1
					e.Player.LearnSpell(8724);	//2
					e.Player.LearnSpell(8725);	//3
					e.Player.LearnSpell(11267);	//4
					e.Player.LearnSpell(11268);	//5
					e.Player.LearnSpell(11269);	//6
					/*Cheap Shot*/
					e.Player.LearnSpell(1833);
					/*Eviscerate*/
					e.Player.LearnSpell(6760);	//2
					e.Player.LearnSpell(6761);	//3
					e.Player.LearnSpell(6762);	//4
					e.Player.LearnSpell(8623);	//5
					e.Player.LearnSpell(8624);	//6
					e.Player.LearnSpell(11299);	//7
					e.Player.LearnSpell(11300);	//8
					/*Expose Armor*/
					e.Player.LearnSpell(8647);	//1
					e.Player.LearnSpell(8649);	//2
					e.Player.LearnSpell(8650);	//3
					e.Player.LearnSpell(11197);	//4
					e.Player.LearnSpell(11198);	//5
					/*Garrote*/
					e.Player.LearnSpell(703);	//1
					e.Player.LearnSpell(8631);	//2
					e.Player.LearnSpell(8632);	//3
					e.Player.LearnSpell(8633);	//4
					e.Player.LearnSpell(11289);	//5
					e.Player.LearnSpell(11290);	//6
					/*Kidney Shot*/
					e.Player.LearnSpell(408);	//1
					e.Player.LearnSpell(8643);	//2
					/*Rupture*/
					e.Player.LearnSpell(1943);	//1
					e.Player.LearnSpell(8639);	//2
					e.Player.LearnSpell(8640);	//3
					e.Player.LearnSpell(11273);	//4
					e.Player.LearnSpell(11274);	//5
					e.Player.LearnSpell(11275);	//6
					/*Slice and Dice*/
					e.Player.LearnSpell(5171);	//1
					e.Player.LearnSpell(6774);	//2
					#endregion
					#region Combat
					/*Backstab*/
					e.Player.LearnSpell(53);	//1
					e.Player.LearnSpell(2589);	//2
					e.Player.LearnSpell(2590);	//3
					e.Player.LearnSpell(2591);	//4
					e.Player.LearnSpell(8721);	//5
					e.Player.LearnSpell(11279);	//6
					e.Player.LearnSpell(11280);	//7
					e.Player.LearnSpell(11281);	//8
					/*Evasion*/
					e.Player.LearnSpell(5277);
					/*Feint*/
					e.Player.LearnSpell(1966);	//1
					e.Player.LearnSpell(6768);	//2
					e.Player.LearnSpell(8637);	//3
					e.Player.LearnSpell(11303);	//4
					/*Gouge*/
					e.Player.LearnSpell(1776);	//1
					e.Player.LearnSpell(1777);	//2
					e.Player.LearnSpell(8629);	//3
					e.Player.LearnSpell(11285);	//4
					e.Player.LearnSpell(11286);	//5
					/*Kick*/
					e.Player.LearnSpell(1766);	//1
					e.Player.LearnSpell(1767);	//2
					e.Player.LearnSpell(1768);	//3
					e.Player.LearnSpell(1769);	//4
					/*Sinister Strike*/
					e.Player.LearnSpell(1757);	//2
					e.Player.LearnSpell(1758);	//3
					e.Player.LearnSpell(1759);	//4
					e.Player.LearnSpell(1760);	//5
					e.Player.LearnSpell(8621);	//6
					e.Player.LearnSpell(11293);	//7
					e.Player.LearnSpell(11294);	//8
					/*Sprint*/
					e.Player.LearnSpell(2983);	//1
					e.Player.LearnSpell(8696);	//2
					e.Player.LearnSpell(11305);	//3
					#endregion
					#region Subtlety
					/*Blind*/
					e.Player.LearnSpell(2094);
					/*Detect Traps*/
					e.Player.LearnSpell(2836);
					/*Disarm Trap*/
					e.Player.LearnSpell(1842);
					/*Distract*/
					e.Player.LearnSpell(1725);
					/*Hemorrhage*/
					e.Player.LearnSpell(16511);	//1
					e.Player.LearnSpell(17347);	//2
					e.Player.LearnSpell(17348);	//3
					/*Pick Pocket*/
					e.Player.LearnSpell(921);
					/*Safe Fall*/
					e.Player.LearnSpell(1860);
					/*Sap*/
					e.Player.LearnSpell(6770);	//1
					e.Player.LearnSpell(2070);	//2
					e.Player.LearnSpell(11297);	//3
					/*Stealth*/
					e.Player.LearnSpell(1784);	//1
					e.Player.LearnSpell(1785);	//2
					e.Player.LearnSpell(1786);	//3
					e.Player.LearnSpell(1787);	//4
					/*Vanish*/
					e.Player.LearnSpell(1856);	//1
					e.Player.LearnSpell(1857);	//2
					#endregion
					/*Mind-numbing Poison*/
					e.Player.LearnSpell(5763);	//1
					e.Player.LearnSpell(8694);	//2
					e.Player.LearnSpell(11400);	//3
					/*Poisons*/
					e.Player.LearnSpell(2842);
					#endregion
					#region TALETS
					#region Assassination
					/*Cold Blood*/
					e.Player.LearnSpell(14177);
					/*Improved Deadly Poison*/
					e.Player.LearnSpell(14259);
					/*Improved Eviscerate*/
					e.Player.LearnSpell(14164);
					/*Improved Expose Armor*/
					e.Player.LearnSpell(14170);
					/*Improved Instant Poison*/
					e.Player.LearnSpell(14117);
					/*Improved Kidney Shot*/
					e.Player.LearnSpell(14176);
					/*Improved Slice and Dice*/
					e.Player.LearnSpell(14167);
					/*Lethality*/
					e.Player.LearnSpell(14137);
					/*Malice*/
					e.Player.LearnSpell(14142);
					/*Murder*/
					e.Player.LearnSpell(14159);
					/*Relentless Strikes*/
					e.Player.LearnSpell(14179);
					/*Remorseless Attacks*/
					e.Player.LearnSpell(14154);
					/*Ruthlessness*/
					e.Player.LearnSpell(14161);
					/*Seal Fate*/
					e.Player.LearnSpell(14195);
					/*Vigor*/
					e.Player.LearnSpell(14983);
					/*Vile Poisons*/
					e.Player.LearnSpell(16720);
					#endregion
					#region Combat
					/*Adrenaline Rush*/
					e.Player.LearnSpell(13750);
					/*Aggression*/
					e.Player.LearnSpell(18429);
					/*Blade Flurry*/
					e.Player.LearnSpell(13877);
					/*Dagger Specialization*/
					e.Player.LearnSpell(13807);
					/*Deflection*/
					e.Player.LearnSpell(13856);
					/*Dual Wield Specialization*/
					e.Player.LearnSpell(13852);
					/*Fist Weapon Specialization*/
					e.Player.LearnSpell(13969);
					/*Improved Backstab*/
					e.Player.LearnSpell(13866);
					/*Improved Evasion*/
					e.Player.LearnSpell(13872);
					/*Improved Gouge*/
					e.Player.LearnSpell(13792);
					/*Improved Kick*/
					e.Player.LearnSpell(13867);
					/*Improved Sinister Strike*/
					e.Player.LearnSpell(13863);
					/*Improved Sprint*/
					e.Player.LearnSpell(13876);
					/*Lightning Reflexes*/
					e.Player.LearnSpell(13791);
					/*Mace Specialization*/
					e.Player.LearnSpell(13803);
					/*Precision*/
					e.Player.LearnSpell(13845);
					/*Riposte*/
					e.Player.LearnSpell(14251);
					/*Sword Specialization*/
					e.Player.LearnSpell(13964);
					/*Throwing Weapon Specialization*/
					e.Player.LearnSpell(13859);
					#endregion
					#region Subtlety
					/*Camouflage*/
					e.Player.LearnSpell(14065);
					/*Elusiveness*/
					e.Player.LearnSpell(14069);
					/*Ghostly Strike*/
					e.Player.LearnSpell(14278);
					/*Hemorrhage*/
					e.Player.LearnSpell(16511);
					/*Improved Ambush*/
					e.Player.LearnSpell(14081);
					/*Improved Cheap Shot*/
					e.Player.LearnSpell(14083);
					/*Improved Distract*/
					e.Player.LearnSpell(14085);
					/*Improved Garrote*/
					e.Player.LearnSpell(14078);
					/*Improved Rupture*/
					e.Player.LearnSpell(14173);
					/*Improved Sap*/
					e.Player.LearnSpell(14095);
					/*Improved Vanish*/
					e.Player.LearnSpell(14092);
					/*Initiative*/
					e.Player.LearnSpell(16504);
					/*Master of Deception*/
					e.Player.LearnSpell(13973);
					/*Opportunity*/
					e.Player.LearnSpell(14075);
					/*Premeditation*/
					e.Player.LearnSpell(14183);
					/*Preparation*/
					e.Player.LearnSpell(14185);
					/*Rapid Concealment*/
					e.Player.LearnSpell(14061);
					/*Setup*/
					e.Player.LearnSpell(14071);
					#endregion
					#endregion
					break;
					#endregion
					#region Shaman
				case Classes.Shaman:
					#region SPELLS
					#region Elemental
					/*Chain Lightning*/
					e.Player.LearnSpell(421);	//1
					e.Player.LearnSpell(930);	//2
					e.Player.LearnSpell(2860);	//3
					e.Player.LearnSpell(10605);	//4
					/*Earth Shock*/
					e.Player.LearnSpell(8042);	//1
					e.Player.LearnSpell(8044);	//2
					e.Player.LearnSpell(8045);	//3
					e.Player.LearnSpell(8046);	//4
					e.Player.LearnSpell(10412);	//5
					e.Player.LearnSpell(10413);	//6
					e.Player.LearnSpell(10414);	//7
					/*Earthbind Totem*/
					e.Player.LearnSpell(2484);
					/*Fire Nova Totem*/
					e.Player.LearnSpell(1535);	//1
					e.Player.LearnSpell(8498);	//2
					e.Player.LearnSpell(8499);	//3
					e.Player.LearnSpell(11314);	//4
					e.Player.LearnSpell(11315);	//5
					/*Flame Shock*/
					e.Player.LearnSpell(8050);	//1
					e.Player.LearnSpell(8052);	//2
					e.Player.LearnSpell(8053);	//3
					e.Player.LearnSpell(10447);	//4
					e.Player.LearnSpell(10448);	//5
					/*Frost Shock*/
					e.Player.LearnSpell(8056);	//1
					e.Player.LearnSpell(8058);	//2
					e.Player.LearnSpell(10472);	//3
					e.Player.LearnSpell(10473);	//4
					/*Lightning Bolt*/
					e.Player.LearnSpell(403);	//1
					e.Player.LearnSpell(529);	//2
					e.Player.LearnSpell(548);	//3
					e.Player.LearnSpell(915);	//4
					e.Player.LearnSpell(943);	//5
					e.Player.LearnSpell(6041);	//6
					e.Player.LearnSpell(10391);	//7
					e.Player.LearnSpell(10392);	//8
					e.Player.LearnSpell(15207);	//9
					e.Player.LearnSpell(15208);	//10
					/*Magma Totem*/
					e.Player.LearnSpell(8190);	//1
					e.Player.LearnSpell(10585);	//2
					e.Player.LearnSpell(10586);	//3
					e.Player.LearnSpell(10587);	//4
					/*Purge*/
					e.Player.LearnSpell(370);	//1
					e.Player.LearnSpell(8012);	//2
					/*Searing Totem*/
					e.Player.LearnSpell(3599);	//1
					e.Player.LearnSpell(6363);	//2
					e.Player.LearnSpell(6364);	//3
					e.Player.LearnSpell(6365);	//4
					e.Player.LearnSpell(10437);	//5
					e.Player.LearnSpell(10438);	//6
					/*Stoneclaw Totem*/
					e.Player.LearnSpell(5730);	//1
					e.Player.LearnSpell(6390);	//2
					e.Player.LearnSpell(6391);	//3
					e.Player.LearnSpell(6392);	//4
					e.Player.LearnSpell(10427);	//5
					e.Player.LearnSpell(10428);	//6
					#endregion
					#region Enhancement
					/*Astral Recall*/
					e.Player.LearnSpell(556);
					/*Ghost Wolf*/
					e.Player.LearnSpell(2645);
					/*Grace of Air Totem*/
					e.Player.LearnSpell(8835);	//1
					e.Player.LearnSpell(10627);	//2
					/*Grounding Totem*/
					e.Player.LearnSpell(8177);
					/*Far Sight*/
					e.Player.LearnSpell(6196);
					//Fire Resistance Totem*/
					e.Player.LearnSpell(8184);	//1
					e.Player.LearnSpell(10537);	//2
					e.Player.LearnSpell(10538);	//3
					/*Flametongue Totem*/
					e.Player.LearnSpell(8227);	//1
					e.Player.LearnSpell(8249);	//2
					e.Player.LearnSpell(10526);	//3
					e.Player.LearnSpell(16387);	//4
					/*Flametongue Weapon*/
					e.Player.LearnSpell(8024);	//1
					e.Player.LearnSpell(8027);	//2
					e.Player.LearnSpell(8030);	//3
					e.Player.LearnSpell(16339);	//4
					e.Player.LearnSpell(16341);	//5
					e.Player.LearnSpell(16342);	//6
					/*Frostbrand Weapon*/
					e.Player.LearnSpell(8033);	//1
					e.Player.LearnSpell(8038);	//2
					e.Player.LearnSpell(10456);	//3
					e.Player.LearnSpell(16355);	//4
					e.Player.LearnSpell(16356);	//5
					/*Frost Resistance Totem*/
					e.Player.LearnSpell(8181);	//1
					e.Player.LearnSpell(10478);	//2
					e.Player.LearnSpell(10479);	//3
					/*Lightning Shield*/
					e.Player.LearnSpell(324);	//1
					e.Player.LearnSpell(325);	//2
					e.Player.LearnSpell(905);	//3
					e.Player.LearnSpell(945);	//4
					e.Player.LearnSpell(8134);	//5
					e.Player.LearnSpell(10431);	//6
					e.Player.LearnSpell(10432);	//7
					/*Nature Resistance Totem*/
					e.Player.LearnSpell(10595);	//1
					e.Player.LearnSpell(10600);	//2
					e.Player.LearnSpell(10601);	//3
					/*Rockbiter Weapon*/
					e.Player.LearnSpell(8017);	//1
					e.Player.LearnSpell(8018);	//2
					e.Player.LearnSpell(8019);	//3
					e.Player.LearnSpell(10399);	//4
					e.Player.LearnSpell(16314);	//5
					e.Player.LearnSpell(16315); //6
					e.Player.LearnSpell(16316); //7
					/*Sentry Totem*/
					e.Player.LearnSpell(6495);
					/*Stoneskin Totem*/
					e.Player.LearnSpell(8071);	//1
					e.Player.LearnSpell(8154);	//2
					e.Player.LearnSpell(8155);	//3
					e.Player.LearnSpell(10406);	//4
					e.Player.LearnSpell(10407);	//5
					e.Player.LearnSpell(10408);	//6
					/*Strength of Earth Totem*/
					e.Player.LearnSpell(8075);	//1
					e.Player.LearnSpell(8160);	//2
					e.Player.LearnSpell(8161);	//3
					e.Player.LearnSpell(10442);	//4
					/*Water Breathing*/
					e.Player.LearnSpell(131);
					/*Water Walking*/
					e.Player.LearnSpell(546);
					/*Windfury Totem*/
					e.Player.LearnSpell(8512);	//1
					e.Player.LearnSpell(10613);	//2
					e.Player.LearnSpell(10614);	//3
					/*Windfury Weapon*/
					e.Player.LearnSpell(8232);	//1
					e.Player.LearnSpell(8235);	//2
					e.Player.LearnSpell(10486);	//3
					e.Player.LearnSpell(16362);	//4
					/*Windwall Totem*/
					e.Player.LearnSpell(15107);	//1
					e.Player.LearnSpell(15111);	//2
					e.Player.LearnSpell(15112);	//3
					#endregion
					#region Restoration
					/*Ancestral Spirit*/
					e.Player.LearnSpell(2008);	//1
					e.Player.LearnSpell(20609);	//2
					e.Player.LearnSpell(20610);	//3
					e.Player.LearnSpell(20776);	//4
					e.Player.LearnSpell(20777);	//5
					/*Chain Heal*/
					e.Player.LearnSpell(1064);	//1
					e.Player.LearnSpell(10622);	//2
					e.Player.LearnSpell(10623);	//3
					/*Cure Disease*/
					e.Player.LearnSpell(2870);
					/*Cure Poison*/
					e.Player.LearnSpell(526);
					/*Disease Cleansing Totem*/
					e.Player.LearnSpell(8170);
					/*Healing Stream Totem*/
					e.Player.LearnSpell(5394);	//1
					e.Player.LearnSpell(6375);	//2
					e.Player.LearnSpell(6377);	//3
					e.Player.LearnSpell(10462);	//4
					e.Player.LearnSpell(10463);	//5
					/*Healing Wave*/
					e.Player.LearnSpell(331);	//1
					e.Player.LearnSpell(332);	//2
					e.Player.LearnSpell(547);	//3
					e.Player.LearnSpell(913);	//4
					e.Player.LearnSpell(939);	//5
					e.Player.LearnSpell(959);	//6
					e.Player.LearnSpell(8005);	//7
					e.Player.LearnSpell(10395);	//8
					e.Player.LearnSpell(10396);	//9
					/*Lesser Healing Wave*/
					e.Player.LearnSpell(8004);	//1
					e.Player.LearnSpell(8008);	//2
					e.Player.LearnSpell(8010);	//3
					e.Player.LearnSpell(10466);	//4
					e.Player.LearnSpell(10467);	//5
					e.Player.LearnSpell(10468);	//6
					/*Mana Spring Totem*/
					e.Player.LearnSpell(5675);	//1
					e.Player.LearnSpell(10495);	//2
					e.Player.LearnSpell(10496);	//3
					e.Player.LearnSpell(10497);	//4
					/*Mana Tide Totem*/
					e.Player.LearnSpell(17354);	//2
					e.Player.LearnSpell(17359);	//3
					/*Poison Cleansing Totem*/
					e.Player.LearnSpell(8166);
					/*Reincarnation Passive*/
					e.Player.LearnSpell(20608);
					/*Reincarnation*/
					e.Player.LearnSpell(21169);
					/*Tremor Totem*/
					e.Player.LearnSpell(8143);
					#endregion
					#endregion
					#region TALENTS
					#region Elemental
					/*Call of Flame*/
					e.Player.LearnSpell(16163);
					/*Call of Thunder*/
					e.Player.LearnSpell(16120);
					/*Concussion*/
					e.Player.LearnSpell(16108);
					/*Convection*/
					e.Player.LearnSpell(16112);
					/*Elemental Focus*/
					e.Player.LearnSpell(16164);
					/*Elemental Fury*/
					e.Player.LearnSpell(16089);
					/*Elemental Mastery*/
					e.Player.LearnSpell(16166);
					/*Improved Chain Lightning*/
					e.Player.LearnSpell(16123);
					/*Improved Fire Nova Totem*/
					e.Player.LearnSpell(16544);
					/*Improved Lightning Bolt*/
					e.Player.LearnSpell(16159);
					/*Improved Magma Totem*/
					e.Player.LearnSpell(16129);
					/*Improved Searing Totem*/
					e.Player.LearnSpell(16127);
					/*Improved Stoneclaw Totem*/
					e.Player.LearnSpell(16133);
					/*Lightning Mastery*/
					e.Player.LearnSpell(16582);
					/*Reverberation*/
					e.Player.LearnSpell(16116);
					#endregion
					#region Enhancement
					/*Ancestral Knowledge*/
					e.Player.LearnSpell(17489);
					/*Anticipation*/
					e.Player.LearnSpell(16274);
					/*Flurry*/
					e.Player.LearnSpell(16284);
					/*Improved Flametongue Weapon*/
					e.Player.LearnSpell(16285);
					/*Improved Frostbrand Weapon*/
					e.Player.LearnSpell(16286);
					/*Improved Ghost Wolf*/
					e.Player.LearnSpell(16287);
					/*Improved Grace of Air Totem*/
					e.Player.LearnSpell(16289);
					/*Improved Grounding Totem*/
					e.Player.LearnSpell(16547);
					/*Improved Lightning Shield*/
					e.Player.LearnSpell(16291);
					/*Improved Rockbiter Weapon*/
					e.Player.LearnSpell(16292);
					/*Improved Stoneskin Totem*/
					e.Player.LearnSpell(16294);
					/*Improved Strength of Earth Totem*/
					e.Player.LearnSpell(16296);
					/*Improved Windfury Weapon*/
					e.Player.LearnSpell(16297);
					/*Parry*/
					e.Player.LearnSpell(16268);
					/*Shield Specialization*/
					e.Player.LearnSpell(16301);
					/*Stormstrike*/
					e.Player.LearnSpell(17364);
					/*Thundering Strikes*/
					e.Player.LearnSpell(16305);
					/*Toughness*/
					e.Player.LearnSpell(16309);
					/*Two-Handed Axes and Maces*/
					e.Player.LearnSpell(16269);
					#endregion
					#region Restoration
					/*Ancestral Healing*/
					e.Player.LearnSpell(16242);
					/*Combat Endurance*/
					e.Player.LearnSpell(16189);
					/*Eventide*/
					e.Player.LearnSpell(16200);
					/*Improved Healing Stream Totem*/
					e.Player.LearnSpell(16204);
					/*Improved Healing Wave*/
					e.Player.LearnSpell(16229);
					/*Improved Lesser Healing Wave*/
					e.Player.LearnSpell(16234);
					/*Improved Mana Spring Totem*/
					e.Player.LearnSpell(16208);
					/*Improved Reincarnation*/
					e.Player.LearnSpell(16209);
					/*Mana Tide Totem*/
					e.Player.LearnSpell(16190);
					/*Nature's Swiftness*/
					e.Player.LearnSpell(16188);
					/*Purification*/
					e.Player.LearnSpell(16213);
					/*Tidal Focus*/
					e.Player.LearnSpell(16217);
					/*Tidal Mastery*/
					e.Player.LearnSpell(16221);
					/*Totemic Focus*/
					e.Player.LearnSpell(16225);
					#endregion
					#endregion
					break;
					#endregion
					#region Warlock
				case Classes.Warlock:
					#region SPELLS
					#region AFFLICTION
					/*Corruption*/
					e.Player.LearnSpell(172);	//1
					e.Player.LearnSpell(6222);	//2
					e.Player.LearnSpell(6223);	//3
					e.Player.LearnSpell(7648);	//4
					e.Player.LearnSpell(11671); //5
					e.Player.LearnSpell(11672); //6
					/*Curse of Agony*/
					e.Player.LearnSpell(980);	//1
					e.Player.LearnSpell(1014);	//2
					e.Player.LearnSpell(6217);	//3
					e.Player.LearnSpell(11711); //4
					e.Player.LearnSpell(11712); //5
					e.Player.LearnSpell(11713); //6
					/*Curse of Doom*/
					e.Player.LearnSpell(603);
					/*Curse of Idiocy*/
					e.Player.LearnSpell(1010);
					/*Curse of Recklessness*/
					e.Player.LearnSpell(704);	//1
					e.Player.LearnSpell(7658);	//2
					e.Player.LearnSpell(7659);	//3
					e.Player.LearnSpell(11717); //4
					/*Curse of Shadow*/
					e.Player.LearnSpell(17862); //1
					e.Player.LearnSpell(17937); //2
					/*Curse of the Elements*/
					e.Player.LearnSpell(1490);	//1
					e.Player.LearnSpell(11721); //2
					e.Player.LearnSpell(11722); //3
					/*Curse of Tongues*/
					e.Player.LearnSpell(1714);	//1
					e.Player.LearnSpell(11719); //2
					/*Curse of Weakness*/
					e.Player.LearnSpell(702);	//1
					e.Player.LearnSpell(1108);	//2
					e.Player.LearnSpell(6205);	//3
					e.Player.LearnSpell(7646);	//4
					e.Player.LearnSpell(11707); //5
					e.Player.LearnSpell(11708); //6
					/*Dark Pact*/
					e.Player.LearnSpell(18937); //2
					e.Player.LearnSpell(18938); //3
					/*Death Coil*/
					e.Player.LearnSpell(6789);	//1
					e.Player.LearnSpell(17925);	//2
					e.Player.LearnSpell(17926); //3
					/*Drain Life*/
					e.Player.LearnSpell(689);	//1
					e.Player.LearnSpell(699);	//2
					e.Player.LearnSpell(709);	//3
					e.Player.LearnSpell(7651);	//4
					e.Player.LearnSpell(11699); //5
					e.Player.LearnSpell(11700); //6
					/*Drain Mana*/
					e.Player.LearnSpell(5138);	//1
					e.Player.LearnSpell(6226);	//2
					e.Player.LearnSpell(11703); //3
					e.Player.LearnSpell(11704); //4
					/*Drain Soul*/
					e.Player.LearnSpell(1120);	//1
					e.Player.LearnSpell(8288);	//2
					e.Player.LearnSpell(8289);	//3
					e.Player.LearnSpell(11675); //4
					/*Fear*/
					e.Player.LearnSpell(5782);	//1
					e.Player.LearnSpell(6213);	//2
					e.Player.LearnSpell(6215);	//3
					/*Howl of Terror*/
					e.Player.LearnSpell(5484);	//1
					e.Player.LearnSpell(17928); //2
					/*Life Tap*/
					e.Player.LearnSpell(1454);	//1
					e.Player.LearnSpell(1455);	//2
					e.Player.LearnSpell(1456);	//3
					e.Player.LearnSpell(11687); //4
					e.Player.LearnSpell(11688); //5
					e.Player.LearnSpell(11689); //6
					/*Siphon Life*/
					e.Player.LearnSpell(18879); //2
					e.Player.LearnSpell(18880); //3
					e.Player.LearnSpell(18881); //4
					#endregion
					#region DEMONOLOGY
					/*Banish*/
					e.Player.LearnSpell(710);	//1
					e.Player.LearnSpell(18647); //2
					/*Create Firestone*/
					e.Player.LearnSpell(17951);
					/*Create Firestone (Greater)*/
					e.Player.LearnSpell(17952);
					/*Create Firestone (Lesser)*/
					e.Player.LearnSpell(6366);
					/*Create Firestone (Major)*/
					e.Player.LearnSpell(17953);
					/*Create Healthstone*/
					e.Player.LearnSpell(5699);
					/*Create Healthstone (Greater)*/
					e.Player.LearnSpell(11729);
					/*Create Healthstone (Lesser)*/
					e.Player.LearnSpell(6202);
					/*Create Healthstone (Major)*/
					e.Player.LearnSpell(11730);
					/*Create Healthstone (Minor)*/
					e.Player.LearnSpell(6201);
					/*Create Soulstone*/
					e.Player.LearnSpell(20755);
					/*Create Soulstone (Greater)*/
					e.Player.LearnSpell(20756);
					/*Create Soulstone (Lesser)*/
					e.Player.LearnSpell(20752);
					/*Create Soulstone (Major)*/
					e.Player.LearnSpell(20757);
					/*Create Soulstone (Minor)*/
					e.Player.LearnSpell(693);
					/*Create Spellstone*/
					e.Player.LearnSpell(2362);
					/*Create Spellstone (Greater)*/
					e.Player.LearnSpell(17727);
					/*Create Spellstone (Major)*/
					e.Player.LearnSpell(17728);
					/*Demon Armor*/
					e.Player.LearnSpell(706);	//1
					e.Player.LearnSpell(1086);	//2
					e.Player.LearnSpell(11733); //3
					e.Player.LearnSpell(11734); //4
					e.Player.LearnSpell(11735); //5
					/*Demon Skin*/
					e.Player.LearnSpell(696);	//2
					/*Detect Greater Invisibility*/
					e.Player.LearnSpell(11743);
					/*Detect Invisibility*/
					e.Player.LearnSpell(2970);
					/*Detect Lesser Invisibility*/
					 e.Player.LearnSpell(132);
					/*Enslave Demon*/
					e.Player.LearnSpell(1098);	//1
					e.Player.LearnSpell(11725); //2
					e.Player.LearnSpell(11726); //3
					/*Eye of Kilrogg*/
					e.Player.LearnSpell(126);
					/*Health Funnel*/
					e.Player.LearnSpell(755);	//1
					e.Player.LearnSpell(3698);	//2
					e.Player.LearnSpell(3699);	//3
					e.Player.LearnSpell(3700);	//4
					e.Player.LearnSpell(11693); //5
					e.Player.LearnSpell(11694); //6
					e.Player.LearnSpell(11695); //7
					/*Inferno*/
					e.Player.LearnSpell(1122);
					/*Ritual of Doom*/
					e.Player.LearnSpell(18540);
					/*Ritual of Summoning*/
					e.Player.LearnSpell(698);
					/*Searing Pain*/
					e.Player.LearnSpell(5676);	//1
					e.Player.LearnSpell(17919); //2
					e.Player.LearnSpell(17920); //3
					e.Player.LearnSpell(17921); //4
					e.Player.LearnSpell(17922); //5
					e.Player.LearnSpell(17923); //6
					/*Sense Demons*/
					e.Player.LearnSpell(5500);
					/*Shadow Ward*/
					e.Player.LearnSpell(6229);	//1
					e.Player.LearnSpell(11739); //2
					e.Player.LearnSpell(11740); //3
					/*Summon Dreadsteed*/
					e.Player.LearnSpell(23161);
					/*Summon Felhunter*/
					e.Player.LearnSpell(691);
					/*Summon Imp*/
					e.Player.LearnSpell(688);
					/*Summon Felsteed*/
					e.Player.LearnSpell(5784);
					/*Summon Succubus*/
					e.Player.LearnSpell(712);
					/*Summon Voidwalker*/
					e.Player.LearnSpell(697);
					/*Unending Breath*/
					e.Player.LearnSpell(5697);
					#endregion
					#region DESTRUCTION
					/*Conflagrate*/
					e.Player.LearnSpell(18930); //2
					e.Player.LearnSpell(18931); //3
					e.Player.LearnSpell(18932); //4
					/*Hellfire*/
					e.Player.LearnSpell(1949);	//1
					e.Player.LearnSpell(11683); //2
					e.Player.LearnSpell(11684); //3
					/*Immolate*/
					e.Player.LearnSpell(348);	//1
					e.Player.LearnSpell(707);	//2
					e.Player.LearnSpell(1094);	//3
					e.Player.LearnSpell(2941);	//4
					e.Player.LearnSpell(11665);	//5
					e.Player.LearnSpell(11667); //6
					e.Player.LearnSpell(11668); //7
					/*Rain of Fire*/
					e.Player.LearnSpell(5740);	//1
					e.Player.LearnSpell(6219);	//2
					e.Player.LearnSpell(11677); //3
					e.Player.LearnSpell(11678); //4
					/*Shadow Bolt*/
					e.Player.LearnSpell(695);	//2
					e.Player.LearnSpell(705);	//3
					e.Player.LearnSpell(1088);	//4
					e.Player.LearnSpell(1106);	//5
					e.Player.LearnSpell(7641);	//6
					e.Player.LearnSpell(11659);	//7
					e.Player.LearnSpell(11660);	//8
					e.Player.LearnSpell(11661);	//9
					/*Shadowburn*/
					e.Player.LearnSpell(18867); //2
					e.Player.LearnSpell(18868); //3
					e.Player.LearnSpell(18869); //4
					e.Player.LearnSpell(18870); //5
					e.Player.LearnSpell(18871); //6
					/*Soul Fire*/
					e.Player.LearnSpell(6353);	//1
					e.Player.LearnSpell(17924); //2
					#endregion
					#endregion
					#region TALENTS
					#region AFFLICTION
					/*Amplify Curse*/
					e.Player.LearnSpell(18288);
					/*Curse of Exhaustion*/
					e.Player.LearnSpell(18223);
					/*Dark Pact*/
					e.Player.LearnSpell(18220);
					/*Fel Concentration*/
					e.Player.LearnSpell(17787);
					/*Grim Reach*/
					e.Player.LearnSpell(18219);
					/*Improved Corruption*/
					e.Player.LearnSpell(17814);
					/*Improved Curse of Agony*/
					e.Player.LearnSpell(18830);
					/*Improved Curse of Exhaustion*/
					e.Player.LearnSpell(18313);
					/*Improved Curse of Weakness*/
					e.Player.LearnSpell(18181);
					/*Improved Drain Life*/
					e.Player.LearnSpell(17808);
					/*Improved Drain Mana*/
					e.Player.LearnSpell(18393);
					/*Improved Drain Soul*/
					e.Player.LearnSpell(18372);
					/*Improved Life Tap*/
					e.Player.LearnSpell(18183);
					/*Nightfall*/
					e.Player.LearnSpell(18095);
					/*Shadow Mastery*/
					e.Player.LearnSpell(18275);
					/*Siphon Life*/
					e.Player.LearnSpell(18265);
					/*Suppression*/
					e.Player.LearnSpell(18178);
					#endregion
					#region DEMONOLOGY
					/*Demonic Embrace*/
					e.Player.LearnSpell(18701);
					/*Demonic Sacrifice*/
					e.Player.LearnSpell(18788);
					/*Fel Domination*/
					e.Player.LearnSpell(18708);
					/*Fel Intellect*/
					e.Player.LearnSpell(18746);
					/*Fel Stamina*/
					e.Player.LearnSpell(18752);
					/*Improved Enslave Demon*/
					e.Player.LearnSpell(18825);
					/*Improved Firestone*/
					e.Player.LearnSpell(18768);
					/*Improved Health Funnel*/
					e.Player.LearnSpell(18704);
					/*Improved Healthstone*/
					e.Player.LearnSpell(18693);
					/*Improved Imp*/
					e.Player.LearnSpell(18696);
					/*Improved Spellstone*/
					e.Player.LearnSpell(18775);
					/*Improved Succubus*/
					e.Player.LearnSpell(18756);
					/*Improved Voidwalker*/
					e.Player.LearnSpell(18707);
					/*Master Conjuror*/
					e.Player.LearnSpell(18758);
					/*Master Demonologist*/
					e.Player.LearnSpell(23825);
					/*Soul Link*/
					e.Player.LearnSpell(19028);
					/*Unholy Power*/
					e.Player.LearnSpell(18773);
					#endregion
					#region DESTRUCTION
					/*Aftermath*/
					e.Player.LearnSpell(18123);
					/*Bane*/
					e.Player.LearnSpell(17792);
					/*Cataclysm*/
					e.Player.LearnSpell(17782);
					/*Conflagrate*/
					e.Player.LearnSpell(17962);
					/*Destructive Reach*/
					e.Player.LearnSpell(17918);
					/*Devastation*/
					e.Player.LearnSpell(18134);
					/*Emberstorm*/
					e.Player.LearnSpell(17958);
					/*Improved Firebolt*/
					e.Player.LearnSpell(18127);
					/*Improved Immolate*/
					e.Player.LearnSpell(17836);
					/*Improved Lash of Pain*/
					e.Player.LearnSpell(18129);
					/*Improved Searing Pain*/
					e.Player.LearnSpell(17932);
					/*Improved Shadow Bolt*/
					e.Player.LearnSpell(17803);
					/*Intensity*/
					e.Player.LearnSpell(18136);
					/*Pyroclasm*/
					e.Player.LearnSpell(18073);
					/*Ruin*/
					e.Player.LearnSpell(17959);
					/*Shadowburn*/
					e.Player.LearnSpell(17877);
					#endregion
					#endregion
					break; 
					#endregion
					#region Warrior
				case Classes.Warrior:
					#region SPELLS
					#region ARMS
					/*Battle Stance Passive*/
					e.Player.LearnSpell(21156);
					/*Charge*/
					e.Player.LearnSpell(100);	//1
					e.Player.LearnSpell(6178);	//2
					e.Player.LearnSpell(11578);	//3
					/*Hamstring*/
					e.Player.LearnSpell(1715);	//1
					e.Player.LearnSpell(7372);	//2
					e.Player.LearnSpell(7373);	//3
					/*Heroic Strike*/
					e.Player.LearnSpell(284);	//2
					e.Player.LearnSpell(285);	//3
					e.Player.LearnSpell(1608);	//4
					e.Player.LearnSpell(11564);	//5
					e.Player.LearnSpell(11565);	//6
					e.Player.LearnSpell(11566);	//7
					e.Player.LearnSpell(11567);	//8
					/*Mortal Strike*/
					e.Player.LearnSpell(21551);	//2
					e.Player.LearnSpell(21552);	//3
					e.Player.LearnSpell(21553);	//4
					/*Mocking Blow*/
					e.Player.LearnSpell(694);	//1
					e.Player.LearnSpell(7400);	//2
					e.Player.LearnSpell(7402);	//3
					e.Player.LearnSpell(20559);	//4
					e.Player.LearnSpell(20560);	//5
					/*Overpower*/
					e.Player.LearnSpell(7384);	//1
					e.Player.LearnSpell(7887);	//2
					e.Player.LearnSpell(11584);	//3
					e.Player.LearnSpell(11585);	//4
					/*Rend*/
					e.Player.LearnSpell(772);	//1
					e.Player.LearnSpell(6546);	//2
					e.Player.LearnSpell(6547);	//3
					e.Player.LearnSpell(6548);	//4
					e.Player.LearnSpell(11572);	//5
					e.Player.LearnSpell(11573);	//6
					e.Player.LearnSpell(11574);	//7
					/*Retaliation*/
					e.Player.LearnSpell(20230);
					/*Thunder Clap*/
					e.Player.LearnSpell(6343);	//1
					e.Player.LearnSpell(8198);	//2
					e.Player.LearnSpell(8204);	//3
					e.Player.LearnSpell(8205);	//4
					e.Player.LearnSpell(11580);	//5
					e.Player.LearnSpell(11581);	//6
					#endregion
					#region FURY
					/*Battle Shout*/
					e.Player.LearnSpell(6673);	//1
					e.Player.LearnSpell(5242);	//2
					e.Player.LearnSpell(6192);	//3
					e.Player.LearnSpell(11549);	//4
					e.Player.LearnSpell(11550);	//5
					e.Player.LearnSpell(11551);	//6
					/*Berserker Rage*/
					e.Player.LearnSpell(18499);
					/*Berserker Stance*/
					e.Player.LearnSpell(2458);
					/*Berserker Stance Passive*/
					e.Player.LearnSpell(7381);
					/*Challenging Shout*/
					e.Player.LearnSpell(1161);
					/*Cleave*/
					e.Player.LearnSpell(845);	//1
					e.Player.LearnSpell(7369);	//2
					e.Player.LearnSpell(11608);	//3
					e.Player.LearnSpell(11609);	//4
					e.Player.LearnSpell(20569);	//5
					/*Demoralizing Shout*/
					e.Player.LearnSpell(1160);	//1
					e.Player.LearnSpell(6190);	//2
					e.Player.LearnSpell(11554);	//3
					e.Player.LearnSpell(11555);	//4
					e.Player.LearnSpell(11556);	//5
					/*Execute*/
					e.Player.LearnSpell(5308);	//1
					e.Player.LearnSpell(20658);	//2
					e.Player.LearnSpell(20660);	//3
					e.Player.LearnSpell(20661);	//4
					e.Player.LearnSpell(20662);	//5
					/*Intercept*/
					e.Player.LearnSpell(20252);	//1
					e.Player.LearnSpell(20616);	//2
					e.Player.LearnSpell(20617);	//3
					/*Intimidating Shout*/
					e.Player.LearnSpell(5246);
					/*Pummel*/
					e.Player.LearnSpell(6552);	//1
					e.Player.LearnSpell(6554);	//2
					/*Recklessness*/
					e.Player.LearnSpell(1719);
					/*Slam*/
					e.Player.LearnSpell(1464);	//1
					e.Player.LearnSpell(8820);	//2
					e.Player.LearnSpell(11604);	//3
					e.Player.LearnSpell(11605);	//4
					/*Whirlwind*/
					e.Player.LearnSpell(1680);					
					#endregion
					#region PROTECTION
					/*Bloodrage*/
					e.Player.LearnSpell(2687);
					/*Defensive Stance*/
					e.Player.LearnSpell(71);
					/*Defensive Stance Passive*/
					e.Player.LearnSpell(7376);
					/*Disarm*/
					e.Player.LearnSpell(676);
					/*Revenge*/
					e.Player.LearnSpell(6572);	//1
					e.Player.LearnSpell(6574);	//2
					e.Player.LearnSpell(7379);	//3
					e.Player.LearnSpell(11600);	//4
					e.Player.LearnSpell(11601);	//5
					/*Shield Bash*/
					e.Player.LearnSpell(72);	//1
					e.Player.LearnSpell(1671);	//2
					e.Player.LearnSpell(1672);	//3
					/*Shield Block*/
					e.Player.LearnSpell(2565);
					/*Shield Wall*/
					e.Player.LearnSpell(871);
					/*Sunder Armor*/
					e.Player.LearnSpell(7386);	//1
					e.Player.LearnSpell(7405);	//2
					e.Player.LearnSpell(8380);	//3
					e.Player.LearnSpell(11596);	//4
					e.Player.LearnSpell(11597);	//5
					/*Taunt*/
					e.Player.LearnSpell(355);
					#endregion
					#endregion region
					#region TALENTS
					#region ARMS
					/*Anger Management*/
					e.Player.LearnSpell(12296);
					/*Axe Specialization*/
					e.Player.LearnSpell(12785);
					/*Deep Wounds*/
					e.Player.LearnSpell(12867);
					/*Deflection*/
					e.Player.LearnSpell(16466);
					/*Impale*/
					e.Player.LearnSpell(16494);
					/*Improved Charge*/
					e.Player.LearnSpell(12697);
					/*Improved Hamstring*/
					e.Player.LearnSpell(23695);
					/*Improved Heroic Strike*/
					e.Player.LearnSpell(12664);
					/*Improved Overpower*/
					e.Player.LearnSpell(12963);
					/*Improved Rend*/
					e.Player.LearnSpell(12659);
					/*Improved Thunder Clap*/
					e.Player.LearnSpell(12666);
					/*Mace Specialization*/
					e.Player.LearnSpell(12704);
					/*Mortal Strike*/
					e.Player.LearnSpell(12294);
					/*Polearm Specialization*/
					e.Player.LearnSpell(12833);
					/*Sweeping Strikes*/
					e.Player.LearnSpell(12292);
					/*Sword Specialization*/
					e.Player.LearnSpell(12815);
					/*Tactical Mastery*/
					e.Player.LearnSpell(12679);
					/*Two-Handed Weapon Specialization*/
					e.Player.LearnSpell(12714);
					#endregion
					#region FURY
					/*Blood Craze*/
					e.Player.LearnSpell(16492);
					/*Bloodthirst*/
					e.Player.LearnSpell(23881);
					/*Booming Voice*/
					e.Player.LearnSpell(12838);
					/*Cruelty*/
					e.Player.LearnSpell(12856);
					/*Death Wish*/
					e.Player.LearnSpell(12328);
					/*Dual Wield Specialization*/
					e.Player.LearnSpell(23588);
					/*Enrage*/
					e.Player.LearnSpell(13048);
					/*Flurry*/
					e.Player.LearnSpell(12974);
					/*Improved Battle Shout*/
					e.Player.LearnSpell(12861);
					/*Improved Berserker Rage*/
					e.Player.LearnSpell(20501);
					/*Improved Cleave*/
					e.Player.LearnSpell(20496);
					/*Improved Demoralizing Shout*/
					e.Player.LearnSpell(12879);
					/*Improved Execute*/
					e.Player.LearnSpell(20503);
					/*Improved Intercept*/
					e.Player.LearnSpell(20505);
					/*Improved Slam*/
					e.Player.LearnSpell(20499);
					/*Piercing Howl*/
					e.Player.LearnSpell(12323);
					/*Unbridled Wrath*/
					e.Player.LearnSpell(13002);
					#endregion
					#region PROTECTION
					/*Anticipation*/
					e.Player.LearnSpell(12753);
					/*Concussion Blow*/
					e.Player.LearnSpell(12809);
					/*Defiance*/
					e.Player.LearnSpell(12792);
					/*Improved Bloodrage*/
					e.Player.LearnSpell(12818);
					/*Improved Disarm*/
					e.Player.LearnSpell(12807);
					/*Improved Revenge*/
					e.Player.LearnSpell(12800);
					/*Improved Shield Bash*/
					e.Player.LearnSpell(12958);
					/*Improved Shield Block*/
					e.Player.LearnSpell(12944);
					/*Improved Shield Wall*/
					e.Player.LearnSpell(12803);
					/*Improved Sunder Armor*/
					e.Player.LearnSpell(12811);
					/*Improved Taunt*/
					e.Player.LearnSpell(12765);
					/*Iron Will*/
					e.Player.LearnSpell(12962);
					/*Last Stand*/
					e.Player.LearnSpell(12975);
					/*One-Handed Weapon Specialization*/
					e.Player.LearnSpell(16542);
					/*Shield Slam*/
					e.Player.LearnSpell(23922);
					/*Shield Specialization*/
					e.Player.LearnSpell(12727);
					/*Toughness*/
					e.Player.LearnSpell(12764);
					#endregion
					#endregion
					break;
					#endregion
			} 
			return true; 
		} 
	} 
}