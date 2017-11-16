VERSION 5.00
Begin VB.MDIForm frmMDI 
   BackColor       =   &H8000000C&
   Caption         =   "aWoWe - Alternative WoW Emulator ALPHA"
   ClientHeight    =   6855
   ClientLeft      =   2550
   ClientTop       =   1845
   ClientWidth     =   9915
   Icon            =   "frmMDI.frx":0000
   LinkTopic       =   "MDIForm1"
   WindowState     =   2  'Maximized
   Begin VB.Menu mnView 
      Caption         =   "View"
      WindowList      =   -1  'True
   End
   Begin VB.Menu mnHelp 
      Caption         =   "Help"
      Begin VB.Menu mnAbout 
         Caption         =   "About"
      End
   End
End
Attribute VB_Name = "frmMDI"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub MDIForm_Load()
    'Dim i As Integer
    ReDim F(20, 4095), sg(20), l(20)
    'For i = 4 To 12
    '    Main_Functions.bigint(i) = i
    'Next i
    
    
    frmLog.Show
    frmMain.Show
    frmWSSetup.Show
    frmMisc.Show
End Sub

Private Sub MDIForm_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    Select Case MsgBox("Do you want to save server data before exit?", vbQuestion + vbYesNoCancel, "aWoWe Server")
    Case vbYes
        Cancel = True
        System.LOG "Requested server stopping..."
        System.LOG "Starting save procedure..."
        System.LOG "PLEASE WAIT"
        System.Terminate
        Unload frmSplash
        End
    Case vbCancel
        Cancel = True
    Case vbNo
        Unload frmSplash
        End
    End Select
End Sub

