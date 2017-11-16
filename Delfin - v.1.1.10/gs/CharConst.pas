unit CharConst;

interface

type
    TNCharRace = (
        crnHuman    =1,
        crnOrc      =2,
        crnDwarf    =3,
        crnNightElf =4,
        crnUndead   =5,
        crnTauren   =6,
        crnGnome    =7,
        crnTroll    =8,
        crnGoblin   =9);

    TNCharClass = (
        ccnWarrior  =1,
        ccnPaladin  =2,
        ccnHunter   =3,
        ccnRogue    =4,
        ccnPriest   =5,
        ccnShaman   =7,
        ccnMage     =8,
        ccnWarlock  =9,
        ccnDruid    =11);

const
  AgilityBonus             = 3;
  StrengthBonus            = 4;
  IntellectBonus           = 5;
  SpiritBonus              = 6;
  StaminaBonus             = 7;

  DmgTypePhysical          = 0;
  DmgTypeHoly              = 1;
  DmgTypeFire              = 2;
  DmgTypeNature            = 3;
  DmgTypeFrost             = 4;
  DmgTypeShadow            = 5;
  DmgTypeArcane            = 6;

  ResistTypePhysical       = 0;
  ResistTypeHoly           = 1;
  ResistTypeFire           = 2;
  ResistTypeNature         = 3;
  ResistTypeFrost          = 4;
  ResistTypeShadow         = 5;
  ResistTypeArcane         = 6;

  itemAgilityBonus         = 3;
  itemStrengthBonus        = 4;
  itemIntellectBonus       = 5;
  itemSpiritBonus          = 6;
  itemStaminaBonus         = 7;

  charStrengthBonus        = 0;
  charAgilityBonus         = 1;
  charStaminaBonus         = 2;
  charIntellectBonus       = 3;
  charSpiritBonus          = 4;

  itemBonus2charBonus_type: array[3..7]of integer = (1,0,3,4,2);

  EDAMAGE_EXHAUSTED = 0;
  EDAMAGE_DROWNING  = 1;
  EDAMAGE_FALL      = 2;
  EDAMAGE_LAVA      = 3;
  EDAMAGE_SLIME     = 4;
  EDAMAGE_FIRE      = 5;

  DEATH_STATE_ALIVE = byte(0);
  DEATH_STATE_GHOST = byte(1);
  DEATH_STATE_DEAD  = byte(2);

  POWER_TYPE_MANA   = longword(0);
  POWER_TYPE_RAGE   = longword(1);
  POWER_TYPE_FOCUS  = longword(2);
  POWER_TYPE_ENERGY = longword(3);

implementation

end.
 