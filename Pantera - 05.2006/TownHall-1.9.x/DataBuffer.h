#ifndef DATABUFFER_H
#define DATABUFFER_H

#include <string>
using namespace std;

class CDataBuffer
{
protected:
	char *m_buffer;
	int m_size;
	int m_position;
private:
	void EnsureBufferSize(int size)
	{
		if(size > m_size)
		{
			int newSize = m_size;
			do
			{
				newSize<<=1;
			}
			while(newSize < size);

			char *tmp = new char[newSize];
			memcpy(tmp, m_buffer, m_size);
			delete [] m_buffer;
			m_buffer = tmp;
			m_size = newSize;
		}
	}
	inline void ValidateReadTo(int position)
	{
		if(position > m_size)
			throw "Buffer overread";
	}
public:
	CDataBuffer()
	{
		m_buffer = new char[256];
		m_size = 256;
		m_position = 0;
	}
	CDataBuffer(int initialbuffersize)
	{
		m_buffer = new char[initialbuffersize];
		m_size = initialbuffersize;
		m_position = 0;
	}

	CDataBuffer(void *buffer, int size)
	{
		m_buffer = new char[size];
		memcpy(m_buffer, buffer, size);
		m_size = size;
		m_position = 0;
	}
	~CDataBuffer()
	{
		delete [] m_buffer;
	}

	inline char* Buffer()
	{
		return m_buffer;
	}
	inline void Buffer(char *buffer, int size)
	{
		Size(size);
		memcpy(m_buffer, buffer, size);
	}

	inline int Size()
	{
		return m_size;
	}

	void Size(int size)
	{
		delete [] m_buffer;
		m_buffer = new char[size];
	}

	void Resize(int size)
	{
		if(m_size == size)
			return;
		else if(m_size < size)
			EnsureBufferSize(size);
		else
		{
			char *tmp = new char[size];
			memcpy(tmp, m_buffer, size);
			delete [] m_buffer;
			m_buffer = tmp;
			m_size = size;
		}
	}

	inline int Position()
	{
		return m_position;
	}

	inline void Position(int position)
	{
		m_position = position;
	}

	inline void Clear()
	{
		memset(m_buffer, 0, m_size);
		m_position = 0;
	}

	template <typename type> inline void Write(const type val)
	{
		EnsureBufferSize(m_position+sizeof(type));
		*(type*)&m_buffer[m_position] = val;
		m_position += sizeof(type);
	}

	inline void Write(const void *data, int len)
	{
		EnsureBufferSize(m_position+len);
		memcpy(&m_buffer[m_position], data, len);
		m_position += len;
	}

	inline void Write(char *str)
	{
		Write(str, (int)(strlen(str)+1));
	}

	inline void Write(const char *str)
	{
		Write(str, (int)(strlen(str)+1));
	}

	inline void Write(const string str)
	{
		Write(str.c_str(), (int)(str.length()+1));
	}

	template <typename type> inline CDataBuffer & operator<<(const type val)
	{
		Write(val);
		return *this;
	}

	template <typename type> inline void Read(type &val)
	{
		ValidateReadTo(m_position+sizeof(type));
		val = *(type*)&m_buffer[m_position];
		m_position += sizeof(type);
	}

	inline void Read(void* data, int len)
	{
		ValidateReadTo(m_position+len);
		memcpy(data, &m_buffer[m_position], len);
	}

	inline void Read(string & str)
	{
		ValidateReadTo(m_position+1);
		string::size_type len = strlen(&m_buffer[m_position]);
		if(((int)(m_position+len)) > m_size)
			len = m_size-m_position;
		str.assign(&m_buffer[m_position], len);
		m_position += (int)len+1;
	}

	template <typename type> inline CDataBuffer & operator>>(type &val)
	{
		Read(val);
		return *this;
	}

	template <typename type> inline void Set(int position, const type val)
	{
		EnsureBufferSize(position+sizeof(type));
		*(type*)&m_buffer[position] = val;
	}

	inline void Set(int position, const char *str)
	{
		Set(position,str,strlen(str)+1);
	}
	inline void Set(int position, const string str)
	{
		Set(position, str.c_str(), (int)(str.length()+1));
	}

	inline void Set(int position, const void *data, const int len)
	{
		EnsureBufferSize(position+len);
		memcpy(&m_buffer[position], data, len);
	}

	template <typename type> inline void Get(int position, type &val)
	{
		ValidateReadTo(position+sizeof(type));
		val = *(type*)&m_buffer[position];
	}

	void Get(int position, string & str)
	{
		ValidateReadTo(position+1);
		string::size_type len = strlen(&m_buffer[position]);
		if(((int)(position+len)) > m_size)
			len = m_size-position;
		str.assign(&m_buffer[position], len);
	}

	inline void Get(int position, void *data, int len)
	{
		ValidateReadTo(position+len);
		memcpy(data, &m_buffer[position], len);
	}
};

#endif // DATABUFFER_H
