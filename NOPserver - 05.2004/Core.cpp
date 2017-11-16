
#include "Common.h"
#include "ThreadComm.h"
#include "Core.h"
#include "NetCode/ServerCore.h"
#include "WorldThread.h"


IMPLEMENT_APP(NOPServer)


DEFINE_LOCAL_EVENT_TYPE(wxEVT_LOG_MESSAGE)

bool NOPServer::OnInit()
{
	InitConfig();
	MainFrame = new  wxMDIParentFrame;
	MainFrame->Create(NULL, -1, "0x90 Server");
	MainFrame->Show(TRUE);//script console stuff
	CreateConsole();
//logging stuff
	wxLog * log = CreateLog();
	delete wxLog::SetActiveTarget(log);
	wxLogMessage("Logging Started:\n");
	
//Thread communications object;
	Comm = new ThreadComm;

//Server
	Server = new ServerCore(Comm);
//world thread stuff
	mWorldThread = new WorldThread(Comm);
	mWorldThread->Create();
	mWorldThread->SetPriority(mThreadPriority);
	mWorldThread->Run();
	
	return true;
}

wxLog* NOPServer::CreateLog()
{

	wxLogTextCtrl *log = new wxLogTextCtrl(LogBox);
	return log; 
}

wxMDIChildFrame *NOPServer::RequestWindow(wxString name)
{
	return new wxMDIChildFrame(MainFrame,-1 ,name);
}

BEGIN_EVENT_TABLE(NOPServer, wxApp)
	EVT_LOG_MESSAGE(LOG_HANDLER, NOPServer::ProcessLogEvent)
	EVT_TEXT_ENTER(COMMAND_WINDOW, NOPServer::EnterScriptCommand)
END_EVENT_TABLE()


void NOPServer::CreateConsole()
{
	wxWindow *temp = RequestWindow("Script Console");
	wxPanel *panel = new wxPanel(temp,-1);
	wxBoxSizer *sizer = new wxBoxSizer(wxVERTICAL);
	LogBox = new wxTextCtrl( panel, -1, "Console Output:\n", wxDefaultPosition, wxSize(400,410), wxTE_MULTILINE|wxTE_READONLY	);
	EditBox = new wxTextCtrl( panel, COMMAND_WINDOW, "", wxDefaultPosition, wxSize(400,20), wxTE_PROCESS_ENTER);
	sizer->Add(LogBox,1,wxEXPAND |wxALL,0 );        
    sizer->Add(EditBox,0,wxEXPAND |wxALL,0 );       
    panel->SetSizer(sizer);
    sizer->SetSizeHints(panel);
	temp->Show(TRUE);
}

void NOPServer::EnterScriptCommand(wxCommandEvent &event )
{
	wxString *command =new wxString(event.GetString());
	Comm->PostCommand(command);
	EditBox->Clear();
}

int NOPServer::OnExit()
{
	ShutdownConfig();
	
	mWorldThread->Delete();	
	delete Server;
	delete Comm; // will ensure the thread finishes first
	return 0;
}
void NOPServer::ProcessLogEvent(wxLogEvent &evt)
{
	LogConsoleOutput(evt.GetMessage());
}
