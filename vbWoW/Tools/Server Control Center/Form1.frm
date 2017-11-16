VERSION 5.00
Begin VB.Form Main 
   BackColor       =   &H00FFFFFF&
   Caption         =   "vbWoW Control Center"
   ClientHeight    =   3105
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   3585
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   3105
   ScaleWidth      =   3585
   StartUpPosition =   2  'CenterScreen
   Begin VB.Timer Timer2 
      Interval        =   1000
      Left            =   3000
      Top             =   120
   End
   Begin VB.TextBox Text2 
      Alignment       =   2  'Center
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   1680
      TabIndex        =   11
      Text            =   "0"
      Top             =   1800
      Width           =   375
   End
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   120
      Top             =   120
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   8
      Top             =   2640
      Width           =   3375
      Begin VB.Label Label11 
         BackStyle       =   0  'Transparent
         Caption         =   "Awaiting user input..."
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   720
         TabIndex        =   10
         Top             =   120
         Width           =   2535
      End
      Begin VB.Label Label10 
         BackStyle       =   0  'Transparent
         Caption         =   "Status:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   6.75
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   120
         Width           =   615
      End
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Settings"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   6.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2400
      TabIndex        =   3
      Top             =   2280
      Width           =   855
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Stop"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   6.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1200
      TabIndex        =   2
      Top             =   2280
      Width           =   855
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Start"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   6.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   1
      Top             =   2280
      Width           =   855
   End
   Begin VB.Label Label8 
      BackStyle       =   0  'Transparent
      Caption         =   "Process crashes:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   120
      TabIndex        =   7
      Top             =   1800
      Width           =   1575
   End
   Begin VB.Label Label7 
      BackStyle       =   0  'Transparent
      Caption         =   "Uptime:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   120
      TabIndex        =   6
      Top             =   840
      Width           =   975
   End
   Begin VB.Line Line6 
      BorderColor     =   &H00808080&
      BorderStyle     =   4  'Dash-Dot
      X1              =   2160
      X2              =   2160
      Y1              =   1200
      Y2              =   1680
   End
   Begin VB.Line Line5 
      BorderColor     =   &H00808080&
      BorderStyle     =   4  'Dash-Dot
      X1              =   1440
      X2              =   1440
      Y1              =   1200
      Y2              =   1680
   End
   Begin VB.Line Line2 
      BorderColor     =   &H00808080&
      X1              =   720
      X2              =   2880
      Y1              =   1680
      Y2              =   1680
   End
   Begin VB.Line Line4 
      BorderColor     =   &H00808080&
      X1              =   2880
      X2              =   2880
      Y1              =   1200
      Y2              =   1680
   End
   Begin VB.Line Line3 
      BorderColor     =   &H00808080&
      X1              =   720
      X2              =   2880
      Y1              =   1200
      Y2              =   1200
   End
   Begin VB.Line Line1 
      BorderColor     =   &H00808080&
      X1              =   720
      X2              =   720
      Y1              =   1200
      Y2              =   1680
   End
   Begin VB.Label Secs 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   495
      Left            =   2280
      TabIndex        =   5
      Top             =   1200
      Width           =   495
   End
   Begin VB.Label Mins 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   495
      Left            =   1560
      TabIndex        =   4
      Top             =   1200
      Width           =   495
   End
   Begin VB.Label Hrs 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "Arial Black"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   495
      Left            =   840
      TabIndex        =   0
      Top             =   1200
      Width           =   495
   End
   Begin VB.Image Image1 
      Height          =   750
      Left            =   240
      Picture         =   "Form1.frx":1708A
      Top             =   0
      Width           =   3000
   End
   Begin VB.Menu mnuSystray 
      Caption         =   "Systray"
      Visible         =   0   'False
      Begin VB.Menu mnuRestore 
         Caption         =   "Restore"
      End
      Begin VB.Menu Spacer1 
         Caption         =   "-"
      End
      Begin VB.Menu mnuexit 
         Caption         =   "Exit"
      End
   End
