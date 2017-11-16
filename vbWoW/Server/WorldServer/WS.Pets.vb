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

Public Module WS_Pets




#Region "WS.Pets.TypeDef"

    Public Const CREATURE_MAX_SPELLS = 4

    Public Class PetObject
        Inherits CreatureObject

        Public Command As Byte = 7
        Public State As Byte = 6
        Public Spells As ArrayList

        Public Sub New(ByVal CreatureID As Integer)
            MyBase.New(CreatureID)
        End Sub

    End Class

    Public Sub SendPetInitialize(ByRef c As CharacterObject, ByVal GUID As Long)
        Dim packet As New PacketClass(OPCODES.SMSG_PET_SPELLS)
        packet.AddInt64(GUID)
        packet.AddInt32(0)
        packet.AddInt32(&H1110000)

        packet.AddInt32(2 + 7 << 24)
        packet.AddInt32(1 + 7 << 24)
        packet.AddInt32(0 + 7 << 24)
        For i As Integer = 1 To 4
            packet.AddInt32(0)
        Next

        packet.AddInt32(2 + 6 << 24)
        packet.AddInt32(1 + 6 << 24)
        packet.AddInt32(0 + 6 << 24)

        packet.AddInt8(0)
        packet.AddInt8(1)
        packet.AddInt32(&H6010)
        packet.AddInt32(0)
        packet.AddInt32(0)
        packet.AddInt16(0)

        c.Client.Send(packet)
        packet.Dispose()
    End Sub

#End Region
#Region "WS.Pets.Handlers"

#End Region




End Module

