//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class Greshka : BaseCreature 
 { 
public  Greshka() : base() 
 { 
Model = 12689;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Greshka" ;
Flags1 = 0x08400046 ;
Id = 12807 ; 
Guild = "Demon Master";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2025 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 54, 70 );
NpcText00 = "Greetings $N, I am Greshka." ;
BaseMana = 0 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
                           , new GrimoireOfLashOfPainRank2()
                           , new GrimoireOfLashOfPainRank3()
                           , new GrimoireOfLashOfPainRank4()
                           , new GrimoireOfLashOfPainRank5()
                           , new GrimoireOfLashOfPainRank6()
                           , new GrimoireOfSoothingKissRank1()
                           , new GrimoireOfSoothingKissRank2()
                           , new GrimoireOfSoothingKissRank3()
                           , new GrimoireOfSoothingKissRank4()
                           , new GrimoireOfSeduction()
                           , new GrimoireOfLesserInvisibility()
                           , new GrimoireOfDevourMagicRank2()
                           , new GrimoireOfDevourMagicRank3()
                           , new GrimoireOfDevourMagicRank4()
                           , new GrimoireOfTaintedBloodRank1()
                           , new GrimoireOfTaintedBloodRank2()
                           , new GrimoireOfTaintedBloodRank3()
                           , new GrimoireOfTaintedBloodRank4()
                           , new GrimoireOfSpellLockRank1()
                           , new GrimoireOfSpellLockRank2()
                           , new GrimoireOfParanoia()
  } ;

Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 19556, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class Hraug : BaseCreature 
 { 
public  Hraug() : base() 
 { 
Model = 14371;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Hraug" ;
Flags1 = 0x08080066 ;
Id = 12776 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 9 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 384 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 9, 12 );
NpcText00 = "Greetings $N, I am Hraug." ;
BaseMana = 0 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
  } ;

Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class JubahlCorpseseeker : BaseCreature 
 { 
public  JubahlCorpseseeker() : base() 
 { 
Model = 5085;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jubahl Corpseseeker" ;
Flags1 = 0x08480046 ;
Id = 6382 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 60 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2426 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 65, 85 );
NpcText00 = "Greetings $N, I am Jubahl Corpseseeker." ;
BaseMana = 5751 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
                           , new GrimoireOfLashOfPainRank3()
                           , new GrimoireOfLashOfPainRank2()
                           , new GrimoireOfLashOfPainRank4()
                           , new GrimoireOfLashOfPainRank5()
                           , new GrimoireOfLashOfPainRank6()
                           , new GrimoireOfSoothingKissRank1()
                           , new GrimoireOfSoothingKissRank2()
                           , new GrimoireOfSoothingKissRank3()
                           , new GrimoireOfSoothingKissRank4()
                           , new GrimoireOfSeduction()
                           , new GrimoireOfLesserInvisibility()
                           , new GrimoireOfDevourMagicRank2()
                           , new GrimoireOfDevourMagicRank3()
                           , new GrimoireOfDevourMagicRank4()
                           , new GrimoireOfTaintedBloodRank1()
                           , new GrimoireOfTaintedBloodRank2()
                           , new GrimoireOfTaintedBloodRank3()
                           , new GrimoireOfTaintedBloodRank4()
                           , new GrimoireOfSpellLockRank1()
                           , new GrimoireOfSpellLockRank2()
                           , new GrimoireOfParanoia()
  } ;

Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class WrenDarkspring : BaseCreature 
 { 
public  WrenDarkspring() : base() 
 { 
Model = 5093;
AttackSpeed= 1500;
BoundingRadius = 0.351900f ;
Name = "Wren Darkspring" ;
Flags1 = 0x08080066 ;
Id = 6376 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 5 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.725f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Wren Darkspring." ;
BaseMana = 230 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
  } ;

Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class DaneWinslow : BaseCreature 
 { 
public  DaneWinslow() : base() 
 { 
Model = 5087;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Dane Winslow" ;
Flags1 = 0x08080066 ;
Id = 6373 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 8 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 160 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 8, 11 );
NpcText00 = "Greetings $N, I am Dane Winslow." ;
BaseMana = 319 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 21251, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class DannieFizzwizzle : BaseCreature 
 { 
public  DannieFizzwizzle() : base() 
 { 
Model = 5042;
AttackSpeed= 1500;
BoundingRadius = 0.351900f ;
Name = "Dannie Fizzwizzle" ;
Flags1 = 0x08480046 ;
Id = 6328 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 14 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 584 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.725f ;
SetDamage ( 15, 19 );
NpcText00 = "Greetings $N, I am Dannie Fizzwizzle." ;
BaseMana = 710 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
  } ;

Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 0, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class Kitha : BaseCreature 
 { 
public  Kitha() : base() 
 { 
Model = 4728;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Kitha" ;
Flags1 = 0x08480046 ;
Id = 6027 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 17 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 704 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 18, 23 );
NpcText00 = "Greetings $N, I am Kitha." ;
BaseMana = 938 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class Kurgul : BaseCreature 
 { 
public  Kurgul() : base() 
 { 
Model = 4354;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Kurgul" ;
Flags1 = 0x08480046 ;
Id = 5815 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 45 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Kurgul." ;
BaseMana = 3801 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
                           , new GrimoireOfLashOfPainRank2()
                           , new GrimoireOfLashOfPainRank3()
                           , new GrimoireOfLashOfPainRank4()
                           , new GrimoireOfLashOfPainRank5()
                           , new GrimoireOfLashOfPainRank6()
                           , new GrimoireOfSoothingKissRank1()
                           , new GrimoireOfSoothingKissRank2()
                           , new GrimoireOfSoothingKissRank3()
                           , new GrimoireOfSoothingKissRank4()
                           , new GrimoireOfSeduction()
                           , new GrimoireOfLesserInvisibility()
                           , new GrimoireOfDevourMagicRank2()
                           , new GrimoireOfDevourMagicRank3()
                           , new GrimoireOfDevourMagicRank4()
                           , new GrimoireOfTaintedBloodRank1()
                           , new GrimoireOfTaintedBloodRank2()
                           , new GrimoireOfTaintedBloodRank3()
                           , new GrimoireOfTaintedBloodRank4()
                           , new GrimoireOfSpellLockRank1()
                           , new GrimoireOfSpellLockRank2()
                           , new GrimoireOfParanoia()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 5098, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class MarthaStrain : BaseCreature 
 { 
public  MarthaStrain() : base() 
 { 
Model = 4149;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Martha Strain" ;
Flags1 = 0x08400046 ;
Id = 5753 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 20 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 824 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 21, 28 );
NpcText00 = "Greetings $N, I am Martha Strain." ;
BaseMana = 1202 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
                           , new GrimoireOfLashOfPainRank2()
                           , new GrimoireOfLashOfPainRank3()
                           , new GrimoireOfLashOfPainRank4()
                           , new GrimoireOfLashOfPainRank5()
                           , new GrimoireOfLashOfPainRank6()
                           , new GrimoireOfSoothingKissRank1()
                           , new GrimoireOfSoothingKissRank2()
                           , new GrimoireOfSoothingKissRank3()
                           , new GrimoireOfSoothingKissRank4()
                           , new GrimoireOfSeduction()
                           , new GrimoireOfLesserInvisibility()
                           , new GrimoireOfDevourMagicRank2()
                           , new GrimoireOfDevourMagicRank3()
                           , new GrimoireOfDevourMagicRank4()
                           , new GrimoireOfTaintedBloodRank1()
                           , new GrimoireOfTaintedBloodRank2()
                           , new GrimoireOfTaintedBloodRank3()
                           , new GrimoireOfTaintedBloodRank4()
                           , new GrimoireOfSpellLockRank1()
                           , new GrimoireOfSpellLockRank2()
                           , new GrimoireOfParanoia()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 21095, InventoryTypes.RangeRight, 2, 19, 2, 0, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class GinaLang : BaseCreature 
 { 
public  GinaLang() : base() 
 { 
Model = 4176;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Gina Lang" ;
Flags1 = 0x08480046 ;
Id = 5750 ; 
Guild = "Demon Pet Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Gina Lang." ;
BaseMana = 382 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 19557, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class KaylaSmithe : BaseCreature 
 { 
public  KaylaSmithe() : base() 
 { 
Model = 4175;
AttackSpeed= 1500;
BoundingRadius = 0.383000f ;
Name = "Kayla Smithe" ;
Flags1 = 0x08080066 ;
Id = 5749 ; 
Guild = "Demon Pet Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Kayla Smithe." ;
BaseMana = 382 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}
public class SpackleThornberry : BaseCreature 
 { 
public  SpackleThornberry() : base() 
 { 
Model = 3316;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Spackle Thornberry" ;
Flags1 = 0x08480046 ;
Id = 5520 ; 
Guild = "Demon Trainer";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 40 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor +(int)NpcActions.Dialog ;
CombatReach = 1.725f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Spackle Thornberry." ;
BaseMana = 3191 ;
Sells = new Item[] { new GrimoireOfFireboltRank2()
                           , new GrimoireOfFireboltRank3()
                           , new GrimoireOfFireboltRank4()
                           , new GrimoireOfFireboltRank5()
                           , new GrimoireOfFireboltRank6()
                           , new GrimoireOfFireboltRank7()
                           , new GrimoireOfBloodPactRank1()
                           , new GrimoireOfBloodPactRank2()
                           , new GrimoireOfBloodPactRank3()
                           , new GrimoireOfBloodPactRank4()
                           , new GrimoireOfBloodPactRank5()
                           , new GrimoireOfFireShieldRank1()
                           , new GrimoireOfFireShieldRank2()
                           , new GrimoireOfFireShieldRank3()
                           , new GrimoireOfFireShieldRank4()
                           , new GrimoireOfFireShieldRank5()
                           , new GrimoireOfPhaseShift()
                           , new GrimoireOfTormentRank2()
                           , new GrimoireOfTormentRank3()
                           , new GrimoireOfTormentRank4()
                           , new GrimoireOfTormentRank5()
                           , new GrimoireOfTormentRank6()
                           , new GrimoireOfSacrificeRank1()
                           , new GrimoireOfSacrificeRank2()
                           , new GrimoireOfSacrificeRank3()
                           , new GrimoireOfSacrificeRank4()
                           , new GrimoireOfSacrificeRank5()
                           , new GrimoireOfSacrificeRank6()
                           , new GrimoireOfConsumeShadowsRank1()
                           , new GrimoireOfConsumeShadowsRank2()
                           , new GrimoireOfConsumeShadowsRank3()
                           , new GrimoireOfConsumeShadowsRank4()
                           , new GrimoireOfConsumeShadowsRank5()
                           , new GrimoireOfConsumeShadowsRank6()
                           , new GrimoireOfSufferingRank1()
                           , new GrimoireOfSufferingRank2()
                           , new GrimoireOfSufferingRank3()
                           , new GrimoireOfSufferingRank4()
                           , new GrimoireOfLashOfPainRank2()
                           , new GrimoireOfLashOfPainRank3()
                           , new GrimoireOfLashOfPainRank4()
                           , new GrimoireOfLashOfPainRank5()
                           , new GrimoireOfLashOfPainRank6()
                           , new GrimoireOfSoothingKissRank1()
                           , new GrimoireOfSoothingKissRank2()
                           , new GrimoireOfSoothingKissRank3()
                           , new GrimoireOfSoothingKissRank4()
                           , new GrimoireOfSeduction()
                           , new GrimoireOfLesserInvisibility()
                           , new GrimoireOfDevourMagicRank2()
                           , new GrimoireOfDevourMagicRank3()
                           , new GrimoireOfDevourMagicRank4()
                           , new GrimoireOfTaintedBloodRank1()
                           , new GrimoireOfTaintedBloodRank2()
                           , new GrimoireOfTaintedBloodRank3()
                           , new GrimoireOfTaintedBloodRank4()
                           , new GrimoireOfSpellLockRank1()
                           , new GrimoireOfSpellLockRank2()
                           , new GrimoireOfParanoia()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
	public override DialogStatus OnDialogStatus( Character c )
	{
		if ( Reputation( c ) > 0.1f )//	If the character have a good reputation for this npc
		{
			return DialogStatus.ChatAvailable;
		}
		return DialogStatus.None;
	}
	public override void OnHello( Character c )
	{
		if(c.Classe == Classes.Warlock) { c.ShowMobileInventory( Guid ); }
		else
		{ c.ResponseMessage( this, 1, "I am sorry "+ c.Name+ ", but you my friend are not a Warlock!" ); }
		
	}
	public override void DialogCharacterSelection( Character c, int id, int resp )
	{
		if ( id == 1 )
		{
			c.EndGossip();
		}
	}
}

	
}
