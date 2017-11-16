CREATE TABLE `ai_agents` (
  `entryId` int(6) NOT NULL default '0',
  `AI_AGENT` int(2) NOT NULL default '0',
  `procEvent` int(2) NOT NULL default '0',
  `procChance` int(3) NOT NULL default '0',
  `procCount` int(6) NOT NULL default '0',
  `spellId` int(6) NOT NULL default '0',
  `spellType` int(2) NOT NULL default '0',
  `spelltargetType` int(2) NOT NULL default '0',
  `spellCooldown` int(8) NOT NULL default '0',
  `floatMisc1` float NOT NULL default '0',
  `Misc2` int(6) NOT NULL default '0',
  PRIMARY KEY  (`entryId`,`AI_AGENT`,`spellId`)
) TYPE=MyISAM