VERSION 5.00
Begin VB.UserControl GTA3ColorPicker 
   ClientHeight    =   4860
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6300
   ScaleHeight     =   324
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   420
   Begin VB.PictureBox picContainer 
      Height          =   4860
      Left            =   0
      ScaleHeight     =   320
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   416
      TabIndex        =   0
      Top             =   0
      Width           =   6300
      Begin VB.CommandButton cmdColorPicker 
         Caption         =   "Cancel"
         Height          =   480
         Index           =   1
         Left            =   5385
         TabIndex        =   75
         Top             =   4320
         Width           =   855
      End
      Begin VB.CommandButton cmdColorPicker 
         Caption         =   "OK"
         Height          =   480
         Index           =   0
         Left            =   4815
         TabIndex        =   74
         Top             =   4320
         Width           =   585
      End
      Begin VB.Label lblColors
         BackColor = &H00000000&
         Height = 480
         Index = 0
         Left = 0
         TabIndex = 3
         TooltipText = "Black"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00F5F5F5&
         Height = 480
         Index = 1
         Left = 480
         TabIndex = 4
         TooltipText = "White"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00A1772A&
         Height = 480
         Index = 2
         Left = 960
         TabIndex = 5
         TooltipText = "Police Car Blue"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00100484&
         Height = 480
         Index = 3
         Left = 1440
         TabIndex = 6
         TooltipText = "Cherry Red"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00393726&
         Height = 480
         Index = 4
         Left = 1920
         TabIndex = 7
         TooltipText = "Midnight Blue"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H006E4486&
         Height = 480
         Index = 5
         Left = 2400
         TabIndex = 8
         TooltipText = "Temple Curtain Purple"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00108ED7&
         Height = 480
         Index = 6
         Left = 2880
         TabIndex = 9
         TooltipText = "Taxi Yellow"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00B7754C&
         Height = 480
         Index = 7
         Left = 3360
         TabIndex = 10
         TooltipText = "Striking Blue"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00C6BEBD&
         Height = 480
         Index = 8
         Left = 3840
         TabIndex = 11
         TooltipText = "Light Blue Grey"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0072705E&
         Height = 480
         Index = 9
         Left = 4320
         TabIndex = 12
         TooltipText = "Hoods"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H007A5946&
         Height = 480
         Index = 10
         Left = 4800
         TabIndex = 13
         TooltipText = "Saxony Blue Poly"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00796A65&
         Height = 480
         Index = 11
         Left = 5280
         TabIndex = 14
         TooltipText = "Concord Blue Poly"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008D7E5D&
         Height = 480
         Index = 12
         Left = 5760
         TabIndex = 15
         TooltipText = "Jasper Green Poly"
         Top = 0
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H005A5958&
         Height = 480
         Index = 13
         Left = 0
         TabIndex = 16
         TooltipText = "Pewter Gray Poly"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00D6DAD6&
         Height = 480
         Index = 14
         Left = 480
         TabIndex = 17
         TooltipText = "Frost White"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00A3A19C&
         Height = 480
         Index = 15
         Left = 960
         TabIndex = 18
         TooltipText = "Silver Stone Poly"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H003F5F33&
         Height = 480
         Index = 16
         Left = 1440
         TabIndex = 19
         TooltipText = "Rio Red"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H001A0E73&
         Height = 480
         Index = 17
         Left = 1920
         TabIndex = 20
         TooltipText = "Torino Red Pearl"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H002A0A7B&
         Height = 480
         Index = 18
         Left = 2400
         TabIndex = 21
         TooltipText = "Formula Red"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00949D9F&
         Height = 480
         Index = 19
         Left = 2880
         TabIndex = 22
         TooltipText = "Honey Beige Poly"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00784E3B&
         Height = 480
         Index = 20
         Left = 3360
         TabIndex = 23
         TooltipText = "Mariner Blue"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H003E2E73&
         Height = 480
         Index = 21
         Left = 3840
         TabIndex = 24
         TooltipText = "Blaze Red"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H003B1E69&
         Height = 480
         Index = 22
         Left = 4320
         TabIndex = 25
         TooltipText = "Classic Red"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008C9196&
         Height = 480
         Index = 23
         Left = 4800
         TabIndex = 26
         TooltipText = "Winning Silver Poly"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00595451&
         Height = 480
         Index = 24
         Left = 5280
         TabIndex = 27
         TooltipText = "Steel Gray Poly"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00453E3F&
         Height = 480
         Index = 25
         Left = 5760
         TabIndex = 28
         TooltipText = "Shadow Silver Poly"
         Top = 480
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00A7A9A5&
         Height = 480
         Index = 26
         Left = 0
         TabIndex = 29
         TooltipText = "Silver Stone Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H005A5C63&
         Height = 480
         Index = 27
         Left = 480
         TabIndex = 30
         TooltipText = "Warm Grey Mica"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00684A3D&
         Height = 480
         Index = 28
         Left = 960
         TabIndex = 31
         TooltipText = "Harbor Blue Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00929597&
         Height = 480
         Index = 29
         Left = 1440
         TabIndex = 32
         TooltipText = "Porcelain Silver Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00211F42&
         Height = 480
         Index = 30
         Left = 1920
         TabIndex = 33
         TooltipText = "Mellow Burgundy"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H002B275F&
         Height = 480
         Index = 31
         Left = 2400
         TabIndex = 34
         TooltipText = "Graceful Red Mica"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00AB9484&
         Height = 480
         Index = 32
         Left = 2880
         TabIndex = 35
         TooltipText = "Currant Blue Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H007C7B76&
         Height = 480
         Index = 33
         Left = 3360
         TabIndex = 36
         TooltipText = "Gray Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00646464&
         Height = 480
         Index = 34
         Left = 3840
         TabIndex = 37
         TooltipText = "Arctic White"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0052575A&
         Height = 480
         Index = 35
         Left = 4320
         TabIndex = 38
         TooltipText = "Anthracite Gray Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00272525&
         Height = 480
         Index = 36
         Left = 4800
         TabIndex = 39
         TooltipText = "Black Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00353A2D&
         Height = 480
         Index = 37
         Left = 5280
         TabIndex = 40
         TooltipText = "Dark Green Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0096A393&
         Height = 480
         Index = 38
         Left = 5760
         TabIndex = 41
         TooltipText = "Seafoam Poly"
         Top = 960
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00887A6D&
         Height = 480
         Index = 39
         Left = 0
         TabIndex = 42
         TooltipText = "Diamond Blue Poly"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00181922&
         Height = 480
         Index = 40
         Left = 480
         TabIndex = 43
         TooltipText = "Biston Brown Poly"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H005F676F&
         Height = 480
         Index = 41
         Left = 960
         TabIndex = 44
         TooltipText = "Desert Taupe Poly"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H002A1C7C&
         Height = 480
         Index = 42
         Left = 1440
         TabIndex = 45
         TooltipText = "Garnet Red Poly"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00150A5F&
         Height = 480
         Index = 43
         Left = 1920
         TabIndex = 46
         TooltipText = "Desert Red"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00263819&
         Height = 480
         Index = 44
         Left = 2400
         TabIndex = 47
         TooltipText = "Green"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00201B5D&
         Height = 480
         Index = 45
         Left = 2880
         TabIndex = 48
         TooltipText = "Cabernet Red Poly"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0072989D&
         Height = 480
         Index = 46
         Left = 3360
         TabIndex = 49
         TooltipText = "Light Ivory"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0060757A&
         Height = 480
         Index = 47
         Left = 3840
         TabIndex = 50
         TooltipText = "Pueblo Beige"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00869598&
         Height = 480
         Index = 48
         Left = 4320
         TabIndex = 51
         TooltipText = "Smoke Silver Poly"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00B0B0AD&
         Height = 480
         Index = 49
         Left = 4800
         TabIndex = 52
         TooltipText = "Astra Silver Poly"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00888984&
         Height = 480
         Index = 50
         Left = 5280
         TabIndex = 53
         TooltipText = "Ascot Gray"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00454F30&
         Height = 480
         Index = 51
         Left = 5760
         TabIndex = 54
         TooltipText = "Agate Green"
         Top = 1440
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0068624D&
         Height = 480
         Index = 52
         Left = 0
         TabIndex = 55
         TooltipText = "Petrol Blue Green Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00482216&
         Height = 480
         Index = 53
         Left = 480
         TabIndex = 56
         TooltipText = "Surf Blue"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H004B2F27&
         Height = 480
         Index = 54
         Left = 960
         TabIndex = 57
         TooltipText = "Nautical Blue Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0056627D&
         Height = 480
         Index = 55
         Left = 1440
         TabIndex = 58
         TooltipText = "Woodrose Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00ABA49E&
         Height = 480
         Index = 56
         Left = 1920
         TabIndex = 59
         TooltipText = "Crystal Blue Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00718D9C&
         Height = 480
         Index = 57
         Left = 2400
         TabIndex = 60
         TooltipText = "Bisque Frost Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0022186D&
         Height = 480
         Index = 58
         Left = 2880
         TabIndex = 61
         TooltipText = "Currant Red Solid"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0081684E&
         Height = 480
         Index = 59
         Left = 3360
         TabIndex = 62
         TooltipText = "Lt.Crystal Blue Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00989C9C&
         Height = 480
         Index = 60
         Left = 3840
         TabIndex = 63
         TooltipText = "Lt.Titanium Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00477391&
         Height = 480
         Index = 61
         Left = 4320
         TabIndex = 64
         TooltipText = "Race Yellow Solid"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00261C66&
         Height = 480
         Index = 62
         Left = 4800
         TabIndex = 65
         TooltipText = "Brt.Currant Red Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H009F9D94&
         Height = 480
         Index = 63
         Left = 5280
         TabIndex = 66
         TooltipText = "Clear Crystal Blue Frost Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00A5A7A4&
         Height = 480
         Index = 64
         Left = 5760
         TabIndex = 67
         TooltipText = "Silver Poly"
         Top = 1920
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00468C8E&
         Height = 480
         Index = 65
         Left = 0
         TabIndex = 68
         TooltipText = "Pastel Alabaster"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H001E1A34&
         Height = 480
         Index = 66
         Left = 480
         TabIndex = 69
         TooltipText = "Mid Currant Red Poly"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008C7A6A&
         Height = 480
         Index = 67
         Left = 960
         TabIndex = 70
         TooltipText = "Med Regatta Blue Poly"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008EADAA&
         Height = 480
         Index = 68
         Left = 1440
         TabIndex = 71
         TooltipText = "Oxford White Solid"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008F98AB&
         Height = 480
         Index = 69
         Left = 1920
         TabIndex = 72
         TooltipText = "Alabaster Solid"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H002E1F85&
         Height = 480
         Index = 70
         Left = 2400
         TabIndex = 73
         TooltipText = "Elec.Currant Red Poly"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0097826F&
         Height = 480
         Index = 71
         Left = 2880
         TabIndex = 74
         TooltipText = "Spinnaker Blue Solid"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00535858&
         Height = 480
         Index = 72
         Left = 3360
         TabIndex = 75
         TooltipText = "Dk.Titanium Poly"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0090A79A&
         Height = 480
         Index = 73
         Left = 3840
         TabIndex = 76
         TooltipText = "Pastel Alabaster Solid"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00231A60&
         Height = 480
         Index = 74
         Left = 4320
         TabIndex = 77
         TooltipText = "Med.Cabernet Solid"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H002C2020&
         Height = 480
         Index = 75
         Left = 4800
         TabIndex = 78
         TooltipText = "Twilight Blue Poly"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0096A0A4&
         Height = 480
         Index = 76
         Left = 5280
         TabIndex = 79
         TooltipText = "Titanium Frost Poly"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00849DAA&
         Height = 480
         Index = 77
         Left = 5760
         TabIndex = 80
         TooltipText = "Sandalwood Frost Poly"
         Top = 2400
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H002B2278&
         Height = 480
         Index = 78
         Left = 0
         TabIndex = 81
         TooltipText = "Wild Strawberry Poly"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H006D310E&
         Height = 480
         Index = 79
         Left = 480
         TabIndex = 82
         TooltipText = "Ultra Blue Poly"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H003F2A72&
         Height = 480
         Index = 80
         Left = 960
         TabIndex = 83
         TooltipText = "Vermilion Solid"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H005E717B&
         Height = 480
         Index = 81
         Left = 1440
         TabIndex = 84
         TooltipText = "Med.Sandalwood Poly"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00281D74&
         Height = 480
         Index = 82
         Left = 1920
         TabIndex = 85
         TooltipText = "Med.Red Solid"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00322E1E&
         Height = 480
         Index = 83
         Left = 2400
         TabIndex = 86
         TooltipText = "Deep Jewel Green"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H002F324D&
         Height = 480
         Index = 84
         Left = 2880
         TabIndex = 87
         TooltipText = "Med.Woodrose Poly"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00441B7C&
         Height = 480
         Index = 85
         Left = 3360
         TabIndex = 88
         TooltipText = "Vermillion Solid"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00205B2E&
         Height = 480
         Index = 86
         Left = 3840
         TabIndex = 89
         TooltipText = "Green"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00835A39&
         Height = 480
         Index = 87
         Left = 4320
         TabIndex = 90
         TooltipText = "Bright Blue Poly"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0037286D&
         Height = 480
         Index = 88
         Left = 4800
         TabIndex = 91
         TooltipText = "Bright Red"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008FA2A7&
         Height = 480
         Index = 89
         Left = 5280
         TabIndex = 92
         TooltipText = "Lt.Champagne Poly"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00B1B1AF&
         Height = 480
         Index = 90
         Left = 5760
         TabIndex = 93
         TooltipText = "Silver Poly"
         Top = 2880
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00554136&
         Height = 480
         Index = 91
         Left = 0
         TabIndex = 94
         TooltipText = "Steel Blue Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H006E6C6D&
         Height = 480
         Index = 92
         Left = 480
         TabIndex = 95
         TooltipText = "Medium Gray Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00896A0F&
         Height = 480
         Index = 93
         Left = 960
         TabIndex = 96
         TooltipText = "Arctic Pearl"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H006B4B20&
         Height = 480
         Index = 94
         Left = 1440
         TabIndex = 97
         TooltipText = "Nassau Blue Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00573E2B&
         Height = 480
         Index = 95
         Left = 1920
         TabIndex = 98
         TooltipText = "Med.Sapphire Blue Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H009D9F9B&
         Height = 480
         Index = 96
         Left = 2400
         TabIndex = 99
         TooltipText = "Silver Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0095846C&
         Height = 480
         Index = 97
         Left = 2880
         TabIndex = 100
         TooltipText = "Lt.Sapphire Blue Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00605D4D&
         Height = 480
         Index = 98
         Left = 3360
         TabIndex = 101
         TooltipText = "Malachite Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H007F9BAE&
         Height = 480
         Index = 99
         Left = 3840
         TabIndex = 102
         TooltipText = "Flax"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008F6C40&
         Height = 480
         Index = 100
         Left = 4320
         TabIndex = 103
         TooltipText = "Med.Maui Blue Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H003B251F&
         Height = 480
         Index = 101
         Left = 4800
         TabIndex = 104
         TooltipText = "Dk.Sapphire Blue Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H007692AB&
         Height = 480
         Index = 102
         Left = 5280
         TabIndex = 105
         TooltipText = "Copper Beige"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00734513&
         Height = 480
         Index = 103
         Left = 5760
         TabIndex = 106
         TooltipText = "Bright Blue Poly"
         Top = 3360
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H006C8196&
         Height = 480
         Index = 104
         Left = 0
         TabIndex = 107
         TooltipText = "Med.Flax"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H006A6864&
         Height = 480
         Index = 105
         Left = 480
         TabIndex = 108
         TooltipText = "Med.Gray Poly"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00825010&
         Height = 480
         Index = 106
         Left = 960
         TabIndex = 109
         TooltipText = "Bright Blue Poly"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H008399A1&
         Height = 480
         Index = 107
         Left = 1440
         TabIndex = 110
         TooltipText = "Lt.Driftwood Poly"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00945638&
         Height = 480
         Index = 108
         Left = 1920
         TabIndex = 111
         TooltipText = "Blue"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00615652&
         Height = 480
         Index = 109
         Left = 2400
         TabIndex = 112
         TooltipText = "Steel Gray Poly"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H0056697F&
         Height = 480
         Index = 110
         Left = 2880
         TabIndex = 113
         TooltipText = "Lt.Beechwood Poly"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H009A928C&
         Height = 480
         Index = 111
         Left = 3360
         TabIndex = 114
         TooltipText = "Slate Gray"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00876E59&
         Height = 480
         Index = 112
         Left = 3840
         TabIndex = 115
         TooltipText = "Lt.Sapphire Blue Poly"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00323547&
         Height = 480
         Index = 113
         Left = 4320
         TabIndex = 116
         TooltipText = "Dk.Beechwood Poly"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H004F6244&
         Height = 480
         Index = 114
         Left = 4800
         TabIndex = 117
         TooltipText = "Torch Red"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00270A73&
         Height = 480
         Index = 115
         Left = 5280
         TabIndex = 118
         TooltipText = "Bright Red"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00573422&
         Height = 480
         Index = 116
         Left = 5760
         TabIndex = 119
         TooltipText = "Med.Sapphire Blue Firemist"
         Top = 3840
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H001B0D64&
         Height = 480
         Index = 117
         Left = 0
         TabIndex = 120
         TooltipText = "Med.Garnet Red Poly"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00C6ADA3&
         Height = 480
         Index = 118
         Left = 480
         TabIndex = 121
         TooltipText = "White Diamond Pearl"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00535869&
         Height = 480
         Index = 119
         Left = 960
         TabIndex = 122
         TooltipText = "Dk.Sable Poly"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00808B9B&
         Height = 480
         Index = 120
         Left = 1440
         TabIndex = 123
         TooltipText = "Antelope Beige"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H001C0B62&
         Height = 480
         Index = 121
         Left = 1920
         TabIndex = 124
         TooltipText = "Brilliant Red Poly"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H005E5D5B&
         Height = 480
         Index = 122
         Left = 2400
         TabIndex = 125
         TooltipText = "Gun Metal Poly"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00284462&
         Height = 480
         Index = 123
         Left = 2880
         TabIndex = 126
         TooltipText = "Med.Beechwood Poly"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00271873&
         Height = 480
         Index = 124
         Left = 3360
         TabIndex = 127
         TooltipText = "Brilliant Red Poly"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H006D371B&
         Height = 480
         Index = 125
         Left = 3840
         TabIndex = 128
         TooltipText = "Bright Blue Poly"
         Top = 4320
         Width = 480
      End
      Begin VB.Label lblColors
         BackColor = &H00AE6AEC&
         Height = 480
         Index = 126
         Left = 4320
         TabIndex = 129
         TooltipText = "Pink"
         Top = 4320
         Width = 480
      End
   End
