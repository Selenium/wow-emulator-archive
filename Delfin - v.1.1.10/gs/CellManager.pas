unit CellManager;

interface

uses Windows, AcedContainers, WorldObject, CharHandler, CharConst;

const
     Map_cell_size = 100;
     MaxOrdMapCell = 200;
     MaxInstMapCell = 80;
     PlayerIsAllianceFaction: array[1..9]of boolean = (true,false,true,true,false,false,false,true,false);
     InstNumbersArr: array[0..39]of integer = (13,25,29,30,33,34,35,36,37,42,43,44,47,48,70,90,109,129,169,
               189,209,229,230,249,269,289,309,329,349,369,389,409,429,449,450,451,469,489,509,529);
     //TODO dynamic inst cell objects, descendant from TMapCell, set cellsize & mapId on create
type
  TOrdinalMapCellArr = array[0..1,-MaxOrdMapCell..MaxOrdMapCell,-MaxOrdMapCell..MaxOrdMapCell]of TArrayList; //continent,x,y
  TOrdinalSpawnActiveByCellsArr = array[0..1,-MaxOrdMapCell..MaxOrdMapCell,-MaxOrdMapCell..MaxOrdMapCell]of boolean; //continent,x,y
  //TInstMapCellArr = array[0..39,-MaxInstMapCell..MaxInstMapCell,-MaxInstMapCell..MaxInstMapCell]of TArrayList;
  TSpawnCellObject = class
  private
    {}
  public
    dbcID: integer;
    objType: TObjectType;
    positionX, positionY: single;  //this can be dynamic
    mapId: word;
    constructor Create(soObjID,soObjType: integer; posX, posY: single; soMapId: word);
  end;

  TMapCell = class
  private
    PlayerCharsCells,ActiveObjectsCells,SpawnCells: TOrdinalMapCellArr;
    OrdinalSpawnedActiveByCellsArr: TOrdinalSpawnActiveByCellsArr;
    //instPlayerCells,instMobGoCells: TInstMapCellArr;
    //InstNumber2arrpos: array[13..530]of integer;
    procedure Add2OrdMapCellArr(obj: TObject; var arr: TOrdinalMapCellArr; map_id,cell_x,cell_y: integer);
    procedure RemoveOrdMapCellArr(obj: TObject; var arr: TOrdinalMapCellArr; map_id,cell_x,cell_y: integer);
    procedure AddObj(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
    procedure RemoveObj(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
    procedure AddSpawn(obj: TSpawnCellObject; map_id, cell_x,cell_y: integer);
    procedure RemoveSpawn(obj: TSpawnCellObject; map_id, cell_x,cell_y: integer);
    procedure SendCreateObjectMsg2Char(plchar,obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
    procedure SendCreateObjectMsg2playersInCell(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
    procedure SendRemoveObjectFromCellMsg2playersInCell(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
    procedure InitSpawnsInCellForChar(plchar: TActiveWorldObject; map_id, cell_x, cell_y,plr_cell_x,plr_cell_y: integer);
    procedure InitPlayersInCellForChar(plchar: TActiveWorldObject; map_id, cell_x, cell_y, plr_cell_x, plr_cell_y: integer);
    procedure RemoveCharFromCell(plchar: TActiveWorldObject; map_id, cell_x, cell_y: integer);
    procedure SendRemoveObjectsInCell2Char(plchar: TActiveWorldObject; map_id, cell_x, cell_y: integer);
    //procedure RemovePlayerInCellForPlayers(obj: TActiveWorldObject; map_id, cell_x, cell_y, plr_cell_x, plr_cell_y: integer);
  public
    constructor Create;
    procedure CreateObj(obj: TActiveWorldObject);
    procedure FindCellRemoveObject(obj: TActiveWorldObject);
    procedure CreateSpawn(obj: TSpawnCellObject);
    procedure FindCellRemoveSpawn(obj: TSpawnCellObject);
    procedure MoveObj(obj: TActiveWorldObject; OpCode: word; ltime: integer);
    procedure SendMoveObjectMsg2playersInCellsNear(obj: TActiveWorldObject; OpCode: word; ltime,map_id,cell_x,cell_y: integer);
  end;
  function MatchObjectGUID(Item1, Item2: Pointer): Integer;

implementation

uses OpcodeHandler, ByteArrayHandler, OpConst, DbcFieldsConst, UnitMain;

{ TSpawnCellObject }

constructor TSpawnCellObject.Create(soObjID,soObjType: integer; posX, posY: single;
  soMapId: word);
begin
     dbcID:=soObjID;objType:=TObjectType(soObjType);
     positionX:=posX; positionY:=posY;
     mapId:=soMapId;
end;

{ MapCell }

constructor TMapCell.Create;
var
   x,y: integer;  //i,
begin
     //FillChar(InstNumber2arrpos,sizeof(InstNumber2arrpos),0);
     //for i:=0 to 39 do InstNumber2arrpos[InstNumbersArr[i]]:=i;
     for x:=-MaxOrdMapCell to MaxOrdMapCell do
         for y:=-MaxOrdMapCell to MaxOrdMapCell do
         begin
              OrdinalSpawnedActiveByCellsArr[0,x,y]:=false;
              OrdinalSpawnedActiveByCellsArr[1,x,y]:=false;
         end;
end;

function MatchObjectGUID(Item1, Item2: Pointer): Integer;
var
  S1, S2: TActiveWorldObject;
begin
  S1 := TActiveWorldObject(Item1);
  S2 := TActiveWorldObject(Item2);
  Result := 0;
  if (S1 <> nil) and (S2 <> nil) then
  begin
    if S1.objGUID <> S2.objGUID then
    begin
         if S1.objGUID < S2.objGUID then result := -1
         else result:=1;
    end;
  end
  else if S1 <> nil then
    Result := -1
  else if S2 <> nil then
    Result := 1;
end;

function GetSuccCell(cell: integer): integer;
begin
     result:=cell;
     inc(result);
     if result>MaxOrdMapCell then result:=MaxOrdMapCell;
end;

function GetPrevCell(cell: integer): integer;
begin
     result:=cell;
     dec(result);
     if cell<(-MaxOrdMapCell) then result:=-MaxOrdMapCell;
end;

function GetAddArrCoord(index, cell: integer): integer;
begin
     result:=cell; //default index 1
     if index=0 then result:=GetPrevCell(cell)
     else if index=2 then result:=GetSuccCell(cell);
end;

procedure TMapCell.AddSpawn(obj: TSpawnCellObject; map_id,cell_x,cell_y: integer);
begin
     if (map_id = 0)or(map_id = 1) then //Azeroth or Kalimdor
     begin
          Add2OrdMapCellArr(obj,SpawnCells,map_id,cell_x,cell_y);
     end;
     {else if (obj.mapId >= 13)or(obj.mapId <= 530) then //instances
     begin
          if obj.objType = TYPEID_PLAYER then Add2InstMapCellArr(obj,instPlayerCells,map_id,cell_x,cell_y)
          else Add2InstMapCellArr(obj,instGoCells,map_id,cell_x,cell_y);
     end;}
end;

{ добавляет кодинаты спавнов в сетку при загрузке мира }
procedure TMapCell.CreateSpawn(obj: TSpawnCellObject);
var
   cell_x,cell_y: integer;
begin
     cell_x:=trunc(obj.positionX / Map_cell_size);
     cell_y:=trunc(obj.positionY / Map_cell_size);
     AddSpawn(obj,obj.mapId,cell_x,cell_y);
end;

procedure TMapCell.CreateObj(obj: TActiveWorldObject);
var
   cell_x,cell_y,x,y,local_cell_x,local_cell_y: integer;
begin
     cell_x:=trunc(obj.positionX / Map_cell_size);
     cell_y:=trunc(obj.positionY / Map_cell_size);
     AddObj(obj,obj.mapId,cell_x,cell_y);
     for x:=0 to 2 do
         for y:=0 to 2 do
         begin
              local_cell_x:=GetAddArrCoord(x,cell_x);
              local_cell_y:=GetAddArrCoord(y,cell_y);
              SendCreateObjectMsg2playersInCell(obj,obj.mapId,local_cell_x,local_cell_y);
              if obj.objType=TYPEID_PLAYER then
              begin
                   //инициализировать пакеты других чаров и отослать всех чару
                   InitPlayersInCellForChar(obj,obj.mapId,local_cell_x,local_cell_y,cell_x,cell_y);
                   //инициализировать пакеты мобов и отослать всех чару
                   InitSpawnsInCellForChar(obj,obj.mapId,local_cell_x,local_cell_y,cell_x,cell_y);
              end;
         end;

     obj.oldPositionX:=obj.positionX; obj.oldPositionY:=obj.positionY; obj.oldPositionZ:=obj.positionZ;
     obj.oldMapId:=obj.mapId;
end;

procedure TMapCell.Add2OrdMapCellArr(obj: TObject; var arr: TOrdinalMapCellArr;
   map_id,cell_x,cell_y: integer);
begin
     if arr[map_id,cell_x,cell_y]=nil then arr[map_id,cell_x,cell_y]:=TArrayList.Create(10);
     arr[map_id,cell_x,cell_y].Add(obj);
end;

{ удалить объект из ячейки }
procedure TMapCell.RemoveOrdMapCellArr(obj: TObject; var arr: TOrdinalMapCellArr;
   map_id,cell_x,cell_y: integer);
var
   index: integer;
begin
     if arr[map_id,cell_x,cell_y]<>nil then
     begin
          index:=arr[map_id,cell_x,cell_y].IndexOf(obj,MatchObjectGUID,false);
          if index>=0 then arr[map_id,cell_x,cell_y].RemoveAt(index);
     end;
end;

{ добавить объект в ячейку }
procedure TMapCell.AddObj(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
begin
     if (map_id = 0)or(map_id = 1) then //Azeroth or Kalimdor
     begin
          if (obj.objType=TYPEID_PLAYER) then
             Add2OrdMapCellArr(obj,PlayerCharsCells,map_id,cell_x,cell_y)
          else Add2OrdMapCellArr(obj,ActiveObjectsCells,map_id,cell_x,cell_y);
     end;
     {else if (obj.mapId >= 13)or(obj.mapId <= 530) then //instances
     begin
          if obj.objType = TYPEID_PLAYER then Add2InstMapCellArr(obj,instPlayerCells,map_id,cell_x,cell_y)
          else Add2InstMapCellArr(obj,instGoCells,map_id,cell_x,cell_y);
     end;}
end;

{ удалить объект из ячейки спавненых чаров, го или мобов }
procedure TMapCell.RemoveObj(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
begin
     if (map_id = 0)or(map_id = 1) then //Azeroth or Kalimdor
     begin
          if (obj.objType=TYPEID_PLAYER) then
          begin
               RemoveOrdMapCellArr(obj,PlayerCharsCells,map_id,cell_x,cell_y);
          end
          else RemoveOrdMapCellArr(obj,ActiveObjectsCells,map_id,cell_x,cell_y);
     end
     {else if (mapId >= 13)or(mapId <= 530) then //instances
     begin
          try
             case obj.objType of
                  TYPEID_UNIT          : RemoveInstMapCellArr(instMobCells,cell_x,cell_y);
                  TYPEID_PLAYER        : if (obj.Faction > 0)and(obj.Faction < 10)then
                                         begin
                                              if PlayerIsAllianceFaction[obj.Faction] then RemoveInstMapCellArr(instAllyPlayerCells,cell_x,cell_y)
                                              else RemoveInstMapCellArr(instHordePlayerCells,cell_x,cell_y);
                                         end;
                  TYPEID_GAMEOBJECT    : RemoveInstMapCellArr(instGoCells,cell_x,cell_y);
                  TYPEID_DYNAMICOBJECT : RemoveInstMapCellArr(instGoCells,cell_x,cell_y);
                  TYPEID_CORPSE        : RemoveInstMapCellArr(instGoCells,cell_x,cell_y);
             end;
          except;
          end;
     end;}
end;

{ удалить объект из ячейки спавненых чаров, го или мобов и разослать сообщение в ячейки рядом }
procedure TMapCell.FindCellRemoveObject(obj: TActiveWorldObject);
var
   cell_x,cell_y,x,y: integer;
begin
     cell_x:=trunc(obj.oldPositionX / Map_cell_size);
     cell_y:=trunc(obj.oldPositionY / Map_cell_size);
     RemoveObj(obj,obj.oldMapId,cell_x,cell_y);
     for x:=0 to 2 do
         for y:=0 to 2 do
             SendRemoveObjectFromCellMsg2playersInCell(obj,obj.oldMapId,GetAddArrCoord(x,cell_x),GetAddArrCoord(y,cell_y));
end;

{ удалить объект из ячейки спавнов }
procedure TMapCell.RemoveSpawn(obj: TSpawnCellObject; map_id,cell_x,cell_y: integer);
begin
     if (map_id = 0)or(map_id = 1) then //Azeroth or Kalimdor
     begin
          RemoveOrdMapCellArr(obj,SpawnCells,map_id,cell_x,cell_y);
     end;
end;

{ найти ячейку и удалить объект из ячейки спавнов }
procedure TMapCell.FindCellRemoveSpawn(obj: TSpawnCellObject);
var
   cell_x,cell_y: integer;
begin
     cell_x:=trunc(obj.positionX / Map_cell_size);
     cell_y:=trunc(obj.positionY / Map_cell_size);
     RemoveSpawn(obj,obj.mapId,cell_x,cell_y);
end;

{ для всех чаров в ячейке отправить пакет о движении объекта }
procedure TMapCell.SendMoveObjectMsg2playersInCellsNear(obj: TActiveWorldObject; OpCode: word; ltime,map_id,cell_x,cell_y: integer);
var
   o,offs,x,y,lx,ly: integer;
   a: TArrayList;
   tempObj: TActiveWorldObject;
   tempArr: array of byte;
begin
     setlength(tempArr,32);
     offs:=0;
     Add2DByteArr(obj.objGUID,tempArr,offs);
     Add2DByteArr(obj.Flags,tempArr,offs);
     Add2DByteArr(ltime,tempArr,offs);
     Add2DByteArr(obj.positionX,tempArr,offs);
     Add2DByteArr(obj.positionY,tempArr,offs);
     Add2DByteArr(obj.positionZ,tempArr,offs);
     Add2DByteArr(obj.positionR,tempArr,offs);

     for x:=0 to 2 do
         for y:=0 to 2 do
         begin
              lx:=GetAddArrCoord(x,cell_x);
              ly:=GetAddArrCoord(y,cell_y);

              a:=PlayerCharsCells[map_id,lx,ly];
              if (a<>nil) then
                 for o:=0 to pred(a.Count)do
                 begin
                      tempObj:=TActiveWorldObject(a.ItemList[o]);
                      if (tempObj<>nil)and(tempObj<>obj) then
                      with ((tempObj as TCharacter).Owner as TPlayer) do
                      begin
                           SendBuff.Init(OpCode);
                           move(tempArr[0],(@SendBuff.data[4])^,32);
                           SendBuff.offs:=36;
                           SendPacket;
                      end;
                 end;
        end;
end;

{ для всех чаров в ячейке разослать пакет о создании объекта }
procedure TMapCell.SendCreateObjectMsg2playersInCell(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
var
   o: integer;
   a: TArrayList;
   tempObj: TActiveWorldObject;
   buff: TSendOpcodeArr;
begin
     a:=PlayerCharsCells[map_id,cell_x,cell_y];
     if (a=nil)or(a.Count=0) then exit;
     //prepare send object to others
     if (obj.objType=TYPEID_PLAYER) then (obj as TCharacter).InitUpdateArrayForOthers
     else if (obj.objType=TYPEID_UNIT) then (obj as TMobile).InitUpdateArrayForOthers
     else if (obj.objType=TYPEID_GAMEOBJECT) then (obj as TGameObject).InitUpdateArrayForOthers;
     //npc flags different for some npc & GO first %(
     buff:=TSendOpcodeArr.Create;
     try
        obj.CreateUpdateBlockForOthers(buff);
        //setlength(buff,data_len);

        for o:=0 to pred(a.Count)do
        begin
             tempObj:=TActiveWorldObject(a.ItemList[o]);
             if (tempObj<>nil)and(tempObj<>obj)then
                  //send obj to players in cell
                  (obj as TWorldObject).FinaliseSendUpdateBlock((tempObj as TCharacter).Owner,buff);
        end;
        //same packet, create/finalize and just send to each player!!!
     finally buff.Free;
     end;
end;

{ послать чару пакет о создании объекта }
procedure TMapCell.SendCreateObjectMsg2Char(plchar,obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
var
   buff: TSendOpcodeArr;
begin
     //prepare send object to others
     if (obj.objType=TYPEID_PLAYER) then (obj as TCharacter).InitUpdateArrayForOthers
     else if (obj.objType=TYPEID_UNIT) then (obj as TMobile).InitUpdateArrayForOthers
     else if (obj.objType=TYPEID_GAMEOBJECT) then (obj as TGameObject).InitUpdateArrayForOthers;
     //npc flags different for some npc & GO first %(
     buff:=TSendOpcodeArr.Create;
     try
        obj.CreateUpdateBlockForOthers(buff);
        (obj as TWorldObject).FinaliseSendUpdateBlock((plchar as TCharacter).Owner,buff);
     finally
       buff.Free;
     end;
end;

{ для всех чаров в ячейке удалить объект }
procedure TMapCell.SendRemoveObjectFromCellMsg2playersInCell(obj: TActiveWorldObject; map_id,cell_x,cell_y: integer);
var
   o: integer;
   a: TArrayList;
   tempObj: TActiveWorldObject;
   //buff: array of byte;
begin
     //setlength(buff,8);

     a:=PlayerCharsCells[map_id,cell_x,cell_y];
     if (a<>nil)and(a.Count>0) then
        for o:=0 to pred(a.Count)do
        begin
             tempObj:=TActiveWorldObject(a.ItemList[o]);
             if (tempObj<>nil)and(tempObj<>obj) then   // должен быть уже удален перед вызовом
             with ((tempObj as TCharacter).Owner as TPlayer) do
             begin
                  SendBuff.Init(SMSG_DESTROY_OBJECT);
                  SendBuff.Add(obj.objGUID);
                  SendPacket;
             end;
        end;
end;

{ удалить все объекты для чара в ячейке }
procedure TMapCell.SendRemoveObjectsInCell2Char(plchar: TActiveWorldObject; map_id,cell_x,cell_y: integer);
var
   o: integer;
   a: TArrayList;
   tempObj: TActiveWorldObject;
   //buff: array of byte;
begin
     //setlength(buff,8);

     a:=PlayerCharsCells[map_id,cell_x,cell_y];
     if (a<>nil)and(a.Count>0) then
        for o:=0 to pred(a.Count)do
        begin
             tempObj:=TActiveWorldObject(a.ItemList[o]);
             if (tempObj<>nil)and(tempObj<>plchar) then
             with ((plchar as TCharacter).Owner as TPlayer) do
             begin
                  SendBuff.Init(SMSG_DESTROY_OBJECT);
                  SendBuff.Add(tempObj.objGUID);
                  SendPacket;
             end;
        end;

     a:=ActiveObjectsCells[map_id,cell_x,cell_y];
     if (a<>nil)and(a.Count>0) then
        for o:=0 to pred(a.Count)do
        begin
             tempObj:=TActiveWorldObject(a.ItemList[o]);
             if (tempObj<>nil) then
             with ((plchar as TCharacter).Owner as TPlayer) do
             begin
                  SendBuff.Init(SMSG_DESTROY_OBJECT);
                  SendBuff.Add(tempObj.objGUID);
                  SendPacket;
             end;
        end;
end;

{ инициализировать пакеты других чаров и отослать всех чару, сравнить что не тот же!!! }
procedure TMapCell.InitPlayersInCellForChar(plchar: TActiveWorldObject; map_id, cell_x, cell_y,plr_cell_x,plr_cell_y: integer);
var
   i: integer;
   //a: TArrayList;
   obj: TCharacter;
begin
     //если есть игроки в ячейке
     if (PlayerCharsCells[map_id, cell_x, cell_y]<>nil)and(PlayerCharsCells[map_id, cell_x, cell_y].Count>0) then
     begin
          for i:=0 to pred(PlayerCharsCells[map_id, cell_x, cell_y].Count)do
          begin
               obj:=TCharacter(PlayerCharsCells[map_id, cell_x, cell_y].ItemList[i]);
               if (obj <> nil)and(obj.objGUID <> plchar.objGUID) then
               begin
                    //send only to cell from where init
                    //для всех чаров в ячейке разослать пакет о создании объекта
                    SendCreateObjectMsg2Char(plchar,obj,map_Id,plr_cell_x,plr_cell_y);
               end
          end;
     end;
end;

{ инициализировать пакеты спавнов или создать мобов/го если не созданы, отослать всех чару }
procedure TMapCell.InitSpawnsInCellForChar(plchar: TActiveWorldObject; map_id, cell_x, cell_y,plr_cell_x,plr_cell_y: integer);
var
   i: integer;
   a: TArrayList;
   spawnObj: TSpawnCellObject;
   obj: TActiveWorldObject;
   mob: TMobile;
   go: TGameObject;
begin
     if not(OrdinalSpawnedActiveByCellsArr[map_id, cell_x, cell_y]) then //not spawned
     begin
          if (SpawnCells[map_id, cell_x, cell_y]<>nil)and(SpawnCells[map_id, cell_x, cell_y].Count>0) then
          begin
               OrdinalSpawnedActiveByCellsArr[map_id, cell_x, cell_y]:=true;
               for i:=0 to pred(SpawnCells[map_id, cell_x, cell_y].Count)do
               begin
                    spawnObj:=TSpawnCellObject(SpawnCells[map_id, cell_x, cell_y].ItemList[i]);
                    if spawnObj.objType = TYPEID_UNIT then
                    begin
                         mob:=TMobile.Create(spawnObj.dbcID);

                         //if plchar.state = DEATH_STATE_GHOST then Exit ;

                         //Не показываем спирит хилера для тех кто не GHOST
                         if mob.npcFlags = 33 then //моб - спиритхилер
                           if plchar.state <> DEATH_STATE_GHOST then Exit;//Есди не дух

                         AddObj(mob,map_id, cell_x, cell_y);
                         //send only to cell from where init
                         //для всех чаров в ячейке разослать пакет о создании объекта
                         SendCreateObjectMsg2Char(plchar,mob,map_Id,plr_cell_x,plr_cell_y);
                         try
                            UnitHT_byGUID.Add(mob.objGUID,mob);
                         except;
                         end;
                    end
                    else if spawnObj.objType = TYPEID_GAMEOBJECT then
                    begin
                         go:=TGameObject.Create(spawnObj.dbcID);
                         AddObj(go,map_id, cell_x, cell_y);
                         //send only to cell from where init
                         //для всех чаров в ячейке разослать пакет о создании объекта
                         SendCreateObjectMsg2Char(plchar,go,map_Id,plr_cell_x,plr_cell_y);
                         try
                            UnitHT_byGUID.Add(go.objGUID,go);
                         except;
                         end;
                    end;
               end;
          end;
     end
     //если уже созданы
     else if (ActiveObjectsCells[map_id, cell_x, cell_y]<>nil)and(ActiveObjectsCells[map_id, cell_x, cell_y].Count>0) then
     begin
          a:=ActiveObjectsCells[map_id, cell_x, cell_y];
          for i:=0 to pred(a.Count)do
          begin
               obj:=TActiveWorldObject(a.ItemList[i]);
               //для всех чаров в ячейке разослать пакет о создании объекта
               SendCreateObjectMsg2Char(plchar,obj,map_Id,plr_cell_x,plr_cell_y);
          end;
     end;
end;

{ удалить чара из ячеек спавненых чаров, разослать сообщение в ячейки рядом и почистить ячейки от мобов и го если чаров поблизости нет}
procedure TMapCell.RemoveCharFromCell(plchar: TActiveWorldObject; map_id, cell_x, cell_y: integer);
var
   i,x,y,local_cell_x,local_cell_y: integer;
   a: TArrayList;
   obj: TActiveWorldObject;
   playersFound: boolean;
begin
     {if (OrdinalSpawnedActiveByCellsArr[map_id, cell_x, cell_y])and(ActiveObjectsCells[map_id, cell_x, cell_y]<>nil)and(ActiveObjectsCells[map_id, cell_x, cell_y].Count>0) then
        SendRemoveObjectFromCellMsg2playersInCell(plchar,map_Id,cell_x,cell_y);}

     playersFound:=false;
     for x:=0 to 2 do
         for y:=0 to 2 do
         begin
             local_cell_x:=GetAddArrCoord(x,cell_x);
             local_cell_y:=GetAddArrCoord(y,cell_y);
             if (PlayerCharsCells[map_id, local_cell_x, local_cell_y]<>nil)and(PlayerCharsCells[map_id, local_cell_x, local_cell_y].Count>0) then
                playersFound:=true;
         end;

     if not(playersFound)and(ActiveObjectsCells[map_id, cell_x, cell_y]<>nil)and(ActiveObjectsCells[map_id, cell_x, cell_y].Count>0) then
     begin
          OrdinalSpawnedActiveByCellsArr[map_id, cell_x, cell_y]:=false;
          a:=ActiveObjectsCells[map_id, cell_x, cell_y];
          for i:=0 to pred(a.Count)do
          begin
               obj:=TActiveWorldObject(a.ItemList[i]);
               if (obj.objType=TYPEID_UNIT) then    
                  UnitHT_byGUID.Remove(obj.objGUID);
               a.ItemList[i]:=nil;
          end;
          ActiveObjectsCells[map_id, cell_x, cell_y]:=nil;
          //no more links, garbage collector should destroy objects
     end;
end;


procedure TMapCell.MoveObj(obj: TActiveWorldObject; OpCode: word; ltime: integer);
var
   new_map_id,old_map_id,new_cell_x,new_cell_y,old_cell_x,old_cell_y: integer;
   x,y,from_add_x,from_add_y,from_rem_x,from_rem_y,to_add_x,to_add_y,to_rem_x,to_rem_y: integer;
   x_differs,x_more: boolean;
begin
     new_map_id:=obj.mapId;
     old_map_id:=obj.oldMapId;
     new_cell_x:=trunc(obj.positionX / Map_cell_size);
     new_cell_y:=trunc(obj.positionY / Map_cell_size);

     old_cell_x:=trunc(obj.oldPositionX / Map_cell_size);
     old_cell_y:=trunc(obj.oldPositionY / Map_cell_size);

     //в той же ячейке
     if (new_cell_x=old_cell_x)and(new_cell_y=old_cell_y) then
     begin
          SendMoveObjectMsg2playersInCellsNear(obj,OpCode,ltime,new_map_id,new_cell_x,new_cell_y);
          obj.oldPositionX:=obj.positionX; obj.oldPositionY:=obj.positionY; obj.oldPositionZ:=obj.positionZ;
          exit;
     end;
     if new_map_id<>old_map_id then //in/out instance, remove full
     begin
          FindCellRemoveObject(obj);  //remove already spawned
          CreateObj(obj);             //create object and send to players near
     end
     // в зависимости от направления перемещения по сетке вычислить ячейки в которые добавит/удалить
     else //if (old_map_id = 0)or(old_map_id = 1) then Azeroth or Kalimdor
     begin
          //удалить из ячейки где был
          RemoveObj(obj,old_map_id,old_cell_x,old_cell_y);
          //добавить куда переместился
          AddObj(obj,new_map_id,new_cell_x,new_cell_y);
          x_differs:=false;x_more:=false;
          //х сетки поменялся
          if new_cell_x<>old_cell_x then
          begin
               x_differs:=true;

               if new_cell_x>old_cell_x then
               begin
                    from_add_x:=GetSuccCell(new_cell_x);
                    from_rem_x:=GetPrevCell(old_cell_x);
                    x_more:=true;
               end
               else begin
                    from_add_x:=GetPrevCell(new_cell_x);
                    from_rem_x:=GetSuccCell(old_cell_x);
               end;
               from_add_y:=GetPrevCell(new_cell_y);
               to_add_y:=GetSuccCell(new_cell_y);
               from_rem_y:=GetPrevCell(old_cell_y);
               to_rem_y:=GetSuccCell(old_cell_y);
               for y:=from_rem_y to to_rem_y do
               begin
                    //разослать удаление по Y
                    SendRemoveObjectFromCellMsg2playersInCell(obj,old_map_id,from_rem_x,y);
                    //почистить спавненых если рядом нет игроков
                    //RemovePlayerInCellForPlayers(obj,old_map_id,from_rem_x,y,new_cell_x,new_cell_y);
                    if (obj.objType=TYPEID_PLAYER) then
                    begin
                         SendRemoveObjectsInCell2Char(obj,old_map_id,from_rem_x,y);
                         RemoveCharFromCell(obj,old_map_id,from_rem_x,y);
                    end;
               end;
               for y:=from_add_y to to_add_y do
               begin
                    //разослать создание по Y
                    SendCreateObjectMsg2playersInCell(obj,new_map_id,from_add_x,y);
                    //отправить всех мобов и чаров игроку в новых ячейках
                    if (obj.objType=TYPEID_PLAYER) then
                    begin
                         InitPlayersInCellForChar(obj,new_map_id,from_add_x,y,new_cell_x,new_cell_y);
                         InitSpawnsInCellForChar(obj,new_map_id,from_add_x,y,new_cell_x,new_cell_y);
                    end;
               end;
          end;
          if new_cell_y<>old_cell_y then
          begin
               if new_cell_y>old_cell_y then
               begin
                    from_add_y:=GetSuccCell(new_cell_y);
                    from_rem_y:=GetPrevCell(old_cell_y);
               end
               else begin
                    from_add_y:=GetPrevCell(new_cell_y);
                    from_rem_y:=GetSuccCell(old_cell_y);
               end;
               if x_differs then
               begin
                    if x_more then
                    begin
                         from_add_x:=GetPrevCell(new_cell_x);
                         to_add_x:=new_cell_x;
                         from_rem_x:=old_cell_x;
                         to_rem_x:=GetSuccCell(old_cell_x);
                    end
                    else begin
                         from_add_x:=new_cell_x;
                         to_add_x:=GetSuccCell(new_cell_x);
                         from_rem_x:=GetPrevCell(old_cell_x);
                         to_rem_x:=old_cell_x;
                    end;
               end
               else begin
                         from_add_x:=GetPrevCell(new_cell_x);
                         to_add_x:=GetSuccCell(new_cell_x);
                         from_rem_x:=GetPrevCell(old_cell_x);
                         to_rem_x:=GetSuccCell(old_cell_x);
               end;
               for x:=from_rem_x to to_rem_x do
               begin
                    //разослать удаление по X
                    SendRemoveObjectFromCellMsg2playersInCell(obj,old_map_id,x,from_rem_y);
                    //почистить спавненых если рядом нет игроков
                    //RemoveSpawnedInCellForPlayer(old_map_id,x,from_rem_y,new_cell_x,new_cell_y);
                    if (obj.objType=TYPEID_PLAYER) then
                    begin
                         SendRemoveObjectsInCell2Char(obj,old_map_id,x,from_rem_y);
                         RemoveCharFromCell(obj,old_map_id,x,from_rem_y);
                    end;
               end;
               for x:=from_add_x to to_add_x do
               begin
                    //разослать создание по Х
                    SendCreateObjectMsg2playersInCell(obj,new_map_id,x,from_add_y);
                    //отправить всех мобов и чаров игроку в новых ячейках
                    if (obj.objType=TYPEID_PLAYER) then
                    begin
                         InitPlayersInCellForChar(obj,new_map_id,x,from_add_y,new_cell_x,new_cell_y);
                         InitSpawnsInCellForChar(obj,new_map_id,x,from_add_y,new_cell_x,new_cell_y);
                    end;
               end;
          end;
     end;
     SendMoveObjectMsg2playersInCellsNear(obj,OpCode,ltime,new_map_id,new_cell_x,new_cell_y);
     obj.oldPositionX:=obj.positionX; obj.oldPositionY:=obj.positionY; obj.oldPositionZ:=obj.positionZ;
     obj.oldMapId:=obj.mapId;
end;

end.
