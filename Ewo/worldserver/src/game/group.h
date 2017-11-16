// Copyright (C) 2006 Team Evolution
#ifndef group20060521
#define group20060521 1

#include "constants.h"
#include "Character.h"

class Group_Node
{
public:
	Group_Node()
	{
		prev=NULL;
		next=NULL;
	}
	~Group_Node(){};
	Group_Node *next,*prev;
	Character *p_char;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Group
{
public:
	Group();
	~Group();
	void add(Character *p_char);
	void del(Character *p_char);
	inline Group_Node *find(Character *p_char)
	{
		Group_Node *kur=first;
		while(kur && kur->p_char!=p_char)
			kur = kur->next;
		return kur;
	}
	void update_group();
	void disband();
	void change_leader(Character *new_leader);
	Group_Node *first,*looter;
	uint32	member_count;
	Character *leader,*loot_master;
	uint8	loot_mode,loot_treshold;
	
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#endif