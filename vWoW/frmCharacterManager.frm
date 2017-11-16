VERSION 5.00
Begin VB.Form frmCharacterManager 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Character Manager"
   ClientHeight    =   4590
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   4635
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4590
   ScaleWidth      =   4635
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame rManagerGuid 
      Caption         =   "Manage Characters"
      Height          =   4455
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   4455
      Begin VB.TextBox txtAccountManagerFacialHair 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   44
         Top             =   4080
         Width           =   1095
      End
      Begin VB.CommandButton cmdNewGuid 
         Caption         =   "New Guid"
         Height          =   255
         Left            =   3000
         TabIndex        =   43
         Top             =   3720
         Width           =   1335
      End
      Begin VB.CheckBox txtAccountManagerGender 
         Caption         =   "Check1"
         Height          =   195
         Left            =   1440
         TabIndex        =   41
         Top             =   2280
         Width           =   255
      End
      Begin VB.TextBox txtCharacterManagerCID 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2160
         Locked          =   -1  'True
         TabIndex        =   40
         Text            =   "ID"
         Top             =   360
         Width           =   855
      End
      Begin VB.CommandButton Command2 
         Caption         =   "<-"
         Height          =   255
         Left            =   240
         TabIndex        =   39
         Top             =   360
         Width           =   375
      End
      Begin VB.CommandButton Command1 
         Caption         =   "->"
         Height          =   255
         Left            =   3600
         TabIndex        =   38
         Top             =   360
         Width           =   375
      End
      Begin VB.TextBox txtAccountManagerPosZ 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   37
         Top             =   3360
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerPosY 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   36
         Top             =   3000
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerPosX 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   35
         Top             =   2640
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerMapID 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   34
         Top             =   2280
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerZoneID 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   33
         Top             =   1920
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerOutfitID 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   32
         Top             =   1560
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerGuildID 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   31
         Top             =   1200
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerHairColor 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   30
         Top             =   3720
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerHairStyle 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   29
         Top             =   3360
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerFace 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   28
         Top             =   3000
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerSkin 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   27
         Top             =   2640
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerRace 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   26
         Top             =   1920
         Width           =   1095
      End
      Begin VB.CommandButton cmdCharacterManagerSave 
         Caption         =   "Save Changes"
         Height          =   255
         Left            =   3000
         TabIndex        =   12
         Top             =   4080
         Width           =   1335
      End
      Begin VB.TextBox txtCharacterManagerGuid 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3240
         TabIndex        =   11
         Top             =   840
         Width           =   1095
      End
      Begin VB.TextBox txtCharacterManagerID 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1200
         Locked          =   -1  'True
         TabIndex        =   9
         Text            =   "ID"
         Top             =   360
         Width           =   855
      End
      Begin VB.CommandButton cmdAccountManagerNext 
         Caption         =   "->"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3120
         TabIndex        =   8
         Top             =   360
         Width           =   375
      End
      Begin VB.CommandButton cmdAccountManagerPrev 
         Caption         =   "<-"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   720
         TabIndex        =   7
         Top             =   360
         Width           =   375
      End
      Begin VB.TextBox txtAccountManagerClass 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   6
         Top             =   1560
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerLevel 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   5
         Top             =   1200
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerName 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   4
         Top             =   840
         Width           =   1095
      End
      Begin VB.Label Label14 
         Caption         =   "Facial Hair:"
         Height          =   255
         Left            =   120
         TabIndex        =   42
         Top             =   4080
         Width           =   975
      End
      Begin VB.Label Label13 
         Caption         =   "Hair Color:"
         Height          =   255
         Left            =   120
         TabIndex        =   25
         Top             =   3720
         Width           =   975
      End
      Begin VB.Label Label12 
         Caption         =   "Pos Z:"
         Height          =   255
         Left            =   2280
         TabIndex        =   24
         Top             =   3360
         Width           =   975
      End
      Begin VB.Label Label11 
         Caption         =   "Pos Y:"
         Height          =   255
         Left            =   2280
         TabIndex        =   23
         Top             =   3000
         Width           =   975
      End
      Begin VB.Label Label10 
         Caption         =   "Pos X:"
         Height          =   255
         Left            =   2280
         TabIndex        =   22
         Top             =   2640
         Width           =   975
      End
      Begin VB.Label Label9 
         Caption         =   "Map ID:"
         Height          =   255
         Left            =   2280
         TabIndex        =   21
         Top             =   2280
         Width           =   975
      End
      Begin VB.Label Label8 
         Caption         =   "Zone ID:"
         Height          =   255
         Left            =   2280
         TabIndex        =   20
         Top             =   1920
         Width           =   975
      End
      Begin VB.Label Label7 
         Caption         =   "Outfit ID:"
         Height          =   255
         Left            =   2280
         TabIndex        =   19
         Top             =   1560
         Width           =   975
      End
      Begin VB.Label Label6 
         Caption         =   "Guild ID:"
         Height          =   255
         Left            =   2280
         TabIndex        =   18
         Top             =   1200
         Width           =   975
      End
      Begin VB.Label Label5 
         Caption         =   "Hair Style:"
         Height          =   255
         Left            =   120
         TabIndex        =   17
         Top             =   3360
         Width           =   735
      End
      Begin VB.Label Label4 
         Caption         =   "Face:"
         Height          =   255
         Left            =   120
         TabIndex        =   16
         Top             =   3000
         Width           =   735
      End
      Begin VB.Label Label3 
         Caption         =   "Skin:"
         Height          =   255
         Left            =   120
         TabIndex        =   15
         Top             =   2640
         Width           =   735
      End
      Begin VB.Label Label2 
         Caption         =   "Gender:"
         Height          =   255
         Left            =   120
         TabIndex        =   14
         Top             =   2280
         Width           =   735
      End
      Begin VB.Label Label1 
         Caption         =   "Race:"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   1920
         Width           =   735
      End
      Begin VB.Label lblCharacterGuid 
         Caption         =   "Guid:"
         Height          =   255
         Left            =   2280
         TabIndex        =   10
         Top             =   840
         Width           =   975
      End
      Begin VB.Label lblAccountManagerClass 
         Caption         =   "Class:"
         Height          =   255
         Left            =   120
         TabIndex        =   3
         Top             =   1560
         Width           =   735
      End
      Begin VB.Label lblAccountManagerLevel 
         Caption         =   "Level:"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   1200
         Width           =   735
      End
      Begin VB.Label lblAccountManagerName 
         Caption         =   "Char Name:"
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Top             =   840
         Width           =   1215
      End
   End
