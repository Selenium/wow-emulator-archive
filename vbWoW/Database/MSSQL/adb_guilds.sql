SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_guilds]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_guilds](
	[guild_id] [int] IDENTITY(1,1) NOT NULL,
	[guild_name] [varchar](255) NOT NULL,
	[guild_leader] [int] NOT NULL DEFAULT ((0)),
	[guild_MOTD] [varchar](255) NOT NULL,
	[guild_info] [varchar](255) NOT NULL,
	[guild_cYear] [tinyint] NOT NULL,
	[guild_cMonth] [tinyint] NOT NULL,
	[guild_cDay] [tinyint] NOT NULL,
	[guild_tEmblemStyle] [tinyint] NOT NULL,
	[guild_tEmblemColor] [tinyint] NOT NULL,
	[guild_tBorderStyle] [tinyint] NOT NULL,
	[guild_tBorderColor] [tinyint] NOT NULL,
	[guild_tBackgroundColor] [tinyint] NOT NULL,
	[guild_rank0] [varchar](255) NOT NULL DEFAULT ('Initiate'),
	[guild_rank0_Rights] [int] NOT NULL DEFAULT ((67)),
	[guild_rank1] [varchar](255) NOT NULL DEFAULT ('Officer'),
	[guild_rank1_Rights] [int] NOT NULL DEFAULT ((67)),
	[guild_rank2] [varchar](255) NOT NULL DEFAULT ('Veteran'),
	[guild_rank2_Rights] [int] NOT NULL DEFAULT ((67)),
	[guild_rank3] [varchar](255) NOT NULL DEFAULT ('Officer'),
	[guild_rank3_Rights] [int] NOT NULL DEFAULT ((67)),
	[guild_rank4] [varchar](255) NOT NULL DEFAULT ('Leader'),
	[guild_rank4_Rights] [int] NOT NULL DEFAULT ((61951)),
	[guild_rank5] [varchar](255) NOT NULL,
	[guild_rank5_Rights] [int] NOT NULL DEFAULT ((61951)),
	[guild_rank6] [varchar](255) NOT NULL,
	[guild_rank6_Rights] [int] NOT NULL DEFAULT ((0)),
	[guild_rank7] [varchar](255) NOT NULL,
	[guild_rank7_Rights] [int] NOT NULL DEFAULT ((0)),
	[guild_rank8] [varchar](255) NOT NULL,
	[guild_rank8_Rights] [int] NOT NULL DEFAULT ((0)),
	[guild_rank9] [varchar](255) NOT NULL,
	[guild_rank9_Rights] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_guilds] PRIMARY KEY CLUSTERED 
(
	[guild_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO