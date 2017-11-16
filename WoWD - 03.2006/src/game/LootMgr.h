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

#ifndef _LOOTMGR_H
#define _LOOTMGR_H


class LootTable
{
public:
	std::list<uint32>mItems;
	std::list<float>mChance;
	std::list<uint32>mProps;
	uint32 lootCount;
	uint32 lootMinCount;
	uint32 lootMaxCount;

};
class LootPropTable
{
public:
	std::list<uint32>mProps;
	std::list<float>mChance;

};
class LootMgr : public Singleton < LootMgr >
{
public:
    LootMgr();
    ~LootMgr();

	LootTable* getLoot(uint32 id);
	void loadLoot(uint32 id);
	LootPropTable* getLootProp(uint32 id);
	LootTable* getObjectLoot(uint32 id);
	void loadObjectLoot(uint32 id);
	void loadLootProp(uint32 id);

    // objects
    typedef HM_NAMESPACE::hash_map<uint32, LootTable*> LootMap;
	typedef HM_NAMESPACE::hash_map<uint32, LootPropTable*> LootPropMap;
	LootMap mLoots;
	LootMap mObjectLoots;
	LootPropMap mLootProps;
};
#define lootmgr LootMgr::getSingleton()

#endif
