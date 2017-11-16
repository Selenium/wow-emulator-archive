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

    Module WS_CharMovement

#Region "WS.CharacterMovement.MovementHandlers"
        Enum MovementFlags As Integer
            MOVEMENTFLAG_FORWARD = &H1
            MOVEMENTFLAG_BACKWARD = &H2
            MOVEMENTFLAG_STRAFE_LEFT = &H4
            MOVEMENTFLAG_STRAFE_RIGHT = &H8
            MOVEMENTFLAG_LEFT = &H10
            MOVEMENTFLAG_RIGHT = &H20
            MOVEMENTFLAG_PITCH_UP = &H40
            MOVEMENTFLAG_PITCH_DOWN = &H80
            MOVEMENTFLAG_WALK = &H100
            MOVEMENTFLAG_JUMPING = &H2000
            MOVEMENTFLAG_FALLING = &H4000
            MOVEMENTFLAG_SWIMMING = &H200000
            MOVEMENTFLAG_FLYING = &H800000
            MOVEMENTFLAG_ONTRANSPORT = &H2000000
            MOVEMENTFLAG_SPLINE = &H4000000
        End Enum

        Public Sub OnMovementPacket(ByRef packet As PacketClass, ByRef Client As ClientClass)
            packet.GetInt16()

            Client.Character.movementFlags = packet.GetInt32()
            Dim time As Integer = packet.GetInt32()
            Client.Character.positionX = packet.GetFloat()
            Client.Character.positionY = packet.GetFloat()
            Client.Character.positionZ = packet.GetFloat()
            Client.Character.orientation = packet.GetFloat()

#If DEBUG Then
            Log.WriteLine(LogType.NETWORK, "[{0}:{1}] {2} [0x{3:X} {4} {5} {6} {7}]", Client.IP, Client.Port, packet.OpCode, Client.Character.movementFlags, Client.Character.positionX, Client.Character.positionY, Client.Character.positionZ, Client.Character.orientation)
#End If

            If HaveFlags(Client.Character.movementFlags, MovementFlags.MOVEMENTFLAG_ONTRANSPORT) Then
                Dim transportGUID As Long = packet.GetInt64
                Dim transportX As Single = packet.GetFloat
                Dim transportY As Single = packet.GetFloat
                Dim transportZ As Single = packet.GetFloat
                Dim transportO As Single = packet.GetFloat
            End If
            If HaveFlags(Client.Character.movementFlags, MovementFlags.MOVEMENTFLAG_SWIMMING) Then
                Dim swimAngle As Single = packet.GetFloat
                '#If DEBUG Then
                '                Console.WriteLine("[{0}] [{1}:{2}] Client swim angle:{3}", Format(TimeOfDay, "hh:mm:ss"), Client.IP, Client.Port, swimAngle)
                '#End If
            End If
            If HaveFlags(Client.Character.movementFlags, MovementFlags.MOVEMENTFLAG_FALLING) Then
                Dim fallTime As Integer = packet.GetInt32
                '#If DEBUG Then
                '                Console.WriteLine("[{0}] [{1}:{2}] Client fall damage: {3}", Format(TimeOfDay, "hh:mm:ss"), Client.IP, Client.Port, fallTime)
                '#End If
            End If
            If HaveFlags(Client.Character.movementFlags, MovementFlags.MOVEMENTFLAG_JUMPING) Then
                Dim unk As Integer = packet.GetInt32
                Dim sinAngle As Single = packet.GetFloat
                Dim cosAngle As Single = packet.GetFloat
                Dim xySpeed As Single = packet.GetFloat
                '#If DEBUG Then
                '                Console.WriteLine("[{0}] [{1}:{2}] Client jump: 0x{3:X} {4} {5} {6}", Format(TimeOfDay, "hh:mm:ss"), Client.IP, Client.Port, unk, sinAngle, cosAngle, xySpeed)
                '#End If
            End If



            If Client.Character.exploreCheckQueued_ AndAlso (Not Client.Character.DEAD) Then
                Dim exploreFlag As Integer = GetAreaFlag(Client.Character.positionX, Client.Character.positionY)

                'DONE: Checking Explore System
                If exploreFlag <> &HFFFF Then
                    Dim areaFlag As Integer = exploreFlag Mod 32
                    Dim areaFlagOffset As Byte = exploreFlag \ 32

                    If HaveFlag(Client.Character.ZonesExplored(areaFlagOffset), areaFlag) = False Then
                        SetFlag(Client.Character.ZonesExplored(areaFlagOffset), areaFlag, True)

                        Dim GainedXP As Integer = AreaTable(exploreFlag).Level * 10
                        Dim percent As Integer = 100 - (((Client.Character.Level - AreaTable(exploreFlag).Level) - 5) * 5)
                        If percent < 0 Then percent = 0
                        If percent > 100 Then percent = 100
                        GainedXP = (GainedXP * percent) / 100

                        Dim SMSG_EXPLORATION_EXPERIENCE As New PacketClass(OPCODES.SMSG_EXPLORATION_EXPERIENCE)
                        SMSG_EXPLORATION_EXPERIENCE.AddInt32(AreaTable(exploreFlag).ID)
                        SMSG_EXPLORATION_EXPERIENCE.AddInt32(GainedXP)
                        Client.Send(SMSG_EXPLORATION_EXPERIENCE)
                        SMSG_EXPLORATION_EXPERIENCE.Dispose()

                        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_EXPLORED_ZONES_1 + areaFlagOffset, Client.Character.ZonesExplored(areaFlagOffset))
                        Client.Character.AddXP_NoLog(GainedXP)

                        'DONE: Fire quest event to check for if this area is used in explore area quest
                        OnQuestExplore(Client.Character, exploreFlag)
                    End If
                End If
            End If

            'DONE: Send to nearby players
            Dim response As New PacketClass(packet.OpCode)
            response.AddPackGUID(Client.Character.GUID)
            Dim tempArray(packet.Data.Length - 6) As Byte
            Array.Copy(packet.Data, 6, tempArray, 0, packet.Data.Length - 6)
            response.AddByteArray(tempArray)
            Client.Character.SendToNearPlayers(response)
            response.Dispose()
        End Sub
        Public Sub OnStartSwim(ByRef packet As PacketClass, ByRef Client As ClientClass)

            If (Client.Character.underWaterTimer Is Nothing) AndAlso (Not Client.Character.underWaterBreathing) AndAlso (Not Client.Character.DEAD) Then
                Client.Character.underWaterTimer = New TDrowingTimer(Client.Character)
            End If

            OnMovementPacket(packet, Client)
        End Sub
        Public Sub OnStopSwim(ByRef packet As PacketClass, ByRef Client As ClientClass)

            If Not Client.Character.underWaterTimer Is Nothing Then
                Client.Character.underWaterTimer.Dispose()
                Client.Character.underWaterTimer = Nothing
            End If

            OnMovementPacket(packet, Client)
        End Sub
        Public Sub OnFallLand(ByRef packet As PacketClass, ByRef Client As ClientClass)
            OnMovementPacket(packet, Client)

            Dim FallTime As Integer = packet.GetInt32
