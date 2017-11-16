unit SpellHandler;

interface

uses Windows, AcedContainers, SysUtils, Dialogs;

type
  TQuickSortFind = class
  private
    prom_arr: array of integer;
    FMoveSize: integer;
    FFieldSize: integer;
    procedure ASwap(var G: array of integer; A, B: integer);
  public
    constructor Create(fieldSize: integer);
    procedure QuickSortIndex(var A: array of integer; iLo, iHi, sortFieldIndex: Integer);
    function QuickFindIndex(const A: array of integer; const looking_for, iLo, iHi, sortFieldIndex: Integer):integer;
  end;
  TSpellLearnClassTemplate = class
  public
    learnTemplate: array of integer;
    spellCount: integer;
    constructor Create(maxlvl,bRace,bClass: integer; craftskill1,craftskill2,craftskill3: integer);
  end;
  procedure InitLearnHashtable;

var
   Spell2Learn: TIntegerIntValueHashtable;
const
     temp_spells_field_count: integer = 6; //learn ID,baseLevel,reqSkill,minSkill,reqSpell,spellCost

implementation

uses DbcHandler, UnitMain, DbcFieldsConst;

constructor TQuickSortFind.Create(fieldSize: integer);
begin
     FFieldSize:=fieldSize;
     FMoveSize:=fieldSize shl 2;
     setlength(prom_arr,fieldSize);
end;

{ iLo, iHi: record offset in array }
procedure TQuickSortFind.ASwap(var G: array of integer; A, B: integer);
begin
     move(G[A],prom_arr[0],FMoveSize);
     move(G[B],G[A],FMoveSize);
     move(prom_arr[0],G[B],FMoveSize);
end;

{ iLo, iHi: record number in array }
procedure TQuickSortFind.QuickSortIndex(var A: array of integer; iLo, iHi, sortFieldIndex: Integer);
var
  Lo, Hi: Integer;
  pivot: integer;
begin
    Lo := iLo;
    Hi := iHi;
    pivot:=A[((Lo + Hi) div 2)*FFieldSize+sortFieldIndex];
    repeat
      while A[Lo*FFieldSize+sortFieldIndex] < pivot do Inc(Lo);
      while A[Hi*FFieldSize+sortFieldIndex] > pivot do Dec(Hi);
      if Lo <= Hi then
      begin
        if Lo <> Hi then ASwap(A,Lo*FFieldSize,Hi*FFieldSize);
        Inc(Lo);
        Dec(Hi);
      end;
    until Lo > Hi;
    if Hi > iLo then QuickSortIndex(A, iLo, Hi, sortFieldIndex);
    if Lo < iHi then QuickSortIndex(A, Lo, iHi, sortFieldIndex);
end;

{ iLo, iHi: record number in array }
function TQuickSortFind.QuickFindIndex(const A: array of integer; const looking_for, iLo, iHi, sortFieldIndex: Integer):integer;
var
  Mid: Integer;
  pivot: integer;
begin
    if (iHi-iLo-1)>0 then
    begin
         Mid:=((iLo+iHi) div 2);
         pivot:=A[Mid*FFieldSize+sortFieldIndex];
         if pivot<looking_for then result:=QuickFindIndex(A,looking_for,Mid,iHi,sortFieldIndex)
         else result:=QuickFindIndex(A,looking_for,iLo,Mid,sortFieldIndex);
    end
    else if looking_for>A[iLo*FFieldSize] then result:=iHi
    else result:=iLo;
end;

procedure InitLearnHashtable;
var
   i,row_offset,field_offset: integer;
   temp_spells: array of integer;
   pspell,plearnSpell: PPackedSpellRecord;
   SpellsQuickSortFind: TQuickSortFind;
const
     temp_spells_field_count: integer = 5;
     learnEffect1: integer = 36;
     learnEffect2: integer = 57;
     learnAttr: integer = $40100;
