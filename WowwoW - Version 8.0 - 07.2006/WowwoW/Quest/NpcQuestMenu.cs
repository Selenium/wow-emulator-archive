using System;
using HelperTools;
using System.Collections;

namespace Server
{
	/// <summary>
	/// Summary description for NpcQuestMenu.
	/// </summary>
	public class NpcQuestMenu
	{
		string title;
		ArrayList menus = new ArrayList();
		ArrayList quests = new ArrayList();

		public NpcQuestMenu()
		{
			title = "";
		}
		public NpcQuestMenu( string _title )
		{
			title = _title;
		}
		public void AddMenu( string menu, BaseQuest bq )
		{
			menus.Add( menu );
			quests.Add( bq );
		}
		public string Title
		{
			get { return title; }
		}
		public ArrayList Menu
		{
			get { return menus; }
		}
		public ArrayList Quests
		{
			get { return quests; }
		}
	}
}
