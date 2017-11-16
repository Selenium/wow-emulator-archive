unit MailHandler; //changed by Aven 5.05.06

interface

uses
  Windows, SysUtils, ByteArrayHandler, UnitMain, OpcodeHandler, OpConst,
  DbcFieldsConst, UpdateConst, ItemHandler;

procedure CMSG_ITEM_TEXT_QUERY_handler(Sender: TPlayer);
procedure CMSG_SEND_MAIL_handler(Sender: TPlayer);
procedure CMSG_GET_MAIL_LIST_handler(Sender: TPlayer);
procedure CMSG_MAIL_TAKE_MONEY_handler(Sender: TPlayer);
procedure CMSG_MAIL_TAKE_ITEM_handler(Sender: TPlayer);
procedure CMSG_MAIL_MARK_AS_READ_handler(Sender: TPlayer);
procedure CMSG_MAIL_RETURN_TO_SENDER_handler(Sender: TPlayer);
procedure CMSG_MAIL_DELETE_handler(Sender: TPlayer);
procedure CMSG_MAIL_CREATE_TEXT_ITEM_handler(Sender: TPlayer);
procedure MSG_QUERY_NEXT_MAIL_TIME_handler(Sender: TPlayer);

implementation

uses WorldObject;

procedure AddMail(Sender: TPlayer; item_id, item_count, reciever_guid, money, COD: Integer; subject, body: String);
var
  PackedMail: TPackedMail;
begin
  PackedMail.item := item_id;
  PackedMail.item_count := item_count ;
  PackedMail.mail_id := MailDbcHandler.MaxID ;
  PackedMail.sender := Sender.CurrChar.objGUID ;
  PackedMail.reciever :=  reciever_guid;
  PackedMail.subject := MailDbcHandler.AddString(subject);
  PackedMail.body := MailDbcHandler.AddString(body);
  PackedMail.money := money;
  PackedMail.time := Now + (30 * 3600);
  PackedMail.COD := COD;
  PackedMail.checked := 0;
  MailDbcHandler.AddRecord(@PackedMail);
end;

procedure CMSG_SEND_MAIL_handler(Sender: TPlayer);
var
  sndr,item_guid: Int64;
  reciever,subject,body: String;
  unk1,unk2,money,COD,reciever_guid, i: Integer;
  bag,slot: Byte; 
  player_chars: PPackedPlayerCharsRecord;
  Item: TItem;
  item_id, item_count: Integer;
