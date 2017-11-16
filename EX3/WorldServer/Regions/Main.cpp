#include <stdio.h>
#include <conio.h>

#include "RegionEnvironment.h"


#define NUMBER_OF_PLAYERS		100


// Function: Main.
int main(int argc, char **argv)
{
	RegionManager regionManager(-1000.0f, -1000.0f, 0.0f, 0.0f, 50.0f, 50.0f);
	Player player(0, "sprattel", 0, 0);
	RegionList *regionList;
	RegionList resultList;
	RegionList::RegionListIterator i;


	printf("Regions in x- and y-axis: %d, %d\n", regionManager.GetRegionXCount(), regionManager.GetRegionYCount());

	// Spawn player into region system.
	player.SetXCoordinate(-940.0f);
	player.SetYCoordinate(-990.0f);

	regionManager.UpdatePlayer(&player);
	player.SetCurrentRegionList(regionManager.GetRegionsWithinRange(&player, RANGETYPE_3X3));

	// Simulate region change.
	player.SetXCoordinate(-990.0f);
	player.SetYCoordinate(-990.0f);

	regionManager.UpdatePlayer(&player);
	regionList = regionManager.GetRegionsWithinRange(&player, RANGETYPE_3X3);

	resultList = *(player.GetCurrentRegionList()) - *regionList;
	player.SetCurrentRegionList(regionManager.GetRegionsWithinRange(&player, RANGETYPE_3X3));


	printf("Resulting regions:\n\n");


	for (i=resultList.Begin(); i!=resultList.End(); i++)
		printf("Region: <%.2f,%.2f>\n", (*i)->GetXCoordinate(), (*i)->GetYCoordinate());

	getch();
	return 0;
}
