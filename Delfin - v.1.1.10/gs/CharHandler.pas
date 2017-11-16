unit CharHandler;

interface

uses
    Windows, Winsock, SysUtils, AcedContainers, WorldObject, CharConst,
    ItemHandler, UpdateConst, ByteArrayHandler, Formulas, SpellPublic, SpellConst;

type
  TCorpse = record
    positionX, positionY, positionZ: Single;
  end;

  TActiveWorldObject = class(TWorldObject)
  private
    {}
  public
        state                     : longword;
mapId, zoneId, oldMapId: word;
    Level, Flags, Model: integer;
    oldPositionX, oldPositionY, oldPositionZ: single;
    Size: single;
    Faction,FactionTemplate,Entry: integer;
    procedure CreateUpdateBlockForOthers(buff: TSendOpcodeArr);
    procedure CreateUpdateValuesBlockForOthers(buff: TSendOpcodeArr);
  end;

  TGameObject = class(TActiveWorldObject)
  private
    {}
  public
    Flags,goType: integer;
    rX, rY, rZ, rR: single;
    constructor Create(mDbcID: integer);
    procedure InitUpdateArray;
    procedure InitUpdateArrayForOthers;
  end;

  TMobile = class(TActiveWorldObject)
  private
    procedure SetHealth(const Value: longword); virtual;
    {}
  public
    { class-related }
    cRace                     : TNCharRace;
    cClass                    : TNCharClass;
    bRace, bClass             : longword;
    mobType                   : longword;
    family                    : longword;
    cType                     : longword;

    { visuals }
    hairFaceSkin              : integer;
    rest_state_f_hair         : integer;

    { group/raid, guild}
    guildID                   : longword;

    { stats }
    basePowerType             : longword;
    powerMaxValue             : array[0..3] of longword;
    healthMaxValue            : longword;

    baseattacktime            : array[0..2]of integer;
    basedamage                : array[0..5]of single;     //min-max mainhand,offhand,ranged

    baseStats                 : array[charStrengthBonus..charSpiritBonus]of integer;     //str,agi,sta,int,spi
    baseResists                   : array[ResistTypePhysical..ResistTypeArcane]of integer;

    { calculated stats }

    powerType                 : longword;
    powerCurrValue            : array[0..3] of longword;
    healthCurrValue           : longword;

    boundingRadius            : single;
    combatReach               : single;

    attackPower               : longword;
    dmgbonus                  : array[0..6,0..1]of single;  //Physical,DmgTypeHoly..DmgTypeArcane: dmgmin-dmgmax
    bonusStats                : array[charStrengthBonus..charSpiritBonus]of integer;    //str,agi,sta,int,spi

    stealth                   : longword;

    resists                   : array[ResistTypePhysical..ResistTypeArcane]of integer;

    currentSpell              : TObject;
    //TODO: a
    publicAuras               : array[0..63] of TAura;
    listAuras                 : TIntegerList; 
    { item information }
    cItems                    : array[EQUIPMENT_SLOT_HEAD..BANK_SLOT_BAG_END]of TItem;
    AmmoId                    : longword;

    { NPC-related }
    npcFlags                  : longword;

    { pets, minions, totems }
    petDisplayId              : longword;
    petLevel                  : longword;
    petCreatureFamily         : longword;

    { messaging }
    function  GetNeighbors : TLinkedList;
    procedure SendMessageToNearby(msg : TSendOpcodeArr);
    procedure Emote(emote_id : longword);

    { damage etc. }
    procedure SpellNonMeleeDamageLog(target : TMobile; spellID : longword; damage, school, absorb, resist, block : longword);
    procedure DealDamage(target : TMobile; damage, procFlag : Integer);
    procedure AddPublicAura(aura : TAura);

    { service }
    constructor Create(mDbcID: integer);
    procedure InitUpdateArray;
    procedure InitUpdateArrayForOthers;

    { custom-managed properties }
    property Health : longword read healthCurrValue write SetHealth;
  end;

  TCharacter = class(TMobile)
  private
    {}
    procedure SetHealth(const Value: longword); override ;
  public
    { settings and general information }
    actionsButtons              : array[0..119]of integer;
    Owner                       : TObject; //TPlayer
    BindingPointMapId,
    BindingPointZoneId          : word;
    pgcr, //pgcr=power,gender,class,race only for players chars!!!
    cXp, cNextLvlXp, copper, restState, Talents: integer;
    BindingPointX, BindingPointY, BindingPointZ, BindingPointR,
      StrengthPerLevel,AgilityPerLevel,StaminaPerLevel,IntellectPerLevel,SpiritPerLevel: single;
    atInn,AFK,DND,inFly: boolean;
    LastLogout: TDateTime;
    cSpells, cSkills, Name, cExploredZones, FriendList, IgnoreList: string;
    ActiveQuests: TArrayList;
    DoneQuests: TIntegerList;
    //DoneObjectives: array[0..19]of int64; //objectives done: hi amount by 6 bit, lo questID, 20 quests * 4 objectives
    GroupLeader: Int64; //guid лидера группы
    IsInGroup: Boolean; //если чар в группе
    IsInvited: Boolean; //Чара уже пригласили в группу
    Tutorials: array[0..7] of Integer; //Массив данных о подсказках
    Selected_guid: Int64; //Выбранный объект
    m_reputation: array [0..63] of Integer;
    m_reputationValues: array [0..63] of Integer;
//    Resting: Boolean; // True если отдыхаешь

    { Items }
    cBagItems: array[INVENTORY_SLOT_BAG_1..INVENTORY_SLOT_BAG_4,0..19] of TItem;
    BankBagItems: array[BANK_SLOT_BAG_1..BANK_SLOT_BAG_6,0..19] of TItem;
    m_buybackitems: array[0..BUYBACK_SLOT_END-1] of TItem; //Buyback items
    CurrentBuybackSlot: Integer; //Последний проданный Item
    { }

    TaxiMask: array[0..7] of Integer; //узлы для такси
    Swim: Boolean;
    Corpse: TCorpse;    
    constructor Create(charGUID: int64; GenerateNewGUID: boolean);
    procedure InitWithCreatePacket;
    procedure CalculateItemsBonusStats;
    procedure SendFullCreateUpdateBlockForPlayer;
    //procedure CreateUpdateBlockForOthers(var buff: array of byte; var data_len: integer);
    procedure SendPartialCreateItemUpdateBlockForPlayer(item: TItem);
    procedure BuildSendCharUpdateBlock;
    procedure LoadItemsSpells;
    procedure InitUpdateArray;
    procedure InitUpdateArrayForOthers;
    procedure RemoveItem(slot: integer);
    procedure RemoveItemFromBag(bag, slot: integer);
    procedure RemoveItemCountFromBag(bag, slot, count: integer);
    function AddItem(item: TItem; slot: integer):boolean;
    function AddItem2Bag(item: TItem; bag, slot: integer):boolean;
    function AddItemCount2Bag(item: TItem; bag, slot, count: integer):boolean;
    function SwapBagItems(srcbag, srcslot, dstbag, dstslot: byte): boolean;
    function CheckBagExists(bag: byte): TInventoryChangeFailure;
    function IsBag_IsEmpty(item: TItem; slot: byte): TInventoryChangeFailure;
    function GetBagItem(bag, slot: byte): TItem;
    function GetInvFreeSlot: Byte;
    function GetBagFreeSlot(bag: Byte): Byte;
    function GetSlotByItemGUID(itemguid: Int64; var bag,slot: Byte): Boolean;
    procedure Teleport(x,y,z,r: single; MapID: Word);
    procedure Hearthstone;
    procedure AddItemToBuyBackSlot(Item: TItem; slot: Integer);
    procedure RemoveItemFromBuyBackSlot(slot: Integer);
    procedure SetCurrentBuybackSlot(slot: Integer);
    procedure SetCopper(NewCopper: Integer);
    procedure AddSpell(spell_id: DWORD);
    procedure EnvironmentalDamage(Guid: Int64; dmg_type: Byte; Amount: Longword) ;
    procedure StartMirrorTimer(TimerType: Byte; MaxValue: Integer);
    procedure StopMirrorTimer(TimerType: Byte);
    procedure Kill;
    procedure SetRunSpeed(Speed: Single);
    procedure SetSwimSpeed(Speed: Single);
    procedure Regenerate;
    procedure GiveXP(XP: Integer);
  end;
  function IsAlliance(race:TNCharRace):boolean;

const
  NEIGHBOR_RADIUS = 100.0;
  
  IsAlly: array[1..10]of boolean = (true,false,true,true,false,false,true,false,false,true);
  LvlXP : array [1..59,0..1] of integer = (
  (400,400),(900,1300),(1400,2700),(2100,4800),(2800,7600),(3600,11200),
  (4500,15700),(5400,21100),(6500,27600),(7600,35200),(8800,44000),
  (10100,54100),(11400,65500),(12900,78400),(14400,92800),(16000,108800),
  (17700,126500),(19400,145900),(21300,167200),(23200,190400),(25200,215600),
  (27300,242900),(29400,272300),(31700,304000),(34000,338000),(36400,374400),
  (38900,413300),(41400,454700),(44300,499000),(47400,546400),(50800,597200),
  (54700,651900),(58600,710500),(62800,773300),(67000,840300),(71600,911900),
  (76100,988000),(80800,1068800),(85700,1154500),(90700,1245200),
  (95800,1341000),(101000,1442000),(106300,1548300),(111800,1660100),
  (117400,1777500),(123200,1900700),(129100,2029800),(135100,2164900),
  (141200,2306100),(147500,2453600),(153900,2607500),(160400,2767900),
  (167100,2935000),(173900,3108900),(180800,3289700),(187900,3477600),
  (195000,3672600),(202300,3874900),(209800,4084700)
  );

implementation

uses OpConst, UnitMain, OpcodeHandler, CellManager,
    DbcFieldsConst, NpcQuestHandler;


function IsAlliance(race:TNCharRace):boolean;
begin
     result:=false;
     if (ord(race)>0)and(ord(race)<11) then result:=IsAlly[ord(race)];
end;

{ TActiveWorldObject }

procedure TActiveWorldObject.CreateUpdateBlockForOthers(buff: TSendOpcodeArr);
begin
		 buff.Init(SMSG_UPDATE_OBJECT);
		 buff.Add(integer(1)); //item count
		 buff.Add(byte(0));

     self.BuildUpdateBlock(UPDATETYPE_CREATE_OBJECT,false,buff);
end;

procedure TActiveWorldObject.CreateUpdateValuesBlockForOthers(buff: TSendOpcodeArr);
begin
		 buff.Init(SMSG_UPDATE_OBJECT);
		 buff.Add(integer(1)); //item count
		 buff.Add(byte(0));

     self.BuildUpdateBlock(UPDATETYPE_VALUES,false,buff);
end;

{ TGameObject }

constructor TGameObject.Create(mDbcID: integer);
var
   pspawn: PPackedSpawnRecord;
begin
     setlength(UpdateArray,integer(GAMEOBJECT_END));
     setlength(UpdateBitsArray,(integer(GAMEOBJECT_END) shr 5)+1);
     updateBitsChanged:=false;
     dbcID:=mDbcID;
     objGUID:=GetGoCorpseUniqGUID;
     objType:=TYPEID_GAMEOBJECT;
     WalkSpeed:=0; RunSpeed:=0; BackwardSpeed:=0; SweemSpeed:=0; SweemBackSpeed:=0; TurnRate:=PI;

     pspawn:=WorldDbcHandler.GetPointerPRValueByIntKey(dbcID);
     ID:=pspawn^.WorldSpawn_SPAWN_GOBJ;
     {TODO through link}

     //actually 90% of that info can be filled directly in "update array"
     Entry:=pspawn^.WorldSpawn_ENTRY;
     positionX:=pspawn^.WorldSpawn_X;
     positionY:=pspawn^.WorldSpawn_Y;
     positionZ:=pspawn^.WorldSpawn_Z;
     positionR:=pspawn^.WorldSpawn_R;
     mapId:=pspawn^.WorldSpawn_MAP;
     rX:=pspawn^.WorldSpawn_rX;
     rY:=pspawn^.WorldSpawn_rY;
     rZ:=pspawn^.WorldSpawn_rZ;
     rR:=pspawn^.WorldSpawn_rR;
     Size:=pspawn^.WorldSpawn_SIZE;
     if Size<=0 then Size:=1;
     Flags:=pspawn^.WorldSpawn_FLAGS;
     Model:=pspawn^.WorldSpawn_MODEL;
     Faction:=pspawn^.WorldSpawn_FACTION;
     Level:=pspawn^.WorldSpawn_LEVEL;
     goType:=pspawn^.WorldSpawn_GTYPE;

     InitUpdateArray;
end;

procedure TGameObject.InitUpdateArray;
begin
     SetUpdateBits(self,objGUID,integer(OBJECT_FIELD_GUID));

     SetUpdateBits(self,integer(TYPE_GAMEOBJECT or TYPE_OBJECT),OBJECT_FIELD_TYPE);
     SetUpdateBits(self,Entry,OBJECT_FIELD_ENTRY);
     SetUpdateBits(self,Size,OBJECT_FIELD_SCALE_X);

     SetUpdateBits(self,int64(0),OBJECT_FIELD_CREATED_BY);
     SetUpdateBits(self,Model,GAMEOBJECT_DISPLAYID);
     SetUpdateBits(self,Flags,GAMEOBJECT_FLAGS);
     SetUpdateBits(self,rX,GAMEOBJECT_ROTATION);
     SetUpdateBits(self,rY,GAMEOBJECT_ROTATION+1);
     SetUpdateBits(self,rZ,GAMEOBJECT_ROTATION+2);
     SetUpdateBits(self,rR,GAMEOBJECT_ROTATION+3);

     SetUpdateBits(self,integer(0),GAMEOBJECT_STATE); //what here?
     SetUpdateBits(self,integer(0),GAMEOBJECT_TIMESTAMP); //what here?
     SetUpdateBits(self,positionX,GAMEOBJECT_POS_X);
     SetUpdateBits(self,positionY,GAMEOBJECT_POS_Y);
     SetUpdateBits(self,positionZ,GAMEOBJECT_POS_Z);
     SetUpdateBits(self,positionR,GAMEOBJECT_FACING);
     SetUpdateBits(self,integer(0),GAMEOBJECT_DYN_FLAGS); //what here?
     SetUpdateBits(self,Faction,GAMEOBJECT_FACTION);
     SetUpdateBits(self,goType,GAMEOBJECT_TYPE_ID);
     SetUpdateBits(self,Level,GAMEOBJECT_LEVEL);
end;

procedure TGameObject.InitUpdateArrayForOthers;
begin
     RaiseBits(integer(OBJECT_FIELD_GUID));
     RaiseBits(integer(OBJECT_FIELD_GUID)+1);

     RaiseBits(OBJECT_FIELD_TYPE);
     RaiseBits(OBJECT_FIELD_ENTRY);
     RaiseBits(OBJECT_FIELD_SCALE_X);
     RaiseBits(OBJECT_FIELD_CREATED_BY);
     RaiseBits(GAMEOBJECT_DISPLAYID);
     RaiseBits(GAMEOBJECT_FLAGS);
     RaiseBits(GAMEOBJECT_ROTATION);
     RaiseBits(GAMEOBJECT_ROTATION+1);
     RaiseBits(GAMEOBJECT_ROTATION+2);
     RaiseBits(GAMEOBJECT_ROTATION+3);

     RaiseBits(GAMEOBJECT_STATE);
     RaiseBits(GAMEOBJECT_TIMESTAMP);
     RaiseBits(GAMEOBJECT_POS_X);
     RaiseBits(GAMEOBJECT_POS_Y);
     RaiseBits(GAMEOBJECT_POS_Z);
     RaiseBits(GAMEOBJECT_FACING);
     RaiseBits(GAMEOBJECT_DYN_FLAGS); 
     RaiseBits(GAMEOBJECT_FACTION);
     RaiseBits(GAMEOBJECT_TYPE_ID);
     RaiseBits(GAMEOBJECT_LEVEL);
end;

{ TMobile }

constructor TMobile.Create(mDbcID: integer);
var
   i: integer;
   pspawn: PPackedSpawnRecord;
   pcreature: PPackedCreatureRecord;
begin
     listAuras := TIntegerList.Create;
     setlength(UpdateArray,integer(UNIT_END));
     setlength(UpdateBitsArray,(integer(UNIT_END) shr 5)+1);
     updateBitsChanged:=false;
     dbcID:=mDbcID;
     objGUID:=GetUnitsUniqGUID;
     objType:=TYPEID_UNIT;

     WalkSpeed:=SPEED_WALK;
     RunSpeed:=SPEED_RUN;
     BackwardSpeed:=SPEED_WALKBACK;
     SweemSpeed:=SPEED_TURN;
     SweemBackSpeed:=SPEED_SWIMBACK;
     TurnRate:=SPEED_TURN;

     pspawn:=WorldDbcHandler.GetPointerPRValueByIntKey(dbcID);
     ID:=pspawn^.WorldSpawn_SPAWN;
     pcreature:=CreaturesDbcHandler.GetPointerPRValueByIntKey(ID);
     if pcreature=nil then
     begin
          AddToLog('Check your tables integrity!!! mobID='+IntToStr(ID));
          exit;
     end;

     Entry:=pspawn^.WorldSpawn_SPAWN; //WorldSpawn_ENTRY;
     positionX:=pspawn^.WorldSpawn_X;
     positionY:=pspawn^.WorldSpawn_Y;
     positionZ:=pspawn^.WorldSpawn_Z;
     positionR:=pspawn^.WorldSpawn_R;
     mapId:=pspawn^.WorldSpawn_MAP;
     // pspawn^.WorldSpawn_SPAWNTIME
     // pspawn^.WorldSpawn_SPAWNDIST

     //name:=CreaturesDbcHandler.GetStringByOffset(pcreature^.Creature_name);
     Size:=pcreature^.size;
     if Size<=0 then Size:=1;
     Flags:=pcreature^.flags1;
     Model:=pcreature^.model;
     healthMaxValue:=pcreature^.maxhealth;
     if healthMaxValue=0 then healthMaxValue:=200; //based on stats later
     healthCurrValue := healthMaxValue; //pcreature^.Creature_maxhealth;
     Faction:=pcreature^.faction;
     state:=DEATH_STATE_ALIVE;
     //isAlive:=true;
     for i:=0 to 2 do baseattacktime[i]:=pcreature^.attack; //weapon dependant/equip later
     for i:=0 to 5 do basedamage[i]:=pcreature^.damage; //min-max mainhand,offhand,ranged
     Level:=pcreature^.level;
     Family:=pcreature^.family;
     npcFlags:=pcreature^.npcflags;
     boundingRadius:=pcreature^.bounding_radius;
     combatReach:=pcreature^.combat_reach;

     { addition/ }
     cType := pcreature^.cType;
     { /addition }

     { pspawn^.WorldSpawn_LINK
      pspawn^.WorldSpawn_REACH
      pspawn^.WorldSpawn_EQUIP
      pspawn^.WorldSpawn_CTYPE
      pspawn^.WorldSpawn_NPCFLAGS
      pspawn^.WorldSpawn_SPAWN_GOBJ
     MaxManaRageEnergy,currManaRageEnergy}

     InitUpdateArray;
end;

procedure TMobile.AddPublicAura(aura : TAura);
var
  slot      : integer;
  flagslot  : byte;
  value     : longword;
begin
  if listAuras.IndexOf(PPackedSpellRecord(aura.spellEntry).ID) <> -1 then
  begin
    // TODO: renew existing aura timing
    exit;
  end;

  listAuras.Add(PPackedSpellRecord(aura.spellEntry).ID);

  if aura.isPositive then
  begin
    for slot := 0 to MAX_POSITIVE_AURA - 1 do
    begin
      if publicAuras[slot] = nil then
      begin
        publicAuras[slot] := aura;
        break;
      end;
    end;
  end else begin
    for slot := MAX_POSITIVE_AURA to MAX_AURAS do
    begin
      if publicAuras[slot] = nil then
      begin
        publicAuras[slot] := aura;
        break;
      end;
    end;
  end;
                                              
  if publicAuras[slot] <> aura then AddToLog('Fucking too much auras!');

  SetUpdateBits(self, PPackedSpellRecord(aura.spellEntry).ID, UNIT_FIELD_AURA + slot);

  flagslot := slot shr 3;
  value := self.UpdateArray[byte(UNIT_FIELD_AURAFLAGS + flagslot)];
  value := value or ($ffffffff and (AFLAG_SET shl ((slot and 7) shl 2)));
  SetUpdateBits(self, byte(value), UNIT_FIELD_AURAFLAGS + flagslot);

  if self is TCharacter then
  begin
    with TPlayer(TCharacter(self).Owner).SendBuff do
    begin
      Init(SMSG_UPDATE_AURA_DURATION);
      Add(byte(slot));
      Add(aura.duration);
    end;
    TPlayer(TCharacter(self).Owner).SendPacket;
  end;

  aura.slot := slot;
end;

procedure TMobile.InitUpdateArray;
var
   i: integer;
begin
     SetUpdateBits(self,objGUID,integer(OBJECT_FIELD_GUID));

     SetUpdateBits(self,integer(TYPE_UNIT or TYPE_OBJECT),OBJECT_FIELD_TYPE);
     SetUpdateBits(self,Entry,OBJECT_FIELD_ENTRY);
     SetUpdateBits(self,Size,OBJECT_FIELD_SCALE_X);
     //if SummonedBy setUpdateValue( (int)UpdateFields.UNIT_FIELD_SUMMONEDBY, SummonedBy.Guid );
     //not attackTarget
     //SetUpdateBits(self,int64(0),UNIT_FIELD_TARGET);
     SetUpdateBits(self,healthCurrValue,UNIT_FIELD_HEALTH);
     SetUpdateBits(self,healthMaxValue,UNIT_FIELD_MAXHEALTH);
     SetUpdateBits(self,powerCurrValue[powertype],UNIT_FIELD_POWER1+powertype);
     SetUpdateBits(self,powerMaxValue[powertype],UNIT_FIELD_MAXPOWER1+powertype);
     SetUpdateBits(self,Level,UNIT_FIELD_LEVEL);
     SetUpdateBits(self,Faction,UNIT_FIELD_FACTIONTEMPLATE);
     SetUpdateBits(self,Model,UNIT_FIELD_DISPLAYID);
     SetUpdateBits(self,Model,UNIT_FIELD_NATIVEDISPLAYID);
     //SetUpdateBits(self,integer(0),UNIT_FIELD_MOUNTDISPLAYID);
     SetUpdateBits(self,integer($01020100),UNIT_FIELD_BYTES_0);    //pgcr
     for i:=0 to 2 do SetUpdateBits(self,baseattacktime[i],UNIT_FIELD_BASEATTACKTIME+i);
     //SetUpdateBits(self,integer(0),UNIT_FIELD_BYTES_1);  //standing
     SetUpdateBits(self,integer(1),UNIT_FIELD_BYTES_2);
     //aura...
for i:=0 to 63 do RaiseBits(UNIT_FIELD_AURA+i);
     for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURAFLAGS+i);
     for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURALEVELS+i);
     for i:=0 to 15 do RaiseBits(UNIT_FIELD_AURAAPPLICATIONS+i);
     

     // TODO: update for auras

     {
     for i:=0 to 63 do
     begin
      aura := publicAuras[i];
      if aura = nil then continue;
      SetUpdateBits(self, longword(PPackedSpellRecord(aura.spellEntry)^.ID), UNIT_FIELD_AURA + i);
      RaiseBits(UNIT_FIELD_AURA + i);
     end;
      }
     //for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURAFLAGS+i);
     //for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURALEVELS+i);
     //for i:=0 to 15 do RaiseBits(UNIT_FIELD_AURAAPPLICATIONS+i);

     //RaiseBits(UNIT_FIELD_AURASTATE);

     SetUpdateBits(self,boundingRadius,UNIT_FIELD_BOUNDINGRADIUS);
     SetUpdateBits(self,combatReach,UNIT_FIELD_COMBATREACH);

     //SetUpdateBits(self,integer($10),UNIT_DYNAMIC_FLAGS);   //later
     SetUpdateBits(self,npcFlags,UNIT_NPC_FLAGS);
end;

procedure TMobile.InitUpdateArrayForOthers;
var
   i: integer;
begin
     RaiseBits(integer(OBJECT_FIELD_GUID));
     RaiseBits(integer(OBJECT_FIELD_GUID)+1);

     RaiseBits(OBJECT_FIELD_TYPE);
     RaiseBits(OBJECT_FIELD_ENTRY);
     RaiseBits(OBJECT_FIELD_SCALE_X);
     //if SummonedBy setUpdateValue( (int)UpdateFields.UNIT_FIELD_SUMMONEDBY, SummonedBy.Guid );
     //not attackTarget
     //RaiseBits(UNIT_FIELD_TARGET);
     RaiseBits(UNIT_FIELD_HEALTH);
     RaiseBits(UNIT_FIELD_POWER1+powerType);
     RaiseBits(UNIT_FIELD_LEVEL);
     RaiseBits(UNIT_FIELD_FACTIONTEMPLATE);
     //RaiseBits(UNIT_FIELD_BYTES_0);
     RaiseBits(UNIT_FIELD_DISPLAYID);
     RaiseBits(UNIT_FIELD_NATIVEDISPLAYID);
     RaiseBits(UNIT_FIELD_MOUNTDISPLAYID);
     RaiseBits(UNIT_FIELD_BYTES_1);  //standing

     RaiseBits(UNIT_DYNAMIC_FLAGS);   //later
     RaiseBits(UNIT_NPC_FLAGS);

     RaiseBits(UNIT_FIELD_BASEATTACKTIME);
     RaiseBits(UNIT_FIELD_BASEATTACKTIME+1);
     RaiseBits(UNIT_FIELD_RANGEDATTACKTIME);
     RaiseBits(UNIT_FIELD_MINDAMAGE);
     RaiseBits(UNIT_FIELD_MAXDAMAGE);
     RaiseBits(UNIT_FIELD_MINOFFHANDDAMAGE);
     RaiseBits(UNIT_FIELD_MAXOFFHANDDAMAGE);
     RaiseBits(UNIT_FIELD_MINRANGEDDAMAGE);
     RaiseBits(UNIT_FIELD_MAXRANGEDDAMAGE);
     RaiseBits(UNIT_FIELD_MAXHEALTH);
     RaiseBits(UNIT_FIELD_POWER1+powerType);
     RaiseBits(UNIT_FIELD_MAXPOWER1+powerType);
     for i:=ResistTypePhysical to ResistTypeArcane do
         RaiseBits(UNIT_FIELD_RESISTANCES+i);

     for i:=0 to 63 do RaiseBits(UNIT_FIELD_AURA+i);
     for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURAFLAGS+i);
     for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURALEVELS+i);
     for i:=0 to 15 do RaiseBits(UNIT_FIELD_AURAAPPLICATIONS+i);
           {
     // TODO: aura updates for others
     for i:=0 to 63 do
     begin
      aura := publicAuras[i];
      if aura = nil then continue;
      SetUpdateBits(self, longword(PPackedSpellRecord(aura.spellEntry)^.ID), UNIT_FIELD_AURA + i);
      RaiseBits(UNIT_FIELD_AURA + i);
     end;   }

     //for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURAFLAGS+i);
     //for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURALEVELS+i);
     //for i:=0 to 15 do RaiseBits(UNIT_FIELD_AURAAPPLICATIONS+i);

     //RaiseBits(UNIT_FIELD_AURASTATE);

end;

procedure TMobile.SetHealth(const Value: longword);
begin
  if Value > healthMaxValue then
    healthCurrValue := healthMaxValue
  else
    healthCurrValue := Value;

  SetUpdateBits(Self, healthCurrValue, UNIT_FIELD_HEALTH);
end;

// TODO: limit chars by zone, not only radius to lower workload
function TMobile.GetNeighbors : TLinkedList;
var
   i, ccount: integer;
   CurrChar : TCharacter;
   l : TLinkedList;
begin
  l := TLinkedList.Create;

  ccount:=0;
  for i:=0 to PlayerCharsHT_byGUID.InnerCapacity-1 do
  begin
    CurrChar:=PlayerCharsHT_byGUID.Items[PlayerCharsHT_byGUID.InnerKeyList[i]];

    if CurrChar<>nil then
    begin
      inc(ccount);

      if (IsInReach(positionX, positionY, positionZ, CurrChar.positionX, CurrChar.positionY, CurrChar.positionZ, NEIGHBOR_RADIUS)) then
      begin
        l.AddHead(CurrChar.Owner);
      end;

      if ccount=PlayerCharsHT_byGUID.Count then break;
    end;
  end;

  Result := l;
end;

procedure TMobile.SendMessageToNearby(msg : TSendOpcodeArr);
var
  players : TLinkedList;
  node : PLinkedListNode;
  i, x : longword;
  dat: array[0..maxword] of byte;
begin
  players := GetNeighbors;

  x := msg.offs;
  for i := 0 to x - 1 do dat[i] := msg.data[i];

  node := players.HeadNode;
  while node <> nil do
  begin
    msg.offs := x;
    for i := 0 to x - 1 do msg.data[i] := dat[i];
    TPlayer(node.Value).SendBuff := msg;
    TPlayer(node.Value).SendPacket;
    node := node.NextNode;
  end;
end;

procedure TMobile.Emote(emote_id : longword);
var
  msg : TSendOpcodeArr;
begin
  msg := TSendOpcodeArr.Create;
  with msg do
  begin
    msg.Init(SMSG_EMOTE);
    msg.Add(emote_id);
    msg.Add(objGUID);
  end;

  SendMessageToNearby(msg);
end;

procedure TMobile.SpellNonMeleeDamageLog(target : TMobile; spellID : longword; damage, school, absorb, resist, block : longword);
var
  msg     : TSendOpcodeArr;
  damage_s : single;
begin
  if target = nil then exit;
  // TODO: prevent spellcasting from/to dead
  //if not Self.isAlive then exit;
  //if not target.isAlive then exit;

  // TODO: count absorb from handler
  // absorb := 0;
  
{
//if(pVictim->m_damageManaShield)
//    if(pVictim->m_damageManaShield->m_modType == SPELL_AURA_SCHOOL_ABSORB)
 // FIX-ME
SpellEntry *spellInfo = sSpellStore.LookupEntry(spellID);
if(spellInfo)
absorb=CalDamageAbsorb(pVictim,spellInfo->School,damage);
}


if((damage - absorb) = 0) then begin
    msg := TSendOpcodeArr.Create;

    damage_s := damage;//single(damage);
    with msg do
    begin
      Init(SMSG_ATTACKERSTATEUPDATE);
      Add(longword($00010020));
      Add(byte($ff));
      Add(objGUID);
      Add(byte($ff));
      Add(target.objGUID);
      Add(longword(0));
      Add(byte(1)); // TODO: SubBlocks?
      Add(longword(0));
      Add(damage_s);
      Add(longword(damage));
      Add(absorb);
      Add(longword(0));
      Add(longword(1));
      Add(longword($FFFFFFFF));
      Add(longword(0));
      Add(longword(0));
    end;

    SendMessageToNearby(msg);
    exit;
  end else begin
    damage := damage - absorb;
  end;

  AddToLog('SpellNonMeleeDamageLog: ' + inttostr(uint64(objGUID)) + ' attacked ' + inttostr(uint64(target.objGUID)) + ' for ' + inttostr(damage) + ' damage inflicted by ' + inttostr(spellID));

  msg := TSendOpcodeArr.Create;
  with msg do
  begin
    Init(SMSG_SPELLNONMELEEDAMAGELOG);
    Add(target.objGUID);          // кого
    Add(objGUID);                 // кто
    Add(spellID);                 // чем
    Add(damage);                  // на сколько

    Add(byte(school));

    Add(longword(absorb)); //absorb
    Add(longword(resist)); // resist

    Add(word($0000)); // UNKNOWN

    Add(longword(block)); // block
  end;
  SendMessageToNearby(msg);

  DealDamage(target, damage, 0);
end;

procedure TMobile.DealDamage(target : TMobile; damage, procFlag : Integer);
var
  creature_type : longword;
  _buf : TSendOpcodeArr;

  hp, XpGain, XpRestedGain: Integer;
begin
  AddToLog('DealDamage BEGIN');

  if target.state <> DEATH_STATE_ALIVE then
  begin
    exit;
  end;

  if stealth <> 0 then
  begin
    //RemoveAffect(stealth);
  end;

  creature_type := target.Family;
  // TODO: if it's not player, AI gain threat etc.
  // ((Creature*)pVictim)->AI().AttackStart((Player*)this);

  if creature_type = 8 then
  begin
    { no loot, xp, honor etc for critters }
    target.Health := 0;
  end;

  hp := target.Health;

  if (hp < damage) then
  begin
    { just died }
    AddToLog('DEALDAMAGE: target just died');

    if (target.mobType = TYPE_UNIT) and (creature_type <> 8) then
    begin
      // TODO: generate loot
      // target.generateLoot;
    end;

    if (target.mobType = TYPE_PLAYER) and (mobType = TYPE_PLAYER) then
    begin
      // TODO: calculate honor

//      honorableKills := TPlayer(Self).CurrChar;
//      dishonorableKills;
{
      SetUpdateBits(Self, 2, PLAYER_FIELD_SESSION_KILLS);
      SetUpdateBits(Self, 1, PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS);
      SetUpdateBits(Self, 1, PLAYER_FIELD_LIFETIME_HONORBALE_KILLS);
      }
                        (*
                        uint16 honorableKills = (uint16)(GetUInt32Value(PLAYER_FIELD_SESSION_KILLS));
                        uint16 unhonorableKills = (uint16)((GetUInt32Value(PLAYER_FIELD_SESSION_KILLS) - honorableKills) / 65536);

                        if ((pKiller->GetLevel() - GetLevel() ) >= 5 )
                        {
                                pKiller->SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, (uint32)(honorableKills + ((unhonorableKills + 1) * 65536)) );
                                pKiller->SetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS, pKiller->GetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS) + 1);
                        }
                        else
                        {
                                pKiller->SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, (uint32)(honorableKills + 1 + ((unhonorableKills) * 65536)));
                                pKiller->SetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS, pKiller->GetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS) + 1);
                        }
                        */

                        // HONOR SYSTEM (Python, executables.py)
                        Call_CalcHonor (pKiller, this);

                        ((Player)pKiller)->m_PVP_timer = 300000;
                        if (!((Player)pKiller)->HasFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER))
                                ((Player)pKiller)->SetFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER);
                                *)
    end;

    // TODO: target.removeAllAffects

    target.state := DEATH_STATE_DEAD;

    if (target.mobType = TYPE_PLAYER) and (mobType <> TYPE_PLAYER) then
    begin
      // TODO: 10% durability loss on death
      // target.durabilityLoss(0.10);;
    end;

    // TODO: stop target' attack
    // target.smsg_attack_stop(Self.objGUID);

    target.Health := 0;

    // TODO: pVictim->RemoveFlag(UNIT_FIELD_FLAGS, 0x00080000);

    if (target.mobType <> TYPE_PLAYER) then
    begin
      if creature_type = 8 then
      begin
        // pVictim->SetUInt32Value(UNIT_DYNAMIC_FLAGS, 0);
      end else begin
        // pVictim->SetUInt32Value(UNIT_DYNAMIC_FLAGS, 1);
      end;
    end;

    if (mobType = TYPE_PLAYER) and (creature_type <> 8) then
    begin
      // TODO: calculate xp
{
                        DEBUG_LOG("DealDamageIsPlayer");
                        uint32 xp = MaNGOS::XP::Gain(static_cast<Player *>(this), pVictim);

                        uint32 entry = 0;
                        if (pVictim->GetTypeId() != TYPEID_PLAYER)
                        entry = pVictim->GetUInt32Value(OBJECT_FIELD_ENTRY );

                        Group *pGroup = objmgr.GetGroupByLeader(((Player*)this)->GetGroupLeader());
                        if (pGroup)
                        {
                                DEBUG_LOG("DealDamageInGroup");
                                xp /= pGroup->GetMembersCount();
                                for (uint32 i = 0; i < pGroup->GetMembersCount(); i++)
                                {
                                        Player *pGroupGuy = ObjectAccessor::Instance().FindPlayer(pGroup->GetMemberGUID(i));
                                        pGroupGuy->GiveXP(xp, victimGuid);

                                        if (pVictim->GetTypeId() != TYPEID_PLAYER)
                                                pGroupGuy->KilledMonster(entry, victimGuid);
                                ]
                        ]
                        else
                        {
                                DEBUG_LOG("DealDamageNotInGroup");

                                ((Player*)this)->GiveXP(xp, victimGuid);

                                if (pVictim->GetTypeId() != TYPEID_PLAYER)
                                ((Player*)this)->KilledMonster(entry, victimGuid);
                        ]
}

    end else begin
{
                        DEBUG_LOG("DealDamageIsCreature");
                        smsg_AttackStop(victimGuid);
                        RemoveFlag(UNIT_FIELD_FLAGS, 0x00080000);
                        addStateFlag(UF_TARGET_DIED);
}
    end;
      XpGain := 100;
      XpRestedGain := XpGain div 2;
      TCharacter(Self).GiveXP(XpGain);
      with TPlayer(TCharacter(Self).Owner) do begin
        SendBuff.Init(SMSG_LOG_XPGAIN);
        SendBuff.Add(target.objGUID);
        SendBuff.Add(longword(XpGain));
        SendBuff.Add(byte(0)); // 00-kill_xp type, 01-non_kill_xp type
        SendBuff.Add(longword(XpRestedGain)); // unrested given experience
        SendBuff.Add(byte(0));      // unknown (static.. it was same at 4 different killed creatures!)
        SendBuff.Add(byte(0));      // *
        SendBuff.Add(byte($80));    // *
        SendBuff.Add(byte($3F));    // *
        SendPacket;
      end;  
  end else begin
    target.Health := hp - damage;
  end;

  {
  {
                DEBUG_LOG("DealDamageAlive");
                DONE
                pVictim->SetUInt32Value(UNIT_FIELD_HEALTH , health - damage);

                if (pVictim->GetTypeId() != TYPEID_PLAYER)
                {
                        ((Creature *)pVictim)->AI().DamageInflict(this, damage);
                        if( getClass() == WARRIOR )
                                ((Player*)this)->CalcRage(damage,true);
    ]
                else
                {
                        ((Player*)pVictim)->addStateFlag(UF_ATTACKING);

                        if( (((Player*)pVictim)->getClass()) == WARRIOR )
                                ((Player*)pVictim)->CalcRage(damage,false);

                // random durability for items (HIT)
                if (pVictim->GetTypeId() == TYPEID_PLAYER)
                {
                        int randdurability = urand(0, 20);
                        if (randdurability == 10)
                        {
                        DEBUG_LOG("HIT: We decrease durability with 5 percent");
                        ((Player*)pVictim)->DeathDurabilityLoss(0.05);
                        ]
                ]

    ]
                for(std::list<struct DamageShield>::iterator i = pVictim->m_damageShields.begin();i != pVictim->m_damageShields.end();i++)
                {
                        pVictim->SpellNonMeleeDamageLog(this,i->m_spellId,i->m_damage);
                ]
        ]
  DEBUG_LOG("DealDamageEnd");
    }

  { update objects for all neighbors/ }
  _buf := TSendOpcodeArr.Create;
  target.CreateUpdateValuesBlockForOthers(_buf);
  target.SendMessageToNearby(_buf);

  _buf := TSendOpcodeArr.Create;
  Self.CreateUpdateValuesBlockForOthers(_buf);
  Self.SendMessageToNearby(_buf);
  { /update objects for all neighbors }

  AddToLog('DealDamage END');
end;

{ TCharacter }

constructor TCharacter.Create(charGUID: int64; GenerateNewGUID: boolean);
begin
     listAuras := TIntegerList.Create;
     setlength(UpdateArray,integer(PLAYER_END));
     setlength(UpdateBitsArray,(integer(PLAYER_END) shr 5)+1);
     updateBitsChanged:=false;
     if GenerateNewGUID then objGUID:=GetCharsUniqGUID
     else objGUID:=charGUID;
     objType:=TYPEID_PLAYER;
     Size:=1;
     WalkSpeed:=SPEED_WALK;
     RunSpeed:=SPEED_RUN;
     BackwardSpeed:=SPEED_WALKBACK;
     SweemSpeed:=SPEED_TURN;
     SweemBackSpeed:=SPEED_SWIMBACK;
     TurnRate:=SPEED_TURN;
     ActiveQuests:=TArrayList.Create(20);
     DoneQuests:=TIntegerList.Create(0);
     IsInGroup:=false;
     IsInvited:=false;
     CurrentBuybackSlot := 0;  
end;

procedure TCharacter.CalculateItemsBonusStats;
var
   i,j,item_bonustype,bonusdmgtype,cr: integer;
   pplcharbase: PPackedClassRaseStartInfoRecord;
const
     s1: single = 1;
begin
     attackPower:=0;
     FillChar(basedamage,sizeof(basedamage),0);
     FillChar(baseattacktime,sizeof(baseattacktime),0);
     FillChar(dmgbonus,sizeof(dmgbonus),0);
     FillChar(bonusStats,sizeof(bonusStats),0);
     FillChar(resists,sizeof(resists),0);

     for i:=0 to INVENTORY_SLOT_BAG_4 do  //calc stats,armor,dmg,spells etc
         if (cItems[i] <> nil)and(cItems[i].ID > 0) then
         begin
              SetUpdateBits(self,cItems[i].ID,PLAYER_VISIBLE_ITEM_1_0+i*12);
              SetUpdateBits(self,cItems[i].objGUID,PLAYER_FIELD_INV_SLOT_HEAD+i*2);

              for j:=0 to 9 do
              begin
                   item_bonustype:=cItems[i].PItemRecord^.ItemStats[j].statType;
                   if (item_bonustype >= itemAgilityBonus)and(item_bonustype <= itemStaminaBonus) then
                      bonusStats[itemBonus2charBonus_type[item_bonustype]]:=bonusStats[itemBonus2charBonus_type[item_bonustype]]+cItems[i].PItemRecord^.ItemStats[j].statValue;
              end;

              for j:=ResistTypePhysical to ResistTypeArcane do
                  resists[j]:=resists[j]+cItems[i].PItemRecord^.Resists[j];

              for j:=0 to 4 do
              begin
                   bonusdmgtype:=cItems[i].PItemRecord^.ItemDmgs[j].DmgType;
                   if (bonusdmgtype >= DmgTypePhysical)and(bonusdmgtype <= DmgTypeArcane) then
                   begin
                        dmgbonus[bonusdmgtype,0]:=dmgbonus[bonusdmgtype,0]+cItems[i].PItemRecord^.ItemDmgs[j].DmgMin;
                        dmgbonus[bonusdmgtype,1]:=dmgbonus[bonusdmgtype,1]+cItems[i].PItemRecord^.ItemDmgs[j].DmgMax;
                   end;
              end;

              // TODO: spell bonuses!!!
         end;

     cr:=pgcr and $FFFF;
     pplcharbase:=PPackedClassRaseStartInfoRecord(CharCRStartInfoDbcHandler.GetPointerPRValueByIntKey(cr));
     if pplcharbase=nil then exit;
     baseStats[charStrengthBonus]:=pplcharbase^.baseStrength+trunc(pred(Level)*StrengthPerLevel);
     baseStats[charAgilityBonus]:=pplcharbase^.baseAgility+trunc(pred(Level)*AgilityPerLevel);
     baseStats[charStaminaBonus]:=pplcharbase^.baseStamina+trunc(pred(Level)*StaminaPerLevel);
     baseStats[charIntellectBonus]:=pplcharbase^.baseIntellect+trunc(pred(Level)*IntellectPerLevel);
     baseStats[charSpiritBonus]:=pplcharbase^.baseSpirit+trunc(pred(Level)*SpiritPerLevel);

     for i:=charStrengthBonus to charSpiritBonus do
         if bonusStats[i] >= 0 then
         begin
              SetUpdateBits(self,bonusStats[i],PLAYER_FIELD_POSSTAT0+i);
              SetUpdateBits(self,integer(0),PLAYER_FIELD_NEGSTAT0+i);
         end
         else begin
              SetUpdateBits(self,integer(0),PLAYER_FIELD_POSSTAT0+i);
              SetUpdateBits(self,-bonusStats[i],PLAYER_FIELD_NEGSTAT0+i);
         end;

     for i:=charStrengthBonus to charSpiritBonus do
     begin
          baseStats[i]:=baseStats[i]+bonusStats[i]; //game values
          SetUpdateBits(self,baseStats[i],UNIT_FIELD_STAT0+i);
     end;

     if cItems[EQUIPMENT_SLOT_MAINHAND]<>nil then
     begin
          baseattacktime[0]:=cItems[EQUIPMENT_SLOT_MAINHAND].PItemRecord^.Delay;
          //dmg
          for j:=0 to 4 do
          begin
               if cItems[EQUIPMENT_SLOT_MAINHAND].PItemRecord^.ItemDmgs[j].DmgType = 0 then //base dmg
               begin
                    basedamage[0]:=basedamage[0]+cItems[EQUIPMENT_SLOT_MAINHAND].PItemRecord^.ItemDmgs[j].DmgMin;
                    basedamage[1]:=basedamage[1]+cItems[EQUIPMENT_SLOT_MAINHAND].PItemRecord^.ItemDmgs[j].DmgMax;
               end;
          end;
     end;
     if cItems[EQUIPMENT_SLOT_OFFHAND]<>nil then
     begin
          baseattacktime[1]:=cItems[EQUIPMENT_SLOT_OFFHAND].PItemRecord^.Delay;
          for j:=0 to 4 do
          begin
               if cItems[EQUIPMENT_SLOT_OFFHAND].PItemRecord^.ItemDmgs[j].DmgType = 0 then //base dmg
               begin
                    basedamage[2]:=basedamage[2]+cItems[EQUIPMENT_SLOT_OFFHAND].PItemRecord^.ItemDmgs[j].DmgMin;
                    basedamage[3]:=basedamage[3]+cItems[EQUIPMENT_SLOT_OFFHAND].PItemRecord^.ItemDmgs[j].DmgMax;
               end;
          end;
     end;
     if cItems[EQUIPMENT_SLOT_RANGED]<>nil then
     begin
          baseattacktime[2]:=cItems[EQUIPMENT_SLOT_RANGED].PItemRecord^.Delay;
          for j:=0 to 4 do
          begin
               if cItems[EQUIPMENT_SLOT_RANGED].PItemRecord^.ItemDmgs[j].DmgType = 0 then //base dmg
               begin
                    basedamage[4]:=basedamage[4]+cItems[EQUIPMENT_SLOT_RANGED].PItemRecord^.ItemDmgs[j].DmgMin;
                    basedamage[5]:=basedamage[5]+cItems[EQUIPMENT_SLOT_RANGED].PItemRecord^.ItemDmgs[j].DmgMax;
               end;
          end;
     end;
     //+ attack power dps...
     case cClass of
        ccnWarrior : attackPower:=Level*3+baseStats[charStrengthBonus]*2-20;
        ccnPaladin : attackPower:=Level*3+baseStats[charStrengthBonus]*2-20;
        ccnHunter  : attackPower:=Level*2+baseStats[charStrengthBonus]+baseStats[charAgilityBonus]-20;
        ccnRogue   : attackPower:=Level*2+baseStats[charStrengthBonus]+baseStats[charAgilityBonus]-20;
        ccnPriest  : attackPower:=baseStats[charStrengthBonus]-10;
        ccnShaman  : attackPower:=Level*2+baseStats[charStrengthBonus]*2-20;
        ccnMage    : attackPower:=baseStats[charStrengthBonus]-10;
        ccnWarlock : attackPower:=baseStats[charStrengthBonus]-10;
        ccnDruid   : attackPower:=baseStats[charStrengthBonus]*2-20;  //form dependant
     end;
     SetUpdateBits(self,attackPower,UNIT_FIELD_ATTACK_POWER);
     SetUpdateBits(self,integer(0),UNIT_FIELD_ATTACK_POWER_MODS); //?
     SetUpdateBits(self,attackPower,UNIT_FIELD_RANGED_ATTACK_POWER);
     SetUpdateBits(self,integer(0),UNIT_FIELD_RANGED_ATTACK_POWER_MODS);

     //DPS = (([max wpn dmg]+[min wpn dmg])/2)/speed   //dual-wield & missrate
     //Block_Chance = 5 - (Level*5 - Current_Naked_Defense)*0.04 + (Current_Defense - Current_Naked_Defense)*0.04

     SetUpdateBits(self,baseattacktime[0],UNIT_FIELD_BASEATTACKTIME);
     SetUpdateBits(self,baseattacktime[1],UNIT_FIELD_BASEATTACKTIME{+1});
     SetUpdateBits(self,baseattacktime[2],UNIT_FIELD_RANGEDATTACKTIME);
     SetUpdateBits(self,basedamage[0],UNIT_FIELD_MINDAMAGE);
     SetUpdateBits(self,basedamage[1],UNIT_FIELD_MAXDAMAGE);
     SetUpdateBits(self,basedamage[2],UNIT_FIELD_MINOFFHANDDAMAGE);
     SetUpdateBits(self,basedamage[3],UNIT_FIELD_MAXOFFHANDDAMAGE);
     SetUpdateBits(self,basedamage[4],UNIT_FIELD_MINRANGEDDAMAGE);
     SetUpdateBits(self,basedamage[5],UNIT_FIELD_MAXRANGEDDAMAGE);

     for i:=0 to 6 do
     begin
          SetUpdateBits(self,s1,PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+i);  //DmgTypePhysical etc
          SetUpdateBits(self,integer(0),PLAYER_FIELD_MOD_DAMAGE_DONE_POS+i);  // damage bonus
          SetUpdateBits(self,integer(0),PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+i);  // damage debonus
     end;

  //Расчет максимума жизни
  healthMaxValue := pplcharbase^.baseHealth ;
  if Level > 1 then
    healthMaxValue := healthMaxValue + longword(baseStats[charStaminaBonus] - pplcharbase^.baseStamina) * 10 ;

  SetUpdateBits(self, healthCurrValue,UNIT_FIELD_HEALTH);
  SetUpdateBits(self, healthMaxValue,UNIT_FIELD_MAXHEALTH);

     //talents
     //Talents := 20;
     //SetUpdateBits(self, Talents, PLAYER_CHARACTER_POINTS1);

     powerMaxValue[powerType] := pplcharbase^.baseManaRageEnergy;   //temp fix
     powerCurrValue[powerType]:=0;

     if powerType=0 then
     begin
          powerMaxValue[powerType]:=baseStats[charIntellectBonus]*10;
          powerCurrValue[powerType]:=powerMaxValue[powerType];
     end;
     SetUpdateBits(self,powerCurrValue[powerType],UNIT_FIELD_POWER1+powerType);
     SetUpdateBits(self,powerMaxValue[powerType],UNIT_FIELD_MAXPOWER1+powerType);
     //resists
     resists[ResistTypePhysical]:=resists[ResistTypePhysical]+baseStats[charAgilityBonus]*2; //armor
     for j:=ResistTypePhysical to ResistTypeArcane do
         SetUpdateBits(self,resists[j],UNIT_FIELD_RESISTANCES+j);

     {SetUpdateBits(self,,PLAYER_BLOCK_PERCENTAGE);
     SetUpdateBits(self,,PLAYER_DODGE_PERCENTAGE);
     SetUpdateBits(self,,PLAYER_PARRY_PERCENTAGE);
     SetUpdateBits(self,,PLAYER_CRIT_PERCENTAGE);}

  SetUpdateBits(Self, AmmoId, PLAYER_AMMO_ID);
end;

procedure TCharacter.InitWithCreatePacket;
var
   i,j,equip_slot,inventory_type,cr{,gcr}: integer;
   empty_bag_slot_found: boolean;
   gender, skin, face, hairStyle, hairColor, facialHair, piersing: byte;
   equipped_slots: array[-1..18]of byte;
   pplcharbase: PPackedClassRaseStartInfoRecord;
   outfit_item: PPackedCharStartOutfitRecord;
   pActionBarStartInfo: PPackedActionBarStartInfo ;
begin
    with (Owner as TPlayer).ReceiveBuff do
    begin
         Get(name);
         Get(byte(cRace));
         Get(byte(cClass));
         Get(gender);
         Get(skin);
         Get(face);
         Get(hairStyle);
         Get(hairColor);
         Get(facialHair);
         Get(piersing);
    end;

    bRace:=dword(1) shl (byte(cRace) - 1);
    bClass:=dword(1) shl (byte(cClass) - 1);

    baseattacktime[0] := 2000;
    baseattacktime[1] := 2000;
    Level:=1;
    cXp:=0;
    LastLogout:=Now;
    copper:=0;
    restState:=1;
    PetDisplayId:=0;
    PetLevel:=0;
    PetCreatureFamily:=0;
    guildID:=0;
    //isAlive:=true;
    state:=DEATH_STATE_ALIVE;
    WalkSpeed:=2.5;
    RunSpeed:=7.0;
    SweemSpeed:=3.0;
    SweemBackSpeed:=1.7;
    Size:=1.0;
    //ID:=$E0FF;    //temp fix
    FactionTemplate:=PPackedCharRacesRecord(CharRacesDbcHandler.GetPointerPRValueByIntKey(integer(cRace)))^.faction_template;
    Faction:=PPackedFactionTemplateRecord(FactionTemplateDbcHandler.GetPointerPRValueByIntKey(FactionTemplate))^.faction;
    Model:=PPackedCharRacesRecord(CharRacesDbcHandler.GetPointerPRValueByIntKey(integer(cRace)))^.model[gender];

    cr:=(integer(cCLass) shl 8)or integer(cRace);
//    gcr:=(integer(gender) shl 16)or(integer(cCLass) shl 8)or integer(cRace);
    pplcharbase:=PPackedClassRaseStartInfoRecord(CharCRStartInfoDbcHandler.GetPointerPRValueByIntKey(cr));
    if pplcharbase=nil then exit;
    powertype := pplcharbase^.ManaRageEnergyKind;
    pgcr:=(integer(powertype) shl 24)or(integer(gender) shl 16)or(integer(cCLass) shl 8)or integer(cRace);
    hairFaceSkin:=(integer(hairColor) shl 24)or(integer(hairStyle) shl 16)or(integer(face) shl 8)or integer(skin);
    rest_state_f_hair := {integer($1EE00) or }(restState shl 24) or integer(facialHair);

    healthCurrValue := pplcharbase^.baseHealth ;

    if powertype=0 then powerCurrValue[powerType]:=100
    else powerCurrValue[powerType]:=0;

		mapId := pplcharbase^.mapID;
		zoneId := pplcharbase^.zoneID;
    positionX:=pplcharbase^.posX;
    positionY:=pplcharbase^.posY;
    positionZ:=pplcharbase^.posZ;
    positionR:=pplcharbase^.posR;

    cSkills:=CharCRStartInfoDbcHandler.GetStringByOffset(pplcharbase^.skills);
    cSpells:=CharCRStartInfoDbcHandler.GetStringByOffset(pplcharbase^.spells);

    BindingPointMapId:=mapId;
    BindingPointZoneId:=zoneId;
    BindingPointX:=positionX;
    BindingPointY:=positionY;
    BindingPointZ:=positionZ;
    BindingPointR:=positionR;
    
  //action bar
  //Берем дефолтные кнопки из ActionBarStartInfo и
  //заполняем основную панель (0-11) значениями по умолчанию
  pActionBarStartInfo := ActionBarStartInfoDbcHandler.GetPointerPRValueByIntKey(cr);
  if pActionBarStartInfo <> nil then
    for i:=0 to 11 do
      if pActionBarStartInfo^.MainActionBar[i] > 80000000 then //item
        actionsButtons[i] := $80000000 - 80000000 + pActionBarStartInfo^.MainActionBar[i]
      else
        actionsButtons[i] := pActionBarStartInfo^.MainActionBar[i];

  FillChar(equipped_slots,length(equipped_slots),0);
  outfit_item:=PPackedCharStartOutfitRecord(CharStartOutfitDbcHandler.GetPointerPRValueByIntKey(cr));
  if outfit_item <> nil then
    for i:=0 to 11 do
      if outfit_item^.item[i] > 0 then begin
        inventory_type:=outfit_item^.inventory_type[i];
        if inventory_type = INVTYPE_AMMO then begin //боеприпасы ложим в сумку
          AmmoId := outfit_item^.item[i] ; //ярлык на боеприпасы
          cBagItems[INVENTORY_SLOT_BAG_1, 0] := TItem.Create(objGUID,outfit_item^.item[i]);
          cBagItems[INVENTORY_SLOT_BAG_1, 0].item_count := cBagItems[INVENTORY_SLOT_BAG_1, 0].PItemRecord^.MaxCount ;
          Continue ;
        end;
        equip_slot:=inventory_type2equip_slot[inventory_type];
        if (equip_slot > 0) and (equip_slot < 255) and (equipped_slots[equip_slot]=0) then begin//if not slot busy, else to bag
          cItems[equip_slot]:=TItem.Create(objGUID,outfit_item^.item[i]);
          cItems[equip_slot].item_count := outfit_item^.item_count[i];
          equipped_slots[equip_slot]:=1;
        end else begin //put in empty bag slot, bags empty, dont bother
          j:=INVENTORY_SLOT_ITEM_START;
          empty_bag_slot_found:=false;
          while not empty_bag_slot_found and (j <= INVENTORY_SLOT_ITEM_END)do begin
            if cItems[j] = nil then begin //Нашли пустую ячейку
              empty_bag_slot_found:=true;
              cItems[j]:=TItem.Create(objGUID,outfit_item^.item[i]);
              if cItems[j].PItemRecord^.MaxCount > 1 then cItems[j].item_count := outfit_item^.item_count[i];
            end;
            inc(j);
          end;
        end;
      end;

  //Приведение имени к правильному виду
  Name := LowerCase(Name);
  Name[1] := Chr(Ord(Name[1]) - 32);
end;

procedure TCharacter.SendFullCreateUpdateBlockForPlayer;
var
   i,j,item_count,data_len: integer;
   buff: TSendOpcodeArr;
begin
   buff:=TSendOpcodeArr.Create;
   try
		 buff.Init(SMSG_UPDATE_OBJECT);
     item_count:=0;
		 buff.Add(item_count); //item count
		 buff.Add(byte(0));

     for i:=0 to pred(length(cItems))do
       if (cItems[i] <> nil)and(cItems[i].ID <> 0) then begin
         inc(item_count);
         cItems[i].BuildUpdateBlock(UPDATETYPE_CREATE_OBJECT,false,buff);
       end;

     for j := INVENTORY_SLOT_BAG_1 to INVENTORY_SLOT_BAG_4 do
      for i := 0 to 19 do
       if (cBagItems[j,i] <> nil)and(cBagItems[j,i].ID <> 0) then begin
         inc(item_count);
         cBagItems[j,i].BuildUpdateBlock(UPDATETYPE_CREATE_OBJECT,false,buff);
       end;

     //char update
     inc(item_count);
     self.BuildUpdateBlock(UPDATETYPE_CREATE_OBJECT,true,buff);

     data_len:=buff.offs;
     buff.offs:=4;
		 buff.Add(item_count); //item count
     buff.offs:=data_len;
     FinaliseSendUpdateBlock(Owner,buff);
   finally
     buff.Free;
   end;
end;

procedure TCharacter.SendPartialCreateItemUpdateBlockForPlayer(item: TItem);
var
   buff: TSendOpcodeArr;
begin
	 buff:=TSendOpcodeArr.Create;
   try
     buff.Init(SMSG_UPDATE_OBJECT);
		 buff.Add(integer(1)); //item count
		 buff.Add(byte(0));

     item.BuildUpdateBlock(UPDATETYPE_CREATE_OBJECT,false,buff);

     FinaliseSendUpdateBlock(Owner,buff);
   finally
     buff.Free;
   end;
end;

procedure TCharacter.BuildSendCharUpdateBlock;
var
   i,j,data_len,item_count: integer;
   buff: TSendOpcodeArr;
begin
   //CalculateItemsBonusStats;  //if changed !!!

   buff:=TSendOpcodeArr.Create;
   item_count:=0;
   try
     buff.Init(SMSG_UPDATE_OBJECT);
		 buff.Add(integer(1)); //item count
		 buff.Add(byte(0));

     for i:=EQUIPMENT_SLOT_HEAD to BANK_SLOT_BAG_END do
         if (cItems[i]<>nil)and(cItems[i].updateBitsChanged)then
         begin
              inc(item_count);
              cItems[i].BuildUpdateBlock(UPDATETYPE_VALUES,false,buff);
         end;
     for i:=INVENTORY_SLOT_BAG_1 to INVENTORY_SLOT_BAG_4 do
         if cItems[i]<>nil then
            for j:=0 to pred(cItems[i].PItemRecord^.ContainerSlots) do
                if (cBagItems[i][j]<>nil)and(cBagItems[i][j].updateBitsChanged)then
                begin
                     inc(item_count);
                     cBagItems[i][j].BuildUpdateBlock(UPDATETYPE_VALUES,false,buff);
                end;

     inc(item_count);
     BuildUpdateBlock(UPDATETYPE_VALUES,true,buff);
     data_len:=buff.offs;
     buff.offs:=4;
		 buff.Add(item_count); //item count + char
     buff.offs:=data_len; 
     FinaliseSendUpdateBlock(owner,buff);
     buff.offs:=data_len;
   finally buff.Free;
   end;
end;

procedure TCharacter.LoadItemsSpells;
var
   i,j,x,iListLen,itemId,itemsCount,questCount,bag,slot,cr: integer;
   itemList,questList: array of integer;
   tempItem: TItem;
   playerchar: PPackedPlayerCharsRecord;
   pplcharbase: PPackedClassRaseStartInfoRecord;
   activeQuest: TActiveQuest;
   pActionBar: PPackedActionBar;
begin
     playerchar:=PPackedPlayerCharsRecord(PlayerCharDbcHandler.GetPointerPRValueByIntKey(ID));
     if playerchar=nil then exit;
     name:=PlayerCharDbcHandler.GetStringByOffset(playerchar^.Name);
     cSpells:=PlayerCharDbcHandler.GetStringByOffset(playerchar^.Spells);
     cSkills:=PlayerCharDbcHandler.GetStringByOffset(playerchar^.Skills);
     //Flags:=PlayerCharDbcHandler.GetIntValueByIntKey(ID,PlayerChars_Flags);
     if TPlayer(Owner).AccessLevel > 0 then Flags := 8
     else Flags:=0;
     Level:=playerchar^.level;
     cXp:=playerchar^.xp;
     //calc this
     cNextLvlXp := LvlXP[Level, 0];
     copper:=playerchar^.copper;
     guildID:=playerchar^.guild_ID;
     rest_state_f_hair := playerchar^.rest_state_f_hair;
     restState:=rest_state_f_hair shr 24;
     hairFaceSkin:=playerchar^.HairFaceSkin;
     healthCurrValue:=playerchar^.CurrHealth;
     powerCurrValue[powerType]:=playerchar^.CurrRMEnergy;

     pgcr:=playerchar^.pgcr;
     powertype:=pgcr shr 24;
     cCLass:=TNCharClass((pgcr shr 8)and $F);
     cRace:=TNcharRace(pgcr and $F);
     bRace:=dword(1) shl (byte(cRace) - 1);
     bClass:=dword(1) shl (byte(cClass) - 1);
     FactionTemplate:=PPackedCharRacesRecord(CharRacesDbcHandler.GetPointerPRValueByIntKey(integer(cRace)))^.faction_template;
     Faction:=PPackedFactionTemplateRecord(FactionTemplateDbcHandler.GetPointerPRValueByIntKey(FactionTemplate))^.faction;
     Model:=PPackedCharRacesRecord(CharRacesDbcHandler.GetPointerPRValueByIntKey(integer(cRace)))^.model[(pgcr shr 16) and 1];    //gender

     healthCurrValue := playerchar^.CurrHealth;

     mapId:=playerchar^.mapID_zoneID shr 16;
     zoneId:=playerchar^.mapID_zoneID; //word already and $FFFF;
     positionX:=playerchar^.positionX;
     positionY:=playerchar^.positionY;
     positionZ:=playerchar^.positionZ;
     positionR:=playerchar^.positionR;
     oldPositionX:=positionX; oldPositionY:=positionY; oldPositionZ:=positionZ;
     oldMapId:=mapId;

     //bindpoint
     BindingPointX := playerchar^.BindingPointX;
     BindingPointY := playerchar^.BindingPointY;
     BindingPointZ := playerchar^.BindingPointZ;
     BindingPointR := playerchar^.BindingPointR;
     BindingPointMapId := playerchar^.BindingPointMapID_ZoneID shr 16;
     BindingPointZoneId := playerchar^.BindingPointMapID_ZoneID;

     CurrentBuybackSlot := 0;

     cr:=pgcr and $FFFF;
     pplcharbase:=PPackedClassRaseStartInfoRecord(CharCRStartInfoDbcHandler.GetPointerPRValueByIntKey(cr));
     if pplcharbase=nil then exit;
     StrengthPerLevel:=pplcharbase^.StrengthPerLevel;
     AgilityPerLevel:=pplcharbase^.AgilityPerLevel;
     StaminaPerLevel:=pplcharbase^.StaminaPerLevel;
     IntellectPerLevel:=pplcharbase^.IntellectPerLevel;
     SpiritPerLevel:=pplcharbase^.SpiritPerLevel;

     //load/create items
     setlength(itemList,maxbyte);
     iListLen:=FillIntArrWithStrData(PlayerCharDbcHandler.GetStringByOffset(playerchar^.Items),';',itemList);
     itemsCount:=iListLen div 6;
     for i:=0 to pred(itemsCount) do begin
          bag:=itemList[i*6];
          itemId:=itemList[i*6+1];
          slot:=itemList[i*6+2];
          tempItem:=TItem.Create(objGUID,itemId);
          tempItem.item_count:=itemList[i*6+3];
          tempItem.durability:=itemList[i*6+4];
          tempItem.random_prop:=itemList[i*6+5];
          AddItem2Bag(tempItem,bag,slot);
     end;

     //load quests
     setlength(questList,maxword);
     questCount:=FillIntArrWithStrData(PlayerCharDbcHandler.GetStringByOffset(playerchar^.ActiveQuests),';',questList);
     questCount:=questCount div 17; //id,obj[0-3]*4
     for i:=0 to pred(questCount) do 
     begin
          activeQuest:=TActiveQuest.Create;
          activeQuest.questID:=questList[i*17];
          for j:=0 to 3 do
          begin
               x:=j shl 2;
               activeQuest.objectives[j].Item:=questList[i*17+x+1];
               activeQuest.objectives[j].Amount:=questList[i*17+x+2];
               activeQuest.objectives[j].Deliver:=questList[i*17+x+3];
               activeQuest.objectives[j].DeliverAmount:=questList[i*17+x+4];
          end;
          ActiveQuests.Add(activeQuest);
     end;

     questCount:=FillIntArrWithStrData(PlayerCharDbcHandler.GetStringByOffset(playerchar^.DoneQuests),';',questList);
     for i:=0 to pred(questCount) do
        DoneQuests.AddIfNotExists(questList[i]);

  itemsCount:=FillIntArrWithStrData(PlayerCharDbcHandler.GetStringByOffset(playerchar^.Tutorials),';',itemList);
       if itemsCount > 7 then itemsCount:=7;
       for i:=0 to pred(itemsCount) do
         Tutorials[i] := itemList[i];

  itemsCount:=FillIntArrWithStrData(PlayerCharDbcHandler.GetStringByOffset(playerchar^.TaxiMask),';',itemList);
       if itemsCount > 7 then itemsCount:=7;
       for i:=0 to pred(itemsCount) do
        TaxiMask[i] := itemList[i];

  //Экшен кнопки
  pActionBar := ActionBarDbcHandler.GetPointerPRValueByIntKey(ID);
  if pActionBar <> nil then
    for  i:=0 to 119 do
      actionsButtons[i] := pActionBar^.ActionBar[i]
  else begin //Если у нас там пусто
    actionsButtons[0] := 6603;         //Добавляем чару по дефолту атаку :)
    for  i:=1 to 119 do
      actionsButtons[i] := 0;
     end;

  FriendList := PlayerCharDbcHandler.GetStringByOffset(playerchar^.FriendList);
  IgnoreList := PlayerCharDbcHandler.GetStringByOffset(playerchar^.IgnoreList);

  AmmoId := playerchar^.Ammo ;

  case healthCurrValue of
    0: state  := DEATH_STATE_DEAD;
    1: state  := DEATH_STATE_GHOST;
  else state     := DEATH_STATE_ALIVE;
  end;
end;

procedure TCharacter.InitUpdateArray;
var
   i,sCount: integer;
   temp_arr: array of integer;
begin
     //inherited InitUpdateArray; //only PLAYER info after that

     SetUpdateBits(self,objGUID,integer(OBJECT_FIELD_GUID));
     SetUpdateBits(self,integer(TYPE_PLAYER or TYPE_UNIT or TYPE_OBJECT),OBJECT_FIELD_TYPE);

    // SetUpdateBits(self,integer(0),OBJECT_FIELD_ENTRY);

     SetUpdateBits(self,Size,OBJECT_FIELD_SCALE_X);
     SetUpdateBits(self,healthCurrValue,UNIT_FIELD_HEALTH);
     SetUpdateBits(self,powerCurrValue[powertype],UNIT_FIELD_POWER1+powertype);
     //temp
     SetUpdateBits(self,healthCurrValue,UNIT_FIELD_MAXHEALTH);

     //temp
     SetUpdateBits(self,integer(0),UNIT_FIELD_POWER1+powertype);
     SetUpdateBits(self,integer(100),UNIT_FIELD_MAXPOWER1+powertype);

     SetUpdateBits(self,Level,UNIT_FIELD_LEVEL);
     SetUpdateBits(self,Faction,UNIT_FIELD_FACTIONTEMPLATE);
     SetUpdateBits(self,pgcr,UNIT_FIELD_BYTES_0);
     SetUpdateBits(self,8,UNIT_FIELD_FLAGS);

     //temp
     SetUpdateBits(self,integer(2000),UNIT_FIELD_BASEATTACKTIME);
     SetUpdateBits(self,integer(2000),UNIT_FIELD_BASEATTACKTIME+1);
     SetUpdateBits(self,integer(2000),UNIT_FIELD_RANGEDATTACKTIME);
     SetUpdateBits(self,integer(10),UNIT_FIELD_MINDAMAGE);
     SetUpdateBits(self,integer(15),UNIT_FIELD_MAXDAMAGE);
     SetUpdateBits(self,integer(10),UNIT_FIELD_MINOFFHANDDAMAGE);
     SetUpdateBits(self,integer(15),UNIT_FIELD_MAXOFFHANDDAMAGE);
     SetUpdateBits(self,integer(10),UNIT_FIELD_MINRANGEDDAMAGE);
     SetUpdateBits(self,integer(15),UNIT_FIELD_MAXRANGEDDAMAGE);

     SetUpdateBits(self,Model,UNIT_FIELD_DISPLAYID);
     SetUpdateBits(self,Model,UNIT_FIELD_NATIVEDISPLAYID);
     {SetUpdateBits(self,integer(0),UNIT_FIELD_MOUNTDISPLAYID);
     SetUpdateBits(self,integer(0),UNIT_FIELD_BYTES_1);  //standing
     //SetUpdateBits(self,integer($EEEEEE00),UNIT_FIELD_BYTES_2);
     //aura...
     {for i:=0 to 63 do RaiseBits(UNIT_FIELD_AURA+i);
     for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURAFLAGS+i);
     for i:=0 to 7 do RaiseBits(UNIT_FIELD_AURALEVELS+i);
     for i:=0 to 15 do RaiseBits(UNIT_FIELD_AURAAPPLICATIONS+i);
     RaiseBits(UNIT_FIELD_AURASTATE);}


     SetUpdateBits(self,boundingRadius,UNIT_FIELD_BOUNDINGRADIUS);
     SetUpdateBits(self,combatReach,UNIT_FIELD_COMBATREACH);

     SetUpdateBits(self,integer($10),UNIT_DYNAMIC_FLAGS);   //later
     SetUpdateBits(self,integer(0),UNIT_NPC_FLAGS);





     
     SetUpdateBits(self,Flags,PLAYER_FLAGS);   //8 ?

     SetUpdateBits(self,hairFaceSkin,PLAYER_BYTES);
     SetUpdateBits(self,rest_state_f_hair,PLAYER_BYTES_2);
     //SetUpdateBits(self,integer(0),PLAYER_BYTES_3);  //honor
     //RaiseBits(PLAYER_FIELD_BYTES);   //additional bars

     for i:=0 to 19 do  //set by ActiveQuests
         if UpdateArray[PLAYER_QUEST_LOG_1_1+i*3]<>0 then
         begin
              //Fill active quests here
              RaiseBits(PLAYER_QUEST_LOG_1_1+i*3);
              RaiseBits(PLAYER_QUEST_LOG_1_1+i*3+1);
              RaiseBits(PLAYER_QUEST_LOG_1_1+i*3+2);
         end;
     //temp fix
     SetUpdateBits(self,cXp,PLAYER_XP);
     SetUpdateBits(self,cNextLvlXp,PLAYER_NEXT_LEVEL_XP);

     //skills
     setlength(temp_arr,500);
     sCount:=(FillIntArrWithStrData(cSkills,';',temp_arr) div 3)-1;
     for i:=0 to sCount do
     begin
          SetUpdateBits(self,temp_arr[i*3],PLAYER_SKILL_INFO_1_1+i*3);
          SetUpdateBits(self,temp_arr[i*3+1]or(temp_arr[i*3+2] shl 16),PLAYER_SKILL_INFO_1_1+i*3+1);
          SetUpdateBits(self,integer(0),PLAYER_SKILL_INFO_1_1+i*3+2);
     end;

     RaiseBits(PLAYER_CHARACTER_POINTS1); //talents

     //for (int i = 0 ; i < 32 ; i++)//	ZONE UPDATE
     //PLAYER_EXPLORED_ZONES_1 + i
     //SetUpdateBits(Self, $FFFF, PLAYER_EXPLORED_ZONES_1);

     //items
     CalculateItemsBonusStats;
     for i:=0 to 15 do //only first bag, rest later
         if (cItems[i+INVENTORY_SLOT_ITEM_START] <> nil)and(cItems[i+INVENTORY_SLOT_ITEM_START].ID > 0) then
         begin
              SetUpdateBits(self,cItems[i+INVENTORY_SLOT_ITEM_START].objGUID,PLAYER_FIELD_PACK_SLOT_1+i*2);
              SetUpdateBits(cItems[i+INVENTORY_SLOT_ITEM_START],cItems[i+INVENTORY_SLOT_ITEM_START].item_count,integer(ITEM_FIELD_STACK_COUNT));
         end;

     SetUpdateBits(self,integer(0),PLAYER_REST_STATE_EXPERIENCE);
     //set crits,agi,etc stats by item info, but should be same from last save except rest state/xp
     SetUpdateBits(self,copper,PLAYER_FIELD_COINAGE);
     {RaiseBits(PLAYER_FIELD_POSSTAT0);
     RaiseBits(PLAYER_FIELD_POSSTAT1);
     RaiseBits(PLAYER_FIELD_POSSTAT2);
     RaiseBits(PLAYER_FIELD_POSSTAT3);
     RaiseBits(PLAYER_FIELD_POSSTAT4);
     RaiseBits(PLAYER_FIELD_NEGSTAT0);
     RaiseBits(PLAYER_FIELD_NEGSTAT1);
     RaiseBits(PLAYER_FIELD_NEGSTAT2);
     RaiseBits(PLAYER_FIELD_NEGSTAT3);
     RaiseBits(PLAYER_FIELD_NEGSTAT4);}

     {RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+1);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+2);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+3);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+4);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+5);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+6);

     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+1);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+2);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+3);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+4);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+5);
     RaiseBits(PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+6);

     RaiseBits(PLAYER_FIELD_MOD_DAMAGE_DONE_POS);
     RaiseBits(PLAYER_FIELD_MOD_DAMAGE_DONE_NEG);
     RaiseBits(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT);  }

     RaiseBits(PLAYER_AMMO_ID);
end;

procedure TCharacter.InitUpdateArrayForOthers;
var
   i: integer;
begin
     inherited InitUpdateArrayForOthers;
     RaiseBits(UNIT_FIELD_BYTES_0);
     RaiseBits(UNIT_FIELD_BYTES_1);
     RaiseBits(PLAYER_FLAGS);

     RaiseBits(PLAYER_BYTES);
     RaiseBits(PLAYER_BYTES_2);

     //items
     for i:=0 to EQUIPMENT_SLOT_TABARD do
         if (cItems[i] <> nil)and(cItems[i].ID > 0) then
         begin
              RaiseBits(PLAYER_VISIBLE_ITEM_1_0+i*12);
              RaiseBits(PLAYER_FIELD_INV_SLOT_HEAD+i*2);
         end;

end;

procedure TCharacter.RemoveItem(slot: integer);
var
   i,visible_base: integer;
begin
     if cItems[slot]=nil then exit;
     cItems[slot]:=nil;
     if slot <= EQUIPMENT_SLOT_TABARD then
     begin
          visible_base:=PLAYER_VISIBLE_ITEM_1_0+slot*12;
          for i:=0 to 11 do SetUpdateBits(self,integer(0),visible_base+i);
          SetUpdateBits(self,int64(0),PLAYER_FIELD_INV_SLOT_HEAD+slot*2);
     end
     else if slot <= BANK_SLOT_BAG_END { INVENTORY_SLOT_ITEM_END} then
          SetUpdateBits(self,int64(0),PLAYER_FIELD_INV_SLOT_HEAD+slot*2);
end;

procedure TCharacter.RemoveItemFromBag(bag,slot: integer);
var
   bagItem: TItem;
begin
     if bag=SLOT_CHARACTER then RemoveItem(slot)
     else begin
          if cBagItems[bag,slot]=nil then exit;
          bagItem:=cItems[bag];
          if bagItem=nil then exit;
          cBagItems[bag,slot]:=nil;
          if slot < bagItem.PItemRecord^.ContainerSlots then //can ever client send > then?
               SetUpdateBits(bagItem,int64(0),CONTAINER_FIELD_SLOT_1+slot*2);
     end;
end;

procedure TCharacter.RemoveItemCountFromBag(bag,slot,count: integer);
var
   bagItem: TItem;
begin
     if bag=SLOT_CHARACTER then
     begin
          if cItems[slot]=nil then exit;
          cItems[slot].item_count:=cItems[slot].item_count-count;
          if cItems[slot].item_count > 0 then
             SetUpdateBits(cItems[slot],cItems[slot].item_count,integer(ITEM_FIELD_STACK_COUNT))
          else RemoveItem(slot);
     end
     else begin
          if cBagItems[bag,slot]=nil then exit;
          bagItem:=cItems[bag];
          if bagItem=nil then exit;
          cBagItems[bag,slot].item_count:=cBagItems[bag,slot].item_count-count;
          if cBagItems[bag,slot].item_count > 0 then
             SetUpdateBits(cBagItems[bag,slot],cBagItems[bag,slot].item_count,integer(ITEM_FIELD_STACK_COUNT))
          else if slot < bagItem.PItemRecord^.ContainerSlots then //can ever client send > then?
               SetUpdateBits(bagItem,int64(0),CONTAINER_FIELD_SLOT_1+slot*2);
     end;
