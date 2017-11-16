unit CommandHandler; //changed by Aven 12.04.06


interface

uses
  Windows, SysUtils, Graphics, unitMain, OpCodeHandler, OpConst, CharHandler,
  DbcFieldsConst, ChatHandler, ItemHandler, WorldObject, UpdateConst,
  ByteArrayHandler, CellManager, CharConst ;

procedure OnCommand(Sender: TPLayer; msg: String);
//all's cmd
procedure CommandHelp(Sender: TPlayer);
procedure CommandHearthstone(Sender: TPlayer);
procedure CommandId(Sender: TPlayer);
procedure CommandSave(Sender: TPlayer);
procedure CommandSuicide(Sender: TPlayer);
procedure CommandUptime(Sender: TPlayer);
procedure CommandWhere(Sender: TPlayer);

//gm's cmd
procedure CommandInfo(Sender: TPlayer);
procedure CommandBroadcast(Sender: TPlayer; msg: String);
procedure CommandDel(Sender: TPlayer; msg: String);
procedure CommandAdd(Sender: TPlayer; msg: String);
procedure CommandKill(Sender: TPlayer);
procedure CommandSetMoney(Sender: TPlayer; param: String);
procedure CommandSetLevel(Sender: TPlayer; param: String);
procedure CommandSetXp(Sender: TPlayer; param: String);
procedure CommandSetHp(Sender: TPlayer; hp: Integer);
procedure CommandGo(Sender: TPlayer; param: String);
procedure CommandGoTrigger(Sender: TPlayer; param: String);
procedure CommandGoName(Sender: TPlayer; param: String);
procedure CommandNameGo(Sender: TPlayer; param: String);
procedure CommandJail(Sender: TPlayer; param: String);
procedure CommandSetFlags(Sender: TPlayer; param: String);
procedure CommandSaveWorld(Sender: TPlayer);
procedure CommandSetSize(Sender: TPlayer; param: String);
procedure CommandSetSpeed(Sender: TPlayer; speed: Single);
procedure CommandLearn(Sender: TPlayer; spell: Integer);
procedure CommandUnLearn(Sender: TPlayer; spell: Integer);
procedure CommandSetCP(Sender: TPlayer; param: String);
procedure CommandAddSpawn(Sender: TPlayer; msg: String);
procedure CommandTest(Sender: TPlayer; msg: String);
procedure CommandWeather(Sender: TPlayer; msg: String);

//admin's cmd
procedure CommandShutdown(Sender: TPlayer);

implementation

procedure OnCommand(Sender: TPLayer; msg: String);
var
  cmd, param: String;
begin
  //Sender.AccessLevel := 2;
  if Pos(' ', msg) > 1 then begin
    cmd := Copy(msg, 1, Pos(' ', msg)-1);
    param := Copy(msg, Pos(' ', msg)+1, Length(msg));
  end else cmd := msg;

  //Пользовательские команды
  if cmd = '.help' then CommandHelp(Sender);
  if cmd = '.hearthstone' then CommandHearthstone(Sender);
  if cmd = '.id' then CommandId(Sender);  
  if cmd = '.save' then CommandSave(Sender);
  if cmd = '.suicide' then CommandSuicide(Sender);
  if cmd = '.uptime' then CommandUptime(Sender);  
  if cmd = '.where' then CommandWhere(Sender);

  //ГМ-команды
  if Sender.AccessLevel >= 1 then begin
    if cmd = '.add' then CommandAdd(Sender, param);
    if cmd = '.broadcast' then CommandBroadcast(Sender, param);
    if cmd = '.del' then CommandDel(Sender, param);
    if cmd = '.go' then CommandGo(Sender, param);
    if (cmd = '.gotrigger') or (cmd = '.gt') then CommandGoTrigger(Sender, param);
    if cmd = '.goname' then CommandGoName(Sender, param);    
    if cmd = '.info' then CommandInfo(Sender);
    if cmd = '.kill' then CommandKill(Sender);
    if cmd = '.setmoney' then CommandSetMoney(Sender, param);
    if cmd = '.setlevel' then CommandSetLevel(Sender, param);
    if cmd = '.setxp' then CommandSetXp(Sender, param);
    if cmd = '.sethp' then CommandSetHp(Sender, StrToInt(param));
    if cmd = '.namego' then CommandNameGo(Sender, param);
    if cmd = '.jail' then CommandJail(Sender, param);
    if (cmd = '.saveworld') or (cmd = '.sw') then CommandSaveWorld(Sender);
    if cmd = '.setcp' then CommandSetCP(Sender, param);
    if cmd = '.setflags' then CommandSetFlags(Sender, param);
    if cmd = '.setsize' then CommandSetSize(Sender, param);
    if cmd = '.setspeed' then CommandSetSpeed(Sender, StrToFloat(param));
    if cmd = '.learn' then CommandLearn(Sender, StrToInt(param));
    if cmd = '.unlearn' then CommandUnLearn(Sender, StrToInt(param));
    if cmd = '.weather' then CommandWeather(Sender, param);
    if (cmd = '.addspawn') or (cmd = '.as') then CommandAddSpawn(Sender, param);
    if cmd = '.test' then CommandTest(Sender, param);
  end;

  //Админ-команды
  if Sender.AccessLevel = 2 then begin 
    if cmd = '.shutdown' then CommandShutdown(Sender);
  end;
