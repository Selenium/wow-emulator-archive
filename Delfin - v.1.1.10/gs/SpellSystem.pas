unit SpellSystem;

interface

uses
    Windows, SysUtils, AcedContainers, WorldObject, CharHandler, CharConst,
    ItemHandler, SpellConst, OpConst, Classes, SyncObjs,
    ByteArrayHandler, DbcFieldsConst, MapHandler, TimedQueue, AcedConsts,
    OpcodeHandler, Formulas, UpdateConst, SpellPublic;

type TSpellSystem = class
  private
  public
    procedure Init;
    procedure CMSG_CAST_SPELL_handler(Sender: TPlayer);
    procedure CMSG_CANCEL_CAST_handler(Sender: TPlayer);
end;

TSpell = class
  private
    { spell cast unique identifier }
    suid                : integer;

    { caster }
    castPlayer          : TPlayer;
    spellCaster         : TMobile;
    castResult          : integer;

    { service information about spell }
    entry               : PPackedSpellRecord;
    triggerSpell        : PPackedSpellRecord;

    { locations }
    
    srcX, srcY, srcZ    : single;
    destX, destY, destZ : single;

    { cast targets }
    target_flags        : word;

    target_unit         : TMobile;
    target_object       : TGameObject;
    target_item         : TItem;
    target_string       : string;

    target_list_units   : TArrayList;
    target_list_items   : TArrayList;
    target_list_gobjs   : TArrayList;

    { spell properties }
    state               : SpellState;

    timer               : integer;
    requiredPower       : integer;

    i_startPositionX    : single;
    i_startPositionY    : single;
    i_startPositionZ    : single;

    targetCount         : integer;
    isTriggered         : boolean;
    areaAura            : boolean;

    castItem            : TItem;

    function    CanCast : integer;
    procedure   CalculateParameters;

    procedure   SendSpellGo;
    procedure   SendSpellResult(spellResult : word);
    procedure   SendInterrupted(cause : byte);
    procedure   SendChannelUpdate(timeValue : integer);

    procedure   ConsumeStuff;
    procedure   HandleEffects(munit : TMobile; item : TItem; gobj : TGameObject; i : longword);

    procedure   ReadAllTargets(inBuf : TReceiveOpcodeArr);
    procedure   WriteAllTargets(outBuf : TSendOpcodeArr);
    procedure   FillTargets;
    procedure   SetTargetMap(i : longword; cur : integer; var TagUnitMap, TagItemMap, TagGOMap : TArrayList);

  public
    constructor Create(Sender : TPlayer; spellIsTriggered : boolean);

    procedure   Start;
    procedure   Cast;
    procedure   Cancel;
    procedure   Finish;
  end;

  SPELL_EFFECT_HandleProc = procedure(spell: TSpell; i : longword);

  procedure     FTimedQueueConsumer(obj: TObject);
  function      FSpellCompare(Item1, Item2 : Pointer) : Integer;

  procedure   SPELL_EFFECT__NULL_HANDLER(spell: TSpell; i : longword);
  procedure   SPELL_EFFECT_SCHOOL_DAMAGE_HANDLER(spell: TSpell; i : longword);
  
var
  SPELL_EFFECT_HandleTable : Array [1..121] of SPELL_EFFECT_HandleProc;
  sp_eff_cntr : integer;
                        
implementation

uses UnitMain;

{TSpellSystem}

function FSpellCompare(Item1, Item2 : Pointer) : Integer;
var
  s1, s2 : TSpell;
begin
  s1 := TSpell(Item1);
  s2 := TSpell(Item2);
  ASSERT( (s1 <> nil)  AND (s2 <> nil) );
  Result := s1.entry.spellPriority - s2.entry.spellPriority;
end;

procedure FTimedQueueConsumer(obj: TObject);
var
  spell   : TSpell;
  aura    : TAura;
begin
  if obj is TSpell then
  begin

    { process spell }

    spell := TSpell(obj);
    spell.Cast;

    { end }

  end else if obj is TAura then begin

    { process aura }

    aura := TAura(obj);

    { end }

  end else begin
    AddToLog('What the hell are you going to do with this damned unknown entry in time queue?');
  end;
end;

procedure TSpellSystem.Init;
var
  t : TTimedQueue;
