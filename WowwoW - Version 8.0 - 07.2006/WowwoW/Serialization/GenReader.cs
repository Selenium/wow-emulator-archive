using System;
using System.IO;
using System.Net;


//Serialization v1.0
//Created by TUM 13.08.05
//Great Thanks to ShaiDeath for the help and bug fixing

//Serialization v1.1
//Modified by ShaiDeath 14.08.05

namespace Server.Serialization
{
	/// <summary>
	/// Summary description for GenReader.
	/// </summary>
	public abstract class GenReader
	{
		public GenReader(){}

		public abstract string ReadString();
		public abstract DateTime ReadDateTime();
		public abstract TimeSpan ReadTimeSpan();
		public abstract DateTime ReadDeltaTime();
		public abstract decimal ReadDecimal();
		public abstract long ReadLong();
		public abstract ulong ReadULong();
		public abstract int ReadInt();
		public abstract uint ReadUInt();
		public abstract short ReadShort();
		public abstract ushort ReadUShort();
		public abstract double ReadDouble();
		public abstract float ReadFloat();
		public abstract char ReadChar();
		public abstract byte ReadByte();
		public abstract sbyte ReadSByte();
		public abstract bool ReadBool();
		public abstract int ReadEncodedInt();
		public abstract IPAddress ReadIPAddress();

		public abstract Character ReadCharacter();
		public abstract BaseCreature ReadBaseCreature();
		public abstract Account ReadAccount();
		public abstract GameObject ReadGameObject();
	
		public abstract bool End();
	}
}
