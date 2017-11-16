#ifndef __SCRIPTEVENT_H
#define __SCRIPTEVENT_H

class ScriptCallbackNode
{
	
	luabind::functor<int> Function;
	luabind::object Table;

	unsigned long NextThink;
	ScriptCallbackNode *next;
    wxStopWatch &Watch;
public:
		
	ScriptCallbackNode(luabind::functor<int> function,luabind::object table,wxStopWatch &watch): 
											Function(function),
											Table(table),
											next(NULL),
											Watch(watch)
	{
	NextThink = Watch.Time();
	}
	
	bool Call(ScriptCallbackNode **Next)
	{
		//dirty but effective way of tightening the loop
		*Next = next; 
		
		if ((unsigned long)Watch.Time() < NextThink) return true;
		int res = Function(Table);
		// if the result is negative the event should be destroyed
		if (res < 0)
		{
			delete this;
			return false; 
		}
		// if all went well sleep for the duration
		NextThink+= res;
		return true;
	}
	ScriptCallbackNode *Attach(ScriptCallbackNode *link)
	{
		next = link;
		return link;
	}
	
};
class ScriptCallbackList
{
private:
	ScriptCallbackNode *root;
	ScriptCallbackNode *last;
	wxStopWatch &StopWatch;
public:
	ScriptCallbackList(wxStopWatch &stopwatch) :root(NULL),last(NULL),StopWatch(stopwatch) {}
	void Call()
	{
		if(!root) return; //if there's nothing to call
		ScriptCallbackNode *current,*previous;

		// provision for the event that root will get destroyed
		while(root && !root->Call(&current)) //stores the next in list in current
			root = current; //store on stack (
		previous = root;
		while(current)
		{
			if( !current->Call(&current))
				previous->Attach(current);
			previous = current;
		}
	}
	void Attach(luabind::functor<int> function,luabind::object table)
	{
		ScriptCallbackNode *NewNode = new ScriptCallbackNode(function,table,StopWatch);
		if (root)
			last = last->Attach(NewNode);
		else
			root = last = NewNode;
	}
};



#endif