begin
  t := PrepareTimedQueue;
  t.comparator := FSpellCompare;
  t.consumer := FTimedQueueConsumer;

  TimedQueue.manager := TTimedQueueManager.Create(t);
  TimedQueue.manager.Start;

  AddToLog('Time queue initialized');
end;

procedure TSpellSystem.CMSG_CAST_SPELL_handler(Sender: TPlayer);
var
  spell       : TSpell;
begin
  {1. prepare all targets} {SPELL_STARTING}
  spell := TSpell.Create(Sender, false);
  spell.spellCaster.currentSpell := spell;

  {2. start spell - send message to all surrounders} {SPELL_PREPARING}
  spell.Start;

  {3. if can not be cast then if triggeredByAffect then sendChannelUpdate(0) and m_triggeredByAffect.setDuration(0) endif finish} {SPELL_CANNOTBECAST}
  {4. put spell into queue} {SPELL_CASTING}
end;

procedure TSpellSystem.CMSG_CANCEL_CAST_handler(Sender: TPlayer);
var
  spellID : integer;
  s       : TSpell;
begin
  if Sender.CurrChar.currentSpell = nil then exit;
  
  Sender.ReceiveBuff.Get(spellID);
  AddToLog('CMSG_CANCEL_CAST: spell ID = ' + IntToStr(spellID));
  s := TSpell(Sender.CurrChar.currentSpell);
  if (s.entry.ID = spellID) then
  begin
    // TODO: remove affects if channeled?
    TimedQueue.manager.Remove(s.suid, Sender.CurrChar.currentSpell);
    TSpell(Sender.CurrChar.currentSpell).SendSpellResult($20);
  end;
end;

{TSpell}

constructor TSpell.Create(Sender : TPlayer; spellIsTriggered : boolean);
var
  spellID     : integer;
begin
  ASSERT( Sender <> nil );

  // TODO: what to do when mob casts?
  castPlayer := Sender;  
  spellCaster := Sender.CurrChar;

  Sender.ReceiveBuff.Get(spellID);
  entry := SpellDbcHandler.GetPointerPRValueByIntKey(spellID);
  AddToLog('SPELL: spell ID = ' + IntToStr(spellID));

  ASSERT(entry <> nil);

  state := SPELL_STATE_NULL;

  i_startPositionX := spellCaster.positionX;
  i_startPositionY := spellCaster.positionY;
  i_startPositionZ := spellCaster.positionZ;

  triggerSpell := nil;
  targetCount := 0;
  isTriggered := spellIsTriggered;
  areaAura := false;
  castItem := nil;

  // TODO: implement triggeredByAffect handling

  ReadAllTargets(Sender.ReceiveBuff);

  CalculateParameters;
end;

procedure TSpell.CalculateParameters;
var
  p_time    : PPackedSpellCastTime;
begin

  { timinigs }
  p_time := SpellCastTimesDbcHandler.GetPointerPRValueByIntKey(entry.CastingTimeIndex);
  if p_time <> nil then
  begin
    timer := p_time.castTime
  end else begin
    timer := 0;
  end;

  {
  chanceHit             : single;
  chanceCrit            : single;
  critDamageBonus       : single; // 2.0 for common situation
  chanceAvoidInterrupt  : single;
  damageBonus           : single;

  chargesTotal          : longword;
  chargesOneTime        : longword; // e.g. double attack

  spellLevel            : longword;

  powerType             : longword;
  powerAmount           : longword;
  powerPerSecond        : longword;
  powerPerSecondPerLevel: longword;
  powerCostReduction    : longword; // 0.0 for full-price cast

  range                 : single;
  castTime              : longword;
  interruptible         : boolean;

  threat                : longword; // maybe bigger? ;-)
  }
end;

function TSpell.CanCast : integer;
begin
  // TODO: canCast
  Result := 0;
end;

procedure TSpell.ReadAllTargets(inBuf : TReceiveOpcodeArr);
var
  target      : int64;
