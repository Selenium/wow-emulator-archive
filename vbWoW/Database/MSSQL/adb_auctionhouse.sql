SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_auctionhouse]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_auctionhouse](
	[auction_id] [int] IDENTITY(1,1) NOT NULL,
	[auction_bid] [int] NOT NULL,
	[auction_buyout] [int] NOT NULL,
	[auction_timeleft] [int] NOT NULL,
	[auction_deposit] [int] NOT NULL DEFAULT ((0)),
	[auction_bidder] [int] NOT NULL DEFAULT ((0)),
	[auction_owner] [int] NOT NULL,
	[auction_itemId] [int] NOT NULL,
	[auction_itemCount] [smallint] NOT NULL DEFAULT ((0)),
	[auction_itemGUID] [int] NOT NULL,
 CONSTRAINT [PK_adb_auctionhouse] PRIMARY KEY CLUSTERED 
(
	[auction_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO