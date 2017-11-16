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

Imports System.IO
Imports vbWoW.Logbase.BaseWriter

Public Module Packets


    Public Sub DumpPacket(ByVal data() As Byte, Optional ByRef Client As ClientClass = Nothing)
        '#If DEBUG Then
        Dim j As Integer
        Dim buffer As String = ""
        If Client Is Nothing Then
            buffer = buffer + [String].Format("DEBUG: Packet Dump{0}", vbNewLine)
        Else
            buffer = buffer + [String].Format("[{0}:{1}] DEBUG: Packet Dump{2}", Client.IP, Client.Port, vbNewLine)
        End If




        If data.Length Mod 16 = 0 Then
            For j = 0 To data.Length - 1 Step 16
                buffer += "|  " & BitConverter.ToString(data, j, 16).Replace("-", " ")
                buffer += " |  " & System.Text.Encoding.ASCII.GetString(data, j, 16).Replace(vbTab, "?").Replace(vbBack, "?").Replace(vbCr, "?").Replace(vbFormFeed, "?").Replace(vbLf, "?") & " |" & vbNewLine
            Next
        Else
            For j = 0 To data.Length - 1 - 16 Step 16
                buffer += "|  " & BitConverter.ToString(data, j, 16).Replace("-", " ")
                buffer += " |  " & System.Text.Encoding.ASCII.GetString(data, j, 16).Replace(vbTab, "?").Replace(vbBack, "?").Replace(vbCr, "?").Replace(vbFormFeed, "?").Replace(vbLf, "?") & " |" & vbNewLine
            Next

            buffer += "|  " & BitConverter.ToString(data, j, data.Length Mod 16).Replace("-", " ")
            buffer += New String(" ", (16 - data.Length Mod 16) * 3)
            buffer += " |  " & System.Text.Encoding.ASCII.GetString(data, j, data.Length Mod 16).Replace(vbTab, "?").Replace(vbBack, "?").Replace(vbCr, "?").Replace(vbFormFeed, "?").Replace(vbLf, "?")
            buffer += New String(" ", 16 - data.Length Mod 16)
            buffer += " |" & vbNewLine
        End If

        Log.WriteLine(LogType.DEBUG, buffer)
        '#End If
    End Sub
    Public Class UpdateClass
        Implements IDisposable

        'Dim packet As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
        'packet.AddInt32(OPERATIONS_COUNT)
        'packet.AddInt8(0)

        Public UpdateMask As BitArray
        Public UpdateData As New Hashtable
        Public Sub New(Optional ByVal Max As Integer = FIELD_MASK_SIZE_PLAYER)
            UpdateMask = New BitArray(Max, False)
        End Sub

        Public Sub SetUpdateFlag(ByVal pos As Integer, ByVal value As Integer)
            UpdateMask.Set(pos, True)
            UpdateData(pos) = (CType(value, Integer))
        End Sub
        Public Sub SetUpdateFlag(ByVal pos As Integer, ByVal value As Long)
            UpdateMask.Set(pos, True)
            UpdateMask.Set(pos + 1, True)
            UpdateData(pos) = (CType((value And 4294967295), Integer))
            UpdateData(pos + 1) = (CType(((value >> 32) And 4294967295), Integer))
        End Sub
        Public Sub SetUpdateFlag(ByVal pos As Integer, ByVal value As Single)
            UpdateMask.Set(pos, True)
            Dim buffer As Byte() = BitConverter.GetBytes(value)
            Dim value_converted As Integer = BitConverter.ToInt32(buffer, 0)
            UpdateData(pos) = (CType(value_converted, Integer))
        End Sub

        'NOTE: CharacterObject.PrepareUpdate
        Public Sub AddToPacket(ByRef packet As PacketClass, ByVal updateType As ObjectUpdateType, ByRef updateObject As CreatureObject, Optional ByVal IsClientObject As Byte = 0)
            packet.AddInt8(updateType)
            packet.AddPackGUID(updateObject.GUID)

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Then
                packet.AddInt8(ObjectTypeID.TYPEID_UNIT)
            End If

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_MOVEMENT Then
                packet.AddInt8(&H78)
                packet.AddInt32(0)  'flags2
                packet.AddInt32(0)
                packet.AddSingle(updateObject.positionX)
                packet.AddSingle(updateObject.positionY)
                packet.AddSingle(updateObject.positionZ)
                packet.AddSingle(updateObject.orientation)
                packet.AddSingle(0)

                packet.AddSingle(CREATURESDatabase(updateObject.ID).WalkSpeed)
                packet.AddSingle(CREATURESDatabase(updateObject.ID).RunSpeed)
                packet.AddSingle(UNIT_NORMAL_SWIM_BACK_SPEED)
                packet.AddSingle(UNIT_NORMAL_SWIM_SPEED)
                packet.AddSingle(UNIT_NORMAL_WALK_BACK_SPEED)
                packet.AddSingle(UNIT_NORMAL_FLY_SPEED)
                packet.AddSingle(UNIT_NORMAL_FLY_BACK_SPEED)
                packet.AddSingle(UNIT_NORMAL_TURN_RATE)

                packet.AddInt64(updateObject.GUID)
            End If

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_VALUES Then
                Dim UpdateCount As Integer = 0
                Dim i As Integer
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then UpdateCount = i
                Next

                packet.AddInt8(CType((UpdateCount + 32) \ 32, Byte))
                packet.AddBitArray(UpdateMask, CType((UpdateCount + 32) \ 32, Byte) * 4)      'OK Flags are Int32, so to byte -> *4
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then packet.AddInt32(UpdateData(i))
                Next

                UpdateData.Clear()
                UpdateMask.SetAll(False)
            End If

            If TypeOf packet Is UpdatePacketClass Then CType(packet, UpdatePacketClass).UpdatesCount += 1
        End Sub
        Public Sub AddToPacket(ByRef packet As PacketClass, ByVal updateType As ObjectUpdateType, ByRef updateObject As CharacterObject, Optional ByVal IsClientObject As Byte = 0)
            packet.AddInt8(updateType)
            packet.AddPackGUID(updateObject.GUID)

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT_SELF Then
                packet.AddInt8(ObjectTypeID.TYPEID_PLAYER)
            End If

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT_SELF Or updateType = ObjectUpdateType.UPDATETYPE_MOVEMENT Then
                If IsClientObject = 1 Then
                    packet.AddInt8(&H61)
                    packet.AddInt32(&H2000)     'flags2
                Else
                    packet.AddInt8(&H60)
                    packet.AddInt32(&H0)        'flags2
                End If
                packet.AddInt32(0)
                packet.AddSingle(updateObject.positionX)
                packet.AddSingle(updateObject.positionY)
                packet.AddSingle(updateObject.positionZ)
                packet.AddSingle(updateObject.orientation)
                packet.AddSingle(0)

                If IsClientObject = 1 Then
                    packet.AddSingle(0)
                    packet.AddSingle(1)
                    packet.AddSingle(0)
                    packet.AddSingle(0)
                End If

                packet.AddSingle(updateObject.WalkSpeed)
                packet.AddSingle(updateObject.RunSpeed)
                packet.AddSingle(updateObject.SwimBackSpeed)
                packet.AddSingle(updateObject.SwimSpeed)
                packet.AddSingle(updateObject.RunBackSpeed)
                packet.AddSingle(updateObject.FlySpeed)
                packet.AddSingle(updateObject.FlyBackSpeed)
                packet.AddSingle(updateObject.TurnRate)

                'packet.AddInt64(updateObject.GUID)
            End If

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_VALUES Or updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT_SELF Then
                Dim UpdateCount As Integer = 0
                Dim i As Integer
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then UpdateCount = i
                Next

                packet.AddInt8(CType((UpdateCount + 32) \ 32, Byte))
                packet.AddBitArray(UpdateMask, CType((UpdateCount + 32) \ 32, Byte) * 4)      'OK Flags are Int32, so to byte -> *4
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then packet.AddInt32(UpdateData(i))
                Next
            End If

            If TypeOf packet Is UpdatePacketClass Then CType(packet, UpdatePacketClass).UpdatesCount += 1
        End Sub
        Public Sub AddToPacket(ByRef packet As PacketClass, ByVal updateType As ObjectUpdateType, ByRef updateObject As ItemObject, Optional ByVal IsClientObject As Byte = 0)
            packet.AddInt8(updateType)
            packet.AddPackGUID(updateObject.GUID)

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Then
                If CType(ITEMDatabase(updateObject.ItemEntry), ItemInfo).ContainerSlots > 0 Then
                    packet.AddInt8(ObjectTypeID.TYPEID_CONTAINER)
                Else
                    packet.AddInt8(ObjectTypeID.TYPEID_ITEM)
                End If
                packet.AddInt8(&H18)
                packet.AddInt64(updateObject.GUID)
            End If

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_VALUES Then
                Dim UpdateCount As Integer = 0
                Dim i As Integer
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then UpdateCount = i
                Next

                packet.AddInt8(CType((UpdateCount + 32) \ 32, Byte))
                packet.AddBitArray(UpdateMask, CType((UpdateCount + 32) \ 32, Byte) * 4)      'OK Flags are Int32, so to byte -> *4
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then packet.AddInt32(UpdateData(i))
                Next
            End If

            If TypeOf packet Is UpdatePacketClass Then CType(packet, UpdatePacketClass).UpdatesCount += 1
        End Sub
        Public Sub AddToPacket(ByRef packet As PacketClass, ByVal updateType As ObjectUpdateType, ByRef updateObject As GameObjectObject, Optional ByVal IsClientObject As Byte = 0)
            packet.AddInt8(updateType)
            packet.AddPackGUID(updateObject.GUID)

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Then
                packet.AddInt8(ObjectTypeID.TYPEID_GAMEOBJECT)

                packet.AddInt8(&H58)
                packet.AddSingle(updateObject.positionX)
                packet.AddSingle(updateObject.positionY)
                packet.AddSingle(updateObject.positionZ)
                packet.AddSingle(updateObject.orientation)
                packet.AddInt64(updateObject.GUID)
            End If

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_VALUES Then
                Dim UpdateCount As Integer = 0
                Dim i As Integer
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then UpdateCount = i
                Next

                packet.AddInt8(CType((UpdateCount + 32) \ 32, Byte))
                packet.AddBitArray(UpdateMask, CType((UpdateCount + 32) \ 32, Byte) * 4)      'OK Flags are Int32, so to byte -> *4
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then packet.AddInt32(UpdateData(i))
                Next
            End If

            If TypeOf packet Is UpdatePacketClass Then CType(packet, UpdatePacketClass).UpdatesCount += 1
        End Sub
        Public Sub AddToPacket(ByRef packet As PacketClass, ByVal updateType As ObjectUpdateType, ByRef updateObject As CorpseObject, Optional ByVal IsClientObject As Byte = 0)
            packet.AddInt8(updateType)
            packet.AddPackGUID(updateObject.GUID)

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Then
                packet.AddInt8(ObjectTypeID.TYPEID_CORPSE)

                packet.AddInt8(&H5A)
                packet.AddSingle(updateObject.positionX)
                packet.AddSingle(updateObject.positionY)
                packet.AddSingle(updateObject.positionZ)
                packet.AddSingle(updateObject.orientation)
                packet.AddInt64(updateObject.GUID)
                packet.AddInt32(1)
            End If

            If updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT Or updateType = ObjectUpdateType.UPDATETYPE_VALUES Then
                Dim UpdateCount As Integer = 0
                Dim i As Integer
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then UpdateCount = i
                Next

                packet.AddInt8(CType((UpdateCount + 32) \ 32, Byte))
                packet.AddBitArray(UpdateMask, CType((UpdateCount + 32) \ 32, Byte) * 4)      'OK Flags are Int32, so to byte -> *4
                For i = 0 To UpdateMask.Count - 1
                    If UpdateMask.Get(i) Then packet.AddInt32(UpdateData(i))
                Next
            End If

            If TypeOf packet Is UpdatePacketClass Then CType(packet, UpdatePacketClass).UpdatesCount += 1
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
        End Sub
    End Class

