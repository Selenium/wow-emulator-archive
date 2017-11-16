using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class ArchDruidFandralStaghelm : BaseNPC
	{
		public ArchDruidFandralStaghelm() : base()
		{
			Name = "Arch Druid Fandral Staghelm";
			Id = 3516;
			Model = 1542;
			Level = RandomLevel(63);
			SetDamage(1f+5.5f*Level,1f+6.5*Level);			
			AttackSpeed = 2000;
			Armor = Level * 52;
			Block = Level +50;
                        ResistArcane = Level*8;
                        ResistFire = Level*10;
                        ResistFrost = Level*8;
                        ResistHoly = Level*8;
                        ResistNature = Level*8;
                        ResistShadow = Level*8;
			Flags1=0x08C91000;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.8f;
			Size = 1.2f;
			Speed = 3.7f;
			WalkSpeed = 3.7f;
			RunSpeed = 6.7f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog ;
			Elite = 3;
			NpcText00="If you are here to waste my time, then you are wasting the time of the Cenarion Circle as a whole.  For your sake, let us hope that you are not foolish enough to be doing just that.";
			Loots = new BaseTreasure[]{  new BaseTreasure(DropsME.MoneyBoss, 100f )};
			/*****************************/
			BCAddon.Hp( this, 77671, 63 );
			/*****************************/
		}
	}
}
