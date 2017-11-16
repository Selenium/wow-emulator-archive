using System;
using Server.Items;
using Server;


namespace Server.Creatures
{
	public class Arashethis: BaseCreature 
	 { 
		public  Arashethis() : base() 
		 { 
			Id = 5349 ; 
			Model = 7569;
			AttackSpeed= 2000;
			Name = "Arash-ethis" ;
			Flags1 = 0x010 ;
			Level = RandomLevel( 49 );
			ResistArcane = 85;
			ResistFire = 85;
			ResistFrost = 85;
			ResistHoly = 85;
			ResistNature =85;
			ResistShadow = 85;
			Str = (int)(Level*1.5f);
			Armor=258;
			NpcType = (int)NpcTypes.Beast ;
BaseMana = 0;
ManaType=1; 

			NpcFlags = 00 ;
			BoundingRadius = 1.500000f ;			
			CombatReach = 1.2525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Elite=4; Block=Level+50;
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;			
			RunSpeed = 6.3f ;
			AIEngine = new BerserkerAI( this );
BCAddon.Hp( this, 500, 49 );
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickLeather), 61.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.Arashethis, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class Arikara: BaseCreature 
	 { 
		public  Arikara() : base() 
		 { 
			Id = 10882 ; 
			Model = 10183;
			AttackSpeed= 2000;
			Name = "Arikara" ;
			Guild="Vengeance";
			Level = RandomLevel( 28 );
			Flags1 = 0x012 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);

BaseMana = 100;
ManaType=1;
			NpcFlags = 00 ;
			BoundingRadius = 1.30000f ;			
			CombatReach = 1.0625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 1.3f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;			
			AIEngine = new SpellCasterAI( this );
LearnSpell( 15571, SpellsTypes.Offensive );
BCAddon.Hp( this, 997, 28 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( HeavyLeather), 60.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.Arikara, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class AzzereTheSkyblade: BaseCreature 
	 { 
		public  AzzereTheSkyblade() : base() 
		 { 
			Id = 5834 ; 
			Model = 2702;
			AttackSpeed= 2000;
			Name = "Azzere the Skyblade" ;
			Level = RandomLevel( 25 );
			Flags1 = 0x010 ;
			ResistArcane = 55;
			ResistFire = 55;
			ResistFrost = 55;
			ResistHoly = 55;
			ResistNature =55;
			ResistShadow = 55;
			Str = (int)(Level*1.5f);
			Armor=858;
			NpcType = (int)NpcTypes.Beast ;
			BaseMana = 0;
			ManaType=1;
			NpcFlags = 00 ;
			BoundingRadius = 1.00000f ;			
			CombatReach = 0.80f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);		
			ManaType=0;
			Family=27 ;
			Elite=4; Block=Level+50;
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;
			AIEngine = new BerserkerAI( this );
BCAddon.Hp( this, 622, 25 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 65.0f )
					          ,new Loot( typeof( MediumLeather), 61.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.AzzereTheSkyblade, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class CloudSerpent: BaseCreature 
	 { 
		public  CloudSerpent() : base() 
		 { 
			Id = 4117 ; 
			Model = 2705;
			AttackSpeed= 2000;
			Name = "Cloud Serpent" ;
			Level = RandomLevel( 25,26 );
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.000000f ;			
			CombatReach = 0.8525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.85f;
			Speed = 2.5f ;
			WalkSpeed = 2.5f ;
			RunSpeed = 6.5f ;
			BCAddon.Hp( this, 640, 25 );						
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 70.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 20.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.CloudSerpent, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class DeviateCoiler: BaseCreature 
	 { 
		public  DeviateCoiler() : base() 
		 { 
			Id = 3630 ; 
			Model = 1742;
			AttackSpeed= 2000;
			Name = "Deviate Coiler" ;
			Level = RandomLevel( 15,16 );
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);

BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 0.50000f ;			
			CombatReach = 0.425f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 0.5f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;		
			BCAddon.Hp( this, 802, 15 );	
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.DeviateCoiler, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class DeviateDreadfang: BaseCreature 
	 { 
		public  DeviateDreadfang() : base() 
		 { 
			Id = 5056 ; 
			Model = 3006;
			AttackSpeed= 2000;
			Name = "Deviate Dreadfang" ;
			Level = RandomLevel( 20,21 );
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);

BaseMana = 0;
ManaType=1;
			NpcFlags = 00 ;
			BoundingRadius = 0.50000f ;			
			CombatReach = 0.425f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 0.56f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;			
			RunSpeed = 6.5f ;	
			BCAddon.Hp( this, 1353, 20 );		
			AIEngine = new AgressiveAnimalAI( this );
			//BCAddon.Hp( this, 730, 27 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.DeviateDreadfang, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class DeviateStinglash: BaseCreature 
	 { 
		public  DeviateStinglash() : base() 
		 { 
			Id = 3631 ; 
			Model = 4091;
			AttackSpeed= 2000;
			Name = "Deviate Stinglash" ;
			Level = RandomLevel( 16,17 );
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 0.50000f ;			
			CombatReach = 0.425f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; 
			Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 0.55f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;			
			RunSpeed = 6.5f ;
			BCAddon.Hp( this, 1075, 16 );			
			AIEngine = new AgressiveAnimalAI( this );
			//BCAddon.Hp( this, 730, 27 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.DeviateStinglash, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class DeviateVenomwing: BaseCreature 
	 { 
		public  DeviateVenomwing() : base() 
		 { 
			Id = 5756 ; 
			Model = 4091;
			AttackSpeed= 2000;
			Name = "Deviate Venomwing" ;
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Level = RandomLevel( 20,21 );
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 0.70000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; 
			Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 0.7f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;	
			BCAddon.Hp( this, 1205, 20 );		
			AIEngine = new AgressiveAnimalAI( this );
			//BCAddon.Hp( this, 730, 27 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 60.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.DeviateVenomwing, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class ElderCloudSerpent: BaseCreature 
	 { 
		public  ElderCloudSerpent() : base() 
		 { 
			Id = 4119 ; 
			Model = 2703;
			AttackSpeed= 2000;
			Name = "Elder Cloud Serpent" ;
			Level = RandomLevel( 27,29 );
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 00;
ManaType=1;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.000000f ;			
			CombatReach = 0.8525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 1.33f;
			Speed = 2.6f ;
			WalkSpeed = 2.6f ;
			RunSpeed = 5.6f ;	
			BCAddon.Hp( this, 730, 27 );					
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item( 7449, InventoryTypes.OneHand, 14, 2, 13, 2, 0, 0, 0 ) );			
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( HeavyLeather), 70.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( HeavyHide), 10.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.ElderCloudSerpent, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class GreaterThunderhawk: BaseCreature 
	 { 
		public  GreaterThunderhawk() : base() 
		 { 
			Id = 3249 ; 
			Model = 1974;
			AttackSpeed= 2000;
			Name = "Greater Thunderhawk" ;
			Level = RandomLevel( 23,24 );
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 0.8500000f ;			
			CombatReach = 0.7525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.85f;
			Speed = 2.6f ;
			WalkSpeed = 2.6f ;
			RunSpeed = 5.6f ;						
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 590, 23 );
			Equip( new Item( 18607, InventoryTypes.TwoHanded, 1, 1, 17, 1, 0, 0, 0 ) );			
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( LightLeather), 70.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 10.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.GreaterThunderhawk, 100f ) };
		}
	}	
}

namespace Server.Creatures
{
	public class HakkariFrostwing: BaseCreature 
	 { 
		public  HakkariFrostwing() : base() 
		 { 
			Id = 5291 ; 
			Model = 7569;
			AttackSpeed= 2000;
			Name = "Hakkar'i Frostwing" ;
			Flags1 = 0x010 ;
			Level = RandomLevel( 48,50 );
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
BaseMana = 0;
ManaType=1;
 
			NpcFlags = 00 ;
			BoundingRadius = 0.70000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;			
			RunSpeed = 6.5f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2875, 48 );
			BCAddon.Hp( this, 730, 27 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.HakkariFrostwing, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class HakkariSapper: BaseCreature 
	 { 
		public  HakkariSapper() : base() 
		 { 
			Id = 8336 ; 
			Model = 1336;
			AttackSpeed= 2000;
			Level = RandomLevel( 48,50 );
			Name = "Hakkar'i Sapper" ;
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
BaseMana = 0;
ManaType=1;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.0000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 3.4f ;
			WalkSpeed = 3.4f ;			
			RunSpeed = 6.4f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2875, 48 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.HakkariSapper, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class Hayoc: BaseCreature 
	 { 
		public  Hayoc() : base() 
		 { 
			Id = 14234 ; 
			Model = 7569;
			AttackSpeed= 2000;
			Name = "Hayoc" ;
			Level = RandomLevel( 41 );
			Flags1 = 0x010 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
BaseMana = 0;
ManaType=1;
 
			NpcFlags = 00 ;
			BoundingRadius = 1.0000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 3.4f ;
			WalkSpeed = 3.4f ;			
			RunSpeed = 6.4f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1902, 41 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( RuggedLeather), 60.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.HakkariSapper, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class RogueValeScreecher: BaseCreature 
	 { 
		public  RogueValeScreecher() : base() 
		 { 
			Id = 5308 ; 
			Model = 3204;
			AttackSpeed= 2000;
			Name = "Rogue Vale Screecher" ;
			Level = RandomLevel( 44,46 );
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 8;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 1.1500000f ;			
			CombatReach = 0.8525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.85f;
			Speed = 2.7f ;
			WalkSpeed = 2.7f ;
			RunSpeed = 5.7f ;						
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 2077, 25 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( HeavyLeather), 70.0f )
					          ,new Loot( typeof( ThickHide), 40.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.RogueValeScreecher, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class SpawnofHakkar: BaseCreature 
	 { 
		public  SpawnofHakkar() : base() 
		 { 
			Id = 5708 ; 
			Model = 4065;
			AttackSpeed= 2000;
			Name = "Spawn of Hakkar" ;
			Flags1 = 0x010 ;
			Level = RandomLevel( 51 );
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 1.50000f ;			
			CombatReach = 0.625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 1.5f;
			Speed = 3.4f ;
			WalkSpeed = 3.4f ;			
			RunSpeed = 6.4f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 3450, 51 );
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather), 80.0f )
					          ,new Loot( typeof( ThickLeather), 60.0f )
					          ,new Loot( typeof( RuggedHide), 40.0f )					          
					          ,new Loot( typeof( ThickHide), 20.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.SpawnofHakkar, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class ThunderhawkCloudscraper: BaseCreature 
	 { 
		public  ThunderhawkCloudscraper() : base() 
		 { 
			Id = 3424 ; 
			Model = 1975;
			AttackSpeed= 2000;
			Name = "Thunderhawk Cloudscraper" ;
			Flags1 = 0x010 ;
			Level = RandomLevel( 20,22 );
			ResistArcane = 0;
			ResistFire = 7;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;
			NpcFlags = 00 ;
			BoundingRadius = 0.700000f ;			
			CombatReach = 0.5525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.7f;
			Speed = 2.4f ;
			WalkSpeed = 2.4f ;
			RunSpeed = 5.4f ;						
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 443, 20 );
			Equip( new Item( 20538, InventoryTypes.OneHand, 7, 1, 13, 1, 0, 0, 0 ) );			
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 70.0f )
					          ,new Loot( typeof( LightHide), 40.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.ThunderhawkCloudscraper, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class ThunderhawkHatchling: BaseCreature 
	 { 
		public  ThunderhawkHatchling() : base() 
		 { 
			Id = 3247 ; 
			Model = 1742;
			AttackSpeed= 2000;
			Name = "Thunderhawk Hatchling" ;
			Flags1 = 0x010 ;
			Level = RandomLevel( 18,20 );
			ResistArcane = 0;
			ResistFire = 7;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 0.500000f ;			
			CombatReach = 0.4525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.5f;
			Speed = 2.4f ;
			WalkSpeed = 2.4f ;
			RunSpeed = 5.4f ;						
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 315, 20 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather), 80.0f )
					          ,new Loot( typeof( MediumLeather), 70.0f )
					          ,new Loot( typeof( LightHide), 40.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.ThunderhawkHatchling, 100f ) };
		}
	}	
}


namespace Server.Creatures
{
	public class ValeScreecher: BaseCreature 
	 { 
		public  ValeScreecher() : base() 
		 { 
			Id = 5307 ; 
			Model = 2699;
			AttackSpeed= 2000;
			Name = "Vale Screecher" ;
			Flags1 = 0x010 ;
			Level = RandomLevel( 41,43 );
			ResistArcane = 0;
			ResistFire = 7;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;
 
			NpcFlags = 00 ;
			BoundingRadius = 0.500000f ;			
			CombatReach = 0.4525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.5f;
			Speed = 2.7f ;
			WalkSpeed = 2.7f ;
			RunSpeed = 6.7f ;						
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1876, 41 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather), 80.0f )
					          ,new Loot( typeof( HeavyLeather), 70.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( ThickHide), 20.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.ValeScreecher, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class VenomousCloudSerpent: BaseCreature 
	 { 
		public  VenomousCloudSerpent() : base() 
		 { 
			Id = 4118 ; 
			Model = 10991;
			AttackSpeed= 2000;
			Name = "Venomous Cloud Serpent" ;
			Level = RandomLevel( 26,28 );
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 7;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 0.8500000f ;			
			CombatReach = 0.74525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.85f;
			Speed = 2.6f ;
			WalkSpeed = 2.6f ;
			RunSpeed = 5.6f ;						
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 785, 26 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( HeavyLeather), 20.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 70.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.VenomousCloudSerpent, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class WashtePawne: BaseCreature 
	 { 
		public  WashtePawne() : base() 
		 { 
			Id = 3472 ; 
			Model = 2699;
			AttackSpeed= 2000;
			Name = "Washte Pawne" ;
			Level = RandomLevel( 25 );
			Flags1 = 0x010 ;
			ResistArcane = 0;
			ResistFire = 7;
			ResistFrost = 3;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*20.2);
BaseMana = 0;
ManaType=1;

			NpcFlags = 00 ;
			BoundingRadius = 1.00000f ;			
			CombatReach = 0.74525f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0;
			Family=27 ;
			Faction = Factions.Monster;
			Size = 0.85f;
			Speed = 2.6f ;
			WalkSpeed = 2.6f ;
			RunSpeed = 5.6f ;						
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 785, 25 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( MediumHide), 20.0f )
					          ,new Loot( typeof( LightHide), 30.0f )
					          ,new Loot( typeof( LightLeather), 70.0f )};					          	
			Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.WashtePawne, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class YoungArikara: BaseCreature 
	 { 
		public  YoungArikara() : base() 
		 { 
			Id = 10581 ; 
			Model = 9913;
			AttackSpeed= 2000;
			Name = "Young Arikara" ;
			Level = RandomLevel( 20 );
			Flags1 = 0x076 ;
			ResistArcane = 2;
			ResistFire = 2;
			ResistFrost = 2;
			ResistHoly = 2;
			ResistNature = 2;
			ResistShadow = 2;
			Str = (int)(Level/1.1f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)((Level*32)*(float)1.2);
BaseMana = 0;
ManaType=1;
 
			NpcFlags = 00 ;
			BoundingRadius = 0.5000f ;			
			CombatReach = 0.4625f ;
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			ManaType=0;
			Elite=4; Block=Level+20;
			Family=27;
			Faction = Factions.Monster;
			Size = 0.5f;
			Speed = 3f ;
			WalkSpeed = 3f ;			
			RunSpeed = 6f ;			
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 897, 28 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather), 80.0f )
					          ,new Loot( typeof( HeavyLeather), 60.0f )
					          ,new Loot( typeof( HeavyHide), 20.0f )
					          ,new Loot( typeof( MediumHide), 40.0f )};					          	
			//Loots = new BaseTreasure[]{ new BaseTreasure( WindSerpentDrops.YoungArikara, 100f ) };
		}
	}	
}


