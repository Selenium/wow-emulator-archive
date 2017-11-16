#if !defined(TAXIPATHNODES_H)
#define TAXIPATHNODES_H

#ifdef NPCS

class TaxiPathNodes
{
	public:
		TaxiPathNodes();
		~TaxiPathNodes();

		DoubleWord PathID;
		DoubleWord Map;
		DoubleWord Index;
		float X;
		float Y;
		float Z;
};

#endif

#endif