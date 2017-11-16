//
// MapMgr.cpp
//

#include "StdAfx.h"
#include "MapMgr.h"

//-----------------------------------------------------------------------------
MapRangeIterator::MapRangeIterator (Object *center)
{
	m_center = center;
	int32 x = center->MapCellX();
	int32 y = center->MapCellY();
	
	enum { PLAYER_UPD_CELLS_RADIUS = 1 };

	m_fromX = m_X = x >= PLAYER_UPD_CELLS_RADIUS ? x - PLAYER_UPD_CELLS_RADIUS : 0;
	m_Y = y >= PLAYER_UPD_CELLS_RADIUS ? y - PLAYER_UPD_CELLS_RADIUS : 0;

	int32 maxX = center->GetMapMgr()->_numCellsX;
	int32 maxY = center->GetMapMgr()->_numCellsY;
	m_toX = x + PLAYER_UPD_CELLS_RADIUS < maxX ? x + PLAYER_UPD_CELLS_RADIUS : maxX;
	m_toY = y + PLAYER_UPD_CELLS_RADIUS < maxY ? y + PLAYER_UPD_CELLS_RADIUS : maxY;

	m_mapMgr = center->GetMapMgr();
	m_cell = & (m_mapMgr->_cells[m_X][m_Y]);
	m_iter = m_cell->Begin();

	if (m_iter == m_cell->End()) Advance();
}

//-----------------------------------------------------------------------------
Object * MapRangeIterator::Advance() 
{
	Object * o = NULL;

	// If cell iterator cannot continue - step to next cell
	if (m_iter == m_cell->End())
		while (1)
		{
			if (m_X == m_toX)
			{
				// if no next cell - return NULL (end of sequence)
				if (m_Y == m_toY) 
					return NULL;

				m_Y++;
				m_X = m_fromX;
			} else
				m_X++;

			// Advanced to next cell - start sequence here
			m_cell = & (m_mapMgr->_cells[m_X][m_Y]);
			m_iter = m_cell->Begin();
			
			if (m_iter != m_cell->End())
			{
				o = GetObject();
				m_iter++;
			}
			return o != m_center ? o : Advance();	// dont return center object
		};

	if (m_iter != m_cell->End())
	{
		o = GetObject();
		m_iter++;
	}
	return o != m_center ? o : Advance();	// dont return center object
}

//-----------------------------------------------------------------------------
MapMgr::MapMgr(uint32 mapId) : _mapId(mapId)
{
	switch (mapId) {
	case 0:	// EASTERN KINGDOMS
		_minX = -16000; _minY = -19200;
		_maxX =   7500; _maxY =  16000;
		break;
	case 1:	// KALIMDOR
		_minX = -11800; _minY = -19800;
		_maxX =  12800; _maxY =  17000;
		break;
	default:	
		_minX = -8000; _minY = -8000;
		_maxX =  8000; _maxY =  8000;
		break;
	}

    //_cellSize = 150;
    //_sizeX = (abs(_minX) + _maxX) / NUM_CELLS;
    //_sizeY = (abs(_minY) + _maxY) / NUM_CELLS;
	
	_sizeX = _sizeY = MAPMGR_CELL_SIZE;
	_numCellsX = (abs(_minX) + _maxX) / _sizeX + 1;
	_numCellsY = (abs(_minY) + _maxY) / _sizeY + 1;

	Log::getSingleton().outString ("\nCreate MapMgr id=%d cellsX=%d cellsY=%d (total %d) sizeof_1=%d",
		mapId, _numCellsX, _numCellsY, _numCellsX * _numCellsY, int32(sizeof (MapCell)));

    _cells = new MapCell*[_numCellsX];
    ASSERT(_cells);
    for (int32 i = 0; i < _numCellsX; i++)
    {
        _cells[i] = new MapCell[_numCellsY];
        ASSERT(_cells[i]);
    }

    _timers[MMUPDATE_FIELDS].SetInterval(200);
    _timers[MMUPDATE_OBJECTS].SetInterval(400);
}

//-----------------------------------------------------------------------------
MapMgr::~MapMgr()
{
    if(_cells)
    {
        for (int32 i = 0; i < _numCellsX; i++)
        {
            delete [] _cells[i];
        }

        delete _cells;
    }
}

//-----------------------------------------------------------------------------
// When player first enters some area - he awakens all sleeping mobs and gameobjects
// and gathers all updates about them. Also player registers in area cells.
//
// When non player object or mob enters area - nothing happens, it just registers in
// current area cells
//
void MapMgr::AddObject(Object *obj)
{
    ASSERT (obj != NULL);
    //ASSERT (obj->GetInRangeSetBegin() == obj->GetInRangeSetEnd()); // make sure object is a virgin
    ASSERT (obj->GetMapId() == _mapId);
	
	ASSERT (obj->GetPositionX() < _maxX);
	ASSERT (obj->GetPositionX() > _minX);
    ASSERT (obj->GetPositionY() < _maxY);
	ASSERT (obj->GetPositionY() > _minY);
    
	ASSERT (_cells != NULL);

    //sLog.outDetail("Adding object "I64FMT" with type %i to the map %u.",
    //    obj->GetGUID(), obj->GetTypeId(), _mapId);

    // That object types are not map objects. TODO: add AI groups here?
    if(obj->GetTypeId() == TYPEID_ITEM || obj->GetTypeId() == TYPEID_CONTAINER)// || obj->GetTypeId() == TYPEID_GAMEOBJECT)
    {
        // mark object as updatable and exit
        obj->AddToWorld();
        return;
    }


	//-------------------------
	// registrations
	//-------------------------
	MapCell	&cell = _cells[obj->MapCellX()][obj->MapCellY()];
	cell.AddObject(obj);
	obj->SetMapCell (&cell);
	//_objects[obj->GetGUID()] = obj;
	obj->AddToWorld();

	UpdateData data;
	UpdateData playerData;
	WorldPacket packet;

	int32	cellX = int32(obj->GetPositionX() - _minX) / _sizeX;
	int32	cellY = int32(obj->GetPositionY() - _minY) / _sizeY;

    //MapCell &cell = _cells[cellX][cellY];

    int32 endX = cellX < _numCellsX ? cellX + 1 : _numCellsX;
    int32 endY = cellY < _numCellsY ? cellY + 1 : _numCellsY;
    int32 startX = cellX > 0 ? cellX - 1 : 0;
    int32 startY = cellY > 0 ? cellY - 1 : 0;
    int32 posX, posY;
    //ObjectSet::iterator iter;

	if(obj->isPlayer())
	{
		// If current cell was sleeping before player arrived, then awake all mobs
		// in cell registering them in update list
		//
		for (posX = startX; posX <= endX; posX++ ) {
			for (posY = startY; posY <= endY; posY++ ) {
				_PlayerEnteredCell ((Player *)obj, _cells[posX][posY], data, playerData, packet);
			}
		}
	}
	else {
		// Non player monsters when entering area just scan it for players and
		// register with them.
		//
		for (posX = startX; posX <= endX; posX++)
			for (posY = startY; posY <= endY; posY++)
				_MobEnteredCell (obj, _cells[posX][posY], playerData, packet);
	}

	/*
	Object *reg;
	if (obj->isPlayer())
		//---------------------------------------------------------
		// Do the loop for all "potentially" visible objects around player 
		//------------------------------------------------------------------
		for (MapRangeIterator iter (obj); reg = iter.Advance(); )
		{
			if (obj->CanSee (reg))
			{
				reg->BuildCreateUpdateBlockForPlayer (&playerData, (Player *)obj);
			}

			// When player meets player - send update to other side too
			//
			if (reg->isPlayer()) 
			{
				if (reg->CanSee (obj))
				{
					data.Clear();
					obj->BuildCreateUpdateBlockForPlayer (&data, (Player *)reg);
					data.BuildPacket (&packet);
					((Player *)reg)->GetSession()->SendPacket (&packet);
				}
			} else {
				ActivateGuid (reg->GetGUID());
			}
		}
	else
		//---------------------------------------------------------
		// Else do the same loop searching for all player objects
		//---------------------------------------------------------
		for (MapRangeIterator iter (obj); reg = iter.Advance(); )
		{
			// if this object is player and he doesn't see us yet
			if (reg->isNotPlayer()) continue;

			if (((Unit *)reg)->CanSee ((Unit *)obj))
			{
				data.Clear();
				obj->BuildCreateUpdateBlockForPlayer (&data, (Player *)reg);
				data.BuildPacket (&packet);
				((Player *)reg)->GetSession()->SendPacket (&packet);

				ActivateGuid (obj->GetGUID());
			}
		}
*/
	// Now add player own update block and send to him
	//
	if (obj->isPlayer())
	{
		playerData.Clear();
		obj->BuildCreateUpdateBlockForPlayer( &playerData, (Player *)obj );

		playerData.BuildPacket( &packet );
		((Player *)obj)->GetSession()->SendPacket( &packet );

 		//if (data.HasData()) {
		//	data.BuildPacket( &packet );
		//	((Player *)obj)->GetSession()->SendPacket( &packet );
		//}
	}
}

