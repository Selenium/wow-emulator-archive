Attribute VB_Name = "DataBase"
Option Explicit
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

Type TItemsEquiped
    ItemID As Integer
    DisplayID As Byte
End Type
Type TChar
    Guid As Long
    Name As String
    Race As Byte
    Class As Byte
    Gender As Boolean
    Skin As Byte
    Face As Byte
    Hairstyle As Byte
    Haircolor As Byte
    Facialhair As Byte
    Outfitid As Byte    'not used!!
    Level As Byte
    Zoneid As Integer
    MapID As Integer
    positionX As Single
    positionY As Single
    positionZ As Single
    GuildID As Integer
    Rest As Boolean
    PetInfo As Integer
    PetLevel As Integer
    PetFamilyID As Integer
    ItemsEquiped(1 To 20) As TItemsEquiped
End Type

Global PlayerCharacters() As TChar
