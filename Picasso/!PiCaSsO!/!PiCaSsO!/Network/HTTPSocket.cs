/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

namespace HTTPServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;


    class MyWebServer
    {

        private TcpListener myListener;

        //The constructor which make the TcpListener start listening on the
        //given port. It also calls a Thread on the method StartListen(). 
        public MyWebServer()
        {
            try
            {
                //start listing on the given port
                myListener = new TcpListener(Server.World.HTTPPort);
                myListener.Start();
                Server.ColoredConsole.ConsoleWriteWhiteWithOne("HTTPServer listening on port {0}", Server.World.HTTPPort);
                //start the thread which calls the method 'StartListen'
                Thread th = new Thread(new ThreadStart(StartListen));
                th.Start();

            }
            catch (Exception e)
            {
                Server.Log.WriteLogWithout("An exception occurred while Listening, please repot this to pAbLoPiCaSsO :" + e.ToString());
            }
        }


        /// <summary>
        /// Returns The Default File Name
        /// Input : WebServerRoot Folder
        /// Output: Default File Name
        /// </summary>
        /// <param name="sMyWebServerRoot"></param>
        /// <returns></returns>
        public string GetTheDefaultFileName(string sLocalDirectory)
        {
            StreamReader sr;
            String sLine = "";

            try
            {
                //Open the default.dat to find out the list
                // of default file
                sr = new StreamReader("Configs\\Default.Dat");

                while ((sLine = sr.ReadLine()) != null)
                {
                    //Look for the default file in the web server root folder
                    if (File.Exists(sLocalDirectory + sLine) == true)
                        break;
                }
            }
            catch (Exception e)
            {
                Server.Log.WriteLogWithout("An exception occurred, please report this to pAbLoPiCaSsO : " + e.ToString());
            }
            if (File.Exists(sLocalDirectory + sLine) == true)
                return sLine;
            else
                return "";
        }



        /// <summary>
        /// This function takes FileName as Input and returns the mime type..
        /// </summary>
        /// <param name="sRequestedFile">To indentify the Mime Type</param>
        /// <returns>Mime Type</returns>
        public string GetMimeType(string sRequestedFile)
        {


            StreamReader sr;
            String sLine = "";
            String sMimeType = "";
            String sFileExt = "";
            String sMimeExt = "";

            // Convert to lowercase
            sRequestedFile = sRequestedFile.ToLower();

            int iStartPos = sRequestedFile.IndexOf(".");

            sFileExt = sRequestedFile.Substring(iStartPos);

            try
            {
                //Open the Vdirs.dat to find out the list virtual directories
                sr = new StreamReader("Configs\\Mime.Dat");

                while ((sLine = sr.ReadLine()) != null)
                {

                    sLine.Trim();

                    if (sLine.Length > 0)
                    {
                        //find the separator
                        iStartPos = sLine.IndexOf(";");

                        // Convert to lower case
                        sLine = sLine.ToLower();

                        sMimeExt = sLine.Substring(0, iStartPos);
                        sMimeType = sLine.Substring(iStartPos + 1);

                        if (sMimeExt == sFileExt)
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Server.Log.WriteLogWithout("An exception occurred, please report this to pAbLoPiCaSsO : " + e.ToString());
            }

            if (sMimeExt == sFileExt)
                return sMimeType;
            else
                return "";
        }



        /// <summary>
        /// Returns the Physical Path
        /// </summary>
        /// <param name="sMyWebServerRoot">Web Server Root Directory</param>
        /// <param name="sDirName">Virtual Directory </param>
        /// <returns>Physical local Path</returns>
        public string GetLocalPath(string sMyWebServerRoot, string sDirName)
        {

            StreamReader sr;
            String sLine = "";
            String sVirtualDir = "";
            String sRealDir = "";
            int iStartPos = 0;


            //Remove extra spaces
            sDirName.Trim();



            // Convert to lowercase
            sMyWebServerRoot = sMyWebServerRoot.ToLower();

            // Convert to lowercase
            sDirName = sDirName.ToLower();

            //Remove the slash
            //sDirName = sDirName.Substring(1, sDirName.Length - 2);


            try
            {
                //Open the Vdirs.dat to find out the list virtual directories
                sr = new StreamReader("Configs\\VDirs.Dat");

                while ((sLine = sr.ReadLine()) != null)
                {
                    //Remove extra Spaces
                    sLine.Trim();

                    if (sLine.Length > 0)
                    {
                        //find the separator
                        iStartPos = sLine.IndexOf(";");

                        // Convert to lowercase
                        sLine = sLine.ToLower();

                        sVirtualDir = sLine.Substring(0, iStartPos);
                        sRealDir = sLine.Substring(iStartPos + 1);

                        if (sVirtualDir == sDirName)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Server.Log.WriteLogWithout("An exception occurred, please report this to pAbLoPiCaSsO : " + e.ToString());
            }


            Server.Log.WriteLogWithout("Virtual Dir : " + sVirtualDir);
            Server.Log.WriteLogWithout("Directory   : " + sDirName);
            Server.Log.WriteLogWithout("Physical Dir: " + sRealDir);
            if (sVirtualDir == sDirName)
                return sRealDir;
            else
                return "";
        }



        /// <summary>
        /// This function send the Header Information to the client (Browser)
        /// </summary>
        /// <param name="sHttpVersion">HTTP Version</param>
        /// <param name="sMIMEHeader">Mime Type</param>
        /// <param name="iTotBytes">Total Bytes to be sent in the body</param>
        /// <param name="mySocket">Socket reference</param>
        /// <returns></returns>
        public void SendHeader(string sHttpVersion, string sMIMEHeader, int iTotBytes, string sStatusCode, ref Socket mySocket)
        {

            String sBuffer = "";

            // if Mime type is not provided set default to text/html
            if (sMIMEHeader.Length == 0)
            {
                sMIMEHeader = "text/html";  // Default Mime Type is text/html
            }

            sBuffer += sHttpVersion + sStatusCode + "\r\n";
            sBuffer += "Server: cx1193719-b\r\n";
            sBuffer += "Content-Type: " + sMIMEHeader + "\r\n";
            sBuffer += "Accept-Ranges: bytes\r\n";
            sBuffer += "Content-Length: " + iTotBytes + "\r\n\r\n";

            Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);

            SendToBrowser(bSendData, ref mySocket);

            Server.Log.WriteLogWithout("Total Bytes : " + iTotBytes.ToString());

        }



        /// <summary>
        /// Overloaded Function, takes string, convert to bytes and calls 
        /// overloaded sendToBrowserFunction.
        /// </summary>
        /// <param name="sData">The data to be sent to the browser(client)</param>
        /// <param name="mySocket">Socket reference</param>
        public void SendToBrowser(String sData, ref Socket mySocket)
        {
            SendToBrowser(Encoding.ASCII.GetBytes(sData), ref mySocket);
        }



        /// <summary>
        /// Sends data to the browser (client)
        /// </summary>
        /// <param name="bSendData">Byte Array</param>
        /// <param name="mySocket">Socket reference</param>
        public void SendToBrowser(Byte[] bSendData, ref Socket mySocket)
        {
            int numBytes = 0;

            try
            {
                if (mySocket.Connected)
                {
                    if ((numBytes = mySocket.Send(bSendData, bSendData.Length, 0)) == -1)
                        Server.Log.WriteLogWithout("Socket Error cannot Send Packet");
                    else
                    {
                        Server.Log.WriteLogWithOne("Number of bytes sent {0}", numBytes);
                    }
                }
                else
                    Server.Log.WriteLogWithout("Connection Dropped....");
            }
            catch (Exception e)
            {
                Server.Log.WriteLogWithOne("Error occurred : {0} ", e);

            }
        }


        // Application Starts Here..
        public static void Main2()
        {
            MyWebServer MWS = new MyWebServer();
        }



        //This method Accepts new connection and
        //First it receives the welcome massage from the client,
        //Then it sends the Current date time to the Client.
        public void StartListen()
        {

            int iStartPos = 0;
            String sRequest;
            String sDirName;
            String sRequestedFile;
            String sErrorMessage;
            String sLocalDir;
            String sMyWebServerRoot = "http\\";
            String sPhysicalFilePath = "";
            String sFormattedMessage = "";
            String sResponse = "";



            while (true)
            {

                //Accept a new connection
                Socket mySocket = myListener.AcceptSocket();

                Server.Log.WriteLogWithout("Socket Type " + mySocket.SocketType);
                if (mySocket.Connected)
                {
                    Server.Log.WriteLogWithout("Client Connected!");
                    Server.Log.WriteLogWithout("==================");
                    Server.Log.WriteLogWithOne("Client IP {0}",
                        mySocket.RemoteEndPoint);



                    //make a byte array and receive data from the client 
                    Byte[] bReceive = new Byte[10000];
                    int i = mySocket.Receive(bReceive, bReceive.Length, 0);



                    //Convert Byte to String
                    string sBuffer = Encoding.ASCII.GetString(bReceive);
                    string sRequest2;
                    string account;
                    string password;
                    string sHttpVersion;
                    //At present we will only deal with GET type
                    if (sBuffer.Substring(0, 4) == "POST")
                    {
                        if (sBuffer.Substring(sBuffer.IndexOf("User-Agent"), sBuffer.IndexOf("User-Agent") + 100).Contains("MSIE 6.0") == false)
                        {
                            sHttpVersion = sBuffer.Substring(iStartPos, 8);
                            sDirName = "/";
                            sRequestedFile = "BrowserError.htm";
                        }
                        else
                        {
                            //Server.Log.WriteLogWithout(sBuffer);
                            Server.Log.WriteLogWithout("HTTPServer: method = POST");
                            sHttpVersion = sBuffer.Substring(iStartPos, 8);
                            sRequest = sBuffer.Substring(0, 1000);
                            sRequest2 = sBuffer.Substring(0, 50);
                            sRequest.Replace("\\", "/");
                            sRequest2.Replace("\\", "/");
                            if ((sRequest.IndexOf(".") < 1) && (!sRequest.EndsWith("/")))
                            {
                                sRequest = sRequest + "/";
                            }
                            if ((sRequest2.IndexOf(".") < 1) && (!sRequest2.EndsWith("/")))
                            {
                                sRequest2 = sRequest2 + "/";
                            }
                            iStartPos = sRequest.LastIndexOf("/") + 1;
                            sRequestedFile = sRequest.Substring(iStartPos);
                            //sRequest = sRequest.Substring(400, 250);
                            sRequest = sRequest.Replace('+', ' ');
                            //sRequest = sRequest.Replace('&', ' ');
                            sRequest = sRequest.Substring(sRequest.IndexOf("=") + 1);
                            account = sRequest.Substring(0, sRequest.IndexOf("&"));
                            account = account.Replace(" ", null);
                            sRequest = sRequest.Substring(sRequest.IndexOf("&") + 10);
                            password = sRequest.Substring(0, sRequest.IndexOf("&"));
                            password = password.Replace(" ", null);
                            if (Server.World.FindUserByUsername(account.ToUpper()) == -1)
                            {
                                Database.Data.accountwriter.WriteLine(account.ToUpper());
                                Database.Data.accountwriter.WriteLine(password.ToUpper());
                                Server.ColoredConsole.ConsoleWriteBlueWithOutAndWithDate("Created new account. Username: " + account + " Password: ****");
                                sDirName = "/";
                                sRequestedFile = "accountcreated.htm";
                                Database.Data.ReloadAccounts();
                            }
                            else
                            {
                                Server.ColoredConsole.ConsoleWriteErrorWithOut("Account already exists! Username: " + account + " Password: ****");
                                sDirName = "/";
                                sRequestedFile = "accountexists.htm";
                            }
                        }
                        
                    }
                    else
                    {
                        // Look for HTTP request
                        iStartPos = sBuffer.IndexOf("HTTP", 1);


                        // Get the HTTP text and version e.g. it will return "HTTP/1.1"
                        sHttpVersion = sBuffer.Substring(iStartPos, 8);


                        // Extract the Requested Type and Requested file/directory
                        sRequest = sBuffer.Substring(0, iStartPos - 1);


                        //Replace backslash with Forward Slash, if Any
                        sRequest.Replace("\\", "/");


                        //If file name is not supplied add forward slash to indicate 
                        //that it is a directory and then we will look for the 
                        //default file name..
                        if ((sRequest.IndexOf(".") < 1) && (!sRequest.EndsWith("/")))
                        {
                            sRequest = sRequest + "/";
                        }


                        //Extract the requested file name
                        iStartPos = sRequest.LastIndexOf("/") + 1;
                        sRequestedFile = sRequest.Substring(iStartPos);


                        //Extract The directory Name
                        sDirName = sRequest.Substring(sRequest.IndexOf("/"), sRequest.LastIndexOf("/") - 3);
                    }



                    /////////////////////////////////////////////////////////////////////
                    // Identify the Physical Directory
                    /////////////////////////////////////////////////////////////////////
                    if (sDirName == "/")
                        sLocalDir = sMyWebServerRoot;
                    else
                    {
                        //Get the Virtual Directory
                        sLocalDir = GetLocalPath(sMyWebServerRoot, sDirName);
                    }


                    Server.Log.WriteLogWithout("Directory Requested : " + sLocalDir);

                    //If the physical directory does not exists then
                    // dispaly the error message
                    if (sLocalDir.Length == 0)
                    {
                        sErrorMessage = "<H2>Error! Requested Directory does not exists</H2><Br>";
                        //sErrorMessage = sErrorMessage + "Please check data\\Vdirs.Dat";

                        //Format The Message
                        SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref mySocket);

                        //Send to the browser
                        SendToBrowser(sErrorMessage, ref mySocket);

                        mySocket.Close();

                        continue;
                    }

                   


                    /////////////////////////////////////////////////////////////////////
                    // Identify the File Name
                    /////////////////////////////////////////////////////////////////////

                    //If The file name is not supplied then look in the default file list
                    if (sRequestedFile.Length == 0)
                    {
                        // Get the default filename
                        sRequestedFile = GetTheDefaultFileName(sLocalDir);

                        if (sRequestedFile == "")
                        {
                            sErrorMessage = "<H2>Error! No Default File Name Specified</H2>";
                            SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref mySocket);
                            SendToBrowser(sErrorMessage, ref mySocket);

                            mySocket.Close();

                            return;

                        }
                    }




                    /////////////////////////////////////////////////////////////////////
                    // Get TheMime Type
                    /////////////////////////////////////////////////////////////////////

                    String sMimeType = GetMimeType(sRequestedFile);



                    //Build the physical path
                    sPhysicalFilePath = sLocalDir + sRequestedFile;
                    Server.Log.WriteLogWithout("File Requested : " + sPhysicalFilePath);


                    if (File.Exists(sPhysicalFilePath) == false)
                    {

                        sErrorMessage = "<H2>Error 404! This file does not exist in the !PiCaSsO! emu!</H2>";
                        SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found --- !PiCaSsO! Emu", ref mySocket);
                        SendToBrowser(sErrorMessage, ref mySocket);

                        Server.Log.WriteLogWithout(sFormattedMessage);
                    }

                    else
                    {
                        int iTotBytes = 0;

                        sResponse = "";

                        FileStream fs = new FileStream(sPhysicalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        // Create a reader that can read bytes from the FileStream.


                        BinaryReader reader = new BinaryReader(fs);
                        byte[] bytes = new byte[fs.Length];
                        int read;
                        while ((read = reader.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Read from the file and write the data to the network
                            sResponse = sResponse + Encoding.ASCII.GetString(bytes, 0, read);

                            iTotBytes = iTotBytes + read;

                        }
                        reader.Close();
                        fs.Close();

                        SendHeader(sHttpVersion, sMimeType, iTotBytes, " 200 OK", ref mySocket);
                        SendToBrowser(bytes, ref mySocket);
                        //mySocket.Send(bytes, bytes.Length,0);

                    }
                    mySocket.Close();
                }
            }
        }
    }
}
