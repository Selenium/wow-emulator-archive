using System;
using System.Collections;

namespace eWoW
{
	public enum UpdateType
	{
		Value,
		Move,
		All,
	};

	/// <summary>
	/// obj 的摘要说明。
	/// </summary>
	public abstract class Obj
	{
		public bool IsType(TYPE t) 
		{
			return (Type & (int)t) != 0;
		}


		public GameServer gameServer;
		public Obj( GameServer gs )
		{
			gameServer = gs;
			Type|=(ushort)TYPE.OBJECT;
		}

		protected void Create(ulong guid)
		{
			if(guid!=0)_guid=guid;
			if(GetUpdateValueFloat(UpdateFields.OBJECT_FIELD_SCALE_X)==0)
			SetUpdateValueFloat( UpdateFields.OBJECT_FIELD_SCALE_X, 1.0 );
			SetUpdateValue( UpdateFields.OBJECT_FIELD_GUID, _guid );
			SetUpdateValue( UpdateFields.OBJECT_FIELD_TYPE, (uint)Type );
		}
		

		public void SetUpdateValue(UpdateFields idx, ulong data, UpdateMask mask)
		{
			if(idx>=UpdateFields.PLAYER_END-1)return;
			CheckUpdateSize();
			updateValues[(ushort)idx]=(uint)data;
			updateValues[(ushort)idx+1]=(uint)(data>>32);
			mask.Set((ushort)idx, true);
			mask.Set((ushort)(idx+1), true);
		}

		public void SetUpdateValue(UpdateFields idx, uint data, UpdateMask mask)
		{
			if(idx==UpdateFields.OBJECT_FIELD_GUID || idx>=UpdateFields.PLAYER_END)return;

			CheckUpdateSize();
			ushort i = (ushort)idx;
			if (updateValues.Count > i)
			{
				updateValues[ (ushort)idx ]=data;
				mask.Set((ushort)idx, true);
			}
		}

		public void SetUpdateValueFloat(UpdateFields idx, double data, UpdateMask mask)
		{
			SetUpdateValueFloat(idx, (float)data, mask);
		}

		public void SetUpdateValueFloat(UpdateFields idx, float data, UpdateMask mask)
		{
			if(idx>=UpdateFields.PLAYER_END)return;
			CheckUpdateSize();
			ushort i = (ushort)idx;
			if (updateValues.Count > i)
			{
				updateValues[(ushort)idx]=data;
				mask.Set((ushort)idx, true);
			}
		}

		public void SetUpdateValue(UpdateFields idx, uint data)
		{
			SetUpdateValue(idx, data, updateMask);
		}

		public void SetUpdateValue(UpdateFields idx, ulong data)
		{
			SetUpdateValue(idx, data, updateMask);
		}

		public void SetUpdateValueFloat(UpdateFields idx, double data)
		{
			SetUpdateValueFloat(idx, (float)data, updateMask);
		}

		public void SetUpdateValueFloat(UpdateFields idx, float data)
		{
			SetUpdateValueFloat(idx, data, updateMask);
		}

		public void TouchUpdateValue(params UpdateFields [] update)
		{
			CheckUpdateSize();
			updateMask.Touch(update);
		}

		public uint GetUpdateValue(UpdateFields idx)
		{
			if((ushort)idx>=updateValues.Count || !(updateValues[(ushort)idx] is uint))
				return 0;
			return (uint)updateValues[(ushort)idx];
		}

		public float GetUpdateValueFloat(UpdateFields idx)
		{
			if((ushort)idx>=updateValues.Count || !(updateValues[(ushort)idx] is float))
				return 0;
			return (float)updateValues[(ushort)idx];
		}

		void CheckUpdateSize()
		{
			ushort cnt=(ushort)(Const.UNIT_BLOCKS*32);
			if( IsType(TYPE.PLAYER) )
				cnt=(ushort)(Const.PLAYER_BLOCKS*32);

			if(updateValues.Count<cnt)
			{
				updateValues.AddRange( new uint[cnt-updateValues.Count] );
			}
		}

		protected virtual void BuildMovementUpdate(ByteArrayBuilder pack)
		{
			//pack.Add( new uint[12] );
			pack.Add( (uint)0, 0, 0, 0, 0, 0 ); // flags

			pack.Add( 2.5 ); // walk speed
			pack.Add( 7.0 ); // run speed
			pack.Add( 2.5 ); // backward speed
			pack.Add( 4.7 );
			pack.Add( 4.5 );
			pack.Add( 3.14159 );
		}

