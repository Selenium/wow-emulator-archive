VERSION 5.00
Begin VB.Form frmMods 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "GTA SA Control Center Mod Selection"
   ClientHeight    =   5565
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7620
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5565
   ScaleWidth      =   7620
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame frameModsGen 
      Caption         =   "Available Mods for Standard Cars:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   26
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameModsGen 
         Caption         =   "Fog Lights:"
         Height          =   1275
         Index           =   4
         Left            =   1590
         TabIndex        =   34
         Top             =   1560
         Width           =   1500
         Begin VB.OptionButton optGenLights 
            Caption         =   "Square Fog"
            Enabled         =   0   'False
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   37
            TabStop         =   0   'False
            Tag             =   "400"
            ToolTipText     =   "Square Fog Lights"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optGenLights 
            Caption         =   "Round Fog"
            Enabled         =   0   'False
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   36
            TabStop         =   0   'False
            Tag             =   "3F5"
            ToolTipText     =   "Round Fog Lights"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optGenLights 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   35
            TabStop         =   0   'False
            ToolTipText     =   "No Fog Lights"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.CheckBox chkGenSideSkirt 
         Caption         =   "Side Skirt"
         Enabled         =   0   'False
         Height          =   600
         Left            =   3135
         TabIndex        =   61
         TabStop         =   0   'False
         Tag             =   "3EF"
         ToolTipText     =   "Generic Side Skirts"
         Top             =   3480
         Width           =   1410
      End
      Begin VB.Frame frameModsGen 
         Caption         =   "Roof Scoop:"
         Height          =   1575
         Index           =   2
         Left            =   120
         TabIndex        =   56
         Top             =   2550
         Width           =   1500
         Begin VB.OptionButton optGenRoofScoops 
            Caption         =   "Champ"
            Enabled         =   0   'False
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   60
            TabStop         =   0   'False
            Tag             =   "3EC"
            ToolTipText     =   "Champ Roof Scoops"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optGenRoofScoops 
            Caption         =   "Fury"
            Enabled         =   0   'False
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   59
            TabStop         =   0   'False
            Tag             =   "3ED"
            ToolTipText     =   "Fury Roof Scoop"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optGenRoofScoops 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   58
            TabStop         =   0   'False
            ToolTipText     =   "No Roof Scoops"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.CheckBox chkGenRoofScoop 
            Caption         =   "Generic"
            Enabled         =   0   'False
            Height          =   300
            Left            =   120
            TabIndex        =   57
            TabStop         =   0   'False
            Tag             =   "3EE"
            ToolTipText     =   "Generic Roof Scoops"
            Top             =   1170
            Width           =   1230
         End
      End
      Begin VB.Frame frameModsGen 
         Caption         =   "Exhaust:"
         Height          =   2205
         Index           =   1
         Left            =   120
         TabIndex        =   27
         Top             =   270
         Width           =   1500
         Begin VB.OptionButton optGenExhaust 
            Caption         =   "Upswept"
            Enabled         =   0   'False
            Height          =   300
            Index           =   5
            Left            =   135
            TabIndex        =   33
            TabStop         =   0   'False
            Tag             =   "3FA"
            ToolTipText     =   "Upswept Exhaust"
            Top             =   1770
            Width           =   1230
         End
         Begin VB.OptionButton optGenExhaust 
            Caption         =   "Twin"
            Enabled         =   0   'False
            Height          =   300
            Index           =   4
            Left            =   135
            TabIndex        =   32
            TabStop         =   0   'False
            Tag             =   "3FB"
            ToolTipText     =   "Twin Exhaust"
            Top             =   1470
            Width           =   1230
         End
         Begin VB.OptionButton optGenExhaust 
            Caption         =   "Large"
            Enabled         =   0   'False
            Height          =   300
            Index           =   3
            Left            =   135
            TabIndex        =   31
            TabStop         =   0   'False
            Tag             =   "3FC"
            ToolTipText     =   "Large Exhaust"
            Top             =   1170
            Width           =   1230
         End
         Begin VB.OptionButton optGenExhaust 
            Caption         =   "Medium"
            Enabled         =   0   'False
            Height          =   300
            Index           =   2
            Left            =   135
            TabIndex        =   30
            TabStop         =   0   'False
            Tag             =   "3FD"
            ToolTipText     =   "Medium Exhaust"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optGenExhaust 
            Caption         =   "Small"
            Enabled         =   0   'False
            Height          =   300
            Index           =   1
            Left            =   135
            TabIndex        =   29
            TabStop         =   0   'False
            Tag             =   "3FE"
            ToolTipText     =   "Small Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optGenExhaust 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   135
            TabIndex        =   28
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameModsGen 
         Caption         =   "Hood Vent:"
         Height          =   1290
         Index           =   5
         Left            =   1590
         TabIndex        =   48
         Top             =   2835
         Width           =   1500
         Begin VB.OptionButton optGenHoodVent 
            Caption         =   "Square"
            Enabled         =   0   'False
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   51
            TabStop         =   0   'False
            Tag             =   "479"
            ToolTipText     =   "Square Hood Vents"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optGenHoodVent 
            Caption         =   "Oval"
            Enabled         =   0   'False
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   50
            TabStop         =   0   'False
            Tag             =   "477"
            ToolTipText     =   "Oval Hood Vents"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optGenHoodVent 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   49
            TabStop         =   0   'False
            ToolTipText     =   "No Hood Vents"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameModsGen 
         Caption         =   "Hood Scoop:"
         Height          =   1275
         Index           =   3
         Left            =   1590
         TabIndex        =   52
         Top             =   270
         Width           =   1500
         Begin VB.OptionButton optGenHoodScoops 
            Caption         =   "Race"
            Enabled         =   0   'False
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   55
            TabStop         =   0   'False
            Tag             =   "3F3"
            ToolTipText     =   "Race Hood Scoop"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optGenHoodScoops 
            Caption         =   "Worx"
            Enabled         =   0   'False
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   54
            TabStop         =   0   'False
            Tag             =   "3F4"
            ToolTipText     =   "Worx Hood Scoop"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optGenHoodScoops 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   53
            TabStop         =   0   'False
            ToolTipText     =   "No Hood Scoops"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameModsGen 
         Caption         =   "Spoiler:"
         Height          =   3135
         Index           =   6
         Left            =   3060
         TabIndex        =   38
         Top             =   270
         Width           =   1500
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Win"
            Enabled         =   0   'False
            Height          =   300
            Index           =   8
            Left            =   120
            TabIndex        =   47
            TabStop         =   0   'False
            Tag             =   "3E9"
            ToolTipText     =   "Win Spoiler"
            Top             =   2670
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Worx"
            Enabled         =   0   'False
            Height          =   300
            Index           =   7
            Left            =   120
            TabIndex        =   46
            TabStop         =   0   'False
            Tag             =   "3F4"
            ToolTipText     =   "Worx Spoiler"
            Top             =   2370
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Race"
            Enabled         =   0   'False
            Height          =   300
            Index           =   6
            Left            =   120
            TabIndex        =   45
            TabStop         =   0   'False
            Tag             =   "3F3"
            ToolTipText     =   "Race Spoiler"
            Top             =   2070
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Pro"
            Enabled         =   0   'False
            Height          =   300
            Index           =   5
            Left            =   120
            TabIndex        =   44
            TabStop         =   0   'False
            Tag             =   "3E8"
            ToolTipText     =   "Pro Spoiler"
            Top             =   1770
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Fury"
            Enabled         =   0   'False
            Height          =   300
            Index           =   4
            Left            =   120
            TabIndex        =   43
            TabStop         =   0   'False
            Tag             =   "3ED"
            ToolTipText     =   "Fury Spoiler"
            Top             =   1470
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Drag"
            Enabled         =   0   'False
            Height          =   300
            Index           =   3
            Left            =   120
            TabIndex        =   42
            TabStop         =   0   'False
            Tag             =   "3EA"
            ToolTipText     =   "Drag Spoiler"
            Top             =   1170
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Champ"
            Enabled         =   0   'False
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   41
            TabStop         =   0   'False
            Tag             =   "3EC"
            ToolTipText     =   "Champ Spoiler"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "Alpha"
            Enabled         =   0   'False
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   40
            TabStop         =   0   'False
            Tag             =   "3EB"
            ToolTipText     =   "Alpha Spoiler"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optGenSpoilers 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   39
            TabStop         =   0   'False
            ToolTipText     =   "No Spoiler"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
   Begin VB.Frame frameMods562 
      Caption         =   "Available Mods for Elegy:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   89
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods562 
         Caption         =   "Side Skirt:"
         Height          =   1305
         Index           =   6
         Left            =   1665
         TabIndex        =   110
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSkirt562 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   113
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirt"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt562 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   112
            TabStop         =   0   'False
            Tag             =   "40C"
            ToolTipText     =   "Alien Side Skirt"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt562 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   111
            TabStop         =   0   'False
            Tag             =   "40F"
            ToolTipText     =   "X-Flow Side Skirt"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods562 
         Caption         =   "Spoiler:"
         Height          =   1305
         Index           =   3
         Left            =   120
         TabIndex        =   106
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSpoiler562 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   109
            TabStop         =   0   'False
            ToolTipText     =   "No Spoiler"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler562 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   108
            TabStop         =   0   'False
            Tag             =   "47B"
            ToolTipText     =   "Alien Spoiler"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler562 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   107
            TabStop         =   0   'False
            Tag             =   "47A"
            ToolTipText     =   "X-Flow Spoiler"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods562 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   5
         Left            =   1665
         TabIndex        =   102
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRB562 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   105
            TabStop         =   0   'False
            Tag             =   "47C"
            ToolTipText     =   "X-Flow Rear Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRB562 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   104
            TabStop         =   0   'False
            Tag             =   "47D"
            ToolTipText     =   "Alien Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB562 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   103
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods562 
         Caption         =   "Roof Vent:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   98
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRoof562 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   101
            TabStop         =   0   'False
            Tag             =   "40B"
            ToolTipText     =   "X-Flow Roof Vent"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRoof562 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   100
            TabStop         =   0   'False
            Tag             =   "40E"
            ToolTipText     =   "Alien Roof Vent"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRoof562 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   99
            TabStop         =   0   'False
            ToolTipText     =   "No Roof Vent"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods562 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1635
         TabIndex        =   94
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB562 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   97
            TabStop         =   0   'False
            Tag             =   "494"
            ToolTipText     =   "X-Flow Front Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optFB562 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   96
            TabStop         =   0   'False
            Tag             =   "493"
            ToolTipText     =   "Alien Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB562 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   95
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods562 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   90
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx562 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   93
            TabStop         =   0   'False
            Tag             =   "40D"
            ToolTipText     =   "X-Flow Exhaust"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optEx562 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   92
            TabStop         =   0   'False
            Tag             =   "40A"
            ToolTipText     =   "Alien Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx562 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   91
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
   Begin VB.Frame frameMods561 
      Caption         =   "Available Mods for Stratum:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   114
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods561 
         Caption         =   "Side Skirt:"
         Height          =   1305
         Index           =   6
         Left            =   1665
         TabIndex        =   135
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSkirt561 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   138
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirt"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt561 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   137
            TabStop         =   0   'False
            Tag             =   "420"
            ToolTipText     =   "Alien Side Skirt"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt561 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   136
            TabStop         =   0   'False
            Tag             =   "421"
            ToolTipText     =   "X-Flow Side Skirt"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods561 
         Caption         =   "Spoiler:"
         Height          =   1305
         Index           =   3
         Left            =   120
         TabIndex        =   131
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSpoiler561 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   134
            TabStop         =   0   'False
            ToolTipText     =   "No Spoiler"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler561 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   133
            TabStop         =   0   'False
            Tag             =   "422"
            ToolTipText     =   "Alien Spoiler"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler561 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   132
            TabStop         =   0   'False
            Tag             =   "424"
            ToolTipText     =   "X-Flow Spoiler"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods561 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   5
         Left            =   1665
         TabIndex        =   127
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRB561 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   130
            TabStop         =   0   'False
            Tag             =   "484"
            ToolTipText     =   "X-Flow Rear Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRB561 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   129
            TabStop         =   0   'False
            Tag             =   "482"
            ToolTipText     =   "Alien Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB561 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   128
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods561 
         Caption         =   "Roof Vent:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   123
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRoof561 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   126
            TabStop         =   0   'False
            Tag             =   "425"
            ToolTipText     =   "X-Flow Roof Vent"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRoof561 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   125
            TabStop         =   0   'False
            Tag             =   "41F"
            ToolTipText     =   "Alien Roof Vent"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRoof561 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   124
            TabStop         =   0   'False
            ToolTipText     =   "No Roof Vent"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods561 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1635
         TabIndex        =   119
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB561 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   122
            TabStop         =   0   'False
            Tag             =   "485"
            ToolTipText     =   "X-Flow Front Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optFB561 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   121
            TabStop         =   0   'False
            Tag             =   "483"
            ToolTipText     =   "Alien Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB561 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   120
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods561 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   115
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx561 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   118
            TabStop         =   0   'False
            Tag             =   "423"
            ToolTipText     =   "X-Flow Exhaust"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optEx561 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   117
            TabStop         =   0   'False
            Tag             =   "428"
            ToolTipText     =   "Alien Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx561 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   116
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
   Begin VB.Frame frameMods560 
      Caption         =   "Available Mods for Sultan:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   139
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods560 
         Caption         =   "Side Skirt:"
         Height          =   1305
         Index           =   6
         Left            =   1665
         TabIndex        =   160
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSkirt560 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   163
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirt"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt560 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   162
            TabStop         =   0   'False
            Tag             =   "402"
            ToolTipText     =   "Alien Side Skirt"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt560 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   161
            TabStop         =   0   'False
            Tag             =   "407"
            ToolTipText     =   "X-Flow Side Skirt"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods560 
         Caption         =   "Spoiler:"
         Height          =   1305
         Index           =   3
         Left            =   120
         TabIndex        =   156
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSpoiler560 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   159
            TabStop         =   0   'False
            ToolTipText     =   "No Spoiler"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler560 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   158
            TabStop         =   0   'False
            Tag             =   "472"
            ToolTipText     =   "Alien Spoiler"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler560 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   157
            TabStop         =   0   'False
            Tag             =   "473"
            ToolTipText     =   "X-Flow Spoiler"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods560 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   5
         Left            =   1665
         TabIndex        =   152
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRB560 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   155
            TabStop         =   0   'False
            Tag             =   "474"
            ToolTipText     =   "X-Flow Rear Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRB560 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   154
            TabStop         =   0   'False
            Tag             =   "475"
            ToolTipText     =   "Alien Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB560 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   153
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods560 
         Caption         =   "Roof Vent:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   148
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRoof560 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   151
            TabStop         =   0   'False
            Tag             =   "409"
            ToolTipText     =   "X-Flow Roof Vent"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRoof560 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   150
            TabStop         =   0   'False
            Tag             =   "408"
            ToolTipText     =   "Alien Roof Vent"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRoof560 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   149
            TabStop         =   0   'False
            ToolTipText     =   "No Roof Vent"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods560 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1635
         TabIndex        =   144
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB560 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   147
            TabStop         =   0   'False
            Tag             =   "492"
            ToolTipText     =   "X-Flow Front Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optFB560 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   146
            TabStop         =   0   'False
            Tag             =   "491"
            ToolTipText     =   "Alien Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB560 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   145
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods560 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   140
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx560 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   143
            TabStop         =   0   'False
            Tag             =   "405"
            ToolTipText     =   "X-Flow Exhaust"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optEx560 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   142
            TabStop         =   0   'False
            Tag             =   "404"
            ToolTipText     =   "Alien Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx560 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   141
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
   Begin VB.Frame frameMods559 
      Caption         =   "Available Mods for Jester:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   164
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods559 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   185
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx559 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   188
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optEx559 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   187
            TabStop         =   0   'False
            Tag             =   "429"
            ToolTipText     =   "Alien Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx559 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   186
            TabStop         =   0   'False
            Tag             =   "42A"
            ToolTipText     =   "X-Flow Exhaust"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods559 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1635
         TabIndex        =   181
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB559 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   184
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optFB559 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   183
            TabStop         =   0   'False
            Tag             =   "488"
            ToolTipText     =   "Alien Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB559 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   182
            TabStop         =   0   'False
            Tag             =   "495"
            ToolTipText     =   "X-Flow Front Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods559 
         Caption         =   "Roof Vent:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   177
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRoof559 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   180
            TabStop         =   0   'False
            ToolTipText     =   "No Roof Vent"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRoof559 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   179
            TabStop         =   0   'False
            Tag             =   "42B"
            ToolTipText     =   "Alien Roof Vent"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRoof559 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   178
            TabStop         =   0   'False
            Tag             =   "42C"
            ToolTipText     =   "X-Flow Roof Vent"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods559 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   5
         Left            =   1665
         TabIndex        =   173
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRB559 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   176
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRB559 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   175
            TabStop         =   0   'False
            Tag             =   "487"
            ToolTipText     =   "Alien Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB559 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   174
            TabStop         =   0   'False
            Tag             =   "489"
            ToolTipText     =   "X-Flow Rear Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods559 
         Caption         =   "Spoiler:"
         Height          =   1305
         Index           =   3
         Left            =   120
         TabIndex        =   169
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSpoiler559 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   172
            TabStop         =   0   'False
            Tag             =   "486"
            ToolTipText     =   "X-Flow Spoiler"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler559 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   171
            TabStop         =   0   'False
            Tag             =   "48A"
            ToolTipText     =   "Alien Spoiler"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler559 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   170
            TabStop         =   0   'False
            ToolTipText     =   "No Spoiler"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods559 
         Caption         =   "Side Skirt:"
         Height          =   1305
         Index           =   6
         Left            =   1665
         TabIndex        =   165
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSkirt559 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   168
            TabStop         =   0   'False
            Tag             =   "42E"
            ToolTipText     =   "X-Flow Side Skirt"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt559 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   167
            TabStop         =   0   'False
            Tag             =   "42D"
            ToolTipText     =   "Alien Side Skirt"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt559 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   166
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirt"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
   Begin VB.Frame frameMods558 
      Caption         =   "Available Mods for Uranus:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   189
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods558 
         Caption         =   "Side Skirt:"
         Height          =   1305
         Index           =   6
         Left            =   1665
         TabIndex        =   210
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSkirt558 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   213
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirt"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt558 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   212
            TabStop         =   0   'False
            Tag             =   "442"
            ToolTipText     =   "Alien Side Skirt"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt558 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   211
            TabStop         =   0   'False
            Tag             =   "445"
            ToolTipText     =   "X-Flow Side Skirt"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods558 
         Caption         =   "Spoiler:"
         Height          =   1305
         Index           =   5
         Left            =   120
         TabIndex        =   206
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSpoiler558 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   209
            TabStop         =   0   'False
            ToolTipText     =   "No Spoiler"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler558 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   208
            TabStop         =   0   'False
            Tag             =   "48C"
            ToolTipText     =   "Alien Spoiler"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler558 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   207
            TabStop         =   0   'False
            Tag             =   "48B"
            ToolTipText     =   "X-Flow Spoiler"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods558 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1665
         TabIndex        =   202
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRB558 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   205
            TabStop         =   0   'False
            Tag             =   "48F"
            ToolTipText     =   "X-Flow Rear Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRB558 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   204
            TabStop         =   0   'False
            Tag             =   "490"
            ToolTipText     =   "Alien Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB558 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   203
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods558 
         Caption         =   "Roof Vent:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   198
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRoof558 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   201
            TabStop         =   0   'False
            Tag             =   "443"
            ToolTipText     =   "X-Flow Roof Vent"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRoof558 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   200
            TabStop         =   0   'False
            Tag             =   "440"
            ToolTipText     =   "Alien Roof Vent"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRoof558 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   199
            TabStop         =   0   'False
            ToolTipText     =   "No Roof Vent"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods558 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   3
         Left            =   1635
         TabIndex        =   194
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB558 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   197
            TabStop         =   0   'False
            Tag             =   "48D"
            ToolTipText     =   "X-Flow Front Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optFB558 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   196
            TabStop         =   0   'False
            Tag             =   "48E"
            ToolTipText     =   "Alien Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB558 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   195
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods558 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   190
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx558 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   193
            TabStop         =   0   'False
            Tag             =   "441"
            ToolTipText     =   "X-Flow Exhaust"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optEx558 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   192
            TabStop         =   0   'False
            Tag             =   "444"
            ToolTipText     =   "Alien Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx558 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   191
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
   Begin VB.Frame frameMods534 
      Caption         =   "Available Mods for Remington:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   214
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods534 
         Caption         =   "Side Skirt:"
         Height          =   1290
         Index           =   4
         Left            =   1665
         TabIndex        =   232
         Top             =   270
         Width           =   1545
         Begin VB.OptionButton optSkirt534 
            Caption         =   "Chr. Arches"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   235
            TabStop         =   0   'False
            Tag             =   "452"
            ToolTipText     =   "Chromer Arches"
            Top             =   870
            Width           =   1320
         End
         Begin VB.OptionButton optSkirt534 
            Caption         =   "Chr. Flames"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   234
            TabStop         =   0   'False
            Tag             =   "462"
            ToolTipText     =   "Chromer Flames"
            Top             =   570
            Width           =   1320
         End
         Begin VB.OptionButton optSkirt534 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   233
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirts"
            Top             =   270
            Value           =   -1  'True
            Width           =   1320
         End
      End
      Begin VB.Frame frameMods534 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   3
         Left            =   120
         TabIndex        =   228
         Top             =   2850
         Width           =   1575
         Begin VB.OptionButton optRB534 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   231
            TabStop         =   0   'False
            Tag             =   "49A"
            ToolTipText     =   "Slamin Rear Bumpers"
            Top             =   870
            Width           =   1320
         End
         Begin VB.OptionButton optRB534 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   230
            TabStop         =   0   'False
            Tag             =   "49C"
            ToolTipText     =   "Chromer Rear Bumpers"
            Top             =   570
            Width           =   1320
         End
         Begin VB.OptionButton optRB534 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   229
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumpers"
            Top             =   270
            Value           =   -1  'True
            Width           =   1320
         End
      End
      Begin VB.Frame frameMods534 
         Caption         =   "Misc:"
         Height          =   2595
         Index           =   5
         Left            =   1665
         TabIndex        =   223
         Top             =   1560
         Width           =   1545
         Begin VB.OptionButton optMisc534 
            Caption         =   "Chr. Lights"
            Height          =   300
            Index           =   3
            Left            =   120
            TabIndex        =   227
            TabStop         =   0   'False
            Tag             =   "465"
            ToolTipText     =   "Chrome Lights"
            Top             =   1170
            Width           =   1320
         End
         Begin VB.OptionButton optMisc534 
            Caption         =   "Chrome Bars"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   226
            TabStop         =   0   'False
            Tag             =   "463"
            ToolTipText     =   "Chrome Bars"
            Top             =   870
            Width           =   1320
         End
         Begin VB.OptionButton optMisc534 
            Caption         =   "Chrome Grill"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   225
            TabStop         =   0   'False
            Tag             =   "44C"
            ToolTipText     =   "Chrome Grill"
            Top             =   570
            Width           =   1320
         End
         Begin VB.OptionButton optMisc534 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   224
            TabStop         =   0   'False
            ToolTipText     =   "No Misc. "
            Top             =   270
            Value           =   -1  'True
            Width           =   1320
         End
      End
      Begin VB.Frame frameMods534 
         Caption         =   "Front Bumper:"
         Height          =   1290
         Index           =   2
         Left            =   120
         TabIndex        =   219
         Top             =   1560
         Width           =   1575
         Begin VB.OptionButton optFB534 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   222
            TabStop         =   0   'False
            Tag             =   "4A1"
            ToolTipText     =   "Slamin Front Bumpers"
            Top             =   870
            Width           =   1320
         End
         Begin VB.OptionButton optFB534 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   221
            TabStop         =   0   'False
            Tag             =   "49B"
            ToolTipText     =   "Chromer Front Bumpers"
            Top             =   570
            Width           =   1320
         End
         Begin VB.OptionButton optFB534 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   220
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumpers"
            Top             =   270
            Value           =   -1  'True
            Width           =   1320
         End
      End
      Begin VB.Frame frameMods534 
         Caption         =   "Exhaust:"
         Height          =   1290
         Index           =   1
         Left            =   120
         TabIndex        =   215
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx534 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   218
            TabStop         =   0   'False
            Tag             =   "467"
            ToolTipText     =   "Slamin Exhaust"
            Top             =   870
            Width           =   1320
         End
         Begin VB.OptionButton optEx534 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   217
            TabStop         =   0   'False
            Tag             =   "466"
            ToolTipText     =   "Chromer Exhaust"
            Top             =   570
            Width           =   1320
         End
         Begin VB.OptionButton optEx534 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   216
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1320
         End
      End
   End
   Begin VB.CommandButton cmdMods 
      Cancel          =   -1  'True
      Caption         =   "Cancel"
      Height          =   420
      Index           =   1
      Left            =   3825
      TabIndex        =   63
      Top             =   5070
      Width           =   3675
   End
   Begin VB.CommandButton cmdMods 
      Caption         =   "OK"
      Default         =   -1  'True
      Height          =   420
      Index           =   0
      Left            =   120
      TabIndex        =   62
      Top             =   5070
      Width           =   3675
   End
   Begin VB.Frame frameMods535 
      Caption         =   "Available Mods for Slamvan:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   236
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.CheckBox chkFB535 
         Caption         =   "Chromer Front Bumper"
         Height          =   420
         Left            =   255
         TabIndex        =   253
         TabStop         =   0   'False
         Tag             =   "45D"
         ToolTipText     =   "Chromer Front Bumper"
         Top             =   2985
         Width           =   2100
      End
      Begin VB.Frame frameMods535 
         Caption         =   "Rear Bullbas"
         Height          =   1305
         Index           =   4
         Left            =   1665
         TabIndex        =   249
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optRB535 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   252
            TabStop         =   0   'False
            Tag             =   "456"
            ToolTipText     =   "Slamin Rear Bullbar"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRB535 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   251
            TabStop         =   0   'False
            Tag             =   "455"
            ToolTipText     =   "Chromer Rear Bullbar"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB535 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   250
            TabStop         =   0   'False
            ToolTipText     =   "No Rear Bullbars"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods535 
         Caption         =   "Side Skirt:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   245
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optSkirt535 
            Caption         =   "Wheelcovers"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   248
            TabStop         =   0   'False
            Tag             =   "45F"
            ToolTipText     =   "Wheelcovers"
            Top             =   870
            Width           =   1275
         End
         Begin VB.OptionButton optSkirt535 
            Caption         =   "Chr. Trims"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   247
            TabStop         =   0   'False
            Tag             =   "45E"
            ToolTipText     =   "Chromer Trims"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt535 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   246
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirts"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods535 
         Caption         =   "Front Bullbar:"
         Height          =   1305
         Index           =   3
         Left            =   1635
         TabIndex        =   241
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB535 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   244
            TabStop         =   0   'False
            Tag             =   "45C"
            ToolTipText     =   "Slamin Front Bullbar"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optFB535 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   243
            TabStop         =   0   'False
            Tag             =   "45B"
            ToolTipText     =   "Chromer Front Bullbar"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB535 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   242
            TabStop         =   0   'False
            ToolTipText     =   "No Front Bullbars"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods535 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   237
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx535 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   240
            TabStop         =   0   'False
            Tag             =   "45A"
            ToolTipText     =   "Slamin Exhaust"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optEx535 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   239
            TabStop         =   0   'False
            Tag             =   "459"
            ToolTipText     =   "Chromer Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx535 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   238
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
   Begin VB.Frame frameMods536 
      Caption         =   "Available Mods for Blade:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   254
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods536 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   268
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx536 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   271
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optEx536 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   270
            TabStop         =   0   'False
            Tag             =   "450"
            ToolTipText     =   "Chromer Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx536 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   269
            TabStop         =   0   'False
            Tag             =   "451"
            ToolTipText     =   "Slamin Exhaust"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods536 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   3
         Left            =   1635
         TabIndex        =   264
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB536 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   267
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optFB536 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   266
            TabStop         =   0   'False
            Tag             =   "49E"
            ToolTipText     =   "Chromer Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB536 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   265
            TabStop         =   0   'False
            Tag             =   "49D"
            ToolTipText     =   "Slamin Front Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods536 
         Caption         =   "Roof:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   260
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optRoof536 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   263
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirts"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRoof536 
            Caption         =   "Vinly Hardtop"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   262
            TabStop         =   0   'False
            Tag             =   "468"
            ToolTipText     =   "Vinly Hardtop Roof"
            Top             =   570
            Width           =   1305
         End
         Begin VB.OptionButton optRoof536 
            Caption         =   "Convertible"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   261
            TabStop         =   0   'False
            Tag             =   "44F"
            ToolTipText     =   "Convertible Roof"
            Top             =   870
            Width           =   1275
         End
      End
      Begin VB.Frame frameMods536 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1665
         TabIndex        =   256
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optRB536 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   259
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRB536 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   258
            TabStop         =   0   'False
            Tag             =   "4A0"
            ToolTipText     =   "Chromer Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB536 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   257
            TabStop         =   0   'False
            Tag             =   "49F"
            ToolTipText     =   "Slamin Rear Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.CheckBox chkSkirt536 
         Caption         =   "Chromer Side Skirt"
         Height          =   420
         Left            =   255
         TabIndex        =   255
         TabStop         =   0   'False
         Tag             =   "454"
         ToolTipText     =   "Chromer Side Skirt"
         Top             =   2985
         Width           =   2100
      End
   End
   Begin VB.Frame frameMods567 
      Caption         =   "Available Mods for Savannah:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   272
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods567 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   286
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx567 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   289
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optEx567 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   288
            TabStop         =   0   'False
            Tag             =   "469"
            ToolTipText     =   "Chromer Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx567 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   287
            TabStop         =   0   'False
            Tag             =   "46C"
            ToolTipText     =   "Slamin Exhaust"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods567 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   3
         Left            =   1635
         TabIndex        =   282
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB567 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   285
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optFB567 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   284
            TabStop         =   0   'False
            Tag             =   "4A5"
            ToolTipText     =   "Chromer Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB567 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   283
            TabStop         =   0   'False
            Tag             =   "4A4"
            ToolTipText     =   "Slamin Front Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods567 
         Caption         =   "Roof:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   278
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optRoof567 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   281
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirts"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRoof567 
            Caption         =   "Hardtop"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   280
            TabStop         =   0   'False
            Tag             =   "46A"
            ToolTipText     =   "Hardtop Roof"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRoof567 
            Caption         =   "Softtop"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   279
            TabStop         =   0   'False
            Tag             =   "46B"
            ToolTipText     =   "Softtop Roof"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods567 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1665
         TabIndex        =   274
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optRB567 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   277
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRB567 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   276
            TabStop         =   0   'False
            Tag             =   "4A3"
            ToolTipText     =   "Chromer Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB567 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   275
            TabStop         =   0   'False
            Tag             =   "4A2"
            ToolTipText     =   "Slamin Rear Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.CheckBox chkSkirt567 
         Caption         =   "Chrome Strips"
         Height          =   420
         Left            =   165
         TabIndex        =   273
         TabStop         =   0   'False
         Tag             =   "46D"
         ToolTipText     =   "Chrome Strips"
         Top             =   2985
         Width           =   2190
      End
   End
   Begin VB.Frame frameMods576 
      Caption         =   "Available Mods for Tornado:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   290
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods576 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   300
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx576 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   303
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optEx576 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   302
            TabStop         =   0   'False
            Tag             =   "470"
            ToolTipText     =   "Chromer Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx576 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   301
            TabStop         =   0   'False
            Tag             =   "46F"
            ToolTipText     =   "Slamin Exhaust"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods576 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   296
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optFB576 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   299
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optFB576 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   298
            TabStop         =   0   'False
            Tag             =   "4A7"
            ToolTipText     =   "Chromer Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB576 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   297
            TabStop         =   0   'False
            Tag             =   "4A6"
            ToolTipText     =   "Slamin Front Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods576 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   3
         Left            =   1665
         TabIndex        =   292
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optRB576 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   295
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRB576 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   294
            TabStop         =   0   'False
            Tag             =   "4A8"
            ToolTipText     =   "Chromer Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB576 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   293
            TabStop         =   0   'False
            Tag             =   "4A9"
            ToolTipText     =   "Slamin Rear Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.CheckBox chkSkirt576 
         Caption         =   "Chrome Strips"
         Height          =   420
         Left            =   1800
         TabIndex        =   291
         TabStop         =   0   'False
         Tag             =   "46E"
         ToolTipText     =   "Chrome Strips"
         Top             =   1650
         Width           =   2100
      End
   End
   Begin VB.Frame frameMods575 
      Caption         =   "Available Mods for Broadway:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   304
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods575 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   314
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx575 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   317
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optEx575 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   316
            TabStop         =   0   'False
            Tag             =   "414"
            ToolTipText     =   "Chromer Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx575 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   315
            TabStop         =   0   'False
            Tag             =   "413"
            ToolTipText     =   "Slamin Exhaust"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods575 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   310
         Top             =   1650
         Width           =   1575
         Begin VB.OptionButton optFB575 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   313
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optFB575 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   312
            TabStop         =   0   'False
            Tag             =   "496"
            ToolTipText     =   "Chromer Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB575 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   311
            TabStop         =   0   'False
            Tag             =   "497"
            ToolTipText     =   "Slamin Front Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods575 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   3
         Left            =   1665
         TabIndex        =   306
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optRB575 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   309
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optRB575 
            Caption         =   "Chromer"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   308
            TabStop         =   0   'False
            Tag             =   "498"
            ToolTipText     =   "Chromer Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB575 
            Caption         =   "Slamin"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   307
            TabStop         =   0   'False
            Tag             =   "499"
            ToolTipText     =   "Slamin Rear Bumper"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.CheckBox chkSkirt575 
         Caption         =   "Chrome Strips"
         Height          =   420
         Left            =   1800
         TabIndex        =   305
         TabStop         =   0   'False
         Tag             =   "412"
         ToolTipText     =   "Chrome Strips"
         Top             =   1650
         Width           =   2100
      End
   End
   Begin VB.Frame frameMisc 
      Caption         =   "Miscellaneous:"
      Height          =   660
      Left            =   60
      TabIndex        =   19
      Top             =   4335
      Width           =   7500
      Begin VB.OptionButton optNitro 
         Caption         =   "No Nitro"
         Height          =   315
         Index           =   0
         Left            =   120
         TabIndex        =   25
         TabStop         =   0   'False
         Top             =   240
         Value           =   -1  'True
         Width           =   1020
      End
      Begin VB.OptionButton optNitro 
         Caption         =   "2 x Nitro"
         Height          =   315
         Index           =   1
         Left            =   1260
         TabIndex        =   24
         TabStop         =   0   'False
         Tag             =   "3F1"
         Top             =   240
         Width           =   1020
      End
      Begin VB.OptionButton optNitro 
         Caption         =   "5 x Nitro"
         Height          =   315
         Index           =   2
         Left            =   2400
         TabIndex        =   23
         TabStop         =   0   'False
         Tag             =   "3F0"
         Top             =   240
         Width           =   1020
      End
      Begin VB.OptionButton optNitro 
         Caption         =   "10 x Nitro"
         Height          =   315
         Index           =   3
         Left            =   3540
         TabIndex        =   22
         TabStop         =   0   'False
         Tag             =   "3F2"
         Top             =   240
         Width           =   1020
      End
      Begin VB.CheckBox chkHydraulics 
         Caption         =   "Hydraulics"
         Height          =   330
         Left            =   4770
         TabIndex        =   21
         TabStop         =   0   'False
         Tag             =   "43F"
         Top             =   240
         Width           =   1230
      End
      Begin VB.CheckBox chkStereo 
         Caption         =   "Bas Boost"
         Height          =   330
         Left            =   6000
         TabIndex        =   20
         TabStop         =   0   'False
         Tag             =   "43E"
         Top             =   240
         Width           =   1230
      End
   End
   Begin VB.Frame framePaintJobs 
      Caption         =   "Paint Jobs"
      Height          =   1200
      Left            =   4710
      TabIndex        =   318
      ToolTipText     =   $"frmMods.frx":0000
      Top             =   3135
      Width           =   2850
      Begin VB.OptionButton optPaintJobs 
         Caption         =   "Paintjob 4*"
         Height          =   300
         Index           =   4
         Left            =   1350
         TabIndex        =   323
         TabStop         =   0   'False
         ToolTipText     =   "Paint Job 4 (Please use only if you use a custom car with 1+4 skin packs)"
         Top             =   870
         Width           =   1230
      End
      Begin VB.OptionButton optPaintJobs 
         Caption         =   "Paintjob 3"
         Height          =   300
         Index           =   3
         Left            =   1350
         TabIndex        =   322
         TabStop         =   0   'False
         ToolTipText     =   "Paint Job 3"
         Top             =   570
         Width           =   1230
      End
      Begin VB.OptionButton optPaintJobs 
         Caption         =   "Paintjob 2"
         Height          =   300
         Index           =   2
         Left            =   120
         TabIndex        =   321
         TabStop         =   0   'False
         ToolTipText     =   "Paint Job 2"
         Top             =   870
         Width           =   1230
      End
      Begin VB.OptionButton optPaintJobs 
         Caption         =   "Paintjob 1"
         Height          =   300
         Index           =   1
         Left            =   120
         TabIndex        =   320
         TabStop         =   0   'False
         ToolTipText     =   "Paint Job 1"
         Top             =   570
         Width           =   1230
      End
      Begin VB.OptionButton optPaintJobs 
         Caption         =   "None"
         Height          =   300
         Index           =   0
         Left            =   120
         TabIndex        =   319
         TabStop         =   0   'False
         ToolTipText     =   "No Paint Job (Paint Jobs are available only for Street Racers and Lowriders)"
         Top             =   270
         Value           =   -1  'True
         Width           =   1230
      End
   End
   Begin VB.Frame frameWheels 
      Caption         =   "Wheels:"
      Height          =   3225
      Left            =   4710
      TabIndex        =   0
      Top             =   60
      Width           =   2850
      Begin VB.OptionButton optWheels 
         Caption         =   "Shadow"
         Height          =   315
         Index           =   17
         Left            =   1440
         TabIndex        =   18
         TabStop         =   0   'False
         Tag             =   "431"
         ToolTipText     =   "Street Racer Wheels"
         Top             =   2760
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Switch"
         Height          =   315
         Index           =   16
         Left            =   1440
         TabIndex        =   17
         TabStop         =   0   'False
         Tag             =   "438"
         ToolTipText     =   "Street Racer Wheels"
         Top             =   2445
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Groove"
         Height          =   315
         Index           =   15
         Left            =   1440
         TabIndex        =   16
         TabStop         =   0   'False
         Tag             =   "439"
         ToolTipText     =   "Street Racer Wheels"
         Top             =   2130
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Mega"
         Height          =   315
         Index           =   14
         Left            =   1440
         TabIndex        =   15
         TabStop         =   0   'False
         Tag             =   "432"
         ToolTipText     =   "Street Racer Wheels"
         Top             =   1815
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Rimshine"
         Height          =   315
         Index           =   13
         Left            =   1440
         TabIndex        =   14
         TabStop         =   0   'False
         Tag             =   "433"
         ToolTipText     =   "Street Racer Wheels"
         Top             =   1500
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Cutter"
         Height          =   315
         Index           =   12
         Left            =   1440
         TabIndex        =   13
         TabStop         =   0   'False
         Tag             =   "437"
         ToolTipText     =   "Street Racer Wheels"
         Top             =   1185
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Off-Road"
         Height          =   315
         Index           =   11
         Left            =   1440
         TabIndex        =   12
         TabStop         =   0   'False
         Tag             =   "401"
         ToolTipText     =   "Off-Road Wheels"
         Top             =   870
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Trance"
         Height          =   315
         Index           =   10
         Left            =   1440
         TabIndex        =   11
         TabStop         =   0   'False
         Tag             =   "43C"
         ToolTipText     =   "Lowrider Wheels"
         Top             =   555
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Wires"
         Height          =   315
         Index           =   9
         Left            =   1440
         TabIndex        =   10
         TabStop         =   0   'False
         Tag             =   "434"
         ToolTipText     =   "Lowrider Wheels"
         Top             =   240
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Twist"
         Height          =   315
         Index           =   8
         Left            =   120
         TabIndex        =   9
         TabStop         =   0   'False
         Tag             =   "436"
         ToolTipText     =   "Lowrider Wheels"
         Top             =   2760
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Dollar"
         Height          =   315
         Index           =   7
         Left            =   120
         TabIndex        =   8
         TabStop         =   0   'False
         Tag             =   "43B"
         ToolTipText     =   "Lowrider Wheels"
         Top             =   2445
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Classic"
         Height          =   315
         Index           =   6
         Left            =   120
         TabIndex        =   7
         TabStop         =   0   'False
         Tag             =   "435"
         ToolTipText     =   "Lowrider Wheels"
         Top             =   2130
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Access"
         Height          =   315
         Index           =   5
         Left            =   120
         TabIndex        =   6
         TabStop         =   0   'False
         Tag             =   "44A"
         ToolTipText     =   "Generic Wheels"
         Top             =   1815
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Virtual"
         Height          =   315
         Index           =   4
         Left            =   120
         TabIndex        =   5
         TabStop         =   0   'False
         Tag             =   "449"
         ToolTipText     =   "Generic Wheels"
         Top             =   1500
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Ahab"
         Height          =   315
         Index           =   3
         Left            =   120
         TabIndex        =   4
         TabStop         =   0   'False
         Tag             =   "448"
         ToolTipText     =   "Generic Wheels"
         Top             =   1185
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Atomic"
         Height          =   315
         Index           =   2
         Left            =   120
         TabIndex        =   3
         TabStop         =   0   'False
         Tag             =   "43D"
         ToolTipText     =   "Generic Wheels"
         Top             =   870
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Import"
         Height          =   315
         Index           =   1
         Left            =   120
         TabIndex        =   2
         TabStop         =   0   'False
         Tag             =   "43A"
         ToolTipText     =   "Generic Wheels"
         Top             =   555
         Width           =   1320
      End
      Begin VB.OptionButton optWheels 
         Caption         =   "Standard"
         Height          =   315
         Index           =   0
         Left            =   120
         TabIndex        =   1
         TabStop         =   0   'False
         ToolTipText     =   "Standard Wheels"
         Top             =   240
         Value           =   -1  'True
         Width           =   1320
      End
   End
   Begin VB.Frame frameMods565 
      Caption         =   "Available Mods for Flash:"
      Height          =   4275
      Index           =   0
      Left            =   60
      TabIndex        =   64
      Top             =   60
      Visible         =   0   'False
      Width           =   4680
      Begin VB.Frame frameMods565 
         Caption         =   "Side Skirt:"
         Height          =   1305
         Index           =   6
         Left            =   1665
         TabIndex        =   85
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSkirt565 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   88
            TabStop         =   0   'False
            ToolTipText     =   "No Side Skirt"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt565 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   87
            TabStop         =   0   'False
            Tag             =   "417"
            ToolTipText     =   "Alien Side Skirt"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSkirt565 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   86
            TabStop         =   0   'False
            Tag             =   "418"
            ToolTipText     =   "X-Flow Side Skirt"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods565 
         Caption         =   "Spoiler:"
         Height          =   1305
         Index           =   3
         Left            =   120
         TabIndex        =   81
         Top             =   2910
         Width           =   1575
         Begin VB.OptionButton optSpoiler565 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   84
            TabStop         =   0   'False
            ToolTipText     =   "No Spoiler"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler565 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   83
            TabStop         =   0   'False
            Tag             =   "419"
            ToolTipText     =   "Alien Spoiler"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optSpoiler565 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   82
            TabStop         =   0   'False
            Tag             =   "41A"
            ToolTipText     =   "X-Flow Spoiler"
            Top             =   870
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods565 
         Caption         =   "Rear Bumper:"
         Height          =   1305
         Index           =   5
         Left            =   1665
         TabIndex        =   77
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRB565 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   80
            TabStop         =   0   'False
            Tag             =   "47F"
            ToolTipText     =   "X-Flow Rear Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRB565 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   79
            TabStop         =   0   'False
            Tag             =   "47E"
            ToolTipText     =   "Alien Rear Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRB565 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   78
            TabStop         =   0   'False
            ToolTipText     =   "Standard Rear Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods565 
         Caption         =   "Roof Vent:"
         Height          =   1305
         Index           =   2
         Left            =   120
         TabIndex        =   73
         Top             =   1590
         Width           =   1575
         Begin VB.OptionButton optRoof565 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   76
            TabStop         =   0   'False
            Tag             =   "41D"
            ToolTipText     =   "X-Flow Roof Vent"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optRoof565 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   75
            TabStop         =   0   'False
            Tag             =   "41E"
            ToolTipText     =   "Alien Roof Vent"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optRoof565 
            Caption         =   "None"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   74
            TabStop         =   0   'False
            ToolTipText     =   "No Roof Vent"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods565 
         Caption         =   "Front Bumper:"
         Height          =   1305
         Index           =   4
         Left            =   1635
         TabIndex        =   69
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optFB565 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   72
            TabStop         =   0   'False
            Tag             =   "480"
            ToolTipText     =   "X-Flow Front Bumper"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optFB565 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   71
            TabStop         =   0   'False
            Tag             =   "481"
            ToolTipText     =   "Alien Front Bumper"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optFB565 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   70
            TabStop         =   0   'False
            ToolTipText     =   "Standard Front Bumper"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
      Begin VB.Frame frameMods565 
         Caption         =   "Exhaust:"
         Height          =   1305
         Index           =   1
         Left            =   120
         TabIndex        =   65
         Top             =   270
         Width           =   1575
         Begin VB.OptionButton optEx565 
            Caption         =   "X-Flow"
            Height          =   300
            Index           =   2
            Left            =   120
            TabIndex        =   68
            TabStop         =   0   'False
            Tag             =   "415"
            ToolTipText     =   "X-Flow Exhaust"
            Top             =   870
            Width           =   1230
         End
         Begin VB.OptionButton optEx565 
            Caption         =   "Alien"
            Height          =   300
            Index           =   1
            Left            =   120
            TabIndex        =   67
            TabStop         =   0   'False
            Tag             =   "416"
            ToolTipText     =   "Alien Exhaust"
            Top             =   570
            Width           =   1230
         End
         Begin VB.OptionButton optEx565 
            Caption         =   "Standard"
            Height          =   300
            Index           =   0
            Left            =   120
            TabIndex        =   66
            TabStop         =   0   'False
            ToolTipText     =   "Standard Exhaust"
            Top             =   270
            Value           =   -1  'True
            Width           =   1230
         End
      End
   End
End
Attribute VB_Name = "frmMods"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public isOKClicked As Boolean
Private oCtl As Control ' VB.OptionButton
Private iModCtr As Integer

Private Sub cmdMods_Click(Index As Integer)
On Error Resume Next
    isOKClicked = (Index = 0)
    Me.Hide
End Sub

Private Sub Form_Load()
On Error Resume Next
    isOKClicked = False
End Sub

Public Function DecodeMods(ByVal CarID As Integer, _
                           ByRef ModsArr() As Integer, _
                           ByVal sAvailableMods As String, _
                           ByVal bPaintJobs As Byte) As Boolean
On Error GoTo errDecodeMods
    Dim sUsedMods As String
    DecodeMods = False
    sAvailableMods = ";;" & sAvailableMods & ";"
    For iModCtr = 0 To 6
        sUsedMods = sUsedMods & ";" & Format(UCase(Hex(ModsArr(iModCtr))), "000")
    Next iModCtr
    sUsedMods = ";" & sUsedMods & ";"
    'Mod Selection Frames (by default, all are invisible)
    Select Case CarID
        Case 534: frameMods534(0).Visible = True 'remingtn
        Case 535: frameMods535(0).Visible = True 'slamvan
        Case 536: frameMods536(0).Visible = True 'blade
        Case 558: frameMods558(0).Visible = True 'uranus
        Case 559: frameMods559(0).Visible = True 'jester
        Case 560: frameMods560(0).Visible = True 'sultan
        Case 561: frameMods561(0).Visible = True 'stratum
        Case 562: frameMods562(0).Visible = True 'elegy
        Case 565: frameMods565(0).Visible = True 'flash
        Case 567: frameMods567(0).Visible = True 'savanna
        Case 575: frameMods575(0).Visible = True 'broadway
        Case 576: frameMods576(0).Visible = True 'tornado
        Case Else: frameModsGen(0).Visible = True 'generic cars
    End Select
    'Paint jobs:
    Select Case bPaintJobs
        Case 0: optPaintJobs(1).Value = True
        Case 1: optPaintJobs(2).Value = True
        Case 2: optPaintJobs(3).Value = True
        Case 3: optPaintJobs(4).Value = True
        Case Else: optPaintJobs(0).Value = True
    End Select
    'All other values:
    For Each oCtl In Me.Controls
        If TypeOf oCtl Is VB.OptionButton Then
            If Len(oCtl.Tag) > 0 Then
                If InStr(sAvailableMods, ";" & oCtl.Tag & ";") > 0 Then
                    'this option is available for this car. so set enable:
                    oCtl.Enabled = True
                    'also check if it has been used:
                    If InStr(sUsedMods, ";" & oCtl.Tag & ";") > 0 Then oCtl.Value = True
                End If
            End If
        ElseIf TypeOf oCtl Is VB.CheckBox Then
            If Len(oCtl.Tag) > 0 Then
                If InStr(sAvailableMods, ";" & oCtl.Tag & ";") > 0 Then
                    'this option is available for this car. so set enable:
                    oCtl.Enabled = True
                    'also check if it has been used:
                    If InStr(sUsedMods, ";" & oCtl.Tag & ";") > 0 Then oCtl.Value = vbChecked
                End If
            End If
        End If
    Next
    DecodeMods = True
