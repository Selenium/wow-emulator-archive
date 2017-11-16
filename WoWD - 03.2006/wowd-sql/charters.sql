SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for charters
#----------------------------
CREATE TABLE `charters` (
  `leaderGuid` bigint(20) NOT NULL default '0',
  `guildName` varchar(32) NOT NULL default '',
  `itemGuid` bigint(20) NOT NULL default '0',
  `signCount` int(11) NOT NULL default '0',  
  `signer1` int(10) unsigned NOT NULL default '0',
  `signer2` int(10) unsigned NOT NULL default '0',
  `signer3` int(10) unsigned NOT NULL default '0',
  `signer4` int(10) unsigned NOT NULL default '0',
  `signer5` int(10) unsigned NOT NULL default '0',
  `signer6` int(10) unsigned NOT NULL default '0',
  `signer7` int(10) unsigned NOT NULL default '0',
  `signer8` int(10) unsigned NOT NULL default '0',
  `signer9` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`leaderGuid`),
  UNIQUE KEY `leaderGuid` (`leaderGuid`)
) TYPE=MyISAM COMMENT='InnoDB free: 11264 kB; InnoDB free: 18432 kB';
#----------------------------
# Records for table charters
#----------------------------