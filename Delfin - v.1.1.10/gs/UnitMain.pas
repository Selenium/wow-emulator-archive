unit UnitMain;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,
  Dialogs, WinSock, StdCtrls, ExtCtrls, OpConst, LbCipher, LbBigInt, IniFiles,
  LbClass, AcedContainers, ByteArrayHandler, DbcHandler, CellManager,
  SpellSystem, WeatherHandler;

const
  WM_AuthSocketEvent=WM_User+1;
  WM_WorldSocketEvent=WM_User+2;
  WM_RLSocketEvent=WM_User+3;  
  Th20arraySize=$20;
  Th20arrayEnd=$1F;
  T20arraySize=20;
  T20arrayEnd=19;

type
  AuthProcs = procedure(Sock: TSocket;const ByteBuff: array of byte; rec_len: integer);
  Th20array = array[0..Th20arrayEnd]of byte;
  T20array = array[0..T20arrayEnd]of byte;
  TForm1 = class(TForm)
    Panel1: TPanel;
    Panel3: TPanel;
    Label1: TLabel;
    Label2: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;      
    Memo1: TMemo;
    Button1: TButton;
    Button2: TButton;
    Timer1: TTimer;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
  private
    AuthSock,WorldSock: TSocket;
    procedure WMAuthSocketEventHandler(var Msg:TMessage);message WM_AuthSocketEvent;
    procedure WMWorldSocketEventHandler(var Msg:TMessage);message WM_WorldSocketEvent;
    procedure WMRLSocketEventHandler(var Msg:TMessage);message WM_RLSocketEvent;
    //procedure ReadFromAuthSocket(Sock:TSocket);
    procedure ReadFromRLSocket(Sock:TSocket);
  public
    { Public declarations }
  end;

function GetItemsUniqGUID: int64;
function GetUnitsUniqGUID: int64;
function GetCharsUniqGUID: int64;
function GetGoCorpseUniqGUID: int64;
function GetDynObjUniqGUID: int64;
  
procedure ConnectToLogin;
function ExtractFileNoExt(const FileName: string): String; //11.12.04
procedure AddToLog(LogString: string);
procedure SaveAll;
procedure SaveUsedDbcs;

var
  Form1: TForm1;
  player_count: integer;
  AuthPlayersHT,LoggedPlayersHT,PlayerCharNamesHT,ChatChannelsHT: TStringHashtable;
  AuthPlayersAccBySockHT,LoggedPlayersAccBySockHT: TIntegerHashtable;
  PlayerCharsHT_byGUID,UnitHT_byGUID,GroupHT_byGUID,
  PlayerCharsNames_byGUID: TInt64Hashtable;  //,CorpseGoHT_byGUID,DynGoHT_byGUID
  AccDbcHandler,PlayerCharDbcHandler,CharStartOutfitDbcHandler, ItemsDbcHandler,
     CharCRStartInfoDbcHandler,CharRacesDbcHandler,CharClassesDbcHandler,
     FactionDbcHandler,FactionTemplateDbcHandler,WorldDbcHandler,
     CreaturesDbcHandler,GameObjectsDbcHandler,PageTextDbcHandler,
     NpcTextDbcHandler,QuestsDbcHandler,SellTemplateDbcHandler,
     ActionBarStartInfoDbcHandler, ActionBarDbcHandler, MailDbcHandler,
     AreaTableDbcHandler, EmotesTextDbcHandler, AreaTriggerDbcHandler,
     RestTriggerDbcHandler, TalentDbcHandler, SpellDbcHandler,
     TaxiNodesHandler, TaxiPathHandler, SkillLineAbilityDbcHandler,
     SkillTiersDbcHandler, SkillRaceClassInfoDbcHandler,
     WorldSafeLocsDbcHandler,
     BankBagSlotPricesDbcHandler,
     //spells
     SpellCastTimesDbcHandler,
{     SpellCategoryDbcHandler,
     SpellChainEffectsDbcHandler,
     SpellDispelTypeDbcHandler,
     }SpellDurationDbcHandler,{
     SpellEffectCameraShakesDbcHandler,
     SpellFocusObjectDbcHandler,
     SpellIconDbcHandler,
     SpellItemEnchantmentDbcHandler,
     SpellMechanicDbcHandler,}
     SpellRadiusDbcHandler{,
     SpellRangeDbcHandler,
     SpellShapeshiftDbcFormHandler,
     SpellVisualDbcHandler,
     SpellVisualEffectNameDbcHandler,
     SpellVisualKitDbcHandler   }
     //end spels

         : TDbcHandler;

  SS : TSpellSystem;
  WM: TWeatherManager ;
  
  ExeName, AppPath, SavesDbcPath, BasesDbcPath, BasesClientDbcPath, LogsPath: string;
  MapCell: TMapCell;
  ItemsUniqueGUID,UnitsUniqueGUID,CharsUniqueGUID,GoCorpseUniqueGUID,DynObjUniqueGUID: int64;
  Sock: TSocket;
  ServerVersion: String;
  StartTime: TDateTime ;
   
  //Настройки
  LogonServerAddr,LogonServerPort,RealmName,RealmAddr,RealmPort: string;
  LogoutTime, SaveTime: dword; //Время ожидания логаута
  ShowMovie: Boolean;  //Показывать ли мувики?
  ShowTutorial: Boolean;  //Показывать ли подсказки?
  LogonEnable: Boolean;  //Включить встроенный логин сервер
  LogLevel: Byte; //Степень детальности логов  3-все 2-опкоды 1-успехи/ошибки 0-нет
  motd: String; //Message of the day
  AllGM: Boolean; // если True тогда все игроки - ГМы
  CheckSpawns: Boolean; //Проверять спауны при запуске
  
  //системы
  SystemAuction,
  SystemExploration,
  SystemMail: Boolean ;

implementation

uses
  OpcodeHandler,DbcFieldsConst,CharHandler,WorldObject,NpcQuestHandler,
  SpellHandler, CharConst, ChatHandler, SaveThread, LoginHandler;

{$R *.dfm}

function GetItemsUniqGUID: int64;
begin
     inc(ItemsUniqueGUID);
     result:=ItemsUniqueGUID;
end;
function GetUnitsUniqGUID: int64;
begin
     inc(UnitsUniqueGUID);
     result:=UnitsUniqueGUID;
end;
function GetCharsUniqGUID: int64;
begin
     inc(CharsUniqueGUID);
     result:=CharsUniqueGUID;
end;
function GetGoCorpseUniqGUID: int64;
begin
     inc(GoCorpseUniqueGUID);
     result:=GoCorpseUniqueGUID;
end;
function GetDynObjUniqGUID: int64;
begin
     inc(DynObjUniqueGUID);
     result:=DynObjUniqueGUID;
end;

function ExtractFileNoExt(const FileName: string): String; //11.12.04
begin
  Result := Copy(FileName, 1, Length(FileName) -
     Length(ExtractFileExt(FileName)));
end;

function GetServerVersion: String;
{ Helper function to get the actual file version information }
var
  Info: Pointer;
  InfoSize: DWORD;
  FileInfo: PVSFixedFileInfo;
  FileInfoSize: DWORD;
  Tmp: DWORD;
  Major1, Major2, Minor1, Minor2: Integer;
begin
  // Get the size of the FileVersionInformatioin
  InfoSize := GetFileVersionInfoSize(PChar(ExeName), Tmp);
  // If InfoSize = 0, then the file may not exist, or
  // it may not have file version information in it.
  if InfoSize = 0 then
    raise Exception.Create('Can''t get file version information for '+ eXEnAME);
  // Allocate memory for the file version information
  GetMem(Info, InfoSize);
  try
    // Get the information
    GetFileVersionInfo(PChar(ExeName), 0, InfoSize, Info);
    // Query the information for the version
    VerQueryValue(Info, '\', Pointer(FileInfo), FileInfoSize);
    // Now fill in the version information
    Major1 := FileInfo.dwFileVersionMS shr 16;
    Major2 := FileInfo.dwFileVersionMS and $FFFF;
    Minor1 := FileInfo.dwFileVersionLS shr 16;
    Minor2 := FileInfo.dwFileVersionLS and $FFFF;

    Result := IntToStr(Major1)+'.'+IntToStr(Major2)+'.'+IntToStr(Minor1)+'.'+IntToStr(Minor2);
  finally
    FreeMem(Info, FileInfoSize);
  end;
end;

procedure AddToLog(LogString: string); //changed by Aven 28.03.2006
var
  FormatLogString: String;
  LogFile: Textfile;
begin
  if LogLevel = 0 then Exit;
  FormatLogString := '['+TimeToStr(Now)+'] ' + LogString;
  Form1.Memo1.Lines.Add(FormatLogString);
  try
     if LowerCase(Copy(LogString, 1, 3)) = '!!!' then
       AssignFile(LogFile, LogsPath + 'erorr.log')
     else
       AssignFile(LogFile, LogsPath + 'system.log');
     {$I-}
     Append(LogFile);
     {$I+}
     if IOResult<>0 then Rewrite(LogFile);
     {$I-}
     writeln(LogFile, FormatLogString);
     {$I+}
     if IOResult<>0 then;
     Flush(LogFile);
     CloseFile(LogFile);
   except;
   end;
end;

procedure SaveAll;
var
  i: Integer;
  Player: TPlayer;
  time: DWORD;
begin
  AddToLog('Saving World...');
  BroadcastSystemMessage('Saving World...');
  time := GetTickCount ;
  for i := 0 to LoggedPlayersHT.InnerCapacity - 1 do
    if LoggedPlayersHT.InnerKeyList[i] <> '' then begin
      Player := LoggedPlayersHT[LoggedPlayersHT.InnerKeyList[i]];
      SaveCharToDBC(Player);
    end;
  SaveUsedDbcs;    
  time := GetTickCount - time;
  BroadcastSystemMessage('World saved [' + IntToStr(time) + ' msec]');
  AddToLog('World saved [' + IntToStr(time) + ' msec]');
end;

procedure SaveUsedDbcs;
begin
  //on save later
  //set changes here or where changed
  PlayerCharDbcHandler.SaveDbc;
  AccDbcHandler.SaveDbc;
  ActionBarDbcHandler.SaveDbc ;
  MailDbcHandler.SaveDbc ;
//  WorldDbcHandler.SaveDbc ;
end;

procedure AddAccount(name, password, chars: String; gm, banned: Byte);
var
  acc_dbc: TPackedAccountRecord ;
begin
  acc_dbc.Account := AccDbcHandler.AddString(name);
  acc_dbc.Password := AccDbcHandler.AddString(password);
  acc_dbc.Gm := gm;
  acc_dbc.Banned := banned;
  acc_dbc.Chars := AccDbcHandler.AddString(chars);
  AccDbcHandler.AddRecord(@acc_dbc);
end;

//Соединяемся с логин сервером
procedure ConnectToLogin;
var
  sin: TSockAddrIn;
  iaddr, err: Integer;
  Block:u_long;
begin
  sock:=socket(AF_INET,SOCK_STREAM, IPPROTO_IP);
  sin.sin_family := AF_INET;
  sin.sin_port := htons(StrToInt(LogonServerPort));
  iaddr:=inet_addr(PChar(LogonServerAddr));
  sin.sin_addr.S_addr:=iaddr;
//Соединение
  err := connect(sock,sin,sizeof(sin));
  if err <> 0 then Exit;
  WSAAsyncSelect(sock, Form1.Handle, WM_RLSocketEvent,FD_Read or FD_Accept or FD_Close);
  Block:=0;
  IOCtlSocket(sock,FIONBIO,Block);
  AddToLog('*** Connected to LoginServ: ' +LogonServerAddr+':'+LogonServerPort);
end;

procedure ReadConfig;
var
  SettingsIni: TIniFile;
  fn: String ;
begin
  try
    fn := AppPath+'config\gameserver.conf' ;
    if not FileExists(fn) then AddToLog('!!! Config not found!');
    
    SettingsIni:=TIniFile.Create(fn);
    LogonEnable:=Boolean(SettingsIni.ReadInteger('LogonServer','LogonEnable',1));
    LogonServerAddr:=SettingsIni.ReadString('LogonServer','LogonServerAddr','127.0.0.1');
    LogonServerPort:=SettingsIni.ReadString('LogonServer','LogonServerPort','7273');
    RealmName:=SettingsIni.ReadString('Realm','RealmName','Home test Server');
    RealmAddr:=SettingsIni.ReadString('Realm','RealmAddr','127.0.0.1:8085');
    RealmPort:=SettingsIni.ReadString('Realm','RealmPort','8085');
    ShowMovie:=Boolean(SettingsIni.ReadInteger('Common','ShowMovie', 1));
    ShowTutorial:=Boolean(SettingsIni.ReadInteger('Common','ShowTutorial', 1));
    LogoutTime:=SettingsIni.ReadInteger('Common','LogoutTime', 20);
    LogLevel:=SettingsIni.ReadInteger('Common','LogLevel',2);
    motd := SettingsIni.ReadString('Common','motd','');
    AllGM := Boolean(SettingsIni.ReadInteger('Common','AllGM', 0));
    SaveTime := SettingsIni.ReadInteger('Common','SaveTime', 60);
    CheckSpawns := Boolean(SettingsIni.ReadInteger('Common','CheckSpawns', 1));

    //системы
    SystemAuction := Boolean(SettingsIni.ReadInteger('System','Auction', 1));
    SystemExploration := Boolean(SettingsIni.ReadInteger('System','Exploration', 0));
    SystemMail := Boolean(SettingsIni.ReadInteger('System','Mail', 1));

    SettingsIni.Free;
  except  
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
var
   Data:TWSAData;
   Addr:TSockAddr;
   i,j,jj,key: integer;
   prom_char_name: string;
   pspawn: PPackedSpawnRecord;
   spawn: TSpawnCellObject;
   player_chars: PPackedPlayerCharsRecord;
   Block:u_long;
begin
   LogLevel := 2;

   ItemsUniqueGUID:=$4000000000000000;
   UnitsUniqueGUID:=$F000100000000000;
   CharsUniqueGUID:=0;
   GoCorpseUniqueGUID:=$F000700000000000;
   DynObjUniqueGUID:=$F000A00000000000;

   player_count:=0;
   Randomize;

   ExeName := Application.ExeName;
   AppPath := ExtractFilePath(ExeName);

   SavesDbcPath := AppPath + 'saves\';
   BasesDbcPath := AppPath + 'bases\';
   LogsPath := AppPath + 'logs\';
   BasesClientDbcPath := BasesDbcPath + 'client\';

   ServerVersion := 'Delfin v' + GetServerVersion ;
   Caption := ServerVersion; StartTime := Now ;
   AddToLog('Server started: ' + DateTimeToStr(StartTime));
   AddToLog('Server version: ' + ServerVersion);

   ReadConfig ;

   //Грузим клиентские dbc
   AddToLog('');
   AddToLog('*** Loading Clients dbc ...');

   AreaTableDbcHandler:=TDbcHandler.Create;
   AreaTableDbcHandler.LoadDbcArray(BasesClientDbcPath+'AreaTable.dbc',0,-1,ktIntArray);
   AddToLog('AreaTable loaded');

   AreaTriggerDbcHandler:=TDbcHandler.Create;
   AreaTriggerDbcHandler.LoadDbcArray(BasesClientDbcPath+'AreaTrigger.dbc',0,-1,ktIntArray);
   AddToLog('AreaTrigger loaded');

   BankBagSlotPricesDbcHandler:=TDbcHandler.Create;
   BankBagSlotPricesDbcHandler.LoadDbcArray(BasesClientDbcPath+'BankBagSlotPrices.dbc',0,-1,ktIntArray);
   AddToLog('BankBagSlotPrices loaded');

   EmotesTextDbcHandler:=TDbcHandler.Create;
   EmotesTextDbcHandler.LoadDbcArray(BasesClientDbcPath+'EmotesText.dbc',0,-1,ktIntArray);
   AddToLog('EmotesText loaded');

   FactionDbcHandler:=TDbcHandler.Create;
   FactionDbcHandler.LoadDbcArray(BasesClientDbcPath+'Faction.dbc',0,-1,ktIntArray);
   AddToLog('Faction loaded');

   FactionTemplateDbcHandler:=TDbcHandler.Create;
   FactionTemplateDbcHandler.LoadDbcArray(BasesClientDbcPath+'FactionTemplate.dbc',0,-1,ktIntArray);
   AddToLog('FactionTemplate loaded');   

   SpellDbcHandler:=TDbcHandler.Create;
   SpellDbcHandler.LoadDbcArray(BasesClientDbcPath+'Spell.dbc',0,-1,ktIntArray);
   AddToLog('Spell loaded');

   SpellRadiusDbcHandler:=TDbcHandler.Create;
   SpellRadiusDbcHandler.LoadDbcArray(BasesClientDbcPath+'SpellRadius.dbc',0,-1,ktIntArray);
   AddToLog('SpellRadius loaded');

   SpellCastTimesDbcHandler:=TDbcHandler.Create;
   SpellCastTimesDbcHandler.LoadDbcArray(BasesClientDbcPath+'SpellCastTimes.dbc',0,-1,ktIntArray);
   AddToLog('SpellCastTimes loaded');

   SpellDurationDbcHandler:=TDbcHandler.Create;
   SpellDurationDbcHandler.LoadDbcArray(BasesClientDbcPath+'SpellDuration.dbc',0,-1,ktIntArray);
   AddToLog('SpellDuration loaded');

   SkillLineAbilityDbcHandler:=TDbcHandler.Create;
   SkillLineAbilityDbcHandler.LoadDbcArray(BasesClientDbcPath+'SkillLineAbility.dbc',0,-1,ktIntArray);
   AddToLog('SkillLineAbility loaded');

   SkillRaceClassInfoDbcHandler:=TDbcHandler.Create;
   SkillRaceClassInfoDbcHandler.LoadDbcArray(BasesClientDbcPath+'SkillRaceClassInfo.dbc',0,-1,ktIntArray);
   AddToLog('SkillRaceClassInfo loaded');

   SkillTiersDbcHandler:=TDbcHandler.Create;
   SkillTiersDbcHandler.LoadDbcArray(BasesClientDbcPath+'SkillTiers.dbc',0,-1,ktIntArray);
   AddToLog('SkillTiers loaded');

   InitLearnHashtable;

   TalentDbcHandler:=TDbcHandler.Create;
   TalentDbcHandler.LoadDbcArray(BasesClientDbcPath+'Talent.dbc',0,-1,ktIntArray);
   AddToLog('Talent loaded');   

   TaxiNodesHandler:=TDbcHandler.Create;
   TaxiNodesHandler.LoadDbcArray(BasesClientDbcPath+'TaxiNodes.dbc',0,-1,ktIntArray);
   AddToLog('TaxiNodes loaded');

   TaxiPathHandler:=TDbcHandler.Create;
   TaxiPathHandler.LoadDbcArray(BasesClientDbcPath+'TaxiPath.dbc',0,-1,ktIntArray);
   AddToLog('TaxiPath loaded');

   WorldSafeLocsDbcHandler:=TDbcHandler.Create;
   WorldSafeLocsDbcHandler.LoadDbcArray(BasesClientDbcPath+'WorldSafeLocs.dbc',0,-1,ktIntArray);
   AddToLog('WorldSafeLocs loaded');

   //Грузим серверные dbc
   AddToLog('');
   AddToLog('*** Loading Server dbc ...');

   ActionBarStartInfoDbcHandler:=TDbcHandler.Create;
   ActionBarStartInfoDbcHandler.LoadDbcArray(BasesDbcPath+'ActionBarStartInfo.dbc',0,-1,ktIntArray);
   AddToLog('ActionBarStartInfo loaded');

   CharStartOutfitDbcHandler:=TDbcHandler.Create;
   CharStartOutfitDbcHandler.LoadDbcArray(BasesDbcPath+'CharStartOutfitMod.dbc',1,-1,ktIntHT);  //CharStartOutfit_male_shl_16_Class_shl_8_race
   AddToLog('CharStartOutfitMod loaded');

   CharCRStartInfoDbcHandler:=TDbcHandler.Create;
   CharCRStartInfoDbcHandler.LoadDbcArray(BasesDbcPath+'CharClassesRacesStartInfo.dbc',1,-1,ktIntHT);  //CharCRStartInfo_class_race
   AddToLog('CharClassesRacesStartInfo loaded');

   CharRacesDbcHandler:=TDbcHandler.Create;
   CharRacesDbcHandler.LoadDbcArray(BasesDbcPath+'ChrRaces.dbc',0,-1,ktIntArray);
   AddToLog('ChrRaces loaded');

   CharClassesDbcHandler:=TDbcHandler.Create;
   CharClassesDbcHandler.LoadDbcArray(BasesDbcPath+'ChrClasses.dbc',0,-1,ktIntArray);
   AddToLog('ChrClasses loaded');

   GameObjectsDbcHandler:=TDbcHandler.Create;
   GameObjectsDbcHandler.LoadDbcArray(BasesDbcPath+'gameobjects.dbc',0,-1,ktIntArray);
   AddToLog('GameObjects loaded, count='+ IntToStr(GameObjectsDbcHandler.RowCount));

   NpcTextDbcHandler:=TDbcHandler.Create;
   NpcTextDbcHandler.LoadDbcArray(BasesDbcPath+'npctexts.dbc',0,-1,ktIntArray);
   AddToLog('NpcText loaded');

   RestTriggerDbcHandler:=TDbcHandler.Create;
   RestTriggerDbcHandler.LoadDbcArray(BasesDbcPath+'RestTrigger.dbc',0,-1,ktIntArray);
   AddToLog('RestTrigger loaded');

   { be carefull with faked wowemu ID's like 999999999, next handlers use arrays and such arrays will be huge }

   PageTextDbcHandler:=TDbcHandler.Create;
   PageTextDbcHandler.LoadDbcArray(BasesDbcPath+'PageText.dbc',0,-1,ktIntArray);
   AddToLog('PageText loaded');

   QuestsDbcHandler:=TDbcHandler.Create;
   QuestsDbcHandler.LoadDbcArray(BasesDbcPath+'Quests.dbc',0,-1,ktIntArray);
   InitQuests;
   AddToLog('Quests loaded, count='+ IntToStr(QuestsDbcHandler.RowCount));

   ItemsDbcHandler:=TDbcHandler.Create;
   ItemsDbcHandler.LoadDbcArray(BasesDbcPath+'items.dbc',0,-1,ktIntArray);
   AddToLog('Items loaded, count='+ IntToStr(ItemsDbcHandler.RowCount));

   CreaturesDbcHandler:=TDbcHandler.Create;
   CreaturesDbcHandler.LoadDbcArray(BasesDbcPath+'Creatures.dbc',0,-1,ktIntArray);
   AddToLog('Creatures loaded, count='+ IntToStr(CreaturesDbcHandler.RowCount));

   SellTemplateDbcHandler:=TDbcHandler.Create;
   SellTemplateDbcHandler.LoadDbcArray(BasesDbcPath+'SellTemplate.dbc',0,-1,ktIntArray);
   AddToLog('SellTemplate loaded, count='+ IntToStr(SellTemplateDbcHandler.RowCount));

   WorldDbcHandler:=TDbcHandler.Create;
   WorldDbcHandler.LoadDbcArray(BasesDbcPath+'world.dbc',0,-1,ktIntHT);
   AddToLog('World loaded, count='+ IntToStr(WorldDbcHandler.RowCount));

   MapCell:= TMapCell.Create;

   j := 0;
   jj := 0;   
   for i:=0 to pred(WorldDbcHandler.DbcHT.InnerCapacity)do begin
     if (WorldDbcHandler.DbcHT.Items[WorldDbcHandler.DbcHT.InnerKeyList[i]]<>nil) then begin
       key:=WorldDbcHandler.DbcHT.InnerKeyList[i];
       pspawn:=WorldDbcHandler.GetPointerPRValueByIntKey(key);
       if CheckSpawns and (pspawn.WorldSpawn_SPAWN <> 0) and (CreaturesDbcHandler.GetPointerPRValueByIntKey(pspawn.WorldSpawn_SPAWN) = nil) then begin
         AddToLog('!!! MobID='+IntToStr(pspawn.WorldSpawn_SPAWN) + ' not found!');
         Inc(j);
         Continue;
       end;
       if CheckSpawns and (pspawn.WorldSpawn_SPAWN_GOBJ <> 0) and (GameObjectsDbcHandler.GetPointerPRValueByIntKey(pspawn.WorldSpawn_SPAWN_GOBJ) = nil) then begin
         AddToLog('!!! GoID='+IntToStr(pspawn.WorldSpawn_SPAWN_GOBJ) + ' not found!');
         Inc(jj);
         Continue;
       end;  
       if ((TObjectType(pspawn^.WorldSpawn_TYPE) = TYPEID_UNIT)and(pspawn^.WorldSpawn_SPAWN > 0)) //better through model 262 and spawn link, but wad use backward links and something wrong with world.save integrity %(
           or((TObjectType(pspawn^.WorldSpawn_TYPE) = TYPEID_GAMEOBJECT)and(pspawn^.WorldSpawn_MODEL > 0)) then begin //link 2 spawns TODO, now only objects directly
         spawn:=TSpawnCellObject.Create(pspawn^.WorldSpawn_ID,pspawn^.WorldSpawn_TYPE,pspawn^.WorldSpawn_X,pspawn^.WorldSpawn_Y,pspawn^.WorldSpawn_MAP);
         if (spawn.mapId<2) then //Kalimdor or Azeroth only now  (mob.mapId>=0)and
           MapCell.CreateSpawn(spawn);
       end;
     end;
   end;
   AddToLog('World spawns init, error mob:go='+IntToStr(j)+':'+IntToStr(jj));   

   //Грузим сейвы
   AddToLog('');
   AddToLog('*** Loading Saves dbc ...');

   AccDbcHandler:=TDbcHandler.Create;
   AccDbcHandler.LoadDbcArray(SavesDbcPath+'accounts.dbc',1,-1,ktStringHT);  //AccountPos
   AddToLog('Accounts loaded, count='+ IntToStr(AccDbcHandler.RowCount));

   ActionBarDbcHandler:=TDbcHandler.Create;
   ActionBarDbcHandler.LoadDbcArray(SavesDbcPath+'ActionBar.dbc',0,-1,ktIntArray);
   AddToLog('ActionBar loaded');

   MailDbcHandler:=TDbcHandler.Create;
   MailDbcHandler.LoadDbcArray(SavesDbcPath+'Mail.dbc',0,-1,ktIntArray);
   AddToLog('Mail loaded, count='+ IntToStr(MailDbcHandler.RowCount));   

   PlayerCharNamesHT:=TStringHashtable.Create(false,0);
   PlayerCharsNames_byGUID:=TInt64Hashtable.Create(0);

   PlayerCharDbcHandler:=TDbcHandler.Create;
   PlayerCharDbcHandler.LoadDbcArray(SavesDbcPath+'playerchars.dbc',0,-1,ktIntHT);

   Key := 0;
   //load all chars to HT here and find CharUniqueGUID
   for i:=1 to PlayerCharDbcHandler.MaxID do
   try
       player_chars := PlayerCharDbcHandler.GetPointerPRValueByIntKey(i);
       if player_chars <> nil then begin
         prom_char_name := PlayerCharDbcHandler.GetStringByOffset(player_chars^.Name);
         if prom_char_name <> '' then begin
           Inc(key);
           if player_chars^.Guid > CharsUniqueGUID then CharsUniqueGUID := player_chars^.Guid ;
           if player_chars^.Guid <> 0 then
             PlayerCharsNames_byGUID.Add(player_chars^.Guid, PChar(prom_char_name));
           PlayerCharNamesHT.Add(prom_char_name,nil);
         end;
       end;
   except;                
   end; 
   AddToLog('Chars loaded, count=' + IntToStr(Key));
   AddToLog('');

   //TODO: сделать проверку на существование чара на аккаунте

   AuthPlayersHT:=TStringHashtable.Create(false);
   LoggedPlayersHT:=TStringHashtable.Create(false);
   AuthPlayersAccBySockHT:=TIntegerHashtable.Create(0);
   LoggedPlayersAccBySockHT:=TIntegerHashtable.Create(0);
   GroupHT_byGUID := TInt64Hashtable.Create(0);
   ChatChannelsHT:=TStringHashtable.Create(false);
   PlayerCharsHT_byGUID:=TInt64Hashtable.Create(0);
   UnitHT_byGUID:=TInt64Hashtable.Create(0);
   //CorpseGoHT_byGUID:=TInt64Hashtable.Create(0);
   //DynGoHT_byGUID:=TInt64Hashtable.Create(0);

   WSAStartup($101,Data);
   // Обычная последовательность действий по созданию сокета,
   // привязке его к адресу и установлению на прослушивание
   if LogonEnable then begin
     AuthSock:=Socket(AF_Inet,Sock_stream,0);
     Addr.sin_family:=PF_Inet;
     Addr.sin_addr.S_addr:=Inet_addr(PChar(LogonServerAddr));
     Addr.sin_port:=HToNS(StrToInt(LogonServerPort));
     FillChar(Addr.sin_zero,SizeOf(Addr.sin_zero),0);
     Bind(AuthSock,Addr,SizeOf(Addr));
     Listen(AuthSock,SOMaxConn);
     WSAAsyncSelect(AuthSock,Handle, WM_AuthSocketEvent, FD_Read or FD_Accept or FD_Close);
     Block:=0;
     IOCtlSocket(AuthSock,FIONBIO,Block);
     AddToLog('*** LoginServ listen on port ' + LogonServerPort);
   end else //Конектимся к логинсерверу
     ConnectToLogin ;
   // Перевод сокета в асинхронный режим. Кроме события FD_Accept
   // указаны также события FD_Read и FD_Close, которые никогда не
   // возникают на сокете, установленном в режим прослушивания.
   // Это сделано потому, что сокеты, созданные с помощью функции
   // Accept, наследуют асинхронный режим, установленный для
   // слушающего сокета. Таким образом, не придётся вызывать
   // функцию WSAAsyncSelect для этих сокетов - для них сразу
   // будет назначен обработчик событий FD_Read и FD_Close.
   WorldSock:=Socket(AF_Inet,Sock_stream,0);
   Addr.sin_family:=PF_Inet;
   Addr.sin_addr.S_addr:=Inet_addr(PChar(RealmAddr));
   Addr.sin_port:=HToNS(StrToInt(RealmPort));
   FillChar(Addr.sin_zero,SizeOf(Addr.sin_zero),0);
   Bind(WorldSock,Addr,SizeOf(Addr));
   Listen(WorldSock,SOMaxConn);
   WSAAsyncSelect(WorldSock,Handle, WM_WorldSocketEvent,FD_Read or FD_Accept or FD_Close);
   Block:=0;
   IOCtlSocket(WorldSock,FIONBIO,Block);   
   AddToLog('*** RealmServ listen on port ' + RealmPort);

   SaveThread.TSaveThread.Create(False);

   SS := TSpellSystem.Create;
   SS.Init;

   WM := TWeatherManager.Create ;

   Timer1.Enabled := True ;

   AddToLog('ready'+#$d#$a);
   SendMessage(Memo1.Handle, EM_LINESCROLL, 0, Memo1.Lines.Count);
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  CloseSocket(AuthSock);
  CloseSocket(WorldSock);
  WSACleanup;
  if LoggedPlayersHT <> nil then SaveAll;
end;

procedure TForm1.ReadFromRLSocket(Sock:TSocket);
var
   cmd: byte;
   lmsg,lstr: string;
   received_len,i: integer;    //len,
   ByteBuff: array of byte;

   offs: Integer;
   acc_name: String;
   CurrPlayer: TPlayer;
begin
     setlength(ByteBuff,$4000);
     received_len:=Recv(Sock,ByteBuff[0],length(ByteBuff),0);
     setlength(ByteBuff,received_len);

     if (LogLevel > 2) and (received_len>0) then
     begin
          lmsg:='';lstr:='';
          for i:=0 to pred(received_len) do lmsg:=lmsg+IntToHex(ByteBuff[i],2)+' ';
          for i:=0 to pred(received_len) do if ByteBuff[i]<>0 then lstr:=lstr+char(ByteBuff[i])+' ';
          AddToLog('receive rl socket ='+IntToStr(Sock));
          AddToLog('Msg='+lmsg+' ('+lstr+')'+#$d#$a);
     end;

  cmd:=ByteBuff[0];
  if cmd = 1 then begin //Получаем от логинсервер пакет с именем акка и ключем для него
    offs := ByteBuff[2] + 4;
    acc_name := StrPas(@ByteBuff[3]);
    AddToLog('Getting RL reply: ' + acc_name);
    CurrPlayer:=TPlayer.Create(acc_name);

    if AllGM and (ByteBuff[1] = 0) then
      CurrPlayer.AccessLevel := 1
    else
      CurrPlayer.AccessLevel := ByteBuff[1];

    //Ключ доступа
    GetFromDByteArr(CurrPlayer.SS_Hash, ByteBuff, offs, 40);

    //Заносим в локальную базу акков если его там нет
    if not AccDbcHandler.ContainStrKey(acc_name) then begin
      //AddToLog('Adding account '+acc_name+' to local account DB');
      AddAccount(acc_name, '', '', 0, 0);
      AddToLog('Account '+acc_name+' added to local account DB');
    end ;//else AddToLog('Account '+acc_name+' exist');
    AuthPlayersHT.Add(acc_name, CurrPlayer);
  end;
end;

procedure TForm1.WMRLSocketEventHandler(var Msg:TMessage);
var
   Sock:TSocket;
   SockError,AcceptResult:Integer;     //
   Addr:TSockAddr;
   Len:Integer;
begin
   Sock:=TSocket(Msg.WParam);
   SockError:=WSAGetSelectError(Msg.lParam);
   if SockError<>0 then
    begin
     // Здесь должен быть анализ ошибки
     CloseSocket(Sock);
     Exit
    end;
   case WSAGetSelectEvent(Msg.lParam) of
    FD_Read:
     begin
      // Пришёл запрос от клиента. Необходимо прочитать данные,
      // сформировать ответ и отправить его.
      ReadFromRLSocket(Sock);
     end;
    FD_Accept:
     begin
      // Просто вызываем функцию Accept. Её результат нигде не
      // сохраняется, потому что вновь созданный сокет автоматически
      // начинает работать в асинхронном режиме, и его дескриптор при
      // необходимости будет передан через Msg.wParam при возникновении
      // события
      AcceptResult:=Accept(Sock,@Addr,@Len);    //
      Sleep(20);
      AddToLog('AcceptResult='+IntToStr(AcceptResult));  //+' Addr='+inet_ntoa(Addr.sin_addr)+' port='+IntToStr(ntohs(Addr.sin_port))+' Len='+IntToStr(Len));
     end;
    FD_Close:
     begin
      // Получив от клиента сигнал завершения, сервер, в принципе,
      // может попытаться отправить ему данные. После этого сервер
      // также должен соединение со своей стороны
      Shutdown(Sock,SD_Send);
      CloseSocket(Sock);
     end
   end
end;

procedure TForm1.WMAuthSocketEventHandler(var Msg:TMessage);
var
   Sock:TSocket;
   SockError,AcceptResult:Integer;     //
   Addr:TSockAddr;
   Len:Integer;
begin
   Sock:=TSocket(Msg.WParam);
   SockError:=WSAGetSelectError(Msg.lParam);
   if SockError<>0 then
    begin
     // Здесь должен быть анализ ошибки
     CloseSocket(Sock);
     Exit
    end;
   case WSAGetSelectEvent(Msg.lParam) of
    FD_Read:
     begin
      // Пришёл запрос от клиента. Необходимо прочитать данные,
      // сформировать ответ и отправить его.
      ReadFromAuthSocket(Sock);
     end;
    FD_Accept:
     begin
      // Просто вызываем функцию Accept. Её результат нигде не
      // сохраняется, потому что вновь созданный сокет автоматически
      // начинает работать в асинхронном режиме, и его дескриптор при
      // необходимости будет передан через Msg.wParam при возникновении
      // события
      AcceptResult:=Accept(Sock,@Addr,@Len);    //
      Sleep(20);
      AddToLog('AcceptResult='+IntToStr(AcceptResult));  //+' Addr='+inet_ntoa(Addr.sin_addr)+' port='+IntToStr(ntohs(Addr.sin_port))+' Len='+IntToStr(Len));
     end;
    FD_Close:
     begin
      // Получив от клиента сигнал завершения, сервер, в принципе,
      // может попытаться отправить ему данные. После этого сервер
      // также должен соединение со своей стороны
      Shutdown(Sock,SD_Send);
      CloseSocket(Sock);
     end
   end
end;

procedure TForm1.WMWorldSocketEventHandler(var Msg:TMessage);
var
   Sock:TSocket;
   SockError,AcceptResult:Integer;
   Addr:TSockAddr;
   Len,offs:Integer;
   out_buff: array of byte;

   Player: TPlayer;   
begin
   Sock:=TSocket(Msg.WParam);
   SockError:=WSAGetSelectError(Msg.lParam);
   if SockError<>0 then
    begin
     CloseSocket(Sock);
     Exit
    end;
   case WSAGetSelectEvent(Msg.lParam) of
    FD_Read:
     begin
      ReadFromWorldSocket(Sock);
     end;
    FD_Accept:
     begin
      AcceptResult:=Accept(Sock,@Addr,@Len);
      AddToLog('AcceptResult='+IntToStr(AcceptResult));  //+' Worldsock sock='+IntToStr(Sock)+' Addr='+inet_ntoa(Addr.sin_addr)+' port='+IntToStr(ntohs(Addr.sin_port))+' Len='+IntToStr(Len));
			setlength(out_buff,8);
      offs:=0;
      Add2DbyteArr(word($600),out_buff,offs);
      Add2DbyteArr(SMSG_AUTH_CHALLENGE,out_buff,offs);
      Add2DbyteArr(SEED,out_buff,offs);
      Sleep(20);
      Send(AcceptResult,out_buff[0],offs,0);
     end;
    FD_Close:
     begin //Здесь можно реализовать сейв чара при разрыве соединения...
      Player := LoggedPlayersAccBySockHT[sock];
      if Player <> nil then
        if AuthPlayersHT.Contains(Player.acc_name) then
          AuthPlayersHT.Remove(Player.acc_name);

      Shutdown(Sock,SD_Send);
      CloseSocket(Sock);
     end
   end
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  if AccDbcHandler.ContainStrKey(Edit1.Text) then begin
    ShowMessage('Account '+Edit1.Text+' already exist!');
    Exit;
  end;
  if (Edit1.Text = '') or (Edit2.Text = '') then begin
    ShowMessage('Заполните поля!');
    Exit;
  end;
  AddAccount(Edit1.Text, Edit2.Text, '', 0, 0);
  ShowMessage('Account '+Edit1.Text+' created!');  
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  SaveAll ;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
var
  i: Integer;
  Player: TPlayer;
begin
  for i := 0 to LoggedPlayersHT.InnerCapacity - 1 do
    if LoggedPlayersHT.InnerKeyList[i] <> '' then begin
      Player := LoggedPlayersHT[LoggedPlayersHT.InnerKeyList[i]];
      if (Player <> nil) and (Player.CurrChar <> nil) then
        Player.CurrChar.Regenerate ;
    end;
end;



end.
