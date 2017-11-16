// (c) AbyssX Group
#if !defined(TYPES_H)
#define TYPES_H

//! Typedefs for uniformity.

#ifdef WIN32
typedef unsigned char Byte;           //! Byte (8 bit) type.
typedef unsigned short Word;          //! Word (16 bit) type.
typedef unsigned int DoubleWord;      //! Double Word (32 bit) type.
typedef unsigned __int64 QuadWord;    //! Quad Word (64 bit) type.
typedef float Float;                  //! Float (32 bit) type.
#else
typedef unsigned char Byte;           //! Byte (8 bit) type.
typedef unsigned short Word;          //! Word (16 bit) type.
typedef unsigned int DoubleWord;      //! Double Word (32 bit) type.
typedef unsigned long long QuadWord;  //! Quad Word (64 bit) type.
typedef float Float;                  //! Float (32 bit) type.
#endif


#endif
