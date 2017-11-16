VERSION 5.00
Begin VB.UserControl GTASAStat 
   ClientHeight    =   510
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   3465
   ScaleHeight     =   510
   ScaleWidth      =   3465
   Begin VB.HScrollBar scrStat 
      Height          =   225
      LargeChange     =   10
      Left            =   240
      Max             =   1000
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   255
      Width           =   3180
   End
   Begin VB.CommandButton cmdStat 
      Caption         =   "Max"
      Height          =   270
      Left            =   2565
      TabIndex        =   1
      ToolTipText     =   "Click to Lock Stat"
      Top             =   0
      Width           =   855
   End
   Begin VB.CheckBox chkLockStat 
      Caption         =   "Current Level  (0):"
      Height          =   195
      Left            =   0
      TabIndex        =   0
      TabStop         =   0   'False
      ToolTipText     =   "Check to Lock Stat"
      Top             =   0
      Width           =   3405
   End
End
Attribute VB_Name = "GTASAStat"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
'Default Property Values:
Const m_def_ValToCapDecimals = 0
Const m_def_HasButton = True
Const m_def_ButtonVal = 400
Const m_def_CaptionFormat = "Current Level ([N]):"
Const m_def_ValToCapMultiplier = 1
'Property Variables:
Dim m_ValToCapDecimals As Integer
Dim m_HasButton As Boolean
Dim m_ButtonVal As Single
Dim m_CaptionFormat As String
Dim m_ValToCapMultiplier As Single
'Event Declarations:
Event LockedClick() 'MappingInfo=chkLockStat,chkLockStat,-1,Click
Attribute LockedClick.VB_Description = "Occurs when the user presses and then releases a mouse button over an object."
Event ScrollChange() 'MappingInfo=scrStat,scrStat,-1,Change
Attribute ScrollChange.VB_Description = "Occurs when the contents of a control have changed."
Event ButtonClick() 'MappingInfo=cmdStat,cmdStat,-1,Click
Attribute ButtonClick.VB_Description = "Occurs when the user presses and then releases a mouse button over an object."

Private Sub SetCaption()
On Error Resume Next
    chkLockStat.Caption = Replace(m_CaptionFormat, "[N]", Round(scrStat.Value * m_ValToCapMultiplier, m_ValToCapDecimals))
End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=0,0,0,1
Public Property Get HasButton() As Boolean
    HasButton = m_HasButton
End Property

Public Property Let HasButton(ByVal New_HasButton As Boolean)
    m_HasButton = New_HasButton
    cmdStat.Visible = m_HasButton
    PropertyChanged "HasButton"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=cmdStat,cmdStat,-1,Caption
Public Property Get ButtonCaption() As String
Attribute ButtonCaption.VB_Description = "Returns/sets the text displayed in an object's title bar or below an object's icon."
    ButtonCaption = cmdStat.Caption
End Property

Public Property Let ButtonCaption(ByVal New_ButtonCaption As String)
    cmdStat.Caption = New_ButtonCaption
    PropertyChanged "ButtonCaption"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=cmdStat,cmdStat,-1,ToolTipText
Public Property Get ButtonTip() As String
Attribute ButtonTip.VB_Description = "Returns/sets the text displayed when the mouse is paused over the control."
    ButtonTip = cmdStat.ToolTipText
End Property

Public Property Let ButtonTip(ByVal New_ButtonTip As String)
    cmdStat.ToolTipText = New_ButtonTip
    PropertyChanged "ButtonTip"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=12,0,0,400
Public Property Get ButtonVal() As Single
    ButtonVal = m_ButtonVal
End Property

Public Property Let ButtonVal(ByVal New_ButtonVal As Single)
    m_ButtonVal = New_ButtonVal
    PropertyChanged "ButtonVal"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=scrStat,scrStat,-1,Max
Public Property Get ScrollMax() As Integer
Attribute ScrollMax.VB_Description = "Returns/sets a scroll bar position's maximum Value property setting."
    ScrollMax = scrStat.max
End Property

Public Property Let ScrollMax(ByVal New_ScrollMax As Integer)
    scrStat.max = New_ScrollMax
    SetCaption
    PropertyChanged "ScrollMax"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=scrStat,scrStat,-1,Min
Public Property Get ScrollMin() As Integer
Attribute ScrollMin.VB_Description = "Returns/sets a scroll bar position's maximum Value property setting."
    ScrollMin = scrStat.min
End Property

Public Property Let ScrollMin(ByVal New_ScrollMin As Integer)
    scrStat.min = New_ScrollMin
    SetCaption
    PropertyChanged "ScrollMin"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=scrStat,scrStat,-1,Value
Public Property Get ScrollVal() As Integer
Attribute ScrollVal.VB_Description = "Returns/sets the value of an object."
    ScrollVal = scrStat.Value
End Property

Public Property Let ScrollVal(ByVal New_ScrollVal As Integer)
    If New_ScrollVal >= scrStat.min And New_ScrollVal <= scrStat.max Then
        scrStat.Value = New_ScrollVal
        SetCaption
        PropertyChanged "ScrollVal"
    End If
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=13,0,0,Current Level ([N]):
Public Property Get CaptionFormat() As String
    CaptionFormat = m_CaptionFormat
End Property

Public Property Let CaptionFormat(ByVal New_CaptionFormat As String)
    m_CaptionFormat = New_CaptionFormat
    SetCaption
    PropertyChanged "CaptionFormat"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=12,0,0,1
