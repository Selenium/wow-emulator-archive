SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for mail
#----------------------------
CREATE TABLE `mail` (
  `mailId` bigint(20) unsigned NOT NULL default '0',
  `sender` bigint(20) unsigned NOT NULL default '0',
  `reciever` bigint(20) unsigned NOT NULL default '0',
  `subject` longtext,
  `body` longtext,
  `item` bigint(20) unsigned NOT NULL default '0',
  `time` bigint(20) unsigned NOT NULL default '0',
  `money` bigint(20) unsigned NOT NULL default '0',
  `COD` bigint(20) unsigned NOT NULL default '0',
  `checked` bigint(20) unsigned NOT NULL default '0',
  PRIMARY KEY  (`mailId`)
) TYPE=MyISAM COMMENT='InnoDB free: 18432 kB';
#----------------------------
# No records for table mail
#----------------------------


