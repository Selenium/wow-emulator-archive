//
// MapCell.h
//

#ifndef __MAP_CELL_H
#define __MAP_CELL_H

class MapCell
{
public:
    typedef std::set<Object*> ObjectSet;

    void AddObject(Object *obj) { _objects.insert(obj); }
    void RemoveObject(Object *obj) { _objects.erase(obj); }
    bool HasObject(Object *obj) { return !(_objects.find(obj) == _objects.end()); }

    ObjectSet::iterator Begin() { return _objects.begin(); }
    ObjectSet::iterator End() { return _objects.end(); }

private:
    ObjectSet _objects;
};

#endif