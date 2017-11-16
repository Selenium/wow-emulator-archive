VERSION 5.00
Begin VB.Form frmAccountManager 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Account Manager"
   ClientHeight    =   4095
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   4335
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4095
   ScaleWidth      =   4335
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame frmAccountsCreate 
      Caption         =   "Create Account"
      Height          =   1575
      Left            =   120
      TabIndex        =   1
      Top             =   2400
      Width           =   4095
      Begin VB.CommandButton cmdCreateAccount 
         Caption         =   "Create Account"
         Height          =   255
         Left            =   2640
         TabIndex        =   21
         Top             =   1080
         Width           =   1335
      End
      Begin VB.TextBox txtCreateAccountPlevel 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1320
         TabIndex        =   20
         Top             =   1080
         Width           =   1095
      End
      Begin VB.TextBox txtCreateAccountPassword 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1320
         TabIndex        =   19
         Top             =   720
         Width           =   1095
      End
      Begin VB.TextBox txtCreateAccountName 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1320
         TabIndex        =   18
         Top             =   360
         Width           =   1095
      End
      Begin VB.Label lblCreateAccountPlevel 
         Caption         =   "Plevel"
         Height          =   255
         Left            =   120
         TabIndex        =   17
         Top             =   1080
         Width           =   975
      End
      Begin VB.Label lblCreateAccountPassword 
         Caption         =   "Password:"
         Height          =   255
         Left            =   120
         TabIndex        =   16
         Top             =   720
         Width           =   855
      End
      Begin VB.Label lblCreateAccountName 
         Caption         =   "Account Name:"
         Height          =   255
         Left            =   120
         TabIndex        =   15
         Top             =   360
         Width           =   1215
      End
   End
   Begin VB.Frame frmAccountsManage 
      Caption         =   "Manage Accounts"
      Height          =   2175
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   4095
      Begin VB.CommandButton cmdAccountManagerSave 
         Caption         =   "Save Changes"
         Height          =   255
         Left            =   2640
         TabIndex        =   14
         Top             =   1560
         Width           =   1335
      End
      Begin VB.CheckBox chkAccountManagerStatus 
         Caption         =   "Banned Acc."
         Height          =   255
         Left            =   2640
         TabIndex        =   13
         Top             =   1200
         Width           =   1335
      End
      Begin VB.TextBox txtAccountManagerIP 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2880
         Locked          =   -1  'True
         TabIndex        =   12
         Top             =   840
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerID 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1200
         Locked          =   -1  'True
         TabIndex        =   10
         Text            =   "ID"
         Top             =   360
         Width           =   1815
      End
      Begin VB.CommandButton cmdAccountManagerNext 
         Caption         =   "->"
         Height          =   255
         Left            =   3120
         TabIndex        =   9
         Top             =   360
         Width           =   375
      End
      Begin VB.CommandButton cmdAccountManagerPrev 
         Caption         =   "<-"
         Height          =   255
         Left            =   720
         TabIndex        =   8
         Top             =   360
         Width           =   375
      End
      Begin VB.TextBox txtAccountManagerPlevel 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1320
         TabIndex        =   7
         Top             =   1560
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerPassword 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1320
         TabIndex        =   6
         Top             =   1200
         Width           =   1095
      End
      Begin VB.TextBox txtAccountManagerName 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1320
         TabIndex        =   5
         Top             =   840
         Width           =   1095
      End
      Begin VB.Label lblAccountManagerIP 
         Caption         =   "IP:"
         Height          =   255
         Left            =   2640
         TabIndex        =   11
         Top             =   840
         Width           =   255
      End
      Begin VB.Label lblAccountManagerPlevel 
         Caption         =   "Plevel:"
         Height          =   255
         Left            =   120
         TabIndex        =   4
         Top             =   1560
         Width           =   735
      End
      Begin VB.Label Label1 
         Caption         =   "Password:"
         Height          =   255
         Left            =   120
         TabIndex        =   3
         Top             =   1200
         Width           =   735
      End
      Begin VB.Label lblAccountManagerName 
         Caption         =   "Account Name:"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   840
         Width           =   1215
      End
   End
End
Attribute VB_Name = "frmAccountManager"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim AccManID As Integer

Private Sub cmdAccountManagerNext_Click()
If AccManID <= (UBound(Account) - 1) Then
    AccManID = AccManID + 1
    txtAccountManagerID.Text = AccManID
    modAccountSystem.AccountManagerUpdateFields (AccManID)
End If
End Sub

Private Sub cmdAccountManagerPrev_Click()
If AccManID >= (LBound(Account) + 1) Then
    AccManID = AccManID - 1
    txtAccountManagerID.Text = AccManID
    modAccountSystem.AccountManagerUpdateFields (AccManID)
End If
End Sub

Private Sub cmdAccountManagerSave_Click()
If txtAccountManagerID.Text <> "ID" Then
modAccountSystem.AccountManagerSaveFields (txtAccountManagerID.Text)
End If
End Sub

Private Sub cmdCreateAccount_Click()
'First we have to check if that account name already exists
Dim i As Integer
For i = LBound(Account) To UBound(Account)
    If Account(i).AccName = UCase(txtCreateAccountName.Text) Then
        MsgBox "Account " & UCase(txtCreateAccountName.Text) & " already exists", vbOKOnly + vbCritical, "Error"
        Exit Sub
    End If
Next i
'Else, we create a new ID and put it with all data
Dim intAccCreatedID As Integer
intAccCreatedID = UBound(Account) + 1
'We add an index to the Account array
ReDim Preserve Account(intAccCreatedID)
    txtCreateAccountName.Text = UCase(txtCreateAccountName.Text)
    txtCreateAccountPassword.Text = UCase(txtCreateAccountPassword.Text)
    Account(intAccCreatedID).AccID = intAccCreatedID
    Account(intAccCreatedID).AccName = txtCreateAccountName.Text
    Account(intAccCreatedID).AccPassword = txtCreateAccountPassword.Text
    Account(intAccCreatedID).AccPlevel = txtCreateAccountPlevel.Text
    modAccountSystem.LoadAccounts True
    modAccountSystem.LoadAccounts False
MsgBox "Account " & txtCreateAccountName.Text & " created succesfully", vbOKOnly + vbInformation, "Account creation"
End Sub

Private Sub Form_Load()
'Temporary fix
AccManID = -1
End Sub

