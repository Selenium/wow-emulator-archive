Option Strict Off
Option Explicit On
Friend Class frmSplash
	Inherits System.Windows.Forms.Form
	
	Private Sub frmSplash_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'lblProgress.Caption = "------------"
		'12
		Randomize()
		'frmMDI.Show
		'frmSplash.Hide
	End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		Timer1.Enabled = False
		frmMDI.Show()
		Me.Hide()
	End Sub
End Class