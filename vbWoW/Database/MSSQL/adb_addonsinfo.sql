SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_addonsinfo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_addonsinfo](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[addOn_Name] [varchar](255) NOT NULL,
	[addOn_Key] [text] NOT NULL,
	[addOn_State] [tinyint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_addonsinfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO