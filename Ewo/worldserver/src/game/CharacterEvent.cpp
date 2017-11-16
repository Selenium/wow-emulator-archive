// Copyright (C) 2006 Team Evolution
#include "Character.h"
//all interupts will owerride base function if they return 1;

//when creating a player if we wanna ad custom items or spells
uint8 Character::On_Player_Create(Character *p_char)
{return 0;}

//when player logs in if we want to display some special message or somthing
uint8 Character::On_Player_Login(Character *p_char)
{return 0;}

//incase we wanna implement interrupts for spells(on event spells)
//internal type will say if it is blockable, spell, melee ..
uint8 Character::On_Player_Take_DMG(Character *p_char,uint32 DMG,uint8 internal_type)
{return 0;}

//if we wanna send a global message to others
uint8 Character::On_Player_Just_Died(Character *p_char)
{return 0;}

//on player logout / exit is called
uint8 Character::On_Player_Log_Out(Character *p_char)
{return 0;}

uint8 Character::On_Player_Update(Character *p_char)
{return 0;}
