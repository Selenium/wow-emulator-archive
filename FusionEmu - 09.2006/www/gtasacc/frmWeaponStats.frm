VERSION 5.00
Begin VB.Form frmWeaponStats 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "GTA SA Control Center - Weapon Stats"
   ClientHeight    =   3480
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5430
   Icon            =   "frmWeaponStats.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3480
   ScaleWidth      =   5430
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdClose 
      Caption         =   "Close"
      Height          =   375
      Left            =   1493
      TabIndex        =   30
      Top             =   3000
      Width           =   2445
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   9
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   28
      TabStop         =   0   'False
      Top             =   2670
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   8
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   25
      TabStop         =   0   'False
      Top             =   2385
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   7
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   22
      TabStop         =   0   'False
      Top             =   2100
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   6
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   19
      TabStop         =   0   'False
      Top             =   1815
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   5
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   16
      TabStop         =   0   'False
      Top             =   1530
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   4
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   13
      TabStop         =   0   'False
      Top             =   1245
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   3
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   960
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   2
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   7
      TabStop         =   0   'False
      Top             =   675
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   1
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   4
      TabStop         =   0   'False
      Top             =   390
      Width           =   3195
   End
   Begin VB.HScrollBar scrWeaponStats 
      Height          =   255
      Index           =   0
      LargeChange     =   10
      Left            =   1485
      Max             =   1000
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   105
      Width           =   3195
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   9
      Left            =   4740
      TabIndex        =   29
      Top             =   2700
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "M4:"
      Height          =   225
      Index           =   9
      Left            =   120
      TabIndex        =   27
      Top             =   2700
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   8
      Left            =   4740
      TabIndex        =   26
      Top             =   2415
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "AK47:"
      Height          =   225
      Index           =   8
      Left            =   120
      TabIndex        =   24
      Top             =   2415
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   7
      Left            =   4740
      TabIndex        =   23
      Top             =   2130
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "SMG:"
      Height          =   225
      Index           =   7
      Left            =   120
      TabIndex        =   21
      Top             =   2130
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   6
      Left            =   4740
      TabIndex        =   20
      Top             =   1845
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "Machine Pistol:"
      Height          =   225
      Index           =   6
      Left            =   120
      TabIndex        =   18
      Top             =   1845
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   5
      Left            =   4740
      TabIndex        =   17
      Top             =   1560
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "Combat Shotgun:"
      Height          =   225
      Index           =   5
      Left            =   120
      TabIndex        =   15
      Top             =   1560
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   4
      Left            =   4740
      TabIndex        =   14
      Top             =   1275
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "Sawn-off Shotgun:"
      Height          =   225
      Index           =   4
      Left            =   120
      TabIndex        =   12
      Top             =   1275
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   3
      Left            =   4740
      TabIndex        =   11
      Top             =   990
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "Shotgun:"
      Height          =   225
      Index           =   3
      Left            =   120
      TabIndex        =   9
      Top             =   990
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   2
      Left            =   4740
      TabIndex        =   8
      Top             =   705
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "Desert Eagle:"
      Height          =   225
      Index           =   2
      Left            =   120
      TabIndex        =   6
      Top             =   705
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   1
      Left            =   4740
      TabIndex        =   5
      Top             =   420
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "Silenced Pistol:"
      Height          =   225
      Index           =   1
      Left            =   120
      TabIndex        =   3
      Top             =   420
      Width           =   1365
   End
   Begin VB.Label lblStatVals 
      Alignment       =   2  'Center
      Caption         =   "0 %"
      Height          =   225
      Index           =   0
      Left            =   4740
      TabIndex        =   2
      Top             =   135
      Width           =   600
   End
   Begin VB.Label lblWeaponStats 
      Caption         =   "Pistol:"
      Height          =   225
      Index           =   0
      Left            =   120
      TabIndex        =   0
      Top             =   135
      Width           =   1365
   End
End
Attribute VB_Name = "frmWeaponStats"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private isInternClick As Boolean

Private Sub Form_Load()
On Error Resume Next
    Dim iStatCtr As Integer
    isInternClick = True
    For iStatCtr = 0 To 9
        scrWeaponStats(iStatCtr).Value = GetMemFloat(GTASABaseAdr.WeaponProfStatAdr(iStatCtr))
        lblStatVals(iStatCtr).Caption = Format(scrWeaponStats(iStatCtr).Value / 10, "#0.0") & " %"
    Next iStatCtr
    isInternClick = False
End Sub

Private Sub scrWeaponStats_Change(Index As Integer)
On Error Resume Next
    If isInternClick Then Exit Sub
    SetMemFloat GTASABaseAdr.WeaponProfStatAdr(Index), scrWeaponStats(Index).Value
    lblStatVals(Index).Caption = Format(scrWeaponStats(Index).Value / 10, "#0.0") & " %"
End Sub

Private Sub cmdClose_Click()
On Error Resume Next
    Me.Hide
End Sub

Private Sub SetMemFloat(ByVal iAdr As Long, ByVal fVal As Single)
On Error Resume Next
    WriteProcessMemory lngPHandle, iAdr, fVal, 4&, 4&
End Sub

Private Function GetMemFloat(ByVal iAdr As Long) As Single
On Error Resume Next
    Static fVal As Single
    If ReadProcessMemory(lngPHandle, iAdr, fVal, 4&, 0&) <> 0 Then GetMemFloat = fVal
End Function