//-----------------------------------------------------------------------------
// When player leaves some area and he was last in this area - we unregister everything
// non-player (except walking NPCs) in this area from updates to conserve CPU resources.
// Also player unregisters from local area cells.
//
// When non player leaves area - he just unregisters from local area cells.
//
void MapMgr::RemoveObject(Object *obj)
{
    ASSERT(obj);
    ASSERT(obj->GetMapId() == _mapId);
    ASSERT(obj->GetPositionX() > _minX && obj->GetPositionX() < _maxX);
    ASSERT(obj->GetPositionY() > _minY && obj->GetPositionY() < _maxY);
    ASSERT(_cells);

    // That object types are not map objects. TODO: add AI groups here?
	uint8 type_id = obj->GetTypeId();
    if (type_id == TYPEID_ITEM || type_id == TYPEID_CONTAINER) // || type_id == TYPEID_GAMEOBJECT)
    {
        // remove updatable flag and exit
        obj->RemoveFromWorld();
        return;
    }

	//ObjectMap::iterator itr;

	//----------------
	obj->RemoveFromWorld();

	//_objects.erase (obj->GetGUID());

    // remove us from updated objects list
	//
	_updatedObjects.erase (obj);
	if (! obj->isPlayer() && ! obj->IsPathWalker())
		HibernateGuid (obj->GetGUID());

	// Unregister from map area cell
	//
    MapCell *objCell = obj->GetMapCell();

    obj->SetMapCell(0);
	objCell->RemoveObject(obj);

	// Check own in_range set for possible players around, and send them news
	// about departure from this area
	//
    //for (ObjectSetIterator iter = obj->GetInRangeSetBegin(); iter != obj->GetInRangeSetEnd(); iter++)
	Object *o;
	for (MapRangeIterator iter (obj); o = iter.Advance(); )
    {
		//o->RemoveInRangeObject(obj);
		if (o->isPlayer() && o != obj)
			obj->DestroyForPlayer( (Player *)o );
    }
    //obj->ClearInRangeSet();

	// When last player leaves the area, we remove mobs from all surrounding cells
	// from update list
	//

	// Calculate cell indexes that located around our current cell
	// 
	uint32 x = (uint32)(obj->GetPositionX() - _minX) / _sizeX;
	uint32 y = (uint32)(obj->GetPositionY() - _minY) / _sizeY;
	UpdateData data;
	WorldPacket packet;

	if (obj->isPlayer())
	{
		/*uint32 endX = x < _sizeX ? x + 1 : _sizeX;
		uint32 endY = y < _sizeY ? y + 1 : _sizeY;
		uint32 startX = x > 0 ? x - 1 : 0;
		uint32 startY = y > 0 ? y - 1 : 0;
		uint32 posX, posY;

		for (posX = startX; posX <= endX; posX++ )
			for (posY = startY; posY <= endY; posY++ )*/
		for (int i = -1; i <= 1; i++)
			for (int j = -1; j <= 1; j++)
				_PlayerLeftCell ((Player *)obj, _cells[x+i][y+j], data, packet);

		if (data.HasData())
		{
			data.BuildPacket( &packet );
			((Player*)obj)->GetSession()->SendPacket( &packet );
		}
	}
}

//-----------------------------------------------------------------------------
// Helper function called to do common mob actions upon entering new cell.
// Mob locates players around and contacts them via InRangeObject field
//
void MapMgr::_MobLeftCell (Object *obj, MapCell &cell, UpdateData &data, WorldPacket &packet)
{
	//Log::getSingleton( ).outDebug ("MapMgr::Mob Left Cell %I64X", obj->GetGUIDLow());
	for (ObjectSetIterator ci = cell.Begin(); ci != cell.End(); ci++)
	{
		Object *reg = *ci;

		// if this object is player and he doesn't see us yet
		//
		if (reg->isPlayer())
		{
			if (((Unit *)reg)->CanSee ((Unit *)obj))
			{
				data.Clear();
				obj->BuildOutOfRangeUpdateBlock (&data);
				data.BuildPacket (&packet);
				((Player *)reg)->GetSession()->SendPacket (&packet);
			}
		}
	}
}

//-----------------------------------------------------------------------------
// Helper function called to do common mob actions upon entering new cell.
// Mob locates players around and contacts them via InRangeObject field
//
void MapMgr::_MobEnteredCell (Object *obj, MapCell &cell, UpdateData &data, WorldPacket &packet)
{
	//Log::getSingleton( ).outDebug ("MapMgr::Mob Entered Cell %I64X", obj->GetGUIDLow());
	for (ObjectSetIterator ci = cell.Begin(); ci != cell.End(); ci++)
	{
		Object *reg = *ci;

		// if this object is player and he doesn't see us yet
		//
		if (reg->isPlayer())
		{
			if (((Unit *)reg)->CanSee ((Unit *)obj))
			{
				data.Clear();
				obj->BuildCreateUpdateBlockForPlayer (&data, (Player *)reg);
				data.BuildPacket (&packet);
				((Player *)reg)->GetSession()->SendPacket (&packet);

				ActivateGuid (obj->GetGUID());
			}
		}
	}
}

//-----------------------------------------------------------------------------
// Helper function called by ChangeObjectLocation for every cell that lost one
// player and now one step closer to total hibernation. When no players walk around
// this cell - all mobs here put into sleep.
// 
void MapMgr::_PlayerLeftCell (Player *player, MapCell &cell,
							  UpdateData &playerData, WorldPacket &packet)
{
	//Log::getSingleton( ).outDebug ("MapMgr::Player Left Cell %I64X", player->GetGUIDLow());
	//ASSERT (cell.player_count > 0);
	//cell.player_count--;
	playerData.Clear();
	UpdateData data;

	//if (cell.AnyPlayersHere (player) == false)
	//{
	for (ObjectSet::iterator ci = cell.Begin(); ci != cell.End(); ci++)
	{
		Object *unreg = *ci;

		if ((Object *)player == unreg) continue;

		unreg->BuildOutOfRangeUpdateBlock (&playerData);

		// if this was player too: send him update about us leaving
		if (unreg->isPlayer()) {
			data.Clear();
			player->BuildOutOfRangeUpdateBlock (&data);
			data.BuildPacket (&packet);
			((Player *)unreg)->GetSession()->SendPacket (&packet);
		}

		//player->RemoveInRangeObject (unreg);
		//unreg->RemoveInRangeObject (player);

		/*
		// We not unregister occasional players and path walking mobs
		if (unreg->isNotPlayer() //&& unreg->NoObjectsInRange() 
			&& ! unreg->IsPathWalker())
		{
			HibernateGuid (unreg->GetGUID());
		}*/

		//if (cell.player_count == 0)
		//	HibernateGuid (unreg->GetGUID());
	}
	//}

	if (playerData.HasData()) {
		WorldPacket pkt;
		playerData.BuildPacket( &pkt );
		player->GetSession()->SendPacket (&pkt);
	}
}
//-----------------------------------------------------------------------------
// Helper function called by ChangeObjectLocation for every cell where player
// enters. If no players were in this cell before, then we need to wake up all sleeping
// mobs here by adding them to update list.
// 
void MapMgr::_PlayerEnteredCell (Player *player, MapCell &cell,
								 UpdateData &data, UpdateData &playerData, WorldPacket &packet)
{
	//Log::getSingleton( ).outDebug ("MapMgr::Player Entered Cell %I64X", player->GetGUIDLow());
	//ASSERT (cell.player_count >= 0);
	//cell.player_count++;
	playerData.Clear();

	// And now look for other players and stuff to get some update packets
	//
	for (ObjectSetIterator ci = cell.Begin(); ci != cell.End(); ci++)
	{
		Object *reg = *ci;

		if ((Object *)player != reg)
		{
			//if (! player->IsInRangeSet (reg)) {
			if (player->CanSee (reg))
			{
				//data.Clear();
				reg->BuildCreateUpdateBlockForPlayer (&playerData, player);
				//data.BuildPacket (&packet);
				//player->GetSession()->SendPacket (&packet);

				//player->AddInRangeObject (reg);
			}
			//}

			// When player meet player - send update to other side too
			// <- this is possible fix to #132 when player logs in to zone with players
			//if (! reg->IsInRangeSet (player)) {
			if (reg->isPlayer()) 
			{
				if (reg->CanSee (player))
				{
					UpdateData udata;
					udata.Clear();
					player->BuildCreateUpdateBlockForPlayer (&udata, (Player *)reg);
					udata.BuildPacket (&packet);
					((Player *)reg)->GetSession()->SendPacket (&packet);

					//reg->AddInRangeObject (player);
				}
			} else {
				ActivateGuid (reg->GetGUID());
				//reg->AddInRangeObject (player);
			}
			//}
		}
	}

	if (playerData.HasData()) {
		playerData.BuildPacket (&packet);
		player->GetSession()->SendPacket (&packet);
		//playerData.Clear();
	}
}

