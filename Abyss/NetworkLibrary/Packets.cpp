// (c) AbyssX Group
#include "../WorldServer/WorldEnvironment.h"

Packets::Packets()
{
}

Packets::~Packets()
{
}

void Packets::NewObjectHeader(Player *ply, Packet *pack, bool curplayer)
{
	pack->Build(SMSG_UPDATE_OBJECT);
	
	// First, the A9 packet header
	pack->AddDoubleWord(1);                   // OP count

	// Now the operation(s)
	pack->AddByte(0);
	pack->AddByte(2);                         // OP (2 == create object)
	pack->AddQuadWord(ply->GetObjectGuid());  // Guid
	pack->AddByte(4);                         // Object tpye (4 == player)
	
	// Now the movement update block
	pack->AddDoubleWord(0);                   // Movement flags
	pack->AddDoubleWord(0);                   // Extended Movement flags
	pack->AddFloat(ply->GetXCoordinate());    // X
	pack->AddFloat(ply->GetYCoordinate());    // Y
	pack->AddFloat(ply->GetZCoordinate());    // Z
	pack->AddFloat(ply->GetFacing());         // Facing
	pack->AddFloat(WALK_SPEED);               // Walk Speed
	pack->AddFloat(RUN_SPEED);                // Run Speed
	pack->AddFloat(RUN_SPEED/2);              // Run Speed BackWards
	pack->AddFloat(SWIM_SPEED);               // Swim Speed
	pack->AddFloat(SWIM_SPEED/2);             // Swim Speed BackWards
	pack->AddFloat(TURN_SPEED);               // Turn Speed
	// Now back to the operation data
	if (curplayer)
	{	
		pack->AddDoubleWord(1);                 // Flags (1 == client player)
		pack->AddDoubleWord(1);                 // Attack Cycle?
	}
	else
	{
		pack->AddDoubleWord(0);                 // Flags (0 == other player)
		pack->AddDoubleWord(0);                 // Attack Cycle?
	}

	pack->AddDoubleWord(0);                   // Timer Id
	pack->AddDoubleWord(0);                   // Victim Guid
	pack->AddDoubleWord(0);                   // Victim Guid
}

void Packets::NewObjectHeader(Mob *mob, Packet *pack)
{
	pack->Build(SMSG_UPDATE_OBJECT);
	
	// First, the A9 packet header
	pack->AddDoubleWord(1);                   // OP count

	// Now the operation(s)
	pack->AddByte(0);
	pack->AddByte(2);                         // OP (2 == create object)
	pack->AddQuadWord(mob->GetObjectGuid());  // Guid
	pack->AddByte(3);                         // Object tpye (3 == Mob)

	// Now the movement update block
	pack->AddDoubleWord(0);                   // Movement flags
	pack->AddDoubleWord(0);                   // Extended Movement flags
	pack->AddFloat(mob->GetXCoordinate());    // X
	pack->AddFloat(mob->GetYCoordinate());    // Y
	pack->AddFloat(mob->GetZCoordinate());    // Z
	pack->AddFloat(mob->GetFacing());         // Facing
	pack->AddFloat(WALK_SPEED);               // Walk Speed
	pack->AddFloat(RUN_SPEED);                // Run Speed
	pack->AddFloat(RUN_SPEED/2);              // Run Speed BackWards
	pack->AddFloat(SWIM_SPEED);               // Swim Speed
	pack->AddFloat(SWIM_SPEED/2);             // Swim Speed BackWards
	pack->AddFloat(TURN_SPEED);               // Turn Speed
	// Now back to the operation data
	pack->AddDoubleWord(0);                   // Flags (0 == other player)
	pack->AddDoubleWord(0);                   // Attack Cycle?
	pack->AddDoubleWord(0);                   // Timer Id?
	pack->AddDoubleWord(0);                   // Victim Guid?
	pack->AddDoubleWord(0);                   // Victim Guid?
}

