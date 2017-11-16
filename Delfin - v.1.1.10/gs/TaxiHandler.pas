unit TaxiHandler;

interface

uses
  Windows, UnitMain, OpcodeHandler, OpConst, DbcFieldsConst, ByteArrayHandler,
  ChatHandler, WorldObject, UpdateConst, SysUtils, Formulas;

const
  sz_new_taxinode_found = 'You have discovered new flight path.';

procedure CMSG_TAXICLEARALLNODES_handler(Sender: TPlayer);
procedure CMSG_TAXIENABLEALLNODES_handler(Sender: TPlayer);
procedure CMSG_TAXISHOWNODES_handler(Sender: TPlayer);
procedure CMSG_TAXINODE_STATUS_QUERY_handler(Sender: TPlayer);
procedure CMSG_TAXIQUERYAVAILABLENODES_handler(Sender: TPlayer);
procedure CMSG_ACTIVATETAXI_handler(Sender: TPlayer);

implementation

procedure CMSG_TAXICLEARALLNODES_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TAXIENABLEALLNODES_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TAXISHOWNODES_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TAXINODE_STATUS_QUERY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TAXIQUERYAVAILABLENODES_handler(Sender: TPlayer);
var
  guid: Int64;
  submask, i, Node_ID: Integer;
  field: Byte;
  TaxiNodes: PPackedTaxiNodes ;
  Distance, Distance_min: Single;
begin
  Sender.ReceiveBuff.Get(guid);

  AddToLog('CMSG_TAXIQUERYAVAILABLENODES');

  Distance_min := -1;
  Node_ID := 0;
  for i := 1 to TaxiNodesHandler.MaxID do begin
    TaxiNodes := TaxiNodesHandler.GetPointerPRValueByIntKey(i) ;
    if TaxiNodes <> nil then
      if TaxiNodes^.MapID = Sender.CurrChar.mapid then begin
        Distance := GetQDistance(TaxiNodes^.PositionX,Sender.CurrChar.PositionX,
                                 TaxiNodes^.PositionY,Sender.CurrChar.PositionY,
                                 TaxiNodes^.PositionZ,Sender.CurrChar.PositionZ);
        if (Distance_min = -1) or (Distance < Distance_min) then begin
          Distance_min := Distance;
          Node_ID := TaxiNodes^.ID ;
        end;
      end;
  end;

  AddToLog('NODE ID: ' + IntToStr(Node_ID));

  if Node_ID = 0 then Exit;

  field := (Node_ID - 1) div 32;
  submask := 1 shl ((Node_ID - 1) mod 32);

  if (Sender.CurrChar.TaxiMask[field] and submask) <> submask then
    with Sender.SendBuff do begin
      Init(SMSG_TAXINODE_STATUS);
      Sender.CurrChar.TaxiMask[field] := Sender.CurrChar.TaxiMask[field] or submask;
      SendSystemChatMessage(Sender, sz_new_taxinode_found);
      Add(guid);
      Add(Byte(1));
      Sender.SendPacket;
    end;

  with Sender.SendBuff do
  begin
    Init(SMSG_SHOWTAXINODES);
    Add(Integer(1));
    Add(guid);
    Add(Node_ID);
    for i := 0 to 7 do
        Add(Sender.CurrChar.TaxiMask[i]);
    Sender.SendPacket;
  end;
end;

procedure GetTaxiPath(source, destination: Integer; var path, cost: Integer);
var
  TaxiPath: PPackedTaxiPath ;
  i: Integer;
begin
  path := 0;
  cost := 0;

  for i := 1 to TaxiPathHandler.MaxID do begin
    TaxiPath := TaxiPathHandler.GetPointerPRValueByIntKey(i) ;
    if TaxiPath <> nil then
      if (TaxiPath^.Node_src = source) and (TaxiPath^.Node_dst = destination) then begin
        path := TaxiPath^.ID ;
        cost := TaxiPath^.Price ;
      end;
  end;
end;

procedure CMSG_ACTIVATETAXI_handler(Sender: TPlayer);
var
  guid: Int64;
  sourcenode, destinationnode, path, cost, newmoney{, traveltime}: Integer;
  MountId: word;
  TaxiNodes: PPackedTaxiNodes ;
begin
  Sender.ReceiveBuff.Get(guid);
  Sender.ReceiveBuff.Get(sourcenode);
  Sender.ReceiveBuff.Get(destinationnode);

  AddToLog('CMSG_ACTIVATETAXI ' + IntToStr(sourcenode) + IntToStr(destinationnode));

  GetTaxiPath(sourcenode, destinationnode, path, cost);
{    FlightPathMovementGenerator *flight(new FlightPathMovementGenerator(_player, path));
    Path &pathnodes(flight->GetPath());
    assert( pathnodes.Size() > 0 );   }

  MountId := 0;
  TaxiNodes := TaxiNodesHandler.GetPointerPRValueByIntKey(sourcenode) ;
  if TaxiNodes <> nil then
    MountId := TaxiNodes^.Mount;

  AddToLog('MountId: ' + IntToStr(MountId));

  if (MountId = 0) or ((path = 0) and (cost = 0)) then
  with Sender.SendBuff do begin
    Init(SMSG_ACTIVATETAXIREPLY);
    Add(Integer(1));
    Sender.SendPacket;
    Exit;
  end;

  newmoney := Sender.CurrChar.copper - cost;
  if newmoney < 0 then
  with Sender.SendBuff do begin
    Init(SMSG_ACTIVATETAXIREPLY);
    Add(Integer(3));
    Sender.SendPacket;
    Exit;
  end;
//  GetPlayer( )->setDismountCost( newmoney );
  Sender.CurrChar.SetCopper(NewMoney);

  with Sender.SendBuff do begin
    Init(SMSG_ACTIVATETAXIREPLY);
    Add(Integer(0));
    Sender.SendPacket;
  end;

{  SetUpdateBits(Sender.CurrChar, MountId, UNIT_FIELD_MOUNTDISPLAYID);
  SetUpdateBits(Sender.CurrChar, $2004, UNIT_FIELD_FLAGS);
  Sender.CurrChar.BuildSendCharUpdateBlock ; }

{  traveltime := 4 * 32; // GetTotalLength * 32;

  offs := 0;
  Add2byteArr(Byte($FF), Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.objGUID, Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.positionX, Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.positionY, Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.positionZ, Sender.OutBuff, offs);
  Add2byteArr(Sender.CurrChar.positionR, Sender.OutBuff, offs);
  Add2byteArr(Byte(0), Sender.OutBuff, offs);
  Add2byteArr(Integer($300), Sender.OutBuff, offs);
  Add2byteArr(traveltime, Sender.OutBuff, offs);
  Add2byteArr(Integer(0), Sender.OutBuff, offs); //  Add2byteArr(pathnodes.Size, Sender.OutBuff, offs);
  Add2byteArr(Integer(0), Sender.OutBuff, offs);//  data.append( (char*)pathnodes.GetNodes( ), pathnodes.Size( ) * 4 * 3 );
  Sender.SendPacketWithOpcode(SMSG_MONSTER_MOVE, offs);    }

  //teleport
  TaxiNodes := TaxiNodesHandler.GetPointerPRValueByIntKey(destinationnode) ;
  if TaxiNodes <> nil then
    Sender.CurrChar.Teleport(TaxiNodes^.PositionX, TaxiNodes^.PositionY, TaxiNodes^.PositionZ, Sender.CurrChar.positionR, TaxiNodes^.MapID)
end;

end.
