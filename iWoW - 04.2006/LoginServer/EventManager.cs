using System;
using System.Collections;
using WoWDaemon.Common;
namespace WoWDaemon.Login
{
	public class LoginEventComparer : IComparer
	{
		public LoginEventComparer()
		{
		}

		public int Compare(object x, object y)
		{
			return ((LoginEvent)x).eventTime.CompareTo(((LoginEvent)y).eventTime);
		}
	}

	public abstract class LoginEvent
	{
		public DateTime eventTime;
		public LoginEvent(TimeSpan fromNow)
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
		static BinaryTree m_tree = BinaryTree.CreateTree(new LoginEventComparer(), true);
		static int m_numEvents = 0;
		public static void AddEvent(LoginEvent e)
		{
			if(e.Node != null)
				return;
			m_numEvents++;
			e.Node = m_tree.AddData(e);
		}

		public static void RemoveEvent(LoginEvent e)
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
			LoginEvent e = node.Data as LoginEvent;
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
