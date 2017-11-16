// (c) AbyssX Group
#include "../WorldEnvironment.h"
#ifdef COMBAT

template <class MeleeHandler> MeleeHandler *Singleton<MeleeHandler>::msSingleton = 0;

void PvsM(void *Param)
{
	PVM *p = (PVM *)Param;

	if(p->ply->GetAttackState() && MonsterHandler::GetSingleton().DistBetween(p->ply, p->mob) < MAX_ATTACK_RANGE && !p->ply->GetGhost() && !p->mob->GetDeadState())
	{
		DoubleWord mPower = MeleeHandler::GetSingleton().DamageCalculation(p->ply);
		MeleeHandler::GetSingleton().PlayerVSMob(p->ply, p->mob, mPower);
#ifdef EVENTSYSTEM
		EventSystem::GetSingleton().AddTimer(p->ply->GetAttackSpeed(), PvsM, (void *)p, MELEEHANDLER, p->ply->GetObjectGuid());
#endif
	}
	else
	{
		MeleeHandler::GetSingleton().StopAttack(p->ply->GetClient(), p->ply->GetObjectGuid(), p->mob->GetObjectGuid());
		delete p;
	}
}

void MvsP(void *Param)
{
	MVP *m = (MVP *)Param;

	if(m->mob->GetAttackState() && MonsterHandler::GetSingleton().DistBetween(m->ply, m->mob) < MAX_FOLLOW_RANGE && !m->ply->GetGhost() && !m->ply->GetDeadState() && !m->mob->GetDeadState())
	{
		if(m->ply->GetPlayerEmote() != 0)
			m->ply->SetPlayerEmote(0);

		DoubleWord mRetroPower = MeleeHandler::GetSingleton().DamageCalculation(m->mob);
		DoubleWord NewTime = m->mob->FollowPlayer(m->ply);

		if(MonsterHandler::GetSingleton().DistBetween(m->ply, m->mob) < MAX_ATTACK_RANGE)
			MeleeHandler::GetSingleton().MobVSPlayer(m->ply, m->mob, mRetroPower);

#ifdef EVENTSYSTEM
		EventSystem::GetSingleton().AddTimer(NewTime, MvsP, (void *)m, MELEEHANDLER, m->mob->GetObjectGuid());
#endif
	}
	else
	{
		m->mob->SetAttackState(false);
		MeleeHandler::GetSingleton().StopAttack(m->ply->GetClient(), m->ply->GetObjectGuid(), m->mob->GetObjectGuid());
		delete m;
	}
}

void PvsP(void *Param)
{
	PVP *pvp = (PVP *)Param;

	if(pvp->ply1->GetAttackState() && !pvp->ply1->GetGhost() && !pvp->ply1->GetDeadState() && !pvp->ply2->GetGhost() && !pvp->ply2->GetDeadState() && PlayersHandler::GetSingleton().DistBetween(pvp->ply1, pvp->ply2) < MAX_ATTACK_RANGE)
	{
		DoubleWord mPower = MeleeHandler::GetSingleton().DamageCalculation(pvp->ply1);
		MeleeHandler::GetSingleton().PlayerVSPlayer(pvp->ply1, pvp->ply2, mPower);

#ifdef EVENTSYSTEM
		EventSystem::GetSingleton().AddTimer(pvp->ply1->GetAttackSpeed(), PvsP, (void *)pvp, MELEEHANDLER, pvp->ply1->GetObjectGuid());
#endif
	}
	else
	{
		MeleeHandler::GetSingleton().StopAttack(pvp->ply1->GetClient(), pvp->ply1->GetObjectGuid(), pvp->ply2->GetObjectGuid());
		delete pvp;
	}
}

MeleeHandler::MeleeHandler()
{
	MobHP = 0;
	PlayerHP = 0;
	mPower = 0;
	mMobExperience = 0;
	PvPSystem = true;
}

MeleeHandler::~MeleeHandler()
{
}

DoubleWord MeleeHandler::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
			case CMSG_ATTACKSWING:
				HandlerMSG_ATTACKSWING(cli, pack);
				return 1;
				break;
			case CMSG_ATTACKSTOP:
				HandlerMSG_ATTACKSTOP(cli, pack);
				return 1;
				break;
	}

	return 0;
}

