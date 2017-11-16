#ifndef _OBJECT_POOL_H_
#define _OBJECT_POOL_H_

//the meaning of this class is to avoid alocation and deallocation of objects
//on looting creatures there are created allways a couple of items ... these can be recycled so we will not require the garbage coelctor asistance

#ifndef NULL
#define NULL 0
#endif
//will store a pointer to the object
template <class Obj>
class Obj_List_Node
{
public:
	Obj_List_Node *next;
	Obj	*value;
};

template <class Obj>
class Obj_List
{
public:
	Obj_List(){first=NULL;}
	void add(Obj_List_Node<Obj> *new_obj)//when we add a new node to the list
	{
		new_obj->next = first;
		first = new_obj;
	}
	Obj_List_Node<Obj>* v_del(Obj *old_obj)//when we want to move a node to another list
	{
		Obj_List_Node<Obj> *kur = first,*prev = NULL;
		while(kur && kur->value!=old_obj)
		{
			prev = kur;
			kur = kur->next;
		}
		if(kur)
		{
			if(prev)prev->next = kur->next;
			else if(kur==first)first = kur->next;
			return kur;
		}
		return NULL;
	}
	void v_del(Obj_List_Node<Obj> *a_node)//when we want to move a node to another list
	{
		Obj_List_Node<Obj> *kur = first,*prev = NULL;
		while(kur && kur!=a_node)
		{
			prev = kur;
			kur = kur->next;
		}
		if(kur)
		{
			if(prev)prev->next = kur->next;
			else if(kur==first)first = kur->next;
		}
	}
	void clear()
	{
		Obj_List_Node<Obj> *kur = first;
		while(kur)
		{
			Obj_List_Node<Obj> *next=kur->next;
			delete kur->value;
			delete kur;
			kur=next;
		}
	}
	Obj_List_Node<Obj>	*first;
};

class Item;
class Character;

class Object_Pool
{
public:
	~Object_Pool()
	{
		free_items.clear();
		used_items.clear();
	}
	
	Item*		Get_New_item();			//will check if has a free object that can be reinited if not we create a new one
	Item*		Get_fast_New_item();	//without refurbish
	void		Release_item(Item*);	//will insert this object in the list of unused objecs
	Character*	Get_New_Character();	//will check if has a free object that can be reinited if not we create a new one
	void		Release_Character(Character*);	//will insert this object in the list of unused objecs

	Obj_List<Item>		free_items;
	Obj_List<Item>		used_items; //will not contain the template items !
	Obj_List<Character>	free_chars;
	Obj_List<Character>	used_chars;
};

#endif