//-----------------------------------------------------------------------------
// When player moves between cells he should decrement players count in cells
// behind and if no more players in those cells - put mobs there to sleep by
// unregistering them from updates.
//
// When mob moves between cells... nothing happens.
//
void MapMgr::ChangeObjectLocation (Object *obj, int32 oldX, int32 oldY)
{
    ASSERT(obj);
    ASSERT(obj->GetMapId() == _mapId);
    ASSERT(_cells);

	if(obj->GetTypeId() == TYPEID_ITEM || obj->GetTypeId() == TYPEID_CONTAINER)// || obj->GetTypeId() == TYPEID_GAMEOBJECT)
        return;

    WorldPacket packet;
    UpdateData data;
    UpdateData playerData;

    //Object* curObj;
	bool	playerHere = (obj->isPlayer());

	// Now we calculate if motion vector crossed any cell boundary, so we leave
	// opposite cells and hibernate mobs there, and enter new cells in front of us,
	// activating mobs there.
	//
	int32	newX = (int32)obj->GetPositionX();
	int32	newY = (int32)obj->GetPositionY();

	// If changed cell - move object to next cell
	MapCell * newCell = & (_cells[obj->MapCellX()][obj->MapCellY()]);

	if (newCell != NULL && obj->GetMapCell() != NULL && newCell != obj->GetMapCell())
	{
		ASSERT (obj->GetMapCell()->HasObject (obj));
		obj->GetMapCell()->RemoveObject (obj);
	} else {
		newCell = NULL;
	}

	//if (playerHere)
	//	Log::getSingleton( ).outDebug ("MapMgr::Player Moved (%i, %i) to (%i, %i)", 
	//	oldX, oldY, newX, newY);

	oldX -= _minX; oldY -= _minY;
	newX -= _minX; newY -= _minY;

	int32	lowBound = oldY - oldY % _sizeY;
	int32	topBound = lowBound + _sizeY;
	int32	leftBound = oldX - oldX % _sizeX;
	int32	rightBound = leftBound + _sizeX;

	int32	cellX = oldX / _sizeX;
	int32	cellY = oldY / _sizeY;

	if (newY > topBound) {
		if (newX > rightBound) {
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Top Right");
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY+1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY+1], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY+2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX]  [cellY+2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+1][cellY+2], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX-1][cellY], data, packet);
				_MobLeftCell (obj, _cells[cellX-1][cellY+1], data, packet);

				_MobEnteredCell (obj, _cells[cellX+2][cellY], data, packet);
				_MobEnteredCell (obj, _cells[cellX+2][cellY+1], data, packet);
				_MobEnteredCell (obj, _cells[cellX+2][cellY+2], data, packet);
				_MobEnteredCell (obj, _cells[cellX]  [cellY+2], data, packet);
				_MobEnteredCell (obj, _cells[cellX+1][cellY+2], data, packet);
			}
		}
		else
		if (newX < leftBound) {
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Top Left");
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY+1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY+1], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY+2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX]  [cellY+2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-1][cellY+2], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX+1][cellY], data, packet);
				_MobLeftCell (obj, _cells[cellX+1][cellY+1], data, packet);

				_MobEnteredCell (obj, _cells[cellX-2][cellY], data, packet);
				_MobEnteredCell (obj, _cells[cellX-2][cellY+1], data, packet);
				_MobEnteredCell (obj, _cells[cellX-2][cellY+2], data, packet);
				_MobEnteredCell (obj, _cells[cellX]  [cellY+2], data, packet);
				_MobEnteredCell (obj, _cells[cellX-1][cellY+2], data, packet);
			}
		}
		else // X not changed
		{
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Top");
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY-1], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX]  [cellY-1], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY-1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX-1][cellY+2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX]  [cellY+2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+1][cellY+2], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX-1][cellY-1], data, packet);
				_MobLeftCell (obj, _cells[cellX]  [cellY-1], data, packet);
				_MobLeftCell (obj, _cells[cellX+1][cellY-1], data, packet);

				_MobEnteredCell (obj, _cells[cellX-1][cellY+2], data, packet);
				_MobEnteredCell (obj, _cells[cellX]  [cellY+2], data, packet);
				_MobEnteredCell (obj, _cells[cellX+1][cellY+2], data, packet);
			}
		}
	} else
	if (newY < lowBound) {
		if (newX > rightBound) {
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Bottom Right");
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY-1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY-1], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY-2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX]  [cellY-2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+1][cellY-2], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX-1][cellY], data, packet);
				_MobLeftCell (obj, _cells[cellX-1][cellY-1], data, packet);

				_MobEnteredCell (obj, _cells[cellX+2][cellY], data, packet);
				_MobEnteredCell (obj, _cells[cellX+2][cellY-1], data, packet);
				_MobEnteredCell (obj, _cells[cellX+2][cellY-2], data, packet);
				_MobEnteredCell (obj, _cells[cellX]  [cellY-2], data, packet);
				_MobEnteredCell (obj, _cells[cellX+1][cellY-2], data, packet);
			}
		}
		else
		if (newX < leftBound) {
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Bottom Left");
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY-1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY-1], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY-2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX]  [cellY-2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-1][cellY-2], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX+1][cellY], data, packet);
				_MobLeftCell (obj, _cells[cellX+1][cellY-1], data, packet);

				_MobEnteredCell (obj, _cells[cellX-2][cellY], data, packet);
				_MobEnteredCell (obj, _cells[cellX-2][cellY-1], data, packet);
				_MobEnteredCell (obj, _cells[cellX-2][cellY-2], data, packet);
				_MobEnteredCell (obj, _cells[cellX]  [cellY-2], data, packet);
				_MobEnteredCell (obj, _cells[cellX-1][cellY-2], data, packet);
			}
		}
		else // X not changed
		{
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Bottom");
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY+1], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX]  [cellY+1], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY+1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX-1][cellY-2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX]  [cellY-2], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+1][cellY-2], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX-1][cellY+1], data, packet);
				_MobLeftCell (obj, _cells[cellX]  [cellY+1], data, packet);
				_MobLeftCell (obj, _cells[cellX+1][cellY+1], data, packet);

				_MobEnteredCell (obj, _cells[cellX-1][cellY-2], data, packet);
				_MobEnteredCell (obj, _cells[cellX]  [cellY-2], data, packet);
				_MobEnteredCell (obj, _cells[cellX+1][cellY-2], data, packet);
			}
		}
	} else {
		if (newX > rightBound) {
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Right");
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY-1], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX-1][cellY+1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY+1], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX+2][cellY-1], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX-1][cellY+1], data, packet);
				_MobLeftCell (obj, _cells[cellX-1][cellY], data, packet);
				_MobLeftCell (obj, _cells[cellX-1][cellY-1], data, packet);

				_MobEnteredCell (obj, _cells[cellX+2][cellY+1], data, packet);
				_MobEnteredCell (obj, _cells[cellX+2][cellY], data, packet);
				_MobEnteredCell (obj, _cells[cellX+2][cellY-1], data, packet);
			}
		}
		if (newX < leftBound) {
			if (playerHere) {
				Log::getSingleton( ).outDebug ("<debug> Player moved Left");
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY+1], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY], playerData, packet);
				_PlayerLeftCell ((Player *)obj, _cells[cellX+1][cellY-1], playerData, packet);

				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY+1], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY], data, playerData, packet);
				_PlayerEnteredCell ((Player *)obj, _cells[cellX-2][cellY-1], data, playerData, packet);
			} else {
				_MobLeftCell (obj, _cells[cellX+1][cellY+1], data, packet);
				_MobLeftCell (obj, _cells[cellX+1][cellY], data, packet);
				_MobLeftCell (obj, _cells[cellX+1][cellY-1], data, packet);

				_MobEnteredCell (obj, _cells[cellX-2][cellY+1], data, packet);
				_MobEnteredCell (obj, _cells[cellX-2][cellY], data, packet);
				_MobEnteredCell (obj, _cells[cellX-2][cellY-1], data, packet);
			}
		}
	}

	if (newCell != NULL)
	{
		obj->SetMapCell (newCell);
		ASSERT (newCell->HasObject (obj) == FALSE);
		newCell->AddObject (obj);
	}

	/*
    if (playerHere && playerData.HasData())
    {
		//obj->BuildCreateUpdateBlockForPlayer( &playerData, (Player*)obj );

		playerData.BuildPacket(&packet);
        ((Player*)obj)->GetSession()->SendPacket( &packet );
    }
	*/
}

