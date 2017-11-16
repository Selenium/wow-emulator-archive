// (c) Abyss Group
#if !defined (CONFIG_H)
#define CONFIG_H

#define CONFIG(x) Config::GetSingleton().GetConfigData()->x

class ConfigCursor
{
	public:
		ConfigCursor(const ConfigCursor &c) : mConf(c.mConf), mNode(c.mNode)
		{
		}

		ConfigCursor(DOTCONFDocument *conf) : mConf(conf), mNode(0)
		{
		}

		//! Moves the cursor to the beginning of the file.
		void Reset() { mNode = 0; }

		//! Moves the cursor to the next entry named nodeName.
		bool Find(const char *nodeName) { return (mNode = (DOTCONFDocumentNode *)mConf->findNode(nodeName, 0, mNode)) != NULL; }

		//! Moves the cursor to the next entry in the section the cursor is currently at named nodeName.
		bool FindIn(const char *nodeName) { return (mNode = (DOTCONFDocumentNode *)mConf->findNode(nodeName, mNode)) != NULL; }

		//! Moves the cursor to the next entry.
		bool Next() { return (mNode = (DOTCONFDocumentNode *)(mNode ? mNode->getNextNode() : mConf->getFirstNode())) != NULL; }

		//! Moves the cursor to the previous entry.
		bool Previous() { return (mNode = (DOTCONFDocumentNode *)(mNode ? mNode->getNextNode() : 0)) != NULL; }

		//! Moves the cursor to the parent entry of the current entry.
		bool Parent() { return (mNode = (DOTCONFDocumentNode *)(mNode ? mNode->getParentNode() : 0)) != NULL; }

		//! Moves the cursor to the first entry in the current entry's section.
		bool Child() { return (mNode = (DOTCONFDocumentNode *)(mNode ? mNode->getChildNode() : mConf->getFirstNode())) != NULL; }

		//! Returns the name of the entry.
		const char *Name() { return mNode ? mNode->getName() : NULL; }

		//! Returns the line number the entry was on in the configuration file.
		int Line() { return mNode ? mNode->getConfigurationLineNumber() : -1; }

		const char *File() { return mNode ? mNode->getConfigurationFileName() : NULL; }

		//! Returns an argument from the currently selected entry.
		const char *operator [] (int index) { return mNode ? mNode->getValue(index) : NULL; }

		//! True if an entry is currently selected.
		operator bool () { return mNode != 0; }

	private:
		DOTCONFDocument *mConf;
		DOTCONFDocumentNode *mNode;
};

struct _ConfigData
{
	struct _ConfigLoginServer
	{
		int ListenPort;
		string RedirectHost;
		int RedirectPort;
	} LoginServer;
	struct _ConfigRedirectServer
	{
		int ListenPort;
		string RedirectHost;
		int RedirectPort;
	} RedirectServer;
	struct
	{
		int ListenPort;
	} WorldServer;
	struct
	{
		struct
		{
			unsigned char DatabaseMysql;
			unsigned char DatabaseSqlite;
			unsigned char Debug;
			unsigned char Network;
			unsigned char Networkbin;
		} LoginServer;
		struct
		{
			unsigned char Debug;
			unsigned char Network;
			unsigned char Networkbin;
		} RedirectServer;
		struct
		{
			unsigned char Chat;
			unsigned char DatabaseMysql;
			unsigned char DatabaseSqlite;
			unsigned char Debug;
			unsigned char GMActions;
			unsigned char Network;
			unsigned char Networkbin;
			unsigned char UnknownPackets;
		} WorldServer;
	} Logging;
	struct _ConfigDatabase
	{
		unsigned char DatabaseModule;
		string InfoString;
		string TablePrefix;
	} Database;
};

class Config : public Singleton<Config>
{
	public:
		Config();
		~Config();

		bool SetSource(const char *file, bool ignorecase = true);

		ConfigCursor Cursor() { return ConfigCursor(mConf); }
		
		const _ConfigData *GetConfigData() { return mConfigData; }

		//! Parse the config file, filling ConfigData with what is found.
		int Parse(char *error, int errorlen);

		enum {LogOn = 0x01, LogLive = 0x02, DbMysql = 0x01, DbSqlite = 0x02};

	private:
		_ConfigData *mConfigData;

		DOTCONFDocument *mConf;
};

#endif

