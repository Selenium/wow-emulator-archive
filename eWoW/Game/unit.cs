using System;
using System.Collections;

namespace eWoW
{

	public class Unit : ObjWithPosition
	{
		//public GameServer gameServer;
		public Unit(GameServer gs) : base(gs)
		{
			gameServer = gs;
			Type|=(ushort)TYPE.UNIT;
		}

		protected void Create()
		{
			if(GUID==0)
				base.Create( gameServer.NextGUID() );
			else
				base.Create( 0 );

			SetUpdateValue(UpdateFields.UNIT_FIELD_DISPLAYID, displayID);
			SetUpdateValue(UpdateFields.UNIT_FIELD_NATIVEDISPLAYID, displayID);

			SetUpdateValue(UpdateFields.UNIT_FIELD_HEALTH, health);
			SetUpdateValue(UpdateFields.UNIT_FIELD_MAXHEALTH, mhealth);
			
			SetUpdateValue( (UpdateFields)(UpdateFields.UNIT_FIELD_POWER1+(ushort)powerType), power[(int)powerType]);
			SetUpdateValue( (UpdateFields)(UpdateFields.UNIT_FIELD_MAXPOWER1+(ushort)powerType), mpower[(int)powerType]);

			SetUpdateValue(UpdateFields.UNIT_FIELD_LEVEL, level);

			if(GetUpdateValue(UpdateFields.UNIT_FIELD_FACTIONTEMPLATE)==0)
				SetUpdateValue(UpdateFields.UNIT_FIELD_FACTIONTEMPLATE, (uint)1 );

			SetUpdateValue(UpdateFields.UNIT_FIELD_BYTES_0, (uint)( ( race ) + ( class_ << 8 ) + ( gender << 16 ) + ((uint)(powerType)<<24) ) );

			for(ushort i=0; i<stat.Length; i++)
			{
				SetUpdateValue(UpdateFields.UNIT_FIELD_STAT0+i, stat[i]);
			}

			SetUpdateValue(UpdateFields.UNIT_FIELD_BASEATTACKTIME, attackTime0);
			SetUpdateValue(UpdateFields.UNIT_FIELD_BASEATTACKTIME+1, attackTime1);
			SetUpdateValueFloat(UpdateFields.UNIT_FIELD_BOUNDINGRADIUS, boundingRadius);
			SetUpdateValueFloat(UpdateFields.UNIT_FIELD_COMBATREACH, combatReach);
			SetUpdateValue(UpdateFields.UNIT_FIELD_FLAGS, (uint)0x1000);
			SetUpdateValue(UpdateFields.UNIT_FIELD_AURASTATE, 2);
			if(!IsType(TYPE.PLAYER))SetUpdateValue(UpdateFields.UNIT_FIELD_BYTES_2, 1);
		}

		public bool Create(uint entry, ushort map, Position pos, float ang, SpawnData spawn)
		{
			Entry       = entry; // asi id monstra
			Map         = map;
			Pos         = pos;
			Orientation = ang;
			spawnPoint  = spawn;

			Hashtable r = gameServer.DB.creatures.Get("creature " + entry.ToString());

			if(r == null)
                return false;

			Name = r["name"] as string;
			displayID = (uint)(int)r["model"];
			if(r.Contains("level"))
			{
				if(r["level"] is int[])
				{
					int[] lvls = r["level"] as int[];
					if(lvls[0] < lvls[1])
						level = (uint)(lvls[0] + Const.rand.Next(lvls[1]-lvls[0]));
					else
						level = (uint)(lvls[1] + Const.rand.Next(lvls[0]-lvls[1]));
				} 
				else 
				{
					level = (uint)(int)r["level"];
				}
			}
			if(r.Contains("npcflags")){
				npcflags = (uint)(int)r["npcflags"];
				SetUpdateValue(UpdateFields.UNIT_NPC_FLAGS, npcflags);
			}

			if(r.Contains("size"))
                SetUpdateValueFloat( UpdateFields.OBJECT_FIELD_SCALE_X, (float)r["size"]);

			if(r.Contains("maxhealth"))
                health = mhealth = (uint)(int)r["maxhealth"];

			if(r.Contains("maxmana"))
                power[0] = mpower[0] = (uint)(int)r["maxmana"];

			if(r.Contains("faction"))
                SetUpdateValue(UpdateFields.UNIT_FIELD_FACTIONTEMPLATE, (uint)(int)r["faction"]);

			Create();
			return true;
		}

		public override void Update()
		{
			if(Const.Tick >= tickLastRegen+1000)
			{
				tickLastRegen = Const.Tick;
				Regen();
			}

		}

		public bool SetPosition(float[] data)
		{
			Pos.x = data[0];
			Pos.y = data[1];
			Pos.z = data[2];
			Orientation = data[3];
			return true;
		}

		public virtual void Regen()
		{
			if(spawnPoint != null && tickAutoMove <= Const.Tick)
			{
				Path path = new Path(); // trida v utility
				float[] movePoint = spawnPoint.spawnDist;

				if(movePoint.Length == 2 && movePoint[0] > 1) // random move
				{
					path.Add(new MapPosition(Pos,0));
					Position pos;
					//while(path.TotalLength() < movePoint[1]*2)
					float dist=0;
					do {
						gameServer.PPoint.GetDest(spawnPoint.map, spawnPoint.point, Const.rand.Next( 6 ), Const.rand.Next( (int)movePoint[0] ), out pos);
						dist = pos.Distance(spawnPoint.point);
					} while(dist > (int)movePoint[0] || dist < 1);
					path.Add(new MapPosition(pos,0));
				} 
				if(movePoint.Length >= 3)
				{

				}
				if(path.Count > 0)
				{
					tickAutoMove = (int)(path.TotalLength()/2.5*1000);
					path.RemoveAt(0);

					ByteArrayBuilder pack = new ByteArrayBuilder(false);
					pack.Add(GUID).Add(Pos.x).Add(Pos.y).Add(Pos.z).Add(Orientation);
					pack.Add(new byte[5]);
					pack.Add((uint)tickAutoMove, (uint)path.Count);
					pack.Add(path.Data());
					SendMessageToSet(OP.SMSG_MONSTER_MOVE, pack, false);

					tickAutoMove+=Const.Tick+1500;

					Pos=path[path.Count-1].Pos;
				}
			}
		}

		public void AddSkill(int id, int level, int maxlevel)
		{
		}

		public void AddSpell(uint id)
		{
		}

		public void BuildSpellData(ByteArrayBuilder pack)
		{
			pack.Add( (byte)0 );
			pack.Add( (ushort)0 );
		}

		public override void BuildCreateMask(UpdateMask mask, bool myself)
		{
			base.BuildCreateMask(mask, myself);
			if(npcflags!=0)mask.Touch(UpdateFields.UNIT_NPC_FLAGS);
			mask.Touch(UpdateFields.UNIT_FIELD_MAXPOWER1 + (ushort)powerType);
			mask.Touch(UpdateFields.UNIT_FIELD_POWER1 + (ushort)powerType);
			mask.Touch(
				UpdateFields.UNIT_FIELD_HEALTH , 
				UpdateFields.UNIT_FIELD_MAXHEALTH  ,
				UpdateFields.UNIT_FIELD_LEVEL  ,            
				UpdateFields.UNIT_FIELD_FACTIONTEMPLATE  ,
				UpdateFields.UNIT_FIELD_BYTES_0 ,
				UpdateFields.UNIT_FIELD_FLAGS,
				UpdateFields.UNIT_NPC_EMOTESTATE,
				UpdateFields.UNIT_FIELD_BASEATTACKTIME ,   
				UpdateFields.UNIT_FIELD_BASEATTACKTIME+1,
				UpdateFields.UNIT_FIELD_BOUNDINGRADIUS,
				UpdateFields.UNIT_FIELD_COMBATREACH,
				UpdateFields.UNIT_FIELD_DISPLAYID,
				UpdateFields.UNIT_FIELD_NATIVEDISPLAYID,
				UpdateFields.UNIT_FIELD_AURASTATE,
				UpdateFields.UNIT_FIELD_MINDAMAGE,
				UpdateFields.UNIT_FIELD_MAXDAMAGE ,
				UpdateFields.UNIT_FIELD_BYTES_1 ,  
				UpdateFields.UNIT_FIELD_MOUNTDISPLAYID,
				UpdateFields.UNIT_FIELD_STAT0  ,
				UpdateFields.UNIT_FIELD_STAT1 ,            
				UpdateFields.UNIT_FIELD_STAT2 ,
				UpdateFields.UNIT_FIELD_STAT3  ,            
				UpdateFields.UNIT_FIELD_STAT4
				);
		}

