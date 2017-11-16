//
// RealmList.h
//

#ifndef _REALMLIST_H
#define _REALMLIST_H

/*struct Realm
{
    std::string address;
    uint8 icon;
    uint8 color;
    uint8 timezone;
};*/



struct Realm
{
	/// Realm name
	const char *name;
	/// Server address (x.x.x.x:port)
	std::string address;
	/// Low/Medium/High, absolute values do not matter, everything is relative
	//float population;
	/// 0 - Normal, 1 - PvP, 2 - Offline
	uint32 icon;
	/// 0 - Orange, 1 - Red, 2 - Disabled
	uint8 color;
	/// 0,1 - English, 2 - German, 3 - French, 4 - Other
	uint8 timezone;
	/// Number of characters owned by the client on this server
	//uint8 numChars;

	/*Realm (const char *Name, const char *Address, float population, uint32 icon,
		   uint8 color, uint8 language)*/
	Realm (const char *Name, std::string Address, uint32 Icon, uint8 Color, uint8 Timezone)
	{
		name = Name;
		address = Address;
		//population = Population;
		icon = Icon;
		color = Color;
		timezone = Timezone;
		//numChars = 0;
	}

	~Realm ()
	{
	}
};


class RealmList : public Singleton<RealmList>
{
public:
    typedef std::map<std::string, Realm*> RealmMap;

    RealmList();
    ~RealmList();

    void AddRealm( const char * name, const char * address, uint8 icon, uint8 color, uint8 timezone );
	//DK
	void GetAndAddRealms();
	void UpdateRealms();
    void SetRealm( const char * name, uint8 icon, uint8 color, uint8 timezone );
    void RemoveRealm (const char * name );

    RealmMap::const_iterator begin() const { return _realms.begin(); }
    RealmMap::const_iterator end() const { return _realms.end(); }
    uint32 size() const { return _realms.size(); }


private:
    RealmMap _realms;

    struct Patch
    {
        uint8 Hash[16];
        char Platform[4];
    };

    typedef std::map <uint32, Patch*> PatchMap;
    PatchMap _patches;
};


#define sRealmList RealmList::getSingleton()


#endif