		public ObjectType ObjectType
		{
			get 
			{
				if(IsType(TYPE.PLAYER))return ObjectType.PLAYER;
				if(IsType(TYPE.CONTAINER))return ObjectType.CONTAINER;
				if(IsType(TYPE.GAMEOBJECT))return ObjectType.GAMEOBJECT;
				if(IsType(TYPE.DYNAMICOBJECT))return ObjectType.DYNAMICOBJECT;
				if(IsType(TYPE.CORPSE))return ObjectType.CORPSE;
				if(IsType(TYPE.AIGROUP))return ObjectType.AIGROUP;
				if(IsType(TYPE.AREATRIGGER))return ObjectType.AREATRIGGER;
				if(IsType(TYPE.ITEM))return ObjectType.ITEM;
				if(IsType(TYPE.UNIT))return ObjectType.UNIT;
				return ObjectType.OBJECT;
			}
		}

		public byte[] BuildUpdate(UpdateMask mask, UpdateType type, bool bControl)
		{
			ByteArrayBuilder pack=new ByteArrayBuilder(false);

			pack.Add((byte)type);
			pack.Add(GUID);

			if(type!=UpdateType.Value)  // buildMoveType
			{
				pack.Add((byte)ObjectType);
				BuildMovementUpdate(pack);
			}

			if(type==UpdateType.All)
			{
				if( bControl )
					pack.Add( (uint)1 );
				else
					pack.Add( (uint)0 );

				pack.Add( (uint)1 );
				pack.Add( (uint)0 ); // timeid
				pack.Add( (uint)0 ); // victim
				pack.Add( (uint)0 );
			}

			if(type!=UpdateType.Move)  // have update value
			{
				mask.BuildUpdate(pack);
				for(ushort idx=0; idx<mask.Length; idx++)
				{
					if(mask.Set(idx, false))
					{
						if(idx>=updateValues.Count)
							pack.Add( (uint)0 );
						else if(updateValues[idx] is uint)
							pack.Add( (uint)updateValues[idx] );
						else
							pack.Add( (float)updateValues[idx] );
					}
				}
			}

			return pack;
		}
		public abstract void Update();

		public virtual void BuildCreateMask(UpdateMask mask, bool myself)
		{
			mask.Touch(
				UpdateFields.OBJECT_FIELD_GUID,
				UpdateFields.OBJECT_FIELD_GUID+1,
				UpdateFields.OBJECT_FIELD_ENTRY,
				UpdateFields.OBJECT_FIELD_TYPE,
				UpdateFields.OBJECT_FIELD_SCALE_X);
		}

		public ulong GUID 
		{
			get 
			{
				return _guid;
			}
		}

		public     uint   Entry 
		{
			get 
			{
				return entry;
			}
			set 
			{
				entry=value;
				SetUpdateValue(UpdateFields.OBJECT_FIELD_ENTRY, entry);
			}
		}

		public static uint ParseHex(string str)
		{
			return uint.Parse(str, System.Globalization.NumberStyles.HexNumber);
		}

		public     ushort Type;
		protected  uint   entry;
		protected  ulong  _guid=0;

		ArrayList  updateValues=new ArrayList();
		protected  UpdateMask updateMask=new UpdateMask();
	}


	public abstract class ObjWithPosition : Obj
	{
		public ObjWithPosition(GameServer gs) : base (gs)
		{

		}
		public ushort Map
		{
			get 
			{
				return mapID;
			}
			set
			{
				mapID=value;
				lastUpdatePos.z=Const.UPDATE_DISTANCE*1000;
			}
		}
		public ushort Zone
		{
			get 
			{
				return zoneID;
			}
			set
			{
				zoneID=value;
			}
		}

		protected void Create(uint guidlow, float x, float y, float z, float ang)
		{
			Pos=new Position(x, y, z);
			Orientation=ang;
			Map=0;
			zoneID=0;
			Create(guidlow);
		}

