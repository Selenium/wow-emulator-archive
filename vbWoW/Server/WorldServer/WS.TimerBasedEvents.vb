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
Imports vbWoW.Logbase.BaseWriter

Public Module WS_TimerBasedEvents

    'NOTE: Regenerates players' Mana, Life and Rage
    Public Class TRegenerator
        Implements IDisposable

        Private RegenerationTimer As Object = Nothing
        Private RegenerationTimerDelegate As Threading.TimerCallback = Nothing

        Private operationsCount As Integer
        Private BaseMana As Integer
        Private BaseLife As Integer
        Private BaseRage As Integer
        Private BaseEnergy As Integer
        Private _updateFlag As Boolean

        Public Const REGENERATION_TIMER As Integer = 2          'Timer period (ms)
        Public Const REGENERATION_ENERGY As Integer = 20        'Base rage degeneration rate
        Public Const REGENERATION_RAGE As Integer = 20          'Base energy regeneration rate
        Public Sub New()
            RegenerationTimerDelegate = New Threading.TimerCallback(AddressOf Regenerate)
            RegenerationTimer = New System.Threading.Timer(RegenerationTimerDelegate, Nothing, 60000, REGENERATION_TIMER * 1000)
        End Sub
        Private Sub Regenerate(ByVal state As Object)
            charactersLock_.AcquireReaderLock(Timeout.Infinite)
            For Each Character As DictionaryEntry In CHARACTERS
                'Character = CType(CharacterEntry.Value, CharacterClass)


                'DONE: If all invalid check passed then regenerate
                'DONE: If dead don't regenerate
                If (Not Character.Value.Dead) AndAlso (Character.Value.underWaterTimer Is Nothing) AndAlso (Character.Value.LogoutTimer Is Nothing) Then
                    With CType(Character.Value, CharacterObject)


                        BaseMana = .Mana.Current
                        BaseRage = .Rage.Current
                        BaseEnergy = .Energy.Current
                        BaseLife = .Life.Current
                        _updateFlag = False

                        'Rage
                        'DONE: In combat do not decrease, but send updates
                        If .ManaType = ManaTypes.TYPE_RAGE AndAlso .Rage.Current > 0 Then
                            If ((.cUnitFlags And UnitFlags.UNIT_FLAG_IN_COMBAT) <> UnitFlags.UNIT_FLAG_IN_COMBAT) Then
                                .Rage.Current -= REGENERATION_RAGE
                                If .Rage.Current < 0 Then .Rage.Current = 0
                            End If
                        End If

                        'Energy
                        If .ManaType = ManaTypes.TYPE_ENERGY AndAlso .Energy.Current < .Energy.Maximum Then
                            .Energy.Increment(REGENERATION_ENERGY)
                        End If

                        'Mana
                        'DONE: Don't regenerate while casting, 5 second rule
                        'TODO: If c.ManaRegenerationWhileCastingPercent > 0 ...
                        If .spellCastManaRegeneration = 0 Then
                            If .spellCastState = SpellCastState.SPELL_STATE_IDLE AndAlso .ManaType = ManaTypes.TYPE_MANA AndAlso .Mana.Current < .Mana.Maximum Then
                                Select Case .Classe
                                    Case Classes.CLASS_MAGE
                                        .Mana.Increment(CType((.Spirit.Value / 4 + 12.5) * .ManaRegenerationModifier, Integer))
                                    Case Classes.CLASS_PRIEST
                                        .Mana.Increment(CType((.Spirit.Value / 4 + 12.5) * .ManaRegenerationModifier, Integer))
                                    Case Classes.CLASS_WARLOCK
                                        .Mana.Increment(CType((.Spirit.Value / 5 + 15) * .ManaRegenerationModifier, Integer))
                                    Case Classes.CLASS_DRUID
                                        'TODO: if in bear/cat form?
                                        .Mana.Increment(CType((.Spirit.Value / 5 + 15) * .ManaRegenerationModifier, Integer))
                                    Case Classes.CLASS_SHAMAN
                                        .Mana.Increment(CType((.Spirit.Value / 5 + 17) * .ManaRegenerationModifier, Integer))
                                    Case Classes.CLASS_HUNTER
                                        .Mana.Increment(CType((.Spirit.Value / 5 + 15) * .ManaRegenerationModifier, Integer))
                                    Case Classes.CLASS_PALADIN
                                        .Mana.Increment(CType((.Spirit.Value / 4 + 8) * .ManaRegenerationModifier, Integer))
                                End Select
                                '.Mana.Increment(CType((.Level + 2) * .ManaRegenerationModifier, Integer))       ' * ManaRegenerationWhileCastingPercent / 100
                            End If
                        Else
                            If .spellCastManaRegeneration < REGENERATION_TIMER Then
                                .spellCastManaRegeneration = 0
                            Else
                                .spellCastManaRegeneration -= REGENERATION_TIMER
                            End If
                        End If

                        'Life
                        'DONE: Don't regenerate in combat
                        'TODO: If c.LifeRegenWhileFightingPercent > 0 ...
                        If .Life.Current < .Life.Maximum AndAlso ((.cUnitFlags And UnitFlags.UNIT_FLAG_IN_COMBAT) <> UnitFlags.UNIT_FLAG_IN_COMBAT) Then
                            Select Case .Classe
                                Case Classes.CLASS_MAGE
                                    .Life.Increment(CType((.Spirit.Value * 0.1) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_PRIEST
                                    .Life.Increment(CType((.Spirit.Value * 0.1) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_WARLOCK
                                    .Life.Increment(CType((.Spirit.Value * 0.11) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_DRUID
                                    .Life.Increment(CType((.Spirit.Value * 0.11) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_SHAMAN
                                    .Life.Increment(CType((.Spirit.Value * 0.11) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_ROGUE
                                    .Life.Increment(CType((.Spirit.Value * 0.5) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_WARRIOR
                                    .Life.Increment(CType((.Spirit.Value * 0.8) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_HUNTER
                                    .Life.Increment(CType((.Spirit.Value * 0.25) * .LifeRegenerationModifier, Integer))
                                Case Classes.CLASS_PALADIN
                                    .Life.Increment(CType((.Spirit.Value * 0.25) * .LifeRegenerationModifier, Integer))
                            End Select
                            '.Life.Increment(CType((.Level + 2) * .LifeRegenerationModifier, Integer))       ' * LifeRegenWhileFightingPercent / 100
                        End If

                        Dim UpdateData As New UpdateClass
                        'DONE: Send updates to players near
                        If BaseMana <> .Mana.Current Then
                            _updateFlag = True
                            UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1, CType(.Mana.Current, Integer))
                        End If
                        If BaseRage <> .Rage.Current Or ((.cUnitFlags And UnitFlags.UNIT_FLAG_IN_COMBAT) = UnitFlags.UNIT_FLAG_IN_COMBAT) Then
                            _updateFlag = True
                            UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER2, CType(.Rage.Current, Integer))
                        End If
                        If BaseEnergy <> .Energy.Current Then
                            _updateFlag = True
                            UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER4, CType(.Energy.Current, Integer))
                        End If
                        If BaseLife <> .Life.Current Then
                            _updateFlag = True
                            UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, CType(.Life.Current, Integer))
                        End If

                        If _updateFlag Then
                            Dim myPacket As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                            myPacket.AddInt32(1)      'Operations.Count
                            myPacket.AddInt8(0)
                            UpdateData.AddToPacket(myPacket, ObjectUpdateType.UPDATETYPE_VALUES, CType(Character.Value, CharacterObject), 1)
                            .Client.Send(myPacket)
                            myPacket.Dispose()

                            Dim tmpPacket As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                            tmpPacket.AddInt32(1)      'Operations.Count
                            tmpPacket.AddInt8(0)
                            UpdateData.AddToPacket(tmpPacket, ObjectUpdateType.UPDATETYPE_VALUES, CType(Character.Value, CharacterObject), 0)
                            .SendToNearPlayers(tmpPacket)
                            tmpPacket.Dispose()
                        End If
                        UpdateData.Dispose()


                        'DONE: Duel counter
                        If .DuelOutOfBounds <> DUEL_COUNTER_DISABLED Then
                            .DuelOutOfBounds -= REGENERATION_TIMER
                            If .DuelOutOfBounds = 0 Then DuelComplete(.DuelPartner, .Client.Character)
                        End If
                    End With
                End If

                'Send UPDATE_OUT_OF_RANGE
                Try
                    If Character.Value.guidsForRemoving.Count > 0 Then Character.Value.SendOutOfRangeUpdate()
                Catch e As Exception
                    Log.WriteLine(LogType.WARNING, "Character.guidsForRemoving could not be enumerated!")
                End Try

            Next
            charactersLock_.ReleaseReaderLock()

        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            RegenerationTimer.dispose()
            RegenerationTimer = Nothing
            RegenerationTimerDelegate = Nothing
        End Sub
    End Class


    'NOTE: Manages spell durations and DOT spells
    Public Class TSpellManager
        Implements IDisposable

        Private SpellManagerTimer As Object = Nothing
        Private SpellManagerTimerDelegate As Threading.TimerCallback = Nothing

        Public Const UPDATE_TIMER As Integer = 1000        'Timer period (ms)
        Public Sub New()
            SpellManagerTimerDelegate = New Threading.TimerCallback(AddressOf Update)
            SpellManagerTimer = New System.Threading.Timer(SpellManagerTimerDelegate, Nothing, 6000, UPDATE_TIMER)
        End Sub
        Private Sub Update(ByVal state As Object)
            SyncLock WORLD_CREATUREs.SyncRoot
                For Each de As DictionaryEntry In WORLD_CREATUREs
                    UpdateSpells(de.Value)
                Next
            End SyncLock

            charactersLock_.AcquireReaderLock(Timeout.Infinite)
            For Each Character As DictionaryEntry In CHARACTERS
                UpdateSpells(Character.Value)
            Next
            charactersLock_.ReleaseReaderLock()
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            SpellManagerTimer.dispose()
            SpellManagerTimer = Nothing
            SpellManagerTimerDelegate = Nothing
        End Sub

        Private Sub UpdateSpells(ByVal c As BaseUnit)
            For i As Integer = 0 To MAX_AURA_EFFECTs_VISIBLE - 1
                If Not c.ActiveSpells(i) Is Nothing Then


                    'DONE: Count aura duration
                    If c.ActiveSpells(i).SpellDuration <> SPELL_DURATION_INFINITE Then
                        c.ActiveSpells(i).SpellDuration -= UPDATE_TIMER

                        'DONE: Cast aura (check if: there is aura; aura is periodic; time for next activation)
                        If Not c.ActiveSpells(i).Aura1 Is Nothing AndAlso _
                        c.ActiveSpells(i).Aura1_Info.Amplitude <> 0 AndAlso _
                        ((c.ActiveSpells(i).GetSpellInfo.GetDuration - c.ActiveSpells(i).SpellDuration) Mod c.ActiveSpells(i).Aura1_Info.Amplitude) = 0 Then
                            c.ActiveSpells(i).Aura1.Invoke(c, c.ActiveSpells(i).SpellCaster, c.ActiveSpells(i).Aura1_Info, c.ActiveSpells(i).SpellID, WS_Spells.AuraAction.AURA_UPDATE)
                        End If
                        If Not c.ActiveSpells(i).Aura2 Is Nothing AndAlso _
                        c.ActiveSpells(i).Aura2_Info.Amplitude <> 0 AndAlso _
                        ((c.ActiveSpells(i).GetSpellInfo.GetDuration - c.ActiveSpells(i).SpellDuration) Mod c.ActiveSpells(i).Aura2_Info.Amplitude) = 0 Then
                            c.ActiveSpells(i).Aura3.Invoke(c, c.ActiveSpells(i).SpellCaster, c.ActiveSpells(i).Aura2_Info, c.ActiveSpells(i).SpellID, WS_Spells.AuraAction.AURA_UPDATE)
                        End If
                        If Not c.ActiveSpells(i).Aura3 Is Nothing AndAlso _
                        c.ActiveSpells(i).Aura3_Info.Amplitude <> 0 AndAlso _
                        ((c.ActiveSpells(i).GetSpellInfo.GetDuration - c.ActiveSpells(i).SpellDuration) Mod c.ActiveSpells(i).Aura3_Info.Amplitude) = 0 Then
                            c.ActiveSpells(i).Aura3.Invoke(c, c.ActiveSpells(i).SpellCaster, c.ActiveSpells(i).Aura3_Info, c.ActiveSpells(i).SpellID, WS_Spells.AuraAction.AURA_UPDATE)
                        End If

                        'DONE: Remove finished aura
                        If c.ActiveSpells(i).SpellDuration <= 0 AndAlso c.ActiveSpells(i).SpellDuration <> SPELL_DURATION_INFINITE Then c.RemoveAura(i, c.ActiveSpells(i).SpellCaster)
                    End If


                End If
            Next

        End Sub
    End Class


    'NOTE: Manages ai movement and combat reactions
    Public Class TAIManager
        Implements IDisposable

        Private AIManagerTimer As Object = Nothing
        Private AIManagerTimerDelegate As Threading.TimerCallback = Nothing

        Public Const UPDATE_TIMER As Integer = 1000     'Timer period (ms)
        Public Sub New()
            AIManagerTimerDelegate = New Threading.TimerCallback(AddressOf Update)
            AIManagerTimer = New System.Threading.Timer(AIManagerTimerDelegate, Nothing, 60000, UPDATE_TIMER)
        End Sub
        Private Sub Update(ByVal state As Object)
            SyncLock WORLD_CREATUREs.SyncRoot
                For Each de As DictionaryEntry In WORLD_CREATUREs
                    If Not CType(de.Value, CreatureObject).aiScript Is Nothing Then CType(de.Value, CreatureObject).aiScript.DoThink()
                Next
            End SyncLock
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            AIManagerTimer.dispose()
            AIManagerTimer = Nothing
            AIManagerTimerDelegate = Nothing
        End Sub
    End Class

    'TODO: Timer for kicking not connected players (ping timeout)
    'TODO: Timer for auction items and mails
    'TODO: Timer for weather change

End Module


