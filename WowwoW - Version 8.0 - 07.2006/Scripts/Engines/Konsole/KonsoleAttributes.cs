// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole
{
	public class UsageAttribute : Attribute
	{
		private string m_Usage;

		public string Usage{ get{ return m_Usage; } }

		public UsageAttribute( string usage )
		{
			m_Usage = usage;
		}
	}

	public class DescriptionAttribute : Attribute
	{
		private string m_Description;

		public string Description{ get{ return m_Description; } }

		public DescriptionAttribute( string description )
		{
			m_Description = description;
		}
	}

	public class AliasesAttribute : Attribute
	{
		private string[] m_Aliases;

		public string[] Aliases{ get{ return m_Aliases; } }

		public AliasesAttribute( params string[] aliases )
		{
			m_Aliases = aliases;
		}
	}

	public class CategoryAttribute : Attribute
	{
		private string m_Category;

		public string Category{ get{ return m_Category; } }

		public CategoryAttribute( string category )
		{
			m_Category = category;
		}
	}
}