end;

procedure CommandHelp(Sender: TPlayer);
var
  Text: String;
begin
  //Пользовательские команды
  Text := 'Command list:'#13#10'.hearthstone'#13#10'.help'#13#10'.id'#13#10'.save'#13#10'.suicide'#13#10'.uptime'#13#10'.where';

  if Sender.AccessLevel >= 1 then //ГМ-команды
    Text := Text + #13#10'.info'#13#10'.broadcast'#13#10'.add'#13#10+
      '.setmoney'#13#10'.setlevel'#13#10'.setxp'#13#10'.jail'#13#10+
      '.saveworld .sw'#13#10'.goname'#13#10'.namego'#13#10'.gotrigger .gt'#13#10+
      '.setsize'#13#10'.learn'#13#10'.unlearn'#13#10'.setcp'#13#10'.setspeed';

  if Sender.AccessLevel = 2 then //Админ-команды
    Text := Text + #13#10'.shutdown';

  SendSystemChatMessage(Sender, Text);
end;

procedure CommandHearthstone(Sender: TPlayer);
begin
  Sender.CurrChar.Hearthstone ;
end;

procedure CommandId(Sender: TPlayer);
var
  s: String;
begin
  case Sender.AccessLevel of
    0: s := 'Your access level is user (0)';
    1: s := 'Your access level is gm (1)';
    2: s := 'Your access level is admin (2)';
  else s := 'Unknown access level (' + IntToStr(Sender.AccessLevel) + ')';
  end;
  SendSystemChatMessage(Sender, s);
end;

procedure CommandInfo(Sender: TPlayer);
var
  mob: TMobile;
  pcreature: PPackedCreatureRecord ;
begin
  mob := UnitHT_byGUID[Sender.CurrChar.Selected_guid];
  if mob <> nil then begin
    pcreature:=CreaturesDbcHandler.GetPointerPRValueByIntKey(mob.ID);
    if pcreature <> nil then begin
      SendSystemChatMessage(Sender, 'Information:');
      SendSystemChatMessage(Sender, 'Name: ' + CreaturesDbcHandler.GetStringByOffset(pcreature^.name));
      SendSystemChatMessage(Sender, 'ID: ' + IntToStr(mob.ID));
      SendSystemChatMessage(Sender, 'GUID: ' + IntToStr(Integer(mob.objGUID)));
      SendSystemChatMessage(Sender, 'Faction: ' + IntToStr(mob.Faction));
      SendSystemChatMessage(Sender, 'HitPoints: ' + IntToStr(mob.healthMaxValue));
      SendSystemChatMessage(Sender, 'Mana/Rage: ' + IntToStr(mob.powerMaxValue[longword(mob.powerType)]));
      SendSystemChatMessage(Sender, 'Level: ' + IntToStr(mob.Level));
      SendSystemChatMessage(Sender, 'NPCFlags: ' + IntToStr(mob.npcFlags));
      SendSystemChatMessage(Sender, 'Model: ' + IntToStr(mob.Model));            
    end;
  end else SendSystemChatMessage(Sender, 'You must select a mobile before');
