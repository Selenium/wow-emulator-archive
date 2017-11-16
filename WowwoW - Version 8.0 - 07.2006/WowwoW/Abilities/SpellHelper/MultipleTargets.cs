using System;
using System.IO;
using System.Collections;
using Server;
namespace Server
{
	public class MultipleTargets
	{
		public static Hashtable multipleTargets = new Hashtable();
		private static MultipleTargets temp = new MultipleTargets();
		public MultipleTargets()
		{
			MultipleTargets.multipleTargets[11608] = 2; //Cleave
			MultipleTargets.multipleTargets[11609] = 2; //Cleave
			MultipleTargets.multipleTargets[15496] = 2; //Cleave
			MultipleTargets.multipleTargets[15613] = 2; //Cleave
			MultipleTargets.multipleTargets[15622] = 2; //Cleave
			MultipleTargets.multipleTargets[15623] = 2; //Cleave
			MultipleTargets.multipleTargets[19319] = 2; //Vicious Bite
			MultipleTargets.multipleTargets[20569] = 2; //Cleave
			MultipleTargets.multipleTargets[22336] = 2; //Shadow Bolt
			MultipleTargets.multipleTargets[22540] = 2; //Cleave
			MultipleTargets.multipleTargets[4281] = 2; //Quickness
			MultipleTargets.multipleTargets[5532] = 2; //Cleave
			MultipleTargets.multipleTargets[7290] = 2; //Soul Siphon
			MultipleTargets.multipleTargets[7369] = 2; //Cleave
			MultipleTargets.multipleTargets[845] = 2; //Cleave
			MultipleTargets.multipleTargets[9373] = 2; //Soul Siphon
			MultipleTargets.multipleTargets[9654] = 2; //Jumping Lightning
			MultipleTargets.multipleTargets[10605] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[10622] = 3; //Chain Heal
			MultipleTargets.multipleTargets[10623] = 3; //Chain Heal
			MultipleTargets.multipleTargets[1064] = 3; //Chain Heal
			MultipleTargets.multipleTargets[11085] = 3; //Chain Bolt
			MultipleTargets.multipleTargets[11427] = 3; //Cleave
			MultipleTargets.multipleTargets[12058] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[14112] = 3; //Flaying Vine
			MultipleTargets.multipleTargets[14200] = 3; //Chained Bolt
			MultipleTargets.multipleTargets[14288] = 3; //Multi-Shot
			MultipleTargets.multipleTargets[14289] = 3; //Multi-Shot
			MultipleTargets.multipleTargets[14290] = 3; //Multi-Shot
			MultipleTargets.multipleTargets[14443] = 3; //Multi-Shot
			MultipleTargets.multipleTargets[14900] = 3; //Chain Heal
			MultipleTargets.multipleTargets[15117] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[15284] = 3; //Cleave
			MultipleTargets.multipleTargets[15549] = 3; //Chained Bolt
			MultipleTargets.multipleTargets[15579] = 3; //Cleave
			MultipleTargets.multipleTargets[15584] = 3; //Cleave
			MultipleTargets.multipleTargets[15659] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[15663] = 3; //Cleave
			MultipleTargets.multipleTargets[15754] = 3; //Cleave
			MultipleTargets.multipleTargets[15799] = 3; //Chain Heal
			MultipleTargets.multipleTargets[16006] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[16367] = 3; //Chain Heal
			MultipleTargets.multipleTargets[16921] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[17685] = 3; //Cleave
			MultipleTargets.multipleTargets[17963] = 3; //Sundering Cleave
			MultipleTargets.multipleTargets[18651] = 3; //Multi-Shot
			MultipleTargets.multipleTargets[18819] = 3; //Holy Cleave
			MultipleTargets.multipleTargets[20535] = 3; //Lightning Breath
			MultipleTargets.multipleTargets[20605] = 3; //Cleave
			MultipleTargets.multipleTargets[20627] = 3; //Lightning Breath
			MultipleTargets.multipleTargets[20677] = 3; //Cleave
			MultipleTargets.multipleTargets[20831] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[21179] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[22355] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[22947] = 3; //Mana Burn
			MultipleTargets.multipleTargets[23106] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[23206] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[2643] = 3; //Multi-Shot
			MultipleTargets.multipleTargets[2860] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[421] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[6254] = 3; //Chained Bolt
			MultipleTargets.multipleTargets[7145] = 3; //Diving Sweep
			MultipleTargets.multipleTargets[769] = 3; //Swipe
			MultipleTargets.multipleTargets[779] = 3; //Swipe
			MultipleTargets.multipleTargets[780] = 3; //Swipe
			MultipleTargets.multipleTargets[8211] = 3; //Chain Burn
			MultipleTargets.multipleTargets[8292] = 3; //Chain Bolt
			MultipleTargets.multipleTargets[930] = 3; //Chain Lightning
			MultipleTargets.multipleTargets[9754] = 3; //Swipe
			MultipleTargets.multipleTargets[9908] = 3; //Swipe
			MultipleTargets.multipleTargets[16790] = 3; //Knockdown
			MultipleTargets.multipleTargets[22919] = 3; //Mind Flay
			MultipleTargets.multipleTargets[20684] = 4; //Cleave
			MultipleTargets.multipleTargets[15305] = 5; //Chain Lightning
			MultipleTargets.multipleTargets[19642] = 5; //Cleave
			MultipleTargets.multipleTargets[20691] = 5; //Cleave
			MultipleTargets.multipleTargets[21390] = 5; //Multi-Shot
			MultipleTargets.multipleTargets[21992] = 5; //Thunderblade
			MultipleTargets.multipleTargets[23953] = 5; //Mind Flay
			MultipleTargets.multipleTargets[19128] = 5; //Knockdown
			MultipleTargets.multipleTargets[20276] = 5; //Knockdown
			MultipleTargets.multipleTargets[20666] = 5; //Cleave
			MultipleTargets.multipleTargets[7295] = 5; //Soul Drain
			MultipleTargets.multipleTargets[8255] = 5; //Strong Cleave
			MultipleTargets.multipleTargets[20543] = 8; //Lightning Breath
			MultipleTargets.multipleTargets[16033] = 10; //Chain Lightning
			MultipleTargets.multipleTargets[16044] = 10; //Cleave
			MultipleTargets.multipleTargets[19632] = 10; //Cleave
			MultipleTargets.multipleTargets[19983] = 10; //Cleave
			MultipleTargets.multipleTargets[20735] = 10; //Multi-Shot
			MultipleTargets.multipleTargets[15398] = 1; //Psychic Scream
			MultipleTargets.multipleTargets[8122] = 2; //Psychic Scream
			MultipleTargets.multipleTargets[11790] = 3; //Poison Cloud
			MultipleTargets.multipleTargets[8124] = 3; //Psychic Scream
			MultipleTargets.multipleTargets[10888] = 4; //Psychic Scream
			MultipleTargets.multipleTargets[11580] = 4; //Thunder Clap
			MultipleTargets.multipleTargets[11581] = 4; //Thunder Clap
			MultipleTargets.multipleTargets[13532] = 4; //Thunder Clap
			MultipleTargets.multipleTargets[1680] = 4; //Whirlwind
			MultipleTargets.multipleTargets[23023] = 4; //Conflagration
			MultipleTargets.multipleTargets[6343] = 4; //Thunder Clap
			MultipleTargets.multipleTargets[8198] = 4; //Thunder Clap
			MultipleTargets.multipleTargets[8204] = 4; //Thunder Clap
			MultipleTargets.multipleTargets[8205] = 4; //Thunder Clap
			MultipleTargets.multipleTargets[10890] = 5; //Psychic Scream
			MultipleTargets.multipleTargets[13704] = 5; //Psychic Scream
			MultipleTargets.multipleTargets[17928] = 5; //Howl of Terror
			MultipleTargets.multipleTargets[19482] = 5; //War Stomp
			MultipleTargets.multipleTargets[20549] = 5; //War Stomp
			MultipleTargets.multipleTargets[22884] = 5; //Psychic Scream
			MultipleTargets.multipleTargets[5484] = 5; //Howl of Terror
			MultipleTargets.multipleTargets[13910] = 10; //Force Create Elemental Totem
			MultipleTargets.multipleTargets[22012] = 10; //Spirit Heal
		}
	}
}
