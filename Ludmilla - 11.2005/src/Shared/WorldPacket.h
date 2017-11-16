// Copyright (c) WoWD Team
#ifndef WOWSERVER_WORLDPACKET_H
#define WOWSERVER_WORLDPACKET_H

#include "Common.h"
#include "ByteBuffer.h"

class WorldPacket : public ByteBuffer
{
public:
    WorldPacket() : ByteBuffer(), m_opcode(0) { }
    WorldPacket(size_t res) : ByteBuffer(res), m_opcode(0) { }
    WorldPacket(const WorldPacket &packet) : ByteBuffer(packet), m_opcode(packet.m_opcode) {}

    //! Clear packet and set opcode all in one mighty blow
    void Initialize(uint16 opcode )
    {
        clear();
        m_opcode = opcode;
    }

    uint16 GetOpcode() const { return m_opcode; }
    void SetOpcode(uint16 opcode) { m_opcode = opcode; }

protected:
	uint16 m_opcode;
};

#endif
