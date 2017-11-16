// (c) AbyssX Group
#if !defined(PACKETS_H)
#define PACKETS_H

class Packets
{
	public:
		Packets();
		~Packets();
		static void NewObjectHeader(Player *ply, Packet *pack, bool curplayer);
		static void NewObjectHeader(Mob *mob, Packet *pack);
		static void NewItemHeader(Player_Item *pitem, Packet *pack);
		static void NewObjectData(Player *ply, Packet *pack);
		static void NewObjectData(Mob *mob, Packet *pack);
		static void NewItemData(Player_Item *pitem, Packet *pack);
		static void UpdateObjectHeader(Player *ply, Packet *pack);
		static void UpdateObjectHeader(Mob *mob, Packet *pack);
		static void UpdateObjectMoviment(Player *ply, Packet *pack);
		static void UpdateObjectMoviment(Mob *mob, Packet *pack);
};

#endif