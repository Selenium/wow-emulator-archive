// For debugging only


#include "dbc.h"

/*
	Notes on wx:
	wfstream.h - file stream stuff
		wxFileInputStream inherits from wxInputStream : wxStreamBase (stream.h)
	string.h - string stuff
*/

DbcReader::DbcReader(wxString Filename)
{
	mInput = NULL;
	mFilename = Filename;
	Initialise();
}

DbcReader::~DbcReader()
{
	if (mInput) delete mInput;
}

wxInt32 DbcReader::GetRecordCount()
{
	return RecordCount;
}

wxInt32 DbcReader::GetFieldCount()
{
	return FieldCount;
}

wxInt32 DbcReader::ReadInt32(wxInt32 Record, wxInt32 Field)
{
	wxInt32 Result;

	SeekField(Record, Field);
	mInput->Read(&Result, sizeof(wxInt32));
	return Result;
}

wxFloat32 DbcReader::ReadFloat32(wxInt32 Record, wxInt32 Field)
{
	wxFloat32 Result;

	SeekField(Record, Field);

	mInput->Read(&Result, sizeof(wxFloat32));
	return Result;
}

wxString DbcReader::ReadString(wxInt32 Record, wxInt32 Field)
{
	wxInt32 Offset;

	Offset = ReadInt32(Record, Field);
	return GetString(Offset);
}

void DbcReader::Initialise(void)
{
	mInput = new wxFileInputStream(mFilename);
	mInput->SeekI(4); // Skip the magic number at the start
	mInput->Read(&RecordCount, sizeof(wxInt32));
	mInput->Read(&FieldCount, sizeof(wxInt32));
	mInput->Read(&RecordSize, sizeof(wxInt32));
	mInput->Read(&StringTableSize, sizeof(wxInt32));

	StringTableStart = 0x14 + (RecordCount * RecordSize);
}

wxString DbcReader::GetString(wxInt32 Offset)
{
	wxString Data;

	if (Offset > StringTableSize) return Data;
	mInput->SeekI(StringTableStart + Offset);
	

	while(!mInput->Eof())
	{
		char c = mInput->GetC();
		if (c == 0) break;
		Data += c;
	}
	return Data;
}

bool DbcReader::SeekField(wxInt32 Record, wxInt32 Field)
{
	wxInt32 Offset;

	if (Record > RecordCount || Field > FieldCount) return false;
	Offset = 0x14 + (RecordSize * Record) + ((Field) * 4);
	mInput->SeekI(Offset);
	return true;
}
