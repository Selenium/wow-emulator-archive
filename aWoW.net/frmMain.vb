Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form
	
	Private Sub chkEnableWS_Click()
		
	End Sub
	
	Private Sub cmdAddWS_Click()
		
	End Sub
	
	Private Sub cmdRemWS_Click()
		
	End Sub
	
	'UPGRADE_WARNING: Event chkOnline.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkOnline_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkOnline.CheckStateChanged
		RSPacketAnalyzer.UpdateRealms()
	End Sub
	
	Private Sub cmdRSRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRSRun.Click
		RSPacketAnalyzer.UpdateRealms()
		Me.lblRSStatus.Text = "Realm Server ONLINE"
		RS(0).LocalPort = CInt(txtRSPort.Text)
		RS(0).Listen()
		System_Renamed.LOG("Server started listening on " & RS(0).LocalIP & ":" & RS(0).LocalPort)
		Me.txtRSIP.Text = RS(0).LocalIP
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Users(Users_Count).Acc = "TEST"
		Get_Acc_Data(0)
		Send_Client_LOGON_CHALLENGE(1, (0))
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim a As String
		Dim M1 As String
		a = UCase("232fb1b88529643d95b8dce78f2750c75b2df37acba873eb31073839eda0738d")
		M1 = UCase("eeb4adca80f4de02f9a9fe8d000d682e3ddfad6f")
		Send_Client_LOGON_PROOF(a, M1, 1, 0)
	End Sub
	
	Private Sub Command3_Click()
		
	End Sub
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Left = frmLog.Width
		Me.Top = frmLog.Top
	End Sub
	
	Private Sub lstWSs_Click()
	End Sub
	
	Private Sub RS_CloseEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RS.CloseEvent
		Dim Index As Short = RS.GetIndex(eventSender)
		RS(Index).Close()
		OpenSockets(Index) = False
		LOG("  RS," & Index & " [" & RS(Index).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Disconected [Client]")
		If CDbl(RS(Index).Tag) <> -1 Then Users(CInt(RS(Index).Tag)).Acc = ""
	End Sub
	
	Private Sub RS_ConnectionRequest(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent) Handles RS.ConnectionRequest
		Dim Index As Short = RS.GetIndex(eventSender)
		Dim i As Short
		For i = 1 To UBound(OpenSockets)
			If OpenSockets(i) = False Then
				RS(i).Accept(eventArgs.requestID)
				OpenSockets(i) = True
				LOG("  RS," & i & " [" & RS(i).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Incoming connection")
				RS(i).Tag = -1
				Exit Sub
			End If
		Next i
		ReDim Preserve OpenSockets(i)
		RS.Load(i)
		RS(i).LocalPort = CInt(txtRSPort.Text)
		RS(i).Accept(eventArgs.requestID)
		OpenSockets(i) = True
		LOG("  RS," & i & " [" & RS(i).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Incoming connection")
		RS(i).Tag = -1
	End Sub
	
	Private Sub RS_DataArrival(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent) Handles RS.DataArrival
		Dim Index As Short = RS.GetIndex(eventSender)
		Dim data() As Byte
		RS(Index).GetData(data, VariantType.Array + VariantType.Byte)
		
		RSPacketAnalyzer.Analyze(Index, data)
	End Sub
	
	Private Sub RS_Error(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent) Handles RS.Error
		Dim Index As Short = RS.GetIndex(eventSender)
		RS(Index).Close()
		OpenSockets(Index) = False
		LOG("  RS," & Index & " [" & RS(Index).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Disconected [Error on this connection!!!]")
		If CDbl(RS(Index).Tag) <> -1 Then Users(CInt(RS(Index).Tag)).Acc = ""
	End Sub
End Class