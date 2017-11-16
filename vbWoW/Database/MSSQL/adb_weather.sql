SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_weather]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_weather](
	[weather_zone] [smallint] NOT NULL DEFAULT ((0)),
	[weather_type] [tinyint] NOT NULL DEFAULT ((0)),
	[weather_intensity] [float] NOT NULL DEFAULT ((0)),
	[weather_aviableTypes] [varchar](255) NOT NULL DEFAULT ('0'),
 CONSTRAINT [PK_adb_weather] PRIMARY KEY CLUSTERED 
(
	[weather_zone] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO