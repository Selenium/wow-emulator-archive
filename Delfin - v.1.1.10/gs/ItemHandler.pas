unit ItemHandler;

interface

uses Windows, SysUtils, WorldObject;

type
  TItemStat = packed record
    statType: integer;
    statValue: integer;
  end;
  TItemDmg = packed record
    DmgMin: single;
    DmgMax: single;
    DmgType: integer;
  end;
  TItemSpell = packed record
    SpellId                        : integer; //71
    SpellTrigger                   : integer; //72
    SpellCharges                   : integer; //73
    SpellCooldown                  : integer; //74
    SpellCategory                  : integer; //75
    SpellCategoryCool              : integer; //76
  end;

  TPackedItemRecord = packed record   //string field is offsets
     item_id                          : integer; //0
     item_Class                       : integer; //1
     item_SubClass                    : integer; //2
     Name_Inv                         : integer; //3
     Name_Quest                       : integer; //4
     Name_Unk1                        : integer; //5
     Name_Unk2                        : integer; //6
     Model                            : integer; //7
     Quality                          : integer; //8
     Flags                            : integer; //9
     BuyPrice                         : integer; //10
     SellPrice                        : integer; //11
     InventoryType                    : integer; //12
     AllowableClass                   : integer; //13
     AllowableRace                    : integer; //14
     ItemLevel                        : integer; //15
     RequiredLevel                    : integer; //16
     RequiredSkill                    : integer; //17
     RequiredSkillRank                : integer; //18
     RequiredSpell                    : integer; //19
     RequiredFaction                  : integer; //20
     RequiredFactionLevel             : integer; //21
     RequiredPVPRank_0                : integer; //22
     RequiredPVPRank_1                : integer; //23
     UniqueFlag                       : integer; //24
     MaxCount                         : integer; //25
     ContainerSlots                   : integer; //26
     ItemStats                        : array[0..9]of TItemStat;
     ItemDmgs                         : array[0..4]of TItemDmg;
     Resists                          : array[0..6]of integer;
     Delay                            : integer; //69
     AmmoType                         : integer; //70
     unk71                            : integer; //71
     ItemSpells                       : array[0..4]of TItemSpell;
     Bonding                          : integer; //101
     Description                      : integer; //102
     PageTextID                       : integer; //103
     PageLanguage                     : integer; //104
     PageMaterial                     : integer; //105
     StartQuest                       : integer; //106
     LockId                           : integer; //107
     LockMaterial                     : integer; //108
     Sheath                           : integer; //109
     Unk3                             : integer; //110
     Block                            : integer; //111
     ItemSet                          : integer; //112
     MaxDurability                    : integer; //113
     Unk6                             : integer; //114
  end;
  PPackedItemRecord = ^TPackedItemRecord;
  TContainerItems = record
    itemID: integer;
    itemGUID: int64;
  end;
  TItem = class(TWorldObject)
  private
    {}
  public
    durability,random_prop,item_count: integer;
    PItemRecord: PPackedItemRecord;
    ownerGuid: int64;
    containerItems: array of TContainerItems;
    constructor Create(owner_guid: int64; item_id: integer);
  end;

  TInventoryChangeFailure = (
	  EQUIP_ERR_OK = 0,
	  EQUIP_ERR_YOU_MUST_REACH_LEVEL_N,
	  EQUIP_ERR_SKILL_ISNT_HIGH_ENOUGH,
	  EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT,
	  EQUIP_ERR_BAG_FULL,
	  EQUIP_ERR_NONEMPTY_BAG_OVER_OTHER_BAG,
	  EQUIP_ERR_ONLY_AMMO_CAN_GO_HERE,
	  EQUIP_ERR_NO_REQUIRED_PROFICIENCY,
	  EQUIP_ERR_NO_EQUIPMENT_SLOT_AVAILABLE,
	  EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM,
	  EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM2,
	  EQUIP_ERR_NO_EQUIPMENT_SLOTS_IS_AVAILABLE,
	  EQUIP_ERR_CANT_EQUIP_WITH_TWOHANDED,
	  EQUIP_ERR_CANT_DUAL_WIELD_YET,
	  EQUIP_ERR_ITEM_DOESNT_GO_INTO_BAG,
	  EQUIP_ERR_ITEM_DOESNT_GO_INTO_BAG2,
	  EQUIP_ERR_CANT_CARRY_MORE_OF_THIS,
	  EQUIP_ERR_NO_EQUIPMENT_SLOT_AVAILABLE2,
	  EQUIP_ERR_ITEM_CANT_STACK,
	  EQUIP_ERR_ITEM_CANT_BE_EQUIPPED,
	  EQUIP_ERR_ITEMS_CANT_BE_SWAPPED,
	  EQUIP_ERR_SLOT_IS_EMPTY,
	  EQUIP_ERR_ITEM_NOT_FOUND,
	  EQUIP_ERR_CANT_DROP_SOULBOUND,
	  EQUIP_ERR_OUT_OF_RANGE,
	  EQUIP_ERR_TRIED_TO_SPLIT_MORE_THAN_COUNT,
	  EQUIP_ERR_COULDNT_SPLIT_ITEMS,
	  EQUIP_ERR_BAG_FULL2,
	  EQUIP_ERR_NOT_ENOUGH_MONEY,
	  EQUIP_ERR_NOT_A_BAG,
	  EQUIP_ERR_CAN_ONLY_DO_WITH_EMPTY_BAGS,
	  EQUIP_ERR_DONT_OWN_THAT_ITEM,
	  EQUIP_ERR_CAN_EQUIP_ONLY1_QUIVER,
	  EQUIP_ERR_MUST_PURCHASE_THAT_BAG_SLOT,
	  EQUIP_ERR_TOO_FAR_AWAY_FROM_BANK,
	  EQUIP_ERR_ITEM_LOCKED,
	  EQUIP_ERR_YOU_ARE_STUNNED,
	  EQUIP_ERR_YOU_ARE_DEAD,
	  EQUIP_ERR_CANT_DO_RIGHT_NOW,
	  EQUIP_ERR_BAG_FULL3,
	  EQUIP_ERR_CAN_EQUIP_ONLY1_QUIVER2,
	  EQUIP_ERR_CAN_EQUIP_ONLY1_AMMOPOUCH,
	  EQUIP_ERR_STACKABLE_CANT_BE_WRAPPED,
	  EQUIP_ERR_EQUIPPED_CANT_BE_WRAPPED,
	  EQUIP_ERR_WRAPPED_CANT_BE_WRAPPED,
	  EQUIP_ERR_BOUND_CANT_BE_WRAPPED,
	  EQUIP_ERR_UNIQUE_CANT_BE_WRAPPED,
	  EQUIP_ERR_BAGS_CANT_BE_WRAPPED,
	  EQUIP_ERR_ALREADY_LOOTED,
	  EQUIP_ERR_INVENTORY_FULL,
	  EQUIP_ERR_BANK_FULL,
	  EQUIP_ERR_ITEM_IS_CURRENTLY_SOLD_OUT,
	  EQUIP_ERR_BAG_FULL4,
	  EQUIP_ERR_ITEM_NOT_FOUND2,
	  EQUIP_ERR_ITEM_CANT_STACK2,
	  EQUIP_ERR_BAG_FULL5,
	  EQUIP_ERR_ITEM_SOLD_OUT,
	  EQUIP_ERR_OBJECT_IS_BUSY,
	  EQUIP_ERR_NONE,					// DOES NOT EXIST
	  EQUIP_ERR_CANT_DO_IN_COMBAT,
	  EQUIP_CANT_DO_WHILE_DISARMED,
	  EQUIP_ERR_NONE2,				// DOES NOT EXIST
	  EQUIP_ITEM_RANK_NOT_ENOUGH,
	  EQUIP_ITEM_REPUTATION_NOT_ENOUGH
  );

