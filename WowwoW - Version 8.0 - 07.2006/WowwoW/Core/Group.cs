using System;
using System.Collections;
using HelperTools;


namespace Server
{
	public enum LootMethod
	{
		FreeForAll =0 ,
		RoundRobin = 1,
		MasterLooter = 2,
		GroupLoot = 3,
		NeedBeforeGreed = 4
	}
	/// <summary>
	/// Summary description for Group.
	/// </summary>
	public class Group
	{
		ArrayList members = new ArrayList();
		Member groupLeader;

			
		public Group()
		{
			members = new ArrayList();
		}
		public void Add( Character c )
		{
			Add( c, 0x1 );			
		}
		public void Add( Character c, ushort droit )
		{
			Member m = new Member( c );
			m.Droits = droit;
			members.Add( m );
			if ( Count == 1 )
				groupLeader = m;
			else
				UpdateList();
		}
		void UpdateList()
		{
			foreach( Member to in Members )
			{
				int offset = 4;
				Converter.ToBytes( (short)0, groupLeader.Char.tempBuff, ref offset );
				Converter.ToBytes( Count, groupLeader.Char.tempBuff, ref offset );
				int n = 0;
				foreach( Member m in Members )
				{
					Converter.ToBytes( m.Char.Name, groupLeader.Char.tempBuff, ref offset );
					Converter.ToBytes( (byte)0, groupLeader.Char.tempBuff, ref offset );
					Converter.ToBytes( m.Char.Guid, groupLeader.Char.tempBuff, ref offset );
					if ( to == m )
						Converter.ToBytes( (ushort)0x101, groupLeader.Char.tempBuff, ref offset );					
					else
						Converter.ToBytes( (ushort)0x1, groupLeader.Char.tempBuff, ref offset );					
					n++;
				}
				Converter.ToBytes( GroupLeader.Char.Guid, groupLeader.Char.tempBuff, ref offset );
				Converter.ToBytes( (byte)0, groupLeader.Char.tempBuff, ref offset );
				Converter.ToBytes( GroupLeader.Char.Guid, groupLeader.Char.tempBuff, ref offset );
				Converter.ToBytes( (byte)0, groupLeader.Char.tempBuff, ref offset );
			
				to.Char.Send( OpCodes.SMSG_GROUP_LIST, groupLeader.Char.tempBuff, offset );
			}
		}
		public void PromoteLeader( Character c )
		{
			foreach( Member to in Members )
			{
				int offset = 4;
				Converter.ToBytes( to.Char.Name, groupLeader.Char.tempBuff, ref offset );
				Converter.ToBytes( (byte)0, groupLeader.Char.tempBuff, ref offset );
				to.Char.Send( OpCodes.SMSG_GROUP_SET_LEADER, groupLeader.Char.tempBuff, offset );
				if ( c == to.Char )
					groupLeader = to;
			}			
			UpdateList();
		}
		public void Quit( Character c )
		{
			if ( members == null )
				return;
			ArrayList al = new ArrayList();
			foreach( Member m in members )
			{
				if ( m.Char == c )
				{					
					c.Send( OpCodes.SMSG_GROUP_DESTROYED, c.tempBuff, 4 );
				}
				else
				{
				//	Console.WriteLine("Stay in group {0}", m.Char.Name );
					al.Add( m );
				}
			}
			members = al;
			if ( Count > 1 )
			{
				if ( groupLeader.Char == c )
					groupLeader = (Member)al[ 0 ];
				UpdateList();
			}
			else
				if ( Count == 1 )
			{
				( members[ 0 ] as Member ).Char.Send( OpCodes.SMSG_GROUP_DESTROYED, c.tempBuff, 4 );
				( members[ 0 ] as Member ).Char.QuitGroup();				
			}
		}
		public Member GroupLeader
		{
			get { return groupLeader; }
		}
		public int Count
		{
			get { return members.Count; }
		}
		public ArrayList Members
		{
			get { return members; }
		}
	}

	public class Member
	{
		Character character;
		ushort droits = 0x1;
		public Member( Character c )
		{
			character = c;
		}
		public Character Char
		{
			get { return character; }
		}
		public ushort Droits
		{
			get { return droits; }
			set { droits = value; }
		}
	}

}
