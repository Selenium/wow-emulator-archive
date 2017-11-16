// (c) Abyss Group
#if !defined(FIELD_H)
#define FIELD_H


class Field
{
	public:
		//! Contains general datatypes that native datatypes can be converted into.
		enum DataTypes
		{
			DB_TYPE_UNKNOWN = 0x00,
			DB_TYPE_STRING  = 0x01,
			DB_TYPE_INTEGER = 0x02,
			DB_TYPE_FLOAT   = 0x03
		};
		// no DB_TYPE_BOOLEAN for now, it will be a 1/0 integer

		Field();
		Field(Field &f);
		Field(const char *value, const char *name, enum DataTypes type);

		~Field();

		char *Value() { return mValue; }

		void SetValue(const char *value);

		char *Name() { return mName; }

		void SetName(const char *name);

		enum DataTypes Type() { return mType; }

		void SetType(enum DataTypes type) { mType = type; }

	private:
		char *mValue;

		char *mName;

		enum DataTypes mType;
};

#endif
