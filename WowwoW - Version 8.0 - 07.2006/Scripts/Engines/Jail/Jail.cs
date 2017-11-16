using System;
using System.Collections;
using Server;
using Server.Scripts.Commands;
//using Server.Scripts.Properties;
using Server.Serialization;
using HelperTools;

//Jail System v0.2
//Created by TUM 13.08.05
//Modified 16.08.05

namespace Server.Scripts.Commands.JailSystem
{
	/// <summary>
	/// Jail System main class.
	/// </summary>
	/// 
	public class Jail : ISerialize
	{
		//Options
		public static int Range = 40;
		public static float X = -7463f;
		public static float Y = -1083f;
		public static float Z = 897f;
		public static ushort MapId = 0;

		public static ArrayList JailInfo = new ArrayList();		
		public static WowTimer CheckTimer = new CheckTimer(1001);
		

		public static void JailCharacter(Character c, int Days, int Hours, int Minutes)
		{
			c.Teleport(X, Y, Z, MapId );
			c.SendMessage(String.Format("You have been jailed on {0} days, {1} hours, {2} minutes", Days, Hours, Minutes));
			JailInfo info = new JailInfo();
			info.Character = c;
			info.JailedDate = DateTime.Now;
			info.JailTime = new TimeSpan(Days, Hours, Minutes, 0);
			Jail.JailInfo.Add(info);
			if (Jail.JailInfo.Count == 1)
				Jail.CheckTimer.Start();
		}

		public static void UnJailCharacter(Character c)
		{
			foreach(JailInfo info in Jail.JailInfo)
			{
				if(info.Character == c)
				{
					ToStartLocation.TeleportToStartingLocation(info.Character);
					info.Character.SendMessage("You have been unjailed");
					Jail.JailInfo.Remove(info);
					return;
				}
			}
		}

		public void Serialize (GenWriter writer)
		{
			writer.Write((int) 0 ); // version

			writer.Write(JailInfo.Count);
			foreach(JailInfo info in JailInfo)
			{
				info.Serialize(writer);				
			}						
		}
		public void Deserialize (GenReader reader)
		{
			int version = reader.ReadInt();

			switch(version)
			{
				case 0:
				{
					int count = reader.ReadInt();
					for (int i=0; i<count; i++)
					{
						JailInfo info = new JailInfo();
	
						info.Deserialize(reader);
						
						if (info.Character != null)
							JailInfo.Add(info);
					}					
					if (JailInfo.Count > 0)
					{
						CheckTimer.Start();
					}				

				}
					break;
			}			
		}
	}
}
