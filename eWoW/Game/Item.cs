using System;
using System.Collections;

namespace eWoW
{
	public enum CreateItemType 
	{
		Self,
		Other,
		Bank,
	};


	public class Item : Obj
	{
		WORN   wornType;
		byte   quality=1;
		uint   model;
		ushort stackcount=1;
		uint   flags=0;

		public int[] bonusData;
		public int[] damageData;
		public int[] resData;
		public int[] spellData;
		public int   delay=4000;
		public ushort durability=0;
		public ushort mdurability=0;

		public Item(GameServer gs) : base(gs)
		{
			gameServer = gs;
			Type|=(ushort)TYPE.ITEM;
		}

		public override void Update()
		{

		}

		protected virtual bool Create(Character c, Hashtable data, ByteArrayBase moredata)
		{
			if(!data.Contains("model"))return false;

			base.Create( c.NextGUID() );

			model=(uint)(int)data["model"];

			SetUpdateValue(UpdateFields.ITEM_FIELD_OWNER, c.GUID);
			//SetUpdateValue(UpdateFields.ITEM_FIELD_OWNER_01, c.GUID);
			SetUpdateValue(UpdateFields.ITEM_FIELD_CONTAINED, c.GUID);
			//SetUpdateValue(UpdateFields.ITEM_FIELD_CONTAINED_01, c.GUID);
			
			if(data.Contains("inventorytype"))wornType=(WORN)(int)data["inventorytype"];
			if(data.Contains("quality"))quality=(byte)(int)data["quality"];

			uint moreflags=0;
			if(moredata!=null)
			{
				moredata.Get(out mdurability).Get(out durability).Get(out stackcount).Get(out flags).Get(out moreflags);
			} 
			else 
			{
				if(data.Contains("durability"))durability=mdurability=(ushort)(int)data["durability"];
				if(data.Contains("stackcount"))stackcount=(byte)(int)data["stackcount"];
			}

			bonusData=data["bonus"] as int[];
			damageData=data["damage"] as int[];
			spellData=data["spell"] as int[];
			resData=new int[7];
			for(int i=1; i<=7; i++)
			{
				string str="resistance" + i.ToString();
				if(data.Contains(str))resData[i-1]=(int)data[str];
			}
			if(data.Contains("delay"))delay=(int)data["delay"];

			SetUpdateValue(UpdateFields.ITEM_FIELD_STACK_COUNT, stackcount);
			SetUpdateValue(UpdateFields.ITEM_FIELD_FLAGS, flags);
			SetUpdateValue(UpdateFields.ITEM_FIELD_DURABILITY, (uint)durability);
			SetUpdateValue(UpdateFields.ITEM_FIELD_MAXDURABILITY, (uint)mdurability);
			return true;
		}

		public virtual byte[] GetSaveData()
		{
			ByteArrayBuilder pack=new ByteArrayBuilder();
			pack.Add(mdurability).Add(durability).Add(stackcount).Add(flags).Add((uint)0);
			return pack;
		}

		public virtual void SendCreateItem(Character c)
		{
			UpdateMask mask=new UpdateMask();
			BuildCreateMask(mask, true);
			c.SendUpdate( BuildUpdate(mask, UpdateType.All, false) );
		}

		public virtual void SendUpdateItem(Character c)
		{
			if(updateMask.Count==0)return;
			c.SendUpdate( BuildUpdate(updateMask, UpdateType.Value, false) );
		}

		public void SendUpdateItem(ArrayList us)
		{
			if(updateMask.Count==0)return;
			byte[] b=BuildUpdate(updateMask, UpdateType.Value, false);
			foreach(Character c in us)
			{
				c.SendUpdate(b);
			}
		}

		public virtual void GetSaveData(ByteArrayBuilder data)
		{
		}

		public Hashtable GetData(uint entry)
		{
			return gameServer.DB.items.Get( String.Format("item {0}", entry) );
		}

		public Item Create(Character c, uint entry, ByteArrayBase data)
		{
			Hashtable r=GetData(entry);
			if(r==null)return null;

			Item p=null;
			if(r.Contains("containerslots"))
			{
				p=new Container(gameServer);
			} 
			else 
			{
				p=new Item(gameServer);
			}
			p.Entry=entry;
			if( p.Create( c, r, data) ) return p;
			return null;
		}

		public override void BuildCreateMask(UpdateMask mask, bool myself)
		{
			base.BuildCreateMask(mask, myself);
			mask.Touch(
				UpdateFields.ITEM_FIELD_OWNER,
				UpdateFields.ITEM_FIELD_OWNER+1,
				UpdateFields.ITEM_FIELD_CONTAINED,
				UpdateFields.ITEM_FIELD_CONTAINED+1,
				UpdateFields.ITEM_FIELD_STACK_COUNT,
				UpdateFields.ITEM_FIELD_DURABILITY,
				UpdateFields.ITEM_FIELD_MAXDURABILITY,
				UpdateFields.ITEM_FIELD_FLAGS);
		}

		public WORN WornType 
		{
			get 
			{
				return wornType;
			}
		}

		public byte Quality 
		{
			get 
			{
				return quality;
			}
		}

		public uint Model 
		{
			get 
			{
				return model;
			}
		}
	}

	public class ItemHandler 
	{
		public ItemHandler(PlayerConnection c)
		{
			c.AddHandler(OP.CMSG_SWAP_INV_ITEM, new DoMessageFunction(SwapInv), c.player);
			c.AddHandler(OP.CMSG_SWAP_ITEM, new DoMessageFunction(Swap), c.player);
			c.AddHandler(OP.CMSG_DESTROYITEM, new DoMessageFunction(Destroy), c.player);
			c.AddHandler(OP.CMSG_AUTOEQUIP_ITEM, new DoMessageFunction(AutoEquip), c.player);
			c.AddHandler(OP.CMSG_AUTOSTORE_BAG_ITEM, new DoMessageFunction(AutoStoreBag), c.player);
		}

		void SwapInv(OP code, PlayerConnection c)
		{
			byte srcSlot, destSlot;
			c.Seek(2).Get(out srcSlot).Get(out destSlot);

			c.Log("{0} {1} -> {2}", code, srcSlot, destSlot);
			c.player.SwapItem( SlotID.CHARACTER, (SlotID)srcSlot, SlotID.CHARACTER, (SlotID)destSlot );
		}

		void Swap(OP code, PlayerConnection c)
		{
			byte srcBag, srcSlot, destBag, destSlot;
			c.Seek(2).Get(out destBag).Get(out destSlot).Get(out srcBag).Get(out srcSlot);

			c.Log("{0} {1}.{2} -> {3}.{4}", code, srcBag, srcSlot, destBag, destSlot);

			c.player.SwapItem( (SlotID)srcBag, (SlotID)srcSlot, (SlotID)destBag, (SlotID)destSlot );
		}

		void Destroy(OP code, PlayerConnection c)
		{
			c.Log("{0} {1}", code, c.InputLength);
		}

		void AutoEquip(OP code, PlayerConnection c)
		{
			byte srcBag, srcSlot;
			c.Seek(2).Get(out srcBag).Get(out srcSlot);

			c.Log("{0} {1}.{2}", code, srcBag, srcSlot);

			c.player.AutoEquipItem( (SlotID)srcBag, (SlotID)srcSlot);
		}

		void AutoStoreBag(OP code, PlayerConnection c)
		{
			byte srcBag, srcSlot, destBag;
			c.Seek(2).Get(out srcBag).Get(out srcSlot).Get(out destBag);

			c.Log("{0} {1}.{2} -> {3}", code, srcBag, srcSlot, destBag);

			c.player.SwapItem( (SlotID)srcBag, (SlotID)srcSlot, (SlotID)destBag, SlotID.CHARACTER );
		}

	};

}
