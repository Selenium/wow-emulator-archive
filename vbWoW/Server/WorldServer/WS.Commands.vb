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
Imports System.Reflection
Imports vbWoW.Logbase.BaseWriter


#Region "WS.Commands.Attributes"
    <AttributeUsage(AttributeTargets.Method, Inherited:=False, AllowMultiple:=True)> _
        Public Class ChatCommandAttribute
        Inherits System.Attribute

        Private Command As String = ""
        Private CommandHelp As String = "No information available."
        Private CommandAccess As AccessLevel = WS_Commands.AccessLevel.GameMaster

        Public Sub New(ByVal cmdName As String, Optional ByVal cmdHelp As String = "No information available.", Optional ByVal cmdAccess As AccessLevel = WS_Commands.AccessLevel.GameMaster)
            Command = cmdName
            CommandHelp = cmdHelp
            CommandAccess = cmdAccess
        End Sub

        Public Property cmdName() As String
            Get
                Return Command
            End Get
            Set(ByVal Value As String)
                Command = Value
            End Set
        End Property
        Public Property cmdHelp() As String
            Get
                Return CommandHelp
            End Get
            Set(ByVal Value As String)
                CommandHelp = Value
            End Set
        End Property
        Public Property cmdAccess() As AccessLevel
            Get
                Return CommandAccess
            End Get
            Set(ByVal Value As AccessLevel)
                CommandAccess = Value
            End Set
        End Property

    End Class
#End Region


Public Module WS_Commands


#Region "WS.Commands.Framework"


    Public Const WardenGUID As Long = Integer.MaxValue
    Public Const WardenNAME As String = "Warden"
    Public Enum AccessLevel As Byte
        Trial = 0
        Player = 1
        PlayerVip = 2
        GameMaster = 3
        Admin = 4
        Developer = 5
    End Enum



    Public ChatCommands As New Hashtable
    Public ScriptedChatCommands As ScriptedObject
    Public Class ChatCommand
        Public CommandHelp As String
        Public CommandAccess As AccessLevel = AccessLevel.GameMaster
        Public CommandDelegate As ChatCommandDelegate
    End Class
    Public Delegate Function ChatCommandDelegate(ByRef c As CharacterObject, ByVal Message As String) As Boolean


    Public Sub RegisterChatCommands()
        ScriptedChatCommands = New ScriptedObject("scripts\Commands.vb", "vbWoW.Commands.dll", False)

        For Each tmpModule As Type In [Assembly].GetExecutingAssembly.GetTypes
            For Each tmpMethod As MethodInfo In tmpModule.GetMethods
                Dim infos() As ChatCommandAttribute = tmpMethod.GetCustomAttributes(GetType(ChatCommandAttribute), True)

                If infos.Length <> 0 Then
                    For Each info As ChatCommandAttribute In infos
                        Dim cmd As New ChatCommand
                        cmd.CommandHelp = info.cmdHelp
                        cmd.CommandAccess = info.cmdAccess
                        cmd.CommandDelegate = ChatCommandDelegate.CreateDelegate(GetType(ChatCommandDelegate), tmpMethod)

                        ChatCommands.Add(UCase(info.cmdName), cmd)
#If DEBUG Then
                        Log.WriteLine(vbWoW.Logbase.BaseWriter.LogType.INFORMATION, "Command found: {0}", UCase(info.cmdName))
#End If
                    Next
                End If
            Next
        Next

        For Each tmpModule As Type In ScriptedChatCommands.ass.GetTypes
            For Each tmpMethod As MethodInfo In tmpModule.GetMethods
                Dim infos() As ChatCommandAttribute = tmpMethod.GetCustomAttributes(GetType(ChatCommandAttribute), True)

                If infos.Length <> 0 Then
                    For Each info As ChatCommandAttribute In infos
                        Dim cmd As New ChatCommand
                        cmd.CommandHelp = info.cmdHelp
                        cmd.CommandAccess = info.cmdAccess
                        cmd.CommandDelegate = ChatCommandDelegate.CreateDelegate(GetType(ChatCommandDelegate), tmpMethod)

                        ChatCommands.Add(UCase(info.cmdName), cmd)
#If DEBUG Then
                        Log.WriteLine(vbWoW.Logbase.BaseWriter.LogType.INFORMATION, "Command found: {0}", UCase(info.cmdName))
#End If
                    Next
                End If
            Next
        Next


    End Sub
    Public Sub OnCommand(ByRef Client As ClientClass, ByVal Message As String)
        Try
            'DONE: Find the command
            Dim tmp() As String = Split(Message, " ", 2)
            Dim Command As ChatCommand = CType(ChatCommands(UCase(tmp(0))), ChatCommand)

            'DONE: Build argument string
            Dim Arguments As String = ""
            If tmp.Length = 2 Then Arguments = Trim(tmp(1))


            If Command Is Nothing Then
                Client.Character.CommandResponse("Unknown command.")
            ElseIf Command.CommandAccess > Client.Character.Access Then
                Client.Character.CommandResponse("This command is not available for your access level.")
            ElseIf Not Command.CommandDelegate(Client.Character, Arguments) Then
                Client.Character.CommandResponse(Command.CommandHelp)
            Else
                Log.WriteLine(LogType.USER, "[{0}:{1}] Command used: {2}", Client.IP, Client.Port, Message)
            End If

        Catch err As Exception
            Log.WriteLine(LogType.FAILED, "[{0}:{1}] Client command caused error! {3}{2}", Client.IP, Client.Port, err.ToString, vbNewLine)
            Client.Character.CommandResponse(String.Format("Your command caused error:" & vbNewLine & " [{0}]", err.Message))
        End Try
    End Sub


