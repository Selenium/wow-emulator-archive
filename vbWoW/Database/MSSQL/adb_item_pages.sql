SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_item_pages]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_item_pages](
	[pageId] [smallint] NOT NULL DEFAULT ((0)),
	[pageNext] [smallint] NOT NULL DEFAULT ((0)),
	[pageText] [text] NOT NULL,
 CONSTRAINT [PK_adb_item_pages] PRIMARY KEY CLUSTERED 
(
	[pageId] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO