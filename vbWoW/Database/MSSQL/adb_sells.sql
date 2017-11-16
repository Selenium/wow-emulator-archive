SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_sells]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_sells](
	[sell_id] [int] IDENTITY(1,1) NOT NULL,
	[sell_item] [int] NOT NULL DEFAULT ((0)),
	[sell_count] [tinyint] NOT NULL DEFAULT ((1)),
	[sell_group] [smallint] NOT NULL DEFAULT ((0)),
	[sell_price] [smallint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_sells] PRIMARY KEY CLUSTERED 
(
	[sell_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO