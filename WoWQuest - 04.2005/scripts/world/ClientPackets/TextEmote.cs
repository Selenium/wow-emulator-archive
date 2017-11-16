using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;

namespace WorldScripts.ClientPackets
{
	/// <summary>
	/// Summary description for TextEmote.
	/// </summary>
	[WorldPacketHandler]
	public class TextEmote
	{
		[WorldPacketDelegate(CMSG.TEXT_EMOTE)]
		static void OnTextEmote(WorldClient client, CMSG msgID, BinReader data)
		{
			int emoteTextID = data.ReadInt32();
			if(emoteTextID >= emote_lookup.Length || emoteTextID < 0)
				return;
			data.BaseStream.Position += 4;
			ulong guid = data.ReadUInt64();
			LivingObject obj = (LivingObject)ObjectManager.GetWorldObject(OBJECTTYPE.PLAYER, guid);
			if(obj == null)
				obj = (LivingObject)ObjectManager.GetWorldObject(OBJECTTYPE.UNIT, guid);

			ServerPacket pkg = new ServerPacket(SMSG.TEXT_EMOTE);
			pkg.Write(client.Player.GUID);
			pkg.Write(emoteTextID);

			if(obj != null)
			{
				pkg.Write(guid);
				pkg.Write((string)obj.Name);
			}
			else
			{
				pkg.Write(guid);
			}

			pkg.Finish();
			client.Player.MapTile.Map.Send(pkg, client.Player.Position, 25.0f);

			switch(((EMOTE)emoteTextID))
			{
				case EMOTE.SIT:
				{
					if(client.Player.StandState == UNITSTANDSTATE.SITTING)
						client.Player.StandState = UNITSTANDSTATE.STANDING;
					else
						client.Player.StandState = UNITSTANDSTATE.SITTING;
					client.Player.UpdateData();
					break;
				}
				case EMOTE.STAND:
				{
					client.Player.StandState = UNITSTANDSTATE.STANDING;
					client.Player.UpdateData();
					break;
				}
				case EMOTE.KNEEL:
				{
					if(client.Player.StandState == UNITSTANDSTATE.KNEEL)
						client.Player.StandState = UNITSTANDSTATE.STANDING;
					else
						client.Player.StandState = UNITSTANDSTATE.KNEEL;
					client.Player.UpdateData();
					break;
				}
				case EMOTE.SLEEP:
				{
					if(client.Player.StandState == UNITSTANDSTATE.SLEEPING)
						client.Player.StandState = UNITSTANDSTATE.STANDING;
					else
						client.Player.StandState = UNITSTANDSTATE.SLEEPING;
					client.Player.UpdateData();
					break;
				}
				default:
				{
					if(emote_lookup[emoteTextID] != 0)
					{
						pkg = new ServerPacket(SMSG.EMOTE);
						pkg.Write(emote_lookup[emoteTextID]);
						pkg.Write(client.Player.GUID);
						pkg.Finish();
						client.Player.MapTile.Map.Send(pkg, client.Player.Position, 50.0f);
					}
					break;
				}
			}
		}

		static int[] emote_lookup = {0, 0, 0, 14, 0, 21, 24, 0, 20, 0, 0, 0, 24, 0, 0, 0, 0, 2, 0, 3, 11,
										4, 19, 11, 21, 6, 21, 0, 0, 0, 0, 18, 6, 2, 10, 7, 0, 7, 0, 0, 0,
										23, 0, 5, 0, 11, 0, 11, 3, 0, 0, 20, 11, 3, 0, 3, 0, 0, 17, 68, 11,
										12, 0, 0, 0, 18, 0, 0, 0, 0, 0, 20, 25, 0, 16, 15, 11, 14, 66, 0, 0,
										0, 22, 6, 24, 0, 13, 12, 0, 0, 0, 0, 20, 1, 5, 5, 0, 0, 0, 0, 4,
										3, 3, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 6, 0, 6,
										0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 0, 0, 0, 0,
										26, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
										0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
										0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
										0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
										0, 0, 0, 0, 0, 0, };
	}

