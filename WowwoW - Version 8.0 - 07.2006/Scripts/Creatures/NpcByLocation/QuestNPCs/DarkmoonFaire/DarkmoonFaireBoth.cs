using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class YebbNeblegear : BaseNPC
	{
		public YebbNeblegear() : base()
		{
			Id = 14829;
			Level = RandomLevel( 55 );
			Name = "Yebb Neblegear";
			Model = 14856;
			AttackSpeed = 1344;
			CombatReach = 0.9f;
			BoundingRadius = 0.6f;
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
			NpcType = (int)NpcTypes.Humanoid;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class Sayge : BaseNPC
	{
		public Sayge() : base()
		{
			Id = 14822;
			Level = RandomLevel( 55 );
			Name = "Sayge";
			Guild = "Darkmoon Faire Fortune Teller";
			NpcText00 = "Greetings $N.";
			Model = 491;
			AttackSpeed = 1344;
			CombatReach = 0.9f;
			BoundingRadius = 0.6f;
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
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class Chronos : BaseNPC
	{
		public Chronos() : base()
		{
			Id = 14833;
			Level = RandomLevel( 55 );
			Name = "Chronos";
			Guild = "He Who Never Forgets!";
			NpcText00 = "My memory is as shard as a nail, if I saw it, I remember it, trust me, do not doubt my memory.";
			Model = 14875;
			AttackSpeed = 1344;
			CombatReach = 0.9f;
			BoundingRadius = 0.6f;
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
			NpcFlags = (int)NpcActions.SpiritHealer;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	
	
}