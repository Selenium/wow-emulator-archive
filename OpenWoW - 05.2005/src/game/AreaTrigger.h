class AreaTrigger
{
public:
    AreaTrigger()
    {
		m_AreaTriggerID = 0;
		m_MapID = 0;
		m_X = 0;
		m_Y = 0;
		m_Z = 0;
		m_O = 0;
		m_TargetTriggerID = 0;
    }

    uint32 m_AreaTriggerID;
	uint32 m_MapID;
	float m_X;
	float m_Y;
	float m_Z;
	float m_O;
	uint32 m_TargetTriggerID;
};