begin
    inBuf.Get(target_flags);

    // wtf? always negative condition
    if (target_flags and TARGET_FLAG_SELF) <> 0 then
    begin
      target_unit := spellCaster;

      AddToLog('SPELL: target unit self = ' + IntToStr(target_unit.objGUID));
    end;

    if (target_flags and TARGET_FLAG_UNIT) <> 0 then
    begin
      inBuf.Get(target);
      target_unit := UnitHT_byGUID.Items[target];
      if target_unit = nil then
      begin
        target_unit := PlayerCharsHT_byGUID.Items[target];
      end;

      AddToLog('SPELL: target unit = ' + IntToStr(uint64(target)));
    end;

    if (target_flags and TARGET_FLAG_OBJECT) <> 0 then
    begin
      inBuf.Get(target);
      target_object := UnitHT_byGUID.Items[target];
      AddToLog('SPELL: target object = ' + IntToStr(target));
    end;

    if (target_flags and TARGET_FLAG_ITEM) <> 0 then
    begin
      inBuf.Get(target);
      target_item := UnitHT_byGUID.Items[target];
      AddToLog('SPELL: target item = ' + IntToStr(target));
    end;

    if (target_flags and TARGET_FLAG_SOURCE_LOCATION) <> 0 then
    begin
      inBuf.Get(srcX);
      inBuf.Get(srcY);
      inBuf.Get(srcZ);

      AddToLog('SPELL: target source location = ' + floattostr(srcX) + ' ' + floattostr(srcY) + ' ' + floattostr(srcZ) + ' ');
    end;

    if (target_flags and TARGET_FLAG_DEST_LOCATION) <> 0 then
    begin
      inBuf.Get(destX);
      inBuf.Get(destY);
      inBuf.Get(destZ);

      AddToLog('SPELL: target dest location = ' + floattostr(destX) + ' ' + floattostr(destY) + ' ' + floattostr(destZ) + ' ');
    end;

    if (target_flags and TARGET_FLAG_STRING) <> 0 then
    begin
      AddToLog('SPELL:  target string ');
      inBuf.Get(target_string);
    end;
end;

procedure TSpell.WriteAllTargets(outBuf : TSendOpcodeArr);
begin
    // wtf? always negative condition
    if (target_flags and TARGET_FLAG_SELF) <> 0 then
    begin
      outBuf.Add(int64(target_unit.objGUID));
    end;

    if (target_flags and TARGET_FLAG_UNIT) <> 0 then
    begin
      outBuf.Add(int64(target_unit.objGUID));
    end;

    if (target_flags and TARGET_FLAG_OBJECT) <> 0 then
    begin
      outBuf.Add(int64(target_object.objGUID));
    end;

    if (target_flags and TARGET_FLAG_ITEM) <> 0 then
    begin
      outBuf.Add(int64(target_item.objGUID));
    end;

    if (target_flags and TARGET_FLAG_SOURCE_LOCATION) <> 0 then
    begin
      outBuf.Add(srcX);
      outBuf.Add(srcY);
      outBuf.Add(srcZ);
    end;

    if (target_flags and TARGET_FLAG_DEST_LOCATION) <> 0 then
    begin
      outBuf.Add(destX);
      outBuf.Add(destY);
      outBuf.Add(destZ);
    end;

    if (target_flags and TARGET_FLAG_STRING) <> 0 then
    begin
      outBuf.Add(target_string);
    end;
end;

procedure TSpell.Start;
var
  buf : TSendOpcodeArr;
begin

  buf := TSendOpcodeArr.Create;

  with buf do
  begin
    Init(SMSG_SPELL_START);
    Add(spellCaster.objGUID);
    Add(spellCaster.objGUID);
    Add(Integer(entry.ID));
    Add(Word(0)); // flags ?
    Add(Integer(timer));
    Add(Word(target_flags));
  end;
  WriteAllTargets(buf);
  buf.Add(Integer(0));

  spellCaster.SendMessageToNearby(buf);

  {
  players := GetCharsByRadius(spellCaster.positionX, spellCaster.positionY, spellCaster.positionZ, spellCaster.zoneId);

  node := players.HeadNode;
  while node <> nil do
  begin
    with TPlayer(node.Value).SendBuff do
    begin
      Init(SMSG_SPELL_START);
      Add(spellCaster.objGUID);
      Add(spellCaster.objGUID);
      Add(Integer(entry.ID));
      Add(Word(0)); // flags ?
      Add(Integer(timer));
      Add(Word(target_flags));
    end;
    WriteAllTargets(TPlayer(node.Value).SendBuff);
    TPlayer(node.Value).SendBuff.Add(Integer(0));

    TPlayer(node.Value).SendPacket;

    node := node.NextNode;
  end;
   }

  state := SPELL_STATE_PREPARING;

  castResult := CanCast;

  if castResult <> 0 then
  begin
    // TODO: if spell can not be cast
    {
          if(m_triggeredByAffect)
          [
           SendChannelUpdate(0);
           m_triggeredByAffect->SetDuration(0);
          ]
          finish();
    }
  end;

  if isTriggered then
  begin
    Cast;
  end else begin
    suid := TimedQueue.manager.Insert(Self.timer, Self);
  end;
