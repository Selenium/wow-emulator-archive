VERSION 5.00
Begin VB.Form frmLog 
   BorderStyle     =   5  'Sizable ToolWindow
   Caption         =   "Log"
   ClientHeight    =   8040
   ClientLeft      =   930
   ClientTop       =   8400
   ClientWidth     =   11205
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   8040
   ScaleWidth      =   11205
   ShowInTaskbar   =   0   'False
   Begin VB.TextBox Text2 
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   8.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0FFC0&
      Height          =   7335
      Left            =   0
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   0
      Text            =   "frmLog.frx":0000
      Top             =   0
      Width           =   10215
   End
End
Attribute VB_Name = "frmLog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    frmLog.Height = 7000
    frmLog.Width = 10000
    System.Initialize
    Text2.text = App.ProductName & vbNewLine
    Text2.text = Text2.text & "version " & Format(App.Major, "0") & "." & Format(App.Minor, "00") & "." & Format(App.Revision, "0000") & vbNewLine
    Print #109, Text2.text
End Sub

Private Sub Form_Resize()
    Text2.Height = frmLog.Height - 400
    Text2.Width = frmLog.Width - 150
End Sub

Private Sub Text2_Change()
    If Len(Text2.text) > 60000 Then Text2.text = Mid(Text2.text, 10000)
End Sub