		public override void UpdateInRange(ICollection allObjs, ArrayList objRemove)
		{
			base.UpdateInRange(allObjs, objRemove);

			ArrayList ego=new ArrayList();
			foreach(Unit p in enemy)
			{
				if(!objectInRange.Contains(p))ego.Add(p);
			}

			foreach(Unit p in ego)
			{
				hate.Remove(p.GUID);
				enemy.Remove(p);
			}

			if(ego.Count>0 && enemy.Count==0)StopCombat();
		}

		public virtual void StopCombat()
		{
		}

		public override bool CanSee(ObjWithPosition ob)
		{
			if(Entry==Const.SpawnPointEntry)return false;  // spawnpoint dont see anyone
			return true;
		}

		#region MESSAGE
		public virtual ArrayList MessageChatGetSet(CHAT mode, string tag)
		{
			ArrayList us=new ArrayList();
			switch(mode)
			{
				case CHAT.SAY:
				case CHAT.MONSTER_SAY:
				case CHAT.EMOTE:
				case CHAT.MONSTER_EMOTE:
				{
					foreach(ObjWithPosition ob in objectInRange)
					{
						if(ob is Character)us.Add(ob);
					}
					us.Add( this );
					break;
				}

				case CHAT.YELL:
				case CHAT.MONSTER_YELL:
					
					break;

				case CHAT.WHISPER:
				{
					
					ulong guid=gameServer.GetCharacter(tag);
					if(guid==0)return null;
					Obj o=gameServer.GetObj(guid);
					if( o is Character)us.Add( o );
					us.Add( this );
					break;
				}

				case CHAT.SYSTEM:
				{
					if(tag==null)return gameServer.GetOnline();
					ulong guid=gameServer.GetCharacter(tag);
					if(guid==0)return null;
					Obj o=gameServer.GetObj(guid);
					if( o is Character)us.Add( o );
					break;
				}

				case CHAT.CHANNEL:
				{
					return gameServer.Channel.MessageChatGetSet(tag);
				}
			}
			return us;
		}

		public bool MessageChat(CHAT mode, uint lang, string text, string target)
		{
			ByteArrayBuilder pack=new ByteArrayBuilder(false);
			pack.Add((byte)mode).Add(lang);

			/* Opravuje to bug s textem za channelem
             * if(mode==CHAT.CHANNEL || mode==CHAT.WHISPER)
			{
				if( target == null)
                    return false;
				pack.Add(target);
			}*/
			pack.Add(GUID);
			pack.Add((uint)(text.Length+1)).Add(text);
			pack.Add((byte)0);

			ArrayList us = MessageChatGetSet(mode, target);
			if(us == null)
			{
				if(target != null)
				{
					MessageChat(CHAT.SYSTEM, lang, String.Format("target \"{0}\" not found", target), Name);
				}
				return false;
			}

			foreach(Character c in us)
			{
				c.Send(OP.SMSG_MESSAGECHAT, pack);
			}
			return true;
		}

        public bool ServerMessage(string text, uint type, Character c)
        {
            ByteArrayBuilder pack = new ByteArrayBuilder();
            pack.Add((byte)type);
            pack.Add((uint)(text.Length));
            pack.Add((byte)1);
            pack.Add(text);
          //  pack.Add((byte)0);
            c.Send(OP.SMSG_SERVER_MESSAGE, pack);
            
            return true;
        }
            /*
            if (mode == CHAT.CHANNEL || mode == CHAT.WHISPER)
            {
                if (target == null)
                    return false;
                pack.Add(target);
            }
            pack.Add(GUID);
            pack.Add((uint)(text.Length + 1)).Add(text);
            pack.Add((byte)0);

            ArrayList us = MessageChatGetSet(mode, target);
            if (us == null)
            {
                if (target != null)
                {
                    MessageChat(CHAT.SYSTEM, lang, String.Format("target \"{0}\" not found", target), Name);
                }
                return false;
            }

            foreach (Character c in us)
            {
                c.Send(OP.SMSG_MESSAGECHAT, pack);
            }
            return true;*/
        

		#endregion

		public uint Level
		{
			get 
			{
				return level;
			}
		}

		public RACE Race 
		{
			get
			{
				return (RACE)race;
			}
		}

		public CLASS Class
		{
			get
			{
				return (CLASS)class_;
			}
		}

		public byte Gender 
		{
			get
			{
				return gender;
			}
		}

		private   SpawnData spawnPoint = null;
		protected uint   npcflags = 0;
		protected float  boundingRadius = 0.39f;
		protected float  combatReach = 1.5f;
         
		protected byte   race,class_,gender;
		protected char[] nstat = new char[5];    // modify
		protected byte[] stat = new byte[5];    // current static

		protected uint[] mpower = new uint[5];  // max
		protected int    nmana = 100;  // modify
		protected uint[] power = new uint[5];
		protected PowerType powerType;

		protected int[]  res = new int[7]; // co to je??

		protected uint   mhealth=100;  // max
		protected int    nhealth=0;    // modify
		protected uint   health=100;

		protected uint   attack;
		protected float  minDamage;
		protected float  maxDamage;
		protected uint   attackTime0;
		protected uint   attackTime1;
		protected uint   level=1;
		protected uint   displayID;

		protected ArrayList enemy = new ArrayList();
		protected Hashtable hate = new Hashtable();

		public string Name;
        int tickLastRegen;
        int tickAutoMove = 0;
	}

}

/*
loot=1772 9.09
name=Imp Minion
guild=CCCCCCCCCCCCCC
flags=0400002
flags1=0100006
type=4
unk3=23
unk4=2
model=4449
level=62
npcflags=1234
maxhealth=15500
maxmana=3580
faction=73
bounding_radius=0.372000
combat_reach=1.500000
attack=2000 2000
damage=20.857140 86.857140

// update packet

22=3c8c 23=dfc 28=3c8c 29=dfc 34=3e 35=49 36=0 46=1000 131=7d0 132=7d0 134=3ec72b02 135=40400000 136=1161 137=1161 138=0 139=41a6db6c 140=42adb6db 152=4d2 155=0 156=0 157=0 158=0 159=0 160=0 161=0 162=0 163=0 164=0 165=0 167=0 170=1



MSG_MOVE_SET_RAW_POSITION_ACK

*/

// MSG_MOVE_SET_RAW_POSITION_ACK
// {66 2E 21 00 00 00 00 00 00 00 E0 40 }

// MSG_MOVE_TELEPORT_ACK
// {66 2E 21 00 00 00 00 00 00 00 00 00 00 00 00 00 A2 17 EB 44 89 17 CB 44 63 DE BC 42 ED 36 B7 40 }



// MSG_MINIMAP_PING
// {79 2E 21 00 00 00 00 00 8F 56 D1 44 7B AE D1 44 }

// 1 TYPE=0 GUID=212e66 UPDATE { 22=1 180=10}

/* wolf
 0=2B 1=0 2=9 3=12B 4=3F800000 
 22=64 23=14 28=64 29=14 
 34=1 35=1 36=0 46=1000 
 130=2 131=0 132=0 133=0 134=3EC72B02 135=3FC00000 136=1BF 137=1BF 138=0 139=0 140=0 155=0 156=0 157=0 158=0 159=0
 
*/