#If DEBUG Then
            Log.WriteLine(LogType.USER, "[{0}:{1}] Client fall damage: {2}", Client.IP, Client.Port, FallTime)
#End If

            'DONE: If FallTime > 1100 and not Dead
            If FallTime > 1000 AndAlso (Not Client.Character.DEAD) AndAlso Client.Character.positionZ > GetWaterLevel(Client.Character.positionX, Client.Character.positionY) Then
                Dim Damage As Integer = Client.Character.Life.Maximum * ((FallTime - 1000) / 2000)
                Client.Character.LogEnvironmentalDamage(EnviromentalDamage.DAMAGE_FALL, Damage)
                Client.Character.DealDamage(Damage)
            End If

            If Not Client.Character.underWaterTimer Is Nothing Then
                Client.Character.underWaterTimer.Dispose()
                Client.Character.underWaterTimer = Nothing
            End If
            If Not Client.Character.LogoutTimer Is Nothing Then
                'DONE: Initialize packet
                Dim UpdateData As New UpdateClass
                Dim SMSG_UPDATE_OBJECT As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                SMSG_UPDATE_OBJECT.AddInt32(1)      'Operations.Count
                SMSG_UPDATE_OBJECT.AddInt8(0)

                'DONE: Disable Turn
                SetFlag(Client.Character.cUnitFlags, UnitFlag.UNIT_FLAG_STUNTED, True)
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, Client.Character.cUnitFlags)
                'DONE: StandState -> Sit
                Client.Character.StandState = StandState.STANDSTATE_SIT
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_1, Client.Character.cBytes1)

                'DONE: Send packet
                UpdateData.AddToPacket(SMSG_UPDATE_OBJECT, ObjectUpdateType.UPDATETYPE_VALUES, CType(Client.Character, CharacterObject), 1)
                Client.Send(SMSG_UPDATE_OBJECT)
                SMSG_UPDATE_OBJECT.Dispose()
            End If

        End Sub
        Public Sub OnAreaTrigger(ByRef packet As PacketClass, ByRef Client As ClientClass)
            packet.GetInt16()
            Dim triggerID As Integer = packet.GetInt32
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_AREATRIGGER [triggerID={2}]", Client.IP, Client.Port, triggerID)

            If AreaTriggers.ContainsMethod("AreaTriggers", String.Format("HandleAreaTrigger_{0}", triggerID)) Then
                AreaTriggers.Invoke("AreaTriggers", String.Format("HandleAreaTrigger_{0}", triggerID), New Object() {Client.Character.GUID})
            Else
                Log.WriteLine(LogType.WARNING, "[{0}:{1}] AreaTrigger [{2}] not found!", Client.IP, Client.Port, triggerID)
            End If
        End Sub
        Public Sub OnZoneUpdate(ByRef packet As PacketClass, ByRef Client As ClientClass)
            packet.GetInt16()
            Dim newZone As Integer = packet.GetInt32
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_ZONEUPDATE [newZone={2}]", Client.IP, Client.Port, newZone)
            Client.Character.ZoneID = newZone
            Client.Character.exploreCheckQueued_ = True

            If HaveFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_RESTING) Then SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_RESTING, False)



            'DONE: Send weather
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT * FROM adb_weather WHERE weather_zone = {0};", Client.Character.ZoneID), MySQLQuery)
            If MySQLQuery.Rows.Count = 0 Then
                SendWeather(0, 0, Client)
            Else
                SendWeather(MySQLQuery.Rows(0).Item("weather_type"), MySQLQuery.Rows(0).Item("weather_intensity"), Client)
            End If
        End Sub
        Public Sub OnChangeSpeed(ByRef packet As PacketClass, ByRef Client As ClientClass)
            packet.GetInt16()
            Dim GUID As Long = packet.GetInt64

            If GUID <> Client.Character.GUID Then Exit Sub

            packet.GetInt32()
            Dim flags As Integer = packet.GetInt32()
            Dim time As Integer = packet.GetInt32()
            Client.Character.positionX = packet.GetFloat()
            Client.Character.positionY = packet.GetFloat()
            Client.Character.positionZ = packet.GetFloat()
            Client.Character.orientation = packet.GetFloat()
            Dim falltime As Single = packet.GetInt32()
            Dim newSpeed As Single = packet.GetFloat()

            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] {3} [{2}]", Client.IP, Client.Port, newSpeed, packet.OpCode)

            'DONE: Anti hack
            If Client.Character.antiHackSpeedChanged_ <= 0 Then
                Log.WriteLine(LogType.WARNING, "[{0}:{1}] CHEAT: Possible speed hack detected!", Client.IP, Client.Port)
                Client.Character.Logout(Nothing)
                Exit Sub
            End If

            'DONE: Update speed value and create packet
            Client.Character.antiHackSpeedChanged_ -= 1
            Select Case packet.OpCode
                Case OPCODES.CMSG_FORCE_RUN_SPEED_CHANGE_ACK
                    Client.Character.RunSpeed = newSpeed
                Case OPCODES.CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK
                    Client.Character.RunBackSpeed = newSpeed
                Case OPCODES.CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK
                    Client.Character.SwimBackSpeed = newSpeed
                Case OPCODES.CMSG_FORCE_SWIM_SPEED_CHANGE_ACK
                    Client.Character.SwimSpeed = newSpeed
                Case OPCODES.CMSG_FORCE_TURN_RATE_CHANGE_ACK
                    Client.Character.TurnRate = newSpeed
                Case OPCODES.CMSG_FORCE_FLY_SPEED_CHANGE_ACK
                    Client.Character.FlySpeed = newSpeed
                Case OPCODES.CMSG_FORCE_FLY_BACK_SPEED_CHANGE_ACK
                    Client.Character.FlyBackSpeed = newSpeed
            End Select
        End Sub

        Public Sub On_MSG_MOVE_HEARTBEAT(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_MOVE_HEARTBEAT", Client.IP, Client.Port)

            OnMovementPacket(packet, Client)

            If Client.Character.CellX <> GetMapTileX(Client.Character.positionX) Or Client.Character.CellY <> GetMapTileY(Client.Character.positionY) Then
                MoveCell(Client.Character)
            End If
            UpdateCell(Client.Character)

            'DONE: Update ZoneID
            Client.Character.ZoneID = AreaTable(GetAreaFlag(Client.Character.positionX, Client.Character.positionY)).Zone

            'DONE: Check for out of continent - coordinates from WorldMapContinent.dbc
            If IsOutsideOfMap(Client.Character) Then
                If Client.Character.outsideMapID_ = False Then
                    Client.Character.outsideMapID_ = True
                    Client.Character.StartMirrorTimer(MirrorTimer.FATIGUE, 30000)
                End If
            Else
                If Client.Character.outsideMapID_ = True Then
                    Client.Character.outsideMapID_ = False
                    Client.Character.StopMirrorTimer(MirrorTimer.FATIGUE)
                End If
            End If

            'DONE: Duel check
            If Client.Character.IsInDuel Then CheckDuelDistance(Client.Character)
        End Sub

        Public Function IsOutsideOfMap(ByRef c As BaseObject) As Boolean
#If HANDLED_MAP_ID = 0 Then
            'Azeroth
            If c.positionX > 8533.0F Or c.positionX < -15470.0F Then
                Log.WriteLine(LogType.USER, "Outside map: {0:X}", c.GUID)
                Return True
            ElseIf c.positionY > 11200.0F Or c.positionY < -12800.0F Then
                Log.WriteLine(LogType.USER, "Outside map: {0:X}", c.GUID)
                Return True
            Else
                Return False
            End If
#ElseIf HANDLED_MAP_ID = 1 Then
             'Kalimdor
            If c.positionX > 12470.0F Or c.positionX < -11870.0F Then
                Return True
            ElseIf c.positionY > 10970.0F Or c.positionY < -13370.0F Then
                Return True
            Else
                Return False
            End If
#ElseIf HANDLED_MAP_ID = 530 Then
            'Expansion1
            If c.positionX > 6400.0F Or c.positionX < -5967.0F Then
                Return True
            ElseIf c.positionY > 10670.0F Or c.positionY < -1600.0F Then
                Return True
            Else
                Return False
            End If
#End If
        End Function


#End Region
#Region "WS.CharacterMovement.CellFramework"


        Public Sub MAP_Load(ByVal x As Byte, ByVal y As Byte)
            For i As Short = -1 To 1
                For j As Short = -1 To 1
                    If x + i > -1 AndAlso x + i < 64 AndAlso y + j > -1 AndAlso y + j < 64 Then
                        If MapTiles(x + i, y + j) Is Nothing Then MapTiles(x + i, y + j) = New TMapTile(String.Format("{0}{1}{2}.map", Format(HANDLED_MAP_ID, "000"), Format(x + i, "00"), Format(y + j, "00")))
                    End If
                Next
            Next
        End Sub
        Public Sub MAP_UnLoad(ByVal x As Byte, ByVal y As Byte)
            If MapTiles(x, y).PlayersHere.Count = 0 Then
                Log.WriteLine(LogType.INFORMATION, "Unloading map [{1},{2}]...", x, y)
                MapTiles(x, y).Dispose()
                MapTiles(x, y) = Nothing
            End If
        End Sub

        Public Sub AddToWorld(ByRef Character As CharacterObject)
            GetMapTile(Character.positionX, Character.positionY, Character.CellX, Character.CellY)

            'DONE: Dynamic map loading
            If MapTiles(Character.CellX, Character.CellY) Is Nothing Then MAP_Load(Character.CellX, Character.CellY)




            'DONE: Creating packet for this Character
            'Dim myPacket As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
            'myPacket.AddInt32(1)
            'myPacket.AddInt8(0)
            'Dim myTmpUpdate As New UpdateClass(EPlayerFields.PLAYER_END)
            'Character.FillAllUpdateFlags(myTmpUpdate, False, Nothing)
            'myTmpUpdate.AddToPacket(myPacket, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, Character, 0)

            Dim index As Integer
            Dim GUID As Long = 0

            'DONE: Sending near players in <CENTER> Cell
            If MapTiles(Character.CellX, Character.CellY).PlayersHere.Count > 0 Then
                With MapTiles(Character.CellX, Character.CellY)
                    index = 0
                    While index < .PlayersHere.Count
                        Try
                            GUID = .PlayersHere.Item(index)
                            If Character.CanSee(CHARACTERs(GUID)) Then
                                'If Math.Sqrt((Character.positionX - CHARACTERs(GUID).positionX) ^ 2 + (Character.positionY - CHARACTERs(GUID).positionY) ^ 2) < DEFAULT_VISIBLE_DISTANCE Then
                                Dim packet As New UpdatePacketClass
                                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_PLAYER)
                                CHARACTERs(GUID).FillAllUpdateFlags(tmpUpdate, Character)
                                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(CHARACTERs(GUID), CharacterObject), 0)
                                tmpUpdate.Dispose()
                                Character.Client.Send(packet)
                                packet.Dispose()

                                CHARACTERs(GUID).SeenBy.Add(Character.GUID)
                                Character.playersNear.Add(GUID)
                            End If
                            If CHARACTERs(GUID).CanSee(Character) Then
                                Dim myPacket As New UpdatePacketClass
                                Dim myTmpUpdate As New UpdateClass(FIELD_MASK_SIZE_PLAYER)
                                Character.FillAllUpdateFlags(myTmpUpdate, CHARACTERs(GUID))
                                myTmpUpdate.AddToPacket(myPacket, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, Character, 0)
                                myTmpUpdate.Dispose()
                                CHARACTERs(GUID).Client.Send(myPacket)
                                myPacket.Dispose()
                                'CHARACTERs(GUID).Client.SendMultiplyPackets(myPacket)

                                Character.SeenBy.Add(GUID)
                                CHARACTERs(GUID).playersNear.Add(Character.GUID)
                            End If
                        Finally
                            index += 1
                        End Try
                    End While
                End With
            End If



            'DONE: Cleanig
            'myPacket.Dispose()
            MapTiles(Character.CellX, Character.CellY).PlayersHere.Add(Character.GUID)


            'DONE: Sending near Creatures in <CENTER> Cell
            If MapTiles(Character.CellX, Character.CellY).CreaturesHere.Count > 0 Then
                With MapTiles(Character.CellX, Character.CellY)
                    index = 0
                    While index < .CreaturesHere.Count
                        Try
                            GUID = .CreaturesHere.Item(index)
                            If Character.CanSee(WORLD_CREATUREs(GUID)) Then
                                'If Math.Sqrt((Character.positionX - WORLD_CREATUREs(GUID).positionX) ^ 2 + (Character.positionY - WORLD_CREATUREs(GUID).positionY) ^ 2) < DEFAULT_VISIBLE_DISTANCE Then
                                Dim packet As New UpdatePacketClass
                                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_UNIT)
                                WORLD_CREATUREs(GUID).FillAllUpdateFlags(tmpUpdate, Character)
                                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(WORLD_CREATUREs(GUID), CreatureObject), 0)
                                tmpUpdate.Dispose()
                                Character.Client.Send(packet)
                                packet.Dispose()

                                Character.creaturesNear.Add(GUID)
                                WORLD_CREATUREs(GUID).SeenBy.Add(Character.GUID)
                            End If
                        Finally
                            index += 1
                        End Try
                    End While
                End With
            End If

            'DONE: Sending near GameObjects in <CENTER> Cell
            If MapTiles(Character.CellX, Character.CellY).GameObjectsHere.Count > 0 Then
                With MapTiles(Character.CellX, Character.CellY)
                    index = 0
                    While index < .GameObjectsHere.Count
                        Try
                            GUID = .GameObjectsHere.Item(index)
                            If Not Character.gameObjectsNear.Contains(GUID) Then
                                If Character.CanSee(WORLD_GAMEOBJECTs(GUID)) Then
                                    Dim packet As New UpdatePacketClass
                                    If WORLD_GAMEOBJECTs(GUID).GetType Is GetType(GameObjectObject) Then
                                        Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_GAMEOBJECT)
                                        WORLD_GAMEOBJECTs(GUID).FillAllUpdateFlags(tmpUpdate, Character)
                                        tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(WORLD_GAMEOBJECTs(GUID), GameObjectObject), 0)
                                        tmpUpdate.Dispose()
                                    ElseIf WORLD_GAMEOBJECTs(GUID).GetType Is GetType(CorpseObject) Then
                                        Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_CORPSE)
                                        WORLD_GAMEOBJECTs(GUID).FillAllUpdateFlags(tmpUpdate, Character)
                                        tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(WORLD_GAMEOBJECTs(GUID), CorpseObject), 0)
                                        tmpUpdate.Dispose()
                                    Else
                                        Log.WriteLine(LogType.WARNING, "GameObject type not found for {0:X}!", GUID)
                                    End If
                                    Character.Client.Send(packet)
                                    packet.Dispose()

                                    Character.gameObjectsNear.Add(GUID)
                                    WORLD_GAMEOBJECTs(GUID).SeenBy.Add(Character.GUID)
                                End If
                            End If
                        Finally
                            index += 1
                        End Try
                    End While
                End With
            End If

        End Sub
        Public Sub RemoveFromWorld(ByRef Character As CharacterObject)
            If Not MapTiles(Character.CellX, Character.CellY) Is Nothing Then
                'DONE: Remove character from map
                GetMapTile(Character.positionX, Character.positionY, Character.CellX, Character.CellY)
                MapTiles(Character.CellX, Character.CellY).PlayersHere.Remove(Character.GUID)
            End If




            Dim index As Integer
            Dim GUID As Long

            'DONE: Removing from players wich can see it
            While index < Character.SeenBy.Count
                Try
                    GUID = Character.SeenBy.Item(index)
                    If CHARACTERs(GUID).playersNear.Contains(Character.GUID) Then
                        CHARACTERs(GUID).playersNear.Remove(Character.GUID)
                        CHARACTERs(GUID).guidsForRemoving.Add(Character.GUID)
                    End If
                    'DONE: Fully clean
                    CHARACTERs(GUID).SeenBy.Remove(Character.GUID)
                Finally
                    index += 1
                End Try
            End While
            Character.playersNear.Clear()
            Character.SeenBy.Clear()

            'DONE: Removing from creatures wich can see it
            index = 0
            While index < Character.creaturesNear.Count
                Try
                    GUID = Character.creaturesNear.Item(index)
                    If WORLD_CREATUREs(GUID).SeenBy.Contains(Character.GUID) Then
                        WORLD_CREATUREs(GUID).SeenBy.Remove(Character.GUID)
                    End If
                Finally
                    index += 1
                End Try
            End While
            Character.creaturesNear.Clear()

            'DONE: Removing from gameObjects wich can see it
            index = 0
            While index < Character.gameObjectsNear.Count
                Try
                    GUID = Character.gameObjectsNear.Item(index)
                    If WORLD_GAMEOBJECTs(GUID).SeenBy.Contains(Character.GUID) Then
                        WORLD_GAMEOBJECTs(GUID).SeenBy.Remove(Character.GUID)
                    End If
                Finally
                    index += 1
                End Try
            End While
            Character.gameObjectsNear.Clear()
        End Sub
        Public Sub MoveCell(ByRef Character As CharacterObject)
            MapTiles(Character.CellX, Character.CellY).PlayersHere.Remove(Character.GUID)
            GetMapTile(Character.positionX, Character.positionY, Character.CellX, Character.CellY)
            MapTiles(Character.CellX, Character.CellY).PlayersHere.Add(Character.GUID)

            MAP_Load(Character.CellX, Character.CellY)
        End Sub
        Public Sub UpdateCell(ByRef Character As CharacterObject)
            Dim index As Integer
            Dim GUID As Long = 0

            'DONE: Remove players,creatures,objects if dist is >
            index = 0
            While index < Character.playersNear.Count
                Try
                    GUID = Character.playersNear.Item(index)
                    If Not Character.CanSee(CHARACTERs(GUID)) Then
                        CHARACTERs(GUID).SeenBy.Remove(Character.GUID)
                        Character.playersNear.Remove(GUID)
                        Character.guidsForRemoving.Add(GUID)
                    End If
                    'Remove me for him
                    If (Not CHARACTERs(GUID).CanSee(Character)) AndAlso Character.SeenBy.Contains(GUID) Then
                        Character.SeenBy.Remove(GUID)
                        CHARACTERs(GUID).playersNear.Remove(Character.GUID)
                        CHARACTERs(GUID).guidsForRemoving.Add(Character.GUID)
                    End If
                Finally
                    index += 1
                End Try
            End While

            index = 0
            While index < Character.creaturesNear.Count
                Try
                    GUID = Character.creaturesNear.Item(index)
                    If Not Character.CanSee(WORLD_CREATUREs(GUID)) Then
                        WORLD_CREATUREs(GUID).SeenBy.Remove(Character.GUID)
                        Character.creaturesNear.Remove(GUID)
                        Character.guidsForRemoving.Add(GUID)
                    End If
                Finally
                    index += 1
                End Try
            End While

            index = 0
            While index < Character.gameObjectsNear.Count
                Try
                    GUID = Character.gameObjectsNear.Item(index)
                    If Not Character.CanSee(WORLD_GAMEOBJECTs(GUID)) Then
                        WORLD_GAMEOBJECTs(GUID).SeenBy.Remove(Character.GUID)
                        Character.gameObjectsNear.Remove(GUID)
                        Character.guidsForRemoving.Add(GUID)
                    End If
                Finally
                    index += 1
                End Try
            End While

            'DONE: Add new if dist is <
            Dim CellXAdd As Short = -1
            Dim CellYAdd As Short = -1
            If GetSubMapTileX(Character.positionX) > 32 Then CellXAdd = 1
            If GetSubMapTileX(Character.positionY) > 32 Then CellYAdd = 1
            If (Character.CellX + CellXAdd) > 63 Or (Character.CellX + CellXAdd) < 0 Then CellXAdd = 0
            If (Character.CellY + CellYAdd) > 63 Or (Character.CellY + CellYAdd) < 0 Then CellYAdd = 0

            'DONE: Sending near creatures in <CENTER CELL>
            If MapTiles(Character.CellX, Character.CellY).CreaturesHere.Count > 0 Then
                UpdateCreaturesInCell(MapTiles(Character.CellX, Character.CellY), Character)
            End If
            'DONE: Sending near players in <CENTER CELL>
            If MapTiles(Character.CellX, Character.CellY).PlayersHere.Count > 0 Then
                UpdatePlayersInCell(MapTiles(Character.CellX, Character.CellY), Character)
            End If
            'DONE: Sending near gameobjects in <CENTER CELL>
            If MapTiles(Character.CellX, Character.CellY).GameObjectsHere.Count > 0 Then
                UpdateGameObjectsInCell(MapTiles(Character.CellX, Character.CellY), Character)
            End If


            If CellXAdd <> 0 Then
                'DONE: Sending near creatures in <LEFT/RIGHT CELL>
                If MapTiles(Character.CellX + CellXAdd, Character.CellY).CreaturesHere.Count > 0 Then
                    UpdateCreaturesInCell(MapTiles(Character.CellX + CellXAdd, Character.CellY), Character)
                End If
                'DONE: Sending near players in <LEFT/RIGHT CELL>
                If MapTiles(Character.CellX + CellXAdd, Character.CellY).PlayersHere.Count > 0 Then
                    UpdatePlayersInCell(MapTiles(Character.CellX + CellXAdd, Character.CellY), Character)
                End If
                'DONE: Sending near gameobjects in <LEFT/RIGHT CELL>
                If MapTiles(Character.CellX + CellXAdd, Character.CellY).GameObjectsHere.Count > 0 Then
                    UpdateGameObjectsInCell(MapTiles(Character.CellX + CellXAdd, Character.CellY), Character)
                End If
            End If


            If CellYAdd <> 0 Then
                'DONE: Sending near creatures in <TOP/BOTTOM CELL>
                If MapTiles(Character.CellX, Character.CellY + CellYAdd).CreaturesHere.Count > 0 Then
                    UpdateCreaturesInCell(MapTiles(Character.CellX, Character.CellY + CellYAdd), Character)
                End If
                'DONE: Sending near players in <TOP/BOTTOM CELL>
                If MapTiles(Character.CellX, Character.CellY + CellYAdd).PlayersHere.Count > 0 Then
                    UpdatePlayersInCell(MapTiles(Character.CellX, Character.CellY + CellYAdd), Character)
                End If
                'DONE: Sending near gameobjects in <TOP/BOTTOM CELL>
                If MapTiles(Character.CellX, Character.CellY + CellYAdd).GameObjectsHere.Count > 0 Then
                    UpdateGameObjectsInCell(MapTiles(Character.CellX, Character.CellY + CellYAdd), Character)
                End If
            End If


            If CellYAdd <> 0 AndAlso CellXAdd <> 0 Then
                'DONE: Sending near creatures in <CORNER CELL>
                If MapTiles(Character.CellX + CellXAdd, Character.CellY + CellYAdd).CreaturesHere.Count > 0 Then
                    UpdateCreaturesInCell(MapTiles(Character.CellX + CellXAdd, Character.CellY + CellYAdd), Character)
                End If
                'DONE: Sending near players in <LEFT/RIGHT CELL>
                If MapTiles(Character.CellX + CellXAdd, Character.CellY + CellYAdd).PlayersHere.Count > 0 Then
                    UpdatePlayersInCell(MapTiles(Character.CellX + CellXAdd, Character.CellY + CellYAdd), Character)
                End If
                'DONE: Sending near gameobjects in <LEFT/RIGHT CELL>
                If MapTiles(Character.CellX + CellXAdd, Character.CellY + CellYAdd).GameObjectsHere.Count > 0 Then
                    UpdateGameObjectsInCell(MapTiles(Character.CellX + CellXAdd, Character.CellY + CellYAdd), Character)
                End If
            End If

            Character.SendOutOfRangeUpdate()
        End Sub

        <MethodImplAttribute(MethodImplOptions.Synchronized)> _
        Public Sub UpdatePlayersInCell(ByRef MapTile As TMapTile, ByRef Character As CharacterObject)
            Dim index As Integer = 0
            Dim GUID As Long
            With MapTile
                index = 0
                While index < .PlayersHere.Count
                    Try
                        GUID = .PlayersHere.Item(index)
                        'DONE: Send to me
                        If Not CHARACTERs(GUID).SeenBy.Contains(Character.GUID) Then
                            If Character.CanSee(CHARACTERs(GUID)) Then
                                Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                                packet.AddInt32(1)
                                packet.AddInt8(0)
                                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_PLAYER)
                                CHARACTERs(GUID).FillAllUpdateFlags(tmpUpdate, Character)
                                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(CHARACTERs(GUID), CharacterObject), 0)
                                tmpUpdate.Dispose()
                                Character.Client.Send(packet)
                                packet.Dispose()

                                CHARACTERs(GUID).SeenBy.Add(Character.GUID)
                                Character.playersNear.Add(GUID)
                            End If
                        End If
                        'DONE: Send to him
                        If Not Character.SeenBy.Contains(GUID) Then
                            If CHARACTERs(GUID).CanSee(Character) Then
                                Dim myPacket As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                                myPacket.AddInt32(1)
                                myPacket.AddInt8(0)
                                Dim myTmpUpdate As New UpdateClass(FIELD_MASK_SIZE_PLAYER)
                                Character.FillAllUpdateFlags(myTmpUpdate, CHARACTERs(GUID))
                                myTmpUpdate.AddToPacket(myPacket, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, Character, 0)
                                myTmpUpdate.Dispose()

                                CHARACTERs(GUID).Client.Send(myPacket)
                                myPacket.Dispose()

                                Character.SeenBy.Add(GUID)
                                CHARACTERs(GUID).playersNear.Add(Character.GUID)
                            End If
                        End If
                    Finally
                        index += 1
                    End Try
                End While
            End With
        End Sub
        Public Sub UpdateCreaturesInCell(ByRef MapTile As TMapTile, ByRef Character As CharacterObject)
            Dim index As Integer = 0
            Dim GUID As Long
            With MapTile
                index = 0
                While index < .CreaturesHere.Count
                    Try
                        GUID = .CreaturesHere.Item(index)
                        If Not Character.creaturesNear.Contains(GUID) Then
                            If Character.CanSee(WORLD_CREATUREs(GUID)) Then
                                Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                                packet.AddInt32(1)
                                packet.AddInt8(0)
                                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_UNIT)
                                WORLD_CREATUREs(GUID).FillAllUpdateFlags(tmpUpdate, Character)
                                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(WORLD_CREATUREs(GUID), CreatureObject), 0)
                                tmpUpdate.Dispose()
                                Character.Client.Send(packet)
                                packet.Dispose()

                                Character.creaturesNear.Add(GUID)
                                WORLD_CREATUREs(GUID).SeenBy.Add(Character.GUID)
                            End If
                        End If
                    Finally
                        index += 1
                    End Try
                End While
            End With
        End Sub
        Public Sub UpdateGameObjectsInCell(ByRef MapTile As TMapTile, ByRef Character As CharacterObject)
            With MapTile

                Dim index As Integer = 0
                Dim GUID As Long
                While index < .GameObjectsHere.Count
                    Try
                        GUID = .GameObjectsHere.Item(index)
                        If Not Character.gameObjectsNear.Contains(GUID) Then
                            If Character.CanSee(WORLD_GAMEOBJECTs(GUID)) Then
                                Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                                packet.AddInt32(1)
                                packet.AddInt8(0)
                                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_GAMEOBJECT)
                                WORLD_GAMEOBJECTs(GUID).FillAllUpdateFlags(tmpUpdate, Character)
                                If TypeOf WORLD_GAMEOBJECTs(GUID) Is GameObjectObject Then
                                    tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(WORLD_GAMEOBJECTs(GUID), GameObjectObject), 0)
                                ElseIf WORLD_GAMEOBJECTs(GUID).GetType Is GetType(CorpseObject) Then
                                    tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, CType(WORLD_GAMEOBJECTs(GUID), CorpseObject), 0)
                                Else
                                    Log.WriteLine(LogType.WARNING, "GameObject type not found for {0:X}!", GUID)
                                End If
                                tmpUpdate.Dispose()
                                Character.Client.Send(packet)
                                packet.Dispose()

                                Character.gameObjectsNear.Add(GUID)
                                WORLD_GAMEOBJECTs(GUID).SeenBy.Add(Character.GUID)
                            End If
                        End If
                    Finally
                        index += 1
                    End Try
                End While

            End With
        End Sub