end;

procedure CommandBroadcast(Sender: TPlayer; msg: String);
begin
  BroadcastSystemMessage('|c8f'+IntToHex(ColorToRGB(clLime),6)+'<GM>|r |c8fff2020['+Sender.CurrChar.name+']|r |c8f'+IntToHex(ColorToRGB(clLime),6)+ 'to all:|r ' + msg);
end;

procedure CommandDel(Sender: TPlayer; msg: String);
begin
  if WorldDbcHandler.GetPointerPRValueByIntKey(Sender.CurrChar.Selected_guid) <> nil then begin
    MapCell.FindCellRemoveObject(UnitHT_byGUID[Sender.CurrChar.Selected_guid]);
    WorldDbcHandler.RemoveRecordIntKey(Sender.CurrChar.Selected_guid);

    SendSystemChatMessage(Sender, 'Deleted.'); 
  end;
end;

procedure CommandAdd(Sender: TPlayer; msg: String); //changed by Aven 01.04.06
var
  Item: TItem;
  item_id: Integer;
  item_count: Byte;
begin
 try
  if Pos(' ', msg) > 1 then begin
    item_id := StrToInt(Copy(msg, 1, Pos(' ', msg)-1));
    item_count := StrToInt(Copy(msg, Pos(' ', msg)+1, Length(msg)));
  end else begin
    item_id := StrToInt(msg);
    item_count := 1;
  end;
  
  Item := TItem.Create(Sender.CurrChar.objGUID, item_id);
  if Item.PItemRecord = nil then begin
    SendSystemChatMessage(Sender, 'Item: '+IntToStr(item_id) + ' not found!');
    Exit;
  end;
  Item.item_count := item_count;
  Sender.CurrChar.AddItemCount2Bag(Item, SLOT_CHARACTER, Sender.CurrChar.GetInvFreeSlot, item_count);
  Sender.CurrChar.SendPartialCreateItemUpdateBlockForPlayer(Item);
  Sender.CurrChar.BuildSendCharUpdateBlock ;
 except
   AddToLog('Error .add command!');
 end;
end;

procedure CommandKill(Sender: TPlayer);
var
  SelChar: TCharacter;
  SelMob: TMobile;
  _buf: TSendOpcodeArr;
begin
  try
    SelChar :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    SelMob := UnitHT_byGUID[Sender.CurrChar.Selected_guid];
    if SelChar <> nil then
      SelChar.Health := 0
    else if SelMob <> nil then begin
      SelMob.Health := 0 ;
      _buf := TSendOpcodeArr.Create;
      SelMob.CreateUpdateValuesBlockForOthers(_buf);
      SelMob.SendMessageToNearby(_buf);
    end else
      SendSystemChatMessage(Sender, 'You must select a mobile before');
  except
    AddToLog('.kill ERROR!'); 
  end;
end;

procedure CommandSetMoney(Sender: TPlayer; param: String);
begin
  try
    Sender.CurrChar.SetCopper(StrToInt(param));
  except
    SendSystemChatMessage(Sender, 'Sintax: .setmoney copper_count');
  end;
end;

procedure CommandSetLevel(Sender: TPlayer; param: String);
var
  Sellected: TCharacter;
begin
  try
    Sellected :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    if Sellected <> nil then begin
      Sellected.Level := StrToInt(param);
      SetUpdateBits(Sender.CurrChar, Sellected.Level, UNIT_FIELD_LEVEL);
      Sellected.BuildSendCharUpdateBlock;
    end else
      SendSystemChatMessage(Sender, 'You must select a player before');
  except
    AddToLog('.setlevel ERROR!'); 
  end;
end;

procedure CommandSetXp(Sender: TPlayer; param: String);//changed by CnApTaK 
var
  Sellected: TCharacter; i:integer;
begin
  try
    Sellected :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    if Sellected <> nil then begin
      Sellected.cXp := StrToInt(param);
      i:=1;

      while (Sellected.cXp>=LvlXP[i,1])and(i<60) do
        inc(i);

      CommandSetLevel(Sender, IntToStr(i));

      if i=1 then
        SetUpdateBits(Sender.CurrChar, Sellected.cXp, PLAYER_XP)
      else
        SetUpdateBits(Sender.CurrChar, Sellected.cXp-LvlXP[i-1,1], PLAYER_XP);

      Sellected.cNextLvlXp := LvlXP[i,0] ;
      SetUpdateBits(Sender.CurrChar, Sellected.cNextLvlXp, PLAYER_NEXT_LEVEL_XP);
      Sellected.BuildSendCharUpdateBlock;
    end else
      SendSystemChatMessage(Sender, 'You must select a player before');
  except
    AddToLog('.setxp ERROR!');
  end;
end;

procedure CommandSetHp(Sender: TPlayer; hp: Integer);
var
  Sellected: TCharacter;
begin
  try
    Sellected :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    if Sellected <> nil then begin
      Sellected.healthMaxValue := hp;
      SetUpdateBits(Sellected, hp, UNIT_FIELD_MAXHEALTH);
      Sellected.Health := hp;
    end else
      SendSystemChatMessage(Sender, 'You must select a player before');
  except
    AddToLog('.sethp ERROR!'); 
  end;
end;

procedure CommandShutdown(Sender: TPlayer);
begin
  Form1.Close;
end;

procedure CommandGo(Sender: TPlayer; param: String);
var
  s,posx,posy,posz,mapid:string;
  semicolon:integer;
begin
  try
    s:=param;
    if s<>'' then begin
      semicolon:=pos(' ',s);
      mapid:=copy(s,1,semicolon-2);
      Delete(s,1,semicolon);
      semicolon:=pos(' ',s);
      posx:=copy(s,1,semicolon-2);
      Delete(s,1,semicolon);
      semicolon:=pos(' ',s);
      posy:=copy(s,1,semicolon-2);
      Delete(s,1,semicolon);
      //semicolon:=pos(' ',s);
      posz:=s;
      sender.CurrChar.Teleport(strtoint(posx),strtoint(posy),strtoint(posz),0,strtoint(mapid));
    end;
  except
    SendSystemChatMessage(Sender, 'Sintax: .go MapID, Xposition, Yposition, Zposition');
  end;
end;

procedure CommandWhere(Sender: TPlayer);
var
  s: String;
begin
  s := 'map='+IntToStr(Sender.CurrChar.mapId)+' zone='+IntToStr(Sender.CurrChar.zoneId)+#13#10+
       'x,y,z,r='+FloatToStr(Sender.CurrChar.positionX)+','+FloatToStr(Sender.CurrChar.positionY)+','+FloatToStr(Sender.CurrChar.positionZ)+','+FloatToStr(Sender.CurrChar.positionR)  ;
  SendSystemChatMessage(Sender, s);
end;

procedure CommandJail(Sender: TPlayer; param: String); //TODO доделать время
const                                                  //когда чара вернет назад
  JailX = -7463;
  JailY = -1083;
  JailZ = 897;
  JailMapId = 0;
var
  Sellected: TCharacter;
  param_tmp, p1,p2: String;
  days, hours, minutes: Integer;
