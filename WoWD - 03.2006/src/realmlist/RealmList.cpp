//
// RealmList.cpp
//

#include "Common.h"
#include "RealmList.h"
#include "Database/DatabaseEnv.h"



initialiseSingleton( RealmList );



RealmList::RealmList( )
{
}

RealmList::~RealmList( )
{
    for( RealmMap::iterator i = _realms.begin(); i != _realms.end(); i++ )
        delete i->second;

    _realms.clear( );
    for( PatchMap::iterator i = _patches.begin(); i != _patches.end(); i++ )
        delete i->second;

    _patches.clear( );
}
//DK:Realmlist
void RealmList::GetAndAddRealms()
{
	std::stringstream query;
	//query << "SELECT name,address,population,type,color,language,online FROM realms";
	query << "SELECT name,address,icon,color,timezone FROM realms";
	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
        Field *fields = result->Fetch();
		//Openw0w style realm
		//FIXME:Online-Offline
		/*if(!(NumChars = fields[6].GetUInt8()))
		{
			r->Color = 2;
		}*/
		AddRealm(fields[0].GetString(),fields[1].GetString(),fields[2].GetUInt8(), fields[3].GetUInt8(), fields[4].GetUInt8());

		while( result->NextRow() )
        {
            Field *fields = result->Fetch();
			//Openw0w style realm
			//FIXME:Online-Offline
			/*if(!(NumChars = fields[6].GetUInt8()))
			{
				r->Color = 2;
			}*/
  			AddRealm(fields[0].GetString(),fields[1].GetString(),fields[2].GetUInt8(), fields[3].GetUInt8(), fields[4].GetUInt8());
		}
		delete result;
	}
	else
	{
		sLog.outString( "Realm:***There is no realm defined in database!Working at localhost mode!***" );
	}
}
//Finish

void RealmList::AddRealm( const char * name, const char * address, uint8 icon, uint8 color, uint8 timezone )
{
	if(_realms[ name ])
		RemoveRealm( name );

    //_realms[ name ] = new Realm( );
	_realms[ name ] = new Realm( name, address, icon, color , timezone);

    _realms[ name ]->address = address;
    _realms[ name ]->icon = icon;
    _realms[ name ]->color = color;
    _realms[ name ]->timezone = timezone;
}

void RealmList::SetRealm( const char * name, uint8 icon, uint8 color, uint8 timezone )
{
    if( _realms.find( name ) != _realms.end( ) )
    {
        _realms[ name ]->icon = icon;
        _realms[ name ]->color = color;
        _realms[ name ]->timezone = timezone;
    }
}

void RealmList::RemoveRealm( const char * name )
{
    if( _realms.find( name ) != _realms.end( ) )
    {
        delete _realms[ name ];
        _realms.erase( name );
    }
}

void RealmList::UpdateRealms()
{
    for ( RealmMap::iterator i = _realms.begin(); i != _realms.end(); ++i ) {
        delete i->second;
    }
    _realms.clear();
	GetAndAddRealms();
}
