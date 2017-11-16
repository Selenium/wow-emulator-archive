using System;
using Server.Items;


namespace Server.Creatures
{	public class TorturedSentinel : BaseCreature
	{
		public TorturedSentinel() : base()
		{
			Name = "Tortured Sentinel";
			Id = 12179;
			Model = 12270;
			Level = RandomLevel(56, 57);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.00077550f;
			CombatReach = 1.500f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;

			NpcType = (int)NpcTypes.Undead;
			Size = 1f;
			//Elite=1;
			//Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ), new Item( 8106, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.TorturedSentinel, 100f ),
										  new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2086, 56 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}


namespace Server.Creatures
{	public class DragonmawGrunt : BaseCreature
	{
		public DragonmawGrunt() : base()
		{
			Name = "Dragonmaw Grunt";
			Id = 2102;
			Model = 4927;
			Level = RandomLevel(20,21);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseMana = 300;
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1f;
			LearnSpell( 8042, SpellsTypes.Defensive );
			Equip( new Item( 7478, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.DragonmawGrunt, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
			/*****************************/
			BCAddon.Hp( this, 500, 20 ); 
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}



namespace Server.Creatures
{	public class ScarshieldGrunt : BaseCreature
	{
		public ScarshieldGrunt() : base()
		{
			Name = "Scarshield Grunt";
			Guild="Scarshield Legion";
			Id = 9043;
			Model = 8899;
			Level = RandomLevel(53,54);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 80*Level;
			Block = 5*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 2.9f;
			Faction = Factions.Monster;

			NpcType = (int)NpcTypes.Humanoid;
			Elite=1;
			Size = 1.2f;
			Equip( new Item( 22319, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 22638, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.ScarshieldGrunt, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
			/*****************************/
			BCAddon.Hp( this, 4493, 53 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class TormentedOfficer : BaseCreature
	{
		public TormentedOfficer() : base()
		{
			Name = "Tormented Officer";
			Id = 3873;
			Model = 8899;
			Level = RandomLevel(23,24);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 2000;
			Armor = 80*Level;
			Block = 5*Level;
			Flags1 = 0x080000;
			NpcFlags = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.Monster;
			
			NpcType = 6;
			Elite=1;
			Size = 1.2f;
			Equip( new Item( 7419, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.TormentedOfficer, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
			/*****************************/
			BCAddon.Hp( this, 1790, 23 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}





namespace Server.Creatures
{	public class ArgentOfficerGarush : BaseCreature
	{
		public ArgentOfficerGarush() : base()
		{
			Name = "Argent Officer Garush";
			Guild="The Argent Dawn";
			Id = 10839;
			Model = 10210;
			Level = 60;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x080006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.ArgentDawn;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1f;
			NpcText00="Well met, friend.  I am Officer Garush, and I am a proud member of a world-wide organization known as the Argent Dawn.  Our cause is to fight swifty and mercilessly against any element of evil that surfaces in Azeroth.  We are not a political body, nor do we ever wish to become one.  Our cause is singular, and to that end we call both the Horde and Alliance as friends - friends in the cause of stamping out evil!$B$BFor the Dawn, my $g brother : sister;!";
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.ArgentOfficerGarush, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2558, 60 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class ArgentOfficerPureheart : BaseCreature
	{
		public ArgentOfficerPureheart() : base()
		{
			Name = "Argent Officer Pureheart";
			Guild="The Argent Dawn";
			Id = 10840;
			Model = 10211;
			Level = 60;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x080006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.ArgentDawn;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1f;
			NpcText00="Well met, friend.  I am Officer Pureheart, and I am a proud member of a world-wide organization known as the Argent Dawn.  Our cause is simple - fight swifty and mercilessly against any element of evil that surfaces in Azeroth.  We are not a political body, nor do we ever wish to become one.  To that end we call both the Alliance and the Horde both as friends - friends in the cause of stamping out evil!$B$BFor the Dawn, my $g brother : sister;!";
			Equip( new Item( 23357, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));//, new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.ArgentOfficerPureheart, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2558, 60 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class LieutenantRotimer : BaseCreature
	{
		public LieutenantRotimer() : base()
		{
			Name = "Lieutenant Rotimer";
			Guild="Stormpike Guard Recruitment Officer";
			Id = 13843;
			Model = 13850;
			Level = 60;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 2000;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x0480006;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.StormpikeGuard;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1f;
			Equip( new Item( 23171, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));//, new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.LieutenantRotimer, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2558, 60 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}




namespace Server.Creatures
{	public class FirebrandGrunt : BaseCreature
	{
		public FirebrandGrunt() : base()
		{
			Name = "Firebrand Grunt";
			Guild="Firebrand Legion";
			Id = 9259;
			Model = 9664;
			Level = RandomLevel(56, 57);
			SetDamage(1f+4f*Level,1f+4.5*Level);			
			AttackSpeed = 1100;
			Armor = 60*Level;
			Block = 4*Level;
			Flags1 = 0x080000;
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*1.5f);
			BoundingRadius = 0.3720f;
			CombatReach = 1.500f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.Monster;

			NpcType = (int)NpcTypes.Humanoid;
			Size = 1f;
			Elite = 1;
			Equip( new Item( 23171, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));//, new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( TrashGuardsDrops.FirebrandGrunt, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
			/*****************************/
			BCAddon.Hp( this, 4501, 56 );
			/*****************************/			
		}
public override void OnAddToWorld()
		{
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
		}
	}
}