End
Attribute VB_Name = "GTA3ColorPicker"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Public intSelectedColorIndex As Integer
Event ColorPicked(ByVal isSelected As Boolean, ByVal intColorOrdinal As Integer)

Private Sub cmdColorPicker_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 0 'OK
            RaiseEvent ColorPicked(True, intSelectedColorIndex)
        Case 1 'Cancel
            RaiseEvent ColorPicked(False, intSelectedColorIndex)
    End Select
    Err.Clear
    
End Sub

Private Sub lblColors_Click(Index As Integer)
On Error Resume Next
    UserControl.BackColor = lblColors(Index).BackColor
    intSelectedColorIndex = Index
    Err.Clear
End Sub

Private Sub lblColors_DblClick(Index As Integer)
On Error Resume Next
    UserControl.BackColor = lblColors(Index).BackColor
    intSelectedColorIndex = Index
    Call cmdColorPicker_Click(0)
    Err.Clear
End Sub

Public Function SetLabelColor(ByVal intLabelIndex As Integer, ByVal lngColorCode As Long, ByVal strToolTip As String) As Boolean
On Error GoTo errSetLabelColor
    SetLabelColor = False
        lblColors(intLabelIndex).BackColor = lngColorCode
        lblColors(intLabelIndex).ToolTipText = strToolTip
    SetLabelColor = True
Exit Function
errSetLabelColor:
    Err.Clear
End Function