#End Region
#Region "WS.Commands.InternalCommands"


    <ChatCommandAttribute("Help", "HELP <CMD>" & vbNewLine & "Displays usage information about command, if no command specified - displays list of available commands.")> _
    Public Function Help(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Trim(Message) <> "" Then
            Dim Command As ChatCommand = CType(ChatCommands(Trim(UCase(Message))), ChatCommand)
            If Command Is Nothing Then
                c.CommandResponse("Unknown command.")
            ElseIf Command.CommandAccess > c.Access Then
                c.CommandResponse("This command is not available for your access level.")
            Else
                c.CommandResponse(Command.CommandHelp)
            End If
        Else
            Dim cmdList As String = "Listing available commands:" & vbNewLine
            For Each Command As DictionaryEntry In ChatCommands
                If CType(Command.Value, ChatCommand).CommandAccess <= c.Access Then cmdList += UCase(Command.Key) & ", "
            Next
            cmdList += vbNewLine + "Use HELP <CMD> for usage information about particular command."
            c.CommandResponse(cmdList)
        End If

        Return True
    End Function

    '****************************************** DEVELOPER COMMANDs *************************************************
    Dim x As Integer = 0
    <ChatCommandAttribute("Test", "This is test command used for debugging. Do not use if you don't know what it does!", AccessLevel.Developer)> _
    Public Function cmdTest(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        WORLD_GAMEOBJECTs(c.TargetGUID).orientation = 0
        WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(0) = 0
        WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(1) = 0
        WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(2) = 0
        WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(3) = 0

        Select Case x
            Case 0
                WORLD_GAMEOBJECTs(c.TargetGUID).orientation = c.orientation
            Case 1
                WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(0) = c.orientation
            Case 2
                WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(1) = c.orientation
            Case 3
                WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(2) = c.orientation
            Case 4
                WORLD_GAMEOBJECTs(c.TargetGUID).Rotation(3) = c.orientation
        End Select

        x += 1
        If x = 5 Then x = 0


        Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
        packet.AddInt32(1)
        packet.AddInt8(0)
        Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_GAMEOBJECT)
        WORLD_GAMEOBJECTs(c.TargetGUID).FillAllUpdateFlags(tmpUpdate, c)
        tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(WORLD_GAMEOBJECTs(c.TargetGUID), GameObjectObject), 0)
        tmpUpdate.Dispose()

        c.Client.Send(packet)

        packet.Dispose()

        Return True
    End Function
    <ChatCommandAttribute("Test2", "This is test command used for debugging. Do not use if you don't know what it does!", AccessLevel.Developer)> _
    Public Function cmdTest2(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        c.SetFlyTakeOff()
        'Dim packet As New PacketClass(811)
        'packet.AddInt32(4)
        'c.Client.Send(packet)
        Return True
    End Function
    Dim currentSpError As SpellFailedReason = SpellFailedReason.CAST_NO_ERROR
    <ChatCommandAttribute("SpellFailedMSG", "SPELLFAILEDMSG <optional ID> - Sends test spell failed message.", AccessLevel.Developer)> _
    Public Function cmdSpellFailed(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then
            currentSpError += 1
        Else
            currentSpError = Message
        End If
        SendCastResult(currentSpError, c.Client, 133)
        c.CommandResponse(String.Format("Sent spell failed message:{2} {0} = {1}", currentSpError, CType(currentSpError, Integer), vbNewLine))
        Return True
    End Function
    Dim currentInvError As InventoryChangeFailure = InventoryChangeFailure.EQUIP_ERR_OK
    <ChatCommandAttribute("InvFailedMSG", "INVFAILEDMSG <optional ID> - Sends test inventory failed message.", AccessLevel.Developer)> _
    Public Function cmdInventoryFailed(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then
            currentInvError += 1
        Else
            currentInvError = Message
        End If
        Dim response As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
        response.AddInt8(currentInvError)
        response.AddInt64(0)
        response.AddInt64(0)
        response.AddInt8(0)
        c.Client.Send(response)
        response.Dispose()
        c.CommandResponse(String.Format("Sent spell failed message:{2} {0} = {1}", currentInvError, CType(currentInvError, Integer), vbNewLine))
        Return True
    End Function
    <ChatCommandAttribute("CastSpell", "CASTSPELL <SpellID> <Target> - Selected unit will start casting spell. Target can be ME or SELF.", AccessLevel.Developer)> _
    Public Function cmdCastSpellMe(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim tmp As String() = Split(Message, " ", 2)
        Dim SpellID As Integer = tmp(0)
        Dim Target As String = UCase(tmp(1))

        If WORLD_CREATUREs.ContainsKey(c.TargetGUID) Then
            Select Case Target
                Case "ME"
                    CType(WORLD_CREATUREs(c.TargetGUID), CreatureObject).CastSpell(SpellID, c)
                Case "SELF"
                    CType(WORLD_CREATUREs(c.TargetGUID), CreatureObject).CastSpell(SpellID, CType(WORLD_CREATUREs(c.TargetGUID), CreatureObject))
            End Select
        Else
            c.CommandResponse(String.Format("GUID=[{0:X}] not found or unsupported.", c.TargetGUID))
        End If

        Return True
    End Function
    <ChatCommandAttribute("Cast", "CAST <SpellID> - You will start casting spell on selected target.", AccessLevel.Developer)> _
    Public Function cmdCastSpell(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim tmp As String() = Split(Message, " ", 2)
        Dim SpellID As Integer = tmp(0)

        If WORLD_CREATUREs.ContainsKey(c.TargetGUID) Then
            Dim Targets As New SpellTargets
            Targets.SetTarget_UNIT(WORLD_CREATUREs(c.TargetGUID))
            CType(SPELLs(SpellID), SpellInfo).Cast(c, Targets)
        ElseIf CHARACTERS.ContainsKey(c.TargetGUID) Then
            Dim Targets As New SpellTargets
            Targets.SetTarget_UNIT(CHARACTERS(c.TargetGUID))
            CType(SPELLs(SpellID), SpellInfo).Cast(c, Targets)
        Else
            c.CommandResponse(String.Format("GUID=[{0:X}] not found or unsupported.", c.TargetGUID))
        End If

        Return True
    End Function
    <ChatCommandAttribute("AddWardenToParty", "This command will add the command bot to you group.", AccessLevel.Developer)> _
    Public Function cmdAddWardenToParty(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim Warden As New CharacterObject
        Warden.Name = WardenNAME
        Warden.GUID = WardenGUID
        Warden.Client = New ClientClass
        Warden.Client.DEBUG_CONNECTION = True

        c.Party = New BaseParty(c)
        c.Party.AddCharacter(Warden)
        Return True
    End Function







    '****************************************** CHAT COMMANDs ******************************************************
    <ChatCommandAttribute("Broadcast", "BROADCAST <TEXT> - Send text message to all players on the server.")> _
    Public Function cmdBroadcast(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False

        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            Character.Value.SystemMessage("System Message: " & SetColor(Message, 255, 0, 0))
        Next
        charactersLock_.ReleaseReaderLock()

        Return True
    End Function
    <ChatCommandAttribute("MSGGame", "MSGGAME <TEXT> - Send text message to all players on the server."), _
     ChatCommandAttribute("GameMessage", "GAMEMESSAGE <TEXT> - Send text message to all players on the server.")> _
    Public Function cmdGameMessage(ByRef c As CharacterObject, ByVal Text As String) As Boolean
        If Text = "" Then Return False

        Dim packet As New PacketClass(OPCODES.SMSG_AREA_TRIGGER_MESSAGE)
        packet.AddInt32(0)
        packet.AddString(Text)
        packet.AddInt8(0)

        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            CType(Character.Value.Client, ClientClass).SendMultiplyPackets(packet)
        Next
        charactersLock_.ReleaseReaderLock()

        packet.Dispose()

        Return True
    End Function
    <ChatCommandAttribute("MSGServer", "MSGSERVER <TYPE> <TEXT> - Send text message to all players on the server."), _
     ChatCommandAttribute("ServerMessage", "SERVERMESSAGE <TYPE> <TEXT> - Send text message to all players on the server.")> _
    Public Function cmdServerMessage(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        '1,"[SERVER] Shutdown in %s"
        '2,"[SERVER] Restart in %s"
        '3,"%s"
        '4,"[SERVER] Shutdown cancelled"
        '5,"[SERVER] Restart cancelled"

        Dim tmp() As String = Split(Message, " ", 2)
        If tmp.Length <> 2 Then Return False
        Dim Type As Integer = tmp(0)
        Dim Text As String = tmp(1)


        Dim packet As New PacketClass(OPCODES.SMSG_SERVER_MESSAGE)
        packet.AddInt32(Type)
        packet.AddString(Text)

        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            CType(Character.Value.Client, ClientClass).SendMultiplyPackets(packet)
        Next
        charactersLock_.ReleaseReaderLock()

        packet.Dispose()

        Return True
    End Function
    <ChatCommandAttribute("MSGNotify", "MSGNOTIFY <TEXT> - Send text message to all players on the server."), _
     ChatCommandAttribute("NotifyMessage", "NOTIFYMESSAGE <TEXT> - Send text message to all players on the server.")> _
    Public Function cmdNotificationMessage(ByRef c As CharacterObject, ByVal Text As String) As Boolean
        If Text = "" Then Return False

        Dim packet As New PacketClass(OPCODES.SMSG_NOTIFICATION)
        packet.AddString(Text)

        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            CType(Character.Value.Client, ClientClass).SendMultiplyPackets(packet)
        Next
        charactersLock_.ReleaseReaderLock()

        packet.Dispose()

        Return True
    End Function
    <ChatCommandAttribute("Say", "SAY <TEXT> - Send tell message from command bot to selected player.")> _
    Public Function cmdSay(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False

        CType(CHARACTERS(c.TargetGUID), CharacterObject).CommandResponse(Message)

        Return True
    End Function


    '****************************************** DEBUG COMMANDs ******************************************************
    <ChatCommandAttribute("AddXP", "ADDXP <XP> - Add X experience points to selected character.")> _
    Public Function cmdAddXP(ByRef c As CharacterObject, ByVal tXP As String) As Boolean
        If tXP = "" Then Return False

        Dim XP As Integer = tXP

        If CHARACTERS.ContainsKey(c.TargetGUID) Then
            CHARACTERS(c.TargetGUID).AddXP(XP)
        Else
            c.CommandResponse("Target not found or not character.")
        End If

        Return True
    End Function
    <ChatCommandAttribute("AddTP", "ADDTP <POINTs> - Add X talent points to selected character.")> _
    Public Function cmdAddTP(ByRef c As CharacterObject, ByVal tTP As String) As Boolean
        If tTP = "" Then Return False

        Dim TP As Integer = tTP

        If CHARACTERS.ContainsKey(c.TargetGUID) Then
            CHARACTERS(c.TargetGUID).TalentPoints += TP
            CHARACTERS(c.TargetGUID).SetUpdateFlag(EPlayerFields.PLAYER_CHARACTER_POINTS1, CType(CHARACTERS(c.TargetGUID).TalentPoints, Integer))
            CHARACTERS(c.TargetGUID).SaveCharacter()
        Else
            c.CommandResponse("Target not found or not character.")
        End If

        Return True
    End Function
    <ChatCommandAttribute("AddItem", "ADDITEM <ID> <optional COUNT> - Add Y items with id X to selected character.")> _
    Public Function cmdAddItem(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim tmp() As String = Split(Message, " ", 2)
        If tmp.Length < 1 Then Return False


        Dim id As Integer = tmp(0)
        Dim Count As Integer = 1
        If tmp.Length = 2 Then Count = tmp(1)

        Dim newItem As New ItemObject(id, c.GUID)
        newItem.StackCount = Count
        If c.ItemADD(newItem) Then
            c.LogCreateItem(id)
        Else
            newItem.Delete()
        End If



        Return True
    End Function
    <ChatCommandAttribute("AddMoney", "ADDMONEY <XP> - Add X copper yours.")> _
    Public Function cmdAddMoney(ByRef c As CharacterObject, ByVal tCopper As String) As Boolean
        If tCopper = "" Then Return False

        Dim Copper As Integer = tCopper

        c.Copper += Copper
        c.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, c.Copper)
        c.SendCharacterUpdate(False)

        Return True
    End Function
    <ChatCommandAttribute("LearnSkill", "LearnSkill <ID> <CURRENT> <MAX> - Add skill id X with value Y of Z to selected character.")> _
    Public Function cmdLearnSkill(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False


        If CHARACTERS.ContainsKey(c.TargetGUID) Then
            Dim tmp() As String
            tmp = Split(Trim(Message), " ")

            Dim SkillID As Integer = tmp(0)
            Dim Current As Int16 = tmp(1)
            Dim Maximum As Int16 = tmp(2)

            If CHARACTERS(c.TargetGUID).Skills.ContainsKey(SkillID) Then
                CType(CHARACTERS(c.TargetGUID).Skills(SkillID), TSkill).Base = Maximum
                CType(CHARACTERS(c.TargetGUID).Skills(SkillID), TSkill).Current = Current
            Else
                CHARACTERS(c.TargetGUID).LearnSkill(SkillID, Current, Maximum)
            End If

            CHARACTERS(c.TargetGUID).FillAllUpdateFlags()
            CHARACTERS(c.TargetGUID).SendUpdate()
        Else
            c.CommandResponse("Target not found or not character.")
        End If

        Return True
    End Function
    <ChatCommandAttribute("LearnSpell", "LearnSpell <ID> - Add spell X to selected character.")> _
    Public Function cmdLearnSpell(ByRef c As CharacterObject, ByVal tID As String) As Boolean
        If tID = "" Then Return False

        Dim ID As Integer = tID

        If CHARACTERS.ContainsKey(c.TargetGUID) Then
            CHARACTERS(c.TargetGUID).LearnSpell(ID)
        Else
            c.CommandResponse("Target not found or not character.")
        End If

        Return True
    End Function

    <ChatCommandAttribute("ShowTaxi", "SHOWTAXI - Unlock all taxi locations.")> _
    Public Function cmdShowTaxi(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        c.TaxiZones.SetAll(True)
        Return True
    End Function
    <ChatCommandAttribute("SET", "SET <INDEX> <VALUE> - Set update value (A9).")> _
    Public Function cmdSetUpdateField(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False
        Dim tmp() As String = Split(Message, " ", 2)

        SetUpdateValue(c.TargetGUID, tmp(0), tmp(1), c.Client)
        Return True
    End Function
    <ChatCommandAttribute("SetRunSpeed", "SETRUNSPEED <VALUE> - Change your run speed.")> _
    Public Function cmdSetRunSpeed(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False
        c.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, Message)
        c.CommandResponse("Your RunSpeed is changed to " & Message)
        Return True
    End Function
    <ChatCommandAttribute("SetSwimSpeed", "SETSWIMSPEED <VALUE> - Change your swim speed.")> _
    Public Function cmdSetSwimSpeed(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False
        c.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.SWIM, Message)
        c.CommandResponse("Your SwimSpeed is changed to " & Message)
        Return True
    End Function
    <ChatCommandAttribute("SetRunBackSpeed", "SETRUNBACKSPEED <VALUE> - Change your run back speed.")> _
    Public Function cmdSetRunBackSpeed(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False
        c.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.SWIMBACK, Message)
        c.CommandResponse("Your RunBackSpeed is changed to " & Message)
        Return True
    End Function
    <ChatCommandAttribute("SetFlySpeed", "SETFLYSPEED <VALUE> - Change your fly speed.")> _
    Public Function cmdSetFlySpeed(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False
        c.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLY, Message)
        c.CommandResponse("Your FlySpeed is changed to " & Message)
        Return True
    End Function
    <ChatCommandAttribute("SetFlyBackSpeed", "SETFLYBACKSPEED <VALUE> - Change your fly back speed.")> _
    Public Function cmdSetFlyBackSpeed(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False
        c.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLYBACK, Message)
        c.CommandResponse("Your FlyBackSpeed is changed to " & Message)
        Return True
    End Function
    <ChatCommandAttribute("SetReputation", "SETREPUTATION <FACTION> <VALUE> - Change your reputation standings.")> _
    Public Function cmdSetReputation(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If Message = "" Then Return False
        Dim tmp() As String = Split(Message, " ", 2)
        c.SetReputation(tmp(0), tmp(1))
        Return True
    End Function

    <ChatCommandAttribute("Mount", "Will mount you to specified model ID.", AccessLevel.GameMaster)> _
    Public Function cmdMount(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim value As Integer = Message
        c.SetUpdateFlag(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID, value)
        c.SendCharacterUpdate(True)
        Return True
    End Function
    <ChatCommandAttribute("FlyMountEnable", "Will enable fly mount mode.", AccessLevel.GameMaster)> _
    Public Function cmdFlyMountEnable(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        c.SetFlyTakeOff()
        Return True
    End Function
    <ChatCommandAttribute("FlyMountDisable", "Will disable fly mount mode.", AccessLevel.GameMaster)> _
    Public Function cmdFlyMountDisable(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        c.SetFlyLand()
        Return True
    End Function





    '****************************************** ACCOUNT MANAGMENT COMMANDs ******************************************
    <ChatCommandAttribute("Slap", "SLAP <DAMAGE> - Slap target creature or player for X damage.")> _
    Public Function cmdSlap(ByRef c As CharacterObject, ByVal tDamage As String) As Boolean
        Dim Damage As Integer = tDamage

        If GuidIsCreature(c.TargetGUID) Then
            CType(WORLD_CREATUREs(c.TargetGUID), CreatureObject).DealDamage(Damage)
        ElseIf GuidIsPlayer(c.TargetGUID) Then
            CType(CHARACTERS(c.TargetGUID), CharacterObject).DealDamage(Damage)
            CType(CHARACTERS(c.TargetGUID), CharacterObject).SystemMessage(c.Name & " slaps you for " & Damage & " damage.")
        Else
            c.CommandResponse("Not supported target selected.")
        End If

        Return True
    End Function
    <ChatCommandAttribute("Kick", "KICK <optional NAME> - Kick selected player or character with name specified if found.")> _
    Public Function cmdKick(ByRef c As CharacterObject, ByVal Name As String) As Boolean
        If Name = "" Then

            'DONE: Kick by selection
            If c.TargetGUID = 0 Then
                c.CommandResponse("No target selected.")
            ElseIf CHARACTERS.ContainsKey(c.TargetGUID) Then
                'DONE: Kick gracefully
                c.CommandResponse(String.Format("Character [{0}] kicked form server.", CType(CHARACTERS(c.TargetGUID), CharacterObject).Name))
                Log.WriteLine(LogType.INFORMATION, "[{0}:{1}] Character [{3}] kicked by [{2}].", c.Client.IP.ToString, c.Client.Port, c.Client.Character.Name, CHARACTERS(c.TargetGUID).Name)
                CHARACTERS(c.TargetGUID).Logout()
            Else
                c.CommandResponse(String.Format("Character GUID=[{0}] not found.", c.TargetGUID))
            End If

        Else

            'DONE: Kick by name
            charactersLock_.AcquireReaderLock(Timeout.Infinite)
            For Each Character As DictionaryEntry In CHARACTERS
                If UCase(CType(Character.Value, CharacterObject).Name) = Name Then
                    charactersLock_.ReleaseReaderLock()
                    'DONE: Kick gracefully
                    Character.Value.Logout()
                    c.CommandResponse(String.Format("Character [{0}] kicked form server.", CType(Character.Value, CharacterObject).Name))
                    Log.WriteLine(LogType.INFORMATION, "[{0}:{1}] Character [{3}] kicked by [{2}].", c.Client.IP.ToString, c.Client.Port, c.Client.Character.Name, Name)
                    Return True
                End If
            Next
            charactersLock_.ReleaseReaderLock()
            c.CommandResponse(String.Format("Character [{0:X}] not found.", Name))

        End If
        Return True
    End Function
    <ChatCommandAttribute("KickReason", "KICKREASON <TEXT> - Display message for 2 seconds and kick selected player.")> _
    Public Function cmdKickReason(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If c.TargetGUID = 0 Then
            c.CommandResponse("No target selected.")
        Else
            SystemMessage(String.Format("Character [{0}] kicked form server.{3}Reason: {1}{3}GameMaster: [{2}].", SetColor(CType(CHARACTERS(c.TargetGUID), CharacterObject).Name, 255, 0, 0), SetColor(Message, 255, 0, 0), SetColor(c.Name, 255, 0, 0), vbNewLine))
            Thread.Sleep(2000)

            cmdKick(c, "")
        End If

        Return True
    End Function
    <ChatCommandAttribute("Disconnect", "DISCONNECT <optional NAME> - Disconnects selected player or character with name specified if found.")> _
    Public Function cmdDisconnect(ByRef c As CharacterObject, ByVal Name As String) As Boolean
        If Name = "" Then

            'DONE: Kick by selection
            If c.TargetGUID = 0 Then
                c.CommandResponse("No target selected.")
            ElseIf CHARACTERS.ContainsKey(c.TargetGUID) Then
                c.CommandResponse(String.Format("Character [{0}] kicked form server.", CType(CHARACTERS(c.TargetGUID), CharacterObject).Name))
                Log.WriteLine(LogType.INFORMATION, "[{0}:{1}] Character [{3}] kicked by [{2}].", c.Client.IP.ToString, c.Client.Port, c.Client.Character.Name, CHARACTERS(c.TargetGUID).Name)
                CType(CHARACTERS(c.TargetGUID), CharacterObject).Client.Socket.Shutdown(Net.Sockets.SocketShutdown.Both)
            Else
                c.CommandResponse(String.Format("Character GUID=[{0}] not found.", c.TargetGUID))
            End If

        Else

            'DONE: Kick by name
            charactersLock_.AcquireReaderLock(Timeout.Infinite)
            For Each Character As DictionaryEntry In CHARACTERS
                If UCase(CType(Character.Value, CharacterObject).Name) = Name Then
                    charactersLock_.ReleaseReaderLock()
                    c.CommandResponse(String.Format("Character [{0}] kicked form server.", CType(Character.Value, CharacterObject).Name))
                    Log.WriteLine(LogType.INFORMATION, "[{0}:{1}] Character [{3}] kicked by [{2}].", c.Client.IP.ToString, c.Client.Port, c.Client.Character.Name, Name)
                    CType(Character.Value, CharacterObject).Client.Socket.Shutdown(Net.Sockets.SocketShutdown.Both)
                    Return True
                End If
            Next
            charactersLock_.ReleaseReaderLock()
            c.CommandResponse(String.Format("Character [{0:X}] not found.", Name))

        End If
        Return True
    End Function

    <ChatCommandAttribute("ForceRename", "FORCERENAME - Force selected player to change his name next time on char enum.")> _
    Public Function cmdForceRename(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If c.TargetGUID = 0 Then
            c.CommandResponse("No target selected.")
        ElseIf CHARACTERS.ContainsKey(c.TargetGUID) Then
            Database.Update(String.Format("UPDATE adb_characters SET force_restrictions = 1 WHERE char_guid = {0};", c.TargetGUID))
            c.CommandResponse("Player will be asked to change his name on next logon.")
        Else
            c.CommandResponse(String.Format("Character GUID=[{0:X}] not found.", c.TargetGUID))
        End If

        Return True
    End Function
    <ChatCommandAttribute("ForceLock", "FORCELOCK - Selected player won't be able to login next time with this character.")> _
    Public Function cmdForceLock(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If c.TargetGUID = 0 Then
            c.CommandResponse("No target selected.")
        ElseIf CHARACTERS.ContainsKey(c.TargetGUID) Then
            Database.Update(String.Format("UPDATE adb_characters SET force_restrictions = 2 WHERE char_guid = {0};", c.TargetGUID))
            c.CommandResponse("Character disabled.")
        Else
            c.CommandResponse(String.Format("Character GUID=[{0:X}] not found.", c.TargetGUID))
        End If

        Return True
    End Function


    <ChatCommandAttribute("Ban", "BAN <ACCOUNT> - Ban specified account from server.")> _
    Public Function cmdBan(ByRef c As CharacterObject, ByVal Name As String) As Boolean
        If Name = "" Then Return False

        Dim result As New DataTable
        Database.Query("SELECT banned FROM adb_accounts WHERE account = """ & Name & """;", result)
        If result.Rows.Count > 0 Then
            If result.Rows(0).Item("banned") = 1 Then
                c.CommandResponse(String.Format("Account [{0}] already banned.", Name))
            Else
                Database.Update("UPDATE adb_accounts SET banned = 1 WHERE account = """ & Name & """;")
                c.CommandResponse(String.Format("Account [{0}] banned.", Name))
                Log.WriteLine(LogType.INFORMATION, "[{0}:{1}] Account [{3}] banned by [{2}].", c.Client.IP.ToString, c.Client.Port, c.Name, Name)
            End If
        Else
            c.CommandResponse(String.Format("Account [{0}] not found.", Name))
        End If

        Return True
    End Function
    <ChatCommandAttribute("UnBan", "UNBAN <ACCOUNT> - Remove ban of specified account from server.")> _
    Public Function cmdUnBan(ByRef c As CharacterObject, ByVal Name As String) As Boolean
        If Name = "" Then Return False

        Dim result As New DataTable
        Database.Query("SELECT banned FROM adb_accounts WHERE account = """ & Name & """;", result)
        If result.Rows.Count > 0 Then
            If result.Rows(0).Item("banned") = 0 Then
                c.CommandResponse(String.Format("Account [{0}] is not banned.", Name))
            Else
                Database.Update("UPDATE adb_accounts SET banned = 0 WHERE account = """ & Name & """;")
                c.CommandResponse(String.Format("Account [{0}] unbanned.", Name))
                Log.WriteLine(LogType.INFORMATION, "[{0}:{1}] Account [{3}] unbanned by [{2}].", c.Client.IP.ToString, c.Client.Port, c.Name, Name)
            End If
        Else
            c.CommandResponse(String.Format("Account [{0}] not found.", Name))
        End If

        Return True
    End Function

    <ChatCommandAttribute("Info", "INFO <optional NAME> - Show account information for selected target or character with name specified if found.")> _
    Public Function cmdInfo(ByRef c As CharacterObject, ByVal Name As String) As Boolean
        If Name = "" Then

            Dim GUID As Long = c.TargetGUID
            If GUID = 0 Then GUID = c.GUID

            'DONE: Info by selection
            If CHARACTERS.ContainsKey(GUID) Then
                c.CommandResponse(String.Format("Information for character [{0}]:{1}account = {2}{1}ip = {3}{1}guid = {4:X}{1}access = {5}", _
                CType(CHARACTERS(GUID), CharacterObject).Name, vbNewLine, _
                CType(CHARACTERS(GUID), CharacterObject).Client.Account, _
                CType(CHARACTERS(GUID), CharacterObject).Client.IP.ToString, _
                CType(CHARACTERS(GUID), CharacterObject).GUID, _
                CType(CHARACTERS(GUID), CharacterObject).Access))
            ElseIf WORLD_CREATUREs.ContainsKey(GUID) Then
                c.CommandResponse(String.Format("Information for creature [{0}]:{1}id = {2}{1}guid = {3:X}{1}model = {4}", _
                CType(WORLD_CREATUREs(GUID), CreatureObject).Name, vbNewLine, _
                CType(WORLD_CREATUREs(GUID), CreatureObject).ID, _
                GUID, _
                CType(CREATURESDatabase(WORLD_CREATUREs(GUID).id), CreatureInfo).Model))
            ElseIf WORLD_GAMEOBJECTs.ContainsKey(GUID) Then
                c.CommandResponse(String.Format("Information for gameobject [{0}]:{1}id = {2}{1}guid = {3:X}{1}model = {4}", _
                CType(WORLD_GAMEOBJECTs(GUID), GameObjectObject).Name, vbNewLine, _
                CType(WORLD_GAMEOBJECTs(GUID), GameObjectObject).ID, _
                GUID, _
                CType(GAMEOBJECTSDatabase(WORLD_GAMEOBJECTs(GUID).id), GameObjectInfo).Model))
            Else
                c.CommandResponse(String.Format("GUID=[{0:X}] not found or unsupported.", GUID))
            End If

        Else

            'DONE: Info by name
            charactersLock_.AcquireReaderLock(Timeout.Infinite)
            For Each Character As DictionaryEntry In CHARACTERS
                If UCase(CType(Character.Value, CharacterObject).Name) = Name Then
                    charactersLock_.ReleaseReaderLock()
                    c.CommandResponse(String.Format("Information for character [{0}]:{1}account = {2}{1}ip = {3}{1}guid = {4}{1}access = {5}", _
                    CType(Character.Value, CharacterObject).Name, vbNewLine, _
                    CType(Character.Value, CharacterObject).Client.Account, _
                    CType(Character.Value, CharacterObject).Client.IP.ToString, _
                    CType(Character.Value, CharacterObject).GUID, _
                    CType(Character.Value, CharacterObject).Access))
                    Exit Function
                End If
            Next
            charactersLock_.ReleaseReaderLock()
            c.CommandResponse(String.Format("Character [{0}] not found.", Name))

        End If

        Return True
    End Function
    <ChatCommandAttribute("Where", "WHERE - Display your position information.")> _
    Public Function cmdWhere(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        c.SendChatMSG(c, String.Format("Coords: x={0}, y={1}, z={2}, or={3}", c.positionX, c.positionY, c.positionZ, c.orientation), ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)
        c.SendChatMSG(c, String.Format("Cell: {0},{1} SubCell: {2},{3}", GetMapTileX(c.positionX), GetMapTileY(c.positionY), GetSubMapTileX(c.positionX), GetSubMapTileY(c.positionY)), ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)
        c.SendChatMSG(c, String.Format("ZCoords: {0} AreaFlag: {1} WaterLevel={2}", GetZCoord(c.positionX, c.positionY), GetAreaFlag(c.positionX, c.positionY), GetWaterLevel(c.positionX, c.positionY)), ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)

        Return True
    End Function


    '****************************************** MISC COMMANDs *******************************************************
    <ChatCommandAttribute("SetGM", "SETGM <FLAG> <INVISIBILITY> - Toggles gameMaster status. You can use values like On/Off/1/0.")> _
    Public Function cmdSetGM(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim tmp() As String = Split(Message, " ", 2)
        Dim value1 As String = tmp(0)
        Dim value2 As String = tmp(1)


        'Commnad: .setgm <gmflag:0/1/off/on> <invisibility:0/1/off/on>
        If value1 = "0" Or UCase(value1) = "OFF" Then
            SetFlag(c.cPlayerFlags, PlayerFlag.PLAYER_FLAG_GM, False)
            c.CommandResponse("GameMaster Flag turned off.")
        Else
            SetFlag(c.cPlayerFlags, PlayerFlag.PLAYER_FLAG_GM, True)
            c.CommandResponse("GameMaster Flag turned on.")
        End If
        If value2 = "0" Or UCase(value2) = "OFF" Then
            c.Invisibility = InvisibilityLevel.VISIBLE
            c.CanSeeInvisibility = InvisibilityLevel.VISIBLE
            c.CommandResponse("GameMaster Invisibility turned off.")
        Else
            c.Invisibility = InvisibilityLevel.GM
            c.CanSeeInvisibility = InvisibilityLevel.GM
            c.CommandResponse("GameMaster Invisibility turned on.")
        End If
        c.SetUpdateFlag(EPlayerFields.PLAYER_FLAGS, c.cPlayerFlags)
        c.SendCharacterUpdate()
        UpdateCell(c)

        Return True
    End Function
    <ChatCommandAttribute("SetWeather", "SETWEATHER <TYPE> <INTENSITY> - Change weather in current zone. Intensity is float value!")> _
    Public Function cmdSetWeather(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim tmp() As String = Split(Message, " ", 2)
        Dim Type As Integer = tmp(0)
        Dim Intensity As Single = tmp(1)


        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_weather WHERE weather_zone = {0};", c.ZoneID), MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then
            Database.Update(String.Format("INSERT INTO adb_weather (weather_zone, weather_type, weather_intensity) VALUES ({0}, {1}, {2});", c.ZoneID, Type, Trim(Str(Intensity))))
        Else
            Database.Update(String.Format("UPDATE adb_weather SET weather_zone = {0}, weather_type = {1}, weather_intensity = {2};", c.ZoneID, Type, Trim(Str(Intensity))))
        End If
        SendWeather(Type, Intensity, c.Client)

        Return True
    End Function


    '****************************************** SPAWNING COMMANDs ***************************************************
    <ChatCommandAttribute("Del", "DEL <ID> - Delete selected creature or gameobject."), _
     ChatCommandAttribute("Delete", "DELETE <ID> - Delete selected creature or gameobject."), _
     ChatCommandAttribute("Remove", "REMOVE <ID> - Delete selected creature or gameobject.")> _
    Public Function cmdDeleteObject(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If c.TargetGUID = 0 Then
            c.CommandResponse("Select target first!")
            Return True
        End If

        If GuidIsCreature(c.TargetGUID) Then
            'DONE: Delete creature
            If Not WORLD_CREATUREs.Contains(c.TargetGUID) Then
                c.CommandResponse("Selected target is not creature!")
                Return True
            End If

            Spawner.DeSpawnCreature(WORLD_CREATUREs(c.TargetGUID))
            Database.Update(String.Format("DELETE FROM tmpSpawnedCreatures WHERE spawned_guid = {0};", c.TargetGUID - GUID_UNIT))
            c.CommandResponse("Creature deleted.")

        ElseIf GuidIsGameObject(c.TargetGUID) Then
            'DONE: Delete GO
            If Not WORLD_GAMEOBJECTs.Contains(c.TargetGUID) Then
                c.CommandResponse("Selected target is not game object!")
                Return True
            End If

            Spawner.DeSpawnGameObject(WORLD_GAMEOBJECTs(c.TargetGUID))
            Database.Update(String.Format("DELETE FROM tmpSpawnedGameObjects WHERE gameObject_guid = {0};", c.TargetGUID - GUID_GAMEOBJECT))
            c.CommandResponse("Game object deleted.")

        End If




        Return True
    End Function
    <ChatCommandAttribute("Turn", "TURN - Selected creature or game object will turn to your position.")> _
    Public Function cmdTurnObject(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If c.TargetGUID = 0 Then
            c.CommandResponse("Select target first!")
            Return True
        End If

        If GuidIsCreature(c.TargetGUID) Then
            'DONE: Turn creature
            If Not WORLD_CREATUREs.Contains(c.TargetGUID) Then
                c.CommandResponse("Selected target is not creature!")
                Return True
            End If

            CType(WORLD_CREATUREs(c.TargetGUID), CreatureObject).TurnTo(c.positionX, c.positionY)

        ElseIf GuidIsGameObject(c.TargetGUID) Then
            'DONE: Turn GO
            If Not WORLD_GAMEOBJECTs.Contains(c.TargetGUID) Then
                c.CommandResponse("Selected target is not game object!")
                Return True
            End If

            CType(WORLD_GAMEOBJECTs(c.TargetGUID), GameObjectObject).TurnTo(c.positionX, c.positionY)

            Dim q As New DataTable
            Dim GUID As Long = c.TargetGUID - GUID_GAMEOBJECT
            Database.Query("SELECT gameObject_guid FROM tmpSpawnedGameObjects WHERE gameObject_guid = " & GUID & ";", q)
            If q.Rows.Count > 0 Then
                Dim rot1 As Single = CType(WORLD_GAMEOBJECTs(c.TargetGUID), GameObjectObject).Rotation(0)
                Dim rot2 As Single = CType(WORLD_GAMEOBJECTs(c.TargetGUID), GameObjectObject).Rotation(1)
                Dim rot3 As Single = CType(WORLD_GAMEOBJECTs(c.TargetGUID), GameObjectObject).Rotation(2)
                Dim rot4 As Single = CType(WORLD_GAMEOBJECTs(c.TargetGUID), GameObjectObject).Rotation(3)
                Dim o As Single = CType(WORLD_GAMEOBJECTs(c.TargetGUID), GameObjectObject).orientation
                Database.Update(String.Format("UPDATE tmpSpawnedGameObjects SET gameObject_orientation = {0}, gameObject_rotation1 = {1},gameObject_rotation2 = {2}, gameObject_rotation3 = {3},gameObject_rotation4 = {4} WHERE gameObject_guid = {5};", Trim(Str(o)), Trim(Str(rot1)), Trim(Str(rot2)), Trim(Str(rot3)), Trim(Str(rot4)), GUID))
            End If

            c.CommandResponse("Object rotation will be visible when the object is reloaded!")

        End If

        Return True
    End Function

    <ChatCommandAttribute("AddNPC", "ADDNPC <ID> - Spawn creature at your position."), _
     ChatCommandAttribute("AddCreature", "ADDCREATURE <ID> - Spawn creature at your position.")> _
    Public Function cmdAddCreature(ByRef c As CharacterObject, ByVal Message As String) As Boolean

        Dim tmpCr As CreatureObject = Spawner.SpawnCreature(CType(Message, Integer), c.positionX, c.positionY, c.positionZ, c.orientation)
        Database.Update(String.Format("INSERT INTO tmpSpawnedCreatures (spawned_guid,spawned_positionX,spawned_positionY,spawned_positionZ,spawned_orientation,spawned_map,spawned_entry,spawn_id) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});", tmpCr.GUID - GUID_UNIT, Trim(Str(tmpCr.positionX)), Trim(Str(tmpCr.positionY)), Trim(Str(tmpCr.positionZ)), Trim(Str(tmpCr.orientation)), tmpCr.MapID, tmpCr.ID, tmpCr.SpawnID))
        c.CommandResponse("Creature [" & tmpCr.Name & "] spawned.")

        Return True
    End Function
    <ChatCommandAttribute("Come", "COME - Selected creature will come to your position.")> _
    Public Function cmdComeCreature(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If c.TargetGUID = 0 Then
            c.CommandResponse("Select target first!")
            Exit Function
        End If
        If Not WORLD_CREATUREs.Contains(c.TargetGUID) Then
            c.CommandResponse("Selected target is not creature!")
            Exit Function
        End If

        CType(WORLD_CREATUREs(c.TargetGUID), CreatureObject).MoveTo(c.positionX, c.positionY, c.positionZ)

        Return True
    End Function
    <ChatCommandAttribute("Kill", "KILL - Selected creature or character will die.")> _
    Public Function cmdKillCreature(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        If c.TargetGUID = 0 Then
            c.CommandResponse("Select target first!")
            Return True
        End If

        If CHARACTERS.ContainsKey(c.TargetGUID) Then
            CHARACTERS(c.TargetGUID).Die(c)
            Return True
        End If
        If WORLD_CREATUREs.ContainsKey(c.TargetGUID) Then
            CType(WORLD_CREATUREs(c.TargetGUID), CreatureObject).Die(c)
            Return True
        End If
        Return True
    End Function

    <ChatCommandAttribute("TargetGo", "TARGETGO - Nearest game object will be selected.")> _
    Public Function cmdTargetGameObject(ByRef c As CharacterObject, ByVal Message As String) As Boolean
        Dim minDistance As Single = Single.MaxValue
        Dim tmpDistance As Single

        For Each guid As Long In c.gameObjectsNear
            tmpDistance = GetDistance(WORLD_GAMEOBJECTs(guid), c)
            If tmpDistance < minDistance Then
                minDistance = tmpDistance
                c.TargetGUID = guid
            End If
        Next

        c.CommandResponse(String.Format("Selected [{0}] game object at distance {1}.", WORLD_GAMEOBJECTs(c.TargetGUID).Name, minDistance))

        Return True
    End Function
    <ChatCommandAttribute("AddGO", "ADDGO <ID> - Spawn game object at your position."), _
     ChatCommandAttribute("AddGameObject", "ADDGAMEOBJECT <ID> - Spawn game object at your position.")> _
    Public Function cmdAddGameObject(ByRef c As CharacterObject, ByVal Message As String) As Boolean

        Dim tmpGO As GameObjectObject = Spawner.SpawnGameObject(CType(Message, Integer), c.positionX, c.positionY, c.positionZ, c.orientation)
        tmpGO.Rotation(2) = Math.Sin(tmpGO.orientation / 2)
        tmpGO.Rotation(3) = Math.Cos(tmpGO.orientation / 2)

        Database.Update(String.Format("INSERT INTO tmpSpawnedGameObjects (gameObject_guid,gameObject_positionX,gameObject_positionY,gameObject_positionZ,gameObject_orientation,gameObject_map,gameObject_entry,gameObject_spawnId,gameObject_rotation1,gameObject_rotation2,gameObject_rotation3,gameObject_rotation4) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});", tmpGO.GUID - GUID_GAMEOBJECT, Trim(Str(tmpGO.positionX)), Trim(Str(tmpGO.positionY)), Trim(Str(tmpGO.positionZ)), Trim(Str(tmpGO.orientation)), tmpGO.MapID, tmpGO.ID, tmpGO.SpawnID, Trim(Str(tmpGO.Rotation(0))), Trim(Str(tmpGO.Rotation(1))), Trim(Str(tmpGO.Rotation(2))), Trim(Str(tmpGO.Rotation(3)))))
        c.CommandResponse("GameObject [" & tmpGO.Name & "] spawned.")

        Return True
    End Function



    'IDEA: Spawning with:
    '       .addcreature <ID>
    '       .delcreature
    '       .come
    '       .turn

    '       .addwaypoint
    '       .setwaypointtype
    '       .setitem <ID>
    '       .setmount <ID>
    '       .savespawn
    '       .setspawndist <DIST>
    '       .setspawntime <TIME>
    '       .delspawn


#End Region
#Region "WS.Commands.InternalCommands.HelperSubs"


    Public Sub SystemMessage(ByVal Message As String)
        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            Character.Value.SystemMessage("System Message: " & Message)
        Next
        charactersLock_.ReleaseReaderLock()
    End Sub
    Public Function SetUpdateValue(ByVal GUID As Long, ByVal Index As Integer, ByVal Value As Integer, ByVal Client As ClientClass) As Boolean
        Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
        packet.AddInt32(1)      'Operations.Count
        packet.AddInt8(0)
        Dim UpdateData As New UpdateClass
        UpdateData.SetUpdateFlag(Index, Value)

        If GuidIsCreature(GUID) Then
            UpdateData.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(WORLD_CREATUREs(GUID), CreatureObject), 0)
        ElseIf GuidIsPlayer(GUID) Then
            If GUID = Client.Character.GUID Then
                UpdateData.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(CHARACTERS(GUID), CharacterObject), 1)
            Else
                UpdateData.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(CHARACTERS(GUID), CharacterObject), 0)
            End If
        End If

        Client.Send(packet)
        packet.Dispose()
        UpdateData.Dispose()
    End Function


#End Region


End Module


