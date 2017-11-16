// (c) Abyss Group
#include "DatabaseEnvironment.h"
#include <stdio.h>

void test_mysql();
void test_sqlite();

int main(int argc, char **argv)
{
	new Config();
	if (!Config::GetSingleton().SetSource("AbyssX.conf"))
	{
		fprintf(stderr, "Could not load AbyssX.conf\n");
		return 0;
	}
	new LogManager("LoginServer");

	if (argc < 2 || strchr(argv[1], 'm'))
		test_mysql();
	if (argc < 2 || strchr(argv[1], 'i'))
		test_sqlite();

	delete LogManager::GetSingletonPtr();
	delete Config::GetSingletonPtr();

	return 0;
}

void test_mysql()
{
	int i, n, r;

	printf("testing mysql...\n");
	DatabaseMysql db("localhost;abyssx;quacko23_;abyssx");

	if (db)
		printf("connection established\n");
	else
	{
		printf("could not connect\n");
		return;
	}

	r = db.Query("SELECT * FROM test;");
	n = db.FieldCount();
	printf("Rows selected: " GUIDFMT ", Query return: %d\n",
		db.RowCount(), r);
	for (i = 0; i < n; i++)
		printf("|_%s_|\t", db[i]->Name());
	printf("\n");
	do
	{
		for (i = 0; i < n; i++)
		{
			if (db[i]->Value())
				printf("|%s|\t", db[i]->Value());
			else
				printf("NULL\t");
		}
		printf("\n");
	} while (db.NextRow());
}

void test_sqlite()
{
	int i, n, r;

	printf("testing sqlite...\n");
	DatabaseSqlite db("testdb.db");

	if (db)
		printf("database opened\n");
	else
	{
		printf("could not open database\n");
		return;
	}

	db.Query("CREATE TABLE test (int I, str S, floob F, xyz);");
	db.Query("INSERT INTO test VALUES(7, 'pork chops', 6.779, 'who knows');");
	db.Query("INSERT INTO test (int, str, xyz) VALUES(89, 'blah', 13);");

	r = db.Query("SELECT * FROM test;");
	n = db.FieldCount();
	printf("Rows selected: " GUIDFMT ", Query return: %d\n",
		db.RowCount(), r);
	for (i = 0; i < n; i++)
		printf("|_%s_|\t", db[i]->Name());
	printf("\n");
	do
	{
		for (i = 0; i < n; i++)
		{
			if (db[i]->Value())
				printf("|%s|\t", db[i]->Value());
			else
				printf("NULL\t");
		}
		printf("\n");
	} while (db.NextRow());
}
