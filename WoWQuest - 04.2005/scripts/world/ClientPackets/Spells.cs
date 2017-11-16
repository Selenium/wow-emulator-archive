using System;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;
using WoWDaemon.World;


namespace WorldScripts.ClientPackets
{
	/// <summary>
	/// Summary description for Combat.
	/// </summary>
	[WorldPacketHandler()]
	public class Spells
	{
		[WorldPacketDelegate(CMSG.CAST_SPELL)]
		static void OnCast(WorldClient client, CMSG msgID, BinReader data)
		{	
			ushort spellId = data.ReadUInt16();
			ushort junk = data.ReadUInt16();
			short flags = data.ReadInt16();
			ulong target = 0;
			ulong targetItem = 0;
			Vector sourceVector = null;
			Vector destinationVector = null;

			if((flags & 0x8802) > 0) target = data.ReadUInt64();
			if((flags & 0x1010) > 0) targetItem = data.ReadUInt64();
			if((flags & 0x20) > 0) sourceVector = data.ReadVector();
			if((flags & 0x40) > 0) destinationVector = data.ReadVector();

			/*
			if(target!=0)
			{
				client.Player.Facing = client.Player.Position.Angle(ObjectManager.GetWorldObjectByGUID(target).Position);
				ServerPacket pkg0 = new ServerPacket(SMSG.MONSTER_MOVE);
				pkg0.Write(client.Player.GUID);
				pkg0.WriteVector(client.Player.Position);
				pkg0.Write(client.Player.Facing);
				pkg0.Write((byte)0x01);
				pkg0.Finish();
				client.Player.MapTile.SendSurrounding(pkg0);
				Console.WriteLine("Tried to set player's Facing =(");
			}
			*/ 

			DBSpell spell = (DBSpell)DBManager.spellsDB[(uint)spellId];
			if(spell==null){Chat.System(client, "Spell:"+spellId+" not found");return;};

			ServerPacket pkg = new ServerPacket(SMSG.SPELL_START);
			pkg.Write((ulong)client.Player.GUID);
			pkg.Write((ulong)client.Player.GUID);
			pkg.Write((short)spellId);
			pkg.Write((UInt16)0); // Just to fill the hole
			pkg.Write(flags);
			pkg.Write((UInt32)spell.CastTime);
			pkg.Write(flags);
			if((flags & 0x8802) > 0)pkg.Write(target);
			if((flags & 0x1010) > 0)pkg.Write(targetItem);
			if((flags & 0x20) > 0)pkg.WriteVector(sourceVector);
			if((flags & 0x40) > 0)pkg.WriteVector(destinationVector);
			pkg.Finish();
			client.Player.MapTile.Map.Send(pkg, client.Player.Position, 25.0f);

			SpellCasting spellcasting = new SpellCasting(client.Player,client,spellId,target,spell.CastTime,flags,destinationVector,spell);


			//client.Player.Aura00 = spellId;
			//client.Player.AuraApplications0 = spellId;
			//client.Player.AuraLevels0 = 1;
		}
		static float GetFacing(Vector pos1, Vector pos2)
		{
			double dx = pos2.X-pos1.X;
			double dy = pos2.Y-pos1.Y;
			return (float)Math.Atan2(dy, dx);
		}
	}
	public class SpellCasting : WorldEvent
	{
		DBSpell spell;
		PlayerObject player;
		WorldClient client;
		ushort spellId;
		ulong target;
		uint casttime;
		short flags;
		ArrayList targetsInRange = null;
		Vector destinationVector;
		public SpellCasting(PlayerObject player, WorldClient client, ushort spellId, ulong target, uint CastTime, short flags, Vector destinationVector, DBSpell spell) : base(TimeSpan.FromMilliseconds(1 + (double)CastTime))
		{
			this.spell = spell;
			this.player = player;
			this.client = client;
			this.spellId = spellId;
			this.target = target;
			this.casttime = CastTime;
			this.flags = flags;
			this.destinationVector = destinationVector;
			EventManager.AddEvent(this);
		}