//-----------------------------------------------------------------------------
void MapMgr::_UpdateObjects()
{
    UpdateData *data;
    HM_NAMESPACE::hash_map<Player*, UpdateData*> updates;
    HM_NAMESPACE::hash_map<Player*, UpdateData*>::iterator i;

    ObjectSet::iterator iobj, iobjend;
	Player * player;
	Item * item;

	// Scan every updated object in the world
	//
    for ( iobj = _updatedObjects.begin(), iobjend = _updatedObjects.end();
        iobj != iobjend; iobj++ )
    {
		uint8 type_id = (*iobj)->GetTypeId();

		// If this is player - then build update packet for himself
		//
		if ((*iobj)->isPlayer())
		{
			player = (Player *)*iobj;

			i = updates.find (player);
			if (i == updates.end())
			{
				data = new UpdateData;
				ASSERT(data);

				updates[player] = data;
			}
			else 
				data = i->second;

			player->BuildValuesUpdateBlockForPlayer (data, player);
		}

		// Build update packets for Items and Containers
		//
        if (type_id == TYPEID_ITEM || 
			type_id == TYPEID_CONTAINER) // || type_id == TYPEID_GAMEOBJECT)
        {
			item = (Item *)*iobj;

            i = updates.find (item->GetOwner());
            if (i == updates.end())
            {
                data = new UpdateData;
                ASSERT(data);

                updates[item->GetOwner()] = data;
            }
            else
                data = i->second;

            item->BuildValuesUpdateBlockForPlayer (data, item->GetOwner());
        }

		// Iterate over all surrounding objects looking for players and
		// appending update info for them to packets
		//
		Object *o;
		for (MapRangeIterator iplr (*iobj); o = iplr.Advance(); )
        {
            if (o->isNotPlayer()) continue;
            
            // TODO: take ranges into accounts as suggested by quetzal

			// Search for already registered update packet for player
			// and append next object update there or create new UpdateData
			//
            i = updates.find( (Player *)o );
            if (i == updates.end())
            {
                data = new UpdateData;
                ASSERT(data);

                updates[(Player *)o] = data;
            }
            else
                data = i->second;

            (*iobj)->BuildValuesUpdateBlockForPlayer( data, (Player *)o );
        }

		// Mark that update data already fetched and sent - clear update fields.
        (*iobj)->ClearUpdateMask();
    }

	// Send all update packets to players
	//
	for ( i = updates.begin(); i != updates.end(); i++ )
    {
		WorldPacket packet;
        UpdateData *up_data = i->second;

		if (up_data->HasData()) 
		{
			up_data->BuildPacket( &packet );
		
			// Send next update from list
		    ((Player*)(i->first))->GetSession()->SendPacket( &packet );
		}

		// Free heap-allocated update data object
        delete up_data;
    }

    updates.clear();
    _updatedObjects.clear();
}