begin
     if Spell2Learn = nil then Spell2Learn:=TIntegerIntValueHashtable.Create(0);
     setlength(temp_spells,SpellDbcHandler.RowCount*temp_spells_field_count); //spell id, attr[0], effectName, learn, name offset
     row_offset:=0;
     SpellDbcHandler.ResetIterator;
     while true do
     begin
          pspell:=PPackedSpellRecord(SpellDbcHandler.GetNextIteratorPointerPRValue);
          if pspell=nil then break;
          field_offset:=0;
          temp_spells[row_offset+field_offset]:=pspell^.ID;
          inc(field_offset);
          temp_spells[row_offset+field_offset]:=pspell^.mechanic_attr[0];
          inc(field_offset);
          temp_spells[row_offset+field_offset]:=pspell^.SpellEffectNames[0];
          inc(field_offset);
          temp_spells[row_offset+field_offset]:=pspell^.link_to_spell;
          inc(field_offset);
          temp_spells[row_offset+field_offset]:=pspell^.Name[0];
          inc(row_offset,temp_spells_field_count);
     end;
     SpellsQuickSortFind:=TQuickSortFind.Create(temp_spells_field_count);
     SpellsQuickSortFind.QuickSortIndex(temp_spells,0,pred(SpellDbcHandler.RowCount),0);
     for i:=0 to pred(SpellDbcHandler.RowCount) do
     begin
          row_offset:=i*temp_spells_field_count;
          if (temp_spells[row_offset+3] > 0)and(temp_spells[row_offset+1] = learnAttr)and((temp_spells[row_offset+2] = learnEffect1)or(temp_spells[row_offset+2] = learnEffect2)) then  //learn > 0 and attr[0]=$40100
          begin
               if Spell2Learn.Contains(temp_spells[row_offset]) then //CheckNames
               begin
                    pspell:=SpellDbcHandler.GetPointerPRValueByIntKey(temp_spells[row_offset]); //ID
                    plearnSpell:=SpellDbcHandler.GetPointerPRValueByIntKey(temp_spells[row_offset+3]); //ID
                    if (pspell <> nil)and(plearnSpell <> nil) then
                       if SpellDbcHandler.GetStringByOffset(pspell^.ID) <> SpellDbcHandler.GetStringByOffset(plearnSpell^.ID) then
                          Spell2Learn.Remove(temp_spells[row_offset]);
               end;
               try
                  Spell2Learn.Add(temp_spells[row_offset+3],temp_spells[row_offset]);
               except;
               end;
          end
     end;
end;

{ TSpellLearnClassTemplate }

constructor TSpellLearnClassTemplate.Create(maxlvl,bRace,bClass: integer;
  craftskill1,craftskill2,craftskill3: integer);
var
   last_offset: integer;
procedure AddSpellsByCraftskill(cs: integer);
var
   i,row_offset,field_offset,learnSpell: integer;
   promSpellByLevelArray: array of integer;
   psab: PPackedSkillLineAbRecord;
   pspell: PPackedSpellRecord;
   SpellsQuickSortFind: TQuickSortFind;
begin
     if craftskill1 > 0 then
     begin
          SkillLineAbilityDbcHandler.ResetIterator;
          setlength(promSpellByLevelArray,SkillLineAbilityDbcHandler.RowCount*temp_spells_field_count);
          row_offset:=0;
          while true do
          begin
               psab:=PPackedSkillLineAbRecord(SkillLineAbilityDbcHandler.GetNextIteratorPointerPRValue);
               if psab = nil then break;
               if psab^.craftskill <> cs then Continue;  //craftskills[i]
               if (psab^.races <> 0)and((psab^.races and bRace) = 0) then continue;
               if (psab^.classes <> 0)and((psab^.classes and bClass) = 0) then continue;
               pspell:=PPackedSpellRecord(SpellDbcHandler.GetPointerPRValueByIntKey(psab^.spell));
               if pspell = nil then exit;
               if (pspell^.baseLevel = 0) then continue; //talents, fix later
               learnSpell:=Spell2Learn[psab^.spell];
               if learnSpell <= 0 then continue;
               field_offset:=0;
               promSpellByLevelArray[row_offset+field_offset]:=learnSpell;
               inc(field_offset);
               promSpellByLevelArray[row_offset+field_offset]:=pspell^.baseLevel;
               inc(field_offset);
               for i:=0 to 3 do //reqSkill,minSkill,reqSpell,spellCost 0 still
               begin
                    promSpellByLevelArray[row_offset+field_offset]:=0;
                    inc(field_offset);
               end;
               inc(row_offset,temp_spells_field_count);
               inc(spellCount);
          end;
          setlength(promSpellByLevelArray,row_offset);
          SpellsQuickSortFind:=TQuickSortFind.Create(temp_spells_field_count);
          SpellsQuickSortFind.QuickSortIndex(promSpellByLevelArray,0,pred(row_offset div temp_spells_field_count),1);
          setlength(learnTemplate,spellCount*temp_spells_field_count);
          move(promSpellByLevelArray[0],learnTemplate[last_offset],(spellCount*temp_spells_field_count) shl 2);
          last_offset:=length(learnTemplate);
     end;
end;
begin
     spellCount:=0;last_offset:=0;
     AddSpellsByCraftskill(craftskill1);
     AddSpellsByCraftskill(craftskill2);
     AddSpellsByCraftskill(craftskill3);
end;

end.
