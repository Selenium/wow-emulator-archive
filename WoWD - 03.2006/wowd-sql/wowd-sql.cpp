//wowd-sql.cpp
//The WoWD sql importer configruator!
#include <string>
#include <iostream>
#include <fstream>
using namespace std;

int main(void)
{
	

	if(system("mysql -ublargnarlsnarfj0312") == 0)
	{
		cout << "MySQL is not defined in your path.\n" 
			 << "Please run \"set path=\"<mysqlpath>\";%PATH\" to fix this!.\n";
		system("pause");
		return -1;
	}
	fstream fout("sql.bat",ios::out);
	if(!fout)
	{
		cout << "sql.bat is read only!  Please delete or fix the attributes for sql.bat!\n";
		system("pause");
		return -1;
	}
	else
	{
		string data = "mysql -h";
		char sinput[80];
		system("cls");
		cout << "Welcome to the WoWDaemon Sql Batch Configuration tool!.\n" <<
			    "Please enter the address of the MySQL server: ";
		cin.get(sinput,80);
		cin.ignore(80,'\n');
		data += sinput;
		data += " -u";
		cout << "Now please enter the username you wish to use!";
		cin.get(sinput,80);
		cin.ignore(80,'\n');
		data += sinput;
		data += " -p";
		cout << "Now enter the password for " << sinput << ": ";
		cin.get(sinput,80);
		cin.ignore(80,'\n');
		data += sinput;
		data += " < create_new.sql\0";
		cout << "sql.bat created!  Please remember to HAVE THE PATH TO MYSQL IN YOUR PATH!";
		fout << data;
		system("pause");
		return 0;
	}
}