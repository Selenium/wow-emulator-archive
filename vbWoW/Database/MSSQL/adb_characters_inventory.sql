SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_characters_inventory]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_characters_inventory](
	[item_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[item_id] [smallint] NOT NULL DEFAULT ((0)),
	[item_slot] [tinyint] NOT NULL DEFAULT ((255)),
	[item_bag] [bigint] NOT NULL DEFAULT ((-1)),
	[item_owner] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[item_creator] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[item_giftCreator] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[item_stackCount] [tinyint] NOT NULL DEFAULT ((0)),
	[item_durability] [smallint] NOT NULL DEFAULT ((0)),
	[item_flags] [smallint] NOT NULL DEFAULT ((0)),
	[item_chargesLeft] [tinyint] NOT NULL DEFAULT ((0)),
	[item_textId] [smallint] NOT NULL DEFAULT ((0)),
	[item_enchantment] [varchar](255) NOT NULL,
	[item_random_properties] [smallint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_characters_inventory] PRIMARY KEY CLUSTERED 
(
	[item_guid] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO