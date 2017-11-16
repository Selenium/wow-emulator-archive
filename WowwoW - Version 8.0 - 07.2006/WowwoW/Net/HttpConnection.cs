using System;
using System.IO;
using Server;
using HelperTools;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;


namespace Server
{
	/// <summary>
	/// Summary description for HttpConnection.
	/// </summary>
	public class HttpConnection : SockClient
	{
		
		int state = 0;
			public HttpConnection( Socket sock, RemoveClientDelegate rcd ) : base( sock, rcd )
		{
		}

		public override byte [] ProcessDataReceived( byte []data, int length )
		{
			string crlf = "" + (char)0xd + "" + (char)0xa;
			if ( World.AllowHttpFrom != "0.0.0.0" && World.AllowHttpFrom != IP.ToString() )
			{
				Send403();
				return null;
			}			
			if ( !World.onHttpDataReceived( this, data, length ) )
				return null;
			try
			{
				string str = "";
				for(int t = 0;t < length;t++ )
				{
					str += "" + (char)data[ t ];
				}
				
				string []strs = str.Split( new char[] { ' ' } );
				if ( strs[ 0 ] == "POST" )
				{
					if ( strs[ 1 ] == "/account.htm" )
					{
						int iuser = str.IndexOf( "username=" );
						int ipass = str.IndexOf( "password=" );
						string username = str.Substring( iuser );
						string []spls = username.Split( new char[]{ '&' } );
						username = spls[ 0 ].Substring( 9 );
						string password = spls[ 1 ].Substring( 9 );
						//Console.WriteLine("Username : {0}, Password : {1}", username, password );
						if ( username.Length > 12 || password.Length > 12 )
							return null;
						Account newAccount = new Account( username, password, AccessLevels.PlayerLevel );
						Account myAccount = World.allAccounts.FindByUserName( username.ToUpper() );
						if ( myAccount == null )
						{
							World.allAccounts.Add( newAccount );
							TextReader tx = new StreamReader( "./http/accountcreated.htm" );
							string part2 = tx.ReadToEnd();
							tx.Close();
							string part1 = "HTTP/1.1 200 OK" + crlf +
								"Date: " + DateTime.Now.ToString( "r" ) + crlf +
								"Server: Dr Nexus 0.1a" + crlf +
								"X-Powered-By: Dr Nexus" + crlf +
								"Cache-Control: private" + crlf +
								//	"Keep-Alive: timeout=15, max=98" +  crlf +
								"Connection: close" + crlf + //Keep-Alive" + crlf +
								//	"Transfer-Encoding: chunked" + crlf +
								"Content-Length: " + ( part2.Length ).ToString() + crlf +
								"Content-Type: text/html" + crlf + crlf;

							string pageHtml = part1 + part2;
							Send( pageHtml );
							//Send( part2 );
							return null;
						}
						else
						{
							World.allAccounts.Add( newAccount );
							TextReader tx = new StreamReader( "./http/accounterror.htm" );
							string part2 = tx.ReadToEnd();
							tx.Close();
							string part1 = "HTTP/1.1 200 OK" + crlf +
								"Date: " + DateTime.Now.ToString( "r" ) + crlf +
								"Server: Dr Nexus 0.1a" + crlf +
								"X-Powered-By: Dr Nexus" + crlf +
								"Cache-Control: private" + crlf +
								//	"Keep-Alive: timeout=15, max=98" +  crlf +
								"Connection: close" + crlf + //Keep-Alive" + crlf +
								//	"Transfer-Encoding: chunked" + crlf +
								"Content-Length: " + ( part2.Length ).ToString() + crlf +
								"Content-Type: text/html" + crlf + crlf;

							string pageHtml = part1 + part2;
							Send( pageHtml );
							//Send( part2 );
							return null;
						}
					}
				}
				if ( strs[ 0 ] == "GET" )
				{
					if ( strs[ 1 ] == "/status.htm" )
					{
						TextReader tx = new StreamReader( "./http/status.htm" );
						string part2 = tx.ReadToEnd();
						tx.Close();


						string part3 = "";
						string fonct = "";
						for(int t = 0;t < part2.Length;t++ )
						{
							if ( part2[ t ] == '<' && state == 0 )
								state = 1;
							else
								if ( part2[ t ] == '?' && state == 1 )
								state = 2;
							else
								if ( part2[ t ] == '?' && state == 2 )
								state = 3;
							else
								if ( part2[ t ] == '>' && state == 3 )
							{
								state = 0;
								fonct = "using System;using System.Collections;using Server.Items;using HelperTools; namespace Server { " + fonct + " }";
								CSharpCodeProvider codeProvider = new CSharpCodeProvider();
								ICodeCompiler compiler = codeProvider.CreateCompiler();
								CompilerParameters parameters = new CompilerParameters();

								parameters.GenerateExecutable = false;
								parameters.GenerateInMemory = true;

								parameters.MainClass = "";
								foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) 
								{
									parameters.ReferencedAssemblies.Add(asm.Location);
								}
			
								parameters.IncludeDebugInformation = false;
								//parameters.OutputAssembly = "./res.dll";

								CompilerResults results = compiler.CompileAssemblyFromSource( parameters, fonct );
								
								if (results.Errors.Count > 0) 
								{
									string errors = "Compilation failed:\n";
									foreach (CompilerError err in results.Errors) 
									{
										errors += err.ToString() + "\n";
									}
									part3 += "<p>" + errors + "</p>";									
								}
								else	
								{									
									Assembly asm = results.CompiledAssembly;
									ConstructorInfo ct = Utility.FindConstructor( "HttpHandler", asm );
									BaseHttpHandler h = (BaseHttpHandler)ct.Invoke( null );
									part3 += h.Get();
								}		
							}
							else
								if ( state == 2 )
							{
								fonct += part2[ t ];
							}
							else
							{
								if ( state == 1 )
									part3 += "<";
								state = 0;										
								part3 += part2[ t ];
							}
						}
						 
						string part1 = "HTTP/1.1 200 OK" + crlf +
							"Date: " + DateTime.Now.ToString( "r" ) + crlf +
							"Server: Dr Nexus 0.1a" + crlf +
							"X-Powered-By: Dr Nexus" + crlf +
							"Cache-Control: private" + crlf +
							"Connection: close" + crlf + 
							"Content-Length: " + ( part3.Length ).ToString() + crlf +
							"Content-Type: text/html" + crlf + crlf;
						Send( part1 + part3 );
						//Send( part3 );
						return null;
					}
					else
						if ( strs[ 1 ] == "/account.htm" )
					{
						TextReader tx = new StreamReader( "./http/account.htm" );
						string part2 = tx.ReadToEnd();
						tx.Close();
						string part1 = "HTTP/1.1 200 OK" + crlf +
							"Date: " + DateTime.Now.ToString( "r" ) + crlf +
							"Server: Dr Nexus 0.1a" + crlf +
							"X-Powered-By: Dr Nexus" + crlf +
							"Cache-Control: private" + crlf +
							//	"Keep-Alive: timeout=15, max=98" +  crlf +
							"Connection: close" + crlf + //Keep-Alive" + crlf +
							//	"Transfer-Encoding: chunked" + crlf +
							"Content-Length: " + ( part2.Length ).ToString() + crlf +
							"Content-Type: text/html" + crlf + crlf;

						//	string pageHtml = part1 + part2;
						Send( part1 + part2 );
						//Send( part2 );
						return null;
					}
					Send404();
				}
			}
			catch( Exception )
			{
			}
			Send403();
			return null;
		}
		