Exit Function
errDecodeMods:
    MsgBox Err.Description, vbCritical, "Error during Mod decoding."
    Err.Clear
End Function

Public Function EncodeMods(ByRef ModsArr() As Integer, _
                           ByRef bPaintJobs As Byte) As Boolean
On Error GoTo errEncodeMods
    EncodeMods = False
    'Paint jobs:
    If optPaintJobs(0).Value Then
        bPaintJobs = &HFF
    ElseIf optPaintJobs(1).Value Then
        bPaintJobs = 0
    ElseIf optPaintJobs(2).Value Then
        bPaintJobs = 1
    ElseIf optPaintJobs(3).Value Then
        bPaintJobs = 2
    Else 'If optPaintJobs(4).Value Then
        bPaintJobs = 3
    End If
    'All other values:
    iModCtr = 0 'starting with the 0 as index
    For Each oCtl In Me.Controls
        If TypeOf oCtl Is VB.OptionButton Then
            If Len(oCtl.Tag) > 0 Then
                If oCtl.Enabled Then
                    'this option was available for this car. so check value:
                    If oCtl.Value Then
                        'if it has been checked, assign to mods
                        ModsArr(iModCtr) = CInt("&H0" & oCtl.Tag)
                        'and increase mod counter:
                        iModCtr = iModCtr + 1
                    End If
                End If
            End If
        ElseIf TypeOf oCtl Is VB.CheckBox Then
            If Len(oCtl.Tag) > 0 Then
                If oCtl.Enabled Then
                    'this option was available for this car. so check if it is used or not:
                    If oCtl.Value = vbChecked Then
                        'if it has been checked, assign to mods:
                        ModsArr(iModCtr) = CInt("&H0" & oCtl.Tag)
                        'and increase mod counter:
                        iModCtr = iModCtr + 1
                    End If
                End If
            End If
        End If
    Next
    'now check the mod counter, to fill the rest with &HFFFF as appropriate:
    Do Until iModCtr > 14
        ModsArr(iModCtr) = -1
        iModCtr = iModCtr + 1
    Loop
    EncodeMods = True
Exit Function
errEncodeMods:
    MsgBox Err.Description, vbCritical, "Error during Mod encoding"
    Err.Clear
End Function
