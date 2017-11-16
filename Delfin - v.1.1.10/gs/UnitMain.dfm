object Form1: TForm1
  Left = 192
  Top = 106
  Width = 544
  Height = 448
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 380
    Width = 536
    Height = 41
    Align = alBottom
    TabOrder = 0
    object Label1: TLabel
      Left = 8
      Top = 14
      Width = 43
      Height = 13
      Caption = 'Account:'
    end
    object Label2: TLabel
      Left = 168
      Top = 14
      Width = 49
      Height = 13
      Caption = 'Password:'
    end
    object Button1: TButton
      Left = 336
      Top = 8
      Width = 105
      Height = 25
      Caption = 'Create Account'
      TabOrder = 0
      OnClick = Button1Click
    end
    object Edit1: TEdit
      Left = 56
      Top = 10
      Width = 105
      Height = 21
      TabOrder = 1
      Text = 'admin'
    end
    object Edit2: TEdit
      Left = 224
      Top = 10
      Width = 97
      Height = 21
      TabOrder = 2
      Text = 'admin'
    end
    object Button2: TButton
      Left = 448
      Top = 8
      Width = 75
      Height = 25
      Caption = 'Save'
      TabOrder = 3
      OnClick = Button2Click
    end
  end
  object Panel3: TPanel
    Left = 0
    Top = 0
    Width = 536
    Height = 380
    Align = alClient
    TabOrder = 1
    object Memo1: TMemo
      Left = 1
      Top = 1
      Width = 534
      Height = 378
      Align = alClient
      ScrollBars = ssVertical
      TabOrder = 0
    end
  end
  object Timer1: TTimer
    Enabled = False
    Interval = 2000
    OnTimer = Timer1Timer
    Left = 8
    Top = 8
  end
end
