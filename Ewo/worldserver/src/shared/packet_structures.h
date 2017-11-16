// Copyright (C) 2006 Team Evolution
#ifndef _PACKET_STRUCTURES_H_
#define _PACKET_STRUCTURES_H_

//wrap constant size packeges into structures to see them better
//don't use uint64 unless it's necesary (jsut a speedtest)
#if __GNUC__ && (GCC_MAJOR < 4 || GCC_MAJOR == 4 && GCC_MINOR < 1)
	#pragma pack(1)
#else
	#pragma pack(push,1)
#endif 

struct P_SMSG_AI_REACTION
{
	unsigned int guidl;
	unsigned int guidh;
	unsigned int reaction;
};

struct P_SMSG_MONSTER_MOVE
{
	unsigned char	guid_mask;
	unsigned int	guid[2];
	float			src_x,src_y,src_z;
	unsigned int	move_serial;
	unsigned char	walk_back;
	unsigned int	walk_flags;
	unsigned int	walk_time;
	unsigned int	path_waypoint_count;
	float			dst_x,dst_y,dst_z;
};

struct P_SMSG_FORCE_MOVE_UNROOT
{
	unsigned char	guid_mask;
	unsigned int	guid[2];
	unsigned int	move_flags; //not sure
};

struct P_SMSG_ATTACKSTOP
{
	unsigned char	self_guid_mask;
	unsigned int	self_guid[2];
	unsigned char	target_guid_mask;
	unsigned int	target_guid[2];
	unsigned int	flags; //not sure, saw examples for 0,1
};

struct P_SMSG_ATTACKSTART
{
	unsigned char	self_guid_mask;
	unsigned int	self_guid[2];
	unsigned char	target_guid_mask;
	unsigned int	target_guid[2];
};

struct P_SMSG_EXPLORATION_EXPERIENCE
{
	unsigned int	zone_id;
	unsigned int	xp;
};
#if __GNUC__ && (GCC_MAJOR < 4 || GCC_MAJOR == 4 && GCC_MINOR < 1)
	#pragma pack()
#else
	#pragma pack(pop)
#endif

#endif