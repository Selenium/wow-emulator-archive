' Custom ingame commands.
'
'Last  update: 08.03.2007


Imports System
Imports Microsoft.VisualBasic
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands

		<ChatCommandAttribute("Sample", "This is sample scripted command.")> _
		Public Function SampleCommand(ByRef c As CharacterObject, ByVal Message As String) as Boolean
			c.CommandResponse("Sample Scripted Command executed.")

			return True				'Returning False will trigger displaying the help info about this command on client-side
		End Function

        'TODO: Implement these commands

        'Public Function BanCharacter(ByVal Name As String, ByRef Client As ClientClass) As Boolean
        '    charactersLock_.AcquireReaderLock(Timeout.Infinite)
        '    For Each Character As DictionaryEntry In CHARACTERs
        '        If UCase(CType(Character.Value, CharacterObject).Name) = Name Then
        '            charactersLock_.ReleaseReaderLock()
        '            Database.Update("UPDATE adb_accounts SET banned = 1 WHERE account = """ & CType(Character.Value, CharacterObject).Client.Account & """;")
        '            Client.Character.CommandResponse(String.Format("Account [{0}] banned.", CType(Character.Value, CharacterObject).Client.Account))
        '            Console.WriteLine("[{0}] Account [{4}] banned by [{3}].", Format(TimeOfDay, "hh:mm:ss"), Client.IP.ToString, Client.Port, Client.Character.Name, CType(Character.Value, CharacterObject).Client.Account)
        '            Exit Function
        '        End If
        '    Next

        '    charactersLock_.ReleaseReaderLock()
        '    Client.Character.CommandResponse(String.Format("Character [{0}] not found.", Name))
        'End Function
        'Public Function BanCharacter(ByVal GUID As Long, ByRef Client As ClientClass) As Boolean
        '    charactersLock_.AcquireReaderLock(Timeout.Infinite)
        '    If CHARACTERs.ContainsKey(GUID) Then
        '        charactersLock_.ReleaseReaderLock()
        '        Database.Update("UPDATE adb_accounts SET banned = 1 WHERE account = """ & CHARACTERs(GUID).Client.Account & """;")
        '        Client.Character.CommandResponse(String.Format("Account [{0}] banned.", CHARACTERs(GUID).Client.Account))
        '        Console.WriteLine("[{0}] Account [{4}] banned by [{3}].", Format(TimeOfDay, "hh:mm:ss"), Client.IP.ToString, Client.Port, Client.Character.Name, CHARACTERs(GUID).Client.Account)
        '    Else
        '        charactersLock_.ReleaseReaderLock()
        '        Client.Character.CommandResponse(String.Format("Character GUID=[{0}] not found.", GUID))
        '    End If
        'End Function
        'Public Function LearnSkill(ByVal SkillInfo As String, ByVal CharacterGUID As Long, ByRef GM As ClientClass) As Boolean

        '    Try
        '        If Not CHARACTERs.ContainsKey(CharacterGUID) Then Throw New ApplicationException("Character with GUID=" & CharacterGUID & " not found!")

        '        Dim tmp() As String
        '        tmp = Split(Trim(SkillInfo), " ")

        '        Dim SkillID As Integer = tmp(0)
        '        Dim Current As Int16 = tmp(1)
        '        Dim Maximum As Int16 = tmp(2)

        '        If CHARACTERs(CharacterGUID).Skills.ContainsKey(SkillID) Then
        '            CType(CHARACTERs(CharacterGUID).Skills(SkillID), TSkill).Maximum = Maximum
        '            CType(CHARACTERs(CharacterGUID).Skills(SkillID), TSkill).Current = Current
        '            GM.Character.CommandResponse(String.Format("Character {0} updated skill ", CHARACTERs(CharacterGUID).Name, SkillID))
        '        Else
        '            CHARACTERs(CharacterGUID).LearnSkill(SkillID, Current, Maximum)
        '            GM.Character.CommandResponse(String.Format("Character {0} learned skill ", CHARACTERs(CharacterGUID).Name, SkillID))
        '        End If

        '        CHARACTERs(CharacterGUID).FillAllUpdateFlags()
        '        CHARACTERs(CharacterGUID).SendUpdate()
        '    Catch e As ApplicationException
        '        GM.Character.CommandResponse(e.ToString)
        '    Catch
        '        GM.Character.CommandResponse("Error in command's parameters:" & vbNewLine & "LEARNSKILL <SkillID> <Current> <Maximum>")
        '    End Try
        'End Function

	End Module
End namespace