// (c) AbyssX Group
#include "../WorldEnvironment.h"

Region *RegionManager::BadRegion = (Region *)0x00000001;

// Constructor: RegionManager.
RegionManager::RegionManager(float worldMinX, float worldMinY, float worldMaxX, float worldMaxY,
	float regionSize) : mWorldMinX(worldMinX), mWorldMinY(worldMinY), mWorldMaxX(worldMaxX),
	mWorldMaxY(worldMaxY), mRegionSize(regionSize), mRegionXCount(0), mRegionYCount(0)
{
	int x, y;
	float positionX, positionY;

	// Calculate number of regions in each direction.
	mRegionXCount = (int)(fabs(worldMinX - worldMaxX) / regionSize) + 1;
	mRegionYCount = (int)(fabs(worldMinY - worldMaxY) / regionSize) + 1;

	// Create the world regions.
	mRegions = new Region[mRegionXCount * mRegionYCount];

	positionX = worldMinX;
	positionY = worldMinY;

	for (y=0; y<mRegionYCount; y++)
	{
		for (x=0; x<mRegionXCount; x++)
		{
			int offset = y * mRegionXCount + x;

			mRegions[offset].SetXCoordinate(positionX);
			mRegions[offset].SetYCoordinate(positionY);
			mRegions[offset].SetSize(mRegionSize);

			// Always assume worldMinX is smaller than worldMaxX.
			positionX += mRegionSize;
		}

		// Always assume worldMinY is smaller than worldMaxY.
		positionY += mRegionSize;

		positionX = worldMinX;
	}
}

// Destructor: ~RegionManager.
RegionManager::~RegionManager()
{
	// Release all allocated regions.
	delete [] mRegions;
	mRegions = 0;
}

// Method: GetRegion [offset].
Region *RegionManager::GetRegion(int offset)
{
	return &mRegions[offset];
}

// Method: UpdatePlayer.
Region *RegionManager::UpdatePlayer(Player *player)
{
	int offset = CalculateRegionOffset(player);
	Region *currentRegion = player->GetCurrentRegion();
	Region *newRegion = 0;
	
	// Make sure this offset is valid before making any calculations.
	// I.e protect from players outside the world extent.
	if (offset == -1)
	{
		LogManager::GetSingleton().Log("RegionBounds.log",
			"%s has moved outside the region bounds (%f, %f, %f) into non-existant "
			"offset of %d\n", player->GetName().c_str(), player->GetXCoordinate(),
			player->GetYCoordinate(), player->GetZCoordinate(), offset);
		return BadRegion;
	}

	newRegion = &mRegions[offset];

	// First, only update player region if the player entered a new region, and if it's within
	// the bounds of the world.
	if (currentRegion == newRegion)
		return 0;

	// Now, remove the object from its current list, if it is a member of any list.
	if (currentRegion != 0)
		currentRegion->RemovePlayer(player);

	// Then, add the player to the new region.
	newRegion->AddPlayer(player);
	player->SetCurrentRegion(newRegion);
	
	return newRegion;
}

// Method: UpdateObject.
Region *RegionManager::UpdateObject(Object *object, bool created)
{
	int offset = CalculateRegionOffset(object);
	Region *currentRegion = object->GetCurrentRegion();
	Region *newRegion = 0;
	
	// Make sure this offset is valid before making any calculations.
	// I.e protect from objects outside the world extent.
	if (offset == -1)
	{
		LogManager::GetSingleton().Log("RegionBounds.log",
			"An object has moved outside the region bounds (%f, %f, %f) into non-existant "
			"offset of %d\n", object->GetXCoordinate(), object->GetYCoordinate(),
			object->GetZCoordinate(), offset);
		return BadRegion;
	}

	newRegion = &mRegions[offset];

	// First, only update Object region if the Object entered a new region.
	if (currentRegion == newRegion && created == false)
		return 0;

	// Now, remove the object from its current list, if it is a member of any list.
	if (currentRegion != 0)
		currentRegion->RemoveObject(object);

	// Then, add the Object to the new region.
	newRegion->AddObject(object);
	object->SetCurrentRegion(newRegion);

	return newRegion;
}

// Method: GetRegionsWithinRange.
RegionList RegionManager::GetRegionsWithinRange(Object *object, RangeType type)
{
	RegionList regionList;
	int offset = CalculateRegionOffset(object);
	int xOffset, yOffset, x, y;

	// Make sure we get a valid offset, or return empty region list.
	if (offset == -1)
		return regionList;

	if (type == RANGETYPE_1X1)
		regionList.AddRegion(&mRegions[offset]);
	else
	if (type == RANGETYPE_3X3)
	{
		// Set offsets to start at upper, left region to be added.
		xOffset = offset % GetRegionXCount() - 1;
		yOffset = offset / GetRegionXCount() - 1;
		
		// Add all the regions in this 3x3 configuration.
		for (y = yOffset; y < yOffset+3; y++)
		{
			// Only allow the loop to continue if offset is within bounds.
			if (y < 0 || y >= GetRegionYCount())
				continue;

			for (x = xOffset; x < xOffset+3; x++)
			{
				// If offset is within bounds of the region system, add the region.
				if (x >= 0 && x < GetRegionXCount())
					regionList.AddRegion(&mRegions[y * GetRegionXCount() + x]);
			}
		}
	}

	return regionList;
}

// Method: CalculateRegionOffset.
int RegionManager::CalculateRegionOffset(Object *object)
{
	int positionX, positionY;

	// Make sure the object is within the world bounds. If it isn't reflect this by returning offset -1.
	if (object->GetXCoordinate() < mWorldMinX || object->GetXCoordinate() > mWorldMaxX)
		return -1;

	if (object->GetYCoordinate() < mWorldMinY || object->GetYCoordinate() > mWorldMaxY)
		return -1;

	// Always assume worldMinX is smaller than worldMaxX.
	positionX = (int)((object->GetXCoordinate() - GetWorldMinX()) / GetRegionSize());
    
	// Always assume worldMinY is smaller than worldMaxY.
	positionY = (int)((object->GetYCoordinate() - GetWorldMinY()) / GetRegionSize());

	return positionY * GetRegionXCount() + positionX;
}

 // Method: RemoveObject.
bool RegionManager::RemoveObject(Object *object)
{
	bool ret = object->GetCurrentRegion()->RemoveObject(object);
	object->SetCurrentRegion(0);
	object->SetCurrentRegionList(RegionList());		// empty region list
	return ret;
}

 // Method: RemovePlayer.
bool RegionManager::RemovePlayer(Player *player)
{
	bool ret = player->GetCurrentRegion()->RemovePlayer(player);
	player->SetCurrentRegion(0);
	player->SetCurrentRegionList(RegionList());		// empty region list
	return ret;
}
