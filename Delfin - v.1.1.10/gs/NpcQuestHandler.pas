unit NpcQuestHandler;

interface

uses Windows, AcedContainers, CharHandler;

const
    DIALOG_STATUS_NONE           = 0;
    DIALOG_STATUS_UNAVAILABLE    = 1;
    DIALOG_STATUS_CHAT           = 2;
    DIALOG_STATUS_INCOMPLETE     = 3;
    DIALOG_STATUS_REWARD_REP     = 4;
    DIALOG_STATUS_AVAILABLE      = 5;
    DIALOG_STATUS_REWARD         = 6;

    QUEST_STATUS_NONE            = 0;
 	  QUEST_STATUS_COMPLETE        = 1;
 	  QUEST_STATUS_UNAVAILABLE     = 2;
 	  QUEST_STATUS_INCOMPLETE      = 3;
 	  QUEST_STATUS_AVAILABLE       = 4;

    SUBMENU_TAXI                 = 1;
    SUBMENU_VENDOR               = 2;
    SUBMENU_TRAINER              = 3;
    SUBMENU_BANKER               = 4;
    SUBMENU_INKEEPER_BIND        = 5;
    SUBMENU_INKEEPER_MSG         = 6;
    SUBMENU_TABARD               = 7;
    SUBMENU_PETITION             = 8;

 		MENUICON_GOSSIP              = $00;
		MENUICON_VENDOR              = $01;
		MENUICON_TAXI                = $02;
		MENUICON_TRAINER             = $03;
		MENUICON_HEALER              = $04;
		MENUICON_BINDER              = $05;
		MENUICON_BANKER              = $06;
		MENUICON_PETITION            = $07;
		MENUICON_TABARD              = $08;
		MENUICON_BATTLEMASTER        = $09;
		MENUICON_AUCTIONER           = $0A;
		MENUICON_GOSSIP2             = $0B;
		MENUICON_GOSSIP3             = $0C;

		NPC_KIND_SPIRITHEALER        = 1;
		NPC_KIND_DIALOG              = 2;
		NPC_KIND_VENDOR              = 4;
		NPC_KIND_TAXI                = 8;
    NPC_KIND_TRAINER             = $10;
    NPC_KIND_HEALER              = $20;
    NPC_KIND_BF_SPIRITHEALER     = $40;
		NPC_KIND_INKEEPER            = $80;
		NPC_KIND_BANKER              = $100;
		NPC_KIND_PETITION            = $200;
		NPC_KIND_TABARD              = $400;
		NPC_KIND_BATTLEMASTER        = $800;
		NPC_KIND_AUCTIONER           = $1000;
		NPC_KIND_STABLEMASTER        = $2000;

