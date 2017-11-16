VERSION 5.00
Begin VB.UserControl GTASACheat 
   ClientHeight    =   375
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   1785
   ScaleHeight     =   375
   ScaleWidth      =   1785
   Begin VB.CheckBox chkCheat 
      Caption         =   "Cheat Caption"
      Height          =   375
      Left            =   345
      Style           =   1  'Graphical
      TabIndex        =   0
      TabStop         =   0   'False
      ToolTipText     =   "Cheat Tooltip"
      Top             =   0
      Width           =   1440
   End
   Begin VB.CheckBox chkCheatLock 
      DownPicture     =   "GTASACheat.ctx":0000
      Height          =   375
      Left            =   0
      Picture         =   "GTASACheat.ctx":014A
      Style           =   1  'Graphical
      TabIndex        =   1
      TabStop         =   0   'False
      ToolTipText     =   "Check to lock selected cheat state"
      Top             =   0
      Width           =   360
   End
End
Attribute VB_Name = "GTASACheat"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
'Event Declarations:
Event CheatClicked() 'MappingInfo=chkCheat,chkCheat,-1,Click
Attribute CheatClicked.VB_Description = "Occurs when the user presses and then releases a mouse button over an object."
Event LockedClicked() 'MappingInfo=chkCheatLock,chkCheatLock,-1,Click
Attribute LockedClicked.VB_Description = "Occurs when the user presses and then releases a mouse button over an object."


'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=chkCheat,chkCheat,-1,Caption
Public Property Get Caption() As String
Attribute Caption.VB_Description = "Returns/sets the text displayed in an object's title bar or below an object's icon."
    Caption = chkCheat.Caption
End Property

Public Property Let Caption(ByVal New_Caption As String)
    chkCheat.Caption = New_Caption
    PropertyChanged "Caption"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=chkCheatLock,chkCheatLock,-1,Value
Public Property Get CheatLock() As Integer
Attribute CheatLock.VB_Description = "Returns/sets the value of an object."
    CheatLock = chkCheatLock.Value
End Property

Public Property Let CheatLock(ByVal New_CheatLock As Integer)
    chkCheatLock.Value = New_CheatLock
    PropertyChanged "CheatLock"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=chkCheat,chkCheat,-1,Value
Public Property Get CheatState() As Integer
Attribute CheatState.VB_Description = "Returns/sets the value of an object."
    CheatState = chkCheat.Value
End Property

Public Property Let CheatState(ByVal New_CheatState As Integer)
    chkCheat.Value = New_CheatState
    PropertyChanged "CheatState"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=chkCheat,chkCheat,-1,ToolTipText
Public Property Get CheatTip() As String
Attribute CheatTip.VB_Description = "Returns/sets the text displayed when the mouse is paused over the control."
    CheatTip = chkCheat.ToolTipText
End Property

Public Property Let CheatTip(ByVal New_CheatTip As String)
    chkCheat.ToolTipText = New_CheatTip
    PropertyChanged "CheatTip"
End Property

'Load property values from storage
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)

    chkCheat.Caption = PropBag.ReadProperty("Caption", "Cheat Caption")
    chkCheatLock.Value = PropBag.ReadProperty("CheatLock", 0)
    chkCheat.Value = PropBag.ReadProperty("CheatState", 0)
    chkCheat.ToolTipText = PropBag.ReadProperty("CheatTip", "Cheat Tooltip")
    UserControl.Enabled = PropBag.ReadProperty("Enabled", True)
    chkCheat.Enabled = UserControl.Enabled
    chkCheatLock.Enabled = UserControl.Enabled
End Sub

'Write property values to storage
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)

    Call PropBag.WriteProperty("Caption", chkCheat.Caption, "Cheat Caption")
    Call PropBag.WriteProperty("CheatLock", chkCheatLock.Value, 0)
    Call PropBag.WriteProperty("CheatState", chkCheat.Value, 0)
    Call PropBag.WriteProperty("CheatTip", chkCheat.ToolTipText, "Cheat Tooltip")
    Call PropBag.WriteProperty("Enabled", UserControl.Enabled, True)
End Sub

Private Sub chkCheat_Click()
    RaiseEvent CheatClicked
End Sub

Private Sub chkCheatLock_Click()
    RaiseEvent LockedClicked
End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=UserControl,UserControl,-1,Enabled
Public Property Get Enabled() As Boolean
Attribute Enabled.VB_Description = "Returns/sets a value that determines whether an object can respond to user-generated events."
    Enabled = UserControl.Enabled
End Property

Public Property Let Enabled(ByVal New_Enabled As Boolean)
    UserControl.Enabled = New_Enabled
    chkCheat.Enabled = New_Enabled
    chkCheatLock.Enabled = New_Enabled
    PropertyChanged "Enabled"
End Property

