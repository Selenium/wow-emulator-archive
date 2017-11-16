#if !defined(TAXIHANDLER_H)
#define TAXIHANDLER_H

#ifdef NPCS

struct PathNode {
	float x,y,z;
};

class TaxiHandler: public Singleton<TaxiHandler>
{
	public:
		TaxiHandler();
		~TaxiHandler();

		void LoadTaxiDB();
		void LoadTaxiNodes();
		void LoadTaxiPathNodes();
		void LoadTaxiPaths();

		DoubleWord GetNearNode(Player *ply);
		DoubleWord GetTaxiMask(DoubleWord SOURCE);
		DoubleWord GetPath(DoubleWord Source, DoubleWord Destination);

		DoubleWord HandlePackets(Client *cli, Packet *pack);
		void HandlerMSG_TAXINODE_STATUS_QUERY(Client *cli, Packet *pack);
		void HandlerMSG_TAXIQUERYAVAILABLENODES(Client *cli, Packet *pack);
		void HandlerMSG_ACTIVATETAXI(Client *cli, Packet *pack);

		list<TaxiNodes *>mTaxiNodes;
		list<TaxiPaths *>mTaxiPaths;
		list<TaxiPathNodes *>mTaxiPathNodes;
};

#endif

#endif