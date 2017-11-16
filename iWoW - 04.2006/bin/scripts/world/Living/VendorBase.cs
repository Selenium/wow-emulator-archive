using System;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class RegisterVendorEvent : WorldEvent
	{
		VendorBase m_vendor;
		public RegisterVendorEvent(VendorBase vendor) : base(TimeSpan.FromSeconds(10))
		{
			m_vendor = vendor;


		}
		

		public override void FireEvent()
		{
			WorldPacket pkg = new WorldPacket(WORLDMSG.REGISTERVENDOR);
			pkg.Write(m_vendor.GUID);
			pkg.Write(m_vendor.Spawn_ID);
			pkg.Write(m_vendor.Level);
			pkg.Write(m_vendor.Name);
			WorldServer.Send(pkg);
		}
	}


	public class VendorBase : UnitBase
	{

		public VendorBase(DBCreature creature) : base(creature)
		{
						
			EventManager.AddEvent(new RegisterVendorEvent(this));

		}	
	}
}