end;

procedure TSpell.ConsumeStuff;
begin
  // Rage/mana/energy

  //spellCaster.currManaRageEnergy := spellCaster.currManaRageEnergy - requiredPower;

  {
	uint32 currentPower;

	uint8 powerType = m_caster->GetPowerIndex();
	uint16 powerField = UNIT_FIELD_POWER1 + powerType;

	currentPower = m_caster->GetUInt32Value(powerField);

	if(currentPower < m_spellInfo->manaCost)
		m_caster->SetUInt32Value (powerField, 0);
	else
		m_caster->SetUInt32Value (powerField, currentPower - m_spellInfo->manaCost);
  }

  // Combo points
  // TODO: how to check whether spell requires combo points?

  // Items 
end;

procedure TSpell.Cast;
var
  i, eff : longword;
begin
  castResult := CanCast;

  if (castResult = 0) then
  begin
    ConsumeStuff;
    FillTargets;
    //

    if entry.ChannelInterruptFlags <> 0 then
    begin
      state := SPELL_STATE_CASTING;
      //SendChannelStart(GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)));
    end;

    if target_list_units.Count > 0 then
    for eff := 0 to 2 do
    for i := 0 to target_list_units.Count - 1 do
    begin
      HandleEffects(target_list_units.ItemList[i], nil, nil, eff);
    end;

    if target_list_items.Count > 0 then
    for eff := 0 to 2 do
    for i := 0 to target_list_items.Count - 1 do
    begin
      HandleEffects(nil, target_list_items.ItemList[i], nil, eff);
    end;

    if target_list_gobjs.Count > 0 then
    for eff := 0 to 2 do
    for i := 0 to target_list_gobjs.Count - 1 do
    begin
      HandleEffects(nil, nil, target_list_gobjs.ItemList[i], eff);
    end;

    //SendExecute;
    // TODO: handle UNIQUE TARGETS effects
{
	for(iunit= UniqueTargets.begin();iunit != UniqueTargets.end();iunit++)
        [
            if((*iunit)->m_ReflectSpellSchool) reflect(*iunit);
            HandleAddAura((*iunit));
        ]
}
  end;

    SendSpellResult(0);
    SendSpellGo;

  if state <> SPELL_STATE_CASTING then
  begin
    Finish;
  end;

  if castResult = 0 then
  begin
    //TriggerSpell;
  end;
end;

procedure TSpell.Cancel;
begin
   if (state = SPELL_STATE_PREPARING) then
   begin
    SendInterrupted(0);
    SendSpellResult($20);
   end else if(state = SPELL_STATE_CASTING) then
   begin
    // TODO: remove affect from caster
    // caster.RemoveAffect(suid);
    SendChannelUpdate(0);
   end;
    
   finish();
   state := SPELL_STATE_FINISHED;

end;

