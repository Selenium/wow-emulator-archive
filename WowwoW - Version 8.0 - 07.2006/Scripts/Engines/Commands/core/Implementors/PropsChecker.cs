/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/
using System;
using System.Collections;
using Server;
using Server.Scripts;
using HelperTools;
using Server.Scripts.Properties;

namespace Server.Scripts.Commands
{
	public class PropsChecker
	{
		public enum CommandType
		{
			Equal = 0,
			More = 1,
			Less = 2,
			MoreOrEqual = 3,
			LessOrEqual = 4,
			NotEqual = 5
		}
		private Hashtable m_CmdEntries;
		private Hashtable m_ValueEntries;

		public Hashtable CmdEntries
		{
			get
			{
				return m_CmdEntries;
			}
		}

		public Hashtable ValueEntries
		{
			get
			{
				return m_ValueEntries;
			}
		}

		public PropsChecker()
		{
			m_CmdEntries = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );
			m_ValueEntries = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );
		}

		private bool StrCheck(string str1, string str2, CommandType type)
		{
			if (type == CommandType.Equal)
			{
				return (str1 == str2);
			}
			else if (type == CommandType.More)
			{
				if (Utility.ToInt32(str1)!=0)
				{
					return ((Utility.ToInt32(str1)) > (Utility.ToInt32(str2)));
				}
				else
				{
					return (0>(Utility.ToInt32(str2)));
				}
			}
			else if (type == CommandType.Less)
			{
				if (Utility.ToInt32(str1)!=0)
				{
					return ((Utility.ToInt32(str1)) < (Utility.ToInt32(str2)));
				}
				else
				{
					return (0<(Utility.ToInt32(str2)));
				}
			}
			else if (type == CommandType.MoreOrEqual)
			{
				if (Utility.ToInt32(str1)!=0)
				{
					return ((Utility.ToInt32(str1)) >= (Utility.ToInt32(str2)));
				}
				else
				{
					return (0>=(Utility.ToInt32(str2)));
				}
			}
			else if (type == CommandType.LessOrEqual)
			{
				if (Utility.ToInt32(str1)!=0)
				{
					return ((Utility.ToInt32(str1)) <= (Utility.ToInt32(str2)));
				}
				else
				{
					return (0<=(Utility.ToInt32(str2)));
				}
			}
			else /*if (type == CommandType.NotEqual)*/
			{
				return (str1 != str2);
			}

		}

		public bool Check(Mobile targ)
		{
			foreach (DictionaryEntry entry in m_CmdEntries)
			{
				if (entry.Key is string)
				{
					string chkval = (string)m_ValueEntries[(string)entry.Key];
					CommandType type = (CommandType)m_CmdEntries[(string)entry.Key];
					string val;
					if ( targ is Character)
					{
						val = Server.Scripts.Properties.CharacterProperties.GetValue(targ, (string)entry.Key);
						if (StrCheck(val, chkval, type))
						{
							continue;
						}
					}
					val = Server.Scripts.Properties.MobileProperties.GetValue(targ, (string)entry.Key);
					if (!StrCheck(val, chkval, type))
					{
						return false;
					}
				}
                
			}
			return true;
		}

		public bool AddProperty( string prop, string cmd, string num)
		{
			if ((cmd == "=") || (cmd == "=="))
			{
				m_CmdEntries[prop] = CommandType.Equal;
			}
			else if (cmd == ">")
			{
				m_CmdEntries[prop] = CommandType.More;
				if ((Utility.ToInt32(num)==0) && (num!= "0"))
				{
					return false;
				}
			}
			else if (cmd == "<")
			{
				m_CmdEntries[prop] = CommandType.Less;
				if ((Utility.ToInt32(num)==0) && (num!= "0"))
				{
					return false;
				}			
			}
			else if ((cmd == "<=") || (cmd == "!>"))
			{
				m_CmdEntries[prop] = CommandType.MoreOrEqual;
				if ((Utility.ToInt32(num)==0) && (num!= "0"))
				{
					return false;
				}			
			}
			else if ((cmd == ">=") || (cmd == "!<"))
			{
				m_CmdEntries[prop] = CommandType.LessOrEqual;
				if ((Utility.ToInt32(num)==0) && (num!= "0"))
				{
					return false;
				}			
			}
			else if ((cmd == "!=") || (cmd == "<>"))
			{
				m_CmdEntries[prop] = CommandType.NotEqual;
			}
			else
			{
				return false;
			}
			m_ValueEntries[prop] = num;
			return true;
		}

	}
}