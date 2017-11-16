Option Strict Off
Option Explicit On
'UPGRADE_NOTE: Global was upgraded to Global_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
Module Global_Renamed
	
	Structure TUser
		'connection vars
		Dim IP As String
		Dim Sock As Short
		Dim SS_Hash As String
		Dim WS As Boolean
		'encoding and decodin
		<VBFixedArray(3)> Dim Key() As Byte
		<VBFixedArray(39)> Dim K() As Byte
		'accounting vars
		Dim Acc As String
		Dim Pass As String
		Dim PLevel As Byte
		'UPGRADE_NOTE: Char was upgraded to Char_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Char_Renamed() As String
		Dim Chars As Byte
		'temp vars
		Dim PublicB As String
		Dim V As String
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim Key(3)
			ReDim K(39)
		End Sub
	End Structure
	
	'general information vars
	Public Users_Count As Short
	Public Users() As TUser
	Public OpenSockets() As Boolean
	Public OpenSocketsWS() As Boolean
	Public MAX_CHARACTERS_PER_USER As Byte
	
	'version check vars
	Public rq_version1 As Byte
	Public rq_version2 As Byte
	Public rq_version3 As Byte
	Public rq_build As Short
	
	'realmlist vars
	Structure TRealmInfo
		Dim address As String
		Dim Name As String
		Dim Players As String
		Dim Status As Byte
	End Structure
	Public Realms_count As Byte
	Public Realms(10) As TRealmInfo
End Module