procedure TSpell.Finish;
begin
  // TODO: finish spell cast
  state := SPELL_STATE_FINISHED;
  spellCaster.currentSpell := nil;
  {
  if(!m_caster) return;

  m_spellState = SPELL_STATE_FINISHED;
  m_caster->m_meleeSpell = false;
  m_caster->m_canMove = true;

  std::list<DynamicObject*>::iterator i;
  std::list<GameObject*>::iterator k;

  WorldPacket data;

  for(i = m_dynObjToDel.begin() ; i != m_dynObjToDel.end() ; i++)
  [
		data.Initialize(SMSG_GAMEOBJECT_DESPAWN_ANIM);
		data << (*i)->GetGUID();
		m_caster->SendMessageToSet(&data, true);

		data.Initialize(SMSG_DESTROY_OBJECT);
		data << (*i)->GetGUID();
		m_caster->SendMessageToSet(&data, true);
		MapManager::Instance().GetMap((*i)->GetMapId())->Remove((*i), true);
	]

	for(k = m_ObjToDel.begin() ; k != m_ObjToDel.end() ; k++)
  [
		data.Initialize(SMSG_GAMEOBJECT_DESPAWN_ANIM);
		data << (*k)->GetGUID();
		m_caster->SendMessageToSet(&data, true);

		data.Initialize(SMSG_DESTROY_OBJECT);
		data << (*k)->GetGUID();
		m_caster->SendMessageToSet(&data, true);
		MapManager::Instance().GetMap((*k)->GetMapId())->Remove((*k), true);
	]

	m_dynObjToDel.clear();
  m_ObjToDel.clear();

	((Player)m_caster)->setRegenTimer(5000);
  }
end;

procedure TSpell.SendInterrupted(cause : byte);
var
  players : TLinkedList;
  node : PLinkedListNode;
begin
  players := GetCharsByRadius(spellCaster.positionX, spellCaster.positionY, spellCaster.positionZ, spellCaster.zoneId);

  node := players.HeadNode;
  while node <> nil do
  begin
    with TPlayer(node.Value).SendBuff do
    begin
      Init(SMSG_SPELL_FAILURE);
      Add(byte($FF));
      Add(spellCaster.ID);
      Add(cause);
    end;
    TPlayer(node.Value).SendPacket;

    node := node.NextNode;
  end;
end;

procedure TSpell.SendSpellResult(spellResult : word);
begin
  if (castPlayer <> nil) then
  begin
    castPlayer.SendBuff.Init(SMSG_CAST_RESULT);
    castPlayer.SendBuff.Add(entry.ID);
    if (spellResult <> 0) then  castPlayer.SendBuff.Add(byte(2));
    castPlayer.SendBuff.Add(spellResult);
    castPlayer.SendPacket;
  end;
end;

procedure TSpell.SendSpellGo;
var
  _buf : TSendOpcodeArr;
begin
  _buf := TSendOpcodeArr.Create;
  with _buf do
  begin
    Init(SMSG_SPELL_GO);
    Add(spellCaster.objGUID);
    Add(spellCaster.objGUID);
    Add(longword(entry.ID));
    Add(Byte($00));
    Add(Word($0101));
    WriteAllTargets(_buf);
    Add(Byte($00));
    Add(word($0002));
    Add(spellCaster.objGUID);
  end;

  spellCaster.SendMessageToNearby(_buf);
end;

procedure TSpell.SendChannelUpdate(timeValue : integer);
begin
  if (castPlayer <> nil) then
  begin
    castPlayer.SendBuff.Init(MSG_CHANNEL_UPDATE);
    castPlayer.SendBuff.Add(timeValue);
    castPlayer.SendPacket;
  end;

  if timeValue = 0 then
  begin
    // TODO: update caster channel-related fields
    {
      m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT,0);
      m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT+1,0);
      m_caster->SetUInt32Value(UNIT_CHANNEL_SPELL,0);
    }
  end;
end;

procedure TSpell.FillTargets;
var
  i   : longword;
begin
  target_list_units := TArrayList.Create;
  target_list_items := TArrayList.Create;
  target_list_gobjs := TArrayList.Create;

  for i := 0 to 2 do
  begin
		SetTargetMap(i, entry.EffectImplicitTargetA[i], target_list_units,
                target_list_items, target_list_gobjs);
		SetTargetMap(i, entry.EffectImplicitTargetB[i], target_list_units,
                target_list_items, target_list_gobjs);
  end;
end;

procedure TSpell.SetTargetMap(i : longword; cur : integer; var TagUnitMap, TagItemMap, TagGOMap : TArrayList);
var
  chars : TLinkedList;
  node  : PLinkedListNode;
  p     : TPlayer;
  sr    : PPackedSpellRaduisRecord;
begin
  case cur of
    TARGET_SELF, TARGET_DY_OBJ, TARGET_SELF_FISHING :
      begin
        if (TagUnitMap.ScanPointer(spellCaster) = -1) then
        TagUnitMap.Add(spellCaster);
      end;
    TARGET_PET :
      begin
        // TODO: TARGET_PET
        // GetUnit(*m_caster,m_caster->GetUInt32Value(UNIT_FIELD_PETNUMBER))
      end;
    TARGET_S_E, TARGET_S_F, TARGET_S_F_2, TARGET_DUELVSPLAYER, TARGET_S_P :
      begin
        if (TagUnitMap.ScanPointer(target_unit) = -1) then
        TagUnitMap.Add(target_unit);
      end;
    TARGET_AE_E :
      begin
        // TODO: TARGET_AE_E ?
      end;
    TARGET_S_GO :
      begin
        if (TagGOMap.ScanPointer(target_object) = -1) then
        TagGOMap.Add(target_object);
      end;
    TARGET_GOITEM :
      begin
        if target_unit <> nil then
        begin
          if (TagUnitMap.ScanPointer(target_unit) = -1) then
          TagUnitMap.Add(target_unit);
        end;
        if target_item <> nil then
        begin
          if (TagItemMap.ScanPointer(target_item) = -1) then
          TagItemMap.Add(target_item);
        end;
      end;
    TARGET_AE_SELECTED :
      begin
        chars := GetCharsByZone(spellCaster.zoneId);
        node := chars.HeadNode;
        while node <> nil do
        begin
          p := tplayer(node);
          if p.CurrChar.state = DEATH_STATE_ALIVE then
          begin
            sr := SpellRadiusDbcHandler.GetPointerPRValueByIntKey(entry.EffectRadiusIndex[i]);
            if (GetDistance(srcX, srcY, srcZ, p.CurrChar.positionX, p.CurrChar.positionY, p.CurrChar.positionZ) <
                sr.radius)
                AND (spellCaster.Faction <> p.CurrChar.Faction)
            then
            begin
              if (TagUnitMap.ScanPointer(p.CurrChar) = -1) then
              TagUnitMap.Add(p.CurrChar);
            end;

          end;

{
         TypeContainerVisitor<MaNGOS::SpellNotifierPlayer, ContainerMapList<Player> > player_notifier(notifier);
         CellLock<GridReadGuard> cell_lock(cell, p);
         cell_lock->Visit(cell_lock, player_notifier, *MapManager::Instance().GetMap(m_caster->GetMapId()));
     ]break;
     }

          node := node.NextNode;
        end;
      end;
    else
      begin
     	// add where custom effects that need default target.
     	//if(m_spellInfo->Effect[i] == 27) TagUnitMap.push_back(m_caster);
     	//else if(m_spellInfo->Effect[i] == 118) TagUnitMap.push_back(m_caster);
      end;
  end;
{
  switch(cur)
  {
     case TARGET_AC_P:
     {
	      Group* pGroup = objmgr.GetGroupByLeader(((Player*)m_caster)->GetGroupLeader());
	      if(pGroup)
	        for(uint32 p=0;p<pGroup->GetMembersCount();p++)
	        {
	           Unit* Target = ObjectAccessor::Instance().FindPlayer(pGroup->GetMemberGUID(p));
	           if(!Target || Target->GetGUID() == m_caster->GetGUID())
	               continue;
	           if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
	               TagUnitMap.push_back(Target);
	        ]
	      else
	        TagUnitMap.push_back(m_caster);
     ]break;
     case TARGET_MINION:
     {
				if(m_spellInfo->Effect[i] != 83) TagUnitMap.push_back(m_caster);
     ]break;
     case TARGET_CHAIN:
     {
         bool onlyParty = false;

         if(!m_targets.m_unitTarget)
         	break;

         Group* pGroup = objmgr.GetGroupByLeader(((Player*)m_caster)->GetGroupLeader());
         for(uint32 p=0;p<pGroup->GetMembersCount();p++)
         {
            if(m_targets.m_unitTarget->GetGUID() == pGroup->GetMemberGUID(p))
            {
               onlyParty = true;
               break;
            ]
         ]
         for(uint32 p=0;p<pGroup->GetMembersCount();p++)
         {
            Unit* Target = ObjectAccessor::Instance().FindPlayer(pGroup->GetMemberGUID(p));

            if(!Target || Target->GetGUID() == m_caster->GetGUID())
                continue;
            if(_CalcDistance(Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ(),m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])) && Target->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) == m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
                TagUnitMap.push_back(Target);
         ]
     ]break;
     case TARGET_AE_E_INSTANT:
     {
	     	CellPair p(MaNGOS::ComputeCellPair(m_caster->GetPositionX(), m_caster->GetPositionY()));
	      Cell cell = RedZone::GetZone(p);
	      cell.data.Part.reserved = ALL_DISTRICT;
	      cell.SetNoCreate();
	      MaNGOS::SpellNotifierCreatureAndPlayer notifier(*this, TagUnitMap, i,PUSH_DEST_CENTER);
	      TypeContainerVisitor<MaNGOS::SpellNotifierCreatureAndPlayer, TypeMapContainer<AllObjectTypes> > object_notifier(notifier);
	      CellLock<GridReadGuard> cell_lock(cell, p);
	      cell_lock->Visit(cell_lock, object_notifier, *MapManager::Instance().GetMap(m_caster->GetMapId()));
     ]break;
     case TARGET_AC_E:
     {
        CellPair p(MaNGOS::ComputeCellPair(m_caster->GetPositionX(), m_caster->GetPositionY()));
        Cell cell = RedZone::GetZone(p);
        cell.data.Part.reserved = ALL_DISTRICT;
        cell.SetNoCreate();
        MaNGOS::SpellNotifierCreatureAndPlayer notifier(*this, TagUnitMap, i,PUSH_SELF_CENTER);
        TypeContainerVisitor<MaNGOS::SpellNotifierCreatureAndPlayer, TypeMapContainer<AllObjectTypes> > object_notifier(notifier);
        CellLock<GridReadGuard> cell_lock(cell, p);
        cell_lock->Visit(cell_lock, object_notifier, *MapManager::Instance().GetMap(m_caster->GetMapId()));
     ]break;
     case TARGET_INFRONT:
     {
        CellPair p(MaNGOS::ComputeCellPair(m_caster->GetPositionX(), m_caster->GetPositionY()));
        Cell cell = RedZone::GetZone(p);
        cell.data.Part.reserved = ALL_DISTRICT;
        cell.SetNoCreate();
        MaNGOS::SpellNotifierCreatureAndPlayer notifier(*this, TagUnitMap, i,PUSH_IN_FRONT);
        TypeContainerVisitor<MaNGOS::SpellNotifierCreatureAndPlayer, TypeMapContainer<AllObjectTypes> > object_notifier(notifier);
        CellLock<GridReadGuard> cell_lock(cell, p);
        cell_lock->Visit(cell_lock, object_notifier, *MapManager::Instance().GetMap(m_caster->GetMapId()));
     ]break;
     case TARGET_AE_E_CHANNEL:
     {
         CellPair p(MaNGOS::ComputeCellPair(m_caster->GetPositionX(), m_caster->GetPositionY()));
         Cell cell = RedZone::GetZone(p);
         cell.data.Part.reserved = ALL_DISTRICT;
         cell.SetNoCreate();
         MaNGOS::SpellNotifierCreatureAndPlayer notifier(*this, TagUnitMap, i,PUSH_DEST_CENTER);
         TypeContainerVisitor<MaNGOS::SpellNotifierCreatureAndPlayer, TypeMapContainer<AllObjectTypes> > object_notifier(notifier);
         CellLock<GridReadGuard> cell_lock(cell, p);
         cell_lock->Visit(cell_lock, object_notifier, *MapManager::Instance().GetMap(m_caster->GetMapId()));
     ]break;
  ]
  }
end;

procedure TSpell.HandleEffects(munit : TMobile; item : TItem; gobj : TGameObject; i : longword);
begin
  if entry.SpellEffectNames[i] = 0 then exit;
  
  //TODO: wtf with this? target_unit becomes something invalid
  target_unit := munit;
  target_item := item;
  target_object := gobj;

  //damage = CalculateDamage((uint8)i);

  AddToLog('SPELLSYSTEM: Spell effect ID is ' + inttostr(entry.SpellEffectNames[i]));
  SPELL_EFFECT_HandleTable[entry.SpellEffectNames[i]](Self, i);
end;

{ SPELL_EFFECT HANDLERS }

