VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "cWarpLocs"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit
'Value to Index Key matrix array class (used by the collection class)
Public sDescription As String
Public sFolder As String
Public sUID As String
Public iLocationCount As Long
Public fXCoord As Single
Public fYCoord As Single
Public fZCoord As Single
Public fAngle As Single

Private m_sLocData As String

Public Property Let sLocData(ByVal New_sLocData As String)
On Error Resume Next
    Dim sLocs() As String
    m_sLocData = New_sLocData
    sLocs = Split(m_sLocData, ";")
    iLocationCount = UBound(sLocs)
    fXCoord = MakeSingle(sLocs(0))
    fYCoord = MakeSingle(sLocs(1))
    fZCoord = MakeSingle(sLocs(2))
    fAngle = MakeSingle(sLocs(3))
End Property

Public Property Get sLocData() As String
On Error Resume Next
    sLocData = m_sLocData
End Property

Public Function GetLocation(ByVal iLocIndex As Long) As String
On Error Resume Next
    Dim sLocs() As String
    sLocs = Split(sLocData, ";")
    GetLocation = sLocs(iLocIndex)
End Function

Private Function MakeSingle(ByVal sValue As String) As Single
On Error Resume Next
    Dim sValueC As String
    Dim sValueS() As String
    sValue = Replace(sValue, ",", ".")
    sValueS = Split(sValue, ".")
    If UBound(sValueS) = 0 Then
        MakeSingle = CSng(sValueS(0))
    Else
        MakeSingle = CSng(sValueS(0)) + (CSng(sValueS(1)) / 10 ^ Len(sValueS(1)))
    End If
End Function
