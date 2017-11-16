#if !defined(TAXIPATHS_H)
#define TAXIPATHS_H

#ifdef NPCS

class TaxiPaths
{
	public:
		TaxiPaths();
		~TaxiPaths();

		DoubleWord ID;
		DoubleWord Source;
		DoubleWord Destination;
		DoubleWord Price;
};

#endif

#endif