		protected override void BuildMovementUpdate(ByteArrayBuilder pack)
		{
			pack.Add( (uint)0, 0 ); // flags
			pack.Add( Pos.x, Pos.y, Pos.z, Orientation );

			pack.Add( 2.5 ); // walk speed
			pack.Add( 7.0 ); // run speed
			pack.Add( 2.5 ); // backward speed
			pack.Add( 4.7 );
			pack.Add( 4.5 );
			pack.Add( 3.14159 );
		}


		public float Distance(ObjWithPosition t)
		{
			return Pos.Distance(t.Pos);
		}

		public void SendMessageToSet(OP code, byte[] data, bool toSelf)
		{
			Character c;

			if(toSelf && (c=this as Character)!=null)
			{
				c.Send(code, data);
			}

			foreach(ObjWithPosition ob in objectInRange)
			{
				if(ob.IsType(TYPE.PLAYER))
				{
					c=ob as Character;
					if(c!=null)c.Send(code, data);
				}
			}
		}

		public void SendUpdateMessageToSet(UpdateMask mask, UpdateType type)
		{
			Character c;

			byte[] b=BuildUpdate(mask, type, false);
			foreach(ObjWithPosition ob in objectInRange)
			{
				if(ob.IsType(TYPE.PLAYER))
				{
					c=ob as Character;
					if(c!=null)c.SendUpdate(b);
				}
			}
		}

		public virtual bool CanSee(ObjWithPosition ob)
		{
			return false;
		}

		public virtual void UpdateInRange(ICollection allObjs, ArrayList objRemove)
		{
			// check someone exit
			ArrayList obExit=new ArrayList();
			foreach(ObjWithPosition ob in objectInRange)
			{
				if(objRemove.Contains(ob) || ob.mapID!=mapID || Distance(ob)>Const.UPDATE_DISTANCE)
					obExit.Add(ob);
			}
			foreach(ObjWithPosition ob in obExit)
			{
				objectInRange.Remove(ob);
				ob.objectInRange.Remove(this);

				if(IsType(TYPE.PLAYER))  // send Exit Message
				{
					ByteArrayBuilder b=new ByteArrayBuilder(false);
					b.Add(ob.GUID);
					(this as Character).Send(OP.SMSG_DESTROY_OBJECT, b);
				}

				if(ob.IsType(TYPE.PLAYER))
				{
					ByteArrayBuilder b=new ByteArrayBuilder(false);
					b.Add(GUID);
					(ob as Character).Send(OP.SMSG_DESTROY_OBJECT, b);
				}
			}

			// check me join
			if( Pos.Distance(lastUpdatePos) < Const.UPDATE_DISTANCE/10 )return;
			if(IsType(TYPE.PLAYER))
			{
				Character c=this as Character;
				if(!c.InWorld())return;
				gameServer.RefrencePosition(this);
			}

			lastUpdatePos=Pos;
			foreach(ObjWithPosition ob in allObjs)
			{
				if(ob.mapID!=mapID || ob==this)continue;
				if(obExit.Contains(ob) || objectInRange.Contains(ob) || Distance(ob)>Const.UPDATE_DISTANCE)continue;

				if(ob.IsType(TYPE.PLAYER) && !(ob as Character).InWorld())continue;

				if( CanSee(ob) )
				{
					objectInRange.Add(ob);

					if(IsType(TYPE.PLAYER))  // send ob Join Message
					{
						UpdateMask mask=new UpdateMask();
						ob.BuildCreateMask(mask, false);
						(this as Character).SendUpdate( ob.BuildUpdate(mask, UpdateType.All, false) );

						if(ob.IsType(TYPE.PLAYER))
						{
							(this as Character).SendCreateItems(ob as Character, CreateItemType.Other);
						}
					}
				}

				if( ob.CanSee(this) )
				{
					ob.objectInRange.Add(this);

					if(ob.IsType(TYPE.PLAYER))  // send ob Join Message
					{
						UpdateMask mask=new UpdateMask();
						BuildCreateMask(mask, false);
						(ob as Character).SendUpdate( BuildUpdate(mask, UpdateType.All, false) );

						if(IsType(TYPE.PLAYER))
						{
							(ob as Character).SendCreateItems(this as Character, CreateItemType.Other);
						}
					}
				}
			}
		}

		protected ushort mapID;
		protected ushort zoneID;
		private Position lastUpdatePos;

		public     Position Pos;
		public     float Orientation;

		protected ArrayList  objectInRange=new ArrayList();
	};
}
