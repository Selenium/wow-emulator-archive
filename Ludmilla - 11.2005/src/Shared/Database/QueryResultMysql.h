// (c) NAWE Group

#if !defined(QUERYRESULTMYSQL_H)
#define QUERYRESULTMYSQL_H

//#ifdef WIN32
//#include <winsock2.h>
//#endif
//#include <mysql/my_global.h>
#include <mysql/mysql.h>

class QueryResultMysql : public QueryResult
{
    public:
        QueryResultMysql(MYSQL_RES *result, uint64 rowCount, uint32 fieldCount);

        //! Frees resources used by QueryResult.
        ~QueryResultMysql();

        //! Selects the next row in the result of the current query.
        /*
        This will update any references to fields of the previous row, so use Field's copy constructor to keep a persistant field.
        @return 1 if the next row was successfully selected, else 0.
        */
        bool NextRow();

    private:
        enum Field::DataTypes ConvertNativeType(enum_field_types mysqlType) const;
        void EndQuery();

        MYSQL_RES *mResult;
};

#endif
