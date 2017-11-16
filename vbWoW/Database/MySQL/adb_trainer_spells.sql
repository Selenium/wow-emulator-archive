/*
MySQL Backup
Source Host:           localhost
Source Server Version: 5.0.21-community
Source Database:       awowedb
Date:                  2006.08.12 23:58:17
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_trainer_spells
#----------------------------
CREATE TABLE `adb_trainer_spells` (
  `id` int(11) NOT NULL auto_increment,
  `trainerId` int(11) NOT NULL default '0',
  `spellId` int(11) NOT NULL default '0',
  `spellCost` int(11) NOT NULL default '0',
  `requiredLevel` tinyint(3) unsigned NOT NULL default '0',
  `requiredSpell` int(11) NOT NULL,
  `requiredSkill` int(11) NOT NULL,
  `requiredSkill_Value` int(11) NOT NULL,
  `requiredRace` int(11) NOT NULL,
  `requiredClass` int(11) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;