begin
  if not SystemMail then Exit ;
  with Sender.ReceiveBuff do
  begin
       Get(sndr);
       Get(reciever);
       Get(subject);
       Get(body);
       Get(unk1);
       Get(unk2);
       Get(item_guid);
       Get(money);
       Get(COD);
  end;

  AddToLog('CMSG_SEND_MAIL ['+Sender.CurrChar.name+'] is sending mail to ['+reciever+'] with subject ['+subject+'] and body ['+body+'] includes item ['+IntToStr(item_guid)+'] and ['+IntToStr(money)+'] copper and ['+IntToStr(cod)+'] COD copper');

  if Sender.CurrChar.copper - money < 30 then
  with Sender.SendBuff do begin //Хватает ли у нас денег?
    Init(SMSG_SEND_MAIL_RESULT);
    Add(Integer(0));
    Add(Integer(0));
    Add(Integer(3));
    Sender.SendPacket;
    Exit;
  end;

  reciever_guid := 0 ;
  //Ищем в базе GUID получателя
  for i:=1 to PlayerCharDbcHandler.MaxID do begin
    player_chars := PlayerCharDbcHandler.GetPointerPRValueByIntKey(i);
    if player_chars <> nil then
      if PlayerCharDbcHandler.GetStringByOffset(player_chars^.Name) = reciever then begin
        reciever_guid := player_chars^.Guid;
        Break;
      end;
  end;

  if reciever_guid <> 0 then
  with Sender.SendBuff do begin
    Init(SMSG_SEND_MAIL_RESULT);
    Add(Integer(0));
    Add(Integer(0));
    Add(Integer(0));
    Sender.SendPacket;

    Item := nil;
    item_id := 0;
    item_count := 0;
    if item_guid <> 0 then begin
      if Sender.CurrChar.GetSlotByItemGUID(item_guid, bag, slot) then
        Item := Sender.CurrChar.GetBagItem(bag, slot) ;
        if Item <> nil then begin
          AddToLog('Sent Item: ' + IntToStr(Item.ID) + 'x' + IntToStr(Item.item_count));

          item_id := Item.ID;
          item_count := Item.item_count;

          Sender.CurrChar.RemoveItemCountFromBag(bag, slot, Item.item_count);
        end;
    end;
    Sender.CurrChar.copper := Sender.CurrChar.copper - 30 - money;
    SetUpdateBits(Sender.CurrChar, Sender.CurrChar.copper, PLAYER_FIELD_COINAGE);
    Sender.CurrChar.BuildSendCharUpdateBlock ;

    AddMail(Sender, item_id, item_count, reciever_guid, money, COD, subject, body);

    Init(SMSG_RECEIVED_MAIL);
    Add(Integer(0));
    Sender.SendPacket();
  end else
  with Sender.SendBuff do begin  //Получателя не существует
    Init(SMSG_SEND_MAIL_RESULT);
    Add(Integer(0));
    Add(Integer(0));
    Add(Integer(4));
    Sender.SendPacket;
  end;
end;

procedure CMSG_GET_MAIL_LIST_handler(Sender: TPlayer);
var
  info, i: Integer;
  mail_count: Byte;
  pMail: PPackedMail;
  mail_time: Single;
begin
  if not SystemMail then Exit ;
  Sender.ReceiveBuff.Get(info);

  //AddToLog('CMSG_GET_MAIL_LIST [' + IntToStr(info) + ']');

  mail_count := 0;
  Sender.SendBuff.Init(SMSG_MAIL_LIST_RESULT);
  Sender.SendBuff.offs := 5;
  for i := 0 to MailDbcHandler.MaxID do begin
    pMail := MailDbcHandler.GetPointerPRValueByIntKey(i);
    if pMail <> nil then
      if pMail^.reciever = Sender.CurrChar.objGUID then
      with Sender.SendBuff do
      begin
        Add(Integer(pMail^.mail_id));
        Add(Byte(0));
        Add(Integer(pMail^.sender));
        Add(Integer(0));
        Add(MailDbcHandler.GetStringByOffset(pMail^.subject));

        if MailDbcHandler.GetStringByOffset(pMail^.body) <> '' then
          Add(Integer(pMail^.mail_id))
        else
          Add(Integer(0));

        Add(Integer(0));
        Add(Integer(41));

        if pMail^.item <> 0 then begin
          Add(Integer(pMail^.item));
        end else
          Add(Integer(0));

        Add(Integer(0));
        Add(Integer(0));
        Add(Integer(0));
        Add(Byte(pMail^.item_count));
        Add(Integer(-1));
        Add(Integer(0));
        Add(Integer(0));
        Add(Integer(pMail^.money));
        Add(Integer(pMail^.COD));
        Add(Integer(pMail^.checked));
        mail_time := (pMail^.time - Now) / 3600;
        Add(Single(mail_time));
        Inc(mail_count)
      end;
  end;
  Sender.SendBuff.data[4] := mail_count;
  Sender.SendPacket;
end;

procedure CMSG_MAIL_TAKE_MONEY_handler(Sender: TPlayer);
var
  mailbox: Int64;
  id: Integer;
  pMail: PPackedMail;
