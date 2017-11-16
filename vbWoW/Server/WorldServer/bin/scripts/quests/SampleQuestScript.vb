Imports System
Imports Microsoft.VisualBasic
Imports vbWoW.WorldServer

Namespace Scripts
    Public Class QuestScript
        Inherits BaseQuestScripted

        Public Overrides Sub OnQuestStart(ByRef c As CharacterObject)
            Console.WriteLine("[{0}] TestQuest: OnQuestStart()", Format(TimeOfDay, "hh:mm:ss"))
        End Sub

        Public Overrides Sub OnQuestCancel(ByRef c As CharacterObject)
            Console.WriteLine("[{0}] TestQuest: OnQuestCancel()", Format(TimeOfDay, "hh:mm:ss"))
        End Sub

        Public Overrides Sub OnQuestComplete(ByRef c As CharacterObject)
            Console.WriteLine("[{0}] TestQuest: OnQuestComplete()", Format(TimeOfDay, "hh:mm:ss"))
        End Sub

        Public Overrides Function IsCompleted() As Boolean
            Return True
        End Function
        Public Overrides Function GetState() As Integer
            Return 0
        End Function
        Public Overrides Sub LoadState(ByVal state As Integer)

        End Sub

        Public Overridable Sub OnQuestItem(ByRef c As CharacterObject, ByVal ItemID As Integer, ByVal ItemCount As Integer)
            Console.WriteLine("[{0}] TestQuest: OnQuestItem()", Format(TimeOfDay, "hh:mm:ss"))
        End Sub
        Public Overridable Sub OnQuestKill(ByRef c As CharacterObject, ByRef Creature As CreatureObject)
            Console.WriteLine("[{0}] TestQuest: OnQuestKill()", Format(TimeOfDay, "hh:mm:ss"))
        End Sub

    End Class
End Namespace