#ifdef ITEMS
void Packets::NewItemHeader(Player_Item *pitem, Packet *pack)
{
	pack->Build(SMSG_UPDATE_OBJECT);
	
	// First, the A9 packet header
	pack->AddDoubleWord(1);                 // OP count

	// Now the operation(s)
	pack->AddByte(0);
	pack->AddByte(2);                       // OP (2 == create object)
	pack->AddQuadWord(pitem->GUID);			// Guid
	pack->AddByte(1);                       // Object tpye (1 == Item)
	// Now the movement update block
	pack->AddDoubleWord(0);                 // Movement flags
	pack->AddDoubleWord(0);					// Extended Moviment Flag
	pack->AddFloat(0);						// X
	pack->AddFloat(0);						// Y
	pack->AddFloat(0);						// Z
	pack->AddFloat(0);						// Facing
	pack->AddFloat(0);						// Walk Speed
	pack->AddFloat(0);						// Run Speed
	pack->AddFloat(0);						// Run Speed Backwards
	pack->AddFloat(0);						// Swim Speed
	pack->AddFloat(0);						// Swim Speed Backwards
	pack->AddFloat(0);						// Turn Speed
	// Now back to the operation data

	pack->AddDoubleWord(0);					// Flags (1 == client player)
	pack->AddDoubleWord(0);                 // Attack Cycle?
	pack->AddDoubleWord(0);                 // Timer Id?
	pack->AddQuadWord(0);                   // Victim Guid?
}
#endif

void Packets::NewObjectData(Player *ply, Packet *pack)
{
	ObjectUpdate objupd;

	// Init our class
	objupd.Clear();
	// Tell the class which types in update
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	objupd.Touch(ObjectUpdate::UPDPLAYER);

	// OBJECT type data
	// Guid
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_GUID0,
		(DoubleWord)(ply->GetObjectGuid() >>  0));
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_GUID1,
		(DoubleWord)(ply->GetObjectGuid() >> 32));

	// object type. 0x19 for player?
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_TYPE, 0x19);
	
	// object scale factor
	objupd.AddFieldFloat(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_SCALE_X, ply->GetScale());
	
	// padding
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_PADDING, 0xEEEEEEEE);

	// UNIT type data
	// current health
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, ply->GetHealth());

	// current mana
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_POWER1 , ply->GetMana());

	// max health
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_MAXHEALTH, ply->GetMaximumHealth());
	
	// current mana
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_MAXPOWER1 , ply->GetMaximumMana());

	// level
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_LEVEL, ply->GetLevel());

	// 0xAABBCCDD where AA == ?, BB == ?, CC == ?, DD == ?
	//objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_DYNAMIC_FLAGS,
	//	((DoubleWord)0x00              << 24) |
	//	((DoubleWord)0x00              << 16) |
	//	((DoubleWord)0x00              <<  8) |
	//	((DoubleWord)0x04              <<  0));
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_DYNAMIC_FLAGS, ply->GetDynamicFlags());

	// 0xAABBCCDD where AA == ?, BB == gender, CC == class, DD == race
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BYTES_0,
		((DoubleWord)0x00              << 24) |
		((DoubleWord)ply->GetGender()  << 16) |
		((DoubleWord)ply->GetClass()   <<  8) |
		((DoubleWord)ply->GetRace()    <<  0));
	
	// 0xAABBCCDD where AA == weaponmode, BB == ?, CC == ?, DD == standstate
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BYTES_1,
		((DoubleWord)0xEE              << 24) |
		((DoubleWord)0x00              << 16) |
		((DoubleWord)0xEE              <<  8) |
		((DoubleWord)ply->GetStandState() <<  0));

	// faction
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FACTIONTEMPLATE, ply->GetFaction());

	// Unit Flags
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FLAGS, ply->GetUnitFlags());
	if (ply->IsMounted())
		objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_MOUNTDISPLAYID, ply->GetMountModel());
	// Model ID
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_DISPLAYID, ply->GetObjectModel());

	//Attack Speed (Makes Client Crash with cmath.h without this value).
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BASEATTACKTIME0, ply->GetAttackSpeed());
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BASEATTACKTIME1, 0);

	objupd.AddFieldFloat(ObjectUpdate::UPDUNIT, UNIT_FIELD_COMBATREACH, 2.0f);

	objupd.AddFieldFloat(ObjectUpdate::UPDUNIT, UNIT_FIELD_MINDAMAGE, (Float)(ply->mDamages.BPhysicalMIN));
	objupd.AddFieldFloat(ObjectUpdate::UPDUNIT, UNIT_FIELD_MAXDAMAGE, (Float)(ply->mDamages.BPhysicalMAX));

	// Player data
	//Money
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_FIELD_COINAGE, ply->GetMoney());

	//Rest State Experience
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_REST_STATE_EXPERIENCE, 0);

	//Status / Resistances
	ply->AddStats(&objupd);

	// 0xAABBCCDD where AA == haircolor, BB == hairstyle, CC == face, DD == skin
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_BYTES,
		((DoubleWord)ply->GetHairColor()   << 24) |
		((DoubleWord)ply->GetHairStyle()   << 16) |
		((DoubleWord)ply->GetFaceType()    <<  8) |
		((DoubleWord)ply->GetSkinType()    <<  0));

	// 0xAABBCCDD where AA == rest state(1-5), BB == ?, CC == facialhair, DD == chatflags 1=afk,2=dnd=4=gm
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_BYTES_2,
		((DoubleWord)ply->GetRestState()       << 24) |
		((DoubleWord)0x00                      << 16) |
		((DoubleWord)ply->GetFacialHairType()  <<  8) |
        ((DoubleWord)ply->GetStatus()          <<  0));

	// 0xAABBCCDD where AA == ?, BB == gender, CC == class, DD == race
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_BYTES_3,
		((DoubleWord)0x00              << 24) |
		((DoubleWord)ply->GetRace()    << 16) |
		((DoubleWord)ply->GetClass()   <<  8) |
		((DoubleWord)ply->GetGender()  <<  0));

	// current xp
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_XP, ply->GetExperiencePoints());

	// xp to level
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_NEXT_LEVEL_XP, ply->GetExperienceNextLevel());

	pack->AddObjectUpdate(&objupd);
}