//-----------------------------------------------------------------------------
void MapMgr::Update(time_t diff)
{
    for(int i = 0; i < MMUPDATE_COUNT; i++)
        _timers[i].Update(diff);

/*
    if (_timers[MMUPDATE_OBJECTS].Passed())
    {
        _timers[MMUPDATE_OBJECTS].Reset();

        ObjectMgr::PlayerMap::iterator chriter;
        ObjectMgr::CreatureMap::iterator iter;

        for( chriter = objmgr.Begin<Player>(); chriter != objmgr.End<Player>( ); ++ chriter )
            chriter->second->Update( fTime );

        for( iter = objmgr.Begin<Creature>(); iter != objmgr.End<Creature>(); ++ iter )
            iter->second->Update( fTime );
    }
*/

    if (_timers[MMUPDATE_FIELDS].Passed())
    {
        _timers[MMUPDATE_FIELDS].Reset();

        _UpdateObjects();
    }
}

//-----------------------------------------------------------------------------
void MapMgr::ScanForFriends (Creature *caller, float scanRadius, ObjectSet &friends)
{
	Object *o;
	for (MapRangeIterator itr (caller); o = itr.Advance(); ) 
	{
		if (o->isUnit() == false) continue;

		// ignore self - implemented in Advance()
		// if ((Object *)caller == o) continue;

		Creature * cr = (Creature *)o;
		float	distSq = caller->GetDistanceSq (cr);

		// Check if helpful family member can hear me
		if (distSq > scanRadius * scanRadius) continue;

		// We won't worry our combating enemies. Only idle enemies will get aggro.
		if (cr->isInCombat()) continue;

		// Check if first word of creature name is like my
		// TEMP-LOCKED OPTION: Think enough comparing only factions
		//if (caller->RelatedByFirstName (cr) == false) continue;

		// Family member must have my faction, to be useful
		if (caller->GetFaction() != cr->GetFaction()) continue;

		// YES! My Friend!!!
		friends.insert (cr);
	}
}

//-----------------------------------------------------------------------------
void MapMgr::UpdateActiveObjects (uint32 diff) 
{
	Unit *obj;
	
	GuidVector	badGuids;
	badGuids.reserve (512);

	GuidVector	activeGuids;
	activeGuids.reserve (512);

	for (GuidSetIterator i = _activeGuids.begin(); i != _activeGuids.end(); i++) 
	{
		activeGuids.push_back (*i);
	}

	Guid guid;
	for (int i = activeGuids.size()-1; i >= 0; i--)
	{
		guid = activeGuids[i];
		obj = (Unit *)objmgr.GetObject<Creature> (guid);
		
		// if Guid was invalid - delete it after this loop
		if (obj == NULL) {
			badGuids.push_back (guid);
			continue;
		}

		ASSERT (obj->isUnit());

		obj->Update( (uint32)diff );
	}

	for (int j = 0; j < (int)badGuids.size(); j++)
		_activeGuids.erase (badGuids[j]);
}

//--- END ---