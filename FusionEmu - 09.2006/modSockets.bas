Attribute VB_Name = "modSockets"
'Global sockets vars
Global sckRSUsed() As Boolean
Global sckWSUsed() As Boolean
Global sckHTUsed() As Boolean

Public Function CloseRealm()
'Vars
Dim i As Integer
'We close all realm sockets
    If UBound(sckRSUsed) > 0 Then
        For i = 0 To UBound(sckRSUsed)
        frmCore.sckRS(i).Close
        Log "sckRS(" & i & ") closed"
        Next i
        Log "Realm Server closed"
    Else
        frmCore.sckRS(0).Close
        Log "sckRS(0) closed"
        Log "Realm Server closed"
    End If
End Function

Public Function CloseWorld()
'Vars
Dim i As Integer
'We close all world sockets
    If UBound(sckWSUsed) > 0 Then
        For i = 0 To UBound(sckWSUsed)
        frmCore.sckWS(i).Close
        Log "sckWS(" & i & ") closed"
        Next i
        Log "World Server closed"
    Else
        frmCore.sckWS(0).Close
        Log "sckWS(0) closed"
        Log "World Server closed"
    End If
End Function

Public Function CloseHTTP()
'Vars
Dim i As Integer
'We close all world sockets
    If UBound(sckHTUsed) > 0 Then
        For i = 0 To UBound(sckHTUsed)
        frmCore.sckHT(i).Close
        Log "sckHT(" & i & ") closed"
        Next i
        Log "HTTP Server closed"
    Else
        frmCore.sckHT(0).Close
        Log "sckHT(0) closed"
        Log "HTTP Server closed"
    End If
End Function
