#ifndef __COMMON_H
#define __COMMON_H


// For compilers that support precompilation, includes "wx/wx.h".
#include <wx/wxprec.h>

#ifdef __BORLANDC__
#  pragma hdrstop
#endif

// for all others, include the necessary headers
#ifndef WX_PRECOMP
#  include <wx/wx.h>
#endif

#include <wx/socket.h>
#include <wx/config.h>
#include <wx/wfstream.h>
#include <wx/hashmap.h>
// --------------------------------------------------------------------------
// resources
// --------------------------------------------------------------------------

// the application icon
#if defined(__WXGTK__) || defined(__WXX11__) || defined(__WXMOTIF__) || defined(__WXMAC__)
#  include "mondrian.xpm"
#endif

// for better memory-leak detection (http://www.litwindow.com/Knowhow/wxHowto/wxhowto.html)
#ifdef _DEBUG
	#include <crtdbg.h>
	#define DEBUG_NEW new(_NORMAL_BLOCK ,__FILE__, __LINE__)
	#define new DEBUG_NEW
#else
	#define DEBUG_NEW new
#endif

//stuff from ../common/common.h goes here
const unsigned int		InvalidMemoryMarker = 0xdeaddead;

/* Class declarations for Handlers/ */
class UserManager;
class Client; 

class ObjectManager;
class ObjPosition;
class Object;
class Unit;
class Character;

/* For wxLongLong hashmaps (see below) */
#include "LongLongHash.h"
/* For Linked Lists (our own, our precioussss) --daxxar */
#include "LinkedList.h"
/* Hashmap declarations for Handlers/ */
WX_DECLARE_STRING_HASH_MAP(wxLongLong, ObjReverseMap);
WX_DECLARE_HASH_MAP(wxLongLong, Character *, wxLongLongHash, wxLongLongEqual, CharHashMap);
WX_DECLARE_HASH_MAP(wxLongLong, Object *, wxLongLongHash, wxLongLongEqual, ObjHashMap);
WX_DECLARE_HASH_MAP(wxUint32, Client *, wxIntegerHash, wxIntegerEqual, ClientHashMap);
typedef LinkedList<wxLongLong> GUIDList;
typedef LinkedNode<wxLongLong> GUIDNode;
typedef LinkedList<Character> CharList;
typedef LinkedNode<Character> CharNode;

#endif
