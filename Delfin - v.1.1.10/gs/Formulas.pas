unit Formulas;

interface

function CalcFallDamage(FallTime: Integer): Integer;
function GetQDistance(x1,x2,y1,y2,z1,z2: Single): Single;
function GetDistance(x1,x2,y1,y2,z1,z2: Single): Single;
function IsInReach(x1, y1, z1, x2, y2, z2, reach : single) : boolean;

implementation

function GetQDistance(x1,x2,y1,y2,z1,z2: Single): Single;
var
  x,y,z: Single;
begin
  x := x1 - x2;
  y := y1 - y2;
  z := z1 - z2;

  Result := x*x + y*y + z*z ;
end;

function GetDistance(x1,x2,y1,y2,z1,z2: Single): Single;
begin
  //Result := Sqrt(Sqr(x1 - x2)+Sqr(y1 - y2)+Sqr(z1 - z2)) ;
  Result := Sqrt(GetQDistance(x1,x2,y1,y2,z1,z2));
end;

function IsInReach(x1, y1, z1, x2, y2, z2, reach : single) : boolean;
begin
  Result := (abs(x1 - x2) <= reach) and (abs(y1 - y2) <= reach) and (abs(z1 - z2) <= reach);
end;

function CalcFallDamage(FallTime: Integer): Integer;
begin
  Result := 0;
  if FallTime > 1100 then
    Result := (FallTime - 1100) div 9;
    //Result := (FallTime - 1100) div 100 + 1;
end;

end.
