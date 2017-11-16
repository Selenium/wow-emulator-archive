#if !defined(TAXINODES_H)
#define TAXINODES_H

#ifdef NPCS

class TaxiNodes
{
	public:
		TaxiNodes();
		~TaxiNodes();

		DoubleWord ID;
		string Name;
		float X;
		float Y;
		float Z;
		DoubleWord Map;
		DoubleWord Flags;
};

#endif

#endif