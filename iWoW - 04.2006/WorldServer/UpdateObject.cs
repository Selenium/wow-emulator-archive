using System;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.World
{
	/// <summary>
	/// Alternative UpdateObject construction.
	/// </summary>
	public class UpdateObjects
	{
		GrowableBitArray mask = new GrowableBitArray(65536);
		BinWriter w = new BinWriter();
		int c=0;

		public void UpdatePlayerObject(WorldObject obj, bool self,DBCharacter m_character)
		{
			w.Write((byte)1);
			w.Write(0);
			w.Write((byte)0); 
			w.Write((byte)2);
			w.Write(obj.GUID);
			w.Write((byte)obj.ObjectType);
			w.Write(0);
			w.Write(0);
			w.WriteVector(obj.Position);
			w.Write(obj.Facing);
			w.Write(obj.WalkSpeed);
			w.Write(obj.RunningSpeed);
			w.Write(obj.RunBackSpeed);
			w.Write(obj.SwimSpeed);
			w.Write(obj.SwimBackSpeed);
			w.Write(obj.TurnRate);
			if (self == true)
				w.Write(1);
			else
                w.Write(0);
			w.Write(1);
			w.Write(0);
			w.Write(0);
			w.Write(0);

			c = 0;

			Add((int)OBJECTFIELDS.GUID, obj.GUID);
			Add((int)OBJECTFIELDS.HIER_TYPE,(long) obj.HierType);
			Add((int)OBJECTFIELDS.SCALE, (float)1.0);




			BinWriter pkg = new BinWriter();
			pkg.Write((int)w.BaseStream.Length);
			pkg.Write(w.GetBuffer());
			Send(SMSG.UPDATE_OBJECT, pkg, m_character);

        


			/*pkg.Write((int)w.BaseStream.Length);
			pkg.Write(ZLib.Compress(w.GetBuffer(), 0, (int)w.BaseStream.Length));
			Send(SMSG.UPDATE_OBJECT, pkg);*/
				
			

		}

		public void Add(int pos, ulong data)
		{
			mask.SetBit(pos,true);
			w.Write((ulong)data);
			c += 1;
		}

		public void Add(int pos, long data)
		{
			mask.SetBit(pos,true);
			w.Write((long)data);
			c += 1;
		}

		public void Add(int pos, byte data)
		{
			mask.SetBit(pos,true);
			w.Write((byte)data);
			c += 1;
		}

		public void Add(int pos, sbyte data)
		{
			mask.SetBit(pos,true);
			w.Write((sbyte)data);
			c += 1;
		}

		public void Add(int pos, float data)
		{
			mask.SetBit(pos,true);
			w.Write((float)data);
			c += 1;
		}

		public void Send(SMSG msgID, BinWriter data,DBCharacter m_character)
		{
			try 
			{
				ServerPacket pkg = new ServerPacket(msgID);
				pkg.Write(data.GetBuffer(), 0, (int)data.BaseStream.Length);
				pkg.Finish();
				pkg.AddDestination(m_character.ObjectId);
				WorldServer.Send(pkg);
			} 
			catch (Exception exp) 
			{
				DebugLogger.Log("", exp);
			}
		}

	}
}
