VERSION 5.00
Begin VB.Form dlgSettings 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "vbWoW Control Center :: Settings"
   ClientHeight    =   6180
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   9480
   Icon            =   "dlgSettings.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6180
   ScaleWidth      =   9480
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton Command22 
      Caption         =   "Cancel"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   5040
      TabIndex        =   47
      Top             =   5640
      Width           =   1575
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1695
      Left            =   4800
      TabIndex        =   68
      Top             =   3720
      Width           =   4575
      Begin VB.Image Image1 
         Height          =   750
         Left            =   720
         Picture         =   "dlgSettings.frx":1708A
         Top             =   360
         Width           =   3000
      End
      Begin VB.Label Label17 
         BackStyle       =   0  'Transparent
         Caption         =   "Control Center :: Settings and Configuration Manager"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   600
         TabIndex        =   69
         Top             =   1200
         Width           =   3375
      End
   End
   Begin VB.CommandButton Command20 
      Caption         =   "Save"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   3360
      TabIndex        =   46
      Top             =   5640
      Width           =   1575
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Realm server:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3615
      Left            =   4800
      TabIndex        =   59
      Top             =   120
      Width           =   4575
      Begin VB.CheckBox Check6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Oracle"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   2880
         TabIndex        =   45
         Top             =   3240
         Width           =   855
      End
      Begin VB.CommandButton Command14 
         Caption         =   "H"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3840
         TabIndex        =   48
         Top             =   2400
         Width           =   255
      End
      Begin VB.TextBox Text20 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   28
         Text            =   "127.0.0.1"
         Top             =   360
         Width           =   1815
      End
      Begin VB.CommandButton Command24 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   29
         Top             =   360
         Width           =   255
      End
      Begin VB.TextBox Text19 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   30
         Text            =   "3724"
         Top             =   720
         Width           =   735
      End
      Begin VB.CommandButton Command23 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   31
         Top             =   720
         Width           =   255
      End
      Begin VB.TextBox Text15 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   32
         Text            =   "127.0.0.1"
         Top             =   1320
         Width           =   1815
      End
      Begin VB.CommandButton Command19 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   33
         Top             =   1320
         Width           =   255
      End
      Begin VB.CommandButton Command18 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   35
         Top             =   1680
         Width           =   255
      End
      Begin VB.TextBox Text14 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   34
         Text            =   "3306"
         Top             =   1680
         Width           =   735
      End
      Begin VB.TextBox Text13 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         IMEMode         =   3  'DISABLE
         Left            =   2280
         PasswordChar    =   "*"
         TabIndex        =   38
         Text            =   "admin"
         Top             =   2400
         Width           =   1215
      End
      Begin VB.CommandButton Command17 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   40
         Top             =   2400
         Width           =   255
      End
      Begin VB.CommandButton Command16 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   37
         Top             =   2040
         Width           =   255
      End
      Begin VB.TextBox Text12 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   36
         Text            =   "root"
         Top             =   2040
         Width           =   1215
      End
      Begin VB.CommandButton Command15 
         Caption         =   "S"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3840
         TabIndex        =   39
         Top             =   2400
         Width           =   255
      End
      Begin VB.TextBox Text11 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   41
         Text            =   "vbwow"
         Top             =   2760
         Width           =   1215
      End
      Begin VB.CommandButton Command13 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   42
         Top             =   2760
         Width           =   255
      End
      Begin VB.CheckBox Check4 
         BackColor       =   &H00FFFFFF&
         Caption         =   "MySQL"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   840
         TabIndex        =   43
         Top             =   3240
         Width           =   855
      End
      Begin VB.CheckBox Check3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "MS SQL"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   1800
         TabIndex        =   44
         Top             =   3240
         Width           =   1095
      End
      Begin VB.Label Label20 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Realm server host (IP/DNS):"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   66
         Top             =   360
         Width           =   2175
      End
      Begin VB.Label Label19 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Realm server port:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   65
         Top             =   720
         Width           =   1455
      End
      Begin VB.Line Line4 
         BorderColor     =   &H00808080&
         X1              =   120
         X2              =   4320
         Y1              =   1200
         Y2              =   1200
      End
      Begin VB.Label Label15 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL host (IP/DNS):"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   64
         Top             =   1320
         Width           =   2415
      End
      Begin VB.Label Label14 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL port:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   63
         Top             =   1680
         Width           =   2415
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL password:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   62
         Top             =   2400
         Width           =   2415
      End
      Begin VB.Label Label12 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL username:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   61
         Top             =   2040
         Width           =   2415
      End
      Begin VB.Label Label11 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL database:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   60
         Top             =   2760
         Width           =   2415
      End
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "World server:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5295
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   4575
      Begin VB.CheckBox Check5 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Oracle"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   3120
         TabIndex        =   27
         Top             =   4920
         Width           =   855
      End
      Begin VB.TextBox Text16 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   7
         Text            =   "1.0"
         Top             =   1680
         Width           =   375
      End
      Begin VB.CommandButton Command21 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   8
         Top             =   1680
         Width           =   255
      End
      Begin VB.CheckBox Check2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "MS SQL"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   1800
         TabIndex        =   26
         Top             =   4920
         Width           =   975
      End
      Begin VB.CheckBox Check1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "MySQL"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   600
         TabIndex        =   25
         Top             =   4920
         Width           =   855
      End
      Begin VB.CommandButton Command12 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   24
         Top             =   4440
         Width           =   255
      End
      Begin VB.TextBox Text10 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   23
         Text            =   "vbwow"
         Top             =   4440
         Width           =   1215
      End
      Begin VB.CommandButton Command11 
         Caption         =   "H"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3840
         TabIndex        =   21
         Top             =   4080
         Width           =   255
      End
      Begin VB.CommandButton Command10 
         Caption         =   "S"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3840
         TabIndex        =   20
         Top             =   4080
         Width           =   255
      End
      Begin VB.TextBox Text9 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   17
         Text            =   "root"
         Top             =   3720
         Width           =   1215
      End
      Begin VB.CommandButton Command9 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   18
         Top             =   3720
         Width           =   255
      End
      Begin VB.CommandButton Command8 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   22
         Top             =   4080
         Width           =   255
      End
      Begin VB.TextBox Text8 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         IMEMode         =   3  'DISABLE
         Left            =   2280
         PasswordChar    =   "*"
         TabIndex        =   19
         Text            =   "admin"
         Top             =   4080
         Width           =   1215
      End
      Begin VB.TextBox Text7 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   15
         Text            =   "3306"
         Top             =   3360
         Width           =   735
      End
      Begin VB.CommandButton Command7 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   16
         Top             =   3360
         Width           =   255
      End
      Begin VB.CommandButton Command6 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   14
         Top             =   3000
         Width           =   255
      End
      Begin VB.TextBox Text6 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   13
         Text            =   "127.0.0.1"
         Top             =   3000
         Width           =   1815
      End
      Begin VB.CommandButton Command5 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   12
         Top             =   2400
         Width           =   255
      End
      Begin VB.TextBox Text5 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   11
         Text            =   "1.0"
         Top             =   2400
         Width           =   375
      End
      Begin VB.CommandButton Command4 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   10
         Top             =   2040
         Width           =   255
      End
      Begin VB.TextBox Text4 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   9
         Text            =   "1.0"
         Top             =   2040
         Width           =   375
      End
      Begin VB.CommandButton Command3 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   6
         Top             =   1320
         Width           =   255
      End
      Begin VB.TextBox Text3 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   5
         Text            =   "100"
         Top             =   1320
         Width           =   735
      End
      Begin VB.CommandButton Command2 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   4
         Top             =   720
         Width           =   255
      End
      Begin VB.TextBox Text2 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   3
         Text            =   "8085"
         Top             =   720
         Width           =   735
      End
      Begin VB.CommandButton Command1 
         Caption         =   "?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4200
         TabIndex        =   2
         Top             =   360
         Width           =   255
      End
      Begin VB.TextBox Text1 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   2280
         TabIndex        =   1
         Text            =   "127.0.0.1"
         Top             =   360
         Width           =   1815
      End
      Begin VB.Label Label16 
         BackColor       =   &H00FFFFFF&
         Caption         =   "XP rate:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   67
         Top             =   1680
         Width           =   2415
      End
      Begin VB.Label Label10 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL database:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   58
         Top             =   4440
         Width           =   2415
      End
      Begin VB.Label Label9 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL username:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   57
         Top             =   3720
         Width           =   2415
      End
      Begin VB.Label Label8 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL password:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   56
         Top             =   4080
         Width           =   2415
      End
      Begin VB.Label Label7 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL port:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   55
         Top             =   3360
         Width           =   2415
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "SQL host (IP/DNS):"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   54
         Top             =   3000
         Width           =   2415
      End
      Begin VB.Line Line2 
         BorderColor     =   &H00808080&
         X1              =   120
         X2              =   4320
         Y1              =   2880
         Y2              =   2880
      End
      Begin VB.Label Label5 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Mana regeneration rate:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   53
         Top             =   2400
         Width           =   2415
      End
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Health regeneration rate:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   52
         Top             =   2040
         Width           =   2415
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00808080&
         X1              =   120
         X2              =   4320
         Y1              =   1200
         Y2              =   1200
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Player limit:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   51
         Top             =   1320
         Width           =   1455
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "World server port:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   50
         Top             =   720
         Width           =   1455
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "World server host (IP/DNS):"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   49
         Top             =   360
         Width           =   2175
      End
   End
