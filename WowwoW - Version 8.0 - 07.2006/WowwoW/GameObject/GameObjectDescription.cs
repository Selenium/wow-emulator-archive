using System;
using System.Collections;
using HelperTools;


namespace Server
{
	/// <summary>
	/// Summary description for GameObjectDescription.
	/// </summary>
	public class GameObjectDescription
	{
		string name;
		byte type;
		uint []sound;
		ushort model;
		float size;
		BaseTreasure []loots;
		int flags;
		

		public static Hashtable all = new Hashtable();

		#region CONSTRUCTOR
		public GameObjectDescription( string n, int t, int mod )
		{
			name = n;
			type = (byte)t;
			model = (ushort)mod;
		}
		public GameObjectDescription( string n, int t, int mod, uint []s ) : this( n, t, mod )
		{
			sound = s;
		}

		public GameObjectDescription( string n, int t, int mod, float siz, int flag, Loot []l, uint []s ) : this( n, t, mod )
		{
			BaseTreasure []bt = new BaseTreasure[] { new BaseTreasure( l, 100.0f ) };
			sound = s;
			loots = bt;
			size = siz;
			flags = flag;
			type = (byte)t;
		}
		public GameObjectDescription( string n, int t, int mod, float siz, int flag,  uint []s ) : this( n, t, mod )
		{
			sound = s;
			size = siz;
			flags = flag;
			type = (byte)t;
		}

		#endregion

		#region ACCESSORS
		public uint[]Sound
		{
			get{ return sound; }
		}
		public string Name
		{
			get{ return name; }
		}
		public int Model
		{
			get{ return model; }
		}
		public int ObjectType
		{
			get{ return (int)type; }
		}
		public float Size
		{
			get{ return size; }
		}
		public int Flags
		{
			get{ return flags; }
		}
		public int Type
		{
			get{ return type; }
		}
		public BaseTreasure []Loots
		{
			get { return loots; }
		}
		#endregion

	}
}
