//DrilLer
using System;
using Server.Items;
using Server;


namespace Server.Creatures
{
	public class BlisterpawHyena: BaseCreature 
	 { 
		public  BlisterpawHyena() : base() 
		 { 
			Id = 5426 ;
			Model = 1536;
			AttackSpeed= 2000;
			Name = "Blisterpaw Hyena" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 44,45 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
 
			NpcFlags = 0 ;
			BoundingRadius = 0.575f ;
			CombatReach = 1.725f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.15f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed = 6.2f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1931, 44 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.702089f ) 
,new Loot( typeof( ThickLeather), 7.74338f ) 
,new Loot( typeof( HeavyHide), 0.425879f ) 
,new Loot( typeof( HeavyLeather), 6.3569f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.BlisterpawHyena, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class BonepawHyena: BaseCreature 
	 { 
		public  BonepawHyena() : base() 
		 { 
			Id = 4688 ;
			Model = 10902;
			AttackSpeed= 2000;
			Name = "Bonepaw Hyena" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 33,35 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.65f ;
			CombatReach = 1.95f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.3f;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 611, 33 );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.489796f ) 
,new Loot( typeof( HeavyLeather), 8.2449f ) 
,new Loot( typeof( MediumHide), 0.979592f ) 
,new Loot( typeof( MediumLeather), 27.8367f ) 
				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.BonepawHyena, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class GalakPackhound: BaseCreature 
	 { 
		public  GalakPackhound() : base() 
		 { 
			Id = 4250 ;
			Model = 2726;
			AttackSpeed= 2000;
			Name = "Galak Packhound" ;
			Level = RandomLevel( 24 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.65f ;
			CombatReach = 1.95f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.3f;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 411, 24 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.862069f ) 
,new Loot( typeof( LightLeather), 12.931f ) 
,new Loot( typeof( MediumHide), 2.41379f ) 
,new Loot( typeof( MediumLeather), 12.7586f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.GalakPackhound, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class Giggler: BaseCreature 
	 { 
		public  Giggler() : base() 
		 { 
			Id = 14228 ;
			Model = 2714;
			AttackSpeed= 2000;
			Name = "Giggler" ;
			Level = RandomLevel( 34 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/0.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*61;

			NpcFlags = 0 ;
			BoundingRadius = 0.65f ;
			CombatReach = 1.95f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.3f;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;
			Faction = Factions.EvilBeast;
			Elite = 4;
			BCAddon.Hp( this, 1279, 34 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( MediumLeather), 12.5f ) 
,new Loot( typeof( HeavyLeather), 12.5f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.Giggler, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class HecklefangHyena: BaseCreature 
	 { 
		public  HecklefangHyena() : base() 
		 { 
			Id = 4127 ;
			Model = 2710;
			AttackSpeed= 2000;
			Name = "Hecklefang Hyena" ;
			Level = RandomLevel( 15,16 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.425f ;
			CombatReach = 1.275f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 100;
			Family=25;
			Size = 0.85f;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;
			LearnSpell( 1604, SpellsTypes.Offensive );	
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			BCAddon.Hp( this, 314, 15 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 1.35426f ) 
,new Loot( typeof( LightLeather), 15.9129f ) 
,new Loot( typeof( RuinedLeatherScraps), 9.54932f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.HecklefangHyena, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class HecklefangSnarler: BaseCreature 
	 { 
		public  HecklefangSnarler() : base() 
		 { 
			Id = 4129 ;
			Model = 2711;
			AttackSpeed= 2000;
			Name = "Hecklefang Snarler" ;
			Level = RandomLevel( 18,19 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.525f ;
			CombatReach = 1.5f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1f;
			Speed = 3.01f ;
			WalkSpeed = 3.01f ;
			RunSpeed = 6.01f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 443, 18 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.959936f ) 
,new Loot( typeof( LightLeather), 15.1578f ) 
,new Loot( typeof( MediumHide), 0.448353f ) 
,new Loot( typeof( MediumLeather), 4.24211f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.HecklefangSnarler, 100f ) };
		}
	}	
}





namespace Server.Creatures
{
	public class HecklefangStalker: BaseCreature 
	 { 
		public  HecklefangStalker() : base() 
		 { 
			Id = 4128 ;
			Model = 2712;
			AttackSpeed= 2000;
			Name = "Hecklefang Stalker" ;
			Level = RandomLevel( 22,23 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.575f ;
			CombatReach = 1.5f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.15f;
			Speed = 3.01f ;
			WalkSpeed = 3.01f ;
			RunSpeed = 6.01f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 522, 22 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 1.09718f ) 
,new Loot( typeof( LightLeather), 13.5008f ) 
,new Loot( typeof( MediumHide), 1.68966f ) 
,new Loot( typeof( MediumLeather), 16.4221f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.HecklefangStalker, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class KolkarPackhound: BaseCreature 
	 { 
		public  KolkarPackhound() : base() 
		 { 
			Id = 4316 ;
			Model = 1535;
			AttackSpeed= 2000;
			Name = "Kolkar Packhound" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 13 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.575f ;
			CombatReach = 1.5f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 0.85f;
			Speed = 3.01f ;
			WalkSpeed = 3.01f ;
			RunSpeed = 6.01f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 209, 13 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 5.96099f ) 
,new Loot( typeof( LightHide), 0.778547f ) 
,new Loot( typeof( LightLeather), 9.99528f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.KolkarPackhound, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class MagramBonepaw: BaseCreature 
	 { 
		public  MagramBonepaw() : base() 
		 { 
			Id = 4662 ;
			Model = 2716;
			AttackSpeed= 2000;
			Name = "Magram Bonepaw" ;
			Level = RandomLevel( 37,38 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.575f ;
			CombatReach = 1.5f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 0.85f;
			Speed = 3.201f ;
			WalkSpeed = 3.201f ;
			RunSpeed = 6.201f ;
			BCAddon.Hp( this, 1044, 37 );
			Faction = Factions.MagranClanCentaure;
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 3.49265f ) 
,new Loot( typeof( HeavyHide), 0.551471f ) 
,new Loot( typeof( HeavyLeather), 13.9443f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.MagramBonepaw, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class MaraudineBonepaw: BaseCreature 
	 { 
		public  MaraudineBonepaw() : base() 
		 { 
			Id = 4660 ;
			Model = 2710;
			AttackSpeed= 2000;
			Name = "Maraudine Bonepaw" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 37,38 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.425f ;
			CombatReach = 1.25f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 0.85f;
			Speed = 2.91f ;
			WalkSpeed = 2.91f ;
			RunSpeed = 5.91f ;
			BCAddon.Hp( this, 1044, 37 );
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 3.47826f ) 
,new Loot( typeof( HeavyLeather), 8.69565f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.MaraudineBonepaw, 100f ) };
		}
	}	
}





namespace Server.Creatures
{
	public class MurderousBlisterpaw: BaseCreature 
	 { 
		public  MurderousBlisterpaw() : base() 
		 { 
			Id = 8208 ;
			Model = 1534;
			AttackSpeed= 1800;
			Name = "Murderous Blisterpaw" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 43 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/0.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*61;

			NpcFlags = 0 ;
			BoundingRadius = 1f ;
			CombatReach = 16f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.3f;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;
			Faction = Factions.EvilBeast;
			Elite = 4;
			BCAddon.Hp( this, 2059, 43 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 7.01754f ) 
				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.MurderousBlisterpaw, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class PesterhideHyena: BaseCreature 
	 { 
		public  PesterhideHyena() : base() 
		 { 
			Id = 4248 ;
			Model = 2713;
			AttackSpeed= 2000;
			Name = "Pesterhide Hyena" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 26,27 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.425f ;
			CombatReach = 1.25f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1f;
			Speed = 3.11f ;
			WalkSpeed = 3.11f ;
			RunSpeed =3.11f ;
			Faction = Factions.EvilBeast;
			BCAddon.Hp( this, 728, 26 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 1.44329f ) 
,new Loot( typeof( MediumLeather), 21.8336f ) 
,new Loot( typeof( HeavyHide), 0.717456f ) 
,new Loot( typeof( HeavyLeather), 6.28681f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.PesterhideHyena, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class PesterhideSnarler: BaseCreature 
	 { 
		public  PesterhideSnarler() : base() 
		 { 
			Id = 4249 ;
			Model = 10903;
			AttackSpeed= 2000;
			Name = "Pesterhide Snarler" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 27,29 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.575f ;
			CombatReach = 1.725f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.15f;
			Speed = 3.11f ;
			WalkSpeed = 3.11f ;
			RunSpeed =3.11f ;
			Faction = Factions.EvilBeast;
			BCAddon.Hp( this, 835, 27 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 1.46315f ) 
,new Loot( typeof( MediumLeather), 20.2383f ) 
,new Loot( typeof( HeavyHide), 0.574401f ) 
,new Loot( typeof( HeavyLeather), 5.55825f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.PesterhideSnarler, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class RabidBlisterpaw: BaseCreature 
	 { 
		public  RabidBlisterpaw() : base() 
		 { 
			Id = 5427 ;
			Model = 2609;
			AttackSpeed= 2000;
			Name = "Rabid Blisterpaw" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 47,48 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.65f ;
			CombatReach = 1.95f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.3f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed =3.2f ;
			Faction = Factions.EvilBeast;
			BCAddon.Hp( this, 2482, 47 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.57394f ) 
,new Loot( typeof( ThickLeather), 14.6502f ) 
,new Loot( typeof( RuggedLeather), 3.55187f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.RabidBlisterpaw, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class RabidBonepaw: BaseCreature 
	 { 
		public  RabidBonepaw() : base() 
		 { 
			Id = 4690 ;
			Model = 10271;
			AttackSpeed= 2000;
			Name = "Rabid Bonepaw" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 36,38 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			NpcFlags = 0 ;
			BoundingRadius = 0.575f ;
			CombatReach = 1.725f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.15f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed =6.2f ;
			Faction = Factions.EvilBeast;
			BCAddon.Hp( this, 1482, 36 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 4.91803f ) 
,new Loot( typeof( HeavyHide), 0.58548f ) 
,new Loot( typeof( HeavyLeather), 19.9063f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.RabidBonepaw, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class Ravage: BaseCreature 
	 { 
		public  Ravage() : base() 
		 { 
			Id = 8300 ;
			Model = 10904;
			AttackSpeed= 1200;
			Name = "Ravage" ;
			Level = RandomLevel( 51 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/0.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= Level*61;

			NpcFlags = 0 ;
			BoundingRadius = 1.05f ;
			CombatReach = 1.95f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1f;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;
			RunSpeed = 6.8f ;
			Faction = Factions.EvilBeast;
			Elite = 4;
			BCAddon.Hp( this, 2980, 51 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 4.24242f ) 
,new Loot( typeof( RuggedLeather), 1.81818f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.Ravage, 100f ) };
		}
	}	
}
/*
Description in scarlet file
Scarlet Hound
Scarlet Tracking Hound
*/



namespace Server.Creatures
{
	public class SnickerfangHyena: BaseCreature 
	 { 
		public  SnickerfangHyena() : base() 
		 { 
			Id = 5985;
			Model = 2714;
			AttackSpeed= 2000;
			Name = "Snickerfang Hyena" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 49,50 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.575f ;
			CombatReach = 1.725f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.15f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed =6.3f ;
			BCAddon.Hp( this, 2731, 49 );
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.772798f ) 
,new Loot( typeof( ThickLeather), 10.0464f ) 
,new Loot( typeof( ThickWolfhide), 0.463679f ) 
,new Loot( typeof( RuggedLeather), 3.17951f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.SnickerfangHyena, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class SnorttheHeckler: BaseCreature 
	 { 
		public  SnorttheHeckler() : base() 
		 { 
			Id = 5829;
			Model = 2714;
			AttackSpeed= 2000;
			Name = "Snort the Heckler" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 17);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/0.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*61);

			NpcFlags = 0 ;
			BoundingRadius = 1f ;
			CombatReach = 1.5f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1f;
			Speed = 3.45f ;
			WalkSpeed = 3.45f ;
			RunSpeed =6.45f ;
			Elite = 4;
			Faction = Factions.Monster;
			BCAddon.Hp( this, 386, 17 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.795756f ) 
,new Loot( typeof( LightLeather), 5.57029f ) 
,new Loot( typeof( MediumHide), 0.265252f ) 
,new Loot( typeof( MediumLeather), 2.12202f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.SnorttheHeckler, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class StarvingBlisterpaw: BaseCreature 
	 { 
		public  StarvingBlisterpaw() : base() 
		 { 
			Id = 5425;
			Model = 1535;
			AttackSpeed= 2000;
			Name = "Starving Blisterpaw" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 41,42 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			NpcText00="We use many animal pelts and skins in our creations.";
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.425f ;
			CombatReach = 1.275f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 0.85f;
			Speed = 3.2f ;
			WalkSpeed = 3.2f ;
			RunSpeed =6.2f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1780, 41 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.755462f ) 
,new Loot( typeof( ThickLeather), 9.09024f ) 
,new Loot( typeof( HeavyHide), 0.524982f ) 
,new Loot( typeof( HeavyLeather), 7.93144f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.StarvingBlisterpaw, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class StarvingBonepaw: BaseCreature 
	 { 
		public  StarvingBonepaw() : base() 
		 { 
			Id = 4689;
			Model = 2726;
			AttackSpeed= 2000;
			Name = "Starving Bonepaw" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 30,32 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.425f ;
			CombatReach = 1.275f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 0.85f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed =6.5f ;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 1083, 30 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 1.27922f ) 
,new Loot( typeof( MediumLeather), 11.6453f ) 
,new Loot( typeof( HeavyHide), 0.882223f ) 
,new Loot( typeof( HeavyLeather), 14.1156f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.StarvingBonepaw, 100f ) };
		}
	}	
}





namespace Server.Creatures
{
	public class StarvingSnickerfang: BaseCreature 
	 { 
		public  StarvingSnickerfang() : base() 
		 { 
			Id = 5984;
			Model = 8050;
			AttackSpeed= 2000;
			Name = "Starving Snickerfang" ;
			Flags1 = 0x010 ; 
			Level = RandomLevel( 45,46 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			NpcFlags = 0 ;
			BoundingRadius = 0.5f ;
			CombatReach = 1.5f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1f;
			Speed = 3.26f ;
			WalkSpeed = 3.26f ;
			RunSpeed =6.26f ;
			Faction = Factions.EvilBeast;
			BCAddon.Hp( this, 1994, 45 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.808004f ) 
,new Loot( typeof( ThickLeather), 10.6825f ) 
,new Loot( typeof( ThickWolfhide), 0.425054f ) 
,new Loot( typeof( RuggedLeather), 2.99543f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.StarvingSnickerfang, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class Steelsnap: BaseCreature 
	 { 
		public  Steelsnap() : base() 
		 { 
			Id = 4548;
			Model = 2609;
			AttackSpeed= 2000;
			Name = "Steelsnap" ;
			Level = RandomLevel( 30 );
			Flags1 = 0x010 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.65f ;
			CombatReach = 1.95f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 1.3f;
			Speed = 3.14f ;
			WalkSpeed = 3.14f ;
			RunSpeed =6.14f ;
			Faction = Factions.EvilBeast;
			BCAddon.Hp( this, 563, 30 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.369686f ) 
,new Loot( typeof( MediumLeather), 9.6488f ) 
,new Loot( typeof( HeavyHide), 0.184843f ) 
,new Loot( typeof( HeavyLeather), 2.29205f ) 

				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.Steelsnap, 100f ) };
		}
	}	
}



namespace Server.Creatures
{
	public class TamedHyena: BaseCreature 
	 { 
		public  TamedHyena() : base() 
		 { 
			Id = 4534;
			Model = 1535;
			AttackSpeed= 1200;
			Name = "Tamed Hyena" ;
			Level = RandomLevel( 30 );
			Flags1 = 0x016 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/0.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*35.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.65f ;
			CombatReach = 1.95f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 0.85f;
			Speed = 3.67f ;
			WalkSpeed = 3.67f ;
			RunSpeed =6.67f ;
			Elite = 1;
			Faction = Factions.EvilBeast;
			BCAddon.Hp( this, 1563, 30 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.369686f ) 
,new Loot( typeof( MediumLeather), 9.6488f ) 
,new Loot( typeof( HeavyHide), 0.184843f ) 
,new Loot( typeof( HeavyLeather), 2.29205f ) 
				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.TamedHyena, 100f ) };
		}
	}	
}




namespace Server.Creatures
{
	public class TrackingHound: BaseCreature 
	 { 
		public  TrackingHound() : base() 
		 { 
			Id = 6867;
			Model = 2709;
			AttackSpeed= 1500;
			Name = "Tracking Hound" ;
			Level = RandomLevel( 30 );
			Flags1 = 0x016 ; 
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/0.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*35.2);

			NpcFlags = 0 ;
			BoundingRadius = 0.65f ;
			CombatReach = 1.95f ;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);			
			ManaType=1;
			BaseMana = 0;
			Family=25;
			Size = 0.85f;
			Speed = 3.18f ;
			WalkSpeed = 3.18f ;
			RunSpeed =6.18f ;
			Faction = Factions.Alliance;
			BCAddon.Hp( this, 1563, 30 );
			AIEngine = new AgressiveAnimalAI( this );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.369686f ) 
,new Loot( typeof( MediumLeather), 9.6488f ) 
,new Loot( typeof( HeavyHide), 0.184843f ) 
,new Loot( typeof( HeavyLeather), 2.29205f ) 
				};	
			Loots = new BaseTreasure[]{ new BaseTreasure( HyenaDrops.TrackingHound, 100f ) };
		}
	}	
}




