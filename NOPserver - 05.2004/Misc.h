#ifndef __MISC_H
#define __MISC_H

#include "Common.h"
class wowPacket;


template<class item_class>
class ItemNode
{
	ItemNode *next;
	item_class* item;
public:
	ItemNode(item_class *i) :next(NULL),item(i) {}
	item_class* GetItem(ItemNode **pnext = NULL)
	{
		item_class * tempitem;
		tempitem = item;
		if(pnext) *pnext = next;
		delete this;
		return tempitem;
	}
	ItemNode *Attach(ItemNode *link)
	{
		next = link;
		return link;
	}
};

template<class list_item> class ItemList
{
	typedef ItemNode<list_item> ListNode;
	ListNode *final;
	ListNode *transit;
	ListNode *root,*last;
	bool swap_lists;
	wxCriticalSection ListAccess;
public:
	ItemList() :final(NULL),transit(NULL),root(NULL),last(NULL),swap_lists(false) {}
	~ItemList()
	{
		while(root) delete root->GetItem(&root);
		while(transit) delete transit->GetItem(&transit);
		while(final) delete root->GetItem(&final);
	}


	list_item *Get()
	{
		return final ? final->GetItem(&final) : GetList();
	}
	//GetList used to switch lists from the transit state to the final state
	//the thread risk for reading the value is minimal, as any change is still done 
	//under lock
	list_item *GetList()
	{
		if (root)swap_lists = true;//signal 
		if(transit) //is it thread safe?
		{
			wxCriticalSectionLocker locker(ListAccess); 
			final = transit;
			transit = NULL;		
		}
		return NULL; //just to tighten the loop a bit more
	}
	void Attach(list_item *item)
	{
		if (swap_lists) SwapLists();
		if(!root)
		{
			root = new ListNode(item);
			last = root;
			return;
		}
		last = last->Attach(new ListNode(item));
	}
	//swap lists - thread safe way of putting the list in "transit"
	void SwapLists()
	{
		if(root)
		{
			wxCriticalSectionLocker locker(ListAccess);
			transit = root;
			root = last = NULL;
			swap_lists = false;
		}
	}
};
//used to pass the packets to the world thread


template<class list_item> class SimpleItemList
{
	typedef ItemNode<list_item> ListNode;
	ListNode *root,*last;
	wxCriticalSection ListAccess;
public:
	SimpleItemList() : root(NULL),last(NULL){}
	~SimpleItemList() // delete any dangling items
	{
		while(root)
			delete root->GetItem(&root);
	}
	//gets the item - as it's propably only for one item only we can safely lock it each time
	//without sacrificing speed
	list_item *Get()
	{
		wxCriticalSectionLocker locker(ListAccess);
		return root ? root->GetItem(&root) : NULL;
	}
	void Attach(list_item *item)
	{
		wxCriticalSectionLocker locker(ListAccess);
		if(!root)
		{
			root = new ListNode(item);
			last = root;
			return;
		}
		last = last->Attach(new ListNode(item));
	}

};
template<class list_item> class SimplestItemList
{
	typedef ItemNode<list_item> ListNode;
	ListNode *root,*last;
public:
	SimplestItemList() : root(NULL),last(NULL){}
	~SimplestItemList() // delete any dangling items
	{
		while(root)
			delete root->GetItem(&root);
	}
	//gets the item - as it's propably only for one item only we can safely lock it each time
	//without sacrificing speed
	list_item *Get()
	{
		return root ? root->GetItem(&root) : NULL;
	}
	void Attach(list_item *item)
	{
		if(!root)
			root = last =new ListNode(item);
		else
			last = last->Attach(new ListNode(item));
	}

};





#endif 