const
  EQUIPMENT_SLOT_NONE        = 255;
	EQUIPMENT_SLOT_HEAD        = 0;
	EQUIPMENT_SLOT_NECK        = 1;
	EQUIPMENT_SLOT_SHOULDERS   = 2;
	EQUIPMENT_SLOT_BODY        = 3;
	EQUIPMENT_SLOT_CHEST       = 4;
	EQUIPMENT_SLOT_WAIST       = 5;
	EQUIPMENT_SLOT_LEGS        = 6;
	EQUIPMENT_SLOT_FEET        = 7;
	EQUIPMENT_SLOT_WRISTS      = 8;
	EQUIPMENT_SLOT_HANDS       = 9;
	EQUIPMENT_SLOT_FINGER1     = 10;
	EQUIPMENT_SLOT_FINGER2     = 11;
	EQUIPMENT_SLOT_TRINKET1    = 12;
	EQUIPMENT_SLOT_TRINKET2    = 13;
	EQUIPMENT_SLOT_BACK        = 14;
	EQUIPMENT_SLOT_MAINHAND    = 15;
	EQUIPMENT_SLOT_OFFHAND     = 16;
	EQUIPMENT_SLOT_RANGED      = 17;
	EQUIPMENT_SLOT_TABARD      = 18;

  INVENTORY_SLOT_BAG_START    = 19;
  INVENTORY_SLOT_BAG_1        = 19;
  INVENTORY_SLOT_BAG_2        = 20;
  INVENTORY_SLOT_BAG_3        = 21;
  INVENTORY_SLOT_BAG_4        = 22;
  INVENTORY_SLOT_BAG_END      = 23;
                                  
  INVENTORY_SLOT_ITEM_START   = 23;
  INVENTORY_SLOT_ITEM_1       = 23;
  INVENTORY_SLOT_ITEM_2       = 24;
  INVENTORY_SLOT_ITEM_3       = 25;
  INVENTORY_SLOT_ITEM_4       = 26;
  INVENTORY_SLOT_ITEM_5       = 27;
  INVENTORY_SLOT_ITEM_6       = 28;
  INVENTORY_SLOT_ITEM_7       = 29;
  INVENTORY_SLOT_ITEM_8       = 30;
  INVENTORY_SLOT_ITEM_9       = 31;
  INVENTORY_SLOT_ITEM_10      = 32;
  INVENTORY_SLOT_ITEM_11      = 33;
  INVENTORY_SLOT_ITEM_12      = 34;
  INVENTORY_SLOT_ITEM_13      = 35;
  INVENTORY_SLOT_ITEM_14      = 36;
  INVENTORY_SLOT_ITEM_15      = 37;
  INVENTORY_SLOT_ITEM_16      = 38;
  INVENTORY_SLOT_ITEM_END     = 39;

  BANK_SLOT_ITEM_START        = 39;
  BANK_SLOT_ITEM_1            = 39;
  BANK_SLOT_ITEM_2            = 40;
  BANK_SLOT_ITEM_3            = 41;
  BANK_SLOT_ITEM_4            = 42;
  BANK_SLOT_ITEM_5            = 43;
  BANK_SLOT_ITEM_6            = 44;
  BANK_SLOT_ITEM_7            = 45;
  BANK_SLOT_ITEM_8            = 46;
  BANK_SLOT_ITEM_9            = 47;
  BANK_SLOT_ITEM_10           = 48;
  BANK_SLOT_ITEM_11           = 49;
  BANK_SLOT_ITEM_12           = 50;
  BANK_SLOT_ITEM_13           = 51;
  BANK_SLOT_ITEM_14           = 52;
  BANK_SLOT_ITEM_15           = 53;
  BANK_SLOT_ITEM_16           = 54;
  BANK_SLOT_ITEM_17           = 55;
  BANK_SLOT_ITEM_18           = 56;
  BANK_SLOT_ITEM_19           = 57;
  BANK_SLOT_ITEM_20           = 58;
  BANK_SLOT_ITEM_21           = 59;
  BANK_SLOT_ITEM_22           = 60;
  BANK_SLOT_ITEM_23           = 61;
  BANK_SLOT_ITEM_24           = 62;
  BANK_SLOT_ITEM_END          = 63;

  BANK_SLOT_BAG_START         = 63;
  BANK_SLOT_BAG_1             = 63;
  BANK_SLOT_BAG_2             = 64;
  BANK_SLOT_BAG_3             = 65;
  BANK_SLOT_BAG_4             = 66;
  BANK_SLOT_BAG_5             = 67;
  BANK_SLOT_BAG_6             = 68;
  BANK_SLOT_BAG_END           = 69;
	SLOT_CHARACTER              = 255;

  INVTYPE_NON_EQUIP      = 0;
  INVTYPE_HEAD           = 1;
  INVTYPE_NECK           = 2;
  INVTYPE_SHOULDERS      = 3;
  INVTYPE_BODY           = 4;	// cloth robes only
  INVTYPE_CHEST          = 5;
  INVTYPE_WAIST          = 6;
  INVTYPE_LEGS           = 7;
  INVTYPE_FEET           = 8;
  INVTYPE_WRISTS         = 9;
  INVTYPE_HANDS          = 10;
  INVTYPE_FINGER         = 11;
  INVTYPE_TRINKET        = 12;
  INVTYPE_WEAPON         = 13;
  INVTYPE_SHIELD         = 14;
  INVTYPE_RANGED         = 15;
  INVTYPE_CLOAK          = 16;
  INVTYPE_TWOHAND_WEAPON = 17;
  INVTYPE_BAG            = 18;
  INVTYPE_TABARD         = 19;
  INVTYPE_ROBE           = 20;
  INVTYPE_WEAPONMAINHAND = 21;
  INVTYPE_WEAPONOFFHAND  = 22;
  INVTYPE_HOLDABLE       = 23;
  INVTYPE_AMMO           = 24;
  INVTYPE_THROWN         = 25;
  INVTYPE_RANGEDRIGHT    = 26;

  inventory_type2equip_slot: array[0..26] of byte = (
                      EQUIPMENT_SLOT_NONE,            // 0
                      EQUIPMENT_SLOT_HEAD,            // 1
                      EQUIPMENT_SLOT_NECK,            // 2
                      EQUIPMENT_SLOT_SHOULDERS,       // 3
                      EQUIPMENT_SLOT_BODY,            // 4
                      EQUIPMENT_SLOT_CHEST,           // 5
                      EQUIPMENT_SLOT_WAIST,           // 6
                      EQUIPMENT_SLOT_LEGS,            // 7
                      EQUIPMENT_SLOT_FEET,            // 8
                      EQUIPMENT_SLOT_WRISTS,          // 9
                      EQUIPMENT_SLOT_HANDS,           // 10
                      EQUIPMENT_SLOT_FINGER1,         // 11
                      EQUIPMENT_SLOT_TRINKET1,        // 12
                      EQUIPMENT_SLOT_MAINHAND,        // 13
                      EQUIPMENT_SLOT_OFFHAND,         // 14
                      EQUIPMENT_SLOT_RANGED,          // 15
                      EQUIPMENT_SLOT_BACK,            // 16
                      EQUIPMENT_SLOT_MAINHAND,        // 17
                      INVENTORY_SLOT_BAG_START,       // 18
                      EQUIPMENT_SLOT_TABARD,          // 19
                      EQUIPMENT_SLOT_CHEST,           // 20
                      EQUIPMENT_SLOT_MAINHAND,        // 21
                      EQUIPMENT_SLOT_OFFHAND,         // 22
                      EQUIPMENT_SLOT_OFFHAND,         // 23
                      EQUIPMENT_SLOT_RANGED,          // 24
                      EQUIPMENT_SLOT_RANGED,          // 25,EQUIPMENT_SLOT_MAINHAND only combat mode
                      EQUIPMENT_SLOT_RANGED);         // 26

  equip_slot2inventory_type: array[-1..18] of shortint = (
                      INVTYPE_NON_EQUIP,
                      INVTYPE_HEAD,                   //  0
                      INVTYPE_NECK,                   //  1
                      INVTYPE_SHOULDERS,              //  2
                      INVTYPE_BODY,                   //  3
                      INVTYPE_CHEST,                  //  4
                      INVTYPE_WAIST,                  //  5
                      INVTYPE_LEGS,                   //  6
                      INVTYPE_FEET,                   //  7
                      INVTYPE_WRISTS,                 //  8
                      INVTYPE_HANDS,                  //  9
                      INVTYPE_FINGER,                 //  10
                      INVTYPE_FINGER,                 //  11
                      INVTYPE_TRINKET,                //  12
                      INVTYPE_TRINKET,                //  13
                      INVTYPE_CLOAK,                  //  14
                      INVTYPE_WEAPONMAINHAND,         //  15
                      INVTYPE_WEAPONOFFHAND,          //  16
                      INVTYPE_RANGEDRIGHT,            //  17
                      INVTYPE_TABARD);                //  18

