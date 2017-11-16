unit SpellPublic;

interface

uses SpellConst;

type
  TAura = class
    public
      { general information }
      suid            : integer;

      spellEntry      : Pointer;
      eff_id          : longword;

      { service info }
      slot            : longword;
      isPositive      : boolean;
      isCancellable   : boolean;

      { variable parameters }
      duration        : longword;
      finishTime      : longword;
      charges         : longword;

      { procedures and functions }
      constructor     Create(baseSpell : Pointer; auraEffectID : longword);

      { statics }
      function  GetPositiveness(auraEffectID : longword) : boolean;
  end;

implementation

constructor TAura.Create(baseSpell : Pointer; auraEffectID : longword);
begin
  spellEntry := baseSpell;
  isPositive := GetPositiveness(auraEffectID);
end;

function TAura.GetPositiveness(auraEffectID : longword) : boolean;
begin
  case auraEffectID of
    SPELL_AURA_PERIODIC_DAMAGE
      : Result := false;
    else Result := true;
  end;
end;

end.