end;

function  ItemAndBagCompatible(item,bag: TItem):boolean;
begin
     result:=true;
     if (bag.PItemRecord^.item_Class=11) then
     begin
          if (item.PItemRecord^.item_Class<>6) then result:=false
          else if (bag.PItemRecord^.item_SubClass<>item.PItemRecord^.item_SubClass) then result:=false;
     end;
end;

function TCharacter.AddItem(item: TItem; slot: integer):boolean;
begin
     result:=false;
     if item = nil then exit;
     if slot <= EQUIPMENT_SLOT_TABARD then
     begin
          //check can char equip or not, only 1 ammo pouch/quiver etc!!!
          if (item.PItemRecord^.RequiredLevel > Level) then
          begin
               SwapFailedResponce((Owner as TPlayer),EQUIP_ERR_YOU_MUST_REACH_LEVEL_N,item);
               exit;
          end;
          if ((item.PItemRecord^.AllowableClass and bClass)=0)or
             ((item.PItemRecord^.AllowableRace and bRace)=0)then
          begin
               SwapFailedResponce((Owner as TPlayer),EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM,item);
               exit;
          end;
          //if count>1 then begin SwapFailedResponce((Owner as TPlayer),EQUIP_ERR_ITEM_CANT_BE_EQUIPPED,item);exit;end;
          cItems[slot]:=item;
          //cItems[slot].item_count:=count;
          SetUpdateBits(self,item.ID,PLAYER_VISIBLE_ITEM_1_0+slot*12);
          SetUpdateBits(self,item.objGUID,PLAYER_FIELD_INV_SLOT_HEAD+slot*2);
          result:=true;
     end
     else if slot <= BANK_SLOT_BAG_END{INVENTORY_SLOT_ITEM_END} then
     begin
          cItems[slot]:=item;
          //cItems[slot].item_count:=count;
          SetUpdateBits(self,item.objGUID,PLAYER_FIELD_INV_SLOT_HEAD+slot*2);
          SetUpdateBits(item,item.item_count,integer(ITEM_FIELD_STACK_COUNT));
          result:=true;
     end;
end;

function TCharacter.AddItem2Bag(item: TItem; bag,slot: integer):boolean;
var
   bagItem: TItem;
begin
     result:=false;
     if item = nil then exit;
     if bag=SLOT_CHARACTER then result:=AddItem(item,slot)
     else begin
          bagItem:=cItems[bag];
          if bagItem=nil then exit;
          if slot < bagItem.PItemRecord^.ContainerSlots then
          begin
               if not(ItemAndBagCompatible(item,bagItem))then
               begin
                    SwapFailedResponce((Owner as TPlayer),EQUIP_ERR_ONLY_AMMO_CAN_GO_HERE,item);
                    exit;
               end;
               cBagItems[bag,slot]:=item;
               SetUpdateBits(bagItem,item.objGUID,CONTAINER_FIELD_SLOT_1+slot*2);
               SetUpdateBits(item,item.item_count,integer(ITEM_FIELD_STACK_COUNT));
               result:=true;
          end;
     end;
end;

function TCharacter.AddItemCount2Bag(item: TItem; bag,slot,count: integer):boolean;
var
   bagItem: TItem;
begin
     result:=false;
     if item = nil then exit;
     if bag=SLOT_CHARACTER then
     begin
          if cItems[slot]=nil then result:=AddItem(item,slot)
          else begin
               cItems[slot].item_count:=cItems[slot].item_count+count;
               if cItems[slot].item_count > cItems[slot].PItemRecord^.MaxCount then
                  cItems[slot].item_count:=cItems[slot].PItemRecord^.MaxCount;
               SetUpdateBits(cItems[slot],cItems[slot].item_count,integer(ITEM_FIELD_STACK_COUNT));
               result:=true;
          end;
          
     end
     else begin
          bagItem:=cItems[bag];
          if bagItem=nil then exit;
          if slot < bagItem.PItemRecord^.ContainerSlots then //possible?
          begin
               if not(ItemAndBagCompatible(item,bagItem))then
               begin
                    SwapFailedResponce((Owner as TPlayer),EQUIP_ERR_ONLY_AMMO_CAN_GO_HERE,item);
                    exit;
               end
               else if cBagItems[bag,slot]=nil then result:=AddItem2Bag(item,bag,slot)
               else begin
                    cBagItems[bag,slot].item_count:=cBagItems[bag,slot].item_count+count;
                    if cBagItems[bag,slot].item_count > cBagItems[bag,slot].PItemRecord^.MaxCount then
                       cBagItems[bag,slot].item_count:=cBagItems[bag,slot].PItemRecord^.MaxCount;
                    SetUpdateBits(cBagItems[bag,slot],cBagItems[bag,slot].item_count,integer(ITEM_FIELD_STACK_COUNT));
                    result:=true;
               end;
          end;
     end;
end;

function IsBagSlot(Slot: Byte): Boolean;
begin
  Result := (Slot >= INVENTORY_SLOT_BAG_1) and (Slot <= INVENTORY_SLOT_BAG_4);
end;

function IsBankBagSlot(Slot: Byte): Boolean;
begin
  Result := (Slot >= BANK_SLOT_BAG_1) and (Slot <= BANK_SLOT_BAG_6);
end;

function TCharacter.SwapBagItems(srcbag,srcslot,dstbag,dstslot: byte):boolean;
var
  srcitem,dstitem: TItem;
  add_count,dst_count: integer;
  chkresult: TInventoryChangeFailure;
begin
  result:=false;
  srcitem:=GetBagItem(srcbag,srcslot);
  dstitem:=GetBagItem(dstbag,dstslot);

  //Проверка что в слот банка для сумок ложим сумку
  if (srcitem <> nil) and IsBankBagSlot(dstslot) then
    if inventory_type2equip_slot[srcitem.PItemRecord^.InventoryType] = EQUIPMENT_SLOT_NONE then begin
      SwapFailedResponce((Owner as TPlayer), EQUIP_ERR_NOT_A_BAG, srcitem);
      exit;
  end;
  
  if (dstitem <> nil) and IsBankBagSlot(srcslot) and (inventory_type2equip_slot[dstitem.PItemRecord^.InventoryType] = EQUIPMENT_SLOT_NONE) then begin
      SwapFailedResponce((Owner as TPlayer), EQUIP_ERR_ITEM_DOESNT_GO_INTO_BAG, srcitem);
      SwapFailedResponce((Owner as TPlayer), EQUIP_ERR_NONE, dstitem);exit;
  end;

  //Проверка что в слот для сумок ложим сумку
  if (dstitem <> nil) and IsBagSlot(srcslot) and (inventory_type2equip_slot[dstitem.PItemRecord^.InventoryType] = EQUIPMENT_SLOT_NONE) then begin SwapFailedResponce((Owner as TPlayer), EQUIP_ERR_ITEM_DOESNT_GO_INTO_BAG, srcitem); SwapFailedResponce((Owner as TPlayer), EQUIP_ERR_NONE, dstitem);exit; end;

  chkresult:=CheckBagExists(srcbag);
     if chkresult<>EQUIP_ERR_OK then begin SwapFailedResponce((Owner as TPlayer),chkresult);exit;end;
     chkresult:=CheckBagExists(dstbag);
     if chkresult<>EQUIP_ERR_OK then begin SwapFailedResponce((Owner as TPlayer),chkresult);exit;end;
     chkresult:=IsBag_IsEmpty(srcitem,srcslot);
     if chkresult<>EQUIP_ERR_OK then begin SwapFailedResponce((Owner as TPlayer),chkresult,srcitem);exit;end;
     chkresult:=IsBag_IsEmpty(dstitem,dstslot);
     if chkresult<>EQUIP_ERR_OK then begin SwapFailedResponce((Owner as TPlayer),chkresult,dstitem);exit;end;
     if (srcslot=dstbag) then  begin SwapFailedResponce((Owner as TPlayer),EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT,srcitem);exit;end;

     if (srcitem<>nil)and(dstitem<>nil)and(srcitem.ID=dstitem.ID)and(dstitem.item_count < dstitem.PItemRecord^.MaxCount) then
     begin
          //make items add
          add_count:=srcitem.item_count;
          dst_count:=add_count+dstitem.item_count;
          if dst_count > dstitem.PItemRecord^.MaxCount then add_count:=add_count-(dst_count - dstitem.PItemRecord^.MaxCount);
          if AddItemCount2Bag(srcitem,dstbag,dstslot,add_count) then
          begin
               RemoveItemCountFromBag(srcbag,srcslot,add_count);
               result:=true;
          end;
     end
     else begin
          result:=true;
          if srcitem<>nil then
          begin
               result:=AddItem2Bag(srcitem,dstbag,dstslot);
               if result then RemoveItemFromBag(srcbag,srcslot);
          end;
          if result and (dstitem<>nil) then
          begin
               result:=AddItem2Bag(dstitem,srcbag,srcslot);
               //if RemoveItemFromBag(dstbag,dstslot);
          end;
     end;
end;

function TCharacter.CheckBagExists(bag: byte): TInventoryChangeFailure;
begin
     result:=EQUIP_ERR_OK;
     if bag<>SLOT_CHARACTER then
     begin
          if cItems[bag]=nil then result:=EQUIP_ERR_NOT_A_BAG
          else if cItems[bag].objType<>TYPEID_CONTAINER then result:=EQUIP_ERR_NOT_A_BAG;
     end;
end;

function TCharacter.IsBag_IsEmpty(item: TItem; slot: byte): TInventoryChangeFailure;
var
   i: integer;
   is_empty: boolean;
begin
     result:=EQUIP_ERR_OK;
     if item=nil then exit;
     if IsBagSlot(SLot) then
     begin
          if item.objType=TYPEID_CONTAINER then
          begin
               is_empty:=true;
               for i:=0 to pred(item.PItemRecord^.ContainerSlots)do
                   if cBagItems[slot][i]<> nil then is_empty:=false;

               if not(is_empty) then result:=EQUIP_ERR_CAN_ONLY_DO_WITH_EMPTY_BAGS;
          end;
     end;
end;

function TCharacter.GetBagItem(bag,slot: byte): TItem;
begin
     result:=nil;
     if bag=SLOT_CHARACTER then result:=cItems[slot]
     else begin
          if cItems[bag]<>nil then
             result:=cBagItems[bag,slot];
     end;
end;

function TCharacter.GetInvFreeSlot: Byte;
var
  i: Integer;
begin
  Result := 255;
  for i := INVENTORY_SLOT_ITEM_1 to INVENTORY_SLOT_ITEM_16 do
    if cItems[i] = nil then begin
      Result := i;
      Break;
    end;
end;

function TCharacter.GetBagFreeSlot(bag: Byte): Byte;
var
  i: Integer;
begin
  Result := 255;

  //сумки на чаре
  if IsBagSlot(bag) then
    for i := 0 to 19 do
      if cBagItems[bag, i] = nil then begin
        Result := i;
        Exit;
      end;

  //сумки в банке
  if IsBankBagSlot(bag) then
    for i := 0 to 19 do
      if BankBagItems[bag, i] = nil then begin
        Result := i;
        Exit;
      end;
end;

function TCharacter.GetSlotByItemGUID(itemguid: Int64; var bag, slot: Byte): Boolean;  //created by Aven 29.03.06
var
  i,j: Integer;
begin
  Result := False;
  //на чаре
  for i := EQUIPMENT_SLOT_HEAD to BANK_SLOT_BAG_END do
    if (cItems[i] <> nil) and (cItems[i].objGUID = itemguid) then begin
      bag := SLOT_CHARACTER;
      slot := i;
      Result := True;
      Exit;
    end;
  //в сумках
  for i := INVENTORY_SLOT_BAG_1 to INVENTORY_SLOT_BAG_4 do
    for j := 0 to 19 do
      if (cBagItems[i,j] <> nil) and (cBagItems[i,j].objGUID = itemguid) then begin
        bag := i;
        slot := j;
        Result := True;
        Exit;
    end;
end;

procedure TCharacter.Teleport(x, y, z, r: single; MapID: Word);
begin
  positionX := x;
  positionY := y;
  positionZ := z;
  positionR := r;
  MapID := MapID;


{  Add2ByteArr(Sender.CurrChar.objGUID,Sender.OutBuff,offs);
  Add2ByteArr(Integer(0),Sender.OutBuff,offs);
  Add2ByteArr(Integer(0),Sender.OutBuff,offs);
  Add2ByteArr(Sender.CurrChar.positionX,Sender.OutBuff,offs);
  Add2ByteArr(Sender.CurrChar.positiony,Sender.OutBuff,offs);
  Add2ByteArr(Sender.CurrChar.positionz,Sender.OutBuff,offs);
  Add2ByteArr(Sender.CurrChar.positionR,Sender.OutBuff,offs);
  Sender.SendPacketWithOpcode(MSG_MOVE_HEARTBEAT,offs); }



{  with TPLayer(Owner).SendBuff do
  begin
       Init(MSG_MOVE_TELEPORT_ACK);
       Add($FF);
       Add(objGUID);
       Add(Integer($80000000));
       Add(word(mapID));
       Add(word($D1EB));
       Add(X);
       Add(y);
       Add(z);
       Add(R);
       Add(Integer(0));
       TPLayer(Owner).SendPacket;
  end;        }