void Packets::NewObjectData(Mob *mob, Packet *pack)
{
	ObjectUpdate objupd;
	
	// Init our class
	objupd.Clear();
	// Tell the class which types in update
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);

  // OBJECT type data
	// Guid
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_GUID0,
		(DoubleWord)(mob->GetObjectGuid() >> 0));
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_GUID1,
		(DoubleWord)(mob->GetObjectGuid() >> 32));
	// object type. 0x19 for player?
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_TYPE, 0x09);
	// object scale factor
	objupd.AddFieldFloat(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_SCALE_X, mob->GetScale());
	// object database id
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_ENTRY, mob->GetEntry());

	// UNIT type data
	// current health
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, mob->GetHealth());
	// max health
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_MAXHEALTH, mob->GetMaximumHealth());
	// level
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_LEVEL, mob->GetLevel());

	//Attack Speed (Makes Client Crash with cmath.h without this value).
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BASEATTACKTIME0, 1000);
	objupd.AddFieldFloat(ObjectUpdate::UPDUNIT, UNIT_FIELD_COMBATREACH, 1.0f);
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FACTIONTEMPLATE, mob->GetFaction());

	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_DISPLAYID, mob->GetObjectModel());

	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_NPC_FLAGS, mob->GetNPCFlags());

	// 0xAABBCCDD where AA == weaponmode, BB == ?, CC == ?, DD == standstate
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BYTES_1,
		((DoubleWord)0x00              << 24) |
		((DoubleWord)0x00              << 16) |
		((DoubleWord)0x00              <<  8) |
		((DoubleWord)mob->GetStandState() <<  0));

	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_DYNAMIC_FLAGS, mob->GetDynamicFlags());
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FLAGS, mob->GetUnitFlags());

	pack->AddObjectUpdate(&objupd);
}

#ifdef ITEMS
void Packets::NewItemData(Player_Item *pitem, Packet *pack)
{
	ObjectUpdate objupd;
	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDITEM);
	
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_GUID0,
		(DoubleWord)(pitem->GUID >>  0));
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_GUID1,
		(DoubleWord)(pitem->GUID >>  32));
	
	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_TYPE, 0x03);
	
	objupd.AddFieldFloat(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_SCALE_X, 1.0f);

	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_ENTRY, pitem->Entry);

	objupd.AddField(ObjectUpdate::UPDOBJECT, OBJECT_FIELD_PADDING, 0xEEEEEEEE);

	objupd.AddField(ObjectUpdate::UPDITEM, ITEM_FIELD_OWNER0,
		(DoubleWord)(pitem->OwnerGuid >>  0));
	
	objupd.AddField(ObjectUpdate::UPDITEM, ITEM_FIELD_OWNER1,
		(DoubleWord)(pitem->OwnerGuid >>  32));

	objupd.AddField(ObjectUpdate::UPDITEM, ITEM_FIELD_CONTAINED0,
		(DoubleWord)(pitem->OwnerGuid >>  0));
	
	objupd.AddField(ObjectUpdate::UPDITEM, ITEM_FIELD_CONTAINED1,
		(DoubleWord)(pitem->OwnerGuid >>  32));
	
	pack->AddObjectUpdate(&objupd);
}
#endif

