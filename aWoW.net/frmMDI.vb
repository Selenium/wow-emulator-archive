Option Strict Off
Option Explicit On
Friend Class frmMDI
	Inherits System.Windows.Forms.Form
	
	Private Sub frmMDI_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Dim i As Integer
		ReDim F(20, 4095)
		ReDim sg(20)
		ReDim l(20)
		'For i = 4 To 12
		'    Main_Functions.bigint(i) = i
		'Next i
		
		
		frmLog.Show()
		frmMain.Show()
		frmWSSetup.Show()
		frmMisc.Show()
	End Sub
	
	Private Sub frmMDI_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Select Case MsgBox("Do you want to save server data before exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "aWoWe Server")
			Case MsgBoxResult.Yes
				Cancel = True
				System_Renamed.LOG("Requested server stopping...")
				System_Renamed.LOG("Starting save procedure...")
				System_Renamed.LOG("PLEASE WAIT")
				System_Renamed.Terminate()
				frmSplash.Close()
				End
			Case MsgBoxResult.Cancel
				Cancel = True
			Case MsgBoxResult.No
				frmSplash.Close()
				End
		End Select
		eventArgs.Cancel = Cancel
	End Sub
End Class