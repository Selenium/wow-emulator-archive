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

Module ModuleTest


    Sub Main()

        Dim tmp2 As New MPQ.MPQArchive("E:\World Of Warcraft\Data\base.MPQ")
        If tmp2.Files(0) Is Nothing Then

        End If
        Dim tmpDBC As New DBC.BaseDBC(tmp2.OpenFile("DBFilesClient\Spell.dbc"))
        tmp2.Dispose()

        Console.ReadLine()
    End Sub

End Module