type
  TQuestFaction = packed record
    Faction                        : integer; //5
    FactionMinReq                  : integer; //6
  end;
  TQuestRewardItem = packed record
    Item                           : integer;
    Amount                         : integer;
  end;
  TQuestNpcObj = packed record
    Item                           : integer;
    Amount                         : integer;
    Deliver                        : integer;
    DeliverAmount                  : integer;
  end;

  TPackedQuestRecord = packed record   //string field is offsets
    id                                    : integer; //0
    RequiresLevel                         : integer; //1
    QuestLevel                            : integer; //2
    Category                              : integer; //3
    Complexity                            : integer; //4
    factions                              : array[0..1]of TQuestFaction; //5-8
    NextStoryQuest                        : integer; //9
    OpenedByQuest                         : integer; //10
    MoneyReward                           : integer; //11
    LearnSpell                            : integer; //12
    ReceiveItem                           : integer; //13
    DescriptiveFlags                      : integer; //14
    rewards                               : array[0..3]of TQuestRewardItem; //15-22
    reward_choices                        : array[0..5]of TQuestRewardItem; //23-34
    ma                                    : integer; //35
    mx                                    : integer; //36
    my                                    : integer; //37
    mz                                    : integer; //38
    Name                                  : integer; //39
    Objectives                            : integer; //40
    Details                               : integer; //41
    EndText                               : integer; //42
    IncompleteText                        : integer; //43
    CompleteText                          : integer; //44
    NpcObjectives                         : array[0..3]of TQuestNpcObj; //45-60
    QuestGiver_NPC                        : integer; //61
    QuestGiver_ITM                        : integer; //62
    QuestGiver_OBJ                        : integer; //63
    QuestFinisher_NPC                     : integer; //64
    QuestFinisher_ITM                     : integer; //65
    QuestFinisher_OBJ                     : integer; //66
    ObjectivesArray                       : array[0..3]of integer; //67-70
    RequiresRace                          : integer; //71
    RequiresClass                         : integer; //72
    RequiresTradeSkill                    : integer; //73
    QuestBehavior                         : integer; //74
  end;
  PPackedQuestRecord = ^TPackedQuestRecord;

  TPackedEmotionRecord = packed record
    Emote_Probability                      : integer; //1
    Emote_Text0                            : integer; //2
    Emote_Text1                            : integer; //3
    Emote_Language                         : integer; //4
    Emote_Emote_Delay0                     : integer; //5
    Emote_Emote_Emote0                     : integer; //6
    Emote_Emote_Delay1                     : integer; //7
    Emote_Emote_Emote1                     : integer; //8
    Emote_Emote_Delay2                     : integer; //9
    Emote_Emote_Emote2                     : integer; //10
  end;

  TPackedNpcTextRecord = packed record   //string field is offsets
    NpcText_id                               : integer; //0
    NpcText_Emotes                           : array[0..7]of TPackedEmotionRecord;
  end;
  PPackedNpcTextRecord = ^TPackedNpcTextRecord;

  TActiveQuest = class
  public
    idx: integer;
    questID                                : integer;
    objectives                             : array[0..3]of TQuestNpcObj;
    //constructor Create;
  end;

  function MatchQuestID(Item1, Item2: Pointer): Integer;
  procedure InitQuests;
  function QuestAble(Sender: TCharacter; questID: integer; out QuestLevel: integer):boolean;
  function QuestDone(Sender: TCharacter; questID: integer):boolean;

var
   UnitStartQuestsHT,ItemStartQuestsHT,ObjectStartQuestsHT,
     UnitFinishQuestsHT,ObjectFinishQuestsHT: TIntegerHashtable;
    
implementation

uses UnitMain, DbcHandler;

{constructor TActiveQuest.Create;
begin
     fillchar(objectives,sizeof(objectives),0);
end;}

function MatchQuestID(Item1, Item2: Pointer): Integer;
var
  S1, S2: TActiveQuest;
begin
  S1 := TActiveQuest(Item1);
  S2 := TActiveQuest(Item2);
  Result := 0;
  if (S1 <> nil) and (S2 <> nil) then
  begin
    if S1.questID <> S2.questID then
    begin
         if S1.questID < S2.questID then result := -1
         else result:=1;
    end;
  end
  else if S1 <> nil then
    Result := -1
  else if S2 <> nil then
    Result := 1;
end;

procedure InitQuests;
var
   i: integer;
   pquest: PPackedQuestRecord;
procedure AddQuest(HT: TIntegerHashtable; key: integer);
var
   itemArr,tempArr: TIntegerList;
begin
     if not(HT.Contains(key)) then
     begin
          tempArr:=TIntegerList.Create(0);
          HT.Add(key,tempArr);
     end;
     itemArr:=TIntegerList(HT.Items[key]);
     try //if already contains
        itemArr.Add(pquest^.id);
     except;
     end;