void MeleeHandler::HandlerMSG_ATTACKSWING(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	if(!ply)
		return; //Shouldn't Happen!

	QuadWord ID = pack->GetQuadWord(0x00);
	Mob *mob = MonsterHandler::GetSingleton().FindMob(ID);
	Player *ply2 = PlayersHandler::GetSingleton().FindPlayer(ID);

	DoCombat(ply ,pack ,mob ,ply2);
}

void MeleeHandler::HandlerMSG_ATTACKSTOP(Client *cli, Packet *pack)
{
	Packet retpack;

	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	if (!ply)
		return; //Shouldn't happens.

	ply->SetAttackState(false);
}

void MeleeHandler::DoCombat(Player *ply, Packet *pack, Mob *monster, Player *ply2)
{
	Packet retpack;

	mPower = DamageCalculation(ply);
	mRetroPower = DamageCalculation(monster);

	if (ply && monster)
	{
		if(ply->GetPlayerEmote() != 0)
			ply->SetPlayerEmote(0);

		if (!ply->GetGhost() && !monster->GetDeadState() && !ply->GetAttackState())
		{
			ply->SetAttackState(true);

			mMobExperience = monster->GetMobExperience();

			PlayerVSMob(ply, monster, mPower);

			PVM *p = new PVM;
			p->ply = ply;
			p->mob = monster;

#ifdef EVENTSYSTEM
			EventSystem::GetSingleton().AddTimer(ply->GetAttackSpeed(), PvsM, (void *)p, MELEEHANDLER, p->ply->GetObjectGuid());
#endif
	
			if (!monster->GetAttackState())
			{
				monster->SetAttackState(true);
				MVP *m = new MVP;
				m->ply = ply;
				m->mob = monster;
#ifdef EVENTSYSTEM
				EventSystem::GetSingleton().AddTimer( 2200, MvsP, (void *)m, MELEEHANDLER, m->mob->GetObjectGuid());
#endif
			}
		}
	}

	if (ply && ply2)
	{
		if(ply->GetPlayerEmote() != 0)
			ply->SetPlayerEmote(0);

		if (PvPSystem)
		{
			if (!ply->GetAttackState() && ply->GetPvPState() && ply2->GetPvPState() && !ply->GetGhost() && !ply2->GetGhost())
			{
				ply->SetAttackState(true);
				PlayerVSPlayer(ply, ply2, mPower);
	
				PVP *pvp = new PVP;
				pvp->ply1 = ply;
				pvp->ply2 = ply2;
				#ifdef EVENTSYSTEM
				EventSystem::GetSingleton().AddTimer(ply->GetAttackSpeed(), PvsP, (void *)pvp, MELEEHANDLER, pvp->ply1->GetObjectGuid());
				#endif
			}
	
			else if (!ply->GetAttackState() && ply->GetFaction() != ply2->GetFaction() && !ply->GetGhost() && !ply2->GetGhost())
			{
				ply->SetAttackState(true);
				PlayerVSPlayer(ply, ply2, mPower);
	
				PVP *pvp = new PVP;
				pvp->ply1 = ply;
				pvp->ply2 = ply2;
	
				#ifdef EVENTSYSTEM
				EventSystem::GetSingleton().AddTimer(ply->GetAttackSpeed(), PvsP, (void *)pvp, MELEEHANDLER, pvp->ply1->GetObjectGuid());
				#endif
			}
	
			if(!ply->GetAttackState() && ply->GetPvPState() && !ply2->GetPvPState() && !ply->GetGhost() && !ply2->GetGhost())
				StopAttack(ply->GetClient(),ply->GetObjectGuid(),ply2->GetObjectGuid());
			else if (!ply->GetAttackState() && ply->GetFaction() != ply2->GetFaction() && !ply->GetGhost() && ply2->GetGhost())
				StopAttack(ply->GetClient(),ply->GetObjectGuid(),ply2->GetObjectGuid());
		}
		else
			StopAttack(ply->GetClient(),ply->GetObjectGuid(),ply2->GetObjectGuid());
	}
}

