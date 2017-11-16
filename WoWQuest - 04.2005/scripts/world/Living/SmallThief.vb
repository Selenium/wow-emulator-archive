Imports WoWDaemon
Imports WoWDaemon.Database.DataTables
Imports WoWDaemon.World

Namespace WorldScripts.Living
    Public Class SmallThief
        Inherits UnitBase

        Public Sub New(ByVal creature As DBCreature)
            MyBase.New(creature)
            MaxHealth = 100
            Health = 100
            MaxPower = 0
            Power = 0
            PowerType = Common.POWERTYPE.RAGE
            Level = 1
            Faction = 0
            DisplayID = 508
            Scale = 0.75
        End Sub

    End Class
End Namespace

