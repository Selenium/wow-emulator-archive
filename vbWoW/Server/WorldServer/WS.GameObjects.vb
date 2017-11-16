' 
' Copyright (C) 2005-2007 vbWoW <http://www.vbwow.org/>
'
' This program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'

Imports System.Threading
Imports System.Runtime.CompilerServices
Imports vbWoW.Logbase.BaseWriter

Public Module WS_GameObjects

#Region "WS.GameObjects.TypeDef"






    'WARNING: Use only with GAMEOBJECTSDatabase()
    Public Class GameObjectInfo
        Implements IDisposable

        Public ID As Integer = 0
        Public Size As Single = 1.0F
        Public Faction As Integer = 0
        Public Flags As Integer = 0
        Public Model As Integer = 0
        Public Type As Byte = 0
        Public Name As String = ""
        Public Sounds(9) As Integer
        Public Loot As Integer = 0
        Private found_ As Boolean = False

        Public Sub New(ByVal ID_ As Integer)
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT * FROM adb_gameObjects WHERE gameObject_id = {0};", ID_), MySQLQuery)

            If MySQLQuery.Rows.Count = 0 Then
                Log.WriteLine(LogType.FAILED, "GameObject {0} not found in SQL database!", ID_)
                found_ = False
                Exit Sub
            End If
            found_ = True

            ID = ID_

            Model = MySQLQuery.Rows(0).Item("gameObject_Model")
            Size = MySQLQuery.Rows(0).Item("gameObject_Size")
            Faction = MySQLQuery.Rows(0).Item("gameObject_Faction")
            Flags = MySQLQuery.Rows(0).Item("gameObject_Flags")
            Type = MySQLQuery.Rows(0).Item("gameObject_Type")
            Name = MySQLQuery.Rows(0).Item("gameObject_Name")

            Sounds(0) = MySQLQuery.Rows(0).Item("gameObject_Sound0")
            Sounds(1) = MySQLQuery.Rows(0).Item("gameObject_Sound1")
            Sounds(2) = MySQLQuery.Rows(0).Item("gameObject_Sound2")
            Sounds(3) = MySQLQuery.Rows(0).Item("gameObject_Sound3")
            Sounds(4) = MySQLQuery.Rows(0).Item("gameObject_Sound4")
            Sounds(5) = MySQLQuery.Rows(0).Item("gameObject_Sound5")
            Sounds(6) = MySQLQuery.Rows(0).Item("gameObject_Sound6")
            Sounds(7) = MySQLQuery.Rows(0).Item("gameObject_Sound7")
            Sounds(8) = MySQLQuery.Rows(0).Item("gameObject_Sound8")
            Sounds(9) = MySQLQuery.Rows(0).Item("gameObject_Sound9")

            Loot = MySQLQuery.Rows(0).Item("gameObject_Loot")

            GAMEOBJECTSDatabase.Add(ID, Me)
        End Sub

        Public Sub Dispose() Implements System.IDisposable.Dispose
            GAMEOBJECTSDatabase.Remove(ID)
        End Sub
        Public Sub Save()
            If found_ = False Then
                Database.Update("INSERT INTO adb_gameObjects (gameObject_id)  VALUES (" & ID & ");")
            End If

            Dim tmp As String = "UPDATE adb_gameObjects SET"

            tmp = tmp & " gameObject_Model=""" & Model & """"
            tmp = tmp & ", gameObject_Size=""" & Trim(Str(Size)) & """"
            tmp = tmp & ", gameObject_Faction=""" & Faction & """"
            tmp = tmp & ", gameObject_Flags=""" & Flags & """"
            tmp = tmp & ", gameObject_Type=""" & Type & """"
            tmp = tmp & ", gameObject_Name='" & Name & "'"

            tmp = tmp & ", gameObject_Sound0=""" & Sounds(0) & """"
            tmp = tmp & ", gameObject_Sound1=""" & Sounds(1) & """"
            tmp = tmp & ", gameObject_Sound2=""" & Sounds(2) & """"
            tmp = tmp & ", gameObject_Sound3=""" & Sounds(3) & """"
            tmp = tmp & ", gameObject_Sound4=""" & Sounds(4) & """"
            tmp = tmp & ", gameObject_Sound5=""" & Sounds(5) & """"
            tmp = tmp & ", gameObject_Sound6=""" & Sounds(6) & """"
            tmp = tmp & ", gameObject_Sound7=""" & Sounds(7) & """"
            tmp = tmp & ", gameObject_Sound8=""" & Sounds(8) & """"
            tmp = tmp & ", gameObject_Sound9=""" & Sounds(9) & """"

            tmp = tmp & ", gameObject_Loot=""" & Loot & """"

            tmp = tmp + String.Format(" WHERE gameObject_id = ""{0}"";", ID)
            Database.Update(tmp)
        End Sub
    End Class
    'WARNING: Use only with WORLD_GAMEOBJECTs()
    Public Class GameObjectObject
        Inherits BaseObject
        Implements IDisposable

        Public ID As Integer = 0
        Public Flags As Integer = 0
        Public DynFlags As Integer = 0
        Public State As GameObjectLootState = GameObjectLootState.LOOT_UNLOOTED
        Public Rotation() As Single = {0, 0, 0, 0}

        Public ReadOnly Property Name() As String
            Get
                Return CType(GAMEOBJECTSDatabase(ID), GameObjectInfo).Name
            End Get
        End Property
        Public ReadOnly Property Type() As Byte
            Get
                Return CType(GAMEOBJECTSDatabase(ID), GameObjectInfo).Type
            End Get
        End Property
        Public ReadOnly Property Sound(ByVal Index As Byte) As Integer
            Get
                Return CType(GAMEOBJECTSDatabase(ID), GameObjectInfo).Sounds(Index)
            End Get
        End Property

        Public Sub FillAllUpdateFlags(ByRef Update As UpdateClass, ByRef Character As CharacterObject)
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_GUID, GUID)
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_TYPE, CType(ObjectType.TYPE_GAMEOBJECT + ObjectType.TYPE_OBJECT, Integer))
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_ENTRY, CType(ID, Integer))
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_SCALE_X, GAMEOBJECTSDatabase(ID).Size)

            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_POS_X, positionX)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_POS_Y, positionY)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_POS_Z, positionZ)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_FACING, orientation)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_DYN_FLAGS, DynFlags)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_STATE, State)

            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_FACTION, GAMEOBJECTSDatabase(ID).Faction)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_FLAGS, Flags)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_DISPLAYID, GAMEOBJECTSDatabase(ID).Model)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_TYPE_ID, GAMEOBJECTSDatabase(ID).Type)
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION, Rotation(0))
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION + 1, Rotation(1))
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION + 2, Rotation(2))
            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION + 3, Rotation(3))
            'Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_TIMESTAMP, 0)

            Update.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ANIMPROGRESS, 100)
        End Sub
        Private Sub Dispose() Implements System.IDisposable.Dispose
            Me.RemoveFromWorld()
            WORLD_GAMEOBJECTs.Remove(GUID)
        End Sub
        Public Sub New(ByVal ID_ As Integer)
            'WARNING: Use only for spawning new object
            If Not GAMEOBJECTSDatabase.ContainsKey(ID_) Then
                Dim baseGameObject As New GameObjectInfo(ID_)
            End If

            Flags = GAMEOBJECTSDatabase(ID_).Flags
            ID = ID_
            GUID = GetNewGUID()
            WORLD_GAMEOBJECTs.Add(GUID, Me)
        End Sub
        Public Sub New(ByVal cGUID As Long, Optional ByRef Info As DataRow = Nothing)
            'WARNING: Use only for loading from DB
            If Info Is Nothing Then
                Dim MySQLQuery As New DataTable
                Database.Query(String.Format("SELECT * FROM tmpspawnedgameobjects WHERE corpse_guid = {0};", cGUID), MySQLQuery)
                If MySQLQuery.Rows.Count > 0 Then
                    Info = MySQLQuery.Rows(0)
                Else
                    Log.WriteLine(LogType.FAILED, "GameObject not found in database. [cGUID={0:X}]", cGUID)
                End If
            End If

            positionX = Info.Item("gameobject_positionX")
            positionY = Info.Item("gameobject_positionY")
            positionZ = Info.Item("gameobject_positionZ")
            orientation = Info.Item("gameobject_orientation")
            MapID = Info.Item("gameobject_map")

            Rotation(0) = Info.Item("gameobject_rotation1")
            Rotation(1) = Info.Item("gameobject_rotation2")
            Rotation(2) = Info.Item("gameobject_rotation3")
            Rotation(3) = Info.Item("gameobject_rotation4")

            ID = Info.Item("gameObject_entry")

            If Not GAMEOBJECTSDatabase.ContainsKey(ID) Then
                Dim baseGameObject As New GameObjectInfo(ID)
            End If

            Flags = GAMEOBJECTSDatabase(ID).Flags

            GUID = cGUID + GUID_GAMEOBJECT
            WORLD_GAMEOBJECTs.Add(GUID, Me)
        End Sub
        Public Sub Save()
            Dim tmpCMD As String = "INSERT INTO tmpspawnedgameobjects (gameobject_guid"
            Dim tmpValues As String = " VALUES (" & (GUID - GUID_GAMEOBJECT)

            tmpCMD = tmpCMD & ", gameobject_rotation1"
            tmpValues = tmpValues & ", " & Trim(Str(Rotation(0)))
            tmpCMD = tmpCMD & ", gameobject_rotation2"
            tmpValues = tmpValues & ", " & Trim(Str(Rotation(1)))
            tmpCMD = tmpCMD & ", gameobject_rotation3"
            tmpValues = tmpValues & ", " & Trim(Str(Rotation(2)))
            tmpCMD = tmpCMD & ", gameobject_rotation4"
            tmpValues = tmpValues & ", " & Trim(Str(Rotation(3)))

            tmpCMD = tmpCMD & ", gameobject_positionX"
            tmpValues = tmpValues & ", " & Trim(Str(positionY))
            tmpCMD = tmpCMD & ", gameobject_positionY"
            tmpValues = tmpValues & ", " & Trim(Str(positionY))
            tmpCMD = tmpCMD & ", gameobject_positionZ"
            tmpValues = tmpValues & ", " & Trim(Str(positionZ))
            tmpCMD = tmpCMD & ", gameobject_mapid"
            tmpValues = tmpValues & ", " & MapID
            tmpCMD = tmpCMD & ", gameobject_orientation"
            tmpValues = tmpValues & ", " & Trim(Str(orientation))

            tmpCMD = tmpCMD & ", gameObject_entry"
            tmpValues = tmpValues & ", " & ID

            tmpCMD = tmpCMD & ") " & tmpValues & ");"
            Database.Update(tmpCMD)
        End Sub
        Public Sub AddToWorld()
            GetMapTile(positionX, positionY, CellX, CellY)
            If MapTiles(CellX, CellY) Is Nothing Then MAP_Load(CellX, CellY)
            Try
                MapTiles(CellX, CellY).GameObjectsHere.Add(GUID)
            Catch
                Exit Sub
            End Try

            Dim index As Integer
            Dim plGUID As Long

            'DONE: Sending to players in <CENTER> Cell
            If MapTiles(CellX, CellY).PlayersHere.Count > 0 Then
                'Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                'packet.AddInt32(1)
                'packet.AddInt8(0)
                'Dim tmpUpdate As New UpdateClass(300)
                'FillAllUpdateFlags(tmpUpdate)
                'tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, Me, 0)
                'tmpUpdate.Dispose

                With MapTiles(CellX, CellY)
                    index = 0
                    While index < .PlayersHere.Count
                        Try
                            plGUID = .PlayersHere.Item(index)
                            If CHARACTERS(plGUID).CanSee(Me) Then
                                Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                                packet.AddInt32(1)
                                packet.AddInt8(0)
                                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_GAMEOBJECT)
                                FillAllUpdateFlags(tmpUpdate, CHARACTERS(plGUID))
                                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, Me, 0)
                                tmpUpdate.Dispose()

                                CHARACTERS(plGUID).Client.SendMultiplyPackets(packet)
                                CHARACTERS(plGUID).gameObjectsNear.Add(GUID)
                                SeenBy.Add(plGUID)

                                packet.Dispose()
                            End If

                        Finally
                            index += 1
                        End Try
                    End While
                End With

                'packet.Dispose()
            End If

        End Sub
        Public Sub RemoveFromWorld()
            GetMapTile(positionX, positionY, CellX, CellY)
            MapTiles(CellX, CellY).GameObjectsHere.Remove(GUID)

            Dim index As Integer
            Dim plGUID As Long

            'DONE: Removing from players in <CENTER> Cell wich can see it
            If MapTiles(CellX, CellY).PlayersHere.Count > 0 Then
                With MapTiles(CellX, CellY)
                    index = 0
                    While index < .PlayersHere.Count
                        Try
                            plGUID = .PlayersHere.Item(index)
                            If CHARACTERS(plGUID).gameObjectsNear.Contains(GUID) Then
                                CHARACTERS(plGUID).guidsForRemoving.Add(GUID)
                                CHARACTERS(plGUID).gameObjectsNear.Remove(GUID)
                            End If
                        Finally
                            index += 1
                        End Try
                    End While
                End With
            End If
        End Sub

        Public Sub SpawnAnimation()
            Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
            packet.AddInt64(GUID)
            SendToNearPlayers(packet)
            packet.Dispose()
        End Sub
        Public Sub Respawn(ByVal state1 As Object, ByVal timeout As Boolean)
            Log.WriteLine(LogType.DEBUG, "Gameobject {0:X} respawning.", GUID)
            State = GameObjectLootState.LOOT_UNLOOTED
            Flags = GAMEOBJECTSDatabase(ID).Flags

            Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
            packet.AddInt32(1)
            packet.AddInt8(0)
            Dim UpdateData As New UpdateClass
            UpdateData.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_STATE, State)
            UpdateData.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_FLAGS, Flags)
            UpdateData.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, Me, 1)
            SendToNearPlayers(packet)
            UpdateData.Dispose()
            packet.Dispose()
        End Sub
        Public Sub Despawn()
            'TODO: Set respawn time
            Log.WriteLine(LogType.DEBUG, "Gameobject {0:X} despawning.", GUID)

            Dim packet As New PacketClass(OPCODES.SMSG_GAMEOBJECT_DESPAWN_ANIM)
            packet.AddInt64(GUID)
            SendToNearPlayers(packet)
            packet.Dispose()

            Me.Dispose()
        End Sub
        Public Sub Destroy()
            Dim packet As New PacketClass(OPCODES.SMSG_DESTROY_OBJECT)
            packet.AddInt64(GUID)
            SendToNearPlayers(packet)
            packet.Dispose()

            Me.Dispose()
        End Sub

        Public Sub TurnTo(ByRef Target As BaseObject)
            TurnTo(Target.positionX, Target.positionY)
        End Sub
        Public Sub TurnTo(ByVal x As Single, ByVal y As Single)
            orientation = GetOrientation(positionX, x, positionY, y)
            Rotation(2) = Math.Sin(orientation / 2)
            Rotation(3) = Math.Cos(orientation / 2)

            Dim index As Integer
            Dim plGUID As Long

            If SeenBy.Count > 0 Then

                'TODO: Rotation change is not visible with simple update
                Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                packet.AddInt32(2)
                packet.AddInt8(0)
                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_GAMEOBJECT)
                tmpUpdate.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_FACING, orientation)
                tmpUpdate.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION, Rotation(0))
                tmpUpdate.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION + 1, Rotation(1))
                tmpUpdate.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION + 2, Rotation(2))
                tmpUpdate.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_ROTATION + 3, Rotation(3))
                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, Me, 0)
                tmpUpdate.Dispose()

                index = 0
                While index < SeenBy.Count
                    plGUID = SeenBy.Item(index)
                    CHARACTERS(plGUID).Client.SendMultiplyPackets(packet)
                    index += 1
                End While

                packet.Dispose()
            End If
        End Sub
    End Class

    Public Enum GameObjectLootState As Integer
        DOOR_OPEN = 0
        DOOR_CLOSED = 1
        LOOT_UNAVIABLE = 0
        LOOT_UNLOOTED = 1
        LOOT_LOOTED = 2
    End Enum



#End Region
#Region "WS.GameObjects.HelperSubs"

    <MethodImplAttribute(MethodImplOptions.Synchronized)> _
    Private Function GetNewGUID() As Long
        GameObjectsGUIDCounter += 1
        GetNewGUID = GameObjectsGUIDCounter
    End Function
    Public Enum GameObjectType As Byte
        GAMEOBJECT_TYPE_DOOR = 0
        GAMEOBJECT_TYPE_BUTTON = 1
        GAMEOBJECT_TYPE_QUESTGIVER = 2
        GAMEOBJECT_TYPE_CHEST = 3
        GAMEOBJECT_TYPE_BINDER = 4
        GAMEOBJECT_TYPE_GENERIC = 5
        GAMEOBJECT_TYPE_TRAP = 6
        GAMEOBJECT_TYPE_CHAIR = 7
        GAMEOBJECT_TYPE_SPELL_FOCUS = 8
        GAMEOBJECT_TYPE_TEXT = 9
        GAMEOBJECT_TYPE_GOOBER = 10
        GAMEOBJECT_TYPE_TRANSPORT = 11
        GAMEOBJECT_TYPE_AREADAMAGE = 12
        GAMEOBJECT_TYPE_CAMERA = 13
        GAMEOBJECT_TYPE_MAP_OBJECT = 14
        GAMEOBJECT_TYPE_MO_TRANSPORT = 15
        GAMEOBJECT_TYPE_DUEL_ARBITER = 16
        GAMEOBJECT_TYPE_FISHINGNODE = 17
        GAMEOBJECT_TYPE_RITUAL = 18
        GAMEOBJECT_TYPE_MAILBOX = 19
        GAMEOBJECT_TYPE_AUCTIONHOUSE = 20
        GAMEOBJECT_TYPE_GUARDPOST = 21
        GAMEOBJECT_TYPE_SPELLCASTER = 22
        GAMEOBJECT_TYPE_MEETINGSTONE = 23
        GAMEOBJECT_TYPE_FLAGSTAND = 24
        GAMEOBJECT_TYPE_FISHINGHOLE = 25
        GAMEOBJECT_TYPE_FLAGDROP = 26
    End Enum

    Public Sub On_CMSG_GAMEOBJECT_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Dim response As New PacketClass(OPCODES.SMSG_GAMEOBJECT_QUERY_RESPONSE)

        packet.GetInt16()
        Dim GameObjectID As Integer = packet.GetInt32
        Dim GameObjectGUID As Long = packet.GetInt64

        Try
            Dim GameObject As GameObjectInfo

            If GAMEOBJECTSDatabase.ContainsKey(GameObjectID) = False Then
                Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GAMEOBJECT_QUERY [GameObject {2} not loaded.]", Client.IP, Client.Port, GameObjectID)
                Exit Sub
            Else
                GameObject = GAMEOBJECTSDatabase(GameObjectID)
                Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GAMEOBJECT_QUERY [GameObjectID={2} GameObjectGUID={3:X}]", Client.IP, Client.Port, GameObjectID, GameObjectGUID - GUID_GAMEOBJECT)
            End If

            response.AddInt32(GameObject.ID)
            response.AddInt32(GameObject.Type)
            response.AddInt32(GameObject.Model)
            response.AddString(GameObject.Name)
            response.AddInt32(0)                    'New in 1.12 - 4 strings
            response.AddInt16(0)                    'New in 2.0.3 - unk
            response.AddInt32(GameObject.Sounds(0))
            response.AddInt32(GameObject.Sounds(1))
            response.AddInt32(GameObject.Sounds(2))
            response.AddInt32(GameObject.Sounds(3))
            response.AddInt32(GameObject.Sounds(4))
            response.AddInt32(GameObject.Sounds(5))
            response.AddInt32(GameObject.Sounds(6))
            response.AddInt32(GameObject.Sounds(7))
            response.AddInt32(GameObject.Sounds(8))
            response.AddInt32(GameObject.Sounds(9))

            response.AddInt64(0)                     'New in 1.12 - 14 new fields
            response.AddInt64(0)
            response.AddInt64(0)
            response.AddInt64(0)
            response.AddInt64(0)
            response.AddInt64(0)
            response.AddInt64(0)
            response.AddInt16(0)

            Client.Send(response)
            response.Dispose()
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_GAMEOBJECT_QUERY_RESPONSE", Client.IP, Client.Port)
        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Unknown Error: Unable to find GameObjectID={0} in database.", GameObjectID)
        End Try
    End Sub
    Public Sub On_CMSG_GAMEOBJ_USE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GAMEOBJ_USE [GUID={2:X}]", Client.IP, Client.Port, GameObjectGUID)

        If Not WORLD_GAMEOBJECTs.ContainsKey(GameObjectGUID) Then Exit Sub

        Select Case CType(WORLD_GAMEOBJECTs(GameObjectGUID).Type, GameObjectType)

            Case GameObjectType.GAMEOBJECT_TYPE_DOOR
                'DONE: Doors opening
                CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject).State = GameObjectLootState.DOOR_OPEN

                Dim response As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                response.AddInt32(1)
                response.AddInt8(0)
                Dim UpdateData As New UpdateClass
                UpdateData.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_STATE, WORLD_GAMEOBJECTs(GameObjectGUID).State)
                UpdateData.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_FLAGS, WORLD_GAMEOBJECTs(GameObjectGUID).Flags)
                UpdateData.AddToPacket(response, ObjectUpdateType.UPDATETYPE_VALUES, CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject), 1)
                WORLD_GAMEOBJECTs(GameObjectGUID).SendToNearPlayers(response)
                UpdateData.Dispose()
                response.Dispose()

                ThreadPool.RegisterWaitForSingleObject(New AutoResetEvent(False), New WaitOrTimerCallback(AddressOf CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject).Respawn), Nothing, 6000, True)


            Case GameObjectType.GAMEOBJECT_TYPE_CHAIR
                'DONE: Chair sitting
                Client.Character.Teleport(CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject).positionX, CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject).positionY, CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject).positionZ, CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject).orientation)

                'STATE_SITTINGCHAIRLOW = 4
                'STATE_SITTINGCHAIRMEDIUM = 5
                'STATE_SITTINGCHAIRHIGH = 6
                Client.Character.StandState = (3 + CType(WORLD_GAMEOBJECTs(GameObjectGUID), GameObjectObject).Sound(1))


            Case GameObjectType.GAMEOBJECT_TYPE_QUESTGIVER
                Dim qm As QuestMenu = GetQuestMenuGO(Client.Character, GameObjectGUID)
                SendQuestMenu(Client.Character, GameObjectGUID, , qm)
        End Select
    End Sub

#End Region


End Module



#Region "WS.GameObjects.HelperTypes"
#End Region