end;
begin
     UnitStartQuestsHT:=TIntegerHashtable.Create(0);
     ItemStartQuestsHT:=TIntegerHashtable.Create(0);
     ObjectStartQuestsHT:=TIntegerHashtable.Create(0);
     UnitFinishQuestsHT:=TIntegerHashtable.Create(0);
     ObjectFinishQuestsHT:=TIntegerHashtable.Create(0);
     for i:=0 to QuestsDbcHandler.MaxID do
     begin
          pquest:=QuestsDbcHandler.GetPointerPRValueByIntKey(i);
          if (pquest<>nil) then
          begin
               if pquest^.QuestGiver_NPC > 0 then AddQuest(UnitStartQuestsHT,pquest^.QuestGiver_NPC)
               else if pquest^.QuestGiver_ITM > 0 then AddQuest(ItemStartQuestsHT,pquest^.QuestGiver_ITM)
               else if pquest^.QuestGiver_OBJ > 0 then  AddQuest(ObjectStartQuestsHT,pquest^.QuestGiver_OBJ);

               if pquest^.QuestFinisher_NPC > 0 then AddQuest(UnitFinishQuestsHT,pquest^.QuestFinisher_NPC)
               else if pquest^.QuestFinisher_OBJ > 0 then  AddQuest(ObjectFinishQuestsHT,pquest^.QuestFinisher_OBJ);
          end;
     end;
end;

function QuestAble(Sender: TCharacter; questID: integer; out QuestLevel: integer):boolean;
var
   pquest: PPackedQuestRecord;
   quest: TActiveQuest;
begin
     result:=false;
     pquest:=QuestsDbcHandler.GetPointerPRValueByIntKey(questID);
     if pquest<>nil then
     begin
          QuestLevel:=pquest^.QuestLevel;
          quest:=TActiveQuest.Create;
          quest.questID:=questID;
          if (pquest^.RequiresLevel <= Sender.Level)and((pquest^.RequiresRace and Sender.bRace)<>0)
             and((pquest^.RequiresClass and Sender.bClass)<>0)
             and (Sender.DoneQuests.IndexOf(questID) < 0)
             and (Sender.ActiveQuests.IndexOf(quest,MatchQuestID,false) < 0)
             and (((pquest^.OpenedByQuest > 0)and(Sender.DoneQuests.IndexOf(pquest^.OpenedByQuest) >= 0))or(pquest^.OpenedByQuest = 0))
             then //and ((skill<>0)and (have required skill))and((faction<>0 and reputation)
                  result:=true;
     end;
end;

function ObjectivesDone(Sender: TCharacter; questID: integer):boolean;
var
   i,questIndex: integer;
   pquest: PPackedQuestRecord;
   quest: TActiveQuest;
begin
     result:=true;
     pquest:=QuestsDbcHandler.GetPointerPRValueByIntKey(questID);
     if pquest<>nil then
     begin
          quest:=TActiveQuest.Create;
          quest.questID:=questID;
          questIndex:=Sender.ActiveQuests.IndexOf(quest,MatchQuestID,false);
          if (questIndex < 0)or(questIndex >= 20) then
          begin
               result:=false;
               exit;
          end;
          quest:=Sender.ActiveQuests.ItemList[questIndex];
          //check objectives
          for i:=0 to 3 do
              if (pquest^.NpcObjectives[i].Item > 0) then
              begin
                   if pquest^.NpcObjectives[i].Amount > quest.objectives[i].Amount then
                   begin
                        result:=false;
                        exit;
                   end;
              end;
          //check delivery
          for i:=0 to 3 do
              if (pquest^.NpcObjectives[i].Deliver > 0) then
              begin
                   if pquest^.NpcObjectives[i].DeliverAmount > quest.objectives[i].DeliverAmount then
                   begin
                        result:=false;
                        exit;
                   end;
              end;
     end
     else result:=false;
end;

function QuestDone(Sender: TCharacter; questID: integer):boolean;
var
   pquest: PPackedQuestRecord;
   quest: TActiveQuest;
begin
     result:=false;
     pquest:=QuestsDbcHandler.GetPointerPRValueByIntKey(questID);
     if pquest<>nil then
     begin
          quest:=TActiveQuest.Create;
          quest.questID:=questID;
          //check objectives and is active
          if (Sender.ActiveQuests.IndexOf(quest,MatchQuestID,false) >= 0)
             and ObjectivesDone(Sender,questID)
             //and DeliveryDone(Sender,questID) //check bags/equipment slots for items
             then result:=true;
     end;
end;

end.
