unit MapHandler;

interface

uses
  AcedContainers,
  OpcodeHandler, Charhandler, Formulas  ;

const
  SIZE_OF_GRIDS = 533.33333;
  MAX_NUMBER_OF_GRIDS =     64;
  MAP_RESOLUTION = 256;
  
type
  GridMap = record
    area_flag:array[0..15, 0..15] of word;
    terrain_type:array[0..15, 0..15] of Byte;
    liquid_level:array[0..15, 0..15] of Single;
    Z:array[0..MAP_RESOLUTION-1, 0..MAP_RESOLUTION-1] of Single;
  end;

procedure UpdateCharsByZone(player : TPlayer; oldZone, newZone : word);
function GetCharsByZone(zoneId : integer) : TLinkedList;
function GetCharsByRadius(x, y, z, radius : single) : TLinkedList;

var
  GridMaps: array[0..MAX_NUMBER_OF_GRIDS-1, 0..MAX_NUMBER_OF_GRIDS-1] of GridMap;
  CharsByZones : TIntegerHashtable;
  
implementation

uses
  UnitMain;

function GetCharsByZone(zoneId : integer) : TLinkedList;
var
  zone : TLinkedList;
begin
  zone := CharsByZones.Items[zoneId];
  if zone = nil then zone := TLinkedList.Create;

  Result := zone;
end;

function GetCharsByRadius(x, y, z, radius : single) : TLinkedList;
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

      if (GetDistance(x, y, z, CurrChar.positionX, CurrChar.positionY, CurrChar.positionZ) <= radius) then l.AddHead(CurrChar.Owner);

      if ccount=PlayerCharsHT_byGUID.Count then break;
    end;
  end;

  Result := l;
end;

procedure UpdateCharsByZone(player : TPlayer; oldZone, newZone : word);
var
  zone : TLinkedList;
  node : PLinkedListNode;
begin
  //TODO: when client is disconnected he must be deleted from list
  zone := CharsByZones.Items[oldZone];
  if zone = nil then zone := TLinkedList.Create;

  node := zone.HeadNode;
  while node <> nil do
  begin
    if player = node.Value then
    begin
      zone.Remove(node);
      break;
    end;

    node := node.NextNode;
  end;

  CharsByZones.Items[oldZone] := zone;

  zone := CharsByZones.Items[newZone];
  if zone = nil then zone := TLinkedList.Create;

  zone.AddTail(player);

  CharsByZones.Items[newZone] := zone;
end;

end.
