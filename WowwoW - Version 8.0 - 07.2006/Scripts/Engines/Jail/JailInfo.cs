using System;
using Server.Serialization;

//Jail System v0.2
//Created by TUM 13.08.05
//Modified 16.08.05

namespace Server.Scripts.Commands.JailSystem
{
	/// <summary>
	/// Summary description for JailInfo.
	/// </summary>
	public class JailInfo
	{
		private DateTime Date;
		private TimeSpan Time;
		private Character m_Character;

		public DateTime JailedDate
		{
			get { return Date; }
			set { Date = value;}
		}

		public TimeSpan JailTime
		{
			get { return Time; }
			set { Time = value;}
		}

		public Character Character
		{
			get {return m_Character;}
			set {m_Character = value;}
		}

		public JailInfo()
		{
		}

		public void Serialize(GenWriter writer)
		{
			writer.Write((int) 0 ); // version

			writer.Write(m_Character);
			writer.Write(Time);
			writer.Write(Date);
		}

		public void Deserialize(GenReader reader)
		{
			int version = reader.ReadInt();

			switch(version)
			{
				case 0:
				{
					m_Character = reader.ReadCharacter();
					Time = reader.ReadTimeSpan();
					Date = reader.ReadDateTime();
					break;
				}
			}
		}
	}
}

