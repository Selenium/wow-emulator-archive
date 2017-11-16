#ifndef _LINKEDNODE_H_
#define _LINKEDNODE_H_

#include "Common.h"

template<class> class LinkedList;

template<class TYPE>
class LinkedNode {
    friend class LinkedList<TYPE>;
    TYPE       *Data;
    wxUint16    Index;
    LinkedNode *Next;
    LinkedNode *Previous;

    void LinkedConstructor (void) {
        Previous = NULL; Next = NULL;
        Data = NULL; Index = NULL;
    }
    LinkedNode (void) { LinkedConstructor(); }
    LinkedNode (TYPE *Value) { LinkedConstructor(); Data = Value; }
    LinkedNode (TYPE *Value, LinkedNode *PrevSegment) {
        LinkedConstructor();
        Data = Value; Previous = PrevSegment;
        Index = PrevSegment->GetIndex() + 1;
    }
    public:
        

        TYPE       *GetData     (void) { return Data; }
        wxUint16    GetIndex    (void) { return Index; }
        LinkedNode *GetNext     (void) { return Next; }
        LinkedNode *GetPrevious (void) { return Previous; }
};

#endif
