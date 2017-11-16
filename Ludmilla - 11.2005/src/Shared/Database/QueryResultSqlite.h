// (c) NAWE Group

#if !defined(QUERYRESULTSQLITE_H)
#define QUERYRESULTSQLITE_H


class QueryResultSqlite : public QueryResult
{
    public:
        QueryResultSqlite(char **tableData, uint32 rowCount, uint32 fieldCount);

        //! Frees resources used by QueryResult.
        ~QueryResultSqlite();

        //! Selects the next row in the result of the current query.
        /*
        This will update any references to fields of the previous row, so use Field's copy constructor to keep a persistant field.
        @return 1 if the next row was successfully selected, else 0.
        */
        bool NextRow();

    private:
        enum Field::DataTypes ConvertNativeType(const char* sqliteType) const;
        void EndQuery();

        char **mTableData;
        uint32 mTableIndex;
};

#endif
