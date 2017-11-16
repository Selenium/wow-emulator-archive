using System;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.World
{
	/// <summary>
	/// Not a network type client
	/// </summary>
	public class WorldClient
	{
		DBCharacter m_character;
		PlayerObject m_player;
		public WorldClient(DBCharacter character)
		{
			m_character = character;
			m_player = WorldServer.Scripts.GetNewPlayerObject(character);
			
			WorldServer.AddClient(this);
		}

		internal void CreatePlayerObject(bool isClient)
		{
			try {
				// at enter world
                DebugLogger.Logger.Log("I have a feeling... that this is whats causing it to not work.");
				BinWriter w = new BinWriter();
				w.Write((byte)1);
              	w.Write((uint)0);
                if (isClient == false) {
                    w.Write((byte)2);
                    Console.WriteLine("DEBUG: 2");
                } else {
                    w.Write((byte)3);
                    Console.WriteLine("DEBUG: 3");
                }
				m_player.AddCreateObject(w, true, true);
				BinWriter pkg = new BinWriter();
				pkg.Write((int)w.BaseStream.Length);
				pkg.Write(ZLib.Compress(w.GetBuffer(), 0, (int)w.BaseStream.Length));
				Send(SMSG.COMPRESSED_UPDATE_OBJECT, pkg);
				m_player.updateTime();
			    } catch (Exception exp) {
					DebugLogger.Logger.Log("", exp);
			}
		}

		public uint CharacterID
		{
			get
			{
				return m_character.ObjectId;
			}
		}

		public PlayerObject Player
		{
			get
			{
				return m_player;
			}
		}

		public void LeaveWorld()
		{
			try {
				this.Player.InWorld = false;
				if (m_player.Group!=null)
				{
					if (m_player.IsLeader|| m_player.Group.Size<3)
						m_player.Group.Destroy();
					else
						m_player.Group.RemoveMember(m_player.Name);
				}
				ChannelManager.Deconnection(this);
				m_player.SaveAndRemove();
				WorldServer.RemoveClient(this);
				WorldPacket pkg = new WorldPacket(WORLDMSG.PLAYER_LEAVE_WORLD);
				pkg.Write(m_character.ObjectId);
				WorldServer.Send(pkg);
			} catch (Exception exp) {
				DebugLogger.Logger.Log("", exp);
			}
		}

		public void Send(SMSG msgID, byte[] data, int index, int count)
		{
			try {
				ServerPacket pkg = new ServerPacket(msgID);
				pkg.Write(data, index, count);
				pkg.Finish();
				pkg.AddDestination(m_character.ObjectId);
				WorldServer.Send(pkg);
			} catch (Exception exp) {
				DebugLogger.Logger.Log("", exp);
			}
		}

		public void Send(SMSG msgID, BinWriter data)
		{
			try {
				ServerPacket pkg = new ServerPacket(msgID);
				pkg.Write(data.GetBuffer(), 0, (int)data.BaseStream.Length);
				pkg.Finish();
				pkg.AddDestination(m_character.ObjectId);
				WorldServer.Send(pkg);
			} catch (Exception exp) {
				DebugLogger.Logger.Log("", exp);
			}
		}
		
	}
}
