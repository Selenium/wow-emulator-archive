#ifndef _LONGLONGHASH_H_
#define _LONGLONGHASH_H_

inline wxLongLong CreateID(char objectType,unsigned long Lo)
{
	return wxLongLong( ( ( (wxGetUTCTime() & 0x3FFFFFF) << 6) + (objectType & 0x3F) ), Lo);
}


class wxLongLongHash
{
public:
    wxLongLongHash() { }
    unsigned long operator()( wxLongLong x ) const { return x.GetHi(); }
    wxLongLongHash operator=(const wxLongLongHash) { return *this; }
};

class wxLongLongEqual
{
public:
    wxLongLongEqual() { }
    bool operator()( wxLongLong a, wxLongLong b ) const { return (a.GetHi() == b.GetHi()) &&(a.GetLo() == b.GetLo()); }
    wxLongLongEqual operator=(const wxLongLongEqual) { return *this; }
};

#endif
