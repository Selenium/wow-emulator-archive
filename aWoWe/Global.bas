Attribute VB_Name = "Global"
Option Explicit

Type TUser
    'connection vars
    IP As String
    Sock As Integer
    SS_Hash As String
    WS As Boolean
    'encoding and decodin
    Key(3) As Byte
    K(39) As Byte
    
    'accounting vars
    Acc As String
    Pass As String
    PLevel As Byte
    Char() As String
    Chars As Byte
    
    'temp vars
    PublicB As String
    V As String
End Type

'general information vars
    Global Users_Count As Integer
    Global Users() As TUser
    Global OpenSockets() As Boolean
    Global OpenSocketsWS() As Boolean
    Global MAX_CHARACTERS_PER_USER As Byte

'version check vars
    Global rq_version1 As Byte
    Global rq_version2 As Byte
    Global rq_version3 As Byte
    Global rq_build As Integer

'realmlist vars
    Type TRealmInfo
        address As String
        Name As String
        Players As String
        Status As Byte
    End Type
    Global Realms_count As Byte
    Global Realms(10) As TRealmInfo


    
    
    
    
    
