VERSION 5.00
Begin VB.Form frmSplash 
   BackColor       =   &H00000000&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   3735
   ClientLeft      =   3690
   ClientTop       =   3645
   ClientWidth     =   7710
   LinkTopic       =   "Form1"
   ScaleHeight     =   3735
   ScaleWidth      =   7710
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   120
      Tag             =   "0"
      Top             =   240
   End
   Begin VB.Label lblProgress 
      BackStyle       =   0  'Transparent
      Caption         =   "-"
      BeginProperty Font 
         Name            =   "Microsoft Sans Serif"
         Size            =   36
         Charset         =   204
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   615
      Left            =   4200
      TabIndex        =   3
      Top             =   2280
      Width           =   3015
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Alternative World of Warcraft Emulator"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   204
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4200
      TabIndex        =   1
      Top             =   2760
      Width           =   3375
      WordWrap        =   -1  'True
   End
   Begin VB.Label lblStatus 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "Initializing..."
      BeginProperty Font 
         Name            =   "Franklin Gothic Medium"
         Size            =   12
         Charset         =   204
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0C0&
      Height          =   375
      Left            =   3480
      TabIndex        =   0
      Top             =   3440
      Width           =   4095
   End
   Begin VB.Image Image7 
      Height          =   660
      Left            =   6600
      Picture         =   "frmSplash.frx":0000
      Top             =   2040
      Width           =   645
   End
   Begin VB.Image Image6 
      Height          =   660
      Left            =   5400
      Picture         =   "frmSplash.frx":0540
      Top             =   2040
      Width           =   645
   End
   Begin VB.Image Image5 
      Height          =   660
      Left            =   6000
      Picture         =   "frmSplash.frx":097E
      Top             =   2040
      Width           =   645
   End
   Begin VB.Image Image4 
      Height          =   660
      Left            =   4800
      Picture         =   "frmSplash.frx":0EF4
      Top             =   2040
      Width           =   645
   End
   Begin VB.Image Image3 
      Height          =   660
      Left            =   4200
      Picture         =   "frmSplash.frx":146A
      Top             =   2040
      Width           =   645
   End
   Begin VB.Image Image9 
      Height          =   2160
      Left            =   10
      Picture         =   "frmSplash.frx":195A
      Top             =   10
      Width           =   7680
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   $"frmSplash.frx":6D8B
      BeginProperty Font 
         Name            =   "MS Serif"
         Size            =   6.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00808080&
      Height          =   1335
      Left            =   120
      TabIndex        =   2
      Top             =   2280
      Width           =   3975
      WordWrap        =   -1  'True
   End
   Begin VB.Shape Shape1 
      FillColor       =   &H00FFFFFF&
      FillStyle       =   0  'Solid
      Height          =   1560
      Left            =   0
      Top             =   2175
      Width           =   7710
   End
End
Attribute VB_Name = "frmSplash"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    'lblProgress.Caption = "------------"
    '12
    Randomize
    'frmMDI.Show
    'frmSplash.Hide
End Sub

Private Sub Timer1_Timer()
    Timer1.Enabled = False
    frmMDI.Show
    frmSplash.Hide
End Sub
