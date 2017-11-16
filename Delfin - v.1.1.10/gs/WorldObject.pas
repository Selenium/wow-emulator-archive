unit WorldObject;

interface

uses Windows, UpdateConst, ByteArrayHandler;

type
  TObjectType = (
    TYPEID_OBJECT                           = 0,
    TYPEID_ITEM                             = 1,
    TYPEID_CONTAINER                        = 2,
    TYPEID_UNIT                             = 3,
    TYPEID_PLAYER                           = 4,
    TYPEID_GAMEOBJECT                       = 5,
    TYPEID_DYNAMICOBJECT                    = 6,
    TYPEID_CORPSE                           = 7,
    TYPEID_AIGROUP                          = 8,
    TYPEID_AREATRIGGER                      = 9
  );

  TWorldObject = class(TObject)
  protected
    procedure AppendUpdateBlock(buff: TSendOpcodeArr);
    procedure BuildMovementUpdate(buff: TSendOpcodeArr; IsOwner: boolean);
  public
    ID,dbcID: integer;
    UpdateArray: array of integer;   //[0..integer(PLAYER_END)]
    UpdateBitsArray: array of integer;   //[0..(integer(PLAYER_END) shr 5)+1]
    objGUID: int64;
    objType: TObjectType;
    updateBitsChanged: boolean;
    positionX, positionY, positionZ, positionR,  
       WalkSpeed, RunSpeed, BackwardSpeed, SweemSpeed, SweemBackSpeed, TurnRate: single;
    procedure BuildUpdateBlock(UpdateType: TUpdateType; IsOwner: boolean;
      buff: TSendOpcodeArr);
    procedure FinaliseSendUpdateBlock(Sender: TObject;
      buff: TSendOpcodeArr);
    procedure RaiseBits(index: integer);
  end;
  procedure SetUpdateBits(Sender: TWorldObject; value: int64; index: integer); overload;
  procedure SetUpdateBits(Sender: TWorldObject; value, index: integer); overload;
  procedure SetUpdateBits(Sender: TWorldObject; value: single; index: integer); overload;

implementation

uses ZLib, OpcodeHandler, OpConst, ItemHandler;

procedure TWorldObject.RaiseBits(index: integer);
var
   arr_pos,bit_pos: integer;
begin
     updateBitsChanged:=true;
     arr_pos:=index shr 5;
     bit_pos:=integer(1) shl (index and $1F);
     UpdateBitsArray[arr_pos]:=UpdateBitsArray[arr_pos] or bit_pos;
end;

procedure SetUpdateBits(Sender: TWorldObject; value: integer; index: integer);overload;
begin
     move((@value)^,Sender.UpdateArray[index],4);
     Sender.RaiseBits(index);
end;

procedure SetUpdateBits(Sender: TWorldObject; value: single; index: integer);overload;
begin
     move((@value)^,Sender.UpdateArray[index],4);
     Sender.RaiseBits(index);
end;

procedure SetUpdateBits(Sender: TWorldObject; value: int64; index: integer);overload;
var
   temp: int64;
begin
     temp:=value;
     move((@temp)^,Sender.UpdateArray[index],4);
     Sender.RaiseBits(index);
     temp:=temp shr 32;
     if temp <> 0 then
     begin
          move((@temp)^,Sender.UpdateArray[index+1],4);
          Sender.RaiseBits(index+1);
     end;
     {move((@value)^,Sender.UpdateArray[index],8);
     Sender.RaiseBits(index);
     Sender.RaiseBits(index+1);}
end;

//Append update bits and values
procedure TWorldObject.AppendUpdateBlock(buff: TSendOpcodeArr);
var
   i,j,arr_pos,bit_pos,mask,up_to: integer;
   index_len: byte;
begin
     index_len:=length(UpdateBitsArray);
     {while (index_len>0) do
     begin
          if UpdateBitsArray[index_len]<>0 then break
          else dec(index_len);
     end;
     inc(index_len,2);}
		 buff.Add(index_len);
     for j:=0 to pred(index_len) do buff.Add(UpdateBitsArray[j]);

     case objType of
          TYPEID_OBJECT        : up_to:=pred(OBJECT_END);
          TYPEID_ITEM          : up_to:=pred(ITEM_END);
          TYPEID_CONTAINER     : up_to:=pred(CONTAINER_END);
          TYPEID_UNIT          : up_to:=pred(UNIT_END);
          TYPEID_PLAYER        : up_to:=pred(PLAYER_END);
          TYPEID_GAMEOBJECT    : up_to:=pred(GAMEOBJECT_END);
          TYPEID_DYNAMICOBJECT : up_to:=pred(DYNAMICOBJECT_END);
          TYPEID_CORPSE        : up_to:=pred(CORPSE_END);
     else up_to:=0;
     end;

     for i:=0 to up_to do
     begin
          arr_pos:=i shr 5;
          bit_pos:=i and $1F;
          mask:=integer(1) shl bit_pos;
          if (UpdateBitsArray[arr_pos] and mask)<>0 then
          begin
               UpdateBitsArray[arr_pos]:=UpdateBitsArray[arr_pos] and (not mask);
               buff.Add(UpdateArray[i]);
          end;
     end;
     updateBitsChanged:=false;
