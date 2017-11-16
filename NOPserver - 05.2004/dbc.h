#ifndef DBC_H
#define DBC_H


#include "Common.h"

class DbcReader
{
private:
	wxString mFilename;
	wxFileInputStream *mInput;

	// Header info
	wxInt32 RecordCount;
	wxInt32 FieldCount;
	wxInt32 RecordSize;
	wxInt32 StringTableSize;
	wxInt32 StringTableStart;

public:
	DbcReader(wxString Filename);
	~DbcReader();

	wxInt32 GetRecordCount();
	wxInt32 GetFieldCount();

	wxInt32 ReadInt32(wxInt32 Record, wxInt32 Field);
	wxFloat32 ReadFloat32(wxInt32 Record, wxInt32 Field);
	wxString ReadString(wxInt32 Record, wxInt32 Field);

private:
	void Initialise(void);
	wxString GetString(wxInt32 Offset);
	bool SeekField(wxInt32 Record, wxInt32 Field);
};

#endif