begin
  if not SystemMail then Exit ;
  Sender.ReceiveBuff.Get(mailbox);
  Sender.ReceiveBuff.Get(id);

  //AddToLog('CMSG_MAIL_TAKE_MONEY [' + IntToStr(id)+']');

  pMail := MailDbcHandler.GetPointerPRValueByIntKey(id);
  if pMail <> nil then begin
    Sender.CurrChar.copper := Sender.CurrChar.copper + pMail^.money;
    SetUpdateBits(Sender.CurrChar, Sender.CurrChar.copper, PLAYER_FIELD_COINAGE);
    Sender.CurrChar.BuildSendCharUpdateBlock ;
    pMail^.money := 0;
  end;

  with Sender.SendBuff do
  begin
       Init(SMSG_SEND_MAIL_RESULT);
       Add(Integer(id));
       Add(Integer(1));
       Add(Integer(0));
       Sender.SendPacket;
  end;
end;

procedure CMSG_MAIL_TAKE_ITEM_handler(Sender: TPlayer);
var
  mailbox: Int64;
  id, NewMoney: Integer;
  pMail: PPackedMail;
  slot: Byte;
  Item: TItem;
begin
  if not SystemMail then Exit ;
  Sender.ReceiveBuff.Get(mailbox);
  Sender.ReceiveBuff.Get(id);

	AddToLog('CMSG_MAIL_TAKE_ITEM ' + IntToStr(id));

  pMail := MailDbcHandler.GetPointerPRValueByIntKey(id);
  if pMail <> nil then
  begin
    slot := Sender.CurrChar.GetInvFreeSlot ;
    if slot = 255 then Exit;

    Item := TItem.Create(Sender.CurrChar.objGUID, pMail^.item);
    if Item <> nil then
    with Sender.SendBuff do
    begin
      //Проверяем есть ли деньги если это COD
      if pMail^.COD <> 0 then begin
        NewMoney := Sender.CurrChar.copper - pMail^.COD ;
        if NewMoney < 0 then begin //Хватает ли у нас денег?
          Init(SMSG_SEND_MAIL_RESULT);
          Add(Integer(0));
          Add(Integer(0));
          Add(Integer(3));
          Sender.SendPacket;
          Exit;
        end;
        Sender.CurrChar.SetCopper(NewMoney);
        //Отправляем деньги за посылку отправителю
        AddMail(Sender, 0, 0, pMail^.sender, pMail^.COD, 0, 'COD: ' + MailDbcHandler.GetStringByOffset(pMail^.subject), '');
        pMail^.COD := 0;
      end;

      Item.item_count := pMail^.item_count ;
      Sender.CurrChar.AddItemCount2Bag(Item, SLOT_CHARACTER, slot, Item.item_count) ;
      Sender.CurrChar.SendPartialCreateItemUpdateBlockForPlayer(Item);
      Sender.CurrChar.BuildSendCharUpdateBlock ;

      pMail^.item := 0;
      pMail^.item_count := 0;

      Init(SMSG_SEND_MAIL_RESULT);
      Add(Integer(id));
      Add(Integer(2));
      Add(Integer(0));
      Sender.SendPacket;
    end;
  end;
end;

procedure CMSG_MAIL_MARK_AS_READ_handler(Sender: TPlayer);
var
  mailbox: Int64;
  id: Integer;
  pMail: PPackedMail;
begin
  if not SystemMail then Exit ;
  Sender.ReceiveBuff.Get(mailbox);
  Sender.ReceiveBuff.Get(id);

  //AddToLog('CMSG_MAIL_MARK_AS_READ ' + IntToStr(id));

  pMail := MailDbcHandler.GetPointerPRValueByIntKey(id);
  if pMail <> nil then begin
    pMail^.checked := 1;
    pMail^.time := Now + (3*3600);
  end;
end;

procedure CMSG_MAIL_RETURN_TO_SENDER_handler(Sender: TPlayer);
begin
  if not SystemMail then Exit ;
	AddToLog('CMSG_MAIL_RETURN_TO_SENDER');
end;

