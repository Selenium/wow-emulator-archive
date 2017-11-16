using System;
using System.IO;

namespace Maelstrom
{
	#region DBCHeader Structure

	internal struct DBCHeader
	{
		public uint RowCount;
		public uint ColumnCount;
		public uint RowSize;
		public uint StringTableSize;			

		public DBCHeader(BinaryReader Source)
		{
			uint DBCIdentifier = Source.ReadUInt32();
			if (DBCIdentifier != 0x43424457)
			{
				throw new Exception();
			}

			RowCount = Source.ReadUInt32();
			ColumnCount = Source.ReadUInt32();
			RowSize = Source.ReadUInt32();
			StringTableSize = Source.ReadUInt32();
		}
	}

	#endregion
	#region UPnPState Structure

	internal struct UPnPState
	{
		public UPnPServiceType Service;
		public string Value;

		public UPnPState(UPnPServiceType Service, string Value)
		{
			this.Service = Service;
			this.Value = Value;
		}
	}

	#endregion
}