End
Attribute VB_Name = "dlgSettings"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
' Copyright (C) 2005-2007 vbWoW <http://www.vbwow.org/>
'
' This program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'

Private Sub Command1_Click()
MsgBox ("The world server host is where users will connect after successfully logging in. The 'world server host' textbox can be an IP (i.e. 127.0.0.1) or a DNS (i.e. server.vbwow.org)."), vbInformation
End Sub
Private Sub Command10_Click()
If MsgBox("Do you want to show the SQL password?", vbYesNo + vbExclamation, "vbWoW Control Center") = vbYes Then
Text8.PasswordChar = ""
Command10.Visible = False
Command11.Visible = True
Else
End If
End Sub
Private Sub Command11_Click()
If MsgBox("Do you want to hide the SQL password?", vbYesNo + vbExclamation, "vbWoW Control Center") = vbYes Then
Text8.PasswordChar = "*"
Command10.Visible = True
Command11.Visible = False
Else
End If
End Sub
Private Sub Command12_Click()
MsgBox ("The SQL database that holds all server information (characters, accounts, etc...). Default value is vbwow."), vbInformation
End Sub
Private Sub Command13_Click()
MsgBox ("The SQL database that holds all server information (characters, accounts, etc...). Default value is vbwow."), vbInformation
End Sub
Private Sub Command15_Click()
If MsgBox("Do you want to show the SQL password?", vbYesNo + vbExclamation, "vbWoW Control Center") = vbYes Then
Text13.PasswordChar = ""
Command15.Visible = False
Command14.Visible = True
Else
End If
End Sub
Private Sub Command14_Click()
If MsgBox("Do you want to hide the SQL password?", vbYesNo + vbExclamation, "vbWoW Control Center") = vbYes Then
Text13.PasswordChar = "*"
Command14.Visible = False
Command15.Visible = True
Else
End If
End Sub
Private Sub Command16_Click()
MsgBox ("The SQL username that is required to access your SQL server. Default value is root."), vbInformation
End Sub
Private Sub Command17_Click()
MsgBox ("The SQL password that is required to access your SQL server."), vbInformation
End Sub
Private Sub Command18_Click()
MsgBox ("The port number that the sql server will listen on. Default port is 3306."), vbInformation
End Sub
Private Sub Command19_Click()
MsgBox ("The sql host is where the server will connect to the database. The 'sql host' textbox can be an IP (i.e. 127.0.0.1) or a DNS (i.e. database.vbwow.org)."), vbInformation
End Sub
Private Sub Command2_Click()
MsgBox ("The port number that the world server will listen on to accept connections. Default port is 3124."), vbInformation
End Sub
Private Sub Command20_Click()
' Writing to OFFICIAL Configuration Files
Open "vbWoW.WorldServer.xml" For Output As #1
Print #1, "<?xml version='1.0' encoding='utf-8'?>"
Print #1, "<WorldServer xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"
Print #1, "<WSPort>"; Text2.Text; "</WSPort>"
Print #1, "<WSHost>"; Text1.Text; "</WSHost>"
Print #1, "<ServerLimit>"; Text3.Text; "</ServerLimit>"
Print #1, "<XPRate>"; Text16.Text; "</XPRate>"
Print #1, "<ManaRegenerationRate>"; Text5.Text; "</ManaRegenerationRate>"
Print #1, "<HealthRegenerationRate>"; Text4.Text; "</HealthRegenerationRate>"
Print #1, "<GlobalAuction>false</GlobalAuction>"
Print #1, "<LogType>COLORCONSOLE</LogType>"
Print #1, "<LogLevel>NETWORK</LogLevel>"
Print #1, "<LogConfig>emupedia.com:6667:aLogBot:#test</LogConfig>"
Print #1, "<SQLUser>"; Text9.Text; "</SQLUser>"
Print #1, "<SQLPass>"; Text8.Text; "</SQLPass>"
Print #1, "<SQLHost>"; Text6.Text; "</SQLHost>"
Print #1, "<SQLPort>"; Text7.Text; "</SQLPort>"
Print #1, "<SQLDBName>"; Text10.Text; "</SQLDBName>"
If Check1.Value = 1 Then
Print #1, "<SQLDBType>MySQL</SQLDBType>"
Else
If Check2.Value = 1 Then
Print #1, "<SQLDBType>MSSQL</SQLDBType>"
Else
If Check5.Value = 1 Then
Print #1, "<SQLDBType>Oracle</SQLDBType>"
Else
End If
End If
End If
Print #1, "<ScriptsCompiler>"
Print #1, "<Include>System.dll</Include>"
Print #1, "<Include>System.Data.dll</Include>"
Print #1, "<Include>Microsoft.VisualBasic.dll</Include>"
Print #1, "<Include>vbWoW.Filebase.dll</Include>"
Print #1, "<Include>vbWoW.Database.dll</Include>"
Print #1, "<Include>vbWoW.Logbase.dll</Include>"
Print #1, "</ScriptsCompiler>"
Print #1, "</WorldServer>"
Close #1

