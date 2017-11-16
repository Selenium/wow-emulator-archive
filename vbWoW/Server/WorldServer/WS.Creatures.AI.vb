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

Public Module WS_Creatures_AI

#Region "WS.Creatures.AI.Framework"
    Public Class TBaseAI
        Implements IDisposable
        Public Enum AIState
            AI_DO_NOTHING
            AI_DEAD
            AI_EVADE

            AI_ATTACKING
            AI_MOVE_FOR_ATTACK
            AI_MOVING
            AI_WANDERING
        End Enum
        Public State As AIState = AIState.AI_DO_NOTHING
        Public aiTarget As BaseUnit = Nothing
        Public aiHateTable As New Hashtable(3)

        Public Overridable Sub Reset()
            State = AIState.AI_DO_NOTHING
        End Sub

        Public Overridable Sub OnAttack(ByRef Attacker As BaseUnit)
        End Sub
        Public Overridable Sub OnGetHit(ByRef Attacker As BaseUnit, ByVal DamageCaused As Integer)
        End Sub
        Public Overridable Sub OnGenerateHate(ByRef Attacker As BaseUnit, ByVal HateValue As Integer)
        End Sub

        Public Overridable Sub DoThink()
        End Sub

        Public Overridable Sub Dispose() Implements System.IDisposable.Dispose
        End Sub
        Public Sub New()
        End Sub
    End Class


#End Region
#Region "WS.Creatures.AI.TestAIs"

    'NOTE: These are timer based AIs
    Public Class TestDefensiveAI
        Inherits TBaseAI
        Protected Creature As CreatureObject
        Protected NextAttackTimer As Timer = Nothing
        Protected NextAttackDelegate As Threading.TimerCallback = Nothing

        Public Sub New(ByRef Creature_ As CreatureObject)
            Creature = Creature_
        End Sub
        Public Overrides Sub Reset()
            aiHateTable.Clear()
            If Not NextAttackTimer Is Nothing Then NextAttackTimer.Dispose()
            NextAttackTimer = Nothing
            NextAttackDelegate = Nothing
            aiTarget = Nothing

            If State <> AIState.AI_DEAD Then State = AIState.AI_DO_NOTHING
        End Sub

        Public Overrides Sub OnAttack(ByRef Attacker As BaseUnit)
            aiHateTable(Attacker) += 0
            InitializeAttack()
        End Sub
        Public Overrides Sub OnGetHit(ByRef Attacker As BaseUnit, ByVal DamageCaused As Integer)
            aiHateTable(Attacker) += DamageCaused
            If State <> AIState.AI_ATTACKING Then
                InitializeAttack()
            End If
        End Sub
        Public Overrides Sub OnGenerateHate(ByRef Attacker As BaseUnit, ByVal HateValue As Integer)
            aiHateTable(Attacker) += HateValue
        End Sub

        Public Sub SelectTarget()
            Try
                Dim max As Integer = -1
                Dim tmpTarget As BaseObject = Nothing

                For Each Victim As DictionaryEntry In aiHateTable
                    If Victim.Value > max Then
                        tmpTarget = Victim.Key
                    End If
                Next

                If Not aiTarget Is tmpTarget Then
                    aiTarget = tmpTarget
                    Creature.TurnTo(aiTarget.positionX, aiTarget.positionY)
                    'SendAttackStart(Creature.GUID, Target.GUID, CType(Target, CharacterObject).Client)
                End If
            Catch
            End Try
            If aiTarget Is Nothing Then Reset()
        End Sub
        Public Sub InitializeAttack()
            If Not NextAttackTimer Is Nothing Then Exit Sub
            SelectTarget()
            NextAttackDelegate = New Threading.TimerCallback(AddressOf DoAttack)
            NextAttackTimer = New System.Threading.Timer(NextAttackDelegate, Nothing, 1000, Timeout.Infinite)
        End Sub
        Public Sub DoAttack(ByVal Status As Object)
            If State = AIState.AI_DEAD Or (aiTarget Is Nothing) Then
                Reset()
            Else
                Try
                    If ((TypeOf aiTarget Is CharacterObject) AndAlso (CType(aiTarget, CharacterObject).DEAD = True)) OrElse _
                       ((TypeOf aiTarget Is CreatureObject) AndAlso (CType(aiTarget, CreatureObject).AIScript.State = AIState.AI_DEAD)) Then
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                    End If

                    Dim distance As Single = GetDistance(Creature, aiTarget)

                    'DONE: Very far objects handling
                    If distance > Creature.MaxDistance Then
                        Creature.SendChatMessage("Arrgh... you won't get away!", ChatMsg.CHAT_MSG_MONSTER_SAY, LANGUAGES.LANG_UNIVERSAL, aiTarget.GUID)
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                        If aiTarget Is Nothing Then
                            Reset()
                            Exit Sub
                        End If
                        distance = GetDistance(Creature, aiTarget)
                    End If

                    'DONE: Far objects handling
                    If distance > CREATURESDatabase(Creature.ID).CombatReach Then
                        If Rnd.NextDouble > 0.3F Then
                            'DONE: Move closer
                            Dim NearX As Single = aiTarget.positionX
                            If aiTarget.positionX > Creature.positionX Then NearX -= Creature.Size Else NearX += Creature.Size
                            Dim NearY As Single = aiTarget.positionY
                            If aiTarget.positionY > Creature.positionY Then NearY -= Creature.Size Else NearY += Creature.Size
                            Dim NearZ As Single = GetZCoord(NearX, NearY)
                            If NearZ > (aiTarget.positionZ + 2) Or NearZ < (aiTarget.positionZ - 2) Then NearZ = aiTarget.positionZ
                            NextAttackTimer.Change(Creature.MoveTo(NearX, NearY, NearZ, True), Timeout.Infinite)
                            Exit Sub
                        Else
                            'DONE: Cast spell
                            Dim tmpTargets As New SpellTargets
                            tmpTargets.SetTarget_UNIT(aiTarget)
                            CType(SPELLs(133), SpellInfo).Cast(Creature, tmpTargets)
                            NextAttackTimer.Change(CType(SPELLs(133), SpellInfo).GetCastTime, Timeout.Infinite)
                            Exit Sub
                        End If
                    End If

                    'DONE: Look to target
                    If Not IsLookingTo(Creature, aiTarget) Then
                        Creature.TurnTo(aiTarget)
                    End If

                    'DONE: Fix Creature VS Creature
                    Dim damageInfo As DamageInfo = CalculateDamage(Creature, aiTarget, False)
                    SendAttackerStateUpdate(Creature, aiTarget, damageInfo)
                    aiTarget.DealDamage(damageInfo.GetDamage)

                    NextAttackTimer.Change(CREATURESDatabase(Creature.ID).BaseAttackTime, Timeout.Infinite)
                Catch e As Exception
                    Console.WriteLine("DEBUG: Error attacking target.")
                    Reset()
                End Try
            End If
        End Sub
    End Class
    Public Class TestMovingAI
        Inherits TBaseAI
        Protected Creature As CreatureObject

        Protected MoveTimer As Object = Nothing
        Protected MoveTimerDelegate As Threading.TimerCallback = Nothing

        Public Sub DoMove(ByVal state As Object)
            Dim selectedX As Single = Creature.positionX + Rnd.Next(-5, 5)
            Dim selectedY As Single = Creature.positionY + Rnd.Next(-5, 5)

            Dim distance As Single = GetDistance(selectedX, Creature.SpawnX, selectedY, Creature.SpawnY)
            If distance > Creature.MaxDistance Then
                DoMove(Nothing)
            Else
                Creature.MoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY))
            End If
        End Sub
        Public Sub New(ByRef Creature_ As CreatureObject)
            Creature = Creature_
            MoveTimerDelegate = New Threading.TimerCallback(AddressOf DoMove)
            MoveTimer = New System.Threading.Timer(MoveTimerDelegate, Nothing, 60000, 5000)
        End Sub
    End Class
    Public Class TestDefaultAI
        Inherits TBaseAI

        Protected Const AI_INTERVAL_MOVE As Integer = 3000
        Protected Const AI_INTERVAL_SLEEP As Integer = 6000
        Protected Const AI_INTERVAL_DEAD As Integer = 60000
        Protected Const PIx2 As Single = 2 * Math.PI

        Protected aiCreature As CreatureObject = Nothing
        Protected aiTimer As Timer = Nothing


        Public Sub New(ByRef Creature As CreatureObject)
            State = AIState.AI_WANDERING

            aiCreature = Creature
            aiTarget = Nothing
            aiTimer = New System.Threading.Timer(New Threading.TimerCallback(AddressOf DoThink), Nothing, AI_INTERVAL_MOVE, Timeout.Infinite)
        End Sub
        Public Overrides Sub OnAttack(ByRef Attacker As BaseUnit)
            aiHateTable(Attacker) += 0
            Me.State = TBaseAI.AIState.AI_ATTACKING
        End Sub
        Public Overrides Sub OnGetHit(ByRef Attacker As BaseUnit, ByVal DamageCaused As Integer)
            aiHateTable(Attacker) += DamageCaused
            Me.State = TBaseAI.AIState.AI_ATTACKING
        End Sub
        Public Overrides Sub OnGenerateHate(ByRef Attacker As BaseUnit, ByVal HateValue As Integer)
            aiHateTable(Attacker) += HateValue
            Me.State = TBaseAI.AIState.AI_ATTACKING
        End Sub


        Protected Shadows Sub DoThink(ByVal state As Object)
            Select Case Me.State
                Case AIState.AI_MOVE_FOR_ATTACK
                    DoMove(Nothing)
                Case AIState.AI_WANDERING
                    If Rnd.NextDouble > 0.2F Then
                        DoMove(Nothing)
                    Else
                        DoNothing(Nothing)
                    End If

                Case AIState.AI_ATTACKING
                    DoAttack(Nothing)
                Case AIState.AI_MOVING
                    DoMove(Nothing)
                Case AIState.AI_DO_NOTHING
                    DoNothing(Nothing)

                Case AIState.AI_DEAD
                    aiTimer.Change(AI_INTERVAL_DEAD, Timeout.Infinite)
                Case Else
                    aiCreature.SendChatMessage("Unknown AI mode!", ChatMsg.CHAT_MSG_MONSTER_SAY, WS_MiscHandlers.LANGUAGES.LANG_UNIVERSAL)
                    Me.State = TBaseAI.AIState.AI_DO_NOTHING
            End Select

        End Sub
        Protected Sub DoMove(ByVal state As Object)
            Dim distanceToSpawn As Single = GetDistance(aiCreature.positionX, aiCreature.SpawnX, aiCreature.positionY, aiCreature.SpawnY, aiCreature.positionZ, aiCreature.SpawnZ)

            'DONE: Back to spawn if too far
            If distanceToSpawn > aiCreature.MaxDistance * 2 Then
                Me.State = TBaseAI.AIState.AI_WANDERING
                aiCreature.Life.Current = aiCreature.Life.Maximum
                aiTimer.Change(aiCreature.MoveTo(aiCreature.SpawnX, aiCreature.SpawnY, aiCreature.SpawnZ, True), Timeout.Infinite)
                Exit Sub
            End If




            If aiTarget Is Nothing Then

                'DONE: Do simple random movement
                Dim distance As Single = AI_INTERVAL_MOVE / 1000 * aiCreature.CreatureInfo.WalkSpeed
                Dim angle As Single = Rnd.NextDouble * PIx2

                Dim selectedX As Single = aiCreature.positionX + Math.Cos(angle) * distance
                Dim selectedY As Single = aiCreature.positionY + Math.Sin(angle) * distance

                If aiCreature.CanMoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY)) Then
                    Me.State = TBaseAI.AIState.AI_WANDERING
                    aiTimer.Change(aiCreature.MoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY), False), Timeout.Infinite)
                Else
                    aiTimer.Change(AI_INTERVAL_MOVE, Timeout.Infinite)
                End If

            Else

                'DONE: Do targeted movement to attack target
                Dim distance As Single = AI_INTERVAL_MOVE / 1000 * aiCreature.CreatureInfo.RunSpeed
                Dim distanceToTarget As Single = GetDistance(aiCreature, aiTarget)

                If distanceToTarget < distance Then
                    'DONE: Move to target
                    Me.State = TBaseAI.AIState.AI_ATTACKING

                    Dim NearX As Single = aiTarget.positionX
                    If aiTarget.positionX > aiCreature.positionX Then NearX -= aiCreature.Size Else NearX += aiCreature.Size
                    Dim NearY As Single = aiTarget.positionY
                    If aiTarget.positionY > aiCreature.positionY Then NearY -= aiCreature.Size Else NearY += aiCreature.Size
                    Dim NearZ As Single = GetZCoord(NearX, NearY)
                    If NearZ > (aiTarget.positionZ + 2) Or NearZ < (aiTarget.positionZ - 2) Then NearZ = aiTarget.positionZ

                    If aiCreature.CanMoveTo(NearX, NearY, NearZ) Then
                        aiTimer.Change(aiCreature.MoveTo(NearX, NearY, NearZ, True), Timeout.Infinite)
                    Else
                        'DONE: Select next target
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                        If Not CheckTarget() Then aiTimer.Change(AI_INTERVAL_MOVE, Timeout.Infinite)
                    End If

                Else

                    'DONE: Move to target by vector
                    Dim angle As Single = Math.Atan2(aiTarget.positionY - aiCreature.positionY, aiTarget.positionX - aiCreature.positionX)
                    Dim selectedX As Single = aiCreature.positionX + Math.Cos(angle) * distance
                    Dim selectedY As Single = aiCreature.positionY + Math.Sin(angle) * distance

                    If aiCreature.CanMoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY)) Then
                        aiTimer.Change(aiCreature.MoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY), True), Timeout.Infinite)
                    Else
                        'DONE: Select next target
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                        If Not CheckTarget() Then aiTimer.Change(AI_INTERVAL_MOVE, Timeout.Infinite)
                    End If

                End If
            End If

        End Sub
        Protected Sub DoAttack(ByVal state As Object)

            If aiTarget Is Nothing Then
                Me.SelectTarget()
            End If

            If Me.State <> AIState.AI_ATTACKING Then
                'DONE: Seems like we lost our target
                aiTimer.Change(AI_INTERVAL_SLEEP, Timeout.Infinite)
            Else
                'DONE: Do real melee attack
                Try
                    If ((TypeOf aiTarget Is CharacterObject) AndAlso (CType(aiTarget, CharacterObject).DEAD = True)) OrElse _
                       ((TypeOf aiTarget Is CreatureObject) AndAlso (CType(aiTarget, CreatureObject).AIScript.State = AIState.AI_DEAD)) Then
                        aiTarget = Nothing
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                    End If
                    If CheckTarget() Then Exit Sub

                    Dim distance As Single = GetDistance(aiCreature, aiTarget)

                    'DONE: Very far objects handling
                    If distance > aiCreature.MaxDistance Then
                        aiCreature.SendChatMessage("Arrgh... you won't get away!", ChatMsg.CHAT_MSG_MONSTER_SAY, LANGUAGES.LANG_UNIVERSAL, aiTarget.GUID)
                        aiTarget = Nothing
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                        If CheckTarget() Then Exit Sub
                        distance = GetDistance(aiCreature, aiTarget)
                    End If

                    'DONE: Far objects handling
                    If distance > CREATURESDatabase(aiCreature.ID).CombatReach Then
                        If Rnd.NextDouble > 0.1F Then
                            'DONE: Move closer
                            Me.State = AIState.AI_MOVE_FOR_ATTACK
                            Me.DoMove(Nothing)
                            Exit Sub
                        Else
                            'DONE: Cast spell
                            Dim tmpTargets As New SpellTargets
                            tmpTargets.SetTarget_UNIT(aiTarget)
                            CType(SPELLs(133), SpellInfo).Cast(aiCreature, tmpTargets)
                            aiTimer.Change(CType(SPELLs(133), SpellInfo).GetCastTime, Timeout.Infinite)
                            Exit Sub
                        End If
                    End If

                    'DONE: Look to aiTarget
                    If Not IsLookingTo(aiCreature, aiTarget) Then
                        aiCreature.TurnTo(aiTarget)
                    End If

                    'DONE: Fix aiCreature VS aiCreature
                    Dim damageInfo As DamageInfo = CalculateDamage(aiCreature, aiTarget, False)
                    SendAttackerStateUpdate(aiCreature, aiTarget, damageInfo)
                    aiTarget.DealDamage(damageInfo.GetDamage)

                    aiTimer.Change(CREATURESDatabase(aiCreature.ID).BaseAttackTime, Timeout.Infinite)
                Catch e As Exception
                    Console.WriteLine("DEBUG: Error attacking aiTarget.")
                    Reset()
                End Try
            End If

        End Sub
        Protected Sub DoNothing(ByVal state As Object)
            aiTimer.Change(AI_INTERVAL_SLEEP, Timeout.Infinite)
        End Sub


        Public Overrides Sub Reset()
            aiHateTable.Clear()
            aiTarget = Nothing

            'DONE: Return to default
            If State <> AIState.AI_DEAD Then
                Me.State = AIState.AI_WANDERING
            End If
        End Sub
        Protected Sub SelectTarget()
            Try
                Dim max As Integer = -1
                Dim tmpTarget As BaseObject = Nothing

                For Each Victim As DictionaryEntry In aiHateTable
                    If Victim.Value > max Then
                        tmpTarget = Victim.Key
                    End If
                Next

                If Not aiTarget Is tmpTarget Then
                    aiTarget = tmpTarget
                    aiCreature.TurnTo(aiTarget.positionX, aiTarget.positionY)
                    'SendAttackStart(Creature.GUID, Target.GUID, CType(Target, CharacterObject).Client)

                    Me.State = AIState.AI_ATTACKING
                End If
            Catch
            End Try

            If aiTarget Is Nothing Then Reset()
        End Sub
        Protected Function CheckTarget() As Boolean
            If aiTarget Is Nothing Then
                Reset()
                aiTimer.Change(AI_INTERVAL_SLEEP, Timeout.Infinite)
                Return True
            End If

            Return False
        End Function

    End Class

