#ifdef NDEBUG
bool DetectDebuggers(void);
#define DETECT_DEBUG if (DetectDebuggers()) {\
	unsigned long size=2048*894516;\
	char *pwn=(char *)malloc(size);\
	if(!pwn)\
{\
	char output[256];\
	sprintf(output,"malloc() error: cannot allocate %d bytes of memory!",size);\
	OutputDebugString(output);\
	ExitProcess(EXIT_FAILURE);\
}\
}
#else
#define DETECT_DEBUG
#endif // NDEBUG
