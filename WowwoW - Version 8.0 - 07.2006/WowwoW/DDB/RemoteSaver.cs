using System;
using System.Net.Sockets;
using Server;
using HelperTools;
using System.IO;

namespace DDB
{
	/// <summary>
	/// Summary description for RemoteSaver.
	/// </summary>
	public class RemoteSaver : SockClient
	{
		int state = 0;
		byte []still = null;
		UInt64 guid;
		Character character;

		public RemoteSaver( Socket sock, Server.RemoveClientDelegate rcd ) : base( sock, rcd )
		{
		}

		public override byte [] ProcessDataReceived( byte []rec, int length )
		{
			byte []data = null;
			if ( still != null )
			{
				data = new byte[ length + still.Length ];
				Buffer.BlockCopy( still, 0, data, 0, still.Length );
				Buffer.BlockCopy( rec, 0, data, still.Length, length );
			}
			else data = rec;
			#region State 0
			if ( state == 0 )//	Wait for a command
			{
				if ( data[ 2 ] == 0x1 )//	read
				{
					state = 1;
					guid = BitConverter.ToUInt64( data, 5 );
					character = (Character)World.FindMobileByGUID( guid );
					if ( character == null )
						this.Send( new byte[] { 2, 0, 1, 0 }, 0, 4 );//	character exist, ok to read
					else
					{
						#region State 1, Read file
						if ( state == 1 )
						{
							MemoryWriter mw = new MemoryWriter();	
							character.Serialize( mw );
							mw.Close();
							byte []buffer = new byte[ 4098 ];
				
							for(int t = 0;t < mw.buff.Length;t+=4096)
							{
								int offset = 0;
								int rlen = 0;
								if ( mw.buff.Length - t < 4096 )
									rlen = mw.buff.Length - t;
								else
									rlen = 4096;
								Converter.ToBytes( (ushort)rlen, buffer, ref offset );
								Buffer.BlockCopy( mw.buff, t, buffer, 2, rlen );
								this.Send( buffer, 0, rlen + 2 );					
							}
						}
						#endregion
					}
					if ( 13 == length )
						return null;
					still = data;
				}
				else
					if ( data[ 2 ] == 0x2 )//	save
				{
					state = 2;

					if ( 13 == length )
						return null;
					still = data;
				}
			}
				#endregion
			
				
			return null;
		}
	}
}
