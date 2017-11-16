using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace eWoW
{



	public delegate void DoMessageFunction(OP code, PlayerConnection conn);

	public class PlayerConnection : SocketClient 
	{ 
		public delegate void LogMessageHandler				(string message);
		public event LogMessageHandler						LogMessageEvent;

		byte[] key = { 0, 0, 0, 0 }; 
		byte[] SS_Hash=null;

		public string userName;
		public Character player=null;

		Hashtable handler=new Hashtable();
		Hashtable handlerob=new Hashtable();


		public GameServer gameServer;

		public PlayerConnection(GameServer gs, Socket sock) : base(sock) 
		{
			gameServer = gs;
			Send(OP.SMSG_AUTH_CHALLENGE, new byte[]{1,2,3,4});
		}

		protected override void OnDisconnect()
		{
			if(player!=null)player.OnDisconnect();
		}

		public void AddHandler(OP code, DoMessageFunction h, object ob)
		{
			handler[code]=h;
			handlerob[code]=ob;
		}

		public void RemoveHandler(object ob)
		{
			ArrayList codeRemove=new ArrayList();
			foreach(OP code in handlerob.Keys)
			{
				if(handlerob[code]==ob)codeRemove.Add(code);
			}

			foreach(OP code in codeRemove)
			{
				handler.Remove(code);
				handlerob.Remove(code);
			}
		}

		void Decode( ByteArrayBuilder data ) 
		{
			for(int t = 0;t < 6; t++ ) 
			{
				byte a = key[ 0 ]; 
				key[ 0 ] = data[ t ]; 

				byte b = data[ t ]; 
				b = (byte)( b - a ); 

				byte d = key[ 1 ]; 
				a = SS_Hash[ d ]; 
				a = (byte)( a ^ b ); 
				data[ t ] = a; 

				a = key[ 1 ]; 
				a++; 
				key[ 1 ] = (byte)( a % 0x28 );
			} 
		} 

		void Encode( ByteArrayBuilder data ) 
		{
			for(int t = 0;t < 4;t++ ) 
			{             
				byte a = key[ 3 ]; 
				a = (byte)( SS_Hash[ a ] ^ data[ t ] );
				byte d = key[ 2 ]; 
				a += d; 
				data[ t ] = a; 
				key[ 2 ] = a; 
				a = key[ 3 ]; 
				a++;             
				key[ 3 ] = (byte)( a % 0x28 ); 
			} 
		}

		public void Send(OP code, byte[] data)
		{
			if(sock == null)
                return;

            #region debug
#if DEBUG

        //    StreamWriter w=new StreamWriter("d:\\msend.txt", true);
			StreamWriter w=new StreamWriter("c:\\msend.txt", true);
			StringBuilder str=new StringBuilder();

			byte[] cdata = data;
			if(code == OP.SMSG_COMPRESSED_UPDATE_OBJECT)
			{
				ICSharpCode.SharpZipLib.Zip.Compression.Inflater inflater = new ICSharpCode.SharpZipLib.Zip.Compression.Inflater();
				inflater.SetInput(data, 4, data.Length-4);

				cdata = new byte[ data[0] + data[1]*256 + data[2]*256*256 ];
				inflater.Inflate(cdata);
              //  ZLib.Decompress(cdata);
			}

			str.AppendFormat("[{0} {1}] {2} length={3} ", Const.Tick, sock.RemoteEndPoint.ToString(), code, cdata.Length);
			if(code == OP.SMSG_UPDATE_OBJECT || code == OP.SMSG_COMPRESSED_UPDATE_OBJECT)
			{
				int pos = 5;
				str.AppendFormat("count={0}\r\n", cdata[0]);
				for(int i=0; i<cdata[0]; i++)
				{
					if(pos>=cdata.Length)break;

					byte type=cdata[pos];
					str.AppendFormat(" {0} TYPE={1} GUID={2:X} ", i+1, type, BitConverter.ToUInt32(cdata, pos+1));
					pos+=9;

					if(type>0)
					{
						byte obtype=cdata[pos]; pos+=9;
						str.AppendFormat("OBTYPE={0} MOVE [", obtype);
						for(int j=0; j<10; j++)
						{
							str.AppendFormat("{0} ", BitConverter.ToSingle(cdata, pos));
							pos+=4;
						}
						pos+=20;
						str.AppendFormat("] ");
					}
					str.AppendFormat("UPDATE [");
					byte cnt=cdata[pos]; pos++;
					int cpos=pos; pos+=cnt*4;
					for(int j=0; j<cnt*32; j++)
					{
						if( (cdata[cpos+j/8] & (1<<(j%8))) != 0)
						{
							if(pos>=cdata.Length)break;

							str.AppendFormat("{0}={1:X} ", j, BitConverter.ToUInt32(cdata, pos));
							pos+=4;
						}
					}
					str.AppendFormat("]\r\n");
				}
				str.Length=str.Length-2;
			} //
			else 
			{
				str.Append("{ ");
				for(int i=0; i<data.Length; i++)
				{
					string s=data[i].ToString("X");
					if(s.Length==2)
						str.Append(s+ " ");
					else
						str.Append("0" + s + " ");
				}
				str.Append("}");
			}

			w.WriteLine(str.ToString());
			w.Close();
#endif
            #endregion
            ByteArrayBuilder pack = new ByteArrayBuilder();
			pack.Add( (ushort)(data.Length+2) );
			pack.Add( (byte)code, (byte)( (ushort)code >> 8) );
			pack.Add( data );
			if(SS_Hash != null)Encode(pack);
			Send( pack );
		}



		Hashtable pendAuth=null;
		public bool SetUserReply(Hashtable h)
		{
			if(pendAuth==null)return false;
			pendAuth=h;
			return true;
		}

		void CheckAuth()
		{
			if(pendAuth==null)return;
			if(pendAuth.Contains("Retry"))
			{
				int r=(int)pendAuth["Retry"];
				if(r>3){ pendAuth=null; Dispose(); return; }  // È¡ CHAR ³¬Ê±
				ServerGroup.Send(ServerGroupMessageType.UserQuery, pendAuth);
				SetTimeoutFunction("CMSG_AUTH_SESSION", 500, new TimerFunction(CheckAuth));
				return;
			}

			SS_Hash=pendAuth["SESSIONKEY"] as Byte[];

			if(SS_Hash==null)
			{
				Send(OP.SMSG_AUTH_RESPONSE, new byte[]{21});
				SetTimeoutFunction("CMSG_AUTH_SESSION", 1000, new TimerFunction(Dispose));
				return;
			}
			new CharacterHandler(gameServer, this, pendAuth["CHAR"] as string);
			pendAuth=null;

			Send(OP.SMSG_AUTH_RESPONSE, new byte[]{12});
		}


		void RunMsg(OP code)
		{
			switch( code ) 
			{ 
				case OP.CMSG_AUTH_SESSION://   CMSG_AUTH_SESSION 
				{
					if (LogMessageEvent != null)
						LogMessageEvent( "CMSG_AUTH_SESSION build=" + inPacket.Seek(2).GetWord());
					Seek(6).Get(out userName);

					pendAuth=new Hashtable();
					pendAuth["Name"] = userName;
					pendAuth["Hash"] = this.GetHashCode();
					pendAuth["Retry"] = (int)0;
					ServerGroup.Send(ServerGroupMessageType.UserQuery, pendAuth);
					SetTimeoutFunction("CMSG_AUTH_SESSION", 500, new TimerFunction(CheckAuth));
				}
					break;

				case OP.CMSG_PING: 
					Send(OP.SMSG_PONG, Seek(2).GetArray(4));
					break;

				default:
				{
					DoMessageFunction h=handler[code] as DoMessageFunction;
					if(h == null)
					{
						gameServer.LogMessage( "UNKNOWN OP: ", code.ToString(), (ushort)code, inPacket.Length);
						Send(OP.MSG_NULL_ACTION, new byte[]{ 0, (byte)code, (byte)((ushort)code>>8)} );
					} 
					else 
					{
						h(code, this);
					}
					break; 
				}
			}
		}

		ByteArrayBuilder input=new ByteArrayBuilder();
		bool needDecode=true;
		public override byte[] OnRecv(byte[] data, int length) 
		{
			for(int i=0; i<length; i++)input.Add(data[i]);
			while(input.Length>=6)
			{
				if(needDecode && SS_Hash!=null)
				{
					Decode(input);
					needDecode=false;
				}
				input.pos=0;
				ushort len=input.GetWord();
				if(input.Length<len+2)return null;

				needDecode=true;
				data=input.GetArray(4, len-2);
				OP code=(OP)( input[2] + (input[3]<<8) );
				input.Remove(0, len+2);
				SetInput(data);

				RunMsg(code);
			}
			return null;
		} 
	} 
}