{  with TPLayer(Owner).SendBuff do begin
    Init(SMSG_TRANSFER_PENDING);
    Add(Integer(mapid));
    TPLayer(Owner).SendPacket; 

    Init(SMSG_NEW_WORLD);
    Add(Integer(mapid));
    Add(X);
    Add(y);
    Add(z);
    Add(R);
    TPLayer(Owner).SendPacket;
  end;       }

with TPLayer(Owner).SendBuff do
  begin
       Init(MSG_MOVE_HEARTBEAT);
       Add(objGUID);
       Add(Integer(0));
       Add(Integer(0));
       Add(X);
       Add(y);
       Add(z);
       Add(R);
       TPLayer(Owner).SendPacket;
  end;

  MapCell.CreateObj(Self);  
end;

procedure TCharacter.AddItemToBuyBackSlot(Item: TItem; slot: Integer);
begin
  if Item.PItemRecord <> nil then begin
    if slot >= BUYBACK_SLOT_END then Exit;
//    RemoveItemFromBuyBackSlot(slot);
    m_buybackitems[slot] := Item;

    SetUpdateBits(Self, Item.objGUID, PLAYER_FIELD_VENDORBUYBACK_SLOT_1+slot*2);
    SetUpdateBits(Self, Item.PItemRecord^.SellPrice * Item.item_count, PLAYER_FIELD_BUYBACK_PRICE_1+slot);
    SetUpdateBits(Self, Integer(Round(Now + (30 * 3600))), PLAYER_FIELD_BUYBACK_TIMESTAMP_1+slot);
    BuildSendCharUpdateBlock ;
  end;
end;

procedure TCharacter.RemoveItemFromBuyBackSlot(slot: Integer);
begin
  if slot >= BUYBACK_SLOT_END then Exit;

	m_buybackitems[slot] := nil;

  SetUpdateBits(Self, 0, PLAYER_FIELD_VENDORBUYBACK_SLOT_1+slot*2);
  SetUpdateBits(Self, 0, PLAYER_FIELD_BUYBACK_PRICE_1+slot);
  SetUpdateBits(Self, 0, PLAYER_FIELD_BUYBACK_TIMESTAMP_1+slot);
  BuildSendCharUpdateBlock ;
end;

procedure TCharacter.SetCurrentBuybackSlot(slot: Integer);
begin
  CurrentBuybackSlot := slot mod 12;
end;

procedure TCharacter.SetCopper(NewCopper: Integer);
begin
  copper := NewCopper ;
  SetUpdateBits(Self, NewCopper, PLAYER_FIELD_COINAGE);
  BuildSendCharUpdateBlock;
end;

procedure TCharacter.AddSpell(spell_id: DWORD);
var
  spellInfo: PPackedSpellRecord ;
  Opcode, i, EffectVal, shiftdata: Integer;
  mark, tmpval,value: word;
  op,j: Byte;  //FlatId,
begin
  spellInfo := SpellDbcHandler.GetPointerPRValueByIntKey(spell_id);
  if spellInfo = nil then Exit;

{ Playerspell *newspell;

	newspell = new Playerspell;
	newspell->spellId = spell_id;
    
	uint8 op;
	uint16 tmpslot=slot_id
 }
  mark := 0;
  //tmpval := 0;
  shiftdata := 1;
  //FlatId := 0;
  //op := 0;
  value := 0;

	Opcode := SMSG_SET_FLAT_SPELL_MODIFIER;
    
{	if (tmpslot == 0xffff)
	begin
		uint16 maxid = 0;
		std::list<Playerspell*>::iterator itr;
		for (itr = m_spells.begin(); itr != m_spells.end(); itr++)
		begin
			if ((itr)->slotId > maxid) maxid = (itr)->slotId;
		end;
		tmpslot = maxid + 1;
	end;
	                    }
	for i :=0 to 2 do begin
		if spellInfo^.EffectItemType[i] > 0 then begin
			EffectVal := spellInfo^.EffectItemType[i];
			op := spellInfo^.EffectMiscValue[i];
			tmpval := spellInfo^.EffectBasePoints[i];

			if tmpval <> 0 then begin
				if tmpval > 0 then begin
					value := tmpval + 1;
					mark := 0;
				end else begin
					value  := $FFFF + (tmpval + 2);
					mark := $FFFF;
				end;
			end;

			if spellInfo^.EffectApplyAuraName[i] = 108 then
  			Opcode := SMSG_SET_PCT_SPELL_MODIFIER;

			for j := 0 to 31 do begin
				if (EffectVal > 0) and (shiftdata > 0) then
        with TPlayer(owner).SendBuff do
        begin
					//FlatId := i;
          Init(Opcode);
          Add(byte(i));  //FlatId
          Add(op);
          Add(value);
          Add(mark);
          TPlayer(owner).SendPacket;
				end;
				shiftdata := shiftdata shl 1;
			end;
		end;
	end;

  cSpells := cSpells + IntToStr(spellinfo^.ID) + ';' ;
{	newspell->slotId = tmpslot;
	m_spells.push_back(newspell); }
end;

procedure TCharacter.EnvironmentalDamage(Guid: Int64; dmg_type: Byte; Amount: Longword) ;
begin
  with TPlayer(owner).SendBuff do
  begin
       Init(SMSG_ENVIRONMENTALDAMAGELOG);
       Add(Guid);
       Add(dmg_type);
       Add(Amount);
       Add(Integer(0));
       Add(Integer(0));
	     TPlayer(owner).SendPacket;
  end;

  if healthCurrValue > Amount then
    Health := healthCurrValue - Amount
  else
    Health := 0 ;
end;

procedure TCharacter.StartMirrorTimer(TimerType: Byte; MaxValue: Integer);
begin
	//TYPE: 0 = fartigua 1 = breath 2 = fire?
  with TPlayer(owner).SendBuff do begin
    Init(SMSG_START_MIRROR_TIMER);
    Add(Integer(TimerType));
    Add(MaxValue);
    Add(MaxValue);
    Add(Integer(-1)); //BreathRegen
	  Add(Integer(0));
    Add(Byte(0));
    TPlayer(owner).SendPacket;
	end;
end;

procedure TCharacter.StopMirrorTimer(TimerType: Byte);
begin
  with TPlayer(owner) do begin
    SendBuff.Init(SMSG_STOP_MIRROR_TIMER);
    SendBuff.Add(Integer(TimerType));
    SendPacket;
	end;
end;

procedure TCharacter.Kill;
var
  i: Integer;
begin
  Health := 0;

  with TPlayer(Owner).SendBuff do begin
    Init(SMSG_FORCE_MOVE_ROOT);
    Add($FF);
    Add(objGUID);
    TPlayer(Owner).SendPacket ;
  end;

  for i := 0 to 2 do
    with TPlayer(Owner).SendBuff do begin
      Init(SMSG_STOP_MIRROR_TIMER);
       Add(Integer(i));
      TPlayer(Owner).SendPacket ;
    end;

  TPlayer(Owner).CurrChar.state := DEATH_STATE_DEAD;

//  Sender.CurrChar.Flags := PLAYER_FLAGS_DEAD ;
//  SetUpdateBits(Sender.CurrChar, PLAYER_FLAGS_DEAD, PLAYER_FLAGS);

  SetUpdateBits(Self, PLAYER_STATE_DEAD, UNIT_FIELD_BYTES_1);
  SetUpdateBits(Self, 8 or $40000, UNIT_FIELD_FLAGS);
  SetUpdateBits(Self, UNIT_DYNFLAG_DEAD, UNIT_DYNAMIC_FLAGS);
  BuildSendCharUpdateBlock ;

{  SetUpdateBits(Sender.CurrChar, 1, UNIT_FIELD_HEALTH);
  Sender.CurrChar.BuildSendCharUpdateBlock ;

  offs := 4;
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_MOVE_WATER_WALK, offs);

  offs := 4;
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_FORCE_MOVE_UNROOT, offs);


	//! corpse reclaim delay 30 * 1000ms
  offs := 4;
  Add2byteArr(Integer(30000), Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_CORPSE_RECLAIM_DELAY, offs);

{  offs := 4;
  Add2byteArr(Byte($FF), Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Add2byteArr(Byte($FF), Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Add2byteArr(Integer(8326), Sender.OutBuff, offs);
  Add2byteArr(Word(0), Sender.OutBuff, offs);
  Add2byteArr(Integer(0), Sender.OutBuff, offs);
  Add2byteArr(Word($02), Sender.OutBuff, offs);
  Add2byteArr(Integer(0), Sender.OutBuff, offs);
  Add2byteArr(Integer(0), Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_SPELL_START, offs);

  offs := 4;
  Add2byteArr(Byte(32), Sender.OutBuff, offs);
  Add2byteArr(Integer(0), Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_UPDATE_AURA_DURATION, offs);

  offs := 4;
  Add2byteArr(Integer(8326), Sender.OutBuff, offs);
  Add2byteArr(Byte(0), Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_CAST_RESULT, offs);

  offs := 4;
  Add2byteArr(Byte($FF), Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Add2byteArr(Byte($FF), Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Add2byteArr(Integer(8326), Sender.OutBuff, offs);
  Add2byteArr(Word(01), Sender.OutBuff, offs);
  Add2byteArr(Byte(0), Sender.OutBuff, offs);
  Add2byteArr(Byte(0), Sender.OutBuff, offs);
  Add2byteArr(Word(0040), Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.positionX, Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.positionY, Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.positionZ, Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_SPELL_GO, offs);

  offs := 4;
  Add2byteArr(Byte($FF), Sender.OutBuff, offs);
  Add2byteArr(Integer(Sender.CurrChar.objGUID), Sender.OutBuff, offs);
  Add2byteArr(Byte($FF), Sender.OutBuff, offs);
  Add2byteArr(Integer(Sender.CurrChar.objGUID), Sender.OutBuff, offs);
  Add2byteArr(Integer(8326), Sender.OutBuff, offs);
  Add2byteArr(Integer(1), Sender.OutBuff, offs);
  Add2byteArr(Integer($24), Sender.OutBuff, offs);
  Add2byteArr(Integer(1), Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Sender.SendPacketWithOpcode(SMSG_SPELLLOGEXECUTE, offs); }
end;

procedure TCharacter.Hearthstone;
begin
  Teleport(BindingpointX, BindingpointY, BindingpointZ,
    BindingpointR, BindingPointMapId);
end;

procedure TCharacter.SetHealth(const Value: longword);
begin
  inherited ;
  if healthCurrValue <= 0 then state := DEATH_STATE_DEAD;
  BuildSendCharUpdateBlock ;
end;

procedure TCharacter.SetRunSpeed(Speed: Single);
begin
  with TPlayer(Owner).SendBuff do begin
    Init(SMSG_FORCE_RUN_SPEED_CHANGE);
    Add($FF);
    Add(objGUID);
    Add(Speed);
    TPlayer(Owner).SendPacket ;
  end;
end;

procedure TCharacter.SetSwimSpeed(Speed: Single);
begin
  with TPlayer(Owner).SendBuff do begin
    Init(SMSG_FORCE_SWIM_SPEED_CHANGE);
    Add($FF);    
    Add(objGUID);
    Add(Speed);
    TPlayer(Owner).SendPacket ;
  end;
end;

procedure TCharacter.Regenerate;
var
  RegenHP: Single;
begin
  if state <> DEATH_STATE_ALIVE then Exit;

  //Регенерация жизни
  if healthCurrValue < healthMaxValue then begin
    if UpdateArray = nil then Exit;
    case cClass of
      ccnWarrior : RegenHP := baseStats[charSpiritBonus] * 0.80;
      ccnPaladin : RegenHP := baseStats[charSpiritBonus] * 0.25;
      ccnHunter  : RegenHP := baseStats[charSpiritBonus] * 0.25;
      ccnRogue   : RegenHP := baseStats[charSpiritBonus] * 0.50 + 2;
      ccnPriest  : RegenHP := baseStats[charSpiritBonus] * 0.10;
      ccnShaman  : RegenHP := baseStats[charSpiritBonus] * 0.11;
      ccnMage    : RegenHP := baseStats[charSpiritBonus] * 0.10;
      ccnWarlock : RegenHP := baseStats[charSpiritBonus] * 0.11;
      ccnDruid   : RegenHP := baseStats[charSpiritBonus] * 0.11;
    else RegenHP := 0;
    end;

    if UpdateArray[UNIT_FIELD_BYTES_1] = 1 then //сидим
      RegenHP := RegenHP * 1.5 ;
    if UpdateArray[UNIT_FIELD_BYTES_1] = 3 then //лежим
      RegenHP := RegenHP * 2 ;

    Health := healthCurrValue + Round(RegenHP) ;
  end;  
end;

procedure TCharacter.GiveXP(Xp: Integer);
var
  i: Integer;
begin
  cXp := cXp + Xp ;
  i := 1;

  while (cXp >= LvlXP[i,1]) and (i<60) do inc(i);

  Level := i;
  if i > 1 then cXP := cXp-LvlXP[i-1,1] ;
  cNextLvlXp := LvlXP[i,0] ;
  
  SetUpdateBits(Self, i, UNIT_FIELD_LEVEL);
  SetUpdateBits(Self, cXp, PLAYER_XP);
  SetUpdateBits(Self, cNextLvlXp, PLAYER_NEXT_LEVEL_XP);
//  BuildSendCharUpdateBlock ;
end;

end.