Public Property Get ValToCapMultiplier() As Single
    ValToCapMultiplier = m_ValToCapMultiplier
End Property

Public Property Let ValToCapMultiplier(ByVal New_ValToCapMultiplier As Single)
    m_ValToCapMultiplier = New_ValToCapMultiplier
    SetCaption
    PropertyChanged "ValToCapMultiplier"
End Property

Private Sub scrStat_Change()
    SetCaption
    RaiseEvent ScrollChange
End Sub

Private Sub cmdStat_Click()
    RaiseEvent ButtonClick
End Sub

'Initialize Properties for User Control
Private Sub UserControl_InitProperties()
    m_HasButton = m_def_HasButton
    m_ButtonVal = m_def_ButtonVal
    m_CaptionFormat = m_def_CaptionFormat
    m_ValToCapMultiplier = m_def_ValToCapMultiplier
    m_ValToCapDecimals = m_def_ValToCapDecimals
End Sub

'Load property values from storage
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)

    m_HasButton = PropBag.ReadProperty("HasButton", m_def_HasButton)
    cmdStat.Caption = PropBag.ReadProperty("ButtonCaption", "Max")
    cmdStat.ToolTipText = PropBag.ReadProperty("ButtonTip", "Click to Set Stat")
    m_ButtonVal = PropBag.ReadProperty("ButtonVal", m_def_ButtonVal)
    scrStat.max = PropBag.ReadProperty("ScrollMax", 1000)
    scrStat.min = PropBag.ReadProperty("ScrollMin", 0)
    scrStat.Value = PropBag.ReadProperty("ScrollVal", 0)
    m_CaptionFormat = PropBag.ReadProperty("CaptionFormat", m_def_CaptionFormat)
    m_ValToCapMultiplier = PropBag.ReadProperty("ValToCapMultiplier", m_def_ValToCapMultiplier)
    chkLockStat.Value = PropBag.ReadProperty("Locked", 0)
    m_ValToCapDecimals = PropBag.ReadProperty("ValToCapDecimals", m_def_ValToCapDecimals)
    chkLockStat.ToolTipText = PropBag.ReadProperty("CheckboxTip", "Check to Lock Stat")
    SetCaption
    cmdStat.Visible = m_HasButton
    UserControl.Enabled = PropBag.ReadProperty("Enabled", True)
End Sub

'Write property values to storage
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)
    
    Call PropBag.WriteProperty("HasButton", m_HasButton, m_def_HasButton)
    Call PropBag.WriteProperty("ButtonCaption", cmdStat.Caption, "Max")
    Call PropBag.WriteProperty("ButtonTip", cmdStat.ToolTipText, "Click to Set Stat")
    Call PropBag.WriteProperty("ButtonVal", m_ButtonVal, m_def_ButtonVal)
    Call PropBag.WriteProperty("ScrollMax", scrStat.max, 1000)
    Call PropBag.WriteProperty("ScrollMin", scrStat.min, 0)
    Call PropBag.WriteProperty("ScrollVal", scrStat.Value, 0)
    Call PropBag.WriteProperty("CaptionFormat", m_CaptionFormat, m_def_CaptionFormat)
    Call PropBag.WriteProperty("ValToCapMultiplier", m_ValToCapMultiplier, m_def_ValToCapMultiplier)
    Call PropBag.WriteProperty("Locked", chkLockStat.Value, 0)
    Call PropBag.WriteProperty("ValToCapDecimals", m_ValToCapDecimals, m_def_ValToCapDecimals)
    Call PropBag.WriteProperty("CheckboxTip", chkLockStat.ToolTipText, "Check to Lock Stat")
    Call PropBag.WriteProperty("Enabled", UserControl.Enabled, True)
End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=chkLockStat,chkLockStat,-1,Value
Public Property Get Locked() As Integer
Attribute Locked.VB_Description = "Returns/sets the value of an object."
    Locked = chkLockStat.Value
End Property

Public Property Let Locked(ByVal New_Locked As Integer)
    chkLockStat.Value = New_Locked
    PropertyChanged "Locked"
End Property

Private Sub chkLockStat_Click()
    RaiseEvent LockedClick
End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=7,0,0,0
Public Property Get ValToCapDecimals() As Integer
    ValToCapDecimals = m_ValToCapDecimals
End Property

Public Property Let ValToCapDecimals(ByVal New_ValToCapDecimals As Integer)
    m_ValToCapDecimals = New_ValToCapDecimals
    SetCaption
    PropertyChanged "ValToCapDecimals"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=chkLockStat,chkLockStat,-1,ToolTipText
Public Property Get CheckboxTip() As String
Attribute CheckboxTip.VB_Description = "Returns/sets the text displayed when the mouse is paused over the control."
    CheckboxTip = chkLockStat.ToolTipText
End Property

Public Property Let CheckboxTip(ByVal New_CheckboxTip As String)
    chkLockStat.ToolTipText = New_CheckboxTip
    PropertyChanged "CheckboxTip"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=UserControl,UserControl,-1,Enabled
Public Property Get Enabled() As Boolean
Attribute Enabled.VB_Description = "Returns/sets a value that determines whether an object can respond to user-generated events."
    Enabled = UserControl.Enabled
End Property

Public Property Let Enabled(ByVal New_Enabled As Boolean)
    UserControl.Enabled() = New_Enabled
    PropertyChanged "Enabled"
End Property

