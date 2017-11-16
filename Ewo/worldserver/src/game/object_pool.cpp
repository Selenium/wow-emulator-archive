#include "object_pool.h"
#include "item.h"

//will check if has a free object that can be reinited if not we create a new one
Item* Object_Pool::Get_New_item()
{
	if(!free_items.first)
	{
		//we have to create a new item
		Obj_List_Node<Item> *new_node=new Obj_List_Node<Item>;
		Item *new_item=new Item;
		new_node->value = new_item;
		used_items.add(new_node);
		return new_item;
	}
	else
	{
		//we remove first node from the list
		Obj_List_Node<Item> *a_node=free_items.first;
		free_items.v_del(a_node);
		used_items.add(a_node);
		a_node->value->Refurbish();
		return a_node->value;
	}
	return NULL;
}

//the difference is that it does not use refurbish
Item* Object_Pool::Get_fast_New_item()
{
	if(!free_items.first)
	{
		//we have to create a new item
		Obj_List_Node<Item> *new_node=new Obj_List_Node<Item>;
		Item *new_item=new Item;
		new_node->value = new_item;
		used_items.add(new_node);
		return new_item;
	}
	else
	{
		//we remove first node from the list
		Obj_List_Node<Item> *a_node=free_items.first;
		free_items.v_del(a_node);
		used_items.add(a_node);
		return a_node->value;
	}
	return NULL;
}

//will insert this object in the list of unused objecs
void Object_Pool::Release_item(Item*release_me)
{
	if(release_me->state1 & ITEM_STATE_IS_TEMPLATE)
		return; //we are not inserting this to the available item buffers
	//find the item in our used items list
	Obj_List_Node<Item> *z_node;
	z_node=used_items.v_del(release_me);
	if(z_node)
		free_items.add(z_node); //make sure to store only valid items here 
}

//will check if has a free object that can be reinited if not we create a new one
Character* Object_Pool::Get_New_Character()
{
	if(!free_chars.first)
	{
//printf("Object Pool : Create new char for request \n");
		//we have to create a new item
		Obj_List_Node<Character> *new_node=new Obj_List_Node<Character>;
		Character *new_char=new Character;
		ASSERT(new_char);
		new_node->value = new_char;
		used_chars.add(new_node);
		return new_char;
	}
	else
	{
//printf("Object Pool : Refurbish char on request \n");
		//we remove first node from the list
		Obj_List_Node<Character> *a_node=free_chars.first;
		free_chars.v_del(a_node);
		used_chars.add(a_node);
		a_node->value->Refurbish();
		return a_node->value;
	}
	return NULL;
}

//will insert this object in the list of unused objecs
void Object_Pool::Release_Character(Character*release_me)
{
//printf("Object Pool : Release char on request \n");
	//find the item in our used items list
	Obj_List_Node<Character> *z_node;
	z_node=used_chars.v_del(release_me);
	if(z_node)
		free_chars.add(z_node);
}
