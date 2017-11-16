SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_guilds_petition]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_guilds_petition](
	[petition_id] [int] NOT NULL,
	[petition_itemGuid] [int] NOT NULL,
	[petition_owner] [int] NOT NULL,
	[petition_name] [varchar](255) NOT NULL,
	[petition_signedMembers] [tinyint] NOT NULL,
	[petition_signedMember1] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember2] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember3] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember4] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember5] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember6] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember7] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember8] [int] NOT NULL DEFAULT ((0)),
	[petition_signedMember9] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_guilds_petition] PRIMARY KEY CLUSTERED 
(
	[petition_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO