' Talent database initialization script.
'
'Last  update: 08.03.2007
'Version support: 2.0.8



Imports System
Imports Microsoft.VisualBasic
Imports vbWoW.Filebase
Imports vbWoW.Logbase.BaseWriter
Imports vbWoW.WorldServer

Namespace Scripts
    Public Module Initializators

        Public Sub Initialize()
            LoadTalentDBC()
            LoadTalentTabDBC()
        End Sub

        Public Sub LoadTalentDBC()
            Dim DBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\Talent.dbc")
            'Log.WriteLine(LogType.DEBUG, DBC.GetFileInformation)

            Dim tmpInfo As TalentInfo

            Dim i As Integer = 0
            For i = 0 To DBC.Rows - 1
                tmpInfo = New TalentInfo

                tmpInfo.TalentID = DBC.Item(i, 0)
                tmpInfo.TalentTab = DBC.Item(i, 1)
                tmpInfo.Row = DBC.Item(i, 2)
                tmpInfo.Col = DBC.Item(i, 3)
                tmpInfo.RankID(0) = DBC.Item(i, 4)
                tmpInfo.RankID(1) = DBC.Item(i, 5)
                tmpInfo.RankID(2) = DBC.Item(i, 6)
                tmpInfo.RankID(3) = DBC.Item(i, 7)
                tmpInfo.RankID(4) = DBC.Item(i, 8)

                tmpInfo.RequiredTalent(0) = DBC.Item(i, 13)
                tmpInfo.RequiredTalent(1) = DBC.Item(i, 14)
                tmpInfo.RequiredTalent(2) = DBC.Item(i, 15)
                tmpInfo.RequiredPoints(0) = DBC.Item(i, 16)
                tmpInfo.RequiredPoints(1) = DBC.Item(i, 17)
                tmpInfo.RequiredPoints(2) = DBC.Item(i, 18)

                Talents.Add(tmpInfo.TalentID, tmpInfo)
            Next i

            DBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} Talents initialized.", i)
        End Sub

        Public Sub LoadTalentTabDBC()
            Dim DBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\TalentTab.dbc")
            'Log.WriteLine(LogType.DEBUG, DBC.GetFileInformation)

            Dim TalentTab As Integer
            Dim TalentMask As Integer

            Dim i As Integer = 0
            For i = 0 To DBC.Rows - 1
                TalentTab = DBC.Item(i, 0)
                TalentMask = DBC.Item(i, 12)

                TalentsTab.Add(TalentTab, TalentMask)
            Next i

            DBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} Talent tabs initialized.", i)
        End Sub

    End Module
End namespace