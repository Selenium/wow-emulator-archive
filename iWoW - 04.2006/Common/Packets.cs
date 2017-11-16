using System;

namespace WoWDaemon.Common
{

	/// <summary>
	/// Do we need a class for anything else than sending?
	/// </summary>
	public class WorldPacket : BinWriter
	{
		// this is basically just for debugging...
		WORLDMSG m_worldMsgId;

		public WorldPacket(WORLDMSG msgID) : base()
		{
			Write((UInt32)0); // WorldPacket len
			Write((UInt32)msgID);

			m_worldMsgId = msgID;
		}

		public override string  ToString()
		{
			return base.ToString() + " WORLDMSG = " + m_worldMsgId.ToString();
		}
	}

	public class ClientPacket : WorldPacket
	{
		CMSG m_clientMsgId;
		uint m_characterId;

		public ClientPacket(CMSG msgID, uint characterID, byte[] data) : base(WORLDMSG.CLIENT_MESSAGE)
		{
			Write(characterID);
			Write((short)msgID);
			if(data != null)
				Write(data);

			m_clientMsgId = msgID;
			m_characterId = characterID;
		}

		public ClientPacket(CMSG msgID, uint characterID, byte[] data, int index, int count) : base(WORLDMSG.CLIENT_MESSAGE)
		{
			Write(characterID);
			Write((short)msgID);
			Write(data, index, count);

			m_clientMsgId = msgID;
		}

		public override string ToString()
		{
			return base.ToString() + ", CMSG = " + m_clientMsgId.ToString()
				+ " characterID = " + m_characterId.ToString();
		}
	}

	public class ServerPacket : WorldPacket
	{
		SMSG m_serverMsgId;

		public ServerPacket(SMSG msgID) : base(WORLDMSG.SERVER_MESSAGE)
		{
			Write((short)msgID);
			Write((short)0); // GamePacket Data Len ( != WorldPacket len )

			m_serverMsgId = msgID;
		}

		public override string ToString()
		{
			return base.ToString() + ", SMSG = " + m_serverMsgId.ToString();
		}

		/// <summary>
		/// Call this once you are ready to add destination clients
		/// </summary>
		public void Finish()
		{
			base.Flush();
            ushort len = (ushort)(BaseStream.Length - 2);
            len = (ushort)((len >> 8) + ((len & 0xFF) << 8));            
			Set(0, (int)(BaseStream.Length));
		}
/*
		/// <summary>
		/// Don't call this before Finalize()!
		/// </summary>
		/// <param name="client"></param>
		public void AddDestination(WorldClient client)
		{
			Write(client.CharacterID);
		}
*/
		/// <summary>
		/// Don't call this before Finalize()!
		/// </summary>
		/// <param name="characterID"></param>
		public void AddDestination(uint characterID)
		{
			Write(characterID);
		}
	}

	public class ScriptPacket : WorldPacket
	{
		public ScriptPacket(SCRMSG msgID) : base(WORLDMSG.SCRIPT_MESSAGE)
		{
			Write((int)msgID);
		}
	}


}
