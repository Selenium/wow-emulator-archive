Option Strict Off
Option Explicit On
Friend Class frmLog
	Inherits System.Windows.Forms.Form
	
	Private Sub frmLog_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Height = VB6.TwipsToPixelsY(7000)
		Me.Width = VB6.TwipsToPixelsX(10000)
		System_Renamed.Initialize()
		Text2.Text = My.Application.Info.ProductName & vbNewLine
		Text2.Text = Text2.Text & "version " & VB6.Format(My.Application.Info.Version.Major, "0") & "." & VB6.Format(My.Application.Info.Version.Minor, "00") & "." & VB6.Format(My.Application.Info.Version.Revision, "0000") & vbNewLine
		PrintLine(109, Text2.Text)
	End Sub
	
	'UPGRADE_WARNING: Event frmLog.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmLog_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Text2.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 400)
		Text2.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 150)
	End Sub
	
	'UPGRADE_WARNING: Event Text2.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Text2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.TextChanged
		If Len(Text2.Text) > 60000 Then Text2.Text = Mid(Text2.Text, 10000)
	End Sub
End Class