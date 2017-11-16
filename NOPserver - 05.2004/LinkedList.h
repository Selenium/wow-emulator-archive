#ifndef _LINKEDLIST_H_
#define _LINKEDLIST_H_

#include "LinkedNode.h"

template<class TYPE>
class LinkedList {
    wxUint16            Count;
    LinkedNode<TYPE>   *First;
    LinkedNode<TYPE>   *Last;
    public:
        LinkedList (void) { First = Last = 0; Count = 0; }
        ~LinkedList (void) {
            LinkedNode<TYPE> *node = First;
            while (node && node->Next) {
                if (node->Previous)
                    delete node->Previous;
                node = node->Next;
            }
            delete node;
        }

        LinkedNode<TYPE> *FindByIndex (wxUint16 i) {
            if (i < int(Count/2)) {
                LinkedNode<TYPE> *node = First;
                while (node && node->Index != i)
                    node = node->Next;

                return node;
            } else if (i >= int(Count/2)) {
                LinkedNode<TYPE> *node = Last;
                while (node && node->Index != i)
                    node = node->Previous;

                return node;
            } else // This wont happen - just to remove compiler warnings.
                return NULL;
        }

        LinkedNode<TYPE> *FindByData (TYPE Find) {
            for (LinkedNode<TYPE> *node = First; node; node = node->Next) {
                if (*node->GetData() == Find)
                    return node;
            }

            return NULL;
        }

        LinkedNode<TYPE> *FindByPtr (TYPE *Find) {
            for (LinkedNode<TYPE> *node = First; node; node = node->Next) {
                if (node->GetData() == Find)
                    return node;
            }

            return NULL;
        }
        

        wxUint16 GetCount (void) { return Count; }

        LinkedNode<TYPE> *GetFirst  (void) { return First; }
        LinkedNode<TYPE> *GetLast   (void) { return Last; }

        void Append (TYPE *NewData) {
            if (!First && !Last)
                First = Last = new LinkedNode<TYPE>(NewData);
            else
                Last = Last->Next = new LinkedNode<TYPE>(NewData, Last);

            Count++;
        }

        void DeleteNode (LinkedNode<TYPE> *Del) { 
            if (Del == First && Del == Last)
                Last = First = NULL;
            else if (Del == First && Del != Last)
                First = First->Next;
            else if (Del != First && Del == Last )
                Last = Last->Previous;

            if (Del->Next)
                Del->Next->Previous = Del->Previous;
            if (Del->Previous)
                Del->Previous->Next = Del->Next;

            for (LinkedNode<TYPE> *node = Del->Next; node; node = node->Next)
                node->Index--;

            delete Del; Count--;
        }
};

#endif
