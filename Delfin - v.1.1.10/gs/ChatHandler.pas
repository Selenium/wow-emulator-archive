unit ChatHandler;
//changed by Aven 05.05.06 

interface

uses Windows, SysUtils, CharHandler, OpcodeHandler;

const
    CHAT_MSG_SAY                                  = $00;
    CHAT_MSG_PARTY                                = $01;
    CHAT_MSG_RAID                                 = $02;
    CHAT_MSG_GUILD                                = $03;
    CHAT_MSG_OFFICER                              = $04;
    CHAT_MSG_YELL                                 = $05;
    CHAT_MSG_WHISPER                              = $06;
    CHAT_MSG_WHISPER_INFORM                       = $07;
    CHAT_MSG_EMOTE                                = $08;
    CHAT_MSG_TEXT_EMOTE                           = $09;
    CHAT_MSG_SYSTEM                               = $0A;
    CHAT_MSG_MONSTER_SAY                          = $0B;
    CHAT_MSG_MONSTER_YELL                         = $0C;
    CHAT_MSG_MONSTER_EMOTE                        = $0D;
    CHAT_MSG_CHANNEL                              = $0E;
    CHAT_MSG_CHANNEL_JOIN                         = $0F;
    CHAT_MSG_CHANNEL_LEAVE                        = $10;
    CHAT_MSG_CHANNEL_LIST                         = $11;
    CHAT_MSG_CHANNEL_NOTICE                       = $12;
    CHAT_MSG_CHANNEL_NOTICE_USER                  = $13;
    CHAT_MSG_AFK                                  = $14;
    CHAT_MSG_DND                                  = $15;
    CHAT_MSG_COMBAT_LOG                           = $16;
    CHAT_MSG_IGNORED                              = $17;
    CHAT_MSG_SKILL                                = $18;
    CHAT_MSG_LOOT                                 = $19;

	  CHAT_NOTIFY_JOINED                            = $00;
	  CHAT_NOTIFY_LEAVE                             = $01;
    CHAT_NOTIFY_YOU_JOINED                        = $02;
	  CHAT_NOTIFY_YOU_LEFT                          = $03;
	  CHAT_NOTIFY_WRONG_PASS                        = $04;
	  CHAT_NOTIFY_NOT_ON                            = $05;
	  CHAT_NOTIFY_NOT_MODERATOR                     = $06;
	  CHAT_NOTIFY_SET_PASS                          = $07;
	  CHAT_NOTIFY_CHANGE_OWNER                      = $08;
	  CHAT_NOTIFY_NOT_ON2                           = $09;
	  CHAT_NOTIFY_NOT_OWNER                         = $0A;
	  CHAT_NOTIFY_WHO_OWNER                         = $0B;
	  CHAT_NOTIFY_MODE_CHANGE                       = $0C;
	  CHAT_NOTIFY_ENABLE_ANNOUNCE                   = $0D;
	  CHAT_NOTIFY_DISABLE_ANNOUNCE                  = $0E;
	  CHAT_NOTIFY_MODERATED                         = $0F;
	  CHAT_NOTIFY_UNMODERATED                       = $10;
	  CHAT_NOTIFY_MUTED                             = $11;
	  CHAT_NOTIFY_KICKED                            = $12;
	  CHAT_NOTIFY_YOU_ARE_BANNED                    = $13;
	  CHAT_NOTIFY_BANNED                            = $14;
	  CHAT_NOTIFY_UNBANNED                          = $15;
	  // 16 unk
	  CHAT_NOTIFY_ALREADY_ON                        = $17;
	  CHAT_NOTIFY_INVITED                           = $18;
	  CHAT_NOTIFY_WRONG_ALLIANCE                    = $19;
	  //....
	  CHAT_NOTIFY_YOU_INVITED                       = $1D;

    LANG_ORCISH                                   = 1;
    LANG_DARNASSIAN                               = 2;
    LANG_TAURAHE                                  = 3;
    LANG_DWARVISH                                 = 6;
    LANG_COMMON                                   = 7;
    LANG_DEMONIC                                  = 8;
    LANG_TITAN                                    = 9;
    LANG_THELASSIAN                               = 10;
    LANG_DRACONIC                                 = 11;
    LANG_KALIMAG                                  = 12;
    LANG_GNOMISH                                  = 13;
    LANG_TROLL                                    = 14;
    LANG_GUTTERSPEAK                              = 33;
    LANG_UNIVERSAL                                =0;

procedure BroadcastSystemMessage(msg: String);
procedure SendSpecialMessage(Sender: TPlayer; ChatMsgType : byte; LngType : integer=0; guid : Int64=0; msg: string='recievedmsg';msg_afk: Byte = 0);
procedure SendChatMessage(Sender: TPlayer; ChatMsgType : byte; LngType : integer; guid : Int64; msg: string; ChannelName: String = ''; msg_afk: Byte = 0);