procedure SPELL_EFFECT__NULL_HANDLER(spell: TSpell; i : longword);
begin
  AddToLog('SPELLSYSTEM: SPELL_EFFECT__NULL_HANDLER called');
end;

procedure SPELL_EFFECT_SCHOOL_DAMAGE_HANDLER(spell: TSpell; i : longword);
var
  baseDMG, randDMG, DMG, absorb, resist: longword;
begin
  with spell do
  begin

    if (target_unit <> nil) and (target_unit.state = DEATH_STATE_ALIVE) then
    begin

    baseDMG := entry.EffectBasePoints[i];
    randDMG := random(entry.EffectDieSides[i]) + 1;

    DMG := baseDMG + randDMG;

    absorb := 0;
    resist := 0;
    spellCaster.SpellNonMeleeDamageLog(target_unit, spell.entry.ID, DMG, spell.entry.school, absorb, resist, 0);

    AddToLog('SPELLSYSTEM: SPELL_EFFECT_SCHOOL_DAMAGE_HANDLER called, base DMG = ' + inttostr(baseDMG) + ', randDMG = ' + inttostr(randDMG) + ', total DMG = ' + inttostr(DMG));
    end;
  end;
end;

procedure SPELL_EFFECT_TELEPORT_UNITS_HANDLER(spell: TSpell; i : longword); //5
begin
  TCharacter(spell.spellCaster).Hearthstone ;
  AddToLog('SPELLSYSTEM: SPELL_EFFECT_TELEPORT_UNITS_HANDLER called');
end;

procedure SPELL_EFFECT_HEAL_HANDLER(spell: TSpell; i : longword); //10
var
  heal, curhealth, maxhealth: longword ;
begin
  //TODO: уменьшать количество итемов 

  heal := spell.entry^.EffectBasePoints[0] ;
  curhealth := TCharacter(spell.spellCaster).healthCurrValue ;
  MaxHealth := TCharacter(spell.spellCaster).healthMaxValue ;

  if curhealth + heal > MaxHealth then
    TCharacter(spell.spellCaster).Health := MaxHealth
  else
    TCharacter(spell.spellCaster).Health := curhealth + heal ;

  AddToLog('SPELLSYSTEM: SPELL_EFFECT_HEAL_HANDLER called');
end;

procedure SPELL_EFFECT_APPLY_AURA_HANDLER(spell: TSpell; i : longword);
var
  aura : TAura;
  _buf : TSendOpcodeArr;
begin
  with spell do
  begin
    aura := TAura.Create(spell.entry, i);

    aura.duration := PPackedSpellDurationRecord(SpellDurationDbcHandler.GetPointerPRValueByIntKey(entry.duration)).duration;

    // TODO: correct targets
    spell.target_unit.AddPublicAura(aura);

    case entry.EffectApplyAuraName[i] of
      SPELL_AURA_PERIODIC_DAMAGE :
        begin
          // spell.spellCaster.AddPublicAura(aura);
          // TODO: a
        end;
    end;

    AddToLog('SPELLSYSTEM: SPELL_EFFECT_APPLY_AURA_HANDLER called');
  end;

  // TODO: correct targets
  _buf := TSendOpcodeArr.Create;
  spell.target_unit.CreateUpdateValuesBlockForOthers(_buf);
  spell.target_unit.SendMessageToNearby(_buf);
end;

initialization

  for sp_eff_cntr := 1 to pred(length(SPELL_EFFECT_HandleTable))do
  begin
    @SPELL_EFFECT_HandleTable[sp_eff_cntr] := @SPELL_EFFECT__NULL_HANDLER;
  end;

	@SPELL_EFFECT_HandleTable[SPELL_EFFECT_SCHOOL_DAMAGE] := @SPELL_EFFECT_SCHOOL_DAMAGE_HANDLER;
	@SPELL_EFFECT_HandleTable[SPELL_EFFECT_TELEPORT_UNITS] := @SPELL_EFFECT_TELEPORT_UNITS_HANDLER;
	@SPELL_EFFECT_HandleTable[SPELL_EFFECT_HEAL] := @SPELL_EFFECT_HEAL_HANDLER;
	@SPELL_EFFECT_HandleTable[SPELL_EFFECT_APPLY_AURA] := @SPELL_EFFECT_APPLY_AURA_HANDLER;

end.