#End Region

        Public Sub SendWeather(ByVal Type As Byte, ByVal Intensity As Single, ByRef Client As ClientClass)
            ' WEATHER_SOUND_NOSOUND                 0
            ' WEATHER_SOUND_RAINLIGHT               8533
            ' WEATHER_SOUND_RAINMEDIUM              8534
            ' WEATHER_SOUND_RAINHEAVY               8535
            ' WEATHER_SOUND_SNOWLIGHT               8536
            ' WEATHER_SOUND_SNOWMEDIUM              8537
            ' WEATHER_SOUND_SNOWHEAVY               8538
            ' WEATHER_SOUND_SANDSTORMLIGHT          8556
            ' WEATHER_SOUND_SANDSTORMMEDIUM         8557
            ' WEATHER_SOUND_SANDSTORMHEAVY          8558

            ' WEATHER_RAIN							1
            ' WEATHER_SNOW							2
            ' WEATHER_SANDSTORM						3

            Dim SMSG_WEATHER As New PacketClass(OPCODES.SMSG_WEATHER)
            SMSG_WEATHER.AddInt32(Type)
            SMSG_WEATHER.AddSingle(Intensity)
            'SMSG_WEATHER.AddInt32(Sound)
            Select Case Intensity
                Case 0
                    SMSG_WEATHER.AddInt32(0)
                Case Is <= 0.33
                    If Type = 1 Then SMSG_WEATHER.AddInt32(8533)
                    If Type = 2 Then SMSG_WEATHER.AddInt32(8533 + 3)
                    If Type = 3 Then SMSG_WEATHER.AddInt32(8533 + 23)
                Case Is <= 0.66
                    If Type = 1 Then SMSG_WEATHER.AddInt32(8534)
                    If Type = 2 Then SMSG_WEATHER.AddInt32(8534 + 3)
                    If Type = 3 Then SMSG_WEATHER.AddInt32(8534 + 23)
                Case Else
                    If Type = 1 Then SMSG_WEATHER.AddInt32(8535)
                    If Type = 2 Then SMSG_WEATHER.AddInt32(8535 + 3)
                    If Type = 3 Then SMSG_WEATHER.AddInt32(8535 + 23)
            End Select
            Client.Send(SMSG_WEATHER)
            'Client.Character.SendToNearPlayers(SMSG_WEATHER)
            SMSG_WEATHER.Dispose()
        End Sub

    End Module
