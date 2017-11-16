unit GroupHandler; //Реализация группы (пати) 14.04.06

interface

uses Windows, SysUtils, CharHandler, OpcodeHandler, OpConst, ByteArrayHandler, UnitMain, UpdateConst;

const
  MAXGROUPSIZE = 5;

type
  MemberSlot = record
    name: String;
    guid: Int64;
   end;       

  TGroup = class(TObject)
  private
  public
    m_count: Byte;
    m_leaderGuid: Int64;
    m_lootMethod: Byte;
    m_looterGuid: Int64;
    m_grouptype: Byte;
    m_leaderName: String; //Имя лидера группы
    m_members: array [0..MAXGROUPSIZE-1] of MemberSlot;
    constructor Create(leaderGuid: Int64; leader_name: string);
    procedure AddMember(guid: Int64; char_name: String);
    function RemoveMember(guid: Int64): Byte;
    procedure ChangeLeader(guid: Int64);
    procedure SendUpdate;
    procedure Disband;
  end;

procedure CMSG_GROUP_INVITE_handler(Sender: TPlayer);
procedure CMSG_GROUP_CANCEL_handler(Sender: TPlayer);
procedure CMSG_GROUP_ACCEPT_handler(Sender: TPlayer);
procedure CMSG_GROUP_DECLINE_handler(Sender: TPlayer);
procedure CMSG_GROUP_UNINVITE_handler(Sender: TPlayer);
procedure CMSG_GROUP_UNINVITE_GUID_handler(Sender: TPlayer);
procedure CMSG_GROUP_SET_LEADER_handler(Sender: TPlayer);
procedure CMSG_LOOT_METHOD_handler(Sender: TPlayer);
procedure CMSG_GROUP_DISBAND_handler(Sender: TPlayer);
procedure UMSG_UPDATE_GROUP_MEMBERS_handler(Sender: TPlayer);

implementation

uses WorldObject;

procedure CMSG_GROUP_INVITE_handler(Sender: TPlayer);
var
  char_name: String;
  Player: TPlayer;
  Group: TGroup;
begin
  char_name := StrPas(@Sender.ReceiveBuff.data);
  AddToLog('Player '+Sender.CurrChar.name+' invite '+char_name+' to group.');

//  Group := nil;
//  Player := LoggedPlayersHT[char_name];
  Player := GetPlayerByName(char_name);

  if Player = nil then
  with Sender.SendBuff do begin //Если принимаемого чара не существует
    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(char_name);
    Add(Integer(1));
    Sender.SendPacket;
    Exit;
  end;

  if (Sender.CurrChar.IsInGroup) and (Sender.CurrChar.GroupLeader <> Sender.CurrChar.objGUID) then
  with Sender.SendBuff do begin
    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(Byte(0));
    Add(Integer(6));
    Sender.SendPacket;
    Exit;
  end;

  Group := GroupHT_byGUID[Player.CurrChar.GroupLeader];
  if Group <> nil then
  begin 
    if Group.m_count = MAXGROUPSIZE then //Группа уже полная
    with Sender.SendBuff do begin
      Init(SMSG_PARTY_COMMAND_RESULT);
      Add(Integer(0));
      Add(Byte(0));
      Add(Integer(3));
      Sender.SendPacket;
     end;
  end
  else if Player.CurrChar.IsInGroup then
  with Sender.SendBuff do begin
    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(char_name);
    Add(Integer(4));
    Sender.SendPacket;
    Exit;
  end;
  
  if not Player.CurrChar.IsInvited then
  with Sender.SendBuff do begin
    Init(SMSG_GROUP_INVITE);
    Add(Sender.CurrChar.name);
    Player.SendPacket;

    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(char_name);
    Add(Integer(0));
    Sender.SendPacket;

    Player.CurrChar.GroupLeader := Sender.CurrChar.objGUID ;
    Player.CurrChar.IsInvited := True;
  end;
end;