procedure CMSG_MAIL_DELETE_handler(Sender: TPlayer);
var
  mailbox: Int64;
  id: Integer;
  pMail: PPackedMail;
begin
  if not SystemMail then Exit ;
  Sender.ReceiveBuff.Get(mailbox);
  Sender.ReceiveBuff.Get(id);

  AddToLog('CMSG_MAIL_DELETE ' + IntToStr(id));

  pMail := MailDbcHandler.GetPointerPRValueByIntKey(id);
  if pMail <> nil then
    MailDbcHandler.RemoveRecordIntKey(id);

  with Sender.SendBuff do
  begin
       Init(SMSG_SEND_MAIL_RESULT);
       Add(Integer(id));
       Add(Integer(4));
       Add(Integer(0));
       Sender.SendPacket;
  end;
end;

procedure CMSG_MAIL_CREATE_TEXT_ITEM_handler(Sender: TPlayer);
var
  unk1,unk2,mailid: Integer;
  Item: TItem;
begin
  if not SystemMail then Exit ;
  Sender.ReceiveBuff.Get(unk1);
  Sender.ReceiveBuff.Get(unk2);
  Sender.ReceiveBuff.Get(mailid);

	//AddToLog('CMSG_MAIL_CREATE_TEXT_ITEM ' + IntToStr(mailid));

//    uint32 sbit2=5;
//    bool   slotfree=false;

  Item := TItem.Create(Sender.CurrChar.objGUID, 889);

//    item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), 889, GetPlayer());
//    item->SetUInt32Value( ITEM_FIELD_ITEM_TEXT_ID , mailid );
  Sender.CurrChar.AddItem(Item, Sender.CurrChar.GetInvFreeSlot); 
  Sender.CurrChar.SendPartialCreateItemUpdateBlockForPlayer(Item);
  Sender.CurrChar.BuildSendCharUpdateBlock ;
end;

procedure MSG_QUERY_NEXT_MAIL_TIME_handler(Sender: TPlayer);
var
  i: Integer;
  checkmail: Boolean;
  pMail: PPackedMail ;
begin
  if not SystemMail then Exit ;
	//AddToLog('MSG_QUERY_NEXT_MAIL_TIME');

	checkmail := False;

  for i := 0 to MailDbcHandler.MaxID do begin
    pMail := MailDbcHandler.GetPointerPRValueByIntKey(i);
    if pMail <> nil then
      if pMail^.reciever = Sender.CurrChar.ID then
        if pMail^.checked = 0 then begin
          checkmail := True;
          Break;
        end;
  end;
	
  if checkmail then
  with Sender.SendBuff do begin
    Init(MSG_QUERY_NEXT_MAIL_TIME);
    Add(Integer(0));
    Sender.SendPacket;
	end else
  with Sender.SendBuff do begin
    Init(MSG_QUERY_NEXT_MAIL_TIME);
    Add(Byte(0));
    Add(Byte($C0));
    Add(Byte($A8));
    Add(Byte($C7));
    Sender.SendPacket;
  end;
end;

procedure CMSG_ITEM_TEXT_QUERY_handler(Sender: TPlayer);
var
  mailguid: Integer;
  unk1: Int64;
  pMail: PPackedMail ;
begin
  if not SystemMail then Exit ;
  Sender.ReceiveBuff.Get(mailguid);
  Sender.ReceiveBuff.Get(unk1);

  //AddToLog('CMSG_ITEM_TEXT_QUERY ' + IntToStr(mailguid));

  pMail := MailDbcHandler.GetPointerPRValueByIntKey(mailguid);
  if pMail <> nil then
  with Sender.SendBuff do begin
    Init(SMSG_ITEM_TEXT_QUERY_RESPONSE);
    Add(Integer(mailguid));
    Add(MailDbcHandler.GetStringByOffset(pMail^.body));
    Add(Integer(0));
    Sender.SendPacket;
  end;
end;

// ------------------------------------------------------------------------- //

end.
