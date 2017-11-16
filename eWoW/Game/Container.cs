using System;
using System.Collections;

namespace eWoW
{
	public enum ItemErrorNo 
	{
		NONE                       = 0,
		CANT_EQUIP_LEVEL_I         = 0x1,  // need more level
		CANT_EQUIP_SKILL           = 0x2,
		WRONG_SLOT                 = 0x3,  // that item do not go that slot
		BAG_FULL                   = 0x4,  
		BAG_IN_BAG                 = 0x5,  // bag not empty
		AMMO_ONLY                  = 0x6,  
		PROFICIENCY_NEEDED         = 0x7,
		NOT_EQUIPPABLE             = 0x8,
		NEVER                      = 0x9,
		NEVER2                     = 0xA,
		WRONG_EQ_SLOT              = 0xb,
		TWOHAND                    = 0xc,
		DULEWIELD                  = 0xd,
		WRONG_SLOT2                = 0xe,
		WRONG_SLOT3                = 0xf,
		ITEM_TOO_MANY              = 0x10,
		NOT_A_BAG                  = 0x1d,
	};

	public interface IContainer
	{
		SlotID ItemCount { get; }
		Item GetItem(ulong guid);
		Item GetItem(SlotID id);
		ItemErrorNo SetItem(SlotID id, Item newItem);
	}

	public class Container : Item , IContainer
	{
		Item[] items = null;

		public Container(GameServer gs) : base(gs)
		{
			gameServer = gs;
			Type|=(ushort)TYPE.CONTAINER;
		}

		public override void Update()
		{
		}

		protected override bool Create(Character c, Hashtable data, ByteArrayBase moredata)
		{
			if(!base.Create(c, data, moredata))return false;
			
			items = new Item[ (int)data["containerslots"] ];
			SetUpdateValue(UpdateFields.CONTAINER_FIELD_NUM_SLOTS, (uint)items.Length);

			while(moredata!=null)
			{
				SlotID slot=(SlotID)moredata.GetByte();
				if(slot==SlotID.CHARACTER)break;
				uint e=moredata.GetDWord();
				ushort len=moredata.GetWord();
				Item n = new Item( gameServer );
				 n=n.Create(c, e, new ByteArray(moredata.GetArray(len)) );
				if(n!=null)
				{
					n.SetUpdateValue(UpdateFields.ITEM_FIELD_CONTAINED, GUID);
					//n.SetUpdateValue(UpdateFields.ITEM_FIELD_CONTAINED_01, GUID);
					SetItem(slot, n);
				}
			}
			return true;
		}

		public override byte[] GetSaveData()
		{
			ByteArrayBuilder pack=new ByteArrayBuilder();
			pack.Add( base.GetSaveData() );

			for(int i=0; i<items.Length; i++)
			{
				if(items[i]==null)continue;
				pack.Add((byte)i);

				pack.Add(items[i].Entry);

				int pos=pack.Length;
				pack.Add((ushort)0);
				pack.Add( items[i].GetSaveData() );
				pack.Set(pos, (ushort)(pack.Length-pos-2) );
			}
			pack.Add((byte)SlotID.CHARACTER);
			return pack;
		}

		public override void BuildCreateMask(UpdateMask mask, bool myself)
		{
			base.BuildCreateMask(mask, myself);
			mask.Touch(
				UpdateFields.CONTAINER_FIELD_NUM_SLOTS
				);
			for(int i=0; i<items.Length; i++)
			{
				mask.Touch(
					UpdateFields.CONTAINER_FIELD_SLOT_1 + (ushort)(i*2), 
					UpdateFields.CONTAINER_FIELD_SLOT_1 + (ushort)(i*2+1)
					);
			}
		}

		public override void SendCreateItem(Character c)
		{
			for(int i=0; i<items.Length; i++)
			{
				if(items[i]==null)continue;
				items[i].SendCreateItem(c);
			}

			base.SendCreateItem(c);
		}

		public override void SendUpdateItem(Character c)
		{
			for(int i=0; i<items.Length; i++)
			{
				if(items[i]==null)continue;
				items[i].SendUpdateItem(c);
			}

			base.SendUpdateItem(c);
		}
		#region IContainer ³ÉÔ±

        public eWoW.SlotID ItemCount
		{
			get
			{
				return (SlotID)items.Length;
			}
		}

		public Item GetItem(ulong guid)
		{
			for(int i=0; i<items.Length; i++)
			{
				if(items[i]==null)continue;
				if(items[i].GUID==guid)return items[i];
			}
			return null;
		}

		public Item GetItem(SlotID id)
		{
			return items[(int)id];
		}

        public ItemErrorNo SetItem(eWoW.SlotID id, Item newItem)
		{
			if((int)id>=items.Length)return ItemErrorNo.WRONG_SLOT;

			items[(int)id]=newItem;
			if(newItem!=null)
			{
				SetUpdateValue(UpdateFields.CONTAINER_FIELD_SLOT_1+(ushort)((byte)id*2), newItem.GUID);
			} 
			else 
			{
				SetUpdateValue(UpdateFields.CONTAINER_FIELD_SLOT_1+(ushort)((byte)id*2), (ulong)0);
			}
			return ItemErrorNo.NONE;
		}
		#endregion
	}

}
