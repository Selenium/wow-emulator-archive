program GameServer;

{%ToDo 'GameServer.todo'}

uses
  Forms,
  UnitMain in 'UnitMain.pas' {Form1},
  OpConst in 'OpConst.pas',
  ByteArrayHandler in 'ByteArrayHandler.pas',
  DbcHandler in 'DbcHandler.pas',
  CharHandler in 'CharHandler.pas',
  CharConst in 'CharConst.pas',
  DbcFieldsConst in 'DbcFieldsConst.pas',
  ItemHandler in 'ItemHandler.pas',
  OpcodeHandler in 'OpcodeHandler.pas',
  UpdateConst in 'UpdateConst.pas',
  WorldObject in 'WorldObject.pas',
  CellManager in 'CellManager.pas',
  NpcQuestHandler in 'NpcQuestHandler.pas',
  ChatHandler in 'ChatHandler.pas',
  SpellHandler in 'SpellHandler.pas',
  GroupHandler in 'GroupHandler.pas',
  CommandHandler in 'CommandHandler.pas',
  MailHandler in 'MailHandler.pas',
  MapHandler in 'MapHandler.pas',
  TaxiHandler in 'TaxiHandler.pas',
  Formulas in 'Formulas.pas',
  SaveThread in 'SaveThread.pas',
  SpellSystem in 'SpellSystem.pas',
  SpellConst in 'SpellConst.pas',
  TimedQueue in 'TimedQueue.pas',
  LoginHandler in 'LoginHandler.pas',
  AuctionHandler in 'AuctionHandler.pas',
  WeatherHandler in 'WeatherHandler.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
