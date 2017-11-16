using System;

namespace WoWDaemon.Common
{

	/// <summary>
	/// Do we need a class for anything else than sending?
	/// </summary>
	public class WorldPacket : BinWriter
	{
		public WorldPacket(WORLDMSG msgID) : base()
		{
			Write(0); // WorldPacket len
			Write((int)msgID);
		}
	}

	public class ClientPacket : WorldPacket
	{
		public ClientPacket(CMSG msgID, uint characterID, byte[] data) : base(WORLDMSG.CLIENT_MESSAGE)
		{
			Write(characterID);
			Write((int)msgID);
			if(data != null)
				Write(data);
		}

		public ClientPacket(CMSG msgID, uint characterID, byte[] data, int index, int count) : base(WORLDMSG.CLIENT_MESSAGE)
		{
			Write(characterID);
			Write((int)msgID);
			Write(data, index, count);
		}
	}

	public class ServerPacket : WorldPacket
	{
		public ServerPacket(SMSG msgID) : base(WORLDMSG.SERVER_MESSAGE)
		{
			Write((int)msgID);
			Write(0); // GamePacket Data Len ( != WorldPacket len )
		}

		/// <summary>
		/// Call this once you are ready to add destination clients
		/// </summary>
		public void Finish()
		{
			Set(12, (int)(BaseStream.Length-16));
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
