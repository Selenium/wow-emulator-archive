//******************************************************************************
// It is file with all our shared definitions.
// It has not any includes.
// It is pratform independent.
//==============================================================================
#ifndef _OURDEFS_H_
#define _OURDEFS_H_
//==============================================================================
// Compiler check:
#if !defined(_MSC_VER) && !defined(__BORLANDC__) && !defined(__GNUC__)
	#pragma error "FATAL ERROR: Unknown compiler."
#endif
//==============================================================================
// Common sized signed/unsigned ints:
#ifdef _MSC_VER // MS VC++

	typedef __int64				int64;
	typedef unsigned __int64	uint64;
	typedef __int32				int32;
	typedef unsigned __int32	uint32;
	typedef __int16				int16;
	typedef unsigned __int16	uint16;
	typedef __int8				int8;
	typedef unsigned __int8		uint8;

#else

	typedef long long			int64;
	typedef unsigned long long	uint64;
	typedef long				int32;
	typedef unsigned long		uint32;
	typedef short				int16;
	typedef unsigned short		uint16;
	typedef char				int8;
	typedef unsigned char		uint8;

#endif
//------------------------------------------------------------------------------
// Platform specific types
#ifndef _WIN32

	#ifndef DWORD
		typedef unsigned long		DWORD;
	#endif

	#ifndef BOOL
		typedef int					BOOL;
	#endif

	#ifndef TRUE
		#define TRUE				1
	#endif

	#ifndef FALSE
		#define FALSE				0
	#endif

#endif
//------------------------------------------------------------------------------
// Compiler specific strings
#ifdef _MSC_VER // MS VC++

	#define I64FMT "%016I64X"
	#define I64FMTD "%I64u"
	#define SI64FMTD "%I64d"

#else

	#define I64FMT "%016llX"
	#define I64FMTD "%llu"
	#define SI64FMTD "%lld"

#endif
//------------------------------------------------------------------------------
// std:: namespace

#ifdef _STLPORT_VERSION

	#define HM_NAMESPACE std

//#elif defined(_MSC_VER) && (_MSC_VER >= 1300) // msvc71
//
//	#define HM_NAMESPACE stdext

#elif defined(__GNUC__) && (__GNUC__ >= 3)

	#define HM_NAMESPACE __gnu_cxx
	#define HM_NAMESPACE_GLIB _GLIBCXX_STD
	namespace __gnu_cxx {
	    template<> struct hash<unsigned long long> {
	        size_t operator()(const unsigned long long &__x) const { return (size_t)__x; }
	    };
	    template<typename T> struct hash<T *> {
	        size_t operator()(T * const &__x) const { return (size_t)__x; }
	    };
	};

#else

	#define HM_NAMESPACE std

#endif
//==============================================================================
#endif
//******************************************************************************
