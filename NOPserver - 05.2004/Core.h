#ifndef CORE_H
#define CORE_H

#include "wx/fileconf.h"
#include "ThreadComm.h"

#define COMMAND_WINDOW 1337


class WorldThread;
class ThreadComm;
class ServerCore;
class NOPServer :public wxApp
{
//main window
	wxMDIParentFrame *MainFrame;

//used for script console
	 wxTextCtrl *LogBox,*EditBox;
//thread communication object
	 ThreadComm *Comm;
	 WorldThread *mWorldThread;
	 unsigned char mThreadPriority;

	 ServerCore *Server;

public:
	NOPServer() {}
	virtual bool OnInit();
	int OnExit();
    virtual wxLog* CreateLog();
	wxMDIChildFrame *RequestWindow(wxString name);
	
	
	
//script system functions
	void CreateConsole();
	void EnterScriptCommand(wxCommandEvent & event);
	void LogConsoleOutput(wxString &text)
	{
		if(LogBox->GetNumberOfLines() > 63)
			LogBox->Remove(0,LogBox->GetLineLength(0)+2);
		LogBox->AppendText(text);
	}
	void ProcessLogEvent(wxLogEvent &evt);
	void ClearConsole()
	{
		
		LogBox->Clear();
		
	}
	void InitConfig()
	{
		wxFileConfig* cfg = new wxFileConfig(_T(""),_T(""),_T("server.ini"),_T(""),wxCONFIG_USE_RELATIVE_PATH | wxCONFIG_USE_LOCAL_FILE);
		wxConfigBase::Set(cfg);
		mThreadPriority = cfg->Read(_T("thread/priority"),50);
		
	}
	void ShutdownConfig()
	{
		wxConfigBase *cfg =wxConfigBase::Set(NULL);
		cfg->SetPath(_T(""));
		if(cfg) delete cfg;
	}
private:

	DECLARE_EVENT_TABLE()
};

DECLARE_APP(NOPServer)

inline void LOG(const wxChar *str,...)
{
	va_list args;
	va_start( args, str );
	wxString l = wxString::FormatV(str,args)+ "\n";
	wxLogEvent evt(l,LOG_HANDLER);
	wxGetApp().AddPendingEvent(evt);
}

#endif 