		public void SendError( int num, string title, string msg )
		{
			string crlf = "" + (char)0xd + "" + (char)0xa;
			string part2 = "137"+ crlf + "<!DOCTYPE HTML PUBLIC \"-//IETF//DTD HTML 2.0//EN\">.<HTML><HEAD>.<TITLE>" + 
				num.ToString() + title + "</TITLE>.</HEAD><BODY>.<H1>" + title + "</H1>" + 
				msg + "<P>.<HR></BODY></HTML>" + crlf + "0" + crlf;

			string part1 = "HTTP/1.1 " + num.ToString() + " " + title + crlf +
				"Date: " + DateTime.Now.ToString( "r" ) + crlf +
				"Server: Dr Nexus 0.1a" + crlf +
				"X-Powered-By: Dr Nexus" + crlf +
				"Cache-Control: private" + crlf +
				//	"Keep-Alive: timeout=15, max=98" +  crlf +
				"Connection: close" + crlf + //Keep-Alive" + crlf +
				//	"Transfer-Encoding: chunked" + crlf +
				"Content-Length: " + ( part2.Length ).ToString() + crlf +
				"Content-Type: text/html" + crlf + crlf;

			Send( part1 );
			Send( part2 );
		}
		public void Send404()
		{
			SendError( 404, "Not Found", "The page cannot be found" );
		}
		public void Send403()
		{
			SendError( 403, "Forbidden", "You don't have permission to access this page on this server" );
		}
	}


}
