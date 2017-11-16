// (c) WoWD Group

#if !defined (CONFIG_H)
#define CONFIG_H

class Config : public Singleton<Config>
{
public:
    Config();
    ~Config();

    bool SetSource(const char *file, bool ignorecase = true);

    bool GetString(const char* name, std::string *value);
    std::string GetStringDefault(const char* name, const char* def);

    bool GetBool(const char* name, bool *value);
    bool GetBoolDefault(const char* name, const bool def = false);

    bool GetInt(const char* name, int *value);
    int GetIntDefault(const char* name, const int def);

private:
    DOTCONFDocument *mConf;
};

#define sConfig Config::getSingleton()

#endif