#Region "Packets.ArrayBased"


    Public Class PacketClass
        Implements IDisposable

        Public Data() As Byte
        Public Offset As Integer = 4

        Public ReadOnly Property Length() As Integer
            Get
                Return (Data(1) + (Data(0) * 256))
            End Get
        End Property
        Public ReadOnly Property OpCode() As OPCODES
            Get
                Return (Data(2) + (Data(3) * 256))
            End Get
        End Property

        Public Sub New(ByVal opcode As OPCODES)
            ReDim Preserve Data(3)
            Data(0) = 0
            Data(1) = 2
            Data(2) = CType(opcode, Int16) Mod 256
            Data(3) = CType(opcode, Int16) \ 256
        End Sub
        Public Sub New(ByRef rawdata() As Byte)
            Data = rawdata
            rawdata.CopyTo(Data, 0)
        End Sub


        Public Sub AddBitArray(ByVal buffer As BitArray, ByVal Len As Integer)
            ReDim Preserve Data(Data.Length - 1 + Len)
            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256

            Dim bufferarray(CType((buffer.Length + 8) / 8, Byte)) As Byte

            buffer.CopyTo(bufferarray, 0)
            Array.Copy(bufferarray, 0, Data, Data.Length - Len, Len)
        End Sub
        Public Sub AddInt8(ByVal buffer As Byte)
            ReDim Preserve Data(Data.Length)
            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256
            Data(Data.Length - 1) = buffer
        End Sub
        Public Sub AddInt16(ByVal buffer As Short)
            ReDim Preserve Data(Data.Length + 1)
            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256

            'Data(Data.Length - 2) = buffer Mod 256
            'Data(Data.Length - 1) = buffer \ 256

            Data(Data.Length - 2) = CType((buffer And 255), Byte)
            Data(Data.Length - 1) = CType(((buffer >> 8) And 255), Byte)
        End Sub
        Public Sub AddInt32(ByVal buffer As Integer)
            ReDim Preserve Data(Data.Length + 3)
            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256

            'Data(Data.Length - 4) = buffer Mod 256
            'Data(Data.Length - 3) = (buffer \ 256) Mod 256
            'Data(Data.Length - 2) = ((buffer \ 256) \ 256) Mod 256
            'Data(Data.Length - 1) = ((buffer \ 256) \ 256) \ 256

            Data(Data.Length - 4) = CType((buffer And 255), Byte)
            Data(Data.Length - 3) = CType(((buffer >> 8) And 255), Byte)
            Data(Data.Length - 2) = CType(((buffer >> 16) And 255), Byte)
            Data(Data.Length - 1) = CType(((buffer >> 24) And 255), Byte)
        End Sub
        Public Sub AddInt64(ByVal buffer As Long)
            ReDim Preserve Data(Data.Length + 7)
            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256

            Data(Data.Length - 8) = CType((buffer And 255), Byte)
            Data(Data.Length - 7) = CType(((buffer >> 8) And 255), Byte)
            Data(Data.Length - 6) = CType(((buffer >> 16) And 255), Byte)
            Data(Data.Length - 5) = CType(((buffer >> 24) And 255), Byte)
            Data(Data.Length - 4) = CType(((buffer >> 32) And 255), Byte)
            Data(Data.Length - 3) = CType(((buffer >> 40) And 255), Byte)
            Data(Data.Length - 2) = CType(((buffer >> 48) And 255), Byte)
            Data(Data.Length - 1) = CType(((buffer >> 56) And 255), Byte)
        End Sub
        Public Sub AddString(ByVal buffer As String)
            Dim Bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(buffer.ToCharArray)

            ReDim Preserve Data(Data.Length + Bytes.Length)
            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256

            Dim i As Integer
            For i = 0 To Bytes.Length - 1
                Data(Data.Length - 1 - Bytes.Length + i) = Bytes(i)
            Next i

            Data(Data.Length - 1) = 0
        End Sub
        Public Sub AddDouble(ByVal buffer2 As Double)
            Dim buffer1 As Byte() = BitConverter.GetBytes(buffer2)
            ReDim Preserve Data(Data.Length + buffer1.Length - 1)
            Buffer.BlockCopy(buffer1, 0, Data, Data.Length - buffer1.Length, buffer1.Length)

            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256
        End Sub
        Public Sub AddSingle(ByVal buffer2 As Single)
            Dim buffer1 As Byte() = BitConverter.GetBytes(buffer2)
            ReDim Preserve Data(Data.Length + buffer1.Length - 1)
            Buffer.BlockCopy(buffer1, 0, Data, Data.Length - buffer1.Length, buffer1.Length)

            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256
        End Sub
        Public Sub AddByteArray(ByVal buffer() As Byte)
            Dim tmp As Integer = Data.Length
            ReDim Preserve Data(Data.Length + buffer.Length - 1)
            Array.Copy(buffer, 0, Data, tmp, buffer.Length)

            Data(0) = (Data.Length - 2) \ 256
            Data(1) = (Data.Length - 2) Mod 256
        End Sub
        Public Sub AddPackGUID(ByVal buffer As Long)
            'Me.AddInt8(&HFF)
            'Me.AddInt64(GUID)

            Dim GUID() As Byte = BitConverter.GetBytes(buffer)
            Dim flags As New BitArray(8)
            Dim offsetStart As Integer = Data.Length
            Dim offsetNewSize As Integer = offsetStart

            flags(0) = (GUID(0) <> 0)
            flags(1) = (GUID(1) <> 0)
            flags(2) = (GUID(2) <> 0)
            flags(3) = (GUID(3) <> 0)
            flags(4) = (GUID(4) <> 0)
            flags(5) = (GUID(5) <> 0)
            flags(6) = (GUID(6) <> 0)
            flags(7) = (GUID(7) <> 0)

            If flags(0) Then offsetNewSize += 1
            If flags(1) Then offsetNewSize += 1
            If flags(2) Then offsetNewSize += 1
            If flags(3) Then offsetNewSize += 1
            If flags(4) Then offsetNewSize += 1
            If flags(5) Then offsetNewSize += 1
            If flags(6) Then offsetNewSize += 1
            If flags(7) Then offsetNewSize += 1
            ReDim Preserve Data(offsetNewSize)



            flags.CopyTo(Data, offsetStart)
            offsetStart += 1

            If flags(0) Then
                Data(offsetStart) = GUID(0)
                offsetStart += 1
            End If
            If flags(1) Then
                Data(offsetStart) = GUID(1)
                offsetStart += 1
            End If
            If flags(2) Then
                Data(offsetStart) = GUID(2)
                offsetStart += 1
            End If
            If flags(3) Then
                Data(offsetStart) = GUID(3)
                offsetStart += 1
            End If
            If flags(4) Then
                Data(offsetStart) = GUID(4)
                offsetStart += 1
            End If
            If flags(5) Then
                Data(offsetStart) = GUID(5)
                offsetStart += 1
            End If
            If flags(6) Then
                Data(offsetStart) = GUID(6)
                offsetStart += 1
            End If
            If flags(7) Then
                Data(offsetStart) = GUID(7)
                offsetStart += 1
            End If

        End Sub


        Public Function GetInt8() As Byte
            Offset = Offset + 1
            Return Data(Offset - 1)
        End Function
        Public Function GetInt8(ByVal Offset As Integer) As Byte
            Offset = Offset + 1
            Return Data(Offset - 1)
        End Function
        Public Function GetInt16() As Short
            Dim num1 As Short = BitConverter.ToInt16(Data, Offset)
            Offset = (Offset + 2)
            Return num1
        End Function
        Public Function GetInt16(ByVal Offset As Integer) As Short
            Dim num1 As Short = BitConverter.ToInt16(Data, Offset)
            Offset = (Offset + 2)
            Return num1
        End Function
        Public Function GetInt32() As Integer
            Dim num1 As Integer = BitConverter.ToInt32(Data, Offset)
            Offset = (Offset + 4)
            Return num1
        End Function
        Public Function GetInt32(ByVal Offset As Integer) As Integer
            Dim num1 As Integer = BitConverter.ToInt32(Data, Offset)
            Offset = (Offset + 4)
            Return num1
        End Function
        Public Function GetInt64() As Long
            Dim num1 As Long = BitConverter.ToInt64(Data, Offset)
            Offset = (Offset + 8)
            Return num1
        End Function
        Public Function GetInt64(ByVal Offset As Integer) As Long
            Dim num1 As Long = BitConverter.ToInt64(Data, Offset)
            Offset = (Offset + 8)
            Return num1
        End Function
        Public Function GetFloat() As Single
            Dim single1 As Single = BitConverter.ToSingle(Data, Offset)
            Offset = (Offset + 4)
            Return single1
        End Function
        Public Function GetFloat(ByVal Offset As Integer) As Single
            Dim single1 As Single = BitConverter.ToSingle(Data, Offset)
            Offset = (Offset + 4)
            Return single1
        End Function
        Public Function GetDouble() As Double
            Dim num1 As Double = BitConverter.ToDouble(Data, Offset)
            Offset = (Offset + 8)
            Return num1
        End Function
        Public Function GetDouble(ByVal Offset As Integer) As Double
            Dim num1 As Double = BitConverter.ToDouble(Data, Offset)
            Offset = (Offset + 8)
            Return num1
        End Function
        Public Function GetString() As String
            Dim start As Integer = Offset
            Dim i As Integer = 0

            While Data(start + i) <> 0
                i = i + 1
                Offset = Offset + 1
            End While
            Offset = Offset + 1

            Return System.Text.Encoding.UTF8.GetString(Data, start, i)
        End Function
        Public Function GetString(ByVal Offset As Integer) As String
            Dim i As Integer = Offset
            Dim tmpString As String = ""
            While Data(i) <> 0
                tmpString = tmpString + Chr(Data(i))
                i = i + 1
                Offset = Offset + 1
            End While
            Offset = Offset + 1
            Return tmpString
        End Function
        Public Function GetPackGUID() As Long
            Dim flags As Byte = Data(Offset)
            Dim GUID() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}
            Offset += 1

            If (flags And 1) = 1 Then
                GUID(0) = Data(Offset)
                Offset += 1
            End If
            If (flags And 2) = 2 Then
                GUID(1) = Data(Offset)
                Offset += 1
            End If
            If (flags And 4) = 4 Then
                GUID(2) = Data(Offset)
                Offset += 1
            End If
            If (flags And 8) = 8 Then
                GUID(3) = Data(Offset)
                Offset += 1
            End If
            If (flags And 16) = 16 Then
                GUID(4) = Data(Offset)
                Offset += 1
            End If
            If (flags And 32) = 32 Then
                GUID(5) = Data(Offset)
                Offset += 1
            End If
            If (flags And 64) = 64 Then
                GUID(6) = Data(Offset)
                Offset += 1
            End If
            If (flags And 128) = 128 Then
                GUID(7) = Data(Offset)
                Offset += 1
            End If

            Return CType(BitConverter.ToInt64(GUID, 0), Long)
        End Function
        Public Function GetPackGUID(ByVal Offset As Integer) As Long
            Dim flags As Byte = Data(Offset)
            Dim GUID() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}
            Offset += 1

            If (flags And 1) = 1 Then
                GUID(0) = Data(Offset)
                Offset += 1
            End If
            If (flags And 2) = 2 Then
                GUID(1) = Data(Offset)
                Offset += 1
            End If
            If (flags And 4) = 4 Then
                GUID(2) = Data(Offset)
                Offset += 1
            End If
            If (flags And 8) = 8 Then
                GUID(3) = Data(Offset)
                Offset += 1
            End If
            If (flags And 16) = 16 Then
                GUID(4) = Data(Offset)
                Offset += 1
            End If
            If (flags And 32) = 32 Then
                GUID(5) = Data(Offset)
                Offset += 1
            End If
            If (flags And 64) = 64 Then
                GUID(6) = Data(Offset)
                Offset += 1
            End If
            If (flags And 128) = 128 Then
                GUID(7) = Data(Offset)
                Offset += 1
            End If

            Return CType(BitConverter.ToInt64(GUID, 0), Long)
        End Function


        Public Sub Dispose() Implements System.IDisposable.Dispose
        End Sub
    End Class
    Public Class UpdatePacketClass
        Inherits PacketClass

        Public Property UpdatesCount() As Integer
            Get
                Return BitConverter.ToInt32(Data, 4)
            End Get
            Set(ByVal Value As Integer)
                Data(4) = CType((Value And 255), Byte)
                Data(5) = CType(((Value >> 8) And 255), Byte)
                Data(6) = CType(((Value >> 16) And 255), Byte)
                Data(7) = CType(((Value >> 24) And 255), Byte)
            End Set
        End Property
        Public Sub New()
            MyBase.New(OPCODES.SMSG_UPDATE_OBJECT)

            Me.AddInt32(0)
            Me.AddInt8(0)
        End Sub

        Public Sub Compress()
        End Sub
    End Class