End
Attribute VB_Name = "Main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
' Copyright (C) 2005-2007 vbWoW <http://www.vbwow.org/>
'
' This program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'

Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
Private Type PROCESS_INFORMATION
         hProcess As Long
         hThread As Long
         dwProcessId As Long
         dwThreadId As Long
      End Type

      Private Type STARTUPINFO
         cb As Long
         lpReserved As String
         lpDesktop As String
         lpTitle As String
         dwX As Long
         dwY As Long
         dwXSize As Long
         dwYSize As Long
         dwXCountChars As Long
         dwYCountChars As Long
         dwFillAttribute As Long
         dwflags As Long
         wShowWindow As Integer
         cbReserved2 As Integer
         lpReserved2 As Long
         hStdInput As Long
         hStdOutput As Long
         hStdError As Long
      End Type

      Private Declare Function CreateProcess Lib "kernel32" _
         Alias "CreateProcessA" _
         (ByVal lpApplicationName As String, _
         ByVal lpCommandLine As String, _
         lpProcessAttributes As Any, _
         lpThreadAttributes As Any, _
         ByVal bInheritHandles As Long, _
         ByVal dwCreationFlags As Long, _
         lpEnvironment As Any, _
         ByVal lpCurrentDriectory As String, _
         lpStartupInfo As STARTUPINFO, _
         lpProcessInformation As PROCESS_INFORMATION) As Long

      Private Declare Function OpenProcess Lib "Kernel32.dll" _
         (ByVal dwAccess As Long, _
         ByVal fInherit As Integer, _
         ByVal hObject As Long) As Long

      Private Declare Function TerminateProcess Lib "kernel32" _
         (ByVal hProcess As Long, _
         ByVal uExitCode As Long) As Long

      Private Declare Function CloseHandle Lib "kernel32" _
         (ByVal hObject As Long) As Long

      Const SYNCHRONIZE = 1048576
      Const NORMAL_PRIORITY_CLASS = &H20&
      
Dim pInfo As PROCESS_INFORMATION
Dim sInfo As STARTUPINFO
Dim sNull As String
Dim lSuccess As Long
Dim lRetValue As Long
Private Sub Command1_Click()
sInfo.cb = Len(sInfo)
         lSuccess = CreateProcess(sNull, _
                                 "vbWoW.WorldServer.exe", _
                                 ByVal 0&, _
                                 ByVal 0&, _
                                 1&, _
                                 NORMAL_PRIORITY_CLASS, _
                                 ByVal 0&, _
                                 sNull, _
                                 sInfo, _
                                 pInfo)
                                 sInfo.cb = Len(sInfo)
         lSuccess = CreateProcess(sNull, _
                                 "vbWoW.RealmServer.exe", _
                                 ByVal 0&, _
                                 ByVal 0&, _
                                 1&, _
                                 NORMAL_PRIORITY_CLASS, _
                                 ByVal 0&, _
                                 sNull, _
                                 sInfo, _
                                 pInfo)
