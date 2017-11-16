SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_trainer_spells]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_trainer_spells](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trainerId] [int] NOT NULL DEFAULT ((0)),
	[spellId] [int] NOT NULL DEFAULT ((0)),
	[spellCost] [int] NOT NULL DEFAULT ((0)),
	[requiredLevel] [tinyint] NOT NULL DEFAULT ((0)),
	[requiredSpell] [int] NOT NULL,
	[requiredSkill] [int] NOT NULL,
	[requiredSkill_Value] [int] NOT NULL,
	[requiredRace] [int] NOT NULL,
	[requiredClass] [int] NOT NULL,
 CONSTRAINT [PK_adb_trainer_spells] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO