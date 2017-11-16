VERSION 5.00
Begin VB.Form frmSelectFolder 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Pick a Folder to Move selected item to"
   ClientHeight    =   6960
   ClientLeft      =   45
   ClientTop       =   285
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6960
   ScaleWidth      =   4680
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdMoveTo 
      Cancel          =   -1  'True
      Caption         =   "Cancel"
      Height          =   420
      Index           =   1
      Left            =   2385
      TabIndex        =   2
      Top             =   6465
      Width           =   2220
   End
   Begin VB.CommandButton cmdMoveTo 
      Caption         =   "OK"
      Default         =   -1  'True
      Height          =   420
      Index           =   0
      Left            =   75
      TabIndex        =   1
      Top             =   6465
      Width           =   2220
   End
   Begin VB.ListBox lstFolders 
      Height          =   6300
      Left            =   75
      Sorted          =   -1  'True
      TabIndex        =   0
      Top             =   90
      Width           =   4530
   End
End
Attribute VB_Name = "frmSelectFolder"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public isOKClicked As Boolean

Private Sub cmdMoveTo_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 0 'OK
            If lstFolders.ListIndex > -1 Then
                isOKClicked = True
            Else
                MsgBox "No Folder has been selected.", vbInformation
                isOKClicked = False
            End If
        Case 1 'Cancel
            isOKClicked = False
    End Select
    Me.Hide
End Sub

Public Function FillInFolders(ByRef tvMain As TreeView) As Boolean
On Error Resume Next
    Dim iNodeCounter As Long
    lstFolders.Clear
    For iNodeCounter = 1 To tvMain.Nodes.Count
        If tvMain.Nodes(iNodeCounter).Tag = "folder" Then
            lstFolders.AddItem tvMain.Nodes(iNodeCounter).FullPath
        End If
    Next iNodeCounter
    If lstFolders.ListCount > 0 Then lstFolders.ListIndex = 0
    FillInFolders = True
End Function
