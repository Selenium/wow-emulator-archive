// (c) Abyss Group
#if !defined(DATABASE_H)
#define DATABASE_H


//! Global function for initializing the database environment based on the set config file.
/*! @return True if database system was initialized successfully, false otherwise. */
//bool InitDatabase();


class Database : public Singleton<Database>
{
	protected:
		//Changed the protection to public for now...

		//! Initialize the database with information passed in the ';' delimited infoString.
		/* @param infoString Highly database module dependent. */
		Database(const char *infoString);
		
		//! Frees resources used by Database.
		virtual ~Database();
		
	public:	
		//! Query the database with a SQL command.
		/*
		This is where all the transaction with the database takes place.
		Any result data is held in memory and can be iterated through with NextRow().
		@param sql SQL command to query the database with. Should be supported by all database modules being used.
		@return Returns 1 if the query succeded and there are RowCount in the result, -1 if the query succeded but there is no result set, else 0. */
		virtual int Query(const char *sql) = 0;
		
		//! Selects the next row in the result of the current query.
		/*
		This will update any references to fields of the previous row, so use Field's copy constructor to keep a persistant field.
		@return 1 if the next row was successfully selected, else 0.
		*/
		virtual int NextRow() = 0;
		
		//! Returns a ';' delimited string with information on the open database.
		/* @return Highly database module dependent. */
		char *InfoString() { return mInfoString; }
		
		//! Returns a pointer to an array of fields of the currently selected row.
		/* Will be updated when NextRow() is called. */
		Field *Fetch() { return mCurrentRow; }
		
		//! Returns a single field reference.
		/* Will be updated when NextRow() is called. */
		Field *operator [] (int index) { return mCurrentRow + index; }
		
		//! Returns the number of fields in the current row.
		int FieldCount() { return mFieldCount; }
		
		//! Returns the rows affected or the number of rows selected, depending on the last query.
		QuadWord RowCount() { return mRowCount; }

		//! Returns the status of the database, and should be used to ensure the database was opened successfully.
		virtual operator bool () = 0;
		
	protected:
		static int ConvertNativeType();
		
		char *mInfoString;
		
		Field *mCurrentRow;
		
		int mFieldCount;
		
		QuadWord mRowCount;
};

#endif