procedure CMSG_GROUP_CANCEL_handler(Sender: TPlayer);
begin
  AddToLog('Player '+Sender.CurrChar.name+' canceled join to group.');
	Sender.CurrChar.IsInvited := False;
end;

procedure CMSG_GROUP_ACCEPT_handler(Sender: TPlayer);
var
  Player: TPlayer;
  Group: TGroup;  
begin
  Player := GetOnlinePlayerByGuid(Sender.CurrChar.GroupLeader) ;

  if (Player <> nil) and (Sender.CurrChar.IsInvited) then begin
    Sender.CurrChar.IsInvited := False;
    if Player.CurrChar.IsInGroup and (Player.CurrChar.GroupLeader = Player.CurrChar.objGUID) then begin
      Sender.CurrChar.IsInGroup := True;

      Group := GroupHT_byGUID[Sender.CurrChar.GroupLeader];
      if Group <> nil then begin
        Group.AddMember(Sender.CurrChar.objGUID, Sender.CurrChar.name);
        Group.SendUpdate;
      end;
    end else
    if not Player.CurrChar.IsInGroup then begin
        Player.CurrChar.IsInGroup := True;
        Player.CurrChar.GroupLeader := Player.CurrChar.objGUID;
        Sender.CurrChar.IsInGroup := True;
        Sender.CurrChar.GroupLeader := Player.CurrChar.objGUID;

        Group := TGroup.Create(Player.CurrChar.objGUID, Player.CurrChar.name);
        if Group <> nil then begin
          Group.AddMember(Sender.CurrChar.objGUID, Sender.CurrChar.name);
          GroupHT_byGUID.Add(Group.m_leaderGuid, Group);
          Group.SendUpdate;
        end;
      AddToLog('Player '+Sender.CurrChar.name+' joined to group.');
    end;
   end;
end;

procedure CMSG_GROUP_DECLINE_handler(Sender: TPlayer);
var
  Player: TPlayer;
begin
    if Sender.CurrChar.IsInvited then begin
      Sender.CurrChar.IsInvited := False;
      Player := GetOnlinePlayerByGuid(Sender.CurrChar.GroupLeader) ;
      if Player <> nil then begin
        Sender.SendBuff.Init(SMSG_GROUP_DECLINE);
        Sender.SendBuff.Add(Sender.CurrChar.name);
        Player.SendPacket;
      end;
    end;
end;

procedure CMSG_GROUP_UNINVITE_handler(Sender: TPlayer);
var
  membername: string ;
  Group: TGroup;
  Player: TPlayer;
begin
  membername := StrPas(@Sender.SendBuff.data);
  Player := LoggedPlayersHT[membername];

	if Player = nil then
  with Sender.SendBuff do
  begin
    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(membername);
    Add(Integer(1));
    Sender.SendPacket;
  end else
  if not Sender.CurrChar.IsInGroup or (Sender.CurrChar.GroupLeader <> Sender.CurrChar.objGUID) then
  with Sender.SendBuff do begin
    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(Byte(0));
    Add(Integer(6));
    Sender.SendPacket;
  end else
  if not Player.CurrChar.IsInGroup or (Player.CurrChar.GroupLeader <> Sender.CurrChar.objGUID) then
  with Sender.SendBuff do begin
    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(membername);
    Add(Integer(2));
    Sender.SendPacket;
  end else begin
    Group := GroupHT_byGUID[Sender.CurrChar.GroupLeader];
    if Group = nil then
    with Sender.SendBuff do
    begin
      Init(SMSG_PARTY_COMMAND_RESULT);
      Add(Integer(0));
      Add(Byte(0));
      Add(Integer(6));
      Sender.SendPacket;
    end else begin
      if Group.RemoveMember(Player.CurrChar.objGUID) <= 1 then begin
        Sender.CurrChar.IsInGroup := False;
        Group.Disband;
        GroupHT_byGUID.Remove(Sender.CurrChar.GroupLeader);
        Sender.SendBuff.Init(SMSG_GROUP_DESTROYED);
        Sender.SendPacket;
        Group.SendUpdate;

		    Player.CurrChar.IsInGroup := False;
        Sender.SendBuff.Init(SMSG_GROUP_UNINVITE);
	    	Player.SendPacket;
		    Group.Free ;
     	end else begin
        Group.SendUpdate;
        Player.CurrChar.IsInGroup := False;
        Sender.SendBuff.Init(SMSG_GROUP_UNINVITE);
        Player.SendPacket;
      end;
    end;
  end;
