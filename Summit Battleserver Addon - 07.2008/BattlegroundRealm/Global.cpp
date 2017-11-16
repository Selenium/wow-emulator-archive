#include "Global.h"

void SetupGlobal()
{
	Global::Initialize();
}

void Global::Initialize()
{
	CREATE_HOOK(ew1,FirstEnterWorldHook,ALL_MAPS,&Global::OnFirstEnterWorld)
	CREATE_HOOK(ew5,EnterWorldHook,ALL_MAPS,&Global::FixWorld);
	CREATE_HOOK(ww1,EnterWorldHook,0,&Global::EnterWorld);
	CREATE_HOOK(ww2,EnterWorldHook,1,&Global::EnterWorld);
	CREATE_HOOK(ww3,EnterWorldHook,530,&Global::EnterWorld);
}

void Global::FixWorld(Player * pPlayer)
{
	if(pPlayer->m_bg)
		return;

	pPlayer->RemoveAura(32727);
	pPlayer->RemoveAura(32725);
	pPlayer->RemoveAura(32724);
	pPlayer->RemoveAura(44521);
}

void Global::EnterWorld(Player * pPlayer)
{
	if(!pPlayer->isDead())
		return;

	pPlayer->ResurrectPlayer(pPlayer);

	if(!pPlayer->HasSpell(7266))
		pPlayer->addSpell(7266);
}

void Global::OnRepopHorde(Player * pPlayer)
{
	pPlayer->EventTeleport(1, 1921.715f, -4152.15f, 40.390f);
	sEventMgr.AddEvent(pPlayer, &Player::ResurrectPlayer, pPlayer, EVENT_UNK, 100, 1, 0);
	sEventMgr.AddEvent(pPlayer, &Player::FullHPMP, EVENT_UNK, 200, 1, 0);
}

void Global::OnRepopAlliance(Player * pPlayer)
{
	pPlayer->EventTeleport(0, -5025.763f, -1255.745f, 505.299f);
	sEventMgr.AddEvent(pPlayer, &Player::ResurrectPlayer, pPlayer, EVENT_UNK, 100, 1, 0);
	sEventMgr.AddEvent(pPlayer, &Player::FullHPMP, EVENT_UNK, 200, 1, 0);
}

