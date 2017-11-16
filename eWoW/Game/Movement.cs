using System;

namespace eWoW
{
	/// <summary>
	/// Movement 的摘要说明。
	/// </summary>
	public class MovementHandler
	{
		public MovementHandler(PlayerConnection c)
		{
			c.AddHandler(OP.CMSG_STANDSTATECHANGE, new DoMessageFunction(StandStateChange), c.player);
			c.AddHandler(OP.CMSG_SETSHEATHED, new DoMessageFunction(SheatheTypeChange), c.player);
			c.AddHandler(OP.MSG_MOVE_JUMP, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_FORWARD, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_BACKWARD, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_SET_FACING, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_STOP, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_STRAFE_LEFT, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_STRAFE_RIGHT, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_STOP_STRAFE, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_TURN_LEFT, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_TURN_RIGHT, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_STOP_TURN, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_PITCH_UP, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_PITCH_DOWN, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_STOP_PITCH, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_SET_RUN_MODE, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_SET_WALK_MODE, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_SET_PITCH, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_START_SWIM, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_STOP_SWIM, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_HEARTBEAT, new DoMessageFunction(MoveChange), c.player);
			c.AddHandler(OP.MSG_MOVE_FALL_LAND, new DoMessageFunction(MoveChange), c.player);
		}

		void SheatheTypeChange(OP code, PlayerConnection c)
		{
			uint anim;
			c.Seek(2).Get(out anim);
			c.Log("{0} {1}", code, (SheatheType)anim);

			uint n=c.player.GetUpdateValue(UpdateFields.UNIT_FIELD_BYTES_1);
			n = (uint) ( (n&0xffff00ff) | (anim<<8) );

			c.player.SetUpdateValue(UpdateFields.UNIT_FIELD_BYTES_1, n);
		}


		void StandStateChange(OP code, PlayerConnection c)
		{
			uint anim;
			c.Seek(2).Get(out anim);
			c.Log("{0} {1}", code, (UnitStandState)anim);

			if((UnitStandState)anim!=UnitStandState.SITTING)
				c.player.LogoutCancel();

			c.player.SetUpdateValue(UpdateFields.UNIT_NPC_EMOTESTATE, (uint)anim);
		}

		void MoveChange(OP code, PlayerConnection c)
		{
			uint flags;
			float u;
			float[] data=new float[4];
			c.Seek(2).
				Get(out flags).Get(out u).Get(out data[0]).
				Get(out data[1]).Get(out data[2]).Get(out data[3]);

			c.player.SetPosition(data);


			// c.Log("{0} {1}", code, c.player.Orientation);

			if(code==OP.MSG_MOVE_HEARTBEAT)return;

			ByteArrayBuilder pack=new ByteArrayBuilder(false);
			pack.Add(c.player.GUID);
			pack.Add(flags);
			pack.Add(u);
			pack.Add(data);
			c.player.SendMessageToSet(code, pack, false);
		}
	}
}


// to new world
//[7106187 1c17e00] CODE=3F LEN=4 {00 00 00 00 }
//[7106187 1c17e00] CODE=3E LEN=20 {00 00 00 00 9A 57 26 C6 EC 61 93 44 60 B6 40 42 CD CC CC 3D }
