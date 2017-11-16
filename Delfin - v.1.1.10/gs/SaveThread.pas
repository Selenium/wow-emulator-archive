unit SaveThread;

interface

uses
  Windows, Classes;

type
  TSaveThread = class(TThread)
  private
    { Private declarations }
  protected
    procedure Execute; override;
    procedure Save;
  end;

implementation

uses
  UnitMain;

procedure TSaveThread.Save;
begin
  SaveAll ;
end;  

procedure TSaveThread.Execute;
begin
  while not Terminated do begin
    Sleep(SaveTime*1000*60);
    Synchronize(Save);
  end;
end;

end.
