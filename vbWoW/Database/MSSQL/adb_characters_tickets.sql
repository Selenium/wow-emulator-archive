SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_characters_tickets]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_characters_tickets](
	[char_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[ticket_text] [text] NOT NULL,
	[ticket_category] [tinyint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_characters_tickets] PRIMARY KEY CLUSTERED 
(
	[char_guid] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO