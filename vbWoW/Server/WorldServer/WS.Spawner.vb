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
Imports System.Runtime.CompilerServices
Imports vbWoW.Logbase.BaseWriter

Public Class TSpawner
    Implements IDisposable
    Public Const SPAWNER_CHECK_INTERVAL As Integer = 60000 '1m = 60s = 60000ms


    Private SpawnerTimer As Object = Nothing
    Private SpawnerTimerDelegate As Threading.TimerCallback = Nothing
    Public Sub CheckSpawns(ByVal state As Object)
        Database.Update(String.Format("UPDATE adb_spawns SET spawn_left = spawn_left - 1 WHERE spawn_map = {0} AND spawn_spawned = 0 AND spawn_left <> 0;", HANDLED_MAP_ID))
        Database.Update(String.Format("UPDATE adb_spawns SET spawn_left = '0' WHERE spawn_map = {0} AND spawn_left < 0;", HANDLED_MAP_ID))

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_spawns WHERE spawn_map = {0} AND spawn_left = 0 AND spawn_spawned = 0;", HANDLED_MAP_ID), MySQLQuery)

        If MySQLQuery.Rows.Count > 0 Then
            'Dim tmp As String = Nothing

            For Each Row As DataRow In MySQLQuery.Rows
                Try
                    If Row.Item("spawn_type") = ObjectTypeID.TYPEID_UNIT Then
                        'If tmp Is Nothing Then
                        '    tmp = "spawn_id=" & Row.Item("spawn_id")
                        'Else
                        '    tmp = " OR spawn_id=" & Row.Item("spawn_id")
                        'End If
                        Database.Update(String.Format("UPDATE adb_spawns SET spawn_left=spawn_time ,spawn_spawned=1 WHERE spawn_id={0};", Row.Item("spawn_id")))

                        'DONE: Here spawn the creature
                        Dim tmpCr As New CreatureObject(CType(Row.Item("spawn_entry"), Integer))
                        tmpCr.positionX = Row.Item("spawn_positionX") + Rnd.Next(Row.Item("spawn_range"))
                        tmpCr.positionY = Row.Item("spawn_positionY") + Rnd.Next(Row.Item("spawn_range"))
                        tmpCr.positionZ = Row.Item("spawn_positionZ") + Rnd.Next(Row.Item("spawn_range"))
                        tmpCr.orientation = Row.Item("spawn_orientation")
                        tmpCr.SpawnID = Row.Item("spawn_id")
                        tmpCr.SpawnX = Row.Item("spawn_positionX")
                        tmpCr.SpawnY = Row.Item("spawn_positionY")
                        tmpCr.SpawnZ = Row.Item("spawn_positionZ")
                        tmpCr.MapID = Row.Item("spawn_map")
                        tmpCr.AddToWorld()

                        'DONE: Save the spawned creature
                        Database.Update(String.Format("INSERT INTO tmpSpawnedCreatures (spawned_guid,spawned_positionX,spawned_positionY,spawned_positionZ,spawned_orientation,spawned_map,spawned_entry,spawn_id) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});", tmpCr.GUID - GUID_UNIT, Trim(Str(tmpCr.positionX)), Trim(Str(tmpCr.positionY)), Trim(Str(tmpCr.positionZ)), Trim(Str(tmpCr.orientation)), tmpCr.MapID, tmpCr.ID, tmpCr.SpawnID))
                        Log.WriteLine(LogType.INFORMATION, "World: Spawned creature [{0}], ID={1}", tmpCr.Name, tmpCr.ID)

                    ElseIf Row.Item("spawn_type") = ObjectTypeID.TYPEID_GAMEOBJECT Then
                        Database.Update(String.Format("UPDATE adb_spawns SET spawn_left=spawn_time ,spawn_spawned=1 WHERE spawn_id={0};", Row.Item("spawn_id")))

                        'DONE: Here spawn the game object
                        Dim tmpGO As New GameObjectObject(CType(Row.Item("spawn_entry"), Integer))
                        tmpGO.positionX = Row.Item("spawn_positionX") + Rnd.Next(Row.Item("spawn_range"))
                        tmpGO.positionY = Row.Item("spawn_positionY") + Rnd.Next(Row.Item("spawn_range"))
                        tmpGO.positionZ = Row.Item("spawn_positionZ") + Rnd.Next(Row.Item("spawn_range"))
                        tmpGO.orientation = Row.Item("spawn_orientation")
                        tmpGO.SpawnID = Row.Item("spawn_id")
                        tmpGO.MapID = Row.Item("spawn_map")
                        tmpGO.AddToWorld()

                        'DONE: Save the spawned creature
                        Database.Update(String.Format("INSERT INTO tmpSpawnedGameObjects (gameObject_guid,gameObject_positionX,gameObject_positionY,gameObject_positionZ,gameObject_orientation,gameObject_map,gameObject_entry,gameObject_spawnId,gameObject_rotation1,gameObject_rotation2,gameObject_rotation3,gameObject_rotation4) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11});", tmpGO.GUID - GUID_GAMEOBJECT, Trim(Str(tmpGO.positionX)), Trim(Str(tmpGO.positionY)), Trim(Str(tmpGO.positionZ)), Trim(Str(tmpGO.orientation)), tmpGO.MapID, tmpGO.ID, tmpGO.SpawnID, tmpGO.Rotation(0), tmpGO.Rotation(1), tmpGO.Rotation(2), tmpGO.Rotation(3)))
                        Log.WriteLine(LogType.INFORMATION, "World: Spawned gameoObject [{0}], ID={1}", tmpGO.Name, tmpGO.ID)
                    End If
                Catch e As Exception
                    Log.WriteLine(LogType.INFORMATION, "World: Unable to spawn gameoObject [SpawnID={0}]", Row.Item("spawn_id"))
                End Try
            Next

            'If tmp <> "" Then MySQL.Update(String.Format("UPDATE adb_spawns SET spawn_left=spawn_time ,spawn_spawned=1 WHERE {0};", tmp))
        End If
    End Sub

    Public Sub New()
        SpawnerTimerDelegate = New Threading.TimerCallback(AddressOf CheckSpawns)
        SpawnerTimer = New System.Threading.Timer(SpawnerTimerDelegate, Nothing, 120000, 60000)
        'SpawnerTimer = New System.Threading.Timer(SpawnerTimerDelegate, Nothing, 1000, Timeout.Infinite)
        Log.WriteLine(LogType.SUCCESS, "Spawner initialized.")
    End Sub
    Public Sub Dispose() Implements System.IDisposable.Dispose
        SpawnerTimer.dispose()
        SpawnerTimer = Nothing
        SpawnerTimerDelegate = Nothing
    End Sub



    Public Function SpawnGameObject(ByVal id As Integer, ByVal x As Single, ByVal y As Single, ByVal z As Single, ByVal o As Single, Optional ByVal SpawnID As Integer = 0) As GameObjectObject
        Dim tmpGO As New GameObjectObject(id)
        tmpGO.positionX = x
        tmpGO.positionY = y
        tmpGO.positionZ = z
        tmpGO.orientation = o
        tmpGO.SpawnID = SpawnID
        tmpGO.MapID = HANDLED_MAP_ID
        tmpGO.AddToWorld()

        Return tmpGO
    End Function
    Public Function SpawnCreature(ByVal id As Integer, ByVal x As Single, ByVal y As Single, ByVal z As Single, ByVal o As Single, Optional ByVal SpawnID As Integer = 0) As CreatureObject
        Dim tmpCr As New CreatureObject(id)
        tmpCr.positionX = x
        tmpCr.positionY = y
        tmpCr.positionZ = z
        tmpCr.orientation = o
        tmpCr.SpawnID = SpawnID
        tmpCr.SpawnX = x
        tmpCr.SpawnY = x
        tmpCr.SpawnZ = y
        tmpCr.MapID = HANDLED_MAP_ID
        tmpCr.AddToWorld()

        Return tmpCr
    End Function
    Public Sub DeSpawnGameObject(ByRef go As GameObjectObject)
        go.Destroy()
    End Sub
    Public Sub DeSpawnCreature(ByRef cr As CreatureObject)
        cr.Destroy()
    End Sub

End Class


