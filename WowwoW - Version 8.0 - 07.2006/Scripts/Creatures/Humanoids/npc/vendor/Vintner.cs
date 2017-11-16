//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{

public class JoshuaMaclure : BaseCreature 
 { 
public  JoshuaMaclure() : base() 
 { 
Model = 3328;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Joshua Maclure" ;
Flags1 = 0x08480046 ;
Id = 258 ; 
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
NpcType = 7 ;
BaseHitPoints = 240 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 13, 16 );
NpcText00 = "Greetings $N, I am Joshua Maclure." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Stormwind;
Guild = "Vintner";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

}