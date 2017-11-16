#include "StdAfx.h"


//-----------------------------------------------------------------------------
bool AbilityRequiresComboPoints (uint32 sp)
{
	return
		//--- Rogue Eviscerate
		sp == 2098 || sp == 6761 || sp == 6762 || sp == 8623 || sp == 8624 ||
		sp == 11299 || sp == 11300;
}

//-----------------------------------------------------------------------------
bool RequiresCasterBehindTarget (uint32 sp)
{
	//--- Rogue Backstab
	if (sp == 53 || sp == 2589 || sp == 2590 || sp == 2591 || sp == 8721 ||
		sp == 11279 || sp == 11280 || sp == 11281) return true;
	
	//--- Rogue Garrote
	if (sp == 703 || sp == 8631 || sp == 8632 || sp == 8633 || sp == 11289 ||
		sp == 11290) return true;
	
	//--- Rogue - Ambush
	if (sp == 8676 || sp == 8724 || sp == 8725 || sp == 11267 || sp == 11268 ||
		sp == 11269) return true;

	return false;
}

//--- END ---