end;

procedure TWorldObject.BuildMovementUpdate(buff: TSendOpcodeArr; IsOwner: boolean);
const
     single0: single = 0;
     single1: single = 1.0;
begin
   with buff do
   begin
     case objType of
          TYPEID_OBJECT,TYPEID_ITEM,TYPEID_CONTAINER     : begin
            Add(byte($10));
          end;
          TYPEID_UNIT          : begin
                                      Add(byte($70));
                                      Add(integer(0));  //$800000
                                      Add(integer(0));  //$B5771D7F
		                                  Add(positionX);Add(positionY);Add(positionZ);Add(positionR);Add(single0);
		                                  Add(WalkSpeed);Add(RunSpeed);Add(BackwardSpeed);Add(SweemSpeed);Add(SweemBackSpeed);
		                                  Add(TurnRate);
          end;
          TYPEID_PLAYER        : begin
                                 if IsOwner then begin
                                      {Add(byte(UPDATETYPE_OUT_OF_RANGE_OBJECTS));
                                      AddPackedGUID(objGUID);
                                      Add(byte(objType));}
                                      Add(byte($71));
                                      Add(integer($2000));//Add(integer($2000));
                                      Add(integer(0));//Add(integer($B74D85D1));
		                                  Add(positionX);Add(positionY);Add(positionZ);Add(positionR);Add(single0);
                                      Add(single0);Add(single1);Add(single0);Add(single0);
		                                  Add(WalkSpeed);Add(RunSpeed);Add(BackwardSpeed);Add(SweemSpeed);Add(SweemBackSpeed);
		                                  Add(TurnRate);
                                 end
                                 else begin
                                      Add(byte($70));
                                      Add(integer(0));
                                      Add(integer(0));  //$B74D85D1
		                                  Add(positionX);Add(positionY);Add(positionZ);Add(positionR);Add(single0);
		                                  Add(WalkSpeed);Add(RunSpeed);Add(BackwardSpeed);Add(SweemSpeed);Add(SweemBackSpeed);
		                                  Add(TurnRate);
                                 end;
          end;
          TYPEID_GAMEOBJECT,TYPEID_DYNAMICOBJECT,TYPEID_CORPSE        : begin
                                 if (objGUID shr 32)=HIGHGUID_PLAYER_CORPSE then begin
                                    Add(byte($52));
                                    Add(integer($6297848C));
                                    Add(integer($BD38BA14));
                                 end
                                 else begin
                                      Add(byte($50));
		                                  Add(positionX);Add(positionY);Add(positionZ);Add(positionR);
                                 end;
          end;
     end;
     Add(integer(0));
   end;
end;

procedure TWorldObject.BuildUpdateBlock(UpdateType: TUpdateType; IsOwner: boolean; buff: TSendOpcodeArr);
begin
   with buff do
   begin
      Add(byte(UpdateType));
      AddPackedGUID(objGUID);

			if (UpdateType<>UPDATETYPE_VALUES)then  // buildMoveType
			begin
           Add(byte(objType));
				   BuildMovementUpdate(buff,IsOwner);
      end;

			if (UpdateType<>UPDATETYPE_MOVEMENT)then  // have update value
         AppendUpdateBlock(buff);
   end;
end;

procedure TWorldObject.FinaliseSendUpdateBlock(Sender: TObject; buff: TSendOpcodeArr);
var
   zippedlen: integer;
   zbuff: pointer;
begin
     if buff.offs > 50000 then //50
     begin
          CompressBuf(@buff.data[4],buff.offs-4,zbuff,zippedlen);
          //move(zbuff^,(@(Sender as TPlayer).SendBuff.data[8])^,zippedlen);
          with (Sender as TPlayer) do
          begin
               SendBuff.Init(SMSG_COMPRESSED_UPDATE_OBJECT);
		           SendBuff.Add(buff.offs);
               SendBuff.Add(zbuff,zippedlen);
               SendPacket;
          end;
     end
     else with (Sender as TPlayer) do
     begin
          SendBuff.Init(SMSG_UPDATE_OBJECT);
          SendBuff.Add(@buff.data[4],buff.offs-4);
          SendPacket;
     end;
end;

end.