void Packets::UpdateObjectHeader(Player *ply, Packet *pack)
{
	pack->Build(SMSG_UPDATE_OBJECT);
	pack->AddDoubleWord(1);
	pack->AddByte(0);
	pack->AddByte(0);
	pack->AddQuadWord(ply->GetObjectGuid());
}

void Packets::UpdateObjectHeader(Mob *mob, Packet *pack)
{
	pack->Build(SMSG_UPDATE_OBJECT);
	pack->AddDoubleWord(1);
	pack->AddByte(0);
	pack->AddByte(0);
	pack->AddQuadWord(mob->GetObjectGuid());
}

void Packets::UpdateObjectMoviment(Player *ply, Packet *pack)
{
		pack->Build(SMSG_UPDATE_OBJECT);
		
		// First, the A9 packet header
		pack->AddDoubleWord(1);                   // OP count

		// Now the operation(s)
		pack->AddByte(0);
		pack->AddByte(1);        // op movement update
		pack->AddQuadWord(ply->GetObjectGuid());  // GUID

		// Now the movement update block
		pack->AddDoubleWord(ply->GetMoveFlags()); // Movement flags
		pack->AddDoubleWord(0);					  // Extended Moviment Flags
		pack->AddFloat(ply->GetXCoordinate());    // X
		pack->AddFloat(ply->GetYCoordinate());    // Y
		pack->AddFloat(ply->GetZCoordinate());    // Z
		pack->AddFloat(ply->GetFacing());         // Facing
		if (ply->GetMoveFlags() & MOVEFLAG_SWIMMING)
			pack->AddFloat(ply->GetPitch());
		pack->AddFloat(WALK_SPEED);               // Walk Speed
		pack->AddFloat(RUN_SPEED);                // Run Speed
		pack->AddFloat(RUN_SPEED/2);              // Run Speed BackWards
		pack->AddFloat(SWIM_SPEED);               // Swim Speed
		pack->AddFloat(SWIM_SPEED/2);             // Swim Speed BackWards
		pack->AddFloat(TURN_SPEED);               // Turn Speed
		// Now back to the operation data
		pack->AddDoubleWord(0);                   // Flags (0 == other player)
		pack->AddDoubleWord(0);                   // Attack Cycle?
		pack->AddDoubleWord(0);                   // Timer Id?
		pack->AddDoubleWord(0);                   // Victim Guid?
		pack->AddDoubleWord(0);                   // Victim Guid?
}

void Packets::UpdateObjectMoviment(Mob *mob, Packet *pack)
{
		pack->Build(SMSG_UPDATE_OBJECT);
		
		// First, the A9 packet header
		pack->AddDoubleWord(1);                   // OP count

		// Now the operation(s)
		pack->AddByte(0);
		pack->AddByte(1);        // op movement update
		pack->AddQuadWord(mob->GetObjectGuid());  // GUID

		// Now the movement update block
		pack->AddDoubleWord(0);					  // Movement flags
		pack->AddDoubleWord(0);					  // Extended Moviment Flags
		pack->AddFloat(mob->GetXCoordinate());    // X
		pack->AddFloat(mob->GetYCoordinate());    // Y
		pack->AddFloat(mob->GetZCoordinate());    // Z
		pack->AddFloat(mob->GetFacing());         // Facing
		pack->AddFloat(WALK_SPEED);               // Walk Speed
		pack->AddFloat(RUN_SPEED);                // Run Speed
		pack->AddFloat(RUN_SPEED/2);              // Run Speed BackWards
		pack->AddFloat(SWIM_SPEED);               // Swim Speed
		pack->AddFloat(SWIM_SPEED/2);             // Swim Speed BackWards
		pack->AddFloat(TURN_SPEED);               // Turn Speed
		// Now back to the operation data
		pack->AddDoubleWord(0);                   // Flags (0 == other player)
		pack->AddDoubleWord(0);                   // Attack Cycle?
		pack->AddDoubleWord(0);                   // Timer Id?
		pack->AddDoubleWord(0);                   // Victim Guid?
		pack->AddDoubleWord(0);                   // Victim Guid?
}


