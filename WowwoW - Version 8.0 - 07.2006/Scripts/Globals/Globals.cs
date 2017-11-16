using System;
using System.IO;
using System.Collections;
using Server.Items;
using HelperTools;
using System.Reflection;
using Server.Creatures;

namespace Server
{
	public class Globals : IInitialize
	{

		public Globals() : base()
		{
			XpTable.xpMultiplicator = 1; //XP Rate
			World.DropMultiplier = 1f;// Drop multiplier
			World.DropGoldMultiplier = 1;//	Drop gold amount multiplier
			
			//	Server statics
			World.ServerIP = "127.0.0.1";
			World.AllowHttpFrom = "0.0.0.0";//	Allow connections to the http server from everywhere
			// World.AllowHttpFrom = "127.0.0.1"; will only allow connection from localhost

			World.ServerName = "Dr Nexus test server";
			World.ServerPort = 8085;
			World.HttpServerPort = 8080;
			
		

			//	World time
			World.onGetActualTime = new World.OnGetActualTime( ActualTime );
			
			//	World saving frequency
			World.WorldSavingTimer = 180;//	180 minutes timer

			//	After death mob decay
			World.DecayTime = 2 * 60 * 1000; //	2 minutes

			//	Http handler
			World.onHttpDataReceived = new World.OnHttpDataReceived( YourHttpHandler );

			//	Called when the save process is triggered
			World.onSave += new World.OnSaveDelegate( OnSave );

			//	Fishing zones definition
			//World.FishZones.Add( -627.1989f, -4246.86f, 58.35506f, 100f, GameObjectDescription.all[ 1 ] );
		
			// ShaiDeath's Initialization
			Unit();	


		}

		public void ActualTime( ref int year, ref int month, ref int day, ref int dayOfTheWeek, ref int hour, ref int minute )
		{
			DateTime now = DateTime.Now;
			year = now.Year-2000; 
			month = now.Month-1;
			day = now.Day - 1;
			dayOfTheWeek = (int)now.DayOfWeek;
			hour = now.Hour;
			minute = now.Minute;
			//	Force to midday for testing purpose
			hour = 12;
			minute = 0;
		}

		public void OnSave()
		{
		}

public bool YourHttpHandler( HttpConnection ch, byte []data, int length ) 
      { 
         //   You will receive here all the packet from remote navigators in the "data" buffer 
         //   You can send packet back by using the ch handler : ch.Send( backDataBuffer ) 
         string request = ""; 
         string[] textArray3; 
         object[] objArray1 = new object[4] { "", '\r', "", '\n' } ; 
         string text1 = string.Concat(objArray1); 
         for (int num1 = 0; num1 < length; num1++) 
         { 
                         request = request + "" + ((char) data[num1]); 
         } 
         char[] chArray1 = new char[1] { ' ' } ; 
         string[] textArray1 = request.Split(chArray1); 
         //If the requested page is stat.xml take over. 
         if (textArray1.Length > 1 && textArray1[1] == "/stat.xml") 
         { 
                         Console.WriteLine("OK Showing stats."); 
                         string responce = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<?xml-stylesheet type=\"text/xsl\" href=\"http://wow.bn.by/wow/stat.xsl\"?>\n"; 
                         responce += "<stats>\n<players>\n\n"; 
                         Console.WriteLine("OK going through chars."); 
                         foreach(Character o in World.allConnectedChars) 
                         { 
                           // We need more stats here. 
                           //responce += "<player>\n <name>" + o.Name + "</name>\n <level>" + o.Level + "</level>\n</player>\n"; 
              responce += "<player>\n <name>" + o.Name + "</name>\n <level>" + o.Level + "</level>\n<race>" + o.Race + "</race>\n<class>" + o.Classe + "</class></player>\n";  
                         } 
                         responce += "</players>\n</stats>"; 
                         Console.WriteLine("OK gone through chars."); 
                         textArray3 = new string[0x13] { 
                                          "HTTP/1.1 200 OK", text1, "Date: ", DateTime.Now.ToString("r"), text1, "Server: Dr Nexus 0.1a", text1, "X-Powered-By: Dr Nexus", text1, "Cache-Control: private", text1, "Connection: close", text1, "Content-Length: ", responce.Length.ToString(), text1, 
                                          "Content-Type: text/html", text1, text1 
                         } ; 
                         string text6 = string.Concat(textArray3); 
                         Console.WriteLine("OK sending text."); 
                         ch.Send( text6 ); 
                         ch.Send( responce ); 
                         return false; 
          } 
     if (textArray1.Length > 1 && textArray1[1] == "/stat.xsl" && File.Exists("./http/stat.xsl")) 
          { 
           // Specify file, instructions, and privelegdes 
           FileStream file = new FileStream("./http/stat.xsl", FileMode.Open, FileAccess.Read); 
           // Create a new stream to read from a file 
           StreamReader sr = new StreamReader(file); 
           // Read contents of file into a string 
           string responce = sr.ReadToEnd(); 
           // Close StreamReader 
           sr.Close(); 
           // Close file 
           file.Close(); 
           textArray3 = new string[0x13] { 
                                          "HTTP/1.1 200 OK", text1, "Date: ", DateTime.Now.ToString("r"), text1, "Server: Dr Nexus 0.1a", text1, "X-Powered-By: Dr Nexus", text1, "Cache-Control: private", text1, "Connection: close", text1, "Content-Length: ", responce.Length.ToString(), text1, 
                                          "Content-Type: text/html", text1, text1 
           } ; 
           string text6 = string.Concat(textArray3); 
           Console.WriteLine("OK sending text."); 
           ch.Send( text6 ); 
           ch.Send( responce ); 
           return false; 
          } 
                        return true;//   To let the default http process runing or return false if you manage all. 
      } 

		// ShaiDeath's Initialization
		private static void Unit() 
		{ 
			try
			{
				AssemblyListEnumerator ale = Utility.externAsm.GetEnumerator();
				while ( ale.MoveNext() )
				{			
					if ( ale.Key == "Creatures" || ale.Key == "Items" )
						continue;
					Type[] types = ale.Value.GetTypes(); 
					for (int i=0; i<types.Length;i++) 
					{ 
						if ( types[ i ].GetInterface("IInitialize",true) != null )
						{ 
							System.Reflection.MethodInfo info = ((Type)types[i]).GetMethod("Initialize", BindingFlags.Static | BindingFlags.Public); 
							if (info!=null) 
							{ 
								info.Invoke( null, null ); 
								//	Console.WriteLine("Found object {0}", info.Name); 
							} 
						} 
					}
				}
			}
			catch( Exception e )
			{
				Console.WriteLine("Error in Globals.Unit() !" );
				Console.WriteLine( e.Message );
				Console.WriteLine( e.Source );
				Console.WriteLine( e.StackTrace );
			}
		} 
	}
}