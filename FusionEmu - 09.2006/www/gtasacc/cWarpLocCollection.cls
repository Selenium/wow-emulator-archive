VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "cWarpLocCollection"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Collection" ,"cWarpLocs"
Attribute VB_Ext_KEY = "Member0" ,"cWarpLocs"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit
'Value to Index Key matrix array collection class (uses cWarpLocs)
'local variable to hold collection
Private mCol As Collection

Public Function AddWarpLocsClass(ByRef cNewWarpLoc As cWarpLocs) As Boolean
On Error Resume Next
    mCol.Add cNewWarpLoc, cNewWarpLoc.sUID
    AddWarpLocsClass = True
End Function

Public Function Add(ByVal sUID As String, _
                    ByVal sFolder As String, _
                    ByVal sDescription As String, _
                    ByVal sLocData As String) As cWarpLocs
On Error Resume Next
    'create a new object
    Dim objNewMember As New cWarpLocs
    
    'set the properties passed into the method
    objNewMember.sFolder = sFolder
    objNewMember.sDescription = sDescription
    objNewMember.sLocData = sLocData
    objNewMember.sUID = sUID
    mCol.Add objNewMember, sUID
    
    'return the object created
    Set Add = objNewMember
    Set objNewMember = Nothing

End Function

Public Property Get Item(ByVal iIndexKey As Long) As cWarpLocs
Attribute Item.VB_UserMemId = 0
On Error Resume Next 'do not let this property to fire an alarm. if wanted key does not exis, just generate it
    Set Item = mCol(iIndexKey)
End Property

Public Property Get WarpLocCount() As Long
On Error Resume Next
    WarpLocCount = mCol.Count
End Property

Public Function GetDumpString(ByVal iIndexKey As Long) As String
On Error Resume Next
    With mCol(iIndexKey)
        GetDumpString = .sUID & "|" & .sFolder & "|" & .sDescription & "|" & .sLocData
    End With
End Function

Public Function GetDumpStringByUID(ByVal sUID As String) As String
On Error Resume Next
    With mCol(sUID)
        GetDumpStringByUID = .sUID & "|" & .sFolder & "|" & .sDescription & "|" & .sLocData
    End With
End Function

Public Function GetItemByUID(ByVal sUID As String) As cWarpLocs
On Error Resume Next 'loop the contents of cShortcuts's, and deliver the wanted object
    Set GetItemByUID = mCol(sUID)
    
End Function

Public Function GetIndexByUID(ByVal sUID As String) As Long
On Error Resume Next 'loop the contents of cWarpLocs's, and deliver the wanted object
    GetIndexByUID = -1
    Static lngItemCounter As Long
    For lngItemCounter = 1 To mCol.Count
        If mCol(lngItemCounter).sUID = sUID Then
            GetIndexByUID = lngItemCounter
            Exit For
        End If
    Next lngItemCounter
End Function

Public Function RemoveByIndex(ByVal iIndexKey As Long) As Boolean
On Error Resume Next
    If iIndexKey > -1 And iIndexKey <= mCol.Count Then
        mCol.Remove iIndexKey
        RemoveByIndex = True
    Else
        RemoveByIndex = False
    End If
End Function

Public Function RemoveByUID(ByVal sUID As String) As Boolean
On Error Resume Next
    Static iIndexKey As Long
    iIndexKey = GetIndexByUID(sUID)
    If iIndexKey > -1 Then
        mCol.Remove iIndexKey
        RemoveByUID = True
    Else
        RemoveByUID = False
    End If
End Function

Public Function CloneByIndex(ByVal iIndexKey As Long) As cWarpLocs
On Error Resume Next
    Set CloneByIndex = New cWarpLocs
    With mCol(iIndexKey)
        CloneByIndex.sUID = .sUID
        CloneByIndex.sFolder = .sFolder
        CloneByIndex.sDescription = .sDescription
        CloneByIndex.sLocData = .sLocData
    End With
End Function

Public Function CloneByUID(ByVal sUID As String) As cWarpLocs
On Error Resume Next
    Set CloneByUID = New cWarpLocs
    With mCol(sUID)
        CloneByUID.sUID = .sUID
        CloneByUID.sFolder = .sFolder
        CloneByUID.sDescription = .sDescription
        CloneByUID.sLocData = .sLocData
    End With
End Function

Public Function RemoveAll() As Boolean
On Error Resume Next
    Set mCol = New Collection
End Function

Private Sub Class_Initialize()
    'creates the collection when this class is created
    Set mCol = New Collection
End Sub

Private Sub Class_Terminate()
    'destroys collection when this class is terminated
    Set mCol = Nothing
End Sub

