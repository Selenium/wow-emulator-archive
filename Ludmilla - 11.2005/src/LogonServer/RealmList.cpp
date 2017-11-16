//******************************************************************************
#include "StdAfx.h"
#include "RealmList.h"
//==============================================================================
createFileSingleton( RealmList );
//==============================================================================
RealmList::~RealmList( )
{
	for( RealmMap::iterator i = _realms.begin(); i != _realms.end(); i++ )
		delete i->second;

	_realms.clear( );
}
//------------------------------------------------------------------------------
void RealmList::AddRealm( const char * name, const char * address, uint8 icon, uint8 color, uint8 timezone )
{
	RemoveRealm( name );

	_realms[ name ] = new Realm( );

	_realms[ name ]->address = address;
	_realms[ name ]->icon = icon;
	_realms[ name ]->color = color;
	_realms[ name ]->timezone = timezone;
}
//------------------------------------------------------------------------------
void RealmList::SetRealm( const char * name, uint8 icon, uint8 color, uint8 timezone )
{
	if( _realms.find( name ) != _realms.end( ) )
	{
		_realms[ name ]->icon = icon;
		_realms[ name ]->color = color;
		_realms[ name ]->timezone = timezone;
	}
}
//------------------------------------------------------------------------------
void RealmList::RemoveRealm( const char * name )
{
	if( _realms.find( name ) != _realms.end( ) )
	{
		delete _realms[ name ];
		_realms.erase( name );
	}
}
//******************************************************************************
