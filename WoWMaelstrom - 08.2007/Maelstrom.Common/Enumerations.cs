using System;

namespace Maelstrom
{
	#region Universal PnP Enumerations

	internal enum UPnPRequestType: int
	{
		AddPortMapping,
		GetGenericPortMappingEntry,
		DeletePortMapping,
		QueryStateVariable,
	}

	internal enum UPnPServiceType: int
	{
		Wan13f,
		WanComm,
		DSLLink,
		WanPPP
	}

	internal enum UPnPStateVariable: int
	{
		DefaultConnectionService,
		WANAccessType,
		Layer1UpstreamMaxBitRate,
		Layer1DownstreamMaxBitRate,
		PhysicalLinkStatus,
		TotalBytesSent,
		TotalBytesReceived,
		TotalPacketsSent,
		TotalPacketsReceived,
		LinkType,
		LinkStatus,
		ModulationType,
		ATMEncapsulation,
		AutoConfig,
		ConnectionType,
		PossibleConnectionTypes,
		ConnectionStatus,
		Uptime,
		UpstreamMaxBitRate,
		DownstreamMaxBitRate,
		RSIPAvailable,
		NATEnabled,
		LastConnectionError,
		ExternalIPAddress,
		RemoteHost,
		ExternalPort,
		InternalPort,
		PortMappingProtocol,
		InternalClient,
		PortMappingDescription,
		PortMappingEnabled,
		PortMappingLeaseDuration,
		PortMappingNumberOfEntries,
		Last
	}

	#endregion
}
