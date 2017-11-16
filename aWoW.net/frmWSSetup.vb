Option Strict Off
Option Explicit On
Friend Class frmWSSetup
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdWSRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWSRun.Click
		Me.lblWSStatus.Text = "World Server ONLINE"
		WS(0).LocalPort = CInt(txtWSPort.Text)
		WS(0).Listen()
		System_Renamed.LOG("Server started listening on " & WS(0).LocalIP & ":" & WS(0).LocalPort)
		Me.txtWSIP.Text = WS(0).LocalIP
	End Sub
	
	Private Sub Command1_Click()
		
	End Sub
	
	Private Sub frmWSSetup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Left = frmLog.Width
		Me.Top = frmMain.Height
	End Sub
	
	Private Sub WS_CloseEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WS.CloseEvent
		Dim Index As Short = WS.GetIndex(eventSender)
		WS(Index).Close()
		OpenSocketsWS(Index) = False
		LOG("  WS," & Index & " [" & WS(Index).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Disconected [Client]")
		If CDbl(WS(Index).Tag) <> -1 Then
			'this handle if in realm list client try to connect 2 times
			If Users(CInt(WS(Index).Tag)).WS = True Then Users(CInt(WS(Index).Tag)).Acc = ""
		End If
	End Sub
	
	Private Sub WS_ConnectionRequest(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent) Handles WS.ConnectionRequest
		Dim Index As Short = WS.GetIndex(eventSender)
		Dim i As Short
		For i = 1 To UBound(OpenSocketsWS)
			If OpenSocketsWS(i) = False Then
				WS(i).Accept(eventArgs.requestID)
				OpenSocketsWS(i) = True
				LOG("  WS," & i & " [" & WS(i).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Incoming connection")
				WS(i).Tag = -1
				WSFunctions.Send_SMSG_AUTH_CHALLENGE(i)
				Exit Sub
			End If
		Next i
		ReDim Preserve OpenSocketsWS(i)
		WS.Load(i)
		WS(i).LocalPort = CInt(txtWSPort.Text)
		WS(i).Accept(eventArgs.requestID)
		OpenSocketsWS(i) = True
		LOG("  WS," & i & " [" & WS(i).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Incoming connection")
		WS(i).Tag = -1
		WSFunctions.Send_SMSG_AUTH_CHALLENGE(i)
	End Sub
	
	Private Sub WS_DataArrival(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent) Handles WS.DataArrival
		Dim Index As Short = WS.GetIndex(eventSender)
		Dim data() As Byte
		WS(Index).GetData(data, VariantType.Array + VariantType.Byte)
		
		WSPacketAnalyzer.Analyze(Index, data)
	End Sub
	
	Private Sub WS_Error(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent) Handles WS.Error
		Dim Index As Short = WS.GetIndex(eventSender)
		WS(Index).Close()
		OpenSocketsWS(Index) = False
		LOG("  WS," & Index & " [" & WS(Index).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Disconected [Error on this connection!!!]")
		If CDbl(WS(Index).Tag) <> -1 Then Users(CInt(WS(Index).Tag)).Acc = ""
	End Sub
End Class