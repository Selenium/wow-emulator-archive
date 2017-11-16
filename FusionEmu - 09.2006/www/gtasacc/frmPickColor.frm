VERSION 5.00
Begin VB.Form frmPickColor 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Available Car colors:"
   ClientHeight    =   4875
   ClientLeft      =   45
   ClientTop       =   285
   ClientWidth     =   6315
   LinkTopic       =   "frmPickColor"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4875
   ScaleWidth      =   6315
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin GTASAControlCenter.GTA3ColorPicker PickCarColor 
      Height          =   4875
      Left            =   15
      TabIndex        =   0
      Top             =   15
      Width           =   6315
      _ExtentX        =   11139
      _ExtentY        =   8599
   End
End
Attribute VB_Name = "frmPickColor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public iPickColor As Integer

Public Sub SetPickColor(ByVal iColorIdxToSet As Integer)
    iPickColor = iColorIdxToSet
End Sub

Private Sub Form_Activate()
On Error Resume Next
    PickCarColor.intSelectedColorIndex = iPickColor
End Sub

Private Sub Form_GotFocus()
On Error Resume Next
    PickCarColor.intSelectedColorIndex = iPickColor
End Sub

Private Sub Form_Load()
On Error Resume Next
    PickCarColor.intSelectedColorIndex = iPickColor
End Sub

Private Sub PickCarColor_ColorPicked(ByVal isSelected As Boolean, ByVal intColorOrdinal As Integer)
On Error Resume Next
    If isSelected Then iPickColor = intColorOrdinal
    Me.Hide
End Sub
