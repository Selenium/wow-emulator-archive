/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:37:05
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_addonsinfo
#----------------------------
CREATE TABLE `adb_addonsinfo` (
  `id` smallint(6) NOT NULL auto_increment,
  `addOn_Name` varchar(255) NOT NULL default '',
  `addOn_Key` bigint(20) NOT NULL default '0',
  `addOn_State` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_addonsinfo
#----------------------------


insert  into adb_addonsinfo values 
(1, 'Blizzard_AuctionUI', 0, 2), 
(2, 'Blizzard_BattlefieldMinimap', 0, 2), 
(3, 'Blizzard_BindingUI', 0, 2), 
(4, 'Blizzard_CraftUI', 0, 2), 
(5, 'Blizzard_InspectUI', 0, 2), 
(6, 'Blizzard_MacroUI', 0, 2), 
(7, 'Blizzard_RaidUI', 0, 2), 
(8, 'Blizzard_TalentUI', 0, 2), 
(9, 'Blizzard_TradeSkillUI', 0, 2), 
(10, 'Blizzard_TrainerUI', 0, 2), 
(11, 'LootLink', 0, 1);