end;

procedure CMSG_GROUP_UNINVITE_GUID_handler(Sender: TPlayer);
begin
	AddToLog('Player '+Sender.CurrChar.name+' send: CMSG_GROUP_UNINVITE_GUID');
end;

procedure CMSG_GROUP_SET_LEADER_handler(Sender: TPlayer);
var
  membername: string ;
  Group: TGroup;
  Player: TPlayer;
begin
  membername := StrPas(@Sender.ReceiveBuff.data);
  Player := LoggedPlayersHT[membername];

  if Player = nil then
  with Sender.SendBuff do
  begin
    Init(SMSG_PARTY_COMMAND_RESULT);
    Add(Integer(0));
    Add(membername);
    Add(Integer(1));
    Sender.SendPacket;
  end else
  if Sender.CurrChar.IsInGroup or (Sender.CurrChar.GroupLeader = Sender.CurrChar.objGUID) then
    if Player.CurrChar.IsInGroup or (Player.CurrChar.GroupLeader = Sender.CurrChar.objGUID) then begin
      Group := GroupHT_byGUID[Sender.CurrChar.GroupLeader];
      if Group <> nil then
        Group.ChangeLeader(Player.CurrChar.objGUID);
    end;
end;

procedure CMSG_LOOT_METHOD_handler(Sender: TPlayer);
var
  lootMethod: Integer;
  lootMaster: Int64;
  Group: TGroup;
begin
  Sender.ReceiveBuff.Get(lootMethod);
  Sender.ReceiveBuff.Get(lootMaster);

  Group := GroupHT_byGUID[Sender.CurrChar.GroupLeader];
  if Group <> nil then begin
    Group.m_lootMethod := lootMethod;
    Group.m_looterGuid := lootMaster;
    Group.SendUpdate;
  end;  
end;

procedure CMSG_GROUP_DISBAND_handler(Sender: TPlayer);
var
  Group: TGroup;
begin
  AddToLog('Player '+Sender.CurrChar.name+' GROUPDISBAND');

  if Sender.CurrChar.IsInGroup then begin
    Sender.CurrChar.IsInGroup := False;

    Group := GroupHT_byGUID[Sender.CurrChar.GroupLeader];

    if Group <> nil then begin
      if Group.RemoveMember(Sender.CurrChar.objGUID) > 1 then
        Group.SendUpdate
      else begin
        Group.Disband;
        GroupHT_byGUID.Remove(Sender.CurrChar.GroupLeader);
        Sender.SendBuff.Init(SMSG_GROUP_DESTROYED);
        Sender.SendPacket;
        Group.Free ;
      end;
      Sender.SendBuff.Init(SMSG_GROUP_UNINVITE);
    	Sender.SendPacket;
    end;
  end;
end;

procedure UMSG_UPDATE_GROUP_MEMBERS_handler(Sender: TPlayer);
begin
	AddToLog('Player '+Sender.CurrChar.name+' send: UMSG_UPDATE_GROUP_MEMBERS');
end;

{ TGroup }

procedure TGroup.AddMember(guid: Int64; char_name: String);
begin
  if m_count < MAXGROUPSIZE-1 then begin
    m_members[m_count].guid := guid;
    m_members[m_count].name := char_name;
    Inc(m_count);
  end;
end;

procedure TGroup.ChangeLeader(guid: Int64);
var
  LeaderName: String;
  i: Integer;
  Player: TPlayer;