Curr_Process = "vbWoW.WorldServer.exe"
Process_Present = False
Process_Present = GetProcesses("vbWoW.WorldServer.exe")
If Process_Present = False Then
MsgBox ("Critical error :: Cannot execute process. Please MAKE sure that you have the 'vbWoW Control Center.exe' file in the folder that contains 'vbWoW.WorldServer.exe' and 'vbWoW.RealmServer.exe'."), vbCritical
Else
Curr_Process = "vbWoW.RealmServer.exe"
Process_Present = False
Process_Present = GetProcesses("vbWoW.RealmServer.exe")
If Process_Present = False Then
MsgBox ("Critical error :: Cannot execute process. Please MAKE sure that you have the 'vbWoW Control Center.exe' file in the folder that contains 'vbWoW.WorldServer.exe' and 'vbWoW.RealmServer.exe'."), vbCritical
Else
Timer1.Enabled = True
Timer2.Enabled = True
Command2.Enabled = True
Command1.Enabled = False
Label11 = "Monitoring for crashes..."
End If
End If
End Sub
Private Sub Command2_Click()
Command1.Enabled = True
Command2.Enabled = False
Timer2.Enabled = False
Timer1.Enabled = False
Hrs = "00"
Mins = "00"
Secs = "00"
Label11 = "Monitoring for crashes disabled..."
End Sub
Private Sub Command3_Click()
dlgSettings.Show
Unload Me
End Sub
Private Sub Form_Load()
Timer1.Enabled = False
Command2.Enabled = False
Timer2.Enabled = False
If GetRegStringValue$(HKEY_LOCAL_MACHINE, "Software\Microsoft\.NETFramework\policy\v2.0", "50727") = "50727-50727" Then
Else
If MsgBox("Microsoft .NET Framework 2.0 is CURRENTLY NOT installed on this PC or is somehow corrupted. In order to run 'vbWoW' you must install .NET Framework 2.0. Would you like to install or reinstall .NET Framework 2.0?", vbYesNo + vbCritical, "vbWoW | Server Control Center") = vbYes Then
ShellExecute Me.hwnd, "Open", "http://www.microsoft.com/downloads/details.aspx?familyid=0856EACB-4362-4B0D-8EDD-AAB15C5E04F5&displaylang=en", 0, 0, 0
MsgBox ("'vbWoW | Server Control Center' will now shutdown. Please run 'vbWoW | Server Control Center' after installing .NET Framework 2.0."), vbExclamation
Unload Me
Else
MsgBox ("You have chosen not to install .NET Framework 2.0 - a necessity for the functionality for 'vbWoW'. This application will now close."), vbExclamation
Unload Me
End If
End If
End Sub
Private Sub Image1_Click()
ShellExecute Me.hwnd, "Open", "http://www.vbwow.org/", 0, 0, 0
End Sub
Private Sub Timer1_Timer()
Curr_Process = "vbWoW.WorldServer.exe"
Process_Present = False
Process_Present = GetProcesses("vbWoW.WorldServer.exe")
If Process_Present = False Then
         sInfo.cb = Len(sInfo)
         lSuccess = CreateProcess(sNull, _
                                 "vbWoW.WorldServer.exe", _
                                 ByVal 0&, _
                                 ByVal 0&, _
                                 1&, _
                                 NORMAL_PRIORITY_CLASS, _
                                 ByVal 0&, _
                                 sNull, _
                                 sInfo, _
                                 pInfo)
Text2.Text = Text2.Text + 1
Hrs = "00"
Mins = "00"
Secs = "00"
End If
End Sub
' ================================== MINIMIZE TO SYSTRAY CODE ==============================
'THIS SOURCE CODE WILL USE WHAT EVER ICON YOUR PROGRAMME USES'
'THIS MAKES THE MENU POPUP WHEN THE FORM IS HIDDEN IN THE SYSTRAY'
Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
Dim Sys As Long
Sys = X / Screen.TwipsPerPixelX
Select Case Sys
Case WM_LBUTTONDOWN:
Me.PopupMenu mnuSystray
End Select
End Sub
'THIS MAKES THE FOR DISSAPEAR/MINIMIZE TO THE SYSTRAY'
Private Sub Form_Resize()
If WindowState = vbMinimized Then
Me.Hide
Me.Refresh
With nid
.cbSize = Len(nid)
.hwnd = Me.hwnd
.uId = vbNull
.uFlags = NIF_ICON Or NIF_TIP Or NIF_MESSAGE
.uCallBackMessage = WM_MOUSEMOVE
.hIcon = Me.Icon
.szTip = Me.Caption & vbNullChar
End With
Shell_NotifyIcon NIM_ADD, nid
Else
Shell_NotifyIcon NIM_DELETE, nid
End If
End Sub
'THIS UNLOADS THE FORM FROM THE MENU'
Private Sub mnuexit_Click()
Unload Me
End Sub
'THIS RESTORES THE FORM'
Private Sub mnuRestore_Click()
WindowState = vbNormal
Me.Show
End Sub
'THIS WILL KILL SYSTRAY ICON WHEN FORM IS UNLOADED'
Private Sub Form_Unload(Cancel As Integer)
Shell_NotifyIcon NIM_DELETE, nid
End Sub
Private Sub Timer2_Timer()
If Secs = 59 Then
Mins = Mins + 1
Secs = "00"
Else
Secs = Secs + 1
End If

If Mins = 60 Then
Hrs = Hrs + 1
Mins = "00"
Else
End If


End Sub