void Global::OnFirstEnterWorld(Player * pPlayer)
{
	/* Level 70! */
	LevelInfo * inf = objmgr.GetLevelInfo(pPlayer->getRace(),pPlayer->getClass(),70);
	if(!inf)
		return;

	pPlayer->ApplyLevelInfo(inf,70);
			// --- Common spells and abilities
		pPlayer->addSpell(6603);	  // Attack

		// --- Racial spells and abilities
		switch (pPlayer->getRace())
		{
		case RACE_HUMAN:
			pPlayer->addSpell(20599); // Dipolmacy
			pPlayer->addSpell(20864); // Mace Specialization
			pPlayer->addSpell(20600); // Perception
			pPlayer->addSpell(20597); // Sword Specialization
			pPlayer->addSpell(20598); // The Human Spirit
			break;
		case RACE_ORC:
			pPlayer->addSpell(20574); // Axe Specialization
			pPlayer->addSpell(20573); // Hardiness
			// Command Aura & Blood Fury will be added in classes
			// rather than adding here.
			break;
		case RACE_DWARF:
			pPlayer->addSpell(2481); // Find Treasure
			pPlayer->addSpell(20596); // Frost Resistance
			pPlayer->addSpell(20595); // Gun Specialization
			pPlayer->addSpell(20594); // Stoneform
			break;
		case RACE_NIGHTELF:
			pPlayer->addSpell(20583); // Nature Resistance
			pPlayer->addSpell(20582); // Quickness
			pPlayer->addSpell(20580); // Shadowmeld
			pPlayer->addSpell(20585); // Wisp Spirit
			break;
		case RACE_UNDEAD:
			pPlayer->addSpell(20577); // Cannibalize
			pPlayer->addSpell(5227); // Underwater Breathing
			pPlayer->addSpell(7744); // Will of the Forsaken
			pPlayer->addSpell(20579); // Shadow Resistance
			break;
		case RACE_TAUREN:
			pPlayer->addSpell(20552); // Cultivation
			pPlayer->addSpell(20550); // Endurance
			pPlayer->addSpell(20551); // Nature Resistance
			pPlayer->addSpell(20549); // War Stomp
			break;
		case RACE_GNOME:
			pPlayer->addSpell(20592); // Arcane Resistance
			pPlayer->addSpell(20593); // Engineering Specialization
			pPlayer->addSpell(20589); // Escape Artist
			pPlayer->addSpell(20591); // Expansive Mind
			break;
		case RACE_TROLL:
			pPlayer->addSpell(20557); // Beast Slaying
			pPlayer->addSpell(26290); // Bow Specialization
			pPlayer->addSpell(20555); // Regeneration
			pPlayer->addSpell(20558); // Throwing Specialization
			// Beserking will be added to classes rather
			// than adding to races.
			break;
		case RACE_BLOODELF:
			pPlayer->addSpell(28877); // Arcane Affinity
			pPlayer->addSpell(822); // Magic Resistance
			pPlayer->addSpell(28734); // Mana Tap
			if(pPlayer->GetPowerType() == POWER_TYPE_MANA)
			{
				pPlayer->addSpell(28730); // Arcane Torrent - Mana
			}
			if(pPlayer->GetPowerType() == POWER_TYPE_ENERGY)
			{
				pPlayer->addSpell(25046); // Arcane Torrent - Energy
			}break;
		case RACE_DRAENEI:
			pPlayer->addSpell(28875); // Gemcutting
			pPlayer->addSpell(28880); // Gift of the Naaru			
			pPlayer->addSpell(20579); // Shadow Resistance
			// Heroic & Inspiring Presences will be added into 
			// classes rather than racials.
			break;
		}

		// Some race req. were not added, because they seemed for me illogical
		// Infos: http://wowvault.ign.com/View.php?view=Classes.List
		if(pPlayer->getClass() == WARRIOR)
		{
			if (/*pPlayer->getRace() != RACE_DRAENEI && */pPlayer->getRace() != RACE_NIGHTELF)
				pPlayer->_AddSkillLine(46, 350, 350);
			if (pPlayer->getRace() != RACE_DRAENEI && pPlayer->getRace() != RACE_GNOME)
				pPlayer->_AddSkillLine(45, 350, 350);
		}
		else if(pPlayer->getClass() == PALADIN)
		{
			/*if(pPlayer->getRace() == RACE_HUMAN || pPlayer->getRace() == RACE_DWARF || pPlayer->getRace() == RACE_DRAENEI)
			{
				pPlayer->addSpell(23214); // Summon Charger (Human/Dwarf/Draenei)
				pPlayer->addSpell(13189); // Summon Warhorse (Human/Dwarf/Draenei)
			}
			else
			{
				pPlayer->addSpell(34767); // Summon Charger (Blood Elf)
				pPlayer->addSpell(34769); // Summon Warhorse (Blood Elf)
			}*/
			if(pPlayer->getRace() == RACE_BLOODELF)
			{
				pPlayer->addSpell(31892); // Seal of Blood (Blood Elf)
			}
			else
			{
				pPlayer->addSpell(31801); // Seal of Vengeance
			}
		}
		else if(pPlayer->getClass() == HUNTER)
		{
			// no racial segregation of some spells
		}
		else if(pPlayer->getClass() == ROGUE)
		{
			if (pPlayer->getRace() != RACE_BLOODELF)
			{
				pPlayer->_AddSkillLine(46, 350, 350);
				pPlayer->_AddSkillLine(43, 350, 350);
			}
			if (pPlayer->getRace() != RACE_BLOODELF && pPlayer->getRace() != RACE_GNOME)
				pPlayer->_AddSkillLine(45, 350, 350);
		}
		else if(pPlayer->getClass() == PRIEST)
		{
			if (pPlayer->getRace() != RACE_BLOODELF && pPlayer->getRace() != RACE_DRAENEI)
				pPlayer->_AddSkillLine(173, 350, 350);

			if(pPlayer->getRace() == RACE_DWARF || pPlayer->getRace() == RACE_DRAENEI)
			{
				pPlayer->addSpell(44041); // Chastise Rank 1
				pPlayer->addSpell(44043); // Chastise Rank 2
				pPlayer->addSpell(44044); // Chastise Rank 3
				pPlayer->addSpell(44045); // Chastise Rank 4
				pPlayer->addSpell(44046); // Chastise Rank 5
				pPlayer->addSpell(44047); // Chastise Rank 6
			}
			if(pPlayer->getRace() == RACE_HUMAN || pPlayer->getRace() == RACE_DWARF)
			{
				pPlayer->addSpell(13908); // Desperate Prayer Rank 1
				pPlayer->addSpell(19236); // Desperate Prayer Rank 2
				pPlayer->addSpell(19238); // Desperate Prayer Rank 3
				pPlayer->addSpell(19240); // Desperate Prayer Rank 4
				pPlayer->addSpell(19241); // Desperate Prayer Rank 5
				pPlayer->addSpell(19242); // Desperate Prayer Rank 6
				pPlayer->addSpell(19243); // Desperate Prayer Rank 7
				pPlayer->addSpell(25437); // Desperate Prayer Rank 8
			}
			if(pPlayer->getRace() == RACE_UNDEAD)
			{
				pPlayer->addSpell(2944); // Devouring Plague Rank 1
				pPlayer->addSpell(19276); // Devouring Plague Rank 2
				pPlayer->addSpell(19277); // Devouring Plague Rank 3
				pPlayer->addSpell(19278); // Devouring Plague Rank 4
				pPlayer->addSpell(19279); // Devouring Plague Rank 5
				pPlayer->addSpell(19280); // Devouring Plague Rank 6
				pPlayer->addSpell(25467); // Devouring Plague Rank 7

				pPlayer->addSpell(2652); // Touch of Weakness Rank 1
				pPlayer->addSpell(19261); // Touch of Weakness Rank 2
				pPlayer->addSpell(19262); // Touch of Weakness Rank 3
				pPlayer->addSpell(19264); // Touch of Weakness Rank 4
				pPlayer->addSpell(19265); // Touch of Weakness Rank 5
				pPlayer->addSpell(19266); // Touch of Weakness Rank 6
				pPlayer->addSpell(25461); // Touch of Weakness Rank 7
			}
			if(pPlayer->getRace() == RACE_TROLL)
			{
				pPlayer->addSpell(9035); // Hex of Weakness Rank 1
				pPlayer->addSpell(19281); // Hex of Weakness Rank 2
				pPlayer->addSpell(19282); // Hex of Weakness Rank 3
				pPlayer->addSpell(19283); // Hex of Weakness Rank 4
				pPlayer->addSpell(19284); // Hex of Weakness Rank 5
				pPlayer->addSpell(19285); // Hex of Weakness Rank 6
				pPlayer->addSpell(25470); // Hex of Weakness Rank 7

				pPlayer->addSpell(18137); // Shadowguard Rank 1
				pPlayer->addSpell(19308); // Shadowguard Rank 2
				pPlayer->addSpell(19309); // Shadowguard Rank 3
				pPlayer->addSpell(19310); // Shadowguard Rank 4
				pPlayer->addSpell(19311); // Shadowguard Rank 5
				pPlayer->addSpell(19312); // Shadowguard Rank 6
				pPlayer->addSpell(25477); // Shadowguard Rank 7
			}
			if(pPlayer->getRace() == RACE_BLOODELF)
			{
				pPlayer->addSpell(2652); // Touch of Weakness Rank 1
				pPlayer->addSpell(19261); // Touch of Weakness Rank 2
				pPlayer->addSpell(19262); // Touch of Weakness Rank 3
				pPlayer->addSpell(19264); // Touch of Weakness Rank 4
				pPlayer->addSpell(19265); // Touch of Weakness Rank 5
				pPlayer->addSpell(19266); // Touch of Weakness Rank 6
				pPlayer->addSpell(25461); // Touch of Weakness Rank 7
			}
			if(pPlayer->getRace() == RACE_BLOODELF)
			{
				pPlayer->addSpell(32676); // Consume Magic
			}
			if(pPlayer->getRace() == RACE_NIGHTELF)
			{
				pPlayer->addSpell(2651); // Elune's Grace

				pPlayer->addSpell(10797); // Starshards Rank 1
				pPlayer->addSpell(19296); // Starshards Rank 2
				pPlayer->addSpell(19299); // Starshards Rank 3
				pPlayer->addSpell(19302); // Starshards Rank 4
				pPlayer->addSpell(19303); // Starshards Rank 5
				pPlayer->addSpell(19304); // Starshards Rank 6
				pPlayer->addSpell(19305); // Starshards Rank 7
				pPlayer->addSpell(25446); // Starshards Rank 8
			}
			if(pPlayer->getRace() == RACE_HUMAN)
			{
				pPlayer->addSpell(13896); // Feedback Rank 1
				pPlayer->addSpell(19271); // Feedback Rank 2
				pPlayer->addSpell(19273); // Feedback Rank 3
				pPlayer->addSpell(19274); // Feedback Rank 4
				pPlayer->addSpell(19275); // Feedback Rank 5
				pPlayer->addSpell(25441); // Feedback Rank 6
			}
		}
		else if(pPlayer->getClass() == SHAMAN)
		{
			if (pPlayer->getRace() != RACE_DRAENEI)
			{
				pPlayer->_AddSkillLine(44, 350, 350);
				pPlayer->_AddSkillLine(173, 350, 350);
			}

			if(pPlayer->getRace() == RACE_ORC || pPlayer->getRace() == RACE_TAUREN || pPlayer->getRace() == RACE_TROLL)
			{
				pPlayer->addSpell(2825); // Bloodlust
			}
			
			if(pPlayer->getRace() == RACE_DRAENEI)
			{
				pPlayer->addSpell(32182); // Heroism
			}
		}
		else if(pPlayer->getClass() == MAGE)
		{
			if (pPlayer->getRace() != RACE_BLOODELF && pPlayer->getRace() != RACE_DRAENEI)
				pPlayer->_AddSkillLine(173, 350, 350);
		}
		else if(pPlayer->getClass() == WARLOCK)
		{
			if (pPlayer->getRace() != RACE_BLOODELF)
			{
				pPlayer->_AddSkillLine(43, 350, 350);
				pPlayer->_AddSkillLine(136, 350, 350);
			}
		}
		else if(pPlayer->getClass() == DRUID)
		{
			// no racial segregation of some spells
		}

		// Helpful variables
		uint32 Class = pPlayer->getClass();

		// --- Spells
		uint32 Spells[12][227]=
		{
			// 0	- ---------
			{},																	
			// 1	- Warrior 125 spells //
			{ 3018, 2764, 674, 6673, 2457, 78, 100, 772, 6343, 1715, 284, 2687,
			71, 6546, 7386, 355, 5242, 7384, 72, 1160, 6572, 285, 694, 2565,
			676, 8198, 845, 6547, 20230, 12678, 6192, 5246, 7405, 6190, 5308,
			1608, 6574, 1161, 6178, 7400, 7887, 871, 8204, 2458, 7369, 20252,
			6548, 1464, 11549, 18499, 20658, 7372, 11564, 1671, 11554, 7379,
			8380, 7402, 1680, 6552, 8820, 8205, 11608, 20660, 11565, 11572,
			11550, 20616, 11555, 11584, 11600, 11578, 20559, 11604, 11596,
			20661, 11566, 11580, 11609, 1719, 11573, 11551, 20617, 1672,
			11556, 7373, 11601, 11605, 20662, 11567, 20560, 6554, 11597,
			11581, 25289, 20569, 25286, 11585, 11574, 25288, 25272, 25241,
			25202, 34428, 25269, 29704, 23920, 25234, 25266, 29707, 25212,
			25225, 25264, 25231, 469, 25208, 2048, 25275, 25242, 25203,
			25236, 30324, 3411, 30357, 750, 0 },		
			// 2	- Paladin - 150 spells //
			{ 635, 21084, 19740, 20271, 498, 639, 21082, 853, 1152, 1022, 
			633, 20287, 19834, 7328, 20162, 19742, 647, 31789, 25780, 1044, 
			5573, 20288, 26573, 879, 19750, 5502, 19835, 19746, 1026, 
			20164,  20305, 5599, 19850, 5588, 10322, 2878, 1038, 19939, 20289, 
			5614, 20116, 19752, 1042, 2800, 20165, 19836, 20306, 19852, 642, 
			19940, 20290, 5615, 10324, 10278, 3472, 20166, 5627, 19977, 20922, 
			5589, 20347, 19837, 4987, 19941, 20291, 20307, 19853, 10312, 24275, 
			6940, 10328, 20929, 20772, 31895, 20356, 19978, 20923, 1020, 19942, 
			20927, 2812, 10310, 20348, 20292, 19838, 10313, 25782, 24274, 20308, 
			10326, 20729, 19854, 25894, 10308, 10329, 20930, 19943, 20293, 20357, 
			19979, 25291, 25290, 20924, 10314, 25898, 25890, 25916, 25895, 25899, 
			25918, 24239, 25292, 20928, 10318, 20773, 20349, 27158, 27147, 32223, 
			27135, 27151, 27174, 27142, 27143, 27137, 27150, 27155, 33776, 27166, 
			27138, 27152, 27180, 27144, 27145, 27139, 27154, 27160, 31884, 27140, 
			27148, 27173, 27149, 27153, 27141, 27169, 27136, 27179, 750, 0 },										
			// 3	- Hunter - 145 spells
			{ 3018, 8737, 75, 2973, 1494, 13163, 1978, 3044, 1130, 5116, 14260, 
			13165, 5149, 883, 2641, 6991, 982, 13549, 1515, 19883, 14281, 20736, 
			136, 2974, 6197, 1002, 1513, 13795, 1495, 14261, 14318, 2643,  13550, 
			19884, 14282, 5118, 781, 14274, 1499, 3111, 14323, 3043, 1462, 14262, 
			19885, 14302, 3045, 13551, 19880, 14283, 14319, 13809, 3661, 13161, 
			15629, 5384, 14269, 14288, 14326, 1543, 14263, 19878, 14272, 13813, 
			13552, 14284, 14303, 3662, 3034, 14320, 14267, 13159, 15630, 14310, 
			14324, 14264, 19882, 1510, 14289, 13553, 14285, 14316, 13542, 14270, 
			20043, 14304,  14327, 14279, 14321, 14273, 14265, 15631, 13554, 19879, 
			14294, 14286, 13543, 14317, 14290, 20190, 14305, 14266, 14280, 14322, 
			14325, 14271, 13555, 14295, 27350, 14287, 25296, 15632, 27351, 14311, 
			27352, 13544, 25294, 27354, 25295, 27353, 19801, 14268, 27025, 27015, 
			34120, 27014, 34074, 27349, 27023, 34026, 27018, 27021, 27016, 27022, 
			27044, 27045, 27046, 34600, 27019, 27020, 27364, 34477, 36916, 27362, 
			27068, 0 },
			// 4	- Rogue - 135 spells
			{ 3018, 2764, 674, 2098, 1752, 53, 921, 1776, 1757, 5277, 6760, 6770, 
			5171, 2983, 2589, 1766, 8647, 703, 1758, 6761, 1966, 1804, 8676, 1777, 
			2590, 3420, 8681, 2842, 1943, 1725, 8631, 1759, 1856, 2836, 6762, 5763, 
			8724, 1833, 8649, 1767,  2591, 6768, 8687, 8639, 2070, 2835, 1842, 8632, 
			408, 1760, 8623, 8629, 13220, 8725, 2094, 8696, 8721, 8650, 8691, 8640, 
			2837, 8633, 8694, 8621, 8624, 8637, 1860, 13228, 11267, 1768, 6774, 1857, 
			11279, 11341, 11273, 11357, 11197, 11289, 11285, 11293, 11299, 11297, 13229, 
			11268, 3421, 26669, 8643, 11280, 11303, 11342, 11400, 11274, 11358, 11290, 
			11294, 11300, 11198, 13230, 11269, 1769, 11305, 11281, 25300, 25347, 31016, 
			25302, 11286, 11343, 11275, 1787, 26839, 26969,  32645, 26861, 26889, 26679, 
			26865, 27448, 27283, 27441, 31224, 26866, 38764, 26786, 26863, 26892, 26867, 
			32684, 38768, 27282, 26884, 5938, 26862, 0 },
			// 5	- Priest - 169 spells
			{ 5019, 227, 2050, 1243, 585, 2052, 589, 17, 591, 586, 139, 2053, 8092, 2006, 
			594, 32548, 588, 1244, 592, 528, 8122, 6074, 598, 2054, 8102, 527, 600, 970, 
			9578, 6346, 2061, 14914, 7128, 453, 6075, 9484, 2055, 8103, 2096, 2010, 984, 
			15262, 8129, 1245, 3747, 9472, 6076, 992, 6063, 8104, 8124, 9579, 15263, 602, 
			605, 6065, 596, 976, 1004, 552, 9473, 8131, 6077, 6064, 1706, 8105, 10880, 2767, 
			988, 15264, 8192, 2791, 6066, 9474, 6078, 6060, 9592, 2060, 1006, 10874, 8106, 996, 
			9485, 15265, 10898, 10888, 10957, 10892, 10915, 10911, 10909, 10927, 10963, 10945, 
			10881, 10933, 15266, 10875, 10937, 10899, 21562, 10941, 10916, 10951, 10960, 10928, 
			10893, 10964, 10946, 10953, 15267, 10900, 10934, 10917, 10876, 27683, 10890, 10929, 
			10958, 10965, 10947, 10912, 20770, 10894, 10942, 25314, 15261, 10952, 10938, 10901, 
			21564, 10961, 25316, 27681, 25315, 10955, 25233, 25363, 32379, 25210, 25379, 25372, 
			32546, 25217, 25221, 25367, 25429, 25384, 34433, 25235,  25596, 25213, 25308, 33076, 
			25435, 25433, 25431, 25375, 25364, 25380, 32375, 25389, 25218, 25392, 39374, 32999, 
			25222, 32996, 25368, 0 },
			// 6	- ---------
			{},
			// 7	- Shaman - 218 spells
			{ 196, 197, 198, 199, 9116, 227, 1180, 15590, 674, 331, 403, 8017, 36591, 8042, 8071, 
			2484, 332, 8044, 529, 324, 8018, 5730, 8050, 8024, 3599, 8075, 2008, 1535, 547, 
			370, 8045, 548, 8154, 526, 325, 8019, 8052, 8027, 913, 6390, 8143,  8056, 8033, 2645, 
			5394, 8004, 915, 6363, 2870, 8498, 8166, 131, 20609, 8046, 8181, 939, 905, 10399, 8155, 
			8160, 6196, 8030, 943, 8190, 5675, 8184, 8053, 8227, 8038, 8008, 6391, 546, 8177, 6375, 
			10595, 20608, 6364, 36936, 8232, 421, 45297, 8499, 959, 6041, 945, 8012, 8512, 8058, 16314, 
			6495, 10406, 20610, 10412, 16339, 8010, 10585, 10495, 15107, 8170, 8249, 10478, 10456, 10391, 
			6392, 8161, 1064, 930, 10447, 6377, 8005, 8134, 6365, 8235, 11314, 10537, 8835, 10613, 10466,  
			10392, 10600, 16315, 10407, 10622, 16341, 10472, 10586, 10496, 15111, 20776, 2860, 10413, 10526,
			16355, 10395, 10431, 10427, 10462, 15207, 10437, 25908, 10486, 11315, 10448, 10467, 10442, 10614, 
			10623, 10479, 16316, 10408, 10605,  16342, 10627, 10396, 15208, 10432, 10587, 10497, 15112, 10538,
			16387, 10473, 16356, 10428, 20777, 10414, 29228, 25359, 10463, 25357, 10468, 10601, 10438, 25361, 
			16362, 25422, 25546, 25585, 25448, 25479, 24398, 25439, 25391, 25469, 25508, 25489, 3738, 25552, 
			25570, 25528, 25577, 2062, 25500, 25420, 25557, 25560, 25449, 25525, 25423, 2894, 25563, 25464, 
			25505, 25454, 25567, 25574, 25533, 33736, 25442, 25547, 25457, 25396, 25472, 25485, 25509, 25587, 
			8737, 0 },
			// 8	- Mage - 181 spells
			{ 5019, 1459, 133, 168, 5504, 116, 587, 2136, 143, 5143, 205, 118, 5505, 7300, 122, 597, 604, 145, 
			130, 1449, 1460, 2137, 837, 5144, 2120, 1008, 3140, 475, 1953, 10, 5506, 12051, 543, 7301, 7322, 1463, 
			12824, 8437, 990, 2138, 6143, 2948, 5145,  2139, 8450, 8400, 2121, 120, 865, 8406, 1461, 6141, 759, 
			8494, 8444, 8455, 8438, 6127, 8412, 8457, 8401, 7302, 8416, 6129, 8422, 8461, 8407, 8492, 6117, 8445, 
			8427, 8451, 8402, 8495, 8439, 3552, 8413, 8408, 8417, 10138, 8458, 8423, 6131, 7320, 12825, 8446, 10169, 
			10156, 10159, 10144, 10148, 8462, 10185, 10179, 10191, 10201, 10197, 22782, 10205, 10211, 10053, 10173, 
			10149, 10215, 10160, 10139, 10223, 10180, 10219, 10186, 10145, 10177, 10192, 10206, 10170, 10202,10199, 
			10150, 10230, 23028, 10157, 10212, 10216, 10181, 10161, 10054, 22783, 10207, 25345, 10187, 28612, 10140, 
			10174, 10225, 10151, 28609, 25304, 10220, 10193, 28272, 28271, 12826, 27078, 27080, 25306, 30482, 27130, 
			27075, 27071, 30451,  27086, 27087, 37420, 27073, 27070, 30455, 33944, 27088, 27085, 27101, 66, 27131, 
			33946, 38699, 27128, 27072, 27124, 27125, 27127, 27082, 27126, 38704, 33717, 27090, 27079, 38692, 32796, 
			38697, 43987, 27074, 30449, 0 },
			// 9	- Warlock - 182 spells
			{ 687, 5019, 348, 686, 688, 172, 702, 1454, 695, 980, 5782, 6201, 696, 1120, 707, 697, 1108, 755, 705, 6222, 
			704, 689, 1455, 5697, 693, 1014, 5676, 706, 3698, 1094, 5740, 698, 1088, 712, 6202, 6205, 699, 126, 6223, 5138, 
			8288, 5500, 1714, 132, 1456, 17919, 710, 6366, 6217, 7658, 3699, 1106, 20752, 1086, 709, 1098, 1949, 2941, 691, 
			1490, 7646, 6213, 6229, 7648, 5699, 6226, 6219, 17920, 17951, 2362, 3700, 11687, 7641, 11711, 7651, 8289, 20755, 
			11733, 5484, 11665, 5784, 7659, 11707, 6789, 11683, 17921, 11739, 11671, 17862, 11703, 11725, 11693, 11659, 17952, 
			11729, 11721, 11699, 11688, 11677, 18647, 17727, 11712, 6353, 20756, 11719, 17925, 11734, 11667, 1122, 17922, 11708, 
			11675, 11694, 11660, 11740,  11672, 11700, 11704, 11684, 17928, 17953, 11717, 17937, 6215, 11689, 17924, 11730, 11713, 
			17926, 11726, 11678, 17923, 25311, 20757, 17728, 603, 11722, 11735, 11695, 11668, 25309, 18540, 11661, 28610, 23161, 
			27224, 27219, 28176, 25307, 27221, 29722, 27211, 27216, 27210, 27250, 28172, 29858, 27218, 27229, 27217, 27259, 27230, 
			27223, 27213, 27222, 29893, 27226, 27228, 30909, 27220, 28189, 27215, 27212, 27209, 27238, 30910, 27260, 30908, 32231, 
			30459, 27243, 30545, 0 },
			// 10	- ---------
			{},
			// 11	- Druid - 227 spells
			{ 5185, 1126, 5176, 8921, 774, 467, 5177, 339, 5186, 5487, 99, 6795, 5232, 6807, 8924, 1058, 5229, 8936, 5211, 8946, 5187, 
			782, 5178, 1066, 8925, 1430, 779, 1062, 770, 2637, 6808, 8938, 768, 1082, 1735, 5188, 6756, 5215, 20484, 1079, 2912, 8926,
			2090, 5221, 2908, 5179, 1822, 8939, 2782, 780, 1075, 5217, 2893, 1850, 5189, 6809, 8949, 5209, 3029, 8998, 5195, 8927, 2091, 
			9492, 6798, 778, 24974, 5234, 20739, 8940, 6800, 740, 783, 5180, 9490, 22568, 6778, 6785, 5225, 8972, 8928, 1823, 3627, 8950, 
			769, 8914, 22842, 9005, 8941, 9493, 6793, 5201, 5196, 8903, 18657, 8992, 8955, 6780, 9000, 9634, 20719, 22827, 16914, 29166, 
			24975, 8907, 8929, 6783, 20742, 8910, 8918, 9747, 9749, 9745, 6787, 9750, 8951, 22812, 9758, 1824, 9752, 9754, 9756, 8983, 
			9821, 22895, 9833, 9823, 9839, 9829, 8905, 9849, 9852, 22828, 9856, 9845, 21849, 9888, 17401, 24976, 9884, 9880, 9866, 20747, 
			9875, 9862, 9892, 9898, 9834, 9840, 9894, 9907, 9904, 9857, 9830, 9901, 9908,  9910, 9912, 22829, 22896, 9889, 9827, 9850, 9853, 
			18658, 9881, 9835, 9867, 9841, 9876, 31709, 31018, 21850, 25297, 17402, 24977, 9885, 9913, 20748, 9858, 25299, 9896, 25298, 9846, 
			9863, 27001, 26984, 26998, 26978, 22570, 24248, 26987, 26981, 33763, 27003, 26997, 26992, 33357, 26999, 26980, 26993, 33745, 27006, 
			27005, 27000, 26996, 27008, 26986, 26989, 33943, 27009, 27004, 26979, 26994, 26982, 26985, 33786, 26991, 27012, 27013, 26990, 26988, 
			27002, 26995, 40120, 26983 },
		};

		for (int i = 0; i < 227; i++)
		{
			if (Spells[Class][i] == 0)
				break;

			pPlayer->addSpell(Spells[Class][i]);
		}

		// --- Skills
		uint32 Skills[12][15]=
		{
			{},																	// 0	- ---------
			{ 136, 229, 473, 226, 43, 55, 44, 172, 54, 160, 176, 162, 0 },		// 1	- Warrior
			{ 55, 43, 162, 160, 54, 0 },										// 2	- Paladin
			{ 162, 44, 45, 226, 173, 473, 46, 229, 136, 43, 176, 55, 172, 0 },	// 3	- Hunter
			{ 473, 226, 162, 176, 173, 54, 0 },									// 4	- Rogue
			{ 136, 228, 162, 54, 0 },											// 5	- Priest
			{},																	// 6	- ---------
			{ 473, 162, 136, 54, 0 },											// 7	- Shaman
			{ 43, 228, 162, 136, 0 },											// 8	- Mage
			{ 228, 162, 173, 0 },												// 9	- Warlock
			{},																	// 10	- ---------
			{ 54, 473, 173, 162, 136, 160, 0 }										// 11	- Druid
		};

		for (int i = 0; i < 15; i++)
		{
			if (Skills[Class][i] == 0)
				break;

			pPlayer->_AddSkillLine(Skills[Class][i], 350, 350);
		}



	pPlayer->_AddSkillLine(762,70*5,70*5); /* Riding Skill */	

	/* Gimmeh max skeels! */
	pPlayer->_AdvanceAllSkills(70*5);

	list<uint32> itemAddList;

	// Items!
	uint32 setId = 0;
	switch(pPlayer->getClass())
	{
		case DRUID:
		{
			setId = 744;
			itemAddList.push_back(28476);
			itemAddList.push_back(24557);
			itemAddList.push_back(28378);
			break;
		}
		case WARLOCK:
			setId = 738;
			itemAddList.push_back(28297);
			itemAddList.push_back(28378);
			break;
		case PALADIN:
			setId = 752;
			itemAddList.push_back(28299);
			itemAddList.push_back(28377);
			break;
		case MAGE:
		{
			setId = 741;
			itemAddList.push_back(28297);
			itemAddList.push_back(28378);
			break;
		}
		case PRIEST:
		{
			setId = 739;
			itemAddList.push_back(24557);
			itemAddList.push_back(28378);
			break;
		}
		case ROGUE:
		{
			setId = 745;
			itemAddList.push_back(28305);
			itemAddList.push_back(28302);
			itemAddList.push_back(28377);
			break;
		}
		case SHAMAN:
		{
			setId = 748;
			itemAddList.push_back(28305);
			itemAddList.push_back(28305);
			itemAddList.push_back(28378);
			break;
		}
		case HUNTER:
		{
			setId = 749;
			itemAddList.push_back(28294);
			itemAddList.push_back(28377);
			break;
		}
		case WARRIOR:
		{
			setId = 750;
			itemAddList.push_back(28298);
			itemAddList.push_back(28377);
			break;
		}
		default:
			break;
	}
	ItemSetEntry *entry = dbcItemSet.LookupEntry(setId);
	if(!entry) return;
	std::list<ItemPrototype*>* l = objmgr.GetListForItemSet(setId);
	if(!l) return;
	
	for(std::list<ItemPrototype*>::iterator itr = l->begin(); itr != l->end(); itr++)
	{
		Item *itm = objmgr.CreateItem((*itr)->ItemId, pPlayer);
		if(!itm) continue;

		uint8 slot = pPlayer->GetItemInterface()->GetItemSlotByType(itm->GetProto()->InventoryType);
		if(pPlayer->GetItemInterface()->GetInventoryItem(-1, slot))
		{
			pPlayer->GetItemInterface()->RemoveItemAmt(pPlayer->GetItemInterface()->GetInventoryItem(-1, slot)->GetProto()->ItemId, 1);
		}

		pPlayer->GetItemInterface()->SafeAddItem(itm, -1, slot);
	}

	for(list<uint32>::iterator itr = itemAddList.begin(); itr != itemAddList.end(); itr++)
	{
		Item *itm = objmgr.CreateItem((*itr), pPlayer);
		if(!itm) continue;

		uint8 slot = pPlayer->GetItemInterface()->GetItemSlotByType(itm->GetProto()->InventoryType);
		if(pPlayer->GetItemInterface()->GetInventoryItem(-1, slot))
		{
			pPlayer->GetItemInterface()->RemoveItemAmt(pPlayer->GetItemInterface()->GetInventoryItem(-1, slot)->GetProto()->ItemId, 1);
		}

		pPlayer->GetItemInterface()->SafeAddItem(itm, -1, slot);
	}

}