End
Attribute VB_Name = "frmCharacterManager"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim AccManID As Integer
Dim AccCharID As Integer

Private Sub cmdAccountManagerNext_Click()
If AccManID <= (UBound(Account) - 1) Then
    AccManID = AccManID + 1
    txtCharacterManagerID.Text = AccManID
End If
End Sub

Private Sub cmdAccountManagerPrev_Click()
If AccManID >= (LBound(Account) + 1) Then
    AccManID = AccManID - 1
    txtCharacterManagerID.Text = AccManID
End If
End Sub

Private Sub cmdCharacterManagerSave_Click()
If txtCharacterManagerID.Text <> "ID" And txtCharacterManagerCID.Text <> "ID" Then
    CharacterManagerSaveFields txtCharacterManagerID.Text, txtCharacterManagerCID.Text
End If
End Sub

Private Sub cmdNewGuid_Click()
    Account(AccManID).AccChar(AccCharID).GUID = GetFreeGUID()
End Sub

Private Sub Command1_Click()
If AccCharID <= 9 Then
    AccCharID = AccCharID + 1
    txtCharacterManagerCID.Text = AccCharID
    modAccountSystem.CharacterManagerUpdateFields AccManID, AccCharID
End If
End Sub

Private Sub Command2_Click()
If AccCharID >= 2 Then
    AccCharID = AccCharID - 1
    txtCharacterManagerCID.Text = AccCharID
    modAccountSystem.CharacterManagerUpdateFields AccManID, AccCharID
End If
End Sub

Private Sub Form_Load()
'Temporary fix
AccManID = 0
AccCharID = 0
End Sub


