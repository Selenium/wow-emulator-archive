//
// UpdateData.h
//

#ifndef __UPDATEDATA_H
#define __UPDATEDATA_H

class WorldPacket;

enum OBJECT_UPDATE_TYPE {
    UPDATETYPE_VALUES = 0,
//  8 bytes - GUID
//  Goto Update Block
    UPDATETYPE_MOVEMENT = 1,
//  8 bytes - GUID
//  Goto Position Update
    UPDATETYPE_CREATE_OBJECT = 2,
//  8 bytes - GUID
//  1 byte - Object Type (*)
//  Goto Position Update
//  Goto Update Block
    UPDATETYPE_OUT_OF_RANGE_OBJECTS = 3,
//  4 bytes - Count
//  Loop Count Times:
//  8 bytes - GUID
    UPDATETYPE_NEAR_OBJECTS = 4 // looks like 3 & 4 do the same thing
//  4 bytes - Count
//  Loop Count Times:
//  8 bytes - GUID
};

class UpdateData
{
public:
    UpdateData();

    void AddOutOfRangeGUID(const uint64 &guid);
    void AddUpdateBlock(const ByteBuffer &block);
    bool BuildPacket(WorldPacket *packet);
    bool HasData() { return m_blockCount > 0 || m_outOfRangeGUIDs.size() > 0; }
    void Clear();

protected:
    uint32 m_blockCount;
    std::set<uint64> m_outOfRangeGUIDs;
    ByteBuffer m_data;

	void Compress(void* dst, uint32 *dst_size, void* src, int src_size);
};

#endif
