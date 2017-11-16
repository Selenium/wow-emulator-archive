//******************************************************************************
#ifndef _REALMLIST_H
#define _REALMLIST_H
//==============================================================================
#include "../Shared/Singleton.h"
#include "../Shared/OurDefs.h"
//==============================================================================
struct Realm
{
    std::string address;
    uint8 icon;
    uint8 color;
    uint8 timezone;
};
//==============================================================================
class RealmList : public Singleton<RealmList>
{
public:
    typedef std::map<std::string, Realm*> RealmMap;

    ~RealmList();

    void AddRealm( const char * name, const char * address, uint8 icon, uint8 color, uint8 timezone );
    void SetRealm( const char * name, uint8 icon, uint8 color, uint8 timezone );
    void RemoveRealm (const char * name );

    RealmMap::const_iterator begin() const { return _realms.begin(); }
    RealmMap::const_iterator end() const { return _realms.end(); }
    size_t size() const { return _realms.size(); }

private:
    RealmMap _realms;
};
//==============================================================================
#define sRealmList RealmList::getSingleton()
//==============================================================================
#endif
//******************************************************************************