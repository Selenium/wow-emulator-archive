using System;
using System.IO;
using Server;
using System.Collections;
using System.Xml;
using HelperTools;
namespace Server
{
	public class HonorTimer : HelperTools.WowTimer
	{
		public static string TBHonorPath;
		public static string DBpath;
		private int delay;
		private DateTime lastDayOfCalculateRank;

		public HonorTimer(string honorTablePath, string honorDBPath, int DelayHours) : base(HelperTools.WowTimer.Priorities.Hour, (double)DelayHours)
		{
			TBHonorPath=honorTablePath;
			DBpath = honorDBPath;
			delay = DelayHours;
			try 
			{
				XmlDocument doc = new XmlDocument();
				doc.Load("C:\\stat.xml");
				lastDayOfCalculateRank = Convert.ToDateTime(
					doc.DocumentElement["Calculate"].ChildNodes[0].InnerText);
				if(CheckTime(lastDayOfCalculateRank))
				{
					this.OnTick();
				}
			}
			catch(FileNotFoundException exc)
			{
				Console.WriteLine(exc.Message + 
					"\nCan't find a \"stat.xml\" file!" +
					"\nHonor System don't start!");
			}
			catch(Exception exc)
			{
				Console.WriteLine(exc.Message + "\n" + exc.Source);
			}
			finally
			{}
		}
		private bool CheckTime(DateTime date)
		{
			if(date.DayOfYear >= DateTime.Now.DayOfYear)return true;
			else return false;
		}
		public override void OnTick()
		{
			//Week
			if(CheckTime(lastDayOfCalculateRank))
			{
				WriteHonorForAll();
				CreateHonorTable();
				RankCalculateForAll();
				foreach(Account acc in World.allAccounts)
				{
					foreach(Character ch in acc.characteres)
					{
						ResetHonorWeek(ch);
					}
				}
			}
			//Day
			else
			{
				WriteHonorForAll();
				foreach(Account acc in World.allAccounts)
				{
					foreach(Character ch in acc.characteres)
					{
						ResetHonorDay(ch);
					}
				}	
			}
		}
		public static void WriteHonorForAll()
		{
			foreach(Account acc in World.allAccounts)
			{
				foreach(Character ch in acc.characteres)
				{
					WriteHonor(ch, DBpath);
				}
			}
		}
		public static void WriteHonor( Character ch, string from)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(from);
			foreach(XmlElement player in doc.DocumentElement["players"].ChildNodes)
			{
				if (player["name"].InnerText==ch.Name)
				{
					player["honarableToday"].InnerText=ch.Honor.HonorableKillsToday.ToString();
					player["dishonarableToday"].InnerText=ch.Honor.DishonorableKillsToday.ToString();
					player["honorToday"].InnerText=ch.Honor.HonorToday.ToString();

					player["honarableYesterday"].InnerText=ch.Honor.HonorableKillsYesterday.ToString();
					player["honorYesterday"].InnerText=ch.Honor.HonorYesterday.ToString();

					player["honarableThisWeek"].InnerText=ch.Honor.HonorableKillsThisWeek.ToString();
					player["honorThisWeek"].InnerText=ch.Honor.HonorThisWeek.ToString();
					player["dishonarableThisWeek"].InnerText = ch.Honor.HonorableKillsThisWeek.ToString();
		
					player["hkillsLastWeek"].InnerText=ch.Honor.HonorableKillsLastWeek.ToString();
					player["dishkillsLastWeek"].InnerText=ch.Honor.DishonorableKillsLastWeek.ToString();
					player["higherstRank"].InnerText=ch.Honor.HigherstRank;
					break;
				}
			}
			doc.Save(from);
		}
		public static void WriteHonor(Character ch, string from, string param, string val)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(from);
			foreach(XmlElement player in doc.DocumentElement["players"].ChildNodes)
			{
				if (player["name"].InnerText==ch.Name)
				{
					player[param].InnerText=val;
					break;
				}
			}
			doc.Save(from);
		}
		public static void LoadHonor(Character ch, string from)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(from);
			foreach(XmlElement player in doc.DocumentElement["players"].ChildNodes)
			{
				if (player["name"].InnerText==ch.Name)
				{
					ch.Honor.HonorableKillsToday=Convert.ToUInt32(player["honarableToday"].InnerText);
					ch.Honor.DishonorableKillsToday=Convert.ToUInt32(player["dishonarableToday"].InnerText);
					ch.Honor.HonorToday=Convert.ToUInt32(player["honorToday"].InnerText);

					ch.Honor.HonorableKillsYesterday=Convert.ToUInt32(player["honarableYesterday"].InnerText);
					ch.Honor.HonorYesterday=Convert.ToUInt32(player["honorYesterday"].InnerText);

					ch.Honor.HonorableKillsThisWeek=Convert.ToUInt32(player["honarableThisWeek"].InnerText);
					ch.Honor.HonorThisWeek=Convert.ToUInt32(player["honorThisWeek"].InnerText);
							
					ch.Honor.HonorableKillsLastWeek=Convert.ToUInt32(player["hkillsLastWeek"].InnerText);
					ch.Honor.DishonorableKillsLastWeek=Convert.ToUInt32(player["dishkillsLastWeek"].InnerText);
					ch.Honor.HigherstRank=player["higherstRank"].InnerText;
					break;
				}
				else continue;
			}
		}
		public void CreateHonorTable()
		{
			Console.WriteLine("-=Calculate Summ of honor for each race=-");
			uint[] summs= new uint[7];
			//Initial
				summs[0] = 0;//Dwarf
				summs[1] = 0;//Gnome
				summs[2] = 0;//Human
				summs[3] = 0;//NightElf
				summs[4] = 0;//Orc
				summs[5] = 0;//Tauren
				summs[6] = 0;//Troll
				summs[7] = 0;//Undead
			XmlDocument doc = new XmlDocument();
			doc.Load(DBpath);
			foreach(XmlElement elem in doc.DocumentElement.ChildNodes)
			{
				if(elem.Name=="players")
				{
					foreach(XmlElement player in elem.ChildNodes)
					{
						switch(player["race"].ToString())
						{
							case "Dwarf":
							{
								summs[0]+=Convert.ToUInt32(player["honorThisWeek"]);
								break;
							}
							case "Gnome":
							{
								summs[1]+=Convert.ToUInt32(player["honorThisWeek"]);
								break;
							}
							case "Human":
							{
								summs[2]+=Convert.ToUInt32(player["honorThisWeek"]);
								break;
							}
							case "NightElf":
							{
								summs[3]+=Convert.ToUInt32(player["honorThisWeek"]);
								break;
							}
							case "Orc":
							{
								summs[4]+=Convert.ToUInt32(player["honorThisWeek"].InnerText);
								break;
							}
							case "Tauren":
							{
								summs[5]+=Convert.ToUInt32(player["honorThisWeek"]);
								break;
							}
							case "Troll":
							{
								summs[6]+=Convert.ToUInt32(player["honorThisWeek"]);
								break;
							}
							case "Undead":
							{
								summs[7]+=Convert.ToUInt32(player["honorThisWeek"]);
								break;
							}
						}
					}
				}
			}
			Console.WriteLine("Summ calculate done!");
			doc.Load(TBHonorPath);
			if(File.Exists(TBHonorPath)) 
			{
				foreach(XmlElement elem in doc.DocumentElement.ChildNodes)
				{
					switch(	elem.Name )
					{
						case "Dwarf":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[0]/100) * (i+1)/2 );
							}
							break;
						}
						case "Gnome":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[1]/100) * (i+1)/2 );
							}
							break;
						}
						case "Human":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[2]/100) * (i+1)/2 );
							}
							break;
						}
						case "NightElf":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[3]/100) * (i+1)/2 );
							}
							break;
						}
						case "Orc":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[4]/100) * (i+1)/2 );
							}
							break;
						}
						case "Tauren":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[5]/100) * (i+1)/2 );
							}
							break;
						}
						case "Troll":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[6]/100) * (i+1)/2 );
							}
							break;
						}
						case "Undead":
						{
							for(int i=0; i<elem.ChildNodes.Count;i++)
							{
								elem.ChildNodes[i].InnerText=Convert.ToString( (summs[7]/100) * (i+1)/2 );
							}
							break;
						}
					}
				}
				doc.Save(TBHonorPath);
			}
			else
			{Console.WriteLine("File not found!"); return;}
		}

		public void RankCalculate(Character ch)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(TBHonorPath);
			if(ch.Honor.HonorThisWeek > 25)
			{
				foreach(XmlElement ranks in doc.DocumentElement[ch.Race.ToString()].ChildNodes)
				{
					if(ch.Honor.HonorThisWeek > Convert.ToInt32(ranks.InnerText))
					{
						ch.Honor.HigherstRank=ranks.Name.Replace('_', ' ');
						continue;
					}
					else break;
				}
			}		
			WriteHonor(ch, TBHonorPath, "higherstRank", ch.Honor.HigherstRank);
		}
		int tickCount;
		public void RankCalculateForAll()
		{
			int step = World.allAccounts.Count / 24;
			for(int t = 0;t < step;t++ )
			{
				int i = t + tickCount * step;
				if ( i >= World.allAccounts.Count )
				{
					tickCount = 0;//	End of the loop, all the account have been computed
					return;
				}
				Account acc = World.allAccounts[ i ];
				foreach(Character ch in acc.characteres)
				{
					RankCalculate(ch);
				}				
			}
			tickCount++;			
		}

		public void ResetHonorWeek(Character ch)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(HonorTimer.DBpath);
			foreach(XmlElement player in doc.DocumentElement["players"].ChildNodes)
			{
				if (player["name"].InnerText==ch.Name)
				{
					//Last Week
					player["hkillsLastWeek"].InnerText=player["honarableThisWeek"].InnerText;
					player["dishkillsLastWeek"].InnerText=player["dishonarableThisWeek"].InnerText;
					//This Week
					player["dishonarableThisWeek"].InnerText=Convert.ToString(Convert.ToUInt32(player["dishonarableToday"].InnerText)+
						Convert.ToUInt32(player["dishonarableThisWeek"].InnerText));
					player["honarableThisWeek"].InnerText=Convert.ToString(Convert.ToUInt32(player["honarableToday"].InnerText) +
						Convert.ToUInt32(player["honarableThisWeek"].InnerText));
					player["honorThisWeek"].InnerText=Convert.ToString(Convert.ToUInt32(player["honorToday"].InnerText) + 
						Convert.ToUInt32(player["honorThisWeek"].InnerText));
					//Yesterday	
					player["honarableYesterday"].InnerText=player["honarableToday"].InnerText;
					player["honorYesterday"].InnerText=player["honorToday"].InnerText;
					//Today
					player["honarableToday"].InnerText="0";
					player["dishonarableToday"].InnerText="0";
					player["honorToday"].InnerText="0";
					break;
				}
			}
			doc.Save(HonorTimer.DBpath);
		}
		public void ResetHonorDay(Character ch)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(HonorTimer.DBpath);
			foreach(XmlElement player in doc.DocumentElement["players"].ChildNodes)
			{
				if (player["name"].InnerText==ch.Name)
				{
					//This Week
					player["dishonarableThisWeek"].InnerText=Convert.ToString(Convert.ToUInt32(player["dishonarableToday"].InnerText)+
						Convert.ToUInt32(player["dishonarableThisWeek"].InnerText));
					player["honarableThisWeek"].InnerText=Convert.ToString(Convert.ToUInt32(player["honarableToday"].InnerText) +
						Convert.ToUInt32(player["honarableThisWeek"].InnerText));
					player["honorThisWeek"].InnerText=Convert.ToString(Convert.ToUInt32(player["honorToday"].InnerText) + 
						Convert.ToUInt32(player["honorThisWeek"].InnerText));
					//Yesterday
					player["honarableYesterday"].InnerText = player["honarableToday"].InnerText;
					player["honorYesterday"].InnerText = player["honorToday"].InnerText;
					//Today
					player["honarableToday"].InnerText="0";
					player["dishonarableToday"].InnerText="0";
					player["honorToday"].InnerText="0";
					break;
				}
			}
			doc.Save(HonorTimer.DBpath);
		}
	}
	public struct HonorUnit
	{
		//public ArrayList HonorTarget;
		private uint hkillsToday;
		private uint dishkillsToday;
		private uint honorToday;

		private uint hkillsYesterday;
		private uint honorYesterday;

		private uint hkillsThisWeek;
		private uint honorThisWeek;
		private uint dishonarableThisWeek;

		private uint hkillsLastWeek;
		private uint dishkillsLastWeek;
		private string higherstRank;
		
		public uint HonorToday
		{
			get {return honorToday;}
			set {honorToday=value;}

		}
		public uint HonorableKillsToday
		{
			get{return hkillsToday;}
			set{hkillsToday=value;}
		}
		public uint DishonorableKillsToday
		{
			get{return dishkillsToday;}
			set{dishkillsToday=value;}
		}
		public uint HonorableKillsYesterday
		{
			get{return hkillsYesterday;}
			set{hkillsYesterday=value;}
		}
		public uint HonorYesterday
		{
			get{return honorYesterday;}
			set{honorYesterday = value;}
		}
		public uint HonorableKillsThisWeek
		{
			get{return hkillsThisWeek;}
			set{hkillsThisWeek=value;}
		}
		public uint DishonarableThisWeek
		{
			get{return dishonarableThisWeek;}
			set{dishonarableThisWeek=value;}
		}
		public uint HonorThisWeek
		{
			get{return honorThisWeek;}
			set{honorThisWeek=value;}
		}
		public uint HonorableKillsLastWeek
		{
			get{return hkillsLastWeek;}
			set{hkillsLastWeek=value;}
		}
		public uint DishonorableKillsLastWeek
		{
			get{return dishkillsLastWeek;}
			set{dishkillsLastWeek=value;}
		}
		public string HigherstRank
		{
			get{return higherstRank;}
			set{higherstRank=value;}
		}
		
	}
	
}