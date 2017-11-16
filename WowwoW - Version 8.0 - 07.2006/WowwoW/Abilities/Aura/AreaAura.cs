using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for AreaAura.
	/// </summary>
	public class AreaAura : Aura
	{
		Mobile from;
		float x;
		float y;
		float z;
		int everyXMs;
		int nTime;
		SingleTargetSpellEffect effectHandler;
		float area;

		public AreaAura( Mobile _from, float _x, float _y, float _z, float _area, int _everyXMs, int _nTime, SingleTargetSpellEffect _effectHandler )
		{
			from = _from;
			x = _x;
			y = _y;
			z = _z;
			everyXMs = _everyXMs;
			nTime = _nTime;
			area = _area * _area;
			effectHandler = _effectHandler;
			BaseCreature bc = World.Add( "Imp", x, y, z, _from.MapId );
			bc.Freeze = true;
			bc.AIEngine = null;
			bc.Visible = InvisibilityLevel.GM;
		}


		public class CastTrainerSpell : WowTimer
		{
			Mobile from;
			Mobile caster;
			int toCast;
			int nTime;
			SingleTargetSpellEffect effectHandler;
			float area;

			public CastTrainerSpell( Mobile f, Mobile castr, int cast, float _area, int every, int n, SingleTargetSpellEffect _effectHandler ) :  base( every )
			{
				from = f;
				caster = castr;
				toCast = cast;
				area = _area;
				nTime = n;
				effectHandler = _effectHandler;
			}
			public void whenCast()
			{
				ArrayList targets = null;
				if ( caster is Character )
					targets = ( caster as Character ).Player.KnownObjects;
				else
					if ( caster.LastSeen != null )
					targets = caster.LastSeen.Player.KnownObjects;
				else
					return;
				foreach( Object o in targets )
				{
					if ( o is Mobile )
					{
						Mobile target = o as Mobile;
						if ( target.Distance( from ) < area )
							effectHandler( Abilities.abilities[ toCast ], caster, target );
					}
				}
			}
			public override void OnTick()
			{
				from.FakeCast( toCast, from, new Mobile.WhenDone( this.whenCast ) );
				nTime--;
				if ( nTime <= 0 )
				{
					Stop();
					World.Remove( from, caster );//	remove the invisible mob
				}
				base.OnTick();
			}
		}
	}
}