		public override void FireEvent()
		{
			BinWriter pkg2 = new BinWriter();
			pkg2.Write(spellId);
			pkg2.Write((byte)0);
			pkg2.Write((byte)0);
			pkg2.Write((byte)8);
			client.Send(SMSG.CAST_RESULT, pkg2);

			ServerPacket pkg5 = new ServerPacket(SMSG.SPELL_GO);
			pkg5.Write((ulong)client.Player.GUID);
			pkg5.Write((ulong)client.Player.GUID);
			pkg5.Write((short)spellId);
			pkg5.Write((UInt32)0);

			if((flags & 0x40) > 0)
			{
				targetsInRange = client.Player.MapTile.Map.GetObjectsInRange(OBJECTTYPE.UNIT,destinationVector,25.0f);
				Console.WriteLine("Targets in range :  " + targetsInRange.Count);
				pkg5.Write((byte)targetsInRange.Count);
				IEnumerator e = targetsInRange.GetEnumerator();
				while(e.MoveNext())
				{
					pkg5.Write(((UnitBase)e.Current).GUID);
				}
			}
			else
			{
				pkg5.Write((byte)0x01);
				if(target==0)pkg5.Write(client.Player.GUID);
				else pkg5.Write(target);
			}
			//Missed targets count
			pkg5.Write((byte)0x00);

			//Flag			
			pkg5.Write(flags);

			// If we got a single target spell
			if((flags & 0x8802) > 0)
			{
				if(target==0)pkg5.Write(client.Player.GUID);
				else {pkg5.Write(target);Chat.System(client, "Target:"+target);}
			}

			// If we got an area spell
			if((flags & 0x40) > 0)
			{
				pkg5.WriteVector(destinationVector);
			}
			pkg5.Finish();
			client.Player.MapTile.Map.Send(pkg5, client.Player.Position, 25.0f);
	
			DBSpell spell;

			try
			{
				spell = (DBSpell)DBManager.spellsDB[(uint)spellId];
			}
			catch(Exception e)
			{
				Console.WriteLine("Spell wasn't found in DB !!! Be sure you got the spell DB!");
				Console.WriteLine(e);
				return;
			}
			if(spell==null){Chat.System(client, "Spell:"+spellId+" not found during fire");return;};

			if(spell.Description.IndexOf("damage") > -1 && targetsInRange==null)
			{
				doDamage(target);
			}
			else if(spell.Description.IndexOf("damage") > -1 && targetsInRange!=null)
			{
				IEnumerator e = targetsInRange.GetEnumerator();
				while(e.MoveNext())
				{
					doDamage(((UnitBase)e.Current).GUID);
				}
			}
			else if(spell.Description.IndexOf("heal") > -1 || spell.Description.IndexOf("Heal") > -1)
			{
				int dmg = 0;
				StatManager.CalculateSpellDamage(client.Player, null, spell, out dmg);

				ServerPacket pkg9 = new ServerPacket(SMSG.SPELLNONMELEEDAMAGELOG);
				// Target GUID
				pkg9.Write((ulong)target);
				// Caster GUID
				pkg9.Write((ulong)client.Player.GUID);
				// spellID
				pkg9.Write((short)spellId);
				// Fill the hole
				pkg9.Write((UInt16)0);
				// damage done
				pkg9.Write(dmg);
				// Fill the hole
				pkg9.Write((UInt16)0);
				// flag?
				pkg9.Write((byte)0x01);
				// damage absorbed
				pkg9.Write((UInt32)0);
				pkg9.Write((byte)0);
				pkg9.Write((byte)0);
				// damage blocked
				pkg9.Write((UInt32)0);
				pkg9.Write((byte)0);
				pkg9.Finish();
				client.Player.MapTile.Map.Send(pkg9, client.Player.Position, 25.0f);
//				LivingObject targetObject = (LivingObject)ObjectManager.GetWorldObjectByGUID(target);
//				if((targetObject is PlayerObject)targetObject.Health += dmg;
				PlayerObject targetObject = (PlayerObject)ObjectManager.GetWorldObject(OBJECTTYPE.PLAYER, target);
				if(targetObject!=null)targetObject.Health += dmg;
			}
			
			client.Player.Power -= (int)spell.ManaCost;
			client.Player.UpdateData();
		}

		public void doDamage(ulong GUID)
		{
			int dmg = 0;
			StatManager.CalculateSpellDamage(client.Player, null, spell, out dmg);

			ServerPacket pkg9 = new ServerPacket(SMSG.SPELLNONMELEEDAMAGELOG);
			// Target GUID
			pkg9.Write((ulong)GUID);
			// Caster GUID
			pkg9.Write((ulong)client.Player.GUID);
			// spellID
			pkg9.Write((short)spellId);
			// Fill the hole
			pkg9.Write((UInt16)0);
			// damage done
			pkg9.Write((short)dmg);
			// Fill the hole
			pkg9.Write((UInt16)0);
			// flag?
			pkg9.Write((byte)0x01);
			// damage absorbed
			pkg9.Write((UInt32)0);
			pkg9.Write((byte)0);
			pkg9.Write((byte)0);
			// damage blocked
			pkg9.Write((UInt32)0);
			pkg9.Write((byte)0);
			pkg9.Finish();
				
			client.Player.MapTile.Map.Send(pkg9, client.Player.Position, 25.0f);
			client.Player.UpdateData();

//			LivingObject targetObject = (LivingObject)ObjectManager.GetWorldObjectByGUID(GUID);
//			if (targetObject.ObjectType==OBJECTTYPE.UNIT)

			UnitBase uobj = (UnitBase)ObjectManager.GetWorldObject(OBJECTTYPE.UNIT, GUID);
			if (uobj!=null)
			{
				client.Player.LastPosition=client.Player.Position;;
//				UnitBase uobj = (UnitBase)targetObject;
				if (!uobj.Attacking)
					uobj.StartCombat(client.Player.GUID);

				uobj.DealDamage(client.Player, dmg);

				if (uobj.Dead && this.player.Selection != null && this.player.Selection.GUID == GUID) {
					this.player.StopCombat();
				}
			}
		}
	}
}
