Attribute VB_Name = "AccountRoutines"
Option Explicit
Option Base 1

Public Function ACCOUNT_GetGUID(LinkNumber As Long) As tGUID
    Dim i As Long

    For i = 1 To Accounts_LoggedIn.Count
        If Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber = LinkNumber Then
            ACCOUNT_GetGUID = Accounts_LoggedIn.AccountsLoggedIn(i).CurrentCharacterGUID
            Exit Function
        End If
    Next i

End Function

Public Function ACCOUNT_GetLinkNumber(GUID As tGUID) As Long
    Dim i As Long

    For i = 1 To Accounts_LoggedIn.Count
        If CompareGUIDs(Accounts_LoggedIn.AccountsLoggedIn(i).CurrentCharacterGUID, GUID) Then
            ACCOUNT_GetLinkNumber = Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber
            Exit Function
        End If
    Next i

    ACCOUNT_GetLinkNumber = -1
End Function

Public Function ACCOUNT_GetPosition(LinkNumber As Long) As Long
    Dim i As Long

    For i = 1 To Accounts_LoggedIn.Count
        If Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber = LinkNumber Then
            ACCOUNT_GetPosition = i
            Exit Function
        End If
    Next i

    ACCOUNT_GetPosition = -1
End Function

Public Function ACCOUNT_GetRecordNumber(LinkNumber As Long) As Long
    Dim i As Long

    For i = 1 To Accounts_LoggedIn.Count
        If Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber = LinkNumber Then
            ACCOUNT_GetRecordNumber = Accounts_LoggedIn.AccountsLoggedIn(i).RecordPosition
            Exit Function
        End If
    Next i

    ACCOUNT_GetRecordNumber = -1
    WORLD_SendResponseCode LinkNumber, 3
End Function

Public Sub ACCOUNT_LogOut(LinkNumber As Long)
    Dim i As Long, tmpLoggedIn As tList_AccountLoggedIn

    For i = 1 To Accounts_LoggedIn.Count
        If Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber = LinkNumber Then
            'do nothing, I guess
        Else
            tmpLoggedIn.Count = tmpLoggedIn.Count + 1
            ReDim Preserve tmpLoggedIn.AccountsLoggedIn(tmpLoggedIn.Count)
            tmpLoggedIn.AccountsLoggedIn(tmpLoggedIn.Count) = Accounts_LoggedIn.AccountsLoggedIn(i)
        End If
    Next i

    Accounts_LoggedIn = tmpLoggedIn
End Sub

Public Sub ACCOUNT_LogIn(AccountNAme As String, LinkNumber As Long)
    Dim i As Long

    For i = 1 To Accounts_LoggedIn.Count
        If Accounts_LoggedIn.AccountsLoggedIn(i).AccountNAme = AccountNAme Then
            Accounts_LoggedIn.AccountsLoggedIn(i).LastCommandTime = Now
            Exit Sub
        End If
    Next i

    Accounts_LoggedIn.Count = Accounts_LoggedIn.Count + 1
    ReDim Preserve Accounts_LoggedIn.AccountsLoggedIn(Accounts_LoggedIn.Count)
    Accounts_LoggedIn.AccountsLoggedIn(Accounts_LoggedIn.Count).AccountNAme = AccountNAme
    Accounts_LoggedIn.AccountsLoggedIn(Accounts_LoggedIn.Count).LinkNumber = LinkNumber
    Accounts_LoggedIn.AccountsLoggedIn(i).LastCommandTime = Now

    For i = 1 To Accounts_Record.Count
        If Accounts_Record.Accounts(i).AccountNAme = AccountNAme Then
            Accounts_LoggedIn.AccountsLoggedIn(Accounts_LoggedIn.Count).RecordPosition = i
            Exit For
        End If
    Next i

End Sub

Public Function ACCOUNT_CheckPassword(AccountNAme As String, Password As String) As enumLoginReturnValues
    Dim i As Long
    Dim AccountNameInDatabase As Boolean, PasswordMatch As Boolean

    AccountNameInDatabase = False
    PasswordMatch = False

    For i = 1 To Accounts_Record.Count
        If Accounts_Record.Accounts(i).AccountNAme = AccountNAme Then
            AccountNameInDatabase = True
            If Accounts_Record.Accounts(i).Password = Password Then
                PasswordMatch = True
                ACCOUNT_CheckPassword = Success
                Exit Function
            End If
            Exit For
        End If
    Next i

    If AccountNameInDatabase = False Then
        Accounts_Record.Count = Accounts_Record.Count + 1
        ReDim Preserve Accounts_Record.Accounts(Accounts_Record.Count)
        Accounts_Record.Accounts(Accounts_Record.Count).AccountNAme = AccountNAme
        Accounts_Record.Accounts(Accounts_Record.Count).Password = Password
        Accounts_Record.Accounts(Accounts_Record.Count).CharactersCount = 0
        ACCOUNT_CheckPassword = AccountCreated
        Exit Function
    End If

    If PasswordMatch = False Then
        ACCOUNT_CheckPassword = WrongPassword
        Exit Function
    End If

End Function