Open "vbWoW.RealmServer.xml" For Output As #2
Print #2, "<RealmServer xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"
Print #2, "<RSPort>"; Text19.Text; "</RSPort>"
Print #2, "<RSHost>"; Text20.Text; "</RSHost>"
Print #2, "<SQLUser>"; Text12.Text; "</SQLUser>"
Print #2, "<SQLPass>"; Text13.Text; "</SQLPass>"
Print #2, "<SQLHost>"; Text15.Text; "</SQLHost>"
Print #2, "<SQLPort>"; Text14.Text; "</SQLPort>"
Print #2, "<SQLDBName>"; Text11.Text; "</SQLDBName>"
If Check4.Value = 1 Then
Print #2, "<SQLDBType>MySQL</SQLDBType>"
Else
If Check3.Value = 1 Then
Print #2, "<SQLDBType>MSSQL</SQLDBType>"
Else
If Check6.Value = 1 Then
Print #1, "<SQLDBType>Oracle</SQLDBType>"
Else
End If
End If
End If
Print #2, "<AutoAccountCreate>false</AutoAccountCreate>"
Print #2, "</RealmServer>"
Close #2
' End writing
Open "vbWoW-cc.ini" For Output As #3
Print #3, Text1.Text
Print #3, Text2.Text
Print #3, Text3.Text
Print #3, Text16.Text
Print #3, Text4.Text
Print #3, Text5.Text
Print #3, Text6.Text
Print #3, Text7.Text
Print #3, Text9.Text
Print #3, Text8.Text
Print #3, Text10.Text
Print #3, Text20.Text
Print #3, Text19.Text
Print #3, Text15.Text
Print #3, Text14.Text
Print #3, Text12.Text
Print #3, Text13.Text
Print #3, Text11.Text
Close #3
MsgBox ("Settings saved and necessary files updated!"), vbExclamation
End Sub
Private Sub Command21_Click()
MsgBox ("The 'xp rate' textbox designates how much experience a user will gain after killing a creature, and completing a quest. Default value is 1.0."), vbInformation
End Sub
Private Sub Command22_Click()
Main.Show
Unload Me
End Sub
Private Sub Command23_Click()
MsgBox ("The port number that the realm server will listen on to accept connections. Default port is 3125."), vbInformation
End Sub
Private Sub Command24_Click()
MsgBox ("The realm server host is where users will attempt to connect before entering the world server. The 'realm server host' textbox can be an IP (i.e. 127.0.0.1) or a DNS (i.e. server.vbwow.org)."), vbInformation
End Sub
Private Sub Command3_Click()
MsgBox ("The 'player limit' textbox allows the server administrator to designate how many players can log in to the world server at a designated time. Default value is 100."), vbInformation
End Sub
Private Sub Command4_Click()
MsgBox ("The 'health regeneration rate' textbox allows the administrator to specify how fast health regenerates. Default value is 1.0."), vbInformation
End Sub
Private Sub Command5_Click()
MsgBox ("The 'mana regeneration rate' textbox allows the administrator to specify how fast mana regenerates. Default value is 1.0."), vbInformation
End Sub
Private Sub Command6_Click()
MsgBox ("The sql host is where the server will connect to the database. The 'sql host' textbox can be an IP (i.e. 127.0.0.1) or a DNS (i.e. database.vbwow.org)."), vbInformation
End Sub
Private Sub Command7_Click()
MsgBox ("The port number that the sql server will listen on. Default port is 3306."), vbInformation
End Sub
Private Sub Command8_Click()
MsgBox ("The SQL password that is required to access your SQL server."), vbInformation
End Sub
Private Sub Command9_Click()
MsgBox ("The SQL username that is required to access your SQL server. Default value is root."), vbInformation
End Sub
Private Sub Form_Load()
If FileExists("vbWoW-cc.ini") = True Then
Else
Dim start1() As Byte
start1 = LoadResData(101, "CUSTOM")
Open "vbWoW-cc.ini" For Binary As #1
Put #1, , start1
Close #1
End If
Dim WSHOST As String
Dim WSPORT As String
Dim PlayerLimit As String
Dim XPRate As String
Dim HPRegenerationRate As String
Dim MANARegenerationRate As String
Dim SQLHOST As String
Dim SQLPORT As String
Dim SQLUsername As String
Dim SQLPassword
Dim SQLDB As String
Dim RSHOST As String
Dim RSPORT As String
Dim SQLHOST2 As String
Dim SQLPORT2 As String
Dim SQLUsername2 As String
Dim SQLPassword2 As String
Dim SQLDB2 As String