begin
  try
    if param = '' then begin
      SendSystemChatMessage(Sender, 'Sintax: .jail days hours minutes');
      Exit;
    end;

    p1:='';p2:='';param_tmp:='';
    if Pos(' ', param) > 1 then begin
      p1 := Copy(param, 1, Pos(' ', param)-1);
      param_tmp := Copy(param, Pos(' ', param)+1, Length(param));
    end;
    if Pos(' ', param_tmp) > 1 then begin
      p2 := Copy(param_tmp, 1, Pos(' ', param_tmp)-1);
      param_tmp := Copy(param_tmp, Pos(' ', param_tmp)+1, Length(param_tmp));
    end;

    if p2 <> '' then begin
      days := StrToInt(p1);
      hours := StrToInt(p2);
      minutes := StrToInt(param_tmp);
    end else
    if p1 <> '' then begin
      days := 0;
      hours := StrToInt(p1);
      minutes := StrToInt(param_tmp);
    end else begin
      days := 0;
      hours := 0;
      minutes := StrToInt(param);
    end;  

    Sellected :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    if Sellected <> nil then begin
      Sellected.Teleport(JailX,JailY,JailZ,0,JailMapId);
      SendSystemChatMessage(TPlayer(Sellected.Owner), 'You have been jailed on '+IntToStr(Days)+' days, '+IntToStr(hours)+' hours, '+IntToStr(minutes)+' minutes');
    end else
      SendSystemChatMessage(Sender, 'You must select a player before');
  except
    AddToLog('.jail ERROR');
  end;
end;

procedure CommandSave(Sender: TPlayer);
begin
  SaveCharToDBC(Sender);
  SendSystemChatMessage(Sender, 'Char saved.');
end;

procedure CommandSaveWorld(Sender: TPlayer);
begin
  SaveAll ;
end;

procedure CommandSuicide(Sender: TPlayer);
begin
  Sender.CurrChar.Health := 0 ; 
end;

procedure CommandUptime(Sender: TPlayer);
var
  CurTime: TDateTime;
begin
  CurTime := Now ;
  SendSystemChatMessage(Sender, 'Current Server Time: ' + DateTimeToStr(CurTime) + ', up ' + DateTimeToStr(CurTime - StartTime));
end;

procedure CommandSetFlags(Sender: TPlayer; param: String);
var
  Sellected: TCharacter;
begin
  try
    Sellected :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    if Sellected <> nil then begin
      Sellected.Flags := StrToInt(param);
      Sellected.InitUpdateArray;
      Sellected.BuildSendCharUpdateBlock;
    end else
      SendSystemChatMessage(Sender, 'You must select a player before');
  except
    SendSystemChatMessage(Sender, 'Sintax: .setflags flags');
  end;
end;

procedure CommandGoTrigger(Sender: TPlayer; param: String);
var
  trig: PPackedAreaTrigger;
begin
  try
    trig := AreaTriggerDbcHandler.GetPointerPRValueByIntKey(StrToInt(param));
    if trig <> nil then
        Sender.CurrChar.Teleport(trig^.positionX, trig^.positionY, trig^.positionZ, 0, trig^.mapId)
    else
      SendSystemChatMessage(Sender, 'Player not found');
  except
    SendSystemChatMessage(Sender, 'Sintax: .gotrigger trigger_id');
  end;
end;

procedure CommandGoName(Sender: TPlayer; param: String);
var
  Player: TPlayer;
begin
  try
    Player :=  GetPlayerByName(param);
    if Player <> nil then
      with Player.CurrChar do
        Sender.CurrChar.Teleport(positionX, positionY, positionZ, positionR, mapId)
    else
      SendSystemChatMessage(Sender, 'Player not found');
  except
    SendSystemChatMessage(Sender, 'Sintax: .goname char_name');
  end;
end;

procedure CommandNameGo(Sender: TPlayer; param: String);
var
  Player: TPlayer;
begin
  try
    Player :=  GetPlayerByName(param);
    if Player <> nil then
      with Sender.CurrChar do
        Player.CurrChar.Teleport(positionX, positionY, positionZ, positionR, mapId)
    else
      SendSystemChatMessage(Sender, 'Player not found');
  except
    SendSystemChatMessage(Sender, 'Sintax: .namego char_name');
  end;
end;

procedure CommandSetSize(Sender: TPlayer; param: String);
var
  Sellected: TCharacter;
begin
  try
    Sellected :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    if Sellected <> nil then begin
      Sellected.Size := StrToFloat(param);
      SetUpdateBits(Sellected, Sellected.Size, OBJECT_FIELD_SCALE_X);
      Sellected.BuildSendCharUpdateBlock;
    end else
      SendSystemChatMessage(Sender, 'You must select a player before');
  except
    SendSystemChatMessage(Sender, 'Sintax: .setsize size');
  end;
