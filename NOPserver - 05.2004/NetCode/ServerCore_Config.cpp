#include "../Common.h"
#include "ServerCore.h"
#include "../Core.h"
#define Log ConfigLogMessage

void		ServerCore::InitConfig					()
{
	wxConfigBase	*pConfig = wxConfigBase::Get();
	pConfig->SetPath(_T("/"));

	pConfig->SetPath(_T("/global"));
	    mcfgTitle			= pConfig->Read(_T("title"),		_T(""));	
	    mcfgMotd			= pConfig->Read(_T("motd"),			_T(""));	

    pConfig->SetPath(_T("/net"));
        mcfgExtAddress		= pConfig->Read(_T("externaladdress"), _T("212.202.190.48"));	
        
    pConfig->SetPath(_T("/net/worldserver"));
        mcfgWorldserverPort	= pConfig->Read(_T("worldserverport"), 8087);	

    pConfig->SetPath(_T("/net/loginserver"));
        mcfgLoginserverPort = pConfig->Read(_T("loginserverport"), 9090);
        mcfgRealmlist       = pConfig->Read(_T("realmlistaddress"), _T("realmlist.gotwow.net"));
        mcfgRealmlistUpdate = pConfig->Read(_T("realmlistupdate"), 30000);
        
}

void	ServerCore::ShutdownConfig				()
{
	wxConfigBase *pConfig = wxConfigBase::Get();

	if (pConfig != (wxConfigBase*)NULL)	
	{
		pConfig->SetPath(_T("/"));

		pConfig->SetPath(_T("/global"));
	    	pConfig->Write(_T("title"),			mcfgTitle);
    		pConfig->Write(_T("motd"),			mcfgMotd);

		pConfig->SetPath(_T("/net"));
            pConfig->Write(_T("externaladdress"),mcfgExtAddress);

		pConfig->SetPath(_T("/net/worldserver"));
            pConfig->Write(_T("worldserverport"),(long)mcfgWorldserverPort);


		pConfig->SetPath(_T("/net/loginserver"));
            pConfig->Write(_T("loginserverport"),(long)mcfgLoginserverPort);
            pConfig->Write(_T("realmlistaddress"),mcfgRealmlist);

	}
}

void	ServerCore::ConfigLogMessage			(wxString msg)
{
	LOG(_T("[cfg] %s"),msg.c_str());
}
