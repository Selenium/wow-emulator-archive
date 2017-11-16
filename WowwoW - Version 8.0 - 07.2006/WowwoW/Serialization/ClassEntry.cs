using System;
using System.Reflection;
using HelperTools;

//Serialization v1.0
//Created by TUM 13.08.05
//Great Thanks to ShaiDeath for the help and bug fixing

//Serialization v1.1
//Modified by ShaiDeath 14.08.05

namespace Server.Serialization
{
	/// <summary>
	/// Summary description for ClassEntry.
	/// </summary>
	public class ClassEntry
	{
		private long m_Position;
		private int m_Length;		
		private string m_ClassName;
		private ISerialize m_Class;

		public string ClassName
		{
			get {return m_ClassName;}
		}
		public long Position
		{
			get {return m_Position;}
		}
		public int Length
		{
			get {return m_Length;}
		}
		public ISerialize Class
		{
			get {return m_Class;}
		}
		public ClassEntry(string Name, long pos, int length )
		{			
			ConstructorInfo info = Utility.FindConstructor(Name);
			if (info != null)
			{				
				m_Class = (ISerialize)info.Invoke(null);
			}
			m_Position = pos;
			m_Length = length;
			m_ClassName = Name;
		}
	}
}