DoubleWord MeleeHandler::DamageCalculation(Player *ply)
{
	if (!ply)
		return 0;

	//DAMAGE CALCULATION
	DoubleWord damage = 0;
	DoubleWord tempdamage = (ply->mDamages.BPhysicalMAX + ply->mDamages.PPhysicalMAX + ply->mDamages.NPhysicalMAX - ply->mDamages.BPhysicalMIN - ply->mDamages.PPhysicalMIN - ply->mDamages.NPhysicalMIN);
	
	if (tempdamage != 0) 
	{
		int random = rand() % 4;
		if (random != 0)
			damage = ply->mDamages.BPhysicalMIN + ply->mDamages.PPhysicalMIN + ply->mDamages.NPhysicalMIN + (rand() % tempdamage);
		else
			damage = 0;
	} 
	else
		damage = tempdamage;
	//DAMAGE CALCULATION

		return damage;
}

DoubleWord MeleeHandler::DamageCalculation(Mob *mob)
{
	if (!mob)
		return 0;

	//DAMAGE CALCULATION
	DoubleWord damage = 0;
	DoubleWord tempdamage = (mob->mDamages.BPhysicalMAX - mob->mDamages.BPhysicalMIN);
	
	if (tempdamage != 0) 
	{
		int random = rand() % 4;
		if (random != 0)
			damage = mob->mDamages.BPhysicalMIN + (rand() % tempdamage);
		else
			damage = 0;
	} 
	else
		damage = tempdamage;
	//DAMAGE CALCULATION

		return damage;
}

void MeleeHandler::PlayerVSPlayer(Player *attacker,Player *victim,DoubleWord damage)
{
	Packet retpack;
	//Updates Players to see someone attacking someone.
	retpack.Build(SMSG_ATTACKERSTATEUPDATE);
	if (damage > 0)
		retpack.AddDoubleWord(0x22);
	else
		retpack.AddDoubleWord(0x01);
	retpack.AddQuadWord(attacker->GetObjectGuid());
	retpack.AddQuadWord(victim->GetObjectGuid());
	retpack.AddDoubleWord(damage);
	retpack.AddDoubleWord(0x01);
	retpack.AddByte(0x00);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(damage);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x01);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x00);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, attacker);

	PlayerHP = victim->GetHealth();
	PlayerHP -= damage;

	victim->SetHealth(PlayerHP);

	//Sending the new Player Health to Everyone.
	Packets::UpdateObjectHeader(victim, &retpack);
	
	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	objupd.Touch(ObjectUpdate::UPDPLAYER);

	if (PlayerHP <= 0)
	{
		victim->SetRegenerationStatus(false);
		victim->SetDeadState(true);

		if (victim->IsGM())
			victim->SetStatus(STATUS_DEAD | STATUS_GM);
		else
			victim->SetStatus(STATUS_DEAD);

		StopAttack(attacker->GetClient(), attacker->GetObjectGuid(), victim->GetObjectGuid());

		// 0xAABBCCDD where AA == rest state(1-5), BB == ?, CC == facialhair, DD == chatflags 1=afk,2=dnd=4=gm
		objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_BYTES_2,
			((DoubleWord)victim->GetRestState()       << 24) |
			((DoubleWord)0x00                      << 16) |
			((DoubleWord)victim->GetFacialHairType()  <<  8) |
			((DoubleWord)victim->GetStatus()          <<  0));

		#ifdef CHAMPIOSHIP
		if (ChampioshipHandler::GetSingleton().mChampioshipMode)
		{
			if (victim->GetFaction() == HORDE)
				ChampioshipHandler::GetSingleton().AlliancePoint(attacker);
			if (victim->GetFaction() == ALLIANCE)
				ChampioshipHandler::GetSingleton().HordePoint(attacker);
		}
		#endif
	}

	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, victim->GetHealth());
	
	retpack.AddObjectUpdate(&objupd);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, attacker);

	victim->Recover();
}

void MeleeHandler::PlayerVSMob(Player *ply,Mob *monster,DoubleWord damage)
{
	Packet retpack;
	//Updates Players to see someone attacking someone.
	retpack.Build(SMSG_ATTACKERSTATEUPDATE);
	if (damage > 0)
		retpack.AddDoubleWord(0x22);
	else
		retpack.AddDoubleWord(0x01);
	retpack.AddQuadWord(ply->GetObjectGuid());
	retpack.AddQuadWord(monster->GetObjectGuid());
	retpack.AddDoubleWord(damage);
	retpack.AddDoubleWord(0x01);
	retpack.AddByte(0x00);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(damage);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x01);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x00);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

	MobHP = monster->GetHealth();
	MobHP -= damage;

	monster->SetHealth(MobHP);

	//Sending the new monster Health to Everyone.
	Packets::UpdateObjectHeader(monster, &retpack);
	
	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, monster->GetHealth());
	
	retpack.AddObjectUpdate(&objupd);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

	//Setting up the Dead State.
	if (MobHP <= 0)
	{
		monster->Death(ply);
		LevelGain(ply,monster);
		StopAttack(ply->GetClient(), ply->GetObjectGuid(), monster->GetObjectGuid());
	}
}

