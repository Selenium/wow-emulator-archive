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


Public Module WS_Creatures

#Region "WS.Cretures.Constants"


    Public Const SKILL_DETECTION_PER_LEVEL As Integer = 5


#End Region
#Region "WS.Creatures.TypeDef"
    Public Delegate Sub CastEvent(ByRef target As Object, ByRef caster As Object)

    'WARNING: Use only with CREATUREsDatabase()
    Public Class CreatureInfo
        Implements IDisposable
        Public Sub New(ByVal CreatureID As Integer)
            Me.New()

            'DONE: Load Item Data from MySQL
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT * FROM adb_creatures WHERE creature_id = {0};", CreatureID), MySQLQuery)

            If MySQLQuery.Rows.Count = 0 Then
                Log.WriteLine(LogType.FAILED, "CreatureID {0} not found in SQL database.", CreatureID)
                found_ = False
                'Throw New ApplicationException(String.Format("CreatureID {0} not found in SQL database.", CreatureID))
                Exit Sub
            End If
            found_ = True

            Model = MySQLQuery.Rows(0).Item("creature_model")
            Name = MySQLQuery.Rows(0).Item("creature_name")
            Guild = MySQLQuery.Rows(0).Item("creature_guild")
            Size = MySQLQuery.Rows(0).Item("creature_size")

            Life = MySQLQuery.Rows(0).Item("creature_life")
            Mana = MySQLQuery.Rows(0).Item("creature_mana")
            ManaType = MySQLQuery.Rows(0).Item("creature_manaType")
            Faction = MySQLQuery.Rows(0).Item("creature_faction")
            Elite = MySQLQuery.Rows(0).Item("creature_elite")
            Damage.Maximum = MySQLQuery.Rows(0).Item("creature_maxDamage")
            RangedDamage.Maximum = MySQLQuery.Rows(0).Item("creature_maxRangedDamage")
            Damage.Minimum = MySQLQuery.Rows(0).Item("creature_minDamage")
            RangedDamage.Minimum = MySQLQuery.Rows(0).Item("creature_minRangedDamage")

            AtackPower = MySQLQuery.Rows(0).Item("creature_attackPower")
            RangedAtackPower = MySQLQuery.Rows(0).Item("creature_rangedAttackPower")

            WalkSpeed = MySQLQuery.Rows(0).Item("creature_walkSpeed")
            RunSpeed = MySQLQuery.Rows(0).Item("creature_runSpeed")
            BaseAttackTime = MySQLQuery.Rows(0).Item("creature_baseAttackSpeed")
            BaseRangedAttackTime = MySQLQuery.Rows(0).Item("creature_baseRangedAttackSpeed")

            CombatReach = MySQLQuery.Rows(0).Item("creature_combatReach")
            BoundingRadius = MySQLQuery.Rows(0).Item("creature_bondingRadius")
            cNpcFlags = MySQLQuery.Rows(0).Item("creature_npcFlags")
            cFlags = MySQLQuery.Rows(0).Item("creature_flags")
            CreatureType = MySQLQuery.Rows(0).Item("creature_type")
            CreatureFamily = MySQLQuery.Rows(0).Item("creature_family")
            LevelMin = MySQLQuery.Rows(0).Item("creature_minLevel")
            LevelMax = MySQLQuery.Rows(0).Item("creature_maxLevel")

            AIScriptSource = MySQLQuery.Rows(0).Item("creature_aiScript")

            SellTable = MySQLQuery.Rows(0).Item("creature_sell")
            Loot = MySQLQuery.Rows(0).Item("creature_loot")
            Loot_Skinning = MySQLQuery.Rows(0).Item("creature_lootSkinning")

            Id = CreatureID

            If Dir(System.AppDomain.CurrentDomain.BaseDirectory() & "scripts\creatures\" & Replace(Name, """", "'") & ".vb") <> "" Then
                Dim tmpScript As New ScriptedObject("scripts\creatures\" & Replace(Name, """", "'") & ".vb", "", True)
                TalkScript = tmpScript.Invoke("TalkScript")
                tmpScript.Dispose()
            Else
                If cNpcFlags = 0 Then
                    TalkScript = Nothing
                ElseIf cNpcFlags = NPCFlags.UNIT_NPC_FLAG_GOSSIP Then
                    'TalkScript = New TGuardTalk
                Else
                    TalkScript = New TDefaultTalk
                End If
            End If

            CREATURESDatabase.Add(Id, Me)
        End Sub
        Public Sub New()
            Damage.Minimum = (0.8F * BaseAttackTime / 1000.0F) * (LevelMin * 10.0F)
            Damage.Maximum = (1.2F * BaseAttackTime / 1000.0F) * (LevelMax * 10.0F)
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            CREATURESDatabase.Remove(Id)
        End Sub
        Public Sub Save()
            If found_ = False Then
                Database.Update("INSERT INTO adb_creatures (creature_id)  VALUES (" & Id & ");")
            End If

            Dim tmp As String = "UPDATE adb_creatures SET"

            tmp = tmp & " creature_model=""" & Model & """"
            tmp = tmp & ", creature_name='" & Name & "'"
            tmp = tmp & ", creature_guild=""" & Guild & """"
            tmp = tmp & ", creature_size=""" & Trim(Str(Size)) & """"
            tmp = tmp & ", creature_life=""" & Life & """"
            tmp = tmp & ", creature_mana=""" & Mana & """"
            tmp = tmp & ", creature_manaType=""" & ManaType & """"
            tmp = tmp & ", creature_elite=""" & Elite & """"
            tmp = tmp & ", creature_faction=""" & Faction & """"
            tmp = tmp & ", creature_family=""" & CreatureFamily & """"
            tmp = tmp & ", creature_type=""" & CreatureType & """"
            tmp = tmp & ", creature_minDamage=""" & Damage.Minimum & """"
            tmp = tmp & ", creature_maxDamage=""" & Damage.Maximum & """"
            tmp = tmp & ", creature_minRangedDamage=""" & RangedDamage.Minimum & """"
            tmp = tmp & ", creature_maxRangedDamage=""" & RangedDamage.Maximum & """"
            tmp = tmp & ", creature_attackPower=""" & AtackPower & """"
            tmp = tmp & ", creature_rangedAttackPower=""" & RangedAtackPower & """"
            tmp = tmp & ", creature_walkSpeed=""" & Trim(Str(WalkSpeed)) & """"
            tmp = tmp & ", creature_runSpeed=""" & Trim(Str(RunSpeed)) & """"
            tmp = tmp & ", creature_baseAttackSpeed=""" & BaseAttackTime & """"
            tmp = tmp & ", creature_baseRangedAttackSpeed=""" & BaseRangedAttackTime & """"
            tmp = tmp & ", creature_combatReach=""" & Trim(Str(CombatReach)) & """"
            tmp = tmp & ", creature_bondingRadius=""" & Trim(Str(BoundingRadius)) & """"
            tmp = tmp & ", creature_npcFlags=""" & cNpcFlags & """"
            tmp = tmp & ", creature_flags=""" & cFlags & """"
            tmp = tmp & ", creature_minLevel=""" & LevelMin & """"
            tmp = tmp & ", creature_maxLevel=""" & LevelMax & """"
            tmp = tmp & ", creature_aiScript=""" & AIScriptSource & """"

            tmp = tmp & ", creature_armor=""" & Resistances(0) & """"
            tmp = tmp & ", creature_resHoly=""" & Resistances(1) & """"
            tmp = tmp & ", creature_resFire=""" & Resistances(2) & """"
            tmp = tmp & ", creature_resNature=""" & Resistances(3) & """"
            tmp = tmp & ", creature_resFrost=""" & Resistances(4) & """"
            tmp = tmp & ", creature_resShadow=""" & Resistances(5) & """"
            tmp = tmp & ", creature_resArcane=""" & Resistances(6) & """"

            tmp = tmp & ", creature_sell=""" & SellTable & """"
            tmp = tmp & ", creature_loot=""" & Loot & """"
            tmp = tmp & ", creature_lootSkinning=""" & Loot_Skinning & """"

            tmp = tmp + String.Format(" WHERE creature_id = ""{0}"";", Id)
            Database.Update(tmp)
        End Sub
        Private found_ As Boolean = False

        Public Id As Integer = 0
        Public Name As String = "MISSING_CREATURE_INFO"
        Public Guild As String = ""
        Public Size As Single = 1
        Public Model As Integer = 262
        Public Life As Short = 1
        Public Mana As Short = 1
        Public ManaType As Byte = 0
        Public Faction As Short = FactionTemplates.NoFaction
        Public CreatureType As Byte = UNIT_TYPE.NOUNITTYPE
        Public CreatureFamily As Byte = CREATURE_FAMILY.NONE
        Public Elite As Byte = CREATURE_ELITE.NORMAL
        Public HonorRank As Byte = 0
        Public Damage As New TDamage
        Public RangedDamage As New TDamage
        Public AtackPower As Integer = 0
        Public RangedAtackPower As Integer = 0
        Public Resistances() As Byte = {0, 0, 0, 0, 0, 0, 0}

        Public WalkSpeed As Single = UNIT_NORMAL_WALK_SPEED
        Public RunSpeed As Single = UNIT_NORMAL_RUN_SPEED
        Public BaseAttackTime As Short = 2000
        Public BaseRangedAttackTime As Short = 2000

        Public CombatReach As Single = 0
        Public BoundingRadius As Single = 0
        Public cNpcFlags As Integer
        Public cFlags As Integer
        Public LevelMin As Byte = 1
        Public LevelMax As Byte = 1
        Public Civilian As Byte = 0

        Public ReputationGains As New Hashtable(0)
        Public EquipedItems() As Integer = {0, 0, 0}
        Public AIScriptSource As String = ""

        Public SpellsTable As Integer = 0
        Public SellTable As Integer = 0
        Public Loot As Integer = 0
        Public Loot_Skinning As Integer = 0

        Public Event OnCast As CastEvent
        Public Sub Cast(ByRef target As Object, ByRef caster As Object)
            RaiseEvent OnCast(target, caster)
        End Sub

        Public TalkScript As TBaseTalk = Nothing
    End Class

    'WARNING: Use only with WORLD_CREATUREs()
    Public Class CreatureObject
        Inherits BaseUnit
        Implements IDisposable

        Public ReadOnly Property CreatureInfo() As CreatureInfo
            Get
                Return CREATURESDatabase(ID)
            End Get
        End Property

        Public ID As Integer = 0
        Public aiScript As TBaseAI = Nothing
        Public SpawnX As Single = 0
        Public SpawnY As Single = 0
        Public SpawnZ As Single = 0

        Public ReadOnly Property Name() As String
            Get
                Return CType(CREATURESDatabase(ID), CreatureInfo).Name
            End Get
        End Property
        Public ReadOnly Property MaxDistance() As Single
            Get
                Return CType(CREATURESDatabase(ID), CreatureInfo).BoundingRadius * 50
            End Get
        End Property

        Public ReadOnly Property isAbleToWalkOnWater() As Boolean
            Get
                'TODO: Fix family filter
                Select Case CType(CREATURESDatabase(ID), CreatureInfo).CreatureFamily
                    Case 3, 10, 11, 12, 20, 21, 27
                        Return False
                    Case Else
                        Return True
                End Select
            End Get
        End Property
        Public ReadOnly Property isAbleToWalkOnGround() As Boolean
            Get
                'TODO: Fix family filter
                Select Case CType(CREATURESDatabase(ID), CreatureInfo).CreatureFamily
                    Case 255
                        Return False
                    Case Else
                        Return True
                End Select
            End Get
        End Property
        Public Overrides ReadOnly Property isDead() As Boolean
            Get
                Return aiScript.State = TBaseAI.AIState.AI_DEAD
            End Get
        End Property


        Public Sub SendTargetUpdate(ByVal TargetGUID As Long)
            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_TARGET, TargetGUID)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, Me)
            tmpUpdate.Dispose()

            SendToNearPlayers(packet)
            packet.Dispose()
        End Sub
        Public Sub FillAllUpdateFlags(ByRef Update As UpdateClass, ByRef Character As CharacterObject)
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_GUID, GUID)
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_TYPE, CType(ObjectType.TYPE_OBJECT + ObjectType.TYPE_UNIT, Integer))
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_ENTRY, CType(ID, Integer))
            Update.SetUpdateFlag(EObjectFields.OBJECT_FIELD_SCALE_X, CREATURESDatabase(ID).Size)

            If (Not aiScript Is Nothing) AndAlso (Not aiScript.aiTarget Is Nothing) Then
                Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_TARGET, aiScript.aiTarget.GUID)
            End If

            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_DISPLAYID, Me.Model)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, CREATURESDatabase(ID).Model)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID, Mount)

            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_0, CType(CType(CREATURESDatabase(ID).ManaType, Integer) << 24, Integer))

            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, Life.Current)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1 + CREATURESDatabase(ID).ManaType, Mana.Current)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXHEALTH, Life.Maximum)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXPOWER1 + CREATURESDatabase(ID).ManaType, Mana.Maximum)

            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_LEVEL, Level)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, CType(CREATURESDatabase(ID).Faction, Integer))
            Update.SetUpdateFlag(EUnitFields.UNIT_NPC_FLAGS, CREATURESDatabase(ID).cNpcFlags)


            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, cUnitFlags)
            If Character.Access > WS_Commands.AccessLevel.Player Then
                Update.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, cDynamicFlags Or DynamicFlags.UNIT_DYNFLAG_SPECIALINFO)
            Else
                Update.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, cDynamicFlags)
            End If


            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + DamageType.DMG_PHYSICAL, CREATURESDatabase(ID).Resistances(DamageType.DMG_PHYSICAL))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + DamageType.DMG_HOLY, CREATURESDatabase(ID).Resistances(DamageType.DMG_HOLY))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + DamageType.DMG_FIRE, CREATURESDatabase(ID).Resistances(DamageType.DMG_FIRE))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + DamageType.DMG_NATURE, CREATURESDatabase(ID).Resistances(DamageType.DMG_NATURE))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + DamageType.DMG_FROST, CREATURESDatabase(ID).Resistances(DamageType.DMG_FROST))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + DamageType.DMG_SHADOW, CREATURESDatabase(ID).Resistances(DamageType.DMG_SHADOW))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + DamageType.DMG_ARCANE, CREATURESDatabase(ID).Resistances(DamageType.DMG_ARCANE))

            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY, Me.CreatureInfo.EquipedItems(0))
            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_INFO, 0)
            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_INFO + 1, 0)

            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 1, Me.CreatureInfo.EquipedItems(1))
            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_INFO + 2, 0)
            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_INFO + 2 + 1, 0)

            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 2, Me.CreatureInfo.EquipedItems(2))
            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_INFO + 4, 0)
            Update.SetUpdateFlag(EUnitFields.UNIT_VIRTUAL_ITEM_INFO + 4 + 1, 0)


            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_BASEATTACKTIME, CREATURESDatabase(ID).BaseAttackTime)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_OFFHANDATTACKTIME, CREATURESDatabase(ID).BaseAttackTime)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RANGEDATTACKTIME, CREATURESDatabase(ID).BaseRangedAttackTime)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_ATTACK_POWER, CREATURESDatabase(ID).AtackPower)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_RANGED_ATTACK_POWER, CREATURESDatabase(ID).RangedAtackPower)

            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_BOUNDINGRADIUS, CType(CREATURESDatabase(ID).BoundingRadius, Single))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_COMBATREACH, CType(CREATURESDatabase(ID).CombatReach, Single))
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_MINDAMAGE, CREATURESDatabase(ID).Damage.Minimum)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXDAMAGE, CREATURESDatabase(ID).Damage.Maximum)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_MINRANGEDDAMAGE, CREATURESDatabase(ID).RangedDamage.Minimum)
            Update.SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXRANGEDDAMAGE, CREATURESDatabase(ID).RangedDamage.Maximum)
        End Sub
        Public Sub ToAllNear(ByRef packet As PacketClass)
            For Each cGUID As Long In MapTiles(CellX, CellY).PlayersHere
                If CHARACTERS(cGUID).creaturesNear.Contains(GUID) Then
                    CHARACTERS(cGUID).Client.SendMultiplyPackets(packet)
                End If
            Next
        End Sub
        Public Sub MoveToInstant(ByVal x As Single, ByVal y As Single, ByVal z As Single)
            Me.positionX = x
            Me.positionY = y
            Me.positionZ = z

            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(0)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_MOVEMENT, Me)

            ToAllNear(packet)
            packet.Dispose()

            MoveCell()
        End Sub
        Public Function MoveTo(ByVal x As Single, ByVal y As Single, ByVal z As Single, Optional ByVal Running As Boolean = False) As Integer
            Try
                If Me.SeenBy.Count = 0 Then
                    Return 10000
                End If
            Catch
            End Try

            Dim TimeToMove As Integer = 1

            Dim SMSG_MONSTER_MOVE As New PacketClass(OPCODES.SMSG_MONSTER_MOVE)
            SMSG_MONSTER_MOVE.AddPackGUID(GUID)
            SMSG_MONSTER_MOVE.AddSingle(positionX)
            SMSG_MONSTER_MOVE.AddSingle(positionY)
            SMSG_MONSTER_MOVE.AddSingle(positionZ)
            SMSG_MONSTER_MOVE.AddInt32(GetTimestamp(Now))   'Sequence/MSTime?

            SMSG_MONSTER_MOVE.AddInt8(0)                    'Type [If type is 1 then the packet ends here]
            If Running Then
                SMSG_MONSTER_MOVE.AddInt32(&H100)           'Flags [0x0 - Walk, 0x100 - Run, 0x200 - Waypoint, 0x300 - Fly]
                TimeToMove = CType(Math.Sqrt((x - positionX) ^ 2 + (y - positionY) ^ 2 + (z - positionZ) ^ 2) / CreatureInfo.RunSpeed * 1000, Integer)
            Else
                SMSG_MONSTER_MOVE.AddInt32(0)
                TimeToMove = CType(Math.Sqrt((x - positionX) ^ 2 + (y - positionY) ^ 2 + (z - positionZ) ^ 2) / CreatureInfo.WalkSpeed * 1000, Integer)
            End If

            orientation = GetOrientation(positionX, x, positionY, y)
            positionX = x
            positionY = y
            positionZ = z

            SMSG_MONSTER_MOVE.AddInt32(TimeToMove)  'Time
            SMSG_MONSTER_MOVE.AddInt32(1)           'Points Count
            SMSG_MONSTER_MOVE.AddSingle(x)          'First Point X
            SMSG_MONSTER_MOVE.AddSingle(y)          'First Point Y
            SMSG_MONSTER_MOVE.AddSingle(z)          'First Point Z

            'The points after that are in the same format only if flag 0x200 is set, else they are compressed in 1 uint32

            ToAllNear(SMSG_MONSTER_MOVE)
            SMSG_MONSTER_MOVE.Dispose()

            MoveCell()
            Return TimeToMove
        End Function
        Public Function CanMoveTo(ByVal x As Single, ByVal y As Single, ByVal z As Single) As Boolean
            If IsOutsideOfMap(Me) Then Return False

            If z < GetWaterLevel(x, y) Then
                If Not Me.isAbleToWalkOnWater Then Return False
            Else
                If Not Me.isAbleToWalkOnGround Then Return False
            End If

            Return True
        End Function
        Public Sub TurnTo(ByRef Target As BaseObject)
            TurnTo(Target.positionX, Target.positionY)
        End Sub
        Public Sub TurnTo(ByVal x As Single, ByVal y As Single)
            orientation = GetOrientation(positionX, x, positionY, y)
            Dim index As Integer
            Dim plGUID As Long

            If SeenBy.Count > 0 Then
                index = 0
                'Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                'packet.AddInt32(2)
                'packet.AddInt8(0)
                'Dim tmpUpdate As New UpdateClass(1)
                'tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_MOVEMENT, Me, 0)
                'tmpUpdate.Dispose()

                Dim packet As New PacketClass(OPCODES.MSG_MOVE_HEARTBEAT)
                packet.AddInt8(&HFF)
                packet.AddInt64(GUID)
                packet.AddInt32(0)
                packet.AddInt32(0)
                packet.AddSingle(positionX)
                packet.AddSingle(positionY)
                packet.AddSingle(positionZ)
                packet.AddSingle(orientation)

                While index < SeenBy.Count
                    plGUID = SeenBy.Item(index)
                    CHARACTERS(plGUID).Client.SendMultiplyPackets(packet)
                    index += 1
                End While

                packet.Dispose()
            End If
        End Sub
        Public Sub TurnTo(ByVal orientation_ As Single)
            orientation = orientation_
            Dim index As Integer
            Dim plGUID As Long

            If SeenBy.Count > 0 Then
                index = 0
                'Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                'packet.AddInt32(1)
                'packet.AddInt8(0)
                'Dim tmpUpdate As New UpdateClass(1)
                'tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_MOVEMENT, Me, 0)

                Dim packet As New PacketClass(OPCODES.MSG_MOVE_HEARTBEAT)
                packet.AddInt8(&HFF)
                packet.AddInt64(GUID)
                packet.AddInt32(0)
                packet.AddInt32(0)
                packet.AddSingle(positionX)
                packet.AddSingle(positionY)
                packet.AddSingle(positionZ)
                packet.AddSingle(orientation)


                While index < SeenBy.Count
                    plGUID = SeenBy.Item(index)
                    CHARACTERS(plGUID).Client.SendMultiplyPackets(packet)
                    index += 1
                End While

                packet.Dispose()
            End If
        End Sub

        Public Overrides Sub Die(ByRef Attacker As BaseUnit)
            cUnitFlags = UnitFlags.UNIT_FLAG_DEAD
            aiScript.State = TBaseAI.AIState.AI_DEAD

            If TypeOf Attacker Is CharacterObject Then
                GiveXP(CType(Attacker, CharacterObject))

                'DONE: Fire quest event to check for if this monster is required for quest
                OnQuestKill(Attacker, Me)

                LootCorpse(CType(Attacker, CharacterObject))
            End If
        End Sub
        Public Overrides Sub DealDamageMagical(ByRef Damage As Integer, ByVal DamageType As DamageType, Optional ByRef Attacker As BaseUnit = Nothing)
            If Life.Current = 0 Then Exit Sub

            Select Case DamageType
                Case DamageType.DMG_PHYSICAL
                    Me.DealDamage(Damage, Attacker)
                    Return
                Case Else
                    If CType(CREATURESDatabase(ID), CreatureInfo).CreatureType = UNIT_TYPE.CRITTER Then
                        'DONE: Critters die in one shot
                        Life.Current = 0
                    Else
                        Life.Current -= Damage
                    End If
            End Select

            'DONE: Check for dead
            If Life.Current = 0 Then Me.Die(Attacker)

            'DONE: Do health update
            If SeenBy.Count > 0 Then
                Dim packetForNear As New UpdatePacketClass
                Dim UpdateData As New UpdateClass(EUnitFields.UNIT_END)
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, CType(Life.Current, Integer))
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, cUnitFlags)
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, cDynamicFlags)
                UpdateData.AddToPacket(packetForNear, ObjectUpdateType.UPDATETYPE_VALUES, Me, 0)

                SendToNearPlayers(packetForNear)
                packetForNear.Dispose()
                UpdateData.Dispose()
            End If

            If Not Attacker Is Nothing Then aiScript.OnGetHit(Attacker, Damage)
        End Sub
        Public Overrides Sub DealDamage(ByVal Damage As Integer, Optional ByRef Attacker As BaseUnit = Nothing)
            If Life.Current = 0 Then Exit Sub

            If CType(CREATURESDatabase(ID), CreatureInfo).CreatureType = UNIT_TYPE.CRITTER Then
                'DONE: Critters die in one shot
                Life.Current = 0
            Else
                Life.Current -= Damage
            End If

            'DONE: Check for dead
            If Life.Current = 0 Then Me.Die(Attacker)

            'DONE: Do health update
            If SeenBy.Count > 0 Then
                Dim packetForNear As New UpdatePacketClass
                Dim UpdateData As New UpdateClass(EUnitFields.UNIT_END)
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, CType(Life.Current, Integer))
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, cUnitFlags)
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, cDynamicFlags)
                UpdateData.AddToPacket(packetForNear, ObjectUpdateType.UPDATETYPE_VALUES, Me, 0)

                SendToNearPlayers(packetForNear)
                packetForNear.Dispose()
                UpdateData.Dispose()
            End If

            If Not Attacker Is Nothing Then aiScript.OnGetHit(Attacker, Damage)
        End Sub
        Public Overrides Sub Heal(ByVal Damage As Integer, Optional ByRef Attacker As BaseUnit = Nothing)
            If Life.Current = 0 Then Exit Sub

            Life.Current += Damage


            'DONE: Do health update
            If SeenBy.Count > 0 Then
                Dim packetForNear As New UpdatePacketClass
                Dim UpdateData As New UpdateClass(EUnitFields.UNIT_END)
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, CType(Life.Current, Integer))
                UpdateData.AddToPacket(packetForNear, ObjectUpdateType.UPDATETYPE_VALUES, Me, 0)

                SendToNearPlayers(packetForNear)
                packetForNear.Dispose()
                UpdateData.Dispose()
            End If
        End Sub
        Public Overrides Sub Energize(ByVal Damage As Integer, Optional ByRef Attacker As BaseUnit = Nothing)
            If ManaType <> WS_CharManagment.ManaTypes.TYPE_MANA Then Exit Sub
            If Mana.Current = Mana.Maximum Then Exit Sub

            Mana.Current += Damage


            'DONE: Do health update
            If SeenBy.Count > 0 Then
                Dim packetForNear As New UpdatePacketClass
                Dim UpdateData As New UpdateClass(EUnitFields.UNIT_END)
                UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1 + ManaType, CType(Mana.Current, Integer))
                UpdateData.AddToPacket(packetForNear, ObjectUpdateType.UPDATETYPE_VALUES, Me, 0)

                SendToNearPlayers(packetForNear)
                packetForNear.Dispose()
                UpdateData.Dispose()
            End If
        End Sub
        Public Sub LootCorpse(ByRef Character As CharacterObject)
            If GenerateLoot(Character, LootType.LOOTTYPE_CORPSE) Then
                cDynamicFlags = DynamicFlags.UNIT_DYNFLAG_LOOTABLE
            ElseIf CType(CREATURESDatabase(ID), CreatureInfo).Loot_Skinning <> 0 Then
                'GenerateLoot(Character, LootType.LOOTTYPE_SKINNNING) 
                cUnitFlags += UnitFlags.UNIT_FLAG_SKINNABLE

                'DONE: Send skinnable and exit
                Dim SkinnablePacket As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                SkinnablePacket.AddInt32(1)
                SkinnablePacket.AddInt8(0)
                Dim UpdateDataSkinnable As New UpdateClass
                UpdateDataSkinnable.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, cDynamicFlags)
                UpdateDataSkinnable.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, cUnitFlags)
                UpdateDataSkinnable.AddToPacket(SkinnablePacket, ObjectUpdateType.UPDATETYPE_VALUES, Me, 0)
                UpdateDataSkinnable.Dispose()
                Character.Client.SendMultiplyPackets(SkinnablePacket)
                Character.SendToNearPlayers(SkinnablePacket)
                SkinnablePacket.Dispose()
                Exit Sub
            Else
                'No loot or skinnable
                Exit Sub
            End If


            'DONE: Create packet
            Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
            packet.AddInt32(1)
            packet.AddInt8(0)
            Dim UpdateData As New UpdateClass
            UpdateData.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, cDynamicFlags)
            UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, cUnitFlags)
            UpdateData.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, Me, 0)
            UpdateData.Dispose()


            If Character.IsInGroup Then
                'DONE: Group loot rulles
                CType(LootTable(GUID), LootObject).LootOwner = 0

                Select Case Character.Party.GroupLootType
                    Case BaseParty.LootMethod.LOOT_FREE_FOR_ALL
                        For i As Byte = 0 To Character.Party.GroupMembers.Length - 1
                            If (Not Character.Party.GroupMembers(i) Is Nothing) AndAlso SeenBy.Contains(Character.Party.GroupMembers(i).GUID) Then Character.Party.GroupMembers(i).Client.SendMultiplyPackets(packet)
                        Next
                    Case BaseParty.LootMethod.LOOT_MASTER
                        If Character.Party.GroupLootMaster = 0 Then Character.Client.Send(packet) Else CHARACTERS(Character.Party.GroupLootMaster).Client.Send(packet)
                    Case BaseParty.LootMethod.LOOT_GROUP, BaseParty.LootMethod.LOOT_NEED_BEFORE_GREED, BaseParty.LootMethod.LOOT_ROUND_ROBIN
                        Dim cLooter As CharacterObject = Character.Party.GetNextLooter(Character)
                        While Not SeenBy.Contains(cLooter.GUID) AndAlso (Not cLooter Is Character)
                            cLooter = Character.Party.GetNextLooter(Character)
                        End While
                        cLooter.Client.Send(packet)
                End Select
            Else
                'GenerateLoot(Character, GUID, LootType.LOOTTYPE_CORPSE)
                Character.Client.Send(packet)
            End If

            'DONE: Dispose packet
            packet.Dispose()
        End Sub
        Public Function GenerateLoot(ByRef Character As CharacterObject, ByVal LootType As LootType) As Boolean
            Dim lootGroup As Integer = 0
            If LootType = LootType.LOOTTYPE_CORPSE Then lootGroup = CREATURESDatabase(ID).Loot
            If LootType = LootType.LOOTTYPE_SKINNNING Then lootGroup = CREATURESDatabase(ID).Loot_Skinning
            If lootGroup = 0 Then Return False

            'DONE: Loot generation
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT * FROM adb_loots WHERE loot_group = {0};", lootGroup), MySQLQuery)
            'If MySQLQuery.Rows.Count = 0 Then Return False

            Dim Loot As New LootObject(GUID, LootType)
            For Each LootRow As DataRow In MySQLQuery.Rows
                If CType(LootRow.Item("loot_chance"), Single) * 10000 > (Rnd.Next(1, 2000001) Mod 1000000) Then
                    Loot.Items.Add(New LootItem(CType(LootRow.Item("loot_item"), Integer), 1))
                End If
            Next

            'DONE: Money loot
            If LootType = LootType.LOOTTYPE_CORPSE Then
                If CType(CREATURESDatabase(ID), CreatureInfo).Elite = 0 Then
                    If CType(CREATURESDatabase(ID), CreatureInfo).CreatureType = UNIT_TYPE.HUMANOID Then
                        Loot.Money = Fix(Level * Rnd.Next(0, Level))
                    ElseIf Rnd.NextDouble < 0.2 Then
                        Loot.Money = Fix(Level * Rnd.Next(0, Level))
                    End If
                Else
                    Loot.Money = Fix(Level * Rnd.Next(0, Level) * CType(CREATURESDatabase(ID), CreatureInfo).Elite)
                End If
            End If

            Loot.LootOwner = Character.GUID

            'DONE: Fire quest event to check for if this monster is required for quest and to add quest's loot if needed
            OnQuestAddQuestLoot(Character, Me, Loot)
            Return True
        End Function
        Public Sub GiveXP(ByRef Character As CharacterObject)
            Dim XP As Integer = Level * 5 + 45  'Green
            Dim lvlDiffirence As Integer = Character.Level - Level

            Select Case lvlDiffirence
                Case 1, 2
                    'Yellow 
                    XP *= (1 + 0.05F * lvlDiffirence)
                Case 3, 4
                    'Orange
                    XP *= (1 + 0.07F * lvlDiffirence)
                Case Is >= 5
                    'Red
                    XP *= 1.4
                Case Is < -(5 + Fix(Character.Level / 10))
                    'Gray
                    XP = 0
                    Exit Sub
            End Select

            'DONE: Killing elites
            If CType(CREATURESDatabase(ID), CreatureInfo).Elite > 0 Then XP *= 2
            'DONE: XP Rate config
            XP *= Config.XPRate


            If Not Character.IsInGroup Then
                'DONE: Single kill
                Character.AddXP(XP, GUID)
            Else

                'DONE: Party bonus
                XP *= (0.8F + 0.2F * Character.Party.GetMembersCount())

                'DONE: Party calculate all levels
                Dim baseLvl As Integer = 0
                For i As Byte = 0 To Character.Party.GroupMembers.Length - 1
                    If Not Character.Party.GroupMembers(i) Is Nothing Then
                        With Character.Party.GroupMembers(i)
                            If .DEAD = False AndAlso (Math.Sqrt((.positionX - positionX) ^ 2 + (.positionY - positionY) ^ 2) <= DEFAULT_DISTANCE_VISIBLE) Then
                                baseLvl += Character.Party.GroupMembers(i).Level
                            End If
                        End With
                    End If
                Next

                'DONE: Party share
                For i As Byte = 0 To Character.Party.GroupMembers.Length - 1
                    If Not Character.Party.GroupMembers(i) Is Nothing Then
                        With Character.Party.GroupMembers(i)
                            If .DEAD = False AndAlso (Math.Sqrt((.positionX - positionX) ^ 2 + (.positionY - positionY) ^ 2) <= DEFAULT_DISTANCE_VISIBLE) Then
                                .AddXP(Fix(XP * .Level / baseLvl), GUID)
                            End If
                        End With
                    End If
                Next
            End If
        End Sub

        Public Function CastSpell(ByVal SpellID As Integer, ByVal Target As BaseObject) As Integer
            If Spell_Silenced Then Return -1

            Dim tmpSpell As New CastSpellParameters
            tmpSpell.tmpTargets = New SpellTargets
            tmpSpell.tmpTargets.SetTarget_UNIT(Target)
            tmpSpell.tmpCaster = Me
            tmpSpell.tmpSpellID = SpellID

            PacketThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf tmpSpell.Cast))
            Return CType(SPELLs(SpellID), SpellInfo).GetCastTime
        End Function
        Public Sub SendChatMessage(ByVal Message As String, ByVal msgType As ChatMsg, ByVal msgLanguage As LANGUAGES, Optional ByVal SecondGUID As Long = 0)
            Dim packet As New PacketClass(OPCODES.SMSG_MESSAGECHAT)
            Dim flag As Byte = 0

            packet.AddInt8(msgType)
            packet.AddInt32(msgLanguage)

            Select Case msgType
                Case ChatMsg.CHAT_MSG_MONSTER_EMOTE
                    packet.AddInt32(System.Text.Encoding.UTF8.GetByteCount(Name) + 1)
                    packet.AddString(Name)
                    packet.AddInt64(0)
                Case ChatMsg.CHAT_MSG_MONSTER_SAY, ChatMsg.CHAT_MSG_MONSTER_YELL
                    packet.AddInt64(GUID)
                    packet.AddInt32(System.Text.Encoding.UTF8.GetByteCount(Name) + 1)
                    packet.AddString(Name)
                    packet.AddInt64(SecondGUID)
                Case Else
                    Log.WriteLine(LogType.WARNING, "Creature.SendChatMessage() must not handle this chat type!")
            End Select

            packet.AddInt32(System.Text.Encoding.UTF8.GetByteCount(Message) + 1)
            packet.AddString(Message)
            packet.AddInt8(flag)
            SendToNearPlayers(packet)
            packet.Dispose()
        End Sub

        Public Sub Initialize()
            'DONE: Database loading
            Me.Level = Rnd.Next(CREATURESDatabase(ID).LevelMin, CREATURESDatabase(ID).LevelMax)
            Me.Size = CREATURESDatabase(ID).Size
            Me.Model = CREATURESDatabase(ID).Model
            Me.ManaType = CREATURESDatabase(ID).ManaType
            Me.Mana.Base = CREATURESDatabase(ID).Mana
            Me.Mana.Current = Me.Mana.Maximum
            Me.Life.Base = CREATURESDatabase(ID).Life
            Me.Life.Current = Me.Life.Maximum

            'DONE: Internal Initializators
            Me.CanSeeInvisibility_Stealth = SKILL_DETECTION_PER_LEVEL * Me.Level
            Me.CanSeeInvisibility_Invisibility = 0

            If (CREATURESDatabase(ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_SPIRITHEALER) = NPCFlags.UNIT_NPC_FLAG_SPIRITHEALER Then
                Invisibility = InvisibilityLevel.DEAD
                cUnitFlags = UnitFlags.UNIT_FLAG_SPIRITHEALER
            ElseIf CREATURESDatabase(ID).cNpcFlags > 0 Then
                cUnitFlags = UnitFlags.UNIT_FLAG_NOT_ATTACKABLE
            End If

            'DONE: Load scripted AI
            If CREATURESDatabase(ID).AIScriptSource <> "" Then
                aiScript = AI.Invoke(CREATURESDatabase(ID).AIScriptSource, New Object() {Me})
            End If

            'DONE: Load default AI 
            If aiScript Is Nothing Then
                If CreatureInfo.cNpcFlags = 0 Then
                    aiScript = New DefaultAI(Me)
                Else
                    aiScript = New TBaseAI
                End If
            End If
        End Sub
        Public Sub New(ByVal GUID_ As Long, Optional ByRef Info As DataRow = Nothing)
            'WARNING: Use only for loading creature from DB
            If Info Is Nothing Then
                Dim MySQLQuery As New DataTable
                Database.Query(String.Format("SELECT * FROM tmpspawnedcreatures WHERE spawned_guid = {0};", GUID_), MySQLQuery)
                If MySQLQuery.Rows.Count > 0 Then
                    Info = MySQLQuery.Rows(0)
                Else
                    Log.WriteLine(LogType.FAILED, "Spawned creature not found in database. [GUID={0:X}]", GUID_)
                    Return
                End If
            End If

            positionX = Info.Item("spawned_positionX")
            positionY = Info.Item("spawned_positionY")
            positionZ = Info.Item("spawned_positionZ")
            orientation = Info.Item("spawned_orientation")

            SpawnX = positionX
            SpawnY = positionY
            SpawnZ = positionZ

            ID = Info.Item("spawned_entry")
            MapID = Info.Item("spawned_map")
            SpawnID = Info.Item("spawn_id")

            If Not CREATURESDatabase.ContainsKey(ID) Then
                Dim baseCreature As New CreatureInfo(ID)
            End If

            GUID = GUID_ + GUID_UNIT
            Initialize()
            WORLD_CREATUREs.Add(GUID, Me)
        End Sub
        Public Sub New(ByVal ID_ As Integer)
            'WARNING: Use only for spawning new crature

            If Not CREATURESDatabase.ContainsKey(ID_) Then
                Dim baseCreature As New CreatureInfo(ID_)
            End If

            ID = ID_
            GUID = GetNewGUID()

            Initialize()
            WORLD_CREATUREs.Add(GUID, Me)
        End Sub
        Private Sub Dispose() Implements System.IDisposable.Dispose
            If Not Me.aiScript Is Nothing Then Me.aiScript.Dispose()

            Me.RemoveFromWorld()
            WORLD_CREATUREs.Remove(GUID)
        End Sub
        Public Sub Destroy()
            Dim packet As New PacketClass(OPCODES.SMSG_DESTROY_OBJECT)
            packet.AddInt64(GUID)
            SendToNearPlayers(packet)
            packet.Dispose()

            Me.Dispose()
        End Sub
        Public Sub AddToWorld()
            GetMapTile(positionX, positionY, CellX, CellY)
            If MapTiles(CellX, CellY) Is Nothing Then MAP_Load(CellX, CellY)
            Try
                MapTiles(CellX, CellY).CreaturesHere.Add(GUID)
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
                'tmpUpdate.Dispose()

                With MapTiles(CellX, CellY)
                    index = 0
                    While index < .PlayersHere.Count
                        Try
                            plGUID = .PlayersHere.Item(index)
                            If CHARACTERS(plGUID).CanSee(Me) Then
                                Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                                packet.AddInt32(1)
                                packet.AddInt8(0)
                                Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_UNIT)
                                FillAllUpdateFlags(tmpUpdate, CHARACTERS(plGUID))
                                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, Me, 0)
                                tmpUpdate.Dispose()

                                CHARACTERS(plGUID).Client.SendMultiplyPackets(packet)
                                CHARACTERS(plGUID).creaturesNear.Add(GUID)
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
            MapTiles(CellX, CellY).CreaturesHere.Remove(GUID)

            Dim index As Integer
            Dim plGUID As Long

            'DONE: Removing from players in <CENTER> Cell wich can see it
            If MapTiles(CellX, CellY).PlayersHere.Count > 0 Then
                With MapTiles(CellX, CellY)
                    index = 0
                    While index < .PlayersHere.Count
                        Try
                            plGUID = .PlayersHere.Item(index)
                            If CHARACTERS(plGUID).creaturesNear.Contains(GUID) Then
                                CHARACTERS(plGUID).guidsForRemoving.Add(GUID)
                                CHARACTERS(plGUID).creaturesNear.Remove(GUID)
                            End If
                        Finally
                            index += 1
                        End Try
                    End While
                End With
            End If
        End Sub
        Public Sub MoveCell()
            If CellX <> GetMapTileX(positionX) OrElse CellY <> GetMapTileY(positionY) Then
                MapTiles(CellX, CellY).CreaturesHere.Remove(GUID)

                GetMapTile(positionX, positionY, CellX, CellY)
                MapTiles(CellX, CellY).CreaturesHere.Add(GUID)
            End If
        End Sub
    End Class
#End Region
#Region "WS.Creatures.HelperSubs"
    Public Sub On_CMSG_CREATURE_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)

        Dim response As New PacketClass(OPCODES.SMSG_CREATURE_QUERY_RESPONSE)

        packet.GetInt16()
        Dim CreatureID As Integer = packet.GetInt32
        Dim CreatureGUID As Long = packet.GetInt64

        Try
            Dim Creature As CreatureInfo

            If CREATURESDatabase.ContainsKey(CreatureID) = False Then
                Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CREATURE_QUERY [Creature {2} not loaded.]", Client.IP, Client.Port, CreatureID)
                Creature = New CreatureInfo(CreatureID)
            Else
                Creature = CREATURESDatabase(CreatureID)
                Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CREATURE_QUERY [CreatureID={2} CreatureGUID={3:X}]", Format(TimeOfDay, "hh:mm:ss"), Client.IP, Client.Port, CreatureID, CreatureGUID - GUID_UNIT)
            End If

            response.AddInt32(Creature.Id)
            response.AddString(Creature.Name)
            response.AddInt8(0)     'Creature.Name2
            response.AddInt8(0)     'Creature.Name3
            response.AddInt8(0)     'Creature.Name4
            response.AddString(Creature.Guild)

            response.AddInt32(Creature.cFlags)              'wdbFeild7=wad flags1
            response.AddInt32(Creature.CreatureType)        'wdbFeild8
            response.AddInt32(Creature.CreatureFamily)      'wdbFeild9
            response.AddInt32(Creature.Elite)               'wdbFeild10             Creature.HonorRank  ?
            response.AddInt32(0)                            'wdbFeild11             Creature.Elite      ?
            response.AddInt32(0)                            'wdbFeild12
            response.AddInt32(Creature.Model)               'wdbFeild13     '-

            response.AddInt32(&H3F800000)                   'wdbFeild14     '-
            response.AddInt32(&H3F800000)                   'wdbFeild15     '-
            response.AddInt16(Creature.Civilian)            'wdbFeild16     '-



            Client.Send(response)
            response.Dispose()
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_CREATURE_QUERY_RESPONSE", Client.IP, Client.Port)
        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Unknown Error: Unable to find CreatureID={0} in database.", CreatureID)
        End Try
    End Sub
    Public Sub On_CMSG_NPC_TEXT_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim TextID As Long = packet.GetInt32
        Dim TargetGUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_NPC_TEXT_QUERY [TextID={2}]", Client.IP, Client.Port, TextID)


        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_npcText WHERE text_id = {0};", TextID), MySQLQuery)

        If MySQLQuery.Rows.Count <> 0 Then
            'DONE: Load TextID
            Dim response As New PacketClass(OPCODES.SMSG_NPC_TEXT_UPDATE)
            'Dim i As Byte
            response.AddInt32(TextID)

            'For i = 1 To 8
            response.AddInt32(MySQLQuery.Rows(0).Item("text_dens_0"))           'dens0          'Probability
            response.AddString(MySQLQuery.Rows(0).Item("text_text_0_1"))        'text0_0        'Text1
            response.AddString(MySQLQuery.Rows(0).Item("text_text_0_2"))        'text0_1        'Text2
            response.AddInt32(MySQLQuery.Rows(0).Item("text_lang_0"))           'lang0=         'Language
            response.AddInt32(MySQLQuery.Rows(0).Item("text_delay_0_1"))        'unk0_0=        'Emote1.Delay
            response.AddInt32(MySQLQuery.Rows(0).Item("text_emote_0_1"))        'unk0_1=        'Emote1.Emote
            response.AddInt32(MySQLQuery.Rows(0).Item("text_delay_0_2"))        'unk0_2=        'Emote2.Delay
            response.AddInt32(MySQLQuery.Rows(0).Item("text_emote_0_2"))        'unk0_3=        'Emote2.Emote
            response.AddInt32(MySQLQuery.Rows(0).Item("text_delay_0_3"))        'unk0_4=        'Emote3.Delay
            response.AddInt32(MySQLQuery.Rows(0).Item("text_emote_0_3"))        'unk0_5=        'Emote3.Emote
            'Next

            Client.Send(response)
            response.Dispose()
        Else
            Dim response As New PacketClass(OPCODES.SMSG_NPC_TEXT_UPDATE)
            response.AddInt32(TextID)
            response.AddInt32(0)
            response.AddString("Error")
            response.AddString("This NPC requires text object missing from our database. Please make bug report for that NPC and include in it this: <npcTextID=" & TextID & ">.")
            Client.Send(response)
            response.Dispose()
        End If

    End Sub

    Public Sub On_CMSG_GOSSIP_HELLO(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GOSSIP_HELLO [GUID={2:X}]", Client.IP, Client.Port, GUID)

        If CREATURESDatabase(WORLD_CREATUREs(GUID).Id).TalkScript Is Nothing Then
            Dim test As New PacketClass(OPCODES.SMSG_NPC_WONT_TALK)
            test.AddInt64(GUID)
            test.AddInt8(1)
            Client.Send(test)
            test.Dispose()

            Dim npcText As New NPCText
            npcText.Count = 1
            npcText.TextID = 34
            npcText.TextLine1(0) = "Hi $N, I'm not yet scripted to talk with you."
            SendNPCText(Client, npcText)

            Client.Character.SendGossip(GUID, 1)
        Else
            CREATURESDatabase(WORLD_CREATUREs(GUID).Id).TalkScript.OnGossipHello(Client.Character, GUID)
        End If
    End Sub
    Public Sub On_CMSG_GOSSIP_SELECT_OPTION(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim SelOption As Long = packet.GetInt32
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GOSSIP_SELECT_OPTION [SelOption={3} GUID={2:X}]", Client.IP, Client.Port, GUID, SelOption)

        If CREATURESDatabase(WORLD_CREATUREs(GUID).Id).TalkScript Is Nothing Then
            Throw New ApplicationException("Invoked OnGossipSelect() on creature without initialized TalkScript!")
        Else
            CREATURESDatabase(WORLD_CREATUREs(GUID).Id).TalkScript.OnGossipSelect(Client.Character, GUID, SelOption)
        End If
    End Sub
    Public Sub On_CMSG_SPIRIT_HEALER_ACTIVATE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_SPIRIT_HEALER_ACTIVATE [GUID={2}]", Client.IP, Client.Port, GUID)

        Try
            Dim i As Byte
            For i = 0 To EQUIPMENT_SLOT_END - 1
                If Client.Character.Items.ContainsKey(i) Then WORLD_ITEMs(Client.Character.Items(i)).ModifyDurability(0.25F, Client)
            Next
        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Error activating spirit healer: {0}", e.ToString)
        End Try

        CharacterResurrect(Client.Character)
    End Sub



    <MethodImplAttribute(MethodImplOptions.Synchronized)> _
    Private Function GetNewGUID() As Long
        CreatureGUIDCounter += 1
        Return CreatureGUIDCounter
    End Function
    Public Sub SendNPCText(ByRef Client As ClientClass, ByRef text As NPCText)
        Dim response As New PacketClass(OPCODES.SMSG_NPC_TEXT_UPDATE)
        Dim i As Byte
        response.AddInt32(text.TextID)

        For i = 0 To text.Count
            response.AddInt32(text.Probability(i))              'dens0          'Probability
            response.AddString(text.TextLine1(i))               'text0_0        'Text1
            response.AddString(text.TextLine2(i))               'text0_1        'Text2
            response.AddInt32(text.Language(i))                 'lang0=         'Language
            response.AddInt32(text.EmoteDelay1(i))              'unk0_0=        'Emote1.Delay
            response.AddInt32(text.Emote1(i))                   'unk0_1=        'Emote1.Emote
            response.AddInt32(text.EmoteDelay2(i))              'unk0_2=        'Emote2.Delay
            response.AddInt32(text.Emote2(i))                   'unk0_3=        'Emote2.Emote
            response.AddInt32(text.EmoteDelay3(i))              'unk0_4=        'Emote3.Delay
            response.AddInt32(text.Emote3(i))                   'unk0_5=        'Emote3.Emote
        Next

        Client.Send(response)
        response.Dispose()
    End Sub
    Public Class NPCText
        Public Count As Byte = 1

        Public TextID As Integer = 0
        Public Probability() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}
        Public Language() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}
        Public TextLine1() As String = {"", "", "", "", "", "", "", ""}
        Public TextLine2() As String = {"", "", "", "", "", "", "", ""}
        Public Emote1() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Public Emote2() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Public Emote3() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Public EmoteDelay1() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Public EmoteDelay2() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Public EmoteDelay3() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
    End Class
#End Region


End Module



#Region "WS.Creatures.HelperTypes"
Public Class TLoot
    Public ItemID As Short = 0
    Public Chance As Single = 0
End Class

Public Enum InvisibilityLevel As Byte
    VISIBLE = 0
    STEALTH = 1
    INIVISIBILITY = 2
    DEAD = 3
    GM = 4
End Enum
#End Region
#Region "WS.Creatures.Gossip"
Public Class GossipMenu
    Public Sub AddMenu(ByVal menu As String, Optional ByVal icon As Byte = 0, Optional ByVal isCoded As Byte = 0, Optional ByVal cost As Integer = 0, Optional ByVal WarningMessage As String = "")
        Icons.Add(icon)
        Menus.Add(menu)
        Coded.Add(isCoded)
        Costs.Add(cost)
        WarningMessages.Add(WarningMessage)
    End Sub
    Public Icons As New ArrayList
    Public Menus As New ArrayList
    Public Coded As New ArrayList
    Public Costs As New ArrayList
    Public WarningMessages As New ArrayList
End Class
Public Class QuestMenu
    Public Sub AddMenu(ByVal QuestName As String, ByVal ID As Short, ByVal Available As Byte, Optional ByVal Icon As Byte = 0)
        Names.Add(QuestName)
        IDs.Add(ID)
        Icons.Add(Icon)
        Availables.Add(Available)
    End Sub
    Public IDs As ArrayList = New ArrayList
    Public Names As ArrayList = New ArrayList
    Public Icons As ArrayList = New ArrayList
    Public Availables As ArrayList = New ArrayList
End Class
Public Class TBaseTalk
    Public Overridable Sub OnGossipHello(ByRef c As CharacterObject, ByVal cGUID As Long)

    End Sub
    Public Overridable Sub OnGossipSelect(ByRef c As CharacterObject, ByVal cGUID As Long, ByVal Selected As Integer)

    End Sub
    Public Overridable Function OnQuestStatus(ByRef c As CharacterObject, ByVal cGUID As Long) As Integer
        Return -1
    End Function
    Public Overridable Function OnQuestHello(ByRef c As CharacterObject, ByVal cGUID As Long) As Boolean
        Return True
    End Function
End Class


Public Enum MenuIcon As Integer
    MENUICON_GOSSIP = &H0
    MENUICON_VENDOR = &H1
    MENUICON_TAXI = &H2
    MENUICON_TRAINER = &H3
    MENUICON_HEALER = &H4
    MENUICON_BINDER = &H5
    MENUICON_BANKER = &H6
    MENUICON_PETITION = &H7
    MENUICON_TABARD = &H8
    MENUICON_BATTLEMASTER = &H9
    MENUICON_AUCTIONER = &HA
    MENUICON_GOSSIP2 = &HB
    MENUICON_GOSSIP3 = &HC
End Enum
#End Region


