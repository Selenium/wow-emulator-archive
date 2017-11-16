// (c) AbyssX Group
#if !defined(LPACKET_H)
#define LPACKET_H

class LPacket
{
	public:
		LPacket();
		~LPacket();

		bool FromInput(Client *cli);

		void QuickCopy(LPacket *pack);

		DoubleWord GetOpCode(void);
		Word GetDataLength(void);
		Word GetByteAfterString(Word byte);
		Byte GetByte(Word byte);
		Byte *GetBytes(Word byte = 0);
		Word GetWord(Word byte);
		DoubleWord GetDoubleWord(Word byte);
		QuadWord GetQuadWord(Word byte);
		Float GetFloat(Word byte);

	private:
		struct PACKETDTA
		{
			Word opcode;
			Word len;
			Byte data[1024*32];
		} mPacket;
};

#endif

