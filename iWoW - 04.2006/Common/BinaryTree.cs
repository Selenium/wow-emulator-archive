using System;
using System.Collections;

namespace WoWDaemon.Common
{
	public class UIntComparer : IComparer
	{
		#region IComparer Members

		public int Compare(object x, object y)
		{
			return ((uint)x).CompareTo(y);
		}

		#endregion

	}

	public class IntComparer : IComparer
	{
		#region IComparer Members

		public int Compare(object x, object y)
		{
			return ((int)x).CompareTo(y);
		}

		#endregion
	}


	public abstract class BinaryTree
	{
		public abstract TreeNode AddData(object data);
		public abstract ITreeEnumerator GetEnumerator();
		public abstract void Clear();
		public static BinaryTree CreateTree(IComparer c, bool allowDups)
		{
			if(allowDups)
				return new BinaryTreeDups(c);
			return new BinaryTreeNoDups(c);
		}
		public abstract TreeNode GetRoot();
		public abstract void RemoveNode(TreeNode node);
		
	}

	internal class BinaryTreeDups : BinaryTree
	{
		TreeNode m_root = null;
		IComparer m_cmp;
		public BinaryTreeDups(IComparer c)
		{
			m_cmp = c;
		}

		public override TreeNode GetRoot()
		{
			return m_root;
		}

		public override ITreeEnumerator GetEnumerator()
		{
			if(m_root == null)
				return new EmptyEnumerator();
			return new TreeEnumerator(this);// todo pre & post enums
		}

		public override void Clear()
		{
			if(m_root != null)
				m_root.Clear();// is the gc smart enough to reconize
			// that it isn't referenced anymore?
			m_root = null;
		}


		public override TreeNode AddData(object data)
		{
			TreeNode newNode = new TreeNode(data);
			if(m_root == null)
			{
				m_root = newNode;
				return newNode;
			}
			_add(newNode, m_root);
			return newNode;
		}

		private void _add(TreeNode node, TreeNode parent)
		{
			int result = m_cmp.Compare(node.Data, parent.Data);
			if(result < 0)
			{
				if(parent.Left != null)
					_add(node, parent.Left);
				else
				{
					node.Parent = parent;
					parent.Left = node;
				}
				return;
			}
			else
			{
				if(parent.Right != null)
					_add(node, parent.Right);
				else
				{
					node.Parent = parent;
					parent.Right = node;
				}
				return;
			}
		}

		public override void RemoveNode(TreeNode node)
		{
			TreeNode parent = node.Parent;
			TreeNode left = node.Left;
			TreeNode right = node.Right;
			if(right != null)
			{
				if(parent == null)
				{
					m_root = right;
				}
				else if(parent.Right == node)
					parent.Right = right;
				else if(parent.Left == node)
					parent.Left = right;
				right.Parent = parent;
				if(left != null)
				{
					if(right.Left != null)
					{
						TreeNode rightLefty = right.Left;
						while(rightLefty.Left != null)
							rightLefty = rightLefty.Left;
						rightLefty.Left = left;
						left.Parent = rightLefty;
					}
					else
					{
						right.Left = left;
						left.Parent = right;
					}
				}
			}
			else if(left != null)
			{
				left.Parent = parent;
				if(parent == null)
					m_root = left;
				else if(parent.Right == node)
					parent.Right = left;
				else if(parent.Left == node)
					parent.Left = left;
			}
			else if(parent != null)
			{
				if(parent.Left == node)
					parent.Left = null;
				else if(parent.Right == node)
					parent.Right = null;
			}
			else
				m_root = null;
			node.Right = null;
			node.Left = null;
			node.Parent = null;
		}
	}

	internal class BinaryTreeNoDups : BinaryTree
	{
		TreeNode m_root = null;
		IComparer m_cmp;
		public BinaryTreeNoDups(IComparer c)
		{
			m_cmp = c;
		}

		public override TreeNode GetRoot()
		{
			return m_root;
		}

		public override ITreeEnumerator GetEnumerator()
		{
			if(m_root == null)
				return new EmptyEnumerator();
			return new TreeEnumerator(this);// todo pre & post enums
		}

		public override void Clear()
		{
			if(m_root != null)
				m_root.Clear();// is the gc smart enough to reconize
			// that it isn't referenced anymore?
			m_root = null;
		}


		public override TreeNode AddData(object data)
		{
			TreeNode newNode = new TreeNode(data);
			if(m_root == null)
			{
				m_root = newNode;
				return newNode;
			}
			_add(newNode, m_root);
			return newNode;
		}

		private void _add(TreeNode node, TreeNode parent)
		{
			int result = m_cmp.Compare(node.Data, parent.Data);
			if(result < 0)
			{
				if(parent.Left != null)
					_add(node, parent.Left);
				else
				{
					node.Parent = parent;
					parent.Left = node;
				}
				return;
			}
			if(result > 0)
			{
				if(parent.Right != null)
					_add(node, parent.Right);
				else
				{
					node.Parent = parent;
					parent.Right = node;
				}
				return;
			}
			parent.Data = node.Data;
		}
		public bool RemoveData(object data)
		{
			TreeNode node = _getNode(m_root, data);
			if(node == null)
				return false;
			RemoveNode(node);
			return true;
		}

