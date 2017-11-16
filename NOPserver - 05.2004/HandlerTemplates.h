#ifndef _HANDLERTEMPLATES_H
#define _HANDLERTEMPLATES_H

class wowPacket;

class  HandlerFunctor
{
public:
      virtual void operator ()(wowPacket *) =0;
};


template<class T>
class  MemberHandlerFunctor :public HandlerFunctor
{
public:
    typedef void (T::*methodType)(wowPacket*);
private:
	T *object;
    methodType func;
public:
    virtual void operator ()(wowPacket *packet)
	{
		(object->*func)(packet);
	}
	MemberHandlerFunctor(T*obj,methodType f)
	{
		object = obj;
		func = f;
	}
};


class  FunctionHandlerFunctor :public HandlerFunctor
{
public:
	typedef void (*functionType)(wowPacket*);
private:
    functionType func;
public:
    virtual void operator ()(wowPacket *packet)
	{
		(*func)(packet);
	}
	FunctionHandlerFunctor(functionType f)
	{
		func = f;
	}
};
template<class HANDLER,class ROUTER>
class RoutedHandlerFunctor : public HandlerFunctor
{
public:
	typedef HANDLER* (ROUTER::*routermethod)(wowPacket *);
	typedef void (HANDLER::*handlermethod)(wowPacket*);
private:
	ROUTER *router;
	routermethod Rmethod;
	handlermethod   Hmethod;
public:
	RoutedHandlerFunctor(ROUTER *robj,routermethod R,handlermethod H)
	{
		router = robj;
		Rmethod = R;
		Hmethod = H;
	}
	 virtual void operator ()(wowPacket *packet)
	 {
		HANDLER *obj = (router->*Rmethod)(packet);
		if (obj) (obj->*Hmethod)(packet);
	 }
};


class CallbackFunctor
{
protected:
	wxStopWatch &sw;
	unsigned long NextThink;
	bool mDead;
public:
      virtual bool operator ()() =0;
	  virtual void Kill() { mDead = true;}
	  CallbackFunctor(wxStopWatch &s) :sw(s),NextThink(s.Time()),mDead(false) {}
};

template<class T>
class  MemberCallbackFunctor :public CallbackFunctor
{
	T *object;
    typedef long (T::*methodType)();
    methodType func;
public:
    virtual bool operator ()()
	{
		if (mDead) return true;
		if (NextThink > (unsigned long)sw.Time()) return true; 
		long ret = (object->*func)();
		if (ret < 0) return false;
		NextThink += ret;
		return true;
	}
	MemberCallbackFunctor(wxStopWatch &s,T*obj,methodType f):CallbackFunctor(s)
	{
		object = obj;
		func = f;
	}
};

class  FunctionCallbackFunctor :public CallbackFunctor
{
    typedef long (*functionType)();
    functionType func;
public:
    virtual bool operator ()()
	{
		if (mDead) return true;
		if (NextThink > (unsigned long)sw.Time()) return true; 
		long ret = (*func)();
		if (ret < 0) return false;
		NextThink += ret;
		return true;
	}
	FunctionCallbackFunctor(wxStopWatch &s,functionType f):CallbackFunctor(s)
	{
		func = f;
	}
};


class CallbackNode
{
	CallbackNode *next;
	CallbackFunctor *func;	
public:
	CallbackNode(CallbackFunctor *f): 	next(NULL),func(f) {}
	~CallbackNode()
	{
		delete func;
	}
	
	bool Call(CallbackNode **Next)
	{
		//dirty but effective way of tightening the loop
		*Next = next; 
		if (!(*func)())
		{
			delete this;
			return false; 
		}
		return true;
	}
	CallbackNode *Attach(CallbackNode *link)
	{
		next = link;
		return link;
	}
	
};
class CallbackList
{
private:
	CallbackNode *root;
	CallbackNode *last;
public:
	CallbackList() :root(NULL),last(NULL) {}
	void Call()
	{
		if(!root) return; //if there's nothing to call
		CallbackNode *current,*previous;

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
	void Attach(CallbackFunctor *f)
	{
		CallbackNode *NewNode = new CallbackNode(f);
		if (root)
			last = last->Attach(NewNode);
		else
			root = last = NewNode;
	}
};

#endif