Open "vbWoW-cc.ini" For Input As #3
Input #3, WSHOST
Text1.Text = WSHOST
Input #3, WSPORT
Text2.Text = WSPORT
Input #3, PlayerLimit
Text3.Text = PlayerLimit
Input #3, XPRate
Text16.Text = XPRate
Input #3, HPRegenerationRate
Text4.Text = HPRegenerationRate
Input #3, MANARegenerationRate
Text5.Text = MANARegenerationRate
Input #3, SQLHOST
Text6.Text = SQLHOST
Input #3, SQLPORT
Text7.Text = SQLPORT
Input #3, SQLUsername
Text9.Text = SQLUsername
Input #3, SQLPassword
Text8.Text = SQLPassword
Input #3, SQLDB
Text10.Text = SQLDB
Input #3, RSHOST
Text20.Text = RSHOST
Input #3, RSPORT
Text19.Text = RSPORT
Input #3, SQLHOST2
Text15.Text = SQLHOST2
Input #3, SQLPORT2
Text14.Text = SQLPORT2
Input #3, SQLUsername2
Text12.Text = SQLUsername2
Input #3, SQLPassword2
Text13.Text = SQLPassword2
Input #3, SQLDB2
Text11.Text = SQLDB2
Close #3

Command11.Visible = False
Command14.Visible = False
End Sub
