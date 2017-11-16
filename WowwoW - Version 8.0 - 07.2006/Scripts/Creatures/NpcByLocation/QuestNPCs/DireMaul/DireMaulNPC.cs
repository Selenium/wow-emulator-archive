using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class CaptainKromcrush : BaseNPC
	{
		public CaptainKromcrush() : base()
		{
			Id = 14325;
			Level = RandomLevel( 56 ,61 );
			Name = "Captain Kromcrush";
			NpcText00 = "Greetings $N, I am Captain Kromcrush.";
			Model = 10169;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
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
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 10.8f )
					, new Loot( typeof( EternalCrown ), 0.06f )
					, new Loot( typeof( EternalSarong ), 0.03f )
					, new Loot( typeof( WarstrikeChestguard ), 0.06f )
					, new Loot( typeof( ExaltedSabatons ), 0.03f )
					, new Loot( typeof( ExaltedHelmet ), 0.03f )
					, new Loot( typeof( SupremeShoes ), 0.06f )
					, new Loot( typeof( SupremeGloves ), 0.06f )
					, new Loot( typeof( SupremeShoulders ), 0.03f )
					, new Loot( typeof( TriumphantSkullcap ), 0.03f )
					, new Loot( typeof( GordokShackleKey ), 9.89f )
					, new Loot( typeof( LibramOfProtection ), 0.23f )
					, new Loot( typeof( GaronaAStudyOnStealthAndTreachery ), 0.54f )
					, new Loot( typeof( CodexOfDefense ), 0.50f )
					, new Loot( typeof( TheArcanistsCookbook ), 0.64f )
					, new Loot( typeof( TheLightAndHowToSwingIt ), 0.50f )
					, new Loot( typeof( HarnessingShadows ), 0.60f )
					, new Loot( typeof( TheGreatestRaceOfHunters ), 0.77f )
					, new Loot( typeof( HolyBolognaWhatTheLightWontTellYou ), 0.47f )
					, new Loot( typeof( FrostShockAndYou ), 0.16f )
					//, new Loot( typeof( TheEmeraldDreamFactOrCarefullyPlannedOutFarcePerpetratedByMyBrother ), 0.47f )
					, new Loot( typeof( FororsCompendiumOfDragonSlaying ), 0.23f )
					, new Loot( typeof( MonstrousGlaive ), 21.7f )
					, new Loot( typeof( KromcrushsChestplate ), 15.6f )
					, new Loot( typeof( MuggersBelt ), 18.7f )
					, new Loot( typeof( BootsOfTheFullMoon ), 19.5f )
					, new Loot( typeof( HappyFunRock ), 0.23f )
					}, 100f ) };
		}
	}
	public class KnotThimblejack : BaseNPC
	{
		public KnotThimblejack() : base()
		{
			Id = 14338;
			Level = RandomLevel( 50 );
			Name = "Knot Thimblejack";
			NpcText00 = "Greetings $N, I am Knot Thimblejack.";
			Model = 14381;
			AttackSpeed = 1413;
			CombatReach = 3.51f;
			BoundingRadius = 0.51f;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class LorekeeperLydros : BaseNPC
	{
		public LorekeeperLydros() : base()
		{
			Id = 14368;
			Level = RandomLevel( 60 );
			Name = "Lorekeeper Lydros";
			NpcText00 = "Greetings $N, I am Lorekeeper Lydros.";
			Model = 14407;
			AttackSpeed = 2100;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
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
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x06;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	
}