implementation

uses UpdateConst,ByteArrayHandler,UnitMain,OpConst;   

constructor TItem.Create(owner_guid: int64; item_id: integer);
const
     single1: single = 1.0;
begin
     ID:=item_id;
     objGUID:=GetItemsUniqGUID;
     updateBitsChanged:=false;
     positionX:=0; positionY:=0; positionZ:=0; positionR:=0;
     WalkSpeed:=SPEED_WALK;
     RunSpeed:=SPEED_RUN;
     BackwardSpeed:=SPEED_WALKBACK;
     SweemSpeed:=SPEED_TURN;
     SweemBackSpeed:=SPEED_SWIMBACK;
     TurnRate:=SPEED_TURN;
     ownerGuid:=owner_guid;
     item_count:=1;

     PItemRecord:=ItemsDbcHandler.GetPointerPRValueByIntKey(ID);
     if PItemRecord<>nil then
     begin
          //durability and random props from char values or on new item
          if PItemRecord^.InventoryType = INVTYPE_BAG then
          begin
               objType:=TYPEID_CONTAINER;
               setlength(containerItems,PItemRecord^.ContainerSlots);
               setlength(UpdateArray,integer(CONTAINER_END) shl 2);
               setlength(UpdateBitsArray,(integer(CONTAINER_END) shr 5)+1);
               SetUpdateBits(self,integer(TYPE_CONTAINER or TYPE_OBJECT),integer(OBJECT_FIELD_TYPE));
               SetUpdateBits(self,PItemRecord^.ContainerSlots,CONTAINER_FIELD_NUM_SLOTS);
          end
          else begin
               objType:=TYPEID_ITEM;
               setlength(UpdateArray,integer(ITEM_END) shl 2);
               setlength(UpdateBitsArray,(integer(ITEM_END) shr 5)+1);
               SetUpdateBits(self,integer(TYPE_ITEM or TYPE_OBJECT),integer(OBJECT_FIELD_TYPE));
          end;
          SetUpdateBits(self,objGUID,integer(OBJECT_FIELD_GUID));  //??
          SetUpdateBits(self,ID,integer(OBJECT_FIELD_ENTRY));
          SetUpdateBits(self,single1,integer(OBJECT_FIELD_SCALE_X));
          SetUpdateBits(self,ownerGuid,integer(ITEM_FIELD_OWNER));      //player guid
          SetUpdateBits(self,ownerGuid,integer(ITEM_FIELD_CONTAINED));  //player guid
          SetUpdateBits(self,PItemRecord^.MaxDurability,integer(ITEM_FIELD_MAXDURABILITY));
          SetUpdateBits(self,PItemRecord^.MaxDurability,integer(ITEM_FIELD_DURABILITY));
          SetUpdateBits(self,item_count,integer(ITEM_FIELD_STACK_COUNT));
          SetUpdateBits(self,PItemRecord^.ItemSpells[0].SpellCharges,integer(ITEM_FIELD_SPELL_CHARGES));
          SetUpdateBits(self,PItemRecord^.Flags,integer(ITEM_FIELD_FLAGS));
          SetUpdateBits(self,integer(0),integer(ITEM_FIELD_RANDOM_PROPERTIES_ID));
     end
     else AddToLog('Item '+IntToStr(item_id)+' not exist in Items.dbc');
end;

end.