//type
procedure CheckAddPlayer2Channel(ch_name: string; Sender: TCharacter);
procedure RemovePlayerFromChannel(ch_name: string; Sender: TCharacter);
procedure MakeSendNotifyPacket(Sender: TPlayer; channel: string; code: byte);
procedure SendSystemChatMessage(Sender: TPlayer; msg: string);

//opcodes
	procedure CMSG_MESSAGECHAT_handler(Sender: TPlayer);
	procedure CMSG_JOIN_CHANNEL_handler(Sender: TPlayer);
	procedure CMSG_LEAVE_CHANNEL_handler(Sender: TPlayer);             
	procedure CMSG_CHANNEL_LIST_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_PASSWORD_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_SET_OWNER_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_OWNER_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_MODERATOR_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_UNMODERATOR_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_MUTE_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_UNMUTE_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_INVITE_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_KICK_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_BAN_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_UNBAN_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_ANNOUNCEMENTS_handler(Sender: TPlayer);
	procedure CMSG_CHANNEL_MODERATE_handler(Sender: TPlayer);
	procedure CMSG_EMOTE_handler(Sender: TPlayer);
	procedure CMSG_TEXT_EMOTE_handler(Sender: TPlayer);  

implementation

uses UnitMain, AcedContainers, CellManager, ByteArrayHandler, OpConst,
     CommandHandler, DbcFieldsConst;

procedure AddToChatLog(LogString: string); //created by Aven 20.03.2006
var
  FormatLogString: String;
  LogFile: Textfile;
begin
  FormatLogString := '['+TimeToStr(Now)+'] ' + LogString;
  try
     AssignFile(LogFile, LogsPath + 'chat.log');
     {$I-}
     Append(LogFile);
     {$I+}
     if IOResult<>0 then Rewrite(LogFile);
     {$I-}
     writeln(LogFile, FormatLogString);
     {$I+}
     if IOResult<>0 then;
     Flush(LogFile);
     CloseFile(LogFile);
  except;
  end;
end;

procedure BroadcastSystemMessage(msg: String);
var
  i: Integer;
  Player: TPlayer;
begin
  for i := 0 to LoggedPlayersHT.InnerCapacity - 1 do
    if LoggedPlayersHT.InnerKeyList[i] <> '' then begin
      Player := LoggedPlayersHT[LoggedPlayersHT.InnerKeyList[i]];
      if (Player <> nil) and (Player.CurrChar <> nil) and (Player.CurrChar.UpdateArray <> nil) then
        SendSystemChatMessage(Player, msg);
    end;
end;

procedure MakeSendNotifyPacket(Sender: TPlayer; channel: string; code: byte);
begin
     with Sender.SendBuff do
     begin
          Init(SMSG_CHANNEL_NOTIFY);
          Add(code);
          Add(channel);
          Add(Sender.CurrChar.objGUID);
     end;
     Sender.SendPacket;
end;

procedure CheckAddPlayer2Channel(ch_name: string; Sender: TCharacter);
var
   ChatChannel: TArrayList;
   index: integer;
begin
     ChatChannel:=TArrayList(ChatChannelsHT.Items[ch_name]);
     if ChatChannel=nil then
     begin
          ChatChannel:=TArrayList.Create(0);
          ChatChannelsHT.Add(ch_name,ChatChannel);
     end;
     index:=ChatChannel.IndexOf(Sender as TActiveWorldObject,MatchObjectGUID,false);
     if index<0 then ChatChannel.Add(@Sender);
end;

procedure RemovePlayerFromChannel(ch_name: string; Sender: TCharacter);
var
   ChatChannel: TArrayList;
   index: integer;
begin
     ChatChannel:=TArrayList(ChatChannelsHT.Items[ch_name]);
     if ChatChannel<>nil then
     begin
          index:=ChatChannel.IndexOf(Sender as TActiveWorldObject,MatchObjectGUID,false);
          if index>=0 then ChatChannel.RemoveAt(index);
     end;
end;

procedure SendChatMessage(Sender: TPlayer; ChatMsgType : byte; LngType : integer; guid : Int64; msg: string; ChannelName: String = ''; msg_afk: Byte = 0);
begin
  with Sender.SendBuff do begin
          Init(SMSG_MESSAGECHAT);
          Add(ChatMsgType);
          Add(LngType);
          Add(guid);
          if channelName <> '' then
             Add(channelName);
          Add(guid);
          Add(Length(msg)+1);
          Add(msg);
          Add(0);
     end;
     Sender.SendPacket;
end;

procedure SendSpecialMessage(Sender: TPlayer; ChatMsgType : byte; LngType : integer=0; guid : Int64=0; msg: string='recievedmsg';msg_afk: Byte = 0);
begin
     with Sender.SendBuff do
     begin
          Init(SMSG_MESSAGECHAT);
          Add(ChatMsgType);
          Add(LngType);
          //Add2ByteArr(Sender.CurrChar.objGUID,Sender.OutBuff,offs);
          Add(guid);
          Add(Length(msg)+1);
          Add(msg);
          Add(0);
     end;
     Sender.SendPacket;
end;

procedure SendSystemChatMessage(Sender: TPlayer; msg: string);
begin
  SendSpecialMessage(Sender, CHAT_MSG_SYSTEM, 0, 0, msg);
