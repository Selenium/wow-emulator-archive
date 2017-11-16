' Here are listed sctipted area triggers, called on packet recv.
' All not scripted triggers are supposed to be teleport trigers,
' handled by the core.
'
'Last  update: 08.03.2007






Imports System
Imports Microsoft.VisualBasic
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module AreaTriggers

		Public Sub HandleAreaTrigger_1(ByVal GUID as Long)
			SetFlag(Characters(GUID).cPlayerFlags, PlayerFlag.PLAYER_FLAG_RESTING, True)
		End Sub

		Public Sub HandleAreaTrigger_710(ByVal GUID as Long)
			SetFlag(Characters(GUID).cPlayerFlags, PlayerFlag.PLAYER_FLAG_RESTING, True)
			Characters(GUID).SetUpdateFlag(EPlayerFields.PLAYER_FLAGS, Characters(GUID).cPlayerFlags)
		End Sub

		Public Sub HandleAreaTrigger_2175(ByVal GUID as Long)
			Characters(GUID).Teleport(71.1234f, 9.74174f, -4.29735f, Characters(GUID).Orientation)
		End Sub

	End Module
End Namespace