begin
  for  i := 0 to m_count-1 do
    if m_members[i].guid = guid then Break;

  m_leaderGuid := guid;
  LeaderName := m_members[i].name;

  //Оповещаем всех членов группы о смене лидера
  for i := 0 to LoggedPlayersHT.InnerCapacity - 1 do
    if LoggedPlayersHT.InnerKeyList[i] <> '' then begin
      Player := LoggedPlayersHT[LoggedPlayersHT.InnerKeyList[i]];
      Player.CurrChar.GroupLeader := guid;
      Player.SendBuff.Init(SMSG_GROUP_SET_LEADER);
      Player.SendBuff.Add(LeaderName);
      Player.SendPacket;
    end;
  SendUpdate;
end;

constructor TGroup.Create(leaderGuid: Int64; leader_name: string);
begin
  AddMember(leaderGuid, leader_name);

  m_leaderGuid := leaderGuid;
  m_leaderName := leader_name;
end;

procedure TGroup.Disband;
var
  i: Byte;
  Player: TPlayer;
begin
  for i := 0 to m_count-1 do begin
  	Player := GetOnlinePlayerByGuid(m_members[i].guid);
    if Player <> nil then begin
      Player.CurrChar.IsInGroup := False;
      Player.SendBuff.Init(SMSG_GROUP_DESTROYED);
      Player.SendPacket;
    end;
  end;
end;

function TGroup.RemoveMember(guid: Int64): Byte;
var
  i, j: Byte;
  leaderFlag: Boolean ;
begin
  leaderFlag := False;
  for i := 0 to m_count-1 do begin
    if m_members[i].guid = guid then begin
      leaderFlag := (m_members[i].guid = m_leaderGuid);

      for j := i + 1 to m_count-1 do  begin
        m_members[j-1].guid := m_members[j].guid;
        m_members[j-1].name := m_members[j].name;
      end;
      break;
    end;
  end;

  Dec(m_count);

  if (m_count > 1) and leaderFlag then
    ChangeLeader(m_members[0].guid);

  Result := m_count;
end;

procedure TGroup.SendUpdate;
var
  i ,j: Integer;
  Player: TPlayer;
begin
  for i := 0 to m_count-1 do begin
    Player := GetOnlinePlayerByGuid(m_members[i].guid);
    if Player <> nil then
    with Player.SendBuff do
    begin
      Init(SMSG_GROUP_LIST);
      Add(Word(m_grouptype));
      Add(Integer(m_count - 1));

      for j := 0 to m_count-1 do
        if m_members[j].guid <> m_members[i].guid then begin
          Add(m_members[j].name);
          Add(m_members[j].guid);
          Add(Integer(0));
          Add(Word(1));
        end;

      Add(Int64(m_leaderGuid));
      Add(Byte(m_lootMethod));
      Add(Integer(m_looterGuid));
      Add(Integer(0));
      Add(Byte(2));

      Player.SendPacket;

      if Player.CurrChar.objGUID = m_leaderGuid then begin
//        Player.CurrChar.Flags := PLAYER_FLAGS_GROUPLEADER;
        if (Player.CurrChar.Flags and PLAYER_FLAGS_GROUPLEADER) <> PLAYER_FLAGS_GROUPLEADER then
          Player.CurrChar.Flags := Player.CurrChar.Flags or PLAYER_FLAGS_GROUPLEADER;
      end else begin
//        Player.CurrChar.Flags := 0;
        if (Player.CurrChar.Flags and PLAYER_FLAGS_GROUPLEADER) = PLAYER_FLAGS_GROUPLEADER then
          Player.CurrChar.Flags := Player.CurrChar.Flags or not PLAYER_FLAGS_GROUPLEADER;
      end;

      Player.CurrChar.InitUpdateArray;
      Player.CurrChar.BuildSendCharUpdateBlock;
    end;
  end;
end;

end.
