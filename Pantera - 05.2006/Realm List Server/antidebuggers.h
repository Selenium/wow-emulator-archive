#ifndef ANTIDEBUGGERS_H
#define ANTIDEBUGGERS_H

#ifdef NDEBUG
bool DetectDebuggers(void);
#define DETECT_DEBUG if (DetectDebuggers()) {\
		OutputDebugString("malloc(): could not allocate 2147483647 bytes of memory!");\
		ExitProcess(EXIT_FAILURE);\
	}
#else
#define DETECT_DEBUG
#endif

#endif // ANTIDEBUGGERS_H
