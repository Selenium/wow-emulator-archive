using System;
using System.Collections;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for CraftTemplate.
	/// </summary>
	public class CraftTemplate : BaseAbility
	{
		int []materials;
		short []nMaterials;
		int objectCraft;
		int tool1;
		int tool2;
		public CraftTemplate( int ob, ushort i, int t1, int t2, 
			int []mat, short []nmat ) : base( i, 2000 )
		{
			objectCraft = ob;
			tool1 = t1;
			tool2 = t2;
			materials = mat;
			nMaterials = nmat;
		}

		public void Create(Mobile.Casting cast, Mobile c )
		{	
			bool ok = true;
			if ( ( c as Character ).FindAFreeSlot() != Slots.None )
			{			
				
				ArrayList toConsume = new ArrayList();				
				for(int t = 0;t < nMaterials.Length;t++ )
				{
					if ( nMaterials[ t ] > 0 )
					{
						int amount = nMaterials[ t ];
						if ( c is Character )
						{
							int ihave = ( c as Character ).FindAmountOfItemById( materials[ t ] );
							if ( amount > ihave )
							{
								ok = false;
								c.SpellFaillure( SpellFailedReason.Required, World.CreateItemInPoolById( materials[ t ] ).Name );
								break;
							}
						}
					}
					else
						break;
				}		
				if ( ok )
					for(int t = 0;t < nMaterials.Length;t++ )
					{
						if ( nMaterials[ t ] > 0 )
						{
							if ( c is Character )
								( c as Character ).ConsumeItemByIdUpTo( materials[ t ], nMaterials[ t ] );
						}
					}
			}
			if ( ok )
			{
				int id = c.cast.id;
				c.SpellSuccess();
				Item i = World.CreateItemInPoolById( objectCraft );
				if ( i.MaxCount == 0 )
					i.MaxCount = 1;
				if ( c is Character )
				{
					c.cast.id = id;
					//c.SpellFaillure( (SpellFailedReason)8 );
					( c as Character ).PutObjectInBackpack( i, 1, true );
					object o = AbilityClasses.abilityClasses[ id ];
					if ( o != null )
					{
						int skill = 0;
						switch( (int)o )
						{
							case (int)ClassesOfSpells.Leatherworking:
							{
								skill = LeatherSkill.SkillId;
								break;
							}
							case (int)ClassesOfSpells.Blacksmithing:
							{
								skill = 164;
								break;
							}
							case (int)ClassesOfSpells.Enchanting:
							{
								skill = 333;
								break;
							}
							case (int)ClassesOfSpells.Engineering:
							{
								skill = 202;
								break;
							}
							case (int)ClassesOfSpells.Tailoring:
							{
								skill = 197;
								break;
							}
							case (int)ClassesOfSpells.Cooking:
							{
								skill = 185;
								break;
							}
							case (int)ClassesOfSpells.Mining:
							{
								skill = 186;
								break;
							}
						}
						Skill sk = c.AllSkills[ (ushort)skill ];
						if ( sk != null && sk.Current < sk.Cap( c ) && c.SkillUp( sk.Current, 30, 1 ) )
						{
							sk.Current++;
							( c as Character ).SendSkillUpdate();
						}
					}
				}
				return;
			}
		}
		public override int CastingTime( Mobile from )
		{
			return 2500;
		}
	}
}