end;

procedure CommandSetSpeed(Sender: TPlayer; speed: Single);
var
  Sellected: TCharacter;
begin
  try
    Sellected :=  PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
    if Sellected <> nil then begin
      //Sellected.RunSpeed := speed;
      Sellected.SetRunSpeed(speed);
    end else
      SendSystemChatMessage(Sender, 'You must select a player before');
  except
    SendSystemChatMessage(Sender, 'Sintax: .setspeed speed');
  end;
end;

procedure CommandLearn(Sender: TPlayer; spell: Integer);
begin
  Sender.CurrChar.AddSpell(spell);

  Sender.SendBuff.Init(SMSG_LEARNED_SPELL);
  Sender.SendBuff.Add(spell);
  Sender.SendPacket;
end;

procedure CommandUnLearn(Sender: TPlayer; spell: Integer);
begin
  Sender.SendBuff.Init(SMSG_REMOVED_SPELL);
  Sender.SendBuff.Add(spell);
  Sender.SendPacket;
end;

procedure CommandSetCP(Sender: TPlayer; param: String);
begin
  try
    SetUpdateBits(Sender.CurrChar, StrToInt(param), PLAYER_CHARACTER_POINTS1);
    Sender.CurrChar.BuildSendCharUpdateBlock ;
  except
  end;
end;

procedure CommandAddSpawn(Sender: TPlayer; msg: String);
var
  world_spawn: TPackedSpawnRecord;
//  pspawn: PPackedSpawnRecord ;
//  spawn: TSpawnCellObject;
  guid: Integer;
begin
  FillChar(world_spawn, SizeOf(world_spawn), 0);

  world_spawn.WorldSpawn_TYPE := 3;
  world_spawn.WorldSpawn_X := Sender.CurrChar.positionX;
  world_spawn.WorldSpawn_Y := Sender.CurrChar.positionY;
  world_spawn.WorldSpawn_Z := Sender.CurrChar.positionZ ;
  world_spawn.WorldSpawn_R := Sender.CurrChar.positionR ;
  world_spawn.WorldSpawn_MAP := Sender.CurrChar.mapId;
  world_spawn.WorldSpawn_SPAWN := StrToInt(msg); //299 ;
  
//  world_spawn.WorldSpawn_MODEL := 262;
//  world_spawn.WorldSpawn_ENTRY := 1;
//  world_spawn.WorldSpawn_FLAGS := $80000000;
//  world_spawn.WorldSpawn_GTYPE  := 0;
//  world_spawn.WorldSpawn_MAXHEALTH := 0;
//  world_spawn.WorldSpawn_LEVEL := 1;

  guid := WorldDbcHandler.AddRecord(@world_spawn);
  WorldDbcHandler.SaveDbc ;

 { pspawn :=} WorldDbcHandler.GetPointerPRValueByIntKey(guid);

//  spawn:=TSpawnCellObject.Create(pspawn^.WorldSpawn_ID,pspawn^.WorldSpawn_TYPE,pspawn^.WorldSpawn_X,pspawn^.WorldSpawn_Y,pspawn^.WorldSpawn_MAP);
//  MapCell.CreateSpawn(spawn);

  //Sender.CurrChar.BuildSendCharUpdateBlock ;

  AddToLog('Spawned ID=' + msg + ' GUID=' + IntTOStr(guid));
  SendSystemChatMessage(Sender, 'Spawned ID=' + msg + ' GUID=' + IntTOStr(guid));
end;

procedure CommandTest(Sender: TPlayer; msg: String);
begin

end;

procedure CommandWeather(Sender: TPlayer; msg: String);
begin
  if msg <> '' then begin
    WM.WeatherType := StrToInt(msg);
    WM.WeatherIntensity := 5 ;
    WM.Start(Sender) ;
  end else WM.Stop(Sender);    
end;

end.


