using System;
using System.Net;

namespace Server.Konsole.Sockets
{
	/// <summary>
	/// TCPEventArgs
	/// </summary>
	public class TCPEventArgs : EventArgs 
	{
		#region Private Variables
		private string _Data;
		private int _SocketID;
		private EndPoint _Endpoint;
		#endregion

		#region Properties
		public string Data
		{
			get
			{
				return (this._Data);
			}
			set
			{
				this._Data = value;
			}
		}

		public int SocketID
		{
			get
			{
				return (this._SocketID);
			}
			set
			{
				this._SocketID = value;
			}
		}

		public EndPoint Endpoint
		{
			get
			{
				return (this._Endpoint);
			}
			set
			{
				this._Endpoint = value;
			}
		}
		#endregion

		#region Constructor
		public TCPEventArgs(string data, int socketid, EndPoint endpoint) 
		{
			_Data = data;
			_SocketID = socketid;
			_Endpoint = endpoint;
		}
		#endregion
	}
}


