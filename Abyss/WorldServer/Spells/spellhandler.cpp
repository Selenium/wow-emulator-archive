// (c) AbyssX Group
#include "../WorldEnvironment.h"
#ifdef SPELLS

template <class Spells> Spells *Singleton<Spells>::msSingleton = 0;
Spells::Spells()
{
}
Spells::~Spells()
{
}

DoubleWord Spells::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
			case CMSG_CAST_SPELL:
				HandlerMSG_CAST_SPELL(cli, pack);
				return 1;
				break;
	}

	return 0;
}
void Spells::CastSpell(Player *ply, QuadWord TargetGUID, Spell *gospell)
{
	ObjectUpdate objupd;
	Packet resultpack;
	Packet gopack;
	Packet dampack;

	Player *player = PlayersHandler::GetSingleton().FindPlayer(TargetGUID);
	Mob *mob = MonsterHandler::GetSingleton().FindMob(TargetGUID);

	if (mob)
	{
		resultpack.Build(SMSG_CAST_RESULT);
		resultpack.AddDoubleWord(gospell->GetSpellId());
		resultpack.AddByte(0x01);
		WorldServer::GetSingleton().SendToPlayersInRange(&resultpack, ply);

		gopack.Build(SMSG_SPELL_GO);
		gopack.AddQuadWord(ply->GetObjectGuid());
		gopack.AddQuadWord(ply->GetObjectGuid());
		gopack.AddDoubleWord(gospell->GetSpellId());
		gopack.AddByte(0x00);
		gopack.AddWord(0x0101);
		gopack.AddQuadWord(mob->GetObjectGuid());
		gopack.AddByte(0x00);
		gopack.AddByte(0x42);
		gopack.AddByte(0x00);
		gopack.AddQuadWord(mob->GetObjectGuid());
		gopack.AddFloat(mob->GetXCoordinate());
		gopack.AddFloat(mob->GetYCoordinate());
		gopack.AddFloat(mob->GetZCoordinate());
		WorldServer::GetSingleton().SendToPlayersInRange(&gopack, ply);

		dampack.Build(SMSG_SPELLNONMELEEDAMAGELOG);
		dampack.AddQuadWord(mob->GetObjectGuid());
		dampack.AddQuadWord(ply->GetObjectGuid());
		dampack.AddDoubleWord(gospell->GetSpellId());
		dampack.AddDoubleWord(gospell->GetSpellDamage());
		dampack.AddByte(0);				//flag
		dampack.AddDoubleWord(0);		//damage absorbed
		dampack.AddByte(0);				//???
		dampack.AddByte(0);				//???
		dampack.AddDoubleWord(0);		//damage blocked
		WorldServer::GetSingleton().SendToPlayersInRange(&dampack, ply);

		DoubleWord MobHP = mob->GetHealth();
		MobHP -= gospell->GetSpellDamage();

		mob->SetHealth(MobHP);

		//Sending the new Player Health to Everyone.
		Packets::UpdateObjectHeader(mob, &dampack);

		objupd.Clear();
		objupd.Touch(ObjectUpdate::UPDOBJECT);
		objupd.Touch(ObjectUpdate::UPDUNIT);
		objupd.Touch(ObjectUpdate::UPDPLAYER);

		objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, mob->GetHealth());

		dampack.AddObjectUpdate(&objupd);

		WorldServer::GetSingleton().SendToPlayersInRange(&dampack, ply);
		printf("[World-Server] - Casting Spell in the -> MOB: %s\n",mob->GetName().c_str());
	}
	else if (player)
	{
		printf("[World-Server] - Casting Spell in the -> PLAYER: %s\n",player->GetName().c_str());
	}
}
void Spells::HandlerMSG_CAST_SPELL(Client *cli, Packet *pack)
{
	Packet retpack;
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	if(!ply)
		return; //Shouldn't Happen!

	DoubleWord spellID = pack->GetDoubleWord(0x00);
	
	Spell *gospell = new Spell();
	gospell = FindSpell(spellID);

	Word Flag = pack->GetWord(0x04);

	QuadWord Target = pack->GetQuadWord(0x06);

	Mob *mob = MonsterHandler::GetSingleton().FindMob(Target);
	Player *player = PlayersHandler::GetSingleton().FindPlayer(Target);
		
	if (mob)
	{	
		retpack.Build(SMSG_SPELL_START);
		retpack.AddQuadWord(ply->GetObjectGuid());
		retpack.AddQuadWord(ply->GetObjectGuid());
		retpack.AddDoubleWord(gospell->GetSpellId());
		retpack.AddWord(Flag);
		retpack.AddDoubleWord(gospell->GetSpellCastTime());
		retpack.AddWord(Flag);
		retpack.AddQuadWord(mob->GetObjectGuid());

		WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

		printf("[World-Server] - Spell Target (MOB: %s)\n",mob->GetName().c_str());
	}
	else if (player)
	{
		printf("[World-Server] - Spell Target (PLAYER: %s)\n",player->GetName().c_str());
	}

	retpack.Build(MSG_CHANNEL_START);
	retpack.AddDoubleWord(gospell->GetSpellId());
	retpack.AddDoubleWord(gospell->GetSpellCastTime());
	WorldServer::GetSingleton().SendToPlayer(&retpack,ply);
	
	CastSpell(ply, Target, gospell);

	delete gospell;

}
void Spells::LoadBasicSpells()
{
	DoubleWord result;
	char *buffer;

	
	// Fetch the database connection.
	Database *ndb = Database::GetSingletonPtr();

	if (!ndb || !*ndb)
	{
		printf("Couldnt Connect in the Database!\n");
		return;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return;

	snprintf(buffer, 2048, "SELECT * FROM spells;");

	result = ndb->Query(buffer);

	DoubleWord count = 0;

	if (result == 1)
	{
		do
		{
			Field *spellfield = ndb->Fetch();

			Spell *dbspell = new Spell();

			dbspell->SetSpellId(atoi(spellfield[0].Value()));		// ENTRY ID
			dbspell->SetSpellSchool(atoi(spellfield[1].Value()));
			dbspell->SetSpellSchool2(atoi(spellfield[2].Value()));
			dbspell->SetSpellCastTime(atoi(spellfield[3].Value()));
			dbspell->SetSpellCooldownTime(atoi(spellfield[4].Value()));
			dbspell->SetSpellPlylvl(atoi(spellfield[5].Value()));
			dbspell->SetSpellMaxlvl(atoi(spellfield[6].Value()));
			dbspell->SetSpellDuration(atoi(spellfield[7].Value()));
			dbspell->SetSpellPowerType(atoi(spellfield[8].Value()));
			dbspell->SetSpellManaCost(atoi(spellfield[9].Value()));
			dbspell->SetSpellManaCostperlvl(atoi(spellfield[10].Value()));
			dbspell->SetSpellRange(atoi(spellfield[11].Value()));
			dbspell->SetSpellSchool3(atoi(spellfield[12].Value()));
			dbspell->SetSpellRandomDam(atoi(spellfield[13].Value()));
			dbspell->SetSpellSpeed(atoi(spellfield[14].Value()));
			dbspell->SetSpellDamage(atoi(spellfield[15].Value()));
			dbspell->SetSpellRadius(atoi(spellfield[16].Value()));

			mSpells.push_back(dbspell);

			count++;

		} while (ndb->NextRow());
	}
	printf("[World-Server] - (%d)-> Spells Loaded...\n",count);
	delete [] buffer;

}
Spell *Spells::FindSpell(DoubleWord entry)
{
	list<Spell *>::iterator it;

	for (it = mSpells.begin(); it != mSpells.end(); it++)
	{
		if ((*it)->GetSpellId() == entry)
			return (*it);
	}

	return NULL;
}
#endif