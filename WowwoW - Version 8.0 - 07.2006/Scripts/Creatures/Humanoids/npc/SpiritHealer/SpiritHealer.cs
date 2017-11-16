using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class ConnorMcCoy : BaseCreature
	{
		public ConnorMcCoy() : base()
		{
			Name = "Connor McCoy";
			Guild="Spirit Healer";
			Id = 2289;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
} 


namespace Server.Creatures
{
	public class BertranKeldrake : BaseCreature
	{
		public BertranKeldrake() : base()
		{
			Name = "Bertran Keldrake";
			Guild="Spirit Healer";
			Id = 2290;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
} 


namespace Server.Creatures
{
	public class ReginaldBerry : BaseCreature
	{
		public ReginaldBerry() : base()
		{
			Name = "Reginald Berry";
			Guild="Spirit Healer";
			Id = 2292;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;			
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
} 


namespace Server.Creatures
{
	public class SherraVayne : BaseCreature
	{
		public SherraVayne() : base()
		{
			Name = "Sherra Vayne";
			Guild="Spirit Healer";
			Id = 2293;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;	
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
} 


namespace Server.Creatures
{
	public class JayniceSillestan : BaseCreature
	{
		public JayniceSillestan() : base()
		{
			Name = "Jaynice Sillestan";
			Guild="Spirit Healer";
			Id = 2294;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
} 


namespace Server.Creatures
{
	public class BartokSteelgrip : BaseCreature
	{
		public BartokSteelgrip() : base()
		{
			Name = "Bartok Steelgrip";
			Guild="Spirit Healer";
			Id = 2295;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
} 


namespace Server.Creatures
{
	public class FulgarIceforge : BaseCreature
	{
		public FulgarIceforge() : base()
		{
			Name = "Fulgar Iceforge";
			Guild="Spirit Healer";
			Id = 2296;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
}


namespace Server.Creatures
{
	public class KerrikFirebeard : BaseCreature
	{
		public KerrikFirebeard() : base()
		{
			Name = "Kerrik Firebeard";
			Guild="Spirit Healer";
			Id = 2297;
			Model = 262;
			Flags1 = 0x0A00066;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
}


namespace Server.Creatures
{
	public class SpiritHealer : BaseCreature
	{
		public SpiritHealer() : base()
		{
			Name = "Spirit Healer";
			Guild="Spirit Healer";
			Id = 6491;
			Model = 5233;
			Flags1 = 0x0280166;
			NpcFlags = (int)NpcActions.SpiritHealer;
			Level = RandomLevel(60);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 2052;
			BaseMana = 2033;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Friend;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnGossipHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}
	}
}
