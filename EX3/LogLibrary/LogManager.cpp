// (c) AbyssX Group
#include "LogEnvironment.h"

template <class LogManager> LogManager *Singleton<LogManager>::msSingleton = 0;

LogManager::LogManager(const char *prefix)
{
	mPrefix = prefix;
}

LogManager::~LogManager()
{
	map<string, FILE *>::iterator it;

	for (it = mFiles.begin(); it != mFiles.end(); it++)
		fclose((*it).second);
}

void LogManager::Log(const char *filename, const char *fmt, ...)
{
	va_list args;
	string fname;
	FILE *fp;
	time_t t;
	char tbuf[25];

	va_start(args, fmt);

	fname = mPrefix;
	fname += "_";
	fname += filename;

	fp = mFiles[fname];
	if (!fp)
	{
		ConfigCursor cfg = Config::GetSingleton().Cursor();
		if (cfg.Find("Logging") && cfg.FindIn(mPrefix.c_str()) && cfg.FindIn(filename))
		{
			if (cfg[0] && stricmp(cfg[0], "on") == 0)
				mDisabled[fname] = false;
			else
				mDisabled[fname] = true;
			if (cfg[1] && stricmp(cfg[1], "live") == 0)
				mLive[fname] = true;
			else
				mLive[fname] = false;
		}
		fp = fopen(fname.c_str(), "a");
		mFiles[fname] = fp;
	}
	if (!fp)
	{
		va_end(args);
		return;
	}

	if (mDisabled[fname])
		return;

	t = time(NULL);
	strncpy(tbuf, ctime(&t), 24);
	tbuf[24] = 0x00;

	fprintf(fp, "[%s] ", tbuf);
	vfprintf(fp, fmt, args);
	if (mLive[fname])
		vprintf(fmt, args);
	fflush(fp); // just in case we crash

	va_end(args);
}

void LogManager::LogBinary(const char *filename, Byte data)
{
	LogBinary(filename, &data, 1);
}

void LogManager::LogBinary(const char *filename, Byte *data, Word len)
{
	string fname;
	FILE *fp;

	fname = mPrefix;
	fname += "_";
	fname += filename;

	fp = mFiles[fname];
	if (!fp)
	{
		ConfigCursor cfg = Config::GetSingleton().Cursor();
		if (cfg.Find("Logging") && cfg.FindIn(mPrefix.c_str()) && cfg.FindIn(filename))
		{
			if (cfg[0] && stricmp(cfg[0], "on") == 0)
				mDisabled[fname] = false;
			else
				mDisabled[fname] = true;
			if (cfg[1] && stricmp(cfg[1], "live") == 0)
				mLive[fname] = true;
			else
				mLive[fname] = false;
		}
		fp = fopen(fname.c_str(), "a");
		mFiles[fname] = fp;
	}
	if (!fp || mDisabled[fname])
		return;

	fwrite(data, len, 1, fp);
	fflush(fp); // just in case we crash
}

void LogManager::Enable(const char *log, bool enable)
{
	string name;

	name = mPrefix;
	name += "_";
	name += log;
	mDisabled[name] = !enable;
}

void LogManager::SetLive(const char *log, bool enable)
{
	string name;

	name = mPrefix;
	name += "_";
	name += log;

	mLive[name] = enable;
}
