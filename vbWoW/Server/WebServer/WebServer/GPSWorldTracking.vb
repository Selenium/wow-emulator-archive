Namespace WebServer

    Public Class GPSWorldTracking
        Public Sub New()
            '
        End Sub

        Private Sub get_player_position(ByRef x As Single, ByRef y As Single, ByVal m As Integer)
            Dim xpos As Single = Math.Round((x / 1000) * 17.7, 0)
            Dim ypos As Single = Math.Round((y / 1000) * 17.7, 0)
            Select Case (m)
                Case 1
                    x = 162 - ypos
                    y = 311 - xpos
                Case 0
                    x = 580 - ypos
                    y = 227 - xpos
                Case Else
                    x = 580 - ypos
                    y = 227 - xpos
                    '// oO maybe this way round.
            End Select
        End Sub

        Private Function GetRace(ByVal inRace As Integer) As String
            Select Case inRace
                Case 1
                    Return "Human"
                Case 2
                    Return "Orc"
                Case 3
                    Return "Dwarf"
                Case 4
                    Return "Night Elf"
                Case 5
                    Return "Undead"
                Case 6
                    Return "Tauren"
                Case 7
                    Return "Gnome"
                Case 8
                    Return "Troll"
                Case Else
                    Return "Unknowen race."
            End Select
        End Function

        Private Function GetClass(ByVal inClass As Integer) As String
            Select Case inClass
                Case 1
                    Return "Warrior"
                Case 2
                    Return "Paladin"
                Case 3
                    Return "Hunter"
                Case 4
                    Return "Rogue"
                Case 5
                    Return "Priest"
                Case 7
                    Return "Shaman"
                Case 8
                    Return "Mage"
                Case 9
                    Return "Warlock"
                    'Case 10 'What class was this again?
                Case 11
                    Return "Druid"
                Case Else
                    Return "Unknowen Class."
            End Select
        End Function

        Public Sub get_player_pins(ByRef TimeOut As String, ByRef NumberOfOnline As Integer, ByRef outbuf As String)
            Dim i As Integer
            Dim TimeIn As Date = Now
            Dim sName As String
            Dim sRace As Integer
            Dim sClass As Integer
            Dim sLevel As Integer
            Dim sX As Single
            Dim sY As Single
            Dim sPoint As String = ""
            Dim sLeft As String
            Dim sTopp As String
            Dim Result As New DataTable
            '                                                           0 = offline
            If SQL.QuerySQL("SELECT * FROM adb_characters WHERE char_online = 0;") Then
                Result = SQL.GetDataTableSQL()

                For i = 0 To (Result.Rows.Count - 1)
                    sName = Result.Rows(i).Item("char_name")
                    sRace = Result.Rows(i).Item("char_race")
                    sClass = Result.Rows(i).Item("char_class")
                    sLevel = Result.Rows(i).Item("char_level")
                    sX = Result.Rows(i).Item("char_positionX")
                    sY = Result.Rows(i).Item("char_positionY")
                    get_player_position(sX, sY, Result.Rows(i).Item("char_map_id"))

                    Select Case sRace
                        Case 2, 5, 6, 8
                            If sLevel > 30 Then
                                sPoint = "images\gpstracking\pins\hordea.gif"
                            Else
                                sPoint = "images\gpstracking\pins\horde.gif"
                            End If
                        Case Else
                            If sLevel > 30 Then
                                sPoint = "images\gpstracking\pins\pointa.gif"
                            Else
                                sPoint = "images\gpstracking\pins\point.gif"
                            End If
                    End Select

                    sLeft = sX.ToString + "px"
                    sTopp = sY.ToString + "px"
                    outbuf += "<img src=""" + sPoint + """" + " style=""position: absolute; border: 0px; left: " + sLeft + "; top: " + sTopp + """ onmouseover=""this.T_TITLE='" + sName + "';return escape('<img src=\'images/gpstracking/class/" + sClass.ToString + ".gif\' style=\'float:right\' border=\'0\'><img src=\'images/gpstracking/race/" + sRace.ToString + ".gif\' style=\'float:right\' border=\'0\'>Race: " + GetRace(sRace) + "<br\>Class: " + GetClass(sClass) + "<br\>Level: " + sLevel.ToString + "')""> " + vbCrLf
                    'THE EXACT WORKING LINE FOR THE TOOLTIP SCRIPT
                    '<img src="images\gpstracking\pins\pointa.gif" style="position: absolute; border: 0px; left: 574.5px; top: 405.2px" onmouseover="this.T_TITLE='Dragon';return escape('<img src=\'images/gpstracking/class/1.gif\' style=\'float:right\' border=\'0\'><img src=\'images/gpstracking/race/1.gif\' style=\'float:right\' border=\'0\'>Race: Human<br\>Class: Warrior<br\>Level: 255')">
                    NumberOfOnline += 1
                Next
                TimeOut = ((Now - TimeIn).Seconds).ToString + "." + ((Now - TimeIn).Milliseconds).ToString
                'Debug.Print(outbuf)
            End If
        End Sub

    End Class

End Namespace