#End Region
#Region "WS.Creatures.AI.StandartAIs"

    'Standart AIs           | move | defend | attack | cooperative | spawn dst. |
    '  DefaultAI:           |  +       +         -          -            +
    '  StandingAI:          |  -       +         -          -            +
    '  GuardAI:             |  -       +         +          -            +
    '  EvilAI:              |  +       +         +          -            +
    '  EvilCooperativeAI:   |  +       +         +          +            +
    'Quest AIs
    '  WaypointAI:          | move in wayponts and defend
    '  EvilWaypointAI:      | move in wayponts, defend and look for enemy
    Public Class DefaultAI
        Inherits TBaseAI

        Protected aiCreature As CreatureObject = Nothing
        Protected aiTimer As Integer = 0

        Protected Const AI_INTERVAL_MOVE As Integer = 3000
        Protected Const AI_INTERVAL_SLEEP As Integer = 6000
        Protected Const AI_INTERVAL_DEAD As Integer = 60000
        Protected Const PIx2 As Single = 2 * Math.PI

        Public Sub New(ByRef Creature As CreatureObject)
            State = AIState.AI_WANDERING

            aiCreature = Creature
            aiTarget = Nothing
        End Sub
        Public Overrides Sub OnAttack(ByRef Attacker As BaseUnit)
            If Me.State <> TBaseAI.AIState.AI_DEAD Then
                aiHateTable(Attacker) += 0
                Me.State = TBaseAI.AIState.AI_ATTACKING
            End If
        End Sub
        Public Overrides Sub OnGetHit(ByRef Attacker As BaseUnit, ByVal DamageCaused As Integer)
            If Me.State <> TBaseAI.AIState.AI_DEAD Then
                aiHateTable(Attacker) += DamageCaused * Attacker.Spell_ThreatModifier
                Me.State = TBaseAI.AIState.AI_ATTACKING
            End If
        End Sub
        Public Overrides Sub OnGenerateHate(ByRef Attacker As BaseUnit, ByVal HateValue As Integer)
            If Me.State <> TBaseAI.AIState.AI_DEAD Then
                aiHateTable(Attacker) += HateValue * Attacker.Spell_ThreatModifier
                Me.State = TBaseAI.AIState.AI_ATTACKING
            End If
        End Sub
        Public Overrides Sub Reset()

            aiHateTable.Clear()
            aiTarget = Nothing
            aiTimer = 0
            aiCreature.SendTargetUpdate(0)

            'DONE: Return to default
            If State <> AIState.AI_DEAD Then
                Me.State = AIState.AI_WANDERING
            End If
        End Sub
        Protected Sub SelectTarget()
            Try

                Dim max As Integer = -1
                Dim tmpTarget As BaseUnit = Nothing

                'DONE: Select max hate
                For Each Victim As DictionaryEntry In aiHateTable
                    If Victim.Value > max Then
                        If Not Victim.Key.isDead Then
                            tmpTarget = Victim.Key
                        End If
                    End If
                Next

                'DONE: Set the target
                If (Not tmpTarget Is Nothing) AndAlso Not aiTarget Is tmpTarget Then
                    aiTarget = tmpTarget
                    aiCreature.TurnTo(aiTarget.positionX, aiTarget.positionY)
                    aiCreature.SendTargetUpdate(tmpTarget.GUID)

                    Me.State = AIState.AI_ATTACKING
                End If
            Catch
                Reset()
            End Try

            If aiTarget Is Nothing Then Reset()
        End Sub
        Protected Function CheckTarget() As Boolean
            If aiTarget Is Nothing Then
                Reset()
                Return True
            End If

            Return False
        End Function

        Public Overrides Sub DoThink()
            If aiTimer > 200 Then
                aiTimer -= AIManager.UPDATE_TIMER
                Exit Sub
            Else
                aiTimer = 0
            End If

            Select Case Me.State
                Case AIState.AI_DEAD
                    'DONE: Remove combat flag from target
                    If Not aiTarget Is Nothing Then
                        If TypeOf aiTarget Is CharacterObject Then SetPlayerOutOfCombat(aiTarget)
                        aiCreature.SendTargetUpdate(aiTarget.GUID)
                        aiTarget = Nothing
                    End If
                Case AIState.AI_MOVE_FOR_ATTACK
                    DoMove()
                Case AIState.AI_WANDERING
                    If Rnd.NextDouble > 0.2F Then
                        DoMove()
                    End If
                Case AIState.AI_ATTACKING
                    DoAttack()
                Case AIState.AI_MOVING
                    DoMove()
                Case AIState.AI_DO_NOTHING
                Case Else
                    aiCreature.SendChatMessage("Unknown AI mode!", ChatMsg.CHAT_MSG_MONSTER_SAY, WS_MiscHandlers.LANGUAGES.LANG_UNIVERSAL)
                    Me.State = TBaseAI.AIState.AI_DO_NOTHING
            End Select
        End Sub

        Protected Sub DoAttack()
            If aiCreature.Spell_Pacifyed Then
                aiTimer = AI_INTERVAL_MOVE
                Exit Sub
            End If

            If aiTarget Is Nothing Then
                Me.SelectTarget()
            End If

            If Me.State <> AIState.AI_ATTACKING Then
                'DONE: Seems like we lost our target
                aiTimer = AI_INTERVAL_SLEEP
            Else
                'DONE: Do real melee attack
                Try
                    If aiTarget.isDead Then
                        aiTarget = Nothing
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                    End If
                    If CheckTarget() Then Exit Sub

                    Dim distance As Single = GetDistance(aiCreature, aiTarget)

                    'DONE: Very far objects handling
                    If distance > aiCreature.MaxDistance Then
                        aiCreature.SendChatMessage("Arrgh... you won't get away!", ChatMsg.CHAT_MSG_MONSTER_SAY, LANGUAGES.LANG_UNIVERSAL, aiTarget.GUID)
                        aiTarget = Nothing
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                        If CheckTarget() Then Exit Sub
                        distance = GetDistance(aiCreature, aiTarget)
                    End If

                    'DONE: Far objects handling
                    If distance > CREATURESDatabase(aiCreature.ID).CombatReach Then
                        If aiCreature.Spell_Silenced Or Rnd.NextDouble > 0.1F Then
                            'DONE: Move closer
                            Me.State = AIState.AI_MOVE_FOR_ATTACK
                            Me.DoMove()
                            Exit Sub
                        Else
                            'DONE: Cast spell
                            'TODO: Get spell for every creature
                            aiTimer = aiCreature.CastSpell(133, aiTarget)
                            Exit Sub
                        End If
                    End If

                    'DONE: Look to aiTarget
                    If Not IsLookingTo(aiCreature, aiTarget) Then
                        aiCreature.TurnTo(aiTarget)
                    End If

                    'DONE: Fix aiCreature VS aiCreature
                    Dim damageInfo As DamageInfo = CalculateDamage(aiCreature, aiTarget, False)
                    SendAttackerStateUpdate(aiCreature, aiTarget, damageInfo)
                    aiTarget.DealDamage(damageInfo.GetDamage)

                    aiTimer = CREATURESDatabase(aiCreature.ID).BaseAttackTime
                Catch e As Exception
                    Console.WriteLine("DEBUG: Error attacking aiTarget.")
                    Reset()
                End Try
            End If

        End Sub
        Protected Sub DoMove()
            Dim distanceToSpawn As Single = GetDistance(aiCreature.positionX, aiCreature.SpawnX, aiCreature.positionY, aiCreature.SpawnY, aiCreature.positionZ, aiCreature.SpawnZ)

            'DONE: Back to spawn if too far
            If aiCreature.SpawnID > 0 AndAlso distanceToSpawn > aiCreature.MaxDistance * 2 Then
                Me.State = TBaseAI.AIState.AI_WANDERING
                aiCreature.Life.Current = aiCreature.Life.Maximum
                aiTimer = aiCreature.MoveTo(aiCreature.SpawnX, aiCreature.SpawnY, aiCreature.SpawnZ, True)
                Exit Sub
            End If




            If aiTarget Is Nothing Then

                'DONE: Do simple random movement
                Dim distance As Single = AI_INTERVAL_MOVE / 1000 * aiCreature.CreatureInfo.WalkSpeed
                Dim angle As Single = Rnd.NextDouble * PIx2

                Dim selectedX As Single = aiCreature.positionX + Math.Cos(angle) * distance
                Dim selectedY As Single = aiCreature.positionY + Math.Sin(angle) * distance

                If aiCreature.CanMoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY)) Then
                    Me.State = TBaseAI.AIState.AI_WANDERING
                    aiTimer = aiCreature.MoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY), False)
                Else
                    aiTimer = AI_INTERVAL_MOVE
                End If

            Else

                'DONE: Do targeted movement to attack target
                Dim distance As Single = AI_INTERVAL_MOVE / 1000 * aiCreature.CreatureInfo.RunSpeed
                Dim distanceToTarget As Single = GetDistance(aiCreature, aiTarget)

                If distanceToTarget < distance Then
                    'DONE: Move to target
                    Me.State = TBaseAI.AIState.AI_ATTACKING

                    Dim NearX As Single = aiTarget.positionX
                    If aiTarget.positionX > aiCreature.positionX Then NearX -= aiCreature.Size Else NearX += aiCreature.Size
                    Dim NearY As Single = aiTarget.positionY
                    If aiTarget.positionY > aiCreature.positionY Then NearY -= aiCreature.Size Else NearY += aiCreature.Size
                    Dim NearZ As Single = GetZCoord(NearX, NearY)
                    If NearZ > (aiTarget.positionZ + 2) Or NearZ < (aiTarget.positionZ - 2) Then NearZ = aiTarget.positionZ

                    If aiCreature.CanMoveTo(NearX, NearY, NearZ) Then
                        aiTimer = aiCreature.MoveTo(NearX, NearY, NearZ, True)
                    Else
                        'DONE: Select next target
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                        If Not CheckTarget() Then aiTimer = AI_INTERVAL_MOVE
                    End If

                Else

                    'DONE: Move to target by vector
                    Dim angle As Single = Math.Atan2(aiTarget.positionY - aiCreature.positionY, aiTarget.positionX - aiCreature.positionX)
                    Dim selectedX As Single = aiCreature.positionX + Math.Cos(angle) * distance
                    Dim selectedY As Single = aiCreature.positionY + Math.Sin(angle) * distance

                    If aiCreature.CanMoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY)) Then
                        aiTimer = aiCreature.MoveTo(selectedX, selectedY, GetZCoord(selectedX, selectedY), True)
                    Else
                        'DONE: Select next target
                        aiHateTable.Remove(aiTarget)
                        SelectTarget()
                        If Not CheckTarget() Then aiTimer = AI_INTERVAL_MOVE
                    End If

                End If
            End If

        End Sub


    End Class

#End Region
#Region "WS.Creatures.AI.BossAIs"

#End Region

End Module