		public override void RemoveNode(TreeNode node)
		{
			TreeNode parent = node.Parent;
			TreeNode left = node.Left;
			TreeNode right = node.Right;
			if(right != null)
			{
				if(parent == null)
				{
					m_root = right;
				}
				else if(parent.Right == node)
					parent.Right = right;
				else if(parent.Left == node)
					parent.Left = right;
				right.Parent = parent;
				if(left != null)
				{
					if(right.Left != null)
					{
						TreeNode rightLefty = right.Left;
						while(rightLefty.Left != null)
							rightLefty = rightLefty.Left;
						rightLefty.Left = left;
						left.Parent = rightLefty;
					}
					else
					{
						right.Left = left;
						left.Parent = right;
					}
				}
			}
			else if(left != null)
			{
				left.Parent = parent;
				if(parent == null)
					m_root = left;
				else if(parent.Right == node)
					parent.Right = left;
				else if(parent.Left == node)
					parent.Left = left;
			}
			else if(parent != null)
			{
				if(parent.Left == node)
					parent.Left = null;
				else if(parent.Right == node)
					parent.Right = null;
			}
			else
				m_root = null;
			node.Right = null;
			node.Left = null;
			node.Parent = null;
		}

		private TreeNode _getNode(TreeNode node, object data)
		{
			int result = m_cmp.Compare(data, node.Data);
			if(result < 0)
			{
				if(node.Left == null)
					return null;
				return _getNode(node.Left, data);
			}
			if(result > 0)
			{
				if(node.Right == null)
					return null;
				return _getNode(node.Right, data);
			}
			return node;
		}
	}

	public class TreeNode
	{
		public TreeNode Parent = null;
		public TreeNode Left = null;
		public TreeNode Right = null;
		public object Data = null;
		public bool Visited = false;
		
		private TreeNode()
		{
		}

		public TreeNode(object data)
		{
			Data = data;
		}

		public void ResetVisit()
		{
			Visited = false;
			if(Left != null)
				Left.ResetVisit();
			if(Right != null)
				Right.ResetVisit();
		}
		public void Clear()
		{
			if(Left != null)
			{
				Left.Clear();
				Left = null;
			}
			if(Right != null)
			{
				Right.Clear();
				Right = null;
			}
			Parent = null;
		}
	}

	public interface ITreeEnumerator : IEnumerator
	{
		void RemoveCurrent();
	}

	internal sealed class EmptyEnumerator : ITreeEnumerator
	{
		#region IEnumerator Members

		public void Reset()
		{
		}

		public object Current
		{
			get
			{
				return null;
			}
		}

		public bool MoveNext()
		{
			return false;
		}

		public void RemoveCurrent()
		{
		}
		#endregion

	}

	internal sealed class TreeEnumerator : ITreeEnumerator
	{
		#region IEnumerator Members

		public TreeEnumerator(BinaryTree tree)
		{
			m_current = tree.GetRoot();
			m_tree = tree;
		}
		private TreeNode m_current;
		private BinaryTree m_tree;

		public void Reset()
		{
			m_current = m_tree.GetRoot();
			m_current.ResetVisit();
		}

		public object Current
		{
			get
			{
				return m_current.Data;
			}
		}

		public bool MoveNext()
		{
			if(m_current.Left != null && !m_current.Left.Visited)
			{
				while(m_current.Left != null)
					m_current = m_current.Left;
				m_current.Visited = true;
				return true;
			}
			
			// visit me
			if(m_current.Visited == false)
			{
				m_current.Visited = true;
				return true;
			}

			// visit right child
			if(m_current.Right != null && !m_current.Right.Visited)
			{
				m_current = m_current.Right;
				while(m_current.Left != null)
					m_current = m_current.Left;
				m_current.Visited = true;
				return true;
			}
			if(m_current.Parent != null)
			{
				m_current = m_current.Parent;
				return MoveNext();
			}
			return false;
		}

		bool MoveNextDontVisit()
		{
			if(m_current.Left != null && !m_current.Left.Visited)
			{
				while(m_current.Left != null)
					m_current = m_current.Left;
				return true;
			}
			
			// visit me
			if(m_current.Visited == false)
			{
				return true;
			}

			// visit right child
			if(m_current.Right != null && !m_current.Right.Visited)
			{
				m_current = m_current.Right;
				while(m_current.Left != null)
					m_current = m_current.Left;
				return true;
			}
			if(m_current.Parent != null)
			{
				m_current = m_current.Parent;
				return MoveNext();
			}
			return false;
		}

		public void RemoveCurrent()
		{
			TreeNode node = m_current;
			if(!MoveNextDontVisit())
			{
				m_current = new TreeNode(null);
				m_current.Visited = true;
			}
			m_tree.RemoveNode(node);
		}
		#endregion
	}
}
