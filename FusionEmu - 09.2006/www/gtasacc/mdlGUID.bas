Attribute VB_Name = "mdlGUID"
Option Explicit
'API for user and message GUID's
Private Declare Function CoCreateGuid Lib "ole32" (id As Any) As Long
'API for TickCount, instead of Rnd Function to generate a unique number adding to datetime
Declare Function GetTickCount Lib "kernel32" () As Long

Function CreateGUID() As String
On Error Resume Next 'Creates GUID for users and alarms for ows / e-mail. (ADS alarms have already one guid per alarm)
    Static id(0 To 15) As Byte      'receives new guid in byte array. return from API
    Static lngArrCounter As Long    'allg. counter
    '[re]initialise array:
    Erase id
    If CoCreateGuid(id(0)) = 0 Then 'if we have successfully generated guid,
        For lngArrCounter = 0 To 15 'dump in unicode hex string
            CreateGUID = CreateGUID + IIf(id(lngArrCounter) < 16, "0", "") + Hex$(id(lngArrCounter))
        Next lngArrCounter
    Else 'if not, use system datetime and random long for mimicing a GUID
        CreateGUID = Format(Now, "yyyymmddhhnnss") & Right$("000000" & CStr(GetTickCount), 6) & Format(Now, "yyyymmddhhnnss") & Right$("000000" & CStr(GetTickCount), 6) & Format(Now, "yyyymmddhhnnss") & Right$("000000" & CStr(GetTickCount), 6)
    End If
    'convert string GUID to readable format:
    CreateGUID = UCase$(Left$(CreateGUID, 8) + "-" + Mid$(CreateGUID, 9, 4) + "-" + Mid$(CreateGUID, 13, 4) + "-" + Mid$(CreateGUID, 17, 4) + "-" + Right$(CreateGUID, 12))
End Function

