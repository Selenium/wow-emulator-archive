using System;
using Server;
using HelperTools;

//Jail System v0.2
//Created by TUM 13.08.05
//Modified 16.08.05

namespace Server.Scripts.Commands.JailSystem
{
	/// <summary>
	/// Summary description for CheckTimer.
	/// </summary>
	public class CheckTimer:WowTimer
	{
		
		public CheckTimer(double time) : base(time)
		{	
						
		}	
		public override void OnTick()
		{
			if (Jail.JailInfo.Count > 0)
			{
				for(int i=0; i<Jail.JailInfo.Count; i++)
				{
					JailInfo info = Jail.JailInfo[i] as JailInfo;
					if (info.Character != null)
					{
						if (info.Character.Distance(Jail.X, Jail.Y, Jail.Z) > (Jail.Range*Jail.Range) || info.Character.MapId != Jail.MapId )
						{
							if (World.allConnectedChars.Contains(info.Character))
								info.Character.Teleport(Jail.X, Jail.Y, Jail.Z, Jail.MapId);
							else
							{
								info.Character.X = Jail.X;
								info.Character.Y = Jail.Y;
								info.Character.Z = Jail.Z;
								info.Character.MapId = Jail.MapId; 
							}
							info.Character.SendMessage("Where are you going?");
							info.Character.SendMessage(String.Format("You have been jailed {0}.{1}.{2} {3}:{4}:{5} on {6} days, {7} hours, {8} minutes", info.JailedDate.Day, info.JailedDate.Month, info.JailedDate.Year, info.JailedDate.Hour, info.JailedDate.Minute, info.JailedDate.Second, info.JailTime.Days, info.JailTime.Hours, info.JailTime.Minutes));
						}
						if ((info.JailedDate + info.JailTime) <= DateTime.Now)
						{
							Jail.UnJailCharacter(info.Character);
							i--;							
						}
					}
					else
					{
						Jail.JailInfo.RemoveAt(i);
						i--;
					}
				}
			}
			if (Jail.JailInfo.Count<=0)
				this.Stop();
		}
	}
}
