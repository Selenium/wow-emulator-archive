unit DbcFieldsConst;

interface

uses
    Windows;

type
    TPackedSpawnRecord = packed record
      WorldSpawn_ID                            : integer; //0
      WorldSpawn_TYPE                          : integer; //1
      WorldSpawn_FLAGS                         : integer; //2
      WorldSpawn_ENTRY                         : integer; //3
      WorldSpawn_MODEL                         : integer; //4
      WorldSpawn_MAP                           : integer; //5
      WorldSpawn_X                             : single;  //6
      WorldSpawn_Y                             : single;  //7
      WorldSpawn_Z                             : single;  //8
      WorldSpawn_R                             : single;  //9
      WorldSpawn_MAXHEALTH                     : integer; //10
      WorldSpawn_SIZE                          : single;  //11
      WorldSpawn_FACTION                       : integer; //12
      WorldSpawn_SPAWNTIME                     : integer; //13
      WorldSpawn_SPAWNDIST                     : single;  //14
      WorldSpawn_SPAWN                         : integer; //15
      WorldSpawn_DAMAGE                        : integer; //16
      WorldSpawn_DELAY                         : integer; //17
      WorldSpawn_SPEED                         : single;  //18
      WorldSpawn_RADIUS                        : single;  //19
      WorldSpawn_LINK                          : integer; //20
      WorldSpawn_LEVEL                         : integer; //21
      WorldSpawn_REACH                         : single;  //22
      WorldSpawn_EQUIP                         : integer; //23 string
      WorldSpawn_CTYPE                         : integer; //24
      WorldSpawn_NPCFLAGS                      : integer; //25
      WorldSpawn_SPAWN_GOBJ                    : integer; //26
      WorldSpawn_rX                            : single;  //27
      WorldSpawn_rY                            : single;  //28
      WorldSpawn_rZ                            : single;  //29
      WorldSpawn_rR                            : single;  //30
      WorldSpawn_GTYPE                         : integer; //31
    end;
    PPackedSpawnRecord = ^TPackedSpawnRecord;

    TPackedCreatureRecord = packed record
      id                                       : integer; //0
      name                                     : integer; //1 string
      model                                    : integer; //2
      level                                    : integer; //3
      faction                                  : integer; //4
      family                                   : integer; //5
      npcflags                                 : integer; //6
      maxhealth                                : integer; //7
      maxmana                                  : integer; //8
      cType                                    : integer; //9
      elite                                    : integer; //10
      guild                                    : integer; //11 string
      damage                                   : integer; //12
      attack                                   : integer; //13
      speed                                    : single; //14
      size                                     : single; //15
      flags1                                   : integer; //16
      selltemplate                             : integer; //17
      traintemplate                            : integer; //18
      loottemplate                             : integer; //19
      bounding_radius                          : single; //20
      combat_reach                             : single; //21
      npctextID                                : integer; //22
      money                                    : integer; //23
      equipmodel                               : integer; //24 string
    end;
    PPackedCreatureRecord = ^TPackedCreatureRecord;

    TPackedSellTemplateRecord = packed record
      id                                       : integer; //0
      sell                                     : integer; //2 string
    end;
    PPackedSellTemplateRecord = ^TPackedSellTemplateRecord;

    TPackedGameObjectRecord = packed record
      id                                       : integer; //0
      Model                                    : integer; //1
      goType                                     : integer; //2
      Names                                    : array[0..3]of integer; //3-6
      SoundEffects                             : array[0..11]of integer; //7-18
    end;
    PPackedGameObjectRecord = ^TPackedGameObjectRecord;

    TPackedSpellRecord = packed record
      ID                                       : integer; //0
      school                                   : integer; //1
      category                                 : integer; //2
      unk_3                                    : integer; //3
      SpellDispell                             : integer; //4 - SpellDispellTypeID.dbc
      SpellMechanic                            : integer; //5 - SpellMechanicID.dbc
      mechanic_attr                            : array[0..4]of integer; //6-10
      targets                                  : integer; //11
      TargetCreatureType                       : integer; //12
      RequiresSpellFocus                       : integer; //13 SpellFocusObject.dbc
      CasterAuraState                          : integer; //14
      TargetAuraState                          : integer; //15
      CastingTimeIndex                         : integer; //16
      RecoveryTime                             : integer; //17
      CategoryRecoveryTime                     : integer; //18
      InterruptFlags                           : integer; //19
      AuraInterruptFlags                       : integer; //20
      ChannelInterruptFlags                    : integer; //21
      procFlags                                : integer; //22
      procChance                               : integer; //23 $h
      procCharges                              : integer; //24 $n
      maxLevel                                 : integer; //25
      baseLevel                                : integer; //26
      spellLevel                               : integer; //27
      duration                                 : integer; //28[id number for SpellDuration.dbc]  $d
      powerType                                : integer; //29
      manacost_energy                          : integer; //30
      manaCostPerlevel                         : integer; //31
      manaPerSecond                            : integer; //32
      manaPerSecondPerLevel                    : integer; //33
      rangeIndex                               : integer; //34 SpellRange.dbc
      speed                                    : single; //35
      modalNextSpell                           : integer; //36
      stackable                                : integer; //37
      tool                                     : integer; //38
      tool_prof                                : integer; //39
      Reagents                                 : array[0..7]of integer; //40
      ReagentsCount                            : array[0..7]of integer; //48
      EquippedItemClass                        : integer; //56
      EquippedItemSubClass                     : integer; //57
      SpellEffectNames                         : array[0..2]of integer; //58 SpellEffectNames.dbc
      EffectDieSides                           : array[0..2]of integer; //61
      EffectBaseDice                           : array[0..2]of integer; //64
      EffectDicePerLevel                       : array[0..2]of integer; //67
      EffectRealPointsPerLevel                 : array[0..2]of single; //70
      EffectBasePoints                         : array[0..2]of integer; //73    $s1
      unk_76                                   : integer; //76
      unk_77                                   : integer; //77
      unk_78                                   : integer; //78
      EffectImplicitTargetA                    : array[0..2]of integer; //79
      EffectImplicitTargetB                    : array[0..2]of integer; //82
      EffectRadiusIndex                        : array[0..2]of integer; //85 - spellradius.dbc
      EffectApplyAuraName                      : array[0..2]of integer; //88
      EffectAmplitude                          : array[0..2]of integer; //91
      Effectunknown                            : array[0..2]of single; //94 $e1-$e3 коэффициент преобразовани€ жизнь/мана мана/дамадж и т.п.
      EffectChainTarget                        : array[0..2]of integer; //97
      EffectItemType                           : array[0..2]of integer; //100
      EffectMiscValue                          : array[0..2]of integer; //103 зависит от значени€ в $M1-$M3
      link_to_spell                            : integer; //106  (train->learn) зависит от значени€ в $M1-$M3
      casting_spell                            : integer; //107  зависит от значени€ в $M1-$M3
      EffectTriggerSpell_3                     : integer; //108  зависит от значени€ в $M1-$M3
      EffectPointsPerComboPoint                : array[0..2]of single; //109
      SpellVisual                              : integer; //112
      unk_110                                  : integer; //113
      iconID                                   : integer; //114
      activeIconID                             : integer; //115
      spellPriority                            : integer; //116
      Name                                     : array[0..7]of integer; //117
      NameFlags                                : integer; //125
      Rank                                     : array[0..7]of integer; //126
      RankFlags                                : integer; //134
      Description                              : array[0..7]of integer; //135
      DescriptionFlags                         : integer; //143
      BuffDescription                          : array[0..7]of integer; //144
      BuffDescriptionFlags                     : integer; //152
      ManaCostPercentage                       : integer; //153
      StartRecoveryCategory                    : integer; //154
      StartRecoveryTime                        : integer; //155
      unk_156                                  : integer; //156
      SpellFamilyName                          : integer; //157 Class - ссылка на Field 15 в ChrClasses.dbc
      SpellFamilyNameClassFlags                : integer; //158
      SpellCharCount                           : integer; //159 $i -  оличество чаров, одновременно огребающих спелл
      unk_160                                  : integer; //160
      unk_161                                  : integer; //161
      unk_162                                  : integer; //162
      EnlargeCoeff                             : array[0..2]of single; //163
      unk_166                                  : integer; //166
    end;
    PPackedSpellRecord = ^TPackedSpellRecord;

    TPackedSkillLineAbRecord = packed record
      id                                       : integer; //0
      craftskill                               : integer; //1
      spell                                    : integer; //2
      races                                    : integer; //3
      classes                                  : integer; //4
      unk_5                                    : integer; //5
      unk_6                                    : integer; //6
      unk_7                                    : integer; //7
      nextskill                                : integer; //8
      unk_9                                    : integer; //9
      unk_10                                   : integer; //10
      unk_11                                   : integer; //11
      unk_12                                   : integer; //12
      unk_13                                   : integer; //13
      unk_14                                   : integer; //14
    end;
    PPackedSkillLineAbRecord = ^TPackedSkillLineAbRecord;

    TPackedSkillTierRecord = packed record
      id                                       : integer; //0
      skill1                                   : array[0..15]of integer;
      skill2                                   : array[0..15]of integer;
    end;
    PPackedSkillTierRecord = ^TPackedSkillTierRecord;

    TPackedAccountRecord = packed record
      id                                       : integer; //0;
      Account                                  : integer; //1;
      Password                                 : integer; //2;
      Gm                                       : integer; //3;
      Banned                                   : integer; //4;
      Chars                                    : integer; //5;
    end;
    PPackedAccountRecord = ^TPackedAccountRecord;

    TPackedPlayerCharsRecord = packed record
      id                                       : integer; //0;
      Name                                     : integer; //1;
      positionX                                : single; //2;
      positionY                                : single; //3;
      positionZ                                : single; //4;
      positionR                                : single; //5;
      mapID_zoneID                             : integer; //6;
      Flags                                    : integer; //7;
      atInn_AFK_DND_inFly                      : integer; //8;
      lastLogout                               : double; //9;
      BindingPointX                            : single; //11;
      BindingPointY                            : single; //12;
      BindingPointZ                            : single; //13;
      BindingPointR                            : single; //14;
      BindingPointMapID_ZoneID                 : integer; 
      pgcr                                     : integer; 
      level                                    : integer; 
      xp                                       : integer; 
      rest_xp                                  : integer; 
      rest_state_f_hair                        : integer; 
      HairFaceSkin                             : integer; 
      copper                                   : integer; 
      guild_ID                                 : integer; 
      CurrHealth                               : integer; 
      CurrRMEnergy                             : integer; 
      Items                                    : integer; 
      ActiveQuests                             : integer; 
      DoneQuests                               : integer; 
      Spells                                   : integer; 
      Skills                                   : integer; 
      ExploredZones                            : integer; 
      Buttons                                  : integer;
      GUID                                     : integer;
      Tutorials                                : integer;
      Auras                                    : integer;
      Reputation                               : integer;
      Talents                                  : integer;
      Honor                                    : integer;
      TaxiMask                                 : integer; //string
      FriendList                               : integer; //string
      IgnoreList                               : integer; //string
      Ammo                                     : integer;
    end;
    PPackedPlayerCharsRecord = ^TPackedPlayerCharsRecord;

    TPackedPageTxtRecord = packed record
      ID                                       : integer; //0;
      NextPage                                 : integer; //1;
      PageText                                 : integer; //2;
    end;
    PPackedPageTxtRecord = ^TPackedPageTxtRecord;

    TPackedClassRaseStartInfoRecord = packed record
      ID                                       : integer; //0;
      class_race                               : integer; //1;
      mapID                                    : integer; //2;
      zoneID                                   : integer; //3;
      posX                                     : single; //4;
      posY                                     : single; //5;
      posZ                                     : single; //6;
      posR                                     : single; //7;
      sizePerLevel                             : single; //8;
      baseStrength                             : integer; //9;
      baseAgility                              : integer; //10;
      baseStamina                              : integer; //11;
      baseIntellect                            : integer; //12;
      baseSpirit                               : integer; //13;
      StrengthPerLevel                         : single; //14;
      AgilityPerLevel                          : single; //15;
      StaminaPerLevel                          : single; //16;
      IntellectPerLevel                        : single; //17;
      SpiritPerLevel                           : single; //18;
      baseHealth                               : integer; //19;
      baseManaRageEnergy                       : integer; //20;
      descr                                    : integer; //21;
      skills                                   : integer; //22;
      spells                                   : integer; //23;
      ManaRageEnergyKind                       : integer; //24;
    end;
    PPackedClassRaseStartInfoRecord = ^TPackedClassRaseStartInfoRecord;

    TPackedCharRacesRecord = packed record
      ID                                       : integer; //0;
      unk0                                     : integer; //1;
      faction_template                         : integer; //2;
      unk1                                     : integer; //3;
      model                                    : array[0..1]of integer; //4-5, male/female;
      unk_array                                : array[6..15]of integer; //6-15;
      movie                                    : integer; //16;
    end;
    PPackedCharRacesRecord = ^TPackedCharRacesRecord;

    TPackedFactionTemplateRecord = packed record
      id                                       : integer; //0;
      faction                                  : integer; //1;
      unk0                                     : integer; //2;
      fightsupport                             : integer; //3;
      friendly                                 : integer; //4;
      hostile                                  : integer; //5;
      link                                     : array[0..7]of integer; //6;
    end;
    PPackedFactionTemplateRecord = ^TPackedFactionTemplateRecord;

    TPackedCharStartOutfitRecord = packed record
      id                                       : integer; //0;
      male_shl_16_Class_shl_8_race             : integer; //1;
      item                                     : array[0..11]of integer; //2-13;
      inventory_type                           : array[0..11]of integer;
      item_count                               : array[0..11]of integer;
    end;
    PPackedCharStartOutfitRecord = ^TPackedCharStartOutfitRecord;

    TPackedActionBarStartInfo = packed record
      class_race                               : integer; //0;
      MainActionBar                            : array[0..11]of integer; //1-12;
    end;
    PPackedActionBarStartInfo = ^TPackedActionBarStartInfo;

    TPackedActionBar = packed record
      id                                   : integer; //0;
      ActionBar                            : array[0..119]of integer; //1-12;
    end;
    PPackedActionBar = ^TPackedActionBar;

    TPackedMail = packed record
      mail_id                              : integer; 
      sender                               : integer;
      reciever                             : integer;
      subject                              : integer; //string
      body                                 : integer; //string
      item                                 : integer;
      item_count                           : integer;
      time                                 : single;
      money                                : integer;
      COD                                  : integer;
      checked                              : integer;
    end;
    PPackedMail = ^TPackedMail;

    TPackedEmotesText = packed record
      Id                                   : integer;
      textid                               : integer;
    end;
    PPackedEmotesText = ^TPackedEmotesText;

    TPackedAreaTable = packed record
      ID                                   : integer;
      zone                                 : integer;
      exploreFlag                          : integer;
      area_level                           : integer;
    end;
    PPackedAreaTable = ^TPackedAreaTable;

    TPackedRestTrigger = packed record
      TriggerID                            : integer;
    end;
    PPackedRestTrigger = ^TPackedRestTrigger;

    TPackedAreaTrigger = packed record
      TriggerID                            : integer;
      MapID                                : integer;
      PositionX                            : single;
      PositionY                            : single;
      PositionZ                            : single;
    end;
    PPackedAreaTrigger = ^TPackedAreaTrigger;

    TPackedTalent = packed record
      TalentID                             : integer;
      TalentTree                           : integer;
      unk1                                 : integer;
      unk2                                 : integer;
      RankID                               : array[0..4] of integer;
    end;
    PPackedTalent = ^TPackedTalent;

    TPackedTaxiNodes = packed record
      ID                                   : integer;
      MapID                                : integer;
      PositionX                            : single;
      PositionY                            : single;
      PositionZ                            : single;
      Mount                                : integer;
    end;
    PPackedTaxiNodes = ^TPackedTaxiNodes;

    TPackedTaxiPath = packed record
      ID                                   : integer;
      Node_src                             : integer;
      Node_dst                             : integer;
      Price                                : integer;
    end;
    PPackedTaxiPath = ^TPackedTaxiPath;

    TPackedWorldSafeLocs = packed record
      ID                                   : integer;
      MapID                                : integer;
      PositionX                            : single;
      PositionY                            : single;
      PositionZ                            : single;
    end;
    PPackedWorldSafeLocs = ^TPackedWorldSafeLocs;    

    TPackedSpellCastTimeRecord = packed record
      id                                       : integer; //0
      castTime                                 : integer; //1
      unk_1                                    : integer; //2
      unk_castTime                             : integer; //3
    end;
    PPackedSpellCastTime = ^TPackedSpellCastTimeRecord;

    TPackedSpellRaduisRecord = packed record
      id                                       : integer; //0
      radius                                   : single; //1
      unk_1                                    : integer; //2
      radius_dupe                              : single; //3
    end;
    PPackedSpellRaduisRecord = ^TPackedSpellRaduisRecord;     

    TPackedSpellDurationRecord = packed record
      id                                       : integer; //0
      duration                                 : integer; //1
      unk_1                                    : integer; //2
      duration_dupe                            : integer; //3
    end;
    PPackedSpellDurationRecord = ^TPackedSpellDurationRecord;

    TPackedBankBagSlotPricesRecord = packed record
      BankSlot                              : integer; //0
      Price                                 : integer; //1
    end;
    PPackedBankBagSlotPricesRecord = ^TPackedBankBagSlotPricesRecord;    

implementation

end.
