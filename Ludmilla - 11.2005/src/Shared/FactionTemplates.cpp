#include "StdAfx.h"
#include "FactionTemplates.h"

uint16 gFactionTemplates[1555] = {0, };

void initFactionTemplates()
{
    //                               fight friendly hostile
    gFactionTemplates[   1] = 0x32C; // 0011 0010 1100 = PLAYER:Human
    gFactionTemplates[   2] = 0x54A; // 0101 0100 1010 = PLAYER:Orc
    gFactionTemplates[   3] = 0x32C; // 0011 0010 1100 = PLAYER:Dwarf
    gFactionTemplates[   4] = 0x32C; // 0011 0010 1100 = PLAYER:Night Elf
    gFactionTemplates[   5] = 0x54A; // 0101 0100 1010 = PLAYER:Undead
    gFactionTemplates[   6] = 0x54A; // 0101 0100 1010 = PLAYER:Tauren 
    gFactionTemplates[   7] = 0x000; // 0000 0000 0000 = Creature
    gFactionTemplates[  10] = 0x320; // 0011 0010 0000 = Escortee
    gFactionTemplates[  11] = 0x32C; // 0011 0010 1100 = Stormwind
    gFactionTemplates[  12] = 0x224; // 0010 0010 0100 = Stormwind
    gFactionTemplates[  14] = 0x801; // 1000 0000 0001 = Monster
    gFactionTemplates[  15] = 0x000; // 0000 0000 0000 = Creature
    gFactionTemplates[  16] = 0x801; // 1000 0000 0001 = Monster
    gFactionTemplates[  17] = 0x801; // 1000 0000 0001 = Defias Brotherhood
    gFactionTemplates[  18] = 0x801; // 1000 0000 0001 = Murloc
    gFactionTemplates[  19] = 0x801; // 1000 0000 0001 = Gnoll:Redridge
    gFactionTemplates[  20] = 0x801; // 1000 0000 0001 = Gnoll:Riverpaw
    gFactionTemplates[  21] = 0x801; // 1000 0000 0001 = Undead:Scourge
    gFactionTemplates[  22] = 0x801; // 1000 0000 0001 = Beast - Spider
    gFactionTemplates[  23] = 0x224; // 0010 0010 0100 = Gnomeregan Exiles
    gFactionTemplates[  24] = 0x801; // 1000 0000 0001 = Worgen
    gFactionTemplates[  25] = 0x800; // 1000 0000 0000 = Kobold
    gFactionTemplates[  26] = 0x801; // 1000 0000 0001 = Kobold
    gFactionTemplates[  27] = 0x801; // 1000 0000 0001 = Defias Brotherhood
    gFactionTemplates[  28] = 0x801; // 1000 0000 0001 = Troll:Bloodscalp
    gFactionTemplates[  29] = 0x442; // 0100 0100 0010 = Orgrimmar
    gFactionTemplates[  30] = 0x801; // 1000 0000 0001 = Troll:Skullsplitter
    gFactionTemplates[  31] = 0x000; // 0000 0000 0000 = Prey
    gFactionTemplates[  32] = 0x000; // 0000 0000 0000 = Beast - Wolf
    gFactionTemplates[  33] = 0x540; // 0101 0100 0000 = Escortee
    gFactionTemplates[  34] = 0x800; // 1000 0000 0000 = Defias Brotherhood
    gFactionTemplates[  35] = 0x010; // 0000 0001 0000 = Friendly
    gFactionTemplates[  36] = 0x000; // 0000 0000 0000 = Trogg
    gFactionTemplates[  37] = 0x801; // 1000 0000 0001 = Troll:Frostmane
    gFactionTemplates[  38] = 0x801; // 1000 0000 0001 = Beast - Wolf
    gFactionTemplates[  39] = 0x801; // 1000 0000 0001 = Gnoll:Shadowhide
    gFactionTemplates[  40] = 0x801; // 1000 0000 0001 = Orc:Blackrock
    gFactionTemplates[  41] = 0x801; // 1000 0000 0001 = Villian
    gFactionTemplates[  42] = 0x110; // 0001 0001 0000 = Victim
    gFactionTemplates[  43] = 0x800; // 1000 0000 0000 = Villian
    gFactionTemplates[  44] = 0x801; // 1000 0000 0001 = Beast - Bear
    gFactionTemplates[  45] = 0x801; // 1000 0000 0001 = Ogre
    gFactionTemplates[  46] = 0x801; // 1000 0000 0001 = Kurzen's Mercenaries
    gFactionTemplates[  47] = 0x801; // 1000 0000 0001 = Venture Company
    gFactionTemplates[  48] = 0x801; // 1000 0000 0001 = Beast - Raptor
    gFactionTemplates[  49] = 0x801; // 1000 0000 0001 = Basilisk
    gFactionTemplates[  50] = 0x801; // 1000 0000 0001 = Dragonflight:Green
    gFactionTemplates[  51] = 0x801; // 1000 0000 0001 = Lost Ones
    gFactionTemplates[  52] = 0x800; // 1000 0000 0000 = Gizlock's Dummy
    gFactionTemplates[  53] = 0x22C; // 0010 0010 1100 = Human:Night Watch
    gFactionTemplates[  54] = 0x801; // 1000 0000 0001 = Dwarf:Dark Iron
    gFactionTemplates[  55] = 0x224; // 0010 0010 0100 = Ironforge
    gFactionTemplates[  56] = 0x22C; // 0010 0010 1100 = Human:Night Watch
    gFactionTemplates[  57] = 0x32C; // 0011 0010 1100 = Ironforge
    gFactionTemplates[  58] = 0x800; // 1000 0000 0000 = Creature
    gFactionTemplates[  59] = 0x801; // 1000 0000 0001 = Trogg
    gFactionTemplates[  60] = 0x801; // 1000 0000 0001 = Dragonflight:Red
    gFactionTemplates[  61] = 0x801; // 1000 0000 0001 = Gnoll:Mosshide
    gFactionTemplates[  62] = 0x801; // 1000 0000 0001 = Orc:Dragonmaw
    gFactionTemplates[  63] = 0x801; // 1000 0000 0001 = Gnome:Leper
    gFactionTemplates[  64] = 0x224; // 0010 0010 0100 = Gnomeregan Exiles
    gFactionTemplates[  65] = 0x000; // 0000 0000 0000 = Orgrimmar
    gFactionTemplates[  66] = 0x801; // 1000 0000 0001 = Leopard
    gFactionTemplates[  67] = 0x801; // 1000 0000 0001 = Scarlet Crusade
    gFactionTemplates[  68] = 0x442; // 0100 0100 0010 = Undercity
    gFactionTemplates[  69] = 0x000; // 0000 0000 0000 = Ratchet
    gFactionTemplates[  70] = 0x801; // 1000 0000 0001 = Gnoll:Rothide
    gFactionTemplates[  71] = 0x54A; // 0101 0100 1010 = Undercity
    gFactionTemplates[  72] = 0x801; // 1000 0000 0001 = Beast - Gorilla
    gFactionTemplates[  73] = 0x801; // 1000 0000 0001 = Beast - Carrion Bird
    gFactionTemplates[  74] = 0x801; // 1000 0000 0001 = Naga
    gFactionTemplates[  76] = 0x024; // 0000 0010 0100 = Dalaran
    gFactionTemplates[  77] = 0x800; // 1000 0000 0000 = Forlorn Spirit
    gFactionTemplates[  78] = 0x801; // 1000 0000 0001 = Darkhowl
    gFactionTemplates[  79] = 0x32C; // 0011 0010 1100 = Darnassus
    gFactionTemplates[  80] = 0x224; // 0010 0010 0100 = Darnassus
    gFactionTemplates[  81] = 0x801; // 1000 0000 0001 = Grell
    gFactionTemplates[  82] = 0x801; // 1000 0000 0001 = Furbolg
    gFactionTemplates[  83] = 0x442; // 0100 0100 0010 = Horde Generic
    gFactionTemplates[  84] = 0x224; // 0010 0010 0100 = Alliance Generic
    gFactionTemplates[  85] = 0x54A; // 0101 0100 1010 = Orgrimmar
    gFactionTemplates[  86] = 0x010; // 0000 0001 0000 = Gizlock's Charm
    gFactionTemplates[  87] = 0x801; // 1000 0000 0001 = Syndicate
    gFactionTemplates[  88] = 0x224; // 0010 0010 0100 = Hillsbrad Militia
    gFactionTemplates[  89] = 0x801; // 1000 0000 0001 = Scarlet Crusade
    gFactionTemplates[  90] = 0x801; // 1000 0000 0001 = Demon
    gFactionTemplates[  91] = 0x801; // 1000 0000 0001 = Elemental
    gFactionTemplates[  92] = 0x801; // 1000 0000 0001 = Spirit
    gFactionTemplates[  93] = 0x801; // 1000 0000 0001 = Monster
    gFactionTemplates[  94] = 0x080; // 0000 1000 0000 = Treasure
    gFactionTemplates[  95] = 0x801; // 1000 0000 0001 = Gnoll:Mudsnout
    gFactionTemplates[  96] = 0x220; // 0010 0010 0000 = HIllsbrad:Southshore Mayor
    gFactionTemplates[  97] = 0x800; // 1000 0000 0000 = Syndicate
    gFactionTemplates[  98] = 0x44A; // 0100 0100 1010 = Undercity
    gFactionTemplates[  99] = 0x800; // 1000 0000 0000 = Victim
    gFactionTemplates[ 100] = 0x009; // 0000 0000 1001 = Treasure
    gFactionTemplates[ 101] = 0x024; // 0000 0010 0100 = Treasure
    gFactionTemplates[ 102] = 0x042; // 0000 0100 0010 = Treasure
    gFactionTemplates[ 103] = 0x801; // 1000 0000 0001 = Dragonflight:Black
    gFactionTemplates[ 104] = 0x442; // 0100 0100 0010 = Thunder Bluff
    gFactionTemplates[ 105] = 0x54A; // 0101 0100 1010 = Thunder Bluff
    gFactionTemplates[ 106] = 0x44A; // 0100 0100 1010 = Horde Generic
    gFactionTemplates[ 107] = 0x801; // 1000 0000 0001 = Troll:Frostmane
    gFactionTemplates[ 108] = 0x000; // 0000 0000 0000 = Syndicate
    gFactionTemplates[ 109] = 0x801; // 1000 0000 0001 = Quilboar:Razormane 2
    gFactionTemplates[ 110] = 0x801; // 1000 0000 0001 = Quilboar:Razormane 2
    gFactionTemplates[ 111] = 0x801; // 1000 0000 0001 = Quilboar:Bristleback
    gFactionTemplates[ 112] = 0x801; // 1000 0000 0001 = Quilboar:Bristleback
    gFactionTemplates[ 113] = 0x110; // 0001 0001 0000 = Escortee
    gFactionTemplates[ 114] = 0x001; // 0000 0000 0001 = Treasure
    gFactionTemplates[ 115] = 0x32C; // 0011 0010 1100 = PLAYER:Gnome
    gFactionTemplates[ 116] = 0x54A; // 0101 0100 1010 = PLAYER:Troll
    gFactionTemplates[ 118] = 0x442; // 0100 0100 0010 = Undercity
    gFactionTemplates[ 119] = 0x801; // 1000 0000 0001 = Bloodsail Buccaneers
    gFactionTemplates[ 120] = 0x000; // 0000 0000 0000 = Booty Bay
    gFactionTemplates[ 121] = 0x108; // 0001 0000 1000 = Booty Bay
    gFactionTemplates[ 122] = 0x224; // 0010 0010 0100 = Ironforge
    gFactionTemplates[ 123] = 0x224; // 0010 0010 0100 = Stormwind
    gFactionTemplates[ 124] = 0x224; // 0010 0010 0100 = Darnassus
    gFactionTemplates[ 125] = 0x442; // 0100 0100 0010 = Orgrimmar
    gFactionTemplates[ 126] = 0x442; // 0100 0100 0010 = Darkspear Trolls
    gFactionTemplates[ 127] = 0x001; // 0000 0000 0001 = Villian
    gFactionTemplates[ 128] = 0x801; // 1000 0000 0001 = Blackfathom
    gFactionTemplates[ 129] = 0x801; // 1000 0000 0001 = Makrura
    gFactionTemplates[ 130] = 0x801; // 1000 0000 0001 = Centaur:Kolkar
    gFactionTemplates[ 131] = 0x801; // 1000 0000 0001 = Centaur:Galak
    gFactionTemplates[ 132] = 0x801; // 1000 0000 0001 = Gelkis Clan Centaur
    gFactionTemplates[ 133] = 0x801; // 1000 0000 0001 = Magram Clan Centaur
    gFactionTemplates[ 134] = 0x801; // 1000 0000 0001 = Maraudine
    gFactionTemplates[ 148] = 0x224; // 0010 0010 0100 = Stormwind
    gFactionTemplates[ 149] = 0x220; // 0010 0010 0000 = Human:Theramore
    gFactionTemplates[ 150] = 0x32C; // 0011 0010 1100 = Human:Theramore
    gFactionTemplates[ 151] = 0x204; // 0010 0000 0100 = Human:Theramore
    gFactionTemplates[ 152] = 0x801; // 1000 0000 0001 = Quilboar:Razorfen
    gFactionTemplates[ 153] = 0x800; // 1000 0000 0000 = Quilboar:Razorfen
    gFactionTemplates[ 154] = 0x801; // 1000 0000 0001 = Quilboar:Deathshead
    gFactionTemplates[ 168] = 0x001; // 0000 0000 0001 = Enemy
    gFactionTemplates[ 188] = 0x080; // 0000 1000 0000 = Ambient
    gFactionTemplates[ 189] = 0x000; // 0000 0000 0000 = Creature
    gFactionTemplates[ 190] = 0x000; // 0000 0000 0000 = Ambient
    gFactionTemplates[ 208] = 0x220; // 0010 0010 0000 = Nethergarde Caravan
    gFactionTemplates[ 209] = 0x220; // 0010 0010 0000 = Nethergarde Caravan
    gFactionTemplates[ 210] = 0x22C; // 0010 0010 1100 = Alliance Generic
    gFactionTemplates[ 230] = 0x801; // 1000 0000 0001 = Southsea Freebooters
    gFactionTemplates[ 231] = 0x328; // 0011 0010 1000 = Escortee
    gFactionTemplates[ 232] = 0x548; // 0101 0100 1000 = Escortee
    gFactionTemplates[ 233] = 0x801; // 1000 0000 0001 = Undead:Scourge
    gFactionTemplates[ 250] = 0x118; // 0001 0001 1000 = Escortee
    gFactionTemplates[ 270] = 0x801; // 1000 0000 0001 = Wailing Caverns
    gFactionTemplates[ 290] = 0x110; // 0001 0001 0000 = Escortee
    gFactionTemplates[ 310] = 0x801; // 1000 0000 0001 = Silithid
    gFactionTemplates[ 311] = 0x800; // 1000 0000 0000 = Silithid
    gFactionTemplates[ 312] = 0x801; // 1000 0000 0001 = Beast - Spider
    gFactionTemplates[ 330] = 0x800; // 1000 0000 0000 = Wailing Caverns
    gFactionTemplates[ 350] = 0x800; // 1000 0000 0000 = Blackfathom
    gFactionTemplates[ 370] = 0x22C; // 0010 0010 1100 = ! REUSE ME 002
    gFactionTemplates[ 371] = 0x22C; // 0010 0010 1100 = ! REUSE ME 001
    gFactionTemplates[ 390] = 0x000; // 0000 0000 0000 = Booty Bay
    gFactionTemplates[ 410] = 0x801; // 1000 0000 0001 = Basilisk
    gFactionTemplates[ 411] = 0x801; // 1000 0000 0001 = Beast - Bat
    gFactionTemplates[ 412] = 0x801; // 1000 0000 0001 = Beast - Bat
    gFactionTemplates[ 413] = 0x801; // 1000 0000 0001 = Scorpid
    gFactionTemplates[ 414] = 0x801; // 1000 0000 0001 = Timbermaw Furbolgs
    gFactionTemplates[ 415] = 0x801; // 1000 0000 0001 = Titan
    gFactionTemplates[ 416] = 0x800; // 1000 0000 0000 = Titan
    gFactionTemplates[ 430] = 0x000; // 0000 0000 0000 = Taskmaster Fizzule
    gFactionTemplates[ 450] = 0x801; // 1000 0000 0001 = Wailing Caverns
    gFactionTemplates[ 470] = 0x801; // 1000 0000 0001 = Titan
    gFactionTemplates[ 471] = 0x000; // 0000 0000 0000 = Ravenholdt
    gFactionTemplates[ 472] = 0x801; // 1000 0000 0001 = Syndicate
    gFactionTemplates[ 473] = 0x000; // 0000 0000 0000 = Ravenholdt
    gFactionTemplates[ 474] = 0x000; // 0000 0000 0000 = Gadgetzan
    gFactionTemplates[ 475] = 0x108; // 0001 0000 1000 = Gadgetzan
    gFactionTemplates[ 494] = 0x801; // 1000 0000 0001 = Gnomeregan Bug
    gFactionTemplates[ 495] = 0x118; // 0001 0001 1000 = Escortee
    gFactionTemplates[ 514] = 0x801; // 1000 0000 0001 = Harpy
    gFactionTemplates[ 534] = 0x220; // 0010 0010 0000 = Alliance Generic
    gFactionTemplates[ 554] = 0x807; // 1000 0000 0111 = Burning Blade
    gFactionTemplates[ 574] = 0x801; // 1000 0000 0001 = Shadowsilk Poacher
    gFactionTemplates[ 575] = 0x801; // 1000 0000 0001 = Searing Spider
    gFactionTemplates[ 594] = 0x800; // 1000 0000 0000 = Trogg
    gFactionTemplates[ 614] = 0x010; // 0000 0001 0000 = Victim
    gFactionTemplates[ 634] = 0x800; // 1000 0000 0000 = Monster
    gFactionTemplates[ 635] = 0x000; // 0000 0000 0000 = Cenarion Circle
    gFactionTemplates[ 636] = 0x801; // 1000 0000 0001 = Timbermaw Furbolgs
    gFactionTemplates[ 637] = 0x108; // 0001 0000 1000 = Ratchet
    gFactionTemplates[ 654] = 0x801; // 1000 0000 0001 = Troll:Witherbark
    gFactionTemplates[ 655] = 0x805; // 1000 0000 0101 = Centaur:Kolkar
    gFactionTemplates[ 674] = 0x000; // 0000 0000 0000 = Dwarf:Dark Iron
    gFactionTemplates[ 694] = 0x224; // 0010 0010 0100 = Wildhammer Clan
    gFactionTemplates[ 695] = 0x000; // 0000 0000 0000 = Hydraxian Waterlords
    gFactionTemplates[ 714] = 0x440; // 0100 0100 0000 = Horde Generic
    gFactionTemplates[ 734] = 0x110; // 0001 0001 0000 = Dwarf:Dark Iron
    gFactionTemplates[ 735] = 0x110; // 0001 0001 0000 = Goblin:Dark Iron Bar Patron
    gFactionTemplates[ 736] = 0x801; // 1000 0000 0001 = Goblin:Dark Iron Bar Patron
    gFactionTemplates[ 754] = 0x801; // 1000 0000 0001 = Dwarf:Dark Iron
    gFactionTemplates[ 774] = 0x320; // 0011 0010 0000 = Escortee
    gFactionTemplates[ 775] = 0x540; // 0101 0100 0000 = Escortee
    gFactionTemplates[ 776] = 0x44A; // 0100 0100 1010 = ! REUSE ME 003
    gFactionTemplates[ 777] = 0x44A; // 0100 0100 1010 = ! REUSE ME 004
    gFactionTemplates[ 778] = 0x801; // 1000 0000 0001 = Giant
    gFactionTemplates[ 794] = 0x000; // 0000 0000 0000 = Argent Dawn
    gFactionTemplates[ 795] = 0x801; // 1000 0000 0001 = Troll:Vilebranch
    gFactionTemplates[ 814] = 0x000; // 0000 0000 0000 = Argent Dawn
    gFactionTemplates[ 834] = 0x801; // 1000 0000 0001 = Elemental
    gFactionTemplates[ 854] = 0x108; // 0001 0000 1000 = Everlook
    gFactionTemplates[ 855] = 0x000; // 0000 0000 0000 = Everlook
    gFactionTemplates[ 874] = 0x224; // 0010 0010 0100 = Wintersaber Trainers
    gFactionTemplates[ 875] = 0x224; // 0010 0010 0100 = Gnomeregan Exiles
    gFactionTemplates[ 876] = 0x442; // 0100 0100 0010 = Darkspear Trolls
    gFactionTemplates[ 877] = 0x54A; // 0101 0100 1010 = Darkspear Trolls
    gFactionTemplates[ 894] = 0x224; // 0010 0010 0100 = Human:Theramore
    gFactionTemplates[ 914] = 0x000; // 0000 0000 0000 = Training Dummy
    gFactionTemplates[ 934] = 0x801; // 1000 0000 0001 = Furbolg:Uncorrupted
    gFactionTemplates[ 954] = 0x801; // 1000 0000 0001 = Demon
    gFactionTemplates[ 974] = 0x801; // 1000 0000 0001 = Undead:Scourge
    gFactionTemplates[ 994] = 0x000; // 0000 0000 0000 = Cenarion Circle
    gFactionTemplates[ 995] = 0x442; // 0100 0100 0010 = Thunder Bluff
    gFactionTemplates[ 996] = 0x108; // 0001 0000 1000 = Cenarion Circle
    gFactionTemplates[1014] = 0x000; // 0000 0000 0000 = Shatterspear Trolls
    gFactionTemplates[1015] = 0x000; // 0000 0000 0000 = Shatterspear Trolls
    gFactionTemplates[1034] = 0x402; // 0100 0000 0010 = Horde Generic
    gFactionTemplates[1054] = 0x32C; // 0011 0010 1100 = Wildhammer Clan
    gFactionTemplates[1055] = 0x224; // 0010 0010 0100 = Wildhammer Clan
    gFactionTemplates[1074] = 0x442; // 0100 0100 0010 = Orgrimmar
    gFactionTemplates[1075] = 0x224; // 0010 0010 0100 = Human:Theramore
    gFactionTemplates[1076] = 0x224; // 0010 0010 0100 = Darnassus
    gFactionTemplates[1077] = 0x224; // 0010 0010 0100 = Human:Theramore
    gFactionTemplates[1078] = 0x224; // 0010 0010 0100 = Stormwind
    gFactionTemplates[1080] = 0x010; // 0000 0001 0000 = Friendly
    gFactionTemplates[1081] = 0x801; // 1000 0000 0001 = Elemental
    gFactionTemplates[1094] = 0x000; // 0000 0000 0000 = Beast - Boar
    gFactionTemplates[1095] = 0x000; // 0000 0000 0000 = Training Dummy
    gFactionTemplates[1096] = 0x32C; // 0011 0010 1100 = Human:Theramore
    gFactionTemplates[1097] = 0x224; // 0010 0010 0100 = Darnassus
    gFactionTemplates[1114] = 0x801; // 1000 0000 0001 = Dragonflight:Black - Bait
    gFactionTemplates[1134] = 0x54A; // 0101 0100 1010 = Undercity
    gFactionTemplates[1154] = 0x54A; // 0101 0100 1010 = Undercity
    gFactionTemplates[1174] = 0x442; // 0100 0100 0010 = Orgrimmar
    gFactionTemplates[1194] = 0x000; // 0000 0000 0000 = Battleground Neutral
    gFactionTemplates[1214] = 0x54A; // 0101 0100 1010 = Frostwolf Clan
    gFactionTemplates[1215] = 0x442; // 0100 0100 0010 = Frostwolf Clan
    gFactionTemplates[1216] = 0x32C; // 0011 0010 1100 = Stormpike Guard
    gFactionTemplates[1217] = 0x224; // 0010 0010 0100 = Stormpike Guard
    gFactionTemplates[1234] = 0x801; // 1000 0000 0001 = Sulfuron Firelords
    gFactionTemplates[1235] = 0x801; // 1000 0000 0001 = Sulfuron Firelords
    gFactionTemplates[1236] = 0x801; // 1000 0000 0001 = Sulfuron Firelords
    gFactionTemplates[1254] = 0x108; // 0001 0000 1000 = Cenarion Circle
    gFactionTemplates[1274] = 0x004; // 0000 0000 0100 = Creature
    gFactionTemplates[1275] = 0x002; // 0000 0000 0010 = Creature
    gFactionTemplates[1294] = 0x801; // 1000 0000 0001 = Gizlock
    gFactionTemplates[1314] = 0x442; // 0100 0100 0010 = Horde Generic
    gFactionTemplates[1315] = 0x224; // 0010 0010 0100 = Alliance Generic
    gFactionTemplates[1334] = 0x224; // 0010 0010 0100 = Stormpike Guard
    gFactionTemplates[1335] = 0x442; // 0100 0100 0010 = Frostwolf Clan
    gFactionTemplates[1354] = 0x000; // 0000 0000 0000 = Shen'dralar
    gFactionTemplates[1355] = 0x000; // 0000 0000 0000 = Shen'dralar
    gFactionTemplates[1374] = 0x801; // 1000 0000 0001 = Ogre (Captain Kromcrush)
    gFactionTemplates[1375] = 0x009; // 0000 0000 1001 = Treasure
    gFactionTemplates[1394] = 0x801; // 1000 0000 0001 = Dragonflight:Black
    gFactionTemplates[1395] = 0x32C; // 0011 0010 1100 = Ironforge
    gFactionTemplates[1414] = 0x004; // 0000 0000 0100 = Spirit Guide - Alliance
    gFactionTemplates[1415] = 0x002; // 0000 0000 0010 = Spirit Guide - Horde
    gFactionTemplates[1434] = 0x801; // 1000 0000 0001 = Jaedenar
    gFactionTemplates[1454] = 0x010; // 0000 0001 0000 = Victim
    gFactionTemplates[1474] = 0x000; // 0000 0000 0000 = Thorium Brotherhood
    gFactionTemplates[1475] = 0x000; // 0000 0000 0000 = Thorium Brotherhood
    gFactionTemplates[1494] = 0x442; // 0100 0100 0010 = Revantusk Trolls
    gFactionTemplates[1495] = 0x54A; // 0101 0100 1010 = Revantusk Trolls
    gFactionTemplates[1496] = 0x442; // 0100 0100 0010 = Revantusk Trolls
    gFactionTemplates[1514] = 0x224; // 0010 0010 0100 = Silverwing Sentinels
    gFactionTemplates[1515] = 0x442; // 0100 0100 0010 = Warsong Outriders
    gFactionTemplates[1534] = 0x224; // 0010 0010 0100 = Stormpike Guard
    gFactionTemplates[1554] = 0x548; // 0101 0100 1000 = Frostwolf Clan
}