	public enum EMOTE 
	{
		AGREE = 1,
		AMAZE = 2,
		ANGRY = 3,
		APOLOGIZE = 4,
		APPLAUD = 5,
		BASHFUL = 6,
		BECKON = 7,
		BEG = 8,
		BITE = 9,
		BLEED = 10,
		BLINK = 11,
		BLUSH = 12,
		BONK = 13,
		BORED = 14,
		BOUNCE = 15,
		BRB = 16,
		BOW = 17,
		BURP = 18,
		BYE = 19,
		CACKLE = 20,
		CHEER = 21,
		CHICKEN = 22,
		CHUCKLE = 23,
		CLAP = 24,
		CONFUSED = 25,
		CONGRATULATE = 26,
		COUGH = 27,
		COWER = 28,
		CRACK = 29,
		CRINGE = 30,
		CRY = 31,
		CURIOUS = 32,
		CURTSEY = 33,
		DANCE = 34,
		DRINK = 35,
		DROOL = 36,
		EAT = 37,
		EYE = 38,
		FART = 39,
		FIDGET = 40,
		FLEX = 41,
		FROWN = 42,
		GASP = 43,
		GAZE = 44,
		GIGGLE = 45,
		GLARE = 46,
		GLOAT = 47,
		GREET = 48,
		GRIN = 49,
		GROAN = 50,
		GROVEL = 51,
		GUFFAW = 52,
		HAIL = 53,
		HAPPY = 54,
		HELLO = 55,
		HUG = 56,
		HUNGRY = 57,
		KISS = 58,
		KNEEL = 59,
		LAUGH = 60,
		LAYDOWN = 61,
		MASSAGE = 62,
		MOAN = 63,
		MOON = 64,
		MOURN = 65,
		NO = 66,
		NOD = 67,
		NOSEPICK = 68,
		PANIC = 69,
		PEER = 70,
		PLEAD = 71,
		POINT = 72,
		POKE = 73,
		PRAY = 74,
		ROAR = 75,
		ROFL = 76,
		RUDE = 77,
		SALUTE = 78,
		SCRATCH = 79,
		SEXY = 80,
		SHAKE = 81,
		SHOUT = 82,
		SHRUG = 83,
		SHY = 84,
		SIGH = 85,
		SIT = 86,
		SLEEP = 87,
		SNARL = 88,
		SPIT = 89,
		STARE = 90,
		SURPRISED = 91,
		SURRENDER = 92,
		TALK = 93,
		TALKEX = 94,
		TALKQ = 95,
		TAP = 96,
		THANK = 97,
		THREATEN = 98,
		TIRED = 99,
		VICTORY = 100,
		WAVE = 101,
		WELCOME = 102,
		WHINE = 103,
		WHISTLE = 104,
		WORK = 105,
		YAWN = 106,
		BOGGLE = 107,
		CALM = 108,
		COLD = 109,
		COMFORT = 110,
		CUDDLE = 111,
		DUCK = 112,
		INSULT = 113,
		INTRODUCE = 114,
		JK = 115,
		LICK = 116,
		LISTEN = 117,
		LOST = 118,
		MOCK = 119,
		PONDER = 120,
		POUNCE = 121,
		PRAISE = 122,
		PURR = 123,
		PUZZLE = 124,
		RAISE = 125,
		READY = 126,
		SHIMMY = 127,
		SHIVER = 128,
		SHOO = 129,
		SLAP = 130,
		SMIRK = 131,
		SNIFF = 132,
		SNUB = 133,
		SOOTHE = 134,
		STINK = 135,
		TAUNT = 136,
		TEASE = 137,
		THIRSTY = 138,
		VETO = 139,
		SNICKER = 140,
		STAND = 141,
		TICKLE = 142,
		VIOLIN = 143,
		SMILE = 163,
		RASP = 183,
		PITY = 203,
		GROWL = 204,
		BARK = 205,
		SCARED = 223,
		FLOP = 224,
		LOVE = 225,
		MOO = 226,
	}

}
