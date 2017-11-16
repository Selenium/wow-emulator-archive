Option Strict Off
Option Explicit On
Module DataBase
	'====================================================================
	'Guids:
	'   0x00000000
	'   0x0000FFFF  - Player Characters - max 2bytes = 65536
	'   0x0001FFFF
	'   0x0020FFFF  - SpawnPoints
	'   0x0021FFFF
	'   0x0060FFFF  - Spawned Creatures
	'   0x0061FFFF
	'   0x00F0FFFF  - Game Objects
	'Guid=0x00000000 & [aWoWe GUID = 4bytes = Long]
	'
	'====================================================================
	'                            Users Vars
	'====================================================================
	
	Structure TItemsEquiped
		Dim ItemID As Short
		Dim DisplayID As Byte
	End Structure
	Structure TChar
		Dim Guid As Integer
		Dim Name As String
		Dim Race As Byte
		'UPGRADE_NOTE: Class was upgraded to Class_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Class_Renamed As Byte
		Dim Gender As Boolean
		Dim Skin As Byte
		Dim Face As Byte
		Dim Hairstyle As Byte
		Dim Haircolor As Byte
		Dim Facialhair As Byte
		Dim Outfitid As Byte 'not used!!
		Dim Level As Byte
		Dim Zoneid As Short
		Dim MapID As Short
		Dim positionX As Single
		Dim positionY As Single
		Dim positionZ As Single
		Dim GuildID As Short
		Dim Rest As Boolean
		Dim PetInfo As Short
		Dim PetLevel As Short
		Dim PetFamilyID As Short
		<VBFixedArray(20)> Dim ItemsEquiped() As TItemsEquiped
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			'UPGRADE_WARNING: Lower bound of array ItemsEquiped was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim ItemsEquiped(20)
		End Sub
	End Structure
	
	Public PlayerCharacters() As TChar
End Module