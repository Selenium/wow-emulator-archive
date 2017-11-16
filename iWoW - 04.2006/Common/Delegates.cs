using System;
using System.Net;
using System.Net.Sockets;

namespace WoWDaemon.Common
{
	public delegate void SocketDelegate(Socket sock);
	public delegate void VoidDelegate();
	public delegate void ExceptionDelegate(Exception e);
	public delegate void IntDelegate(int val);
	public delegate void RealmUpdateDelegate(string Description, string IP, int Users);
	public delegate void RealmRemoveDelegate(string IP);
	public delegate void LoginServerUpdateDelegate(string IP, int Users, bool Full);
	public delegate void DataDelegate(byte[] data);
	public delegate void ScriptPacketDelegate(int msgID, BinReader data);
}