#End Region
#Region "Packets.MemoryStreamBased"


    Public Class PacketClassNew
        Implements IDisposable

        Public Offset As Integer = 4
        Public Length As Integer = 0
        Public ms As MemoryStream
        Public bw As BinaryWriter
        Public br As BinaryReader

        Public ReadOnly Property OpCode() As OPCODES
            Get
                ms.Seek(2, SeekOrigin.Begin)
                Return br.ReadUInt16.ToString
            End Get
        End Property
        Public Property Data() As Byte()
            Get
                Return ms.ToArray
            End Get
            Set(ByVal Value As Byte())
                ms.Close()
                br.Close()
                bw.Close()
                ms = New MemoryStream(Value.Length)
                bw = New BinaryWriter(ms, System.Text.Encoding.UTF8)
                br = New BinaryReader(ms, System.Text.Encoding.UTF8)
                Length = Value.Length - 2
                bw.Write(Value)
            End Set
        End Property

        Public Sub New(ByVal opcode As OPCODES)
            ms = New MemoryStream(12)
            bw = New BinaryWriter(ms, System.Text.Encoding.UTF8)
            br = New BinaryReader(ms, System.Text.Encoding.UTF8)

            Length = 2
            bw.Write(CType(Length, Int16))
            bw.Write(CType(opcode, Int16))
        End Sub
        Public Sub New(ByRef rawms() As Byte)
            ms = New MemoryStream(12)
            bw = New BinaryWriter(ms, System.Text.Encoding.UTF8)
            br = New BinaryReader(ms, System.Text.Encoding.UTF8)

            bw.Write(rawms)

            ms.Seek(0, SeekOrigin.Begin)
            Length = br.ReadInt16

            ms.Seek(Offset, SeekOrigin.Begin)
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            bw.Close()
            br.Close()
            ms.Close()
        End Sub

        Public Sub AddBitArray(ByVal buffer As BitArray, ByVal Len As Integer)
            Dim bufferarray(CType((buffer.Length + 8) / 8, Byte)) As Byte
            buffer.CopyTo(bufferarray, 0)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(bufferarray, 0, Len)

            ms.Seek(0, SeekOrigin.Begin)
            Length += Len
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddInt8(ByVal buffer As Byte)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(buffer)

            ms.Seek(0, SeekOrigin.Begin)
            Length += 1
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddInt16(ByVal buffer As Short)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(buffer)

            ms.Seek(0, SeekOrigin.Begin)
            Length += 2
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddInt32(ByVal buffer As Integer)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(buffer)

            ms.Seek(0, SeekOrigin.Begin)
            Length += 4
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddInt64(ByVal buffer As Long)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(buffer)

            ms.Seek(0, SeekOrigin.Begin)
            Length += 8
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddString(ByVal buffer As String)
            Dim Bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(buffer.ToCharArray)

            ms.Seek(0, SeekOrigin.End)
            bw.Write(Bytes)
            bw.Write(CType(0, Byte))

            ms.Seek(0, SeekOrigin.Begin)
            Length += Bytes.Length + 1
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddDouble(ByVal buffer As Double)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(buffer)

            ms.Seek(0, SeekOrigin.Begin)
            Length += 8
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddSingle(ByVal buffer As Single)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(buffer)

            ms.Seek(0, SeekOrigin.Begin)
            Length += 4
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddByteArray(ByVal buffer() As Byte)
            ms.Seek(0, SeekOrigin.End)
            bw.Write(buffer)

            ms.Seek(0, SeekOrigin.Begin)
            Length += buffer.Length
            bw.Write(CType(Length, Int16))
        End Sub
        Public Sub AddPackGUID(ByVal buffer As Long)
            Dim GUID() As Byte = BitConverter.GetBytes(buffer)
            Dim flags As New BitArray(8)
            Dim flagsByte(1) As Byte
            Length += 1

            flags(0) = (GUID(0) <> 0)
            flags(1) = (GUID(1) <> 0)
            flags(2) = (GUID(2) <> 0)
            flags(3) = (GUID(3) <> 0)
            flags(4) = (GUID(4) <> 0)
            flags(5) = (GUID(5) <> 0)
            flags(6) = (GUID(6) <> 0)
            flags(7) = (GUID(7) <> 0)

            If flags(0) Then Length += 1
            If flags(1) Then Length += 1
            If flags(2) Then Length += 1
            If flags(3) Then Length += 1
            If flags(4) Then Length += 1
            If flags(5) Then Length += 1
            If flags(6) Then Length += 1
            If flags(7) Then Length += 1

            ms.Seek(0, SeekOrigin.End)
            flags.CopyTo(flagsByte, 0)
            bw.Write(flagsByte(0))
            If flags(0) Then bw.Write(GUID(0))
            If flags(1) Then bw.Write(GUID(1))
            If flags(2) Then bw.Write(GUID(2))
            If flags(3) Then bw.Write(GUID(3))
            If flags(4) Then bw.Write(GUID(4))
            If flags(5) Then bw.Write(GUID(5))
            If flags(6) Then bw.Write(GUID(6))
            If flags(7) Then bw.Write(GUID(7))

            ms.Seek(0, SeekOrigin.Begin)
            bw.Write(CType(Length, Int16))
        End Sub

        Public Function GetInt8() As Byte
            Return br.ReadByte()
        End Function
        Public Function GetInt8(ByVal Offset As Integer) As Byte
            ms.Seek(Offset, SeekOrigin.Begin)
            Return br.ReadByte()
        End Function
        Public Function GetInt16() As Short
            Return br.ReadInt16
        End Function
        Public Function GetInt16(ByVal Offset As Integer) As Short
            ms.Seek(Offset, SeekOrigin.Begin)
            Return br.ReadInt16
        End Function
        Public Function GetInt32() As Integer
            Return br.ReadInt32
        End Function
        Public Function GetInt32(ByVal Offset As Integer) As Integer
            ms.Seek(Offset, SeekOrigin.Begin)
            Return br.ReadInt32
        End Function
        Public Function GetInt64() As Long
            Return br.ReadInt64
        End Function
        Public Function GetInt64(ByVal Offset As Integer) As Long
            ms.Seek(Offset, SeekOrigin.Begin)
            Return br.ReadInt64
        End Function
        Public Function GetFloat() As Single
            Return br.ReadSingle
        End Function
        Public Function GetFloat(ByVal Offset As Integer) As Single
            ms.Seek(Offset, SeekOrigin.Begin)
            Return br.ReadSingle
        End Function
        Public Function GetDouble() As Double
            Return br.ReadDouble
        End Function
        Public Function GetDouble(ByVal Offset As Integer) As Double
            ms.Seek(Offset, SeekOrigin.Begin)
            Return br.ReadDouble
        End Function
        Public Function GetString() As String
            Dim tmpString As New System.Text.StringBuilder
            Dim tmpChar As Char = br.ReadChar()
            Dim tmpEndChar As Char = System.Text.Encoding.UTF8.GetString(New Byte() {0})

            While tmpChar <> tmpEndChar
                tmpString.Append(tmpChar)
                tmpChar = br.ReadChar()
            End While

            Return tmpString.ToString
        End Function
        Public Function GetString(ByVal Offset As Integer) As String
            ms.Seek(Offset, SeekOrigin.Begin)
            Dim tmpString As New System.Text.StringBuilder
            Dim tmpChar As Char = br.ReadChar()
            Dim tmpEndChar As Char = System.Text.Encoding.UTF8.GetString(New Byte() {0})

            While tmpChar <> tmpEndChar
                tmpString.Append(tmpChar)
                tmpChar = br.ReadChar()
            End While

            Return tmpString.ToString
        End Function
        Public Function GetPackGUID() As Long
            Dim flags As Byte = br.ReadByte
            Dim GUID() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}
            Offset += 1

            If (flags And 1) = 1 Then GUID(0) = br.ReadByte
            If (flags And 2) = 2 Then GUID(1) = br.ReadByte
            If (flags And 4) = 4 Then GUID(2) = br.ReadByte
            If (flags And 8) = 8 Then GUID(3) = br.ReadByte
            If (flags And 16) = 16 Then GUID(4) = br.ReadByte
            If (flags And 32) = 32 Then GUID(5) = br.ReadByte
            If (flags And 64) = 64 Then GUID(6) = br.ReadByte
            If (flags And 128) = 128 Then GUID(7) = br.ReadByte

            Return CType(BitConverter.ToInt64(GUID, 0), Long)
        End Function
        Public Function GetPackGUID(ByVal Offset As Integer) As Long
            ms.Seek(Offset, SeekOrigin.Begin)
            Dim flags As Byte = br.ReadByte
            Dim GUID() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}
            Offset += 1

            If (flags And 1) = 1 Then GUID(0) = br.ReadByte
            If (flags And 2) = 2 Then GUID(1) = br.ReadByte
            If (flags And 4) = 4 Then GUID(2) = br.ReadByte
            If (flags And 8) = 8 Then GUID(3) = br.ReadByte
            If (flags And 16) = 16 Then GUID(4) = br.ReadByte
            If (flags And 32) = 32 Then GUID(5) = br.ReadByte
            If (flags And 64) = 64 Then GUID(6) = br.ReadByte
            If (flags And 128) = 128 Then GUID(7) = br.ReadByte

            Return CType(BitConverter.ToInt64(GUID, 0), Long)
        End Function

    End Class
    Public Class UpdatePacketClassNew
        Inherits PacketClassNew

        Public Property UpdatesCount() As Integer
            Get
                ms.Seek(4, SeekOrigin.Begin)
                Return br.ReadInt32
            End Get
            Set(ByVal Value As Integer)
                ms.Seek(4, SeekOrigin.Begin)
                bw.Write(Value)
            End Set
        End Property
        Public Sub New()
            MyBase.New(OPCODES.SMSG_UPDATE_OBJECT)

            Me.AddInt32(0)
            Me.AddInt8(0)
        End Sub

        Public Sub Compress()
        End Sub
    End Class


#End Region






End Module