void MeleeHandler::MobVSPlayer(Player *ply,Mob *monster,DoubleWord damage)
{
	Packet retpack;
	
	monster->FollowPlayer(ply);

	int HIT = damage - ply->mResistances.BPhysical;
	
	//Updates Players to see someone attacking someone.
	retpack.Build(SMSG_ATTACKERSTATEUPDATE);
	if (HIT > 0)
		retpack.AddDoubleWord(0x22);
	else
		retpack.AddDoubleWord(0x01);
	retpack.AddQuadWord(monster->GetObjectGuid());
	retpack.AddQuadWord(ply->GetObjectGuid());
	retpack.AddDoubleWord(HIT);
	retpack.AddDoubleWord(0x01);
	retpack.AddByte(0x00);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(HIT);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x01);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x00);
	retpack.AddDoubleWord(0x00);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

	PlayerHP = ply->GetHealth();
	PlayerHP -= HIT;

	ply->SetHealth(PlayerHP);

	//Sending the new Player Health to Everyone.
	Packets::UpdateObjectHeader(ply, &retpack);
	
	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	objupd.Touch(ObjectUpdate::UPDPLAYER);

	if (PlayerHP <= 0)
	{
		ply->SetRegenerationStatus(false);
		ply->SetDeadState(true);

		if(ply->IsGM())
			ply->SetStatus(STATUS_DEAD | STATUS_GM);
		else
			ply->SetStatus(STATUS_DEAD);

		StopAttack(ply->GetClient(), ply->GetObjectGuid(), monster->GetObjectGuid());

		// 0xAABBCCDD where AA == rest state(1-5), BB == ?, CC == facialhair, DD == chatflags 1=afk,2=dnd=4=gm
		objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_BYTES_2,
			((DoubleWord)ply->GetRestState()       << 24) |
			((DoubleWord)0x00                      << 16) |
			((DoubleWord)ply->GetFacialHairType()  <<  8) |
			((DoubleWord)ply->GetStatus()          <<  0));
	}

	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, ply->GetHealth());
	
	retpack.AddObjectUpdate(&objupd);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

	ply->Recover();
}

void MeleeHandler::LevelGain(Player *ply, Mob *mob)
{
	Packet retpack;

	ply->SetExperiencePoints(ply->GetExperiencePoints() + mMobExperience);
	
	if (ply->GetExperiencePoints() >= ply->GetExperienceNextLevel())
		ply->LevelUP();

	//Sending The Update of Player Experience :)
	Packets::UpdateObjectHeader(ply, &retpack);

	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	objupd.Touch(ObjectUpdate::UPDPLAYER);
		
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, ply->GetHealth());
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_MAXHEALTH, ply->GetMaximumHealth());
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_LEVEL, ply->GetLevel());
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_XP, ply->GetExperiencePoints());
	objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_NEXT_LEVEL_XP, ply->GetExperienceNextLevel());

	retpack.AddObjectUpdate(&objupd);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

	retpack.Build(SMSG_LOG_XPGAIN);
	retpack.AddQuadWord(0x00);
	retpack.AddDoubleWord(mMobExperience);
	retpack.AddDoubleWord(0x00);
	retpack.AddByte(0x00);
	WorldServer::GetSingleton().WriteData(ply->GetClient(),&retpack);

#ifdef GROUPS
	GroupsHandler::GetSingleton().ShareXP(ply,mMobExperience);
#endif
}

void MeleeHandler::StopAttack(Client *cli, QuadWord GUID1, QuadWord GUID2)
{
	Packet retpack;
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	if (!ply)
		return;

	ply->SetAttackState(false);

	retpack.Build(SMSG_ATTACKSTOP);
	retpack.AddQuadWord(GUID1);
	retpack.AddQuadWord(GUID2);
	retpack.AddDoubleWord(0x00);
	WorldServer::GetSingleton().WriteData(cli, &retpack);
}

#endif