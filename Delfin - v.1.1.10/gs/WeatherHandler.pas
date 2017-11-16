unit WeatherHandler;

interface

uses
  Windows, SysUtils, Classes,
  OpcodeHandler, OpConst;

type
  TWeatherManager = class
  private
    FWeatherType: Integer;
    FWeatherIntensity: Single;
    procedure SetWeatherType(const Value: Integer);
    procedure SetWeatherIntensity(const Value: Single);
    procedure Change(Player: TPlayer);
  public
    property WeatherType: Integer read FWeatherType write SetWeatherType;
    property WeatherIntensity: Single read FWeatherIntensity write SetWeatherIntensity;
    procedure Start(Player: TPlayer);
    procedure Stop(Player: TPlayer);
  end;

implementation

{ TWeatherManager }

procedure TWeatherManager.Change(Player: TPlayer);
begin
  Player.SendBuff.Init(SMSG_WEATHER) ;
  Player.SendBuff.Add(FWeatherType);
  Player.SendBuff.Add(FWeatherIntensity);
  Player.SendBuff.Add(Integer(0));
  //Player.SendBuff.Add(Byte(0));
  Player.SendPacket ;
end;

procedure TWeatherManager.SetWeatherIntensity(const Value: Single);
begin
  FWeatherIntensity := Value;
end;

procedure TWeatherManager.SetWeatherType(const Value: Integer);
begin
  FWeatherType := Value;
end;

procedure TWeatherManager.Start(Player: TPlayer);
begin
  Change(Player);
end;

procedure TWeatherManager.Stop(Player: TPlayer);
begin
  FWeatherType := 0;
  FWeatherIntensity := 0;
  Change(Player);
end;

end.
