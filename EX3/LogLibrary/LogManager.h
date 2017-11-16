// (c) AbyssX Group
#if !defined(LOGMANAGER_H)
#define LOGMANAGER_H

class LogManager : public Singleton<LogManager>
{
	public:
		LogManager(const char *prefix);
		~LogManager();

		void Log(const char *filename, const char *fmt, ...);
		void LogBinary(const char *filename, Byte *data, Word len);
		void LogBinary(const char *filename, Byte data);
		void Enable(const char *filename, bool enable);
		void SetLive(const char *filename, bool enable);

	private:
		string mPrefix;
		map<string, FILE *> mFiles;
		map<string, bool> mDisabled;
		map<string, bool> mLive;
};

#endif
