' File containing all scripted AIs like boss or quest monsters' AI.
'
'Last  update: 08.03.2007


Imports System
Imports Microsoft.VisualBasic
Imports vbWoW.WorldServer

Namespace Scripts
	Public Class Koboldminer
		Inherits TBaseAI		

		Public Creature As CreatureObject
		Public Sub New(ByRef ParentCreature as CreatureObject)
			Creature = ParentCreature
		End Sub
		Public Overrides Sub Dispose()
		End Sub

		Public Overrides Sub OnAttack(ByRef Attacker As BaseUnit)
			If TypeOf Attacker Is CharacterObject Then
                'Creature.SendChatMessage("Nooo, no kill.... me goood Kobold.", ChatMsg.CHAT_MSG_MONSTER_SAY, LANGUAGES.LANG_UNIVERSAL)
				'Creature.SendChatMessage("Nooo, no kill.... me goood Kobold.", ChatMsg.CHAT_MSG_MONSTER_YELL, LANGUAGES.LANG_UNIVERSAL)
            End If
        End Sub

	End Class




	Public Class Sample_AI
		Inherits TBaseAI

		Public Overrides Sub OnGenerateHate(ByRef Attacker As BaseUnit, ByVal HateValue As Integer)
			Console.WriteLine("Sample_AI.OnGenerateHate()")
        End Sub
		Public Overrides Sub OnGetHit(ByRef Attacker As BaseUnit, ByVal DamageCaused As Integer)
			Console.WriteLine("Sample_AI.OnGetHit()")
        End Sub
		Public Overrides Sub OnAttack(ByRef Attacker As BaseUnit)
			Console.WriteLine("Sample_AI.OnAttack()")
        End Sub


		Public Sub New(ByRef ParentCreature as CreatureObject)
			Console.WriteLine("Sample AI loaded.")
		End Sub

	End Class
End namespace