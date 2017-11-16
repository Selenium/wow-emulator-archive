SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_characters_mail]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_characters_mail](
	[mail_id] [smallint] IDENTITY(1,1) NOT NULL,
	[mail_sender] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[mail_receiver] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[mail_type] [tinyint] NOT NULL DEFAULT ((0)),
	[mail_stationery] [smallint] NOT NULL DEFAULT ((41)),
	[mail_subject] [varchar](255) NOT NULL,
	[mail_body] [varchar](255) NOT NULL,
	[mail_item_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[mail_money] [int] NOT NULL DEFAULT ((0)),
	[mail_COD] [smallint] NOT NULL DEFAULT ((0)),
	[mail_time] [smallint] NOT NULL DEFAULT ((30)),
	[mail_read] [tinyint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_characters_mail] PRIMARY KEY CLUSTERED 
(
	[mail_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO