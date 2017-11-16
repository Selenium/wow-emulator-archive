program LoginServer;

{$DEFINE CONSOLE}

{$IFDEF CONSOLE}
  {$APPTYPE CONSOLE}
{$ENDIF}

uses
  Avl,
  UnitMain in 'UnitMain.pas' {Form1};

//{$R *.RES}

begin
  ConsoleColor := $FFFF;
  AddToLog('Delfin Login Server v0.0.6.2');

  Form1 := TForm1.Create(nil, '');
  Form1.OnCreate := Form1.FormCreate;
  {$IFDEF CONSOLE}
    Form1.Visible := False;
  {$ELSE}
    Form1.SetSize(550, 450);
    Form1.mmLog := TMemo.Create(Form1, '');
    Form1.mmLog.SetSize(540, 420);
  {$ENDIF}
  Form1.Run ;
end.
