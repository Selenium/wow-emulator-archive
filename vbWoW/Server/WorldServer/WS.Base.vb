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

Imports vbWoW.Logbase.BaseWriter

Public Module WS_Base
    Public Class BaseObject
        Public GUID As Long = 0
        Public CellX As Byte = 0
        Public CellY As Byte = 0

        Public positionX As Single = 0
        Public positionY As Single = 0
        Public positionZ As Single = 0
        Public orientation As Single = 0
        Public MapID As Integer = 0

        Public SpawnID As Integer = 0
        Public SeenBy As New ArrayList

        Public Invisibility As InvisibilityLevel = InvisibilityLevel.VISIBLE
        Public Invisibility_Value As Integer = 0
        Public CanSeeInvisibility As InvisibilityLevel = InvisibilityLevel.INIVISIBILITY
        Public CanSeeInvisibility_Stealth As Integer = 0
        Public CanSeeInvisibility_Invisibility As Integer = 0
        Public Overridable Function CanSee(ByRef c As BaseObject) As Boolean
            If GUID = c.GUID Then Return False

            'DONE: GM and DEAD invisibility
            If c.Invisibility > CanSeeInvisibility Then Return False
            'DONE: Stealth Detection
            If c.Invisibility = InvisibilityLevel.STEALTH AndAlso (Math.Sqrt((c.positionX - positionX) ^ 2 + (c.positionY - positionY) ^ 2) < DEFAULT_DISTANCE_DETECTION) Then Return True
            'DONE: Check invisibility
            If c.Invisibility = InvisibilityLevel.INIVISIBILITY AndAlso c.Invisibility_Value > CanSeeInvisibility_Invisibility Then Return False
            If c.Invisibility = InvisibilityLevel.STEALTH AndAlso c.Invisibility_Value > CanSeeInvisibility_Stealth Then Return False

            'DONE: Check distance
            If Math.Sqrt((c.positionX - positionX) ^ 2 + (c.positionY - positionY) ^ 2) > DEFAULT_DISTANCE_VISIBLE Then Return False
            Return True
        End Function
        Public Sub InvisibilityReset()
            Invisibility = InvisibilityLevel.VISIBLE
            Invisibility_Value = 0
            CanSeeInvisibility = InvisibilityLevel.INIVISIBILITY
            CanSeeInvisibility_Stealth = 0
            CanSeeInvisibility_Invisibility = 0
        End Sub

        Public Sub SendToNearPlayers(ByRef packet As PacketClass)
            Dim index As Integer = 0
            While index < SeenBy.Count
                CHARACTERS(CType(SeenBy.Item(index), Long)).Client.SendMultiplyPackets(packet)
                index += 1
            End While
        End Sub
    End Class


    Public Class BaseUnit
        Inherits BaseObject

        Public cUnitFlags As Integer = UnitFlags.UNIT_FLAG_ATTACKABLE
        Public cDynamicFlags As Integer = 0 'DynamicFlags.UNIT_DYNFLAG_SPECIALINFO
        Public cBytes1 As Integer = 0

        Public Level As Byte = 0
        Public Model As Integer = 0
        Public Mount As Integer = 0
        Public ManaType As ManaTypes = WS_CharManagment.ManaTypes.TYPE_MANA
        Public Life As New TStatBar(1, 1, 0)
        Public Mana As New TStatBar(1, 1, 0)
        Public Size As Single = 1.0

        'Temporaly variables
        Public Spell_Silenced As Boolean = False
        Public Spell_Pacifyed As Boolean = False
        Public Spell_ThreatModifier As Single = 1.0F
        Public AttackPowerMods As Integer = 0
        Public AttackPowerModsRanged As Integer = 0

        Public Overridable Sub Die(ByRef Attacker As BaseUnit)
            Log.WriteLine(LogType.WARNING, "BaseUnit can't die.")
        End Sub
        Public Overridable Sub DealDamage(ByVal Damage As Integer, Optional ByRef Attacker As BaseUnit = Nothing)
            Log.WriteLine(LogType.WARNING, "No damage dealt.")
        End Sub
        Public Overridable Sub DealDamageMagical(ByRef Damage As Integer, ByVal DamageType As DamageType, Optional ByRef Attacker As BaseUnit = Nothing)
            Log.WriteLine(LogType.WARNING, "No damage dealt.")
        End Sub
        Public Overridable Sub Heal(ByVal Damage As Integer, Optional ByRef Attacker As BaseUnit = Nothing)
            Log.WriteLine(LogType.WARNING, "No healing done.")
        End Sub
        Public Overridable Sub Energize(ByVal Damage As Integer, Optional ByRef Attacker As BaseUnit = Nothing)
            Log.WriteLine(LogType.WARNING, "No mana increase done.")
        End Sub
        Public Overridable ReadOnly Property isDead() As Boolean
            Get
                Return (Not (Life.Current > 0))
            End Get
        End Property


        'Spell Aura Managment
        Public ActiveSpells(MAX_AURA_EFFECTs_VISIBLE - 1) As BaseActiveSpell
        Public ActiveSpells_Flags(MAX_AURA_EFFECT_FLAGs - 1) As Integer
        Public Sub SetAura(ByVal SpellID As Integer, ByVal Slot As Integer, ByVal Duration As Integer)
            'DONE: Passive auras are not displayed
            If SpellID <> 0 AndAlso SPELLs.ContainsKey(SpellID) AndAlso CType(SPELLs(SpellID), SpellInfo).IsPassive Then Return

            'DONE: Calculating slots
            Dim AuraFlag_Slot As Integer = Slot \ 8
            Dim AuraFlag_SubSlot As Integer = (Slot Mod 8) * 4

            If SpellID = 0 Then
                ActiveSpells_Flags(AuraFlag_Slot) = (ActiveSpells_Flags(AuraFlag_Slot) Or (&H0 << AuraFlag_SubSlot))
            Else
                ActiveSpells_Flags(AuraFlag_Slot) = (ActiveSpells_Flags(AuraFlag_Slot) Or (&HF << AuraFlag_SubSlot))
            End If

            'DONE: Sending updates
            If TypeOf Me Is CharacterObject Then
                CType(Me, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_AURA + Slot, SpellID)
                CType(Me, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_AURAFLAGS + AuraFlag_Slot, ActiveSpells_Flags(AuraFlag_Slot))
                CType(Me, CharacterObject).SendCharacterUpdate(True)

                Dim SMSG_UPDATE_AURA_DURATION As New PacketClass(OPCODES.SMSG_UPDATE_AURA_DURATION)
                SMSG_UPDATE_AURA_DURATION.AddInt8(Slot)
                SMSG_UPDATE_AURA_DURATION.AddInt32(Duration)
                CType(Me, CharacterObject).Client.Send(SMSG_UPDATE_AURA_DURATION)
                SMSG_UPDATE_AURA_DURATION.Dispose()
            Else
                Dim tmpUpdate As New UpdateClass
                Dim tmpPacket As New UpdatePacketClass
                tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_AURA + Slot, SpellID)
                tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_AURAFLAGS + AuraFlag_Slot, ActiveSpells_Flags(AuraFlag_Slot))
                tmpUpdate.AddToPacket(tmpPacket, ObjectUpdateType.UPDATETYPE_VALUES, CType(Me, CreatureObject), 0)
                SendToNearPlayers(tmpPacket)
                tmpPacket.Dispose()
                tmpUpdate.Dispose()
            End If

        End Sub
        Public Sub RemoveAura(ByVal Slot As Integer, ByRef Caster As BaseUnit)
            'DONE: Removing SpellAura
            If Not ActiveSpells(Slot) Is Nothing Then
                If Not ActiveSpells(Slot).Aura1 Is Nothing Then ActiveSpells(Slot).Aura1.Invoke(Me, Caster, ActiveSpells(Slot).Aura1_Info, ActiveSpells(Slot).SpellID, AuraAction.AURA_REMOVE)
                If Not ActiveSpells(Slot).Aura2 Is Nothing Then ActiveSpells(Slot).Aura2.Invoke(Me, Caster, ActiveSpells(Slot).Aura2_Info, ActiveSpells(Slot).SpellID, AuraAction.AURA_REMOVE)
                If Not ActiveSpells(Slot).Aura3 Is Nothing Then ActiveSpells(Slot).Aura3.Invoke(Me, Caster, ActiveSpells(Slot).Aura3_Info, ActiveSpells(Slot).SpellID, AuraAction.AURA_REMOVE)
            End If
            ActiveSpells(Slot) = Nothing

            SetAura(0, Slot, 0)
        End Sub
        Public Sub AddAura(ByVal SpellID As Integer, ByVal Duration As Integer, ByRef Caster As BaseUnit)
            For slot As Integer = 0 To MAX_AURA_EFFECTs
                If ActiveSpells(slot) Is Nothing Then

                    'DONE: Adding New SpellAura
                    ActiveSpells(slot) = New BaseActiveSpell(SpellID, Duration)
                    ActiveSpells(slot).SpellCaster = Caster

                    SetAura(SpellID, slot, Duration)
                    Exit For


                End If
            Next
        End Sub

        Public Property ShapeshiftForm() As ShapeshiftForm
            Get
                Return (cBytes1 And &HFF0000)
            End Get
            Set(ByVal from As ShapeshiftForm)
                cBytes1 = ((cBytes1 And &HFF00FFFF) Or (from << 16))
            End Set
        End Property
    End Class

    Public Class BaseActiveSpell
        Public SpellID As Integer = 0
        Public SpellDuration As Integer = 0
        Public SpellCaster As BaseUnit = Nothing

        Public Aura1 As ApplyAuraHandler = Nothing
        Public Aura2 As ApplyAuraHandler = Nothing
        Public Aura3 As ApplyAuraHandler = Nothing
        Public Aura1_Info As SpellEffect = Nothing
        Public Aura2_Info As SpellEffect = Nothing
        Public Aura3_Info As SpellEffect = Nothing

        Public Sub New(ByVal ID As Integer, ByVal Duration As Integer)
            SpellID = ID
            SpellDuration = Duration
        End Sub
        Public ReadOnly Property GetSpellInfo() As SpellInfo
            Get
                Return SPELLs(SpellID)
            End Get
        End Property
    End Class
End Module
