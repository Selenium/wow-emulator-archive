#pragma once
class CUpdateObject
{
	map<unsigned long, unsigned long> UpdateFields;
	unsigned long maxField;
	unsigned long MakeUpdateBlock(char *buffer, bool reset = true);
	virtual unsigned long AddCreateObjectData(char *buffer) {return 0;};
	virtual void PreCreateObject() {};
	virtual void PostCreateObject() {};
	
	virtual unsigned long AddCreateObjectDataNotMe(char *buffer) {return 0;};
	virtual void PreCreateObjectNotMe() {};
	virtual void PostCreateObjectNotMe() {};

	virtual unsigned long AddCreateObjectDataOnlyMe(char *buffer) {return 0;};
	virtual void PreCreateObjectOnlyMe() {};
	virtual void PostCreateObjectOnlyMe() {};

	void SendCompressedUpdate(unsigned long guid, unsigned long len);
	void SendCompressedUpdateNotMe(unsigned long guid, unsigned long len);
public:
	CUpdateObject(unsigned long maxBits)
	{
		maxField = maxBits;
	};

	void UpdateObject(unsigned long guid, unsigned long guidHigh, bool reset = true);
	void UpdateObjectOnlyMe(unsigned long guid, unsigned long guidHigh, bool reset = true);
	void CreateObjectNotMe(unsigned long guid, bool reset = true);
	void CreateObjectOnlyMe(unsigned long guid, bool reset = true);
	virtual void CreateObject(unsigned long guid, bool reset = true);

	inline virtual void CreateObject(bool reset = true) {throw "CUpdateObject::CreateObject() - not overriden";};
	inline virtual void CreateObjectNotMe(bool reset = true) {throw "CUpdateObject::CreateObjectNotMe() - not overriden";};
	inline virtual void CreateObjectOnlyMe(bool reset = true) {throw "CUpdateObject::CreateObjectOnlyMe() - not overriden";};
	inline virtual void UpdateObject(bool reset = true) {throw "CUpdateObject::UpdateObject() - not overriden";};
	inline virtual void UpdateObjectOnlyMe(bool reset = true) {throw "CUpdateObject::UpdateObjectOnlyMe() - not overriden";};
#define FADD32(type) \
	inline void AddUpdateVal(unsigned long field, type val) \
	{\
		UpdateFields[field] = *(unsigned long*)&val;\
	};
	FADD32(int);
	FADD32(unsigned int);
	FADD32(float);
	FADD32(unsigned long);
	FADD32(long);
#undef FADD32
	inline void AddUpdateVal(unsigned long field, unsigned long valLow, unsigned long valHigh)
	{
		UpdateFields[field] = valLow;
		UpdateFields[field+1] = valHigh;
	};
};
