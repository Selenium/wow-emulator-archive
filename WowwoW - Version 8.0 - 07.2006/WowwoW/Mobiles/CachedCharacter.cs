using System;

namespace Server
{
	public class CachedCharacter
	{
		string name;
		UInt64 guid;
		int loc;
		int mapId;
		int size;
		byte dirty;
	/*	int zoneId;
		byte gender;
		byte skin;
		byte face;
		byte hairStyle;
		byte hairColor;
		byte facialHair;
		Classes classe;
		Races race;
		byte level;
		float x;
		float y;
		float z;*/

		public CachedCharacter( string _name, UInt64 _guid, int _mapId, int _zoneId, int _loc, int _size
		/*	float X, float Y, float Z, 
			int _loc, byte _level, Classes _classe, Races _race,
			byte _gender, byte _skin, byte _face, byte _hairStyle, byte _hairColor, byte _facialHair*/ )
		{
			name = _name;
			guid = _guid;
			mapId = _mapId;
			loc = _loc;
			size = _size;
			dirty = (byte)0;
/*			zoneId = _zoneId;
			skin = _skin;
			gender = _gender;
			face = _face;
			hairStyle = _hairStyle;
			hairColor = _hairColor;
			facialHair = _facialHair;
			race = _race;
			classe = _classe;
			level = _level;*/
		}

		public UInt64 Guid
		{
			get { return guid; }
		}
		public int MapId
		{
			get { return mapId; }
		}
		public int Position
		{
			get { return loc; }
		}
		public int Size
		{
			get { return size; }
		}
		public byte Dirty
		{
			get { return dirty; }
			set { dirty = value; }
		}
	}

}