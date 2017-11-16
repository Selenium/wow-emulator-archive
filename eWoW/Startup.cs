using System;
using System.Threading;
using ErrorLog;				// needed for the log

namespace eWoW
{
	class eWoWClass
	{
		
        public static string version = "0.0.1";
        

        [STAThread]
		static void Main(string[] args)
		{
			
			Log.Active = true; 

            /* 
              
            FormMain formMain = new FormMain();
            // start the main form
            try
            {Application.Run( formMain );}
            catch( Exception exp )
            {Log.LogError(exp);} 
             */

            Commands commands = new Commands();
            
            commands.StartServer();

            #region Console
            if (true) 
            {

                
                while (true)
				{ 
					
					string line = Console.ReadLine();
					if(line == null || line.ToLower() == "quit")
					{
						commands.StopServer();
					}
					if(line.ToLower() == "save")
					{
						commands.StopServerAndSave();
					}

                }
                

				// Const.Log("SYSTEM", "quit...");
            }
            #endregion Console
        }
	}
}