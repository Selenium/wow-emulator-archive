using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for WorldObject.
	/// </summary>
	[UpdateObjectAttribute(MaxFields=(int)OBJECTFIELDS.MAX)]
	public abstract class WorldObject
	{
		static IntComparer comp = new IntComparer();
		BinaryTree m_updateValues = BinaryTree.CreateTree(comp, false);

		#region UpdateValue
		public void UpdateValue(OBJECTFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(ITEMFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(CONTAINERFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(UNITFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(PLAYERFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(GAMEOBJECTFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(DYNAMICOBJECTFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(CORPSEFIELDS field)
		{
			m_updateValues.AddData((int)field);
		}

		public void UpdateValue(int field)
		{
			m_updateValues.AddData(field);
		}
		#endregion

		[UpdateValueAttribute(OBJECTFIELDS.GUID)]
		public abstract ulong GUID
		{
			get;
		}

		[UpdateValueAttribute(OBJECTFIELDS.HIER_TYPE)]
		public virtual HIER_OBJECTTYPE HierType
		{
			get { return HIER_OBJECTTYPE.OBJECT;}
		}

		[UpdateValueAttribute(OBJECTFIELDS.ENTRY)]
		public virtual uint Entry
		{
			get {return 0;}
			set {}
		}

		[UpdateValueAttribute(OBJECTFIELDS.SCALE)]
		public virtual float Scale
		{
			get {return 1.0f;}
			set {}
		}

		public virtual OBJECTTYPE ObjectType
		{
			get {return OBJECTTYPE.OBJECT;}
		}

		public abstract Vector Position
		{
			get;
			set;
		}

		public abstract float Facing
		{
			get;
			set;
		}

		public abstract uint MovementFlags
		{
			get;
			set;
		}

		public float WalkSpeed = 2.5f;
		public float RunningSpeed = 7.0f;
		public float RunBackSpeed = 2.5f;
		public float SwimSpeed = 4.7222223f;
		public float SwimBackSpeed = 4.0f;
		public float TurnRate = 3.141593f;
		public uint[] VisibleItems = new uint[20];
		
		private MapTile m_mapTile;
		public MapTile MapTile
		{
			get { return m_mapTile;}
			set { m_mapTile = value;}
		}

		public WorldObject()
		{

		}

		private void write_updatemovement(BinWriter w)
		{
			w.Write(MovementFlags);
			w.Write(0);
			w.WriteVector(Position);
			w.Write(Facing);
			w.Write(0); // 1.3.0 fix
			w.Write(WalkSpeed);
			w.Write(RunningSpeed);
			w.Write(RunBackSpeed);
			w.Write(SwimSpeed);
			w.Write(SwimBackSpeed);
			w.Write(TurnRate);
		}

		public virtual void PreCreateObject(bool isClient)
		{
			UpdateValue(OBJECTFIELDS.GUID);
			UpdateValue(OBJECTFIELDS.HIER_TYPE);
			UpdateValue(OBJECTFIELDS.ENTRY);
			UpdateValue(OBJECTFIELDS.SCALE);
		}

		public virtual void AddCreateObject(BinWriter w, bool isClient, bool clear)
		{
			PreCreateObject(isClient);
			w.Write((byte)2); // CreateObject
			w.Write(GUID);
			w.Write((byte)ObjectType);
			write_updatemovement(w);
			w.Write(isClient ? 1 : 0);
			w.Write(1);
			w.Write(0);
			w.Write((long)0);
			ObjectUpdateManager.WriteDataUpdate(w, m_updateValues, this, clear, isClient);
		}

		public virtual void PostCreateObject()
		{
		}

		public virtual void UpdateData(BinWriter w, bool clear, bool isClient)
		{
			w.Write((byte)0); // UpdateData 
			w.Write(GUID);
			ObjectUpdateManager.WriteDataUpdate(w, m_updateValues, this, clear, isClient);
		}

		public virtual void UpdateData()
		{
			ServerPacket pkg = new ServerPacket(SMSG.UPDATE_OBJECT);
			pkg.Write(1);
			pkg.Write((byte)0);  // A9 Fix by Phaze
			UpdateData(pkg, true, false);
			pkg.Finish();
			if(MapTile != null)
				MapTile.SendSurrounding(pkg);
		}

		public virtual void Save()
		{
		}

		public virtual void SaveAndRemove()
		{
		}
	}
}
