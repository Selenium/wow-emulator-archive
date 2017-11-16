using System;
using System.Collections;
using WoWDaemon.Common;
namespace WoWDaemon.World
{
	public class WorldEventComparer : IComparer
	{
		public WorldEventComparer()
		{
		}

		public int Compare(object x, object y)
		{
			return ((WorldEvent)x).eventTime.CompareTo(((WorldEvent)y).eventTime);
		}
	}

	public abstract class WorldEvent
	{
		public DateTime eventTime;
		public WorldEvent(TimeSpan fromNow)
		{
			eventTime = DateTime.Now.Add(fromNow);
		}
		public abstract void FireEvent();

		internal TreeNode Node = null;
	}

	public class EventManager
	{
		private EventManager()
		{
		}
		static BinaryTree m_tree = BinaryTree.CreateTree(new WorldEventComparer(), true);
		static int m_numEvents = 0;
		public static void AddEvent(WorldEvent e)
		{
			if(e.Node != null)
				return;
			m_numEvents++;
			e.Node = m_tree.AddData(e);
		}

		public static void RemoveEvent(WorldEvent e)
		{
			if(e.Node == null)
				return;
			m_numEvents--;
			m_tree.RemoveNode(e.Node);
			e.Node = null;
		}

		static DateTime now;
		static bool EnumEvents(TreeNode node)
		{
			if(node == null)
				return true;
			if(node.Left != null)
				if(!EnumEvents(node.Left))
					return false;
			WorldEvent e = node.Data as WorldEvent;
			if(e.eventTime > now)
				return false;
			TreeNode right = node.Right;
			RemoveEvent(e);
			e.FireEvent();
			if(right != null)
				return EnumEvents(right);
			return false;
		}

		internal static void CheckEvents()
		{
			now = DateTime.Now;
			EnumEvents(m_tree.GetRoot());
		}

		public static int NumEvents
		{
			get { return m_numEvents;}
		}
	}
}
