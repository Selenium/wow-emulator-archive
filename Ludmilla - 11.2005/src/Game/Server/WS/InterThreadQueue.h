//******************************************************************************
#ifndef __INTERTHREADQUEUE_H
#define __INTERTHREADQUEUE_H
//==============================================================================
template <class T>
class CInterThreadQueue
{
public:
	void Lock()
		{
			lock.acquire();
			#ifdef _DEBUG
			locked = true;
			#endif
		}
	T Pop()
		{
			#ifdef _DEBUG
			ASSERT(!locked);
			#endif
			T ret = queue.front();
			queue.pop();
			return ret;
		}
	void Push(T t)
		{
			#ifdef _DEBUG
			ASSERT(!locked);
			#endif
			queue.push(t);
		}
	void Unlock()
		{
			lock.release();
			#ifdef _DEBUG
			locked = false;
			#endif
		}

protected:
	#ifdef _DEBUG
	bool locked;
	#endif
	std::queue < T > queue;
	ZThread::Mutex lock;
};
//==============================================================================
#endif //__INTERTHREADQUEUE_H
//******************************************************************************