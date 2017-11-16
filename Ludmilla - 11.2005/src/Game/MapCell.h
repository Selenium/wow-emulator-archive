//
// MapCell.h
//

#ifndef __MAP_CELL_H
#define __MAP_CELL_H

class MapCell
{
public:
	//MapCell() { }

    inline void AddObject (Object *obj) { _objects.insert(obj); }
    inline void RemoveObject (Object *obj) { _objects.erase(obj); }
	inline bool HasObject (Object *obj) { return !(_objects.find(obj) == _objects.end()); }

	inline ObjectSetIterator Begin() { return _objects.begin(); }
	inline ObjectSetIterator End() { return _objects.end(); }

	//int16 player_count;

protected:
    ObjectSet	_objects;
};

#endif