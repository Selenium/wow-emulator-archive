using System;

namespace Server
{

	/// <summary>
	/// Summary description for SkillTemplate.
	/// </summary>
	public class SkillTemplate : BaseAbility
	{
		int type;

		public SkillTemplate( ushort id, int typ ) : base( id, 2000 )
		{
			type = typ;
		}
	}
}