end;

//opcodes

procedure CMSG_MESSAGECHAT_handler(Sender: TPlayer);
var
  mtype,ltype:integer;
  i: integer;
  msg,name: String;
  Player: TPlayer;
begin
  try
    Sender.ReceiveBuff.Get(mtype);
    Sender.ReceiveBuff.Get(ltype);
    Sender.ReceiveBuff.Get(msg);
    if (Length(msg) > 1) and (msg[1]='.') then begin
      OnCommand(Sender, msg); //Команда
      Exit;
    end;
    //что-то криво как-то!!!
    for i := 0 to LoggedPlayersHT.InnerCapacity - 1 do
      if LoggedPlayersHT.InnerKeyList[i] <> '' then  begin
        Player := LoggedPlayersHT[LoggedPlayersHT.InnerKeyList[i]];
        SendChatMessage(Player,mtype ,ltype , Sender.CurrChar.objGUID, msg);
        AddToChatLog(Sender.CurrChar.name+'  >>  '+msg);
      end else
      if mtype = CHAT_MSG_WHISPER then begin
        Sender.ReceiveBuff.offs:=8;
        Sender.ReceiveBuff.Get(name);
        Sender.ReceiveBuff.Get(msg);
        if GetPlayerByName(name)=nil then  begin
          SendSpecialMessage(Sender, CHAT_MSG_SYSTEM, 0, 0, 'Player |c8fff2020'+name+'|r is not online.');
          exit;
        end
      else begin
        //Получателю
        SendSpecialMessage(Sender,CHAT_MSG_WHISPER_INFORM,LANG_UNIVERSAL,GetPlayerByName(name).CurrChar.objGUID,msg);
        //Эхо отправителю
        SendSpecialMessage(GetPlayerByName(name),CHAT_MSG_WHISPER,LANG_UNIVERSAL,sender.CurrChar.objGUID,msg);
        AddToChatLog(Sender.CurrChar.name+'  send_to  '+name+'  >>  '+msg);
        exit;
      end
    end
  except;
  end
end;

procedure CMSG_JOIN_CHANNEL_handler(Sender: TPlayer);
var
   ChannelName, pass: string;
begin
     //todo add player to channel array
     with Sender.ReceiveBuff do
     begin
          Get(ChannelName);
          Get(pass);
     end;
     CheckAddPlayer2Channel(ChannelName,Sender.CurrChar);
     MakeSendNotifyPacket(Sender,ChannelName,CHAT_NOTIFY_YOU_JOINED);
end;

procedure CMSG_LEAVE_CHANNEL_handler(Sender: TPlayer);
var
   ChannelName: string;
begin
     //todo remove player from channel array
     Sender.ReceiveBuff.Get(ChannelName);
	   RemovePlayerFromChannel(ChannelName,Sender.CurrChar);
     MakeSendNotifyPacket(Sender,ChannelName,CHAT_NOTIFY_YOU_LEFT);
end;

procedure CMSG_CHANNEL_LIST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_PASSWORD_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_SET_OWNER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_OWNER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_MODERATOR_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_UNMODERATOR_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_MUTE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_UNMUTE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_INVITE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_KICK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_BAN_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_UNBAN_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_ANNOUNCEMENTS_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHANNEL_MODERATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_EMOTE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TEXT_EMOTE_handler(Sender: TPlayer);
var
  text_emote, unk, i: Integer;
  guid: Int64;
  mobname: String;
  mob: TCharacter;
  Player: TPlayer;
  pEmotes: PPackedEmotesText;
begin
  with Sender.ReceiveBuff do
  begin
       Get(text_emote);
       Get(unk);
       Get(guid);
  end;

  AddToLog('CMSG_TEXT_EMOTE ['+IntToStr(text_emote)+']['+IntToStr(unk)+']['+IntToStr(guid)+']');

  mobname := '';
  
  mob := PlayerCharsHT_byGUID[guid];
  if mob <> nil then begin
    mobname := mob.name ;
  end;

{    emoteentry *em = sEmoteStore.LookupEntry(text_emote);
    if (em)  }
  pEmotes := EmotesTextDbcHandler.GetPointerPRValueByIntKey(text_emote);
  if pEmotes <> nil then begin
    for i := LoggedPlayersHT.InnerCapacity - 1 downto 0 do
      if LoggedPlayersHT.InnerKeyList[i] <> '' then begin
        Player := LoggedPlayersHT[LoggedPlayersHT.InnerKeyList[i]];
        if Player <> nil then
        with Sender.SendBuff do begin
          Init(SMSG_EMOTE);
          Add(pEmotes^.textid);
          Add(Sender.CurrChar.objGUID);
          Player.SendPacket;

          Init(SMSG_TEXT_EMOTE);
          Add(Sender.CurrChar.objGUID);
          Add(text_emote);
          Add(Integer($FF));
          Add(length(mobname)+1);
          Add(mobname);
          Player.SendPacket;
        end; 
      end;
  end;
end;

end.
