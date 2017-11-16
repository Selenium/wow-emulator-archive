using System;
using System.Collections;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace eWoW
{
	public class Character : Unit , IContainer
	{
		PlayerConnection conn = null;
		ulong  curTarget;
		ulong  curSelection;
		// ulong  loot;

		uint   xp = 1;
		uint   restxp = 0;
		byte   skin,face,hairStyle,hairColor,facialHair,outfitId;

		byte[] tutorialFlags = new byte[ 32 ];

        const uint INVCOUNT = (UpdateFields.PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + 2 - UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD) / 2;
		public Item[] items = new Item[INVCOUNT];

		public Character(GameServer gs) : base (gs)
		{
			gameServer = gs;
			Type|=(ushort)TYPE.PLAYER;
		}

		uint nextItemGUID = 0;
		public ulong NextGUID()
		{
			return (GUID << Const.GUID_BITS) + (++nextItemGUID);
		}

		public PlayerConnection Conn
		{
			get
			{
				return conn;
			}
		}

		public bool InWorld()
		{
			return conn != null && conn.player != null;
		}

		#region REGEN
		int tickRemove=0;
		public override void Regen()
		{
			if(tickRemove>0 && tickRemove<Const.Tick)  // should exit world
			{
				if(conn!=null)
				{
					conn.player = null;  // logout
					conn=null;
					gameServer.SaveCharacter(Name, GetSaveData());
				}
				gameServer.DelObj(this);
				return;
			}

			base.Regen();
		}
		#endregion

		#region ITEM
		public Item GetItem(ulong guid)
		{
			for(int i=0; i<items.Length; i++)
			{
				if(items[i]==null)continue;
				if(items[i].GUID==guid)return items[i];
				if(items[i] is Container)
				{
					Item p=((Container)items[i]).GetItem(guid);
					if(p!=null)return p;
				}
			}
			return null;
		}

		public Item GetItem(SlotID slot)
		{
			if((int)slot>=items.Length)return null;
			return items[(int)slot];
		}

		public SlotID ItemCount
		{
			get
			{
				return (SlotID)items.Length;
			}
		}

		SlotID WornSlot(WORN type)
		{
			switch(type)
			{
				case WORN.HEAD: return SlotID.HEAD;
				case WORN.NECK: return SlotID.NECK; 
				case WORN.SHOULDER: return SlotID.SHOULDERS; 
				case WORN.SHIRT: return SlotID.SHIRT; 
				case WORN.CHEST: return SlotID.CHEST; 
				case WORN.WAIST: return SlotID.WAIST; 
				case WORN.PANTS: return SlotID.LEGS; 
				case WORN.BOOTS: return SlotID.FEET; 
				case WORN.BRACERS: return SlotID.WRISTS; 
				case WORN.HAND: return SlotID.HANDS; 
				case WORN.FINGER: return SlotID.FINGERL; 
				case WORN.TRINKET: return SlotID.TRINKETL; 

				case WORN.ROBE:
				case WORN.BACK: 
					return SlotID.BACK; 

				case WORN.MAINHAND:
				case WORN.H2:
				case WORN.H1:
					return SlotID.MAINHAND; 

				case WORN.OFFHAND:
				case WORN.SHIELD:
					return SlotID.OFFHAND;

				case WORN.RANGED: 
				case WORN.RANGEDRIGHT: 
				case WORN.THROWN:
					return SlotID.RANGED; 

				case WORN.TABARD: return SlotID.TABARD; 
			}
			return SlotID.BANK;
		}


		public ulong GetItemGUID(SlotID slot)
		{
			if((int)slot>=items.Length)return 0;
			if(items[(int)slot]==null)return 0;
			return items[(int)slot].GUID;
		}

		bool AddItem( ByteArrayBase data )
		{
			byte slot;
			uint id;
			ushort len;

			data.Get(out slot).Get(out id).Get(out len);

			ByteArray b=null;
			if(len>0)b=new ByteArray(data.GetArray(len));
			Item n = new Item( gameServer );
			n= n.Create( this, id, b );
			if(n==null)return false;
			return AddItem((SlotID)slot, n);
		}

		byte[] GetItemsSaveData()
		{
			ByteArrayBuilder pack=new ByteArrayBuilder();
			for(int i=0; i<items.Length; i++)
			{
				if(items[i]==null)continue;
				pack.Add( (byte)i ).Add(items[i].Entry);

				int pos=pack.Length;
				pack.Add((ushort)0);
				pack.Add( items[i].GetSaveData() );
				pack.Set(pos, (ushort)(pack.Length-pos-2) );
			}
			return pack;
		}

		bool AddItem(SlotID slot, Item item)
		{
			UpdateMask mask=new UpdateMask();
			item.BuildCreateMask(mask, true);
			SendUpdate( item.BuildUpdate(mask, UpdateType.All, false) );

			items[(int)slot]=item;

			SetUpdateValue(UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + (ushort)((int)slot*2), item.GUID);
			return true;
		}

		ulong itemErrorGUID1;
		ulong itemErrorGUID2;
		public bool ItemError(ItemErrorNo no)
		{
			ByteArrayBuilder pack=new ByteArrayBuilder(false);
			pack.Add((byte)no);
			pack.Add(itemErrorGUID1);
			pack.Add(itemErrorGUID2);
			pack.Add((byte)0);
			Send(OP.SMSG_INVENTORY_CHANGE_FAILURE, pack);
			return false;
		}

		public bool AddItem(uint id)
		{
			itemErrorGUID1=itemErrorGUID2=0;

			Item n = new Item( gameServer );
			n =  n.Create(this, id, null);
			if(n==null)
			{
				return ItemError(ItemErrorNo.NEVER);
			}
			itemErrorGUID1=n.GUID;

			// find a empty bag & slot
			SlotID slot;
			IContainer srcBag=this;
			for(slot=SlotID.INBACKPACK; slot<SlotID.BANK; slot++)
			{
				if(srcBag.GetItem(slot) == null)break;
			}
			if(slot==SlotID.BANK)
			{
				for(SlotID bag=SlotID.BAG1; bag<=SlotID.BAG4; bag++)
				{
					if( GetItem(bag) == null )continue;
					srcBag=GetItem(bag) as IContainer;

					for(slot=0; slot<srcBag.ItemCount; slot++)
					{
						if( srcBag.GetItem(slot) == null )break;
					}
					if(slot < srcBag.ItemCount)break;
					slot=SlotID.BANK;
				}
			}
			if(slot==SlotID.BANK)return ItemError(ItemErrorNo.ITEM_TOO_MANY);

			UpdateMask mask = new UpdateMask();
			n.BuildCreateMask(mask, true);
			SendUpdate( n.BuildUpdate(mask, UpdateType.All, false) );

			srcBag.SetItem(slot, n);
			return true;
		}

		public bool AutoEquipItem(SlotID srcBagID, SlotID srcSlot)
		{
			itemErrorGUID1=itemErrorGUID2=0;

			IContainer srcBag=this;
			if(srcBagID!=SlotID.CHARACTER)
			{
				if( items[ (int)srcBagID ] == null )
				{
					return ItemError(ItemErrorNo.NOT_A_BAG);
				}
				itemErrorGUID1=items[ (int)srcBagID ].GUID;
				if( ! (items[ (int)srcBagID ] is IContainer) )
				{
					return ItemError(ItemErrorNo.NOT_A_BAG);
				}
				srcBag=items[ (int)srcBagID ] as IContainer;
			}
			if(srcSlot>=srcBag.ItemCount)
			{
				return ItemError(ItemErrorNo.WRONG_SLOT);
			}

			Item n=srcBag.GetItem(srcSlot);
			if(n==null)
			{
				return ItemError(ItemErrorNo.WRONG_EQ_SLOT);
			}
			itemErrorGUID1=n.GUID;

			SlotID destSlot=WornSlot(n.WornType);
			if(destSlot==SlotID.BANK)
			{
				return ItemError(ItemErrorNo.NEVER);
			}
			return SwapItem(srcBagID, srcSlot, SlotID.CHARACTER, destSlot);
		}

        public ItemErrorNo SetItem(eWoW.SlotID id, Item newItem)
		{
			if((int)id>=items.Length)return ItemErrorNo.WRONG_SLOT;

			if(newItem!=null)
			{
				if( (id>=SlotID.BAG1 && id<=SlotID.BAG4) || (id>=SlotID.BANKBAGS) )
				{
					if(!newItem.IsType(TYPE.CONTAINER))return ItemErrorNo.NOT_A_BAG;
				}

				if( newItem is IContainer && id>SlotID.BAG4)
				{
					IContainer p=newItem as IContainer;
					for(SlotID i=0; i<p.ItemCount; i++)
					{
						if(p.GetItem(i)!=null)return ItemErrorNo.BAG_IN_BAG;
					}
				}

				if( id<SlotID.BAG1 )  // equip
				{ 
					SlotID expect=WornSlot(newItem.WornType);

					if(expect==SlotID.BANK && id<SlotID.BAG1)
						return ItemErrorNo.WRONG_EQ_SLOT;
					if(expect != id)
					{
						bool ok=false;
						if(expect==SlotID.FINGERL && id==SlotID.FINGERR)ok=true;
						if(expect==SlotID.TRINKETL && id==SlotID.TRINKETR)ok=true;
						if(newItem.WornType==WORN.H1 && id==SlotID.OFFHAND)ok=true;
						if(!ok)return ItemErrorNo.WRONG_EQ_SLOT;
					}
					if(newItem.WornType==WORN.H2 && id==SlotID.MAINHAND)  // check offhand
					{
						if( items[(int)SlotID.OFFHAND] != null )
						{
							return ItemErrorNo.WRONG_EQ_SLOT;
						}
					}
				}
			}


			items[(int)id]=newItem;
			if(newItem!=null)
			{
				SetUpdateValue(UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD+(ushort)((byte)id*2), newItem.GUID);
			} 
			else 
			{
				SetUpdateValue(UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD+(ushort)((byte)id*2), (ulong)0);
			}

			if( id<SlotID.BAG1 )UpdateItemStats();
			return ItemErrorNo.NONE;
		}

		public bool SwapItem(SlotID srcBagID, SlotID srcSlot, SlotID destBagID, SlotID destSlot)
		{
			itemErrorGUID1=itemErrorGUID2=0;

			IContainer srcBag=this;
			if(srcBagID!=SlotID.CHARACTER)
			{
				if( items[ (int)srcBagID ] == null )
				{
					return ItemError(ItemErrorNo.NOT_A_BAG);
				}
				itemErrorGUID1=items[ (int)srcBagID ].GUID;
				if( ! (items[ (int)srcBagID ] is IContainer) )
				{
					return ItemError(ItemErrorNo.NOT_A_BAG);
				}
				srcBag=items[ (int)srcBagID ] as IContainer;
			}
			if(srcSlot>=srcBag.ItemCount)
			{
				return ItemError(ItemErrorNo.WRONG_SLOT);
			}
			Item src=srcBag.GetItem(srcSlot);
			itemErrorGUID1=src.GUID;

			IContainer destBag=this;
			if(destBagID!=SlotID.CHARACTER)
			{
				if( items[ (int)destBagID ] == null )
				{
					return ItemError(ItemErrorNo.NOT_A_BAG);
				}
				itemErrorGUID2=items[ (int)destBagID ].GUID;
				if( ! (items[ (int)destBagID ] is IContainer) )
				{
					return ItemError(ItemErrorNo.NOT_A_BAG);
				}
				destBag=items[ (int)destBagID ] as IContainer;
			}
			if(destSlot==SlotID.CHARACTER)
			{
				for(destSlot=0; destSlot<destBag.ItemCount; destSlot++)
				{
					if( destBag.GetItem(destSlot) == null )break;
				}
				if(destSlot == destBag.ItemCount)
				{
					return ItemError(ItemErrorNo.BAG_FULL);
				}
			}
			if(destSlot>=destBag.ItemCount)
			{
				return ItemError(ItemErrorNo.WRONG_SLOT);
			}

			Item dest=destBag.GetItem(destSlot);
			if(dest!=null)itemErrorGUID2=dest.GUID;

			ItemErrorNo n;
			if( (n=srcBag.SetItem(srcSlot, dest)) != ItemErrorNo.NONE )
			{
				return ItemError(n);
			}

			if( (n=destBag.SetItem(destSlot, src)) != ItemErrorNo.NONE )
			{
				srcBag.SetItem(srcSlot, src);
				return ItemError(n);
			}

			SendUpdate();
			return true;
		}

		protected void UpdateItemStats()
		{
			for(int i=0; i<stat.Length; i++)
			{
				stat[i]-=(byte)nstat[i];
			}

			mhealth=(uint)(mhealth-nhealth);
			if(powerType==PowerType.MANA)mpower[0]=(uint)(mpower[0] - nmana);
			nhealth=0;
			nmana=0;

			nstat=new char[5];
			res=new int[7];

			for(SlotID id=0; id<SlotID.BAG1; id++)
			{
				Item p=GetItem(id);
				if(p==null)continue;

				for(int i=0; i<p.resData.Length; i++)
				{
					res[i] += p.resData[i];
				}

				if(p.bonusData!=null)
				{
					for(int i=0; i<p.bonusData.Length/2; i++)
					{
						int idx=p.bonusData[i*2];
						switch(idx)
						{
							case 0: nhealth+=p.bonusData[i*2+1]; break;
							case 1: nmana+=p.bonusData[i*2+1]; break;
							case 3: nstat[1]+=(char)p.bonusData[i*2+1]; break;
							case 4: nstat[0]+=(char)p.bonusData[i*2+1]; break;
							case 5: nstat[3]+=(char)p.bonusData[i*2+1]; break;
							case 6: nstat[4]+=(char)p.bonusData[i*2+1]; break;
							case 7: nstat[2]+=(char)p.bonusData[i*2+1]; break;
						}
					}
				}
			}

			for(int i=0; i<stat.Length; i++)
			{
				stat[i]+=(byte)nstat[i];
			}

			for(ushort i=0; i<res.Length; i++)
			{
				SetUpdateValue(UpdateFields.UNIT_FIELD_RESISTANCES + i, (uint)res[i]);
			}

			for(ushort i=0; i<nstat.Length; i++)
			{
				SetUpdateValue(UpdateFields.PLAYER_FIELD_POSSTAT0 + i, (uint)(int)nstat[i]);
				SetUpdateValue(UpdateFields.UNIT_FIELD_STAT0 + i, (uint)stat[i]);
			}

			Item sword=GetItem(SlotID.MAINHAND);
			if(sword==null || sword.damageData==null)
			{
				minDamage=stat[0]/5;
				maxDamage=stat[0]/5 + 1;
				attackTime0=3000;
				attackTime1=3000;
			} 
			else 
			{
				minDamage=0;
				maxDamage=0;
				for(int i=0; i<sword.damageData.Length/3; i++)
				{
					if(sword.damageData[i*3]==0)
					{
						minDamage=sword.damageData[i*3+1];
						maxDamage=sword.damageData[i*3+2];
					}
				}

				minDamage+=stat[0]/5;
				maxDamage+=stat[0]/5 + 1;
				attackTime0=(uint)sword.delay;
				attackTime1=(uint)sword.delay;
			}

			attack=(uint)( level + (stat[1] + nstat[1])*2 );

			mhealth=(uint)(mhealth + nhealth);
			if(health>mhealth)health=mhealth;

			if(powerType==PowerType.MANA)
			{
				mpower[0]=(uint)(mpower[0]+nmana);
				if(power[0]>mpower[0])power[0]=mpower[0];
			}


			SetUpdateValue(UpdateFields.UNIT_FIELD_HEALTH, health);
			SetUpdateValue(UpdateFields.UNIT_FIELD_MAXHEALTH, mhealth);

			SetUpdateValue(UpdateFields.UNIT_FIELD_ATTACKPOWER, attack);
			
			SetUpdateValue( (UpdateFields)(UpdateFields.UNIT_FIELD_POWER1+(ushort)powerType), power[(int)powerType]);
			SetUpdateValue( (UpdateFields)(UpdateFields.UNIT_FIELD_MAXPOWER1+(ushort)powerType), mpower[(int)powerType]);

			SetUpdateValue(UpdateFields.UNIT_FIELD_BASEATTACKTIME, attackTime0);
			SetUpdateValue(UpdateFields.UNIT_FIELD_BASEATTACKTIME+1, attackTime1);

			SetUpdateValueFloat(UpdateFields.UNIT_FIELD_MINDAMAGE, minDamage);
			SetUpdateValueFloat(UpdateFields.UNIT_FIELD_MAXDAMAGE, maxDamage);
		}
		#endregion

		#region LOGIN/CREATE
		public void GetEnumData(ByteArrayBuilder pack)
		{
			int pos = pack.Length;

			pack.Add( GUID )
				.Add( Name )
				.Add( GetUpdateValue(UpdateFields.UNIT_FIELD_BYTES_0) )
				.Seek( -1 )
				.Add( GetUpdateValue(UpdateFields.PLAYER_BYTES) )
				.Add( (byte)( GetUpdateValue(UpdateFields.PLAYER_BYTES_2) >> 8 ) )
				.Add( (byte)GetUpdateValue(UpdateFields.UNIT_FIELD_LEVEL) )
				.Add( (uint)zoneID, (uint)mapID );

			pack.Add( Pos.x, Pos.y, Pos.z)
				.Add( (uint)0 )  // guildid
				.Add( (byte)1 )  // rest
				.Add( (uint)0 )  // unknown
				.Add( (uint)0, 0, 0);  // petinfoid , petlevel , petfamilyid 

			for(int i=0; i<20; i++)
			{
				if(items[i]==null)
				{
					pack.Add( new byte[5] );
					continue;
				}
				pack.Add( items[i].Model );
				pack.Add( (byte)items[i].WornType );
			}
		}

		public void Login(PlayerConnection c)
		{
			conn = c;
			conn.player = this;
			
			SetMessageHandler();

			Send(OP.SMSG_ACCOUNT_DATA_MD5, new byte[80]);

			ByteArrayBuilder pack = new ByteArrayBuilder(false);
			pack.Add(Pos.x);
			pack.Add(Pos.y);
			pack.Add(Pos.z);
			pack.Add((uint)Zone);
			pack.Add((uint)Map);
			Send(OP.SMSG_BINDPOINTUPDATE, pack);
			pack.Length = 0;

			Send(OP.SMSG_TUTORIAL_FLAGS, tutorialFlags);

			BuildSpellData(pack);
			Send(OP.SMSG_INITIAL_SPELLS, pack);
			pack.Length = 0;

			Send(OP.SMSG_ACTION_BUTTONS, new byte[480]);

			pack.Add( (uint)64 );
			for(int i=0; i<64; i++)
			{
				if(i == 0)
					pack.Add((uint)3);
				else
					pack.Add((uint)1);
				pack.Add((byte)0);
			}
			Send(OP.SMSG_INITIALIZE_FACTIONS, pack);
			pack.Length = 0;

			pack.Add( Const.GetTimeStamp() );
			pack.Add( 0.017f );
			Send(OP.SMSG_LOGIN_SETTIMESPEED, pack);
			pack.Length=0;

			// clear all items update flag
			BuildUpdateForSet();
			updatePacket.Clear();

			BuildCreateMask(updateMask, true);
			SendUpdate( BuildUpdate(updateMask, UpdateType.All, true) );
			SendCreateItems(this, CreateItemType.Self);
			SendUpdate();
			tickRemove = 0;
		}


		bool Create(ByteArrayBase items)
		{
			base.Create();

			while(items.pos<items.Length)
			{
				AddItem( items );
			}

			SetUpdateValue(UpdateFields.UNIT_FIELD_FLAGS, (uint)0x1008); // player

			for(ushort i=0; i<stat.Length; i++)
			{
				SetUpdateValue(UpdateFields.PLAYER_FIELD_POSSTAT0+i, (uint)0);
				SetUpdateValue(UpdateFields.PLAYER_FIELD_NEGSTAT0+i, (uint)0);
			}
			SetUpdateValue(UpdateFields.PLAYER_FIELD_COINAGE, (uint)0);

			SetUpdateValue(UpdateFields.PLAYER_BYTES, (uint)( ((uint)skin) | ((uint)face << 8) | ((uint)hairStyle << 16) | ((uint)hairColor << 24) ));
			SetUpdateValue(UpdateFields.PLAYER_BYTES_2, (uint)((facialHair << 8) + (1 << 24)));

			SetUpdateValue(UpdateFields.PLAYER_XP, xp);
			SetUpdateValue(UpdateFields.PLAYER_NEXT_LEVEL_XP, Script.GetNextLevelXP(this));
			SetUpdateValue(UpdateFields.PLAYER_REST_STATE_EXPERIENCE, restxp);
			SetUpdateValue(UpdateFields.PLAYER_CHARACTER_POINTS1, (uint)0);

			SetUpdateValue(UpdateFields.PLAYER_FIELD_MOD_DAMAGE_DONE_NEG, (uint)0);
			SetUpdateValueFloat(UpdateFields.PLAYER_AMMO_ID, (float)1.0);

			UpdateItemStats();

			return true;
		}

		public bool Create(ulong guid, string n, byte[] _data)
		{
			Name = n;
			_guid = guid;

			DBSerial data = new DBSerial( new MemoryStream(_data) );
			Hashtable h = data.Deserialize() as Hashtable;
			if(h == null)
                return false;

			ByteArray b = new ByteArray( h["Base"] as byte[] );
			b.Get(out race).Get(out class_).Get(out gender).
				Get(out skin).Get(out face).Get(out hairStyle).Get(out hairColor).Get(out facialHair).Get(out outfitId);

			b = new ByteArray( h["Position"] as byte[] );
			Map = b.GetWord();
			Zone = b.GetWord();
			b.Get(out Pos.x).Get(out Pos.y).Get(out Pos.z).Get(out this.Orientation);

			tutorialFlags = h["TutorialFlags"] as byte[];
			stat = h["Stat"] as byte[];

			b = new ByteArray( h["Power"] as byte[] );
			powerType = (PowerType)b.GetByte();
			b.Get(out mpower[0]).Get(out mpower[1]).Get(out mpower[2]).Get(out mpower[3]).Get(out mpower[4]).
				Get(out power[0]).Get(out power[1]).Get(out power[2]).Get(out power[3]).Get(out power[4]);

			b = new ByteArray( h["Health"] as byte[] );
			b.Get(out mhealth).Get(out health);

			b = new ByteArray( h["Attack"] as byte[] );
			b.Get(out attack).Get(out minDamage).Get(out maxDamage).Get(out attackTime0).Get(out attackTime1);

			displayID = (uint)(int)h["DisplayID"];
			level = (uint)(int)h["Level"];
			xp = (uint)(int)h["XP"];
			restxp = (uint)(int)h["RestXP"];

			uint logouttm = (uint)(int)h["TimeStamp"];
			logouttm = Const.GetTimeStamp() - logouttm;
			if(logouttm > 3 * 24 * 60)
                logouttm = 3 * 24 * 60;

			uint maxxp = Script.GetNextLevelXP(this);

			restxp += (logouttm * maxxp) / 3*24*60;
			if(restxp > maxxp)
                restxp = maxxp;
			return Create( new ByteArray( h["Items"] as byte[] ) );
		}

		public byte[] GetSaveData()
		{
			Hashtable h = new Hashtable();

			ByteArrayBuilder b = new ByteArrayBuilder();

			b.Add(race, class_, gender, skin, face, hairStyle, hairColor, facialHair, outfitId);
			h["Base"] = (byte[])b;
			b.Length = 0;

			b.Add( Map, Zone);
			b.Add( Pos.x, Pos.y, Pos.z, Orientation);
			h["Position"] = (byte[])b;
			b.Length = 0;

			h["TutorialFlags"] = tutorialFlags;

			for(int i=0; i<stat.Length; i++)
			{
				stat[i] -= (byte)nstat[i];
			}
			h["Stat"] = stat;
			for(int i=0; i<stat.Length; i++)
			{
				stat[i] += (byte)nstat[i];
			}

			mhealth=(uint)(mhealth-nhealth);
			if(powerType==PowerType.MANA)mpower[0]=(uint)(mpower[0] - nmana);

			b.Add( (byte)powerType ).
				Add(mpower[0], mpower[1], mpower[2], mpower[3], mpower[4]).
				Add(power[0], power[1], power[2], power[3], mpower[4]);
			h["Power"]=(byte[])b;
			b.Length=0;

			b.Add(mhealth, health);
			h["Health"]=(byte[])b;
			b.Length=0;

			mhealth=(uint)(mhealth+nhealth);
			if(powerType==PowerType.MANA)mpower[0]=(uint)(mpower[0] + nmana);

			b.Add(attack).Add(minDamage, maxDamage).Add(attackTime0).Add(attackTime1);
			h["Attack"]=(byte[])b;
			b.Length=0;

			h["DisplayID"]=(int)displayID;
			h["Level"]=(int)level;
			h["XP"]=(int)xp;
			h["RestXP"]=(int)restxp;
			h["TimeStamp"]=(int)Const.GetTimeStamp();

			h["Items"]=GetItemsSaveData();

			MemoryStream ms=new MemoryStream();
			(new DBSerial( ms )).Serialize(h);
			return ms.ToArray();
		}

		public bool CreateNew(PlayerConnection conn, string n)
		{
			Name = n;
            Console.WriteLine(n);
			conn.Get(out race).Get(out class_).Get(out gender).
				Get(out skin).Get(out face).Get(out hairStyle).Get(out hairColor).Get(out facialHair).Get(out outfitId);

			Console.WriteLine("CMSG_CHAR_CREATE {0}/{1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", 
				conn.userName, n, race, class_, gender, skin, face, hairStyle, hairColor, facialHair, outfitId);

			for(int i=0; i<tutorialFlags.Length; i++)
                tutorialFlags[i] = 0xff;

			Hashtable r = gameServer.DB.classes.Get("race " + race.ToString());
			if(r == null)
				return false;
			else 
			{
				mapID = (ushort)(int)r["startmap"];
				zoneID =(ushort)(int)r["startzone"];

				float[] xyz = r["startpos"] as float[];
				Pos.x = xyz[0];
				Pos.y = xyz[1];
				Pos.z = xyz[2];
				Orientation = xyz[3];

                /*Console.WriteLine("Startmap:" + r["startmap"] );
                Console.WriteLine("startzone:" + r["startzone"]);
                Console.WriteLine("startpos: {0}, {1}, {2}, {3} ", xyz[0], xyz[1], xyz[2], xyz[3]);*/


				int[] sstat = r["startstats"] as int[];
				for(int i=0; i<stat.Length; i++)
				{
					stat[i] = (byte)sstat[i];
				}

				if(gender > 0)
					displayID=(uint)(int)r["bodyfemale"];
				else
					displayID=(uint)(int)r["bodymale"];

				int[] skills=r["skill"] as int[];
				for(int i=0; i<skills.Length-2; i+=3)
				{
					AddSkill( skills[i], skills[i+1], skills[i+2] );
				}

				int[] spells=r["spell"] as int[];
				foreach(int sp in spells)
				{
					AddSpell((uint)sp);
				}
			} 

			r = gameServer.DB.classes.Get("class " + class_.ToString());
			if(r!=null)
			{
				int[] sstat=r["startstats"] as int[];
				for(int i=0; i<stat.Length; i++)
				{
					stat[i]+=(byte)sstat[i];
				}

				health=mhealth=(uint)(int)r["health"];

				int[] maxpowers=r["maxpowers"] as int[];
				for(int i=0; i<mpower.Length; i++)
				{
					power[i]=mpower[i]=(uint)maxpowers[i];
					if(power[i]>0)powerType=(PowerType)i;
				}

				int[] attackTime=r["attacktime"] as int[];
				attackTime0=(uint)attackTime[0];
				attackTime1=(uint)attackTime[1];

				// ...

				int[] skills=r["skill"] as int[];
				for(int i=0; i<skills.Length-2; i+=3)
				{
					AddSkill( skills[i], skills[i+1], skills[i+2] );
				}

				int[] spells=r["spell"] as int[];
				foreach(int sp in spells)
				{
					AddSpell((uint)sp);
				}
			} 
			else 
			{
				return false;
			}
			r = gameServer.DB.classes.Get( String.Format("startitems {0} {1}", race, class_) );
			if(r == null)
                return false;

			ByteArrayBuilder items = new ByteArrayBuilder();
			int[] its=r["item"] as int[];
			for(int i=0; i<its.Length-1; i+=2)
			{
				items.Add( (byte)its[i] );   // slot
				items.Add( (uint)its[i+1] ); // entry
				items.Add( (ushort)0 );  // addition data
			}
			items.pos=0;
			return Create( (ByteArrayBase)items );
		}

		#endregion 

		#region QUEST
		public UpdateFields GetEmptyQuestSlot()
		{
			return GetQuestSlot(0);
		}

		void SetQuestLogBits()
		{
		}

		public UpdateFields GetQuestSlot(uint quest)
		{
			for(UpdateFields c=UpdateFields.PLAYER_QUEST_LOG_1_1; c<=UpdateFields.PLAYER_QUEST_LOG_1_1 + 60; c += 3)
			{
				if( GetUpdateValue(c) == quest) return c;
			}
			return UpdateFields.OBJECT_FIELD_GUID;
		}
		#endregion

		#region UPDATE
		public override void BuildCreateMask(UpdateMask mask, bool myself)
		{
			base.BuildCreateMask(mask, myself);
			if(myself)
			{
				mask.Touch(
					UpdateFields.PLAYER_XP ,                 
					UpdateFields.PLAYER_NEXT_LEVEL_XP,
					UpdateFields.PLAYER_REST_STATE_EXPERIENCE ,         
					UpdateFields.PLAYER_FIELD_COINAGE,
					UpdateFields.PLAYER_FIELD_MOD_DAMAGE_DONE_NEG,
					UpdateFields.PLAYER_AMMO_ID);

				uint u=GetUpdateValue(UpdateFields.UNIT_FIELD_FLAGS);
				SetUpdateValue(UpdateFields.UNIT_FIELD_FLAGS, u | 8, mask); // control player

				for(ushort i=0; i<nstat.Length; i++)
				{
					mask.Touch(UpdateFields.PLAYER_FIELD_POSSTAT0 + i);
				}
			} 
			else 
			{
				uint u=GetUpdateValue(UpdateFields.UNIT_FIELD_FLAGS);
				SetUpdateValue(UpdateFields.UNIT_FIELD_FLAGS, u & 0xfffffff7, mask); // not control player
			}
			mask.Touch(
				UpdateFields.PLAYER_BYTES,
				UpdateFields.PLAYER_BYTES_2 ,
				UpdateFields.PLAYER_BYTES_3 ,
				UpdateFields.UNIT_FIELD_ATTACKPOWER,
				UpdateFields.UNIT_FIELD_MINDAMAGE,
				UpdateFields.UNIT_FIELD_MAXDAMAGE,
				UpdateFields.UNIT_FIELD_BASEATTACKTIME,
				UpdateFields.UNIT_FIELD_BASEATTACKTIME+1
				);
			for(ushort i=0; i<res.Length; i++)
			{
				mask.Touch(UpdateFields.UNIT_FIELD_RESISTANCES + i);
			}
		}


		ArrayList updatePacket=new ArrayList();
		public void SendUpdate(byte[] b)
		{
			if(conn==null)
			{
				updatePacket.Clear();
				return;
			}
			updatePacket.Add(b);
		}

		public void SendCreateItems(Character carry, CreateItemType type)
		{
			SlotID start=0;
			SlotID stop=SlotID.BANK;

			if(type == CreateItemType.Other)
			{
				stop=SlotID.INBACKPACK;
			}
			if(type == CreateItemType.Bank)
			{
				start=SlotID.BANK;
				stop=(SlotID)items.Length;
			}

			UpdateMask imask=new UpdateMask();
			while(start<stop)
			{
				Item item=carry.items[(int)start];
				if(item!=null)
				{
					item.SendCreateItem(this);

					imask.Touch(UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + (ushort)((int)start*2));
					imask.Touch(UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + (ushort)((int)start*2+1));
				}
				start++;
			}
			SendUpdate( carry.BuildUpdate(imask, UpdateType.Value, false) );
		}

		public void BuildUpdateForSet()
		{
			ArrayList us=MessageChatGetSet(CHAT.SAY, null);

			for(int i=0; i<(int)SlotID.INBACKPACK; i++)
			{
				if(items[i]==null)continue;
				items[i].SendUpdateItem(us);
			}

			// add group member

			// send all
			if(updateMask.Count == 0)
                return;

			byte[] b = BuildUpdate(updateMask, UpdateType.Value, false);
			foreach(Character c in us)
			{
				c.SendUpdate(b);
			}
		}

		public void SendUpdate()
		{
			SendUpdate(true);
		}

		public void SendUpdate(bool bBuild)
		{
            
            if(bBuild)BuildUpdateForSet();
			if(updatePacket.Count == 0)
                return;

			ByteArrayBuilder pack = new ByteArrayBuilder(false);
			pack.Add( new byte[5] );

			int cnt = 0;
			foreach(byte[] b in updatePacket)
			{
				pack.Add(b);
				cnt++;
				if(pack.Length > 32000)
                    break;
			}
			updatePacket.RemoveRange(0, cnt);
			pack.Set(0, (ushort)cnt);

			byte[] data = pack;
		    if(data.Length>400)  // need compress?
			{
				
               /*/ ICSharpCode.SharpZipLib.Zip.Compression.Deflater deflater = new ICSharpCode.SharpZipLib.Zip.Compression.Deflater();
				deflater.SetInput(data);
				deflater.Finish();

				byte[] cdata = new byte[data.Length];
				int len = deflater.Deflate(cdata);

                Console.WriteLine(len);
                Console.WriteLine(data.Length);
				pack.Length = 0;
            //    pack = new ByteArrayBuilder(false);
                pack.Add((uint)data.Length / 8);
                for (int i = 0; i < len; i++)
                    pack.Add(cdata[i]);
                Console.WriteLine(pack.Length);
                */
                
				// Well, it works.... :-)
				byte[] temp = { 163, 4,  0,  0,  120,  156,  99,  99,  0,
								  2,  38, 38,32,193,8,197,120,128,130,3,3,195,
								  3,7,16,93,36,51,29,72,
								  55,56,220,225,247,116,96,192,162,145,
								  233,190,63,148,1,149,100,6,98,46,176, 
								  72,131,61,55,84,17,55,154,38,
								  144,58,38,102,154,57,5,102,50,51,
								  220,106,2,78,97,161,153,83,96,38,131,
								  156,194,67,140,83,96,12,234,59,5,38,201,
								  12,87,68,192,41,48,103,80,223,41,48,
								  83,65,78,97,34,198,41,48,65,
								  22,152,232,5,9,238,99,167,140,12,14,
								  31, 82,95,236,116,212,203,213,1,159,83,
								  176,249,65,81,158,193,57,80,198,1,
								  33,112,99,62,195,207,253,12,15,56,17,34,28,12,12,14,
								  13,48,78,3,216,4,30,126,6,27,20,99,14,
								  48,144,8,64,62,102,248,3,229,192,124,37,9,151,110,176,
								  135,177,108,208,104,120,100,0,1,136,
								  159,195,14,193,198,198,198,64,61,11,
								  236,141,128,98,70,8,123,28,64,158,135,113,196,129,88,4,136,197,160,180,8,
								  204,33,88,0,114,240,51,50,176,179,2,9,102,
								  193,111,79,153,184,160,114,60,12,136,
								  132,138,156,229,65,52,44,177,163,184,
								  23,202,127,129,100,97,10,14,187,1,224,91,68,126
							  };
			pack = new ByteArrayBuilder();
             pack.Add(temp);
				Send(OP.SMSG_COMPRESSED_UPDATE_OBJECT, pack);
			} 
			else 
			{
				Send(OP.SMSG_UPDATE_OBJECT, data);
			}
		}
		public void Send(OP code, byte[] data)
		{
			if(conn != null)
                conn.Send(code, data);
		}

		#endregion

		#region MESSAGE_HANDLER


		void SetMessageHandler()
		{
			gameServer.Channel.Set(this);
			new QueryHandler(gameServer, conn);
			new ItemHandler(conn);
			new MovementHandler(conn);

			conn.AddHandler(OP.CMSG_LOGOUT_REQUEST, new DoMessageFunction(DoLogoutRequest), this);
			conn.AddHandler(OP.CMSG_PLAYER_LOGOUT, new DoMessageFunction(DoLogoutConfirm), this);
			conn.AddHandler(OP.CMSG_LOGOUT_CANCEL, new DoMessageFunction(DoLogoutCancel), this);
			conn.AddHandler(OP.CMSG_SET_TARGET, new DoMessageFunction(DoSetSelection), this);
			conn.AddHandler(OP.CMSG_SET_SELECTION, new DoMessageFunction(DoSetSelection), this);

			conn.AddHandler(OP.CMSG_ATTACKSWING, new DoMessageFunction(DoAttackSwing), this);
			conn.AddHandler(OP.CMSG_ATTACKSTOP, new DoMessageFunction(DoAttackStop), this);
			conn.AddHandler(OP.CMSG_UPDATE_ACCOUNT_DATA, new DoMessageFunction(DoUpdateAccountData), this);
		}


		void DoSetSelection(OP code, PlayerConnection c)
		{
			if(code==OP.CMSG_SET_TARGET)
			{
				c.Seek(2).Get( out curTarget );
				// this.SetUpdateValue( UpdateFields.UNIT_FIELD_TARGET, curTarget);
				return;
			}
			if(code==OP.CMSG_SET_SELECTION)
			{
				c.Seek(2).Get( out curSelection );
				gameServer.LogMessage("DoSetSelection code: " + code + " selection: " + curSelection );
			}
		}

		void DoLogoutRequest(OP code, PlayerConnection c)
		{
			gameServer.LogMessage("LogoutRequest name: " + Name + " code: " + code);
            Send(OP.SMSG_LOGOUT_RESPONSE, new byte[5]);

            // need sit
            SetUpdateValue(UpdateFields.UNIT_NPC_EMOTESTATE, (uint)UnitStandState.SITTING);
            c.SetTimeoutFunction("DoLogoutRequest", 0 * 1000, new TimerFunction(LogoutTimeOK)); // Cislo predkrat urcuje za kolik sekund se odhlasi
		}

        void LogoutTimeOK()
        {
            if (conn != null) DoLogoutConfirm(OP.SMSG_LOGOUT_COMPLETE, conn);
        }

		void DoLogoutConfirm(OP code, PlayerConnection c)
		{
			// a player wants to leave so his data needs to be saved and the game needs to quit.
			//  (Character) c.player
			gameServer.LogMessage("LogoutConfirm name: " + Name + " code: " + code);
			gameServer.Channel.Logout(Conn);
			Send(OP.SMSG_LOGOUT_COMPLETE, new byte[0]);
			tickRemove=Const.Tick+3*1000;
			c.RemoveHandler(this);
		}

		public void LogoutCancel()
		{
			if(conn.HaveTimer("DoLogoutRequest"))
			{
				Send(OP.SMSG_LOGOUT_CANCEL_ACK, new byte[0]);
				conn.DeleteTimer("DoLogoutRequest");
			}
		}

		void DoLogoutCancel(OP code, PlayerConnection c)
		{
			gameServer.LogMessage("LogoutCancel name: " + Name + " code:" + code);

			SetUpdateValue(UpdateFields.UNIT_NPC_EMOTESTATE, (uint)UnitStandState.STANDING);

			Send(OP.SMSG_LOGOUT_CANCEL_ACK, new byte[0]);
			c.DeleteTimer("DoLogoutRequest");
		}

		public void OnDisconnect()
		{
			gameServer.Channel.Logout(Conn);
			tickRemove=Const.Tick+30*1000;
		}
		#endregion

		#region COMBAT

		public override void StopCombat()
		{
					
		}

		void DoAttackSwing(OP code, PlayerConnection c)
		{
			
		}

		void DoAttackStop(OP code, PlayerConnection c)
		{
		}

		void DoUpdateAccountData(OP code, PlayerConnection c)
		{
			
			/* Must "translate" from Wowdaemon
			 * 
			 * if(client.Character == null)
				return true;
			uint type = data.ReadUInt32();
			int len = data.ReadInt32();
			string conf = string.Empty;
			if(len > 0)
			{
				try
				{
					byte[] compressed = data.ReadBytes((int)(data.BaseStream.Length-data.BaseStream.Position));
					Inflater inflater = new Inflater();
					inflater.SetInput(compressed);
					byte[] decompressed = new byte[len];
					inflater.Inflate(decompressed);
					conf = System.Text.ASCIIEncoding.ASCII.GetString(decompressed);
				}
				catch(Exception e)
				{
					Console.WriteLine("Failed to decompress config type " + type + ": " + e.Message);
					return true;
				}
			}
			switch(type)
			{
				case 0:
					client.Character.UIConfig0 = conf;
					client.Character.Dirty = true;
					break;
				case 1:
					client.Character.UIConfig1 = conf;
					client.Character.Dirty = true;
					break;
				case 2:
					client.Character.UIConfig2 = conf;
					client.Character.Dirty = true;
					break;
				case 3:
					client.Character.UIConfig3 = conf;
					client.Character.Dirty = true;
					break;
				case 4:
					client.Character.UIConfig4 = conf;
					client.Character.Dirty = true;
					break;
				default:
					Console.WriteLine("Unknown config type: " + type);
					Console.WriteLine(conf);
					return true;
			}
			DataServer.Database.SaveObject(client.Character);
			return true;*/
		}
	}
}

		#endregion

