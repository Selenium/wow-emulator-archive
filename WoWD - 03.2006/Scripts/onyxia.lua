
Events.RegisterEvent(10184,3,"Onyxia_OnEnterCombat")

function Onyxia_OnEnterCombat(pUnit, Event)
	pUnit:SetStandState(0)
	pUnit:SendChatMessage(12, 0, "How fortuitous. Usually i have to leave my lair in order to feed.")
end

