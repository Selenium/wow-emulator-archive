// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

//
// CellHandler.h
//

#ifndef __CELLHANDLER_H
#define __CELLHANDLER_H

#include "Common.h"

class Map;

template < class Class >
class CellHandler
{
public:
    CellHandler(Map *map);
    CellHandler(Map *map, uint32 minX, uint32 minY, uint32 maxX, uint32 maxY, uint32 cellSize);
    ~CellHandler();

    Class *GetCell(uint32 x, uint32 y);
    Class *GetCellByCoords(float x, float y);
    Class *Create(uint32 x, uint32 y);
    Class *CreateByCoords(float x, float y);
    void Remove(uint32 x, uint32 y);

    inline bool Allocated(uint32 x, uint32 y) { return _cells[x][y] != NULL; }

    uint32 GetPosX(float x); 
    uint32 GetPosY(float y);

    Map *GetBaseMap() { return _map; }

protected:
    void _Init();

    float _minX, _minY, _maxX, _maxY;
    uint32 _cellSize, _sizeX, _sizeY;
    Class ***_cells;

    Map* _map;
};

template <class Class>
CellHandler<Class>::CellHandler(Map* map)
{
    _map = map;
    _minX = -18000;
    _minY = -18000;
    _maxX = 18000;
    _maxY = 18000;
    _cellSize = 80;

    _Init();
}

template <class Class>
CellHandler<Class>::CellHandler(Map* map, uint32 minX, uint32 minY, uint32 maxX, 
                                uint32 maxY, uint32 cellSize)
{
    _map = map;
    _minX = minX;
    _minY = minY;
    _maxX = maxX;
    _maxY = maxY;
    _cellSize = cellSize;

    _Init();
}

template <class Class>
void CellHandler<Class>::_Init()
{
	_sizeX = (uint32)(abs(_minX) + _maxX)/_cellSize;
	_sizeY = (uint32)(abs(_minY) + _maxY)/_cellSize;

    _cells = new Class**[_sizeX];
	
    ASSERT(_cells);
	for (uint32 i = 0; i < _sizeX; i++)
	{
		_cells[i] = new Class*[_sizeY];
		ASSERT(_cells[i]);
	}

	for (uint32 posX = 0; posX < _sizeX; posX++ )
	{
		for (uint32 posY = 0; posY < _sizeY; posY++ )
		{
			_cells[posX][posY] = NULL;
		}
	}
}

template <class Class>
CellHandler<Class>::~CellHandler()
{
	if(_cells)
	{
		for (uint32 i = 0; i < _sizeX; i++)
		{
            for (uint32 j = 0; j < _sizeY; j++)
            {
                delete _cells[i][j];
            }
			delete [] _cells[i];
		}
		delete [] _cells;
	}
}

template <class Class>
Class* CellHandler<Class>::Create(uint32 x, uint32 y)
{
    ASSERT(_cells[x][y] == NULL);
    
    Class *cls = new Class;
    _cells[x][y] = cls;

    return cls;
}

template <class Class>
Class* CellHandler<Class>::CreateByCoords(float x, float y)
{
    return Create(GetPosX(x),GetPosY(y));
}

template <class Class>
void CellHandler<Class>::Remove(uint32 x, uint32 y)
{
    ASSERT(_cells[x][y] != NULL);

    Class *cls = _cells[x][y];
    _cells[x][y] = NULL;

    delete cls;
}

template <class Class>
Class* CellHandler<Class>::GetCell(uint32 x, uint32 y)
{
    return _cells[x][y];
}

template <class Class>
Class* CellHandler<Class>::GetCellByCoords(float x, float y)
{
    return GetCell(GetPosX(x),GetPosY(y));
}

template <class Class>
uint32 CellHandler<Class>::GetPosX(float x)
{
    ASSERT((x >= _minX) && (x <= _maxX));
    uint32 cellX = (uint32)(x > 0 ? abs(_minX) + x : abs(_minX) - abs(x));
    cellX /= _cellSize;
    
    return cellX;
}

template <class Class>
uint32 CellHandler<Class>::GetPosY(float y)
{
    ASSERT((y >= _minY) && (y <= _maxY));
    uint32 cellY = (uint32)(y > 0 ? abs(_minY) + y : abs(_minY) - abs(y));
    cellY /= _cellSize;
    
    return cellY;
}

#endif