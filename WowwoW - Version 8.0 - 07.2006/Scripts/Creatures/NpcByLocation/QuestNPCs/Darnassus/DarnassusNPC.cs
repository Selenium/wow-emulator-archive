using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class ChiefArchaeologistGreywhisker : BaseNPC
	{
		public ChiefArchaeologistGreywhisker() : base()
		{
			Id = 2912;
			Level = RandomLevel( 40 );
			Name = "Chief Archaeologist Greywhisker";
			Guild = "Explorers' League";
			NpcText00 = "Greetings $N, I am Chief Archaeologist Greywhisker.";
			Model = 1665;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class PriestessAmoora : BaseNPC
	{
		public PriestessAmoora() : base()
		{
			Id = 7313;
			Level = RandomLevel( 20 );
			Name = "Priestess A'moora";
			NpcText00 = "Greetings $N, I am Priestess A'moora.";
			Model = 6348;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class SisterAquinne : BaseNPC
	{
		public SisterAquinne() : base()
		{
			Id = 7316;
			Level = RandomLevel( 15 );
			Name = "Sister Aquinne";
			Guild = "Novice Priestess";
			NpcText00 = "Greetings $N, I am Sister Aquinne.";
			Model = 6349;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class RaedonDuskstriker : BaseNPC
	{
		public RaedonDuskstriker() : base()
		{
			Id = 14725;
			Level = RandomLevel( 35 );
			Name = "Raedon Duskstriker";
			Guild = "Alliance Cloth Quartermaster";
			Model = 14755;
			AttackSpeed = 1623;
			CombatReach = 1.15f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	
	
}